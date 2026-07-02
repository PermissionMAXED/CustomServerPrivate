param(
    [int]$ServerPort = 5161,
    [int]$LeaderCharId = 15,
    [int]$BotCount = 7,
    [int]$GameServerReadyTimeoutSeconds = 160,
    [int]$MatchRunSeconds = 70
)

# Fully HEADLESS match verification: host AND client both run -batchmode -nographics (NO visible
# game window), so the network-driven in-game features (F165 auto-join, F166 autoplay, F172 NetTune)
# execute and log their markers without opening a window. Visual features (F183 model, F185 VFX
# look) are NOT covered here. Run once; not a loop.

$ErrorActionPreference = "Stop"
$Root = Resolve-Path (Join-Path $PSScriptRoot "..")
$ServerDll = Join-Path $Root "CustomMatchServer\bin\Release\net10.0\BapCustomServer.dll"
$GameDir = Join-Path $Root "Spiel\Battleroyalebuild"
$GameExe = Join-Path $GameDir "bapbap.exe"
$LogDir = Join-Path $Root "CustomMatchServer\logs\game-servers"
$HostUnityLog = Join-Path $LogDir "hl-HOST.unity.log"
$ClientLog = Join-Path $LogDir "hl-client.log"
$MatchHostArgs = "-logFile `"$HostUnityLog`" --melonloader.agfoffline --melonloader.captureplayerlogs --bapcustom-host=127.0.0.1 --bapcustom-server-port=$ServerPort --bapcustom-use-proxy=false --bapcustom-show-ui=false"

function Test-PortFree([int]$Port) {
    $c = [System.Net.Sockets.TcpClient]::new()
    try { $t = $c.ConnectAsync("127.0.0.1", $Port); $o = $t.Wait(250); return -not ($o -and $c.Connected) } catch { return $true } finally { $c.Dispose() }
}
function Start-TestServer {
    $psi = [System.Diagnostics.ProcessStartInfo]::new()
    $psi.FileName = "dotnet"; $psi.Arguments = "`"$ServerDll`""; $psi.WorkingDirectory = $Root
    $psi.UseShellExecute = $false; $psi.CreateNoWindow = $true
    $psi.EnvironmentVariables["ASPNETCORE_URLS"] = "http://127.0.0.1:$ServerPort"
    $psi.EnvironmentVariables["CustomServer__PublicBaseUrl"] = "http://127.0.0.1:$ServerPort"
    $psi.EnvironmentVariables["CustomServer__Admin__AllowLoopbackAdminWithoutToken"] = "true"
    $psi.EnvironmentVariables["CustomServer__LaunchGameServers"] = "true"
    $psi.EnvironmentVariables["CustomServer__RequireGameServerBootstrap"] = "true"
    $psi.EnvironmentVariables["CustomServer__GameServerStartAttempts"] = "1"
    # Disable prewarm: it spawns a SECOND bapbap.exe ~2s after server start that collides with the
    # match-host launch on MelonLoader's shared working files -> both abort at 'Failed to initialize'.
    $psi.EnvironmentVariables["CustomServer__GameServerPrewarmOnStartup"] = "false"
    # Drop -logFile from HeadlessArguments: appsettings ships it, and MatchHostArgs adds another, so
    # the spawned host gets TWO -logFile flags (the one structural diff vs a working standalone launch).
    $psi.EnvironmentVariables["CustomServer__HeadlessArguments"] = "-batchmode -nographics -httpport={httpPort} -wsport={wsPort} -kcpport={kcpPort} -tcpport={tcpPort}"
    $psi.EnvironmentVariables["CustomServer__GameServerReadyTimeoutSeconds"] = $GameServerReadyTimeoutSeconds.ToString()
    $psi.EnvironmentVariables["CustomServer__GameExecutablePath"] = $GameExe
    $psi.EnvironmentVariables["CustomServer__GameWorkingDirectory"] = $GameDir
    $psi.EnvironmentVariables["CustomServer__GameLogDirectory"] = $LogDir
    $psi.EnvironmentVariables["CustomServer__AdditionalGameArguments"] = $MatchHostArgs
    return [System.Diagnostics.Process]::Start($psi)
}
function Wait-Health { $d = [DateTime]::UtcNow.AddSeconds(20); do { try { return Invoke-RestMethod "http://127.0.0.1:$ServerPort/health" } catch { Start-Sleep -Milliseconds 300 } } while ([DateTime]::UtcNow -lt $d); throw "no server health" }
function New-Sock([string]$AccountId, [string]$Username) {
    $s = [System.Net.WebSockets.ClientWebSocket]::new()
    $u = [Uri]"ws://127.0.0.1:$ServerPort/ws?accountId=$AccountId&username=$Username"
    $c = $s.ConnectAsync($u, [Threading.CancellationToken]::None); if (-not $c.Wait(6000)) { throw "ws connect timeout $AccountId" }; if ($c.IsFaulted) { throw $c.Exception }
    return $s
}
function Send-Ws($Socket, $Message) {
    $j = $Message | ConvertTo-Json -Compress -Depth 20; $b = [System.Text.Encoding]::UTF8.GetBytes($j); $seg = [ArraySegment[byte]]::new($b)
    $t = $Socket.SendAsync($seg, [System.Net.WebSockets.WebSocketMessageType]::Text, $true, [Threading.CancellationToken]::None); if (-not $t.Wait(5000)) { throw "ws send timeout" }; if ($t.IsFaulted) { throw $t.Exception }
}
function Recv-Ws($Socket, [int]$TimeoutMs = 5000) {
    $buf = New-Object byte[] 65536; $ms = [System.IO.MemoryStream]::new()
    try { do { $seg = [ArraySegment[byte]]::new($buf); $t = $Socket.ReceiveAsync($seg, [Threading.CancellationToken]::None); if (-not $t.Wait($TimeoutMs)) { throw "ws recv timeout" }; if ($t.IsFaulted) { throw $t.Exception }; $r = $t.Result; if ($r.MessageType -eq [System.Net.WebSockets.WebSocketMessageType]::Close) { throw "ws closed" }; $ms.Write($buf, 0, $r.Count) } while (-not $r.EndOfMessage); return ([System.Text.Encoding]::UTF8.GetString($ms.ToArray()) | ConvertFrom-Json) } finally { $ms.Dispose() }
}
function Recv-Until($Socket, [string[]]$Events, [int]$Max = 300, [int]$TimeoutMs = 5000) {
    $seen = @(); for ($i = 0; $i -lt $Max; $i++) { $m = Recv-Ws $Socket $TimeoutMs; $seen += $m.event; if ($Events -contains $m.event) { return [pscustomobject]@{Message = $m; Seen = $seen } } }
    throw "did not see: $($Events -join ',') seen: $($seen -join ',')"
}
function Start-HeadlessClient($Payload) {
    # Args as an ARRAY -> no embedded-quote fragility. -batchmode -nographics => no window.
    $clientArgs = @(
        "-batchmode", "-nographics",
        "-logFile", $ClientLog,
        "--melonloader.agfoffline", "--melonloader.captureplayerlogs",
        "--bapcustom-use-proxy=false", "--bapcustom-show-ui=false",
        "--bapcustom-host=127.0.0.1", "--bapcustom-server-port=$ServerPort",
        "--bapcustom-autoplay", "--bapcustom-auto-select-augments",
        "--bapcustom-selected-char=$LeaderCharId",
        "--bapcustom-join-auth=$($Payload.gameAuthId)",
        "--bapcustom-join-host=$($Payload.gameDns)",
        "--bapcustom-join-ws=$($Payload.wsPort)",
        "--bapcustom-join-kcp=$($Payload.kcpPort)",
        "--bapcustom-join-tcp=$($Payload.tcpPort)"
    )
    return Start-Process -FilePath $GameExe -WorkingDirectory $GameDir -ArgumentList $clientArgs -WindowStyle Hidden -PassThru
}

if (-not (Test-Path $ServerDll)) { throw "build CustomMatchServer first: $ServerDll missing" }
Remove-Item $HostUnityLog, $ClientLog -ErrorAction SilentlyContinue

$server = $null; $startedServer = $false; $client = $null
if (Test-PortFree $ServerPort) { Write-Host "starting local server :$ServerPort"; $server = Start-TestServer; $startedServer = $true; Wait-Health | Out-Null } else { Write-Host "reusing server :$ServerPort" }
$leaderSock = $null
try {
    $leaderSock = New-Sock "hl-leader" "hl-leader"
    Recv-Until $leaderSock @("SOCKET_READY") | Out-Null
    Send-Ws $leaderSock @{ event = "JOIN_LOBBY"; payload = @{ lobbyId = "HLSOLO"; charId = $LeaderCharId; regionId = "custom"; gameModeId = 0; isAutoFill = $false } }
    Recv-Until $leaderSock @("JOIN_LOBBY_SUCCESS") 80 15000 | Out-Null
    Send-Ws $leaderSock @{ event = "UPDATE_CUSTOM_SETTINGS"; payload = @{ settings = @{ gamemode = 1; mapId = 1; teamSize = 2; maxTeams = 4; botCount = $BotCount; botDifficulty = 1 } } }
    Recv-Until $leaderSock @("UPDATE_CUSTOM_SETTINGS_SUCCESS") | Out-Null
    Send-Ws $leaderSock @{ event = "START_CUSTOM_GAME"; payload = @{ forceStart = $true } }
    $tmo = [Math]::Max(40000, ($GameServerReadyTimeoutSeconds + 40) * 1000)
    $ls = Recv-Until $leaderSock @("START_CUSTOM_GAME_FAIL", "GAME_STARTED") 300 $tmo
    if ($ls.Message.event -ne "GAME_STARTED") { throw "no GAME_STARTED (got $($ls.Message.event))" }
    Write-Host "GAME_STARTED dns=$($ls.Message.payload.gameDns) ws=$($ls.Message.payload.wsPort) - launching HEADLESS autoplay client"
    $client = Start-HeadlessClient $ls.Message.payload
    Write-Host "headless client pid=$($client.Id); running match ${MatchRunSeconds}s for auto-join/autoplay/nettune"
    Start-Sleep -Seconds $MatchRunSeconds
}
finally {
    if ($leaderSock) { try { $leaderSock.Abort(); $leaderSock.Dispose() } catch {} }
    if ($client -and -not $client.HasExited) { try { Stop-Process -Id $client.Id -Force -ErrorAction SilentlyContinue } catch {} }
    Get-Process bapbap -ErrorAction SilentlyContinue | Stop-Process -Force -ErrorAction SilentlyContinue
    if ($startedServer -and $server -and -not $server.HasExited) { try { Stop-Process -Id $server.Id -Force -ErrorAction SilentlyContinue } catch {} }
}
Write-Host "match complete"
Write-Host "client log $ClientLog"
Write-Host "host log $HostUnityLog"

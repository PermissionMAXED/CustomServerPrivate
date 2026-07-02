param(
    [int]$ServerPort = 5174,
    [int]$CharId = 0,
    [int]$BotCount = 3,
    [int]$GameServerReadyTimeoutSeconds = 180,
    [int]$ClientObserveSeconds = 180
)

$ErrorActionPreference = "Stop"
$Root = Resolve-Path (Join-Path $PSScriptRoot "..")
$ServerDll = Join-Path $Root "CustomMatchServer\bin\Release\net10.0\BapCustomServer.dll"
$GameDir = Join-Path $Root "Spiel\Battleroyalebuild"
$GameExe = Join-Path $GameDir "bapbap.exe"
$LogDir = Join-Path $Root "CustomMatchServer\logs\game-servers"
$Stamp = Get-Date -Format "yyyyMMdd-HHmmss"
$HostLog = Join-Path $LogDir "postmatch-cleanup-HOST-$Stamp.log"
$ClientLog = Join-Path $LogDir "postmatch-cleanup-client-$Stamp.log"

function Test-PortFree([int]$Port) {
    $client = [System.Net.Sockets.TcpClient]::new()
    try {
        $task = $client.ConnectAsync("127.0.0.1", $Port)
        $open = $task.Wait(250) -and $client.Connected
        return -not $open
    }
    catch { return $true }
    finally { $client.Dispose() }
}

function Start-TestServer {
    $psi = [System.Diagnostics.ProcessStartInfo]::new()
    $psi.FileName = "dotnet"
    $psi.Arguments = "`"$ServerDll`""
    $psi.WorkingDirectory = $Root
    $psi.UseShellExecute = $false
    $psi.CreateNoWindow = $true
    $psi.EnvironmentVariables["ASPNETCORE_URLS"] = "http://127.0.0.1:$ServerPort"
    $psi.EnvironmentVariables["CustomServer__PublicBaseUrl"] = "http://127.0.0.1:$ServerPort"
    $psi.EnvironmentVariables["CustomServer__Admin__AllowLoopbackAdminWithoutToken"] = "true"
    $psi.EnvironmentVariables["CustomServer__LaunchGameServers"] = "true"
    $psi.EnvironmentVariables["CustomServer__RequireGameServerBootstrap"] = "true"
    $psi.EnvironmentVariables["CustomServer__GameServerPrewarmOnStartup"] = "false"
    $psi.EnvironmentVariables["CustomServer__GameServerStartAttempts"] = "1"
    $psi.EnvironmentVariables["CustomServer__GameServerReadyTimeoutSeconds"] = $GameServerReadyTimeoutSeconds.ToString()
    $psi.EnvironmentVariables["CustomServer__GameExecutablePath"] = $GameExe
    $psi.EnvironmentVariables["CustomServer__GameWorkingDirectory"] = $GameDir
    $psi.EnvironmentVariables["CustomServer__GameLogDirectory"] = $LogDir
    $psi.EnvironmentVariables["CustomServer__HeadlessArguments"] = "-batchmode -nographics -httpport={httpPort} -wsport={wsPort} -kcpport={kcpPort} -tcpport={tcpPort}"
    $psi.EnvironmentVariables["CustomServer__AdditionalGameArguments"] = "-logFile `"$HostLog`" --melonloader.agfoffline --melonloader.captureplayerlogs --bapcustom-host=127.0.0.1 --bapcustom-server-port=$ServerPort --bapcustom-use-proxy=false --bapcustom-show-ui=false --bapcustom-auto-end-after=8"
    return [System.Diagnostics.Process]::Start($psi)
}

function Wait-Health {
    $deadline = [DateTime]::UtcNow.AddSeconds(25)
    do {
        try { return Invoke-RestMethod "http://127.0.0.1:$ServerPort/health" -TimeoutSec 3 }
        catch { Start-Sleep -Milliseconds 300 }
    } while ([DateTime]::UtcNow -lt $deadline)
    throw "server did not become healthy"
}

function New-Socket([string]$AccountId, [string]$Username) {
    $socket = [System.Net.WebSockets.ClientWebSocket]::new()
    $uri = [Uri]"ws://127.0.0.1:$ServerPort/ws?accountId=$AccountId&username=$Username"
    $task = $socket.ConnectAsync($uri, [Threading.CancellationToken]::None)
    if (-not $task.Wait(8000)) { throw "websocket connect timed out" }
    if ($task.IsFaulted) { throw $task.Exception }
    return $socket
}

function Send-Ws($Socket, [object]$Message) {
    $json = $Message | ConvertTo-Json -Compress -Depth 20
    $bytes = [System.Text.Encoding]::UTF8.GetBytes($json)
    $task = $Socket.SendAsync([ArraySegment[byte]]::new($bytes), [System.Net.WebSockets.WebSocketMessageType]::Text, $true, [Threading.CancellationToken]::None)
    if (-not $task.Wait(5000)) { throw "websocket send timed out" }
    if ($task.IsFaulted) { throw $task.Exception }
}

function Receive-Ws($Socket, [int]$TimeoutMs = 5000) {
    $buffer = New-Object byte[] 65536
    $stream = [System.IO.MemoryStream]::new()
    try {
        do {
            $task = $Socket.ReceiveAsync([ArraySegment[byte]]::new($buffer), [Threading.CancellationToken]::None)
            if (-not $task.Wait($TimeoutMs)) { throw "websocket receive timed out" }
            if ($task.IsFaulted) { throw $task.Exception }
            $result = $task.Result
            if ($result.MessageType -eq [System.Net.WebSockets.WebSocketMessageType]::Close) { throw "websocket closed" }
            $stream.Write($buffer, 0, $result.Count)
        } while (-not $result.EndOfMessage)
        return [System.Text.Encoding]::UTF8.GetString($stream.ToArray()) | ConvertFrom-Json
    }
    finally { $stream.Dispose() }
}

function Receive-Until($Socket, [string[]]$Events, [int]$Max = 120, [int]$TimeoutMs = 5000) {
    $seen = @()
    for ($i = 0; $i -lt $Max; $i++) {
        $message = Receive-Ws $Socket $TimeoutMs
        $seen += $message.event
        if ($Events -contains $message.event) {
            return $message
        }
    }
    throw "did not see $($Events -join ','); saw $($seen -join ',')"
}

function Start-VisibleClient($Payload) {
    $args = @(
        "-logFile", $ClientLog,
        "--melonloader.agfoffline", "--melonloader.captureplayerlogs",
        "--bapcustom-use-proxy=false", "--bapcustom-show-ui=false",
        "--bapcustom-host=127.0.0.1", "--bapcustom-server-port=$ServerPort",
        "--bapcustom-account-id=postmatch-client", "--bapcustom-username=PostMatchClient",
        "--bapcustom-selected-char=$CharId", "--bapcustom-autoplay", "--bapcustom-auto-select-augments",
        "--bapcustom-join-auth=$($Payload.gameAuthId)",
        "--bapcustom-join-host=$($Payload.gameDns)",
        "--bapcustom-join-ws=$($Payload.wsPort)",
        "--bapcustom-join-kcp=$($Payload.kcpPort)",
        "--bapcustom-join-tcp=$($Payload.tcpPort)"
    )
    return Start-Process -FilePath $GameExe -WorkingDirectory $GameDir -ArgumentList $args -WindowStyle Normal -PassThru
}

if (-not (Test-Path -LiteralPath $ServerDll)) { throw "missing server DLL: $ServerDll" }
if (-not (Test-Path -LiteralPath $GameExe)) { throw "missing game exe: $GameExe" }
New-Item -ItemType Directory -Force -Path $LogDir | Out-Null
Remove-Item -LiteralPath $HostLog, $ClientLog -ErrorAction SilentlyContinue

$server = $null
$client = $null
$socket = $null
try {
    Get-Process bapbap -ErrorAction SilentlyContinue | Stop-Process -Force -ErrorAction SilentlyContinue
    if (-not (Test-PortFree $ServerPort)) { throw "port $ServerPort is already in use" }

    Write-Host "[start] local server :$ServerPort"
    $server = Start-TestServer
    Wait-Health | Out-Null

    $socket = New-Socket "custom-382jfI238ALO" "Sonic0810"
    Send-Ws $socket @{ event = "SOCKET_READY"; payload = @{} }
    Receive-Until $socket @("SOCKET_READY") 40 15000 | Out-Null
    Write-Host "[ws] socket ready"
    Send-Ws $socket @{ event = "JOIN_LOBBY"; payload = @{ lobbyId = ""; charId = $CharId; regionId = "custom"; gameModeId = 0; isAutoFill = $false } }
    Receive-Until $socket @("JOIN_LOBBY_SUCCESS") 120 30000 | Out-Null
    Write-Host "[ws] lobby joined"
    Send-Ws $socket @{ event = "START_CUSTOM_GAME"; payload = @{ forceStart = $true } }
    $timeout = [Math]::Max(40000, ($GameServerReadyTimeoutSeconds + 40) * 1000)
    $started = Receive-Until $socket @("START_CUSTOM_GAME_FAIL", "GAME_STARTED") 240 $timeout
    if ($started.event -ne "GAME_STARTED") {
        $payloadJson = $started.payload | ConvertTo-Json -Compress -Depth 20
        throw "match did not start: $($started.event) payload=$payloadJson"
    }

    Write-Host "[client] launch visible client from $GameExe"
    $client = Start-VisibleClient $started.payload

    $deadline = [DateTime]::UtcNow.AddSeconds($ClientObserveSeconds)
    $closed = $false
    $returnedToLobby = $false
    do {
        Start-Sleep -Seconds 2
        if (Test-Path -LiteralPath $ClientLog) {
            $closed = [bool](Select-String -LiteralPath $ClientLog -Pattern "[PreMatchCleanup] Dismissed" -SimpleMatch -Quiet)
            $returned = [bool](Select-String -LiteralPath $ClientLog -Pattern "[LobbyReturnFallback] Client still in non-lobby scene" -SimpleMatch -Quiet)
            $returnedToLobby = [bool](Select-String -LiteralPath $ClientLog -Pattern "Opening Lobby UI :)" -SimpleMatch -Quiet)
            if ($returned) { $closed = $true }
            if ($closed -or $returnedToLobby) { break }
        }
    } while ([DateTime]::UtcNow -lt $deadline -and $client -and -not $client.HasExited)

    $hostEnded = (Test-Path -LiteralPath $HostLog) -and [bool](Select-String -LiteralPath $HostLog -Pattern "Requested dedicated match auto-end" -SimpleMatch -Quiet)
    $clientJoined = (Test-Path -LiteralPath $ClientLog) -and [bool](Select-String -LiteralPath $ClientLog -Pattern "Requested matchmaking client connect" -SimpleMatch -Quiet)
    $cleanupArmed = (Test-Path -LiteralPath $ClientLog) -and [bool](Select-String -LiteralPath $ClientLog -Pattern "[PreMatchCleanup-DIAG] Armed" -SimpleMatch -Quiet)
    $lobbyReturnFallback = (Test-Path -LiteralPath $ClientLog) -and [bool](Select-String -LiteralPath $ClientLog -Pattern "[LobbyReturnFallback] Client still in non-lobby scene" -SimpleMatch -Quiet)
    $returnedToLobby = (Test-Path -LiteralPath $ClientLog) -and [bool](Select-String -LiteralPath $ClientLog -Pattern "Opening Lobby UI :)" -SimpleMatch -Quiet)

    Write-Host "[logs] host=$HostLog"
    Write-Host "[logs] client=$ClientLog"
    Write-Host "[assert] clientJoined=$clientJoined hostAutoEnded=$hostEnded returnedToLobby=$returnedToLobby cleanupArmed=$cleanupArmed cleanupClosed=$closed lobbyReturnFallback=$lobbyReturnFallback"

    if (-not $clientJoined) { throw "client did not connect to the match" }
    if (-not $hostEnded) { throw "host did not auto-end the match" }
    if (-not ($returnedToLobby -or $cleanupArmed -or $lobbyReturnFallback)) { throw "client did not return to lobby or arm post-match cleanup" }
    if (-not ($returnedToLobby -or $closed -or $lobbyReturnFallback)) { throw "client did not return to lobby or close stale PreMatch char-select UI" }

    Write-Host "PASS post-match stale PreMatch cleanup / lobby-return fallback verified."
}
finally {
    if ($socket) { try { $socket.Abort(); $socket.Dispose() } catch {} }
    if ($client -and -not $client.HasExited) { try { Stop-Process -Id $client.Id -Force -ErrorAction SilentlyContinue } catch {} }
    Get-Process bapbap -ErrorAction SilentlyContinue | Stop-Process -Force -ErrorAction SilentlyContinue
    if ($server -and -not $server.HasExited) { try { $server.Kill($true) } catch { try { $server.Kill() } catch {} } }
}

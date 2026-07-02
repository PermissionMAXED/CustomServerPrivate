param(
    [string]$ServerHost = "ark.atomi23.de",
    [int]$ServerPort = 5055,
    [string]$LeaderAccountId = "custom-382jfI238ALO",
    [string]$LeaderUsername = "Sonic0810",
    [int]$CharId = 0,
    [int]$MapId = 1,
    [int]$BotCount = 7,
    [int]$BotDifficulty = 1,
    [int]$MaxTeams = 4,
    [int]$TeamSize = 1,
    [int]$ReadyTimeoutSeconds = 200,
    [int]$KeepLobbySocketAliveSeconds = 90,
    [string]$ClientExtraArguments = ""
)

# Drives a real match start on the REMOTE AMP server over WebSocket, then launches ONE local game
# client directly into that AMP-hosted match. The local dedicated host cannot boot on this Windows
# box, but AMP's Linux/Wine host does, so this reproduces the in-match "Unknown Error" kick that only
# happens once a player actually joins a running match. Watch the client log for the disconnect.

$ErrorActionPreference = "Stop"
$Root = Resolve-Path (Join-Path $PSScriptRoot "..")
$GameDir = Join-Path $Root "Spiel\Battleroyalebuild"
$GameExe = Join-Path $GameDir "bapbap.exe"
$ClientLog = Join-Path $Root "CustomMatchServer\logs\game-servers\amp-match-client.log"
if (Test-Path $ClientLog) { Remove-Item $ClientLog -Force }

function New-Sock([string]$Url) {
    $sock = [System.Net.WebSockets.ClientWebSocket]::new()
    $task = $sock.ConnectAsync([Uri]$Url, [Threading.CancellationToken]::None)
    if (-not $task.Wait(8000)) { throw "WS connect timed out" }
    if ($task.IsFaulted) { throw $task.Exception }
    return $sock
}
function Send-Json($sock, $obj) {
    $json = $obj | ConvertTo-Json -Compress -Depth 20
    $bytes = [System.Text.Encoding]::UTF8.GetBytes($json)
    $task = $sock.SendAsync([ArraySegment[byte]]::new($bytes), 'Text', $true, [Threading.CancellationToken]::None)
    if (-not $task.Wait(5000)) { throw "WS send timed out" }
}
function Recv-Json($sock, [int]$timeoutMs = 12000) {
    $buffer = New-Object byte[] 65536
    $stream = [System.IO.MemoryStream]::new()
    do {
        $task = $sock.ReceiveAsync([ArraySegment[byte]]::new($buffer), [Threading.CancellationToken]::None)
        if (-not $task.Wait($timeoutMs)) { throw "WS recv timed out after ${timeoutMs}ms" }
        $r = $task.Result
        if ($r.MessageType -eq 'Close') { throw "WS closed" }
        $stream.Write($buffer, 0, $r.Count)
    } while (-not $r.EndOfMessage)
    return [System.Text.Encoding]::UTF8.GetString($stream.ToArray()) | ConvertFrom-Json
}
function Wait-Event($sock, [string[]]$wantedEvents, [int]$maxMessages = 60, [int]$timeoutMs = 12000) {
    for ($i = 0; $i -lt $maxMessages; $i++) {
        try { $msg = Recv-Json $sock $timeoutMs } catch { Write-Host "    recv error: $_"; return $null }
        Write-Host "    -> $($msg.event)"
        if ($wantedEvents -contains $msg.event) { return $msg }
    }
    return $null
}

$base = "http://${ServerHost}:${ServerPort}"
Write-Host "[health] $base/health"
$h = Invoke-RestMethod "$base/health" -TimeoutSec 15
Write-Host "    ok=$($h.ok) release=$($h.release)"

Write-Host "[step 1] connect WS as admin $LeaderAccountId"
$wsUrl = "ws://${ServerHost}:${ServerPort}/ws?accountId=${LeaderAccountId}&username=${LeaderUsername}"
$sock = New-Sock $wsUrl
Wait-Event $sock @("SOCKET_READY") 10 8000 | Out-Null

Write-Host "[step 2] JOIN_LOBBY (charId=$CharId)"
Send-Json $sock @{ event = "JOIN_LOBBY"; payload = @{ lobbyId = ""; charId = $CharId; regionId = "custom"; gameModeId = 1; isAutoFill = $true } }
$join = Wait-Event $sock @("JOIN_LOBBY_SUCCESS","JOIN_LOBBY_FAIL") 40 15000
if (-not $join -or $join.event -ne "JOIN_LOBBY_SUCCESS") { $sock.Abort(); throw "JOIN_LOBBY failed" }

Write-Host "[step 3] UPDATE_CUSTOM_SETTINGS (map=$MapId bots=$BotCount maxTeams=$MaxTeams)"
Send-Json $sock @{ event = "UPDATE_CUSTOM_SETTINGS"; payload = @{ settings = @{ gamemode = 1; mapId = $MapId; teamSize = $TeamSize; maxTeams = $MaxTeams; botCount = $BotCount; botDifficulty = $BotDifficulty } } }
Wait-Event $sock @("UPDATE_CUSTOM_SETTINGS_SUCCESS") 20 8000 | Out-Null

Write-Host "[step 4] START_CUSTOM_GAME forceStart=true (host boot up to ${ReadyTimeoutSeconds}s)"
Send-Json $sock @{ event = "START_CUSTOM_GAME"; payload = @{ forceStart = $true } }
$gs = Wait-Event $sock @("GAME_STARTED","START_CUSTOM_GAME_FAIL") 80 ([Math]::Max(40000, ($ReadyTimeoutSeconds + 40) * 1000))
if (-not $gs -or $gs.event -ne "GAME_STARTED") { $sock.Abort(); throw "no GAME_STARTED (got $($gs.event))" }
$p = $gs.payload
Write-Host "    GAME_STARTED gameDns=$($p.gameDns) ws=$($p.wsPort) kcp=$($p.kcpPort) tcp=$($p.tcpPort) auth=$($p.gameAuthId)"

Write-Host "[step 5] launch ONE local client into the AMP match"
$a = "-logFile `"$ClientLog`" --melonloader.agfoffline --melonloader.captureplayerlogs " +
     "--bapcustom-use-proxy=false --bapcustom-host=$ServerHost --bapcustom-server-port=$ServerPort " +
     "--bapcustom-account-id=$LeaderAccountId --bapcustom-username=$LeaderUsername " +
     "--bapcustom-selected-char=$CharId --bapcustom-autoplay --bapcustom-auto-select-augments " +
     "--bapcustom-join-auth=$($p.gameAuthId) --bapcustom-join-host=$($p.gameDns) " +
     "--bapcustom-join-ws=$($p.wsPort) --bapcustom-join-kcp=$($p.kcpPort) --bapcustom-join-tcp=$($p.tcpPort)"
if (-not [string]::IsNullOrWhiteSpace($ClientExtraArguments)) {
    $a = "$a $ClientExtraArguments"
}
$client = Start-Process -FilePath $GameExe -WorkingDirectory $GameDir -ArgumentList $a -WindowStyle Normal -PassThru
Write-Host "    client pid=$($client.Id) log=$ClientLog"
if ($KeepLobbySocketAliveSeconds -gt 0) {
    Write-Host "[step 6] keeping lobby socket alive for ${KeepLobbySocketAliveSeconds}s while client boots"
    Start-Sleep -Seconds $KeepLobbySocketAliveSeconds
}
$sock.Abort(); $sock.Dispose()
Write-Host "DONE - watch $ClientLog for char-select/spawn or disconnect."

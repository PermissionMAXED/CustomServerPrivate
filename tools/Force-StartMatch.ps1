param(
    [string]$ServerHost = "127.0.0.1",
    [int]$ServerPort = 5198,
    [string]$LeaderAccountId = "test-visible-client",
    [string]$LeaderUsername = "VisibleTester",
    [string]$LobbyId = "WD4HXG",
    [int]$CharId = 1,
    [int]$MapId = 1,
    [int]$BotCount = 0,
    [int]$BotDifficulty = 1,
    [int]$MaxTeams = 2,
    [int]$TeamSize = 1
)

$ErrorActionPreference = "Stop"

function New-Sock([string]$Url) {
    $sock = [System.Net.WebSockets.ClientWebSocket]::new()
    $task = $sock.ConnectAsync([Uri]$Url, [Threading.CancellationToken]::None)
    if (-not $task.Wait(5000)) { throw "WS connect timed out" }
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

function Wait-Event($sock, [string[]]$wantedEvents, [int]$maxMessages = 30, [int]$timeoutMs = 12000) {
    $seen = @()
    for ($i = 0; $i -lt $maxMessages; $i++) {
        try {
            $msg = Recv-Json $sock $timeoutMs
        } catch {
            Write-Host "    recv error: $_"
            return $null
        }
        $seen += $msg.event
        Write-Host "    -> $($msg.event)"
        if ($wantedEvents -contains $msg.event) {
            return @{ msg = $msg; seen = $seen }
        }
    }
    return @{ msg = $null; seen = $seen }
}

# Grant admin to test-visible-client account so we can use admin from new socket
Write-Host "[step 1] Grant admin to $LeaderAccountId"
$adminBody = @{ command = "grant-admin"; accountId = $LeaderAccountId } | ConvertTo-Json
$adminHeaders = @{ "X-BAP-Admin-Token" = "" }
try {
    $r = Invoke-RestMethod "http://${ServerHost}:$ServerPort/admin/commands" -Method Post -Body $adminBody -ContentType "application/json" -Headers $adminHeaders -TimeoutSec 5
    Write-Host "    $($r.message)"
} catch {
    Write-Host "    WARN: admin grant failed: $_"
}

# Connect a second socket as the same accountId (now admin)
Write-Host "[step 2] Connect external socket as $LeaderAccountId (admin)"
$leaderUrl = "ws://${ServerHost}:${ServerPort}/ws?accountId=${LeaderAccountId}&username=${LeaderUsername}"
$sock = New-Sock $leaderUrl
Wait-Event $sock @("SOCKET_READY") 10 5000 | Out-Null

# JOIN_LOBBY (wait 8s for the 6s server delay)
Write-Host "[step 3] JOIN_LOBBY $LobbyId"
Send-Json $sock @{ event = "JOIN_LOBBY"; payload = @{ lobbyId = $LobbyId; charId = $CharId; regionId = "custom"; gameModeId = 1; isAutoFill = $true } }
$joinResult = Wait-Event $sock @("JOIN_LOBBY_SUCCESS","JOIN_LOBBY_FAIL") 30 12000
if (-not $joinResult -or -not $joinResult.msg) {
    Write-Host "    JOIN_LOBBY did not complete"
    $sock.Abort(); $sock.Dispose()
    exit 1
}
Write-Host "    JOIN result: $($joinResult.msg.event)"

# UPDATE_CUSTOM_SETTINGS with bot count + team config
Write-Host "[step 4] UPDATE_CUSTOM_SETTINGS (mapId=$MapId botCount=$BotCount maxTeams=$MaxTeams teamSize=$TeamSize)"
Send-Json $sock @{ event = "UPDATE_CUSTOM_SETTINGS"; payload = @{ settings = @{ gamemode = 1; mapId = $MapId; teamSize = $TeamSize; maxTeams = $MaxTeams; botCount = $BotCount; botDifficulty = $BotDifficulty } } }
Wait-Event $sock @("UPDATE_CUSTOM_SETTINGS_SUCCESS") 20 5000 | Out-Null

# START_CUSTOM_GAME forceStart=true
Write-Host "[step 5] START_CUSTOM_GAME forceStart=true"
Send-Json $sock @{ event = "START_CUSTOM_GAME"; payload = @{ forceStart = $true } }
$gameResult = Wait-Event $sock @("GAME_STARTED","START_CUSTOM_GAME_FAIL") 30 180000
if (-not $gameResult -or -not $gameResult.msg) {
    Write-Host "    Did not get GAME_STARTED/FAIL"
    $sock.Abort(); $sock.Dispose()
    exit 1
}
Write-Host "    Result: $($gameResult.msg.event)"
if ($gameResult.msg.event -eq "GAME_STARTED") {
    Write-Host "    Payload: $($gameResult.msg.payload | ConvertTo-Json -Depth 10)"
} elseif ($gameResult.msg.payload) {
    Write-Host "    Payload: $($gameResult.msg.payload | ConvertTo-Json -Depth 10)"
}

$sock.Abort(); $sock.Dispose()
Write-Host "DONE"

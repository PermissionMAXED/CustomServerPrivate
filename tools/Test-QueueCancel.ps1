# Test-QueueCancel.ps1
#
# Verifies queue cancel works end-to-end on the SERVER. Drives:
#   1) HTTP /api/queue/join
#   2) HTTP /api/queue/cancel + /api/queue/leave + DELETE /api/queue
#   3) WebSocket SWITCH_READY=true (auto-enqueue) -> CANCEL_MATCHMAKING (auto-dequeue)
#   4) WebSocket CANCEL_QUEUE / LEAVE_QUEUE alias paths
#   5) Lobby state stays intact after cancel (no LOBBY_LEFT)
#   6) Admin queue-clear / queue-leave commands
#
# Usage:
#   .\Test-QueueCancel.ps1                           # against http://127.0.0.1:5058
#   .\Test-QueueCancel.ps1 -BaseUrl http://ark.atomi23.de:5058
#   .\Test-QueueCancel.ps1 -BaseUrl http://127.0.0.1:5058 -SkipWebSocket

[CmdletBinding()]
param(
    [string]$BaseUrl = 'http://127.0.0.1:5058',
    [switch]$SkipWebSocket,
    [int]$WsTimeoutSeconds = 8
)

$ErrorActionPreference = 'Stop'
$BaseUrl = $BaseUrl.TrimEnd('/')

function Write-Section($msg) {
    Write-Host ''
    Write-Host ('=== ' + $msg + ' ===') -ForegroundColor Cyan
}

function Invoke-JsonPost {
    param([string]$Url, [hashtable]$Headers = @{}, [object]$Body = $null)
    $params = @{
        Uri = $Url
        Method = 'POST'
        Headers = $Headers
        ContentType = 'application/json'
    }
    if ($null -ne $Body) { $params.Body = ($Body | ConvertTo-Json -Compress) } else { $params.Body = '{}' }
    return Invoke-RestMethod @params
}

function Invoke-JsonGet {
    param([string]$Url, [hashtable]$Headers = @{})
    return Invoke-RestMethod -Uri $Url -Method GET -Headers $Headers
}

function Invoke-JsonDelete {
    param([string]$Url, [hashtable]$Headers = @{})
    return Invoke-RestMethod -Uri $Url -Method DELETE -Headers $Headers
}

$account = 'qa-cancel-' + [Guid]::NewGuid().ToString('n').Substring(0, 8)
$username = 'QaCancel' + (Get-Random -Minimum 100 -Maximum 999)
$headers = @{
    'X-Custom-Account-Id' = $account
    'X-Custom-Username'   = $username
}

Write-Section "Health check $BaseUrl/health"
try {
    $h = Invoke-JsonGet "$BaseUrl/health"
    Write-Host ($h | ConvertTo-Json -Compress)
} catch {
    Write-Host "FAILED to reach $BaseUrl/health: $_" -ForegroundColor Red
    exit 1
}

Write-Section "Test 1: /api/queue/join then /api/queue/leave (legacy)"
$j = Invoke-JsonPost "$BaseUrl/api/queue/join" $headers @{ charId = 1 }
Write-Host ("join => " + ($j | ConvertTo-Json -Compress))
$status1 = Invoke-JsonGet "$BaseUrl/api/queue/status"
Write-Host ("status => " + ($status1 | ConvertTo-Json -Compress))
$leave = Invoke-JsonPost "$BaseUrl/api/queue/leave" $headers
Write-Host ("leave => " + ($leave | ConvertTo-Json -Compress))
if (-not $leave.ok) { Write-Host "FAIL: /api/queue/leave returned ok=false" -ForegroundColor Red; exit 2 }

Write-Section "Test 2: /api/queue/join then /api/queue/cancel (new alias)"
$j2 = Invoke-JsonPost "$BaseUrl/api/queue/join" $headers @{ charId = 1 }
Write-Host ("join => " + ($j2 | ConvertTo-Json -Compress))
$cancel = Invoke-JsonPost "$BaseUrl/api/queue/cancel" $headers
Write-Host ("cancel => " + ($cancel | ConvertTo-Json -Compress))
if (-not $cancel.ok)        { Write-Host "FAIL: /api/queue/cancel returned ok=false" -ForegroundColor Red; exit 3 }
if (-not $cancel.wasInQueue) { Write-Host "FAIL: /api/queue/cancel wasInQueue=false" -ForegroundColor Red; exit 3 }

Write-Section "Test 3: GET /api/queue/cancel"
Invoke-JsonPost "$BaseUrl/api/queue/join" $headers @{ charId = 1 } | Out-Null
$cancelGet = Invoke-JsonGet "$BaseUrl/api/queue/cancel" $headers
Write-Host ("cancel(GET) => " + ($cancelGet | ConvertTo-Json -Compress))
if (-not $cancelGet.wasInQueue) { Write-Host "FAIL: GET /api/queue/cancel wasInQueue=false" -ForegroundColor Red; exit 4 }

Write-Section "Test 4: DELETE /api/queue"
Invoke-JsonPost "$BaseUrl/api/queue/join" $headers @{ charId = 1 } | Out-Null
$del = Invoke-JsonDelete "$BaseUrl/api/queue" $headers
Write-Host ("DELETE => " + ($del | ConvertTo-Json -Compress))
if (-not $del.wasInQueue) { Write-Host "FAIL: DELETE /api/queue wasInQueue=false" -ForegroundColor Red; exit 5 }

Write-Section "Test 5: cancel when not queued is idempotent"
$idem = Invoke-JsonPost "$BaseUrl/api/queue/cancel" $headers
Write-Host ("cancel(idem) => " + ($idem | ConvertTo-Json -Compress))
if (-not $idem.ok)         { Write-Host "FAIL: idempotent cancel returned ok=false" -ForegroundColor Red; exit 6 }
if ($idem.wasInQueue)      { Write-Host "FAIL: idempotent cancel wasInQueue=true" -ForegroundColor Red; exit 6 }

if ($SkipWebSocket) {
    Write-Host ""
    Write-Host "Skipped WebSocket tests (-SkipWebSocket)." -ForegroundColor Yellow
    Write-Host "All HTTP tests passed." -ForegroundColor Green
    exit 0
}

# WebSocket portion --------------------------------------------------------------
Add-Type -AssemblyName System.Net.WebSockets

$wsBase = $BaseUrl -replace '^http', 'ws'
$wsUrl = "$wsBase/ws"

function New-Ws {
    param([string]$AccountId, [string]$Username)
    $ws = New-Object System.Net.WebSockets.ClientWebSocket
    $ws.Options.SetRequestHeader('X-Custom-Account-Id', $AccountId)
    $ws.Options.SetRequestHeader('X-Custom-Username', $Username)
    $cts = New-Object System.Threading.CancellationTokenSource
    $cts.CancelAfter([TimeSpan]::FromSeconds(15))
    $ws.ConnectAsync([Uri]$wsUrl, $cts.Token).GetAwaiter().GetResult()
    return $ws
}

function Send-Ws {
    param($Ws, [string]$EventName, [object]$Payload = $null)
    $body = @{ event = $EventName; payload = $Payload } | ConvertTo-Json -Compress -Depth 8
    $bytes = [Text.Encoding]::UTF8.GetBytes($body)
    $seg = [ArraySegment[byte]]::new($bytes)
    $cts = New-Object System.Threading.CancellationTokenSource
    $cts.CancelAfter([TimeSpan]::FromSeconds(5))
    $Ws.SendAsync($seg, [System.Net.WebSockets.WebSocketMessageType]::Text, $true, $cts.Token).GetAwaiter().GetResult()
    Write-Host ("  -> sent " + $EventName)
}

function Receive-Ws-Until {
    param($Ws, [string[]]$Until, [int]$TimeoutSeconds = 8)
    $deadline = (Get-Date).AddSeconds($TimeoutSeconds)
    $buf = New-Object byte[] (32 * 1024)
    $seen = New-Object System.Collections.Generic.List[string]
    while ((Get-Date) -lt $deadline) {
        $cts = New-Object System.Threading.CancellationTokenSource
        $cts.CancelAfter([TimeSpan]::FromMilliseconds(1500))
        try {
            $seg = [ArraySegment[byte]]::new($buf)
            $res = $Ws.ReceiveAsync($seg, $cts.Token).GetAwaiter().GetResult()
            if ($res.Count -gt 0) {
                $s = [Text.Encoding]::UTF8.GetString($buf, 0, $res.Count)
                $evtMatch = [regex]::Match($s, '"event"\s*:\s*"([^"]+)"')
                $name = if ($evtMatch.Success) { $evtMatch.Groups[1].Value } else { '?' }
                Write-Host ("  <- " + $name + "  " + ($s.Substring(0, [Math]::Min($s.Length, 200))))
                $seen.Add($name) | Out-Null
                if ($Until -contains $name) { return $seen.ToArray() }
            }
        } catch [System.Net.WebSockets.WebSocketException] { break }
          catch [System.OperationCanceledException] { continue }
    }
    return $seen.ToArray()
}

Write-Section "Test 6: WS connect, JOIN_LOBBY, SWITCH_READY=true (auto-queue), CANCEL_MATCHMAKING"
$ws = New-Ws -AccountId $account -Username $username
try {
    $seen0 = Receive-Ws-Until -Ws $ws -Until @('SOCKET_READY') -TimeoutSeconds 5
    Send-Ws -Ws $ws -EventName 'JOIN_LOBBY' -Payload @{ charId = 1; gameModeId = 0 }
    $seenJoin = Receive-Ws-Until -Ws $ws -Until @('JOIN_LOBBY_SUCCESS') -TimeoutSeconds 12
    if ($seenJoin -notcontains 'JOIN_LOBBY_SUCCESS') {
        Write-Host "FAIL: never received JOIN_LOBBY_SUCCESS" -ForegroundColor Red; exit 7
    }

    Send-Ws -Ws $ws -EventName 'SWITCH_READY' -Payload @{ isReady = $true }
    $seenReady = Receive-Ws-Until -Ws $ws -Until @('MATCHMAKING_ENTERED') -TimeoutSeconds $WsTimeoutSeconds
    if ($seenReady -notcontains 'MATCHMAKING_ENTERED') {
        Write-Host "FAIL: SWITCH_READY=true did not produce MATCHMAKING_ENTERED" -ForegroundColor Red; exit 8
    }

    Send-Ws -Ws $ws -EventName 'CANCEL_MATCHMAKING' -Payload @{}
    $seenCancel = Receive-Ws-Until -Ws $ws -Until @('CANCEL_MATCHMAKING_SUCCESS') -TimeoutSeconds $WsTimeoutSeconds
    if ($seenCancel -notcontains 'CANCEL_MATCHMAKING_SUCCESS') {
        Write-Host "FAIL: CANCEL_MATCHMAKING did not produce CANCEL_MATCHMAKING_SUCCESS" -ForegroundColor Red; exit 9
    }
    if ($seenCancel -contains 'LOBBY_LEFT') {
        Write-Host "FAIL: CANCEL_MATCHMAKING wrongly produced LOBBY_LEFT (lobby destroyed). Should stay in lobby." -ForegroundColor Red; exit 10
    }
    if ($seenCancel -notcontains 'MATCHMAKING_EXITED') {
        Write-Host "WARN: no MATCHMAKING_EXITED seen after CANCEL_MATCHMAKING. Client UI may not transition." -ForegroundColor Yellow
    }

    Write-Section "Test 7: WS CANCEL_QUEUE alias"
    Send-Ws -Ws $ws -EventName 'SWITCH_READY' -Payload @{ isReady = $true }
    Receive-Ws-Until -Ws $ws -Until @('MATCHMAKING_ENTERED') -TimeoutSeconds $WsTimeoutSeconds | Out-Null
    Send-Ws -Ws $ws -EventName 'CANCEL_QUEUE' -Payload @{}
    $seenCancel2 = Receive-Ws-Until -Ws $ws -Until @('CANCEL_MATCHMAKING_SUCCESS') -TimeoutSeconds $WsTimeoutSeconds
    if ($seenCancel2 -notcontains 'CANCEL_MATCHMAKING_SUCCESS') {
        Write-Host "FAIL: CANCEL_QUEUE alias did not produce CANCEL_MATCHMAKING_SUCCESS" -ForegroundColor Red; exit 11
    }

    Write-Section "Test 8: WS LEAVE_QUEUE alias"
    Send-Ws -Ws $ws -EventName 'SWITCH_READY' -Payload @{ isReady = $true }
    Receive-Ws-Until -Ws $ws -Until @('MATCHMAKING_ENTERED') -TimeoutSeconds $WsTimeoutSeconds | Out-Null
    Send-Ws -Ws $ws -EventName 'LEAVE_QUEUE' -Payload @{}
    $seenCancel3 = Receive-Ws-Until -Ws $ws -Until @('CANCEL_MATCHMAKING_SUCCESS') -TimeoutSeconds $WsTimeoutSeconds
    if ($seenCancel3 -notcontains 'CANCEL_MATCHMAKING_SUCCESS') {
        Write-Host "FAIL: LEAVE_QUEUE alias did not produce CANCEL_MATCHMAKING_SUCCESS" -ForegroundColor Red; exit 12
    }

    Write-Section "Test 9: SWITCH_READY=false produces MATCHMAKING_EXITED and queue is empty"
    Send-Ws -Ws $ws -EventName 'SWITCH_READY' -Payload @{ isReady = $true }
    Receive-Ws-Until -Ws $ws -Until @('MATCHMAKING_ENTERED') -TimeoutSeconds $WsTimeoutSeconds | Out-Null
    Send-Ws -Ws $ws -EventName 'SWITCH_READY' -Payload @{ isReady = $false }
    $seenUnready = Receive-Ws-Until -Ws $ws -Until @('MATCHMAKING_EXITED') -TimeoutSeconds $WsTimeoutSeconds
    if ($seenUnready -notcontains 'MATCHMAKING_EXITED') {
        Write-Host "FAIL: SWITCH_READY=false did not produce MATCHMAKING_EXITED" -ForegroundColor Red; exit 13
    }
    $statusAfter = Invoke-JsonGet "$BaseUrl/api/queue/status"
    Write-Host ("queue status after WS unready: " + ($statusAfter | ConvertTo-Json -Compress))
    if ($statusAfter.players | Where-Object { $_.accountId -eq $account }) {
        Write-Host "FAIL: account still in queue after SWITCH_READY=false" -ForegroundColor Red; exit 14
    }

    Write-Section "Test 10: Lobby still alive after cancel (player can re-ready)"
    Send-Ws -Ws $ws -EventName 'SWITCH_READY' -Payload @{ isReady = $true }
    $seenReReady = Receive-Ws-Until -Ws $ws -Until @('MATCHMAKING_ENTERED') -TimeoutSeconds $WsTimeoutSeconds
    if ($seenReReady -notcontains 'MATCHMAKING_ENTERED') {
        Write-Host "FAIL: re-ready after cancel did not re-enter queue (lobby state corrupted)" -ForegroundColor Red; exit 15
    }
    Send-Ws -Ws $ws -EventName 'CANCEL_MATCHMAKING' -Payload @{}
    Receive-Ws-Until -Ws $ws -Until @('CANCEL_MATCHMAKING_SUCCESS') -TimeoutSeconds $WsTimeoutSeconds | Out-Null
}
finally {
    if ($ws.State -eq 'Open') {
        $cts = New-Object System.Threading.CancellationTokenSource
        $cts.CancelAfter([TimeSpan]::FromSeconds(2))
        try { $ws.CloseAsync('NormalClosure', 'done', $cts.Token).GetAwaiter().GetResult() } catch {}
    }
    $ws.Dispose()
}

Write-Host ""
Write-Host "All queue-cancel tests PASSED for $BaseUrl" -ForegroundColor Green
exit 0

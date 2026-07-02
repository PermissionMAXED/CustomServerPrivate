# 2-client lobby-code test: leader creates a lobby (empty lobbyId) and gets a code;
# joiner uses that code and must land in the SAME lobby; a bad code must fail (wasInvalid).
$ErrorActionPreference = "Stop"
$wsBase = "ws://ark.atomi23.de:5055/ws"

function New-Ws($acct, $user) {
    $ws = [System.Net.WebSockets.ClientWebSocket]::new()
    $ws.ConnectAsync([Uri]"$wsBase`?accountId=$acct&username=$user", [Threading.CancellationToken]::None).Wait(8000) | Out-Null
    return $ws
}
function Send-Ws($ws, $json) {
    $b = [Text.Encoding]::UTF8.GetBytes($json)
    $ws.SendAsync([ArraySegment[byte]]::new($b), 'Text', $true, [Threading.CancellationToken]::None).Wait(5000) | Out-Null
}
function Recv-Until($ws, $pattern, $timeoutMs) {
    $sw = [Diagnostics.Stopwatch]::StartNew()
    $buf = New-Object byte[] 65536
    $pending = $null
    while ($sw.ElapsedMilliseconds -lt $timeoutMs) {
        if ($null -eq $pending) {
            $pending = $ws.ReceiveAsync([ArraySegment[byte]]::new($buf), [Threading.CancellationToken]::None)
        }
        if ($pending.Wait(400)) {
            $r = $pending.Result; $pending = $null
            $m = [Text.Encoding]::UTF8.GetString($buf, 0, $r.Count)
            if ($m -match $pattern) { return $m }
        }
    }
    return $null
}

# --- Leader: create lobby ---
$leader = New-Ws "lc-leader" "LcLeader"
Recv-Until $leader "SOCKET_READY" 5000 | Out-Null
Send-Ws $leader '{"event":"JOIN_LOBBY","payload":{"lobbyId":"","charId":0,"regionId":"custom","gameModeId":3,"isAutoFill":false}}'
$ls = Recv-Until $leader "JOIN_LOBBY_SUCCESS" 8000
if (-not $ls) { Write-Host "LEADER: no JOIN_LOBBY_SUCCESS"; exit 1 }
$code = ([regex]'"lobbyId":"([A-Z0-9]+)"').Match($ls).Groups[1].Value
Write-Host "LEADER lobby code = $code"

# --- Joiner: use the code ---
$joiner = New-Ws "lc-joiner" "LcJoiner"
Recv-Until $joiner "SOCKET_READY" 5000 | Out-Null
Send-Ws $joiner "{`"event`":`"JOIN_LOBBY`",`"payload`":{`"lobbyId`":`"$code`",`"charId`":1,`"regionId`":`"custom`",`"gameModeId`":3,`"isAutoFill`":false}}"
$js = Recv-Until $joiner "JOIN_LOBBY_SUCCESS|JOIN_LOBBY_FAIL" 8000
if (-not $js) { Write-Host "JOINER: no response"; }
else {
    $sameLobby = ([regex]"`"lobbyId`":`"$code`"").IsMatch($js)
    $invalid = $js -match '"wasInvalid":true'
    $playerCount = ([regex]'"accountId":"lc-').Matches($js).Count
    Write-Host "JOINER resolved-to-code=$sameLobby wasInvalid=$invalid playersInLobby=$playerCount"
}

# --- Bad code must fail ---
$bad = New-Ws "lc-bad" "LcBad"
Recv-Until $bad "SOCKET_READY" 5000 | Out-Null
Send-Ws $bad '{"event":"JOIN_LOBBY","payload":{"lobbyId":"ZZZZ99","charId":1,"regionId":"custom","gameModeId":3,"isAutoFill":false}}'
$bs = Recv-Until $bad "JOIN_LOBBY_SUCCESS|JOIN_LOBBY_FAIL" 8000
if (-not $bs) { Write-Host "BADCODE: no response (unexpected)" }
else { Write-Host ("BADCODE wasInvalid=" + ($bs -match '"wasInvalid":true')) }

foreach ($w in @($leader, $joiner, $bad)) { try { $w.Abort() } catch {} }
Write-Host "DONE"

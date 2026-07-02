param(
    [int]$SwitchTo = 4,            # 4=Duos
    [string]$Acct = "modeswitchprobe02",
    [string]$User = "ModeSwitchProbe"
)
# Drives the full lobby mode-switch exchange against the LIVE server and prints every frame.
# Uses a single pending ReceiveAsync polled via Task.Wait(timeout) so we NEVER cancel the token
# (cancelling ReceiveAsync aborts a ClientWebSocket permanently).
$ErrorActionPreference = "Stop"
$wsUri = [Uri]"ws://ark.atomi23.de:5055/ws?accountId=$Acct&username=$User"
$ws = [System.Net.WebSockets.ClientWebSocket]::new()
$ws.ConnectAsync($wsUri, [Threading.CancellationToken]::None).GetAwaiter().GetResult()
Write-Host "WS state: $($ws.State)"

$buf = New-Object byte[] 131072
$pending = $null
function PumpFor([int]$ms) {
    $deadline = (Get-Date).AddMilliseconds($ms)
    while ((Get-Date) -lt $deadline -and $ws.State -eq 'Open') {
        if ($null -eq $script:pending) {
            $seg = [System.ArraySegment[byte]]::new($buf)
            $script:pending = $ws.ReceiveAsync($seg, [System.Threading.CancellationToken]::None)
        }
        if ($script:pending.Wait(300)) {
            $r = $script:pending.GetAwaiter().GetResult()
            $script:pending = $null
            if ($r.MessageType -eq 'Close') { Write-Host "<<CLOSE>>"; return }
            $m = [System.Text.Encoding]::UTF8.GetString($buf, 0, $r.Count)
            Write-Host "RECV: $($m.Substring(0,[Math]::Min(900,$m.Length)))"
        }
    }
}
function Send([string]$json) {
    $bytes = [System.Text.Encoding]::UTF8.GetBytes($json)
    $seg = [System.ArraySegment[byte]]::new($bytes)
    $ws.SendAsync($seg, [System.Net.WebSockets.WebSocketMessageType]::Text, $true, [System.Threading.CancellationToken]::None).GetAwaiter().GetResult()
    Write-Host "SENT: $json"
}

Write-Host "--- handshake ---"
PumpFor 2500
Send '{"event":"JOIN_LOBBY","payload":{"lobbyId":"","charId":1,"isAutoFill":true}}'
Write-Host "--- waiting for JOIN_LOBBY_SUCCESS ---"
PumpFor 9000
Write-Host "--- SWITCH_GAME_MODE -> $SwitchTo ---"
Send "{`"event`":`"SWITCH_GAME_MODE`",`"payload`":{`"gameModeId`":$SwitchTo,`"password`":`"`"}}"
PumpFor 6000

try { $ws.Abort() } catch {}
Write-Host "done"

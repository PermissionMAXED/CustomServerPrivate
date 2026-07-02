$ErrorActionPreference = "Stop"
function NS($u) { $s = [System.Net.WebSockets.ClientWebSocket]::new(); $t = $s.ConnectAsync([Uri]$u, [Threading.CancellationToken]::None); $null = $t.Wait(8000); return $s }
function SJ($s, $o) { $j = $o | ConvertTo-Json -Compress -Depth 20; $b = [Text.Encoding]::UTF8.GetBytes($j); $null = $s.SendAsync([ArraySegment[byte]]::new($b), 'Text', $true, [Threading.CancellationToken]::None).Wait(5000) }
function RJ($s, $ms) { $buf = New-Object byte[] 65536; $st = [IO.MemoryStream]::new(); do { $t = $s.ReceiveAsync([ArraySegment[byte]]::new($buf), [Threading.CancellationToken]::None); if (-not $t.Wait($ms)) { throw "recv timeout" }; $r = $t.Result; if ($r.MessageType -eq 'Close') { throw "ws closed" }; $st.Write($buf, 0, $r.Count) } while (-not $r.EndOfMessage); return [Text.Encoding]::UTF8.GetString($st.ToArray()) | ConvertFrom-Json }

$u = "ws://ark.atomi23.de:5055/ws?accountId=custom-382jfI238ALO&username=Sonic0810"
$s = NS $u
for ($i = 0; $i -lt 5; $i++) { $m = RJ $s 8000; if ($m.event -eq "SOCKET_READY") { break } }
Write-Host "[connected]"
SJ $s @{ event = "JOIN_LOBBY"; payload = @{ lobbyId = ""; charId = 0; regionId = "custom"; gameModeId = 1; isAutoFill = $true } }
for ($i = 0; $i -lt 40; $i++) { $m = RJ $s 15000; if ($m.event -eq "JOIN_LOBBY_SUCCESS") { break } }
Write-Host "[lobby joined]"
$start = Get-Date
SJ $s @{ event = "START_CUSTOM_GAME"; payload = @{ forceStart = $true } }
Write-Host "[START_CUSTOM_GAME sent, waiting for host bootstrap...]"
for ($i = 0; $i -lt 30; $i++) {
    $m = RJ $s 200000
    $secs = [int]((Get-Date) - $start).TotalSeconds
    Write-Host "  -> $($m.event) (${secs}s)"
    if ($m.event -eq "GAME_STARTED") { Write-Host "RESULT: host bootstrapped OK in ${secs}s"; break }
    if ($m.event -match "FAIL") { Write-Host "RESULT: FAIL after ${secs}s -- $($m.payload | ConvertTo-Json -Compress)"; break }
}
$s.Abort()

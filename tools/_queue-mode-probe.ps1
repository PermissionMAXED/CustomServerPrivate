param(
    [int]$GameModeId = 4,        # 4=Duos, 5=Trios, 3=Solos, 0=Warmup/Training, 9=FFA
    [string]$Acct = "modetest01",
    [string]$User = "ModeTest",
    [int]$WaitSeconds = 60
)
# Robust matchmaking-queue probe: opens a WS (registers accountId server-side), POSTs
# /api/queue/join with the requested mode, keeps the WS alive with a non-crashing async
# receive loop, and prints any QUEUE_MATCHED / GAME_STARTED frame (which carries team data).
$ErrorActionPreference = "Stop"
$base = "http://ark.atomi23.de:5055"
$wsUri = [Uri]"ws://ark.atomi23.de:5055/ws?accountId=$Acct&username=$User"

$ws = [System.Net.WebSockets.ClientWebSocket]::new()
$ws.ConnectAsync($wsUri, [Threading.CancellationToken]::None).Wait(8000) | Out-Null
Write-Host "WS state: $($ws.State)"

Add-Type -AssemblyName System.Net.Http
$c = [System.Net.Http.HttpClient]::new()
$req = [System.Net.Http.HttpRequestMessage]::new([System.Net.Http.HttpMethod]::Post, "$base/api/queue/join")
$req.Headers.Add("X-BAP-AccountId", $Acct); $req.Headers.Add("X-BAP-Username", $User)
$req.Content = [System.Net.Http.StringContent]::new("{`"charId`":1,`"gameModeId`":$GameModeId}", [System.Text.Encoding]::UTF8, "application/json")
$resp = $c.SendAsync($req).GetAwaiter().GetResult()
Write-Host ("queue/join(mode=$GameModeId) -> " + [int]$resp.StatusCode + " " + $resp.Content.ReadAsStringAsync().GetAwaiter().GetResult())

$deadline = (Get-Date).AddSeconds($WaitSeconds)
$buf = New-Object byte[] 65536
while ((Get-Date) -lt $deadline -and $ws.State -eq 'Open') {
    $seg = [ArraySegment[byte]]::new($buf)
    $cts = [Threading.CancellationTokenSource]::new(4000)
    try {
        $r = $ws.ReceiveAsync($seg, $cts.Token).GetAwaiter().GetResult()
    } catch {
        continue   # timeout or transient — keep the socket alive
    } finally {
        $cts.Dispose()
    }
    if ($r.MessageType -eq 'Close') { Write-Host "server closed WS"; break }
    $m = [System.Text.Encoding]::UTF8.GetString($buf, 0, $r.Count)
    if ($m -match 'QUEUE_MATCHED|GAME_STARTED|MATCHMAKING') {
        Write-Host ("EVENT: " + $m.Substring(0, [Math]::Min(900, $m.Length)))
    }
}
try { $ws.Abort() } catch {}
Write-Host "done (mode=$GameModeId)"

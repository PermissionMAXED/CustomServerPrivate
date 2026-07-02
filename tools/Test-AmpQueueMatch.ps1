param(
    [string]$ServerHost = "ark.atomi23.de",
    [int]$ServerPort = 5055,
    [string]$AccountId = "custom-382jfI238ALO",
    [string]$Username = "Sonic0810",
    [int]$CharId = 0
)

# Drives the REAL matchmaking-queue path the user hit: JOIN_LOBBY then SWITCH_READY (the exact
# message the in-game Ready button sends -> matchmaking queue), times how long until GAME_STARTED,
# then launches ONE real game client into that match so we can screenshot INSIDE the round.
# No autoplay flag. SWITCH_READY is the genuine Ready-button protocol event.

$ErrorActionPreference = "Stop"
$Root = Resolve-Path (Join-Path $PSScriptRoot "..")
$GameDir = Join-Path $Root "Spiel\Battleroyalebuild"
$GameExe = Join-Path $GameDir "bapbap.exe"
$ClientLog = Join-Path $Root "CustomMatchServer\logs\game-servers\amp-round-client.log"
if (Test-Path $ClientLog) { Remove-Item $ClientLog -Force }

function NS($u) { $s = [System.Net.WebSockets.ClientWebSocket]::new(); $t = $s.ConnectAsync([Uri]$u, [Threading.CancellationToken]::None); $null = $t.Wait(8000); if ($t.IsFaulted) { throw $t.Exception }; return $s }
function SJ($s, $o) { $j = $o | ConvertTo-Json -Compress -Depth 20; $b = [Text.Encoding]::UTF8.GetBytes($j); $null = $s.SendAsync([ArraySegment[byte]]::new($b), 'Text', $true, [Threading.CancellationToken]::None).Wait(5000) }
function RJ($s, $ms) { $buf = New-Object byte[] 65536; $st = [IO.MemoryStream]::new(); do { $t = $s.ReceiveAsync([ArraySegment[byte]]::new($buf), [Threading.CancellationToken]::None); if (-not $t.Wait($ms)) { throw "recv timeout" }; $r = $t.Result; if ($r.MessageType -eq 'Close') { throw "ws closed" }; $st.Write($buf, 0, $r.Count) } while (-not $r.EndOfMessage); return [Text.Encoding]::UTF8.GetString($st.ToArray()) | ConvertFrom-Json }

Write-Host "[health] $((Invoke-RestMethod "http://${ServerHost}:${ServerPort}/health" -TimeoutSec 15).ok)"
$u = "ws://${ServerHost}:${ServerPort}/ws?accountId=${AccountId}&username=${Username}"
$s = NS $u
for ($i = 0; $i -lt 5; $i++) { $m = RJ $s 8000; if ($m.event -eq "SOCKET_READY") { break } }
Write-Host "[connected] socket ready"

SJ $s @{ event = "JOIN_LOBBY"; payload = @{ lobbyId = ""; charId = $CharId; regionId = "custom"; gameModeId = 1; isAutoFill = $true } }
for ($i = 0; $i -lt 40; $i++) { $m = RJ $s 15000; if ($m.event -eq "JOIN_LOBBY_SUCCESS") { break } }
Write-Host "[lobby] joined"

# THE READY BUTTON: SWITCH_READY isReady=true enters the matchmaking queue.
$readyAt = Get-Date
SJ $s @{ event = "SWITCH_READY"; payload = @{ isReady = $true } }
Write-Host "[ready] clicked Ready at $($readyAt.ToString('HH:mm:ss')) - now in matchmaking queue, waiting for GAME_STARTED..."

$payload = $null
# Keep recv timeout LONG: after MATCHMAKING_ENTERED the server is silent through the 30s queue timer
# AND the 60-120s Wine host boot before GAME_STARTED, so a short recv would kill the socket (and the
# queue entry) mid-wait. 200s per recv tolerates the whole cycle.
for ($i = 0; $i -lt 6; $i++) {
    $m = RJ $s 200000
    if ($m.event -eq "MATCHMAKING_ENTERED") { Write-Host "  -> MATCHMAKING_ENTERED ($([int]((Get-Date)-$readyAt).TotalSeconds)s)" }
    elseif ($m.event -eq "QUEUE_MATCHED") { Write-Host "  -> QUEUE_MATCHED ($([int]((Get-Date)-$readyAt).TotalSeconds)s)" }
    elseif ($m.event -eq "GAME_STARTED") { $payload = $m.payload; break }
    else { Write-Host "  -> $($m.event) ($([int]((Get-Date)-$readyAt).TotalSeconds)s)" }
}
if ($null -eq $payload) { $s.Abort(); throw "no GAME_STARTED" }
$queueSecs = [int]((Get-Date) - $readyAt).TotalSeconds
Write-Host "[match] GAME_STARTED after ${queueSecs}s in queue. gameDns=$($payload.gameDns) ws=$($payload.wsPort) kcp=$($payload.kcpPort) tcp=$($payload.tcpPort)"

Write-Host "[client] launching real game client INTO the match (no autoplay)"
$a = "-logFile `"$ClientLog`" --melonloader.agfoffline --melonloader.captureplayerlogs " +
     "--bapcustom-use-proxy=false --bapcustom-host=$ServerHost --bapcustom-server-port=$ServerPort " +
     "--bapcustom-account-id=$AccountId --bapcustom-username=$Username --bapcustom-selected-char=$CharId " +
     "--bapcustom-join-auth=$($payload.gameAuthId) --bapcustom-join-host=$($payload.gameDns) " +
     "--bapcustom-join-ws=$($payload.wsPort) --bapcustom-join-kcp=$($payload.kcpPort) --bapcustom-join-tcp=$($payload.tcpPort)"
$client = Start-Process -FilePath $GameExe -WorkingDirectory $GameDir -ArgumentList $a -PassThru
Write-Host "[client] pid=$($client.Id) queueSeconds=$queueSecs"
$s.Abort(); $s.Dispose()
Write-Host "DONE queueSeconds=$queueSecs"

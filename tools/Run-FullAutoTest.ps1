param(
    [int]$ServerPort = 5198,
    [string]$LobbyId = "WD4HXG",
    [int]$WaitSeconds = 90,
    [int]$BotCount = 0,
    [int]$MaxTeams = 2,
    [int]$TeamSize = 1
)

$ErrorActionPreference = "Stop"
$Root = "C:\Users\Administrator\Downloads\CustomServer"

Write-Host "=== Step 1: Start match via Force-StartMatch (botCount=$BotCount maxTeams=$MaxTeams) ===" -ForegroundColor Cyan
$output = & powershell -ExecutionPolicy Bypass -File "$Root\tools\Force-StartMatch.ps1" -ServerPort $ServerPort -LobbyId $LobbyId -BotCount $BotCount -MaxTeams $MaxTeams -TeamSize $TeamSize 2>&1
Write-Host ($output -join "`n")

# Parse ports + gameAuthId from output
$gameAuthId = $null
$wsPort = $null
$kcpPort = $null
$tcpPort = $null
$gameDns = $null
foreach ($line in $output) {
    $s = "$line"
    if ($s -match '"gameAuthId":\s*"([^"]+)"') { $gameAuthId = $Matches[1] }
    if ($s -match '"gameDns":\s*"([^"]+)"') { $gameDns = $Matches[1] }
    if ($s -match '"wsPort":\s*(\d+)') { $wsPort = $Matches[1] }
    if ($s -match '"kcpPort":\s*(\d+)') { $kcpPort = $Matches[1] }
    if ($s -match '"tcpPort":\s*(\d+)') { $tcpPort = $Matches[1] }
}
if (-not $gameAuthId) { Write-Host "FAIL: no gameAuthId from Force-StartMatch" -ForegroundColor Red; exit 1 }
Write-Host "Match: auth=$gameAuthId host=$gameDns ws=$wsPort kcp=$kcpPort tcp=$tcpPort" -ForegroundColor Green

Write-Host "`n=== Step 2: Launch visible bapbap.exe with auto-join ===" -ForegroundColor Cyan
$gameDir = "$Root\Spiel\Battleroyalebuild"
$gameExe = "$gameDir\bapbap.exe"
$argList = @(
    "--melonloader.agfoffline",
    "--bapcustom-host=127.0.0.1",
    "--bapcustom-server-port=$ServerPort",
    "--bapcustom-join-auth=$gameAuthId",
    "--bapcustom-join-host=$gameDns",
    "--bapcustom-join-ws=$wsPort",
    "--bapcustom-join-kcp=$kcpPort",
    "--bapcustom-join-tcp=$tcpPort"
)
$g = Start-Process -FilePath $gameExe -ArgumentList $argList -WorkingDirectory $gameDir -PassThru
Write-Host "Game PID=$($g.Id)" -ForegroundColor Green

Write-Host "`n=== Step 3: Wait for match start ($WaitSeconds seconds), screenshot every 30s ===" -ForegroundColor Cyan
$shotsDir = "$Root\tools\logs\autotest-shots"
New-Item -ItemType Directory -Path $shotsDir -ErrorAction SilentlyContinue | Out-Null
$elapsed = 0
$shotIndex = 0
while ($elapsed -lt $WaitSeconds) {
    Start-Sleep -Seconds 30
    $elapsed += 30
    $shotIndex++
    $proc = Get-Process -Id $g.Id -ErrorAction SilentlyContinue
    if (-not $proc) { Write-Host "Game died at ${elapsed}s"; break }
    $hwnd = $proc.MainWindowHandle.ToInt64()
    if ($hwnd -eq 0) { Write-Host "[t=${elapsed}s] no window yet"; continue }
    $shotPath = "$shotsDir\shot-${elapsed}s.png"
    try {
        & "$Root\tools\Take-HwndShot.ps1" -Hwnd $hwnd -Path $shotPath 2>&1 | Out-Null
        if (Test-Path $shotPath) {
            $size = [int]((Get-Item $shotPath).Length / 1024)
            Write-Host "[t=${elapsed}s] shot saved: shot-${elapsed}s.png (${size} KB)"
        }
    } catch { Write-Host "[t=${elapsed}s] shot failed" }
}

Write-Host "`n=== Step 4: Mod log analysis ===" -ForegroundColor Cyan
$modLog = "$Root\Spiel\Battleroyalebuild\MelonLoader\Latest.log"
$keyEvents = Get-Content $modLog -ErrorAction SilentlyContinue | Where-Object {
    $_ -match '\[MapFix\]|\[CrateFix\]|\[AugmentFix\]|\[MatchFoundDedup\]|\[DevPanel\]|preMatch|Match has|StartZone|Forced gameMode|currentGameMode|Bootstrap payload|spawnPoints'
} | Select-Object -Last 30
$keyEvents | ForEach-Object { Write-Host "  $_" }

Write-Host "`n=== Step 5: Dedicated server log analysis ===" -ForegroundColor Cyan
$srvLog = Get-ChildItem "$Root\CustomMatchServer\logs\game-servers" -Filter '*.log' -ErrorAction SilentlyContinue | Sort-Object LastWriteTime -Descending | Select-Object -First 1
if ($srvLog) {
    Write-Host "Server log: $($srvLog.Name)"
    Get-Content $srvLog.FullName | Where-Object {
        $_ -match '\[GameMode\]|\[LIFECYCLE\]|\[PRE-MATCH\]|\[CHAR SELECT\]|\[SPAWN SELECT\]|connected|disconnect|teamId|StartZone|spawnPoints'
    } | Where-Object { $_ -notmatch 'shader|Shader' } | Select-Object -Last 25 | ForEach-Object { Write-Host "  $_" }
}

Write-Host "`nDONE. Game still running PID=$($g.Id). Use Get-Process bapbap to check." -ForegroundColor Cyan

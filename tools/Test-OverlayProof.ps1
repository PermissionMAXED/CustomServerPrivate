$ErrorActionPreference = "Continue"
$Root = "C:\Users\Administrator\Downloads\CustomServer"
$Stamp = (Get-Date -Format "yyyyMMdd-HHmmss")
$RunLog = Join-Path $Root "tools\logs\overlay-prove-$Stamp.log"
$watch = [System.Diagnostics.Stopwatch]::StartNew()
$HardTimeoutSec = 180

function Log($m) {
    $el = [Math]::Round($watch.Elapsed.TotalSeconds, 1)
    "[t+${el}s] $m" | Tee-Object -FilePath $RunLog -Append | Out-Host
}

# 1. Start server
Log "Starting server"
$env:ASPNETCORE_URLS = "http://127.0.0.1:5198"
$env:CustomServer__PublicBaseUrl = "http://127.0.0.1:5198"
$env:CustomServer__LaunchGameServers = "false"
$srv = Start-Process dotnet `
    -ArgumentList "$Root\CustomMatchServer\bin\Release\net10.0\BapCustomServer.dll" `
    -PassThru `
    -RedirectStandardOutput "$Root\tools\logs\op-srv.log" `
    -RedirectStandardError "$Root\tools\logs\op-srv-err.log" `
    -WindowStyle Hidden `
    -WorkingDirectory $Root
Log "  server PID=$($srv.Id)"

# Wait for healthy
$ok = $false
for ($i = 0; $i -lt 20; $i++) {
    Start-Sleep -Milliseconds 500
    try {
        $h = Invoke-RestMethod "http://127.0.0.1:5198/health" -TimeoutSec 1 -ErrorAction Stop
        if ($h.ok) { $ok = $true; break }
    } catch { }
}
if (-not $ok) { Log "Server not healthy. abort"; exit 1 }
Log "Server ready"

# 2. Start game
Log "Starting game"
$g = Start-Process -FilePath "$Root\Spiel\Battleroyalebuild\bapbap.exe" `
    -ArgumentList "--melonloader.agfoffline" `
    -WorkingDirectory "$Root\Spiel\Battleroyalebuild" `
    -PassThru
Log "  game PID=$($g.Id)"

# 3. Poll melon log for "Opening Lobby UI" - that's when GUI is fully rendering
$melonLog = "$Root\Spiel\Battleroyalebuild\MelonLoader\Latest.log"
$playerLog = "$env:LOCALAPPDATA\..\LocalLow\gg.bapbap\BAPBAP\Player.log"
$lobbyReady = $false
for ($i = 0; $i -lt 120; $i++) {
    if ($watch.Elapsed.TotalSeconds -ge $HardTimeoutSec) { Log "TIMEOUT"; break }
    Start-Sleep -Seconds 1
    $p = Get-Process -Id $g.Id -ErrorAction SilentlyContinue
    if (-not $p) { Log "Game DIED at +$([Math]::Round($watch.Elapsed.TotalSeconds, 1))s"; break }

    # Try to detect "Opening Lobby UI" in player log
    $hit = Select-String -Path "C:\Users\Administrator\AppData\LocalLow\gg.bapbap\BAPBAP\Player.log" -Pattern "Opening Lobby UI" -ErrorAction SilentlyContinue | Select-Object -Last 1
    if ($hit) {
        Log "  Lobby UI ready at iteration $i"
        $lobbyReady = $true
        # Take TWO screenshots quickly: now and 2s later
        & powershell -ExecutionPolicy Bypass -File "$Root\tools\Take-WindowShot.ps1" -ProcId $g.Id -Path "$Root\tools\logs\overlay-prove-$Stamp-immediate.png" 2>&1 | Out-Null
        Start-Sleep -Seconds 2
        if (Get-Process -Id $g.Id -ErrorAction SilentlyContinue) {
            & powershell -ExecutionPolicy Bypass -File "$Root\tools\Take-WindowShot.ps1" -ProcId $g.Id -Path "$Root\tools\logs\overlay-prove-$Stamp-plus2.png" 2>&1 | Out-Null
        }
        break
    }
}

# 4. Try a final screenshot regardless
$p = Get-Process -Id $g.Id -ErrorAction SilentlyContinue
if ($p) {
    & powershell -ExecutionPolicy Bypass -File "$Root\tools\Take-WindowShot.ps1" -ProcId $g.Id -Path "$Root\tools\logs\overlay-prove-$Stamp-final.png" 2>&1 | Out-Null
    Log "  final screenshot taken"
}

# 5. Print sizes
Get-ChildItem "$Root\tools\logs\overlay-prove-$Stamp-*.png" -ErrorAction SilentlyContinue | ForEach-Object {
    Log "  $($_.Name): $([Math]::Round($_.Length/1KB,1)) KB"
}

Log "=== END elapsed=$([Math]::Round($watch.Elapsed.TotalSeconds, 1))s lobbyReady=$lobbyReady ==="
exit 0

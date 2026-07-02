$ErrorActionPreference = "Continue"
$Root = "C:\Users\Administrator\Downloads\CustomServer"
$Logs = Join-Path $Root "tools\logs"
$RunStamp = (Get-Date -Format "yyyyMMdd-HHmmss")
$RunLog = Join-Path $Logs "captest-$RunStamp.log"

$watch = [System.Diagnostics.Stopwatch]::StartNew()
$HardTimeoutSec = 240

function Log($m) {
    $ts = (Get-Date -Format "HH:mm:ss")
    $el = [Math]::Round($watch.Elapsed.TotalSeconds, 1)
    "$ts [t+${el}s] $m" | Tee-Object -FilePath $RunLog -Append | Out-Host
}

function Check-Timeout {
    if ($watch.Elapsed.TotalSeconds -ge $HardTimeoutSec) {
        Log "!! HARD TIMEOUT after $HardTimeoutSec s"
        Get-Process -Name 'bapbap' -ErrorAction SilentlyContinue | Stop-Process -Force
        Log "exit 99"
        exit 99
    }
}

Log "=== START captest-$RunStamp ==="

# Step 1: kill
Log "[1] kill old processes"
Get-Process -Name "bapbap","BapCustomServer" -ErrorAction SilentlyContinue | Stop-Process -Force -ErrorAction SilentlyContinue
Start-Sleep -Seconds 2

# Step 2: start server with cap=1
Log "[2] start server MaxConcurrentMatches=1"
$env:ASPNETCORE_URLS = "http://127.0.0.1:5198"
$env:CustomServer__PublicBaseUrl = "http://127.0.0.1:5198"
$env:CustomServer__LaunchGameServers = "false"
$env:CustomServer__MatchmakingPolicy = "Both"
$env:CustomServer__MaxConcurrentMatches = "1"
$srv = Start-Process dotnet `
    -ArgumentList "$Root\CustomMatchServer\bin\Release\net10.0\BapCustomServer.dll" `
    -PassThru `
    -RedirectStandardOutput "$Logs\cap-srv.log" `
    -RedirectStandardError "$Logs\cap-srv-err.log" `
    -WindowStyle Hidden `
    -WorkingDirectory $Root
Log "    server PID=$($srv.Id)"

# health
$ok = $false
for ($i = 0; $i -lt 20; $i++) {
    Check-Timeout
    Start-Sleep -Milliseconds 500
    try {
        $h = Invoke-RestMethod "http://127.0.0.1:5198/health" -TimeoutSec 1 -ErrorAction Stop
        if ($h.ok) { $ok = $true; break }
    } catch { }
}
if (-not $ok) { Log "    server not healthy. FAIL"; exit 1 }
Log "    server healthy"

# Step 3: verify config
$cfg = Invoke-RestMethod "http://127.0.0.1:5198/api/server-config" -TimeoutSec 2
Log "[3] config: policy=$($cfg.matchmakingPolicy) custom=$($cfg.allowCustomMatch) mm=$($cfg.allowMatchmaking)"

# Step 4: first force-start
Log "[4] FIRST match - should succeed"
$startLog1 = Join-Path $Logs "captest-$RunStamp-start1.log"
& powershell -ExecutionPolicy Bypass -File "$Root\tools\Force-StartMatch.ps1" `
    -ServerPort 5198 -LeaderAccountId cap-test-1 -LeaderUsername CapTest1 -LobbyId LOBBY1 2>&1 |
    Tee-Object -FilePath $startLog1 |
    ForEach-Object { Log "    [s1] $_" }
Check-Timeout

# Step 5: verify 1 active match
Start-Sleep -Seconds 2
try {
    $matches = Invoke-RestMethod "http://127.0.0.1:5198/admin/matches" -Headers @{ "X-Admin-Token" = "" } -TimeoutSec 3
    $cnt = ($matches | Measure-Object).Count
    Log "[5] /admin/matches count=$cnt"
} catch { Log "    err: $_" }

# Step 6: SECOND force-start - should FAIL with ERR_SERVER_FULL
Log "[6] SECOND match - MUST be blocked with ERR_SERVER_FULL"
$startLog2 = Join-Path $Logs "captest-$RunStamp-start2.log"
& powershell -ExecutionPolicy Bypass -File "$Root\tools\Force-StartMatch.ps1" `
    -ServerPort 5198 -LeaderAccountId cap-test-2 -LeaderUsername CapTest2 -LobbyId LOBBY2 2>&1 |
    Tee-Object -FilePath $startLog2 |
    ForEach-Object { Log "    [s2] $_" }
Check-Timeout

# Step 7: check server log for ERR_SERVER_FULL
Log "[7] verify server logged ERR_SERVER_FULL"
$hits = Select-String -Path "$Logs\cap-srv.log" -Pattern "ERR_SERVER_FULL|at capacity" -ErrorAction SilentlyContinue
if ($hits) {
    foreach ($h in $hits) { Log "    [srv] $($h.Line)" }
} else {
    Log "    NO match in server log"
}

# Step 8: cleanup
# Use tracked PID for the server we started; only blanket-kill bapbap (game process).
Log "[8] cleanup"
if ($srv -and !$srv.HasExited) { $srv.Kill() | Out-Null }
Get-Process -Name 'bapbap' -ErrorAction SilentlyContinue | Stop-Process -Force

Log "=== END elapsed=$([Math]::Round($watch.Elapsed.TotalSeconds, 1))s ==="
exit 0

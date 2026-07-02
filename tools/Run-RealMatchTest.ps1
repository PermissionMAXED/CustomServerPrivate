param(
    [int]$ServerPort = 5198,
    [string]$LeaderAccountId = "ui-test-leader",
    [string]$LeaderUsername = "UITestLeader",
    [int]$ClientLobbyWaitSec = 70,
    [int]$MatchObserveSec = 90,
    [int]$HardTimeoutSec = 300,   # 5 minutes
    [switch]$KillFirst
)

# Hard 5-minute wall clock. Anything longer = test failed.
$ErrorActionPreference = "Continue"
$Root = "C:\Users\Administrator\Downloads\CustomServer"
$Logs = Join-Path $Root "tools\logs"
$RunStamp = (Get-Date -Format "yyyyMMdd-HHmmss")
$RunLog  = Join-Path $Logs "real-match-$RunStamp.log"
$ServerStdout = Join-Path $Logs "real-server.log"
$ServerStderr = Join-Path $Logs "real-server-err.log"

$watch = [System.Diagnostics.Stopwatch]::StartNew()

function Log($msg) {
    $ts = (Get-Date -Format "HH:mm:ss.fff")
    $elapsed = [Math]::Round($watch.Elapsed.TotalSeconds, 1)
    "$ts [t+${elapsed}s] $msg" | Tee-Object -FilePath $RunLog -Append | Write-Host
}

function Check-Timeout {
    if ($watch.Elapsed.TotalSeconds -ge $HardTimeoutSec) {
        Log "!! HARD TIMEOUT REACHED ($HardTimeoutSec s). Test FAILED."
        Log "!! Killing all bapbap/dotnet processes to clean up."
        Get-Process -Name "bapbap" -ErrorAction SilentlyContinue |
            Stop-Process -Force -ErrorAction SilentlyContinue
        Log "=== END (FAILED-TIMEOUT) ==="
        exit 99
    }
}

# Watchdog: independent background job that hard-kills processes after timeout in case main loop hangs.
$watchdog = Start-Job -ScriptBlock {
    param($timeoutSec)
    Start-Sleep -Seconds $timeoutSec
    Get-Process -Name "bapbap" -ErrorAction SilentlyContinue |
        Stop-Process -Force -ErrorAction SilentlyContinue
} -ArgumentList ($HardTimeoutSec + 30)

Log "=== START real-match test stamp=$RunStamp hardTimeout=${HardTimeoutSec}s watchdogJob=$($watchdog.Id) ==="

if ($KillFirst) {
    Log "[1] Killing previous bapbap/dotnet processes"
    Get-Process -Name "bapbap" -ErrorAction SilentlyContinue |
        Stop-Process -Force -ErrorAction SilentlyContinue
    Start-Sleep -Seconds 2
}

# Step 1: Start server
Log "[2] Starting server with LaunchGameServers=true on port $ServerPort"
$env:ASPNETCORE_URLS = "http://127.0.0.1:$ServerPort"
$env:CustomServer__PublicBaseUrl = "http://127.0.0.1:$ServerPort"
$env:CustomServer__LaunchGameServers = "true"
$env:CustomServer__RequireGameServerBootstrap = "true"
$env:CustomServer__GameServerReadyTimeoutSeconds = "150"
$env:CustomServer__GameExecutablePath = "$Root\Spiel\Battleroyalebuild\bapbap.exe"
$env:CustomServer__GameWorkingDirectory = "$Root\Spiel\Battleroyalebuild"
$env:CustomServer__GameLogDirectory = "$Root\CustomMatchServer\logs\game-servers"
$env:CustomServer__AdditionalGameArguments = "--melonloader.agfoffline --melonloader.captureplayerlogs"

$serverProc = Start-Process dotnet `
    -ArgumentList "$Root\CustomMatchServer\bin\Release\net10.0\BapCustomServer.dll" `
    -PassThru `
    -RedirectStandardOutput $ServerStdout `
    -RedirectStandardError $ServerStderr `
    -WindowStyle Hidden `
    -WorkingDirectory $Root
Log "    Server PID=$($serverProc.Id)"

$ready = $false
for ($i = 0; $i -lt 30; $i++) {
    Check-Timeout
    Start-Sleep -Milliseconds 500
    try {
        $h = Invoke-RestMethod "http://127.0.0.1:$ServerPort/health" -TimeoutSec 1 -ErrorAction Stop
        if ($h.ok -eq $true -or $h.status -eq "ok") { $ready = $true; break }
    } catch { }
}
if (-not $ready) {
    Log "    SERVER did not become healthy in 15s. FAILED."
    Stop-Job -Id $watchdog.Id -ErrorAction SilentlyContinue
    Remove-Job -Id $watchdog.Id -Force -ErrorAction SilentlyContinue
    exit 1
}
Log "    Server /health OK"

# Step 2: Start visible game client
Log "[3] Starting visible game client"
$gameProc = Start-Process `
    -FilePath "$Root\Spiel\Battleroyalebuild\bapbap.exe" `
    -ArgumentList "--melonloader.agfoffline" `
    -WorkingDirectory "$Root\Spiel\Battleroyalebuild" `
    -PassThru
$GamePid = $gameProc.Id
Log "    Game client PID=$GamePid"

# Step 3: Poll for visible client lobby
Log "[4] Polling /admin/lobbies for client lobby (max ${ClientLobbyWaitSec}s)"
$LobbyId = $null
$lobbyDeadline = $watch.Elapsed.TotalSeconds + $ClientLobbyWaitSec
while ($watch.Elapsed.TotalSeconds -lt $lobbyDeadline) {
    Check-Timeout
    Start-Sleep -Seconds 2
    try {
        $r = Invoke-RestMethod "http://127.0.0.1:$ServerPort/admin/lobbies" `
            -Headers @{ "X-Admin-Token" = "" } `
            -TimeoutSec 3 -ErrorAction Stop
        if ($r) {
            $lobby = $null
            if ($r -is [System.Array]) {
                $lobby = $r | Where-Object { $_.leaderAccountId -eq $LeaderAccountId } | Select-Object -First 1
            } elseif ($r.leaderAccountId -eq $LeaderAccountId) {
                $lobby = $r
            }
            if ($lobby) {
                $LobbyId = $lobby.id
                Log "    LOBBY FOUND: $LobbyId leader=$LeaderAccountId"
                break
            }
        }
    } catch {
        Log "    /admin/lobbies err: $_"
    }
}
if (-not $LobbyId) {
    Log "    Visible client did not appear in lobby. FAILED."
    Stop-Job -Id $watchdog.Id -ErrorAction SilentlyContinue
    Remove-Job -Id $watchdog.Id -Force -ErrorAction SilentlyContinue
    exit 2
}

# Step 4: Pre-shot
$preShot = Join-Path $Logs "rmt-$RunStamp-pre.png"
& powershell -ExecutionPolicy Bypass -File "$Root\tools\Take-WindowShot.ps1" -ProcId $GamePid -Path $preShot 2>&1 | Out-Null
Log "[5] Pre-start screenshot saved: $preShot"

# Step 5: Force start
Log "[6] Force-StartMatch with lobby $LobbyId"
$startLog = Join-Path $Logs "rmt-$RunStamp-startmatch.log"
& powershell -ExecutionPolicy Bypass -File "$Root\tools\Force-StartMatch.ps1" `
    -ServerPort $ServerPort `
    -LeaderAccountId $LeaderAccountId `
    -LeaderUsername $LeaderUsername `
    -LobbyId $LobbyId 2>&1 | Tee-Object -FilePath $startLog | ForEach-Object { Log "    [start] $_" }

# Step 6: Observe
Log "[7] Observing match for ${MatchObserveSec}s. Screenshots at +5/+15/+30/+60s."
$observeStart = $watch.Elapsed.TotalSeconds
$shotTimes = @(5, 15, 30, 60) | Where-Object { $_ -le $MatchObserveSec }
$shotIndex = 0

while (($watch.Elapsed.TotalSeconds - $observeStart) -lt $MatchObserveSec) {
    Check-Timeout
    Start-Sleep -Milliseconds 1000
    $elapsed = [int]($watch.Elapsed.TotalSeconds - $observeStart)
    if ($shotIndex -lt $shotTimes.Count -and $elapsed -ge $shotTimes[$shotIndex]) {
        $t = $shotTimes[$shotIndex]
        $shot = Join-Path $Logs "rmt-$RunStamp-t$t.png"
        & powershell -ExecutionPolicy Bypass -File "$Root\tools\Take-WindowShot.ps1" -ProcId $GamePid -Path $shot 2>&1 | Out-Null
        $size = (Get-Item $shot -ErrorAction SilentlyContinue).Length
        $port7777 = (Test-NetConnection -ComputerName 127.0.0.1 -Port 7777 -WarningAction SilentlyContinue -InformationLevel Quiet)
        $port7778 = (Test-NetConnection -ComputerName 127.0.0.1 -Port 7778 -WarningAction SilentlyContinue -InformationLevel Quiet)
        try {
            $matches = Invoke-RestMethod "http://127.0.0.1:$ServerPort/admin/matches" -Headers @{ "X-Admin-Token" = "" } -TimeoutSec 3 -ErrorAction Stop
            $matchCount = ($matches | Measure-Object).Count
        } catch { $matchCount = "ERR" }
        Log "    T+${t}s shot=${size}B port7777=$port7777 port7778=$port7778 activeMatches=$matchCount"
        $shotIndex++
    }
}

# Final
Log "[8] FINAL"
try {
    $matches = Invoke-RestMethod "http://127.0.0.1:$ServerPort/admin/matches" -Headers @{ "X-Admin-Token" = "" } -TimeoutSec 3
    Log "    matches: $($matches | ConvertTo-Json -Compress -Depth 5)"
} catch { Log "    matches err: $_" }

$gsLogDir = Join-Path $Root "CustomMatchServer\logs\game-servers"
if (Test-Path $gsLogDir) {
    $latestGs = Get-ChildItem $gsLogDir -Filter "*.log" -ErrorAction SilentlyContinue |
        Sort-Object LastWriteTime -Descending | Select-Object -First 1
    if ($latestGs) {
        Log "    Latest game-server log: $($latestGs.FullName) [$($latestGs.Length) B]"
    } else {
        Log "    NO game-server logs found"
    }
}

Log "    Server log tail:"
Get-Content $ServerStdout -Tail 30 -ErrorAction SilentlyContinue | ForEach-Object { Log "      $_" }
Log "    Server err tail:"
Get-Content $ServerStderr -Tail 15 -ErrorAction SilentlyContinue | ForEach-Object { Log "      $_" }

Log "=== END (success) totalElapsed=$([Math]::Round($watch.Elapsed.TotalSeconds,1))s ==="

# Clean up watchdog
Stop-Job -Id $watchdog.Id -ErrorAction SilentlyContinue
Remove-Job -Id $watchdog.Id -Force -ErrorAction SilentlyContinue

exit 0

param(
    [Parameter(Mandatory=$true)] [string]$Command,
    [int]$TimeoutSec = 300,
    [string]$LogFile = ""
)

# Runs $Command in a new cmd.exe window via /B (background) so its stdout/stderr
# are NOT connected to this shell. Tracks the spawned PID and enforces a hard timeout.
# After timeout, ALL child processes are killed and the script returns exit code 99.

$ErrorActionPreference = "Continue"
$watch = [System.Diagnostics.Stopwatch]::StartNew()

if (-not $LogFile) {
    $LogFile = Join-Path $env:TEMP "run-$([Guid]::NewGuid().ToString('N').Substring(0,8)).log"
}

# Use cmd /c start /B to spawn truly detached, redirecting output via cmd's > operator.
# This avoids PowerShell's Start-Process pipe issue.
$batCmd = "$Command > `"$LogFile`" 2>&1"
$proc = Start-Process cmd -ArgumentList "/c", $batCmd -WindowStyle Hidden -PassThru
$pidNum = $proc.Id

Write-Host "RUN_PID=$pidNum LOG=$LogFile"

while (-not $proc.HasExited) {
    if ($watch.Elapsed.TotalSeconds -ge $TimeoutSec) {
        Write-Host "!! HARD TIMEOUT after ${TimeoutSec}s. Killing process tree."
        try { taskkill /T /F /PID $pidNum 2>&1 | Out-Null } catch {}
        Write-Host "EXIT=99 (timeout)"
        if (Test-Path $LogFile) {
            Write-Host "--- log tail ---"
            Get-Content $LogFile -Tail 20 -ErrorAction SilentlyContinue
        }
        exit 99
    }
    Start-Sleep -Milliseconds 500
}

$rc = $proc.ExitCode
Write-Host "EXIT=$rc elapsed=$([Math]::Round($watch.Elapsed.TotalSeconds,1))s"
if (Test-Path $LogFile) {
    Write-Host "--- output ---"
    Get-Content $LogFile -ErrorAction SilentlyContinue
}
exit $rc

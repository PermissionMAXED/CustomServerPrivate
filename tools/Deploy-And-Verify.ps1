param(
  [string]$BaseUrl = "http://ark.atomi23.de:5055",
  [string]$ExpectedModSha = "38301be1c46939e57ad5e2e40703b537cac0ea7cb7f523f8fdcd975c3957a5ec",
  [int]$HealthTimeoutSec = 240
)
# One-shot: deploy the netcustomchar zip to live AMP, then poll /health until the server is back
# up AND reports the new build. Requires a valid token in %TEMP%\amp_session.txt
# (run tools\Login-AmpInteractive.ps1 first). Safe to re-run.
$ErrorActionPreference = "Stop"
$root = "C:\Users\Administrator\Downloads\CustomServer"

$tf = Join-Path $env:TEMP "amp_session.txt"
if (-not (Test-Path $tf)) { throw "No token at $tf. Run tools\Login-AmpInteractive.ps1 first." }

Write-Host "=== Pre-deploy /health ==="
try { $pre = Invoke-RestMethod "$BaseUrl/health" -TimeoutSec 12; Write-Host ("  release=" + $pre.release + " medusaDll=" + $pre.artifacts.modApiDllSha256) } catch { Write-Host "  (unreachable)" }

Write-Host "=== Deploying (stops + restarts production) ==="
& "$root\tools\Deploy-NetCustomChar.ps1"
if ($LASTEXITCODE -ne $null -and $LASTEXITCODE -ne 0) { Write-Host "WARN: deploy script exit=$LASTEXITCODE" }

Write-Host "=== Waiting for server to come back (max ${HealthTimeoutSec}s) ==="
$sw = [System.Diagnostics.Stopwatch]::StartNew()
$ok = $false
while ($sw.Elapsed.TotalSeconds -lt $HealthTimeoutSec) {
  Start-Sleep 8
  try {
    $h = Invoke-RestMethod "$BaseUrl/health" -TimeoutSec 10
    $line = "  t+{0}s release={1} ok={2} prewarm={3} medusaAvail={4}" -f [int]$sw.Elapsed.TotalSeconds, $h.release, $h.ok, $h.prewarm.state, $h.medusa.available
    Write-Host $line
    if ($h.ok -and $h.medusa.available) {
      # Report all artifact hashes so we can confirm the new Medusa DLL landed.
      Write-Host ("  serverDll=" + $h.artifacts.serverDllSha256)
      Write-Host ("  medusaDll=" + $h.artifacts.medusaDllSha256)
      Write-Host ("  modApiDll=" + $h.artifacts.modApiDllSha256)
      $ok = $true; break
    }
  } catch { Write-Host ("  t+{0}s (not ready: {1})" -f [int]$sw.Elapsed.TotalSeconds, $_.Exception.Message) }
}
if ($ok) { Write-Host "=== DEPLOY+HEALTH OK ===" } else { Write-Host "=== TIMED OUT waiting for healthy server - check AMP console ===" }

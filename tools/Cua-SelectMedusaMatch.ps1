param(
  [string]$GamePath = "C:\Users\Administrator\Downloads\CustomServer\Spiel\Battleroyalebuild\bapbap.exe",
  [string]$Base = "http://ark.atomi23.de:5055"
)
$ErrorActionPreference = "Continue"
$cua = "C:\Users\Administrator\AppData\Local\Programs\Cua\cua-driver\bin\cua-driver.exe"
$dir = "C:\Users\Administrator\Downloads\CustomServer\logs\cua"
New-Item -ItemType Directory -Force -Path $dir | Out-Null
function Cua($tool, $json) { $json | & $cua call $tool 2>&1 }
function Shot($pid_, $wid, $tag) {
  $p = Join-Path $dir ("auto-$tag-{0}.png" -f (Get-Date -Format HHmmss))
  $r = (Cua "get_window_state" "{`"pid`":$pid_,`"window_id`":$wid}") -join "`n"
  $w = if ($r -match '"screenshot_width":\s*(\d+)') { [int]$Matches[1] } else { 0 }
  $h = if ($r -match '"screenshot_height":\s*(\d+)') { [int]$Matches[1] } else { 0 }
  Cua "get_window_state" "{`"pid`":$pid_,`"window_id`":$wid}" *> $null
  # capture to file
  '{"pid":'+$pid_+',"window_id":'+$wid+'}' | & $cua call get_window_state --screenshot-out-file $p *> $null
  return @{ path=$p; w=$w; h=$h }
}
function ClickRel($pid_, $wid, $rx, $ry, $w, $h) {
  $x=[int]($rx*$w); $y=[int]($ry*$h)
  Cua "click" "{`"pid`":$pid_,`"window_id`":$wid,`"x`":$x,`"y`":$y,`"dispatch`":`"foreground`"}" *> $null
}

# 1) Fresh client
Get-Process bapbap -ErrorAction SilentlyContinue | ForEach-Object { try { '{"pid":'+$_.Id+'}' | & $cua call kill_app *>$null } catch {} }
Start-Sleep -Seconds 3
$lr = ('{"path":"'+($GamePath -replace '\\','\\')+'","additional_arguments":["--melonloader.agfoffline","--melonloader.captureplayerlogs"]}') | & $cua call launch_app 2>&1
$gpid = if ((($lr) -join "`n") -match '"pid":\s*(\d+)') { [int]$Matches[1] } else { 0 }
Write-Host "launched pid=$gpid"
Start-Sleep -Seconds 52

# 2) find window
$wins = ('{"pid":'+$gpid+'}' | & $cua call list_windows 2>&1) -join "`n"
$wid = 0
foreach ($m in [regex]::Matches($wins,'"title":\s*"BAPBAP"[^}]*?"window_id":\s*(\d+)','Singleline')) { $wid=[int]$m.Groups[1].Value; break }
if ($wid -eq 0) { foreach ($m in [regex]::Matches($wins,'"window_id":\s*(\d+)')) { $wid=[int]$m.Groups[1].Value; break } }
Write-Host "window=$wid"
$s = Shot $gpid $wid "lobby"; Write-Host ("lobby shot {0} {1}x{2}" -f $s.path,$s.w,$s.h)

# 3) READY (relative bottom-right)
ClickRel $gpid $wid 0.883 0.886 $s.w $s.h
Write-Host "clicked READY; waiting for match..."

# 4) poll server log for match start (connected successfully) up to 150s
$startSeen=$false
for ($i=0; $i -lt 30; $i++) {
  Start-Sleep -Seconds 5
  try {
    $g = Invoke-RestMethod -Uri "$Base/api/diagnostics/game-logs?tailLines=40&files=2" -TimeoutSec 12
    $gt = if ($g -is [string]) { $g } else { ($g | ConvertTo-Json -Depth 8) }
    if ($gt -match 'connected successfully') { $startSeen=$true; Write-Host "match start detected (poll $i)"; break }
  } catch {}
}

# 5) fire Medusa-tile + lock-in clicks across the char-select window
Start-Sleep -Seconds 3
for ($k=0; $k -lt 10; $k++) {
  $s2 = Shot $gpid $wid "cs$k"
  if ($s2.w -gt 0) {
    ClickRel $gpid $wid 0.695 0.894 $s2.w $s2.h   # Medusa tile (16th, bottom-right of 2x8 grid)
    Start-Sleep -Milliseconds 400
    ClickRel $gpid $wid 0.498 0.698 $s2.w $s2.h   # LOCK IN
  }
  Start-Sleep -Milliseconds 1600
}

# 6) final spawn shots
Start-Sleep -Seconds 6
$f1 = Shot $gpid $wid "spawn1"
Start-Sleep -Seconds 4
$f2 = Shot $gpid $wid "spawn2"
Write-Host ("SPAWN_SHOTS: {0} | {1}" -f $f1.path,$f2.path)
Write-Host "GPID=$gpid WID=$wid"

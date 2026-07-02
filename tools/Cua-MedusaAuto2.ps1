$ErrorActionPreference="Continue"
$cua="C:\Users\Administrator\AppData\Local\Programs\Cua\cua-driver\bin\cua-driver.exe"
$dir="C:\Users\Administrator\Downloads\CustomServer\logs\cua"
$Base="http://ark.atomi23.de:5055"
$GamePath="C:\Users\Administrator\Downloads\CustomServer\Spiel\Battleroyalebuild\bapbap.exe"
$Acct="codex-v1668-medusa-20260608-0252"; $User="CodexMedusa8"; $Disc="9974"
function Raw($t,$j){ $j | & $cua call $t 2>&1 }
function WH($p,$w){ $r=(Raw "get_window_state" "{`"pid`":$p,`"window_id`":$w}") -join "`n"; $ww=if($r -match '"screenshot_width":\s*(\d+)'){[int]$Matches[1]}else{0}; $hh=if($r -match '"screenshot_height":\s*(\d+)'){[int]$Matches[1]}else{0}; @($ww,$hh) }
function CR($p,$w,$rx,$ry,$ww,$hh){ Raw "click" ("{`"pid`":$p,`"window_id`":$w,`"x`":$([int]($rx*$ww)),`"y`":$([int]($ry*$hh)),`"dispatch`":`"foreground`"}") *>$null }
function Shot($p,$w,$tag){ $f=Join-Path $dir ("m-$tag-{0}.png" -f (Get-Date -Format HHmmss)); ('{"pid":'+$p+',"window_id":'+$w+'}') | & $cua call get_window_state --screenshot-out-file $f *>$null; $f }
function GLog(){ try{ $g=Invoke-RestMethod "$Base/api/diagnostics/game-logs?tailLines=30&files=2" -TimeoutSec 12; if($g -is [string]){$g}else{($g|ConvertTo-Json -Depth 8)} }catch{ "" } }
function QJoin($c){ try{ $h=@{"X-BAP-AccountId"=$Acct;"X-BAP-Username"=$User;"X-BAP-Discriminator"=$Disc}; Invoke-RestMethod "$Base/api/queue/join" -Method POST -Headers $h -ContentType "application/json" -Body (@{charId=$c}|ConvertTo-Json) -TimeoutSec 12 | Out-Null; "queued" }catch{ "qerr:"+$_.Exception.Message } }

Get-Process bapbap -EA SilentlyContinue | ForEach-Object { try{ ('{"pid":'+$_.Id+'}') | & $cua call kill_app *>$null }catch{} }
Start-Sleep 3
$lr=(('{"path":"'+($GamePath -replace '\\','\\')+'","additional_arguments":["--melonloader.agfoffline","--melonloader.captureplayerlogs"]}') | & $cua call launch_app 2>&1) -join "`n"
$gpid=if($lr -match '"pid":\s*(\d+)'){[int]$Matches[1]}else{0}; Write-Host "pid=$gpid"
Start-Sleep 48
$wins=(('{"pid":'+$gpid+'}') | & $cua call list_windows 2>&1) -join "`n"
$wid=0; foreach($m in [regex]::Matches($wins,'"title":\s*"BAPBAP"[^}]*?"window_id":\s*(\d+)','Singleline')){$wid=[int]$m.Groups[1].Value;break}
if($wid -eq 0){foreach($m in [regex]::Matches($wins,'"window_id":\s*(\d+)')){$wid=[int]$m.Groups[1].Value;break}}
Write-Host "wid=$wid"
$bc=([regex]::Matches((GLog),'connected successfully')).Count
$matched=$false
for($r=0;$r -lt 3 -and -not $matched;$r++){
  $sz=WH $gpid $wid
  try{ powershell -NoProfile -ExecutionPolicy Bypass -File "C:\Users\Administrator\Downloads\CustomServer\tools\Force-Foreground.ps1" -Hwnd $wid *>$null }catch{}
  if($sz[0] -gt 0){ CR $gpid $wid 0.883 0.886 $sz[0] $sz[1] }
  Write-Host ("READY r$r win=$($sz[0])x$($sz[1]) "+(QJoin 0))
  for($i=0;$i -lt 14;$i++){ Start-Sleep 5; if(([regex]::Matches((GLog),'connected successfully')).Count -gt $bc){ $matched=$true; Write-Host "MATCH START"; break } }
}
if(-not $matched){ Write-Host "NO_MATCH"; Shot $gpid $wid "nomatch" | Out-Null; Write-Host "wid=$wid pid=$gpid"; return }
Start-Sleep 3
Shot $gpid $wid "cs" | Out-Null
for($k=0;$k -lt 16;$k++){ $sz=WH $gpid $wid; $w=$sz[0]; $h=$sz[1]; if($w -gt 0){ $mrx=0.5 + 178.0/$w; CR $gpid $wid $mrx 0.88 $w $h; Start-Sleep -Milliseconds 300; CR $gpid $wid 0.5 0.67 $w $h }; Start-Sleep -Milliseconds 1200 }
Start-Sleep 6; Shot $gpid $wid "spawn1" | Out-Null
Start-Sleep 4; $f=Shot $gpid $wid "spawn2"
Write-Host "DONE spawn=$f pid=$gpid wid=$wid"

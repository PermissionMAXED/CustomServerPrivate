$cua="C:\Users\Administrator\AppData\Local\Programs\Cua\cua-driver\bin\cua-driver.exe"
$dir="C:\Users\Administrator\Downloads\CustomServer\logs\cua"
$game="C:\Users\Administrator\Downloads\CustomServer\Spiel\Battleroyalebuild"
$FF="C:\Users\Administrator\Downloads\CustomServer\tools\Force-Foreground.ps1"
$Base="http://ark.atomi23.de:5055"
$Acct="codex-v1668-medusa-20260608-0252"; $User="CodexMedusa8"; $Disc="9974"
function Raw($t,$j){ $j | & $cua call $t 2>&1 }
function WH($p,$w){ $r=(Raw "get_window_state" "{`"pid`":$p,`"window_id`":$w}") -join "`n"; $ww=if($r -match '"screenshot_width":\s*(\d+)'){[int]$Matches[1]}else{0}; $hh=if($r -match '"screenshot_height":\s*(\d+)'){[int]$Matches[1]}else{0}; @($ww,$hh) }
function FG($w){ try{ powershell -NoProfile -ExecutionPolicy Bypass -File $FF -Hwnd $w *>$null }catch{} }
function CR($p,$w,$rx,$ry,$ww,$hh){ Raw "click" ("{`"pid`":$p,`"window_id`":$w,`"x`":$([int]($rx*$ww)),`"y`":$([int]($ry*$hh)),`"dispatch`":`"foreground`"}") *>$null }
function RC($p,$w,$rx,$ry,$ww,$hh){ Raw "right_click" ("{`"pid`":$p,`"window_id`":$w,`"x`":$([int]($rx*$ww)),`"y`":$([int]($ry*$hh)),`"dispatch`":`"foreground`"}") *>$null }
function PK($p,$w,$k){ Raw "press_key" ("{`"pid`":$p,`"window_id`":$w,`"key`":`"$k`",`"dispatch`":`"foreground`"}") *>$null }
function Shot($p,$w,$tag){ $f=Join-Path $dir ("nc-$tag-{0}.png" -f (Get-Date -Format HHmmss)); ('{"pid":'+$p+',"window_id":'+$w+'}') | & $cua call get_window_state --screenshot-out-file $f *>$null; $f }
function QJoin($c){ try{ $h=@{"X-BAP-AccountId"=$Acct;"X-BAP-Username"=$User;"X-BAP-Discriminator"=$Disc}; Invoke-RestMethod "$Base/api/queue/join" -Method POST -Headers $h -ContentType "application/json" -Body (@{charId=$c}|ConvertTo-Json) -TimeoutSec 12 | Out-Null; "queued" }catch{ "qerr:"+$_.Exception.Message } }

Get-Process bapbap -EA SilentlyContinue | ForEach-Object { try{ ('{"pid":'+$_.Id+'}') | & $cua call kill_app *>$null }catch{} }
Start-Sleep 3
$lr=(('{"path":"'+($game -replace '\\','\\')+'\\bapbap.exe","additional_arguments":["--melonloader.agfoffline","--melonloader.captureplayerlogs"]}') | & $cua call launch_app 2>&1) -join "`n"
$gpid=if($lr -match '"pid":\s*(\d+)'){[int]$Matches[1]}else{0}; Write-Host "pid=$gpid"
Start-Sleep 50
$wins=(('{"pid":'+$gpid+'}') | & $cua call list_windows 2>&1) -join "`n"
$wid=0; foreach($m in [regex]::Matches($wins,'"title":\s*"BAPBAP"[^}]*?"window_id":\s*(\d+)','Singleline')){$wid=[int]$m.Groups[1].Value;break}
if($wid -eq 0){foreach($m in [regex]::Matches($wins,'"window_id":\s*(\d+)')){$wid=[int]$m.Groups[1].Value;break}}
Write-Host "wid=$wid"
Write-Host ("queue "+(QJoin 15))
Start-Sleep 105
# advance past augment-select (click top card a couple times)
$sz=WH $gpid $wid; $w=$sz[0]; $h=$sz[1]; FG $wid
if($w -gt 0){ CR $gpid $wid 0.864 0.31 $w $h; Start-Sleep -Milliseconds 500; CR $gpid $wid 0.864 0.31 $w $h }
Start-Sleep 5
Shot $gpid $wid "precast" | Out-Null
# cast loop: LMB + RMB + Space + E at spread world points
$pts=@(@(0.62,0.40),@(0.40,0.42),@(0.66,0.58),@(0.36,0.56),@(0.70,0.48),@(0.30,0.52))
for($c=0;$c -lt 20;$c++){
  if($c % 3 -eq 0){ FG $wid }
  $sz=WH $gpid $wid; $w=$sz[0]; $h=$sz[1]
  if($w -gt 0){
    $pt=$pts[$c % $pts.Count]
    CR $gpid $wid $pt[0] $pt[1] $w $h; Start-Sleep -Milliseconds 110
    RC $gpid $wid $pt[0] $pt[1] $w $h; Start-Sleep -Milliseconds 110
    PK $gpid $wid "space"; Start-Sleep -Milliseconds 110
    PK $gpid $wid "e"
  }
  if($c % 3 -eq 0){ Shot $gpid $wid ("cast$c") | Out-Null }
  Start-Sleep -Milliseconds 550
}
$f=Shot $gpid $wid "castfinal"
Write-Host "CAST DONE shot=$f pid=$gpid wid=$wid"
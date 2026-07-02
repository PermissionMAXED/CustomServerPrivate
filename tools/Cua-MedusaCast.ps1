$cua="C:\Users\Administrator\AppData\Local\Programs\Cua\cua-driver\bin\cua-driver.exe"
$dir="C:\Users\Administrator\Downloads\CustomServer\logs\cua"
$Base="http://ark.atomi23.de:5055"
$GamePath="C:\Users\Administrator\Downloads\CustomServer\Spiel\Battleroyalebuild\bapbap.exe"
$LogLocal="C:\Users\Administrator\Downloads\CustomServer\Spiel\Battleroyalebuild\MelonLoader\Latest.log"
$Acct="codex-v1668-medusa-20260608-0252"; $User="CodexMedusa8"; $Disc="9974"
$FF="C:\Users\Administrator\Downloads\CustomServer\tools\Force-Foreground.ps1"
function Raw($t,$j){ $j | & $cua call $t 2>&1 }
function WH($p,$w){ $r=(Raw "get_window_state" "{`"pid`":$p,`"window_id`":$w}") -join "`n"; $ww=if($r -match '"screenshot_width":\s*(\d+)'){[int]$Matches[1]}else{0}; $hh=if($r -match '"screenshot_height":\s*(\d+)'){[int]$Matches[1]}else{0}; @($ww,$hh) }
function FG($w){ try{ powershell -NoProfile -ExecutionPolicy Bypass -File $FF -Hwnd $w *>$null }catch{} }
function CR($p,$w,$rx,$ry,$ww,$hh){ Raw "click" ("{`"pid`":$p,`"window_id`":$w,`"x`":$([int]($rx*$ww)),`"y`":$([int]($ry*$hh)),`"dispatch`":`"foreground`"}") *>$null }
function RC($p,$w,$rx,$ry,$ww,$hh){ Raw "right_click" ("{`"pid`":$p,`"window_id`":$w,`"x`":$([int]($rx*$ww)),`"y`":$([int]($ry*$hh)),`"dispatch`":`"foreground`"}") *>$null }
function PK($p,$w,$k){ Raw "press_key" ("{`"pid`":$p,`"window_id`":$w,`"key`":`"$k`",`"dispatch`":`"foreground`"}") *>$null }
function Shot($p,$w,$tag){ $f=Join-Path $dir ("c-$tag-{0}.png" -f (Get-Date -Format HHmmss)); ('{"pid":'+$p+',"window_id":'+$w+'}') | & $cua call get_window_state --screenshot-out-file $f *>$null; $f }
function QJoin($c){ try{ $h=@{"X-BAP-AccountId"=$Acct;"X-BAP-Username"=$User;"X-BAP-Discriminator"=$Disc}; Invoke-RestMethod "$Base/api/queue/join" -Method POST -Headers $h -ContentType "application/json" -Body (@{charId=$c}|ConvertTo-Json) -TimeoutSec 12 | Out-Null; "queued" }catch{ "qerr:"+$_.Exception.Message } }
function SpawnCount(){ try{ ([regex]::Matches((Get-Content $LogLocal -Raw -ErrorAction SilentlyContinue),'live local diag ready')).Count }catch{ 0 } }

Get-Process bapbap -EA SilentlyContinue | ForEach-Object { try{ ('{"pid":'+$_.Id+'}') | & $cua call kill_app *>$null }catch{} }
Start-Sleep 3
$lr=(('{"path":"'+($GamePath -replace '\\','\\')+'","additional_arguments":["--melonloader.agfoffline","--melonloader.captureplayerlogs"]}') | & $cua call launch_app 2>&1) -join "`n"
$gpid=if($lr -match '"pid":\s*(\d+)'){[int]$Matches[1]}else{0}; Write-Host "pid=$gpid"
Start-Sleep 48
$wins=(('{"pid":'+$gpid+'}') | & $cua call list_windows 2>&1) -join "`n"
$wid=0; foreach($m in [regex]::Matches($wins,'"title":\s*"BAPBAP"[^}]*?"window_id":\s*(\d+)','Singleline')){$wid=[int]$m.Groups[1].Value;break}
if($wid -eq 0){foreach($m in [regex]::Matches($wins,'"window_id":\s*(\d+)')){$wid=[int]$m.Groups[1].Value;break}}
Write-Host "wid=$wid"
$baseSpawn = SpawnCount
Write-Host "baseSpawn=$baseSpawn"
$spawned=$false
for($i=0;$i -lt 100 -and -not $spawned;$i++){
  if(($i % 18) -eq 0){ $sz=WH $gpid $wid; FG $wid; if($sz[0] -gt 0){ CR $gpid $wid 0.883 0.886 $sz[0] $sz[1] }; Write-Host ("Q i=$i "+(QJoin 0)) }
  Start-Sleep 5
  if((SpawnCount) -gt $baseSpawn){ $spawned=$true; Write-Host "SPAWNED i=$i" }
}
if(-not $spawned){ Write-Host "NO_SPAWN"; Shot $gpid $wid "nospawn" | Out-Null; Write-Host "wid=$wid pid=$gpid"; return }
Start-Sleep 30
Shot $gpid $wid "preattack" | Out-Null
$pts=@(@(0.62,0.40),@(0.40,0.42),@(0.66,0.58),@(0.36,0.56),@(0.70,0.48),@(0.32,0.52))
for($c=0;$c -lt 26;$c++){
  if($c % 3 -eq 0){ FG $wid }
  $sz=WH $gpid $wid; $w=$sz[0]; $h=$sz[1]
  if($w -gt 0){
    $pt=$pts[$c % $pts.Count]
    CR $gpid $wid $pt[0] $pt[1] $w $h; Start-Sleep -Milliseconds 110
    RC $gpid $wid $pt[0] $pt[1] $w $h; Start-Sleep -Milliseconds 110
    PK $gpid $wid "space"; Start-Sleep -Milliseconds 110
    PK $gpid $wid "e"; Start-Sleep -Milliseconds 110
    PK $gpid $wid "q"
  }
  if($c % 3 -eq 0){ Shot $gpid $wid ("atk$c") | Out-Null }
  Start-Sleep -Milliseconds 550
}
$f=Shot $gpid $wid "atkfinal"
Write-Host "CAST DONE shot=$f pid=$gpid wid=$wid"
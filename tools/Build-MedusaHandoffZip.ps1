$ErrorActionPreference = "Stop"
$CS   = "C:\Users\Administrator\Downloads\CustomServer"
$MOD  = "C:\Users\Administrator\Downloads\BAPBAPModdingAPI\medusa-mod"
$RE   = "C:\Users\Administrator\Downloads\BAPBAPModdingAPI\BAPBAPModAPI\reverse-engineering"
$BAP  = Join-Path $RE "decompiled\Assembly-CSharp\Il2CppBAPBAP"
$stage= Join-Path $CS "deployment\medusa-native-handoff"
$zip  = Join-Path $CS "deployment\medusa-native-handoff.zip"

function Copy-To($src,$dstDir,$name=$null){
  if(-not (Test-Path -LiteralPath $src)){ Write-Host "  MISS $src"; return }
  New-Item -ItemType Directory -Force -Path $dstDir | Out-Null
  $dst = if($name){ Join-Path $dstDir $name } else { Join-Path $dstDir (Split-Path $src -Leaf) }
  Copy-Item -LiteralPath $src -Destination $dst -Force
  Write-Host ("  + {0} ({1:N0} B)" -f (Split-Path $dst -Leaf),(Get-Item $dst).Length)
}

# --- source: medusa mod (the file to edit) ---
$mdst = Join-Path $stage "source\medusa-mod"
foreach($f in 'MedusaMod.cs','MedusaMelon.cs','MedusaMelonAttributes.cs','PrematchMedusaClickProxy.cs','BAPBAP.Medusa.csproj','README.md','DOCUMENTATION.md'){ Copy-To (Join-Path $MOD $f) $mdst }

# --- source: server char flow (context) ---
$sdst = Join-Path $stage "source\server"
foreach($f in 'LobbyService.cs','CustomServerOptions.cs','Contracts.cs','Program.cs','MatchmakingQueueService.cs'){ Copy-To (Join-Path $CS "CustomMatchServer\$f") $sdst }

# --- source: client mod (context) ---
Copy-To (Join-Path $CS "BapCustomServerMelon\CustomServerMod.cs") (Join-Path $stage "source\client-mod")

# --- source-mapping: relevant decompiled native classes ---
$ddst = Join-Path $stage "source-mapping\decompiled"
$classes = @('PreMatchManager.cs','PlayerPreMatch.cs','GameMode.cs','GameNetworkManager.cs','PlayerManager.cs','EntityManager.cs','CharAbilities.cs','Ability.cs','CharacterConfiguration.cs','UICharactersConfiguration.cs','UILobbyCharacterSelectPage.cs','UILobbyMatchCharacterSelectPage.cs','CharSelectController.cs','View_PreMatch_CharSelect.cs','MatchmakingPlayerData.cs','QueueMatchedData.cs','CharacterPageModel.cs','CharacterSelectModel.cs','CharManager.cs','UIPreMatch.cs','UILobbyPlayTabPage.cs')
if(Test-Path -LiteralPath $BAP){
  $found = Get-ChildItem -LiteralPath $BAP -Recurse -File -Include $classes -ErrorAction SilentlyContinue
  New-Item -ItemType Directory -Force -Path $ddst | Out-Null
  foreach($cf in $found){
    $rel = $cf.FullName.Substring($BAP.Length).TrimStart('\')
    $target = Join-Path $ddst $rel
    New-Item -ItemType Directory -Force -Path (Split-Path $target -Parent) | Out-Null
    Copy-Item -LiteralPath $cf.FullName -Destination $target -Force
  }
  Write-Host ("  decompiled classes copied: {0}" -f $found.Count)
} else { Write-Host "  MISS decompiled BAP tree: $BAP" }
# RE research notes (characters)
Copy-To (Join-Path $RE "research\CHARACTERS_RESEARCH.md") (Join-Path $stage "source-mapping\research")

# --- tools (build/deploy/diag/cua) ---
$tdst = Join-Path $stage "tools"
foreach($t in 'Build-AmpFullLinuxWinePackage.ps1','Invoke-AmpHotfixDeploy.ps1','Build-MedusaHotfixZip.ps1','Get-LiveDiag.ps1','Cua-MedusaAuto2.ps1','Force-Foreground.ps1','Select-MedusaOnPrematch.ps1','Install-BapCustomServerMelon.ps1'){ Copy-To (Join-Path $CS "tools\$t") $tdst }

# --- project context docs ---
foreach($d in 'CONTEXT.md','MISSION.md','AI_HANDOFF.md'){ Copy-To (Join-Path $CS $d) $stage }

# --- live state ---
$infoSrc = Join-Path $CS "deployment\amp-full-linux-wine\package\BapCustomServer\deployment-info.json"
Copy-To $infoSrc $stage "deployment-info.json"
try { (Invoke-RestMethod -Uri 'http://ark.atomi23.de:5055/health' -TimeoutSec 12 | ConvertTo-Json -Depth 8) | Set-Content -LiteralPath (Join-Path $stage "health.json") -Encoding UTF8; Write-Host "  + health.json (live)" } catch { Write-Host "  health fetch failed: $($_.Exception.Message)" }
$medusaDll = Join-Path $MOD "bin\Release\BAPBAP.Medusa.dll"
$mh = if(Test-Path $medusaDll){ (Get-FileHash $medusaDll -Algorithm SHA256).Hash } else { "n/a" }
@"
# Live state snapshot ($(Get-Date -Format s))
Live AMP: http://ark.atomi23.de:5055  (release: medusa-v1728-charsel-time)
Clobber/Skinny bug: FIXED + verified live 3x (current MedusaMod.cs has interim fix; refactor should remove the whole record/restore subsystem).
Current built BAPBAP.Medusa.dll SHA256 (clobber-fix build): $mh
Medusa: charId 15, Mirror asset 0x4D454455, base clone = Kitsu(0), skinAssetId=-1. Registered + selectable (16th card) verified live.
Char ids: 0 Kitsu,1 Anna,2 Chuck,3 Sashimi,4 Kiddo,5 Zook,6 Skinny,7 Froggy,8 Teevee,9 Sofia,10 Jiro,11 Bishop,12 Celeste,13 Kate,14 Rocky,15 Medusa.
Edit: source/medusa-mod/MedusaMod.cs  (see HANDOFF.md section 3). Deliver the edited file back.
"@ | Set-Content -LiteralPath (Join-Path $stage "STATE.md") -Encoding UTF8
Write-Host "  + STATE.md"

# --- zip (forward-slash entries for cross-tool/AI compatibility) ---
if(Test-Path -LiteralPath $zip){ Remove-Item -LiteralPath $zip -Force }
Add-Type -AssemblyName System.IO.Compression
Add-Type -AssemblyName System.IO.Compression.FileSystem
$za=[System.IO.Compression.ZipFile]::Open($zip,[System.IO.Compression.ZipArchiveMode]::Create)
try {
  foreach($f in (Get-ChildItem -LiteralPath $stage -Recurse -File)){
    $rel = ($f.FullName.Substring($stage.Length).TrimStart('\') -replace '\\','/')
    [System.IO.Compression.ZipFileExtensions]::CreateEntryFromFile($za,$f.FullName,$rel,[System.IO.Compression.CompressionLevel]::Optimal) | Out-Null
  }
} finally { $za.Dispose() }
$zi = Get-Item $zip
Write-Host ("`nZIP: {0}  ({1:N1} MB)" -f $zip, ($zi.Length/1MB))
$z=[System.IO.Compression.ZipFile]::OpenRead($zip); try { Write-Host ("entries: {0}" -f $z.Entries.Count); Write-Host "verify key entries:"; foreach($k in 'HANDOFF.md','source/medusa-mod/MedusaMod.cs','source/server/LobbyService.cs','source/client-mod/CustomServerMod.cs','tools/Invoke-AmpHotfixDeploy.ps1'){ $h=$z.Entries|Where-Object{$_.FullName -eq $k}|Select-Object -First 1; Write-Host ("  {0}: {1}" -f $k,($(if($h){'OK'}else{'MISS'}))) }; $dm=($z.Entries|Where-Object{$_.FullName -match 'source-mapping/decompiled/.*/(PreMatchManager|GameMode|GameNetworkManager|PlayerManager|CharacterConfiguration|UICharactersConfiguration|PlayerPreMatch)\.cs$'}); Write-Host ("  key decompiled classes: {0} found" -f $dm.Count); $dm | Select-Object -First 8 | ForEach-Object { Write-Host ("    "+$_.FullName) } } finally { $z.Dispose() }

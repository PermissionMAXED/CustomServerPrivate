#requires -version 5
<#
.SYNOPSIS
  Build a custom-map AssetBundle headlessly via Unity + MapBundleBuilder.

.DESCRIPTION
  Mirrors tools/Build-CharBundle.ps1. Invokes the ExportedProject's MapBundleBuilder.Build editor
  method to package an existing <mapname>_bakedata folder (the baked SerializedLevelHolder Sv/Cl
  prefab pair + NavData/Minimap) into a single AssetBundle named "<mapname>" (lowercase).

  REQUIRES an active Unity 2022.3.38f1 license. If you see "No valid Unity Editor license found"
  in the log, activate via Unity Hub (sign in -> Personal license) or a manual .ulf, then re-run.

.EXAMPLE
  pwsh tools/Build-MapBundle.ps1 -MapName CustomFlat
#>
param(
    [Parameter(Mandatory = $true)] [string] $MapName,
    [string] $UnityExe = 'C:\Program Files\Unity\Hub\Editor\2022.3.38f1\Editor\Unity.exe',
    [string] $ProjectPath = 'C:\Users\Administrator\Downloads\neueBapbap\GameCode\ExportedProject',
    [string] $BuildOut = '',
    [string] $BakedataDir = '',   # default: Resources/levels/maps/<mapname>_bakedata
    [int]    $TimeoutSec = 600
)
$ErrorActionPreference = 'Stop'
$root = Split-Path -Parent $PSScriptRoot
if (-not (Test-Path -LiteralPath $UnityExe)) { throw "Unity editor not found: $UnityExe" }
if (-not (Test-Path -LiteralPath $ProjectPath)) { throw "ExportedProject not found: $ProjectPath" }

$lower = $MapName.ToLowerInvariant()
if ([string]::IsNullOrWhiteSpace($BuildOut)) {
    $BuildOut = Join-Path $root "artifacts\$lower-mapbundle"
}
New-Item -ItemType Directory -Force -Path $BuildOut | Out-Null
$log = Join-Path $root "logs\mapbundle-$lower.log"
New-Item -ItemType Directory -Force -Path (Split-Path -Parent $log) | Out-Null

$unityArgs = @(
    '-batchmode', '-nographics', '-quit',
    '-projectPath', $ProjectPath,
    '-executeMethod', 'MapBundleBuilder.Build',
    '-mapName', $MapName,
    '-buildOut', $BuildOut,
    '-logFile', $log
)
if (-not [string]::IsNullOrWhiteSpace($BakedataDir)) { $unityArgs += @('-bakedataDir', $BakedataDir) }

Write-Host "[Build-MapBundle] Unity build: map=$MapName out=$BuildOut"
Write-Host "[Build-MapBundle] log=$log"
$proc = Start-Process -FilePath $UnityExe -ArgumentList $unityArgs -PassThru -NoNewWindow
if (-not $proc.WaitForExit($TimeoutSec * 1000)) {
    try { $proc.Kill() } catch {}
    throw "[Build-MapBundle] Unity timed out after ${TimeoutSec}s. See $log"
}
Write-Host "[Build-MapBundle] Unity exit=$($proc.ExitCode)"

# License check (the common failure mode).
if (Select-String -Path $log -Pattern 'No valid Unity Editor license' -Quiet -ErrorAction SilentlyContinue) {
    throw "[Build-MapBundle] Unity license NOT active. Activate via Unity Hub (sign in) or a manual .ulf, then re-run. See $log"
}

$produced = Join-Path $BuildOut $lower
if (Test-Path -LiteralPath $produced) {
    $len = (Get-Item -LiteralPath $produced).Length
    Write-Host "[Build-MapBundle] SUCCESS: $produced ($len bytes)"
    # Copy to the canonical deploy/runtime locations.
    $deployDst = Join-Path $root "deployment\netcustomchar-deploy\stage\game\UserData\CustomMaps\$MapName"
    $localDst  = Join-Path $root "Spiel\Battleroyalebuild\UserData\CustomMaps\$MapName"
    foreach ($d in @($deployDst, $localDst)) {
        New-Item -ItemType Directory -Force -Path $d | Out-Null
        Copy-Item -LiteralPath $produced -Destination (Join-Path $d "$lower.bundle") -Force
        Write-Host "[Build-MapBundle] copied -> $d\$lower.bundle"
    }
    exit 0
} else {
    Write-Host "[Build-MapBundle] FAILED: expected bundle not found at $produced. See $log"
    exit 6
}

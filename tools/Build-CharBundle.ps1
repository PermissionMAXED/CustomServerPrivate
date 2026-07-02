<#
.SYNOPSIS
    Build a real-asset AssetBundle for any BAPBAP character (generic, config-driven).

.DESCRIPTION
    Runs the Unity editor headless against the exported project and invokes the
    generic CharBundleBuilder.Build editor method for the requested character.
    The builder discovers that char's prefab/controller/avatar/clips/materials/VFX
    by naming convention, creates a stripped "<Name>_Visual" prefab, tags everything
    into a bundle named "<name>" (lowercase), and writes it to the build-out dir.

    On completion this script prints the produced bundle size and tails the Unity
    log for the SUCCESS line, controller param count, and visual-only animator count.

.PARAMETER Char
    Character name, e.g. Medusa, Eve, Kiddo. Matches Assets/GameObject/<Char>.prefab.

.PARAMETER BuildOut
    Optional output directory for the bundle. Defaults to <repo>\artifacts\char-bundles\<char>.

.EXAMPLE
    .\Build-CharBundle.ps1 -Char Medusa
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [string] $Char,

    [string] $BuildOut,

    [string] $UnityExe = 'C:\Program Files\Unity\Hub\Editor\2022.3.38f1\Editor\Unity.exe',

    [string] $ProjectPath = 'C:\Users\Administrator\Downloads\neueBapbap\GameCode\ExportedProject',

    [int] $TimeoutSeconds = 1200
)

$ErrorActionPreference = 'Stop'

$repoRoot = Split-Path -Parent $PSScriptRoot
$bundleName = $Char.ToLowerInvariant()
if (-not $BuildOut) {
    # IMPORTANT: the output folder name must NOT equal the bundle name, otherwise
    # Unity's auto-generated manifest bundle (named after the folder) conflicts with
    # the user-defined "<name>" bundle and BuildAssetBundles returns null.
    $BuildOut = Join-Path $repoRoot ("artifacts\char-bundles\" + $Char + "BundleOut")
}
if ((Split-Path $BuildOut -Leaf).ToLowerInvariant() -eq $bundleName) {
    throw "BuildOut folder name '$(Split-Path $BuildOut -Leaf)' must not equal the bundle name '$bundleName' (Unity manifest-name conflict). Pick a different -BuildOut."
}

if (-not (Test-Path -LiteralPath $UnityExe)) {
    throw "Unity editor not found: $UnityExe"
}
if (-not (Test-Path -LiteralPath (Join-Path $ProjectPath 'Assets'))) {
    throw "Unity project not found: $ProjectPath"
}

New-Item -ItemType Directory -Force -Path $BuildOut | Out-Null

$logDir = Join-Path $PSScriptRoot 'logs'
New-Item -ItemType Directory -Force -Path $logDir | Out-Null
$stamp = (Get-Date -Format 'yyyyMMddHHmmss')
$logFile = Join-Path $logDir ("char-bundle-{0}-{1}.log" -f $bundleName, $stamp)

Write-Host "=== Build-CharBundle ===" -ForegroundColor Cyan
Write-Host "Char       : $Char"
Write-Host "Bundle     : $bundleName"
Write-Host "Project    : $ProjectPath"
Write-Host "Build out  : $BuildOut"
Write-Host "Unity log  : $logFile"
Write-Host ""

$unityArgs = @(
    '-batchmode'
    '-nographics'
    '-quit'
    '-projectPath', $ProjectPath
    '-executeMethod', 'CharBundleBuilder.Build'
    '-charName', $Char
    '-buildOut', $BuildOut
    '-logFile', $logFile
)

Write-Host "Running Unity headless..." -ForegroundColor Yellow
$proc = Start-Process -FilePath $UnityExe -ArgumentList $unityArgs -PassThru -NoNewWindow
# Touch the handle so the cached ExitCode is populated after exit (Start-Process quirk).
$null = $proc.Handle
if (-not $proc.WaitForExit($TimeoutSeconds * 1000)) {
    try { $proc.Kill() } catch { }
    throw "Unity build timed out after $TimeoutSeconds s. See log: $logFile"
}
$exitCode = $proc.ExitCode
Write-Host "Unity exit code: $exitCode" -ForegroundColor ($(if ($exitCode -eq 0) { 'Green' } else { 'Red' }))

# --- Report produced bundle size. ---
$producedBundle = Join-Path $BuildOut $bundleName
Write-Host ""
Write-Host "=== Result ===" -ForegroundColor Cyan
if (Test-Path -LiteralPath $producedBundle) {
    $len = (Get-Item -LiteralPath $producedBundle).Length
    $mb = [math]::Round($len / 1MB, 3)
    Write-Host "Bundle: $producedBundle"
    Write-Host ("Size  : {0} bytes ({1} MB)" -f $len, $mb) -ForegroundColor Green
} else {
    Write-Host "Bundle NOT produced at: $producedBundle" -ForegroundColor Red
}

# --- Tail relevant log lines. ---
if (Test-Path -LiteralPath $logFile) {
    Write-Host ""
    Write-Host "=== CharBundleBuilder log highlights ===" -ForegroundColor Cyan
    Select-String -LiteralPath $logFile `
        -Pattern 'SUCCESS:|controller params=|visual-only:|Tagged \d+|Built bundle:|WARNING|EXCEPTION|param:' |
        ForEach-Object { $_.Line }
}

if ($exitCode -ne 0) {
    Write-Host ""
    Write-Host "Build reported a non-zero exit code; inspect $logFile" -ForegroundColor Red
}
exit $exitCode

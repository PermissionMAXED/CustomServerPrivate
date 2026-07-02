param(
    [string]$Configuration = "Release",
    [string]$GameDir = "",
    [switch]$Rebuild,
    [switch]$ForceOverwriteDist
)

$ErrorActionPreference = "Stop"

# ---------------------------------------------------------------------------
# Hash-pinned BapCustomServerMelon installer.
#
# Background (audit a18):
#   The working in-game mod DLL is the prebuilt artifact at
#   BapCustomServerMelon\dist\BapCustomServerMelon.dll. The current source tree
#   must stay aligned with the latest match-tested artifact. The current
#   known-good binary that local clients and AMP/Wine deployments depend on has:
#       SHA256 = 24D45419EE066B5987AD004D4E1143C56B47707EAD67A211150D1D91B1B585C9
#       Size   = 266240 bytes
#
# This script must therefore NEVER overwrite the dist DLL by accident. The
# default code path does not run dotnet build at all; it simply copies the
# pinned dist DLL into the game's Mods folder.
#
# To rebuild from source you must explicitly pass -Rebuild. Even then we will
# refuse to overwrite the working dist unless -ForceOverwriteDist is also
# passed, and we always back up the previous dist DLL with a timestamp first.
# ---------------------------------------------------------------------------

$PinnedDistSha256 = "24D45419EE066B5987AD004D4E1143C56B47707EAD67A211150D1D91B1B585C9"
$PinnedDistSize = 266240

$Root = Resolve-Path (Join-Path $PSScriptRoot "..")
$Project = Join-Path $Root "BapCustomServerMelon\BapCustomServerMelon.csproj"
$BuildOutputDll = Join-Path $Root "BapCustomServerMelon\bin\$Configuration\net6.0\BapCustomServerMelon.dll"
$SourceIni = Join-Path $Root "BapCustomServerMelon\BapCustomServer.ini"
$DistDir = Join-Path $Root "BapCustomServerMelon\dist"
$DistDll = Join-Path $DistDir "BapCustomServerMelon.dll"
$DistIni = Join-Path $DistDir "BapCustomServer.ini"
$AppDataIni = Join-Path $env:APPDATA "BAPBAPBATTLEROYALE\BapCustomServer.ini"

if ([string]::IsNullOrWhiteSpace($GameDir)) {
    $GameDir = Join-Path $Root "Spiel\Battleroyalebuild"
}
$ModsDir = Join-Path $GameDir "Mods"

function Get-Sha256 {
    param([Parameter(Mandatory = $true)][string]$Path)
    if (-not (Test-Path -LiteralPath $Path)) { return $null }
    return (Get-FileHash -Algorithm SHA256 -LiteralPath $Path).Hash.ToUpperInvariant()
}

function Assert-DistIntegrity {
    param([Parameter(Mandatory = $true)][string]$DllPath)

    if (-not (Test-Path -LiteralPath $DllPath)) {
        throw @"
Working dist DLL is missing: $DllPath
Expected SHA256 = $PinnedDistSha256 (size $PinnedDistSize bytes).
Restore the latest match-tested binary before continuing.
"@
    }

    $size = (Get-Item -LiteralPath $DllPath).Length
    $hash = Get-Sha256 -Path $DllPath

    if ($size -ne $PinnedDistSize -or $hash -ne $PinnedDistSha256) {
        throw @"
Dist DLL hash/size mismatch.
  Path     : $DllPath
  Got SHA  : $hash
  Got size : $size bytes
  Expected : $PinnedDistSha256 ($PinnedDistSize bytes)
This is the working in-game binary that real deployments depend on.
Restore it from a backup or rebuild and re-test before continuing.
"@
    }
}

# Always require a known-good dist DLL before doing anything else.
Assert-DistIntegrity -DllPath $DistDll

New-Item -ItemType Directory -Force -Path $DistDir | Out-Null
New-Item -ItemType Directory -Force -Path $ModsDir | Out-Null

# ---------------------------------------------------------------------------
# Optional rebuild path. Off by default. Even when on, refuses to overwrite
# the working dist unless the operator explicitly passes -ForceOverwriteDist.
# ---------------------------------------------------------------------------
if ($Rebuild) {
    Write-Host "[-Rebuild] Compiling BapCustomServerMelon from source. This usually produces a BROKEN dll (D00968FD...)." -ForegroundColor Yellow
    Write-Host "[-Rebuild] The working dist DLL ($PinnedDistSha256) will NOT be overwritten unless -ForceOverwriteDist is also passed." -ForegroundColor Yellow

    dotnet build $Project -c $Configuration
    if ($LASTEXITCODE -ne 0) {
        throw "dotnet build failed with exit code $LASTEXITCODE"
    }

    if (-not (Test-Path -LiteralPath $BuildOutputDll)) {
        throw "Build succeeded but output DLL was not found at: $BuildOutputDll"
    }

    $builtSize = (Get-Item -LiteralPath $BuildOutputDll).Length
    $builtHash = Get-Sha256 -Path $BuildOutputDll

    Write-Host ""
    Write-Host "Built  : $BuildOutputDll" -ForegroundColor Cyan
    Write-Host "  SHA256 = $builtHash"
    Write-Host "  Size   = $builtSize bytes"
    Write-Host "Pinned : $PinnedDistSha256 ($PinnedDistSize bytes)"

    if ($builtHash -eq $PinnedDistSha256 -and $builtSize -eq $PinnedDistSize) {
        Write-Host "Built DLL matches the pinned working dist exactly. No dist update required." -ForegroundColor Green
    }
    elseif ($ForceOverwriteDist) {
        $timestamp = Get-Date -Format "yyyyMMddHHmmss"
        $backupDll = Join-Path $DistDir ("BapCustomServerMelon.dll.$timestamp.bak")
        Copy-Item -LiteralPath $DistDll -Destination $backupDll -Force
        Write-Host "Backed up previous dist DLL to: $backupDll" -ForegroundColor Yellow
        Copy-Item -LiteralPath $BuildOutputDll -Destination $DistDll -Force
        Write-Warning "Overwrote dist DLL with freshly built binary. Verify this build actually works in-game before shipping; the current source tree is known to produce a broken DLL."
    }
    else {
        Write-Warning "Built DLL differs from the pinned working dist."
        Write-Warning "Refusing to overwrite dist\\BapCustomServerMelon.dll. Pass -ForceOverwriteDist to override."
        Write-Warning "The freshly built (and likely broken) DLL is left in place at: $BuildOutputDll"
    }

    # Re-validate so a partial overwrite never leaves a corrupt dist behind.
    Assert-DistIntegrity -DllPath $DistDll
}

# ---------------------------------------------------------------------------
# Default deployment: copy the pinned dist DLL into the game's Mods folder.
# ---------------------------------------------------------------------------
$ModsDll = Join-Path $ModsDir "BapCustomServerMelon.dll"
Copy-Item -LiteralPath $DistDll -Destination $ModsDll -Force

# Sanity check: the file we just placed in Mods must match the pinned hash.
Assert-DistIntegrity -DllPath $ModsDll

# ---------------------------------------------------------------------------
# INI handling: only initialize when missing. Never clobber existing configs.
# ---------------------------------------------------------------------------
if (Test-Path -LiteralPath $SourceIni) {
    if (-not (Test-Path -LiteralPath $DistIni)) {
        Copy-Item -LiteralPath $SourceIni -Destination $DistIni -Force
        Write-Host "Initialized dist INI: $DistIni" -ForegroundColor Cyan
    }
    else {
        Write-Host "Kept existing dist INI: $DistIni"
    }

    $appDataDir = Split-Path -Parent $AppDataIni
    New-Item -ItemType Directory -Force -Path $appDataDir | Out-Null
    if (-not (Test-Path -LiteralPath $AppDataIni)) {
        Copy-Item -LiteralPath $SourceIni -Destination $AppDataIni
        Write-Host "Initialized AppData INI: $AppDataIni" -ForegroundColor Cyan
    }
    else {
        Write-Host "Kept existing AppData INI: $AppDataIni"
    }
}

Write-Host ""
Write-Host "Deployed pinned BapCustomServerMelon.dll." -ForegroundColor Green
Write-Host "  Dist : $DistDll"
Write-Host "  Mods : $ModsDll"
Write-Host "  INI  : $AppDataIni"
Write-Host "  SHA  : $PinnedDistSha256"

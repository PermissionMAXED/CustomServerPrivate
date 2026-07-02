param(
    [string]$ReleaseLabel = "medusa-v1727-charselect-respect"
)
$ErrorActionPreference = "Stop"

$Root        = "C:\Users\Administrator\Downloads\CustomServer"
$NewMedusa   = "C:\Users\Administrator\Downloads\BAPBAPModdingAPI\medusa-mod\bin\Release\BAPBAP.Medusa.dll"
$BaseInfo    = Join-Path $Root "deployment\amp-full-linux-wine\package\BapCustomServer\deployment-info.json"
$Staging     = Join-Path $Root "deployment\amp-medusa-hotfix\stage"
$ZipOut      = Join-Path $Root "deployment\amp-medusa-hotfix\bapcustomserver-medusa-hotfix.zip"
$LocalMods   = Join-Path $Root "Spiel\Battleroyalebuild\Mods"

if (-not (Test-Path -LiteralPath $NewMedusa)) { throw "New Medusa DLL not found: $NewMedusa" }
if (-not (Test-Path -LiteralPath $BaseInfo))  { throw "Base deployment-info.json not found: $BaseInfo" }

$newHash = (Get-FileHash -LiteralPath $NewMedusa -Algorithm SHA256).Hash.ToUpperInvariant()
Write-Host "New Medusa DLL SHA256 = $newHash"

# --- Build minimal staging tree: game/Mods/BAPBAP.Medusa.dll + deployment-info.json ---
if (Test-Path -LiteralPath $Staging) { Remove-Item -LiteralPath $Staging -Recurse -Force }
$modsDir = Join-Path $Staging "game\Mods"
New-Item -ItemType Directory -Force -Path $modsDir | Out-Null
Copy-Item -LiteralPath $NewMedusa -Destination (Join-Path $modsDir "BAPBAP.Medusa.dll") -Force

# --- Updated deployment-info.json ---
$info = Get-Content -LiteralPath $BaseInfo -Raw | ConvertFrom-Json
$info.releaseLabel    = $ReleaseLabel
$info.medusaDllSha256 = $newHash
$info.packageBuildUtc = (Get-Date).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffffffZ")
$info.gitDirty        = $true
$infoJson = $info | ConvertTo-Json -Depth 12
Set-Content -LiteralPath (Join-Path $Staging "deployment-info.json") -Value $infoJson -Encoding UTF8

# --- Zip (entries relative to staging root) ---
if (Test-Path -LiteralPath $ZipOut) { Remove-Item -LiteralPath $ZipOut -Force }
New-Item -ItemType Directory -Force -Path (Split-Path -Parent $ZipOut) | Out-Null
Add-Type -AssemblyName System.IO.Compression.FileSystem
[System.IO.Compression.ZipFile]::CreateFromDirectory($Staging, $ZipOut)

Write-Host "`n=== Hotfix zip entries ==="
$z = [System.IO.Compression.ZipFile]::OpenRead($ZipOut)
try { $z.Entries | ForEach-Object { "{0}  ({1} bytes)" -f $_.FullName, $_.Length } } finally { $z.Dispose() }
$zi = Get-Item -LiteralPath $ZipOut
Write-Host ("`nZip: {0}  ({1:N1} KB)" -f $ZipOut, ($zi.Length/1KB))

# --- Refresh local test client's Medusa DLL (for faithful client-side test) ---
if (Test-Path -LiteralPath $LocalMods) {
    $localDll = Join-Path $LocalMods "BAPBAP.Medusa.dll"
    if (Test-Path -LiteralPath $localDll) {
        $bak = "$localDll.$(Get-Date -Format yyyyMMddHHmmss).pre-v1727.bak"
        Copy-Item -LiteralPath $localDll -Destination $bak -Force
        Write-Host "Backed up local client Medusa DLL -> $bak"
    }
    Copy-Item -LiteralPath $NewMedusa -Destination $localDll -Force
    Write-Host "Updated local client Medusa DLL -> $localDll (sha256=$((Get-FileHash -LiteralPath $localDll -Algorithm SHA256).Hash))"
} else {
    Write-Host "Local client Mods folder not found ($LocalMods); skipped local DLL refresh."
}

param(
    [string]$GameDir   = "C:\Users\Administrator\Downloads\CustomServer\Spiel\Battleroyalebuild",
    [string]$ConfigDir = "C:\Users\Administrator\Downloads\CustomServer\artifacts\client-release-config",
    [string]$ZipPath   = "C:\Users\Administrator\Downloads\CustomServer\artifacts\BAPBAP-CustomClient.zip",
    [string]$TopFolder = "BAPBAP-CustomClient"
)
$ErrorActionPreference = "Stop"
Add-Type -AssemblyName System.IO.Compression
Add-Type -AssemblyName System.IO.Compression.FileSystem

# Files we substitute with cleaned versions (overlay off, identity cleared).
$cleanIni  = Join-Path $ConfigDir "BapCustomServer.ini"
$cleanPrefs = Join-Path $ConfigDir "MelonPreferences.cfg"
foreach ($p in @($cleanIni, $cleanPrefs)) {
    if (-not (Test-Path -LiteralPath $p)) { throw "Missing cleaned config: $p" }
}

# Skip rules: backups, disabled mods, captured logs, per-run state, user identity configs.
function Test-Skip([string]$rel) {
    $r = $rel.Replace('\','/')
    if ($r -match '\.bak($|[./])') { return $true }
    if ($r -match '\.disabled$') { return $true }
    if ($r -match '(?i)\.bak\b') { return $true }
    if ($r -match '(?i)\.log$') { return $true }
    if ($r -match '(?i)^logs/') { return $true }
    # These two are replaced by cleaned copies, so skip the originals here.
    if ($r -ieq 'Mods/BapCustomServer.ini') { return $true }
    if ($r -ieq 'UserData/MelonPreferences.cfg') { return $true }
    # Drop any leftover per-device identity/state under UserData except what we re-add.
    if ($r -match '(?i)^UserData/Medusa/auto-select\.txt$') { return $true }
    return $false
}

if (Test-Path -LiteralPath $ZipPath) { Remove-Item -LiteralPath $ZipPath -Force }
New-Item -ItemType Directory -Force -Path (Split-Path -Parent $ZipPath) | Out-Null

$rootFull = [System.IO.Path]::GetFullPath($GameDir).TrimEnd('\','/')
$included = 0; $skipped = 0; $bytes = 0
$zipStream = [System.IO.File]::Open($ZipPath, [System.IO.FileMode]::CreateNew)
try {
    $archive = New-Object System.IO.Compression.ZipArchive($zipStream, [System.IO.Compression.ZipArchiveMode]::Create)
    try {
        Get-ChildItem -LiteralPath $GameDir -Recurse -File -Force | ForEach-Object {
            $full = [System.IO.Path]::GetFullPath($_.FullName)
            $rel  = $full.Substring($rootFull.Length).TrimStart('\','/')
            if (Test-Skip $rel) { $script:skipped++; return }
            $entryName = "$TopFolder/" + ($rel -replace '\\','/')
            $entry = $archive.CreateEntry($entryName, [System.IO.Compression.CompressionLevel]::Optimal)
            $es = $entry.Open()
            try {
                $fs = [System.IO.File]::OpenRead($full)
                try { $fs.CopyTo($es) } finally { $fs.Dispose() }
            } finally { $es.Dispose() }
            $script:included++; $script:bytes += $_.Length
        }
        # Add cleaned config substitutes.
        foreach ($pair in @(
            @{ src = $cleanIni;   dest = "$TopFolder/Mods/BapCustomServer.ini" },
            @{ src = $cleanPrefs; dest = "$TopFolder/UserData/MelonPreferences.cfg" }
        )) {
            $entry = $archive.CreateEntry($pair.dest, [System.IO.Compression.CompressionLevel]::Optimal)
            $es = $entry.Open()
            try {
                $fs = [System.IO.File]::OpenRead($pair.src)
                try { $fs.CopyTo($es) } finally { $fs.Dispose() }
            } finally { $es.Dispose() }
            $included++
        }
    } finally { $archive.Dispose() }
} finally { $zipStream.Dispose() }

$zipLen = (Get-Item -LiteralPath $ZipPath).Length
[pscustomobject]@{
    zip = $ZipPath
    filesIncluded = $included
    filesSkipped = $skipped
    sourceBytesGB = [math]::Round($bytes / 1GB, 2)
    zipSizeGB = [math]::Round($zipLen / 1GB, 2)
} | ConvertTo-Json -Compress

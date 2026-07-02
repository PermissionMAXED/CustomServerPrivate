param([string]$ReleaseLabel = "medusa-v1730-skin-fix")
$ErrorActionPreference = "Stop"
$Root     = "C:\Users\Administrator\Downloads\CustomServer"
$Dll      = Join-Path $Root "CustomMatchServer\bin\Release\net10.0\BapCustomServer.dll"
$InfoBase = Join-Path $Root "deployment\amp-medusa-hotfix\stage\deployment-info.json"   # has medusaDll=2223E4 (native)
$Stage    = Join-Path $Root "deployment\amp-server-hotfix\stage"
$Zip      = Join-Path $Root "deployment\amp-server-hotfix\bapcustomserver-server-hotfix.zip"

if (-not (Test-Path $Dll))      { throw "server dll not found: $Dll" }
if (-not (Test-Path $InfoBase)) { throw "base deployment-info not found: $InfoBase" }

if (Test-Path $Stage) { Remove-Item $Stage -Recurse -Force }
New-Item -ItemType Directory -Force -Path $Stage | Out-Null
Copy-Item -LiteralPath $Dll -Destination (Join-Path $Stage "BapCustomServer.dll") -Force
# Ship appsettings.json too: the EnabledGameModeIdsCsv mode list lives here, and a DLL-only hotfix
# would leave the live server on its old (Solos-only) mode advertisement. Env-var overrides set via
# AMP still win over appsettings in .NET config precedence, so this is safe to ship wholesale.
$AppSettings = Join-Path $Root "CustomMatchServer\appsettings.json"
if (Test-Path $AppSettings) { Copy-Item -LiteralPath $AppSettings -Destination (Join-Path $Stage "appsettings.json") -Force }

$hash = (Get-FileHash -LiteralPath $Dll -Algorithm SHA256).Hash
$info = Get-Content -LiteralPath $InfoBase -Raw | ConvertFrom-Json
$info.releaseLabel    = $ReleaseLabel
$info.serverDllSha256 = $hash
$info.packageBuildUtc = (Get-Date).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffffffZ")
($info | ConvertTo-Json -Depth 12) | Set-Content -LiteralPath (Join-Path $Stage "deployment-info.json") -Encoding UTF8

if (Test-Path $Zip) { Remove-Item $Zip -Force }
New-Item -ItemType Directory -Force -Path (Split-Path $Zip -Parent) | Out-Null
Add-Type -AssemblyName System.IO.Compression
Add-Type -AssemblyName System.IO.Compression.FileSystem
$za=[System.IO.Compression.ZipFile]::Open($Zip,[System.IO.Compression.ZipArchiveMode]::Create)
try { foreach($f in (Get-ChildItem -LiteralPath $Stage -Recurse -File)){ $rel=($f.FullName.Substring($Stage.Length).TrimStart('\') -replace '\\','/'); [System.IO.Compression.ZipFileExtensions]::CreateEntryFromFile($za,$f.FullName,$rel,[System.IO.Compression.CompressionLevel]::Optimal) | Out-Null } } finally { $za.Dispose() }
Write-Host ("server dll SHA256=$hash")
Write-Host ("ZIP: {0} ({1:N1} KB) release=$ReleaseLabel" -f $Zip, ((Get-Item $Zip).Length/1KB))
$z=[System.IO.Compression.ZipFile]::OpenRead($Zip); try { $z.Entries | ForEach-Object { $_.FullName } } finally { $z.Dispose() }

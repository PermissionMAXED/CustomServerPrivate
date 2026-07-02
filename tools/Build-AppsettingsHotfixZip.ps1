param([string]$ReleaseLabel = "medusa-v1728-charsel-time")
$ErrorActionPreference = "Stop"
$Root      = "C:\Users\Administrator\Downloads\CustomServer"
$AppSrc    = Join-Path $Root "deployment\amp-full-linux-wine\package\BapCustomServer\appsettings.json"
$InfoBase  = Join-Path $Root "deployment\amp-medusa-hotfix\stage\deployment-info.json"   # v1727 (medusaDll=AADDB5)
$Staging   = Join-Path $Root "deployment\amp-appsettings-hotfix\stage"
$ZipOut    = Join-Path $Root "deployment\amp-appsettings-hotfix\bapcustomserver-appsettings-hotfix.zip"

if (-not (Test-Path $AppSrc))  { throw "appsettings not found: $AppSrc" }
if (-not (Test-Path $InfoBase)){ throw "base deployment-info not found: $InfoBase" }

if (Test-Path $Staging) { Remove-Item $Staging -Recurse -Force }
New-Item -ItemType Directory -Force -Path $Staging | Out-Null
Copy-Item -LiteralPath $AppSrc -Destination (Join-Path $Staging "appsettings.json") -Force

$info = Get-Content -LiteralPath $InfoBase -Raw | ConvertFrom-Json
$info.releaseLabel    = $ReleaseLabel
$info.packageBuildUtc = (Get-Date).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffffffZ")
($info | ConvertTo-Json -Depth 12) | Set-Content -LiteralPath (Join-Path $Staging "deployment-info.json") -Encoding UTF8

if (Test-Path $ZipOut) { Remove-Item $ZipOut -Force }
New-Item -ItemType Directory -Force -Path (Split-Path -Parent $ZipOut) | Out-Null
Add-Type -AssemblyName System.IO.Compression.FileSystem
[System.IO.Compression.ZipFile]::CreateFromDirectory($Staging, $ZipOut)
Write-Host "Hotfix zip: $ZipOut"
$z=[System.IO.Compression.ZipFile]::OpenRead($ZipOut); try { $z.Entries | ForEach-Object { $_.FullName } } finally { $z.Dispose() }
$csm = (Get-Content $AppSrc -Raw | Select-String -Pattern '"CharSelectMillis":\s*\d+').Matches.Value
Write-Host "appsettings $csm ; release=$ReleaseLabel"

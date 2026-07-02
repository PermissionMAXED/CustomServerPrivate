param()

$ErrorActionPreference = "Stop"

$Root = Resolve-Path (Join-Path $PSScriptRoot "..")
$AmpDir = Join-Path $Root "deployment\amp-linux-webpanel"
$PackageRoot = Join-Path $AmpDir "package"
$TemplateDir = Join-Path $PackageRoot "templates"
$ZipPath = Join-Path $AmpDir "bapcustomserver-linux-webpanel-template.zip"

if (Test-Path -LiteralPath $PackageRoot) {
    Remove-Item -LiteralPath $PackageRoot -Recurse -Force
}

New-Item -ItemType Directory -Force -Path $TemplateDir | Out-Null

Copy-Item -LiteralPath (Join-Path $AmpDir "bapcustomserverlinux.kvp") -Destination $TemplateDir
Copy-Item -LiteralPath (Join-Path $AmpDir "bapcustomserverlinuxconfig.json") -Destination $TemplateDir
Copy-Item -LiteralPath (Join-Path $AmpDir "bapcustomserverlinuxmetaconfig.json") -Destination $TemplateDir
Copy-Item -LiteralPath (Join-Path $AmpDir "bapcustomserverlinuxports.json") -Destination $TemplateDir
Copy-Item -LiteralPath (Join-Path $AmpDir "README.md") -Destination (Join-Path $PackageRoot "README-AMP-LINUX-WEBPANEL.md")

Remove-Item -LiteralPath $ZipPath -Force -ErrorAction SilentlyContinue
Compress-Archive -Path (Join-Path $PackageRoot "*") -DestinationPath $ZipPath -Force

[pscustomobject]@{
    zip = $ZipPath
    templates = $TemplateDir
} | ConvertTo-Json -Compress

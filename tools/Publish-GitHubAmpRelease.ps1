param(
    [Parameter(Mandatory = $true)]
    [ValidatePattern("^[^/\s]+/[^/\s]+$")]
    [string]$Repository,

    [string]$Tag = ("bapcustomserver-" + (Get-Date -Format "yyyyMMdd-HHmmss")),

    [switch]$CreatePrivateRepository,

    [switch]$SkipRebuild
)

$ErrorActionPreference = "Stop"

$Root = Resolve-Path (Join-Path $PSScriptRoot "..")
$FullZip = Join-Path $Root "deployment\amp-full-linux-wine\bapcustomserver-amp-full-linux-wine.zip"
$TemplateZip = Join-Path $Root "deployment\amp-github-autoinstall\bapcustomserver-github-autoinstall-template.zip"
$ClientZip = Join-Path $Root "deployment\client-bundle\BAPBAP-CustomServer-Client.zip"

if (-not (Get-Command gh -ErrorAction SilentlyContinue)) {
    throw "GitHub CLI 'gh' is required. Install it and run 'gh auth login' before publishing."
}

if (-not $SkipRebuild.IsPresent) {
    & (Join-Path $Root "tools\Build-AmpFullLinuxWinePackage.ps1") -ReleaseLabel $Tag | Out-Host
    & (Join-Path $Root "tools\Build-AmpGitHubAutoInstallPackage.ps1") -Repository $Repository | Out-Host
    & (Join-Path $Root "tools\Build-ClientBundle.ps1") -PublicHost "ark.atomi23.de" -LobbyPort 5055 -LocalProxyPort 5055 -BundleName "BAPBAP-CustomServer-Client" | Out-Host
}

if (-not (Test-Path -LiteralPath $FullZip)) {
    throw "Full package not found: $FullZip"
}

if (-not (Test-Path -LiteralPath $TemplateZip)) {
    throw "GitHub autoinstall template package not found: $TemplateZip"
}

if (-not (Test-Path -LiteralPath $ClientZip)) {
    throw "Client bundle not found: $ClientZip"
}

if ($CreatePrivateRepository.IsPresent) {
    gh repo view $Repository 1>$null 2>$null
    if ($LASTEXITCODE -ne 0) {
        gh repo create $Repository --private
    }
}

$notes = @"
BAPBAP Custom Server AMP release.

AMP template asset:
- bapcustomserver-github-autoinstall-template.zip

Server/game package asset:
- bapcustomserver-amp-full-linux-wine.zip

Client package asset:
- BAPBAP-CustomServer-Client.zip

Install in AMP:
1. Import the template ZIP.
2. Create a new instance from BAPBAP Custom Server GitHub AutoInstall.
3. Press Update.
4. Press Start.
"@

gh release create $Tag $FullZip $TemplateZip $ClientZip --repo $Repository --title $Tag --notes $notes

[pscustomobject]@{
    repository = $Repository
    tag = $Tag
    fullZip = $FullZip
    templateZip = $TemplateZip
    clientZip = $ClientZip
} | ConvertTo-Json -Compress

$ErrorActionPreference = "Stop"

$Root = "C:\Users\Administrator\Downloads\CustomServer"
$Stage = Join-Path (Join-Path $Root "deployment") "amp-hotfix-both-stage"
$Zip = Join-Path (Join-Path $Root "deployment") "bapcustomserver-both-hotfix.zip"

if (Test-Path -LiteralPath $Stage) { Remove-Item -LiteralPath $Stage -Recurse -Force }
$gameMods = Join-Path (Join-Path $Stage "game") "Mods"
New-Item -ItemType Directory -Force -Path $gameMods | Out-Null

$modDllSrc = Join-Path (Join-Path $Root "BapCustomServerMelon") "dist\BapCustomServerMelon.dll"
$networkedCustomCharDllSrc = "C:\Users\Administrator\Downloads\BAPBAPModdingAPI\netcustomchar-mod\bin\Release\NetworkedCustomChar.dll"
$svDllSrc = Join-Path (Join-Path (Join-Path $Root "CustomMatchServer\bin\Release") "net10.0") "BapCustomServer.dll"
$appSettingsSrc = Join-Path $Root "CustomMatchServer\appsettings.json"
$startMatchSrc = Join-Path (Join-Path $Root "deployment") "amp-full-linux-wine\start-match.sh"

Copy-Item -LiteralPath $modDllSrc -Destination (Join-Path $gameMods "BapCustomServerMelon.dll") -Force
Copy-Item -LiteralPath $networkedCustomCharDllSrc -Destination (Join-Path $gameMods "NetworkedCustomChar.dll") -Force
Copy-Item -LiteralPath $svDllSrc -Destination (Join-Path $Stage "BapCustomServer.dll") -Force
if (Test-Path -LiteralPath $appSettingsSrc) { Copy-Item -LiteralPath $appSettingsSrc -Destination (Join-Path $Stage "appsettings.json") -Force }
Copy-Item -LiteralPath $startMatchSrc -Destination (Join-Path $Stage "start-match.sh") -Force

function Get-Sha256([string]$Path) {
    if (-not (Test-Path -LiteralPath $Path)) { return "" }
    return (Get-FileHash -Algorithm SHA256 -LiteralPath $Path).Hash.ToUpperInvariant()
}

$gitCommit = (git rev-parse --short=12 HEAD).Trim()
$gitBranch = (git rev-parse --abbrev-ref HEAD).Trim()
$gitStatus = (git status --short).Trim()
$deploymentInfo = [ordered]@{
    schemaVersion = 1
    releaseLabel = "hotfix-lobby-return-botfill-20260702"
    packageBuildUtc = (Get-Date).ToUniversalTime().ToString("o")
    gitCommit = $gitCommit
    gitBranch = $gitBranch
    gitDirty = -not [string]::IsNullOrWhiteSpace($gitStatus)
    configuration = "Release"
    selfContained = $true
    publicHost = "ark.atomi23.de"
    serverDllSha256 = Get-Sha256 $svDllSrc
    modDllSha256 = Get-Sha256 $modDllSrc
    networkedCustomCharDllSha256 = Get-Sha256 $networkedCustomCharDllSrc
    appSettingsSha256 = Get-Sha256 $appSettingsSrc
    startMatchSha256 = Get-Sha256 $startMatchSrc
    notes = "Fixes post-match lobby return fallback including MainScene-based matches, removes queue/augment audit issues, raises GameMode.SpawnAllBotsFill bot cap from currentMaxBotTeams, and keeps AMP bootstrap polling alive while the match host returns 503 warmingUp."
}
[System.IO.File]::WriteAllText((Join-Path $Stage "deployment-info.json"), ($deploymentInfo | ConvertTo-Json -Depth 8), [System.Text.UTF8Encoding]::new($false))

if (Test-Path -LiteralPath $Zip) { Remove-Item -LiteralPath $Zip -Force }

Add-Type -AssemblyName System.IO.Compression
Add-Type -AssemblyName System.IO.Compression.FileSystem
$zf = [System.IO.Compression.ZipFile]::Open($Zip, [System.IO.Compression.ZipArchiveMode]::Create)
try {
    $rootPath = [System.IO.Path]::GetFullPath($Stage).TrimEnd('\', '/')
    Get-ChildItem -LiteralPath $Stage -Recurse -File | ForEach-Object {
        $fullPath = [System.IO.Path]::GetFullPath($_.FullName)
        $relative = $fullPath.Substring($rootPath.Length).TrimStart('\', '/').Replace('\', '/')
        [System.IO.Compression.ZipFileExtensions]::CreateEntryFromFile($zf, $fullPath, $relative, [System.IO.Compression.CompressionLevel]::Optimal) | Out-Null
    }
} finally { $zf.Dispose() }

$sz = (Get-Item -LiteralPath $Zip).Length
Write-Host "zipReady sizeKB=$([math]::Round($sz/1KB,1)) zip=$Zip"
Write-Host "serverDllSha256=$($deploymentInfo.serverDllSha256)"
Write-Host "modDllSha256=$($deploymentInfo.modDllSha256)"
Write-Host "networkedCustomCharDllSha256=$($deploymentInfo.networkedCustomCharDllSha256)"
Write-Host "startMatchSha256=$($deploymentInfo.startMatchSha256)"
Write-Host "rootPath=$rootPath"

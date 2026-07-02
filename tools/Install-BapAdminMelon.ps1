param(
    [string]$Configuration = "Release",
    [string]$GameDir = ""
)

$ErrorActionPreference = "Stop"

$Root = Resolve-Path (Join-Path $PSScriptRoot "..")
$Project = Join-Path $Root "BapAdminMelon\BapAdminMelon.csproj"
$BuildOutput = Join-Path $Root "BapAdminMelon\bin\$Configuration\net6.0\BapAdminMelon.dll"
$DistDir = Join-Path $Root "BapAdminMelon\dist"

if ([string]::IsNullOrWhiteSpace($GameDir)) {
    $GameDir = Join-Path $Root "Spiel\Battleroyalebuild"
}

$ModsDir = Join-Path $GameDir "Mods"

dotnet build $Project -c $Configuration
if ($LASTEXITCODE -ne 0) {
    throw "BapAdminMelon build failed with exit code $LASTEXITCODE."
}

if (-not (Test-Path -LiteralPath $BuildOutput)) {
    throw "Build succeeded but BapAdminMelon.dll was not found at $BuildOutput."
}

New-Item -ItemType Directory -Force -Path $DistDir, $ModsDir | Out-Null
Copy-Item -LiteralPath $BuildOutput -Destination (Join-Path $DistDir "BapAdminMelon.dll") -Force
Copy-Item -LiteralPath $BuildOutput -Destination (Join-Path $ModsDir "BapAdminMelon.dll") -Force

$hash = (Get-FileHash -LiteralPath $BuildOutput -Algorithm SHA256).Hash.ToUpperInvariant()
Write-Host "Deployed BapAdminMelon.dll to $ModsDir" -ForegroundColor Green
Write-Host "SHA256: $hash"

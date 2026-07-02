param(
    [Parameter(Mandatory = $true)]
    [ValidatePattern("^[^/\s]+/[^/\s]+$")]
    [string]$Repository,

    [string]$AssetName = "bapcustomserver-amp-full-linux-wine.zip"
)

$ErrorActionPreference = "Stop"

$Root = Resolve-Path (Join-Path $PSScriptRoot "..")
$AmpDir = Join-Path $Root "deployment\amp-github-autoinstall"
$PackageRoot = Join-Path $AmpDir "package"
$TemplateDir = Join-Path $PackageRoot "templates"
$ZipPath = Join-Path $AmpDir "bapcustomserver-github-autoinstall-template.zip"

if (Test-Path -LiteralPath $PackageRoot) {
    Remove-Item -LiteralPath $PackageRoot -Recurse -Force
}

New-Item -ItemType Directory -Force -Path $TemplateDir | Out-Null

$manifest = Get-Content -Raw -LiteralPath (Join-Path $AmpDir "manifest.json.template")
$manifest = $manifest.Replace("__GITHUB_REPOSITORY__", $Repository)
[System.IO.File]::WriteAllText(
    (Join-Path $PackageRoot "manifest.json"),
    $manifest.Replace("`r`n", "`n"),
    [System.Text.UTF8Encoding]::new($false)
)

$template = Get-Content -Raw -LiteralPath (Join-Path $AmpDir "bapcustomservergithub.kvp.template")
$template = $template.Replace("__GITHUB_REPOSITORY__", $Repository)
[System.IO.File]::WriteAllText(
    (Join-Path $TemplateDir "bapcustomservergithub.kvp"),
    $template.Replace("`r`n", "`n"),
    [System.Text.UTF8Encoding]::new($false)
)

$updates = Get-Content -Raw -LiteralPath (Join-Path $AmpDir "bapcustomservergithubupdates.json.template")
$updates = $updates.Replace("__GITHUB_REPOSITORY__", $Repository).Replace("__PACKAGE_ASSET__", $AssetName)
[System.IO.File]::WriteAllText(
    (Join-Path $TemplateDir "bapcustomservergithubupdates.json"),
    $updates.Replace("`r`n", "`n"),
    [System.Text.UTF8Encoding]::new($false)
)

Copy-Item -LiteralPath (Join-Path $AmpDir "bapcustomservergithubconfig.json") -Destination $TemplateDir
Copy-Item -LiteralPath (Join-Path $AmpDir "bapcustomservergithubmetaconfig.json") -Destination $TemplateDir
Copy-Item -LiteralPath (Join-Path $AmpDir "bapcustomservergithubports.json") -Destination $TemplateDir
Copy-Item -LiteralPath (Join-Path $AmpDir "README.md") -Destination (Join-Path $PackageRoot "README-AMP-GITHUB-AUTOINSTALL.md")

Remove-Item -LiteralPath $ZipPath -Force -ErrorAction SilentlyContinue
Add-Type -AssemblyName System.IO.Compression
Add-Type -AssemblyName System.IO.Compression.FileSystem
$zipStream = [System.IO.File]::Open($ZipPath, [System.IO.FileMode]::CreateNew)
try {
    $archive = [System.IO.Compression.ZipArchive]::new($zipStream, [System.IO.Compression.ZipArchiveMode]::Create, $false)
    try {
        $rootFullPath = [System.IO.Path]::GetFullPath($PackageRoot).TrimEnd('\', '/')
        Get-ChildItem -LiteralPath $PackageRoot -Recurse -File | ForEach-Object {
            $fileFullPath = [System.IO.Path]::GetFullPath($_.FullName)
            $relative = $fileFullPath.Substring($rootFullPath.Length).TrimStart('\', '/')
            $entryName = $relative.Replace('\', '/')
            [System.IO.Compression.ZipFileExtensions]::CreateEntryFromFile(
                $archive,
                $fileFullPath,
                $entryName,
                [System.IO.Compression.CompressionLevel]::Optimal
            ) | Out-Null
        }
    }
    finally {
        $archive.Dispose()
    }
}
finally {
    $zipStream.Dispose()
}

$badEntries = [System.IO.Compression.ZipFile]::OpenRead($ZipPath)
try {
    $windowsPathEntries = $badEntries.Entries | Where-Object { $_.FullName.Contains('\') }
    if ($windowsPathEntries.Count -gt 0) {
        $sample = ($windowsPathEntries | Select-Object -First 10 | ForEach-Object { $_.FullName }) -join ', '
        throw "Refusing to ship AutoInstall template ZIP with Windows path separators: $sample"
    }
}
finally {
    $badEntries.Dispose()
}

[pscustomobject]@{
    zip = $ZipPath
    repository = $Repository
    assetName = $AssetName
    templates = $TemplateDir
} | ConvertTo-Json -Compress

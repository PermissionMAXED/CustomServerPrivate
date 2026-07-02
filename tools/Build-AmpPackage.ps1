param(
    [string]$Configuration = "Release"
)

$ErrorActionPreference = "Stop"

$Root = Resolve-Path (Join-Path $PSScriptRoot "..")
$AmpDir = Join-Path $Root "deployment\amp"
$PackageRoot = Join-Path $AmpDir "package"
$TemplateDir = Join-Path $PackageRoot "templates"
$ServerWinDir = Join-Path $PackageRoot "server\win-x64\BapCustomServer"
$ServerLinuxDir = Join-Path $PackageRoot "server\linux-x64\BapCustomServer"
$ZipPath = Join-Path $AmpDir "bapcustomserver-amp-instance.zip"

$serverProject = Join-Path $Root "CustomMatchServer\BapCustomServer.csproj"
$PublishRoot = Join-Path $Root "CustomMatchServer\publish"

function Set-ZipUnixExecutableAttribute {
    param(
        [Parameter(Mandatory = $true)]
        [string]$ZipFile,

        [Parameter(Mandatory = $true)]
        [string[]]$EntryNames
    )

    Add-Type -AssemblyName System.IO.Compression
    Add-Type -AssemblyName System.IO.Compression.FileSystem

    $normalizedTargets = @{}
    foreach ($name in $EntryNames) {
        $normalizedTargets[$name.Replace("\", "/")] = $true
    }

    $archive = [System.IO.Compression.ZipFile]::Open($ZipFile, [System.IO.Compression.ZipArchiveMode]::Update)
    try {
        foreach ($entry in $archive.Entries) {
            $normalizedName = $entry.FullName.Replace("\", "/")
            if ($normalizedTargets.ContainsKey($normalizedName)) {
                $entry.ExternalAttributes = (0x81ED -shl 16) -bor ($entry.ExternalAttributes -band 0xFFFF)
            }
        }
    }
    finally {
        $archive.Dispose()
    }
}

if (Test-Path $PublishRoot) {
    Remove-Item -LiteralPath $PublishRoot -Recurse -Force
}

dotnet publish $serverProject -c $Configuration -r win-x64 --self-contained false -o (Join-Path $Root "CustomMatchServer\publish\win-x64")
dotnet publish $serverProject -c $Configuration -r linux-x64 --self-contained false -o (Join-Path $Root "CustomMatchServer\publish\linux-x64")

if (Test-Path $PackageRoot) {
    Remove-Item -LiteralPath $PackageRoot -Recurse -Force
}

New-Item -ItemType Directory -Force -Path $TemplateDir, $ServerWinDir, $ServerLinuxDir | Out-Null

Copy-Item -LiteralPath (Join-Path $AmpDir "bapcustomserver.kvp") -Destination $TemplateDir
Copy-Item -LiteralPath (Join-Path $AmpDir "bapcustomserverconfig.json") -Destination $TemplateDir
Copy-Item -LiteralPath (Join-Path $AmpDir "bapcustomservermetaconfig.json") -Destination $TemplateDir
Copy-Item -LiteralPath (Join-Path $AmpDir "bapcustomserverports.json") -Destination $TemplateDir
Copy-Item -LiteralPath (Join-Path $AmpDir "README.md") -Destination (Join-Path $PackageRoot "README-AMP.md")

Copy-Item -Path (Join-Path $Root "CustomMatchServer\publish\win-x64\*") -Destination $ServerWinDir -Recurse
Copy-Item -Path (Join-Path $Root "CustomMatchServer\publish\linux-x64\*") -Destination $ServerLinuxDir -Recurse

if (Test-Path $ZipPath) {
    Remove-Item -LiteralPath $ZipPath -Force
}

Compress-Archive -Path (Join-Path $PackageRoot "*") -DestinationPath $ZipPath -Force
Set-ZipUnixExecutableAttribute -ZipFile $ZipPath -EntryNames @(
    "server/linux-x64/BapCustomServer/BapCustomServer"
)

[pscustomobject]@{
    zip = $ZipPath
    templates = $TemplateDir
    windowsServer = $ServerWinDir
    linuxServer = $ServerLinuxDir
} | ConvertTo-Json -Compress

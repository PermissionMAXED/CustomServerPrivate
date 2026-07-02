param(
    [string]$Configuration = "Release",
    [switch]$FrameworkDependent,
    [switch]$IncludeGameFiles
)

$ErrorActionPreference = "Stop"

# Pinned dist-mod hash. We pull from BapCustomServerMelon\dist\BapCustomServerMelon.dll
# and refuse to ship a server package that does not contain the locally match-tested mod.
$ExpectedModSha256 = "35942181ED16CD1FE3A06350F7D2255030CFD6C6D30BE0109BC1E4123CE4C611"

$Root = Resolve-Path (Join-Path $PSScriptRoot "..")
$OutRoot = Join-Path $Root "deployment\server-packages"
$PackageRoot = Join-Path $OutRoot "package"
$WinRoot = Join-Path $PackageRoot "windows-server"
$LinuxRoot = Join-Path $PackageRoot "linux-server"
$ServerProject = Join-Path $Root "CustomMatchServer\BapCustomServer.csproj"
$ModDll = Join-Path $Root "BapCustomServerMelon\dist\BapCustomServerMelon.dll"
$GameDir = Join-Path $Root "Spiel\Battleroyalebuild"

# Fail fast if the on-disk dist DLL is not the pinned working build.
if (-not (Test-Path -LiteralPath $ModDll)) {
    throw "Mod DLL not found at $ModDll. Server packages must ship the dist build, not bin\Release."
}
$sourceModHash = (Get-FileHash -LiteralPath $ModDll -Algorithm SHA256).Hash
if ($sourceModHash.ToUpperInvariant() -ne $ExpectedModSha256.ToUpperInvariant()) {
    throw "Source mod DLL hash mismatch at $ModDll. Expected $ExpectedModSha256 got $sourceModHash. Refusing to build broken server packages."
}

$selfContained = -not $FrameworkDependent.IsPresent
$selfContainedText = if ($selfContained) { "true" } else { "false" }

New-Item -ItemType Directory -Force -Path $OutRoot | Out-Null
if (Test-Path $PackageRoot) {
    Remove-Item -LiteralPath $PackageRoot -Recurse -Force
}

New-Item -ItemType Directory -Force -Path `
    (Join-Path $WinRoot "BapCustomServer"), `
    (Join-Path $LinuxRoot "BapCustomServer"), `
    (Join-Path $WinRoot "client-mod"), `
    (Join-Path $LinuxRoot "client-mod") | Out-Null

$winPublish = Join-Path $OutRoot "publish\win-x64"
$linuxPublish = Join-Path $OutRoot "publish\linux-x64"
if (Test-Path (Join-Path $OutRoot "publish")) {
    Remove-Item -LiteralPath (Join-Path $OutRoot "publish") -Recurse -Force
}

dotnet publish $ServerProject -c $Configuration -r win-x64 --self-contained $selfContainedText -o $winPublish
dotnet publish $ServerProject -c $Configuration -r linux-x64 --self-contained $selfContainedText -o $linuxPublish

Copy-Item -Path (Join-Path $winPublish "*") -Destination (Join-Path $WinRoot "BapCustomServer") -Recurse
Copy-Item -Path (Join-Path $linuxPublish "*") -Destination (Join-Path $LinuxRoot "BapCustomServer") -Recurse

if (Test-Path $ModDll) {
    Copy-Item -LiteralPath $ModDll -Destination (Join-Path $WinRoot "client-mod")
    Copy-Item -LiteralPath $ModDll -Destination (Join-Path $LinuxRoot "client-mod")
}

@'
param(
    [string]$PublicHost = "127.0.0.1",
    [int]$LobbyPort = 5055,
    [string]$AdminToken = ""
)

$ErrorActionPreference = "Stop"
$Root = Split-Path -Parent $MyInvocation.MyCommand.Path
$env:ASPNETCORE_URLS = "http://0.0.0.0:$LobbyPort"
$env:CustomServer__PublicBaseUrl = "http://$PublicHost`:$LobbyPort"
$env:CustomServer__PublicGameHost = $PublicHost
$env:CustomServer__GameExecutablePath = Join-Path $Root "game\bapbap.exe"
$env:CustomServer__GameWorkingDirectory = Join-Path $Root "game"
$env:CustomServer__GameLogDirectory = Join-Path $Root "logs\game-servers"
if (-not [string]::IsNullOrWhiteSpace($AdminToken)) {
    $env:CustomServer__Admin__ApiToken = $AdminToken
}

& (Join-Path $Root "BapCustomServer\BapCustomServer.exe")
'@ | Set-Content -LiteralPath (Join-Path $WinRoot "Start-BapCustomServer.ps1") -Encoding UTF8

@'
#!/usr/bin/env bash
set -euo pipefail

ROOT="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
PUBLIC_HOST="${PUBLIC_HOST:-127.0.0.1}"
LOBBY_PORT="${LOBBY_PORT:-5055}"

export ASPNETCORE_URLS="http://0.0.0.0:${LOBBY_PORT}"
export CustomServer__PublicBaseUrl="http://${PUBLIC_HOST}:${LOBBY_PORT}"
export CustomServer__PublicGameHost="${PUBLIC_HOST}"
export CustomServer__GameExecutablePath="${ROOT}/game/bapbap.x86_64"
export CustomServer__GameWorkingDirectory="${ROOT}/game"
export CustomServer__GameLogDirectory="${ROOT}/logs/game-servers"

if [[ -n "${ADMIN_TOKEN:-}" ]]; then
  export CustomServer__Admin__ApiToken="${ADMIN_TOKEN}"
fi

chmod +x "${ROOT}/BapCustomServer/BapCustomServer" 2>/dev/null || true
exec "${ROOT}/BapCustomServer/BapCustomServer"
'@ | Set-Content -LiteralPath (Join-Path $LinuxRoot "start-bapcustomserver.sh") -Encoding UTF8

@'
# BAPBAP Custom Server - Windows Package

Run:

```powershell
.\Start-BapCustomServer.ps1 -PublicHost "YOUR_PUBLIC_IP" -LobbyPort 5055 -AdminToken "CHANGE_ME"
```

Place the Windows game host files in `game\` if this package was built without `-IncludeGameFiles`.
The expected executable is `game\bapbap.exe`.

Players install `client-mod\BapCustomServerMelon.dll` into their game `Mods` folder, open the in-game panel with F7, and point it to your public host and lobby port.
'@ | Set-Content -LiteralPath (Join-Path $WinRoot "README-WINDOWS-SERVER.md") -Encoding UTF8

@'
# BAPBAP Custom Server - Linux Package

Run:

```bash
chmod +x ./start-bapcustomserver.sh
PUBLIC_HOST="YOUR_PUBLIC_IP" LOBBY_PORT=5055 ADMIN_TOKEN="CHANGE_ME" ./start-bapcustomserver.sh
```

Place a real Linux Unity dedicated/headless build in `game/` if this package was built without `-IncludeGameFiles`.
The expected executable is `game/bapbap.x86_64`.

The ASP.NET lobby/matchmaker is Linux-native. The Unity match process still requires a Linux dedicated build or a working Wine setup for the Windows executable.
'@ | Set-Content -LiteralPath (Join-Path $LinuxRoot "README-LINUX-SERVER.md") -Encoding UTF8

if ($IncludeGameFiles) {
    Copy-Item -LiteralPath $GameDir -Destination (Join-Path $WinRoot "game") -Recurse
    Copy-Item -LiteralPath $GameDir -Destination (Join-Path $LinuxRoot "game-windows-build-for-wine") -Recurse
}
else {
    New-Item -ItemType Directory -Force -Path (Join-Path $WinRoot "game"), (Join-Path $LinuxRoot "game") | Out-Null
    "Place bapbap.exe and its Unity data files here for Windows match hosting." |
        Set-Content -LiteralPath (Join-Path $WinRoot "game\PUT_WINDOWS_GAME_FILES_HERE.txt") -Encoding UTF8
    "Place a Linux Unity dedicated/headless build here as bapbap.x86_64." |
        Set-Content -LiteralPath (Join-Path $LinuxRoot "game\PUT_LINUX_DEDICATED_BUILD_HERE.txt") -Encoding UTF8
}

$winZip = Join-Path $OutRoot "bapcustomserver-windows-server.zip"
$linuxZip = Join-Path $OutRoot "bapcustomserver-linux-server.zip"
Remove-Item -LiteralPath $winZip, $linuxZip -Force -ErrorAction SilentlyContinue
Compress-Archive -Path (Join-Path $WinRoot "*") -DestinationPath $winZip -Force
Compress-Archive -Path (Join-Path $LinuxRoot "*") -DestinationPath $linuxZip -Force

# Post-compress verification: open each archive WITHOUT extracting and SHA256
# the bundled mod DLL entry. Throws if either archive's mod DLL does not match
# the pinned dist build.
Add-Type -AssemblyName System.IO.Compression.FileSystem | Out-Null
function Assert-BundledModHash {
    param(
        [Parameter(Mandatory = $true)] [string]$ZipPath,
        [Parameter(Mandatory = $true)] [string]$EntryRelativePath,
        [Parameter(Mandatory = $true)] [string]$Expected
    )
    $normalized = $EntryRelativePath -replace '\\', '/'
    $zipHandle = [System.IO.Compression.ZipFile]::OpenRead($ZipPath)
    try {
        $entry = $zipHandle.Entries |
            Where-Object { ($_.FullName -replace '\\', '/') -ieq $normalized } |
            Select-Object -First 1
        if (-not $entry) {
            throw "Bundled archive $ZipPath does not contain $normalized"
        }
        $entryStream = $entry.Open()
        try {
            $sha = [System.Security.Cryptography.SHA256]::Create()
            try {
                $hashBytes = $sha.ComputeHash($entryStream)
                $bundledHash = (-join ($hashBytes | ForEach-Object { $_.ToString("x2") })).ToUpperInvariant()
            } finally {
                $sha.Dispose()
            }
        } finally {
            $entryStream.Dispose()
        }
    } finally {
        $zipHandle.Dispose()
    }
    if ($bundledHash -ne $Expected.ToUpperInvariant()) {
        throw "Bundled mod DLL hash mismatch inside $ZipPath at $normalized. Expected $Expected got $bundledHash. Package is invalid."
    }
    Write-Host "Verified $ZipPath :: $normalized SHA256 = $bundledHash" -ForegroundColor Green
}

Assert-BundledModHash -ZipPath $winZip   -EntryRelativePath "client-mod/BapCustomServerMelon.dll" -Expected $ExpectedModSha256
Assert-BundledModHash -ZipPath $linuxZip -EntryRelativePath "client-mod/BapCustomServerMelon.dll" -Expected $ExpectedModSha256

[pscustomobject]@{
    selfContained = $selfContained
    includeGameFiles = $IncludeGameFiles.IsPresent
    windowsZip = $winZip
    linuxZip = $linuxZip
    windowsRoot = $WinRoot
    linuxRoot = $LinuxRoot
} | ConvertTo-Json -Compress

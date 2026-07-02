param(
    [string]$Configuration = "Release",
    [switch]$FrameworkDependent,
    [string]$PublicHost = "ark.atomi23.de",
    [int]$LobbyPort = 5055,
    [int]$BaseWsPort = 7777,
    [int]$BaseKcpPort = 7778,
    [int]$BaseTcpPort = 7779,
    [int]$BaseHttpPort = 7850,
    [string]$ReleaseLabel = $env:BAPCUSTOM_RELEASE_LABEL
)

$ErrorActionPreference = "Stop"

$Root = Resolve-Path (Join-Path $PSScriptRoot "..")
$OutRoot = Join-Path $Root "deployment\amp-full-linux-wine"
$PackageRoot = Join-Path $OutRoot "package"
$ServerProject = Join-Path $Root "CustomMatchServer\BapCustomServer.csproj"
$GameSource = Join-Path $Root "Spiel\Battleroyalebuild"
$ModDll = Join-Path $Root "BapCustomServerMelon\dist\BapCustomServerMelon.dll"
$ModIni = Join-Path $Root "BapCustomServerMelon\dist\BapCustomServer.ini"
$AssetIndex = Join-Path $Root "data\asset-index.json"
$ZipPath = Join-Path $OutRoot "bapcustomserver-amp-full-linux-wine.zip"
$DownloadsRoot = Split-Path -Parent ([string]$Root)
$ModdingRoot = Join-Path $DownloadsRoot "BAPBAPModdingAPI"
$MedusaModRoot = Join-Path $ModdingRoot "medusa-mod"
$ModApiRoot = Join-Path $ModdingRoot "BAPBAPModAPI"
$MedusaDll = Join-Path $MedusaModRoot "bin\Release\BAPBAP.Medusa.dll"
$MedusaBundle = Join-Path $MedusaModRoot "medusa.bundle"
$ModApiDllCandidates = @(
    (Join-Path $ModApiRoot "modapi\bin\$Configuration\BAPBAP.ModAPI.dll"),
    (Join-Path $ModApiRoot "modapi\bin\Release\BAPBAP.ModAPI.dll"),
    (Join-Path $ModApiRoot "dist\UserLibs\BAPBAP.ModAPI.dll")
)

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

function Get-FileSha256 {
    param([Parameter(Mandatory = $true)][string]$Path)
    if (-not (Test-Path -LiteralPath $Path)) { return "" }
    return (Get-FileHash -Algorithm SHA256 -LiteralPath $Path).Hash.ToUpperInvariant()
}

function Resolve-FirstExistingPath {
    param(
        [Parameter(Mandatory = $true)][string[]]$Candidates,
        [Parameter(Mandatory = $true)][string]$Name
    )

    foreach ($candidate in $Candidates) {
        if (Test-Path -LiteralPath $candidate) {
            return $candidate
        }
    }

    throw "$Name not found. Checked: $($Candidates -join ', ')"
}

$ModApiDll = Resolve-FirstExistingPath -Candidates $ModApiDllCandidates -Name "BAPBAP.ModAPI.dll"

function Install-MedusaArtifacts {
    param([Parameter(Mandatory = $true)][string]$TargetGameRoot)

    $targetMods = Join-Path $TargetGameRoot "Mods"
    $targetUserLibs = Join-Path $TargetGameRoot "UserLibs"
    $targetMedusaUserData = Join-Path $TargetGameRoot "UserData\Medusa"
    New-Item -ItemType Directory -Force -Path $targetMods, $targetUserLibs, $targetMedusaUserData | Out-Null

    if (Test-Path -LiteralPath $ModApiDll) {
        Copy-Item -LiteralPath $ModApiDll -Destination (Join-Path $targetMods "BAPBAP.ModAPI.dll") -Force
        Copy-Item -LiteralPath $ModApiDll -Destination (Join-Path $targetUserLibs "BAPBAP.ModAPI.dll") -Force
    }
    if (Test-Path -LiteralPath $MedusaDll) {
        Copy-Item -LiteralPath $MedusaDll -Destination (Join-Path $targetMods "BAPBAP.Medusa.dll") -Force
    }
    if (Test-Path -LiteralPath $MedusaBundle) {
        Copy-Item -LiteralPath $MedusaBundle -Destination (Join-Path $targetMedusaUserData "medusa.bundle") -Force
    }

    $required = @(
        (Join-Path $targetMods "BAPBAP.ModAPI.dll"),
        (Join-Path $targetUserLibs "BAPBAP.ModAPI.dll"),
        (Join-Path $targetMods "BAPBAP.Medusa.dll"),
        (Join-Path $targetMedusaUserData "medusa.bundle")
    )
    foreach ($path in $required) {
        if (-not (Test-Path -LiteralPath $path)) {
            throw "Missing Medusa package artifact '$path'. Build/copy BAPBAP.ModAPI + BAPBAP.Medusa from '$ModdingRoot' before packaging."
        }
    }

    Write-Host "Installed Medusa package artifacts:" -ForegroundColor Green
    Write-Host "  Mods/BAPBAP.ModAPI.dll SHA256=$(Get-FileSha256 (Join-Path $targetMods 'BAPBAP.ModAPI.dll'))" -ForegroundColor DarkGreen
    Write-Host "  Mods/BAPBAP.Medusa.dll SHA256=$(Get-FileSha256 (Join-Path $targetMods 'BAPBAP.Medusa.dll'))" -ForegroundColor DarkGreen
    Write-Host "  UserData/Medusa/medusa.bundle SHA256=$(Get-FileSha256 (Join-Path $targetMedusaUserData 'medusa.bundle'))" -ForegroundColor DarkGreen
}

function Invoke-GitOneLine {
    param([Parameter(Mandatory = $true)][string[]]$GitArgs)
    try {
        $output = & git @GitArgs 2>$null
        $exitCode = $LASTEXITCODE
        $value = $output | Select-Object -First 1
        if ($exitCode -eq 0 -and -not [string]::IsNullOrWhiteSpace($value)) {
            return [string]$value
        }
    }
    catch { }
    return ""
}

if (-not (Test-Path -LiteralPath $GameSource)) {
    throw "Game source folder not found: $GameSource"
}

if (-not (Test-Path -LiteralPath $ModDll) -or -not (Test-Path -LiteralPath $ModIni)) {
    # Do NOT auto-rebuild here. The dist DLL is the canonical artifact that
    # has been tested against the live AMP/Wine flow:
    #   SHA256 = 24C78476138DD0DFD3D483C0E4F26054EAEB89FB3E3FA283B027FA4D6F9D18EB
    #   Size   = 266240 bytes
    # If the dist artifacts are missing, the operator must restore them from a
    # backup before packaging. Silently invoking Install-BapCustomServerMelon.ps1
    # here would bypass the pinned artifact check below.
    throw @"
Required mod artifacts are missing under BapCustomServerMelon\dist:
  DLL: $ModDll
  INI: $ModIni

Refusing to auto-rebuild. Restore the pinned binary (SHA256 24C78476138DD0DFD3D483C0E4F26054EAEB89FB3E3FA283B027FA4D6F9D18EB,
size 266240 bytes) and the matching BapCustomServer.ini into BapCustomServerMelon\dist
before re-running this packager. See tools\Install-BapCustomServerMelon.ps1 and
the latest source backup under C:\Users\Administrator\Downloads\CustomServer-Backups.
"@
}

$selfContained = -not $FrameworkDependent.IsPresent
$selfContainedText = if ($selfContained) { "true" } else { "false" }

if (Test-Path -LiteralPath $PackageRoot) {
    try {
        Remove-Item -LiteralPath $PackageRoot -Recurse -Force
    }
    catch {
        $fallbackPackageRoot = Join-Path $OutRoot ("package-build-" + (Get-Date -Format "yyyyMMddHHmmss"))
        Write-Warning "Could not remove old package staging folder '$PackageRoot'. Building in '$fallbackPackageRoot' instead. Original error: $($_.Exception.Message)"
        $PackageRoot = $fallbackPackageRoot
    }
}

$ServerRoot = Join-Path $PackageRoot "BapCustomServer"
$GameRoot = Join-Path $ServerRoot "game"

New-Item -ItemType Directory -Force -Path $ServerRoot, $GameRoot | Out-Null

dotnet publish $ServerProject -c $Configuration -r linux-x64 --self-contained $selfContainedText -o $ServerRoot

# Copy per-match wine isolation wrapper next to BapCustomServer in the SERVER root.
# Each match invocation gets its own WINEPREFIX and Xvfb display, fixing W1/W2/W4
# concurrent-match races identified in audit a27.
$startMatchSource = Join-Path $OutRoot "start-match.sh"
if (-not (Test-Path -LiteralPath $startMatchSource)) {
    throw "Required wrapper script not found: $startMatchSource"
}
$startMatchDest = Join-Path $ServerRoot "start-match.sh"
$startMatchContent = [System.IO.File]::ReadAllText($startMatchSource).Replace("`r`n", "`n")
[System.IO.File]::WriteAllText($startMatchDest, $startMatchContent, [System.Text.UTF8Encoding]::new($false))
Write-Host "Copied per-match wine isolation wrapper to server root: $startMatchDest" -ForegroundColor Green

Copy-Item -LiteralPath $GameSource -Destination $GameRoot -Recurse

$nestedGame = Join-Path $GameRoot "Battleroyalebuild"
if (Test-Path -LiteralPath $nestedGame) {
    Get-ChildItem -LiteralPath $nestedGame -Force | ForEach-Object {
        Move-Item -LiteralPath $_.FullName -Destination $GameRoot -Force
    }
    Remove-Item -LiteralPath $nestedGame -Recurse -Force
}

$gameMods = Join-Path $GameRoot "Mods"
New-Item -ItemType Directory -Force -Path $gameMods | Out-Null
Copy-Item -LiteralPath $ModDll -Destination (Join-Path $gameMods "BapCustomServerMelon.dll") -Force
$stagedModIni = Join-Path $gameMods "BapCustomServer.ini"
Copy-Item -LiteralPath $ModIni -Destination $stagedModIni -Force

# Patch the staged ini for the dedicated match process. Inside the AMP container,
# the game should talk to the local ASP.NET lobby, not hairpin through public DNS.
# The proxy is a client-only convenience.
$stagedIniText = [System.IO.File]::ReadAllText($stagedModIni)
$stagedIniText = [regex]::Replace($stagedIniText, '(?im)^[ \t]*Host[ \t]*=.*$', "Host=127.0.0.1")
$stagedIniText = [regex]::Replace($stagedIniText, '(?im)^[ \t]*Port[ \t]*=.*$', "Port=$LobbyPort")
$stagedIniText = [regex]::Replace($stagedIniText, '(?im)^[ \t]*UseLocalProxy[ \t]*=.*$', 'UseLocalProxy=false')
$stagedIniText = [regex]::Replace($stagedIniText, '(?im)^[ \t]*AutoGuestLogin[ \t]*=.*$', 'AutoGuestLogin=false')
$stagedIniText = [regex]::Replace($stagedIniText, '(?im)^[ \t]*ShowStatusChip[ \t]*=.*$', 'ShowStatusChip=false')
$stagedIniText = [regex]::Replace($stagedIniText, '(?im)^[ \t]*UseNativeGameUi[ \t]*=.*$', 'UseNativeGameUi=false')
[System.IO.File]::WriteAllText(
    $stagedModIni,
    $stagedIniText,
    [System.Text.UTF8Encoding]::new($false)
)
Write-Host "Patched staged BapCustomServer.ini: Host=127.0.0.1, Port=$LobbyPort, UseLocalProxy=false, UI=false." -ForegroundColor Green

foreach ($path in @(
    (Join-Path $GameRoot "MelonLoader\Logs"),
    (Join-Path $GameRoot "MelonLoader\Latest.log"),
    (Join-Path $GameRoot "customserver-melon-debug-support-afterpatch.log"),
    (Join-Path $GameRoot "customserver-melon-debug-support.log"),
    (Join-Path $GameRoot "customserver-melon-patched-interop.log"),
    (Join-Path $GameRoot "customserver-melon-patched-no-force.log"),
    (Join-Path $GameRoot "customserver-melon-smoke-flags.log"),
    (Join-Path $GameRoot "customserver-melon-smoke.log"),
    (Join-Path $GameRoot "Mods\BapCustomServerMelon.dll.4FC3B8DA.bak"),
    (Join-Path $GameRoot "Mods\BapCustomServerMelon.dll.B6677CA.current.bak"),
    (Join-Path $GameRoot "bapbap_Data\resources.assets.bak"),
    (Join-Path $GameRoot "bapbap_Data\sharedassets0.assets.bak"),
    (Join-Path $ServerRoot "data\admin-state.json"),
    (Join-Path $ServerRoot "data\economy-state.json"),
    (Join-Path $ServerRoot "data\ranked-state.json")
)) {
    Remove-Item -LiteralPath $path -Recurse -Force -ErrorAction SilentlyContinue
}

$assetsDir = Join-Path $ServerRoot "assets"
New-Item -ItemType Directory -Force -Path $assetsDir | Out-Null
if (Test-Path -LiteralPath $AssetIndex) {
    Copy-Item -LiteralPath $AssetIndex -Destination (Join-Path $assetsDir "asset-index.json") -Force
    Write-Host "Staged static asset index under assets/asset-index.json (outside preserved data/)." -ForegroundColor Green
}
else {
    Write-Warning "Static asset index not found at $AssetIndex. Admin asset-index API will rely on runtime/local fallback paths."
}

# Force-write a clean MelonPreferences.cfg into the dedicated server bundle.
# NetTune is disabled in the Wine package because this path has shown
# startup/thread stalls with the tuning hooks enabled.
$userDataDir = Join-Path $GameRoot "UserData"
New-Item -ItemType Directory -Force -Path $userDataDir | Out-Null
$cleanMelonPrefs = @"
[BapCustomServer]
Host = "127.0.0.1"
ServerPort = $LobbyPort
UseHttps = false
UseLocalProxy = false
LocalProxyPort = 5055
ShowStatusChip = false
UseNativeGameUi = false
AccountId = ""
Username = ""
AutoGuestLogin = false
ShowModdingOverlay = false
ModdingOverlayTitle = "BAPBAP Modding"
ModdingOverlaySubtitle = "discord.gg/bapbapmods"
AllowDevPanel = false
ForceOnMatchStarted = false
NetTuneEnabled = false
ProductionMode = true
"@
[System.IO.File]::WriteAllText(
    (Join-Path $userDataDir "MelonPreferences.cfg"),
    $cleanMelonPrefs.Replace("`r`n", "`n"),
    [System.Text.UTF8Encoding]::new($false)
)
Write-Host "Force-wrote MelonPreferences.cfg with NetTuneEnabled=false and cleared identity." -ForegroundColor Green

Install-MedusaArtifacts -TargetGameRoot $GameRoot

$medusaAutoSelectMarker = Join-Path $GameRoot "UserData\Medusa\auto-select.txt"
if ($env:BAPCUSTOM_PACKAGE_MEDUSA_AUTOSELECT -eq "1") {
    Write-Warning "Packaging Medusa auto-select marker because BAPCUSTOM_PACKAGE_MEDUSA_AUTOSELECT=1."
}
else {
    Remove-Item -LiteralPath $medusaAutoSelectMarker -Force -ErrorAction SilentlyContinue
    Write-Host "Ensured Medusa auto-select marker is not shipped in the AMP game bundle." -ForegroundColor Green
}

$appsettings = Join-Path $ServerRoot "appsettings.json"
$settings = Get-Content -Raw -LiteralPath $appsettings | ConvertFrom-Json

function Set-JsonProperty {
    param($Object, $Name, $Value)
    if ($Object.PSObject.Properties[$Name]) {
        $Object.$Name = $Value
    } else {
        $Object | Add-Member -NotePropertyName $Name -NotePropertyValue $Value -Force
    }
}

Set-JsonProperty $settings 'Urls' "http://0.0.0.0:$LobbyPort"
Set-JsonProperty $settings.CustomServer 'PublicBaseUrl' "http://${PublicHost}:$LobbyPort"
Set-JsonProperty $settings.CustomServer 'PublicGameHost' $PublicHost
Set-JsonProperty $settings.CustomServer 'BaseHttpPort' $BaseHttpPort
Set-JsonProperty $settings.CustomServer 'BaseWsPort' $BaseWsPort
Set-JsonProperty $settings.CustomServer 'BaseKcpPort' $BaseKcpPort
Set-JsonProperty $settings.CustomServer 'BaseTcpPort' $BaseTcpPort
Set-JsonProperty $settings.CustomServer 'PortSearchRange' 1
Set-JsonProperty $settings.CustomServer 'PortReleaseCooldownSeconds' 0
Set-JsonProperty $settings.CustomServer 'MaxConcurrentMatches' 1
Set-JsonProperty $settings.CustomServer 'EmptyLobbyMatchCleanupGraceSeconds' 15
Set-JsonProperty $settings.CustomServer 'EmptyLobbyMatchConnectedCleanupGraceSeconds' 45
Set-JsonProperty $settings.CustomServer 'RequireGameServerKcpPort' $true
Set-JsonProperty $settings.CustomServer 'GameExecutablePath' "./game/bapbap.exe"
Set-JsonProperty $settings.CustomServer 'GameWorkingDirectory' "./game"
Set-JsonProperty $settings.CustomServer 'GameLauncherPath' "./start-match.sh"
Set-JsonProperty $settings.CustomServer 'GameLauncherArguments' "`"{gameExecutable}`" {gameArguments}"
Set-JsonProperty $settings.CustomServer 'GameLogDirectory' "logs/game-servers"
Set-JsonProperty $settings.CustomServer 'GameServerReadyTimeoutSeconds' 300
Set-JsonProperty $settings.CustomServer 'GameServerBootstrapHttpTimeoutSeconds' 20
Set-JsonProperty $settings.CustomServer 'GameServerBootstrapResetPollMillis' 1500
Set-JsonProperty $settings.CustomServer 'GameServerManagedBootstrapStatusTimeoutSeconds' 180
Set-JsonProperty $settings.CustomServer 'GameServerManagedBootstrapListenerOnlyTimeoutSeconds' 0
Set-JsonProperty $settings.CustomServer 'GameServerTcpPortReadyTimeoutSeconds' 30
Set-JsonProperty $settings.CustomServer 'GameServerKcpPortReadyTimeoutSeconds' 45
Set-JsonProperty $settings.CustomServer 'GameServerStartAttempts' 2
Set-JsonProperty $settings.CustomServer 'GameServerStartRetryDelaySeconds' 10
Set-JsonProperty $settings.CustomServer 'GameServerStopWaitMillis' 5000
Set-JsonProperty $settings.CustomServer 'GameServerPostCleanupStartDelayMillis' 3000
Set-JsonProperty $settings.CustomServer 'GameServerStartupStallGraceSeconds' 45
Set-JsonProperty $settings.CustomServer 'GameServerStartupStallSeconds' 25
Set-JsonProperty $settings.CustomServer 'GameServerWrapperOnlyStartupStallGraceSeconds' 60
Set-JsonProperty $settings.CustomServer 'GameServerWrapperOnlyStartupStallSeconds' 25
Set-JsonProperty $settings.CustomServer 'GameServerPrewarmOnStartup' $true
Set-JsonProperty $settings.CustomServer 'GameServerPrewarmTimeoutSeconds' 180
Set-JsonProperty $settings.CustomServer 'GameServerPrewarmMatchWaitSeconds' 35
Set-JsonProperty $settings.CustomServer 'GameServerPrewarmPortOffset' 150
Set-JsonProperty $settings.CustomServer 'GameServerPrewarmSettleSeconds' 3
Set-JsonProperty $settings.CustomServer 'AdditionalGameArguments' "--melonloader.agfoffline --bapcustom-use-proxy=false --bapcustom-show-ui=false"

# === Playtest bug fixes ===
Set-JsonProperty $settings.CustomServer.Unlocks 'UnlockEverything' $true
Set-JsonProperty $settings.CustomServer.Unlocks 'SkinAssetIdStart' 300000
Set-JsonProperty $settings.CustomServer.Unlocks 'SkinAssetIdEnd' 300026
Set-JsonProperty $settings.CustomServer.Unlocks 'ExtraOwnedAssetIds' @(300000, 300003, 300005, 300007, 300013, 300015, 300016, 300017, 300018, 300019, 300020, 300021, 300023, 300025, 300026)
Set-JsonProperty $settings.CustomServer.Unlocks 'CurrencyAssetIds' @(0, 1, 2, 3, 4, 5)
Set-JsonProperty $settings.CustomServer.Unlocks 'CurrencyBalance' 999999
Set-JsonProperty $settings.CustomServer.Unlocks 'CharTokenBalance' 0
Set-JsonProperty $settings.CustomServer.Unlocks 'CharTokenAssetId' 2
Set-JsonProperty $settings.CustomServer.Unlocks 'GoldAssetId' 0

Set-JsonProperty $settings.CustomServer.MatchDefaults 'MapId' 0
$mapPool = @(1, 2, 3, 4)
$mapMapping = @()
foreach ($gameModeId in 0..10) {
    $mapMapping += [pscustomobject]@{ UnityGameModeId = $gameModeId; MapIds = $mapPool }
}
Set-JsonProperty $settings.CustomServer.MatchDefaults 'MapMapping' $mapMapping
Set-JsonProperty $settings.CustomServer.MatchDefaults 'UnityGameMode' 0
Set-JsonProperty $settings.CustomServer.MatchDefaults 'MatchmakingGameMode' 0
# Advertised lobby modes: Solos + Duos only. WITHOUT this field the server falls back to the code
# default "0,3,4,5,9,10", whose first tile (0=Warmup) shows as the selected mode. Keep it pinned.
Set-JsonProperty $settings.CustomServer.MatchDefaults 'EnabledGameModeIdsCsv' '3,4'
Set-JsonProperty $settings.CustomServer.MatchDefaults 'CharSelectMillis' 20000
Set-JsonProperty $settings.CustomServer.MatchDefaults 'SpawnSelectMillis' 10000
Set-JsonProperty $settings.CustomServer.MatchDefaults 'SpawnShowMillis' 3000
Set-JsonProperty $settings.CustomServer.MatchDefaults 'AvailableCharacters' @(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15)
if (-not $settings.CustomServer.PSObject.Properties['Roster']) {
    Set-JsonProperty $settings.CustomServer 'Roster' ([pscustomobject]@{})
}
Set-JsonProperty $settings.CustomServer.Roster 'EnableMedusa' $true

Set-JsonProperty $settings.CustomServer.MatchmakingQueue 'DefaultGameMode' 3
Set-JsonProperty $settings.CustomServer.MatchmakingQueue 'DefaultTeamSize' 1
Set-JsonProperty $settings.CustomServer.MatchmakingQueue 'DefaultMaxTeams' 8
Set-JsonProperty $settings.CustomServer.MatchmakingQueue 'DefaultBotCount' 0
# MaxBotCount clamps the per-mode BotCount (PicMatch ResolveModeSettings -> queue clamp). It MUST be
# >= the largest PerModeSettings BotCount (20) or Solos/Duos get clamped down to a near-empty lobby.
Set-JsonProperty $settings.CustomServer.MatchmakingQueue 'MaxBotCount' 32
Set-JsonProperty $settings.CustomServer.MatchmakingQueue 'DefaultBotDifficulty' 1
Set-JsonProperty $settings.CustomServer.MatchmakingQueue 'DefaultMapId' 0
Set-JsonProperty $settings.CustomServer.MatchmakingQueue 'FailedStartRetryDelaySeconds' 5

# Analytics section: AMP's AnalyticsPlugin reads server logs via these regex patterns
if (-not $settings.CustomServer.PSObject.Properties['Analytics']) {
    Add-Member -InputObject $settings.CustomServer -NotePropertyName 'Analytics' -NotePropertyValue ([pscustomobject]@{}) -Force
}
Set-JsonProperty $settings.CustomServer.Analytics 'Enabled' $true
Set-JsonProperty $settings.CustomServer.Analytics 'PlayerJoinRegex' '^\[Analytics\] Player joined: (?<Username>[^ ]+) \(accountId=(?<AccountId>[^)]+)\)$'
Set-JsonProperty $settings.CustomServer.Analytics 'PlayerLeaveRegex' '^\[Analytics\] Player left: (?<Username>[^ ]+) \(accountId=(?<AccountId>[^)]+)\)$'
Set-JsonProperty $settings.CustomServer.Analytics 'MatchStartRegex' '^\[Analytics\] Match started: (?<GameId>[^ ]+) mapId=(?<MapId>\d+) players=(?<PlayerCount>\d+)$'
Set-JsonProperty $settings.CustomServer.Analytics 'MatchEndRegex' '^\[Analytics\] Match ended: (?<GameId>.+)$'
Set-JsonProperty $settings.CustomServer.Analytics 'ChatMessageRegex' ''

# === AMP Analytics integration ===
# AMP's AnalyticsPlugin scrapes the live ASP.NET Core console log via these regex
# patterns to drive the player count + match count graphs in the AMP UI. The
# server emits the matching "[Analytics] Player joined: ...", "[Analytics] Player
# left: ...", "[Analytics] Match started: ...", and "[Analytics] Match ended: ..."
# log lines through ILogger; we just have to enable the feature and ship the
# regexes that match those lines into appsettings.json.
if (-not $settings.CustomServer.PSObject.Properties['Analytics']) {
    Set-JsonProperty $settings.CustomServer 'Analytics' ([pscustomobject]@{})
}
Set-JsonProperty $settings.CustomServer.Analytics 'Enabled' $true
Set-JsonProperty $settings.CustomServer.Analytics 'PlayerJoinRegex' '^\[Analytics\] Player joined: (?<Username>[^ ]+) \(accountId=(?<AccountId>[^)]+)\)$'
Set-JsonProperty $settings.CustomServer.Analytics 'PlayerLeaveRegex' '^\[Analytics\] Player left: (?<Username>[^ ]+) \(accountId=(?<AccountId>[^)]+)\)$'
Set-JsonProperty $settings.CustomServer.Analytics 'MatchStartRegex' '^\[Analytics\] Match started: (?<GameId>[^ ]+) mapId=(?<MapId>\d+) players=(?<PlayerCount>\d+)$'
Set-JsonProperty $settings.CustomServer.Analytics 'MatchEndRegex' '^\[Analytics\] Match ended: (?<GameId>.+)$'

[System.IO.File]::WriteAllText($appsettings, ($settings | ConvertTo-Json -Depth 50), [System.Text.UTF8Encoding]::new($false))

$rootString = [string]$Root
$gitCommit = Invoke-GitOneLine -GitArgs @("-C", $rootString, "rev-parse", "--short=12", "HEAD")
$gitBranch = Invoke-GitOneLine -GitArgs @("-C", $rootString, "rev-parse", "--abbrev-ref", "HEAD")
$gitStatus = Invoke-GitOneLine -GitArgs @("-C", $rootString, "status", "--porcelain", "--untracked-files=no")
$effectiveReleaseLabel = $ReleaseLabel
if ([string]::IsNullOrWhiteSpace($effectiveReleaseLabel)) {
    $effectiveReleaseLabel = Invoke-GitOneLine -GitArgs @("-C", $rootString, "describe", "--tags", "--always", "--dirty")
}
if ([string]::IsNullOrWhiteSpace($effectiveReleaseLabel)) {
    $effectiveReleaseLabel = "local-" + (Get-Date -AsUTC -Format "yyyyMMddHHmmss")
}

$startLinuxWine = @"
#!/usr/bin/env bash
set -euo pipefail

ROOT=`"`$(cd `"`$(dirname `"`${BASH_SOURCE[0]}`")`" && pwd)`"
PUBLIC_HOST=`"`${PUBLIC_HOST:-$PublicHost}`"
LOBBY_PORT=`"`${LOBBY_PORT:-$LobbyPort}`"

export ASPNETCORE_URLS=`"http://0.0.0.0:`${LOBBY_PORT}`"
export CustomServer__PublicBaseUrl=`"http://`${PUBLIC_HOST}:`${LOBBY_PORT}`"
export CustomServer__PublicGameHost=`"`${PUBLIC_HOST}`"
export CustomServer__GameExecutablePath=`"./game/bapbap.exe`"
export CustomServer__GameWorkingDirectory=`"./game`"
if [[ `"`${BAPCUSTOM_ALLOW_LAUNCHER_OVERRIDE:-0}`" == `"1`" ]]; then
  export CustomServer__GameLauncherPath=`"`${GAME_LAUNCHER_PATH:-./start-match.sh}`"
  if [[ -n `"`${GAME_LAUNCHER_ARGUMENTS:-}`" ]]; then
    export CustomServer__GameLauncherArguments=`"`${GAME_LAUNCHER_ARGUMENTS}`"
  else
    export CustomServer__GameLauncherArguments=`"\`"{gameExecutable}\`" {gameArguments}`"
  fi
else
  export CustomServer__GameLauncherPath=`"./start-match.sh`"
  export CustomServer__GameLauncherArguments=`"\`"{gameExecutable}\`" {gameArguments}`"
fi
export CustomServer__GameServerReadyTimeoutSeconds=`"`${GAME_READY_TIMEOUT:-300}`"
export CustomServer__RequireGameServerKcpPort=`"`${REQUIRE_GAME_KCP_PORT:-true}`"
export CustomServer__GameServerManagedBootstrapStatusTimeoutSeconds=`"`${GAME_MANAGED_BOOTSTRAP_TIMEOUT:-180}`"
export CustomServer__GameServerManagedBootstrapListenerOnlyTimeoutSeconds=`"`${GAME_MANAGED_BOOTSTRAP_LISTENER_ONLY_TIMEOUT:-0}`"
export CustomServer__EmptyLobbyMatchCleanupGraceSeconds=`"`${EMPTY_LOBBY_MATCH_CLEANUP_GRACE:-15}`"
export CustomServer__EmptyLobbyMatchConnectedCleanupGraceSeconds=`"`${EMPTY_LOBBY_MATCH_CONNECTED_CLEANUP_GRACE:-45}`"
export CustomServer__GameServerTcpPortReadyTimeoutSeconds=`"`${GAME_TCP_READY_TIMEOUT:-30}`"
export CustomServer__GameServerKcpPortReadyTimeoutSeconds=`"`${GAME_KCP_READY_TIMEOUT:-45}`"
export CustomServer__GameServerStartAttempts=`"`${GAME_START_ATTEMPTS:-2}`"
export CustomServer__GameServerStartRetryDelaySeconds=`"`${GAME_START_RETRY_DELAY:-2}`"
export CustomServer__GameServerStopWaitMillis=`"`${GAME_STOP_WAIT_MS:-5000}`"
export CustomServer__GameServerPostCleanupStartDelayMillis=`"`${GAME_POST_CLEANUP_START_DELAY_MS:-3000}`"
export CustomServer__GameServerStartupStallGraceSeconds=`"`${GAME_STARTUP_STALL_GRACE:-45}`"
export CustomServer__GameServerStartupStallSeconds=`"`${GAME_STARTUP_STALL:-25}`"
export CustomServer__GameServerWrapperOnlyStartupStallGraceSeconds=`"`${GAME_WRAPPER_ONLY_STALL_GRACE:-8}`"
export CustomServer__GameServerWrapperOnlyStartupStallSeconds=`"`${GAME_WRAPPER_ONLY_STALL:-5}`"
export CustomServer__GameServerPrewarmOnStartup=`"`${GAME_PREWARM_ON_STARTUP:-true}`"
export CustomServer__GameServerPrewarmTimeoutSeconds=`"`${GAME_PREWARM_TIMEOUT:-180}`"
export CustomServer__GameServerPrewarmMatchWaitSeconds=`"`${GAME_PREWARM_MATCH_WAIT:-35}`"
export CustomServer__GameServerPrewarmPortOffset=`"`${GAME_PREWARM_PORT_OFFSET:-150}`"
export CustomServer__GameServerPrewarmSettleSeconds=`"`${GAME_PREWARM_SETTLE:-3}`"
export CustomServer__AdditionalGameArguments=`"`${ADDITIONAL_GAME_ARGS:---melonloader.agfoffline --bapcustom-use-proxy=false --bapcustom-show-ui=false}`"
GRAPHICS_MODE=`"`${BAPCUSTOM_UNITY_GRAPHICS_MODE:-`${BAPCUSTOM_UNITY_GRAPHICS:-none}}`"
export BAPCUSTOM_RELEASE_LABEL=`"`${BAPCUSTOM_RELEASE_LABEL:-$effectiveReleaseLabel}`"
export BAPCUSTOM_GIT_COMMIT=`"`${BAPCUSTOM_GIT_COMMIT:-$gitCommit}`"
export BAPCUSTOM_GIT_BRANCH=`"`${BAPCUSTOM_GIT_BRANCH:-$gitBranch}`"

echo `"[start-linux-wine] release=`${BAPCUSTOM_RELEASE_LABEL} git=`${BAPCUSTOM_GIT_COMMIT} branch=`${BAPCUSTOM_GIT_BRANCH}`"
if [[ -f `"`${ROOT}/deployment-info.json`" ]]; then
  echo `"[start-linux-wine] deploymentInfo=`$(tr -d '\n' < `"`${ROOT}/deployment-info.json`" | cut -c1-700)`"
fi
echo `"[start-linux-wine] winePath=`$(command -v wine || true) wineVersion=`$(wine --version 2>&1 || true)`"
echo `"[start-linux-wine] xvfbRunPath=`$(command -v xvfb-run || true) xauthPath=`$(command -v xauth || true) glxinfoPath=`$(command -v glxinfo || true)`"
echo `"[start-linux-wine] gameLauncherPath=`${CustomServer__GameLauncherPath} gameLauncherArguments=`${CustomServer__GameLauncherArguments} graphicsMode=`${GRAPHICS_MODE}`"

if [[ -n `"`${ADMIN_TOKEN:-}`" ]]; then
  export CustomServer__Admin__ApiToken=`"`${ADMIN_TOKEN}`"
fi

chmod +x `"`${ROOT}/BapCustomServer`" `"`${ROOT}/amp-webpanel-start.sh`" 2>/dev/null || true
exec `"`${ROOT}/amp-webpanel-start.sh`" `"`${ASPNETCORE_URLS}`"
[System.IO.File]::WriteAllText(
    (Join-Path $ServerRoot "start-linux-wine.sh"),
    $startLinuxWine.Replace("`r`n", "`n"),
    [System.Text.UTF8Encoding]::new($false)
)

$webPanelStart = @"
#!/bin/sh
# AMP-managed launcher for BAPBAP Custom Server.
# Listen URL is passed as `$1 from AMP. All other config (match ports, public host)
# is provided via App.EnvironmentVariables in the kvp -> ASP.NET Core picks them up
# through CustomServer__BaseWsPort etc. (double-underscore = nested IConfiguration key).
set -eu

ROOT=`$(CDPATH= cd -- `"`$(dirname -- `"`$0`")`" && pwd)
cd `"`$ROOT`"

LISTEN_URL=`"`${1:-`${ASPNETCORE_URLS:-http://0.0.0.0:$LobbyPort}}`"

export ASPNETCORE_URLS=`"`${ASPNETCORE_URLS:-`$LISTEN_URL}`"
export CustomServer__PublicBaseUrl=`"`${CustomServer__PublicBaseUrl:-http://${PublicHost}:$LobbyPort}`"
export CustomServer__PublicGameHost=`"`${CustomServer__PublicGameHost:-$PublicHost}`"
export CustomServer__GameExecutablePath=`"`${CustomServer__GameExecutablePath:-./game/bapbap.exe}`"
export CustomServer__GameWorkingDirectory=`"`${CustomServer__GameWorkingDirectory:-./game}`"
export CustomServer__GameLauncherPath=`"`${GAME_LAUNCHER_PATH:-./start-match.sh}`"
if [ -n `"`${GAME_LAUNCHER_ARGUMENTS:-}`" ]; then
  export CustomServer__GameLauncherArguments=`"`${GAME_LAUNCHER_ARGUMENTS}`"
else
  export CustomServer__GameLauncherArguments=`"\`"{gameExecutable}\`" {gameArguments}`"
fi
export CustomServer__GameServerReadyTimeoutSeconds=`"`${GAME_READY_TIMEOUT:-300}`"
export CustomServer__RequireGameServerKcpPort=`"`${REQUIRE_GAME_KCP_PORT:-true}`"
export CustomServer__GameServerManagedBootstrapStatusTimeoutSeconds=`"`${GAME_MANAGED_BOOTSTRAP_TIMEOUT:-180}`"
export CustomServer__GameServerManagedBootstrapListenerOnlyTimeoutSeconds=`"`${GAME_MANAGED_BOOTSTRAP_LISTENER_ONLY_TIMEOUT:-0}`"
export CustomServer__EmptyLobbyMatchCleanupGraceSeconds=`"`${EMPTY_LOBBY_MATCH_CLEANUP_GRACE:-15}`"
export CustomServer__EmptyLobbyMatchConnectedCleanupGraceSeconds=`"`${EMPTY_LOBBY_MATCH_CONNECTED_CLEANUP_GRACE:-45}`"
export CustomServer__GameServerTcpPortReadyTimeoutSeconds=`"`${GAME_TCP_READY_TIMEOUT:-30}`"
export CustomServer__GameServerKcpPortReadyTimeoutSeconds=`"`${GAME_KCP_READY_TIMEOUT:-45}`"
export CustomServer__GameServerStartAttempts=`"`${GAME_START_ATTEMPTS:-2}`"
export CustomServer__GameServerStartRetryDelaySeconds=`"`${GAME_START_RETRY_DELAY:-2}`"
export CustomServer__GameServerStopWaitMillis=`"`${GAME_STOP_WAIT_MS:-5000}`"
export CustomServer__GameServerPostCleanupStartDelayMillis=`"`${GAME_POST_CLEANUP_START_DELAY_MS:-3000}`"
export CustomServer__GameServerStartupStallGraceSeconds=`"`${GAME_STARTUP_STALL_GRACE:-45}`"
export CustomServer__GameServerStartupStallSeconds=`"`${GAME_STARTUP_STALL:-25}`"
export CustomServer__GameServerWrapperOnlyStartupStallGraceSeconds=`"`${GAME_WRAPPER_ONLY_STALL_GRACE:-8}`"
export CustomServer__GameServerWrapperOnlyStartupStallSeconds=`"`${GAME_WRAPPER_ONLY_STALL:-5}`"
export CustomServer__GameServerPrewarmOnStartup=`"`${GAME_PREWARM_ON_STARTUP:-true}`"
export CustomServer__GameServerPrewarmTimeoutSeconds=`"`${GAME_PREWARM_TIMEOUT:-180}`"
export CustomServer__GameServerPrewarmMatchWaitSeconds=`"`${GAME_PREWARM_MATCH_WAIT:-35}`"
export CustomServer__GameServerPrewarmPortOffset=`"`${GAME_PREWARM_PORT_OFFSET:-150}`"
export CustomServer__GameServerPrewarmSettleSeconds=`"`${GAME_PREWARM_SETTLE:-3}`"
export CustomServer__MatchmakingQueue__FailedStartRetryDelaySeconds=`"`${FAILED_START_RETRY_DELAY:-5}`"
export CustomServer__AdditionalGameArguments=`"`${ADDITIONAL_GAME_ARGS:---melonloader.agfoffline --bapcustom-use-proxy=false --bapcustom-show-ui=false}`"

chmod +x ./BapCustomServer ./createdump ./start-linux-wine.sh ./start-match.sh 2>/dev/null || true

DEPLOYED_RELEASE=`$(sed -n 's/.*"releaseLabel"[[:space:]]*:[[:space:]]*"\([^"]*\)".*/\1/p' ./deployment-info.json 2>/dev/null | head -n 1 || true)
[ -n "`$DEPLOYED_RELEASE" ] || DEPLOYED_RELEASE="$effectiveReleaseLabel"
export BAPCUSTOM_RELEASE_LABEL="`${BAPCUSTOM_RELEASE_LABEL:-`$DEPLOYED_RELEASE}"

echo "[amp-start] release=`${BAPCUSTOM_RELEASE_LABEL} git=`${BAPCUSTOM_GIT_COMMIT:-$gitCommit} branch=`${BAPCUSTOM_GIT_BRANCH:-$gitBranch}"
if [ -f ./deployment-info.json ]; then
  echo "[amp-start] deploymentInfo=`$(tr -d '\n' < ./deployment-info.json | cut -c1-700)"
fi
echo "[amp-start] uname=`$(uname -a 2>/dev/null || true)"
echo "[amp-start] winePath=`$(command -v wine || true)"
echo "[amp-start] wineVersion=`$(wine --version 2>&1 || true)"
echo "[amp-start] winebootPath=`$(command -v wineboot || true)"
echo "[amp-start] xvfbRunPath=`$(command -v xvfb-run || true)"
echo "[amp-start] xauthPath=`$(command -v xauth || true)"
echo "[amp-start] glxinfoPath=`$(command -v glxinfo || true)"
echo "[amp-start] vulkanInfoPath=`$(command -v vulkaninfo || true)"

if [ "`${BAPCUSTOM_PREWARM_WINE:-1}" != "0" ]; then
  echo "[amp-start] prewarm begin"
  ./start-match.sh --prewarm ./game/bapbap.exe -batchmode -nographics
  echo "[amp-start] prewarm complete"
else
  echo "[amp-start] prewarm skipped by BAPCUSTOM_PREWARM_WINE=0"
fi

if [ "`${BAPCUSTOM_PREWARM_UNITY:-1}" != "0" ]; then
  PREWARM_KEY=`$(grep -E '"(releaseLabel|modDllSha256|medusaDllSha256|medusaBundleSha256)"' ./deployment-info.json 2>/dev/null | tr -d ' ",:' | tr -d '\r' | tr '\n' '_' | tr -cd '[:alnum:]_.-' | cut -c1-180 || true)
  [ -n "`$PREWARM_KEY" ] || PREWARM_KEY="unknown"
  PREWARM_MARKER="./wineprefix32/.bapcustom-unity-prewarm-`$PREWARM_KEY.ok"
  if [ -f "`$PREWARM_MARKER" ]; then
    echo "[amp-start] unity prewarm skipped marker=`$PREWARM_MARKER"
  else
    mkdir -p ./logs/game-servers ./wineprefix32
    PREWARM_TIMEOUT="`${BAPCUSTOM_PREWARM_UNITY_TIMEOUT:-240}"
    PREWARM_HTTP="`${CustomServer__BaseHttpPort:-$BaseHttpPort}"
    PREWARM_WS="`${CustomServer__BaseWsPort:-$BaseWsPort}"
    PREWARM_KCP="`${CustomServer__BaseKcpPort:-$BaseKcpPort}"
    PREWARM_TCP="`${CustomServer__BaseTcpPort:-$BaseTcpPort}"
    PREWARM_LOG="./logs/game-servers/prewarm-unity-`$(date -u +%Y%m%dT%H%M%SZ).log"
    PREWARM_SENTINEL="./logs/game-servers/.prewarm-sentinel-`$(date -u +%Y%m%dT%H%M%SZ)-`$$"
    : > "`$PREWARM_SENTINEL" 2>/dev/null || true
    echo "[amp-start] unity prewarm begin timeout=`${PREWARM_TIMEOUT}s http=`$PREWARM_HTTP ws=`$PREWARM_WS kcp=`$PREWARM_KCP tcp=`$PREWARM_TCP log=`$PREWARM_LOG"
    set +e
    if command -v timeout >/dev/null 2>&1; then
      timeout -k 15s "`${PREWARM_TIMEOUT}s" ./start-match.sh ./game/bapbap.exe -batchmode -logFile "`$PREWARM_LOG" -httpport="`$PREWARM_HTTP" -wsport="`$PREWARM_WS" -kcpport="`$PREWARM_KCP" -tcpport="`$PREWARM_TCP" --melonloader.agfoffline --bapcustom-use-proxy=false --bapcustom-show-ui=false --bapcustom-host=127.0.0.1 --bapcustom-server-port="$LobbyPort" &
    else
      ./start-match.sh ./game/bapbap.exe -batchmode -logFile "`$PREWARM_LOG" -httpport="`$PREWARM_HTTP" -wsport="`$PREWARM_WS" -kcpport="`$PREWARM_KCP" -tcpport="`$PREWARM_TCP" --melonloader.agfoffline --bapcustom-use-proxy=false --bapcustom-show-ui=false --bapcustom-host=127.0.0.1 --bapcustom-server-port="$LobbyPort" &
    fi
    PREWARM_PID=`$!
    PREWARM_READY=0
    PREWARM_READY_SOURCE="none"
    PREWARM_ELAPSED=0
    PREWARM_STARTED=`$(date +%s)
    while kill -0 "`$PREWARM_PID" 2>/dev/null; do
      PREWARM_ELAPSED=`$((`$(date +%s) - PREWARM_STARTED))
      [ "`$PREWARM_ELAPSED" -lt "`$PREWARM_TIMEOUT" ] || break
      if command -v curl >/dev/null 2>&1 && curl -sS -o /dev/null --connect-timeout 1 --max-time 2 "http://127.0.0.1:`$PREWARM_HTTP/status" 2>/dev/null; then
        PREWARM_READY=1
        PREWARM_READY_SOURCE="http-listener"
        break
      fi
      MELON_LOG="./game/MelonLoader/Latest.log"
      if [ -f "`$MELON_LOG" ] && [ "`$MELON_LOG" -nt "`$PREWARM_SENTINEL" ] && grep -E "\[SceneLoaded\] Scene 'MainScene'|Requested dedicated server start through GameNetworkManager|Dedicated network start is pending|post-StartServer" "`$MELON_LOG" >/dev/null 2>&1; then
        PREWARM_READY=1
        PREWARM_READY_SOURCE="dedicated-main-loop-log"
        break
      fi
      sleep 1
    done
    if [ "`$PREWARM_READY" = "1" ]; then
      PREWARM_SETTLE="`${BAPCUSTOM_PREWARM_UNITY_SETTLE_SECONDS:-3}"
      echo "[amp-start] unity prewarm ready source=`$PREWARM_READY_SOURCE elapsed=`${PREWARM_ELAPSED}s settle=`${PREWARM_SETTLE}s"
      sleep "`$PREWARM_SETTLE"
    fi
    kill "`$PREWARM_PID" 2>/dev/null || true
    wait "`$PREWARM_PID" 2>/dev/null
    PREWARM_RC=`$?
    set -e
    UNITY_SIZE=0
    [ -f "`$PREWARM_LOG" ] && UNITY_SIZE=`$(wc -c < "`$PREWARM_LOG" 2>/dev/null | tr -d ' ' || echo 0)
    MELON_LOG="./game/MelonLoader/Latest.log"
    MELON_SIZE=0
    [ -f "`$MELON_LOG" ] && MELON_SIZE=`$(wc -c < "`$MELON_LOG" 2>/dev/null | tr -d ' ' || echo 0)
    echo "[amp-start] unity prewarm finished rc=`$PREWARM_RC ready=`$PREWARM_READY source=`$PREWARM_READY_SOURCE elapsed=`${PREWARM_ELAPSED}s unityLogBytes=`$UNITY_SIZE melonLogBytes=`$MELON_SIZE"
    if [ -f "`$MELON_LOG" ]; then
      tail -n 14 "`$MELON_LOG" 2>/dev/null | sed 's/^/[amp-start] melon-tail /' || true
    fi
    if [ "`$PREWARM_READY" = "1" ]; then
      touch "`$PREWARM_MARKER" 2>/dev/null || true
      echo "[amp-start] unity prewarm marker written `$PREWARM_MARKER"
    else
      echo "[amp-start] WARNING: unity prewarm did not reach dedicated main-loop readiness; no readiness marker written"
    fi
    rm -f "`$PREWARM_SENTINEL" 2>/dev/null || true
  fi
else
  echo "[amp-start] unity prewarm skipped by BAPCUSTOM_PREWARM_UNITY=0"
fi

exec ./BapCustomServer --urls `"`$LISTEN_URL`"
"@
[System.IO.File]::WriteAllText(
    (Join-Path $ServerRoot "amp-webpanel-start.sh"),
    $webPanelStart.Replace("`r`n", "`n"),
    [System.Text.UTF8Encoding]::new($false)
)

$deploymentInfo = [ordered]@{
    schemaVersion = 1
    releaseLabel = $effectiveReleaseLabel
    packageBuildUtc = (Get-Date).ToUniversalTime().ToString("o")
    gitCommit = $gitCommit
    gitBranch = $gitBranch
    gitDirty = -not [string]::IsNullOrWhiteSpace($gitStatus)
    configuration = $Configuration
    selfContained = $selfContained
    publicHost = $PublicHost
    serverDllSha256 = Get-FileSha256 (Join-Path $ServerRoot "BapCustomServer.dll")
    modDllSha256 = Get-FileSha256 $ModDll
    modApiDllSha256 = Get-FileSha256 (Join-Path $GameRoot "Mods\BAPBAP.ModAPI.dll")
    medusaDllSha256 = Get-FileSha256 (Join-Path $GameRoot "Mods\BAPBAP.Medusa.dll")
    medusaBundleSha256 = Get-FileSha256 (Join-Path $GameRoot "UserData\Medusa\medusa.bundle")
    medusaCharId = 15
    gameExeSha256 = Get-FileSha256 (Join-Path $GameRoot "bapbap.exe")
    startMatchSha256 = Get-FileSha256 $startMatchDest
    packageSha256 = ""
    ports = [ordered]@{
        lobby = $LobbyPort
        ws = $BaseWsPort
        kcp = $BaseKcpPort
        tcp = $BaseTcpPort
        http = $BaseHttpPort
    }
}
$deploymentInfoPath = Join-Path $ServerRoot "deployment-info.json"
[System.IO.File]::WriteAllText($deploymentInfoPath, ($deploymentInfo | ConvertTo-Json -Depth 8), [System.Text.UTF8Encoding]::new($false))
Write-Host "Wrote deployment metadata: $deploymentInfoPath ($effectiveReleaseLabel / $gitCommit)" -ForegroundColor Green

$readme = @'
# BAPBAP Custom Server - AMP Full Linux/Wine Package

This package contains the complete `BapCustomServer/` folder for an AMP Generic instance:

- Linux ASP.NET CustomMatchServer.
- Windows Unity game build under `game/`.
- MelonLoader files.
- `Mods/BapCustomServerMelon.dll`.
- `Mods/BapCustomServer.ini`.
- Medusa ModAPI files: `Mods/BAPBAP.ModAPI.dll`, `UserLibs/BAPBAP.ModAPI.dll`, `Mods/BAPBAP.Medusa.dll`, `UserData/Medusa/medusa.bundle`.

Upload/extract this package into the AMP instance root so the final path is:

`<instance>/BapCustomServer/BapCustomServer`
`<instance>/BapCustomServer/game/bapbap.exe`

Web-panel-only deployment order:

1. Import the Linux web-panel AMP template package `deployment\amp-linux-webpanel\bapcustomserver-linux-webpanel-template.zip`.
2. Create a new instance from the `BAPBAP Custom Server Linux Web Panel` template.
3. Upload this full package in the instance File Manager.
4. Extract it into the instance root so the `BapCustomServer/` folder is visible at `/BapCustomServer`.
5. Press `Start`.

The Linux web-panel template starts the system `/bin/sh` executable and passes it
`BapCustomServer/amp-webpanel-start.sh`. That script does not need its own
executable flag because `/bin/sh` reads it as text, then the script marks
`BapCustomServer` executable and starts the server. Do not use an older
instance/template that starts `BapCustomServer` directly, because web-panel ZIP
extraction can lose the Linux executable flag.

Required Linux packages on the AMP host:

```bash
sudo dpkg --add-architecture i386
sudo apt update
sudo apt install -y wine wine32 wine64 xvfb xauth libgl1 libgl1:i386 libgl1-mesa-dri libgl1-mesa-dri:i386 libglx-mesa0 libglx-mesa0:i386 libvulkan1 libvulkan1:i386 mesa-vulkan-drivers mesa-vulkan-drivers:i386 mesa-utils x11-utils
```

If you only have web-panel access, your AMP host/container image must already
provide Wine and Xvfb, or the host provider/admin must add them. File upload alone
cannot install host OS packages.

The matching AMP template starts `/bin/sh` on Linux and runs
`amp-webpanel-start.sh`. This is required for web-panel-only deployments where
SSH/terminal `chmod` is not available.

Recommended AMP settings:

- Public Base URL: `http://YOUR_PUBLIC_IP_OR_DOMAIN:5055`
- Public Game Host: `YOUR_PUBLIC_IP_OR_DOMAIN`
- Game Executable Path: `./game/bapbap.exe`
- Game Working Directory: `./game`
- Game Launcher Path: `./start-match.sh`
- Game Launcher Arguments: `"{gameExecutable}" {gameArguments}`
- Additional Game Arguments: `--melonloader.agfoffline --bapcustom-use-proxy=false --bapcustom-show-ui=false`
- Game Ready Timeout: `300`
- Launch Match Processes: `true`
- Require Bootstrap: `true`

The `start-match.sh` wrapper is required. It logs the active release, Wine/Xvfb
paths, Mesa state, graphics strategy, and per-match Unity/Melon logs. Do not set
the launcher directly to `xvfb-run` or `wine` unless you intentionally bypass the
diagnostic wrapper.

Open firewall/NAT:

- `5055/tcp` for lobby/API/WebSocket.
- `7777/tcp` for match WebSocket.
- `7778/udp` for match KCP.
- `7779/tcp` for match TCP fallback.

Players only need `BapCustomServerMelon.dll` and `BapCustomServer.ini` in their local game `Mods` folder. In their ini:

```ini
[Server]
Host=YOUR_PUBLIC_IP_OR_DOMAIN
Port=5055
UseHttps=false
UseLocalProxy=true
LocalProxyPort=5055
```
[System.IO.File]::WriteAllText(
    (Join-Path $PackageRoot "README-FULL-LINUX-WINE.md"),
    $readme,
    [System.Text.UTF8Encoding]::new($false)
)

# === Strip user-state directories from staging before zipping ===
# These hold per-instance state that an AMP "Update" must never overwrite:
#   data/                  player accounts, economy, ranked, admin, friends
#   logs/                  audit logs, match history
# The server creates the missing dirs on first run via Directory.CreateDirectory,
# so leaving them out of the zip is safe and prevents update-side data loss.
# Dedicated game config under game/Mods and game/UserData is intentionally
# refreshed so the headless Wine runtime keeps known-good mod defaults.
$stagedStateDataDir = Join-Path $ServerRoot "data"
$stagedStateLogsDir = Join-Path $ServerRoot "logs"
foreach ($p in @($stagedStateDataDir, $stagedStateLogsDir)) {
    if (Test-Path -LiteralPath $p) {
        Remove-Item -LiteralPath $p -Recurse -Force
        Write-Host "Stripped from update bundle: $p (preserves user state across AMP Update)" -ForegroundColor Yellow
    }
}

Remove-Item -LiteralPath $ZipPath -Force -ErrorAction SilentlyContinue

# Manually build the zip with forward-slash entry names.
# .NET Framework 4.x's ZipFile.CreateFromDirectory uses OS path separator
# (backslash on Windows), which Linux unzip rejects. We iterate files
# ourselves and call CreateEntry with explicit forward-slash paths.
Add-Type -AssemblyName System.IO.Compression -ErrorAction SilentlyContinue
Add-Type -AssemblyName System.IO.Compression.FileSystem -ErrorAction SilentlyContinue

$zipStream = [System.IO.File]::Open($ZipPath, [System.IO.FileMode]::CreateNew)
try {
    $archive = New-Object System.IO.Compression.ZipArchive($zipStream, [System.IO.Compression.ZipArchiveMode]::Create)
    try {
        $rootFull = [System.IO.Path]::GetFullPath($PackageRoot).TrimEnd([System.IO.Path]::DirectorySeparatorChar)
        Get-ChildItem -LiteralPath $PackageRoot -Recurse -File | ForEach-Object {
            $full = [System.IO.Path]::GetFullPath($_.FullName)
            if (-not $full.StartsWith($rootFull, [System.StringComparison]::OrdinalIgnoreCase)) { return }
            $rel = $full.Substring($rootFull.Length).TrimStart([System.IO.Path]::DirectorySeparatorChar, [System.IO.Path]::AltDirectorySeparatorChar)
            $entryName = ($rel -replace '\\','/') -replace '^BapCustomServer/',''
            if (-not $entryName) { return }  # skip empty (e.g. the BapCustomServer/ dir entry itself)
            $entry = $archive.CreateEntry($entryName, [System.IO.Compression.CompressionLevel]::Optimal)
            $entryStream = $entry.Open()
            try {
                $fileStream = [System.IO.File]::OpenRead($full)
                try { $fileStream.CopyTo($entryStream) } finally { $fileStream.Dispose() }
            } finally { $entryStream.Dispose() }
        }
    } finally { $archive.Dispose() }
} finally { $zipStream.Dispose() }
Write-Host "Created Linux-friendly zip with forward-slash paths: $ZipPath" -ForegroundColor Green

# Verify the mod DLL inside the freshly produced zip matches the live-tested
# dist artifact. If anything has touched/recompiled it without updating this
# pin after a live AMP match, fail fast instead of shipping an unverified mod.
$ExpectedModDllSha256 = 'B56C06574235ACCFCBBC0AD71340168DA82C67B763A0B320445FB4D0E705C73E'
$ExpectedMedusaDllSha256 = '88CE3999CC51E0EE25735306337336284295BCF0F7DE573C3138C87F7EADE776'
$ModDllZipEntryName = 'game/Mods/BapCustomServerMelon.dll'
$MedusaDllZipEntryName = 'game/Mods/BAPBAP.Medusa.dll'

Add-Type -AssemblyName System.IO.Compression
Add-Type -AssemblyName System.IO.Compression.FileSystem

$verifyArchive = [System.IO.Compression.ZipFile]::OpenRead($ZipPath)
try {
    $stateEntries = $verifyArchive.Entries | Where-Object {
        $name = $_.FullName.Replace('\','/').TrimStart('/')
        $name -match '^(data|logs)/' -or
        $name -match '(^|/)(admin-state|economy-state|friends-state|ranked-state|shop-state)\.json$' -or
        $name -match '(^|/)match-history\.jsonl$' -or
        $name -match '(^|/)admin-audit\.jsonl$' -or
        $name -match '^(data/players)(/|$)'
    }
    if ($stateEntries.Count -gt 0) {
        $bad = ($stateEntries | Select-Object -First 20 | ForEach-Object { $_.FullName }) -join ', '
        throw "Refusing to ship AMP update zip with preserved user-state entries: $bad"
    }

    $modEntry = $verifyArchive.Entries | Where-Object { $_.FullName.Replace('\','/') -eq $ModDllZipEntryName } | Select-Object -First 1
    if ($null -eq $modEntry) {
        throw "Mod DLL entry '$ModDllZipEntryName' not found in '$ZipPath'."
    }
    $medusaEntry = $verifyArchive.Entries | Where-Object { $_.FullName.Replace('\','/') -eq $MedusaDllZipEntryName } | Select-Object -First 1
    if ($null -eq $medusaEntry) {
        throw "Medusa DLL entry '$MedusaDllZipEntryName' not found in '$ZipPath'."
    }

    foreach ($requiredEntry in @(
        'game/Mods/BAPBAP.ModAPI.dll',
        'game/UserLibs/BAPBAP.ModAPI.dll',
        'game/Mods/BAPBAP.Medusa.dll',
        'game/UserData/Medusa/medusa.bundle'
    )) {
        $found = $verifyArchive.Entries | Where-Object {
            $_.FullName.Replace('\','/') -eq $requiredEntry
        } | Select-Object -First 1
        if ($null -eq $found) {
            throw "Medusa artifact entry '$requiredEntry' not found in '$ZipPath'."
        }
    }

    $entryStream = $modEntry.Open()
    try {
        $memStream = New-Object System.IO.MemoryStream
        try {
            $entryStream.CopyTo($memStream)
            $memStream.Position = 0
            $sha = [System.Security.Cryptography.SHA256]::Create()
            try {
                $hashBytes = $sha.ComputeHash($memStream)
                $actualHash = ([System.BitConverter]::ToString($hashBytes)).Replace('-', '').ToUpperInvariant()
            }
            finally {
                $sha.Dispose()
            }
        }
        finally {
            $memStream.Dispose()
        }
    }
    finally {
        $entryStream.Dispose()
    }

    $entryStream = $medusaEntry.Open()
    try {
        $memStream = New-Object System.IO.MemoryStream
        try {
            $entryStream.CopyTo($memStream)
            $memStream.Position = 0
            $sha = [System.Security.Cryptography.SHA256]::Create()
            try {
                $hashBytes = $sha.ComputeHash($memStream)
                $actualMedusaHash = ([System.BitConverter]::ToString($hashBytes)).Replace('-', '').ToUpperInvariant()
            }
            finally {
                $sha.Dispose()
            }
        }
        finally {
            $memStream.Dispose()
        }
    }
    finally {
        $entryStream.Dispose()
    }
}
finally {
    $verifyArchive.Dispose()
}

if ($actualHash -ne $ExpectedModDllSha256) {
    throw "BapCustomServerMelon.dll inside '$ZipPath' has SHA256 '$actualHash' but expected '$ExpectedModDllSha256'. Refusing to ship a mismatched mod. Update the pin only after a live AMP match proves the new binary."
}
if ($actualMedusaHash -ne $ExpectedMedusaDllSha256) {
    throw "BAPBAP.Medusa.dll inside '$ZipPath' has SHA256 '$actualMedusaHash' but expected '$ExpectedMedusaDllSha256'. Refusing to ship a mismatched Medusa DLL."
}
Write-Host "Verified mod DLL SHA256 inside AMP zip matches dist: $actualHash" -ForegroundColor Green
Write-Host "Verified Medusa DLL SHA256 inside AMP zip matches source-built selection/spawn fix: $actualMedusaHash" -ForegroundColor Green
Write-Host "Verified Medusa artifacts inside AMP zip." -ForegroundColor Green

Set-ZipUnixExecutableAttribute -ZipFile $ZipPath -EntryNames @(
    "BapCustomServer",
    "amp-webpanel-start.sh",
    "start-linux-wine.sh",
    "start-match.sh",
    "createdump"
)

[pscustomobject]@{
    selfContained = $selfContained
    zip = $ZipPath
    packageRoot = $PackageRoot
    serverRoot = $ServerRoot
    gameRoot = $GameRoot
    sizeGB = [math]::Round((Get-Item -LiteralPath $ZipPath).Length / 1GB, 2)
} | ConvertTo-Json -Compress

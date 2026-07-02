param(
    [string]$PublicHost = "ark.atomi23.de",
    [int]$LobbyPort = 5055,
    [int]$LocalProxyPort = 5055,
    [string]$BundleName = "BAPBAP-CustomServer-Client"
)

$ErrorActionPreference = "Stop"

# Pinned dist-mod hash. Keep BapCustomServerMelon\dist\BapCustomServerMelon.dll
# as the canonical tested artifact and refuse to ship anything that does not match.
$ExpectedModSha256 = "A32BF4340BA5E285699BE0B4A0DF9436D5C7B7171FC050E4D24A7F735FC83B86"

$Root = Resolve-Path (Join-Path $PSScriptRoot "..")
$GameSource = Join-Path $Root "Spiel\Battleroyalebuild"
$ModDll = Join-Path $Root "BapCustomServerMelon\dist\BapCustomServerMelon.dll"
$OutRoot = Join-Path $Root "deployment\client-bundle"
$StagingRoot = Join-Path $OutRoot "staging"
$ZipPath = Join-Path $OutRoot "$BundleName.zip"
$DownloadsRoot = Split-Path -Parent ([string]$Root)
$ModdingRoot = Join-Path $DownloadsRoot "BAPBAPModdingAPI"
$MedusaModRoot = Join-Path $ModdingRoot "medusa-mod"
$ModApiRoot = Join-Path $ModdingRoot "BAPBAPModAPI"
$MedusaDll = Join-Path $MedusaModRoot "bin\Release\BAPBAP.Medusa.dll"
$MedusaBundle = Join-Path $MedusaModRoot "medusa.bundle"
$ModApiDllCandidates = @(
    (Join-Path $ModApiRoot "modapi\bin\Release\BAPBAP.ModAPI.dll"),
    (Join-Path $ModApiRoot "dist\UserLibs\BAPBAP.ModAPI.dll")
)

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
            throw "Missing Medusa client artifact '$path'. Build/copy BAPBAP.ModAPI + BAPBAP.Medusa from '$ModdingRoot' before packaging."
        }
    }

    Write-Host "Medusa client artifacts installed:" -ForegroundColor Green
    Write-Host "  Mods/BAPBAP.ModAPI.dll SHA256=$(Get-FileSha256 (Join-Path $targetMods 'BAPBAP.ModAPI.dll'))" -ForegroundColor DarkGreen
    Write-Host "  Mods/BAPBAP.Medusa.dll SHA256=$(Get-FileSha256 (Join-Path $targetMods 'BAPBAP.Medusa.dll'))" -ForegroundColor DarkGreen
    Write-Host "  UserData/Medusa/medusa.bundle SHA256=$(Get-FileSha256 (Join-Path $targetMedusaUserData 'medusa.bundle'))" -ForegroundColor DarkGreen
}

if (-not (Test-Path -LiteralPath $GameSource)) {
    throw "Game source folder not found: $GameSource"
}
if (-not (Test-Path -LiteralPath $ModDll)) {
    throw "Mod DLL not found: $ModDll"
}

# Fail fast if the on-disk dist DLL is not the pinned working build.
$sourceModHash = (Get-FileHash -LiteralPath $ModDll -Algorithm SHA256).Hash
if ($sourceModHash.ToUpperInvariant() -ne $ExpectedModSha256.ToUpperInvariant()) {
    throw "Source mod DLL hash mismatch at $ModDll. Expected $ExpectedModSha256 got $sourceModHash. Refusing to build a broken bundle."
}

if (Test-Path -LiteralPath $StagingRoot) {
    try {
        Remove-Item -LiteralPath $StagingRoot -Recurse -Force
    } catch {
        $StagingRoot = Join-Path $OutRoot ("staging-" + (Get-Date -Format "yyyyMMddHHmmss"))
        Write-Warning "Could not remove old staging; using $StagingRoot"
    }
}

New-Item -ItemType Directory -Force -Path $StagingRoot | Out-Null

Write-Host "Copying game files (flattened to bundle root) ..." -ForegroundColor Cyan
Get-ChildItem -LiteralPath $GameSource -Force | ForEach-Object {
    Copy-Item -LiteralPath $_.FullName -Destination $StagingRoot -Recurse -Force
}

# Strip developer/debug files
$stripPatterns = @(
    "MelonLoader\Logs",
    "MelonLoader\Latest.log",
    "customserver-melon-debug-support-afterpatch.log",
    "customserver-melon-debug-support.log",
    "customserver-melon-patched-interop.log",
    "customserver-melon-patched-no-force.log",
    "customserver-melon-smoke-flags.log",
    "customserver-melon-smoke.log",
    "BAPBAP_BurstDebugInformation_DoNotShip",
    "bapbap_Data\resources.assets.bak",
    "Mods\BapCustomServerMelon.dll.4FC3B8DA.bak"
)
foreach ($pattern in $stripPatterns) {
    $target = Join-Path $StagingRoot $pattern
    if (Test-Path -LiteralPath $target) {
        Remove-Item -LiteralPath $target -Recurse -Force -ErrorAction SilentlyContinue
        Write-Host "  stripped: $pattern" -ForegroundColor DarkGray
    }
}

# Force-write a clean MelonPreferences.cfg for end-user clients. Empty AccountId/Username
# triggers Setup-And-Launch.ps1's prompt OR the in-game first-launch overlay. Local proxy
# stays ON for client connections to the lobby's local proxy port.
$userDataDir = Join-Path $StagingRoot "UserData"
New-Item -ItemType Directory -Force -Path $userDataDir | Out-Null
$cleanMelonPrefs = @"
[BapCustomServer]
Host = "$PublicHost"
ServerPort = $LobbyPort
UseHttps = false
UseLocalProxy = true
LocalProxyPort = $LocalProxyPort
ShowStatusChip = true
UseNativeGameUi = true
AccountId = ""
Username = ""
AutoGuestLogin = true
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

# Replace mod DLL with the known-working dist version
$gameMods = Join-Path $StagingRoot "Mods"
New-Item -ItemType Directory -Force -Path $gameMods | Out-Null
Copy-Item -LiteralPath $ModDll -Destination (Join-Path $gameMods "BapCustomServerMelon.dll") -Force
$modHash = (Get-FileHash (Join-Path $gameMods "BapCustomServerMelon.dll") -Algorithm SHA256).Hash
Write-Host "Mod DLL installed (SHA256 $modHash)" -ForegroundColor Green

Install-MedusaArtifacts -TargetGameRoot $StagingRoot

$medusaAutoSelectMarker = Join-Path $StagingRoot "UserData\Medusa\auto-select.txt"
if ($env:BAPCUSTOM_PACKAGE_MEDUSA_AUTOSELECT -eq "1") {
    Write-Warning "Packaging Medusa auto-select marker because BAPCUSTOM_PACKAGE_MEDUSA_AUTOSELECT=1."
}
elseif (Test-Path -LiteralPath $medusaAutoSelectMarker) {
    Remove-Item -LiteralPath $medusaAutoSelectMarker -Force
    Write-Host "Ensured Medusa auto-select marker is not shipped in the client bundle." -ForegroundColor Green
}

# Prefilled INI: server pre-configured, identity blank.
# If the user runs Start.cmd, the wrapper prompts for a username and writes it here BEFORE
# launching bapbap.exe so the mod's empty-identity overlay doesn't even need to fire.
$iniTemplate = @"
[Server]
Host=$PublicHost
Port=$LobbyPort
UseHttps=false
UseLocalProxy=true
LocalProxyPort=$LocalProxyPort

[Identity]
AccountId=
Username=
AutoGuestLogin=true
"@
[System.IO.File]::WriteAllText(
    (Join-Path $gameMods "BapCustomServer.ini"),
    $iniTemplate.Replace("`r`n", "`r`n"),
    [System.Text.UTF8Encoding]::new($false)
)

# === Setup-And-Launch.ps1 ===
# Interactive launcher that prompts for the player name on first run, writes it to the
# Mods\BapCustomServer.ini, then starts bapbap.exe. This bypasses the in-game first-login
# overlay (which can fail to render on some systems).
$setupPs1 = @'
$ErrorActionPreference = "Stop"

# Hoist Add-Type to the top of the script. The missing-file MessageBox checks
# below need WinForms loaded BEFORE they fire (cold-start safety).
Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Drawing

$here         = Split-Path -Parent $MyInvocation.MyCommand.Definition
$localIniPath = Join-Path $here "Mods\BapCustomServer.ini"
$exePath      = Join-Path $here "bapbap.exe"

# The mod actually reads %APPDATA%\BAPBAPBATTLEROYALE\BapCustomServer.ini at runtime.
# Mods\BapCustomServer.ini is just a one-time migration seed, so the launcher must
# write to BOTH locations for the prompt-once-and-launch flow to take effect.
$appDataDir = Join-Path $env:APPDATA "BAPBAPBATTLEROYALE"
$appDataIni = Join-Path $appDataDir "BapCustomServer.ini"

if (-not (Test-Path -LiteralPath $localIniPath)) {
    [System.Windows.Forms.MessageBox]::Show(
        "Mods\BapCustomServer.ini not found. Did you extract the ZIP completely?",
        "BAPBAP Custom Server", "OK", "Error"
    ) | Out-Null
    exit 1
}
if (-not (Test-Path -LiteralPath $exePath)) {
    [System.Windows.Forms.MessageBox]::Show(
        "bapbap.exe not found. Did you extract the ZIP completely?",
        "BAPBAP Custom Server", "OK", "Error"
    ) | Out-Null
    exit 1
}

function Show-NameDialog {
    # Real WinForms dialog with explicit OK / Cancel DialogResult so callers can
    # distinguish "user typed nothing" from "user cancelled" (Microsoft.VisualBasic
    # InputBox returns "" in both cases, which is the bug we are fixing).
    $form                 = New-Object System.Windows.Forms.Form
    $form.Text            = "BAPBAP Custom Server - First Launch"
    $form.Size            = New-Object System.Drawing.Size(440, 190)
    $form.StartPosition   = "CenterScreen"
    $form.FormBorderStyle = "FixedDialog"
    $form.MaximizeBox     = $false
    $form.MinimizeBox     = $false
    $form.TopMost         = $true

    $label                = New-Object System.Windows.Forms.Label
    $label.Text           = "Choose your in-game name" + [Environment]::NewLine + "(2-20 characters: letters, digits, or underscore)"
    $label.Location       = New-Object System.Drawing.Point(12, 12)
    $label.Size           = New-Object System.Drawing.Size(410, 40)
    $form.Controls.Add($label)

    $textBox              = New-Object System.Windows.Forms.TextBox
    $textBox.Location     = New-Object System.Drawing.Point(12, 58)
    $textBox.Size         = New-Object System.Drawing.Size(410, 23)
    $textBox.MaxLength    = 20
    $form.Controls.Add($textBox)

    $okButton                  = New-Object System.Windows.Forms.Button
    $okButton.Text             = "OK"
    $okButton.Location         = New-Object System.Drawing.Point(248, 100)
    $okButton.Size             = New-Object System.Drawing.Size(80, 26)
    $okButton.DialogResult     = [System.Windows.Forms.DialogResult]::OK
    $form.Controls.Add($okButton)
    $form.AcceptButton         = $okButton

    $cancelButton              = New-Object System.Windows.Forms.Button
    $cancelButton.Text         = "Cancel"
    $cancelButton.Location     = New-Object System.Drawing.Point(338, 100)
    $cancelButton.Size         = New-Object System.Drawing.Size(80, 26)
    $cancelButton.DialogResult = [System.Windows.Forms.DialogResult]::Cancel
    $form.Controls.Add($cancelButton)
    $form.CancelButton         = $cancelButton

    $result = $form.ShowDialog()
    $value  = $textBox.Text
    $form.Dispose()

    if ($result -ne [System.Windows.Forms.DialogResult]::OK) {
        return $null
    }
    return $value
}

function Get-IniValue {
    param(
        [Parameter(Mandatory)] [AllowEmptyString()] [string]$Content,
        [Parameter(Mandatory)] [string]$Key
    )
    # [^\r\n] keeps the captured value clean of CR even on CRLF files.
    $pattern = '(?im)^[ \t]*' + [regex]::Escape($Key) + '[ \t]*=[ \t]*([^\r\n]*)'
    $m = [regex]::Match($Content, $pattern)
    if ($m.Success) { return $m.Groups[1].Value.Trim() }
    return ""
}

function Set-IniLine {
    param(
        [Parameter(Mandatory)] [AllowEmptyString()] [string]$Content,
        [Parameter(Mandatory)] [string]$Key,
        [Parameter(Mandatory)] [AllowEmptyString()] [string]$Value
    )
    # Match Key= line WITHOUT eating the trailing CR or LF, so CRLF files keep
    # their existing line endings instead of getting mixed-mode after rewrite.
    $pattern = '(?im)^[ \t]*' + [regex]::Escape($Key) + '[ \t]*=[^\r\n]*'
    if ([regex]::IsMatch($Content, $pattern)) {
        return [regex]::Replace($Content, $pattern, ($Key + "=" + $Value))
    }
    # Key not present: append using the file's existing newline style.
    if ($Content -match "`r`n") {
        $newline = "`r`n"
    } elseif ($Content -match "`n") {
        $newline = "`n"
    } else {
        $newline = "`r`n"
    }
    if ($Content.Length -gt 0 -and -not $Content.EndsWith($newline)) {
        $Content = $Content + $newline
    }
    return $Content + $Key + "=" + $Value + $newline
}

# Make sure the AppData target exists; seed from the bundled local ini if absent.
if (-not (Test-Path -LiteralPath $appDataDir)) {
    New-Item -ItemType Directory -Force -Path $appDataDir | Out-Null
}
if (-not (Test-Path -LiteralPath $appDataIni)) {
    Copy-Item -LiteralPath $localIniPath -Destination $appDataIni -Force
}

# AppData ini is the canonical source the mod reads at runtime.
$ini              = [System.IO.File]::ReadAllText($appDataIni)
$existingAccount  = Get-IniValue -Content $ini -Key "AccountId"
$existingUsername = Get-IniValue -Content $ini -Key "Username"

# Prompt the player ONLY if Username is missing. Cancel exits cleanly without
# launching the game (no infinite loop on "" return).
if ([string]::IsNullOrWhiteSpace($existingUsername)) {
    while ($true) {
        $name = Show-NameDialog
        if ($null -eq $name) { exit 0 }
        $name = $name.Trim()
        if ($name -match '^[A-Za-z0-9_]{2,20}$') { break }
        [System.Windows.Forms.MessageBox]::Show(
            "Name must be 2-20 characters, letters/digits/underscore only.",
            "BAPBAP Custom Server", "OK", "Warning"
        ) | Out-Null
    }
    $ini = Set-IniLine -Content $ini -Key "Username" -Value $name
}

# Generate AccountId only when it is empty. Don't regenerate it just because
# Username happened to be empty; that would orphan saved progress.
if ([string]::IsNullOrWhiteSpace($existingAccount)) {
    $rng   = [System.Security.Cryptography.RandomNumberGenerator]::Create()
    $bytes = New-Object byte[] 6
    $rng.GetBytes($bytes)
    $rng.Dispose()
    $accountId = "custom-" + (-join ($bytes | ForEach-Object { $_.ToString("x2") }))
    $ini = Set-IniLine -Content $ini -Key "AccountId" -Value $accountId
}

# Persist to BOTH locations: AppData (runtime) and local Mods\ (migration seed).
$utf8NoBom = [System.Text.UTF8Encoding]::new($false)
[System.IO.File]::WriteAllText($appDataIni,  $ini, $utf8NoBom)
[System.IO.File]::WriteAllText($localIniPath, $ini, $utf8NoBom)

# Launch the game with the bundle dir as CWD so MelonLoader / mod relative paths resolve.
Start-Process -FilePath $exePath -WorkingDirectory $here
'@
[System.IO.File]::WriteAllText(
    (Join-Path $StagingRoot "Setup-And-Launch.ps1"),
    $setupPs1.Replace("`r`n", "`r`n"),
    [System.Text.UTF8Encoding]::new($false)
)

$startCmd = @"
@echo off
powershell -NoProfile -ExecutionPolicy Bypass -File "%~dp0Setup-And-Launch.ps1"
"@
[System.IO.File]::WriteAllText(
    (Join-Path $StagingRoot "Start.cmd"),
    $startCmd.Replace("`r`n", "`r`n"),
    [System.Text.UTF8Encoding]::new($false)
)

# README at bundle root
$readme = @"
BAPBAP Custom Server Edition
============================

Public server: $PublicHost`:$LobbyPort
Mod build: $modHash
Custom character: Medusa (charId 15)

How to play
-----------
1. Extract this ZIP somewhere (e.g. Desktop\BAPBAP).
2. Double-click Start.cmd
3. Type your in-game name (2-20 characters, letters/digits/underscore).
4. The game launches. Press the matchmaking button to play.

You only see the name prompt the first time. Later runs just launch the game.

Notes
-----
- Settings are stored per-user in %APPDATA%\BAPBAPBATTLEROYALE\BapCustomServer.ini.
  Delete that file (or clear just the AccountId / Username lines) to reset and pick
  a new name on the next Start.cmd launch. A copy is also kept next to the game in
  Mods\BapCustomServer.ini for first-time migration / debugging visibility.
- Press F7 in-game to inspect/change server settings without editing files.
- The mod runs a small local proxy on 127.0.0.1:$LocalProxyPort. If a Windows firewall
  popup appears, allow it for both private and public networks.
- Medusa is bundled through BAPBAP.ModAPI. Keep `Mods\BAPBAP.Medusa.dll`,
  `Mods\BAPBAP.ModAPI.dll`, `UserLibs\BAPBAP.ModAPI.dll`, and
  `UserData\Medusa\medusa.bundle` together with the game files.

Advanced (optional): you can launch bapbap.exe directly. The game will show an in-game
"Custom Server Setup" overlay to enter your name. Start.cmd is the recommended path
because the in-game overlay sometimes does not render on top of the splash screen.

Troubleshooting
---------------
- Server unreachable: visit http://$PublicHost`:$LobbyPort/health in a browser; expect {"ok":true}.
- Stuck on loading screen: re-download the latest bundle from the GitHub release.
  Client and server build versions must match.

Built with the BAP Custom Server stack by Sonic0810.
"@
[System.IO.File]::WriteAllText(
    (Join-Path $StagingRoot "README.txt"),
    $readme.Replace("`r`n", "`r`n"),
    [System.Text.UTF8Encoding]::new($false)
)

# Compress
if (Test-Path -LiteralPath $ZipPath) {
    Remove-Item -LiteralPath $ZipPath -Force
}

Write-Host "Compressing to $ZipPath ..." -ForegroundColor Cyan
Compress-Archive -Path (Join-Path $StagingRoot "*") -DestinationPath $ZipPath -CompressionLevel Optimal -Force

# Post-compress verification: open the archive WITHOUT extracting and SHA256 the
# bundled mod DLL entry. Throws if the archive's mod DLL does not match the
# pinned dist build.
Add-Type -AssemblyName System.IO.Compression.FileSystem | Out-Null
$bundledModHash = $null
$zipHandle = [System.IO.Compression.ZipFile]::OpenRead($ZipPath)
try {
    $entry = $zipHandle.Entries |
        Where-Object { $_.FullName -replace '\\', '/' -ieq 'Mods/BapCustomServerMelon.dll' } |
        Select-Object -First 1
    if (-not $entry) {
        throw "Bundled archive $ZipPath does not contain Mods/BapCustomServerMelon.dll"
    }
    $entryStream = $entry.Open()
    try {
        $sha = [System.Security.Cryptography.SHA256]::Create()
        try {
            $hashBytes = $sha.ComputeHash($entryStream)
            $bundledModHash = (-join ($hashBytes | ForEach-Object { $_.ToString("x2") })).ToUpperInvariant()
        } finally {
            $sha.Dispose()
        }
    } finally {
        $entryStream.Dispose()
    }
} finally {
    $zipHandle.Dispose()
}

if ($bundledModHash -ne $ExpectedModSha256.ToUpperInvariant()) {
    throw "Bundled mod DLL hash mismatch inside $ZipPath. Expected $ExpectedModSha256 got $bundledModHash. Bundle is invalid."
}
Write-Host "Verified bundled Mods/BapCustomServerMelon.dll SHA256 = $bundledModHash" -ForegroundColor Green

$requiredMedusaEntries = @(
    'Mods/BAPBAP.ModAPI.dll',
    'UserLibs/BAPBAP.ModAPI.dll',
    'Mods/BAPBAP.Medusa.dll',
    'UserData/Medusa/medusa.bundle'
)
$zipHandle = [System.IO.Compression.ZipFile]::OpenRead($ZipPath)
try {
    foreach ($requiredEntry in $requiredMedusaEntries) {
        $found = $zipHandle.Entries |
            Where-Object { $_.FullName.Replace('\','/') -ieq $requiredEntry } |
            Select-Object -First 1
        if (-not $found) {
            throw "Bundled archive $ZipPath does not contain $requiredEntry"
        }
    }
}
finally {
    $zipHandle.Dispose()
}
Write-Host "Verified bundled Medusa artifacts are present." -ForegroundColor Green

$zipInfo = Get-Item -LiteralPath $ZipPath
[pscustomobject]@{
    bundleName  = $BundleName
    publicHost  = $PublicHost
    lobbyPort   = $LobbyPort
    modSha256   = $modHash
    zipPath     = $ZipPath
    sizeMB      = [math]::Round($zipInfo.Length / 1MB, 1)
} | Format-List

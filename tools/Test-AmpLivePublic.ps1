param(
    [string]$PublicHost = "ark.atomi23.de",
    [int]$LobbyPort = 5055,
    [int[]]$AlternateLobbyPorts = @(5056, 5058),
    [int]$MatchWebSocketPort = 7777,
    [int]$MatchKcpPort = 7778,
    [int]$MatchTcpPort = 7779,
    [int]$BootstrapPort = 7850,
    [string]$ReleaseRepo = "Sonic0810/BAPBAP-CustomServer-AMPTemplates",
    [string]$ReleaseTag = "bapcustomserver-20260530-cleanlogs",
    [string]$ExpectedFullZipSha256 = "5f6c99eeb69092c15d9873fe85de58f2181067135ebdedcdd5571d95f1e515b3",
    [string]$ExpectedAutoInstallZipSha256 = "a062abb7716a25befcd9a9218cc74b29f2c196596e38d0c8657dad7c0f3a6a43",
    [int]$TcpTimeoutMs = 3000,
    [int]$HealthTimeoutSeconds = 6,
    [switch]$AsJson,
    [switch]$FailOnUnreachable
)

$ErrorActionPreference = "Stop"

$results = New-Object System.Collections.Generic.List[object]

function Add-Result {
    param(
        [string]$Check,
        [string]$Status,
        [string]$Detail,
        [object]$Value = $null
    )

    $results.Add([pscustomobject]@{
        check = $Check
        status = $Status
        detail = $Detail
        value = $Value
    }) | Out-Null
}

function Test-TcpPortFast {
    param(
        [string]$HostName,
        [int]$Port,
        [int]$TimeoutMs
    )

    $client = [Net.Sockets.TcpClient]::new()
    try {
        $async = $client.BeginConnect($HostName, $Port, $null, $null)
        if (-not $async.AsyncWaitHandle.WaitOne($TimeoutMs, $false)) {
            return $false
        }

        $client.EndConnect($async)
        return $true
    }
    catch {
        return $false
    }
    finally {
        $client.Close()
    }
}

function Get-GitHubContentText {
    param(
        [string]$Repo,
        [string]$Path,
        [string]$Ref = "main"
    )

    $uri = "https://api.github.com/repos/$Repo/contents/$Path`?ref=$Ref"
    $response = Invoke-RestMethod -Uri $uri -Headers @{ "User-Agent" = "bapcustom-live-verifier" } -TimeoutSec 20
    $content = ($response.content -replace '\s', '')
    [Text.Encoding]::UTF8.GetString([Convert]::FromBase64String($content))
}

try {
    $dns = Resolve-DnsName $PublicHost -ErrorAction Stop |
        Where-Object { $_.IPAddress } |
        Select-Object Type, IPAddress
    Add-Result "dns" "ok" "Resolved $PublicHost" ($dns | ConvertTo-Json -Compress)
}
catch {
    Add-Result "dns" "fail" $_.Exception.Message
}

$healthPorts = @($LobbyPort) + $AlternateLobbyPorts | Select-Object -Unique
foreach ($port in $healthPorts) {
    $url = "http://$PublicHost`:$port/health"
    $watch = [Diagnostics.Stopwatch]::StartNew()
    try {
        $response = Invoke-WebRequest -Uri $url -UseBasicParsing -TimeoutSec $HealthTimeoutSeconds
        $watch.Stop()
        Add-Result "health:$port" "ok" "HTTP $($response.StatusCode) in $($watch.ElapsedMilliseconds)ms" $response.Content
    }
    catch {
        $watch.Stop()
        Add-Result "health:$port" "fail" "No /health response in $($watch.ElapsedMilliseconds)ms: $($_.Exception.Message)"
    }
}

$tcpPorts = @($LobbyPort) + $AlternateLobbyPorts + @($MatchWebSocketPort, $MatchTcpPort, $BootstrapPort) | Select-Object -Unique
foreach ($port in $tcpPorts) {
    $connected = Test-TcpPortFast -HostName $PublicHost -Port $port -TimeoutMs $TcpTimeoutMs
    Add-Result "tcp:$port" ($(if ($connected) { "ok" } else { "fail" })) ($(if ($connected) { "TCP handshake succeeded" } else { "No TCP handshake within ${TcpTimeoutMs}ms" }))
}

Add-Result "udp:$MatchKcpPort" "unverified" "UDP reachability cannot be proven safely from this workstation; verify on AMP host with ss or /proc/net/udp."

try {
    $releaseJson = gh release view $ReleaseTag --repo $ReleaseRepo --json assets,url 2>$null
    if ($LASTEXITCODE -ne 0 -or [string]::IsNullOrWhiteSpace($releaseJson)) {
        throw "gh release view failed"
    }

    $release = $releaseJson | ConvertFrom-Json
    Add-Result "release:url" "ok" "Release exists" $release.url

    $expected = @{
        "bapcustomserver-amp-full-linux-wine.zip" = $ExpectedFullZipSha256.ToLowerInvariant()
        "bapcustomserver-github-autoinstall-template.zip" = $ExpectedAutoInstallZipSha256.ToLowerInvariant()
    }

    foreach ($name in $expected.Keys) {
        $asset = $release.assets | Where-Object { $_.name -eq $name } | Select-Object -First 1
        if ($null -eq $asset) {
            Add-Result "release:$name" "fail" "Asset missing"
            continue
        }

        $digest = [string]$asset.digest
        $actual = $digest -replace '^sha256:', ''
        $ok = $actual.ToLowerInvariant() -eq $expected[$name]
        Add-Result "release:$name" ($(if ($ok) { "ok" } else { "fail" })) "digest=$digest size=$($asset.size) updatedAt=$($asset.updatedAt)"
    }
}
catch {
    Add-Result "release" "fail" $_.Exception.Message
}

try {
    $kvp = Get-GitHubContentText -Repo $ReleaseRepo -Path "bapcustomservergithub.kvp"
    $config = Get-GitHubContentText -Repo $ReleaseRepo -Path "bapcustomservergithubconfig.json"
    $updates = Get-GitHubContentText -Repo $ReleaseRepo -Path "bapcustomservergithubupdates.json"
    $verifyScript = Get-GitHubContentText -Repo $ReleaseRepo -Path "verify-amp-instance.sh"

    $canonicalFields = @(
        "EnableMapBazaarCity",
        "EnableMapLyceum",
        "EnableMapArenaMap2",
        "EnableMapOpenBetaBoccato"
    )
    $legacyFields = @(
        "EnableMapTireclub",
        "EnableMapBazaarcity",
        "EnableMapBonsai",
        "EnableMapSunset"
    )

    $missingCanonical = $canonicalFields | Where-Object { -not $config.Contains($_) }
    $visibleLegacy = $legacyFields | Where-Object { $config.Contains($_) }
    if ($missingCanonical.Count -eq 0 -and $visibleLegacy.Count -eq 0) {
        Add-Result "github-main:map-fields" "ok" "Canonical AMP map fields are present and legacy UI field names are absent."
    }
    else {
        Add-Result "github-main:map-fields" "fail" "missingCanonical=[$($missingCanonical -join ',')] visibleLegacy=[$($visibleLegacy -join ',')]"
    }

    $hasUiSync = $updates -like "*Sync AMP configuration UI manifest*" -and
        $updates -like "*bapcustomservergithubconfig.json*" -and
        $updates -like "*GithubRelease*" -and
        $updates -like "*bapcustomserver-amp-full-linux-wine.zip*"
    Add-Result "github-main:update-manifest" ($(if ($hasUiSync) { "ok" } else { "fail" })) "Update manifest syncs AMP UI files and release package."

    $hasSafePackages = $kvp.Contains('"libgl1-mesa-dri:i386"') -and
        $kvp.Contains('"libglx-mesa0:i386"') -and
        $kvp.Contains('"mesa-vulkan-drivers:i386"') -and
        $kvp.Contains('"xvfb"') -and
        -not $kvp.Contains("winetricks")
    Add-Result "github-main:wine-packages" ($(if ($hasSafePackages) { "ok" } else { "fail" })) "AMP container packages should include Wine, Xvfb, and Mesa software graphics packages; winetricks should stay absent."

    $hasStartMatchDefaults = $config.Contains('"DefaultValue":  "./start-match.sh"') -and
        $config.Contains('"DefaultValue":  "\"{gameExecutable}\" {gameArguments}"')
    Add-Result "github-main:wine-launcher" ($(if ($hasStartMatchDefaults) { "ok" } else { "fail" })) "AMP launcher defaults should use start-match.sh, not raw /usr/bin/env wine."

    $hasGraphicsModeCheck = $verifyScript.Contains("graphicsMode=") -and
        $verifyScript.Contains("BAPCUSTOM_UNITY_GRAPHICS_MODE")
    Add-Result "github-main:graphics-mode-check" ($(if ($hasGraphicsModeCheck) { "ok" } else { "fail" })) "AMP verify helper should check the Wine wrapper logs the selected Unity graphics strategy."

    $hasDiagnosticsCheck = $verifyScript.Contains("deployment-info.json") -and
        $verifyScript.Contains("[amp-start] wineVersion=") -and
        $verifyScript.Contains("glxinfo probe")
    Add-Result "github-main:diagnostics-check" ($(if ($hasDiagnosticsCheck) { "ok" } else { "fail" })) "AMP verify helper should check deployment metadata and Wine/Xvfb diagnostics logging."
}
catch {
    Add-Result "github-main" "fail" $_.Exception.Message
}

if ($AsJson.IsPresent) {
    $results | ConvertTo-Json -Depth 5
}
else {
    $results | Format-Table -AutoSize
}

if ($FailOnUnreachable.IsPresent) {
    $healthOk = $results | Where-Object { $_.check -like 'health:*' -and $_.status -eq 'ok' }
    if (($healthOk | Measure-Object).Count -eq 0) {
        exit 20
    }
}

$failures = $results | Where-Object { $_.status -eq 'fail' -and $_.check -notlike 'health:*' -and $_.check -notlike 'tcp:*' }
if (($failures | Measure-Object).Count -gt 0) {
    exit 1
}

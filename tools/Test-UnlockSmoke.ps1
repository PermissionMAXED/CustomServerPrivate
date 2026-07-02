param(
    [int]$ServerPort = 5156
)

$ErrorActionPreference = "Stop"

$Root = Resolve-Path (Join-Path $PSScriptRoot "..")
$ServerDll = Join-Path $Root "CustomMatchServer\bin\Release\net10.0\BapCustomServer.dll"

if (-not (Test-Path $ServerDll)) {
    throw "Server DLL not built: $ServerDll. Run dotnet build first."
}

$psi = [System.Diagnostics.ProcessStartInfo]::new()
$psi.FileName = "dotnet"
$psi.Arguments = "`"$ServerDll`""
$psi.WorkingDirectory = $Root
$psi.UseShellExecute = $false
$psi.RedirectStandardOutput = $true
$psi.RedirectStandardError = $true
$psi.CreateNoWindow = $true
$psi.EnvironmentVariables["ASPNETCORE_URLS"] = "http://127.0.0.1:$ServerPort"
$psi.EnvironmentVariables["CustomServer__PublicBaseUrl"] = "http://127.0.0.1:$ServerPort"
$psi.EnvironmentVariables["CustomServer__LaunchGameServers"] = "false"

$server = [System.Diagnostics.Process]::Start($psi)
try {
    # wait until /health responds
    $deadline = [DateTime]::UtcNow.AddSeconds(15)
    $base = "http://127.0.0.1:$ServerPort"
    do {
        try {
            $health = Invoke-RestMethod "$base/health" -TimeoutSec 1
            if ($health.ok) { break }
        } catch {}
        Start-Sleep -Milliseconds 200
    } while ([DateTime]::UtcNow -lt $deadline)

    if (-not $health -or -not $health.ok) {
        throw "Server did not become healthy."
    }

    $headers = @{
        "X-BAP-AccountId"     = "custom-smoke-unlock"
        "X-BAP-Username"      = "SmokeUnlock"
        "X-BAP-Discriminator" = "1234"
    }

    $load = Invoke-RestMethod "$base/api/load" -Headers $headers
    $assetsCount = $load.assets.Count
    $skinAssets = ($load.assets | Where-Object { $_.assetId -ge 300000 -and $_.assetId -lt 400000 }).Count
    $bannerAssets = ($load.assets | Where-Object { $_.assetId -ge 500000 -and $_.assetId -lt 600000 }).Count
    $masteryAssets = ($load.assets | Where-Object { $_.assetId -ge 600000 -and $_.assetId -lt 700000 }).Count
    $tombAssets = ($load.assets | Where-Object { $_.assetId -ge 700000 -and $_.assetId -lt 800000 }).Count
    $loadoutSkins = $load.loadout.skins.Count

    $authComplete = Invoke-RestMethod "$base/api/auth/complete" -Headers $headers -Method Post -Body "{}"
    $loadoutBanner = Invoke-RestMethod "$base/api/loadout/banner" -Headers $headers -Method Post -Body '{"assetId":500000}'
    $loadoutSkinsResp = Invoke-RestMethod "$base/api/loadout/skins" -Headers $headers -Method Post -Body '{"charId":1,"assetId":300011}'
    $userLookup = Invoke-RestMethod "$base/api/v1/user-lookup"
    $charsMastery = Invoke-RestMethod "$base/api/chars/mastery/1"

    [pscustomobject]@{
        accountId           = $load.accountId
        totalAssets         = $assetsCount
        skinAssets          = $skinAssets
        bannerAssets        = $bannerAssets
        masteryBadgeAssets  = $masteryAssets
        tombstoneAssets     = $tombAssets
        loadoutSkinSlots    = $loadoutSkins
        authCompleteOk      = ($null -ne $authComplete.accountId)
        loadoutBannerEcho   = ($null -ne $loadoutBanner.accountId)
        loadoutSkinsEcho    = ($null -ne $loadoutSkinsResp.accountId)
        userLookupOk        = ($null -ne $userLookup.users)
        charsMasteryOk      = ($null -ne $charsMastery.passId)
    } | ConvertTo-Json -Compress
}
finally {
    if (-not $server.HasExited) {
        try { $server.Kill() } catch {}
        $server.WaitForExit(2000) | Out-Null
    }
}

param(
    [string]$AssetRipRoot = "C:\Users\Administrator\Downloads\CustomServer\AssetRip\ExportedProject\Assets\MonoBehaviour",
    [string]$OutPath      = "C:\Users\Administrator\Downloads\CustomServer\CustomMatchServer\data\asset-index.json"
)

$ErrorActionPreference = "Stop"

# 1) Build a global GUID -> filename index from all .asset.meta files
Write-Host "Indexing .meta files..." -ForegroundColor Cyan
$metaFiles = Get-ChildItem $AssetRipRoot -Filter '*.asset.meta' -File -ErrorAction SilentlyContinue
$guidToName = @{}
foreach ($mf in $metaFiles) {
    $content = Get-Content $mf.FullName -Raw -ErrorAction SilentlyContinue
    if ($content -match 'guid:\s*([0-9a-fA-F]{32})') {
        $guid = $Matches[1].ToLower()
        $name = $mf.BaseName  # filename minus .meta -> e.g. "PlayerBanner_Anna.asset" -> ".asset" stripped below
        $name = $name -replace '\.asset$',''
        $guidToName[$guid] = $name
    }
}
Write-Host "  Found $($guidToName.Count) GUID->name mappings"

# 2) Helper: parse the GUID list from inside an array section of a *Data.asset file
function Get-GuidArray {
    param([string]$File, [string]$ArrayKey)
    if (-not (Test-Path $File)) { return @() }
    $lines = Get-Content $File
    $result = New-Object System.Collections.Generic.List[string]
    $inArray = $false
    foreach ($line in $lines) {
        if ($line -match "^\s*${ArrayKey}:\s*$") { $inArray = $true; continue }
        if ($inArray) {
            # Stop when we hit a line that doesn't start with whitespace + dash
            if ($line -match '^\s*-\s*\{') {
                # Either a real GUID reference or {fileID: 0} placeholder
                if ($line -match 'guid:\s*([0-9a-fA-F]{32})') {
                    $result.Add($Matches[1].ToLower())
                } else {
                    $result.Add('')  # empty slot
                }
            } elseif ($line -match '^\s*[a-zA-Z]') {
                # End of array (next field at same indent level)
                break
            }
        }
    }
    return ,$result.ToArray()
}

# 3) Build per-category index
$index = [ordered]@{}

$dataFiles = @(
    @{ Path="$AssetRipRoot\SkinData.asset";          Array='skins';         Offset=300000; Category='skin' },
    @{ Path="$AssetRipRoot\EmoteData.asset";         Array='emotes';        Offset=400000; Category='emote' },
    @{ Path="$AssetRipRoot\PlayerBannerData.asset";  Array='playerBanners'; Offset=500000; Category='banner' },
    @{ Path="$AssetRipRoot\MasteryBadgeData.asset";  Array='masteryBadges'; Offset=600000; Category='masteryBadge' },
    @{ Path="$AssetRipRoot\TombstoneData.asset";     Array='tombstones';    Offset=700000; Category='tombstone' }
)

foreach ($entry in $dataFiles) {
    if (-not (Test-Path $entry.Path)) {
        Write-Host "  SKIP: $($entry.Path) (not found)" -ForegroundColor Yellow
        continue
    }
    $guids = Get-GuidArray -File $entry.Path -ArrayKey $entry.Array
    Write-Host "$($entry.Category): $($guids.Count) entries from $(Split-Path $entry.Path -Leaf)" -ForegroundColor Cyan

    for ($i = 0; $i -lt $guids.Count; $i++) {
        $guid = $guids[$i]
        if ([string]::IsNullOrWhiteSpace($guid)) {
            continue  # empty slot
        }
        $assetId = $entry.Offset + $i
        $name = if ($guidToName.ContainsKey($guid)) { $guidToName[$guid] } else { "unknown_$guid" }
        $index["$assetId"] = @{ category = $entry.Category; name = $name; index = $i }
    }
}

# 3b) Game Modifiers - hardcoded list since they're not in a Data file (they're in GameModifierManager prefab)
Write-Host "Adding game modifiers (hardcoded, 16 known + names)..." -ForegroundColor Cyan
$modifiers = @(
    @{ Id=0;  Name='GM_AllGigantic';        Display='All Gigantic - all chars huge'},
    @{ Id=1;  Name='GM_AngledMap';          Display='Angled Map - tilted terrain'},
    @{ Id=2;  Name='GM_CDReduction';        Display='Cooldown Reduction'},
    @{ Id=3;  Name='GM_FastZone';           Display='Fast Zone - storm closes faster'},
    @{ Id=4;  Name='GM_GoldDropIncrease';   Display='Gold Drop Increase'},
    @{ Id=5;  Name='GM_HpReduction';        Display='HP Reduction - less health'},
    @{ Id=6;  Name='GM_MeteorShower';       Display='Meteor Shower'},
    @{ Id=7;  Name='GM_MoneyIsPower';       Display='Money Is Power'},
    @{ Id=8;  Name='GM_MoveSpeedBoost';     Display='Move Speed Boost'},
    @{ Id=9;  Name='GM_NightTime';          Display='Night Time - dark map'},
    @{ Id=10; Name='GM_NoPainNoGain';       Display='No Pain No Gain'},
    @{ Id=11; Name='GM_NoPotionDrops';      Display='No Potion Drops'},
    @{ Id=12; Name='GM_ReviveTeammateOnKill';Display='Revive Teammate On Kill'},
    @{ Id=13; Name='GM_UniqueItemChance';   Display='Unique Item Chance'},
    @{ Id=14; Name='GM_UseJuiceBoost';      Display='Juice Boost'},
    @{ Id=15; Name='GM_XCOM';               Display='XCOM - misses possible'}
)
foreach ($m in $modifiers) {
    $index["mod-$($m.Id)"] = @{ category = 'modifier'; name = $m.Name; display = $m.Display; index = $m.Id }
}
Write-Host "  Added $($modifiers.Count) modifiers"

# 4) Save to BOTH locations: server bin (for offline) and workspace root (for active server cwd)
$json = $index | ConvertTo-Json -Depth 5 -Compress
$paths = @(
    $OutPath,
    "C:\Users\Administrator\Downloads\CustomServer\data\asset-index.json"
)
foreach ($p in $paths) {
    $dir = Split-Path $p -Parent
    if (-not (Test-Path $dir)) { New-Item -ItemType Directory -Path $dir -Force | Out-Null }
    Set-Content -Path $p -Value $json -Encoding UTF8
    Write-Host "  wrote $p"
}

Write-Host ""
Write-Host "Wrote $($index.Count) asset entries" -ForegroundColor Green
Write-Host ""
Write-Host "Sample entries:" -ForegroundColor Cyan
$index.GetEnumerator() | Where-Object { $_.Key -in @('300001','300003','500001','500121','700001') } | ForEach-Object {
    "  $($_.Key) = $($_.Value.name) ($($_.Value.category))"
}

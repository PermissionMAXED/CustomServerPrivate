$ErrorActionPreference = 'Stop'
$cfgPath = Join-Path $PSScriptRoot '..\deployment\amp-github-autoinstall\bapcustomservergithubconfig.json'
$assetIndexPath = Join-Path $PSScriptRoot '..\data\asset-index.json'
$catalogOut = Join-Path $PSScriptRoot '..\BAPBAP-Asset-Reference.md'

# 1) Convert shop dropdowns (Slot1/2/3 + Freebie AssetId fields) from enum -> number
$entries = Get-Content $cfgPath -Raw -Encoding UTF8 | ConvertFrom-Json
foreach ($entry in $entries) {
    if ($entry.FieldName -in @('ShopSlot1Asset','ShopSlot2Asset','ShopSlot3Asset','ShopFreebieAsset')) {
        $entry.InputType = 'number'
        $entry.PSObject.Properties.Remove('EnumValues')
        $entry.Description = $entry.Description + ' Enter a numeric AssetId. See BAPBAP-Asset-Reference.md for the full list of IDs and names.'
    }
}
$json = $entries | ConvertTo-Json -Depth 10
[System.IO.File]::WriteAllText($cfgPath, $json, [System.Text.UTF8Encoding]::new($false))
Write-Host "Shop slots converted to number input." -ForegroundColor Green

# 2) Generate Asset Reference catalog grouped by category
$assets = Get-Content $assetIndexPath -Raw -Encoding UTF8 | ConvertFrom-Json
$grouped = @{}
foreach ($prop in $assets.PSObject.Properties) {
    $id = [int]$prop.Name
    $entry = $prop.Value
    $cat = $entry.category
    if (-not $grouped.ContainsKey($cat)) { $grouped[$cat] = @() }
    # Clean up the raw name: strip Sticker_/PlayerBanner_/Skin_/MasteryBadge_/Tombstone_ prefix, replace underscores with spaces, drop trailing underscore
    $rawName = $entry.name
    $clean = $rawName -replace '^(Sticker_|PlayerBanner_|Skin_|MasteryBadge_|Tombstone_|Animation_|Voiceline_)','' -replace '_',' ' -replace '\s+',' '
    $clean = $clean.Trim()
    $grouped[$cat] += [pscustomobject]@{
        Id = $id
        RawName = $rawName
        DisplayName = $clean
    }
}

$out = [System.Text.StringBuilder]::new()
[void]$out.AppendLine("# BAPBAP Asset ID Reference")
[void]$out.AppendLine("")
$totalAssets = @($assets.PSObject.Properties).Count
[void]$out.AppendLine("Generated from data/asset-index.json. $totalAssets total assets across $($grouped.Count) categories.")
[void]$out.AppendLine("")
[void]$out.AppendLine("Use these AssetIds in the AMP UI under BAPBAP - Shop -> Slot N -> Item, or in the matching ShopSlot*AssetId fields.")
[void]$out.AppendLine("")

$catOrder = @('skin','banner','emote','masteryBadge','tombstone')
foreach ($cat in $catOrder) {
    if (-not $grouped.ContainsKey($cat)) { continue }
    $catTitle = switch ($cat) {
        'skin' { "Skins (300000+)" }
        'banner' { "Banners (500000+)" }
        'emote' { "Emotes / Stickers / Animations (400000+)" }
        'masteryBadge' { "Mastery Badges (600000+)" }
        'tombstone' { "Tombstones (700000+)" }
        default { $cat }
    }
    [void]$out.AppendLine("## $catTitle")
    [void]$out.AppendLine("")
    [void]$out.AppendLine("| AssetId | Display Name | Raw Name |")
    [void]$out.AppendLine("|---------|--------------|----------|")
    $sorted = $grouped[$cat] | Sort-Object Id
    foreach ($a in $sorted) {
        $disp = $a.DisplayName -replace '\|','\\|'
        $raw = $a.RawName -replace '\|','\\|'
        [void]$out.AppendLine("| $($a.Id) | $disp | ``$raw`` |")
    }
    [void]$out.AppendLine("")
}

[System.IO.File]::WriteAllText($catalogOut, $out.ToString(), [System.Text.UTF8Encoding]::new($false))
Write-Host "Wrote asset reference: $catalogOut ($((Get-Item $catalogOut).Length) bytes)" -ForegroundColor Green

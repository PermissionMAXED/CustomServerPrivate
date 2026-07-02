<#
.SYNOPSIS
    Validates custom-map JSON files for carrier-unsafe fields that would crash the game.

.DESCRIPTION
    Custom maps in BAPBAP dress a shipped carrier (Arena_Map2, 130x130) with entities,
    spawn points, and tile edits -- but certain fields, if set to anything other than
    their safe defaults, corrupt the carrier at load time and crash the match.

    This script checks the four gating fields:

        Field                          Safe value    Crash when
        -----------------------------  ----------    -------------------------------
        mapSize                        null          Set to e.g. [48,48] -- grid
                                                      size mismatch corrupts the
                                                      carrier's internal arrays.
        enableTileEdits                false         true -- tile mutation on a
                                                      wrong-sized grid corrupts
                                                      the navmesh.
        customZoneRounds               false         true -- zone data written for
                                                      a wrong grid corrupts zone
                                                      calculations.
        useLevelDataTileMutations      false         true -- alternative tile path
                                                      also corrupts on carrier.

    Each file is inspected via raw JSON parsing (no Unity dependency). The script
    exits with code 0 when every map passes, or 1 when any map fails -- suitable
    for CI / build-pipeline gating.

    File paths and failure details are written to stdout as a formatted summary.
    Use -PassThru to receive the result object instead.

.PARAMETER Path
    Path to a single map JSON file, or a directory containing map JSON files.
    Defaults to the current directory.

.PARAMETER PassThru
    If specified, the result object is emitted to the pipeline instead of writing
    the summary to stdout. Combined with -PassThru and capturing the output, you
    can integrate this script into automated workflows:

        $results = & .\Test-CustomMapCarrierSafety.ps1 .\maps -PassThru
        if ($results.AnyFailures) { exit 1 }

.EXAMPLE
    # Validate all maps in a directory
    .\Test-CustomMapCarrierSafety.ps1 .\MapEditorUnity\maps

.EXAMPLE
    # Validate a single map file
    .\Test-CustomMapCarrierSafety.ps1 .\maps\customcitadel.json

.EXAMPLE
    # Validate and get structured results
    $r = .\Test-CustomMapCarrierSafety.ps1 .\maps -PassThru
    $r.Results | Where-Object { -not $_.Passed } | ForEach-Object { $_.FilePath }

.EXAMPLE
    # Use in CI pipeline: fails (exit 1) if any map is unsafe
    .\Test-CustomMapCarrierSafety.ps1 .\maps -PassThru | Out-Null
#>

param(
    [Parameter(Position = 0)]
    [string]$Path = ".",

    [switch]$PassThru
)

# ---------------------------------------------------------------
# Helper: test a single map JSON for carrier safety
# ---------------------------------------------------------------
function Test-MapCarrierSafety {
    param([string]$FilePath)

    # Use PSCustomObject so the hashtable is NOT enumerated when returned
    # from the function (PowerShell enumerates bare hashtables in pipeline).
    $result = [PSCustomObject]@{
        FilePath   = $FilePath
        MapName    = "<unknown>"
        MapId      = $null
        Passed     = $true
        Failures   = @()
        IsJson     = $true
    }

    # Resolve to a full path for consistent error messages
    $resolved = $ExecutionContext.SessionState.Path.GetUnresolvedProviderPathFromPSPath($FilePath)

    # Read and parse
    try {
        $raw = Get-Content -Path $resolved -Raw -Encoding UTF8
    }
    catch {
        $result.Passed = $false
        $result.IsJson = $false
        $result.Failures = @($result.Failures) + "FILE_NOT_FOUND: $resolved"
        return $result
    }

    try {
        $map = $raw | ConvertFrom-Json
    }
    catch {
        $result.Passed = $false
        $result.IsJson = $false
        $result.Failures = @($result.Failures) + "INVALID_JSON: $($_.Exception.Message)"
        return $result
    }

    $result.MapName = if ($map.name) { $map.name } else { "(no name)" }
    $result.MapId   = if ($null -ne $map.mapId) { [int]$map.mapId } else { $null }

    # Check 1: mapSize must be null or absent
    if ($map.PSObject.Properties['mapSize'] -and $null -ne $map.mapSize) {
        $result.Passed = $false
        $sizeText = $map.mapSize | ConvertTo-Json -Compress
        $result.Failures = @($result.Failures) + "mapSize must be null, but got '$sizeText'"
    }

    # Check 2: enableTileEdits must be false
    if ($map.PSObject.Properties['enableTileEdits'] -and $map.enableTileEdits -eq $true) {
        $result.Passed = $false
        $result.Failures = @($result.Failures) + "enableTileEdits must be false, but got true"
    }

    # Check 3: customZoneRounds must be false
    if ($map.PSObject.Properties['customZoneRounds'] -and $map.customZoneRounds -eq $true) {
        $result.Passed = $false
        $result.Failures = @($result.Failures) + "customZoneRounds must be false, but got true"
    }

    # Check 4: useLevelDataTileMutations must be false
    if ($map.PSObject.Properties['useLevelDataTileMutations'] -and $map.useLevelDataTileMutations -eq $true) {
        $result.Passed = $false
        $result.Failures = @($result.Failures) + "useLevelDataTileMutations must be false, but got true"
    }

    return $result
}

# ---------------------------------------------------------------
# Discover files to validate
# ---------------------------------------------------------------
$resolvedPath = $ExecutionContext.SessionState.Path.GetUnresolvedProviderPathFromPSPath($Path)

$files = @()
if (Test-Path -Path $resolvedPath -PathType Container) {
    $files = Get-ChildItem -Path $resolvedPath -Filter "*.json" -Recurse -File
}
elseif (Test-Path -Path $resolvedPath -PathType Leaf) {
    $files = @(Get-Item -Path $resolvedPath)
}
else {
    Write-Error "Path not found: $resolvedPath"
    exit 1
}

if ($files.Count -eq 0) {
    Write-Warning "No JSON files found at: $resolvedPath"
    if ($PassThru) {
        return [PSCustomObject]@{
            Path         = $resolvedPath
            AnyFailures  = $false
            Results      = @()
            FilesScanned = 0
            Summary      = @{ ValidJson = 0; Passed = 0; Failed = 0; ParseErrors = 0 }
        }
    }
    exit 0
}

# ---------------------------------------------------------------
# Validate every file
# ---------------------------------------------------------------
$results = [System.Collections.ArrayList]@()
foreach ($f in $files) {
    [void]$results.Add((Test-MapCarrierSafety -FilePath $f.FullName))
}

# Wrap Where-Object results in @() to ensure we always get an array.
# In PowerShell 5.1, a single PSCustomObject result lacks the intrinsic
# .Count member, so unadorned Where-Object output would give $null.Count.
$validJson   = @($results | Where-Object { $_.IsJson })
$passedItems = @($validJson | Where-Object { $_.Passed })
$failedItems = @($validJson | Where-Object { -not $_.Passed })
$parseErrItems = @($results | Where-Object { -not $_.IsJson })

$totalScanned = $results.Count
$passCount    = $passedItems.Count
$failCount    = $failedItems.Count
$parseErrors  = $parseErrItems.Count
$anyFailed    = $failedItems.Count -gt 0

$output = [PSCustomObject]@{
    Path         = $resolvedPath
    AnyFailures  = $anyFailed
    Results      = $results
    FilesScanned = $totalScanned
    Summary      = [PSCustomObject]@{
        ValidJson      = $validJson.Count
        Passed         = $passCount
        Failed         = $failCount
        ParseErrors    = $parseErrors
    }
}

# ---------------------------------------------------------------
# Emit result
# ---------------------------------------------------------------
if ($PassThru) {
    return $output
}

# Write human-readable summary to stdout
Write-Host ""
Write-Host "=== Custom Map Carrier Safety Report ===" -ForegroundColor Cyan
Write-Host "  Scanned : $resolvedPath"
Write-Host "  Files   : $totalScanned (valid JSON: $($validJson.Count), parse errors: $parseErrors)"
Write-Host "  Passed  : $passCount"
Write-Host "  Failed  : $failCount"
Write-Host ""

foreach ($r in $results) {
    $symbol = if ($r.Passed) { "[PASS]" } else { "[FAIL]" }
    $color  = if ($r.Passed) { "Green" } else { "Red" }
    $mapLabel = ""
    if ($r.IsJson) {
        $mn = if ($r.MapName) { $r.MapName } else { "(no name)" }
        $mi = if ($null -ne $r.MapId) { ", mapId $($r.MapId)" } else { "" }
        $mapLabel = " ($mn$mi)"
    }

    if ($r.IsJson) {
        Write-Host "$symbol $($r.FilePath)$mapLabel" -ForegroundColor $color
    }
    else {
        Write-Host "$symbol $($r.FilePath)" -ForegroundColor DarkRed
    }

    foreach ($failure in $r.Failures) {
        Write-Host "       -> $failure" -ForegroundColor Yellow
    }
}

Write-Host ""

if ($anyFailed) {
    Write-Host "RESULT: FAILED -- $failCount map(s) have carrier-unsafe fields." -ForegroundColor Red
    Write-Host "Correct the fields listed above before deploying these maps." -ForegroundColor Red
    Write-Host ""
    exit 1
}
else {
    Write-Host "RESULT: PASSED -- all maps are carrier-safe." -ForegroundColor Green
    Write-Host ""
    exit 0
}

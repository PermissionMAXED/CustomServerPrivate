param(
    [string]$BaseUrl = "http://ark.atomi23.de:5055",
    [int]$ServerTail = 500,
    [int]$GameTail = 200,
    [int]$GameFiles = 8,
    [string]$Filter = "charId|char id|CharId|Medusa|Skinny|SpawnPlayerChar|AssignCharacters|recorded non-Medusa|restored recorded|qmd|DefaultCharacter|selected char|SwitchCharacter|prematch|PreMatch|characterPrefabsByCharId|spawn"
)

$ErrorActionPreference = "Continue"
$stamp = Get-Date -Format "yyyyMMdd-HHmmss"
$outDir = Join-Path $PSScriptRoot "..\logs\livediag-$stamp"
New-Item -ItemType Directory -Force -Path $outDir | Out-Null

Write-Host "=== HEALTH ==="
try {
    $health = Invoke-RestMethod -Uri "$BaseUrl/health" -TimeoutSec 12
    "release=$($health.release) build=$($health.packageBuildUtc) modDll=$($health.artifacts.modDllSha256) serverDll=$($health.artifacts.serverDllSha256) medusaDll=$($health.artifacts.medusaDllSha256)" | Write-Host
} catch {
    Write-Host ("HEALTH ERROR: " + $_.Exception.Message)
}

Write-Host "`n=== SERVER LOG (filtered, tail=$ServerTail) ==="
try {
    $srv = Invoke-RestMethod -Uri "$BaseUrl/api/diagnostics/server-log?tail=$ServerTail" -TimeoutSec 20
    $srvText = if ($srv -is [string]) { $srv } else { ($srv | Out-String) }
    $srvText | Set-Content -LiteralPath (Join-Path $outDir "server-log.txt") -Encoding UTF8
    ($srvText -split "`n") | Select-String -Pattern $Filter | Select-Object -Last 120 | ForEach-Object { $_.Line }
} catch {
    Write-Host ("SERVER LOG ERROR: " + $_.Exception.Message)
}

Write-Host "`n=== GAME LOGS (filtered, tail=$GameTail files=$GameFiles) ==="
try {
    $game = Invoke-RestMethod -Uri "$BaseUrl/api/diagnostics/game-logs?tailLines=$GameTail&files=$GameFiles" -TimeoutSec 20
    $gameText = if ($game -is [string]) { $game } else { ($game | ConvertTo-Json -Depth 12) }
    $gameText | Set-Content -LiteralPath (Join-Path $outDir "game-logs.txt") -Encoding UTF8
    ($gameText -split "`n") | Select-String -Pattern $Filter | Select-Object -Last 150 | ForEach-Object { $_.Line }
} catch {
    Write-Host ("GAME LOGS ERROR: " + $_.Exception.Message)
}

Write-Host "`nSaved raw diagnostics to $outDir"

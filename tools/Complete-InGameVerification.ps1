<#
.SYNOPSIS
  One-command completion path for the 9 remaining in-game (Blocked-NeedsGameClient) features.

.DESCRIPTION
  Wraps the two-step handoff into a single user-driven run:
    1. Launches Test-SingleClientMedusa.ps1 (host + ONE client + bots) so YOU can play.
    2. Waits for you to exercise the features in-game, then press ENTER.
    3. Auto-runs Verify-InGameLogs.ps1 against the captured logs -> functional pass/fail.

  This script is meant to be run BY YOU (it opens a real game window). It is not run
  autonomously in a loop (see memory: don't spam test matches).

  To hit all 9 features in one session, while in-game:
    F157 press F7 (needs ProductionMode OFF or ShowStatusChip=true in the ini)
    F158 confirm overlays are hidden in a default ProductionMode build
    F165 the launched client auto-joins the hosted match (automatic)
    F166 (optional) relaunch a client with --bapcustom-autoplay
    F169 open char-select and pick a non-default character
    F172 play a full match (NetTune is default-on)
    F174 (optional) delete AccountId/Username from the ini first to trigger identity setup
    F183 LOOK: Medusa renders with her real model (your eyes)
    F185 LOOK: cast each ability slot, VFX/hitboxes appear (your eyes)
#>
param(
    [int]$ServerPort = 5161,
    [int]$BotCount = 7
)

$ErrorActionPreference = "Stop"
$Root = Resolve-Path (Join-Path $PSScriptRoot "..")
$ClientLog = Join-Path $Root "CustomMatchServer\logs\game-servers\1c-med-leader.log"
$HostLog   = Join-Path $Root "CustomMatchServer\logs\game-servers\1c-med-HOST.unity.log"

Write-Host "=== Step 1/3: launching single-client test match ===" -ForegroundColor Cyan
& (Join-Path $PSScriptRoot "Test-SingleClientMedusa.ps1") -ServerPort $ServerPort -BotCount $BotCount

Write-Host ""
Write-Host "=== Step 2/3: play the match now ===" -ForegroundColor Cyan
Write-Host "Exercise the in-game features (see this script's header for the checklist)," -ForegroundColor Yellow
Write-Host "then come back here and press ENTER to run the log verifier." -ForegroundColor Yellow
[void](Read-Host "Press ENTER when done playing")

Write-Host ""
Write-Host "=== Step 3/3: verifying captured logs ===" -ForegroundColor Cyan
& (Join-Path $PSScriptRoot "Verify-InGameLogs.ps1") -ClientLog $ClientLog -HostLog $HostLog
$verifyExit = $LASTEXITCODE

Write-Host ""
Write-Host "Done. Paste the PASS/FAIL block above back to Claude to update docs/FEATURE_STATUS.csv" -ForegroundColor Cyan
Write-Host "and fix anything that FAILed. F183/F185 are visual - report those from your eyes." -ForegroundColor Cyan
exit $verifyExit

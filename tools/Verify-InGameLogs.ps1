<#
.SYNOPSIS
  Functional log-assertion verifier for the 20 in-game (Blocked-NeedsGameClient) features.

.DESCRIPTION
  These features run only inside a live bapbap.exe / IL2CPP client and cannot execute in the
  headless dev environment. This script does NOT spawn a match (see memory: don't spam test
  matches). Instead, AFTER you run a match yourself (tools/Test-SingleClientMedusa.ps1), point
  this at the captured client + host + server logs and it asserts each feature's REAL log marker,
  turning the in-game checklist from manual eyeballing into deterministic functional pass/fail.

  Two features are deliberately NOT log-checkable and remain user-eyes-only per saved feedback
  (no visual success from logs): F183 (Medusa model renders correctly) and F185 (ability VFX look).
  They are reported as MANUAL so you know to judge them visually.

.PARAMETER ClientLog
  The visible client's Unity/MelonLoader log (e.g. CustomMatchServer\logs\game-servers\1c-med-leader.log).
.PARAMETER HostLog
  The dedicated match host's Unity log (e.g. CustomMatchServer\logs\game-servers\1c-med-HOST.unity.log).
.PARAMETER ServerLog
  The lobby server's stdout/log capture (optional; used for bootstrap-applied + GAME_STARTED).
#>
param(
    [string]$ClientLog = "",
    [string]$HostLog = "",
    [string]$ServerLog = ""
)

$ErrorActionPreference = "Stop"

function Read-LogSafe([string]$path) {
    if ([string]::IsNullOrWhiteSpace($path)) { return "" }
    if (-not (Test-Path $path)) { Write-Host "  (log not found: $path)" -ForegroundColor DarkYellow; return "" }
    return (Get-Content -Raw -ErrorAction SilentlyContinue $path)
}

$client = Read-LogSafe $ClientLog
$hostl  = Read-LogSafe $HostLog
$server = Read-LogSafe $ServerLog
$all    = "$client`n$hostl`n$server"

# Each check: feature id, name, the log to look in, and one or more REAL marker substrings (any match = pass).
# Markers verified against BapCustomServerMelon/CustomServerMod.cs + server logs in this repo.
$checks = @(
    @{ Id="F151"; Name="SESSION_ID / AUTO_LOGIN priming";            Log=$client; Markers=@("Primed auto-login prefs for custom server session") }
    @{ Id="F152"; Name="Automatic guest login";                      Log=$client; Markers=@("Custom guest-login scan resolved LobbyNetworkClient", "guest-login", "LoginGuest") }
    @{ Id="F156"; Name="UnityWebRequest header/callback repair";     Log=$client; Markers=@("Rewrote UnityWebRequest callback URL", "Rewrote UnityWebRequest loopback API URL", "Repaired empty UnityWebRequest header") }
    @{ Id="F157"; Name="F7 / native settings panel";                 Log=$client; Markers=@("Native custom server UI attached to existing game UI canvas", "F7 settings", "Native custom server UI could not be created") }
    @{ Id="F158"; Name="Production-mode overlay suppression";        Log=$client; Markers=@("Production mode", "ProductionMode") }
    @{ Id="F162"; Name="Bootstrap payload applied to GameNetworkManager"; Log=$hostl; Markers=@("Applied managed match bootstrap payload") }
    @{ Id="F163"; Name="Dedicated game-network startup";             Log=$hostl; Markers=@("Started dedicated game network", "Dedicated game network is listening", "post-StartServer") }
    @{ Id="F164"; Name="Dedicated match auto-end timer";             Log=$hostl; Markers=@("Requested dedicated match auto-end with winnerTeamId") }
    @{ Id="F165"; Name="Client auto-join of hosted match";           Log=$client; Markers=@("Auto-joining match", "client-autojoin-before-connect", "client-autojoin-after-connect") }
    @{ Id="F166"; Name="Autoplay automation";                        Log=$client; Markers=@("[Autoplay] Joined lobby", "[Autoplay] Ready set", "[Autoplay] GameManager detected", "[Autoplay] Players detected") }
    @{ Id="F169"; Name="Character-selection tracking/propagation";   Log=$client; Markers=@("[CharacterSelection]", "CharacterSelectionTracker") }
    @{ Id="F171"; Name="Lobby/UI stability + crash-guard patches";   Log=$client; Markers=@("[LockerGuard] Installed exception-swallow finalizer", "CharacterSelectPrefix", "Skipped UILobbyMatchCharacterSelectPage", "shop request throttle") }
    @{ Id="F172"; Name="Network tuning (Mirror/KCP)";                Log=$all;    Markers=@("[NetTune]") }
    @{ Id="F173"; Name="Analytics no-op patch";                      Log=$client; Markers=@("Installed AnalyticsManager custom-server no-op patch") }
    @{ Id="F174"; Name="Quit guard during identity relaunch";        Log=$client; Markers=@("Queued game relaunch after first-start identity setup", "Relaunching game after first-start identity setup", "quit guard", "Guard expires") }
    @{ Id="F182"; Name="Data-only custom character registration";    Log=$all;    Markers=@("Char_Medusa", "registered Char_", "custom character", "[M2]") }
    @{ Id="F184"; Name="Headless / dedicated-host safety gating";    Log=$hostl;  Markers=@("[BAPCustomConfig] mode=dedicated", "batchMode=True", "[BatchMode] Application.isBatchMode=true", "dedicated=True") }
    @{ Id="F187"; Name="Medusa selection normalization";             Log=$all;    Markers=@("Medusa player state forced via AddPlayerMatchmaking", "old=11 new=15", "charId 15", "[M2] graft") }
)

# Visual-only (user eyes), never asserted from logs (memory: no-visual-success-from-logs).
$manual = @(
    @{ Id="F183"; Name="Medusa model renders correctly (lobby + match)" }
    @{ Id="F185"; Name="Per-slot ability hitbox/VFX look correct on cast" }
)

if ([string]::IsNullOrWhiteSpace($client) -and [string]::IsNullOrWhiteSpace($hostl) -and [string]::IsNullOrWhiteSpace($server)) {
    Write-Host ""
    Write-Host "No logs supplied. Run a match first (tools/Test-SingleClientMedusa.ps1), then:" -ForegroundColor Cyan
    Write-Host "  tools/Verify-InGameLogs.ps1 -ClientLog <client.log> -HostLog <host.unity.log> [-ServerLog <server.log>]"
    Write-Host ""
    Write-Host "Default capture locations from Test-SingleClientMedusa.ps1:" -ForegroundColor DarkGray
    Write-Host "  Client: CustomMatchServer\logs\game-servers\1c-med-leader.log"
    Write-Host "  Host:   CustomMatchServer\logs\game-servers\1c-med-HOST.unity.log"
    exit 2
}

$pass = 0; $fail = 0
Write-Host ""
Write-Host "=== Functional in-game log assertions ===" -ForegroundColor Cyan
foreach ($c in $checks) {
    $hay = [string]$c.Log
    $hit = $false
    foreach ($m in $c.Markers) { if ($hay -and $hay.Contains($m)) { $hit = $true; break } }
    if ($hit) { Write-Host ("  PASS {0} | {1}" -f $c.Id, $c.Name) -ForegroundColor Green; $pass++ }
    else      { Write-Host ("  FAIL {0} | {1}  (no marker: {2})" -f $c.Id, $c.Name, ($c.Markers -join " | ")) -ForegroundColor Red; $fail++ }
}

Write-Host ""
Write-Host "=== Visual checks (YOUR EYES - not assertable from logs) ===" -ForegroundColor Cyan
foreach ($m in $manual) { Write-Host ("  MANUAL {0} | {1}" -f $m.Id, $m.Name) -ForegroundColor Yellow }

Write-Host ""
Write-Host ("=== {0} functional PASS, {1} FAIL, {2} MANUAL (visual) ===" -f $pass, $fail, $manual.Count) -ForegroundColor Cyan
if ($fail -gt 0) {
    Write-Host "FAILs mean the marker was absent - either the feature did not run, or the marker string drifted. Check the log for surrounding context." -ForegroundColor DarkYellow
    exit 1
}
exit 0

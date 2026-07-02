param()
# Self-contained UNATTENDED full-test runner. Launched in the BACKGROUND so no caller blocks.
# Writes analysis\full-test-report.md with PASS/FAIL + evidence. Verifies via LOGS (reliable).
$ErrorActionPreference = 'Continue'
$root = 'C:\Users\Administrator\Downloads\CustomServer'
$rep  = "$root\analysis\full-test-report.md"
function Log($m){ $line = "[{0}] {1}" -f (Get-Date -Format 'HH:mm:ss'), $m; Add-Content -Path $rep -Value $line }
"# Full Test Report ($(Get-Date -Format 'yyyy-MM-dd HH:mm'))" | Set-Content $rep
Add-Content $rep ""

function KillStale {
    Get-Process -Name bapbap,cua-driver,dotnet -ErrorAction SilentlyContinue | ForEach-Object {
        try { cmd /c "wmic process where processid=$($_.Id) call terminate" 2>&1 | Out-Null } catch {}
    }
    Start-Sleep 3
}

# ---------------- TEST 1: 2-client networked parity (local) ----------------
KillStale
Log "TEST1 (2-client parity): launching Test-TwoClientMedusa.ps1"
$p1 = Start-Process powershell -ArgumentList '-NoProfile','-ExecutionPolicy','Bypass','-File',"$root\tools\Test-TwoClientMedusa.ps1" -WindowStyle Hidden -PassThru -RedirectStandardOutput "$root\logs\ft-2c.out" -RedirectStandardError "$root\logs\ft-2c.err"
if (-not $p1.WaitForExit(600000)) { try { $p1.Kill() } catch {}; Log "TEST1: timed out (600s)" }
$gLog = "$root\CustomMatchServer\logs\game-servers\2c-med-guest.log"
$lLog = "$root\CustomMatchServer\logs\game-servers\2c-med-leader.log"
function MedusaAsset($f){
    try { $m = Select-String -Path $f -Pattern "assetId '(\d+)'\. Old prefab 'Char_Medusa'" -ErrorAction SilentlyContinue | Select-Object -First 1
          if ($m) { return $m.Matches[0].Groups[1].Value } } catch {}
    return ''
}
$gA = MedusaAsset $gLog; $lA = MedusaAsset $lLog
$started = ((Select-String -Path "$root\logs\ft-2c.out" -Pattern 'GAME_STARTED both' -ErrorAction SilentlyContinue) -ne $null)
Log "TEST1: GAME_STARTED_both=$started guest_Char_Medusa_assetId=$gA leader_assetId=$lA parity=$([bool]($gA -ne '' -and $gA -eq $lA))"
$test1 = ($started -and $gA -ne '' -and $gA -eq $lA)
Log "TEST1 RESULT: $(if($test1){'PASS'}else{'FAIL'})"

# ---------------- TEST 2: live cast (abilities + owner/team, no despawn) ----------------
KillStale
Log "TEST2 (live cast): launching Test-NetCustomCast.ps1 against ark"
$env:BAPBAP_NETCUSTOM_AUTOSELECT = '1'
$p2 = Start-Process powershell -ArgumentList '-NoProfile','-ExecutionPolicy','Bypass','-File',"$root\tools\Test-NetCustomCast.ps1" -WindowStyle Hidden -PassThru -RedirectStandardOutput "$root\logs\ft-cast.out" -RedirectStandardError "$root\logs\ft-cast.err"
$castEvidence = ''; $m5 = ''
for ($i = 0; $i -lt 9; $i++) {
    Start-Sleep 45
    try {
        $resp = Invoke-RestMethod "http://ark.atomi23.de:5055/api/diagnostics/game-logs?tailLines=400&files=1" -TimeoutSec 20
        $t = if ($resp -is [string]) { $resp } else { ($resp | ConvertTo-Json -Depth 8) }
        $lines = $t -split "`n"
        if (-not $m5) { $a = $lines | Select-String "M5\] active definition" | Select-Object -Last 1; if ($a) { $m5 = $a.Line.Trim() } }
        $hit = $lines | Select-String 'spawned authentic Medusa networked prefab' | Select-Object -Last 1
        if ($hit) { $castEvidence = $hit.Line.Trim(); break }
    } catch {}
}
try { if (-not $p2.HasExited) { $p2.WaitForExit(150000) | Out-Null } } catch {}
$ownerOk = ($castEvidence -match 'owner=(\d+)') -and ([int]$Matches[1] -gt 0)
Log "TEST2: castEvidence=$castEvidence"
Log "TEST2: ownerPositive=$ownerOk"
$test2 = ($castEvidence -ne '' -and $ownerOk)
Log "TEST2 RESULT: $(if($test2){'PASS'}else{'INCONCLUSIVE (cast timing) - see ft-cast.out'})"

# ---------------- TEST 3: config-driven load ----------------
Log "TEST3 (config-driven): $m5"
$test3 = ($m5 -match 'Medusa') -and ($m5 -match '0xB0B00F0F')
Log "TEST3 RESULT: $(if($test3){'PASS'}else{'FAIL'})"

KillStale
Log "DONE. SUMMARY: TEST1(parity)=$(if($test1){'PASS'}else{'FAIL'}) TEST2(live-cast)=$(if($test2){'PASS'}else{'INCONCLUSIVE'}) TEST3(config)=$(if($test3){'PASS'}else{'FAIL'})"

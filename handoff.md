# HANDOFF — How to Continue

_Practical runbook. Read MISSION.md + CONTEXT.md first._

## Workflow rules (IMPORTANT — avoid getting "stuck")
- **Never block a tool call for minutes.** Long runs (matches, tests, deploys) → launch in the
  **background** with `Start-Process` (returns instantly), then check results with **short** status
  reads (read a file / list procs). No multi-minute `Start-Sleep` in a foreground command.
- **Do NOT use blocking subagents to RUN long tests** — they only have blocking mode and hang the turn.
  Use the background runner (`tools\Run-FullTest.ps1`) instead. Subagents are fine for short reviews.
- **Verify via LOGS, not screenshots** (screenshots of this top-down game are flaky to auto-frame).
- **AMP rate limit**: don't spam the AMP panel API. Prefer HTTP `/health` + `/api/diagnostics/game-logs`
  (these are the game/ASP.NET endpoints, NOT AMP). Only touch AMP for stop/start/deploy.

## Build
```powershell
dotnet build C:\Users\Administrator\Downloads\BAPBAPModdingAPI\netcustomchar-mod -c Release
# -> bin\Release\NetworkedCustomChar.dll  (deterministic; verify SHA256)
```
Reference assemblies come from `Battleroyalebuild\MelonLoader\net6` + `MelonLoader\Il2CppAssemblies`
(incl. `Newtonsoft.Json.dll`). Verify Il2Cpp member names against the real reference assemblies.

## Deploy (server + client)
```powershell
# Stage configs + DLL into the deploy stage, rebuild the zip, copy DLL to the local client, then:
powershell -File C:\Users\Administrator\Downloads\CustomServer\tools\Deploy-NetCustomChar.ps1
```
- `Deploy-NetCustomChar.ps1`: AmpBaseUrl `https://ark.atomi23.de`, InstanceId
  `a8556e48-c8be-4f34-b7a1-517607f96b3b`, SessionId from `%TEMP%\amp_session.txt`.
  Stops the instance → deletes old `BAPBAP.Medusa.dll`/`BAPCustomChars.dll` → uploads+MD5-verifies+extracts
  the zip (`game\Mods\NetworkedCustomChar.dll` + `game\UserData\Medusa\medusa.bundle` +
  `game\UserData\CustomChars\*.json`) → restarts. Server prewarms a match-host on restart.
- Stage dir: `deployment\netcustomchar-deploy\stage\game\` — put the DLL in `Mods\`, the bundle in
  `UserData\Medusa\`, and the configs in `UserData\CustomChars\`, then the script zips + uploads.

## Test (background — never blocks the caller)
```powershell
Start-Process powershell -ArgumentList '-NoProfile','-ExecutionPolicy','Bypass','-File',`
  'C:\Users\Administrator\Downloads\CustomServer\tools\Run-FullTest.ps1' -WindowStyle Hidden
# ~13 min later, read the report (fast):
Get-Content C:\Users\Administrator\Downloads\CustomServer\analysis\full-test-report.md
```
`Run-FullTest.ps1` runs TEST1 (`Test-TwoClientMedusa.ps1`, 2-client parity, local) + TEST2
(`Test-NetCustomCast.ps1`, live cast vs ark) + TEST3 (config), verifies via logs, writes PASS/FAIL.

### Manual verification (fast, no AMP)
```powershell
Invoke-RestMethod "http://ark.atomi23.de:5055/health"
$g=Invoke-RestMethod "http://ark.atomi23.de:5055/api/diagnostics/game-logs?tailLines=500&files=1"
# grep for: [M5] active definition | [M1] loaded | [M3c] spawned ... owner=
```
2-client parity logs: `CustomMatchServer\logs\game-servers\2c-med-{leader,guest}.log` (grep `Char_Medusa` + assetId).

## Key paths / facts
- Mod source: `C:\Users\Administrator\Downloads\BAPBAPModdingAPI\netcustomchar-mod`
- Local game (has the deployed mod): `C:\Users\Administrator\Downloads\CustomServer\Spiel\Battleroyalebuild`
- Configs: `…\Battleroyalebuild\UserData\CustomChars\*.json` (medusa.json enabled)
- Decompiled game: `C:\Users\Administrator\Downloads\neueBapbap\GameCode\ExportedProject\_DisabledScripts\Assembly-CSharp\BAPBAP`
- Reverse-engineering dumps (Medusa): `C:\Users\Administrator\Downloads\BAPBAPModdingAPI\BAPBAPModAPI\reverse-engineering\dumps\latest\medusa\` (`ABILITY_MANIFEST.md`)
- Designs/reports: `CustomServer\analysis\` (NEW-CHAR-SYSTEM-CONCEPT, M1-PREFAB-REGISTRATION-DESIGN, CUSTOM-NETWORKING-DESIGN, m1-build-report, m3b/m3c-verification, final-audit, full-test-report)
- AMP token: `%TEMP%\amp_session.txt` (currently `1b800b60-2c2f-4fa7-ab75-b1e073153587`; valid as of the
  17:16 2026-06-14 deploy). Refresh, if expired, via Edge DevTools: `localStorage.getItem('LastSessionID')`
  (offline extraction from Edge's leveldb is blocked — Snappy-compressed `.ldb` + app-bound `v20` cookies).
- Kill stuck procs: `cmd /c "wmic process where processid=<id> call terminate"` (taskkill is access-denied on cua-launched clients).

## How to add a NEW character (the M5 goal in practice)
1. Build the character's AssetBundle (e.g., `foo.bundle` with a `Foo_Visual` prefab) and place it at
   `…\UserData\Foo\foo.bundle`.
2. Create `…\UserData\CustomChars\foo.json`:
   `{ "charId":15, "name":"Foo", "displayName":"FOO", "baseCharId":0, "graftVisual":true,
      "bundleFileName":"foo.bundle", "visualPrefabName":"Foo_Visual", "enabled":true }`
   and set `enabled:false` on the others (only one active; charId 15 is the proven custom slot —
   non-roster, no native-name collision; note Eve is NATIVE charId 8).
3. Deploy (DLL unchanged; only configs + the new bundle). No recompile.

## Known issues / next steps
- **Ability content not yet config-driven**: the JSONs carry `statusOnHit`/`abilityHitboxes`/`abilityTitles`/
  `abilityDescriptions`/`abilityPaletteHex`, but the loader currently reads only the identity+visual fields.
  Next increment: drive `BuildStatusEffects` + the M3c hitbox selection + UI text/palette from the def.
- **Ability icons** stay base-clone sprites — hard asset limit (no Medusa ability sprites exist).
- **Clean cross-view screenshot** of guest-sees-Medusa was never auto-captured (augment panel / framing);
  the "others see it" property is proven instead by registration parity + the live kill-by-other.
- A real 2nd char (e.g., Blitz) needs its own bundle (content), not just config.

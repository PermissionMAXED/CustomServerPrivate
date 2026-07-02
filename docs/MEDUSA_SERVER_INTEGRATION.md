# Medusa Server Integration

Date: 2026-06-09

This custom server advertises and packages Medusa as custom character `charId=15`.
The live AMP deployment currently verified is `medusa-v1722-lifecycle-fix`.

## Backend Support

- Server roster supports character IDs `0..15`.
- `CustomServer.Roster.EnableMedusa` defaults to `true`.
- `MatchDefaults.AvailableCharacters` includes `15`.
- `/health`, `/`, `/api/load`, `/api/server-config`, and character listing/mastery endpoints expose Medusa.
- `/api/chars/mastery/15` returns a Medusa mastery path.
- `/api/internal/xp` accepts character XP writes for Medusa.
- Match-end rewards persist character XP for the selected character.
- `/health` reports Medusa artifact hashes and availability.

## Required Client Artifacts

The client and AMP game files must include:

- `Mods/BAPBAP.ModAPI.dll`
- `UserLibs/BAPBAP.ModAPI.dll`
- `Mods/BAPBAP.Medusa.dll`
- `UserData/Medusa/medusa.bundle`
- `UserData/Medusa/medusa-portrait.png`
- `UserData/Medusa/medusa-wide.png`

Current live hashes:

```text
BAPBAP.ModAPI.dll        0E14F39A9C47B6EBA106A0F23E76A0989B3270D7BCDD3E4BB0DD51E63BDB3CB5
BAPBAP.Medusa.dll        800D59FED09A2E531AE89C3680F0591338D03E0BBEB531FC707E1638BB5C09C1
medusa.bundle            C4872D6E124E76F9F4B4EC75482FFC2795D051D3CA65EB7C25E9FE68023B1D70
BapCustomServerMelon.dll 7C062B85E5ADF11E1A79492E4DA1DD21F43FA0C786CAF64214271FDFD5DC003E
BapCustomServer.dll      47316404CE1E4093F309FCA901F5AAE5EC8EAD8B2F985531278CCAF59FD20431
```

## Selection And Spawn Path

Seeing Medusa in the lobby is not enough. The selected character must survive all later match phases:

- lobby selection;
- queue payload;
- prematch character select;
- dedicated match bootstrap;
- `PreMatchManager.AssignCharacters`;
- `GameMode.SpawnPlayerChar`;
- client network spawn and prefab resolution.

Current implementation details:

- Medusa uses `charId=15`.
- Mirror asset id is stable: `0x4D454455`.
- Medusa selected players are normalized to `charId=15` with `skinAssetId=-1`.
- Non-Medusa selections are recorded and restored so normal characters do not become Medusa.
- Dedicated/batchmode startup registers the Medusa prefab even when normal UI character config is missing.
- Runtime `NetworkIdentity` state is sanitized before registration.
- Medusa globally registering on client startup is expected and is not spawn proof by itself.

Current live proof:

- normal `charId=1` control stayed non-Medusa in the queue payload;
- Medusa control spawned as `Char_Medusa(Clone)` / `[CodexVfx] Medusa`;
- `visualActive=True`;
- mesh `MedusaBase`;
- animator/controller `Medusa`;
- material `Medusa_Material_Native`;
- no observed Skinny fallback in the v1722 custom Medusa test;
- no observed transparent respawn/despawn loop in the v1722 custom Medusa test.
- with `BotCount=2`, screenshots showed in-game player counter `3` and a visible enemy model at the screen edge.

## Ability And VFX Path

The old ripped build does not ship official first-party Medusa ScriptableObjects.
The mod therefore builds the Medusa runtime path from the owned client, ModAPI, Medusa bundle, and runtime bridges.

Current Medusa DLL: `v1.6.70`.

Implemented behavior:

- Medusa-specific ability display data;
- four Medusa-green runtime ability UI entries;
- inherited Kitsu VFX references suppressed;
- native Medusa bundle FX emitted for ability feedback;
- runtime Medusa FX cleanup on scene reset and GameMode shutdown;
- invalid animator layer writes/crossfades guarded;
- input fallback restricted to the local Medusa entity;
- duplicate cast drivers debounced;
- material caches isolated per prefab so native VFX do not mutate unrelated materials.

v1722 proof from `custom-medusa-vfx-v1708-20260609-030830`:

- loaded native FX prefabs: `VFX_Medusa_Poison_Escape`, `Hit`, `Muzzle`, `Puddle`, `Trail`, `Wall`
- slot `0`: muzzle, trail, hit
- slot `1`: muzzle, trail, puddle
- slot `2`: escape, trail, puddle
- slot `3`: muzzle, wall, hit
- logs report `inherited Kitsu Shoot suppressed`
- screenshot `slot3-e-180ms.png` shows Medusa visible in match

v1722 bot/enemy visual proof from `custom-medusa-vfx-v1708-20260609-032137`:

- custom match started at `t+28.6s`
- `BotCount=2`
- screenshots `slot0-left-1030ms.png` and `slot3-e-1030ms.png` show Medusa visible
- in-game player counter shows `3`
- an enemy model is visible at the screen edge
- client diagnostic still reports only the local player in `players=1`; this is visual proof, not a full entity-list audit

## Queue And AMP Startup

The queue issue was a startup and lifecycle pipeline problem, not a Medusa-only problem:

- Wine/Unity may cold start slowly;
- some failed attempts produced only wrapper logs and no fresh Unity/Melon readiness;
- `/setup-game` polling used to spam `Connection refused`;
- old test matches could occupy the single-match capacity;
- fixed AMP ports could be reused before a killed Windows game process fully exited.

Current v1722 behavior:

- startup prewarm is enabled and tracked in `/health`;
- `GameServerStopWaitMillis=5000` waits after process kill before port reuse;
- `GameServerPostCleanupStartDelayMillis=3000` waits after stale match cleanup before the next start;
- active/noisy Unity startup still gets a longer bootstrap window;
- empty-lobby matches are cleaned before capacity checks;
- match starts retry up to an effective `2` attempts;
- `HttpClient.game-server` info logs are filtered so connection-refused polling does not flood AMP console output;
- `/health` reports Wine, Xvfb, queue timings, cleanup timings, prewarm status, and artifact hashes.

Current live queue proof:

- normal matchmaking control reached `GAME_STARTED` at `t+52.8s` after prewarm was ready;
- the server performed one real start attempt (`attempt 1/2`) and bootstrapped in `20.1s`, not the old failed-first-attempt/requeue loop;
- Medusa custom match reached game start in about `28.3s`;
- after cleanup, root reports no lobbies and queue reports no players.

## Verification Commands

Health:

```powershell
Invoke-RestMethod -Uri 'http://ark.atomi23.de:5055/health' -TimeoutSec 10 | ConvertTo-Json -Depth 8
```

Normal character control:

```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File .\tools\Test-LiveMedusaQueueDirect.ps1 -BaseUrl 'http://ark.atomi23.de:5055' -GameHost 'ark.atomi23.de' -CharacterId 1 -ObserveSeconds 12 -MatchEventTimeoutMs 180000 -KillFirst
```

Medusa VFX control:

```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File .\tools\Test-LiveCustomMedusaVfx.ps1 -BaseUrl 'http://ark.atomi23.de:5055' -GameHost 'ark.atomi23.de' -CharacterId 15 -MapId 1 -BotCount 0 -KillFirst
```

## Known Limits

This is a modded native integration for an older build, not a first-party data patch with official Medusa ScriptableObjects. Keep validating all layers together: backend selection, prematch state, spawned prefab, visible model, ability UI, VFX, and normal character regressions.

The remaining manual QA item is leaving a match through the normal UI and checking that no red outline or overlay persists. Automated tests currently restart/kill clients and therefore do not fully prove that UI cleanup path.

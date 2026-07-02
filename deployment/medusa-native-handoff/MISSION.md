# Mission: Medusa Native Integration

Updated: 2026-06-09 03:35 +02:00.

## Objective

Make Medusa behave like a real playable character in the owned BAPBAP client/backend setup:

- selectable in lobby and match character select;
- normal character selection must still work;
- no automatic Medusa forcing for non-Medusa players;
- no Skinny fallback;
- stable Medusa model, animator, material, and visibility in match;
- Medusa ability UI and native Medusa VFX instead of Kitsu leftovers or green placeholder lines;
- queue/start behavior should not spend minutes on a dead first attempt;
- AMP and client logs should show release, hashes, Wine/Xvfb, startup checks, and actionable match diagnostics.

## Current Live Result

AMP is live on `medusa-v1722-lifecycle-fix`.

Current state is functionally playable for the tested paths:

- `/health` confirms release `medusa-v1722-lifecycle-fix`.
- Wine, `wineboot`, `xvfb-run`, and `xauth` are detected by the running AMP instance.
- Startup prewarm is `ready=true` and `completed=true`.
- Medusa is advertised as `charId=15`.
- Normal matchmaking after prewarm with `charId=1` kept `charId=1`; it was not converted to Medusa and reached `GAME_STARTED` at `t+52.8s`.
- A custom Medusa match with `charId=15` started successfully.
- A custom Medusa match with `BotCount=2` showed in-game player counter `3` and a visible enemy model at the screen edge.
- Medusa spawned as `Char_Medusa(Clone)` / `[CodexVfx] Medusa`.
- Medusa was visible in match and used `MedusaBase`, `Medusa_Material_Native`, shader `Custom/Toon/Toon_Character_Amplify`, and animator controller `Medusa`.
- Runtime ability UI applied four Medusa-green entries.
- Native Medusa VFX were emitted for slots `0`, `1`, `2`, and `3`.
- Kitsu inherited shoot/VFX paths were suppressed for Medusa ability drivers.
- Server root and queue are clean after the latest test: no lobbies, no queue players.

## Live Version And Hashes

```text
release                  medusa-v1722-lifecycle-fix
packageBuildUtc          2026-06-09T00:58:10.3283631Z
BapCustomServer.dll      47316404CE1E4093F309FCA901F5AAE5EC8EAD8B2F985531278CCAF59FD20431
BapCustomServerMelon.dll 7C062B85E5ADF11E1A79492E4DA1DD21F43FA0C786CAF64214271FDFD5DC003E
BAPBAP.ModAPI.dll        0E14F39A9C47B6EBA106A0F23E76A0989B3270D7BCDD3E4BB0DD51E63BDB3CB5
BAPBAP.Medusa.dll        800D59FED09A2E531AE89C3680F0591338D03E0BBEB531FC707E1638BB5C09C1
medusa.bundle            C4872D6E124E76F9F4B4EC75482FFC2795D051D3CA65EB7C25E9FE68023B1D70
game exe                 7CF5E8746DEDD1B2183A8C5B733B06B394B667EF8F041831C293C27097B57EF0
start-match.sh           02E09C0B12716B296E275DCE50F4595ECC5FE24AD29A6406E2F318CEFF4049F3
Wine                     wine-10.0 (Debian 10.0~repack-6)
```

## Queue And Startup Fixes

The queue problem was not one single Medusa bug. It was a match-server lifecycle/startup problem:

- the server could clean a stale match entry before the fixed AMP ports were actually free;
- the next match could start too quickly on the same fixed ports;
- the repeated `/setup-game` polling made AMP console output look worse than the real root cause;
- a player could queue while startup prewarm was still running after deploy, making the first queue look slow.

Current v1722 fixes:

- `GameServerStopWaitMillis=5000` waits after killing a match process before fixed ports are reused.
- `GameServerPostCleanupStartDelayMillis=3000` adds a short delay after cleanup before starting a new custom or matchmaking server.
- startup prewarm is enabled and visible in `/health`;
- default queue map is clamped to map `1` instead of accidentally using map `4`;
- `HttpClient.game-server` connection-refused polling is filtered from normal AMP log spam;
- `/health` exposes Wine/Xvfb checks, queue timings, stop wait, post-cleanup delay, prewarm status, and artifact hashes.

The latest post-prewarm v1722 normal queue test reached `GAME_STARTED` at `t+52.8s`: 30 second queue timer plus 20.1 second server bootstrap. The server log shows one real game server attempt (`attempt 1/2`), not the old failed-first-attempt/requeue loop.

## Medusa Fixes

The active Medusa DLL is `v1.6.70`.

Important behavior now present:

- Medusa prefab registered with Mirror asset id `0x4D454455`.
- `charId=15` survives roster, queue, prematch, bootstrap, assign, spawn, and client network prefab resolution.
- Non-Medusa selections are recorded and restored so normal characters do not silently become Medusa.
- Medusa uses `skinAssetId=-1` to avoid base-skin fallback paths.
- Bundle visual is grafted with native toon material and Medusa animator.
- Visibility repair forces renderers/materials opaque and repairs CharAnimator bindings.
- Runtime Medusa FX are cleaned on scene reset and GameMode shutdown.
- Invalid animator layer writes/crossfades are guarded.
- Input fallback is restricted to the local Medusa entity.
- Duplicate cast drivers are debounced.
- Inherited Kitsu VFX references are suppressed.
- Native Medusa FX prefabs are loaded from `UserData\Medusa\medusa.bundle`.

Artwork included in the AMP/client package:

- `Spiel\Battleroyalebuild\UserData\Medusa\medusa-portrait.png`
- `Spiel\Battleroyalebuild\UserData\Medusa\medusa-wide.png`

## Evidence

Normal character control:

- run log: `C:\Users\Administrator\Downloads\CustomServer\logs\live-medusa-direct-20260609-031711.log`
- client log: `C:\Users\Administrator\Downloads\CustomServer\logs\live-medusa-direct-client-20260609-031711.log`
- screenshot: `C:\Users\Administrator\Downloads\CustomServer\logs\live-medusa-direct-20260609-031711-t10.png`

Proof points:

- test account: `codex-live-v177-20260609-031711`
- queue payload stayed `charId=1`
- `QUEUE_MATCHED` and `GAME_STARTED` at `t+52.8s`
- available characters included `0..15`
- no `OnCharacterChanged(1->15)` proof of forced Medusa conversion in this run

Medusa custom match and VFX:

- no-bot run directory: `C:\Users\Administrator\Downloads\CustomServer\logs\custom-medusa-vfx-v1708-20260609-030830`
- bot run directory: `C:\Users\Administrator\Downloads\CustomServer\logs\custom-medusa-vfx-v1708-20260609-032137`
- bot visual proof: `C:\Users\Administrator\Downloads\CustomServer\logs\custom-medusa-vfx-v1708-20260609-032137\slot0-left-1030ms.png`
- Medusa slot-3 visual proof: `C:\Users\Administrator\Downloads\CustomServer\logs\custom-medusa-vfx-v1708-20260609-032137\slot3-e-1030ms.png`

Proof points:

- custom games started in about `28.3s` to `28.6s`;
- `BotCount=2` visual run showed player counter `3` and a visible enemy model at the screen edge;
- `Char_Medusa(Clone)`;
- `[CodexVfx] Medusa`;
- `visualActive=True`;
- `MedusaBase`;
- `Medusa_Material_Native`;
- controller `Medusa`;
- runtime ability UI applied with `abilities=4 colors=medusa-green`;
- loaded VFX prefabs: `VFX_Medusa_Poison_Escape`, `Hit`, `Muzzle`, `Puddle`, `Trail`, `Wall`;
- slot `0`: muzzle, trail, hit;
- slot `1`: muzzle, trail, puddle;
- slot `2`: escape, trail, puddle;
- slot `3`: muzzle, wall, hit;
- logs report inherited Kitsu shoot suppressed.

## Remaining Risk

I would not call this a perfect first-party data backport. It is a modded native integration built from the owned client, backend, ModAPI, Medusa DLL, Medusa bundle, and runtime bridges.

The remaining weak proof area is normal in-game UI leave/cleanup. The automated tests kill or restart clients, so they do not fully prove that leaving through the normal UI clears every red outline/overlay symptom. Keep that as a manual regression check.

The bot visibility test has a useful screenshot, but the Medusa client diagnostic still reports only the local player in its `players=1` line. Treat the screenshot/player-counter evidence as visual proof, not as a fully instrumented network-entity audit.

## Completion Criteria

Treat the mission as complete when these stay true across repeated real-client tests:

- `/health` reports `medusa-v1722-lifecycle-fix` or a newer intentional release.
- Normal non-Medusa character selection still spawns non-Medusa.
- Medusa selected as `charId=15` spawns as Medusa, not Skinny.
- Medusa stays visible without repeated fade/despawn/respawn.
- Ability UI is Medusa-specific.
- Medusa native VFX appear for all ability slots.
- Kitsu inherited VFX are not visible for Medusa abilities.
- Queue reaches match without multi-minute dead first attempt after prewarm is ready.
- Leaving a match through normal UI does not leave old overlays.

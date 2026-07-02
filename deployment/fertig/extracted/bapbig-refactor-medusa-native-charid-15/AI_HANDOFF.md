# AI Handoff: Medusa Native Integration, Queue, AMP

Updated: 2026-06-09 03:35 +02:00, Europe/Berlin.

Workspace: `C:\Users\Administrator\Downloads\CustomServer`

Medusa source: `C:\Users\Administrator\Downloads\BAPBAPModdingAPI\medusa-mod`

Source mapping / ModAPI: `C:\Users\Administrator\Downloads\BAPBAPModdingAPI\BAPBAPModAPI`

## Current Live State

AMP is live on `medusa-v1722-lifecycle-fix`.

Verified through the running server:

- URL: `http://ark.atomi23.de:5055`
- release: `medusa-v1722-lifecycle-fix`
- package build UTC: `2026-06-09T00:58:10.3283631Z`
- Wine: `wine-10.0 (Debian 10.0~repack-6)`
- `wineboot`: available
- `xvfb-run` and `xauth`: available
- Medusa roster: enabled and available as `charId=15`
- queue timer: `30s`
- start attempts: `2`
- stop wait after match kill: `5000ms`
- post-cleanup start delay: `3000ms`
- startup prewarm: enabled and ready
- empty lobby cleanup: `15s`, or `45s` while a match client is still connected
- current root state: no lobbies
- current queue state: no queued players

Live hashes:

```text
BapCustomServer.dll      47316404CE1E4093F309FCA901F5AAE5EC8EAD8B2F985531278CCAF59FD20431
BapCustomServerMelon.dll 7C062B85E5ADF11E1A79492E4DA1DD21F43FA0C786CAF64214271FDFD5DC003E
BAPBAP.ModAPI.dll        0E14F39A9C47B6EBA106A0F23E76A0989B3270D7BCDD3E4BB0DD51E63BDB3CB5
BAPBAP.Medusa.dll        800D59FED09A2E531AE89C3680F0591338D03E0BBEB531FC707E1638BB5C09C1
medusa.bundle            C4872D6E124E76F9F4B4EC75482FFC2795D051D3CA65EB7C25E9FE68023B1D70
game exe                 7CF5E8746DEDD1B2183A8C5B733B06B394B667EF8F041831C293C27097B57EF0
start-match.sh           02E09C0B12716B296E275DCE50F4595ECC5FE24AD29A6406E2F318CEFF4049F3
```

## What Changed In v1722

Queue/start lifecycle:

- Added `GameServerStopWaitMillis` and `GameServerPostCleanupStartDelayMillis`.
- `GameServerProcessManager` now kills and waits for game server process exit before fixed AMP ports are considered reusable.
- `LobbyService` now waits briefly after stale match cleanup before starting the next custom or matchmaking server.
- Package/start scripts export the new lifecycle settings.
- `/health` reports both values.
- Startup prewarm remains enabled and visible in `/health`.
- The queue default map is clamped to map `1`.
- ASP.NET `HttpClient.game-server` info logging remains filtered so `/setup-game` connection-refused polling does not flood AMP console output.

Medusa/native:

- Active Medusa DLL is `v1.6.70`.
- Medusa registers as Mirror asset id `0x4D454455`.
- `charId=15` is preserved through queue, prematch, assign, and spawn.
- Non-Medusa selections are recorded and restored so normal characters are not silently converted to Medusa.
- Inherited Kitsu VFX references are suppressed on Medusa.
- Medusa runtime ability UI applies four Medusa-green ability entries.
- Native Medusa VFX are emitted for slots `0`, `1`, `2`, and `3`.
- Visibility repair forces Medusa renderers/materials opaque and rebinds `CharAnimator` to the Medusa animator.
- Runtime Medusa FX are cleaned on scene reset and GameMode shutdown.
- Invalid animator layer writes/crossfades are guarded.
- Input fallback is restricted to the local Medusa entity.
- Duplicate cast drivers are debounced.

## Current Proof

Normal character control, v1722:

- command:
  `powershell -NoProfile -ExecutionPolicy Bypass -File tools\Test-LiveMedusaQueueDirect.ps1 -BaseUrl http://ark.atomi23.de:5055 -GameHost ark.atomi23.de -CharacterId 1 -ObserveSeconds 12 -MatchEventTimeoutMs 180000 -KillFirst`
- run log:
  `C:\Users\Administrator\Downloads\CustomServer\logs\live-medusa-direct-20260609-031711.log`
- client log:
  `C:\Users\Administrator\Downloads\CustomServer\logs\live-medusa-direct-client-20260609-031711.log`
- screenshot:
  `C:\Users\Administrator\Downloads\CustomServer\logs\live-medusa-direct-20260609-031711-t10.png`
- result:
  `QUEUE_MATCHED`/`GAME_STARTED` at `t+52.8s`; payload stayed `charId=1`; available characters included `0..15`; server bootstrap took `20.1s` on attempt `1/2`; no forced Medusa conversion was observed.

Medusa custom VFX proof, v1722:

- command:
  `powershell -NoProfile -ExecutionPolicy Bypass -File tools\Test-LiveCustomMedusaVfx.ps1 -BaseUrl http://ark.atomi23.de:5055 -GameHost ark.atomi23.de -CharacterId 15 -MapId 1 -BotCount 0 -KillFirst`
- run directory:
  `C:\Users\Administrator\Downloads\CustomServer\logs\custom-medusa-vfx-v1708-20260609-030830`
- result:
  custom game started in about `28.3s`; Medusa spawned as `Char_Medusa(Clone)` / `[CodexVfx] Medusa`; `visualActive=True`; mesh `MedusaBase`; material `Medusa_Material_Native`; shader `Custom/Toon/Toon_Character_Amplify`; animator controller `Medusa`; runtime ability UI applied with `abilities=4 colors=medusa-green`.
- native FX:
  `VFX_Medusa_Poison_Muzzle`, `Trail`, `Hit`, `Puddle`, `Escape`, and `Wall` loaded and spawned; native cast FX emitted for slots `0`, `1`, `2`, and `3`; logs explicitly say inherited Kitsu shoot was suppressed.
- visual proof:
  `C:\Users\Administrator\Downloads\CustomServer\logs\custom-medusa-vfx-v1708-20260609-030830\slot3-e-180ms.png`

Medusa bot/enemy visual proof, v1722:

- command:
  `powershell -NoProfile -ExecutionPolicy Bypass -File tools\Test-LiveCustomMedusaVfx.ps1 -BaseUrl http://ark.atomi23.de:5055 -GameHost ark.atomi23.de -CharacterId 15 -MapId 1 -BotCount 2 -KillFirst`
- run directory:
  `C:\Users\Administrator\Downloads\CustomServer\logs\custom-medusa-vfx-v1708-20260609-032137`
- result:
  custom game started at `t+28.6s`; in-game player counter showed `3`; screenshots show Medusa visible, native Medusa VFX, and an enemy model at the screen edge.
- visual proof:
  `C:\Users\Administrator\Downloads\CustomServer\logs\custom-medusa-vfx-v1708-20260609-032137\slot0-left-1030ms.png`
- caveat:
  the Medusa diagnostic line still reports `players=1` for its local player list, so use this as visual proof, not as a complete network-entity audit.

## Important Caveats

- Visible clients still load and register Medusa globally even when selecting another character. That is expected. Check actual spawn, queue payload, screenshot, and absence of forced character change for non-Medusa proof.
- `ServicesInitializationException` from Unity Analytics, `WindowsVideoMedia` Wine warnings, shader warnings, and ALSA warnings still appear. They are environment noise unless they correlate with a broken match.
- UI leave/overlay cleanup through the normal in-game menu is still the weakest proof area. Automated tests kill/restart clients; a manual UI leave test should be kept as a regression check.
- `maxMatches=1` means an old visible test client or stale custom lobby can make the queue appear slow. Check `/`, `/api/queue/status`, and game logs before assuming matchmaking broke.
- The integration is modded-native, not a clean first-party ScriptableObject backport. Keep validating model, UI, VFX, normal character safety, and match cleanup together.

## Files To Preserve

Backend and deploy:

- `C:\Users\Administrator\Downloads\CustomServer\CustomMatchServer\CustomServerOptions.cs`
- `C:\Users\Administrator\Downloads\CustomServer\CustomMatchServer\GameServerProcessManager.cs`
- `C:\Users\Administrator\Downloads\CustomServer\CustomMatchServer\LobbyService.cs`
- `C:\Users\Administrator\Downloads\CustomServer\CustomMatchServer\Program.cs`
- `C:\Users\Administrator\Downloads\CustomServer\CustomMatchServer\appsettings.json`
- `C:\Users\Administrator\Downloads\CustomServer\tools\Build-AmpFullLinuxWinePackage.ps1`
- `C:\Users\Administrator\Downloads\CustomServer\tools\Invoke-AmpHotfixDeploy.ps1`

Client/Medusa:

- `C:\Users\Administrator\Downloads\CustomServer\BapCustomServerMelon\CustomServerMod.cs`
- `C:\Users\Administrator\Downloads\CustomServer\BapCustomServerMelon\dist\BapCustomServerMelon.dll`
- `C:\Users\Administrator\Downloads\BAPBAPModdingAPI\medusa-mod\MedusaMod.cs`
- `C:\Users\Administrator\Downloads\BAPBAPModdingAPI\medusa-mod\bin\Release\BAPBAP.Medusa.dll`
- `C:\Users\Administrator\Downloads\BAPBAPModdingAPI\medusa-mod\medusa.bundle`

## Useful Commands

Health:

```powershell
Invoke-RestMethod -Uri 'http://ark.atomi23.de:5055/health' -TimeoutSec 10 | ConvertTo-Json -Depth 8
```

Normal char control:

```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File .\tools\Test-LiveMedusaQueueDirect.ps1 -BaseUrl 'http://ark.atomi23.de:5055' -GameHost 'ark.atomi23.de' -CharacterId 1 -ObserveSeconds 12 -MatchEventTimeoutMs 180000 -KillFirst
```

Medusa VFX proof:

```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File .\tools\Test-LiveCustomMedusaVfx.ps1 -BaseUrl 'http://ark.atomi23.de:5055' -GameHost 'ark.atomi23.de' -CharacterId 15 -MapId 1 -BotCount 0 -KillFirst
```

Builds:

```powershell
dotnet build .\CustomMatchServer\BapCustomServer.csproj -c Release
dotnet build .\BapCustomServerMelon\BapCustomServerMelon.csproj -c Release
dotnet build C:\Users\Administrator\Downloads\BAPBAPModdingAPI\medusa-mod\BAPBAP.Medusa.csproj -c Release
```

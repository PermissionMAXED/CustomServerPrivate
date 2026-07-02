# Context: Medusa, Queue, AMP

Updated: 2026-06-09 03:35 +02:00.

## Paths

Main workspace:

- `C:\Users\Administrator\Downloads\CustomServer`

Medusa mod:

- `C:\Users\Administrator\Downloads\BAPBAPModdingAPI\medusa-mod`

Source mapping / ModAPI:

- `C:\Users\Administrator\Downloads\BAPBAPModdingAPI\BAPBAPModAPI`

Local game:

- `C:\Users\Administrator\Downloads\CustomServer\Spiel\Battleroyalebuild\bapbap.exe`

## Important Files

Backend:

- `C:\Users\Administrator\Downloads\CustomServer\CustomMatchServer\CustomServerOptions.cs`
- `C:\Users\Administrator\Downloads\CustomServer\CustomMatchServer\GameServerProcessManager.cs`
- `C:\Users\Administrator\Downloads\CustomServer\CustomMatchServer\LobbyService.cs`
- `C:\Users\Administrator\Downloads\CustomServer\CustomMatchServer\Program.cs`
- `C:\Users\Administrator\Downloads\CustomServer\CustomMatchServer\appsettings.json`

Client custom-server mod:

- `C:\Users\Administrator\Downloads\CustomServer\BapCustomServerMelon\CustomServerMod.cs`
- `C:\Users\Administrator\Downloads\CustomServer\BapCustomServerMelon\dist\BapCustomServerMelon.dll`

Medusa:

- `C:\Users\Administrator\Downloads\BAPBAPModdingAPI\medusa-mod\MedusaMod.cs`
- `C:\Users\Administrator\Downloads\BAPBAPModdingAPI\medusa-mod\BAPBAP.Medusa.csproj`
- `C:\Users\Administrator\Downloads\BAPBAPModdingAPI\medusa-mod\medusa.bundle`

Deploy/test:

- `C:\Users\Administrator\Downloads\CustomServer\tools\Build-AmpFullLinuxWinePackage.ps1`
- `C:\Users\Administrator\Downloads\CustomServer\tools\Invoke-AmpHotfixDeploy.ps1`
- `C:\Users\Administrator\Downloads\CustomServer\tools\Start-AmpApp.ps1`
- `C:\Users\Administrator\Downloads\CustomServer\tools\Test-LiveMedusaQueueDirect.ps1`
- `C:\Users\Administrator\Downloads\CustomServer\tools\Test-LiveCustomMedusaVfx.ps1`

## Current Live AMP State

Endpoint:

- `http://ark.atomi23.de:5055`

Release:

- `medusa-v1722-lifecycle-fix`

Health highlights:

```text
wineAvailable=true
winePath=/usr/bin/wine
wineVersion=wine-10.0 (Debian 10.0~repack-6)
winebootAvailable=true
xvfbRunAvailable=true
xauthAvailable=true
queueTimerSeconds=30
gameServerReadyTimeoutSeconds=300
gameServerManagedBootstrapStatusTimeoutSeconds=90
effectiveGameServerManagedBootstrapListenerOnlyTimeoutSeconds=30
gameServerStartAttempts=2
gameServerStopWaitMillis=5000
gameServerPostCleanupStartDelayMillis=3000
gameServerPrewarmOnStartup=true
gameServerPrewarmTimeoutSeconds=180
gameServerPrewarmMatchWaitSeconds=35
emptyLobbyMatchCleanupGraceSeconds=15
emptyLobbyMatchConnectedCleanupGraceSeconds=45
prewarm.state=ready
prewarm.ready=true
prewarm.completed=true
```

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

Root endpoint currently reports no lobbies. Queue status currently reports `playerCount=0`, `isActive=false`.

## Technical Decisions

Medusa identity:

- char id: `15`
- Mirror asset id: `0x4D454455`

Selection:

- Medusa is normal selectable data, not an unconditional forced local override.
- Non-Medusa selections are recorded by player/account and restored before prematch assign and spawn.
- Medusa uses `skinAssetId=-1` to avoid base skin fallback paths.

Prefab:

- Medusa is cloned from a known base character and then the bundle visual, native material, animator, and ability bridges are grafted.
- Visible clients register Medusa through `NetworkManager.spawnPrefabs`.
- Dedicated/batchmode server can patch the network prefab pool.

Ability/VFX:

- Medusa ability display data is runtime-patched.
- Inherited Kitsu VFX references are suppressed.
- Native Medusa bundle FX are spawned for cast feedback.
- Slots currently proven: `0`, `1`, `2`, `3`.

Queue/start:

- The startup problem included Wine/Unity cold start, occasional blank wrapper-only processes, fixed AMP port reuse, and connection-refused log noise while `/setup-game` was not ready.
- v1722 waits up to `5000ms` after killing a match server before reusing fixed ports.
- v1722 waits `3000ms` after stale match cleanup before starting the next game server.
- Startup prewarm is enabled and exposed in `/health`.
- Empty matches are pruned before capacity checks to avoid old tests blocking `maxMatches=1`.
- `HttpClient.game-server` info logs are filtered so connection-refused polling does not dominate AMP console output.

## Latest Validation

Normal character:

- command: `powershell -NoProfile -ExecutionPolicy Bypass -File tools\Test-LiveMedusaQueueDirect.ps1 -BaseUrl http://ark.atomi23.de:5055 -GameHost ark.atomi23.de -CharacterId 1 -ObserveSeconds 12 -MatchEventTimeoutMs 180000 -KillFirst`
- run: `C:\Users\Administrator\Downloads\CustomServer\logs\live-medusa-direct-20260609-031711.log`
- client: `C:\Users\Administrator\Downloads\CustomServer\logs\live-medusa-direct-client-20260609-031711.log`
- screenshot: `C:\Users\Administrator\Downloads\CustomServer\logs\live-medusa-direct-20260609-031711-t10.png`
- result: payload stayed `charId=1`, `QUEUE_MATCHED`/`GAME_STARTED` at `t+52.8s`, server bootstrap took `20.1s` on attempt `1/2`, no forced Medusa conversion.

Medusa:

- command: `powershell -NoProfile -ExecutionPolicy Bypass -File tools\Test-LiveCustomMedusaVfx.ps1 -BaseUrl http://ark.atomi23.de:5055 -GameHost ark.atomi23.de -CharacterId 15 -MapId 1 -BotCount 0 -KillFirst`
- dir: `C:\Users\Administrator\Downloads\CustomServer\logs\custom-medusa-vfx-v1708-20260609-030830`
- screenshot: `C:\Users\Administrator\Downloads\CustomServer\logs\custom-medusa-vfx-v1708-20260609-030830\slot3-e-180ms.png`
- result: Medusa visible, `visualActive=True`, animator `Medusa`, material `Medusa_Material_Native`, VFX for all slots, Kitsu shoot suppressed.

Medusa with bots:

- command: `powershell -NoProfile -ExecutionPolicy Bypass -File tools\Test-LiveCustomMedusaVfx.ps1 -BaseUrl http://ark.atomi23.de:5055 -GameHost ark.atomi23.de -CharacterId 15 -MapId 1 -BotCount 2 -KillFirst`
- dir: `C:\Users\Administrator\Downloads\CustomServer\logs\custom-medusa-vfx-v1708-20260609-032137`
- screenshots: `slot0-left-1030ms.png`, `slot3-e-1030ms.png`
- result: Medusa visible, native VFX for slots `0..3`, in-game player counter `3`, visible enemy model at screen edge. Client diagnostic still reports `players=1` for the local player list, so this is visual proof rather than a complete entity-list audit.

## Useful Commands

Health:

```powershell
Invoke-RestMethod -Uri 'http://ark.atomi23.de:5055/health' -TimeoutSec 10 | ConvertTo-Json -Depth 8
```

Server log tail:

```powershell
Invoke-RestMethod -Uri 'http://ark.atomi23.de:5055/api/diagnostics/server-log?tail=320' -TimeoutSec 10
```

Game log tail:

```powershell
Invoke-RestMethod -Uri 'http://ark.atomi23.de:5055/api/diagnostics/game-logs?tailLines=80&files=8' -TimeoutSec 10
```

Normal char control:

```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File .\tools\Test-LiveMedusaQueueDirect.ps1 -BaseUrl 'http://ark.atomi23.de:5055' -GameHost 'ark.atomi23.de' -CharacterId 1 -ObserveSeconds 12 -MatchEventTimeoutMs 180000 -KillFirst
```

Medusa VFX proof:

```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File .\tools\Test-LiveCustomMedusaVfx.ps1 -BaseUrl 'http://ark.atomi23.de:5055' -GameHost 'ark.atomi23.de' -CharacterId 15 -MapId 1 -BotCount 0 -KillFirst
```

Build and deploy:

```powershell
dotnet build .\CustomMatchServer\BapCustomServer.csproj -c Release
powershell -NoProfile -ExecutionPolicy Bypass -File .\tools\Build-AmpFullLinuxWinePackage.ps1 -ReleaseLabel medusa-v1722-lifecycle-fix
powershell -NoProfile -ExecutionPolicy Bypass -File .\tools\Invoke-AmpHotfixDeploy.ps1 -ZipPath C:\Users\Administrator\Downloads\CustomServer\deployment\amp-full-linux-wine\bapcustomserver-amp-full-linux-wine.zip -RemoteZipPath bapcustomserver-amp-full-linux-wine-v1722-lifecycle-fix.zip
```

## Pitfalls

- Do not count Medusa lobby/menu registration logs as spawn proof. Spawn proof is `Char_Medusa(Clone)` plus screenshot or live diagnostics.
- Do not confuse another AI's BAPBAP client/mod with this test client.
- `maxMatches=1` can make queue look stuck if an old visible test client or stale custom match is still occupying the slot.
- A first queue right after deploy can be slow while startup prewarm is still running.
- Unity Analytics, WindowsVideoMedia, shader, and ALSA warnings are expected Wine/Linux noise unless they correlate with a broken match.
- Keep normal non-Medusa control tests around; this integration touches shared prematch/spawn paths.

# BAP Custom Server Project

This workspace contains the custom server stack, client routing tools, and a MelonLoader mod for selecting a custom server from inside the game.

## Components

- `CustomMatchServer`: ASP.NET Core lobby/match server for Linux deployment.
- `CustomClientProxy`: external Windows proxy/launcher-style tool for routing the game client to a custom server.
- `BapCustomServerMelon`: in-game MelonLoader mod with per-device `%APPDATA%\BAPBAPBATTLEROYALE\BapCustomServer.ini`, a native Unity IP/port panel, first-start identity setup, account identity headers, match bootstrap hooks, and an embedded HTTP/WebSocket reverse proxy.
- `deployment/amp-github-autoinstall`: recommended CubeCoders AMP Generic-module template for Linux web-panel installs. It downloads the full Linux/Wine package from a GitHub Release.
- `tools/Set-CustomApiHost.ps1`: binary asset patch helper for setting the game's API host.
- `tools/Install-BapCustomServerMelon.ps1`: builds and copies the MelonLoader mod into the game `Mods` folder.

## Build everything

```powershell
dotnet build C:\Users\Administrator\Downloads\CustomServer\CustomMatchServer\BapCustomServer.csproj -c Release
dotnet build C:\Users\Administrator\Downloads\CustomServer\CustomClientProxy\CustomClientProxy.csproj -c Release
dotnet build C:\Users\Administrator\Downloads\CustomServer\BapCustomServerMelon\BapCustomServerMelon.csproj -c Release
C:\Users\Administrator\Downloads\CustomServer\tools\Install-BapCustomServerMelon.ps1
C:\Users\Administrator\Downloads\CustomServer\tools\Build-AmpPackage.ps1
```

## Smoke test

```powershell
C:\Users\Administrator\Downloads\CustomServer\tools\Test-CustomServerSmoke.ps1
C:\Users\Administrator\Downloads\CustomServer\tools\Test-LobbySettingsSmoke.ps1
C:\Users\Administrator\Downloads\CustomServer\tools\Test-AdminControlsSmoke.ps1
C:\Users\Administrator\Downloads\CustomServer\tools\Test-MatchStartTwoClientSmoke.ps1
```

Expected checks:

- direct server `/health`
- direct server socket discovery
- direct server WebSocket connect
- external proxy `/health`
- external proxy socket rewrite to `ws://127.0.0.1:5055/ws`
- external proxy WebSocket connect
- first-client lobby join
- custom settings update for mode, map, team size, max teams, bot count, bot difficulty, modifier IDs, dimensions, matchmaking mode, and timers
- admin grant persistence, ban/unban blocking, and audit logs

Full local hosted match smoke:

```powershell
C:\Users\Administrator\Downloads\CustomServer\tools\Test-MatchStartSmoke.ps1 `
  -ServerPort 5157 `
  -LaunchGameServers:$true `
  -RequireGameServerBootstrap:$true `
  -GameServerReadyTimeoutSeconds 150 `
  -AdditionalGameArguments '--melonloader.debug --melonloader.captureplayerlogs --melonloader.agfoffline --bapcustom-auto-end-after=3' `
  -LaunchAutoJoinClient:$true `
  -WaitForGameEnded:$true `
  -GameEndedTimeoutSeconds 90
```

The two-client smoke starts two WebSocket lobby clients and two auto-join game clients in the same match.

## AMP package

The older direct AMP package is generated at:

`C:\Users\Administrator\Downloads\CustomServer\deployment\amp\bapcustomserver-amp-instance.zip`

It includes the AMP template files plus `server\win-x64\BapCustomServer` and `server\linux-x64\BapCustomServer`.

For the proven live Linux setup, use the GitHub AutoInstall package instead.

## AMP GitHub AutoInstall

Recommended for web-panel-only Linux AMP setups:

`https://github.com/Sonic0810/BAPBAP-CustomServer-AMPTemplates`

Add that as an AMP remote configuration source, refresh templates, create a new instance from `BAPBAP Custom Server GitHub AutoInstall`, press `Update`, then press `Start`.

The remote repository uses root-level AMP template files and an AMP-style include:

```text
App.UpdateSources=@IncludeJson[bapcustomservergithubupdates.json]
```

It also includes a root `manifest.json`, matching the AMP custom-template
repository flow used by CubeCoders and the working `BAPBAPRelay-AMP` repo.

The update stage downloads the full package from the public GitHub Release:

`bapcustomserver-amp-full-linux-wine.zip`

That package contains the Linux ASP.NET server, the Windows game files, Wine launch scripts, MelonLoader, the mod DLL, and `Mods\BapCustomServer.ini`. If AMP logs `No stash entries found` while updating the remote source, that line alone is not a failure; it means AMP had no cached stash to restore.

Current proven live release:

```text
bapcustomserver-20260530-cleanlogs
```

The final AMP/Linux/Wine root cause and runbook are documented in
`docs/AMP_LINUX_WINE_ROOT_CAUSE.md`.

## Run the Linux server

Use the published Linux build from:

`C:\Users\Administrator\Downloads\CustomServer\CustomMatchServer\publish\linux-x64\BapCustomServer`

The server exposes lobby HTTP routes, socket discovery, and `/ws` for WebSocket lobby traffic. See `CustomMatchServer\README.md` for deployment settings.

## How to host matches: Custom Match vs Matchmaking

The custom server supports two ways to start a match. Both end with the same outcome (a real BAPBAP match running on the configured ports), but the player flow is different.

### Custom Match (private game, host-controlled)

Use this when a host wants to start a match for themselves and friends without going through the public queue.

1. Players launch the modded BAPBAP client. The mod points the client at your custom server and shows the normal main menu lobby.
2. The lobby leader opens the `PLAY` tab and configures the lobby (mode, map, team size, bots, modifiers). All settings come from the lobby panel and override the defaults.
3. Friends join the lobby via lobby code (`JOIN_LOBBY` event with the 6-char code) or party invite.
4. The leader presses `READY/PLAY` once the lobby is set. The mod sends `START_CUSTOM_GAME` (with `forceStart=true` if the leader is admin and wants to skip queue countdown).
5. The server fires `START_CUSTOM_GAME_SUCCESS` -> `QUEUE_MATCHED` -> spawns the dedicated match process -> broadcasts `GAME_STARTED` to every connection in the lobby.
6. All clients transition to char select (20s), spawn select (10s), then the match begins.

WebSocket sequence on the leader's connection:

```text
JOIN_LOBBY             -> JOIN_LOBBY_SUCCESS
UPDATE_CUSTOM_SETTINGS -> UPDATE_CUSTOM_SETTINGS_SUCCESS
START_CUSTOM_GAME      -> START_CUSTOM_GAME_SUCCESS -> QUEUE_MATCHED -> GAME_STARTED
```

Admin override: any account in `CustomServer:Admin:AdminAccountIdsCsv` can send `START_CUSTOM_GAME` with `forceStart=true` to skip the queue countdown for instant start. The script `tools\Force-StartMatch.ps1` does exactly this from outside the game for testing.

### Matchmaking (public queue, server-controlled)

Use this when players want to drop into a match without coordinating a lobby.

1. Player launches the modded client and reaches the lobby.
2. Player presses the matchmaking entry (queue) button. The client sends `POST /api/queue/join` with their account and chosen char.
3. Server starts a 30-second queue timer (configurable via `CustomServer:MatchmakingQueue:QueueTimerSeconds`).
4. While the timer runs, more players can join. The minimum to start is 1 (`MinPlayersToStart`); bots fill the remaining slots according to `DefaultBotCount` and `DefaultBotDifficulty`.
5. When the timer hits zero, `MatchmakingHostedService` calls `LobbyService.StartMatchmakingGameAsync`, which uses the same flow as a custom match: spawn a dedicated game process, then broadcast `GAME_STARTED` to every queued player.
6. All clients transition to char select -> spawn select -> match.

HTTP sequence:

```text
POST /api/queue/join   -> { ok:true, position, secondsRemaining }
GET  /api/queue/status -> { playerCount, secondsRemaining, isActive, players }
POST /api/queue/leave  -> { ok:true }
```

After the timer expires, the player's existing WebSocket lobby connection receives `GAME_STARTED` automatically.

### Comparison

| Aspect | Custom Match | Matchmaking |
|---|---|---|
| Trigger | Leader presses PLAY in lobby | Server timer fires after first queue join |
| Settings come from | Leader's lobby panel | `CustomServer:MatchmakingQueue:Default*` |
| Start condition | Leader ready (or admin force) | Timer (default 30s) + min players |
| Map selection | Leader chooses map ID | Server picks from `MapMapping` for the configured `DefaultGameMode` |
| Team composition | Leader-defined teams | Server splits queue into balanced teams |
| Bots | `BotTeams` from lobby setting | `DefaultBotCount` from server config |
| Char select phase | 20s in-match | 20s in-match |

Both paths converge on the same `LobbyService.StartCustomGameAsync` / `StartMatchmakingGameAsync` flow which spawns the dedicated game server, calls bootstrap (`/setup-game`, `/add-teams`, `/queue-matched`), and broadcasts `GAME_STARTED` to all participants.

### Random map per match

To rotate maps automatically:

- AMP panel -> `Custom Match Settings` -> `Random Maps (Map Mapping JSON)` -> set to e.g. `[{"UnityGameModeId":0,"MapIds":[1,2,3]}]`. The server picks one MapId from the list when `GAME_STARTED` is sent.
- Defaults to `[{"UnityGameModeId":0,"MapIds":[1]},{"UnityGameModeId":1,"MapIds":[1]}]` (Bazaarcity for both modes).

### Available characters

To restrict the character pool:

- AMP panel -> `Custom Match Settings` -> `Available Character IDs` -> e.g. `1,5,8,11,12` for those five chars only.
- Defaults to `0,1,2,3,4,5,6,7,8,9,10,11,12,13,14` (all 15 chars).

### Currency, Economy, Ranked

- AMP panel -> `Unlocks` -> `Unlock Everything = true` makes every cosmetic appear owned and grants the configured `Currency Balance` for every `Currency Asset ID`. Recommended on private servers.
- AMP panel -> `Economy` -> tune `Win Gold`, `Kill Gold`, `Placement Gold` (CSV by placement), `Participation Gold`, `Starting Gold`.
- AMP panel -> `Ranked` -> tune `Placement Ranked Points` (CSV), `Kill Ranked Points`, `Loss Ranked Points`, `Min Floor`, `Starting Points`.

### Admin commands and force-start

The local script `tools\Force-StartMatch.ps1` covers the admin path end-to-end:

1. `POST /admin/commands { command: grant-admin, accountId: ... }` (loopback only, no token required by default).
2. Connect a second WebSocket as the now-admin account.
3. `JOIN_LOBBY` -> `UPDATE_CUSTOM_SETTINGS` -> `START_CUSTOM_GAME { forceStart: true }`.
4. Wait up to 180s for `GAME_STARTED` (server takes ~60s to spawn and bootstrap a fresh dedicated process).

This is the path used by `tools\Run-RealMatchTest.ps1` to run automated end-to-end smoke tests with screenshots.


## Run with the MelonLoader mod

Ready-made player package:

`C:\Users\Administrator\Downloads\CustomServer\deployment\client-mod-package\bapcustomserver-client-mod.zip`

It contains the current `BapCustomServerMelon.dll`, `BapCustomServer.sample.ini`, `MelonLoader.v0.7.2.x86.zip`, and `README-CLIENT-INSTALL.md`.

1. Install MelonLoader 0.7.x into:
   `C:\Users\Administrator\Downloads\CustomServer\Spiel\Battleroyalebuild`
2. Ensure the mod DLL exists at:
   `C:\Users\Administrator\Downloads\CustomServer\Spiel\Battleroyalebuild\Mods\BapCustomServerMelon.dll`
3. Edit or create the per-device config:
   `%APPDATA%\BAPBAPBATTLEROYALE\BapCustomServer.ini`
4. Minimal client config:

```ini
[Server]
Host=YOUR_SERVER_IP_OR_DNS
Port=5055
UseHttps=false
UseLocalProxy=true
LocalProxyPort=5055

[Identity]
AccountId=
Username=
AutoGuestLogin=true
```

5. Start the game. If `AccountId` or `Username` is empty, the mod shows a native `Custom Server Setup` panel, asks for a player name, generates a local `custom-...` account ID, saves both values to `%APPDATA%\BAPBAPBATTLEROYALE\BapCustomServer.ini`, then relaunches the game once so the saved custom-server session is used by the original login startup path.
6. Optional: press `F7` to inspect/change the same settings and save them back to the ini.
7. Optionally set account identity in the ini or with launch args: `--bapcustom-account-id=<id>` and `--bapcustom-username=<name>`.
8. To show the first-start setup again, clear either `AccountId` or `Username` in `%APPDATA%\BAPBAPBATTLEROYALE\BapCustomServer.ini` and restart the game.

## Client startup proof

Refreshed on 2026-05-17 against the workspace game copy and local server on `127.0.0.1:5163`.

- Setup screen proof: `logs\runtime-first-start-relaunch-final-setup-printwindow.png`
- Final lobby proof after automatic relaunch: `logs\runtime-first-start-relaunch-final-lobby-printwindow.png`
- AppData first-start setup proof: `Spiel\Battleroyalebuild\MelonLoader\Latest.log` logged `Loaded custom server ini: C:\Users\Administrator\AppData\Roaming\BAPBAPBATTLEROYALE\BapCustomServer.ini`, `Created first-start custom-server identity: appdata1 (custom-7fe0915bc438)`, and `Primed BAPBAP auto-login prefs for custom server guest session: bapcustom-custom-7fe0915bc438`.
- Generated identity in the per-device AppData ini: `AccountId=custom-7fe0915bc438`, `Username=appdata1`.
- Second-start auth bypass proof: `logs\runtime-appdata-secondstart-player.log` contains `STEAM: Steam unavailable`, `Opening Lobby UI :)`, and player/lobby JSON for `custom-7fe0915bc438` / `appdata1`.
- Melon log proof: `Custom-server load response handled by LoginController: accountId=custom-7fe0915bc438 username=appdata1 isGuest=False isCompleted=True blocked=False`.
- Full match proof after the AppData change: `tools\Test-MatchStartSmoke.ps1` returned `terminalEvent=GAME_STARTED`, `seenEvents=["START_CUSTOM_GAME_SUCCESS","QUEUE_MATCHED","GAME_STARTED"]`, `gameEndedObserved=true`, and `postGameMatches=[]` for `custom-20260517212630-3904`.
- Current AMP/client proof: the live `bapcustomserver-20260530-cleanlogs` release and client bundle contain `BapCustomServerMelon.dll` with SHA256 `035F05098CD3A413B79A51530099D5C68754A28256C5AA09C50994CE0DEF40A5`.
- Negative checks: the final AppData second-start run did not show the old provider-selection prompt in the captured markers. One nonfatal `UILobbyCharacterSelectPage.GetCharacterListingIndexFromCharId` `NullReferenceException` still logs during delayed character data refresh, but it no longer blocks entry into the lobby.

## AMP Analytics

The server emits player and match events as plain ASP.NET Core log lines so AMP's built-in `AnalyticsPlugin` can scrape them with no extra agent. The AMP Generic-module template wires those lines to AMP's session tracker through `GenericModule.App.OnlineRegex` / `OfflineRegex` in `bapcustomservergithub.kvp`:

```text
[Analytics] Player joined: <username> (accountId=<id>)
[Analytics] Player left:   <username> (accountId=<id>)
[Analytics] Match started: <gameId> mapId=<n> players=<n>
[Analytics] Match ended:   <gameId>
```

AMP turns the join/leave matches into the live player count graph and the start/end matches into match count metrics. Toggle off by setting `CustomServer:Analytics:Enabled=false` (or unsetting the `OnlineRegex` / `OfflineRegex` keys in the AMP instance config). See `deployment/AMP_ADMIN_README.md` for the operator view.

## Shop asset IDs

ShopSlot AssetId fields in the AMP UI are free-form numeric inputs. The full ID list (skins, banners, emotes, mastery badges, tombstones) lives in `BAPBAP-Asset-Reference.md` at the workspace root, generated from `data/asset-index.json` via `tools\Generate-AssetReference.ps1`. Treat that file as the source of truth.

Do not use AssetIds `300001`, `300004`, or `300006` in any shop slot — those entries crash the in-game locker UI on open. Pick any other ID from the reference file.

## Reality check

The project now has Windows and Linux ASP.NET custom server publishes, an external proxy, a real MelonLoader mod for IP/port and first-start account setup, client traffic routing, Wine/Xvfb match-host bootstrap on Linux AMP, admin/banning/command endpoints, audit logs, and a GitHub AutoInstall AMP package. The verified live AMP path launches the supplied Windows `bapbap.exe` through `start-match.sh`, injects match bootstrap payloads through the mod, reaches a real match, exits to lobby, and cleans up the launched match process.

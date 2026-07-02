# BAPBAP Custom Match Server

This is a standalone ASP.NET Core custom lobby and matchmaker for the extracted BAPBAP build in this workspace.

It does not rebuild the AssetRipper Unity project. The exported C# files are mostly IL2CPP stubs, so the safe integration point is the existing runtime protocol:

- HTTP socket discovery returns `socketUrl`.
- WebSocket lobby events use the game's existing uppercase event names, for example `JOIN_LOBBY`, `UPDATE_CUSTOM_SETTINGS`, `START_CUSTOM_GAME`, `QUEUE_MATCHED`, and `GAME_STARTED`.
- When a custom game starts, the server can launch `Spiel/Battleroyalebuild/bapbap.exe` with `-httpport=`, `-wsport=`, `-kcpport=`, and `-tcpport=` arguments and then sends every client the selected `gameDns` and ports.
- Match start is fail-closed by default: `RequireGameServerBootstrap=true` prevents the lobby from reporting a started match unless the Unity match process accepts `/setup-game`, `/add-teams`, and `/queue-matched`.

## Run

```powershell
dotnet run --project .\CustomMatchServer\BapCustomServer.csproj
```

Default API base URL:

```text
http://127.0.0.1:5055
```

Useful endpoints:

- `GET /health`
- `GET /api/lobby/socket`
- `GET /api/lobbies/socket`
- `GET /admin/lobbies`
- `GET /admin/matches`
- `GET /admin/state`
- `GET /admin/logs/audit`
- `POST /admin/commands`
- `WS /ws`

Admin endpoints require `X-BAP-Admin-Token` when `CustomServer:Admin:ApiToken` is configured. If no token is configured, admin endpoints are loopback-only by default for local testing.

## Linux hosting

The ASP.NET Core lobby/matchmaker runs on Linux. A Linux build is already published in this workspace at `CustomMatchServer/publish/linux-x64`.

Publish it again with:

```bash
dotnet publish CustomMatchServer/BapCustomServer.csproj -c Release -o /opt/bapbap/custom-match-server
```

Example Linux deployment files are in `deployment/linux`:

- `custom-match-server.env.example`
- `custom-match-server.service`

The provided game binary is a Windows Unity build. The current proven AMP path
runs it on Linux through Wine and Xvfb, not through a native Linux Unity
dedicated binary. Use the full AMP Linux/Wine package and keep:

```bash
CustomServer__GameLauncherPath=./start-match.sh
CustomServer__GameLauncherArguments="\"{gameExecutable}\" {gameArguments}"
CustomServer__RequireGameServerBootstrap=true
```

`start-match.sh` is the required wrapper. It initializes a 32-bit Wine prefix,
runs the Windows build under `xvfb-run`, defaults Unity to `-nographics`, and
logs Wine/Xvfb/Mesa diagnostics before the match process starts.

The bootstrap listener is opened by the Melon mod inside the Windows Unity
process. Match start remains fail-closed: if `/setup-game`, `/add-teams`, or
`/queue-matched` cannot be accepted, the lobby requeues players instead of
sending them into dead match ports.

For raw/manual Wine testing on Linux, configure:

```bash
CustomServer__GameLauncherPath=wine
CustomServer__GameLauncherArguments="\"{gameExecutable}\" {gameArguments}"
CustomServer__GameExecutablePath=/opt/bapbap/build/bapbap.exe
CustomServer__GameWorkingDirectory=/opt/bapbap/build
```

## Point the local build at this server

The extracted Windows build contains the production API host as a fixed-size string. For local testing, this replacement has the same byte length:

```powershell
.\tools\Set-CustomApiHost.ps1 -ApiHost "http://127.0.0.1:5055"
```

The script backs up each patched binary asset once as `*.bak`.

For a remote host, the replacement must be exactly 21 ASCII bytes when patching binary assets. If it is not, use `-SkipBinaryPatch` and patch/rebuild the Unity project instead:

```powershell
.\tools\Set-CustomApiHost.ps1 -ApiHost "http://10.0.0.10:5055" -SkipBinaryPatch
```

## Configuration

Edit `appsettings.json` or use environment variables with the `CustomServer__` prefix.

Important values:

- `CustomServer:PublicBaseUrl`: URL clients use for HTTP and WebSocket discovery.
- `CustomServer:PublicGameHost`: hostname sent in `GAME_STARTED`.
- `CustomServer:LaunchGameServers`: when `true`, this service starts a game process per match.
- `CustomServer:GameExecutablePath`: path to `bapbap.exe`.
- `CustomServer:HeadlessArguments`: game process command-line template.
- `CustomServer:RequireGameServerBootstrap`: when `true`, match start fails if the game process does not accept inferred bootstrap POSTs.
- `CustomServer:Admin:ApiToken`: token for remote admin commands.
- `CustomServer:Admin:AdminAccountIdsCsv`: account IDs that receive `isAdmin=true`.
- `CustomServer:Admin:BannedAccountIdsCsv`: account IDs blocked from login and lobby sockets.
- `CustomServer:MatchDefaults:GameModifierIdsCsv`: comma-separated game modifier IDs for new matches.
- `CustomServer:MatchDefaults:DimensionDataJson`: JSON array for advanced dimension defaults.
- `CustomServer:MapPool:*`: AMP-facing map toggles. The current canonical map IDs are `1=Map2_BazaarCity 3`, `2=Map3_Lyceum`, `3=Arena_Map2`, and `4=OpenBetaMap#J02_P_Boccato`.

For each match the server resolves one authoritative map ID, sends it to the game process in `/setup-game`, sends the same value to players as `QUEUE_MATCHED.levelId`, and includes it in `GAME_STARTED.mapId` for test/diagnostic parity.

Admin command payload examples:

```json
{"command":"grant-admin","accountId":"custom-user-1"}
{"command":"ban","accountId":"custom-user-2","reason":"rule violation"}
{"command":"kick","accountId":"custom-user-2","reason":"admin kick"}
{"command":"stop-match","gameId":"custom-20260504113639-7053"}
```

The internal bootstrap paths are inferred from the IL2CPP metadata:

- `/setup-game`
- `/add-teams`
- `/queue-matched`

If the build uses different paths, adjust `BootstrapConnectPath`, `BootstrapAddTeamsPath`, and `BootstrapQueueMatchedPath`.

## Client proxy for IP:port entry

The local build was patched to call `http://127.0.0.1:5055`. To let players enter a remote server IP without repatching the binary for each server, run the client proxy:

```powershell
.\CustomClientProxy\publish\win-x64\BapCustomClientProxy.exe 203.0.113.10:5055
```

Keep that window open and then start the game. The proxy forwards HTTP and WebSocket traffic from `127.0.0.1:5055` to the entered custom server.

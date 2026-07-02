# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## What this is

A custom private-server stack for the IL2CPP Unity game **BAPBAP Battle Royale**. The original game's
exported C# is mostly IL2CPP stubs, so nothing here rebuilds the game. Instead the project re-implements
the game's **runtime HTTP/WebSocket protocol** in a standalone ASP.NET server, and uses a MelonLoader mod
to point unmodified game clients at that server. There are three shipping .NET projects:

- **`CustomMatchServer/`** (`BapCustomServer.csproj`, **net10.0**, ASP.NET Core) — the lobby/matchmaker
  server. Runs on Linux (production via AMP) or Windows. Speaks the game's uppercase WebSocket lobby
  events and the HTTP auth/metagame endpoints, and launches a dedicated match process per match.
- **`BapCustomServerMelon/`** (`BapCustomServerMelon.csproj`, **net6.0 / x86**, MelonLoader + Unity refs) —
  the in-game client mod. Routes the client's API + WebSocket traffic to the custom server, handles
  first-start guest identity, and runs an in-process reverse proxy. Single DLL, ships to both clients
  **and** the dedicated match host.
- **`CustomClientProxy/`** (net10.0) — a standalone Windows HTTP/WS forwarder so players can target a
  remote server IP without re-patching the game binary.

The game binary itself lives under `Spiel/Battleroyalebuild/` (gitignored, too large for Git).

## Build & run

```bash
# Server (primary project)
dotnet build CustomMatchServer/BapCustomServer.csproj -c Release
dotnet run   --project CustomMatchServer/BapCustomServer.csproj      # serves http://127.0.0.1:5055

# Client mod (must target net6/x86 — do not retarget)
dotnet build BapCustomServerMelon/BapCustomServerMelon.csproj -c Release

# Client proxy
dotnet build CustomClientProxy/CustomClientProxy.csproj -c Release
```

`dotnet --version` here is .NET 10. The Melon mod references Unity DLLs under
`AssetRip/AuxiliaryFiles/GameAssemblies/` — that directory must be present to build it.

Helper scripts (all PowerShell, in `tools/`):

- `Install-BapCustomServerMelon.ps1` — build the mod and copy it into the game `Mods/` folder.
- `Build-AmpPackage.ps1`, `Build-AmpFullLinuxWinePackage.ps1`, `Build-AmpGitHubAutoInstallPackage.ps1` —
  produce the AMP deployment packages.
- `Set-CustomApiHost.ps1` — binary-patch the game's hardcoded API host (21-byte fixed-size string).

## Tests / smoke

There is **no xUnit/NUnit suite**. Verification is done with PowerShell smoke scripts under `tools/`
that drive a live server + WebSocket clients end-to-end. Run a single scenario by invoking its script:

```powershell
tools/Test-CustomServerSmoke.ps1          # health, socket discovery, WS connect, lobby join
tools/Test-LobbySettingsSmoke.ps1         # custom-settings updates
tools/Test-AdminControlsSmoke.ps1         # grant/ban/kick + audit log
tools/Test-MatchStartSmoke.ps1            # full hosted match (launches a real game process)
tools/Test-MatchStartTwoClientSmoke.ps1   # two WS clients + two game clients in one match
tools/Force-StartMatch.ps1                # admin force-start path from outside the game
```

`Test-MatchStart*` actually spawns `bapbap.exe` and waits up to ~180s for bootstrap, so they only pass
on a machine with the game build present.

## Server architecture

`Program.cs` (~2400 lines) is the composition root: DI registration, options binding, and **every HTTP
endpoint** as minimal-API lambdas. Most endpoints are deliberately permissive stubs that satisfy the
game client's metagame calls (shop/IAP/challenge/mastery/leaderboard) so the lobby doesn't stall on a
404 — real logic lives in the singleton services. Many routes are registered under multiple aliases
(`/api/load`, `/load`, `/api/login`, ...) because the client varies the path it calls.

Core singletons (registered in `Program.cs`, one responsibility each):

- **`LobbyService`** — the heart. Owns the `/ws` WebSocket loop (`HandleSocketAsync`), all lobbies and
  active matches, the `JOIN_LOBBY → UPDATE_CUSTOM_SETTINGS → START_CUSTOM_GAME → QUEUE_MATCHED →
  GAME_STARTED` flow, and match lifecycle/cleanup. Both the Custom Match path and the Matchmaking path
  converge on its `StartCustomGameAsync` / `StartMatchmakingGameAsync`.
- **`GameServerProcessManager`** — spawns and supervises the dedicated game process, drives the
  fail-closed bootstrap (`/setup-game`, `/add-teams`, `/queue-matched`), and handles port-ready polling,
  retries, and stall detection. The bootstrap listener is opened by the Melon mod *inside* the game
  process, not by this server.
- **`MatchmakingQueueService`** + **`MatchmakingHostedService`** — public queue with a countdown timer;
  the hosted service fires the match when the timer expires.
- **`GameServerPrewarmService`** (hosted) — optional warm spare game process.
- **`PortAllocator`** — leases the http/ws/kcp/tcp port quad per match with a release cooldown.
- **`ServerAdminService`, `EconomyService`, `ShopService`, `FriendsService`, `RankedService`,
  `MatchHistoryService`, `PlayerStorageService`** — persisted state services (JSON files under a
  gitignored `data/` dir). On a custom server most cosmetics are reported as owned.

`CustomServerOptions.cs` defines the entire config surface (bound from `appsettings.json` /
`CustomServer__*` env vars) **plus** the AMP-facing catalogs. Key invariant: `CharacterCatalog` and
`MapCatalog` are the single source of truth for name↔id resolution and **must stay in sync** with the
Melon mod's tables and the AMP config JSON (`deployment/amp-github-autoinstall/*.json`). Shipped
characters are ids 0–14; custom characters (Medusa) use id ≥15.

### Two ways a match starts

- **Custom Match** — a lobby leader configures settings and presses PLAY (`START_CUSTOM_GAME`, with
  `forceStart=true` for admins). Settings come from the lobby panel.
- **Matchmaking** — players `POST /api/queue/join`; a server timer starts the match. Settings come from
  `CustomServer:MatchmakingQueue:Default*`.

`MatchmakingPolicy` (`Both` / `MatchmakingOnly` / `CustomOnly`) gates which paths are allowed.

## Client mod architecture

`CustomServerMod.cs` (~12k lines, single file) is the whole mod. It reads per-device config from
`%APPDATA%\BAPBAPBATTLEROYALE\BapCustomServer.ini`, patches `BAPBAP.Network.NetworkConfig.ApiHost`,
generates a `custom-...` guest identity on first start (priming the game's own `SESSION_ID`/`AUTO_LOGIN`
prefs so no Steam/Discord login is needed), and starts an in-process reverse proxy (`LocalReverseProxy.cs`)
on `127.0.0.1:5055` that rewrites socket-discovery responses back through itself. `F7` opens a native
IMGUI settings panel. The same DLL, running inside the headless `bapbap.exe` under `-batchmode`, also
serves the match bootstrap listener the server calls.

## Linux / AMP deployment (production)

The game is a **Windows** Unity build. Production runs it on Linux via **Wine + Xvfb**, *not* a native
Linux dedicated binary. The required launch wrapper is `deployment/amp-full-linux-wine/start-match.sh`
(initializes a 32-bit Wine prefix, runs under `xvfb-run`, defaults to `-nographics`). The server config
for this path:

```
CustomServer__GameLauncherPath=./start-match.sh
CustomServer__GameLauncherArguments="\"{gameExecutable}\" {gameArguments}"
CustomServer__RequireGameServerBootstrap=true
```

The recommended install is the **AMP GitHub AutoInstall** template (CubeCoders AMP Generic module) which
downloads a full release package from GitHub. The full root-cause writeup and runbook is
`docs/AMP_LINUX_WINE_ROOT_CAUSE.md`. Match start is **fail-closed**: if the game process doesn't accept
the three bootstrap POSTs, the lobby requeues players rather than sending them to dead ports.

## Custom characters

Adding a playable character is data-only (asset bundle + JSON, no per-character code) — see
`docs/ADD-A-CHARACTER.md`. **Medusa** (charId 15) is the reference. Note the character framework mod
(`BAPCustomChars.dll` / `NetworkedCustomChar.dll`) is developed in a **separate** repo
(`BAPBAPModdingAPI/`); `CONTEXT.md` and `MISSION.md` at the root track that work. Within *this* repo the
relevant integration doc is `docs/MEDUSA_SERVER_INTEGRATION.md`.

## Gotchas

- **Two-tier admin:** WS admin (lobby control) checks only `AdminAccountIds` because the game client can't send HTTP headers on WebSocket upgrade. HTTP admin (gold, bans, server-state) requires `ApiToken` or loopback trust via `AdminAuth.IsAuthorized`. A client spoofing `X-BAP-AccountId` gets lobby admin but **not** full admin. The in-game Dev Panel (`AllowDevPanel` in ini) is a separate client-side toggle — neither admin tier unlocks it on its own.

- **Never use skin AssetIds `300001`, `300004`, `300006`** in any shop slot or owned-assets list — they
  are empty `SkinData` slots and crash the in-game locker UI (filtered out in `BuildOwnedAssets`).
- Endpoints intentionally return success stubs for purchases/IAP because there is no real economy on a
  private server. Don't "fix" these into hard failures.
- The repo root holds many `tmp-*.png`, `amp-*.png`, `*.log` capture artifacts and numerous handoff
  markdown files (`AI_HANDOFF*.md`, `HANDOFF*.md`, etc.) — these are scratch/diagnostic, not authoritative.
  `CONTEXT.md` (dated, "authoritative snapshot") and `README.md` are the best living overviews.
- Default API port is **5055**; some docs/log captures reference other ports (5157/5163) from specific
  test runs.

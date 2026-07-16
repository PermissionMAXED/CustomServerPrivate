# AGENTS.md

This file provides guidance to Codex (Codex.ai/code) when working with code in this repository.

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

There **is** an xUnit suite at `tests/BapCustomServer.Tests/` (run with
`dotnet test tests/BapCustomServer.Tests/BapCustomServer.Tests.csproj`; see the
`## Cursor Cloud specific instructions` section below). In addition, end-to-end verification is done
with PowerShell smoke scripts under `tools/` that drive a live server + WebSocket clients. Run a
single scenario by invoking its script:

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

- **Never use skin AssetIds `300001`, `300004`, `300006`** in any shop slot or owned-assets list — they
  are empty `SkinData` slots and crash the in-game locker UI (filtered out in `BuildOwnedAssets`).
- Endpoints intentionally return success stubs for purchases/IAP because there is no real economy on a
  private server. Don't "fix" these into hard failures.
- The repo root holds many `tmp-*.png`, `amp-*.png`, `*.log` capture artifacts and numerous handoff
  markdown files (`AI_HANDOFF*.md`, `HANDOFF*.md`, etc.) — these are scratch/diagnostic, not authoritative.
  `CONTEXT.md` (dated, "authoritative snapshot") and `README.md` are the best living overviews.
- Default API port is **5055**; some docs/log captures reference other ports (5157/5163) from specific
  test runs.

## Cursor Cloud specific instructions

- **.NET SDK 10** lives in `~/.dotnet` (PATH is set in `~/.bashrc`; non-login shells need
  `export PATH="$HOME/.dotnet:$PATH"`). `Microsoft.AspNetCore.App` / `Microsoft.NETCore.App` 10.x
  runtimes are present.
- **Linux dev scope** (what actually builds/runs on this VM): `CustomMatchServer` (the server),
  `CustomClientProxy`, and `tests/BapCustomServer.Tests` (xUnit). The Melon mod projects
  (`BapCustomServerMelon`, `BapAdminMelon`) reference Unity DLLs under the gitignored `AssetRip/`
  and target net6/x86 — treat them as Windows/Unity-only. `tools/Test-MatchStart*` PowerShell smoke
  scripts need the Windows game binary + Wine/Xvfb and are out of scope for Linux dev smoke.
- **Run the server:** `dotnet run --project CustomMatchServer/BapCustomServer.csproj` →
  `http://127.0.0.1:5055`. Plain startup spawns no game process (`GameServerPrewarmOnStartup`
  defaults false); `LaunchGameServers=true` only matters when a match actually starts, and no
  DB/redis is needed (state is JSON files under `data/` dirs). NOTE: some of those state files
  (e.g. `CustomMatchServer/data/*.json`) are git-TRACKED despite the `data/` gitignore pattern, so a
  server run can rewrite them and dirty `git status` — `git checkout -- <file>` to discard that churn;
  never `git add -A` it.
- **Tests:** `dotnet test tests/BapCustomServer.Tests/BapCustomServer.Tests.csproj` (self-contained:
  temp dirs + ephemeral ports, safe to run alongside a live server). There is no lint config
  (no `.editorconfig`/analyzers/solution), so `dotnet build` warnings are the lint signal; the build
  is warning-free. All tests pass (390 after the Phase-0 contract lock, which added
  `RouteManifestContractTests`, `WsConnectGreetingContractTests`, `JoinLobbyContractTests`, and
  `CatalogSyncTests`).
- **GOTCHA for authors of NEW tests:** any new `WebApplicationFactory` test must redirect
  `CustomServer:PlayerOverrides:StateFile` (and `Shop:StateFile`) AND pre-seed a neutral
  `{ "defaults": {}, "players": {} }` overrides document — use the shared TestSupport helpers
  `Svc.StateFileRedirects(dataDir)` / `Svc.WriteNeutralPlayerOverrides(dataDir)`.
  `PlayerOverridesService` regenerates an `unlockEverything:true` default at any missing path, which
  silently defeats `UnlockAllCharacters=false`. If `RouteManifest_MatchesCheckedInContract` fails
  after an intentional route change, regenerate
  `tests/BapCustomServer.Tests/Fixtures/routes.contract.json` from the `routes.actual.json` dump the
  failure writes to the temp dir.
- **GOTCHA — Git LFS pointers in committed `bin/`/`obj/`:** stale build outputs under `**/bin`/`**/obj`
  are git-TRACKED (committed before the `.gitignore` rule) and `.gitattributes` routes `*.dll` through
  Git LFS, so a fresh checkout leaves ~131-byte pointer files. Symptom: `dotnet test` reports
  "No test is available" (the pointer is `xunit.runner.visualstudio.testadapter.dll`). Fix: delete the
  `bin/` and `obj/` dirs under `CustomMatchServer`, `CustomClientProxy`, `tests/BapCustomServer.Tests`
  (and `MapEditorVerify`) and rebuild — incremental builds do NOT overwrite the pointers. Do NOT
  `git lfs pull` (downloads gigabytes of game assets). NEVER stage/commit `bin/` or `obj/` paths; they
  are marked `git update-index --skip-worktree` locally (undo with `--no-skip-worktree` if a pull
  conflicts).
- **Hello-world / WS smoke:** `GET /health` → `{"ok":true,...}`. `GET /api/lobby/socket` returns
  `ws://ark.atomi23.de:5055/ws` because `PublicBaseUrl` is set in `appsettings.json` — expected;
  connect to `ws://127.0.0.1:5055/ws` locally. Connect with `?accountId=X&username=Y`, send
  `{"event":"JOIN_LOBBY","payload":{}}`; expect `SOCKET_READY`, `GAME_MODES_UPDATED`, then
  `JOIN_LOBBY_SUCCESS` after a deliberate ~6-second server delay (use ≥20s client timeouts). A lobby
  exists only while its WebSocket stays open. `node` + the `ws` module (in `/workspace/node_modules`)
  are available for WS scripting.

## Gooby iOS project

- `Gooby/project.yml` is the XcodeGen source of truth; `Gooby/Gooby.xcodeproj/` is generated and
  ignored. Never hand-edit or commit the generated project.
- The app is procedural and offline-only: native SwiftUI/non-AR RealityKit, procedural feedback and
  art, local JSON persistence, no runtime package dependencies or network services.
- Linux can run only the Swift package manifest/build/tests. App builds, RealityKit app tests, UI
  tests, and the recorded demo require macOS with Xcode 16+, XcodeGen, and an iOS Simulator.
- Linux checks: `swift build --package-path Gooby -Xswiftc -warnings-as-errors` and
  `swift test --package-path Gooby --parallel -Xswiftc -warnings-as-errors`.
- On macOS, run `xcodegen generate` in `Gooby/`, then use the generated `Gooby.xcodeproj` with the
  `Gooby` scheme; exact simulator, unsigned Release, and demo commands are in `Gooby/README.md`.

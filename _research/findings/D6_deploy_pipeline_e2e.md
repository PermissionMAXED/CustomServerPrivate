# D6 — End-to-end deploy pipeline + match launch on AMP / Linux / Wine

Session: `D6_deploy_pipeline_e2e` — READ-ONLY research. No source/build/deploy changes were made.
Scope: trace the full launch chain (AMP Start → ASP.NET lobby → `start-match.sh` → xvfb/wine
`bapbap.exe` → mod bootstrap listener → `/setup-game,/add-teams,/queue-matched` → `GAME_STARTED`),
confirm where `Mods/`+Medusa load into the Wine game, and give deploy-fragility hypotheses.

All paths are under `C:\Users\Administrator\Downloads\CustomServer` unless noted.
The two-repo scope also covers `C:\Users\Administrator\Downloads\BAPBAPModdingAPI` (no D6-relevant
launch-chain code found there; the bootstrap listener lives in `BapCustomServerMelon`).

Investigation areas (1)(2)(3)(4) — Medusa native refs, green-line/Kitsu FX fallback, VFX,
spawn/transparency/FPS/invisibility/red-outline — are **out of D6 scope** (owned by the B*/Medusa
agents). D6 covers (5) AMP persistence (cross-referenced with D1/D3) and (6) queue 3–8min /
first-attempt-fails, both of which are deploy-pipeline behaviours. Pointers for (1)–(4) are at the end.

---

## 0. TL;DR launch chain (file:line)

```
AMP "Start"
  └─ kvp: App.ExecutableLinux=/bin/sh
          App.CommandLineArgs=./amp-webpanel-start.sh "http://{{$ApplicationIPBinding}}:{{$ApplicationPort1}}"
     (deployment/amp-github-autoinstall/bapcustomservergithub.kvp — App.* block)
        │
        ▼
  amp-webpanel-start.sh
     ├─ (prewarm) ./start-match.sh --prewarm ./game/bapbap.exe -batchmode -nographics   [guarded by BAPCUSTOM_PREWARM_WINE, default "1"]
     └─ exec ./BapCustomServer --urls "$LISTEN_URL"
     (deployment/amp-full-linux-wine/package/BapCustomServer/amp-webpanel-start.sh:31-43)
        │
        ▼
  ASP.NET lobby (BapCustomServer / Program.cs)
     ├─ appsettings.json: GameLauncherPath="./start-match.sh", GameExecutablePath="./game/bapbap.exe",
     │   GameWorkingDirectory="./game", LaunchGameServers=true, RequireGameServerBootstrap=true,
     │   GameServerReadyTimeoutSeconds=120, BaseHttpPort=7850/ws7777/kcp7778/tcp7779
     │   (package/BapCustomServer/appsettings.json:19-37, 293-311)
     └─ match trigger:
         • Custom Match:  LobbyService.StartCustomGameAsync           (LobbyService.cs:942)
         • Matchmaking:   MatchmakingHostedService(1s timer)→TakeReadyMatch→StartMatchmakingGameAsync (LobbyService.cs:1093)
        │
        ▼
  GameServerProcessManager.StartMatchServerAsync (GameServerProcessManager.cs:46)
     ├─ GameLauncherPath non-empty → processFileName=ResolveExecutableOrCommand("./start-match.sh") (cs:82-84)
     ├─ Process.Start(startInfo)                                       (cs:105)
     │     → runs: ./start-match.sh "./game/bapbap.exe" -batchmode -logFile ... -httpport=7850 -wsport=7777
     │              -kcpport=7778 -tcpport=7779 --melonloader.agfoffline --bapcustom-use-proxy=false
     │              --bapcustom-show-ui=false  (+ AppendLocalCallbackArguments: --bapcustom-host=127.0.0.1 --bapcustom-server-port=5055)
     └─ TryBootstrapServerAsync → POST /setup-game, /add-teams, /queue-matched (cs:219-221) w/ explicit Content-Length
        then WaitForUdpPortAsync(kcpPort)
        │
        ▼
  start-match.sh (deployment/amp-full-linux-wine/start-match.sh)
     ├─ WINEPREFIX=wineprefix32, WINEARCH=win32, esync/fsync off, LIBGL_ALWAYS_SOFTWARE=1, GALLIUM_DRIVER=llvmpipe, swrast
     ├─ GRAPHICS_MODE default "nographics" → UNITY_GRAPHICS_ARGS=(-nographics)
     ├─ wineboot -u  (only if prefix not initialised / key changed → may rm -rf prefix)
     └─ exec xvfb-run -a --server-args="..." wine "./game/bapbap.exe" -nographics <args>   (final line of script)
        │
        ▼
  Wine bapbap.exe + MelonLoader  (game/version.dll bootstraps MelonLoader; loads game/Mods/*.dll)
     ├─ Mods loaded: BapCustomServerMelon.dll, BAPBAP.Medusa.dll, BAPBAP.ModAPI.dll  (game/Mods/)
     └─ CustomServerMod parses -httpport= → _dedicatedHttpPort                          (CustomServerMod.cs:2188-2192)
        EnsureManagedBootstrapListener(httpPort) → TcpListener(IPAddress.Loopback, httpPort) (cs:4457, 4468)
        HandleBootstrapTcpClientAsync: reads Content-Length (cs:4618), accepts ONLY
        /setup-game,/add-teams,/queue-matched (cs:4644) → OnServerMatchSetup/AddTeams/QueueMatched (cs:5481-5489), idempotent (cs:5510-5518)
        │
        ▼
  Back in LobbyService: StartCustomGameSuccess + QUEUE_MATCHED broadcast, then poll dedicated /health ≤15s,
  log "Dedicated server ready for {Game} after {Ms}ms", then multicast GAME_STARTED to every account socket
     (LobbyService.cs:1024-1093 custom path; :1246-1270 matchmaking path)
```

---

## 1. AMP "Start" → ASP.NET lobby (entry point)

`deployment/amp-github-autoinstall/bapcustomservergithub.kvp` (App.* block, verified content):

- `App.ExecutableLinux=/bin/sh`
- `App.CommandLineArgs=./amp-webpanel-start.sh "http://{{$ApplicationIPBinding}}:{{$ApplicationPort1}}"`
- `App.RootDir=./BapCustomServer/`, `App.BaseDirectory=./BapCustomServer/` (= `{{$FullBaseDir}}`)
- `App.EnvironmentVariables={"ASPNETCORE_URLS":"http://0.0.0.0:{{$ApplicationPort1}}",
  "CustomServer__BaseWsPort":"{{$ApplicationPort2}}", "...BaseKcpPort":"{{$ApplicationPort3}}",
  "...BaseTcpPort":"{{$ApplicationPort4}}", "...BaseHttpPort":"{{$ApplicationPort5}}",
  "...PortSearchRange":"1", "...MaxConcurrentMatches":"1", "...RequireGameServerKcpPort":"true",
  "...GameServerReadyTimeoutSeconds":"120"}`
- `App.ApplicationReadyMode=RegexMatch` + `Console.AppReadyRegex=Now listening on:` → AMP flips to "Ready" when Kestrel logs the listen line.
- `Limits.AutoRetryCount=2` → AMP will auto-restart the instance up to 2× on crash (interacts with fragility, §7).

**KEY DEPLOY FACT:** the AMP env block does **NOT** set `CustomServer__GameLauncherPath`. On the
AMP path the launcher indirection comes **only** from `appsettings.json` (§2). (The separate manual
script `start-linux-wine.sh:11-18` *does* export `CustomServer__GameLauncherPath`, but that script is
NOT the AMP entry point — AMP uses `amp-webpanel-start.sh`.) This is a single point of failure (§7-F1).

`amp-webpanel-start.sh` (package/BapCustomServer/amp-webpanel-start.sh):
- Resolves `LISTEN_URL="${1:-...:5055}"`, `chmod +x` the binary+scripts.
- Logs `[amp-start] release=... wine=... xvfb-run=... xauth=...` diagnostics.
- **Pre-warms Wine** when `BAPCUSTOM_PREWARM_WINE != 0` (default on):
  `./start-match.sh --prewarm ./game/bapbap.exe -batchmode -nographics`. The `--prewarm` flag makes
  `start-match.sh` initialise the wineprefix then exit before launching Unity (start-match.sh:
  `PREWARM_ONLY` handling, "prewarm complete; exiting before Unity match launch").
- Finally `exec ./BapCustomServer --urls "$LISTEN_URL"`.

---

## 2. ASP.NET lobby config that drives the launch (appsettings.json)

`deployment/amp-full-linux-wine/package/BapCustomServer/appsettings.json`:
- `:19` `"LaunchGameServers": true`
- `:20` `"RequireGameServerBootstrap": true`
- `:21` `"GameLauncherPath": "./start-match.sh"`   ← the indirection that makes Wine work
- `:22` `"GameLauncherArguments": "\"{gameExecutable}\" {gameArguments}"`
- `:23` `"GameExecutablePath": "./game/bapbap.exe"`
- `:24` `"GameWorkingDirectory": "./game"`
- `:26` `"AdditionalGameArguments": "--melonloader.agfoffline --bapcustom-use-proxy=false --bapcustom-show-ui=false"`
- `:27-30` ports `BaseHttpPort=7850, BaseWsPort=7777, BaseKcpPort=7778, BaseTcpPort=7779`
- `:31` `"PortSearchRange": 1`
- `:33` `"GameServerReadyTimeoutSeconds": 120`
- `:37-39` `BootstrapConnectPath=/setup-game, BootstrapAddTeamsPath=/add-teams, BootstrapQueueMatchedPath=/queue-matched`
- `:293-295` `"MatchmakingQueue": { "QueueTimerSeconds": 30, "MinPlayersToStart": 1 }`
- `:311` `"MaxConcurrentMatches": 1`

Defaults in code (when appsettings absent): `CustomServerOptions.cs:31` `GameLauncherPath = ""`
(empty → would launch the exe directly!), `:39` `GameExecutablePath = "../Spiel/Battleroyalebuild/bapbap.exe"`,
`:48` `GameServerReadyTimeoutSeconds = 30`. So the AMP package overrides these via appsettings.json;
the launcher indirection is NOT a code default. (Reinforces §7-F1.)

---

## 3. ASP.NET lobby → start-match.sh (GameServerProcessManager)

`CustomMatchServer/GameServerProcessManager.cs`:
- `:46` `StartMatchServerAsync(MatchBootstrap, ct)` — entry. Reserves http/ws/kcp/tcp ports
  (`ReserveFrom(BaseHttpPort, PortSearchRange)` etc.).
- Builds `gameArguments` from `HeadlessArguments` (`-batchmode -logFile {logFile} -httpport={httpPort} ...`)
  + `AdditionalGameArguments`, then `AppendLocalCallbackArguments` adds `--bapcustom-host=127.0.0.1`,
  `--bapcustom-server-port=<lobby port>`, `--bapcustom-use-proxy=false`.
- `:82-84` Because `GameLauncherPath` is non-empty → `processFileName = ResolveExecutableOrCommand("./start-match.sh")`
  and `processArguments = GameLauncherArguments` with `{gameExecutable}`→`./game/bapbap.exe`, `{gameArguments}`→headless args.
- `:105` `Process.Start(startInfo)` (UseShellExecute=false, CreateNoWindow=true, WorkingDirectory=`./game`).
- `TryBootstrapServerAsync` polls `http://127.0.0.1:{httpPort}` until deadline (`GameServerReadyTimeoutSeconds`=120s):
  - `:219` POST `BootstrapConnectPath` (`/setup-game`, payload `bootstrap.GameData`)
  - `:220` POST `BootstrapAddTeamsPath` (`/add-teams`, `bootstrap.TeamData`)
  - `:221` POST `BootstrapQueueMatchedPath` (`/queue-matched`, `bootstrap.QueueMatchedData`)
  - then `WaitForUdpPortAsync(kcpPort)` (checks active UDP listeners + `/proc/net/udp[6]`).
- `PostJsonAsync` pre-serialises JSON to bytes and sets explicit `Content-Length` — comment states the
  mod's hand-rolled HTTP listener "only understands Content-Length, not chunked encoding" (matches the
  mod side at CustomServerMod.cs:4618). This is the fix documented in `AMP_LINUX_WINE_ROOT_CAUSE.md`.
- `:144` On bootstrap failure with `RequireGameServerBootstrap=true`: kills the process, releases ports,
  throws `"Game server {GameId} did not accept match bootstrap data."` → surfaced to the player as
  `ERR_GAME_SERVER_BOOTSTRAP` (custom) or a `false` return (matchmaking → requeue, §6).

---

## 4. start-match.sh → xvfb + wine bapbap.exe

`deployment/amp-full-linux-wine/start-match.sh` (wrapperVersion `20260530-graphics-modes-v3`):
- Optional `--prewarm` first-arg (used by amp-webpanel-start.sh) → init prefix and exit before Unity launch.
- Hard-requires `wine`, `xvfb-run`, `xauth` (exit 127 if missing); requires the game exe (exit 66).
- Exports `WINEPREFIX=$ROOT/wineprefix32`, `WINEARCH=win32`, `WINEESYNC=0`, `WINEFSYNC=0`,
  `LIBGL_ALWAYS_SOFTWARE=1`, `GALLIUM_DRIVER=llvmpipe`, `MESA_LOADER_DRIVER_OVERRIDE=swrast`.
- `GRAPHICS_MODE` default `nographics` → `UNITY_GRAPHICS_ARGS=(-nographics)`.
- Prefix compatibility key: if `PREFIX_KEY` (wrapperVer|wine|graphics|arch|GL env) changes →
  `rm -rf "$WINEPREFIX"` and re-`wineboot -u`. **First match after any wrapper/wine/graphics change
  pays a full wineboot cost** (slow → see §6 first-attempt-fails).
- Final exec: `exec "$XVFB_RUN_BIN" -a --server-args="$XVFB_SERVER_ARGS" "$WINE_BIN" "$GAME_EXE" "${UNITY_GRAPHICS_ARGS[@]}" "$@"`.
- The docs forbid pointing `GameLauncherPath` directly at `wine`/`xvfb-run` and forbid removing
  `xvfb`/`xauth`/Mesa i386 (AMP_LINUX_WINE_ROOT_CAUSE.md "What not to change casually").

---

## 5. Where Mods / Medusa load into the Wine game (CONFIRMED)

Deployed game tree: `deployment/amp-full-linux-wine/package/BapCustomServer/game/`:
- `version.dll` (9.9 MB) = MelonLoader proxy bootstrap that loads into `bapbap.exe` under Wine.
- `MelonLoader/` (net6/net35/Il2CppAssemblies/Dependencies) = MelonLoader runtime.
- `game/Mods/` (loaded by MelonLoader at game start):
  - `BAPBAP.Medusa.dll` — **162816 bytes, mtime May 31 16:09** (the custom charId-15 character mod)
  - `BapCustomServerMelon.dll` — 210432 bytes (owns the bootstrap listener + traffic routing)
  - `BAPBAP.ModAPI.dll` — 1653248 bytes; also mirrored in `game/UserLibs/BAPBAP.ModAPI.dll`
  - `BapCustomServer.ini` (mod runtime config; Host=127.0.0.1, Port=5055, UseLocalProxy=false)
- `game/UserData/Medusa/` (Medusa asset bundle dir, e.g. `medusa.bundle`) and `game/UserData/MelonPreferences.cfg`
  (`[BapCustomServer] ProductionMode=true, ShowModdingOverlay=false`).

So **Medusa loads inside the Wine `bapbap.exe` process via MelonLoader scanning `game/Mods/*.dll`**.
The mod's bootstrap listener (`BapCustomServerMelon` `CustomServerMod.cs`) runs in that same process:
`EnsureManagedBootstrapListener(httpPort)` (cs:4457) binds a `TcpListener` on `127.0.0.1:<httpPort>`
(cs:4468) and the ASP.NET server posts the 3 bootstrap payloads to it. The verify script asserts this
layout: `verify-amp-instance.sh` `require_file "./game/Mods/BAPBAP.Medusa.dll"` (per D1/D3).

> Note (Medusa default-skin link to areas 1–3): `CustomServerOptions.cs CharacterCatalog`:
> `MedusaCharId = 15` (`:` const), `Names[15]="Medusa"`, and `DefaultSkinAssetIds[15] = 300018`
> with the comment "Medusa currently reuses **Kitsu's** default skin id because the upstream Medusa
> asset drop contains no native 2D/skin asset entry for this older build." `RosterOptions.EnableMedusa=true`
> default; `BuildEnabledCharIds()` adds `CharacterCatalog.MedusaCharId`. This is supporting evidence for
> the B-agents on the Kitsu fallback / no-native-Medusa-asset cause (areas 1–3).

---

## 6. Queue 3–8 min + "first attempt fails then works" (area 6)

Mechanism is fully explained by the deploy/bootstrap timing, NOT by the queue timer alone:

- Base queue timer is short: `MatchmakingQueueOptions.QueueTimerSeconds = 30` (code default
  `MatchmakingQueueService.cs:8`; appsettings `:294`), `MinPlayersToStart = 1` (`:295`). So a lone
  player's queue should fire in ~30s.
- The multi-minute wait comes from the **bootstrap-timeout → requeue loop**:
  1. `MatchmakingHostedService.ExecuteAsync` runs a `PeriodicTimer(1s)`; on ready it calls
     `_queueService.TakeReadyMatch()` (clears queue + resets `_queueStartedUtc`) then
     `_lobbyService.StartMatchmakingGameAsync(players, ...)`.
  2. `StartMatchmakingGameAsync` → `GameServerProcessManager.StartMatchServerAsync` →
     `TryBootstrapServerAsync` waits up to **`GameServerReadyTimeoutSeconds = 120s`** for the cold
     Wine/Unity process to open its bootstrap listener on 7850. Cold start = connection refused.
  3. If it times out, `StartMatchmakingGameAsync` returns `false` →
     `MatchmakingHostedService` calls `_queueService.RequeuePlayers(players)`.
  4. `RequeuePlayers` re-adds the players and **resets `_queueStartedUtc = DateTimeOffset.UtcNow`**
     (`MatchmakingQueueService.RequeuePlayers`). → another ~30s wait, then another ≤120s attempt.
  - Each failed cycle ≈ up to 30s (timer) + up to 120s (bootstrap) ≈ **~2.5 min**. 2–3 cycles before a
    warm Wine prefix / warmed Unity finally opens the listener → **~3–8 min total**, then it succeeds.
- **"First attempt fails then works"** root cause: cold Wine prefix + cold Unity/Xvfb software-GL
  startup is slow the first time. `start-match.sh` may `rm -rf wineprefix32` + re-`wineboot` on any
  PREFIX_KEY change (§4), making the *first* match after a deploy exceed the 120s bootstrap window.
  Subsequent launches reuse the warmed prefix and succeed. The amp-webpanel-start.sh `--prewarm` step
  initialises the prefix but does NOT warm a full Unity match process, so the first *real* match still
  pays Unity/asset load latency.
- **Custom Match path** differs: `StartCustomGameAsync` (LobbyService.cs:942) *throws* on bootstrap
  failure → `StartCustomGameFail` `ERR_GAME_SERVER_BOOTSTRAP`; the player must press Start again
  (manual "first attempt fails, second works").
- Direct doc corroboration: `docs/AMP_LINUX_WINE_ROOT_CAUSE.md` "What was broken":
  `POST http://127.0.0.1:7850/setup-game Connection refused` / "did not accept match bootstrap data
  before timeout" → player "sat in queue or was requeued."

Confidence: **HIGH** that the requeue + 120s-bootstrap-timeout loop produces multi-minute waits and the
cold→warm transition explains first-fail-then-works. **MEDIUM-HIGH** that exactly 3–8 min = 2–3 cycles
(depends on how many cold cycles before a warm success on a given host).

---

## 7. AMP persistence (area 5) — deploy-pipeline view (cross-ref D1 / D3)

D1 (`D1_update_source.md`) and D3 (`D3_why_dll_reset.md`) already nailed this with file:line. D6
confirms and adds the live-package drift evidence:

- The **Update** button runs `bapcustomservergithubupdates.json` stage 6 "Download BAPBAP Custom Server
  full package": `UpdateSource=GithubRelease`, `UpdateSourceData=bapcustomserver-amp-full-linux-wine.zip`,
  `UpdateSourceTarget={{$FullBaseDir}}` (=`BapCustomServer/`), `UnzipUpdateSource=true`,
  `OverwriteExistingFiles=true`, `SkipOnFailure=false` (json lines 52–62). The ZIP **contains**
  `game/Mods/BAPBAP.Medusa.dll`, so a live SFTP/web-upload of a newer DLL is overwritten on the next Update.
- **Start/Restart do NOT re-extract** (`kvp App.PreStartStages=[]`, `App.ForceUpdate=False`) → a live
  upload survives Start/Restart but is wiped by Update. Only `data/**` and `logs/**` survive Update,
  by ZIP *exclusion*, not file protection; `game/Mods/*.dll` is explicitly documented as "refreshed by
  updates" (README-AMP-GITHUB-AUTOINSTALL.md:74; bapbap-amp-setup.sh python `protected` block omits `game/Mods`).
- **Real persistent path:** rebuild `bapcustomserver-amp-full-linux-wine.zip` with the new DLL
  (`tools/Build-AmpFullLinuxWinePackage.ps1`), publish a GitHub Release reusing the **same asset name**
  (manifest matches by filename, not tag), then press Update.
- **SFTP/web-upload alternative:** valid hot-fix that survives Start/Restart, wiped by next Update — so
  the operator must avoid Update until the change is baked into the published Release.

**NEW D6 evidence — live-package drift (supports the "resets" symptom):**
The locally-staged package is **ahead of the published release & docs**, which is exactly the state that
produces "I uploaded a new Medusa DLL and it reverted":
- `package/BapCustomServer/deployment-info.json`: `releaseLabel = "bapcustomserver-20260531-medusa-v173-livepatch"`,
  `gitDirty = true`, `medusaDllSha256 = 999D4BDF5C60E9F6BFC5E30FA3BBF071AB2AB4204890AE5FA3A30772B9C2BFC0`,
  `medusaCharId = 15`.
- But `docs/AMP_LINUX_WINE_ROOT_CAUSE.md` (current target) says release `...-medusa-v172` with
  `medusa.medusaDllSha256 = 4D3050CAC36C94AA726F575DE2F271A34248EB70CC81D6C55D27F2248CFBA16C`, and
  `README-AMP-GITHUB-AUTOINSTALL.md` pins `BAPBAP.Medusa.dll 4D3050CAC3...`.
- i.e. three different Medusa DLL identities are in play (live-patch 999D…, doc/health 4D30…, and the
  doc's "current tested mod DLL" 3E796F… which is actually the `modDllSha256` of `BapCustomServerMelon.dll`).
  If the published Release still carries the v172 DLL, pressing Update reverts the live v173 livepatch DLL.
  This is concrete corroboration of D1/D3's H1/H2. Confidence **HIGH** for the drift; the published
  Release's actual asset bytes were not fetched (offline) — flagged.

---

## 8. Deploy-fragility hypotheses + confidence (D6 deliverable)

| # | Hypothesis | Confidence | Evidence |
|---|-----------|-----------|----------|
| F1 | The Wine indirection depends solely on `appsettings.json GameLauncherPath="./start-match.sh"`; AMP's kvp `App.EnvironmentVariables` does NOT set `CustomServer__GameLauncherPath`, and the code default is `""` (would `Process.Start` `bapbap.exe` directly on Linux → fail). If Start's metaconfig rewrite of appsettings.json drops/overrides that key, every match launch breaks. | **HIGH** | kvp App.EnvironmentVariables (no GameLauncherPath); appsettings.json:21; CustomServerOptions.cs:31 default `""`; docs "Do not point GameLauncherPath at wine/xvfb-run". (Whether metaconfig maps GameLauncherPath as Importable not verified — see open items.) |
| F2 | `PortSearchRange=1` + `MaxConcurrentMatches=1` (fixed ports 7850/7777/7778/7779). A lingering/zombie Wine match process from a prior match holds 7850, so the next match either fails to reserve or bootstraps against a stale listener → requeue/long wait. | **MEDIUM** | appsettings.json:31, :311; kvp env `PortSearchRange=1`,`MaxConcurrentMatches=1`; GameServerProcessManager `ReserveFrom` uses range; docs note idle-closed 7850 is normal. |
| F3 | First match after any deploy/wrapper/wine/graphics change triggers `rm -rf wineprefix32` + `wineboot` in start-match.sh, pushing cold-start past the 120s bootstrap window → first-attempt-fails. | **HIGH** | start-match.sh PREFIX_KEY reset block + `wineboot -u`; GameServerReadyTimeoutSeconds=120; §6. |
| F4 | The bootstrap loop is the dominant queue-latency source (≤120s/attempt × requeue), not the 30s queue timer; explains 3–8 min queues. | **HIGH** | MatchmakingHostedService requeue; MatchmakingQueueService.RequeuePlayers resets timer; appsettings QueueTimerSeconds=30 vs ReadyTimeout=120. |
| F5 | Live `game/Mods/BAPBAP.Medusa.dll` (v173 livepatch, 999D…) diverges from published release/docs (v172, 4D30…); pressing AMP Update reverts it. The single source of truth must be the republished Release ZIP. | **HIGH** | deployment-info.json vs docs/README hashes (§7); D1/D3 stage-6 overwrite. |
| F6 | Prewarm (`amp-webpanel-start.sh --prewarm`) only warms the wineprefix, not a Unity match; disabling it (`BAPCUSTOM_PREWARM_WINE=0`) makes the first real match pay full wineboot, worsening F3. | **MEDIUM** | amp-webpanel-start.sh prewarm guard; start-match.sh `PREWARM_ONLY` exits before Unity. |
| F7 | The mod bootstrap listener is a hand-rolled TCP/HTTP parser that only honours `Content-Length` (no chunked); any future change to `PostJsonAsync` back to `PostAsJsonAsync`/streaming would silently break bootstrap. | **MEDIUM-HIGH** | GameServerProcessManager `PostJsonAsync` Content-Length comment; CustomServerMod.cs:4618 Content-Length parse, :4644 path allow-list. |

---

## 9. Open items / not verified by D6
- Whether `bapcustomservergithubmetaconfig.json` maps `CustomServer:GameLauncherPath` as an Importable
  key (i.e. whether Start's appsettings.json rewrite can clobber the launcher) — **not read by D6** (F1 risk).
- The published GitHub Release asset bytes (offline) — cannot confirm whether the live Release carries
  v172 (4D30…) or the v173 livepatch (999D…) Medusa DLL.
- Exact kvp/JSON line numbers for `App.CommandLineArgs`/`App.BaseDirectory` come from D1/D3 (kvp:24,:27)
  and were cross-checked against the kvp content D6 read; treat as HIGH but defer to D1/D3 for the precise lines.
- Areas (1)(2)(3)(4) (Medusa native refs, green-line/Kitsu FX, VFX, spawn/transparency/FPS/invisibility/
  red-outline) are **out of D6 scope**; pointers: `docs/MEDUSA_SERVER_INTEGRATION.md` (Kitsu-based kit +
  Medusa visual bridges; `Char_Medusa(Clone) has already spawned` Mirror NetworkIdentity issue;
  Skinny/Kitsu fallback), and `CharacterCatalog` Medusa=charId15 reusing Kitsu default skin 300018.
```

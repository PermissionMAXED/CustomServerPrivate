# E6 — GameServerProcessManager + Port Lifecycle (READ-ONLY research)

Scope: process spawn/readiness/timeout/kill/cleanup, port allocation, and whether a
leftover/zombie process or port conflict causes the "first-attempt-fails-then-works"
symptom and the 3–8 min queue. Cross-checked `logs\` and AMP runtime state.

Primary files:
- `CustomMatchServer\GameServerProcessManager.cs`
- `CustomMatchServer\PortAllocator.cs`
- `CustomMatchServer\CustomServerOptions.cs`
- `CustomMatchServer\appsettings.json`
- `CustomMatchServer\MatchmakingHostedService.cs`, `MatchmakingQueueService.cs`
- `CustomMatchServer\LobbyService.cs`, `ResourceMonitorService.cs`, `Program.cs`

---

## 1. Process lifecycle (file:line + evidence)

### Spawn / arguments
- `GameServerProcessManager.cs:33` `StartMatchServerAsync(MatchBootstrap, CancellationToken)` — entry point.
- `GameServerProcessManager.cs:37-46` — when `LaunchGameServers=false`, returns a static `ExternalGameServer` session (no spawn).
- `GameServerProcessManager.cs:50-53` — reserves **four** ports up front:
  ```
  int httpPort = _ports.ReserveFrom(_options.BaseHttpPort, _options.PortSearchRange);
  int wsPort   = _ports.ReserveFrom(_options.BaseWsPort,   _options.PortSearchRange);
  int kcpPort  = _ports.ReserveFrom(_options.BaseKcpPort,  _options.PortSearchRange);
  int tcpPort  = _ports.ReserveFrom(_options.BaseTcpPort,  _options.PortSearchRange);
  ```
- `GameServerProcessManager.cs:60-72` — builds args from `HeadlessArguments` token-replacing `{gameId}{httpPort}{wsPort}{kcpPort}{tcpPort}{logFile}`. Default template (`CustomServerOptions.cs:35-36`): `-batchmode -logFile "{logFile}" -httpport={httpPort} -wsport={wsPort} -kcpport={kcpPort} -tcpport={tcpPort}`.
- `GameServerProcessManager.cs:74-77` — appends `AdditionalGameArguments` (prod = `--melonloader.agfoffline --melonloader.captureplayerlogs`, `appsettings.json:27`).
- `GameServerProcessManager.cs:79` `AppendLocalCallbackArguments` → adds `--bapcustom-host=127.0.0.1`, `--bapcustom-server-port=<lobby port>`, `--bapcustom-use-proxy=false` (`:494-540`).
- `GameServerProcessManager.cs:81-92` — optional `GameLauncherPath` wrapper (prod empty, so `bapbap.exe` launched directly).
- `GameServerProcessManager.cs:94-105` — `ProcessStartInfo { UseShellExecute=false, CreateNoWindow=true }`; **`Process.Start` at line 105** (`?? throw "Process.Start returned null."`).
- Log dir created at `:58` from `GameLogDirectory` = `logs/game-servers` (`CustomServerOptions.cs:34`, `appsettings.json:22`); per-match log file `{gameId}.log` (`:62`).

### Readiness detection
- `GameServerProcessManager.cs:138` `bool bootstrapped = await TryBootstrapServerAsync(...)`.
- `TryBootstrapServerAsync` (`:184-279`): polls `http://127.0.0.1:{httpPort}` and POSTs `/setup-game`, `/add-teams`, `/queue-matched` (paths `CustomServerOptions.cs:46-48`).
  - Deadline = `startedAt.AddSeconds(GameServerReadyTimeoutSeconds)`; poll = `GameServerReadyPollMillis` (`:207-208`, loop `:218`).
  - Early-exit if the process dies: `if (session.Process is { } process && process.HasExited)` → returns false with diagnostics (`:220-229`).
  - After HTTP accepted, **KCP UDP gate**: `if (_options.RequireGameServerKcpPort && !await WaitForUdpPortAsync(session.KcpPort, ...))` → returns false (`:240-249`).
- `WaitForUdpPortAsync` (`:455-475`): deadline capped at **`Math.Min(15, Math.Max(3, GameServerReadyTimeoutSeconds))`** ⇒ **only ~15 s** to see the KCP UDP listener after HTTP is up. Detection via `GetActiveUdpListeners()` then `/proc/net/udp(6)` fallback (`:477-540`).

### Timeout values
- `CustomServerOptions.cs:43` `GameServerReadyTimeoutSeconds = 30` (code default) — **overridden to 120 in `appsettings.json:32`** (deployed value).
- `CustomServerOptions.cs:44` `GameServerReadyPollMillis = 500`.
- KCP wait sub-timeout hard-capped at 15 s (see above) regardless of the 120 s HTTP timeout.
- Secondary readiness probe in `LobbyService.cs:1031-1052` (custom) and `:1218-...` (matchmaking): an *extra* 15 s `GetAsync(.../health)` poll after the manager already returned — informational only, does not abort.

### Kill / cleanup
- Failure-with-`RequireGameServerBootstrap=true` (`appsettings.json:17` = true): `GameServerProcessManager.cs:139-145` →
  ```
  TryKill(process);
  _ports.ReleaseImmediately(httpPort, wsPort, kcpPort, tcpPort);   // line 142
  throw InvalidOperationException("... did not accept match bootstrap data.");
  ```
- Generic `catch` (`:152-163`): `TryKill(process)` + `_ports.ReleaseImmediately(...)` (`:159`).
- Normal end of match: `StopMatchServer` (`:166-182`) → `TryKill(process)` + `process.Dispose()` + **`_ports.Release(...)` (line 181, WITH 60 s cooldown)**. Called from `LobbyService.RecordGameEnded` (`LobbyService.cs:285`).
- `TryKill` (`:664-674`): `process.Kill(entireProcessTree: true)` (`:670`) — kills wine child tree, best-effort, swallows exceptions.

### Max concurrent
- `CustomServerOptions.cs:26` `MaxConcurrentMatches = 0` ⇒ **unlimited** (guards `LobbyService.cs:982` and `:1100` are `if (MaxConcurrentMatches > 0 && _matches.Count >= ...)`, skipped when 0). Not present in the deployed `appsettings.json` game block ⇒ stays 0. Capacity is effectively bounded only by `PortSearchRange = 200`.

---

## 2. Port allocation (file:line + evidence)

- Base ports (`CustomServerOptions.cs:38-42`, mirrored `appsettings.json:25-30`): `BaseHttpPort=7850`, `BaseWsPort=7777`, `BaseKcpPort=7778`, `BaseTcpPort=7779`, `PortSearchRange=200`.
- `PortAllocator.ReserveFrom` (`PortAllocator.cs:23-55`): linear scan `startPort..startPort+range`; skips `_reserved` (`:34`), skips `_cooldown` (`:38-44`), else `IsFree(port)` → reserve.
- **Cooldown** (W3 mitigation): `CooldownDuration = TimeSpan.FromSeconds(60)` (`:21`). `Release(...)` parks ports for 60 s (`:57-58`, `ReleaseCore addCooldown:true` `:71-82`). Comment `:11-17` explicitly: *"a freshly recycled game-server port can collide with the previous match's still-bound UDP socket on wine deployments."*
- **`ReleaseImmediately` bypasses cooldown** (`:62-65`, `addCooldown:false`, `_cooldown.Remove(port)`). This is the path used on **bootstrap failure** (`GameServerProcessManager.cs:142, 159`).
- **`IsFree` only tests TCP, loopback** (`PortAllocator.cs:131-145`):
  ```
  using var tcp = new TcpListener(IPAddress.Loopback, port);  // line 135
  ```
  ⇒ a busy **UDP/KCP** port (7778 family) is **never detected at reservation time**, and a port bound on a non-loopback interface is not detected either.

---

## 3. First-attempt-fails-then-works & 3–8 min queue — mechanism

Matchmaking retry loop:
- `MatchmakingHostedService.cs:21` `PeriodicTimer(TimeSpan.FromSeconds(1))`; loop awaits `StartMatchmakingGameAsync` to completion (`:35`) — so one in-flight attempt **blocks the loop for up to the full 120 s** bootstrap timeout.
- On failure → `RequeuePlayers(players)` (`:38`, `:50`).
- `MatchmakingQueueService.RequeuePlayers` (`:218-243`) re-adds players and **resets the timer**: `_queueStartedUtc = DateTimeOffset.UtcNow` (`~:235`). `QueueTimerSeconds=30` (`:8`).
- Cost per failed cycle ≈ 30 s (queue wait) + up to 120 s (bootstrap timeout) ≈ **~150 s**. Two failed cold cycles + a success ≈ **5–8 min**, exactly the reported window. The first match also happens to be the slowest (cold wine/Unity), so "first attempt fails, later works."

Custom-match path (`LobbyService.cs:1004`) is single-shot: a cold-start failure surfaces as `ERR_GAME_SERVER_BOOTSTRAP` (`:1011-1018`) and the player must press PLAY again — same "fails then works" feel, no auto-retry.

---

## 4. Cross-check: logs & runtime state

- **No local `logs\game-servers\` directory exists** in this workspace (glob `**/game-servers/**` = 0 hits). The dir is created at runtime on the Linux/AMP host (`GameServerProcessManager.cs:58`); not captured here, so per-match Unity/wrapper logs could not be inspected for direct timeout evidence.
- `logs\cua-medusa-v1616-144640\turn-00039\app_state.json` (live AMP UI snapshot) shows instance **BAPBattle01** at `ark.atomi23.de:5055`, **SFTP Port 2254**, and a "Network Port Status" panel listing **Match WebSocket 7778 / Match KCP 7779 / Match TCP 7780 / Match Bootstrap HTTP 7850**, all "Not Listening" while Stopped.
  - Note an **off-by-one between AMP's port labels and the server config** (config base WS=7777/KCP=7778/TCP=7779). AMP only checks the single base port per range; because `PortAllocator` drifts ports within a 200-wide window, the actually-bound match ports can differ from what AMP/firewall watches — possible relevance for E2/E3 connectivity, not a spawn blocker.
- **No orphan/zombie cleanup anywhere.** `ResourceMonitorService.cs:105-117` enumerates `Process.GetProcessesByName("bapbap")` and **only logs** them (`[Resource] bapbap.exe: ...`); it never kills. `Program.cs:2062-2065` `process.Kill` is an unrelated shell-probe timeout guard. There is **no startup sweep** that kills bapbap.exe / wineserver left over from a previous server lifecycle.

---

## 5. Hypotheses + confidence

**H1 — Cold wine/Unity warm-up exceeds the 120 s readiness timeout on the first match (then warm = fast). [PRIMARY — HIGH ~0.75]**
First headless `bapbap.exe` under wine after a (re)start pays wineprefix init + Unity load + shader cache. README states a fresh process takes "~60s" and the smoke harness bumps `GameServerReadyTimeoutSeconds` to **150** while prod runs **120** (`appsettings.json:32`). A first cold launch crossing 120 s ⇒ `TryBootstrapServerAsync` times out (`:262-270`) ⇒ `RequireGameServerBootstrap` throws ⇒ requeue. Second (warm) launch finishes < 120 s ⇒ success. Fully explains both symptoms; ties to the 3–8 min queue via the ~150 s/cycle requeue math.

**H2 — KCP UDP readiness gate is too tight (15 s) and a cross-lifecycle zombie UDP socket is invisible to the allocator. [SECONDARY — MEDIUM-HIGH ~0.6]**
`IsFree` checks **TCP only** (`PortAllocator.cs:135`), so a leftover wine process from a prior AMP restart/update still bound to UDP 7778/7779 is **not** detected and the port is reused. The new server then can't bind KCP, or `WaitForUdpPortAsync` (15 s cap, `:455-475`) can even **false-positive on the zombie's listener**. With no startup cleanup (§4), an AMP "Update"/restart that orphaned a match process is a concrete first-attempt failure trigger; the zombie eventually dies → retry works.

**H3 — Bootstrap-failure path releases ports WITHOUT the 60 s cooldown. [CONTRIBUTING — MEDIUM ~0.5]**
`GameServerProcessManager.cs:142,159` use `ReleaseImmediately` on failure, defeating the very wine-UDP-teardown protection the cooldown was added for (`PortAllocator.cs:11-17`). An immediate retry can grab the same ports while the just-killed wine tree is still unbinding its UDP socket → consecutive failures. The ~30 s matchmaking requeue gap partly masks this (< 60 s cooldown but often enough for teardown), so it compounds H1/H2 rather than standing alone.

**H4 — TCP-only / loopback-only free check mis-judges availability. [LOW-MEDIUM ~0.35]**
Beyond UDP, `IsFree` binds only `IPAddress.Loopback`; a port bound on `0.0.0.0`/external by another AMP instance on the shared host (the box runs dozens — see app_state) would pass the loopback test yet fail the real bind. Lower confidence because the 7777–8050 range is BAPBAP-specific.

**Not a cause:** concurrency cap — `MaxConcurrentMatches=0` (unlimited), so "server full" is not gating first attempts.

---

## 6. Suggested verification (no changes made)
1. Inspect host `logs/game-servers/<gameId>.log` + `.wrapper.log` for the first failed match: confirm whether it shows a 120 s HTTP timeout (H1) vs a KCP/UDP bind error (H2/H3).
2. On the host, after a failed first attempt, run `ss -lunp | grep 777` / `pgrep -fa bapbap` to check for a zombie holding the KCP UDP port (H2).
3. Compare wall-clock of first vs second successful match start in server logs (`Started game server ... PID` → `Bootstrapped game server`) to size the cold-vs-warm delta (H1).

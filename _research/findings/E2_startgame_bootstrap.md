# E2 — Match-start + Bootstrap Flow (first-attempt-fails-then-works)

Scope: `CustomMatchServer\LobbyService.cs` (StartCustomGameAsync, StartMatchmakingGameAsync, bootstrap POSTs, readiness wait) and `CustomMatchServer\GameServerProcessManager.cs` (spawn, GameServerReadyTimeoutSeconds, port allocation). READ-ONLY. No code changed.

Files inspected:
- `CustomMatchServer\LobbyService.cs`
- `CustomMatchServer\GameServerProcessManager.cs`
- `CustomMatchServer\CustomServerOptions.cs`
- `CustomMatchServer\MatchmakingHostedService.cs`
- `CustomMatchServer\MatchmakingQueueService.cs`
- `CustomMatchServer\PortAllocator.cs`
- `CustomMatchServer\appsettings.json` (deployed overrides)
- `deployment\amp-full-linux-wine\start-match.sh` (Wine/Xvfb launcher)

---

## 1. The start -> spawn -> bootstrap -> ready sequence (file:line)

### A. Custom Match path — `LobbyService.StartCustomGameAsync`
- `LobbyService.cs:942` — method entry.
- Guard gates (each sends `START_CUSTOM_GAME_FAIL` and returns):
  - `LobbyService.cs:944` policy == `MatchmakingOnly` -> `ERR_CUSTOM_DISABLED`.
  - `LobbyService.cs:959` `TryGetLobby` fails -> silent return.
  - `LobbyService.cs:964` `CanControlLobby` fails -> `ERR_NOT_LEADER`.
  - `LobbyService.cs:974` not all ready & `!ForceStart` -> `ERR_NOTREADY` (`showForceStartModal=true`).
  - `LobbyService.cs:986` `MaxConcurrentMatches` reached -> `ERR_SERVER_FULL`.
- `LobbyService.cs:996` build `gameId = custom-{yyyyMMddHHmmss}-{rand}`.
- `LobbyService.cs:999` `MatchBootstrap bootstrap = CreateBootstrap(...)`.
- `LobbyService.cs:1003` `lobby.Starting = true;`
- `LobbyService.cs:1004` `session = await _gameServers.StartMatchServerAsync(bootstrap, cancellationToken);` **<- spawn + bootstrap happen inside here (blocking).**
- `LobbyService.cs:1006-1017` catch -> `lobby.Starting=false`, `START_CUSTOM_GAME_FAIL` with `errorCode="ERR_GAME_SERVER_BOOTSTRAP"`. **This is the user-visible first-attempt failure.**
- `LobbyService.cs:1019` `_matches[gameId] = session;`
- `LobbyService.cs:1022` broadcast `START_CUSTOM_GAME_SUCCESS`.
- `LobbyService.cs:~1027` broadcast `QUEUE_MATCHED`.
- `LobbyService.cs:1035-1060` **secondary readiness wait** (separate from the manager's bootstrap wait): `maxWaitMs=15000`, `pollMs=200`, HttpClient `Timeout=2s`, polls `http://127.0.0.1:{HttpPort}/health`. Any HTTP response = ready. **Non-fatal**: on timeout it only logs `"Dedicated server bootstrap timeout for {Game}"` (`:1055`) and still proceeds to `GAME_STARTED`.
- `LobbyService.cs:~1063+` multicast `GAME_STARTED` to every connection of each lobby account.

### B. Matchmaking path — `LobbyService.StartMatchmakingGameAsync`
- `LobbyService.cs:1093` — method entry; returns `bool`.
- `LobbyService.cs:1099` `MaxConcurrentMatches` reached -> `return false` (players stay queued).
- Builds an `MM…` lobby, seeds players (all `IsReady=true`).
- `LobbyService.cs:1194` `lobby.Starting=true;`
- `LobbyService.cs:1195` `session = await _gameServers.StartMatchServerAsync(bootstrap, cancellationToken);`
- `LobbyService.cs:1197-1203` catch -> `lobby.Starting=false`, removes lobby, **`return false`** (triggers requeue — see §6).
- `LobbyService.cs:1205` `_matches[gameId] = session;`
- `LobbyService.cs:1216-1241` identical secondary `/health` wait (`maxWaitMs=15000`, `pollMs=200`), non-fatal.
- then `GAME_STARTED` multicast; `LobbyService.cs:~1244` `return true`.

### C. Spawn + bootstrap — `GameServerProcessManager.StartMatchServerAsync`
- `GameServerProcessManager.cs:33` — method entry.
- `GameServerProcessManager.cs:35` if `!LaunchGameServers` -> return external session (no spawn). (Deployed `LaunchGameServers=true`.)
- `GameServerProcessManager.cs:50-53` reserve ports via `_ports.ReserveFrom`: http `BaseHttpPort=7850`, ws `7777`, kcp `7778`, tcp `7779`, each with `PortSearchRange=200`.
- `GameServerProcessManager.cs:105` `process = Process.Start(startInfo)` (executable or `GameLauncherPath` wrapper -> on Linux this is `start-match.sh` driving Wine/Xvfb).
- `GameServerProcessManager.cs:138` `bool bootstrapped = await TryBootstrapServerAsync(session, bootstrap, cancellationToken);`
- `GameServerProcessManager.cs:139-145` if `!bootstrapped && RequireGameServerBootstrap` -> `TryKill(process)`, `ReleaseImmediately(ports)`, **throw `InvalidOperationException("… did not accept match bootstrap data.")`**.
- `GameServerProcessManager.cs:150-165` catch -> `TryKill` + `ReleaseImmediately` + rethrow.

### D. Readiness wait — `GameServerProcessManager.TryBootstrapServerAsync`
- `GameServerProcessManager.cs:184` — method entry.
- `GameServerProcessManager.cs:188` `startedAt = UtcNow`.
- `GameServerProcessManager.cs:189` `deadline = startedAt.AddSeconds(GameServerReadyTimeoutSeconds)`.
- Loop while `UtcNow < deadline`:
  - `GameServerProcessManager.cs:205` if `process.HasExited` -> log `"… exited before accepting bootstrap data"` + `return false`.
  - POST sequence (each `EnsureSuccessStatusCode`): `BootstrapConnectPath=/setup-game`, `BootstrapAddTeamsPath=/add-teams`, `BootstrapQueueMatchedPath=/queue-matched` (`PostJsonAsync`).
  - `GameServerProcessManager.cs:229` after POSTs succeed, if `RequireGameServerKcpPort && !await WaitForUdpPortAsync(session.KcpPort)` -> `return false`.
  - on full success -> log `"Bootstrapped game server"` + `return true`.
  - catch `HttpRequestException`/`TaskCanceledException` (connection refused / timeout): record `lastError`, progress-log every `GameServerBootstrapProgressLogSeconds`, `await Task.Delay(GameServerReadyPollMillis)`, retry.
- `GameServerProcessManager.cs:264` after deadline -> log `"… did not accept bootstrap data before timeout"` + `return false`.

### E. KCP gate — `GameServerProcessManager.WaitForUdpPortAsync`
- `GameServerProcessManager.cs:472` — `deadline = UtcNow.AddSeconds(Math.Min(15, Math.Max(3, GameServerReadyTimeoutSeconds)))` -> **effectively capped at 15s** regardless of the 120s bootstrap timeout. Polls `GetActiveUdpListeners()` then `/proc/net/udp(6)` every `GameServerReadyPollMillis`.

### F. Content-Length quirk — `PostJsonAsync`
- `GameServerProcessManager.cs:~456` pre-serializes JSON to a byte buffer with explicit `Content-Length` because "the mod's hand-rolled HTTP parser only understands Content-Length, not chunked encoding." Streaming/`PostAsJsonAsync` would be dropped by the mod listener. Evidence-relevant: bootstrap correctness depends on the mod's managed listener being fully up.

---

## 2. What makes it return false (connection refused / timeout)

`TryBootstrapServerAsync` returns false (→ throw when `RequireGameServerBootstrap=true` → custom path `ERR_GAME_SERVER_BOOTSTRAP`, matchmaking path `return false`→requeue) when ANY of:
1. **Process exits early** (`GameServerProcessManager.cs:205`) — Unity/Wine crash on cold launch (graphics/GL negotiation under Xvfb llvmpipe).
2. **All three bootstrap POSTs never succeed within the timeout** — repeated `HttpRequestException` ("connection refused") because the mod's managed HTTP listener on `127.0.0.1:{httpPort}` is not up yet, or `TaskCanceledException` (per-request HttpClient timeout). Final state at `GameServerProcessManager.cs:264`.
3. **KCP UDP port not visible within ~15s** after HTTP bootstrap succeeded (`GameServerProcessManager.cs:229` + `:472`), with `RequireGameServerKcpPort=true`.

Note the LobbyService secondary `/health` wait (`:1035`/`:1216`) is NOT a failure source — it is purely informational and never blocks `GAME_STARTED`.

---

## 3. Timeout / interval values

| Setting | C# default (`CustomServerOptions.cs`) | Deployed (`appsettings.json:33-34`, `:20`) | Effect |
|---|---|---|---|
| `GameServerReadyTimeoutSeconds` | 30 (`CustomServerOptions.cs:44`) | **120** | bootstrap retry deadline |
| `GameServerReadyPollMillis` | 500 (`:45`) | 500 | retry / UDP poll interval |
| `GameServerBootstrapProgressLogSeconds` | 15 (`:46`) | 15 | progress log cadence |
| `RequireGameServerBootstrap` | true (`:29`) | true | false bootstrap => throw/fail |
| `RequireGameServerKcpPort` | true (`:30`) | (default true) | adds KCP UDP gate |
| `WaitForUdpPortAsync` deadline | `min(15,max(3,timeout))` | **15s** cap (`:472`) | KCP visibility window |
| LobbyService `/health` wait | `maxWaitMs=15000`, `pollMs=200`, HttpClient 2s | same | non-fatal |
| `QueueTimerSeconds` | 30 (`MatchmakingQueueService.cs`) | **30** (`appsettings.json:134`) | queue countdown |
| `MinPlayersToStart` | 1 | 1 | bots fill rest |
| `PortAllocator.CooldownDuration` | **60s** (`PortAllocator.cs`) | n/a | parks released ports |

---

## 4. Hypotheses on first-attempt-fails-then-works

**H1 — Wine prefix / Unity cold start exceeds bootstrap window. CONFIDENCE: HIGH.**
`start-match.sh` does a one-time wineprefix init: it resets the prefix when the compatibility key changes and runs `wineboot -u` under `xvfb-run`, gated by markers `.bapcustom-wineboot-ok` / `.bapcustom-wineboot-key` (`start-match.sh` "initializing wineprefix" block). The FIRST match after a fresh deploy, key change, or container restart pays full `wineboot` + Unity x86 shader/asset cold-load under software GL (`LIBGL_ALWAYS_SOFTWARE=1`, `GALLIUM_DRIVER=llvmpipe`). The mod's managed HTTP listener therefore comes up late; bootstrap POSTs get connection-refused until the deadline. Once the prefix is warm and cached, the retry launches fast and bootstraps. Directly explains "first fails, then works." (If any package shipped the 30s default instead of 120s, the cold path almost always loses.)

**H2 — Recycled port collides with previous match's lingering Wine UDP socket. CONFIDENCE: MEDIUM-HIGH.**
`PortAllocator` deliberately parks released ports for `CooldownDuration=60s` with the comment that "a freshly recycled game-server port can collide with the previous match's still-bound UDP socket on wine." On the first attempt soon after a prior match ended, a reused port may still be held by Wine's not-yet-released UDP socket; `WaitForUdpPortAsync` (15s cap) then fails -> `return false`. A retry lands on a cooled-down/alternate port and succeeds.

**H3 — KCP UDP bind lags HTTP bootstrap. CONFIDENCE: MEDIUM.**
HTTP `/setup-game,/add-teams,/queue-matched` can all succeed, yet the KCP transport may not have bound its UDP socket within the 15s `WaitForUdpPortAsync` cap during a cold/slow load -> bootstrap returns false even though HTTP was accepted. Warm retry binds UDP in time.

**H4 — Effective timeout actually 30s (config not applied). CONFIDENCE: LOW-MEDIUM.**
If a deployment runs with the compiled default (`GameServerReadyTimeoutSeconds=30`) rather than the appsettings 120, virtually every cold first launch times out; the second (warm) launch fits in 30s. Worth verifying the live AMP instance's effective `$.CustomServer.GameServerReadyTimeoutSeconds`.

---

## 5. Queue 3-8 min symptom (relation to E2)

`QueueTimerSeconds` is **30s** in both default and deployed config — the configured queue is NOT 3-8 minutes. The multi-minute wait is an emergent effect of the failure loop:
- `MatchmakingHostedService.cs` ticks every 1s, calls `TakeReadyMatch()` once `secondsElapsed >= 30` and `count >= 1`.
- On a failed start, `StartMatchmakingGameAsync` returns false (`LobbyService.cs:1197-1203`) -> `MatchmakingHostedService` calls `RequeuePlayers`, which **resets `_queueStartedUtc = UtcNow`** (`MatchmakingQueueService.RequeuePlayers`) — so another full 30s must elapse before the next attempt.
- Each failed cycle therefore costs roughly: up to **120s bootstrap timeout + 30s requeue countdown ≈ 150s**. Two cold failures ≈ ~5 min, three ≈ ~7.5 min — squarely in the reported **3-8 min** window, ending when the warm wineprefix finally bootstraps. CONFIDENCE: MEDIUM-HIGH that the 3-8 min is compounded (bootstrap-timeout x requeue), not a queue config value.

---

## 6. Cross-references / loose ends (outside E2, flagged for other agents)
- `start-match.sh` graphics negotiation (`nographics`/`glcore`/`d3d11`) and `wineprefix` reset behavior likely overlap with the "FPS drops / transparency / enemies invisible" rendering symptoms (E-render scope).
- The Content-Length-only mod listener (`PostJsonAsync`, `GameServerProcessManager.cs:~456`) means bootstrap reliability is partly a mod-side concern (mod-scope agent).
- AMP persistence of `GameServerReadyTimeoutSeconds` (H4) should be confirmed against the live instance config (D1/AMP-scope).

Confidence summary: sequence/file:line — HIGH (read directly). Timeout values — HIGH. H1 — HIGH. H2 — MEDIUM-HIGH. H3 — MEDIUM. H4 — LOW-MEDIUM. Queue 3-8 min compounding — MEDIUM-HIGH.

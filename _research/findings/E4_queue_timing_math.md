# E4 — Queue Timing Math

READ-ONLY research. Scope E4: quantify the matchmaking queue timing and explain the
observed "3–8 minutes, first attempt fails then works" behavior. No code/builds/deploys.

All paths relative to `C:\Users\Administrator\Downloads\CustomServer`.

---

## 1. Every timing constant (file:line + value + evidence)

### Queue timer / start gate
- `CustomMatchServer\MatchmakingQueueService.cs:8` — `public int QueueTimerSeconds { get; set; } = 30;`
- `CustomMatchServer\MatchmakingQueueService.cs:9` — `public int MinPlayersToStart { get; set; } = 1; // start even with 1 player (bots fill)`
- Effective config (workspace): `CustomMatchServer\appsettings.json` `MatchmakingQueue` block — `QueueTimerSeconds: 30`, `MinPlayersToStart: 1`.
- Effective config (deployed): `deployment\amp\package\server\linux-x64\BapCustomServer\appsettings.json:129` `"QueueTimerSeconds": 30`, `:130` `"MinPlayersToStart": 1` (win-x64 copy identical).
- Timer readiness gate: `CustomMatchServer\MatchmakingQueueService.cs:353` — `if (secondsElapsed < _options.QueueTimerSeconds) return false;` then `return _queue.Count >= _options.MinPlayersToStart;` (`:355`). So a lone player starts a match after **exactly 30 s**.

### Queue poll loop
- `CustomMatchServer\MatchmakingHostedService.cs:21` — `using var timer = new PeriodicTimer(TimeSpan.FromSeconds(1));` — queue is checked once per second (1 s granularity, negligible).

### Dedicated game-server bootstrap timeout (the big one)
- `CustomMatchServer\CustomServerOptions.cs:43` — DEFAULT `GameServerReadyTimeoutSeconds = 30;`
- **OVERRIDDEN to 120** in both configs:
  - `CustomMatchServer\appsettings.json:33` — `"GameServerReadyTimeoutSeconds": 120,`
  - `deployment\amp\package\server\linux-x64\BapCustomServer\appsettings.json:30` — `"GameServerReadyTimeoutSeconds": 120,` (win-x64 identical).
  - **Effective value = 120 s**, NOT the 30 s C# default. The worked timeline must use 120.
- `CustomMatchServer\CustomServerOptions.cs:44` — `GameServerReadyPollMillis = 500;` (poll interval inside the wait loop).
- `CustomMatchServer\CustomServerOptions.cs:45` — `GameServerBootstrapProgressLogSeconds = 15;` (log cadence only, no timing effect).
- Deadline computed at `CustomMatchServer\GameServerProcessManager.cs:189` — `DateTimeOffset deadline = startedAt.AddSeconds(_options.GameServerReadyTimeoutSeconds);`
- Wait loop `:203` — `while (DateTimeOffset.UtcNow < deadline && !cancellationToken.IsCancellationRequested)`; on each failed HTTP attempt it sleeps `await Task.Delay(_options.GameServerReadyPollMillis, ...)` (`:259`).

### KCP UDP-port wait (additive, after HTTP bootstrap accepted)
- `CustomMatchServer\GameServerProcessManager.cs:229` — `if (_options.RequireGameServerKcpPort && !await WaitForUdpPortAsync(session.KcpPort, ...))`
- `CustomMatchServer\GameServerProcessManager.cs:474` — `DateTimeOffset deadline = DateTimeOffset.UtcNow.AddSeconds(Math.Min(15, Math.Max(3, _options.GameServerReadyTimeoutSeconds)));` → with timeout=120 this clamps to **15 s** max.

### Post-spawn "/health" confirmation wait (after StartMatchServer returns)
- `CustomMatchServer\LobbyService.cs:1216` — `int maxWaitMs = 15000;` and `:1217` — `int pollMs = 200;` (matchmaking path). Same pair at `:1035`/`:1036` (custom-match path). Adds up to **15 s** before `GAME_STARTED` broadcast.

### In-match phase timers (AFTER GAME_STARTED — perceived "time to play", not queue time)
- `CustomMatchServer\CustomServerOptions.cs:374` `CharSelectMillis = 20000` (20 s), `:375` `SpawnSelectMillis = 10000` (10 s), `SpawnShowMillis = 3000` (3 s). Total ~**33 s** of in-match pre-game phases.

---

## 2. Failure / retry mechanics (why one cycle costs ~150 s)

Chain on the matchmaking path:

1. `MatchmakingHostedService.cs:32` calls `_queueService.TakeReadyMatch()` (fires at 30 s).
2. `:35` `bool started = await _lobbyService.StartMatchmakingGameAsync(players, ...)`.
3. `StartMatchmakingGameAsync` (`LobbyService.cs:1093`) → `_gameServers.StartMatchServerAsync(...)` (`LobbyService.cs:~1188`).
4. `StartMatchServerAsync` (`GameServerProcessManager.cs:33`) launches `bapbap.exe`, then `:138` `bool bootstrapped = await TryBootstrapServerAsync(...)`.
5. `TryBootstrapServerAsync` polls `/setup-game` `/add-teams` `/queue-matched` until the **120 s** deadline (`:189`/`:203`). On expiry it logs `did not accept bootstrap data before timeout` and returns `false`.
6. `GameServerProcessManager.cs:139` — `if (!bootstrapped && _options.RequireGameServerBootstrap)` (RequireGameServerBootstrap=true, appsettings `:17`) → kills process, **throws** `InvalidOperationException`.
7. `StartMatchmakingGameAsync` catch returns `false`; `MatchmakingHostedService.cs:36–38` → `_queueService.RequeuePlayers(players)`.
8. `RequeuePlayers` (`MatchmakingQueueService.cs`) re-adds players AND resets `_queueStartedUtc = DateTimeOffset.UtcNow` → **the full 30 s queue timer restarts**.

There is **no attempt counter / max-retries cap** — the loop is unbounded: it retries every (30 s timer + bootstrap duration) until a launch succeeds or all sockets drop. (`attempts` at `GameServerProcessManager.cs:192/216` only counts HTTP polls within ONE bootstrap window; it is not a cross-cycle retry limit.)

Early-exit shortcut: if the launched process dies before the deadline, `:205` `process.HasExited` returns `false` immediately, so a fast-crashing cold start fails in seconds rather than 120 s.

---

## 3. Worked timeline — how N failed cold starts sum to 3–8 min

Cost of ONE failed cold-start cycle (bootstrap never answers → hits deadline):

```
  30 s   queue timer (or 30 s requeue restart)
+ 120 s  GameServerReadyTimeoutSeconds bootstrap deadline
---------
~150 s   per failed cycle
```

Cost of the SUCCESSFUL cycle (warm process answers bootstrap):

```
  30 s   queue timer (requeue restart)
+ B  s   bootstrap accept time, 0..120 s (Unity warm start typically ~30–90 s)
+ ≤15 s  KCP UDP wait
+ ≤15 s  post-spawn /health wait
---------
~75–150 s
```

Total time from first queue join to `GAME_STARTED`:

| Failed cold cycles (N) | Failed time | + Success cycle | Total | Minutes |
|---|---|---|---|---|
| 0 (warm/lucky) | 0 | 30 + ~60 | ~90 s | ~1.5 min |
| 1 | 150 | ~75–150 | **225–300 s** | **3.75–5.0 min** |
| 2 | 300 | ~75–150 | **375–450 s** | **6.25–7.5 min** |
| 3 | 450 | ~75–150 | ~525–600 s | ~8.75–10 min |

The observed **3–8 min** window maps cleanly to **N = 1 to 2 failed cold-start cycles**, each dominated by the **120 s `GameServerReadyTimeoutSeconds`** plus the **30 s `QueueTimerSeconds`** restart that `RequeuePlayers` forces on every failure. (Add ~33 s of in-match Char/Spawn select if the user measured "time until actually playing.")

---

## 4. Does config make the first queue ~30 s, then failures balloon it? — YES

- First start gate is purely the queue timer: `MinPlayersToStart = 1` + `QueueTimerSeconds = 30` ⇒ a solo player triggers the FIRST match-start attempt at **t = 30 s** (`MatchmakingQueueService.cs:353–355`). Confirmed: the ~30 s baseline is config-driven.
- Failures balloon it because (a) each failed attempt burns up to **120 s** waiting on the cold dedicated server (`appsettings.json:33` / deployed `:30`), and (b) `RequeuePlayers` **restarts the full 30 s timer** instead of starting immediately — so every retry adds a fixed 150 s floor with no backoff cap.
- "First-attempt-fails-then-works" is fully consistent with timing: attempt #1 is a **cold** `bapbap.exe` launch (Wine prefix init / asset + shader load) that does not open its HTTP bootstrap listener within 120 s → timeout → requeue. By attempt #2 the OS file cache / Wine prefix / game files are **warm**, so the listener appears inside the 120 s window → success. (The *why-cold-start-is-slow* root cause is outside E4's timing scope — flagged for E-series VFX/Wine agents.)

---

## 5. Hypotheses + confidence

- **H1 (HIGH ~0.9):** The 3–8 min is `QueueTimerSeconds(30) + N×(30 + up-to-120) + success-cycle`. The 120 s `GameServerReadyTimeoutSeconds` is the dominant term; 1–2 failed cold cycles produce 3.75–7.5 min, matching observation.
- **H2 (HIGH ~0.9):** Baseline first-attempt latency is ~30 s by design (`MinPlayersToStart=1`, `QueueTimerSeconds=30`); failures, not the queue, cause the balloon.
- **H3 (HIGH ~0.85):** No retry cap exists; `RequeuePlayers` resets the 30 s timer each failure, so latency grows in ~150 s steps with no exponential backoff and no max-attempts ceiling (`MatchmakingHostedService.cs:32–38`, `MatchmakingQueueService.RequeuePlayers`).
- **H4 (MEDIUM ~0.6):** Real-world failed cycles may be *shorter* than 150 s when the cold process crashes early (`HasExited` short-circuit, `GameServerProcessManager.cs:205`); in that case more cycles fit in the same wall-clock window, still landing in 3–8 min.
- **H5 (MEDIUM ~0.55):** The effective timeout being 120 s (config override) rather than the 30 s C# default (`CustomServerOptions.cs:43`) is the single largest tunable; lowering it would shrink the per-failure cost but risks aborting legitimately-slow cold starts.
- **H6 (LOW–MED ~0.4):** Additive KCP wait (≤15 s, `:474`) + post-spawn /health wait (≤15 s, `LobbyService.cs:1216`) contribute up to ~30 s per *successful* cycle; minor vs the 120 s term but explains why even a clean run isn't instant after the 30 s timer.

---

## 6. Evidence quotes (verbatim)

- `MatchmakingQueueService.cs:8` `public int QueueTimerSeconds { get; set; } = 30;`
- `MatchmakingQueueService.cs:353` `if (secondsElapsed < _options.QueueTimerSeconds) return false;`
- `appsettings.json:33` `"GameServerReadyTimeoutSeconds": 120,`
- `GameServerProcessManager.cs:189` `DateTimeOffset deadline = startedAt.AddSeconds(_options.GameServerReadyTimeoutSeconds);`
- `GameServerProcessManager.cs:139` `if (!bootstrapped && _options.RequireGameServerBootstrap) { TryKill(process); ... throw new InvalidOperationException($"Game server {bootstrap.GameId} did not accept match bootstrap data."); }`
- `MatchmakingHostedService.cs:35-37` `bool started = await _lobbyService.StartMatchmakingGameAsync(players, stoppingToken); if (!started) { _queueService.RequeuePlayers(players); }`
- `GameServerProcessManager.cs:474` `... AddSeconds(Math.Min(15, Math.Max(3, _options.GameServerReadyTimeoutSeconds)));`
- `LobbyService.cs:1216-1217` `int maxWaitMs = 15000; int pollMs = 200;`

*(E4 covered only queue/bootstrap timing math. Items 1–5 of the umbrella brief — Medusa VFX/fallback/AMP-persistence — are out of E4 scope and owned by sibling agents.)*

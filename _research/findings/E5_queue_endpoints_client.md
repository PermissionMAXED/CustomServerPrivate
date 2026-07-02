# E5 — Queue Endpoints + Client Behavior (READ-ONLY findings)

Scope: matchmaking queue HTTP endpoints, server requeue/timer logic, GAME_STARTED/QUEUE_MATCHED
broadcast, and how the client reacts. Investigated for the user-visible "stuck 3–8 min" and
"first attempt fails then works" symptoms.

Files scanned (read-only, no changes):
- `CustomMatchServer\Program.cs`
- `CustomMatchServer\MatchmakingQueueService.cs`
- `CustomMatchServer\MatchmakingHostedService.cs`
- `CustomMatchServer\LobbyService.cs`
- `CustomMatchServer\GameServerProcessManager.cs`
- `CustomMatchServer\CustomServerOptions.cs`, `appsettings.json`
- `BapCustomServerMelon\CustomServerMod.cs`

---

## 1. Queue endpoints (file:line)

`CustomMatchServer\Program.cs`

- `POST /api/queue/join` — line **718**. Resolves identity, parses `charId`, calls
  `queueService.JoinQueue(...)`, returns `{ ok, message, position, secondsRemaining }`.
  Returns `ok:false` early when `MatchmakingPolicy == CustomOnly` (lines 720–723).
- `POST /api/queue/leave` — line **743** → `queueService.LeaveQueue(accountId)`.
- `POST /api/queue/cancel` — line **757** (alias), `GET /api/queue/cancel` — line **771**,
  `DELETE /api/queue` — line **765** (all aliases to `LeaveQueue`).
- `GET /api/queue/status` — line **778** → `queueService.GetStatus()` returns
  `{ PlayerCount, SecondsRemaining, IsActive, Players }`.

Queue state machine: `CustomMatchServer\MatchmakingQueueService.cs`
- `JoinQueue` lines 65–116; starts timer (`_queueStartedUtc`) on first player (lines 95–101).
- `TakeReadyMatch` lines 195–219: when ready it **clears the queue and sets
  `_queueStartedUtc = null`** (lines 209–210) before the match start is attempted.
- `RequeuePlayers` lines 221–252: re-adds entries with **fresh `JoinedUtc`** and resets
  `_queueStartedUtc = DateTimeOffset.UtcNow` (lines 240–243) → full timer restart.
- `GetSecondsRemainingInternal` lines 323–331: returns **full `QueueTimerSeconds` when
  `_queueStartedUtc is null`** (line 327). Default `QueueTimerSeconds = 30`
  (MatchmakingQueueService.cs:8, appsettings.json:134).

Driver loop: `CustomMatchServer\MatchmakingHostedService.cs` — `PeriodicTimer(1s)` (line 21),
`TakeReadyMatch()` each tick (line 27); on `!started` calls `RequeuePlayers(players)` (lines 36–38);
on exception also requeues (lines 50–52).

## 2. Client polling (file:line)

The MelonLoader mod does **NOT** poll `/api/queue/*` and does **NOT** parse GAME_STARTED itself.
Grep for `/api/queue`, `queue/status`, `secondsRemaining` in `CustomServerMod.cs` = **0 matches**.
The mod is a transparent HTTP/WS reverse proxy; the **native BAPBAP client** issues the queue
HTTP calls and consumes `secondsRemaining`/`PlayerCount` and the WS `GAME_STARTED`/`QUEUE_MATCHED`
events. The mod only:
- Harmony-wraps the game's own WS handlers `HandleGameStartedMessage`, `HandleQueueMatchedMessage`,
  etc. with NullRef finalizers (`CustomServerMod.cs` lines ~2952–2965, target list 2945–2965).
- Dedups the "MATCH FOUND" splash that both `LobbyController` and `MatchmakingController` play on
  `QUEUE_MATCHED` (`CustomServerMod.cs` lines 6633–6688, `MatchFoundDedupPrefix`).
- Runs a managed match-bootstrap TCP listener (lines 4457–4521) — unrelated to queue display.

Implication: the on-screen queue timer the user sees is **entirely server-driven** via the
`secondsRemaining`/`PlayerCount` values the native client polls from `GET /api/queue/status`
and the `secondsRemaining` returned by `POST /api/queue/join`.

## 3. GAME_STARTED / QUEUE_MATCHED broadcast (file:line)

`CustomMatchServer\LobbyService.cs`, `StartMatchmakingGameAsync` (begins ~line 1089):
- Capacity gate: `if (MaxConcurrentMatches > 0 && _matches.Count >= Max) return false;` line **1100**
  → hosted service requeues. Default `MaxConcurrentMatches = 0` (unlimited) — CustomServerOptions.cs:26.
- **No-live-socket drop:** if no queued account has an active WS, logs "no queued players had an
  active websocket … returning success so they are NOT requeued" and **`return true`** (~lines
  1117–1128). This makes the hosted service **skip requeue** — players are silently dropped with
  **no GAME_STARTED and no requeue**.
- `QUEUE_MATCHED` broadcast: `BroadcastAsync(lobby, Events.QueueMatched, ...)` (~line 1205, comment
  block 1207–1212), then an inline 15 s `/health` poll of the dedicated process (~1213–1240).
- `GAME_STARTED` multicast: `foreach (LobbyPlayer ...)` selecting
  `_clients.Values.Where(client.AccountId == player.AccountId)` and `SendAsync(... Events.GameStarted ...)`
  comment at line **1246**, loop ~1244–1272. If `targets.Length == 0` it `continue`s (skips the
  player). Same pattern for the custom-match path at lines **1062–1090** (comment line 1065).

WS keepalive: `Program.cs:144` `KeepAliveInterval = TimeSpan.FromSeconds(20)`; `/ws` mapped at
`Program.cs:937`, accept at 946. Protocol-level keepalive should survive long spawn waits **if** the
reverse proxy forwards control frames.

## 4. Match-start timing (root of the multi-minute stall)

`GameServerProcessManager.StartMatchServerAsync` (line 33) spawns the process then
**awaits `TryBootstrapServerAsync`** (line ~136). That bootstrap wait loop (lines 185–264) runs until
`deadline = startedAt + GameServerReadyTimeoutSeconds`. **`GameServerReadyTimeoutSeconds = 120`**
(appsettings.json:33; default 30 in CustomServerOptions.cs:43). On failure with
`RequireGameServerBootstrap`, it kills the process and **throws** (lines ~137–142), which propagates
to `StartMatchmakingGameAsync` → matchmaking returns false → `RequeuePlayers`.

So a single failed cold start can block up to **120 s** inside the start attempt, then requeue with a
**fresh 30 s timer**, then a successful start adds ~another 30–60 s to spawn/bootstrap.
1 failure ≈ 120 + 30 + 60 ≈ 3.5 min; 2 failures ≈ 5–8 min. This matches the reported window.

---

## Deliverable answers

**Does the client show a misleading timer while the server requeues?** — Very likely YES.
1. `TakeReadyMatch` clears the queue and nulls `_queueStartedUtc` (MatchmakingQueueService.cs:209–210)
   the instant a start is attempted. For the up-to-120 s duration of `StartMatchServerAsync`, a client
   polling `GET /api/queue/status` sees `PlayerCount = 0`, `IsActive = false`, and
   `SecondsRemaining = 30` (full reset, GetSecondsRemainingInternal:327). The UI looks like an empty,
   freshly-reset queue while the server is actually mid-spawn.
2. On a failed start, `RequeuePlayers` restarts the timer at 30 s (line 240–243). The native client's
   countdown therefore **restarts from 30 each failed cycle**, so the user sees the timer "loop"
   3–8 min with no progress indication that a spawn is in flight. The server has **no field**
   communicating "match is spawning"/"requeued after failure" to the client — only the generic queue
   counters. Confidence: **High** for the server-side cause; **Medium** that the native UI renders it
   as the described misleading loop (client UI source not in scope/repo).

**Does the WS lobby connection reliably receive GAME_STARTED after a requeue?** — Conditionally.
- If the account has a live WS in `_clients` at broadcast time, GAME_STARTED is multicast to **all**
  its connections (LobbyService.cs:1244–1272) — reliable, and resilient to multiple sockets.
- Two concrete failure paths break reliability:
  (a) **No-live-socket drop** (~1117–1128): if the WS is momentarily absent when the 1 s hosted tick
      fires `TakeReadyMatch`, players are dropped with `return true` → no GAME_STARTED, **no requeue**.
      The player is left in lobby with nothing → must manually re-queue. Strong candidate for
      "first attempt fails, then works."
  (b) **WS drop during the up-to-120 s bootstrap wait**: if the socket idles/drops while the dedicated
      process is spawning, the final multicast finds `targets.Length == 0` and `continue`s — the match
      starts **without** notifying the player. KeepAliveInterval=20 s (Program.cs:144) mitigates this
      only if the proxy chain forwards ping frames.
- Confidence: **High** that paths (a)/(b) exist in code; **Medium** on how often they trigger live.

**Hypotheses for user-visible "stuck 3–8 min" (ranked):**
1. **(High)** Cold dedicated-server spawn under Wine/Xvfb fails or exceeds the 120 s
   `GameServerReadyTimeoutSeconds`, throwing → requeue with fresh 30 s timer → retry. One or two such
   cycles produce 3.5–8 min. The client only ever sees a looping 30 s countdown.
2. **(Medium-High)** "First attempt fails then works" = the no-live-socket drop (LobbyService.cs
   ~1117–1128) or a first cold-spawn timeout, with the second (warm) attempt succeeding because ports
   are freed / caches warm and the WS is now stably registered.
3. **(Medium)** `_queueStartedUtc` reset to `null` during the spawn window makes the queue look empty
   to status polls, so any client-side "are we still queued?" logic may re-issue join, compounding the
   perceived delay.
4. **(Low-Medium)** WS dropping during the long bootstrap wait → GAME_STARTED multicast hits zero
   targets → silent stall until the user backs out and re-queues.

**Not the cause within E5 scope:** the queue endpoints themselves are simple and correct; the stall is
driven by (a) the 120 s blocking bootstrap inside the start attempt and (b) the binary
clear/requeue/timer-reset model with no "spawning" signal to the client.

## Notes / handoffs to other agents
- The 120 s `GameServerReadyTimeoutSeconds` and why cold spawns fail belong to the
  Wine/Xvfb/process-manager agent (see `docs/AMP_LINUX_WINE_ROOT_CAUSE.md`).
- The actual on-screen timer rendering lives in native `BAPBAP.UI.MatchmakingController` /
  `LobbyController` (not in this repo); E5 can only confirm the server inputs that drive it.

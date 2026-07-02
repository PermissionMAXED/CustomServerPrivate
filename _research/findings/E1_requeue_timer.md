# E1 — Requeue Timer-Reset Loop (long matchmaking queues 3–8 min, "first attempt fails then works")

Agent: `E1_requeue_timer` · Mode: READ-ONLY research · Date: 2026-06-01
Scope: the matchmaking requeue loop that restarts the 30s queue timer on every failed
game-server start, causing 3–8 min queues and the "fails first, works on retry" pattern.

> NOTE: Items (1)–(5) of the broad brief (Medusa VFX/fallback/persistence/AMP) are owned by
> sibling agents. This file delivers **E1 only** — the requeue/timer half of item (6).

---

## TL;DR (high confidence)

A failed `StartMatchmakingGameAsync` puts the players **back** in the queue **and resets the
queue start time to "now"**, which restarts the full `QueueTimerSeconds` (30s) countdown. Because
the dedicated game process bootstrap can take up to **120s** to fail (`GameServerReadyTimeoutSeconds`),
each failed attempt costs ≈ **120s (bootstrap timeout) + 30s (fresh queue wait) ≈ 150s**. One or two
failed bootstrap cycles before a warm process succeeds yields the observed **~3.5–7 min** end-to-end,
and the "first attempt fails, second works" is a **cold-start** dedicated process missing its first
120s bootstrap window, then succeeding warm.

---

## Evidence chain (file:line)

### 1. The 1-second poll loop and the failure→requeue branch
`CustomMatchServer/MatchmakingHostedService.cs`

- **L21** `using var timer = new PeriodicTimer(TimeSpan.FromSeconds(1));`
- **L28** `var ready = _queueService.TakeReadyMatch();`
- **L35** `bool started = await _lobbyService.StartMatchmakingGameAsync(players, stoppingToken);`
- **L36–38**
  ```csharp
  if (!started)
  {
      _queueService.RequeuePlayers(players);
  }
  ```
- Plus the exception path (catch Exception) also requeues:
  ```csharp
  catch (Exception ex) { ... if (players.Length > 0) { _queueService.RequeuePlayers(players); } }
  ```

So **a failed start (return false OR throw) re-enters the players via `RequeuePlayers`.** PROVEN.

### 2. `TakeReadyMatch` consumes the queue and clears the timer
`CustomMatchServer/MatchmakingQueueService.cs`

- **L192** `public (bool ShouldStart, QueueEntry[] Players) TakeReadyMatch()`
- **L196** `if (!IsReadyInternal(out int secondsElapsed)) return (false, []);`
- **L203** `_queue.Clear();`
- **L204** `_queueStartedUtc = null;`   ← queue/timer fully reset when a match is taken

### 3. `RequeuePlayers` re-adds players AND resets `_queueStartedUtc = now`  ← THE BUG
`CustomMatchServer/MatchmakingQueueService.cs`

- **L218** `public void RequeuePlayers(IEnumerable<QueueEntry> players)`
- **L230–232** re-add each player (`player.JoinedUtc = DateTimeOffset.UtcNow; _queue.Add(player);`)
- **L236–238**
  ```csharp
  if (_queue.Count > 0)
  {
      _queueStartedUtc = DateTimeOffset.UtcNow;   // ← restarts the full 30s countdown
  }
  ```

This is the proof the brief asks for: **a failed `StartMatchmakingGameAsync` requeues players AND
sets `_queueStartedUtc = now`, restarting the 30s timer.** PROVEN (L36–38 → L218 → L238).

### 4. The 30s gate that must re-elapse after every requeue
`CustomMatchServer/MatchmakingQueueService.cs`

- **L50** `private DateTimeOffset? _queueStartedUtc;`
- **L345** `private bool IsReadyInternal(out int secondsElapsed)`
- **L348** `if (_queue.Count == 0 || _queueStartedUtc is null) return false;`
- **L350** `secondsElapsed = (int)(DateTimeOffset.UtcNow - _queueStartedUtc.Value).TotalSeconds;`
- **L353** `if (secondsElapsed < _options.QueueTimerSeconds) return false;`  ← needs full 30s again
- `GetSecondsRemainingInternal` **L324–** recomputes remaining from `_queueStartedUtc`, so after a
  requeue a client polling `GET /api/queue/status` sees the countdown **jump back up to 30s**
  (visible symptom of the reset).

Config: `MatchmakingQueueOptions.QueueTimerSeconds = 30` (`MatchmakingQueueService.cs:8`) and
`appsettings.json:134 "QueueTimerSeconds": 30`, `:135 "MinPlayersToStart": 1`.

### 5. Why `StartMatchmakingGameAsync` returns false / throws (the failure source)
`CustomMatchServer/LobbyService.cs` (method **L1093–1275**)

- **L1097** `return false;` — no queue entries.
- **L1100–1105** `return false;` — at capacity (`MaxConcurrentMatches`). Fast failure → tight 30s loops.
- **L1129** `return true;` — no live websocket for queued accounts: deliberately returns **true** so
  RequeuePlayers is skipped ("would otherwise create a zombie loop ... fire every 30s, no players,
  requeue, fire again"). So the infinite loop is avoided **only** when sockets are absent; with a real
  connected player waiting, a failed dedicated launch DOES requeue (the 3–8 min case).
- **L1195** `session = await _gameServers.StartMatchServerAsync(bootstrap, cancellationToken);`
- **L1202** `return false;` — catch block when `StartMatchServerAsync` **throws** (the dedicated game
  process didn't accept bootstrap). This is the dominant 3–8 min trigger.

### 6. How long a single failure takes (drives the 3–8 min math)
`CustomMatchServer/GameServerProcessManager.cs`

- `StartMatchServerAsync` **L33–164**; on `!bootstrapped && RequireGameServerBootstrap` it throws
  `"Game server {GameId} did not accept match bootstrap data."` (kills process, releases ports).
- `TryBootstrapServerAsync` **L184–271**:
  - **L188** `deadline = startedAt.AddSeconds(_options.GameServerReadyTimeoutSeconds);`
  - polls `BootstrapConnectPath/AddTeams/QueueMatched` every `GameServerReadyPollMillis` (500ms),
  - returns **false** on timeout (**L264–271**) or if the process exits early.
- `appsettings.json`: **:20** `"RequireGameServerBootstrap": true`, **:33**
  `"GameServerReadyTimeoutSeconds": 120`, **:34/:35** poll 500ms / progress-log 15s.

⇒ A bootstrap that never succeeds blocks the hosted-service loop for **~120s** before
`StartMatchmakingGameAsync` returns false and the requeue (L238) restarts the 30s timer.

---

## Timing computation: how repeated failures ⇒ 3–8 minutes

Let `B` = time for one failed `StartMatchServerAsync` (bootstrap), `Q` = QueueTimerSeconds = 30s.
Per failed cycle the players wait ≈ `B + Q` before the next start is even attempted.

| Failure mode | B (per attempt) | Cycle = B+Q | 1 fail+success | 2 fails+success |
|---|---|---|---|---|
| **Bootstrap timeout** (cold process never readies) | ~120s | ~150s | 150 + (~60–120 final) ≈ **3.5–4.5 min** | 300 + (~60–120) ≈ **6–7 min** |
| **Process crash-exits fast** (HasExited) | ~1–5s | ~35s | needs ~6–14 cycles to reach 3–8 min | ~6–14 retries × 35s ≈ 3.5–8 min |
| **Capacity (`MaxConcurrentMatches`)** | ~0s | ~30s | ~6–16 loops ≈ 3–8 min | same |

The **bootstrap-timeout row** matches the report most cleanly: **1–2 failed 120s bootstraps + one
final successful start = ~3.5 to ~7 min**, squarely inside the observed 3–8 min window, with very few
retries (consistent with "first attempt fails, then it works").

Note: while one bootstrap is being awaited (~120s), the 1s PeriodicTimer loop is **serially blocked**
inside `await StartMatchmakingGameAsync` (single-threaded loop), so no parallel attempts overlap — the
delays are strictly additive, which is why a couple of failures already reach minutes.

---

## "First attempt fails, then works" — mechanism

- The dedicated match is a real Windows/Wine `bapbap.exe` (`appsettings.json` GameExecutablePath,
  HeadlessArguments). A **cold** process + cold Wine prefix + MelonLoader init frequently exceeds the
  120s `GameServerReadyTimeoutSeconds` on first launch → bootstrap timeout → `return false` (L1202) →
  `RequeuePlayers` (L238) restarts the 30s timer.
- The retry launches a now-**warm** environment (filesystem cache, Wine prefix, JIT/asset warm-up), so
  bootstrap completes inside 120s → `StartMatchServerAsync` succeeds → `GAME_STARTED`.
- README corroborates the cost: "server takes ~60s to spawn and bootstrap a fresh dedicated process"
  and recommends `GameServerReadyTimeoutSeconds 150` for cold runs — i.e. 120s is borderline for a cold
  first launch, exactly producing a first-attempt failure.

---

## Secondary observations / contributing factors

- `JoinQueue` starts the timer only when `_queueStartedUtc is null` (**L92–94**); `LeaveQueue` nulls it
  when empty (**L158**). These are correct. The **only** place the timer is restarted while players
  remain mid-flow is `RequeuePlayers` **L238** — the loop's restart point.
- `MinPlayersToStart = 1` + bots fill means a lone real player can trigger the start→fail→requeue cycle
  indefinitely as long as their socket stays connected (the L1129 zombie guard does NOT apply because a
  live socket exists).
- Client UX symptom: because `GetSecondsRemainingInternal` is derived from `_queueStartedUtc`, every
  requeue makes `secondsRemaining` (in `GET /api/queue/status`) snap back to 30 — the player sees the
  countdown "reset" each time, which reads as a stuck/long queue.

---

## Hypotheses & confidence

- **H1 (PRIMARY) — Requeue resets the 30s timer; combined with the 120s bootstrap timeout, 1–2 cold-start
  failures produce 3–8 min queues and the "fails-then-works" pattern.**
  Evidence: HostedService L35–38 → QueueService L218/L238 (timer reset) + L353 (30s re-gate) +
  GameServerProcessManager L188 (120s) + LobbyService L1195/L1202. **Confidence: HIGH (~0.9).**

- **H2 — Even when failures are fast (capacity at L1100–1105, or fast process crash-exit), the L238 reset
  still forces a fresh 30s wait per retry, so a burst of fast failures alone can also stack to 3–8 min.**
  Plausible secondary path; would show many "Requeued ... player(s)" log lines.
  **Confidence: MEDIUM (~0.55).** Distinguishable from H1 by retry count + per-attempt latency in logs.

- **H3 — The fix shape:** on requeue, preserve the original `_queueStartedUtc` (do NOT reset to now), OR
  bound total requeues / use exponential backoff, OR raise `GameServerReadyTimeoutSeconds` to ~150s so
  the first cold launch succeeds. (Analysis only — NO change made, per read-only scope.)
  **Confidence: MEDIUM-HIGH (~0.7)** that not resetting `_queueStartedUtc` removes the per-failure +30s.

## What I could NOT verify (read-only, no runtime)

- Actual production failure mode (bootstrap-timeout vs fast-crash vs capacity) — needs the live AMP
  `logs/game-servers/*.log` + server log lines `"Requeued {Count} ... after failed match start."`,
  `"did not accept bootstrap data before timeout"`, and `Dedicated server bootstrap timeout`.
- Whether `MaxConcurrentMatches` is set >0 in the live AMP config (would enable the capacity fast-fail
  path of H2). Only the in-repo `appsettings.json` was read.

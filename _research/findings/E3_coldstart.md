# E3 — Cold Start: why the FIRST match attempt fails, then a later one works

Scope: read-only research. Evidence is file:line + quotes from
`C:\Users\Administrator\Downloads\CustomServer`. No code changed.

## TL;DR

The first match after a fresh server/container start pays a one-time Wine/Unity
cold-start cost (32-bit Wine prefix `wineboot -u` init + first Unity-under-Wine
load + cold OS/shader/page caches). During that window the per-match bootstrap
HTTP listener is **not yet open**, so the lobby server's bootstrap POSTs get
**connection refused**. If that exceeds the bootstrap deadline, the server kills
the match and throws. The matchmaking path then **requeues** the players, and a
later attempt — now warm — succeeds. There is **no warm pool, no process reuse,
and the `--prewarm` hook is never invoked**, so the cold cost is always paid by
the first real match. This matches the "first round only" symptom directly.

Confidence overall: **HIGH**.

---

## 1. Doc evidence: cold Wine/Unity leaves the bootstrap port closed initially

`docs\AMP_LINUX_WINE_ROOT_CAUSE.md`

- The exact repeated failure (quote):
  ```
  POST http://127.0.0.1:7850/setup-game
  Connection refused
  Game server ... did not accept match bootstrap data before timeout
  ```
- Cause statement (quote): *"the ASP.NET lobby server had already decided to
  start a match, but the Windows Unity match process had not opened its internal
  bootstrap HTTP listener on the per-match HTTP port. The client therefore sat in
  queue or was requeued because the server correctly refused to send players into
  a dead match."*
- Startup instability extends the window (quote, cause #2): *"Unity/Wine graphics
  startup was unstable in AMP. Some modes produced shader/graphics noise and
  delayed or prevented bootstrap readiness."*
- Explicit "port only exists once warm" note (quote, "What not to change"):
  *"Do not treat an idle closed `7850/tcp` as a failure. The bootstrap port only
  exists while a match process is starting or running."*

Conclusion: the doc states, in plain language, that the bootstrap port is closed
until the cold Unity-under-Wine process finishes coming up. **Confidence: HIGH.**

---

## 2. The first match pays a one-time Wine-prefix init; later matches skip it

`deployment\amp-full-linux-wine\start-match.sh`

- `WINESERVER_TIMEOUT=0` (line 84) — the wineserver stays resident after the
  first launch, so later launches reuse a warm Wine session (OS-level warmth).
- Prefix init is **gated on a persisted marker file** (lines 186–192):
  ```bash
  if [[ -n "$WINEBOOT_BIN" && ! -f "$WINEPREFIX/.bapcustom-wineboot-ok" ]]; then
    echo "[start-match] initializing wineprefix"
    "$XVFB_RUN_BIN" -a --server-args="$XVFB_SERVER_ARGS" "$WINEBOOT_BIN" -u
    printf '%s' "$PREFIX_KEY" > "$PREFIX_KEY_FILE"
    touch "$WINEPREFIX/.bapcustom-wineboot-ok"
    echo "[start-match] wineprefix ready"
  fi
  ```
  `wineboot -u` (the slow part) runs **only on the first match** (or after a
  prefix reset on lines 176–185). Every later match finds the
  `.bapcustom-wineboot-ok` marker and skips straight to the Unity launch
  (`exec ... wine "$GAME_EXE" ...`, line 199).

So the first match alone bears: prefix bootstrap + cold Unity image load + cold
shader/page caches. Subsequent matches reuse the persisted prefix, the resident
wineserver, and warm OS caches → they reach the bootstrap listener far faster.
**Confidence: HIGH.**

---

## 3. There is NO warm pool / NO process reuse, and `--prewarm` is never called

`CustomMatchServer\GameServerProcessManager.cs`

- Every match start spawns a **brand-new process** — `StartMatchServerAsync`
  (line 33) → `Process.Start(startInfo)` (≈ line 125). There is no pool, no
  reuse, and no keep-alive of a previous match process. `StopMatchServer`
  (after the method) kills and disposes the process at match end.
- The bootstrap wait is a **single launch with a poll loop**, not a relaunch:
  `TryBootstrapServerAsync` polls the POST every `GameServerReadyPollMillis`
  until `deadline = startedAt.AddSeconds(_options.GameServerReadyTimeoutSeconds)`
  (line 189). It never restarts the Unity process within one match-start call.
- On bootstrap failure it kills and throws (lines 139–145):
  ```csharp
  if (!bootstrapped && _options.RequireGameServerBootstrap)
  {
      TryKill(process);
      _ports.ReleaseImmediately(httpPort, wsPort, kcpPort, tcpPort);
      releaseStartupPorts = false;
      throw new InvalidOperationException($"Game server {bootstrap.GameId} did not accept match bootstrap data.");
  }
  ```

`start-match.sh` has a `--prewarm` mode (lines 5–8 set `PREWARM_ONLY`, lines
194–197 `echo "[start-match] prewarm complete; exiting before Unity match
launch"; exit 0`) that would warm the prefix without launching a match.
**A repo-wide grep for `--prewarm` returns exactly one hit — its own definition
in `start-match.sh:6`.** No AMP/start script (`amp-webpanel-start.sh`,
`start-linux-wine.sh`, setup scripts) ever invokes it. So the prewarm capability
exists but is **not wired up**; the cold cost is always paid by the first real
match. **Confidence: HIGH.**

---

## 4. The default bootstrap timeout is too short for a cold start

- Compiled default: `CustomServerOptions.cs:43` →
  `public int GameServerReadyTimeoutSeconds { get; set; } = 30;`
  with `RequireGameServerBootstrap = true` (line 28) and
  `RequireGameServerKcpPort = true` (line 29).
- But **every shipped config and every test overrides it to 120–240s**, which is
  strong evidence the cold path routinely needs >30s:
  - `CustomMatchServer\appsettings.json:33` → `"GameServerReadyTimeoutSeconds": 120`
  - `deployment\amp-github-autoinstall\bapcustomservergithub.kvp:30` →
    `CustomServer__GameServerReadyTimeoutSeconds":"120`
  - `tools\Build-AmpFullLinuxWinePackage.ps1:331` → sets it to `120`
  - `README.md:52` full hosted smoke → `-GameServerReadyTimeoutSeconds 150`
  - `tools\Test-FullE2E.ps1:57`, `Test-FullIntegration.ps1:47`,
    `Test-MatchmakingAutostart.ps1:120` → `150`
  - `TEMP-kvp-08ccfc2.txt:91` → `240`
  - Sibling finding `_research\findings\E2_startgame_bootstrap.md:118` already
    notes: *"If a deployment runs with the compiled default (30) ... virtually
    every cold first launch times out; the second (warm) launch fits in 30s."*

So if a live instance is effectively running with the 30s default (not the
120s override), the cold first attempt is almost guaranteed to time out, while
the warm second attempt fits. Even at 120s, a sufficiently slow cold Unity/Wine
boot under software rendering can still miss the first window. **Confidence: HIGH
that the default is too short; MEDIUM on which value the live instance actually
runs (needs a live `$.CustomServer.GameServerReadyTimeoutSeconds` check).**

---

## 5. "Fails then works" + "queue 3–8 min": the requeue loop

Matchmaking path (auto-retry):
- `MatchmakingHostedService.cs` runs a 1s `PeriodicTimer`; on a failed start it
  requeues:
  ```csharp
  bool started = await _lobbyService.StartMatchmakingGameAsync(players, stoppingToken);
  if (!started) { _queueService.RequeuePlayers(players); }      // line 38
  ...
  catch (Exception ex) { ... if (players.Length > 0) { _queueService.RequeuePlayers(players); } }  // line 50
  ```
- `MatchmakingQueueService.RequeuePlayers` (line 218) resets each entry's
  `JoinedUtc = DateTimeOffset.UtcNow` and restarts the queue clock
  (`_queueStartedUtc = DateTimeOffset.UtcNow`), logging *"Requeued {Count}
  matchmaking player(s) after failed match start."* (line 243).
- The queue timer is `QueueTimerSeconds = 30` with `MinPlayersToStart = 1`
  (`MatchmakingQueueService.cs:8–9`).

Net effect: cold attempt fails → ~30s requeue wait → next attempt (often still
warming) → possibly fails again → another ~30s → eventually warm → success.
Stacking the 30s queue cycles, the cold Unity load (tens of seconds to >1 min),
and the 120s bootstrap wait per attempt produces a **multi-minute "stuck in
queue" window (the reported 3–8 min)** that resolves on a later attempt.
**Confidence: HIGH** for the mechanism; the exact minute count depends on how
many attempts the cold boot needs.

Custom-match (host PLAY) path — no auto-retry:
- `LobbyService.cs:1004` calls `StartMatchServerAsync`; on failure (lines
  ~1006–1016) it sets `lobby.Starting = false` and sends `StartCustomGameFail`
  with `errorCode = "ERR_GAME_SERVER_BOOTSTRAP"`. There is **no automatic
  requeue** here — the leader must press PLAY again. So the host-driven path
  shows the same "first press fails, second press works" once the prefix/Unity
  is warm. **Confidence: HIGH.**

---

## 6. Does "first round only" match the cold-start theory?

**Yes — strongly.** All the one-time costs cluster on the first match after a
container/server (re)start:
- `wineboot -u` prefix init runs once and is then skipped (start-match.sh:186).
- The wineserver stays resident (`WINESERVER_TIMEOUT=0`, start-match.sh:84).
- OS page cache, Mesa/llvmpipe shader compilation, and Unity asset load are cold
  on the first launch and warm afterward.
- No process pool means warmth is at the Wine/OS/filesystem-cache layer, not a
  reused match process — but that is exactly enough to push the second attempt
  inside the bootstrap deadline.

After the first successful match, those caches persist for the container's
lifetime, so later matches reliably reach the bootstrap listener in time. A new
"first round" failure would only reappear after a full container/prefix reset
(e.g., the prefix-key reset on start-match.sh:176–185, or an AMP update that
wipes the prefix). **Confidence: HIGH.**

---

## Hypotheses ranked

1. **Cold Wine-prefix init + cold Unity load makes the first match miss the
   bootstrap deadline; requeue/retry succeeds once warm.** Confidence: **HIGH.**
   Direct doc + code support (sections 1–3, 5–6).
2. **Effective bootstrap timeout on the live instance may still be the 30s
   compiled default rather than the 120s override, guaranteeing the cold miss.**
   Confidence: **MEDIUM** — needs a live `GameServerReadyTimeoutSeconds` read;
   default is 30 (`CustomServerOptions.cs:43`) but configs ship 120.
3. **The unused `--prewarm` hook is the intended (but unwired) fix.** Wiring
   `start-match.sh --prewarm` into server startup would pay the prefix cost
   before the first player queues and likely remove the first-round failure.
   Confidence: **MEDIUM-HIGH** that this is the mechanism designers intended;
   not verified in a live run.

## Open items to verify on the live host (read-only)
- Effective `$.CustomServer.GameServerReadyTimeoutSeconds` in the running AMP
  instance config.
- Wrapper/Unity logs of the *first* failed match vs the *second* success:
  look for `[start-match] initializing wineprefix` on attempt 1 only, and
  `setup-game Connection refused` → later `Bootstrapped game server` on the
  retry.
- Whether the live instance shows multiple `Requeued ... after failed match
  start.` log lines preceding a success (confirms the 3–8 min requeue loop).

## Key file:line index
- `docs\AMP_LINUX_WINE_ROOT_CAUSE.md` — connection-refused symptom, bootstrap-
  listener-not-open cause, "port only exists while starting/running".
- `deployment\amp-full-linux-wine\start-match.sh:5-8` (`--prewarm` flag),
  `:84` (`WINESERVER_TIMEOUT=0`), `:176-185` (prefix reset),
  `:186-192` (one-time wineboot init), `:194-197` (prewarm exit), `:199` (exec).
- `CustomMatchServer\GameServerProcessManager.cs:33` (StartMatchServerAsync),
  `~125` (Process.Start, fresh per match), `:139-145` (kill+throw on bootstrap
  fail), `:189` (deadline = GameServerReadyTimeoutSeconds).
- `CustomMatchServer\CustomServerOptions.cs:28` (RequireGameServerBootstrap),
  `:43` (GameServerReadyTimeoutSeconds=30), `:44` (poll 500ms).
- `CustomMatchServer\MatchmakingHostedService.cs:38,50` (RequeuePlayers).
- `CustomMatchServer\MatchmakingQueueService.cs:8-9` (QueueTimerSeconds=30,
  MinPlayersToStart=1), `:218-243` (RequeuePlayers resets JoinedUtc/clock).
- `CustomMatchServer\LobbyService.cs:1004-1016` (custom-match start + failure,
  no auto-requeue).
- `CustomMatchServer\appsettings.json:33` / AMP kvp `:30` (120s override).

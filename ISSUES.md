# ISSUES — Custom Server Stack Audit

**Generated:** 2026-07-02  
**Scope:** Exit-to-lobby flow, stutter/micro-freeze, bot count, augment UI, server lifecycle, proxy/overlay performance.

---

## Note on subagent run

Four parallel analysis subagents were launched (CustomServerMod hotpath, exit flow, proxy/overlay, server quality) but **were interrupted before returning reports**. This document consolidates:

1. Findings from `HANDOFF_2026-06-30_exit-bots-stutter.md` and follow-up notes (2026-07-01).
2. A direct code audit covering the same analysis areas, with file + line references.

---

## Status legend

| Status | Meaning |
|--------|---------|
| **OPEN** | Not fixed or not verified in production |
| **FIXED-LOCAL** | Code change exists locally; user has not confirmed on live AMP / fresh client |
| **FIXED-VERIFIED** | Verified locally (logs, screenshot, or xUnit) |
| **WONTFIX / BY-DESIGN** | Known limitation or intentional stub |

---

## Priority summary (action order)

| P | Issue | Area | Status |
|---|-------|------|--------|
| **P0** | Bot count capped at ~8 despite server requesting 20 | Game binary / NetworkedCustomChar | **OPEN** |
| **P0** | Client stuck in match scene after server-side end (WARMUP repro) | Client + server grace-stop | **OPEN** |
| **P1** | Augment UI vanish → reappear → can't select | Client mod | **OPEN** |
| **P1** | Medusa shown as Kitsu to other players/bots | NetworkedCustomChar (separate repo) | **OPEN** |
| **P1** | Stutter / standbild from HTTP polling | Client proxy | **FIXED-LOCAL** (needs user retest) |
| **P1** | Char-pick UI reappears after Exit-to-Lobby | Client + server | **FIXED-VERIFIED** (local) |
| **P2** | Aggressive lobby UI cleanup broke top nav + FPS | Client mod | **FIXED-LOCAL** |
| **P2** | Post-match auto-requeue (char-select loop) | Server | **FIXED-VERIFIED** (xUnit + local client) |
| **P2** | `TryRecoverStaleLobbyQueueUi` uses `.Result` on main thread | Client mod | **OPEN** (low severity) |
| **P3** | Misleading augment timer log says "30s" but sets 10s | Client mod | **OPEN** (cosmetic) |
| **P3** | `AdminOverlay.cs` excluded from build | Client mod | **BY-DESIGN** (dev-only, not shipped) |
| **P3** | Medusa VFX still basic / build issues in BAPBAPModdingAPI | Separate repo | **OPEN** |

---

## 1. Performance / stutter / micro-freeze (client hotpath)

### 1.1 HTTP body logging caused periodic standbild — FIXED-LOCAL

**File:** `BapCustomServerMelon/LocalReverseProxy.cs` (~657–665)

**Was:** `LogAllHttpTraffic` dumped full REQ/RES JSON bodies on every metagame poll (multi-KB IAP/profile listings). Synchronous log writes every few seconds caused visible freezes.

**Now:** Only a one-line status is logged (`[NET] HTTP … -> statusCode`). Comment documents the fix explicitly.

**Verify:** Install client DLL with md5 ≠ `eaf325cf…` / `d2b0f9f2…`; confirm no multi-KB log lines during lobby idle; user eyes on in-match smoothness.

---

### 1.2 Per-second PreMatch FindObjectsOfType poll — FIXED-LOCAL

**File:** `BapCustomServerMelon/CustomServerMod.cs` (~595–599)

**Was:** `TryDismissStalePreMatchCharSelectUi` ran every second with heap walks; never dismissed live prematch UI; caused in-match stutter.

**Now:** Removed from `OnUpdate`. Exit cleanup handled only by `MonitorMatchDisconnectAndCleanPreMatchUi()` after Mirror disconnect.

---

### 1.3 Uncached `HasActiveMatchRuntime()` every frame — FIXED-LOCAL

**File:** `BapCustomServerMelon/CustomServerMod.cs` (~6794–6800, ~7260–7270)

**Was:** 2–3 `FindObjectsOfType` scans **every frame** while Mirror connected — main constant in-match stutter source per code comments.

**Now:** `HasActiveMatchRuntimeCached(3f)` — at most one scan burst per 3 seconds.

**Remaining risk:** During the 3s cache window, cleanup flags may lag slightly; acceptable tradeoff documented in code.

---

### 1.4 Mod scan throttle (2s) — MITIGATED

**File:** `BapCustomServerMelon/CustomServerMod.cs` (~539–588)

**Was:** Harmony install + `FindLoadedUnityObjects` scans could run at 60–200 Hz without throttle (comment: 80%+ CPU).

**Now:** `runScans` gated to once every 2s. Patch queue staggered (3 patches per 50ms from ~35s onward).

**Still hot when `runScans` fires:** `TryAutoSelectOpenAugment`, `TryPopulateCharacterModelsDirect`, `TryExtendAugmentSelectTimer` — each may call `FindLoadedUnityObjects`. Acceptable at 2s interval but worth watching if stutter aligns with 2s ticks.

---

### 1.5 Lobby queue recovery every 5s — MITIGATED

**File:** `BapCustomServerMelon/CustomServerMod.cs` (~589–593, ~9586–9659)

**Was:** Every 2s (handoff says throttled to 5s in follow-up fix).

**Now:** Runs every 5s in lobby scenes only; skips when live prematch context exists.

**Issue — blocking `.Result` on Unity main thread:**

```9642:9644:BapCustomServerMelon/CustomServerMod.cs
        bool serverIdle = false;
        try { serverIdle = _lobbyQueueIdleProbe.Result; } catch { }
        _lobbyQueueIdleProbe = null;
```

**Impact:** When the background HTTP probe completes, `.Result` can block the main thread for one frame (usually small; worse on slow networks).

**Fix suggestion:** Replace with a completion flag set from `Task.Run` continuation, or poll `IsCompleted` + read result only when true without blocking (store result in a field from continuation).

---

### 1.6 `EnsureLobbyCharIdsPrefix` Harmony prefix — MITIGATED

**File:** `BapCustomServerMelon/CustomServerMod.cs` (~4886–4939)

**Was:** Per-call reflection on every `TryGetLobbyCharConfigByIndex` (lobby UI rebuild).

**Now:** Field/method `MethodInfo` cached in statics (`s_lobbyCharIdsField`, etc.). Counter `_ensureLobbyCharIdsCallCount` still increments every call (cheap).

**Removed:** Repeating 15s stats log `UI patch stats: EnsureLobbyCharIdsPrefix called=50 filled=0` (handoff 2026-07-01).

---

### 1.7 Medusa auto-select probe on every WS frame — FIXED-LOCAL

**File:** `BapCustomServerMelon/LocalReverseProxy.cs` (~40–43)

**Was:** Env-var read + up to four `File.Exists` syscalls on every outgoing WS text frame.

**Now:** Static cache `s_medusaAutoSelectCache` (0=unknown, 1=on, 2=off).

---

### 1.8 Native UI refresh every 0.5s when enabled — LOW

**File:** `BapCustomServerMelon/CustomServerMod.cs` (~524–528)

When `_nativeUiEntry` is on and not production/dedicated, `RefreshNativeGameUi` runs twice per second. Gated off in production mode. Not a production issue if INI is correct.

---

### 1.9 OnGUI cost — MITIGATED for production

**File:** `BapCustomServerMelon/CustomServerMod.cs` (~748–772)

- Dedicated process: early return (no GUI).
- Production mode: skips panels except mandatory identity setup.
- `_moddingOverlayEntry`: off by default.

**AdminOverlay:** `BapCustomServerMelon.csproj` has `<Compile Remove="AdminOverlay.cs" />` — **not shipped** in main mod DLL. If re-enabled for dev, `AdminOverlay.cs` already caches `FindLocalDevLobby` for 1s (~777–794) to avoid 120+ scene scans/sec when F8 panel open.

---

## 2. Exit-to-lobby / post-match flow

### 2.1 Server: post-match auto-requeue suppression — FIXED-VERIFIED (xUnit)

**Files:** `CustomMatchServer/LobbyService.cs`, `CustomMatchServer/Program.cs`

**Mechanism:**

| Mechanism | TTL | Set at | Consumed at |
|-----------|-----|--------|-------------|
| `_suppressNextReadyAfterMatch` | 30 min (`SuppressFlagTtl`) | Match **start** (~1919, ~2195) | First ready after match; WS path ~1426; HTTP `/api/queue/join` via `TryConsumePostMatchRequeueSuppression` (~216–227, Program ~984) |
| `_postMatchReturnUtc` | 30 s (`PostMatchRequeueSuppression`) | Match end, disconnect, stale cleanup (`StampPostMatchReturnWindow` ~174–189) | WS ready burst (~1404–1406); HTTP join window check (~225–226) |

**On suppress:** Player stays in lobby; broadcasts unready + `SWITCH_CUSTOM_READY_SUCCESS`, `MATCHMAKING_EXITED`, `CANCEL_MATCHMAKING_SUCCESS` (~1429–1439).

**Pruning:** `PruneExpiredSuppressionState` (~358+) runs from `CleanupStaleMatches` every ~10s — prevents unbounded growth from guest `custom-{N}` accounts.

**Gap that was fixed:** Stale-match cleanup paths now call `StampPostMatchReturnWindow` **before** `_matchAccountIds.TryRemove` (~301, ~323, ~342) so auto-ready after abandoned-match cleanup is also guarded.

---

### 2.2 Client: post-match PreMatch UI cleanup — FIXED-VERIFIED (local)

**File:** `BapCustomServerMelon/CustomServerMod.cs` (~6780–6916)

**Flow:**

1. `MonitorMatchDisconnectAndCleanPreMatchUi()` every frame (~594) — cheap when not in 18s window.
2. On Mirror disconnect after having been connected → `ArmPostMatchPrematchCleanup` 18s (~6832–6850).
3. Every 2s in window → `TryDismissStalePreMatchCharSelectUi()` (~6828–6829).
4. If in-match PreMatch visible → `ForceCloseStalePreMatchParents` + deactivate char views.
5. Else → `CloseStaleLobbyMatchCharacterSelectPages()` via close methods only (~6978+) — **no** `SetActive(false)` on lobby pages.

**Verified (2026-07-01):** Exit Match → normal lobby, READY visible, log markers `[PreMatchCleanup-DIAG]` / `[PreMatchCleanup]`.

---

### 2.3 Over-aggressive lobby cleanup broke top UI — FIXED-LOCAL

**Handoff 2026-07-01:** Previous cleanup deactivated `UILobbyMatchCharacterSelectPage` → missing top nav + low FPS.

**Fix:** Destructive `pageGo.SetActive(false)` removed; only invoke close methods. Log marker changed from `lobbyMatch=` to `lobbyPageCloseCalls=`.

**DLL md5 (local build):** `2A687ACA71B89626598F4B6C574D73C0`

---

### 2.4 Client stuck in match scene after server end (WARMUP) — OPEN

**Handoff:** Local test on port 5174 reached `GAME_STARTED`, then server `Game ended`; client **stayed in match scene** after server-side end / manual exit in WARMUP mode.

**Server side:** `RecordGameEnded` (~544–604) removes match, stamps `_postMatchReturnUtc`, clears `ActiveGameId`, schedules **10s grace-stop** before killing host (`ScheduleMatchServerStop`) so scoreboard/return RPCs can finish.

**Likely gap:** Client return-to-lobby depends on game RPCs + Mirror disconnect. If WARMUP ends abruptly or KCP times out (60s comment ~587–588), client may not load MainScene. Not the same as char-select overlay bug.

**Fix suggestions:**

- Confirm whether WARMUP game mode skips normal end-of-match UI flow (game binary behavior).
- Client mod: on Mirror disconnect + lobby scene **not** loaded within N seconds after server-side queue idle, force scene load or disconnect cleanup (needs careful testing — risk of double-transition).
- Log correlation: server `Game ended` timestamp vs client `[PreMatchCleanup-DIAG]` vs active scene name.

---

### 2.5 Phantom match blocks re-queue (`MaxConcurrentMatches=1`) — FIXED

**File:** `LobbyService.cs` (~1408–1416)

`ReleaseAbandonedMatchForLobby` + `ReleaseAbandonedMatchesForAccount` on ready-after-return prevents `ActiveGameId` from blocking forever.

---

### 2.6 Double port release race on game-ended — FIXED

**File:** `LobbyService.cs` (~551–555)

`RecordGameEnded` now `TryRemove`s match **first** (atomic claim) before stop, preventing stale sweep + game-ended both calling `StopMatchServer` and releasing ports twice.

---

### 2.7 WebSocket send wedging global lobby — MITIGATED

**File:** `LobbyService.cs` (~3329–3368)

- Per-connection `SendLock` (~3433).
- 10s send timeout; aborts wedged socket so `_gate` is not held forever.

**Note:** Global `_gate` (~401) still serializes lobby mutations; slow broadcasts under lock remain a latency concern but no longer infinite deadlock.

---

## 3. LocalReverseProxy / overlay / admin

### 3.1 Proxy architecture — generally sound

**File:** `BapCustomServerMelon/LocalReverseProxy.cs`

- Accept loop on background thread (`Task.Run(AcceptLoopAsync)` ~71).
- Single shared `HttpClient` with `SocketsHttpHandler` (~59–62) — good (no per-request client).
- `ConfigureAwait(false)` on accept path (~99).

**Verify:** No `.Wait()` / `.Result` in proxy hot path (grep clean except unrelated client code).

---

### 3.2 Interesting WebSocket log cap — OK

**File:** `LocalReverseProxy.cs` (~37–38, `MaxInterestingWebSocketLogs = 80`)

Caps verbose WS diagnostic logs.

---

### 3.3 AdminOverlay not in shipping mod — BY-DESIGN

**File:** `BapCustomServerMelon/BapCustomServerMelon.csproj` — `AdminOverlay.cs` removed from compile.

Separate **BapAdminMelon** project exists for admin tooling. Production client uses `ProductionMode=true` to hide dev UI.

---

### 3.4 BapAdminMelon — not audited in depth

**Files:** `BapAdminMelon/AdminMelonMod.cs`, `AdminOperatorBridge.cs`

Not analyzed line-by-line in this pass. Treat as separate deployment surface.

---

## 4. Server quality / lifecycle

### 4.1 Stale match cleanup — OK

**File:** `LobbyService.cs` `CleanupStaleMatches` (~285–350)

Removes matches when:

- Process exited
- Empty lobby beyond grace (connected vs disconnected grace differs)
- Exception path still stamps post-match window

Calls `PruneExpiredSuppressionState`.

---

### 4.2 GameServerProcessManager — OK (spot check)

**File:** `CustomMatchServer/GameServerProcessManager.cs`

- `TryDisposeProcess` (~238+)
- `WaitForExit` with timeout on stop paths (~731)
- Bootstrap fail-closed documented in CLAUDE.md

**Not fully audited:** Log file handle lifetime, all `OutputDataReceived` unsubscribe paths.

---

### 4.3 PortAllocator — OK (spot check)

**File:** `CustomMatchServer/PortAllocator.cs`

`Release` vs `ReleaseImmediately`; cooldown on normal release. Double-release race mitigated by atomic match claim in `RecordGameEnded`.

---

### 4.4 JSON persistence services — LOW RISK

Economy/PlayerStorage/etc. use file-backed JSON. Typical pattern: load on start, save on mutation. Concurrent write under heavy parallel HTTP not fully stress-tested; acceptable for private server scale.

---

### 4.5 Match-end rewards empty-set bug — FIXED

**File:** `LobbyService.cs` (~560–565)

`endedAccounts` captured **before** `_matchAccountIds.TryRemove` so participation rewards apply.

---

## 5. Gameplay / content issues (not server-config fixable)

### 5.1 Bot count = 8, not 20 — OPEN (HIGH)

**Handoff + decomp:** Server sends `BotCount=20` correctly. Dedicated host caps via:

- `GameMode.SpawnAllBotsFill(..., maxBotsToFill = 6, ...)` — default 6 in decomp (`decomp_tmp/BAPBAP_Game_GameMode.cs` ~823)
- Map spawn point count (~8 on typical maps)
- `GameManager.currentMaxBotTeams`

**Cannot fix in CustomMatchServer alone.**

**Required fix (NetworkedCustomChar / Harmony in game process):**

- Raise `maxBotsToFill` cap and `currentMaxBotTeams` to target (20)
- Pad `GameMode.spawnPoints` to ≥32 (prefer `GetSpawnPointsOnNavMesh()` over jitter)
- Gate behind `_dedicatedProcess` + INI flag
- **Risk:** bot stacking / invalid spawns — needs postfix count log + single-client test
- **User greenlight:** requested in handoff, awaiting answer

---

### 5.2 Augment UI vanish → reappear → can't select — OPEN

**File:** `CustomServerMod.cs` (~9845–9894, ~9896+)

**Current mitigations:**

- `TryExtendAugmentSelectTimer`: sets `augmentSelectWaitDuration` to **10s** (comment says 30s was too long)
- `TryAutoSelectOpenAugment` when `_autoSelectAugmentsEnabled`

**Bug:** Log line ~9892 says "to 30s" but code sets `10f` (~9883) — misleading for debugging.

**Assessment:** Timer tweak alone unlikely root cause of vanish/reappear. Needs repro with UIAugments state logging during respawn augment phase.

---

### 5.3 Medusa shown as Kitsu to observers — OPEN

**Handoff:** Networked prefab / assetId resolution on **observing** clients. Local-player graft does not fix remote replication.

**Repo:** `BAPBAPModdingAPI/netcustomchar-mod` (separate from this repo).

See also `AI_HANDOFF_2026-06-29.md` for projectile/VFX issues.

---

### 5.4 Medusa ability slot-0 damage — FIXED (AMP host)

Handoff: damage 80 (was 120) in `medusa.json` on production host.

---

## 6. Deployment / verification checklist

### Server (AMP `ark.atomi23.de:5055`)

- [ ] DLL md5 matches intended release after deploy
- [ ] `GET /health` → `ok:true`
- [ ] Post-match exit: server log contains `Suppressed post-match auto-requeue for {AccountId}`
- [ ] Do **not** hotfix package `appsettings.json` without reconciling vs `CustomMatchServer/appsettings.json`

### Client

- [ ] Use non-Steam build: `Spiel/Battleroyalebuild/bapbap.exe`
- [ ] Verify WMI `ExecutablePath` before testing
- [ ] Expected DLL: `2A687ACA71B89626598F4B6C574D73C0` (or newer after further fixes)
- [ ] After Exit Match: no char-select overlay; top lobby nav visible
- [ ] Log: no `[PreMatchCleanup] ... lobbyMatch=` (old bad marker)
- [ ] Log: `UI_PATCH_STATS_COUNT=0` equivalent (no 15s spam)
- [ ] Stutter: no multi-KB HTTP body lines in `MelonLoader/Latest.log`

### Automated tests

```powershell
dotnet test tests/BapCustomServer.Tests/BapCustomServer.Tests.csproj -c Release
```

- Last known: **375/375** passed after 2026-07-01 client fixes
- Key test: `WebSocket_AutoReadyAfterMatch_SuppressedAndStaysInLobby`
- **Do not** spam live match harness on AMP (opens real game windows)

---

## 7. Recommended next work (ordered)

1. **User retest** stutter fix + exit-to-lobby with DLL `2A687ACA…` on AMP (fresh client zip).
2. **Investigate WARMUP stuck-in-match-scene** with correlated server + client logs.
3. **Bot count Harmony patch** — only after user greenlights spawn-point padding approach.
4. **Augment UI** — capture repro; consider Harmony on UIAugments show/hide rather than timer only.
5. **Medusa observer model** — fix in NetworkedCustomChar repo (replication / prefab id).
6. **Replace `.Result`** in `TryRecoverStaleLobbyQueueUi` (~9643).
7. **Fix log typo** augment "30s" → "10s" (~9892).

---

## 8. File index (primary touchpoints)

| File | Lines (approx) | Role |
|------|----------------|------|
| `BapCustomServerMelon/CustomServerMod.cs` | ~13 400 | Client mod: OnUpdate, exit cleanup, augment, queue recovery |
| `BapCustomServerMelon/LocalReverseProxy.cs` | ~680 | In-process HTTP/WS proxy |
| `BapCustomServerMelon/AdminOverlay.cs` | ~1 200 | Dev admin panel (not compiled into shipping mod) |
| `CustomMatchServer/LobbyService.cs` | ~2 900 | WS lobby, match lifecycle, post-match suppression |
| `CustomMatchServer/GameServerProcessManager.cs` | ~1 400 | Dedicated process spawn/bootstrap |
| `CustomMatchServer/Program.cs` | ~2 500 | HTTP endpoints incl. `/api/queue/join` |
| `HANDOFF_2026-06-30_exit-bots-stutter.md` | — | Session handoff source for this audit |

---

## 9. Changelog reference (fixes already in tree)

| Date | Change | Evidence |
|------|--------|----------|
| 2026-06-30 | HTTP body logging removed from proxy | `LocalReverseProxy.cs` ~657–665 |
| 2026-06-30 | Server post-match suppression + HTTP guard | `LobbyService.cs`, `Program.cs` |
| 2026-07-01 | Client `MonitorMatchDisconnectAndCleanPreMatchUi` | md5 `D8054E4E…` verified exit |
| 2026-07-01 | Narrow lobby page cleanup (no SetActive false) | md5 `2A687ACA…` |
| 2026-07-01 | Queue recovery 2s→5s; remove UI patch stats spam | Handoff + code ~589–592 |
| 2026-07-01 | `HasActiveMatchRuntimeCached(3f)` | ~6797, ~7260 |
| 2026-07-01 | xUnit 375/375 green | Handoff |

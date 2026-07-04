# 06 — Risks and Open Questions

## Top risks (ranked)

### R1. Hidden client dependencies not covered by any golden test — Severity: critical
The protocol was reverse-engineered; the IL2CPP build stripped string literals, so parts of the
contract are *inferred* (explicitly: the friends WS events, `Contracts.cs:77–91`). A rewrite can
pass every contract test and still break a code path only the real client exercises (e.g. field
order sensitivity, an undocumented endpoint the client calls only after an IAP prompt, timing
tolerances during char-select).
**Mitigation:** Phase 0 differential harness with *recorded real-client sessions* (add the WS
session recorder before migration starts); the unknown-event diagnostic logger stays; every
High-risk phase gates on the Windows two-client smoke; soak the new lobby pipeline on the live
server behind the migration flag before deleting the old path.
**Residual:** rare client paths (Twitch link, creator codes) may only surface in production —
rollback flags are the answer.

### R2. `LobbyService` decomposition breaks concurrency behavior — Severity: high
The current design serializes lobby mutations with one `SemaphoreSlim _gate` and per-connection
send locks; comments record races already fought (stuck `Starting` claim at `LobbyService.cs:1778`,
slot reservation at `:1831`, "one dead peer must not abort GAME_STARTED dispatch"). Splitting into
`SocketSession`/`LobbyManager`/`MatchOrchestrator` changes lock scopes; a subtle reordering can
deadlock or double-start a match under real concurrency that unit tests won't reproduce.
**Mitigation:** keep the coarse single-gate model in the first cut (do NOT "improve" to
fine-grained locking during migration); encode the historical races as state-machine tests; add a
50-socket concurrent broadcast/load test; soak on live server.
**Residual:** moderate — accept coarse locking as the price of safety; revisit only post-Phase 7.

### R3. Wine/AMP bootstrap regressions — Severity: high
`docs/AMP_LINUX_WINE_ROOT_CAUSE.md` documents a long, painful root-cause history (Wine cold start,
UDP teardown, listener-only stalls, F033). `BootstrapDriver` re-models this as a state machine; any
transition-guard mistranslation reproduces exactly the class of failure that took longest to fix,
and it only manifests on the AMP Linux host under real Wine timing.
**Mitigation:** 1:1 mapping table from every existing timeout option to a named transition guard,
reviewed against the doc; fixture parity tests replaying the *recorded* pathological sequences
(listener-only, slow Xvfb start, UDP port lag); one staged AMP cold-start run per phase touching
this area; fail-closed semantics asserted in every failure-path test.
**Residual:** Wine is inherently timing-flaky; the fail-closed design bounds the damage (players
requeue instead of joining dead ports).

### R4. Mod refactor destabilizes the IL2CPP interop layer — Severity: high
`CustomServerMod.cs` works partly *because* of accumulated ordering knowledge: early bootstrap
listener before Il2CppInterop readiness, patch cadence (50 ms fast window for 180 s), reflection
cache warm-up, carrier-array rewrites happening before `GameMode.LoadCoroutine`. Moving code into
components can silently change initialization order or `OnUpdate` interleaving.
**Mitigation:** `UpdatePump` preserves exact cadences as data (the existing constants move, not
change); component moves are one-family-per-PR with full Windows smoke each; the
dedicated-host-critical families (`Bootstrap/`, `DedicatedHost/`) move last; previous DLL kept as
rollback artifact per release.
**Residual:** moderate — there is no way to test MelonLoader+IL2CPP behavior on Linux, period.

### R5. Contract tests freeze bugs as behavior — Severity: medium
Golden tests generated from current behavior will faithfully pin oddities (legacy fields, alias
sprawl, permissive stubs). Someone will be tempted to "clean up" while migrating, breaking the
client; conversely, a real bug (wrong field for some mode) gets enshrined.
**Mitigation:** the cross-phase rule "never change wire behavior and structure in the same PR";
a `KNOWN_ODDITIES.md` ledger inside the contract test project recording each pinned oddity and why;
post-Phase-7 review of the ledger with live-client verification per item before any change.
The ledger MUST include the deliberate timing/ordering workarounds from `03` §1.3's "Timing &
ordering contract" (the 6 s `JoinLobbyAsync` delay, post-cleanup start delay, empty-lobby grace,
20 s keep-alive, 10 s send-timeout-abort, post-match ready suppression) — they are the oddities
most likely to be "cleaned up" by someone who doesn't know the client depends on them, and they
are invisible to timing-blind golden tests.

### R6. Migration stalls halfway — Severity: medium
Strangler migrations die when the dual-path period drags: two lobby pipelines, flags multiplying,
contributors unsure where new code goes.
**Mitigation:** one flag per phase with mandatory deletion at phase exit; phases sized so each is a
reviewable PR series; `02-target-architecture.md` is the single "where does code go" reference;
if work pauses, any completed phase is a stable stopping point (each phase ships value alone —
e.g. Phase 2 alone makes `Program.cs` maintainable).

### R7. Test-isolation and environment drift — Severity: low/medium
Already observed: 2/375 tests fail on a clean Linux checkout. Verified root cause (NOT general
`data/` leakage — the integration factory already redirects six services to a temp dir):
`PlayerOverridesService` auto-writes its `unlockEverything: true` default document to the
unredirected `CustomServer:PlayerOverrides:StateFile` path under `AppContext.BaseDirectory`, which
defeats `UnlockAllCharacters=false` via `CharacterUnlockService.cs:84` (details:
`05-testing-and-tooling.md` §1.4). Similar drift risks: `ShopService` state equally unredirected;
catalogs vs AMP JSON (until the sync test lands); analytics regexes vs log wording (the existing
`AnalyticsRegexTests` pins literal copies, not the call-site constants); `GameAssemblies`
LFS-content availability for the CI mod build (see R9); stale tracked `bin/`/`obj/` outputs
poisoning `dotnet test` on fresh checkouts (see `05` §3).
**Mitigation:** Phase 0 fixes isolation with the defaults-override (not just a path move);
`CatalogSyncTests` + analytics coupling test make drift red in CI; CI deletes tracked build
outputs before building and builds the mod on every PR (behind the LFS fetch step).

### R8. Files the plan depends on vs what git actually tracks — Severity: medium
Several inputs this plan's tests and CI consume live in **gitignored paths that only work today
because the files were tracked before the ignore rules were added** (verified via `git ls-files`):
`deployment/amp-*/` is gitignored (`.gitignore` "Generated hotfix packages/staging" block) yet
`tools/Build-Amp*.ps1` consume `deployment/amp-github-autoinstall/bapcustomservergithubconfig.json`
and `deployment/amp-full-linux-wine/start-match.sh` from there — both ARE tracked (legacy), but
any NEW or renamed file in those folders will silently not be committed, and `CatalogSyncTests`
plans to read the AMP JSON as its third sync source. Same pattern for
`AssetRip/AuxiliaryFiles/GameAssemblies/` (tracked LFS DLLs inside a gitignored folder). And
Phase 3's original "fixture test with a copy of the repo's `data/`" was impossible as written —
`CustomMatchServer/data/` is gitignored and NOT tracked; fixtures must be synthesized or captured
from the production host (fixed in `04` Phase 3).
Related plan-input gap: **no `.sln` exists in the repo today** — the CI outline in `05` §3 builds
`BapCustomServer.sln`, which must be *created* in Phase 0 (six csprojs exist, no solution file;
don't present the solution as an existing asset).
**Mitigation:** Phase 0 ships a `git ls-files` audit script that asserts every file the contract
tests/CI depend on is tracked (and fails on gitignored-but-consumed paths); new fixtures live
under `tests/` or `fixtures/`, never under gitignored trees; Phase 0 creates the solution file.

### R9. Single-maintainer bus factor — Severity: high (organizational, not technical)
Every High-risk phase gate in `04-migration-plan.md` funnels through ONE person's resources: the
Windows machine with the game build (`Spiel/Battleroyalebuild/`, gitignored, exists nowhere
else), the production/staging AMP instance, and the GitHub accounts — `tools/` scripts hardcode
`Sonic0810` (repo/release owner) and `ark.atomi23.de` (AMP host). If that person is unavailable,
Phases 2, 4, 5, and 6 cannot exit their gates, and the migration stalls exactly as R6 warns.
There is also no documented second holder of the AMP credentials or the game build.
**Mitigation:** before Phase 2 exits (same deadline as Q6): document the Windows-gate runbook so
a second person can execute it; park a copy of the game build + MelonLoader setup somewhere a
second maintainer can reach; extract the hardcoded host/owner values in `tools/` into parameters
with defaults; and treat "two people have run the full smoke set" as a Phase 4 entry criterion.
**Residual:** high — a hobby project may accept this; the plan should at least stop *hiding* it.

## Open questions (need an owner/decision before the relevant phase)

| # | Question | Needed by | Notes |
| --- | --- | --- | --- |
| Q1 | **Friends WS event strings**: capture a real friends-panel session to confirm/correct the inferred `SET_FRIENDS`/`FRIEND_STATUS`/`UPDATE_FRIEND_REQUESTS`/`INVITE_LOBBY` strings? | Phase 0 (recorder exists then) | Until captured, treat inferred strings as contract. A capture session on the Windows box with two accounts settles it. |
| Q2 | **SQLite adoption**: `SqliteStore<T>` has been DROPPED from Phase 3 (premature — the AMP host's backup workflow operates on `data/` files; see `02` A.5). Question narrows to: does anyone ever ask for it post-Phase-7? | post-Phase 7 (if ever) | The `IStateStore<T>`/`IKeyedStateStore<T>`/`IAppendLog` seams are the Phase 3 deliverable; a SQLite provider can be added behind them later without design changes. |
| Q3 | **Single-DLL mechanism**: keep one csproj with folders (recommended — zero packaging risk) vs multi-project + ILRepack (cleaner boundaries, new failure modes in the IL2CPP domain)? | Phase 6 step 2 | Plan assumes one csproj. Revisit only if the project file becomes unwieldy. |
| Q4 | **Catalog generation direction**: generate mod/AMP artifacts from `Bap.Catalog/*.json` at build time (needs the AMP template repo `Sonic0810/BAPBAP-CustomServer-AMPTemplates` to accept generated commits) or keep the sync test as permanent enforcement? | Phase 7 | The AMP template lives partly in a *separate GitHub repo*; generation must fit that release flow (`Build-AmpGitHubAutoInstallPackage.ps1`). |
| Q5 | **Scope of `BapAdminMelon` and `CustomClientProxy`**: fold their duplicated DTOs onto `Bap.Protocol` (net6-compatible multi-target?) or leave them untouched? | Phase 2 | `Bap.Protocol` would need `net6.0;net10.0` multi-targeting for the mods to reference it. Cheap, but confirm MelonLoader tolerates the extra dependency DLL — otherwise link-compile the source files (as the tests do). |
| Q6 | **Windows gate logistics**: who owns the game-build machine used for smoke gates, and is the AMP staging instance (`ark.atomi23.de` per `CONTEXT.md`) available for cold-start checks per phase? | before Phase 2 exit | The whole plan's High-risk gating assumes this machine exists and is usable per phase. |
| Q7 | **Repo hygiene**: relocate the ~150 scratch artifacts at repo root (`tmp-*.png`, `amp-*.png`, `*_dump.cs`, handoff MDs) into `analysis/`+`artifacts/` (gitignored) as part of Phase 7? | Phase 7 | Not architectural, but the noise raises onboarding cost and hides the real docs (`CONTEXT.md`, `README.md`). Out of scope for this plan's file-creation step (no existing files touched). |
| Q8 | **Two currently-failing tests**: RESOLVED diagnosis — not `data/` leakage and not an economy regression. `PlayerOverridesService` regenerates an `unlockEverything:true` default at the unredirected `PlayerOverrides:StateFile` path (`PlayerOverrides.cs:198–216, 253–274`), making the locked test character owned via `CharacterUnlockService.cs:84`; signatures `Expected: 1/Actual: 3` and `Expected: 0/Actual: 1` reproduced and explained (`05` §1.4). Remaining decision: fix via config-seeded locked-down defaults vs a test-only knob on the service. | Phase 0 | The fix must OVERRIDE the defaults; relocating the file alone regenerates the same unlock-everything document at the new path. |

## Decision log seeds (recommendations already embedded in this plan)

1. Strangler fig over big-bang — protocol risk dominates (accepted premise of the whole plan).
2. Contract lock (Phase 0) is a hard precondition — no migration PR merges before it.
3. Keep coarse lobby locking through migration; performance work only post-Phase 7. This
   explicitly includes the per-connection send path: the lock-per-send + 10 s-abort model moves
   mechanically in Phase 4; any channel-based send queue is post-Phase-7 with its own exit
   criteria (`02` A.3).
4. One csproj / one DLL for the mod; components via folders (pending Q3). `AdminAuthClient.cs`/
   `AdminOverlay.cs` stay `Compile Remove`d from the main DLL and link-compiled into
   `BapAdminMelon` (`02` B.2).
5. JSON stays the only store; the storage *seams* ship in Phase 3, SQLite dropped until someone
   asks (Q2).
6. Catalogs: sync test first, generation later (pending Q4).
7. Option TYPES live in a leaf project (`Bap.Options`); binding/validation in the host — required
   by the `Server → Infrastructure` dependency direction (`02` A.1/A.7).
8. `Bap.Domain` may be merged into `Bap.Application` as a folder (recommendation, decide at
   Phase 4 — `02` A.1).

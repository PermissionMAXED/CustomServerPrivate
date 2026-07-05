# 04 — Migration Plan (Strangler Fig, Not Big Bang)

## Why strangler fig

A from-scratch rewrite would have to re-derive, from behavior, a protocol that was itself
reverse-engineered from an IL2CPP binary — the highest-risk possible move. Instead: lock the
contract with tests (Phase 0), then move code into the new module structure **in place**, one seam
at a time, with the old implementation remaining the fallback until the new one has survived both
contract tests and live smoke. Each phase is independently shippable and reversible.

Difficulty below is phrased as component risk:
- **Low** — pure code motion, behavior pinned by existing tests.
- **Medium** — restructuring with behavior pinned by new contract tests.
- **High** — touches the WS flow, bootstrap, or the mod runtime (only verifiable end-to-end on the
  Windows game machine).

Ordering rule: risk-increasing, value-early. Server before mod (server is Linux-CI-verifiable; the
mod runtime is not).

---

## Phase 0 — Contract lock (no production code changes) — Medium effort, zero risk

> **STATUS (July 2026): partially DONE.** Landed: the 2-test isolation fix (defaults-override via
> `PlayerOverrides:StateFile`/`Shop:StateFile` redirect + neutral `{ "defaults": {}, "players": {} }`
> pre-seed, shared via the TestSupport helpers), plus green `RouteManifestContractTests` (route+method
> manifest against `Fixtures/routes.contract.json` + uniqueness assertion),
> `WsConnectGreetingContractTests`, `JoinLobbyContractTests` (incl. the 6s-delay lower-bound and the
> post-join `GAME_MODES_UPDATED` re-send), and `CatalogSyncTests` (HC5 server↔mod↔AMP-JSON). Suite is
> 390/390. Still open: DTO wire goldens, bootstrap fixtures, the remaining WS scenario/error-code
> tests, the differential harness, the `git ls-files` audit script, the `.sln`, and CI.

**Ships:** `Bap.Protocol.Tests` goldens, `Bap.Server.ContractTests` route manifest + shape
snapshots, bootstrap fixtures, WS scenario tests, differential proxy harness
(`03-protocol-compatibility.md` layers 1–4), CI pipeline running all of it plus the existing 375
tests. Also: fix the 2 failing `EndpointIntegrationTests` — a test-only change, but with the
CORRECT fix: the `AppFactory` must add `CustomServer:PlayerOverrides:StateFile` → temp dir AND
seed/override the defaults (`unlockEverything:false` etc. as the tests require), because
`PlayerOverridesService` regenerates its unlock-everything default document at whatever path it
is given (`PlayerOverrides.cs:198–216, 253–274`); redirecting the path alone does NOT fix the
tests. Redirect `CustomServer:Shop:*` state the same way while in there. Also add a `git
ls-files` audit script asserting every file the contract tests and CI depend on is actually
tracked (AMP JSON, `start-match.sh`, fixtures — see risk R8 in `06-risks-and-open-questions.md`).

**Exit criteria:** goldens generated from current code and reviewed; route manifest =
the `EndpointDataSource` dump of route+method pairs from the running app (≈158 today — do NOT
hand-maintain a count; see `03-protocol-compatibility.md` §1.2) with a **uniqueness assertion**
(duplicate route+method registrations are invisible at startup and ambiguous-match at request
time — the `/api/shop` comment at `Program.cs:1271` records a past instance); contract suite
green on current `main`, 375/375 existing tests green (isolation fix applied); differential
harness shows old-vs-old = zero diff (harness self-test). **No migration work may start before
this gate.**

**Rollback:** trivial — everything is additive test code.

---

## Phase 1 — Extract `Bap.Protocol` + `Bap.Catalog` (code motion) — Low risk

**Ships:** `Contracts.cs` contents split into `Bap.Protocol` (Events, Envelopes, Payloads,
WireJson, ErrorCodes) and route alias tables into `Routes.cs`; `NormalizeEvent` moves to
`EventNormalization`; catalogs (`CharacterCatalog`, `MapCatalog`, `GameModeCatalog`) move to
`Bap.Catalog` with the forbidden-skin deny-list; the catalog **sync test** (server ↔
`MelonMapHelpers` ↔ AMP JSON, see `05-testing-and-tooling.md`) lands here. `CustomMatchServer`
references the new projects via `global using` aliases / type-forwarding so no call site changes
semantically.

**Old+new side by side:** n/a — same binary, new project boundaries.
**Exit criteria:** all Phase 0 suites green; published linux-x64 output byte-comparable behaviorally
(differential harness zero-diff); AMP package build scripts (`tools/Build-Amp*.ps1`) still produce a
working package (verify file list).
**Rollback:** revert the commit; no data or config format changed.

---

## Phase 2 — Endpoint modularization (hollow out `Program.cs`) — Medium risk

**Ships:** the ≈158 route+method registrations (~122 top-level `app.Map*` calls + the
`MapSocketDiscovery`/`MapClientJson` families) move into `Endpoints/*` static classes grouped by domain
(`AuthEndpoints`, `MetagameStubEndpoints`, `ShopEndpoints`, `FriendsEndpoints`, `QueueEndpoints`,
`MatchCallbackEndpoints`, `AdminEndpoints`, `DiagnosticsEndpoints`, `SocketDiscoveryEndpoints`),
each registered from route data in `Bap.Protocol.Routes`. Inline endpoint logic >10 lines
(`/api/chars/listing/purchase`, `/api/queue/join`) moves to Application-layer workflow classes
(`PurchaseWorkflow`, `QueueCoordinator` façade). `PostConfigure` blocks and local functions
(`BuildLoadResult`, startup diagnostics) move to the Options module / `LoadResponseBuilder`.
`Program.cs` shrinks to builder + `AddBapServer()` + `MapBapEndpoints()`.

**Old+new side by side:** per-group feature flag `CustomServer:Migration:UseNewEndpoints:<group>`
selects old lambda vs new module at startup (both compiled in). Default old; flip per group after
the route-manifest + differential harness pass for that group; delete old lambdas at phase end.
**Exit criteria:** route manifest identical; shape snapshots identical; rate limiter still covers
`/admin` + `/api/admin`; `tools/Test-CustomServerSmoke.ps1` + `Test-AdminControlsSmoke.ps1` pass on
the Windows box.
**Rollback:** flip the group flag(s) back; flags removed only when the phase exits.

---

## Phase 3 — Persistence seams (`IStateStore<T>` / `IKeyedStateStore<T>` / `IAppendLog`) — Medium risk

**Ships:** three store implementations matching the three existing on-disk shapes (see `02` A.5):
`JsonFileStore<T>` for the six single-file snapshot stores (`EconomyService`, `ShopService`,
`RankedService`, `FriendsService`, `ServerAdminService` state, `PlayerOverridesService`);
`JsonDirectoryStore<T>` (`IKeyedStateStore<T>`) for `PlayerStorageService`'s
`players/{accountId}/player.json` + `index.json` layout; `JsonlAppendLog` for
`MatchHistoryService` and the admin audit log. All with today's exact file names/shapes under
`data/`; test composition uses in-memory stores. Mutation APIs support returning results
(`TResult Mutate<TResult>(…)`) so purchase-style workflows stay single-round-trip. **No
`SqliteStore<T>` in this phase** — the seam is the deliverable; a SQLite provider remains a
possible post-Phase-7 addition behind the same interfaces (Q2).

**Old+new side by side:** per-service delegation, one service per PR; old bespoke load/save code
deleted only after that service's golden state-file test passes.
**Exit criteria:** `data/` dirs captured from the live/staging server load unchanged (NOTE:
`data/` is **gitignored** — `CustomMatchServer/data/` in `.gitignore` — so there is no "repo copy"
to test against; fixtures must be synthesized in-repo plus at least one sanitized capture from
the production AMP host); service unit tests green with in-memory stores; on-disk JSON written by
new code is diff-identical for the same mutations (golden state files).
**Rollback:** revert the service's delegation PR; JSON files were never rewritten destructively
(atomic rename keeps the previous file until success).

---

## Phase 4 — Split `LobbyService` — **High risk (the crux)**

**Ships:** `SocketSession` (transport), `LobbyEventDispatcher` (handler registry),
`LobbyManager` + Domain `LobbyStateMachine`, `MatchOrchestrator` (single start tail for both
custom and matchmaking paths), `MatchLifecycleTracker`, `AdminHandshake` — per
`02-target-architecture.md` A.3. The old `LobbyService` class remains as a thin adapter delegating
to the new components until the end of the phase.

**Sequencing inside the phase (each step individually shippable):**
1. Transport extraction (`SocketSession`) — a MECHANICAL move of the existing lock-per-send model
   (per-connection `SendLock`, 10 s timeout → `Socket.Abort()`, close-under-lock). The
   channel-based send queue is explicitly **out of scope until post-Phase 7** (see `02` A.3 and
   R2). WS framing behavior pinned by scenario tests; verify no interleaved-frame regressions
   under concurrent broadcast (load test with 50 fake sockets, asserting dead-socket cleanup and
   that one aborted socket never aborts dispatch to the rest).
2. Dispatcher extraction (switch → registry; normalization already in Protocol).
3. Admin handshake handlers.
4. Lobby state machine + mutation handlers (ready/team/settings/mode/region/char).
5. Match orchestration unification (custom + matchmaking tails converge on `MatchOrchestrator`);
   `MatchmakingHostedService` calls the orchestrator.
6. Lifecycle tracker (empty-lobby grace, post-match return suppression maps).

**Old+new side by side:** `CustomServer:Migration:UseNewLobbyPipeline` (bool) selects the wiring at
startup. Differential WS replay (Phase 0 layer 4) runs against both pipelines in CI on every PR of
this phase.
**Exit criteria:** all WS scenario + sequence tests green on the new pipeline; **timing contract
preserved** — an explicit test measures elapsed time from `JOIN_LOBBY` to `JOIN_LOBBY_SUCCESS`
and asserts it is ≥ the configured join delay (the deliberate 6 s `Task.Delay` at
`LobbyService.cs:1150–1155`; see the "Timing & ordering contract" subsection of `03` §1.3 — the
other listed delays get equivalent assertions where testable); the asymmetric `QUEUE_MATCHED`
broadcast error-handling of the two start paths is preserved (matchmaking try/catch vs custom
propagate — `03` §2.4); two-client live smoke (`Test-MatchStartTwoClientSmoke.ps1`) and
`Force-StartMatch.ps1` pass on Windows with the flag ON; soak: one real evening session on the
private server with the flag ON and zero protocol-error log lines. Then old code path deleted,
flag removed.
**Rollback:** single flag; both pipelines share the same state services so flipping back mid-run is
safe at process restart (not hot). NOTE: a restart runs `ApplicationStopping` →
`LobbyService.StopAllMatches()` (`Program.cs:416–419`), killing all in-memory lobbies and live
matches — flip flags during idle windows only (applies to every phase's rollback).

---

## Phase 5 — Split `GameServerProcessManager` + prewarm — High risk, contained blast radius

**Ships:** `ProcessLauncher`, `BootstrapDriver` (explicit state machine with named transitions for
F033 listener-only, setup replay, stall windows), `ReadinessProbes`, `StallDetector`, `PrewarmPool`.
Every existing timeout option maps 1:1 onto a transition guard (document the mapping in code).

**Old+new side by side:** `CustomServer:Migration:UseNewBootstrapDriver` flag; bootstrap fixture
suite (Phase 0 layer 3) runs both drivers against identical scripted listener behaviors and diffs
the decision traces.
**Exit criteria:** fixture parity old-vs-new including failure paths (requeue on every `Failed`
state); `Test-MatchStartSmoke.ps1` with `-RequireGameServerBootstrap:$true` passes on Windows; a
Wine cold-start on the AMP staging instance completes bootstrap (this is the path with the worst
history — see `docs/AMP_LINUX_WINE_ROOT_CAUSE.md`).
**Rollback:** flag; the wire behavior toward the mod is unchanged, so mixed operation is safe.

---

## Phase 6 — Mod decomposition — High risk, mitigated by structure-only steps

Precondition: Phases 0–5 done, so the server side is stable while the mod moves.

**Ships (in-order, one PR each, all inside the single csproj → still one DLL):**
1. `Pure/` extraction: bootstrap HTTP parsing, payload validation, INI parsing, identity
   generation, dedup/carrier math → Unity-free classes + Linux tests (extends the proven
   `Melon*Helpers` pattern). No behavior change.
2. `Core/` scaffolding: `ModContext`, `CompositionRoot`, `UpdatePump` (`ITickable`), Il2Cpp interop
   caches move under `Core/Il2CppInterop/`. `CustomServerMod` fields migrate to components
   incrementally; each PR moves one component family.
3. Component moves, ordered by risk: `Config` → `Ui` → `ClientQoL` → `Identity` → `Network` →
   `Bootstrap` (listener/queue/applier last-but-one) → `DedicatedHost` (`MatchRuntime`,
   `LevelCarrier` — last, it's the match-critical path).

**Old+new side by side:** the mod can't dual-run in one process; instead each step ships a new DLL
version tested via `tools/Install-BapCustomServerMelon.ps1` + full smoke on Windows, with the
previous DLL kept as the rollback artifact in the release (mod versions in `[assembly: MelonInfo]`
bumped per step). AMP releases pin exact DLL versions, so production rolls forward/back by release
tag.
**Exit criteria per step:** mod builds against the `AssetRip/AuxiliaryFiles/GameAssemblies`
reference DLLs — which on Linux/CI requires materializing their Git-LFS content first
(`git lfs pull --include="AssetRip/AuxiliaryFiles/GameAssemblies/*"`, 114 DLLs ≈ 17 MB; a plain
checkout leaves ~130-byte LFS pointers and the build fails with CS0246 — see
`05-testing-and-tooling.md` §3 for the CI mechanism decision); Linux unit tests green; Windows:
client boots to lobby, F7 panel works, guest identity intact,
`Test-MatchStartTwoClientSmoke.ps1` passes (client + dedicated host both exercise the DLL);
bootstrap fixture parity for `Bootstrap/` steps; if a step moves/renames `AdminAuthClient.cs` or
`AdminOverlay.cs`, the `BapAdminMelon.csproj` link paths are updated in the same PR (see `02`
B.2's cross-project constraint).
**Rollback:** ship previous DLL version (single-file swap in `Mods/`). The repo already tracks
pinned DLLs + timestamped `.bak` siblings under `BapCustomServerMelon/dist/` (via Git LFS) —
Phase 6 formalizes that convention as the rollback artifact per release instead of ad-hoc `.bak`
copies.

---

## Phase 7 — Consolidation and cleanup — Low risk

**Ships:** delete all migration flags and adapters; catalog **generation** replaces the sync test
as primary enforcement (test remains as backstop); options grouped into sub-objects with binding
compatibility tests; docs refresh (`README.md`, `AGENTS.md`/`CLAUDE.md` architecture sections,
AMP runbook pointers); differential harness retired to an on-demand tool; repo hygiene (Q7):
relocate root scratch artifacts AND **untrack the ~2,580 committed `bin/`/`obj/` build outputs**
(`git rm -r --cached` — they are LFS-routed stale binaries that break fresh-checkout `dotnet
test`, see `05-testing-and-tooling.md` §3) — the `**/bin/`/`**/obj/` ignore rules already exist,
so untracking is sufficient.

**Exit criteria:** `Program.cs` < 300 lines; no source file > ~800 lines except generated code;
zero references to `CustomServer:Migration:*` keys; full smoke pass; one clean AMP
GitHub-AutoInstall release deployed to the live instance.

---

## Cross-phase rules

- **One flag per phase, startup-scoped, default OLD** until exit criteria met; flags are deleted at
  phase exit (no permanent dual paths).
- **The 375-test suite + contract suite run on every PR**; a red contract test blocks merge, no
  exceptions, including "obvious improvements".
- **Windows smoke is the gate for every High-risk phase** — schedule migration steps so the Windows
  machine (with the game build under `Spiel/Battleroyalebuild/`) is available for the gate runs.
- **Never change wire behavior and structure in the same PR.** If a genuine bug is found
  mid-migration, fix it on the old path first (with a test), let the fix flow into the new path.
- **AMP releases**: each phase that changes the published server or mod DLL produces a tagged
  GitHub release via the existing `tools/Build-AmpGitHubAutoInstallPackage.ps1` flow, so the AMP
  instance can roll back by re-pinning the previous release.
- **Data safety**: `data/` JSON files are only ever migrated additively (Phase 3's atomic-rename
  write keeps prior files); take a `data/` backup before flipping any storage flag in production.

# 01 — Current State Assessment

Findings from reading the actual sources (line counts from `wc -l`, July 2026 tree). This is not a
criticism of the code — much of it is deliberately defensive because the client is unmodifiable —
but it maps where complexity concentrates and what a rewrite must untangle.

## 1. Inventory and sizes

### Server (`CustomMatchServer/`, net10.0 — 15,364 lines total)

| File | Lines | Responsibilities observed |
| --- | ---: | --- |
| `LobbyService.cs` | 3,512 | WS accept loop + framing (ArrayPool receive, 4 MB incoming cap — `MaxIncomingMessageBytes`, line 123), event dispatch (`HandleMessageAsync` switch), event-name normalization, lobby CRUD + leader logic, ready/team/settings handlers, custom-game start, matchmaking-game start, `QUEUE_MATCHED`/`GAME_STARTED` payload building + multicast, match lifecycle/cleanup timers, empty-lobby grace tracking, admin 3-step WS handshake (`MOD_HELLO`/`MOD_AUTH`/`ADMIN_AUTH`), friend-invite WS handlers, ban enforcement, per-connection send locking, `BuildSocketUrl`, map/mode resolution glue |
| `Program.cs` | 2,776 | Composition root: logging filters, options binding + 4 `PostConfigure` blocks re-parsing CSV/JSON config, HttpClient config, rate limiter, **≈158 route+method registrations** (~122 top-level `app.Map*` calls + `MapSocketDiscovery` 6×GET+POST + `MapClientJson` 12×GET+POST; 126 textual `app.Map` occurrences — the `EndpointDataSource` dump is the authoritative count, see `03` §1.2) covering auth/load aliases, metagame stubs incl. the `MapMetagameBootstrapEndpoints` family (lines 1248–1340), shop, friends, queue, admin, diagnostics, bootstrap callbacks, socket discovery — plus local functions like `BuildLoadResult` (line 1497) and startup diagnostics |
| `GameServerProcessManager.cs` | 1,578 | Process spawn/supervise, launcher templating, port-ready polling (TCP/UDP/KCP), fail-closed 3-POST bootstrap with managed status polling, retries, stall detection, wrapper-only stall variant, log-tail diagnostics |
| `EconomyService.cs` | 940 | Gold/fractals/char-tokens balances, XP/levels, owned assets (incl. the forbidden-skin filter in `BuildOwnedAssets`), JSON persistence |
| `CustomServerOptions.cs` | 862 | ~54 scalar knobs on the root class + ~10 nested option-class properties (60 root properties total) + `CharacterCatalog`/`MapCatalog`/`GameModeCatalog` static catalogs + AMP-facing roster/map-pool/shop-slot/analytics option groups |
| `PlayerStorageService.cs` | 827 | Player profile persistence (JSON) |
| `FriendsService.cs` | 671 | Friend graph, requests, invites, persistence |
| `AdminService.cs` | 569 | Admin accounts, bans, grants, audit log (`ServerAdminService`, `AdminAuth`) |
| `RankedService.cs` | 549 | Points, leaderboard, placement mapping |
| `ShopService.cs` | 537 | Rotation/freebie listings, purchase glue |
| `GameServerPrewarmService.cs` | 501 | Warm-spare game process hosted service |
| `MatchmakingQueueService.cs` | 436 | Public queue, countdown timer state |
| `Contracts.cs` | 402 | `Events` string constants, WS envelope, all client-facing DTOs, `JsonContract.Options` |
| `PlayerOverrides.cs` | 368 | Per-player override config service |
| `MatchHistoryService.cs` | 228 | Match history ring, persistence |
| `PortAllocator.cs` | 173 | Port-quad leasing, cooldown, TCP/UDP probing |
| Others (`CharacterUnlockService`, `ResourceMonitorService`, `DiagnosticsLogBuffer`, `MatchmakingHostedService`) | 435 | Small, mostly single-purpose |

### Mod (`BapCustomServerMelon/`, net6.0 x86 — 18,921 lines total)

| File | Lines | Responsibilities observed |
| --- | ---: | --- |
| `CustomServerMod.cs` | **15,604** | ONE class (~385 members, of which ~300 are fields): INI + MelonPreferences config; `NetworkConfig.ApiHost` patching (2s slow / 50ms fast cadence); first-start guest identity (primes `SESSION_ID`/`AUTO_LOGIN` prefs); reverse-proxy lifecycle; managed bootstrap TCP listener (`EnsureManagedBootstrapListener`, ~line 6238) serving `/setup-game`/`/add-teams`/`/queue-matched` inside the game process; bootstrap payload queue/retry/repair loop; dedicated-host match runtime (char-select timings, late-join, auto-end); IMGUI settings window (F7) + first-start setup window + status chip; native Unity UI panel; reflection caches over Il2Cpp types; Mirror/KCP tick-rate tuning (~line 9310); crate-respawn disable (~line 9701); MATCH FOUND dedup (~line 9762); augment-select wait extension (~line 10170); custom map carrier table; auto-join client logic; Harmony patch installation flags for ~8 patch families |
| `AdminOverlay.cs` | 1,408 | In-game admin overlay UI |
| `LocalReverseProxy.cs` | 791 | In-process HTTP/WS proxy on 127.0.0.1:5055, socket-discovery rewrite |
| `MelonProxyHelpers.cs` | 559 | Pure proxy helpers (tested on Linux) |
| `AdminAuthClient.cs` | 345 | WS admin handshake client side |
| `Melon{Bootstrap,Arg,Identity,Map}Helpers.cs` | 214 | Pure, Unity-free logic extracted for tests — the pattern to generalize |

### Other projects
- `CustomClientProxy/` (287 lines): small, already clean.
- `BapAdminMelon/` (343 lines): separate admin mod, small. Note it does not own its admin source:
  `AdminAuthClient.cs`/`AdminOverlay.cs` physically live in `BapCustomServerMelon/` but are
  `Compile Remove`d there (`BapCustomServerMelon.csproj:16–19`) and link-compiled into
  `BapAdminMelon.dll` (`BapAdminMelon.csproj:46–49`) — see `02-target-architecture.md` B.2.
- `MapEditorUnity/` (Unity map-editor toolkit, 12 C# files under `Assets/`): produces the custom
  maps that the carrier-slot mechanism (map ids 5..40, HC5) exists to serve. Not a .NET-SDK
  project (no csproj at its root; it is a Unity project folder).
- `MapEditorVerify/` (the 6th `.csproj` in the repo, alongside BapAdminMelon, BapCustomServerMelon,
  CustomClientProxy, CustomMatchServer/BapCustomServer, and the test project): a small
  verification console for map-editor output.
- `tests/BapCustomServer.Tests/` (5,371 lines, 42 `.cs` files): **375 xUnit tests**. Verified run
  on this Linux workspace: `Failed: 2, Passed: 373` (since fixed in Phase 0 — suite now green,
  incl. the new contract tests). The two `EndpointIntegrationTests` failures
  (`CharacterPurchase_DebitsTokensAndLoadShowsUnlockAsset` — `Expected: 1, Actual: 3`;
  `CharacterListing_ShowsConfiguredPriceForLockedCharacter` — `Expected: 0, Actual: 1`) are NOT
  caused by the repo `data/` dir leaking: `EndpointIntegrationTests.AppFactory`
  (`EndpointIntegrationTests.cs:27–64`) already redirects the Economy/Friends/Ranked/
  MatchHistory/Admin/PlayerStorage state files into a per-run temp dir. The real cause (verified
  by rerunning both tests and inspecting the written file): `CustomServer:PlayerOverrides:StateFile`
  (default `data/player-overrides.json`, resolved against `AppContext.BaseDirectory` —
  `PlayerOverrides.cs:11, 113–117`) is **not** redirected, and `PlayerOverridesService`
  auto-creates a default document with `unlockEverything: true` (`PlayerOverrides.cs:198–216,
  253–274`) in the test bin dir. `CharacterUnlockService.IsCharacterOwned` honors that override
  (`CharacterUnlockService.cs:84`), so the "locked" test character reports as owned even with
  `UnlockAllCharacters=false`. Fixing it requires **overriding the defaults** (redirecting the
  path alone is insufficient — the service regenerates the unlock-everything default at any
  path). `ShopService` state (`data/shop-state.json`) is likewise unredirected — same class of
  problem, currently benign. Both stale files are even *tracked in git* under
  `tests/.../bin/*/net10.0/data/`. Finding: **test isolation has one specific hole
  (PlayerOverrides/Shop), not a general `data/` leak.**
- Git/LFS state worth knowing before planning CI: `.gitattributes` routes `*.dll`, `*.exe`,
  `*.png` (and much more) through **Git LFS** (`.gitattributes:5` for `*.dll`); ~2,580 stale
  build outputs under `bin/`/`obj/` are tracked (committed before the `**/bin/`/`**/obj/` ignore
  rules); pinned mod DLLs plus timestamped `.bak` siblings are tracked under
  `BapCustomServerMelon/dist/` and `BapAdminMelon/dist/` (these interact with Phase 6's
  previous-DLL-as-rollback strategy — see `04-migration-plan.md`).

## 2. Pain points, concretely

### P1. `Program.cs` is a 2,776-line composition root with business logic inside
- ≈158 route+method registrations in one file; many with inline logic (e.g. `/api/chars/listing/purchase`
  at line 525 embeds a ~44-line purchase workflow; `/api/queue/join` at line 973 embeds queue+ranked+
  unlock validation across 7 injected services).
- 4 `PostConfigure` blocks re-parse CSV/JSON strings (`ParseIntCsv`, `ParseDimensionDataJson`,
  `ParseMapMappingJson`, `ParsePerModeSettingsJson`) — config normalization logic living in the
  host file, invisible to tests that construct options directly.
- Route aliasing is done by repetition: `BuildLoadResult` is mapped to **16** route/method
  combinations (lines 431–470); socket discovery mapped 6× via a local `MapSocketDiscovery`.
  Nothing machine-checks that an alias set is complete.
- Local static functions at the bottom (`BuildLoadResult` line 1497, `LoadDeploymentInfo`,
  `BuildRuntimeDiagnostics`, …) are only reachable through the whole-app integration tests.

### P2. `LobbyService` mixes four lifecycles in one class
State fields tell the story (lines 125–157): `_clients` (connections), `_lobbies` (lobby state),
`_matches` + `_matchAccountIds` + `_emptyLobbyMatchSinceUtc` + `_postMatchReturnUtc` +
`_suppressNextReadyAfterMatch` (match lifecycle), `_pendingAttestations` + `_adminGrants` (admin
auth). One `SemaphoreSlim _gate` (line 401) serializes lobby mutations; per-connection `SendLock`
serializes writes. Consequences:
- Transport concerns (WS framing, close semantics, 4 MB fragmented-message guard) live beside
  domain rules (leader-only settings, `ERR_NOTREADY`, `ERR_SERVER_FULL`).
- Both start paths (`StartCustomGameAsync`, `StartMatchmakingGameAsync`) duplicate the
  `QUEUE_MATCHED`/`GAME_STARTED` multicast blocks (lines ~1945–1975 and ~2217–2247 are near-copies,
  each with its own "one dead socket must not abort dispatch" handling).
- Comments record past races patched in place (e.g. atomic start claim at line 1778 fixing "stuck
  `lobby.Starting`", slot reservation at line 1831) — evidence the implicit state machine has no
  explicit representation.

### P3. `CustomServerMod.cs` is a 15.6k-line god class
- Everything shares one instance's ~300 fields; the update loop (`OnUpdate`) interleaves
  host patching, bootstrap repair, auto-join, UI, and patch installation via time-slicing constants
  (`PatchIntervalSeconds`, `FastPatchIntervalSeconds`, `BootstrapRepairIntervalSeconds`).
- Client-mode and dedicated-host-mode logic are interwoven in the same class and gated by runtime
  flags, though they are effectively two different programs sharing utilities.
- The four `Melon*Helpers.cs` files prove extraction works (they're pure and unit-tested); ~95% of
  the logic hasn't had that treatment.
- Reflection caching (`s_unityObjectFinderCache`, `s_instanceMemberCache`,
  `s_il2cppArrayAccessorCache`) is good engineering buried in the god class instead of an interop
  utility layer.

### P4. Config sprawl and triple representation
- `CustomServerOptions` has ~54 scalar knobs on the root class (ports, 20+ timeouts/stall
  windows, prewarm, bootstrap paths, overlay strings…), plus ~10 nested option classes bound as
  root properties.
- Several values exist in **two forms** (typed array + CSV string: `AvailableCharacters` /
  `AvailableCharactersCsv`, `GameModifierIds` / `GameModifierIdsCsv`, prices, placement tables)
  because AMP's UI can only write flat strings; merging happens in `Program.cs` PostConfigure.
- The same catalog data exists in **three places** that must be hand-synced: `CharacterCatalog`/
  `MapCatalog` (server), `MelonMapHelpers.BuildKnownLevelNames()` (mod, 41-slot carrier array whose
  *size* is load-bearing), and `deployment/amp-github-autoinstall/bapcustomservergithubconfig.json`
  (AMP UI labels with hardcoded charIds). The `MapCatalog` doc comment says "update … in lockstep";
  nothing enforces it.
- `AnalyticsOptions` regexes must match log-line formats emitted by `LobbyService` — config coupled
  to log strings. `AnalyticsRegexTests.cs` already pins the default regexes against literal copies
  of the log lines; what's still missing is a link from the regexes to the *actual message
  constants used at the log call sites* (a reworded log line still compiles and only the literal
  copies in the test would drift) — see `05-testing-and-tooling.md` §1.2.

### P5. Persistence is bespoke JSON-per-service — and not one shape, three
Seven services (`ServerAdminService`, `EconomyService`, `ShopService`, `FriendsService`,
`RankedService`, `MatchHistoryService`, `PlayerStorageService`, plus `PlayerOverridesService`) each
implement their own load/save/locking over files in `data/`. No shared store interface, no
transactionality across services (e.g. a character purchase touches economy + unlock state), and —
as the 2 failing tests showed (fixed in Phase 0) for `PlayerOverridesService` specifically — an
incomplete test-time isolation seam. Note the persistence shapes are NOT uniform (this matters
for the `IStateStore<T>` design in `02` A.5): most services are single-file snapshot stores (tmp-write + `File.Move`), but
`PlayerStorageService` is a *directory* of per-player files plus an index
(`players/{accountId}/player.json` + `index.json`, `PlayerStorageService.cs:713–730, 732+`), and
`MatchHistoryService` is a JSONL append log.

### P6. Protocol contract is implicit
`Contracts.cs` centralizes event names and DTOs (good), but:
- Response shapes for the ~60 stub endpoints are anonymous objects inline in `Program.cs`.
- Casing/null-suppression rules live in `JsonContract` but nothing snapshot-tests actual wire bytes.
- Some event strings are **inferred, not confirmed** (comment at `Contracts.cs` lines 77–81: friends
  WS strings were stripped by IL2CPP; a diagnostic logger in `HandleMessageAsync` exists to capture
  the real ones at runtime). Any rewrite must preserve the same inference *and* the capture path.
- Alias tolerance (`NormalizeEvent`, route alias sets) is spread between `LobbyService` and
  `Program.cs`.

### P7. Process-manager complexity is irreducible but under-modeled
`GameServerProcessManager` handles a genuinely hard problem (Unity-under-Wine cold start, F033
listener-only detection at line ~653, replayed setup POSTs, prewarm handoff). It is 1,578 lines of
sequential logic with states expressed as booleans/timeouts rather than an explicit bootstrap state
machine, which makes the many timeout knobs in `CustomServerOptions` hard to reason about.

## 3. Coupling map (who reaches into whom)

- `Program.cs` → everything (expected for a composition root, but it also *implements* logic).
- `LobbyService` → `GameServerProcessManager`, `MatchmakingQueueService`, `PortAllocator`,
  `ServerAdminService`, `EconomyService`, `PlayerStorageService`, `FriendsService`, options — the
  widest fan-out; it is both orchestrator and transport.
- `GameServerPrewarmService` ↔ `GameServerProcessManager` (prewarm handoff protocol).
- Mod `CustomServerMod` → everything in its project; helpers are leaf dependencies (correct
  direction, just too little extracted).
- Cross-repo: server `CharacterCatalog`/`MapCatalog` ↔ mod tables ↔ AMP JSON (manual sync).

## 4. What is testable/runnable where

| Thing | Linux (this VM / CI) | Windows + game build |
| --- | --- | --- |
| Server build + run (`dotnet run`, port 5055) | ✅ | ✅ |
| xUnit suite (375 tests, incl. WS + proxy integration tests via TestServer/sockets) | ✅ (2 failed from the unredirected `PlayerOverrides` default — see §1; fixed in Phase 0) | ✅ |
| Melon mod **build** | ⚠️ conditional: the 7 `UnityEngine*` reference DLLs under `AssetRip/AuxiliaryFiles/GameAssemblies/` are **Git-LFS pointers** on a plain checkout (build fails with CS0246); after `git lfs pull --include="AssetRip/AuxiliaryFiles/GameAssemblies/*"` (114 DLLs, ~17 MB) the build succeeds — verified both ways on this VM. NOTE: `AssetRip/` is gitignored (`.gitignore:8`) so these files are legacy-tracked; nothing new under `AssetRip/` can be committed, and `ARTIFACT_MANIFEST.md:11` describes the folder as a 2.27 GB local-only export — the 114 GameAssemblies DLLs are the only committed slice. See `05-testing-and-tooling.md` §3 for the CI consequence. | ✅ |
| Melon mod **execution** (MelonLoader + IL2CPP game) | ❌ | ✅ |
| `tools/Test-*Smoke.ps1` (need pwsh; `Test-MatchStart*` need `bapbap.exe`) | ❌ (no pwsh installed; no game build — `Spiel/` gitignored) | ✅ |
| AMP/Wine deployment path | partially (scripts lintable; wine run needs setup) | n/a (production is Linux) |

Implication for the rewrite: everything server-side can be verified in CI; mod-runtime and
full-match behavior can only be verified on the Windows game machine → the migration plan
(`04-migration-plan.md`) sequences mod changes behind server changes and keeps each mod phase small.

## 5. What is already good (keep, don't re-invent)

- `Contracts.cs` as the seed of a real protocol module; `Events` constants already exist.
- Fail-closed bootstrap philosophy and its logging discipline.
- `PortAllocator` — small, correct, tested; needs only an interface for injection.
- The `Melon*Helpers` extraction pattern + their Linux-runnable tests.
- Reflection caches in the mod (measurable GC win per its own comments).
- Rate limiting on admin paths; HMAC challenge admin handshake.
- 375-test suite: broad enough to act as the regression net during migration (after fixing the
  `PlayerOverrides`/`Shop` isolation hole).
- Extensive doc comments capturing *why* (e.g. carrier-array sizing, Wine UDP cooldown) — port these
  into the new modules as they migrate.

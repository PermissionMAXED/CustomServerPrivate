# 00 — Goals and Constraints

## Goals (in priority order)

### G1. Protocol safety through structure
The wire contract the game client speaks must become an explicit, versioned, tested artifact — not
an emergent property of 2,776 lines of minimal-API lambdas (`CustomMatchServer/Program.cs`) and a
3,512-line service (`LobbyService.cs`). Target: a dedicated **Protocol** module that owns every
event name, payload DTO, route alias, and casing rule, plus contract tests that fail if any of it
drifts (see `03-protocol-compatibility.md`).

### G2. Modularity
- Server: split the composition root into domain-grouped endpoint modules (auth/metagame, shop,
  friends, queue, admin, diagnostics, bootstrap callbacks) and split `LobbyService` into
  connection management, lobby state, match orchestration, and event dispatch.
- Mod: split `CustomServerMod.cs` (15,604 lines, one class, ~385 members) into cohesive components
  (config, network redirect, identity, bootstrap listener, dedicated-host runtime, UI, patch
  families) that still compile into a **single DLL**.

### G3. Testability
- Every new module unit-testable on Linux without `bapbap.exe`, Unity, or MelonLoader.
- The mod's pure logic follows the existing `Melon*Helpers.cs` pattern (Unity-free static helpers
  already covered by `MelonArgHelpersTests`, `MelonMapHelpersTests`, etc.) — extended so most of the
  mod's decision logic lives in testable classes and the MelonMod shell is thin.
- Contract/golden tests pin the wire protocol so refactors are verifiable without a live client.

### G4. Maintainability
- No file over ~800 lines; no class with more than one reason to change.
- Config declared once, validated at startup (`ValidateOnStart`), documented in one place instead of
  spread across `CustomServerOptions.cs` (862 lines), `Program.cs` PostConfigure blocks
  (~120 lines of CSV/JSON re-parsing), and AMP `.kvp`/JSON templates.
- Catalogs (characters, maps, game modes) generated from one source of truth instead of hand-synced
  across three places (see HC5).

### G5. Performance (bounded goal, not a driver)
The current system performs adequately for its scale (small private server, one process per match).
Keep existing optimizations — `ArrayPool` WS receive buffers, reflection caches in the mod
(`s_instanceMemberCache` etc.), rate limiting on `/admin` — and add (strictly **post-Phase-7**,
per decision-log #3 in `06-risks-and-open-questions.md`): per-connection send queues instead of
lock-per-send, `System.Text.Json` source generation for hot payloads, and no regression in match
bootstrap latency. Do not trade protocol risk for speculative performance — in particular the
send-queue swap changes abort-on-stall and broadcast error-isolation semantics and is NOT part of
the migration itself (see `02-target-architecture.md` A.3).

## HARD constraints (violating any of these fails the rewrite)

### HC1. 100% game-client protocol compatibility — the dominant constraint
The BAPBAP client is an unmodifiable IL2CPP binary. It cannot be patched to tolerate server-side
changes. Everything it observes is frozen:
- All HTTP routes **including aliases** (`/api/load`, `/load`, `/api/login`, `/login`, `/api/guest`,
  `/auth/guest`, … — see the ~30 alias registrations in `Program.cs` lines 431–470).
- Socket discovery on six paths (`/api/lobbies/socket`, `/api/lobby/socket`, `/lobbies/socket`,
  `/lobby/socket`, `/api/socket`, `/socket`) returning `{"socketUrl": "ws://..."}`.
- Uppercase WS events and their exact payload shapes: `JOIN_LOBBY`/`JOIN_LOBBY_SUCCESS`,
  `UPDATE_CUSTOM_SETTINGS[_SUCCESS]`, `START_CUSTOM_GAME[_SUCCESS|_FAIL]`, `QUEUE_MATCHED`,
  `GAME_STARTED`, `SWITCH_*`, `CANCEL_MATCHMAKING`, `MATCHMAKING_ENTERED/EXITED` (`…_ERRORED` is
  defined but never emitted — see `03` §1.3), the
  `MOD_HELLO → MOD_CHALLENGE → MOD_AUTH → MOD_AUTH_OK → ADMIN_AUTH → ADMIN_AUTH_RESULT` handshake
  (all defined in `CustomMatchServer/Contracts.cs`).
- camelCase JSON with null-suppression (`JsonContract.Options`, `JsonSerializerDefaults.Web`,
  `WhenWritingNull`) — field-name casing and null-emission behavior are part of the contract.
- The dedicated-host bootstrap: server POSTs `/setup-game`, `/add-teams`, `/queue-matched` to the
  Melon-mod listener inside the game process, fail-closed with managed status polling
  (`GameServerProcessManager.cs`).
- Event-name normalization tolerance (`LobbyService.NormalizeEvent`: `lobbies:join`, kebab/lower
  variants) — some tooling and older paths rely on it.
- **Deliberate delays and ordering workarounds are part of the frozen contract.** The 6-second
  delay at the start of `JoinLobbyAsync` (`LobbyService.cs:1150–1155` — the client must finish
  processing initial HTTP responses before `JOIN_LOBBY_SUCCESS` triggers UI init), the
  post-cleanup start delay (`GameServerPostCleanupStartDelayMillis`), empty-lobby grace windows,
  the 20 s WS keep-alive, and the 10 s send-timeout-then-abort are all client-observable timing
  behavior. They look like removable sleeps; they are not. See the "Timing & ordering contract"
  subsection of `03-protocol-compatibility.md` §1.3.
Details and the test strategy that locks all of this: `03-protocol-compatibility.md`.

### HC2. Linux + Wine + AMP deployment keeps working
Production runs the Windows Unity build under Wine/Xvfb via
`deployment/amp-full-linux-wine/start-match.sh`, orchestrated by CubeCoders AMP using the GitHub
AutoInstall template (`deployment/amp-github-autoinstall/`). The rewrite must keep:
- `CustomServer__*` environment-variable config binding (AMP writes env vars from its `.kvp` UI).
- The launcher templating (`GameLauncherPath` / `GameLauncherArguments` /
  `{gameExecutable}`/`{gameArguments}`/`{logFile}`/`{httpPort}`… placeholders in
  `CustomServerOptions.HeadlessArguments`).
- Fail-closed match start (`RequireGameServerBootstrap=true`): if bootstrap doesn't complete,
  players are requeued — never sent to dead ports.
- Single self-contained linux-x64 publish output that AMP launches directly.
- The AMP AnalyticsPlugin log-regex contract (`AnalyticsOptions` doc comments name the exact log
  lines AMP parses, e.g. `Client {AccountId} connected. admin={IsAdmin}` and
  `[Analytics] Match started: …`) — those log message shapes are an external interface too.

### HC3. Single-DLL mod, net6.0/x86, shipping to both clients and the match host
`BapCustomServerMelon.dll` runs in the visible player client **and** in the headless dedicated host
(`bapbap.exe -batchmode`). MelonLoader loads plain DLLs from `Mods/`; the refactor may split the
source into many files/classes and even multiple projects, but the shipped artifact stays one DLL
(ILRepack/ILMerge or compile-into-one-project), targets net6.0 x86, and must not retarget. The
same-DLL-everywhere property is also a correctness rule for the separate custom-character mod
(peer-identical registration, see `CONTEXT.md`) — keep the deployment story identical.

### HC4. Permissive metagame stubs stay permissive
`/api/iap/*`, `/api/challenge/*`, `/api/code/*`, mastery purchase, the `MapMetagameBootstrapEndpoints`
family (`/api/daily`, `/api/profile*`, `/api/leaderboards/*`, `/api/pinger`, … —
`Program.cs:1248–1340`), etc. intentionally return success stubs so the client UI never stalls on
a 404 or an error path with no offline handling. A "cleaner" rewrite must NOT turn these into
validation failures. They move into an explicitly named `MetagameStubEndpoints` module with a
comment and contract test each, but their observable behavior is frozen.
Careful with the boundary: several endpoints that sit *between* the stub blocks in `Program.cs`
have **real logic** and are NOT stubs — `/api/shop/freebie/purchase` and
`/api/shop/rotation/purchase` (`Program.cs:495–523`, real `ShopService`/`EconomyService`
debits), `/api/chars/listing/purchase` (`Program.cs:525+`, the real character-purchase workflow),
and the loopback-gated `/api/internal/xp` (`Program.cs:770–790`). The stub-vs-real classification
in `03-protocol-compatibility.md` §1.2 is authoritative; don't sweep real-logic endpoints into
`MetagameStubEndpoints` by line-range.

### HC5. Catalog-sync invariant
`CharacterCatalog` / `MapCatalog` / `GameModeCatalog` (`CustomServerOptions.cs` lines 643–862) are
the server's name↔id source of truth and MUST stay in sync with:
- the mod's `MelonMapHelpers.BuildKnownLevelNames()` carrier table (41 slots; index = mapId;
  indices 5..40 are custom-map carriers — array size is load-bearing, see bug B25),
- the AMP config UI JSON (`deployment/amp-github-autoinstall/bapcustomservergithubconfig.json`
  per-character/per-map toggles and their `charId` descriptions).
Shipped characters are ids 0–14; custom characters (Medusa) are id ≥ 15. The rewrite must make this
invariant *enforced by a test* (and ideally generated from one shared source) rather than a comment
saying "update these three places in lockstep". See `05-testing-and-tooling.md`.

### HC6. Two-tier admin model is intentional — preserve it
WS lobby admin checks only `AdminAccountIds` (plus the WS handshake grant cache); full HTTP admin
requires `ApiToken` or loopback trust (`AdminAuth.IsAuthorized`). A client spoofing
`X-BAP-AccountId` gets lobby admin but not full admin. This asymmetry looks like a bug and is not
one. Note the precise mechanics: the **raw game client** sets no identity headers, but the mod's
`LocalReverseProxy` *does* inject `X-BAP-*` headers (and query parameters, the primary carrier)
on the WS upgrade — identity is resolved from the upgrade `HttpContext`, not from any first
message (see `03-protocol-compatibility.md` §1.6). The rewrite documents this in the protocol
layer and keeps rate limiting on `/admin` and `/api/admin` paths.

### HC7. Never ship the forbidden skin AssetIds
`300001`, `300004`, `300006` are empty `SkinData` slots that crash the in-game locker UI. The
current filter lives in `BuildOwnedAssets`; the rewrite centralizes the deny-list in the catalog
module and adds a unit test that no shop slot, owned-assets payload, or default loadout can emit them.

## Non-goals

- Rewriting the game, the IL2CPP interop layer, or the separate `BAPBAPModdingAPI` character
  framework repo (`NetworkedCustomChar.dll` — different repo, only its integration points matter here).
- Changing the one-process-per-match execution model or replacing Wine with a native Linux build
  (no such build exists).
- Real economy/IAP (HC4 makes stubs permanent).
- Horizontal scaling / multi-node lobby state. JSON-file persistence is replaced by a storage
  *abstraction* (JSON default, SQLite optional) but distributed state is out of scope.
- Rewriting the PowerShell smoke scripts as a precondition — they remain the Windows e2e harness;
  CI-friendly equivalents are additive (`05-testing-and-tooling.md`).

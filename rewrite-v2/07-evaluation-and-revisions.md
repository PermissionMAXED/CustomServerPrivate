# 07 — Evaluation and Revisions (provenance)

The rewrite-v2 plan (docs `00`–`06`) was reviewed by **three independent evaluators**, whose
consolidated findings were then applied by a finalizer pass. Every finding that cites file/line
evidence was **re-verified against the actual repository** before the corresponding doc was
edited (key verifications listed at the bottom). This document records what changed so the
plan's provenance is auditable.

## High-severity corrections applied

1. **Timing & ordering contract added** (`03` §1.3 subsection; HC1 note in `00`; Phase 4 exit
   criterion in `04`; KNOWN_ODDITIES ledger rule in `06` R5). The client depends on deliberate
   server delays invisible to timing-blind golden tests: the 6 s `Task.Delay` at the top of
   `JoinLobbyAsync` (`LobbyService.cs:1150–1155`), `GameServerPostCleanupStartDelayMillis`
   (`LobbyService.cs:385–398`), empty-lobby grace windows, WS `KeepAliveInterval=20s`
   (`Program.cs:222–225`), and the 10 s `SendTimeout`→`Abort` (`LobbyService.cs:3329–3368`).

2. **WS identity section rewritten as a resolution ladder** (`03` §1.6; HC6 reworded in `00`).
   `ClientIdentityResolver.Resolve` (`AdminService.cs:501–557`) reads, in priority:
   `X-BAP-AccountId` → `X-BAP-UserId` (previously undocumented alias) → `?accountId` →
   `?userId` → `sid` cookie (`bapcustom-{id}`) → minted fallback. Identity is resolved from the
   **WS upgrade HttpContext** (`LobbyService.cs:799–837`), and the mod's proxy injects `X-BAP-*`
   headers on the upgrade (`LocalReverseProxy.cs:373–395`, query string primary carrier at
   `:264–296`) — the plan's earlier claims ("identity via first messages", "headers can't be set
   on WS upgrade") were wrong and removed. `sid` write-back documented (`AttachSessionCookie`,
   `Program.cs:1531–1547`). `X-BAP-Custom-Secret` reclassified: sent by the mod
   (`CustomServerMod.cs:38`), **ignored by the server** (zero references) — tolerate, never
   validate.

3. **HTTP route inventory and counts fixed** (`03` §1.2; `01` §1/§2; `04` Phases 0 & 2; `05`
   §1.2). Added the `MapMetagameBootstrapEndpoints` family (`Program.cs:1248–1340`, 12
   `MapClientJson` endpoints × GET+POST, incl. `/api/pinger`'s hardcoded
   `ws://127.0.0.1:5163/ws`) and the separately-registered mastery-progress endpoints
   (`Program.cs:570–608`). The hardcoded "125 registrations" figure was dropped everywhere:
   real surface ≈ 122 top-level `app.Map*` + 6×2 socket discovery + 12×2 client JSON ≈ **158
   route+method registrations**; the exit criterion is now expressed in terms of the
   `EndpointDataSource` dump plus a route+method **uniqueness assertion** (duplicate
   registrations are ambiguous-match at request time — `Program.cs:1271` comment).

4. **Outbound WS event inventory fixed** (`03` §1.3). Added the connect-time greeting sequence
   (`SOCKET_READY` → `GAME_MODES_UPDATED` → `SET_FRIENDS`/`SET_FRIEND_REQUESTS` →
   `FRIEND_STATUS` fan-out, `LobbyService.cs:728–737`); `GAME_MODES_UPDATED` (plural,
   `Contracts.cs:46`) incl. the load-bearing re-send after `JOIN_LOBBY_SUCCESS`
   (`LobbyService.cs:1287`); the emitted friends events; the banned-at-connect
   `JOIN_LOBBY_FAIL`/`ERR_BANNED` + `PolicyViolation` close (`LobbyService.cs:703–721`).
   Never-emitted constants annotated (grep-verified zero non-definition references):
   `MATCHMAKING_ERRORED`, `GAME_COMPLETED`, `FRIEND_ONLINE/OFFLINE`, `PARTY_INVITE_RECEIVED`,
   `FRIEND_REQUEST_*`, `UPDATE_FRIEND_REQUESTS`, `FRIEND_REMOVED`. Inventory now distinguishes
   "defined" vs "emitted".

5. **CI mod-build story corrected** (`05` §3; `01` §4; `04` Phase 6; `06` R7). Verified ground
   truth (which also refines the evaluators' claim): `AssetRip/` is gitignored (`.gitignore:8`)
   and mostly local-only (`ARTIFACT_MANIFEST.md:11`, 2.27 GB), **but** the 114
   `GameAssemblies/*.dll` files are legacy-tracked **Git-LFS objects** (~17 MB) whose content is
   fetchable: a plain checkout yields ~130-byte pointers and the mod build fails with CS0246
   (reproduced), while `git lfs pull --include="AssetRip/AuxiliaryFiles/GameAssemblies/*"` makes
   the build succeed (reproduced). The CI job now includes that fetch step, plus the recommended
   hardening (secured artifact with only the 7 referenced UnityEngine DLLs + licensing note) and
   the fallback (drop the CI job, gate on Windows).

6. **Git-LFS-pointer-in-`bin/` gotcha added** (`05` §3; `04` Phase 7). `.gitattributes:5` routes
   `*.dll` through LFS and ~2,580 stale `bin/`/`obj/` outputs are tracked (verified) — fresh
   checkouts materialize them as pointers or stale assemblies, breaking `dotnet test` ("No test
   is available"). CI now deletes tracked build outputs before building; Phase 7's hygiene item
   extends to `git rm -r --cached` of `bin/`/`obj/`.

7. **The 2 failing tests re-diagnosed everywhere** (`01` §1/§4/§5-P5; `05` §1.4; `06` R7 & Q8).
   NOT `data/` state leakage — `EndpointIntegrationTests.AppFactory`
   (`EndpointIntegrationTests.cs:27–64`) already redirects six services to a temp dir. Verified
   root cause: `CustomServer:PlayerOverrides:StateFile` (default `data/player-overrides.json`
   against `AppContext.BaseDirectory`, `PlayerOverrides.cs:11, 113–117`) is unredirected and the
   service auto-writes `unlockEverything: true` defaults (`PlayerOverrides.cs:198–216, 253–274`),
   defeating `UnlockAllCharacters=false` via `CharacterUnlockService.cs:84`. Both failure
   signatures (`Expected: 1/Actual: 3`, `Expected: 0/Actual: 1`) reproduced on this workspace,
   and the unlock-everything file was found in the test bin dir (it is even tracked in git).
   The fix must **override the defaults**, not merely relocate the file. `ShopService`
   (`data/shop-state.json`) noted as equally unredirected.

## Medium-severity corrections applied

8. `02`: (a) `Admin/` removed from the mod component tree and mermaid — `AdminAuthClient.cs`/
   `AdminOverlay.cs` are `Compile Remove`d from the main mod (`BapCustomServerMelon.csproj:16–19`)
   and link-compiled into the separate `BapAdminMelon.dll` (`BapAdminMelon.csproj:46–49`); the
   cross-project link arrangement documented as a constraint on file moves. (b) The send-queue
   swap moved OUT of Phase 4 step 1 to post-Phase-7 (contradiction with R2/decision-log #3
   resolved): lock-per-send moves mechanically; exit criteria added for any future queue
   (abort-on-stall, close-race, 50-socket broadcast dead-socket cleanup) — the 10 s-abort
   semantics (`LobbyService.cs:3329–3368`) and synchronous `GAME_STARTED` per-target isolation
   (`LobbyService.cs:1943–1978`) are load-bearing. (c) Option **types** moved to a new leaf
   project `Bap.Options` (Infrastructure consumes the timeout knobs; types in `Bap.Server` would
   invert `Server → Infrastructure`); binding stays in the host.

9. `02` A.5 / `04` Phase 3: persistence re-scoped to **three seams** — `IStateStore<T>` for the
   six single-file snapshot stores, `IKeyedStateStore<T>` for `PlayerStorageService`'s
   per-player directory + index (`PlayerStorageService.cs:713–730`), `IAppendLog` for the JSONL
   logs; mutation APIs get `TResult Mutate<TResult>(…)` (purchases return results).
   `SqliteStore<T>` dropped from Phase 3 (premature; Q2 narrowed accordingly).

10. `03` §1.5: loopback gating of `/game-ping`, `/game-ended`, `/team-ended` (+
    `/api/internal/*`) documented (`Program.cs:1100–1134`). Bootstrap detail expanded: hardcoded
    `GET /status` (`GameServerProcessManager.cs:527–529`), full 8-field
    `ManagedBootstrapStatus` (`:1370–1380`), listener-only replay constants (+6 s, 10 s spacing,
    max 4 — `:509–511, 580`), `RequireGameServerKcpPort` UDP gate (`:381–397`),
    explicit-`Content-Length` POSTs (`:1358–1366`). "Any failure requeues players" corrected:
    matchmaking requeues; the custom path sends `START_CUSTOM_GAME_FAIL`/
    `ERR_GAME_SERVER_BOOTSTRAP` and players stay in the lobby (`LobbyService.cs:1863–1875`).
    `LaunchGameServers=false` external-host short-circuit (`GameServerProcessManager.cs:39–52`)
    added as a `BootstrapDriver` preservation requirement (`02` A.4).

11. `03` §2.4: differential-harness determinism rules added — fixed `X-BAP-*` headers on every
    teed request (fallback identity derives from `Connection.RemotePort`,
    `Program.cs:1549–1556, 1597–1604`), canonicalization of minted ids/nonces/lobby+game ids,
    per-connection (not global) ordering assertions. Pinned: `JOIN_LOBBY_SUCCESS` =
    `{lobby,wasFull,wasInvalid,wasKicked}` with failures-as-success+null-lobby
    (`LobbyService.cs:1186–1226`); empty-string `warningMessage`/`errorCode` fields survive
    `WhenWritingNull` (`UPDATE_CUSTOM_SETTINGS_SUCCESS` shape, `:1618–1625`); `SWITCH_GAME_MODE`
    failures reuse `UPDATE_CUSTOM_SETTINGS_FAIL` (`:1641, 1658`); asymmetric `QUEUE_MATCHED`
    broadcast handling (matchmaking try/catch `:2200–2210` vs custom propagate `:1937–1938`)
    pinned before any tail unification; rollback-restart kills in-memory matches
    (`ApplicationStopping`→`StopAllMatches`, `Program.cs:416–419`) → idle-window flips only
    (also in `04` Phase 4 rollback).

12. `06`: new risks — R8 (gitignored-but-consumed paths: `deployment/amp-*/` ignore rule vs the
    tracked-legacy AMP JSON/`start-match.sh` the tools and `CatalogSyncTests` consume; `data/`
    fixture impossibility fixed in Phase 3; no `.sln` exists yet — must be created in Phase 0;
    Phase 0 `git ls-files` audit added) and R9 (single-maintainer bus factor: Windows gate
    machine, AMP instance, hardcoded `Sonic0810`/`ark.atomi23.de` in `tools/`).

13. `01` "Other projects": added `MapEditorUnity/` (Unity map-editor toolkit, 12 C# files) and
    `MapEditorVerify/` (6th csproj); documented LFS-tracked `dist/` DLLs + `.bak` siblings
    (interacts with Phase 6 rollback artifacts) and the `.gitattributes` LFS routing.

## Low-severity corrections applied

14. WS incoming cap corrected to **4 MB** (`LobbyService.cs:123`) in `01`/`02`/`03`.
15. `lobbies:matchmaking_cancel` added to the `NormalizeEvent` table (`LobbyService.cs:1128`).
16. Frame-type tolerance documented (non-Close message types parsed as JSON; outbound always
    Text — `LobbyService.cs:848–868, 3353`).
17. `/api/queue/join` response corrected to `{ok, message, position, secondsRemaining, charId}`
    (`Program.cs:1022`); leave/cancel/DELETE shape differences noted.
18. 404-logging middleware (`Program.cs:227–235`) preserved as the HTTP twin of the
    unknown-WS-event logger.
19. `AnalyticsRegexTests.cs` acknowledged as existing; `05` §1.2 reworded to "extend" (gap: bind
    regexes to log-call-site constants); `01` P4's "no test" claim fixed.
20. Numbers corrected: `CustomServerOptions` ≈54 root scalars + ~10 nested (not ~90);
    `CustomServerMod` ≈300 fields / ≈385 members (not ~120 fields / 413); tests = 42 `.cs`
    files (not 44); `app.Map` textual = 126 / ≈158 registrations (not 125).
21. HC4 stub line-ranges fixed — `/api/shop/*/purchase` (`Program.cs:495–523`),
    `/api/chars/listing/purchase` (`:525+`), and loopback `/api/internal/xp` (`:770–790`) are
    real-logic endpoints, excluded from the stub classification (aligned with `03` §1.2).
22. `02`: recommendation recorded to consider merging `Bap.Domain` into `Bap.Application`
    (decide at Phase 4).
23. Host-project transition named: `CustomMatchServer/BapCustomServer.csproj` keeps its
    name/path through Phase 7 (AMP publish scripts + `WebApplicationFactory<ApiEntryPoint>`,
    `Program.cs:2770–2776`, bind to it).
24. Cheap Linux-CI HC2 checks added (`05` §3 `linux-publish-smoke`): self-contained linux-x64
    publish + boot + `/health` smoke, and `shellcheck` on
    `deployment/amp-full-linux-wine/start-match.sh`.

## Verification notes

Re-verified directly against the working tree before editing (not taken on faith from the
audits): the 6 s join delay and its comment; `ClientIdentityResolver.Resolve`'s full ladder and
the `sid`-cookie parsing; `LocalReverseProxy`'s WS-upgrade header + query injection; the
`MapMetagameBootstrapEndpoints`/`MapClientJson`/`MapSocketDiscovery` definitions and the
122/126/158 counts; the greeting sequence and banned-at-connect path; the never-emitted event
constants (grep for non-definition uses); `PlayerOverrides` default-document generation and
`CharacterUnlockService.cs:84` (plus a live rerun of both failing tests reproducing
`Expected: 1/Actual: 3` and `Expected: 0/Actual: 1`, and the unlock-everything file present —
and tracked — under the test bin dir); `.gitignore:8`/`.gitattributes:5`/`ARTIFACT_MANIFEST.md:11`;
the LFS pointer→content behavior of `GameAssemblies` including a failing-then-passing mod build;
the tracked `bin`/`obj` count (~2,580) and `dist/` `.bak` inventory; the `Compile Remove`/link
pair in the two Melon csprojs; the bootstrap constants, status shape, and external-host
short-circuit in `GameServerProcessManager`; the loopback gates; `StopAllMatches` on shutdown;
`ApiEntryPoint`; and the absence of any `.sln`.

One evaluator claim was **corrected during verification** rather than applied as stated:
`GameAssemblies` is not "absent from the repo" — the 114 DLLs are committed as Git-LFS objects
(inside the gitignored `AssetRip/` folder) and their content is fetchable; the CI consequence
(fresh checkout can't build the mod without an explicit LFS step) stands, and the docs state the
verified mechanism.

# 03 — Protocol Compatibility: The Wire Contract and How to Lock It

**This is the hardest constraint of the whole rewrite.** The BAPBAP client is an IL2CPP binary we
cannot patch to tolerate changes; the Melon mod redirects its traffic but does not translate it.
Every observable behavior below is a public API. Anything not listed here should still be treated
as contract until proven otherwise (Hyrum's Law applies with force: the client was reverse-
engineered, not spec'd).

## 1. The contract to preserve

### 1.1 JSON conventions (apply to everything)
From `CustomMatchServer/Contracts.cs` `JsonContract.Options`:
- `JsonSerializerDefaults.Web` → **camelCase** property names, case-insensitive read.
- `DefaultIgnoreCondition = WhenWritingNull` → null properties are **omitted**, not emitted.
- Responses are compact (`WriteIndented = false`).
Changing casing, adding a stray `$type`, or emitting `"foo": null` where today the key is absent
are all breaking changes.

### 1.2 HTTP endpoints (server ← client / mod / proxy)

Grouped; full alias lists are in `Program.cs` (lines cited) and must be carried into
`Bap.Protocol/Routes.cs` as data.

**Counting rule (important):** do NOT hand-count registrations. `Program.cs` has ~122 top-level
`app.Map*` calls **plus** two local-function families that multiply routes: `MapSocketDiscovery`
(6 call sites × GET+POST = 12 registrations, `Program.cs:1240–1246`) and `MapClientJson`
(12 call sites × GET+POST = 24 registrations, `Program.cs:1342–1346`) — ≈ **158 route+method
registrations** total today. The authoritative inventory is the `EndpointDataSource` dump of
route+method pairs (see §2.2), not any hardcoded number in this document. The dump must ALSO
assert route+method **uniqueness**: ASP.NET minimal APIs accept duplicate registrations at
startup and only fail with an ambiguous-match exception at request time (this already bit the
codebase once — see the "`/api/shop` is now handled by ShopService" comment at
`Program.cs:1271`).

| Group | Routes (all registered variants) | Notes |
| --- | --- | --- |
| Health/root | `/`, `/health` | `/health` payload is read by smoke scripts + AMP checks |
| Socket discovery | `/api/lobbies/socket`, `/api/lobby/socket`, `/lobbies/socket`, `/lobby/socket`, `/api/socket`, `/socket` (GET+POST each via `MapSocketDiscovery`, `Program.cs:421–426, 1240–1246`) | returns `{"socketUrl":"ws://host:port/ws"}`; the mod's `LocalReverseProxy` rewrites this value — shape is doubly load-bearing |
| Auth/load | `/api/load`, `/load`, `/api/login`, `/login`, `/api/guest`, `/guest`, `/api/auth/guest`, `/auth/guest` — GET+POST each (16 registrations, lines 431–446) + `/api/auth/steam-ticket/login` | all → `BuildLoadResult` → `LoadResponse` DTO (accountId, username, discriminator, isGuest, level, isAdmin, assets[], loadout, availableCharacters[], …) |
| Auth misc | `/api/link/{provider}` (+ `/link`, `/api/auth/link`), `/api/complete` (+aliases), `/api/return`, `/return`, `/api/auth/logout` (+aliases) | fixed stub shapes, e.g. `{provider, params:""}`, `{twitchUsername:""}` |
| Loadout | `/api/loadout/banner`, `/api/loadout/skins` (+ un-prefixed POST variants) | equip result stub |
| Metagame stubs (HC4) | `/api/iap/steam/finalise`, `/api/iap/steam/purchase`, `/api/iap/xsolla/purchase`, `/api/shop/rotation/refresh`, `/api/chars/mastery/purchase`, `/api/challenge/claim/{drops,games,referral}`, `/api/challenge/signup`, `/api/code/creator-code`, `/api/code/redeem`, `/api/v1/user-lookup`, `/api/internal/api2/channels/`, `/api/internal/gold`, `/api/internal/reset-metagame` | permissive `{ok:true}`-style responses; MUST stay successes |
| Metagame bootstrap stubs (HC4) — the `MapMetagameBootstrapEndpoints` family (`Program.cs:1248–1340`), each GET+POST via `MapClientJson` | `/api/challenge/preview`, `/api/iap/listing`, `/api/daily`, `/api/profile`, `/api/profile/levels`, `/api/chars/pass`, `/api/chars/mastery/preview`, `/api/leaderboards/preview`, `/api/leaderboards/all/{mode:int}`, `/api/leaderboards/friends/{mode:int}`, `/api/leaderboards/self/{mode:int}`, `/api/pinger` | polled at lobby entry; fixed shapes. `/api/pinger` returns a **hardcoded** `"pingerUrl":"ws://127.0.0.1:5163/ws"` (`Program.cs:1310–1320`) — pin it as-is. `/api/chars/mastery/preview` is deliberately empty (native handler crashes on synthetic pass data — comment at `:1288–1291`) |
| Mastery progress (real logic, GET/POST mix) | `GET /api/chars/mastery/progress`, `GET /api/chars/mastery/progress/{charId:int}`, `GET+POST /api/chars/mastery/{charId:int}` (`Program.cs:570–608`) | per-player mastery state from `EconomyService`; NOT part of the `MapClientJson` family |
| Shop/economy (real logic) | `/api/shop` (GET/POST), `/api/shop/freebie/purchase`, `/api/shop/rotation/purchase`, `/api/chars/listing` (GET/POST), `/api/chars/listing/purchase`, `/api/internal/xp` (loopback-gated, `Program.cs:770–790`) | never emit skin AssetIds 300001/300004/300006 (HC7) |
| Friends | `/api/friends` (+ `add/accept/decline/remove/requests/invite/invites/toggle-*`) | |
| Matchmaking queue | `POST /api/queue/join`, `POST /api/queue/leave`, `POST /api/queue/cancel`, `DELETE /api/queue`, `GET /api/queue/cancel`, `GET /api/queue/status` | join returns `{ok, message, position, secondsRemaining, charId}` (`Program.cs:1022`); leave/cancel/DELETE each have slightly different response shapes (`wasInQueue` vs `message`) — pin each |
| Ranked/history | `/api/ranked/self`, `/api/ranked/leaderboard`, `/api/matches/history[/{gameId}]`, `/api/matches/player/{accountId}` | |
| Match callbacks (game host → server) | `/api/internal/game-ping` + `/game-ping`, `/api/internal/game-ended` + `/game-ended`, `/api/internal/team-ended` + `/team-ended` | called by the mod inside the dedicated host; both alias forms required. **All six return 401 unless `AdminAuth.IsLoopback(context)`** (`Program.cs:1100–1134`) — the differential harness must model loopback vs non-loopback callers (see §2.4) |
| Server config for mod | `/api/server-config`, `/api/internal/servers` + `/internal/servers` | mod reads roster/map settings from here |
| Admin (token/loopback per HC6) | `/admin/state`, `/admin/logs/audit`, `/admin/lobbies`, `/admin/matches`, `/admin/commands`, `/api/admin/{asset-index,bots,modifiers,…}`, `/api/diagnostics/*` | rate-limited (20 req/10 s per IP); not client-facing but tooling-facing |

Also preserve the **404-logging middleware** (`Program.cs:227–235`): every unmatched
route logs `404 Not Found: {Method} {Path}` at Warning. It is the HTTP twin of the
unknown-WS-event diagnostic logger — the live discovery mechanism for endpoints the client
calls that we don't know about yet. The rewrite keeps it verbatim.

### 1.3 WebSocket contract on `/ws`
- Upgrade: plain `AcceptWebSocketAsync` (no subprotocol). **Identity is resolved at upgrade time
  from the upgrade `HttpContext`** — see §1.6 for the full resolution ladder. (An earlier draft
  claimed identity arrives "via first messages" and that headers can't be set on the WS upgrade;
  both claims are wrong — `LobbyService.CreateConnection` calls `ClientIdentityResolver.Resolve`
  on the upgrade context at `LobbyService.cs:799–837`, and the mod's proxy does inject `X-BAP-*`
  headers on the upgrade.)
- Connect-time greeting (unsolicited, on EVERY accepted socket, before any inbound event —
  `LobbyService.cs:728–737`): `SOCKET_READY` → `GAME_MODES_UPDATED` (full mode list) →
  `SET_FRIENDS` per friend + `SET_FRIEND_REQUESTS` (`PushFriendsStateAsync`) → `FRIEND_STATUS`
  fan-out to online friends (`NotifyFriendsOfStatusAsync`). This ordering is contract: the client
  initializes lobby UI state from it. Golden WS tests must assert the greeting sequence, not just
  request/response pairs.
- Banned-at-connect path (`LobbyService.cs:703–721`): if the account is banned, the server sends
  `JOIN_LOBBY_FAIL` with `{warningMessage, errorCode:"ERR_BANNED"}` **immediately after accept**
  (no `SOCKET_READY` greeting) and closes with `WebSocketCloseStatus.PolicyViolation`/`"banned"`.
- Frame-type tolerance: the receive loop ignores `WebSocketMessageType` except `Close` — a binary
  frame is parsed as JSON like a text frame (`LobbyService.cs:848–868`); outbound frames are
  always `Text` (`LobbyService.cs:3353`). Preserve both.
- Incoming message cap: **4 MB** (`MaxIncomingMessageBytes = 4 * 1024 * 1024`,
  `LobbyService.cs:123`); an over-cap fragmented message closes with `MessageTooBig`.
- Envelope: `{"event": "<NAME>", "payload": {…}}` in both directions
  (`SocketEnvelope`/`OutgoingEnvelope`).
- Inbound events accepted (after `NormalizeEvent` — see 1.4): `SOCKET_READY` (echoed back),
  `JOIN_LOBBY`, `SWITCH_READY`, `SWITCH_CUSTOM_READY`, `UPDATE_CUSTOM_TEAM`,
  `UPDATE_CUSTOM_SETTINGS`, `START_CUSTOM_GAME`, `SWITCH_GAME_MODE`, `SWITCH_REGION`, `SWITCH_CHAR`,
  `CANCEL_MATCHMAKING` (+ aliases `CANCEL_QUEUE`, `LEAVE_QUEUE`, `QUEUE_LEAVE`, `LEAVE_MATCHMAKING`),
  `LOBBIES_LEAVE`, `FRIEND_INVITE_LOBBY`, `JOIN_FRIEND_LOBBY`, `MOD_HELLO`, `MOD_AUTH`, `ADMIN_AUTH`,
  `PING` (silently ignored). Unknown events must be logged at Information with payload kind — this
  logging is the live discovery mechanism for IL2CPP-stripped event names.
- Outbound events — the inventory MUST distinguish **emitted** from **defined-but-never-emitted**:
  - Emitted responses/broadcasts: `*_SUCCESS`/`*_FAIL` responses, `LOBBY_JOINED`, `LOBBY_LEFT`,
    `READY_UPDATED`, `CHAR_UPDATED`, `REGION_UPDATED`, `GAME_MODE_UPDATED`,
    `GAME_MODES_UPDATED` (plural — `Contracts.cs:46`; sent in the connect greeting AND re-sent
    right after `JOIN_LOBBY_SUCCESS` at `LobbyService.cs:1287` to move the client's `gameModeId`
    from `-1` to a valid value — that re-send is load-bearing), `QUEUE_UPDATED`,
    `MATCHMAKING_ENTERED`, `MATCHMAKING_EXITED` (+ legacy `MATCHMAKING_LEFT`), and the match pair
    `QUEUE_MATCHED` → `GAME_STARTED`.
  - Emitted friends events: `SET_FRIENDS`, `SET_FRIEND_REQUESTS`, `FRIEND_STATUS`,
    `INVITE_LOBBY`, `JOIN_FRIEND_LOBBY_SUCCESS` (strings inferred — see §3).
  - Defined in `Contracts.cs` but **never emitted anywhere** (grep-verified zero non-definition
    references): `MATCHMAKING_ERRORED`, `GAME_COMPLETED`, `FRIEND_ONLINE`, `FRIEND_OFFLINE`,
    `PARTY_INVITE_RECEIVED`, `FRIEND_REQUEST_RECEIVED`, `FRIEND_REQUEST_ACCEPTED`,
    `UPDATE_FRIEND_REQUESTS`, `FRIEND_REMOVED`. Keep the constants (they document intent and may
    be confirmed by live capture later) but annotate them `// defined, never emitted` and exclude
    them from "the server can send this" golden expectations.
- Error codes inside fail payloads: `ERR_BANNED`, `ERR_NOT_LEADER`, `ERR_MODE_DISABLED`,
  `ERR_CUSTOM_DISABLED`, `ERR_NOTREADY`, `ERR_ALREADY_STARTING`, `ERR_SERVER_FULL`,
  `ERR_GAME_SERVER_BOOTSTRAP` (grep-verified list from `LobbyService.cs`).
- The canonical happy path (also documented in `README.md`):
  `JOIN_LOBBY → JOIN_LOBBY_SUCCESS`, `UPDATE_CUSTOM_SETTINGS → UPDATE_CUSTOM_SETTINGS_SUCCESS`,
  `START_CUSTOM_GAME → START_CUSTOM_GAME_SUCCESS → QUEUE_MATCHED → GAME_STARTED`.
- Join success/failure shape (`LobbyService.cs:1186–1226, 1278–1284`): `JOIN_LOBBY_SUCCESS`
  payload is `{lobby, wasFull, wasInvalid, wasKicked}`. Join FAILURES for full / in-match /
  invalid-code lobbies are expressed as `JOIN_LOBBY_SUCCESS` with `lobby: null` plus the
  corresponding flag — **not** as `JOIN_LOBBY_FAIL`. Only the ban path uses `JOIN_LOBBY_FAIL`.
  Pin all four variants as goldens.
- Multicast rule: `GAME_STARTED` goes to **all connections of each account** in the match (a player
  may hold a lobby socket and a game-client socket); one dead socket must not abort dispatch to the
  rest (`LobbyService.cs:1943–1978`).
- Payload shapes with known landmines (from `Contracts.cs` comments):
  - `MatchmakingScoreSheetData`: client expects `tier` (string), `max`, `placements` (list), `kills`.
  - `MatchmakingDimensionData`: client expects `spawnPoint` (`{x,y}`) + `radius` (float), NOT
    `rounds`.
  - `LobbyData` carries `gold`/`fractals`/`charTokens`/`accountXp` — the client UI reads currency
    from the lobby payload, not `/api/load`.
  - `QUEUE_MATCHED.levelId` and `GAME_STARTED.mapId` must both carry the one authoritative map id
    that was sent to `/setup-game` (three-way parity).
- 3-step admin handshake ordering is enforced:
  `MOD_HELLO → MOD_CHALLENGE {nonce}`, `MOD_AUTH {nonce, signature=HMAC-SHA256(secret, nonce+accountId)}
  → MOD_AUTH_OK {ok, requestToken}`, `ADMIN_AUTH {token} → ADMIN_AUTH_RESULT {ok}`.

#### Timing & ordering contract (deliberate delays are frozen behavior)

The unmodifiable client depends on server-side delays and orderings that are **invisible to
golden/sequence tests** (which are timing-blind by construction). These are part of the frozen
contract and must survive the rewrite verbatim, each with an explicit timing test:

| Delay / ordering | Where | Why the client needs it |
| --- | --- | --- |
| **6-second delay** at the start of `JoinLobbyAsync` (`await Task.Delay(6000)`) | `LobbyService.cs:1150–1155` | the client must finish processing the initial HTTP responses (chars/listing, profile/levels, …) before `JOIN_LOBBY_SUCCESS` triggers UI initialization that depends on that data |
| `GameServerPostCleanupStartDelayMillis` wait before starting a game server after match cleanup (clamped 0–30,000 ms) | `LobbyService.cs:385–398` (`DelayAfterMatchCleanupAsync`) | fixed AMP ports must settle after Wine/Unity teardown before the next process binds them |
| Empty-lobby grace windows (`EmptyLobbyMatchCleanupGraceSeconds` / `…ConnectedCleanupGraceSeconds`) + the 10 s `ScheduleMatchServerStop` grace after `/game-ended` | `LobbyService.cs:192–205, 585–632` | the host still serves score/end-of-match traffic briefly after reporting game end; players re-connecting must not have the process killed under them |
| WS `KeepAliveInterval = 20 s` | `Program.cs:222–225` | client-side idle-connection behavior is tuned to this ping cadence |
| Per-send `SendTimeout = 10 s` then `Socket.Abort()` | `LobbyService.cs:3329–3368` | one wedged peer must not block broadcasts; the abort-on-stall semantic is what keeps the global `_gate` from deadlocking |
| Post-match auto-ready suppression windows (30 s `PostMatchRequeueSuppression`, 30 min `SuppressFlagTtl`) | `LobbyService.cs:139–160` | the client auto-sends a ready frame ~15–20 s after "Exit to Lobby" (after a full disconnect/reconnect **and** the 6 s join delay); the windows are sized to that cycle |

Rules: (a) these delays/orderings get their own entries in the KNOWN_ODDITIES ledger (see R5 in
`06-risks-and-open-questions.md`) — they look like removable "sleeps" and are not; (b) Phase 4 of
`04-migration-plan.md` carries an explicit exit criterion measuring the JOIN_LOBBY →
JOIN_LOBBY_SUCCESS elapsed time; (c) any new transport (send queues etc.) must preserve the
10 s-abort semantic, not just eventual delivery.
- Payload shapes with known landmines (from `Contracts.cs` comments):
  - `MatchmakingScoreSheetData`: client expects `tier` (string), `max`, `placements` (list), `kills`.
  - `MatchmakingDimensionData`: client expects `spawnPoint` (`{x,y}`) + `radius` (float), NOT
    `rounds`.
  - `LobbyData` carries `gold`/`fractals`/`charTokens`/`accountXp` — the client UI reads currency
    from the lobby payload, not `/api/load`.
  - `QUEUE_MATCHED.levelId` and `GAME_STARTED.mapId` must both carry the one authoritative map id
    that was sent to `/setup-game` (three-way parity).
- 3-step admin handshake ordering is enforced:
  `MOD_HELLO → MOD_CHALLENGE {nonce}`, `MOD_AUTH {nonce, signature=HMAC-SHA256(secret, nonce+accountId)}
  → MOD_AUTH_OK {ok, requestToken}`, `ADMIN_AUTH {token} → ADMIN_AUTH_RESULT {ok}`.

### 1.4 Event-name normalization (tolerance is contract too)
`LobbyService.NormalizeEvent` (lines 1119–1148) accepts lowercase, kebab-case, and
namespace-colon forms: `lobbies:join`, `lobbies:leave`, `lobbies:start`, `lobbies:cancel`,
`lobbies:matchmaking_cancel` (line 1128), `matchmaking:cancel|leave`, `queue:cancel|leave`, plus
generic `trim → '-'→'_' → UPPER`. This table moves verbatim into
`Bap.Protocol/EventNormalization.cs` with a golden test enumerating every mapping.

### 1.5 Dedicated-host bootstrap (server → mod inside `bapbap.exe`)
Fail-closed, three POSTs to `127.0.0.1:<httpPort>` (paths configurable but default-frozen:
`BootstrapConnectPath=/setup-game`, `BootstrapAddTeamsPath=/add-teams`,
`BootstrapQueueMatchedPath=/queue-matched`):
1. `POST /setup-game` body = `MatchmakingGameData` (reqId, queueId, modeIds, teamSize, mapId,
   gameModifierId[], dimensionData[], charSelect/spawnSelect/spawnShow millis, scoreTable[]).
2. `POST /add-teams` body = `MatchmakingTeamData` (reqId, gameId, botTeams, botDifficulty,
   spawnLocationPerTeam[], players[] with gameAuthId/charId/skinAssetId/teamId…).
3. `POST /queue-matched` body = `QueueMatchedData` (reqId, gameId, players[], botTeams,
   botDifficulty, availableCharacters[]).

Status polling details (all contract for `BootstrapDriver` in Phase 5):
- The status endpoint is **hardcoded `GET /status`** on the mod's listener
  (`GameServerProcessManager.cs:527–529`) — it is NOT configurable like the three POST paths.
- The full status document is `ManagedBootstrapStatus`
  (`GameServerProcessManager.cs:1370–1380`): `ok`, `networkStarted`, `setupGameApplied`,
  `addTeamsApplied`, `queueMatchedApplied`, `bootstrapRepairComplete`, `lastStatus` (string),
  `realtime` (double, seconds) — golden fixtures must carry all eight fields, not just the three
  `*Applied` flags.
- After each POST the server polls until the corresponding `*Applied` flag AND `networkStarted`
  are true. Listener-up-but-not-applied ("listener-only", F033) is a distinct state with its own
  timeout and **setup-POST replay**: first replay at +6 s, then every 10 s, max 4 replays
  (`GameServerProcessManager.cs:509–511, 580`).
- After the three POSTs succeed there is a final gate before `GAME_STARTED`: if
  `RequireGameServerKcpPort=true` the server also waits for the KCP **UDP** port to become
  visible (`GameServerProcessManager.cs:381–397`); if false, the UDP check is diagnostic-only.
- The bootstrap POST bodies are sent with explicit `Content-Length` (never chunked) because the
  mod's hand-rolled HTTP parser drops `Transfer-Encoding: chunked`
  (`GameServerProcessManager.cs:1358–1366`) — a rewritten HTTP client must preserve this.
- **External-host short-circuit:** with `LaunchGameServers=false`, `StartMatchServerAsync`
  returns a session pointing at `ExternalGameServerOptions` host/ports without spawning anything
  or running bootstrap (`GameServerProcessManager.cs:39–52`). The integration tests and any
  externally hosted deployment rely on this branch — Phase 5's `BootstrapDriver` must preserve it.

Failure semantics differ by start path — do NOT document this as "any failure requeues players":
- **Matchmaking path**: a bootstrap failure propagates to `MatchmakingHostedService`, which
  requeues the players (the fail-closed behavior HC2 describes).
- **Custom-lobby path**: a bootstrap failure sends `START_CUSTOM_GAME_FAIL` with
  `errorCode: "ERR_GAME_SERVER_BOOTSTRAP"` (+`showForceStartModal:false`) to the leader and the
  players simply **stay in the lobby** (`LobbyService.cs:1863–1875`) — there is no queue to
  requeue into.
Only after full bootstrap does the lobby broadcast `GAME_STARTED`. The client-side of this
contract is the mod's `BootstrapListener` — both sides must migrate against the same golden
fixtures.

### 1.6 Identity resolution ladder (HTTP **and** WS upgrade)
Identity for every HTTP request and every WS connection is resolved by
`ClientIdentityResolver.Resolve` (`AdminService.cs:501–557`) from the request/upgrade
`HttpContext`, in strict priority order:

1. Header `X-BAP-AccountId`
2. Header `X-BAP-UserId` (alias — previously undocumented; the mod sends BOTH,
   `LocalReverseProxy.cs:382–383`)
3. Query `?accountId=`
4. Query `?userId=`
5. Cookie `sid` with value `bapcustom-{accountId}` (prefix-stripped,
   `AdminService.cs:546–556`)
6. Minted fallback — `custom-{N}`/`Player{N}` on WS (`LobbyService.CreateConnection`,
   `LobbyService.cs:799–837`) or `custom-{RemotePort:0000}`/`Custom{RemotePort:0000}` on HTTP
   (`Program.cs:1549–1556, 1597–1604`).

Username (`X-BAP-Username` → `?username=` → fallback) and discriminator
(`X-BAP-Discriminator` → `?discriminator=` → fallback) resolve the same way.

Key facts the rewrite must not get wrong:
- **WS identity is resolved from the UPGRADE HttpContext, not from any first message.** The mod's
  `LocalReverseProxy` carries identity on the upstream WS URL **query string as the primary
  carrier** (`LocalReverseProxy.cs:264–296` — immune to `ClientWebSocket` restricted-header
  rejection on Mono) and ALSO injects `X-BAP-AccountId`/`X-BAP-UserId`/`X-BAP-Username`/
  `X-BAP-Discriminator` headers on the upgrade as a best-effort secondary carrier
  (`LocalReverseProxy.cs:373–395`). Any claim that "headers can't be set on the WS upgrade" is
  false for the proxy path; what remains true for HC6 is that the **raw game client** itself sets
  none of these — which is why WS lobby-admin trust rests on `AdminAccountIds` and the grant
  cache, not on upgrade headers.
- **Session cookie write-back:** auth/load responses attach `sid=bapcustom-{accountId}`
  (`AttachSessionCookie`, `Program.cs:1531–1547`; HttpOnly=false, SameSite=Lax, Path=/) so a
  cookie-preserving client keeps a stable identity across header-less requests. The cookie format
  is contract (step 5 of the ladder reads it back).
- **`X-BAP-Custom-Secret` is sent by the mod but IGNORED by the server.** The constant exists
  only in `CustomServerMod.cs:38` (default value `local-custom-server`); the server has **zero**
  references to it. The new server must *tolerate* (and ignore) the header — do NOT "finish" the
  feature by validating it, which would break every existing mod install that sends a mismatched
  or empty value.
- Fallback identity derives from `Connection.RemotePort` on HTTP — this makes header-less
  requests **non-deterministic across server instances** (see §2.4 determinism rules).

### 1.7 Launch-argument contract (server → game process)
`HeadlessArguments` default: `-batchmode -logFile "{logFile}" -httpport={httpPort}
-wsport={wsPort} -kcpport={kcpPort} -tcpport={tcpPort}` — parsed by the mod (`MelonArgHelpers`).
Port-quad semantics and `start-match.sh` wrapper templating (HC2) are part of this contract.

## 2. Strategy to lock the contract before rewriting

### 2.1 Layer 1 — Golden wire snapshots (new `Bap.Protocol.Tests`)
Serialize every outbound DTO (`LoadResponse`, `LobbyData`, `QueueMatchedPayload`,
`GameStartedPayload`, `MatchmakingGameData/TeamData/QueueMatchedData`, every stub shape) with
`JsonContract.Options` from fully-populated and minimally-populated instances, and compare
byte-for-byte against checked-in `.golden.json` files. Generate the initial goldens **from the
current code** so the current behavior is the spec. Any rewrite-induced diff fails CI with a
readable JSON diff. Include: camelCasing, null-omission, array-vs-null, float formatting
(`radius: 100`), and enum-as-number cases.

### 2.2 Layer 2 — Route/contract tests (new `Bap.Server.ContractTests`)
Against `WebApplicationFactory<Program>` (in-memory, Linux CI):
- **Route completeness**: a checked-in manifest (`routes.contract.json`) listing every
  route+method the current server answers (extracted once from the current `Program.cs`
  registrations; can be dumped from `EndpointDataSource` at startup). Test asserts new server
  answers exactly the same set — alias regressions become impossible.
- **Response-shape checks**: for each route in the manifest, issue a canonical request and
  snapshot status code + body (with volatile fields like timestamps/ids normalized).
- **Stub permissiveness**: every HC4 stub returns 2xx with its frozen body for empty, garbage, and
  well-formed inputs.
- **WS scenario scripts**: drive `/ws` through the happy path
  (`JOIN_LOBBY → … → START_CUSTOM_GAME` with `LaunchGameServers=false` + a fake
  `IGameServerLauncher`), the alias/normalization table, the admin handshake (good + each failure
  branch), and ban/leader error codes — asserting full outbound event sequences and payloads.
  The existing `EventNormalizationTests`, `LobbyPayloadTests`, `AuthHandshakeTests` are the seed;
  extend them into sequence-level assertions.

### 2.3 Layer 3 — Bootstrap contract fixtures (shared server/mod)
Check in golden JSON for the three bootstrap POST bodies and the status-endpoint responses at each
state (`fixtures/bootstrap/*.json`). Two consumers:
- Server side: `BootstrapDriver` tests feed a scripted fake listener that replays the status
  progression (including listener-only stall and mid-bootstrap crash) and assert fail-closed
  requeue behavior. (`BootstrapFlowTests`/`BootstrapPostTests` already cover parts — extend, don't
  replace.)
- Mod side: `BootstrapListener`/`BootstrapQueue` parsing lives in `Pure/` and is tested against the
  same fixture files on Linux.
This guarantees both halves of the rewrite speak the same frozen dialect even though they can only
be integration-tested together on the Windows game machine.

### 2.4 Layer 4 — Differential (old vs new) proxy harness — the strangler verifier
During migration, run OLD server (current `Program.cs`) and NEW server side by side; a small
recording proxy (reuse `CustomClientProxy` forwarding code) tees each HTTP request to both and
diffs status+body (normalized). For WS, replay recorded lobby sessions (captures already exist in
the repo's `*.log` diagnostics; add a session recorder toggle) against both and diff event
sequences. Run this in CI for HTTP; run it manually with a real client on the Windows box before
each cutover phase. This is the strongest evidence available short of the game itself.

**Determinism rules (without these, the harness diffs on noise, not regressions):**
- **Fixed identity on every teed request.** Fallback identity derives from
  `context.Connection.RemotePort` (`Program.cs:1549–1556, 1597–1604`), and a tee proxy
  necessarily gives the old and new servers *different* source ports — so every header-less
  request would diff on `accountId`/`username`. The harness must inject fixed `X-BAP-AccountId`/
  `X-BAP-Username`/`X-BAP-Discriminator` headers on every teed request.
- **Canonicalize volatile values** before diffing: minted `custom-{N}` ids, HMAC nonces from
  `MOD_CHALLENGE`, randomly generated lobby codes and `gameId`s, timestamps, `realtime` seconds,
  and `Set-Cookie: sid=` values.
- **Loopback modeling.** `/game-ping`, `/game-ended`, `/team-ended` (+ `/api/internal/*`) return
  401 for non-loopback callers (`Program.cs:1100–1134`); the harness must exercise both a
  loopback-origin and a remote-origin variant, since a tee proxy may change which one the server
  sees.
- **Per-connection ordering, not global order.** WS replay must assert the outbound event
  sequence *per connection*; a global total order across connections is not deterministic
  (broadcast fan-out interleaving is scheduler-dependent) and must not be asserted.
- **Pin the asymmetric `QUEUE_MATCHED` broadcast semantics before unifying the two start
  tails**: the matchmaking path wraps its `QUEUE_MATCHED` broadcast in try/catch so one dead
  socket cannot unwind into `MatchmakingHostedService` and requeue already-started players
  (`LobbyService.cs:2200–2210`); the custom path lets the same broadcast failure propagate
  (`LobbyService.cs:1937–1938`). Both behaviors get a golden test each; `MatchOrchestrator`
  (Phase 4/5) must reproduce both, or the unification is a wire-behavior change.
- **Empty-string fields are contract.** Error/success payloads carry `warningMessage`/`errorCode`
  sometimes as EMPTY strings — e.g. `UPDATE_CUSTOM_SETTINGS_SUCCESS` is
  `{settings, warningMessage:"", errorCode:"", maxTeams, mapMapping}` (`LobbyService.cs:1618–1625`).
  Empty strings survive `WhenWritingNull` and must not be "cleaned" into omitted keys. Also pin
  that `SWITCH_GAME_MODE` failures reuse `UPDATE_CUSTOM_SETTINGS_FAIL` (not a `SWITCH_GAME_MODE_FAIL`)
  for both not-leader and mode-disabled branches (`LobbyService.cs:1641, 1658`).
- **Rollback caveat:** flipping a migration flag requires a process restart, and
  `ApplicationStopping` runs `LobbyService.StopAllMatches()` (`Program.cs:416–419`) — a restart
  kills all in-memory lobbies and live matches. Schedule cutover/rollback flips during idle
  windows only; this is an operational rule for every phase in `04-migration-plan.md`.

### 2.5 Layer 5 — Live smoke (Windows game machine, unchanged)
`tools/Test-CustomServerSmoke.ps1`, `Test-LobbySettingsSmoke.ps1`, `Test-AdminControlsSmoke.ps1`,
`Test-MatchStartSmoke.ps1`, `Test-MatchStartTwoClientSmoke.ps1` remain the final gate for every
phase that touches the WS flow, bootstrap, or the mod. These launch real `bapbap.exe` processes and
are the only test of the IL2CPP client's actual tolerance.

## 3. Rules for ambiguous cases

- **Unknown-unknowns**: if a behavior isn't covered by a golden test yet, add the golden test
  *from the old implementation first*, then migrate. Never "fix" an oddity mid-migration (e.g. the
  legacy `MATCHMAKING_LEFT` alias, `Placement/Points` legacy fields in `MatchmakingScoreSheetData`,
  or the 16 load-route aliases) — record it, keep it, revisit only after full cutover.
- **Inferred friends events** (`SET_FRIENDS`, `FRIEND_STATUS`, … — `Contracts.cs:77–91`): keep the
  unknown-event diagnostic logger and the one-place definition so a live capture can correct them;
  treat current strings as contract until such a capture says otherwise.
- **Config-dependent contract**: bootstrap paths and `PublicGameHost` are configurable; goldens pin
  the defaults, and a test asserts the defaults never drift.

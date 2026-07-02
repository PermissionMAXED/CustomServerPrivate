# R13 — Dedicated / Headless Match-Host: Server-Authoritative Spawning, Abilities & Hitboxes

**Scope:** How the BAPBAP headless server runs and executes character spawning, abilities and
hitboxes WITHOUT rendering (server-authoritative paths), what differs from a client, and what a
server build must have *registered* for a custom character + custom abilities to work for
**everyone** in the match. Includes why the previous clone/client-graft approach (Medusa) is
fundamentally incompatible with a real dedicated host.

**Engine:** Unity 2022.3.38f1, IL2CPP, **Mirror** networking (+ `Mirror.SimpleWeb`, `kcp2k`,
`Telepathy`, a custom `WebRTCTransport`, all multiplexed).

> **Source note on the two code trees.** `GameCode\…\_DisabledScripts\Assembly-CSharp\BAPBAP\…`
> is the AssetRipper *stub* export — correct signatures/fields/attributes but **empty method
> bodies** (e.g. `GameNetworkManager.ConfigureHeadlessFrameRate()` is `{}`). The real method
> bodies are in `_decomp\` (ILSpy of the live DLL: `br\…GameModeBattleRoyale.decompiled.cs`,
> `hurtbox\…CharHurtbox.decompiled.cs`) and in the raw IL `_decomp\arena_gamecode_il.txt`.
> Citations below use whichever tree contains the cited fact.

---

## 0. TL;DR for the synthesis stage

1. **The dedicated host is the same Unity game build, launched headless** (`-batchmode -nographics`,
   on Linux through Wine/Xvfb per the CustomServer README) acting as a **Mirror dedicated server**
   via `GameNetworkManager : NetworkManager` with a dedicated `ConfigureHeadlessFrameRate()` path
   (`GameNetworkManager.cs`). There is **no host/listen client**: it is server-only.
2. **The server is authoritative for gameplay.** It spawns the player character
   (`GameMode.SpawnPlayerChar`) from `GameNetworkManager.characterPrefabsByCharId[charId]` via
   `NetworkServer.Spawn`, runs ability ticks (`CharAbilities.OnTick` / `SvOnAbilityTriggered`),
   spawns ability **hitboxes** (`HitboxBase : NetworkBehaviour`) with `NetworkServer.Spawn`, and
   applies damage server-side (`CharHurtbox.ApplyHit` → `[Server] SvSetHp/SvSetShield` SyncVars +
   `[ClientRpc] RpcOnHit`). Clients only **render** what the server tells them.
3. **Physics, colliders, NavMesh, animation logic, ability simulation, and damage all run on the
   headless server with no renderer.** Only *visual/audio presentation* (particles, meshes, VFX,
   SFX, camera) is client-only.
4. **For a custom character + abilities to work for everyone, the SERVER BUILD must itself have
   registered:** the char prefab in `characterPrefabsByCharId[charId]`, a matching Mirror
   `NetworkIdentity.assetId`, the prefab in `NetworkManager.spawnPrefabs` and the
   `NetworkPrefabPool`/`NetworkPrefabLibrary.PooledPrefabs`, **every** custom ability hitbox/
   projectile prefab as a spawnable networked prefab, and **identical** Mirror RPC/SyncVar
   registration (`RemoteProcedureCalls.RegisterRpc`) on server *and* all clients. Missing any of
   these = the char/ability is invisible, frozen, or non-functional for other players.
5. **Why Medusa failed (R13 lens):** it was a **client-only** mod. The dedicated server process had
   no Medusa prefab/assetId/pool, so it never network-spawned Medusa or her hitboxes; the mod's
   "damage" was a fake client-side driver gated on `Application.isBatchMode`/`graphicsDeviceType`
   that only does anything inside a listen-server. On a true dedicated host the authoritative path
   ran **base-Kitsu** logic. Result: not visible to others, despawns, frozen poses, only LMB works.

---

## 1. How the headless server process starts and runs

### 1.1 It is a Mirror `NetworkManager` running server-only

`GameNetworkManager` extends Mirror's `NetworkManager`:

- `GameCode\…\BAPBAP\Network\GameNetworkManager.cs` — `public class GameNetworkManager : NetworkManager`.
- Transports it owns and multiplexes (fields): `multiplexTransport` (`MultiplexTransport`),
  `wsTransport` (`SimpleWebTransport`), `kcpTransport` (`KcpTransport`), `tcpTransport`
  (`TelepathyTransport`), `webRTCTransport` (`WebRTCTransport`), plus `latencySimulation`.
  The custom ASP.NET proxy reaches the game over **`ws://127.0.0.1:5055/ws`** (SimpleWeb) per the
  CustomServer README, i.e. WebSocket transport into the headless game.
- It also has `webServer` (`WebServer`) — the in-process HTTP endpoint the external orchestrator
  pokes for match bootstrap (see §4).
- Interest management for AOI: `aoi` (`CustomSpatialHashInterestManagement`) — server decides which
  entities each connection can see (`Network\CustomSpatialHashInterestManagement.cs`,
  `CustomGrid2D.cs`). This runs server-side without rendering.

Server lifecycle overrides present on `GameNetworkManager`:

```
OnStartServer()                      // server boot
ConfigureHeadlessFrameRate()         // headless tick-rate config (override)
OnServerConnect(conn)
OnServerReady(conn)
OnServerAddPlayer(conn)              // server creates the player object
OnServerClInit(conn, ClInitMsg)      // client identity handshake (name/gameAuthId)
OnServerMatchmakingClInit(conn,msg)
OnServerMatchSetup(MatchmakingGameData)      // match bootstrap (mode/map/teams cfg)
OnServerMatchAddTeams(MatchmakingTeamData)   // team roster injection
OnServerQueueMatched(QueueMatchedData)       // start a queued match
OnServerMatchReset() / OnServerMatchCleanUp()
OnServerDisconnect(conn)
OnStopServer()
```

(All declared in `GameNetworkManager.cs`; bodies live in the live DLL.) The IL confirms the headless
hook exists: `_decomp\arena_gamecode_il.txt:78054` —
`instance void ConfigureHeadlessFrameRate () cil managed`.

### 1.2 `ConfigureHeadlessFrameRate()` — the "run without a screen" knob

Mirror's base `NetworkManager.ConfigureHeadlessFrameRate()` sets `Application.targetFrameRate` to
the server tick rate when running headless (so the server simulates at a fixed cadence instead of
spinning at uncapped FPS or being throttled by absent vsync). BAPBAP **overrides** it
(`GameNetworkManager.cs` declares `public override void ConfigureHeadlessFrameRate()`), giving the
match-host a deterministic simulation cadence that matches its `FixedUpdate` tick. This is the only
"frame rate" the headless host cares about — there is no render loop.

### 1.3 Detecting headless at runtime (the seam every system uses)

The canonical "am I a non-rendering server?" check is captured verbatim in the failed mod and is the
exact gate the game's own presentation code uses:

`BAPBAPModdingAPI\bapcustomchars-mod\MedusaMod.cs` — `CanSpawnClientFx()`:

```csharp
if (Application.isBatchMode) return false;                       // -batchmode
if ((int)SystemInfo.graphicsDeviceType == 4) return false;       // GraphicsDeviceType.Null (-nographics)
return true;
```

So on the dedicated host, `Application.isBatchMode == true` and
`SystemInfo.graphicsDeviceType == GraphicsDeviceType.Null`. **Anything visual must be skipped; all
gameplay must still run.** This is the dividing line of the whole document.

### 1.4 Where it physically runs (CustomServer deployment)

Per the workspace README and `docs/AMP_LINUX_WINE_ROOT_CAUSE.md`, the proven live path launches the
Windows `bapbap.exe` through `start-match.sh` under **Wine + Xvfb** on Linux AMP. Xvfb provides a
dummy X server so Wine/Unity initialize, but the game is still `-batchmode -nographics` for match
hosting — i.e. it is the dedicated Mirror server, not a player client.

---

## 2. Server vs client: what executes where

The codebase splits behaviour with three Mirror predicates, used pervasively:

| Predicate | Meaning | Typical use |
|---|---|---|
| `base.isServer` | running on the authoritative server | spawn entities, run gameplay, mutate SyncVars |
| `base.isServerOnly` | server **and not also a client** (true on dedicated host) | skip/disable client-only renderers, hide root |
| `base.isClient` | has a local client | UI, VFX, audio, camera, animation feedback |

Concrete evidence in `GameModeBattleRoyale.decompiled.cs`:

- `OnEnable()` — **all match logic is under `if (base.isServer)`**: choosing zone rounds, setting
  `NetworkzoneRoundsCount`, `SpawnNetworkedObjects()`, `LocalManager…SpawnDimension(...)`, setting
  `matchTime`/`NetworkmatchRemainingTimeSync`. Only the UI (`uiGameMode.battleRoyaleUI…`,
  `UpdateTimerUI()` coroutine) is under `if (base.isClient)`.
- `FixedUpdate()` — `if (!base.isServer || !gameManager.matchStarted) return;` then runs augment
  timers, event/supply-drop spawns, NPC ticks (`spawnNpcsObj.SvTick(...)`). **The match simulation
  tick is server-only and renderer-free.**
- `Start()` — `if (base.isClient) Localise(...)` only. Pure presentation.

Evidence in `CharHurtbox.decompiled.cs`:

- `Start()` — `if (base.isServer) SvSetHp(hp);` (server initializes authoritative HP).
- `if (flag && charMaterial != null && base.isServerOnly) { charMaterial.charRootHolder.SetActive(false);
  charMaterial.SetCharRendererEnabled(false); }` — the **dedicated server actively disables the
  character renderer** for items/interactables; it doesn't need meshes.

**Takeaway:** the headless server runs the FULL gameplay simulation (movement, abilities, hitboxes,
damage, zone, bots, match flow, physics, NavMesh pathing) and merely *omits rendering/audio/UI*.
Custom content must therefore have its **gameplay** half present and registered on the server.

---

## 3. Mirror weaving model (you MUST reproduce this for custom networked types)

The decompiled BR mode shows exactly how Mirror's IL weaver expands networked members. A custom
character/ability that introduces **new** `NetworkBehaviour` types or new RPCs must reproduce this
pattern *identically on server and clients*, or the per-method hash registry won't match and calls
will be dropped/desynced.

### 3.1 SyncVars (`GameModeBattleRoyale.decompiled.cs`)

```csharp
[SyncVar(hook = "OnPlayerCountChanged")] public int playerCount;
public int NetworkplayerCount {
  get => playerCount;
  set => GeneratedSyncVarSetter(value, ref playerCount, 4uL, _Mirror_SyncVarHookDelegate_playerCount);
}
public override void SerializeSyncVars(NetworkWriter writer, bool forceAll) { … writer.WriteInt(playerCount); … }
public override void DeserializeSyncVars(NetworkReader reader, bool initialState) { … GeneratedSyncVarDeserialize(ref playerCount, …, reader.ReadInt()); … }
```

Server writes `Network<field>`; the dirty-bit mask (`2uL`, `4uL`, `8uL`, …) and serialize order must
be byte-identical on both ends.

### 3.2 ClientRpc / TargetRpc / Command (same file)

```csharp
[ClientRpc] public virtual void RpcSendGameModeEventZoneClosing() {
  NetworkWriterPooled writer = NetworkWriterPool.Get();
  SendRPCInternal("System.Void BAPBAP.Game.GameModeBattleRoyale::RpcSendGameModeEventZoneClosing()", 881335321, writer, 0, includeOwner:true);
  …
}
// receiver side:
public virtual void UserCode_RpcSendGameModeEventZoneClosing() { /* real body: UI/VFX */ }
public static void InvokeUserCode_…(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient sender) {
  if (!NetworkClient.active) Debug.LogError("RPC … called on server."); else ((GameModeBattleRoyale)obj).UserCode_…();
}
// registration in the static ctor:
static GameModeBattleRoyale() {
  RemoteProcedureCalls.RegisterRpc(typeof(GameModeBattleRoyale),
    "System.Void BAPBAP.Game.GameModeBattleRoyale::RpcSendGameModeEventZoneClosing()",
    InvokeUserCode_RpcSendGameModeEventZoneClosing);
  …
}
```

Key facts for custom abilities:
- Each RPC is identified by a **string signature + stable hash** (e.g. `881335321`) registered via
  `RemoteProcedureCalls.RegisterRpc` in the type's static constructor. The Mirror weaver produces
  these at build time for game types. **A mod-added NetworkBehaviour must call `RegisterRpc` with the
  same signatures/hashes on server and all clients**, or RPCs silently mismatch.
- `[Server]` methods guard execution: e.g. `[Server] StartCloseZone()` begins with
  `if (!NetworkServer.active) { Debug.LogWarning("[Server] function … called when server was not active"); return; }`.
  Same pattern in `CharHurtbox` (`[Server] SvSetHp`, `[Server] SvSetShield`) and
  `BattleRoyaleZone` (`[Server] DamageAllPlayersInZone`, etc.).

### 3.3 Spawning networked objects (the replication primitive)

`GameModeBattleRoyale.SpawnBRZone()`:
```csharp
GameObject gameObject = UnityEngine.Object.Instantiate(zonePrefab, …);
zone = gameObject.GetComponent<BattleRoyaleZone>();
zone.Initialize(...);
NetworkServer.Spawn(gameObject);          // <-- server replicates to ALL clients by assetId
…
NetworkServer.Destroy(zone.gameObject);   // in DestroyNetworkedObjects()
```

`NetworkServer.Spawn` is how *every* networked object reaches clients. The prefab must carry a
`NetworkIdentity` whose `assetId` is registered in the client spawn table; otherwise clients can't
instantiate it. This is the crux for custom chars and custom ability hitboxes.

---

## 4. Match bootstrap on the headless host (orchestrator → game)

The external CustomServer (ASP.NET) launches the headless game and then **injects** the match config
through the in-game `WebServer` HTTP endpoints. The README documents the call sequence
`/setup-game`, `/add-teams`, `/queue-matched`, which map 1:1 to the `GameNetworkManager` server
methods:

| HTTP (CustomServer) | `GameNetworkManager` handler | Payload type |
|---|---|---|
| `/setup-game`     | `OnServerMatchSetup`     | `MatchmakingGameData` (mode, map, dimensions, settings) |
| `/add-teams`      | `OnServerMatchAddTeams`  | `MatchmakingTeamData` (per-team `MatchmakingPlayerData`) |
| `/queue-matched`  | `OnServerQueueMatched`   | `QueueMatchedData` |
| (cleanup)         | `OnServerMatchCleanUp` / `OnServerMatchReset` | — |

`MatchmakingPlayerData` carries the **selected `charId`** per player (see `Network\MatchmakingPlayerData.cs`,
`Game\UnityPlayerData.cs`). This is the value the server later feeds into `SpawnPlayerChar` (§5).
**A custom char's id must be a value the server accepts here and can resolve to a prefab.**

The Mirror handshake adds client identity on top: `ClInitMsg { playerName, gameAuthId }` →
`OnServerClInit`; the server answers with `SvInitMsg { buildVersion, teamIdCache, playerIdCache,
teammatePlayerIdsCache }`. Note `buildVersion`: server and clients are expected to be the same build
— another reason custom content baked into the server must also be present on clients.

---

## 5. Server-authoritative character spawning

### 5.1 The registration array

`GameNetworkManager` (`GameNetworkManager.cs`) holds the canonical character → prefab map:

```csharp
[SerializeField] public GameObject[] characterPrefabsByCharId;            // index = charId
[SerializeField] public CharacterBotPrefabs[] charBotPrefabsByCharId;     // per-difficulty bot prefabs
public GameObject GetCharacterBotPrefab(int charId, BotDifficulty botDifficulty);
public const int KitsuCharId = 0;  AnnaCharId = 1;  ZookCharId = 5;  TeeveeCharId = 8;  SpriestCharId = 11;  EveCharId = 12;
```

IL confirms the field on the manager: `_decomp\arena_gamecode_il.txt:77825`
`.field public … UnityEngine.GameObject[] characterPrefabsByCharId`.

`CharacterBotPrefabs.GetBotPrefab(BotDifficulty)` returns the easy/medium/hard/expert variant.

### 5.2 The spawn call

`GameMode.SpawnPlayerChar(PlayerManager playerManager, Vector3 spawnPos)` is the server entry point
(IL: `_decomp\arena_gamecode_il.txt:213375` `instance void SpawnPlayerChar (…)`). It is invoked
server-side from the match flow (e.g. pre-match → in-match transition). It:
1. looks up `characterPrefabsByCharId[playerManager.charId]`,
2. `Instantiate`s it at `spawnPos`,
3. `NetworkServer.Spawn(charGo, conn)` so the char replicates to every connection (by `assetId`),
4. wires `playerManager.primaryCharManager` (the `EntityManager`) — the field every system reads
   (`PlayerManager.primaryCharManager`, IL `:69764`, `:285601`).

`GameModeBattleRoyale.OnMatchBegin()` additionally calls
`SpawnAllBotsFill(GmTeamSize, currentMaxBotTeams, botDifficulty)` → uses
`GetCharacterBotPrefab(charId, difficulty)` for bot slots.

The failed mod's own patches corroborate these are the spawn seams:
`MedusaMod.cs` patches `GameMode.SpawnPlayerChar` (prefix `EnsureMedusaPrefabRegistered`),
`GameNetworkManager.OnStartServer`, `OnServerQueueMatched`, `OnServerMatchAddTeams`, and
`GetCharacterBotPrefab`.

### 5.3 What the server build needs for a custom char to spawn for everyone

For `SpawnPlayerChar`/`NetworkServer.Spawn` to produce a character that **all** clients see and that
behaves correctly:

1. **`characterPrefabsByCharId[customCharId]` populated on the SERVER** with the custom char prefab
   (so the server can instantiate it). If the server only has base chars, it will spawn a base char
   (or fail) regardless of what the client thinks it picked.
2. **A `NetworkIdentity` on the prefab with a stable `assetId`** that is identical on server and all
   clients. `NetworkServer.Spawn` sends the `assetId`; each client instantiates *its* prefab
   registered under that id. Mismatch/absence ⇒ client can't spawn it ⇒ char invisible to others.
3. **Prefab present in `NetworkManager.spawnPrefabs`** and in the pooling system
   (`NetworkPrefabLibrary.PooledPrefabs` + `NetworkPrefabPool.ServerCreate`/`ClientCreate`) — the
   game uses a `NetworkPrefabPool` (see `Pooling\NetworkPrefabPool.cs`, `NetworkPrefabLibrary.cs`),
   so spawned chars/hitboxes come from pools, not raw Instantiate. The server pool must contain the
   custom prefab (`Application.isBatchMode || NetworkServer.active` branch in the mod's
   `TryRegisterNetworkPrefabPool`).
4. **The gameplay components must exist on the prefab** server-side: `EntityManager`, `CharHurtbox`,
   `CharAbilities`, `CharMove`, `CharAim`, etc. The server runs all of these without rendering.
5. **`charBotPrefabsByCharId[customCharId]`** if the char should be usable as a bot; otherwise the
   server must fall back to a base bot for that slot (the mod does exactly this — see §8).

---

## 6. Server-authoritative abilities (cast → simulate → hitbox → damage)

### 6.1 Tick/command model

Abilities are part of a **predicted, tick-based simulation**. `CharAbilities`
(`Entities\CharAbilities.cs`) implements the simulated entity interface and exposes:

```csharp
public CmdBufferSystem cmdBufferSystem;                    // :53
public void OnTick(float fixedDt, Command cmd, bool isResim);   // :175  (server + client prediction)
public void OnAbilityCast(CommandId cmdId);                // :307
public void SvOnAbilityTriggered(CommandId cmdId);         // :311  (Sv = server-authoritative)
```

Flow: the client samples input into a `Command` (see `Network\SimulationFsm.cs`,
`NetworkedSimulationSubroutine.cs`, `INetworkSimulated.cs`, `INetworkPredicted.cs`) and sends it to
the server. The **server** replays the command in `OnTick` (renderer-free) and, when an ability
fires, calls `SvOnAbilityTriggered(cmdId)` — the authoritative trigger. `CharHurtbox.OnTick` has the
same signature (`(float fixedDt, Command cmd, bool isResim)`), confirming the unified server tick.

### 6.2 Ability prefabs and the hitbox

`Ability` (`Entities\Ability.cs`) holds `entityManager`, `charAim`, `charTriggerbox`, `triggerId`,
ability state (`AbilityStates`). Concrete ability subclasses (CatShot/CatMissile/CatPolymorph/
CatJump/Arrow/ChargedArrows/RecoilArrow/ArrowMissile, etc.) carry **spawn prefab references** that
the failed mod enumerates and nulls out: `spellPrefab`, `catSpellPrefabSmall`, `catSpellPrefabBig`,
`vfxCastPrefab`, `vfxJumpPrefab`, `vfxLandPrefab` (`MedusaMod.SuppressInheritedKitsuAbilityVfx`).
`spellPrefab` is the **networked hitbox/projectile** that the *server* spawns; `vfx*Prefab` are the
client-only presentation.

### 6.3 Hitbox = a server-spawned NetworkBehaviour

`HitboxBase : NetworkBehaviour` (`Entities\HitboxBase.cs`) is the authoritative hit volume:

- `[SyncVar] public int ownerPlayerId;`  `[SyncVar] public int teamId;` — replicated identity of the
  caster/team (so clients and server agree who owns the hitbox).
- `public ProjectileMove projMove;` — server-simulated motion (`Entities\ProjectileMove.cs`); runs
  in `ManagedFixedUpdate()`/`ManagedLateFixedUpdate()` with no renderer.
- `public VFXSpawn vfxSpawn;` `public AudioPlayFmod …;` — client-only presentation hooks.
- `public Ability ability;` — back-reference for attribution.
- `public void OnHitSuccess(EntityManager otherEntityManager)` — invoked when the hitbox's collider
  overlaps a valid target **on the server** (collision/`Physics` runs headless).
- `[Server] public void DestroyHitbox(...)`, `[ClientRpc] RpcOnHitboxImpact(Vector3)`,
  `[ClientRpc] RpcDestroyHitbox(bool,Vector3)` — server decides lifetime; clients get the impact/
  destroy presentation via Rpc. The `[ClientRpc]` methods follow the exact `SendRPCInternal` /
  `UserCode_*` / `InvokeUserCode_*` / `RegisterRpc` weaving shown in §3.
- `CanHitEntity(otherTeamId, otherPlayerId)` + `allowHitToEnemies/Team/OwnerPlayer/Interactables`
  filtering — friend/foe resolution done server-side.

So a real ability is: **server spawns `spellPrefab` (a `HitboxBase`) via the pool/`NetworkServer.Spawn`
→ `ProjectileMove` simulates it on the server → `OnHitSuccess` → `CharHurtbox.ApplyHit` (server) →
SyncVar HP + `RpcOnHit` to clients → `RpcDestroyHitbox`.** No client authority anywhere.

### 6.4 Damage application is server-only

`CharHurtbox.ApplyHit(...)` (`hurtbox\…CharHurtbox.decompiled.cs:296`) is the single damage funnel:

```csharp
public void ApplyHit(int damage, StatusEffectInfo[] statusEffects=null, int otherPlayerId=-1,
    GameObject otherCharObj=null, bool isCrit=false, …, Vector3 pushDir=default, …, Collider collider=null)
{
  if (this==null || entityManager==null || isDead || !gameManager.matchStarted) return;
  …
  damage = GetModifiedDamage(damage, otherCharShred);
  …
  SvSetShield(shield - num2);                 // [Server] SyncVar setter
  …
  if (!nonDamagable) SvSetHp(num4);           // [Server] SyncVar setter
  …
  RpcOnHit(oldLife, newLife, oldTotalLife, newTotalLife, damage, isCrit, applyWobble, isTrueDamage, otherPlayerId); // [ClientRpc] feedback
  RpcWobbleHit(pushDir.xz(), damage);
  …
}
```

- `SvSetHp`/`SvSetShield` are `[Server]` (lines ~843/859) guarded by `NetworkServer.active`; they
  mutate replicated HP/shield SyncVars. Clients learn HP **only** through these SyncVars + `RpcOnHit`.
- Status effects, lifesteal, thorns, aggro, scoring (`playerScores.damageDealt/Received`), kill
  detection — **all inside `ApplyHit`, server-side.** Death/elimination flows up to
  `GameModeBattleRoyale.OnPlayerKilled` (server) which drives placement, `EndMatch`, and the
  win/lose `TargetRpc`s.

**Implication for custom abilities:** the *damage* and *hit detection* of a custom ability must be
produced by server-side code that ends in `CharHurtbox.ApplyHit` (ideally by spawning a real
`HitboxBase` so existing collision + ApplyHit do the work). Anything the client computes locally is
purely cosmetic and never authoritative.

---

## 7. Exactly what a SERVER BUILD must have registered (checklist)

For a custom character **and** its custom abilities to work for everyone, the **headless server
build** (and, with matching ids, every client build) must contain:

1. **Char prefab** in `GameNetworkManager.characterPrefabsByCharId[customCharId]` with full gameplay
   components (`EntityManager`, `CharHurtbox`, `CharAbilities` + the 4 `Ability` slots, `CharMove`,
   `CharAim`, `CharStatusEffects`, `CharPassives`, …).
2. **Stable Mirror `NetworkIdentity.assetId`** on that prefab, identical server↔client, and the
   prefab present in `NetworkManager.spawnPrefabs` + `NetworkPrefabLibrary.PooledPrefabs` (server &
   client pool created via `NetworkPrefabPool.ServerCreate`/`ClientCreate`).
3. **Every custom ability hitbox/projectile prefab** (`HitboxBase` subclasses, the `spellPrefab`
   targets) registered the same way (own `NetworkIdentity.assetId`, spawn table, pool). The server
   `NetworkServer.Spawn`s these; clients must be able to instantiate them by assetId.
4. **Identical RPC + SyncVar weaving/registration** for any *new* `NetworkBehaviour` types
   (`RemoteProcedureCalls.RegisterRpc` with matching signatures/hashes; matching
   `SerializeSyncVars`/`DeserializeSyncVars` order and dirty-bit masks). If custom abilities reuse
   existing game `Ability`/`HitboxBase` types, you inherit their already-registered RPCs — strongly
   preferred over inventing new networked types.
5. **`charBotPrefabsByCharId[customCharId]`** (4 difficulties) if the char can be a bot; else a
   server-side fallback to a base bot char id (see §8).
6. **Server-acceptable `charId`** end-to-end: char select / `MatchmakingPlayerData.charId` /
   `SpawnPlayerChar` lookup must all agree on the id, and the id must index a real prefab on the
   server.
7. **Animator/animation assets** referenced by the char's `CharAnimator` must load on the server
   too (the server runs animation state for hit/ability timing even though it doesn't render);
   missing controllers cause the kind of layer/crossfade exceptions the mod had to guard.
8. **Status-effect ScriptableObjects** used by the abilities resolvable on the server (the mod
   resolves `_poisonSO`/`_petrifySO` at runtime) so `ApplyStatusEffects` works authoritatively.

If items 1–4 are not in the **server** build, the character/ability does not exist for other players
no matter what a client mod does.

---

## 8. Why the previous (Medusa) clone/client-graft approach is incompatible with a dedicated host

`bapcustomchars-mod\MedusaMod.cs` is a **MelonLoader client mod**. Read through the R13 lens, every
failure symptom maps to "the authoritative server never had the custom content":

1. **Registration happened on the wrong process.** The mod registers Medusa into
   `characterPrefabsByCharId`, `spawnPrefabs`, and `NetworkPrefabPool` **inside the local client**
   (patches on `GameNetworkManager.Awake/OnStartServer`, `TryConfigureMirrorPrefab` setting
   `_assetId = MedusaMirrorAssetId (0x4D454455)`, `TryAddSpawnPrefab`, `TryRegisterNetworkPrefabPool`).
   A real match is hosted by a **separate headless server process** that does **not** load this mod,
   so its `characterPrefabsByCharId` has no Medusa entry and no matching assetId. When the server
   ran `SpawnPlayerChar`, it spawned a **base** prefab (Kitsu) — which is exactly what other players
   see, and explains "not visible / wrong character to others."

2. **The damage path was a client-side fake.** `RunAuthoredMedusaAbilityDriver` →
   `ApplyAuthoredMedusaGameplay` manually scans entities and calls `charHurtbox.ApplyHit(...)`, but
   only `if (IsAuthoritativeServer(caster))` where `IsAuthoritativeServer = ((NetworkBehaviour)entity).isServer`.
   On a dedicated host the *real* server (no mod) is authoritative, so this driver **never executes
   there**. The mod also gates all visuals/hitbox-presentation behind `CanSpawnClientFx()`
   (`Application.isBatchMode`/`graphicsDeviceType==Null`), i.e. deliberately does nothing on the
   headless host. Net: the only thing that "worked" was the **inherited base ability** the mod did
   *not* suppress on a render-capable client (`TrySuppressInheritedKitsuShoot` returns early when
   `CanSpawnClientFx()`), which is why **only LMB** produced an effect and **E played Kitsu's
   animation** (it was literally still Kitsu's `CatJump`/arrow ability).

3. **Visuals were local-only, hence invisible and ephemeral.** Casts spawned presentation via
   `Object.Instantiate` of `MedusaFX_*`/`Hitbox_*` copies with `NetworkIdentity`/Mirror components
   **stripped** (`DisableNativeVfxGameplay`), then `Object.Destroy(..., ttl)`. Because they were
   never `NetworkServer.Spawn`'d, other clients never received them ("visuals only local"), and the
   TTL/scene-reset cleanup (`DestroyRuntimeMedusaArtifacts`) is what made them **despawn**.

4. **Frozen poses (Standbilder).** The mod re-grafts the visual/animator at runtime
   (`CharAnimatorRebindPatch`, `BindMedusaVisualToCharMaterial`, repeated `AnchorMedusaVisual`/
   `FitMedusaVisualToBaseBounds`). Comments in the file explicitly record that re-anchoring every
   frame **froze the pose**; and since the server never animated a Medusa entity (it animated Kitsu),
   the client had no authoritative animation stream to follow.

5. **Bots couldn't be Medusa.** `GameNetworkManagerGetCharacterBotPrefabPatch` rewrites a Medusa bot
   request back to a base char id — an admission that the server has no Medusa bot prefab.

**Root cause (one sentence):** the approach tried to add a networked character + networked abilities
**from a single client**, but BAPBAP is **server-authoritative Mirror** — spawning, ability
simulation, hitboxes and damage all happen on the dedicated host, so anything not registered and
executed on the server build is, by construction, invisible and inert for everyone else.

---

## 9. Design implications carried to the synthesis stage

1. **Ship custom content in the server build (or a server-side mod loaded into the headless
   process), not only the client.** The same prefabs, assetIds, spawn tables, pools, and RPC/SyncVar
   registrations must exist on the dedicated host and every client. `SvInitMsg.buildVersion` already
   assumes server/client parity.
2. **Prefer reusing existing networked types** (`Ability`, `HitboxBase` subclasses, `ProjectileMove`,
   `CharHurtbox`) so you inherit their weaved RPC/SyncVar registration instead of hand-writing
   `RegisterRpc`/serialize logic for new `NetworkBehaviour`s (a common desync source).
3. **Make abilities truly authoritative:** client sends a `Command`; server replays it in
   `CharAbilities.OnTick`/`SvOnAbilityTriggered`, spawns a real `HitboxBase` via
   `NetworkServer.Spawn`, lets `ProjectileMove` + collider + `OnHitSuccess` drive
   `CharHurtbox.ApplyHit`, then SyncVar/`RpcOnHit` replicates results. Keep all VFX/SFX strictly in
   the `base.isClient` / `CanSpawnClientFx()` branch so the headless host stays renderer-free and
   stable (this part the mod actually got right).
4. **Register the custom `charId` end-to-end:** char-select UI, `MatchmakingPlayerData.charId`,
   `characterPrefabsByCharId`, and `charBotPrefabsByCharId` (or a deterministic bot fallback).
5. **Keep gameplay components on the prefab and renderer/VFX components separable**, since the
   dedicated host disables/omits the renderer (`isServerOnly` branch in `CharHurtbox.Start`) but runs
   everything else.

---

## 10. Primary evidence index (file : line / symbol)

- Headless/server manager & registration arrays:
  `GameCode\…\BAPBAP\Network\GameNetworkManager.cs` — `: NetworkManager`; `ConfigureHeadlessFrameRate()`;
  `characterPrefabsByCharId`, `charBotPrefabsByCharId`, `GetCharacterBotPrefab`; `OnStartServer`,
  `OnServerAddPlayer`, `OnServerMatchSetup`, `OnServerMatchAddTeams`, `OnServerQueueMatched`,
  `OnServerMatchCleanUp`; transports `wsTransport/kcpTransport/tcpTransport/webRTCTransport`;
  `aoi` (`CustomSpatialHashInterestManagement`); `ClInitMsg`, `SvInitMsg`; `KitsuCharId=0` … `EveCharId=12`.
- IL corroboration: `_decomp\arena_gamecode_il.txt:78054` `ConfigureHeadlessFrameRate`;
  `:77825` `characterPrefabsByCharId`; `:213375` `GameMode::SpawnPlayerChar`; `:69764/:285601`
  `PlayerManager.primaryCharManager`; `:567970` `isServerOnly` params.
- Server-gated match logic & spawn: `_decomp\br\BAPBAP.Game.GameModeBattleRoyale.decompiled.cs` —
  `OnEnable` (`if (base.isServer)`), `FixedUpdate` (`if (!base.isServer…) return`),
  `SpawnBRZone` (`NetworkServer.Spawn`), `DestroyNetworkedObjects` (`NetworkServer.Destroy`),
  `[Server] StartCloseZone` (`NetworkServer.active` guard), `OnMatchBegin`→`SpawnAllBotsFill`,
  SyncVar `GeneratedSyncVarSetter`/`SerializeSyncVars`, `[ClientRpc]`/`UserCode_*`/`InvokeUserCode_*`/
  `RemoteProcedureCalls.RegisterRpc`.
- Server-authoritative damage: `_decomp\hurtbox\BAPBAP.Entities.CharHurtbox.decompiled.cs` —
  `: NetworkBehaviour, INetworkPredicted`; `Start` (`if (base.isServer) SvSetHp`); `isServerOnly`
  renderer-disable (l.235); `ApplyHit(...)` (l.296); `SvSetShield`/`SvSetHp` `[Server]` (l.~843/859);
  `RpcOnHit`/`RpcWobbleHit`; `OnHitDelegate`.
- Hitbox networking: `GameCode\…\BAPBAP\Entities\HitboxBase.cs` — `: NetworkBehaviour`;
  `[SyncVar] ownerPlayerId/teamId`; `projMove`/`vfxSpawn`/`ability`; `OnHitSuccess(EntityManager)`;
  `[Server] DestroyHitbox`; `[ClientRpc] RpcOnHitboxImpact/RpcDestroyHitbox`; `CanHitEntity`.
- Ability tick/cast: `GameCode\…\BAPBAP\Entities\CharAbilities.cs` — `cmdBufferSystem` (l.53),
  `OnTick(float,Command,bool)` (l.175), `OnAbilityCast(CommandId)` (l.307),
  `SvOnAbilityTriggered(CommandId)` (l.311); `Entities\Ability.cs` — `entityManager`/`charAim`/
  `triggerId`; ability-subclass `spellPrefab`/`vfx*Prefab` fields enumerated by the mod.
- Failed client approach: `BAPBAPModdingAPI\bapcustomchars-mod\MedusaMod.cs` — `CanSpawnClientFx()`
  (`Application.isBatchMode`, `graphicsDeviceType==Null`); `IsAuthoritativeServer = isServer`;
  `ApplyAuthoredMedusaGameplay`→`charHurtbox.ApplyHit`; `TrySuppressInheritedKitsuShoot`;
  `TryConfigureMirrorPrefab` (`_assetId = 0x4D454475`); `TryAddSpawnPrefab`/`TryRegisterNetworkPrefabPool`;
  patches on `GameMode.SpawnPlayerChar`, `GameNetworkManager.{Awake,OnStartServer,OnServerQueueMatched,
  OnServerMatchAddTeams,GetCharacterBotPrefab}`; `bapcustomchars-mod\CustomCharFramework.cs`
  (data-driven char definition: `CharId`, `MirrorAssetId`, `AbilityHitboxes`, `StatusOnHit`).
- Deployment: CustomServer `README.md` + `docs/AMP_LINUX_WINE_ROOT_CAUSE.md` — Wine/Xvfb
  `start-match.sh`, `ws://127.0.0.1:5055/ws`, `/setup-game` → `/add-teams` → `/queue-matched`.

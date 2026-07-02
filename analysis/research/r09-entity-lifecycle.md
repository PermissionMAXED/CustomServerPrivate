# R09 — Entity Lifecycle & Despawn Root Cause

**Stage:** R09 (entity lifecycle / despawn)
**Game:** BAPBAP — Unity 2022.3.38f1, IL2CPP, Mirror networking
**Goal of this stage:** Explain *precisely* why a cloned/client-grafted custom networked entity **despawns shortly after spawning** (and the related "invisible to others"/"frozen pose" symptoms), and define **what a correctly-registered entity needs to persist** for the from-scratch design.

> Method note: The primary decompile at
> `…\neueBapbap\GameCode\ExportedProject\_DisabledScripts\Assembly-CSharp\BAPBAP\` is a **header-only**
> decompile — class/field/SyncVar/attribute layout and method *signatures* are intact, but method
> *bodies* are stripped (every method returns default). The second IL2CPP decompile under
> `…\CustomServer\deployment\…\source-mapping\decompiled\` contains only IL2CPP interop accessor
> stubs (native pointer marshalling), not readable game logic. Therefore the lifecycle reconstruction
> below is built from: (a) the authoritative **field/SyncVar/attribute contract**, (b) the **Mirror
> framework semantics** those attributes imply, (c) the **failed framework's own code and runtime
> logs** which reveal the observed behaviour, and (d) cross-referenced sibling systems (pooling,
> interest management, GameMode spawn/kill, CharNetwork prediction). Every claim is tagged with its
> source. Where a claim is an inference from the contract rather than a directly readable body, it is
> marked **[inferred]**.

---

## 1. Files examined (with role)

| File | Role for this stage |
|---|---|
| `BAPBAP\Entities\EntityManager.cs` | The networked root component of every character/NPC/loot/interactable entity. Holds all SyncVars + lifecycle hooks. |
| `BAPBAP\Entities\EntityBehaviour.cs` | Base for hittable/activatable networked sub-entities (hitboxes etc.); `PreAwake(EntityManager e)` wiring contract + `[SyncVar]` cooldown/activation. |
| `BAPBAP\Entities\CharNetwork.cs` | Per-entity netcode: prediction, state/event sync, `OnStartServer/OnStartClient/OnStopServer/OnStopClient`, delta compressors. |
| `BAPBAP\Entities\CharDestroyTimer.cs` | TTL-driven server destroy (`INetworkPredicted`, `DoDestroy`). |
| `BAPBAP\Entities\CharHurtbox.cs` | Death/`isDead` path that drives kill→destroy. |
| `BAPBAP\Game\GameMode.cs` | Authoritative spawn/kill flow: `SpawnPlayerChar`, `SpawnBotChar`, `InstantiateEntity`, `SpawnEntity [Server]`, `DestroyCharacter [Server]`, `KillCharacter [Server]`, `KillPlayerSecondaryCharacters [Server]`, `DestroyPlayerOwnedCharactersImmediate [Server]`, `ResetAllEntities [Server]`. |
| `BAPBAP\Network\GameNetworkManager.cs` | `NetworkManager` subclass. `characterPrefabsByCharId`, `networkPrefabLibrary`, `spawnPrefabs`, `aoi` (interest mgmt), `GetCharacterBotPrefab`, server match lifecycle. |
| `BAPBAP\Pooling\NetworkPrefabPool.cs` / `NetworkPrefabLibrary.cs` | Mirror spawn-handler-based object pool keyed by **assetId** (`netIdLookup`, `poolLookup`, `SpawnHandler`/`DespawnHandler`). |
| `BAPBAP\Network\CustomSpatialHashInterestManagement.cs` | Server-side Mirror `InterestManagement` (AOI); `OnRebuildObservers`, `SetHostVisibility`, periodic rebuild. |
| `…\BAPBAPModdingAPI\bapcustomchars-mod\MedusaMod.cs` + `CustomCharFramework.cs` | The **failed** clone+graft framework. |
| `…\CustomServer\logs\*medusa*` | Runtime logs confirming observed behaviour. |

---

## 2. Anatomy of `EntityManager` (the persistence contract)

`EntityManager : NetworkBehaviour` with `[DisallowMultipleComponent]` (`EntityManager.cs`). It is the
**networked identity root** of an entity and is wired to every `Char*` sub-component via `[NonSerialized]`
references (`charNetwork`, `charEvents`, `charSim`, `charMove`, `charAim`, `charHurtbox`,
`charTriggerbox`, `charAbilities`, `charItems`, `charPassives`, `charStatusEffects`, `charHpRegen`,
`charDestroyTimer`, `npcBehaviour`, `targetDetection`, `charAnim`, `charMaterial`, `charFx`, …).

### 2.1 Entity classification
```csharp
public enum EntityType { Char = 0, Npc = 1, Loot = 2, Interactable = 3 }
public EntityType entityType;
public bool isNpc, isBot, isLootbox, isInteractable, isItem;   // [SerializeField]
```
These are **prefab-baked SerializeFields** — they are *not* SyncVars. A clone inherits whatever the
source prefab had. (`EntityManager.cs`, "Entity Type Configs" header.)

### 2.2 The SyncVars (state every client must receive to keep the entity alive & correct)
From `EntityManager.cs` (all `[SyncVar]`, several with hooks):

| SyncVar | Hook | Purpose |
|---|---|---|
| `string customEntityName` | – | display name |
| `bool isPrimary` | – | **is this the player's main character** (vs. a secondary/clone-ability entity) |
| `GameObject playerObj` | `OnPlayerObjChanged` | the owning `PlayerManager` GameObject — drives local authority / camera binding |
| `int charId` | – | character id (selects prefab + config) |
| `int charInstanceId` | – | unique instance id used by kill/cleanup routing |
| `int entityTeamId` | `OnEntityTeamIdChanged` | team |
| `int botPlayerId` | – | bot owner id |
| `int botSpectatorCount` | `OnBotSpectatorCountChanged` | – |
| `byte locked` | `OnLockedChanged` | portal / cinematic locks |
| `bool isMatchPoint` | `OnMatchPointChanged` | – |

Non-synced but lifecycle-critical: `int ownerPlayerId`, `bool dieWithPrimary`, `bool isDestroyed`,
`byte inPortalLocks`, `bool _isClient`, and actions `onDestroyEvent`, `svOnLockedChanged`,
`clOnLockedChanged`. There is also `uint ___playerObjNetId` — Mirror's backing netId for the
`playerObj` GameObject SyncVar.

**Key consequence [inferred from Mirror semantics]:** A SyncVar of type `GameObject` (`playerObj`) is
serialized **by netId**, not by reference. On a remote client the value resolves only if the referenced
object is itself a Mirror-spawned object known to that client. If the entity (or its `playerObj`) was
*not* server-spawned with a netId, `playerObj` deserializes to null on remotes → `OnPlayerObjChanged`
never binds ownership/camera there.

### 2.3 Lifecycle hooks (signatures present; bodies stripped)
`EntityManager.cs` declares: `Awake()`, `override OnStartClient()`, `override OnStopClient()`,
`Start()`, `OnDestroy()`, `SvOnLockedChanged()`, `[ClientRpc] RpcOnCharDestroy()`, `ClOnCharDestroy()`,
`GetTeamId()/GetPlayerId()/GetPlayerName()`, `UpdateTeam()`, `AddLock()/RemoveLock()`,
`ClStartAuth()/ClStopAuth()`, the SyncVar hooks, and the Mirror weaver plumbing
(`SerializeSyncVars`/`DeserializeSyncVars`, `InvokeUserCode_RpcOnCharDestroy`).

`CharNetwork.cs` adds the **server side**: `override OnStartServer()`, `override OnStopServer()`,
plus `OnStartClient/OnStopClient`, `SvTick`, `ManagedSvUpdate(Dictionary<int,NetworkWriter> stateWriters, …)`.

> **Lifecycle ordering [inferred, standard Mirror]:** server `NetworkServer.Spawn` →
> `OnStartServer` (server) → SpawnMessage to observers → each client instantiates the registered
> prefab/handler → `OnStartClient` → SyncVar initial-state applied → hooks fire. `ClStartAuth/ClStopAuth`
> on `EntityManager` are the camera/input authority transitions, gated by ownership. `Destroy` flows
> through `RpcOnCharDestroy` → `ClOnCharDestroy` → `OnStopClient`/`OnDestroy`.

### 2.4 The `PreAwake(EntityManager e)` wiring contract
Every sub-component exposes `public void PreAwake(EntityManager e)` (e.g. `CharNetwork.PreAwake`,
`EntityBehaviour.PreAwake`, `CharDestroyTimer.PreAwake`, `CharHurtbox` has the same pattern). This is
the game's **deterministic component-graph initialization**: `EntityManager.Awake` (or the spawn path)
calls `PreAwake` on each sibling so they cache the shared `EntityManager` and each other. The failed
mod hooks `CharAbilities.PreAwake` and `EntityManager.Start/OnStartClient` precisely because that is the
only safe point where the wired graph exists (`MedusaMod.cs`: `CharAbilitiesPreAwakePatch`,
`EntityManagerStartPatch`, `EntityManagerOnStartClientPatch`).

**Implication for new chars:** a from-scratch entity prefab must carry the *complete* `Char*` component
graph the game expects for its `entityType`, so that `PreAwake` wiring succeeds. Grafting a foreign
visual onto a base prefab does not change this graph (which is why the graft "works" structurally) —
but it also means **the networked entity is still the base character**, not a new one.

---

## 3. The canonical (correct) spawn lifecycle

Server-authoritative, from `GameMode.cs` + `GameNetworkManager.cs`:

1. **Prefab table is fixed at build/registration time.** `GameNetworkManager.characterPrefabsByCharId`
   (`GameObject[]`) maps `charId → prefab`, and `networkPrefabLibrary` (`NetworkPrefabLibrary`) holds
   `PooledPrefabs` (`NetworkPrefabPool.Config[]`) + `InstantiatedPrefabs`. The base
   `NetworkManager.spawnPrefabs` list is the Mirror registry of spawnable assetIds.
2. **Match setup.** `OnServerQueueMatched` / `OnServerMatchSetup` / `OnServerMatchAddTeams`
   (`GameNetworkManager.cs`) populate teams and trigger `GameMode` load.
3. **Char spawn.** `GameMode.SpawnPlayerChar(PlayerManager, Vector3 spawnPos)` (server) selects the
   prefab via `characterPrefabsByCharId[charId]`, instantiates through `InstantiateEntity` /
   `SpawnEntity [Server]`, and (via the pool or `NetworkServer.Spawn`) assigns a **netId + owner
   connection**. Bots: `SpawnBotChar(...)`. `GameMode.SpawnNetworkedObjects` / `SpawnEntityPrefab`
   handle map entities.
4. **Pool spawn handler.** `NetworkPrefabPool.Spawn(prefab,pos,rot)` and the per-pool
   `SpawnHandler(SpawnMessage)` / `DespawnHandler(GameObject)` are registered with Mirror keyed by the
   prefab's NetworkIdentity **assetId** (`poolLookup : Dictionary<uint,NetworkPrefabPool>`,
   `netIdLookup : Dictionary<GameObject,uint>`). On clients, Mirror reads `assetId` from the incoming
   `SpawnMessage` and calls the matching handler to materialize the object.
5. **Observer assignment (AOI).** `CustomSpatialHashInterestManagement` (the `NetworkManager.aoi`)
   computes observers in `OnRebuildObservers` / `OnCheckObserver`, on a periodic
   `fullRebuildInterval` (+ partial rebuilds via `RebuildPartial`, `RepopulateSpatialHash`). Only
   **server-spawned** identities are in this grid; it controls which clients receive/keep the object.
6. **Client materialization.** `OnStartClient` (EntityManager + CharNetwork) runs, SyncVar initial
   state (`charId`, `playerObj`, `isPrimary`, `entityTeamId`, `ownerPlayerId`-equivalent routing)
   applies, hooks fire, `ClStartAuth` binds camera/input for the owner.
7. **Lifetime.** `CharNetwork.SvTick`/`ManagedSvUpdate` stream predicted state each tick;
   `CharDestroyTimer.OnTick` (server) counts down `ttl` and calls `DoDestroy` when expired;
   death routes through `CharHurtbox` → `GameMode.KillCharacter`/`DestroyCharacter`.

---

## 4. Despawn mechanisms that exist in the game

These are the *only* code paths that remove a live entity. Each is a candidate for the observed bug:

| # | Path | Trigger | Source |
|---|---|---|---|
| D1 | **AOI observer loss** | Server's periodic `OnRebuildObservers` removes a client from an object's observer set → Mirror sends `ObjectHide`/destroy to that client. | `CustomSpatialHashInterestManagement.cs` (`OnRebuildObservers`, `RebuildPartial`, `fullRebuildInterval`) |
| D2 | **Pool despawn** | `NetworkPrefabPool.Despawn` / `DespawnHandler` returns the instance to `_inactive` via `Push` → `SetActive(false)`. `DespawnAfter`/`DespawnAfterRoutine` do it on a timer. | `NetworkPrefabPool.cs` |
| D3 | **TTL destroy** | `CharDestroyTimer.OnTick` server tick exceeds `ttl` → `DoDestroy`. | `CharDestroyTimer.cs` |
| D4 | **Death / kill** | `CharHurtbox.isDead` → `GameMode.KillCharacter`/`KillNpc`/`DestroyCharacter [Server]`. | `CharHurtbox.cs`, `GameMode.cs` |
| D5 | **Owner cleanup** | `GameMode.KillPlayerSecondaryCharacters` / `DestroyPlayerOwnedCharactersImmediate` iterate **player-owned** entities (by `ownerPlayerId`) and destroy them; `dieWithPrimary` ties secondaries to the primary. | `GameMode.cs`, `EntityManager.dieWithPrimary` |
| D6 | **Match reset** | `GameMode.ResetAllEntities [Server]` / `OnServerMatchReset` / `OnServerMatchCleanUp` / `GameMode.OnDisable`. | `GameMode.cs`, `GameNetworkManager.cs` |
| D7 | **Mirror "unknown assetId" rejection** | On a client, if a `SpawnMessage` carries an assetId with **no registered prefab/spawn handler**, Mirror cannot create the object (logs a spawn failure) — the object never appears, or a placeholder is discarded. | Mirror framework + `NetworkPrefabPool` registration |

---

## 5. Root-cause analysis — why the clone/graft entity despawns

The failed approach (`MedusaMod.cs` / `CustomCharFramework.cs`) does **clone + client-side graft**:

- It clones a **base** character prefab (Kitsu, `BaseCharId = 0`) at runtime
  (`RegisterPrefab` → `Object.Instantiate` of `characterPrefabsByCharId[baseCharId]`,
  renamed `Char_<Name>`), grafts the bundle visual onto it (`GraftMedusaVisual`), and stamps a **novel
  Mirror assetId** `0x4D454455` ("MEDU") via `TryConfigureMirrorPrefab` (`val._assetId = MedusaMirrorAssetId`).
- It tries to register that prefab into `characterPrefabsByCharId`, `spawnPrefabs`, and the
  `NetworkPrefabPool` (`TryRegisterNetworkPrefabPool`, `ClientCreate`/`ServerCreate`,
  `NetworkPrefabLibrary.PooledPrefabs` append).
- Crucially, on the **dedicated server** it *forces the char back to a base id*:
  `GameNetworkManagerGetCharacterBotPrefabPatch` rewrites Medusa's `charId` to
  `ResolveBotFallbackCharId(...)` (a base prefab). Comment in the mod: the headless host must run the
  "native authored-driver path … so the match-host behaves identically to the proven native build".

This produces a fundamental **server/client identity split**, which is the actual root cause of all
four symptoms. Concretely:

### 5.1 Why it is invisible to other players (visuals/attacks only local)
The authoritative entity that the server spawns and replicates is a **base-character entity** (the
Medusa visual/abilities were applied *client-side, locally* — see `MedusaMod` `SpawnMedusaCastFx`,
`GraftMedusaVisual`, and `SuppressInheritedKitsuAbilityVfx` which only runs on render-capable clients via
`CanSpawnClientFx()`). Other clients receive the base entity's SyncVars/state and render the base
character; they never receive the local graft or the local-only ability FX/damage driver
(`ApplyAuthoredMedusaGameplay` runs only `if (IsAuthoritativeServer(caster))`, and FX only on the local
machine). **The custom character has no networked existence — it is a local skin on a base entity.**

### 5.2 Why it despawns shortly after spawning
Two compounding mechanisms (D1, D7, and on dedicated hosts D5):

1. **assetId mismatch / unknown-prefab (D7).** When the prefab's NetworkIdentity assetId is changed at
   runtime to a value (`0x4D454455`) that is **not present in the server's authoritative spawnable set**
   (because the *server* deliberately spawns a base prefab — §5 bullet 4), the SpawnMessage assetId the
   other clients receive will not be the custom one. Conversely, if a client-side instance is created
   with the custom assetId but the server's identity uses a different one, Mirror's reconciliation on
   the next snapshot/`ObjectSpawnFinished` finds an identity/handler mismatch and **destroys the
   unmatched local object**. The mod's own `SanitizeMirrorIdentities` (zeroing `sceneId`, `_netId`,
   `hasSpawned`, `_SpawnedFromInstantiate`, `connectionToClient`) is an attempt to fight exactly this
   reconciliation, which confirms the failure mode.
2. **AOI observer rebuild (D1).** A locally-grafted/duplicate object that is **not server-spawned** is
   **not in the spatial-hash grid** (`CustomSpatialHashInterestManagement`). The interest manager's
   periodic `OnRebuildObservers`/`RebuildPartial` only manages server identities; any client-side extra
   is outside its bookkeeping and is hidden/destroyed the moment Mirror's snapshot for that netId says
   "not an observer here" or the base entity's visibility toggles. The mod's `MinimapAddIconOnPosByNetId`
   "duplicate netId" guard and the repeated `EnsureLocalMedusaBindingFromWorld` / `RepairLocalMedusaBinding`
   polling are direct evidence of the binding being lost and re-acquired (i.e. churn), not stable.
3. **On the dedicated host, owner-cleanup (D5).** Because the server runs the base path, any
   *secondary* entity the graft path may have produced that is owned by the player but is **not flagged
   `isPrimary`** (or has a mismatched `charInstanceId`) is a candidate for
   `KillPlayerSecondaryCharacters` / `DestroyPlayerOwnedCharactersImmediate`, which enumerate
   player-owned characters and destroy non-primary ones. `dieWithPrimary` further ties such entities to
   the primary's lifetime.

> Runtime corroboration: the client logs (`…\logs\*medusa*…client.log`) show the local object as
> `Char_Medusa(Clone)` repeatedly re-running `camera target repair … OnStartClient.alreadyPrimary`
> and `visual anchor / render enable` every spawn — i.e. the *local* instance is the primary and is
> being continually re-stabilized by the mod, while nothing in those logs shows a **server-replicated
> Medusa** reaching other observers. This matches "local-only, churns, despawns elsewhere".

### 5.3 Why it shows frozen poses (Standbilder)
Animation is driven through `CharAnimator` / `CharNetwork` predicted state. The graft rebinds
`CharAnimator.animator` to the bundle's Animator (`CharAnimatorRebindPatch`) and forces
`customAnimator = true`, but the **networked animation/locomotion state** is computed by `CharNetwork`
(`SvTick`/`ManagedSvUpdate`/prediction) for the *base* rig. When the foreign Animator is driven by a
controller whose state names/layers don't match what `CharNetwork`/`CharAnimator` expect, the animator
receives no valid locomotion updates → it rests on a default/idle clip = **frozen pose**. The mod even
patches `Animator.SetLayerWeight` / `CrossFadeInFixedTime` to *suppress invalid layer writes*
(`AnimatorSetLayerWeightMedusaGuardPatch`, `AnimatorCrossFadeInFixedTimeLayerGuardPatch`) — proof that
the foreign controller's layer/state topology does not match, so animation never advances normally.
Additionally, on remote clients (who only have the base entity) there is *no* Medusa rig at all to
animate.

### 5.4 Why abilities are broken (LMB only, RMB = green dot, Space bugs, E = Kitsu anim)
This is the ability-graft consequence (full detail belongs to the ability-stage research, summarized
here for lifecycle context):
- Abilities live as concrete `Ability`-derived components on the prefab
  (`CatShotAbility`, `ArrowAbility`, `CatJumpAbility`, …), invoked by `CharAbilities.SetCastAbility`
  with `CastFlags` (bit 0=LMB, 1=Q/RMB, 2=Space, 3=Ult — see `MedusaMod.TryRunMedusaAbilityDriverFromCastFlag`).
- The graft keeps the **base (Kitsu) ability components**; LMB maps to the base shot which "works"; the
  other slots' authored prefabs are nulled out by `SuppressInheritedKitsuAbilityVfx` on the server while
  the client tries a hand-rolled `ApplyAuthoredMedusaGameplay`/`SpawnMedusaCastFx`. The "green dot" =
  fallback FX primitive / missing spell prefab; "E plays Kitsu's animation" = the inherited base ability
  animation still firing because the ability component is still Kitsu's. **The abilities were never
  modeled as networked, server-driven `Ability` components on a real prefab — they were faked
  client-side.**

### 5.5 The unifying root cause
> **The custom character is not a first-class, server-spawned networked entity. It is a base-character
> entity with a client-side cosmetic/ability graft and a runtime-mutated Mirror assetId.** Because the
> server's authoritative spawn uses a base prefab (and the assetId/prefab registration is not identical
> and stable across server + every client), the entity has **no consistent networked identity**:
> Mirror's spawn/observer/reconcile machinery (D1/D7) culls the client-side custom object, owner-cleanup
> (D5) can remove non-primary owned duplicates, and the foreign animator/abilities never receive valid
> networked state (frozen pose, broken abilities). All four symptoms are facets of the same identity
> split.

---

## 6. What a correctly-registered entity needs to **persist** (checklist)

Derived from the EntityManager SyncVar/lifecycle contract + Mirror + pool + AOI semantics:

1. **One canonical prefab, registered identically on server *and* every client.** The custom-char prefab
   must exist in `GameNetworkManager.characterPrefabsByCharId[charId]` **on the server** (not just the
   local client), be in `NetworkManager.spawnPrefabs`, and—if pooled—have a
   `NetworkPrefabPool.Config` in `networkPrefabLibrary.PooledPrefabs`. (`GameNetworkManager.cs`,
   `NetworkPrefabPool.cs`)
2. **A stable, build-consistent NetworkIdentity `assetId`.** The assetId must be the **same value on
   all peers** and must be the one the *server actually spawns from*. Do **not** mutate assetId at
   runtime on only one side, and do **not** let the server fall back to a different (base) prefab while
   clients expect the custom one. (Counter-example: `MedusaMod.TryConfigureMirrorPrefab` +
   `GetCharacterBotPrefabPatch` — the exact mismatch that breaks D7.)
3. **Server-authoritative spawn via the game's path.** Spawn through `GameMode.SpawnPlayerChar` /
   `SpawnBotChar` / `SpawnEntity [Server]` (which call `NetworkServer.Spawn`/pool `Spawn`), so the entity
   receives a real `netId`, an **owner connection**, and is entered into the AOI grid. A client-side
   `Instantiate` is never a persistent networked entity. (`GameMode.cs`)
4. **Correct SyncVar initialization on the server:** `charId`, `isPrimary = true` for the player's main
   character, `charInstanceId` (unique), `entityTeamId`, `ownerPlayerId`, and `playerObj` set to the
   owning `PlayerManager` GameObject (which must itself be Mirror-spawned so the by-netId SyncVar
   resolves). These drive `OnPlayerObjChanged`/`ClStartAuth` (camera/input) and kill-routing.
   (`EntityManager.cs`)
5. **Complete `Char*` component graph for its `entityType`**, so `PreAwake(EntityManager e)` wiring
   succeeds and `CharNetwork` prediction/state-sync, `CharAnimator`, `CharHurtbox`, `CharAbilities` all
   operate. A new character should be a *real* prefab variant carrying this graph, with its own
   Animator controller whose state/layer topology matches what `CharAnimator`/`CharNetwork` drive
   (otherwise §5.3 frozen poses recur). (`EntityManager.cs`, `CharNetwork.cs`, `EntityBehaviour.cs`)
6. **Not flagged for premature destroy:** `isDestroyed=false`, no expired `CharDestroyTimer.ttl`,
   `dieWithPrimary` set **only** for genuine secondaries, and the entity must be the registered
   `isPrimary` so owner-cleanup (`KillPlayerSecondaryCharacters` / `DestroyPlayerOwnedCharactersImmediate`)
   does not reap it. (`CharDestroyTimer.cs`, `GameMode.cs`)
7. **Inside the AOI grid:** guaranteed automatically *iff* server-spawned (step 3). Never rely on a
   client-side duplicate; it will be hidden/destroyed on the next `OnRebuildObservers`.
   (`CustomSpatialHashInterestManagement.cs`)
8. **Pool symmetry:** if registered with the pool, both `ServerCreate` and `ClientCreate` must run on
   their respective peers with the **same Config/assetId**, so `SpawnHandler`/`DespawnHandler` round-trip
   correctly and `Despawn` returns it to the pool instead of orphaning it. (`NetworkPrefabPool.cs`)

---

## 7. Implications for the from-scratch design (handoff to synthesis)

- **Treat a new character as a new networked prefab + new `charId`, registered identically on server and
  client at load time (before any match spawn), with a fixed assetId.** This is the single change that
  dissolves the despawn/invisibility/frozen/ability cluster — all of which stem from the server/client
  identity split, not from any single bug.
- **Never graft visuals/abilities only on the client.** Visuals (skinned mesh + Animator controller) and
  ability components must live on the server-spawned prefab so SyncVars/prediction/AOI replicate them to
  everyone.
- **Abilities should be modeled as the game's `Ability`-derived components on the prefab**, cast via
  `CharAbilities`/`CastFlags`, so they are server-driven and networked (eliminates LMB-only / green-dot /
  Kitsu-E). (Detailed ability wiring is the ability-stage's deliverable; this stage establishes that the
  ability components must ride a correctly-registered entity to be networked at all.)
- **The dedicated headless host must spawn the SAME prefab/charId as clients expect** (do not rewrite the
  custom charId to a base id on the server). If the headless host cannot render, that is a *graphics*
  concern handled by `Application.isBatchMode` guards on FX only — the **networked entity identity must
  remain the custom one** on the server.
- **A registration/lifecycle hook point** that is safe: install the prefab into
  `characterPrefabsByCharId`/`spawnPrefabs`/`networkPrefabLibrary` at `GameNetworkManager.Awake` /
  `OnStartServer` (server) and at client connect, *before* `OnServerQueueMatched`/`SpawnPlayerChar`.
  (`GameNetworkManager.cs`; the failed mod already targets these hooks — it just registered a *clone*
  with an unstable assetId instead of a proper, server-consistent prefab.)

---

## 8. Confidence & gaps

- **High confidence:** the SyncVar/attribute/lifecycle contract of `EntityManager`/`CharNetwork`; the
  spawn entry points in `GameMode`/`GameNetworkManager`; the pool's assetId-keyed handler model; the AOI
  being server-only; the failed mod's clone+graft+runtime-assetId+server-base-fallback design (all read
  directly from source / the mod / logs).
- **Inferred (marked):** exact internal bodies of `OnStartClient`/`OnStartServer`/`OnDestroy`/
  `RpcOnCharDestroy` and the precise order of SyncVar-hook firing — bodies are stripped in both
  decompiles. These are reconstructed from Mirror's documented semantics + attribute usage and are
  consistent with the runtime logs.
- **Open for adjacent stages:** the precise `Ability`/`CastFlags`/`CharAbilities` cast pipeline
  (ability stage), the Animator controller/state-name contract for a custom rig (animation stage), and
  the exact prefab/assetId registration API surface to use for clean first-class registration
  (registration stage). This stage's conclusion — *entities persist only as first-class, server-spawned,
  identically-registered networked prefabs* — is the precondition all of those depend on.

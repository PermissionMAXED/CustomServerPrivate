# R11 — VFX Spawning & Replication in BAPBAP

**Scope:** How ability VFX are spawned, whether they are server-spawned + networked or client-local,
which visuals every player sees vs only the local client, and how to make a custom ability's VFX
visible to all players. Unity 2022.3.38f1, IL2CPP, Mirror networking.

**Source roots cited below**

- Decompiled game: `C:\Users\Administrator\Downloads\neueBapbap\GameCode\ExportedProject\_DisabledScripts\Assembly-CSharp\BAPBAP\` (referred to as `…\BAPBAP\…`).
- Failed mod framework: `C:\Users\Administrator\Downloads\BAPBAPModdingAPI\bapcustomchars-mod\MedusaMod.cs` and `CustomCharFramework.cs`.

> **Decompiler caveat (important for the synthesis stage).** The `_DisabledScripts` tree is an ILSpy
> header/stub export of an IL2CPP build. **All method bodies are empty** (`return null/0/false`, blank
> `{}`). Every structural claim below is therefore reconstructed from *signatures, field names, types,
> base classes, attributes (`[ClientRpc]`, `[Server]`, `[SyncVar]`), and Mirror weave artifacts*
> (`UserCode_*` / `InvokeUserCode_*` / `Weaved()`), which are fully intact and unambiguous. Behavioral
> claims about *order of operations inside a body* are inferred from these and are flagged where they are
> inference rather than direct evidence.

---

## 1. Executive summary

BAPBAP has **four distinct VFX delivery mechanisms**, three of which are networked-to-all-players and
one of which (raw client-side `Instantiate`) is not. Ability VFX in the shipping characters use the
**predicted + reconciled entity event-buffer** path, not Mirror's per-particle `NetworkServer.Spawn`.

| # | Mechanism | Networked to all? | Used for |
|---|-----------|-------------------|----------|
| 1 | `VfxSubroutine` → `CharEvents.AddPredictedVfxEvent` → `CharEvents.OnNetSerialize` → `VfxManager.SpawnVfx` | **Yes** (predicted on owner, authoritative-replicated by server) | The main ability cast/destroy/impact VFX |
| 2 | `LoopVfxSubroutine : NetworkedSimulationSubroutine` (its own `OnNetSerialize`/`OnNetDeserialize`) + `HitboxBase.RpcSpawnLoopVfx/RpcDestroyLoopVfx` | **Yes** | Channels, auras, persistent looping VFX |
| 3 | `[ClientRpc]` methods (`HitboxBase.RpcSpawnVfx`, `CharPassives.RpcSpawnVfx`, `EntityActivateVFXHit.RpcPlayHit*`, `EntitySpawner.RpcCreateSpawnVfx`, `TileCooldown.RpcPlayDespawnVfx`) | **Yes** | One-shot, server-authoritative, non-predicted VFX (on-hit, passive procs, spawn/despawn) |
| 4 | `VFXSpawn` MonoBehaviour riding on a Mirror-spawned `HitboxBase`/entity prefab | **Yes** (because the *carrier* prefab is `NetworkServer.Spawn`-ed on every client) | Cast/follow/destroy/impact VFX bolted onto a networked hitbox |
| — | Raw `Object.Instantiate(prefab)` on one client (the failed Medusa path) | **NO — local only** | (the bug) |

The **root cause** of "visuals/attacks were only local" is that `MedusaMod` spawned every VFX with a
plain client-side `Object.Instantiate` gated behind `CanSpawnClientFx()`, with all networking
components stripped (`DisableNativeVfxGameplay`). Nothing was ever placed into a `CharEvents` event
buffer, sent through a `[ClientRpc]`, net-serialized by a `LoopVfxSubroutine`, or carried by a
Mirror-spawned prefab — so no other client ever heard about it.

---

## 2. The core networked-VFX data model

### 2.1 `VfxEventData` — the wire payload

`…\BAPBAP\Network\EventData\VfxEventData.cs`

```csharp
public struct VfxEventData : IEquatable<VfxEventData>
{
    public int predTickNum;        // line 9  — prediction tick for reconciliation
    public int vfxId;              // line 11 — INDEX into VfxManager prefab registry (NOT an assetId)
    public VfxEventAction action;  // line 13 — Spawn | Destroy
    public VfxTarget target;       // line 15 — World | Base | Attached
    public Vector3 position;       // line 17
    public Quaternion rotation;    // line 19
    public float scale;            // line 21
    public byte attachableId;      // line 23 — which attach point on the char/entity
    public int instanceId;         // line 25 — identifies a specific live instance (for Destroy)
}
```

- `VfxEventAction` (`…\Network\EventData\VfxEventAction.cs:3`): `enum : byte { Spawn = 0, Destroy = 1 }`.
- `VfxTarget` (`…\Local\VfxTarget.cs`): `enum : byte { World = 0, Base = 1, Attached = 2 }` — i.e. spawn in
  world space, at the entity base, or parented to an attach point.

**Critical fact:** `vfxId` is an **int index**, not a Mirror `assetId` and not a name. It is resolved
to/from a concrete `GameObject` through the `VfxManager` prefab registry (see §2.3). For the same int to
mean the same prefab on every machine, the registry **must be identical on every client**. This is the
single most important constraint for adding custom VFX (see §6).

### 2.2 `CharEvents` — the per-entity networked event ring buffer

`…\BAPBAP\Entities\CharEvents.cs` — `public class CharEvents : NetworkBehaviour` (line 12)

Relevant members:

```csharp
public VfxManager vfxManager;                       // line 17
public List<VfxEventData> clVfxEventHistory;        // line 28  — client-side received/applied history
public List<VfxEventData> vfxEventsBuffer;          // line 46  — events queued this tick to serialize
public int clLastRecvPredTickNum;                   // line 43

public void AddPredictedVfxEvent(VfxEventData eventData, bool isResim);  // line 64
public void DiffWithVfxHistory(List<VfxEventData> newVfxEvents, int forcedPredTickNumHistory = -1); // line 92
public void ReconciliatePredicted(int svPredTickNum, int clPredTickNum); // line 76
public void Reconciliate();                          // line 81
public void OnNetSerialize(NetworkWriter netWriter); // line 104
public void OnNetDeserialize(NetworkReader netReader);// line 108
public void ClearBuffers();                          // line 112
```

Reconstructed flow (from names/types; bodies are stubbed):

1. **Owner/predicting client** calls `AddPredictedVfxEvent(eventData, isResim)` during ability
   simulation. The event is stored in `clVfxEventHistory` (for later reconcile) and, on the locally
   predicting machine, also applied immediately so the caster sees instant feedback.
2. **Server** records authoritative `VfxEventData` into `vfxEventsBuffer` and writes them out in
   `OnNetSerialize`. Because `CharEvents` is a `NetworkBehaviour`, this rides the entity's normal state
   snapshot to **every observer**.
3. **Remote clients** read them in `OnNetDeserialize`, then `DiffWithVfxHistory` compares the incoming
   authoritative list against `clVfxEventHistory`; new/unmatched events are applied (spawned) and
   mispredicted ones reconciled. `clLastRecvPredTickNum` / `predTickNum` drive the dedup so a predicted
   VFX on the owner is not double-spawned when the authoritative copy arrives.

The same `CharEvents` buffer pattern is mirrored for sound and animation, confirming it is the engine's
general "cosmetic event" replication channel, not VFX-specific:

```csharp
public List<SfxEventData>     clSfxEventHistory;       // line 31
public List<SfxFmodEventData> clSfxFmodEventHistory;   // line 34
public List<AnimEventData>    clAnimEventHistory;      // line 37
public List<WarpEventData>    clWarpEventHistory;      // line 40
public void AddPredictedSfxFmodEvent(...);  // line 67
public void AddPredictedAnimEvent(...);     // line 70
public void AddPredictedWarpEvent(...);     // line 73
```

> **Why this matters for the synthesis:** animations and VFX use the *same* replication channel
> (`CharEvents`). The failed mod's "E plays Kitsu's animation" and "VFX only local" symptoms are the
> **same class of bug** — neither animation events nor VFX events were ever pushed into `CharEvents`, so
> remote clients fell back to the base prefab's default state. Fixing VFX and fixing animations is one
> design problem: feed both through `CharEvents`/the subroutine event API. (Animation specifics belong to
> another stage; noted here only because it is the same channel.)

### 2.3 `VfxManager` — the prefab registry + client spawner

`…\BAPBAP\Local\VfxManager.cs` — `public class VfxManager : MonoBehaviour` (line 8)

```csharp
[Serializable] public class PrefabConfig { public GameObject prefab; public float destroyDelay; } // line 11
public PrefabConfig[] vfxPrefabConfigs;                       // line 22  — THE REGISTRY (authored in inspector)
public Dictionary<GameObject,int> vfxPrefabToId;              // line 25  — prefab -> id
public Dictionary<int,List<ActiveVfxData>> activeVfxDataByNetId; // line 28 — live instances keyed by owner netId

public static VfxManager Instance => null;                    // line 98 (singleton)

public int GetPredVfxId(GameObject prefab);                   // line 105  prefab -> vfxId
public GameObject GetPredVfx(int id);                         // line 110  vfxId -> prefab

public int  SpawnVfx(VfxEventData eventData, uint netId);     // line 122  *** the client-side applier ***
public void DestroyOldestVfx(VfxEventData eventData, uint netId); // line 127
public bool DestroyVfx(VfxEventData eventData, uint netId);   // line 131

public GameObject SpawnVfxInstance(GameObject vfxPrefab, Transform parent, Vector3 position, Quaternion rotation, float destroyDelay = 0f); // line 136
public GameObject SpawnVfxInstance(GameObject vfxPrefab, Vector3 position, Quaternion rotation, float destroyDelay = 0f);                    // line 141
public void DespawnVfxInstance(GameObject vfxPrefab, GameObject vfxInstance, float delay = 0f);                                              // line 145
```

Key deductions:

- `vfxPrefabConfigs` is the inspector-authored array of all VFX prefabs the engine can replay by id.
- `GetPredVfxId(prefab)` / `GetPredVfx(id)` are the two halves of the prefab↔int mapping. The producing
  side (ability) converts a prefab reference into an int via `GetPredVfxId`, packs it into `VfxEventData.vfxId`;
  the consuming side (every client) converts back with `GetPredVfx(id)` inside `SpawnVfx`.
- `SpawnVfx(VfxEventData, uint netId)` is what every client calls (driven by `CharEvents.DiffWithVfxHistory`)
  to actually `Instantiate` the resolved prefab at `eventData.position/rotation/scale`, attaching per
  `VfxTarget`, and tracks the instance in `activeVfxDataByNetId[netId]` so a later `Destroy` event
  (`DestroyVfx` / `DestroyOldestVfx`, matched via `instanceId`) can tear it down.
- `VfxManager` also holds the **shared global VFX prefabs** for non-ability cosmetics that the whole game
  needs (`healVFXPrefab`, `killedVFXPrefab`, `reviveVFXPrefab`, `downedVFXPrefab`, `teleportVfx`,
  `cementedVfxPrefab`, `vfxThornsPrefab`, `wallImpactVfxPrefab`, etc. — lines 56–96) plus shared materials
  (`frozenMaterial`, `petrifyMaterial`, `spiritformMaterial`, lines 33–44).

---

## 3. How an ability emits a VFX event (the primary path)

### 3.1 `VfxSubroutine` — the generic emitter

`…\BAPBAP\Entities\VfxSubroutine.cs` — `public class VfxSubroutine : SimulationSubroutine` (line 9)

```csharp
public Ability ability;            // line 12
public VfxTarget vfxTarget;        // line 15
public VfxEventAction vfxAction;   // line 18
public int vfxId;                  // line 21
public Vector3 position;           // line 24
public Quaternion rotation;        // line 27
public float scale;                // line 30
public byte attachableId;          // line 33

// Two constructors: one takes a resolved vfxId, one takes a GameObject prefab (resolved internally
// via VfxManager.GetPredVfxId):
public VfxSubroutine(Ability ability, VfxEventAction vfxAction, VfxTarget vfxTarget, int vfxId,
                     Vector3 position, Quaternion rotation, float scale = 1f, byte attachableId = 0); // line 35
public VfxSubroutine(Ability ability, VfxEventAction vfxAction, VfxTarget vfxTarget, GameObject vfxPrefab,
                     Vector3 position, Quaternion rotation, float scale = 1f, byte attachableId = 0); // line 39

public override void OnEnter(float fixedDt, Command cmd, bool isResim);  // line 43
```

`VfxSubroutine` extends `SimulationSubroutine` (`…\Network\SimulationSubroutine.cs`):

```csharp
public class SimulationSubroutine
{
    public virtual void OnEnter(float fixedDt, Command cmd, bool isResim);
    public virtual byte OnTick(float fixedDt, Command cmd, bool isResim);
    public virtual void OnExit(float fixedDt, Command cmd, bool isResim);
    public virtual void DeBuild();
}
```

Reconstructed behavior of `VfxSubroutine.OnEnter`: build a `VfxEventData { vfxId, action, target,
position, rotation, scale, attachableId }` and call `ability.<entity>.charEvents.AddPredictedVfxEvent(data, isResim)`.
The `cmd`/`predTickNum`/`isResim` arguments are exactly the data needed to stamp `VfxEventData.predTickNum`
and to suppress duplicate spawns during resimulation — which is why these are method params. This is the
deterministic-simulation way every shipping ability emits its cast/impact VFX.

### 3.2 Real ability examples (per-ability `CustomVfxSubroutine`)

Many abilities define a nested `CustomVfxSubroutine` with the same shape. Example —
`…\BAPBAP\Entities\KatanaMeleeAbility.cs`:

```csharp
public class CustomVfxSubroutine : SimulationSubroutine    // line 34
{
    public KatanaMeleeAbility ability;     // line 37
    public VfxTarget vfxTarget;            // line 40
    public VfxEventAction vfxAction;       // line 44
    public int vfxId;                      // line 47
    public int vfxFireId;                  // line 50  (a second VFX id for the fire-augment variant)
    public Vector3 position;               // line 53
    public Quaternion rotation;            // line 56
    public byte attachableId;              // line 59
    public CustomVfxSubroutine(KatanaMeleeAbility ability, VfxEventAction vfxAction, VfxTarget vfxTarget,
        GameObject vfxPrefab, GameObject vfxFirePrefab, Vector3 position, Quaternion rotation, byte attachableId = 0); // line 61
    public override void OnEnter(float fixedDt, Command cmd, bool isResim);  // line 68
}
```

KatanaMeleeAbility also exposes the **inspector-authored prefab fields** that feed those subroutines:
`vfxCast1Prefab`, `vfxCast2Prefab`, `vfxCast3Prefab`, `vfxCast3FirePrefab` (lines ~ "VFX" header), and the
augment set `vfxCast3AugPrefab`, `vfxCast3AugFirePrefab`. The constructor takes the *prefab*, and the
subroutine internally resolves it to a `vfxId` via the registry. The same nested `CustomVfxSubroutine`
pattern appears in `AssassinMeleeAbility.cs:34`, `JiroJumpKickAbility.cs:70`, and the `CustomCastVfxSubroutine`
in every NPC ability (`NpcDashAttackAbility.cs:13`, `NpcExplodeAbility.cs:12`, `MechDashAttackAbility.cs:13`,
`BossChadSequenceAbility.cs:51`, etc.). This is the **uniform engine convention** for one-shot ability VFX.

### 3.3 Loop / persistent VFX

`…\BAPBAP\Entities\LoopVfxSubroutine.cs` — `public class LoopVfxSubroutine : NetworkedSimulationSubroutine` (line 10)

```csharp
public EntityManager entityManager;        // line 13
public VFXStopParticles vfxStopParticles;  // line 16
public GameObject loopVfxInstance;         // line 19
public bool isActive;                      // line 22
public GameObject VfxInstance => null;     // line 24

public LoopVfxSubroutine(Ability ability, GameObject loopVfxPrefab, Transform attachTransform);        // line 26
public LoopVfxSubroutine(EntityManager entityManager, GameObject loopVfxPrefab, Transform attachTransform); // line 30

public virtual void SpawnVfx(GameObject vfxPrefab, Transform parent);  // line 38
public virtual void DestroyVfx();          // line 42
public override void OnEnter(...);  public override void OnExit(...);   // line 46/50
public void Stop(); public void SetIsActive(bool); public virtual void OnActiveChanged(); // line 54/58/62

// *** It is its own networked subroutine — it serializes its active/instance state to all clients ***
public override void OnNetDeserialize(NetworkReader netReader); // line 66
public override void OnNetSerialize(NetworkWriter netWriter);   // line 70
public override bool OnNetDebugCompare(NetworkReader netReader);// line 74
public override void OnNetDebugLog(StringBuilder sb);           // line 78
```

`NetworkedSimulationSubroutine` (`…\Network\NetworkedSimulationSubroutine.cs`) extends `SimulationSubroutine`
and adds the four `OnNet*` serialization hooks. So a `LoopVfxSubroutine` is a **stateful, server-replicated**
subroutine: the server serializes `isActive` (and instance bookkeeping) and remote clients
`SpawnVfx`/`DestroyVfx` accordingly. Subclasses are everywhere: `P_LoopVfxSubroutine.cs:7`,
`P_LoopVfxOrbitSubroutine.cs:10`, `SpriestSnareAbility.CustomLoopVfxSubroutine` (line 28),
`P_BloodDive.CustomLoopVfxSubroutine` (line 191), `SpriestExpungeAbility.CustomLoopVfxSubroutine` (line 14),
`NpcWormTunnelAbility.CustomLoopVfxSubroutine` (line 13).

A complementary RPC path for loops lives directly on the hitbox (see §4): `HitboxBase.RpcSpawnLoopVfx` /
`RpcDestroyLoopVfx`.

---

## 4. `[ClientRpc]`-driven VFX (server → all clients, non-predicted)

These are plain Mirror `[ClientRpc]` methods (server calls, runs on every client). The Mirror weave
artifacts (`UserCode_*` + `InvokeUserCode_*` + `Weaved()`) are present, confirming they are real RPCs.

`…\BAPBAP\Entities\HitboxBase.cs` — `public class HitboxBase : NetworkBehaviour, IPoolDespawnListener` (line 12):

```csharp
public VFXSpawn vfxSpawn;                                       // line ~20 (NonSerialized)
[ClientRpc] public void RpcSpawnVfx(int passiveId, int vfxId, VfxTarget vfxTarget);     // line ~118
[ClientRpc] public void RpcSpawnLoopVfx(int passiveId, int vfxId, VfxTarget vfxTarget); // (next)
[ClientRpc] public void RpcDestroyLoopVfx(int passiveId, int id);                       // (next)
[ClientRpc] public void RpcPlaySfx(AudioManager.SFX sfxId); ... RpcCustomEvent(byte eventId, int passiveId);
public void OnNetSerialize(NetworkWriter netWriter); public void OnNetDeserialize(NetworkReader netReader);
```

Note again the RPC carries a **`vfxId` int**, not a prefab — resolved on each client through the registry.

`…\BAPBAP\Entities\CharPassives.cs`:

```csharp
[ClientRpc] public void RpcSpawnVfx(int passiveId, int vfxId, VfxTarget vfxTarget);  // line 388
public void UserCode_RpcSpawnVfx__Int32__Int32__VfxTarget(int passiveId, int vfxId, VfxTarget vfxTarget); // line 454
public static void InvokeUserCode_RpcSpawnVfx__Int32__Int32__VfxTarget(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection); // line 458
```

`…\BAPBAP\Entities\Passive.cs` (the client-side spawn helper used by passives):

```csharp
public GameObject ClSpawnVfxObj(int vfxId, Transform transform, float destroyDelay = 0f);  // line 379
public void ClDestroyLoopVfxObj(int id);                                                    // line ~372
```

`…\BAPBAP\Entities\EntityActivateVFXHit.cs` — `public class EntityActivateVFXHit : EntityActivateBase` (line 7):

```csharp
public GameObject onHitVfxPrefab;          // line 11
public bool onHitVfxSpawnInWorld;          // line 14
public bool playVfxInsteadOfSpawn;         // line 21 (Play() one persistent obj instead of Instantiate per hit)
public override void Activate();           // line ...
[ClientRpc] public void RpcPlayHit(int teamId);                          // line ~33
[ClientRpc] public void RpcPlayHitExternal(Vector3 position, int teamId);// line ~37
```

Other `[ClientRpc]` cosmetic VFX: `EntitySpawner.RpcCreateSpawnVfx()` (`EntitySpawner.cs:110`, with
`spawnVfxPrefab` field line 40) and `TileCooldown.RpcPlayDespawnVfx()` (`TileCooldown.cs:153`). There are
also dedicated networked tether VFX behaviours: `VFXTetherAreaSpawn : NetworkBehaviour`
(`…\Entities\VFXTetherAreaSpawn.cs:10`) and `VFXTetherImpactPlay : NetworkBehaviour`
(`…\Entities\VFXTetherImpactPlay.cs:7`).

**When the engine uses RPC vs the event buffer (inference):** the `CharEvents` event-buffer path (§3) is
used for VFX that the *casting client predicts* and that must reconcile against rollback (cast/swing
VFX tied to ability simulation). `[ClientRpc]` is used for VFX that originate purely server-side and need
no client prediction — on-hit reactions, passive procs, entity spawn/despawn, tile cooldowns. Both end up
visible on **every** client; they differ only in prediction/authority, not in reach.

---

## 5. `VFXSpawn` riding on a Mirror-spawned carrier prefab (path 4)

`…\BAPBAP\Local\VFXSpawn.cs` — `public class VFXSpawn : MonoBehaviour` (line 11)

```csharp
public HitboxBase hitbox;          // line 91 (NonSerialized) — back-reference to the carrying hitbox
public bool applyTransformScale; public float vfxScale; public float startDelay;     // settings
public GameObject VFXCastPrefab;    public float VFXCastDestroyDelay;     // "Cast Vfx" — on hitbox start
public GameObject VFXFollowPrefab;  public float VFXFollowDestroyDelay; public Transform customFollowParent; // follows hitbox as child
public GameObject VFXDestroyPrefab; public float VFXDestroyDelayDestroy; // on hitbox destroy
public GameObject VFXImpactPrefab;  public float VFXImpactDestroyDelay;  // on enemy/collision impact
public int teamId; public bool isAlly;

public void Spawn();                                   // line ~158
public void DoDestroy(bool doDestroyVFX, Vector3 destroyPos);  // line ~167
public void SpawnImpactVFX(Vector3 impactPosition);    // line ~170
public void SpawnVFX(GameObject vfxPrefab, Vector3 pos, float delayDestroy = 1f, bool setParent = false); // line 173
public void SpawnVFXFollow(); public void RestartVFXFollow(); public void DestroyVFXFollow(bool immediate = false);
```

`VFXSpawn` is a **plain MonoBehaviour with no networking of its own**. It is referenced from
`HitboxBase.vfxSpawn` (`HitboxBase.cs`, `public VFXSpawn vfxSpawn;`). The reason its VFX is seen by all
players is **not** that `VFXSpawn` replicates anything — it is that the **hitbox prefab carrying it is a
`NetworkBehaviour` spawned via Mirror on every client**. `HitboxBase : NetworkBehaviour` (line 12), and
abilities spawn it server-side through the spawn-hitbox subroutines (`AB_SpawnHitbox_Base`,
`AB_SpawnHitbox_Base_SO`, `P_CharAugment_SpawnHitbox.SpawnHitbox(...)` at `P_CharAugment_SpawnHitbox.cs:47`).
When Mirror instantiates that registered prefab on each client, the prefab's `VFXSpawn`/`Start`/`Spawn`
runs locally on each of them → identical visuals everywhere, with no extra event/RPC needed.

`AB_SpawnHitbox_Base.Config` (`…\Entities\AB_SpawnHitbox_Base.cs:10`) holds the `GameObject hitboxPrefab`,
damage, ttl, status effects, hit filters, etc. The hitbox prefab is what bundles mesh + `VFXSpawn` +
`HitboxBase` together. This is the cleanest "server-authoritative, networked, no custom event code"
route and is exactly what the existing custom-char attempt tried to imitate but did **client-side only**.

---

## 6. Which visuals every player sees vs only the local client

**Seen by ALL players** (any of):

1. VFX emitted via `VfxSubroutine`/`CustomVfxSubroutine` → `CharEvents.AddPredictedVfxEvent` → serialized by
   `CharEvents.OnNetSerialize` → applied by remote `VfxManager.SpawnVfx`. (Predicted instantly on the
   caster; authoritatively on everyone.)
2. VFX driven by a `[ClientRpc]` (`HitboxBase.RpcSpawnVfx/RpcSpawnLoopVfx`, `CharPassives.RpcSpawnVfx`,
   `EntityActivateVFXHit.RpcPlayHit*`, `EntitySpawner.RpcCreateSpawnVfx`, `TileCooldown.RpcPlayDespawnVfx`).
3. VFX state carried by a `LoopVfxSubroutine` (its own `OnNetSerialize`/`OnNetDeserialize`).
4. VFX carried by a Mirror-spawned prefab (`HitboxBase` + `VFXSpawn`, `VFXTetherAreaSpawn`,
   `VFXTetherImpactPlay`) that was `NetworkServer.Spawn`-ed; each client runs the prefab's `VFXSpawn` locally.

In all four, the **`vfxId` int must resolve to the same prefab on every client** (paths 1–3 send only the
int; path 4 sends the prefab itself through Mirror's spawnable-prefab registry / `assetId`).

**Seen by ONLY the local client** (the bug class):

- Any direct `Object.Instantiate(prefab)` performed on a single client without a corresponding event/RPC/
  networked carrier. This is precisely what `MedusaMod` does.

### 6.1 Direct evidence of the failed (local-only) approach

`MedusaMod.cs` `SpawnNativeMedusaVfx(...)` (around line 3796):

```csharp
GameObject val = ResolveNativeMedusaVfxPrefab(prefabName);
...
GameObject val2 = Object.Instantiate<GameObject>(val);          // ~line 3824  — PLAIN, LOCAL instantiate
((Object)val2).name = "MedusaFX_Native_" + prefabName;
val2.transform.position = position; ...
DisableNativeVfxGameplay(val2);                                 // strips NetworkIdentity/Mirror/colliders
val2.SetActive(true);
Object.Destroy((Object)val2, ttl);
```

`SpawnNativeMedusaHitbox(...)` (around line 3873) is documented in its own comment as
**"CLIENT-SIDE PRESENTATION only"** and re-gates on `CanSpawnClientFx()`:

```csharp
// Spawns a REAL bundled Hitbox_Medusa* ability prefab as CLIENT-SIDE PRESENTATION only.
// ... The instantiated copy is fully neutralized (NetworkIdentity/Mirror, HitboxDps, ProjectileMove,
//     ColliderEnable, VFXSpawn, NetworkTransformFollow, ... disabled), so it renders ... but runs no
//     gameplay or networking. ... Thus the dedicated match-host is never affected.
if (!CanSpawnClientFx()) return false;          // ~line 3877 — server/headless never spawns
...
GameObject val2 = Object.Instantiate<GameObject>(val);  // ~line 3897 — again local only
DisableNativeVfxGameplay(val2);                          // deliberately removes VFXSpawn + NetworkIdentity
```

**Consequences (each a reported symptom):**

- The VFX/hitbox is `Instantiate`d on the *casting* client only — no `CharEvents` event, no `[ClientRpc]`,
  no Mirror spawn → **invisible to other players** ("visuals/attacks were only local").
- `DisableNativeVfxGameplay` strips the very `VFXSpawn` component (path 4) and `NetworkIdentity` that would
  otherwise have made it replicate — so even the natural carrier-prefab route is destroyed.
- The headless dedicated host (`-batchmode -nographics`) is hard-gated out (`CanSpawnClientFx()` false), so
  the server has no authoritative VFX/hitbox at all and cannot broadcast anything.
- Because nothing went into the prediction/reconcile pipeline, the cosmetic object is `Object.Destroy`-ed
  after a fixed `ttl` with no server confirmation — consistent with the "despawns / frozen poses
  (Standbilder)" reports: the local clone has no networked driver to keep it alive or animated.

The Medusa data model (`CustomCharFramework.cs`) reinforces that the whole approach is a **client-side
graft**: it clones Kitsu's prefab (`BaseCharId = 0` / `BaseCharName = "Kitsu"`), registers a custom Mirror
`MirrorAssetId = 1296385109` for the *visual* root, and lists bundle hitbox prefab names
(`AbilityHitboxes = ["Hitbox_MedusaPoisonProjectile", ...]`) that it then instantiates locally rather than
spawning through the server. There is no use of `VfxManager.vfxPrefabConfigs`, `GetPredVfxId`,
`AddPredictedVfxEvent`, `VfxSubroutine`, or any `[ClientRpc]` — i.e. **none of the four real replication
mechanisms is engaged for VFX.**

---

## 7. How to make a custom ability's VFX visible to all players

Three viable designs, in order of fidelity to the engine. **All three share one mandatory prerequisite:**
the custom VFX prefab must be resolvable to the same identifier on every client.

### Prerequisite — register custom VFX in the prefab registry (for id-based paths 1–3)

`VfxManager.vfxPrefabConfigs` is the int→prefab table consumed by `GetPredVfx(id)` /
`VfxManager.SpawnVfx(eventData,…)`. To use any int-`vfxId` path, append your custom prefabs into
`VfxManager.Instance.vfxPrefabConfigs` (and rebuild `vfxPrefabToId`) **at load time on every client, in a
deterministic order so the int ids match across machines.** If ids can drift between clients, a `vfxId`
will resolve to a different (or null) prefab remotely — the classic "green dot only" / wrong-VFX symptom.
Safest deterministic scheme: assign custom ids in a reserved high range derived from a stable key (e.g.
hash of prefab name), identical in the mod on host and all clients.

### Option A — Event-buffer VFX (preferred; matches every shipping ability)

1. Register custom prefab(s) in `VfxManager.vfxPrefabConfigs` (prerequisite).
2. In the custom ability's simulation, add a `VfxSubroutine` (or a nested `CustomVfxSubroutine`) and, in
   `OnEnter`, build `VfxEventData{ vfxId, action = Spawn, target, position, rotation, scale, attachableId }`
   and call `charEvents.AddPredictedVfxEvent(data, isResim)` — exactly as `KatanaMeleeAbility.CustomVfxSubroutine`
   does. Use the `GameObject`-taking `VfxSubroutine` constructor (`VfxSubroutine.cs:39`) so it resolves the id
   for you via `GetPredVfxId`.
3. The server's `CharEvents.OnNetSerialize` replicates it; remote clients apply it through
   `DiffWithVfxHistory` → `VfxManager.SpawnVfx`. To remove, emit a second event with
   `action = Destroy` and the same `instanceId`.

This gives owner-side prediction (instant feedback, correct under rollback) **and** all-client visibility
with no extra networking code. It is the only path that behaves identically to native abilities.

### Option B — Networked carrier prefab (simplest server-authoritative)

1. Author the VFX as a child of a hitbox/entity prefab that has `HitboxBase`(+`VFXSpawn`) or is otherwise a
   `NetworkBehaviour`.
2. Register that prefab as a Mirror **spawnable prefab** (give it a stable `assetId`, add it to the
   `NetworkManager` spawnable list) on host and all clients.
3. Spawn it **server-side** via the existing spawn-hitbox subroutine / `NetworkServer.Spawn`
   (`AB_SpawnHitbox_Base`, `P_CharAugment_SpawnHitbox.SpawnHitbox`). Mirror instantiates it on every client
   and the prefab's own `VFXSpawn` plays everywhere.

This is what the failed mod *tried* to look like — the fix is to **spawn it through the server and keep its
`NetworkIdentity`/`VFXSpawn` intact** instead of `Object.Instantiate`-ing a neutralized client-only copy.

### Option C — `[ClientRpc]` one-shot (non-predicted procs / on-hit)

1. Register custom prefab in the registry (prerequisite).
2. Add a `[ClientRpc]` on a `NetworkBehaviour` attached to the char/hitbox (mirroring
   `CharPassives.RpcSpawnVfx(passiveId, vfxId, vfxTarget)` / `HitboxBase.RpcSpawnVfx`) and call it from
   server authority. Every client resolves `vfxId` and spawns the VFX (via `Passive.ClSpawnVfxObj` or
   `VfxManager.SpawnVfxInstance`).

Use for server-decided VFX that need no client prediction (on-hit bursts, passive triggers). For looping
RPC VFX, pair `RpcSpawnLoopVfx` with `RpcDestroyLoopVfx` (id-matched), like `HitboxBase`.

### Anti-patterns to avoid (each caused a reported bug)

- ❌ `Object.Instantiate` of a VFX/hitbox on one client with no event/RPC/Mirror-spawn → local-only,
  despawns, frozen.
- ❌ Stripping `NetworkIdentity`/`VFXSpawn` ("DisableNativeVfxGameplay") off a prefab you then expect others
  to see.
- ❌ Sending a `vfxId` whose registry index is not identical on every client → null/wrong VFX (the "green
  dot"/wrong-prefab class).
- ❌ Doing any of this only when `CanSpawnClientFx()` is true → the authoritative headless host never drives
  the VFX, so nothing is broadcast.

---

## 8. Quick file:line index for the synthesis stage

| Symbol | File:line | Role |
|---|---|---|
| `VfxEventData` (struct, vfxId/action/target/instanceId) | `Network\EventData\VfxEventData.cs:7` | Wire payload |
| `VfxEventAction { Spawn, Destroy }` | `Network\EventData\VfxEventAction.cs:3` | Action enum |
| `VfxTarget { World, Base, Attached }` | `Local\VfxTarget.cs:1` | Attach mode enum |
| `CharEvents : NetworkBehaviour` | `Entities\CharEvents.cs:12` | Per-entity networked event buffer |
| `CharEvents.AddPredictedVfxEvent` | `Entities\CharEvents.cs:64` | Emit (predicted) |
| `CharEvents.DiffWithVfxHistory` | `Entities\CharEvents.cs:92` | Apply/reconcile on clients |
| `CharEvents.OnNetSerialize/Deserialize` | `Entities\CharEvents.cs:104/108` | Replication |
| `VfxManager.vfxPrefabConfigs` | `Local\VfxManager.cs:22` | int→prefab REGISTRY |
| `VfxManager.GetPredVfxId / GetPredVfx` | `Local\VfxManager.cs:105/110` | prefab↔id mapping |
| `VfxManager.SpawnVfx(VfxEventData,netId)` | `Local\VfxManager.cs:122` | Client-side applier |
| `VfxManager.DestroyVfx / DestroyOldestVfx` | `Local\VfxManager.cs:131/127` | Teardown by instanceId |
| `VfxSubroutine : SimulationSubroutine` | `Entities\VfxSubroutine.cs:9` | Generic ability VFX emitter |
| `LoopVfxSubroutine : NetworkedSimulationSubroutine` | `Entities\LoopVfxSubroutine.cs:10` | Networked loop VFX |
| `SimulationSubroutine` (OnEnter/OnTick/OnExit) | `Network\SimulationSubroutine.cs:5` | Subroutine base |
| `NetworkedSimulationSubroutine` (OnNet*) | `Network\NetworkedSimulationSubroutine.cs:5` | Net subroutine base |
| `KatanaMeleeAbility.CustomVfxSubroutine` | `Entities\KatanaMeleeAbility.cs:34` | Real example emitter |
| `HitboxBase : NetworkBehaviour`, `vfxSpawn` | `Entities\HitboxBase.cs:12` | Networked carrier |
| `HitboxBase.RpcSpawnVfx/RpcSpawnLoopVfx/RpcDestroyLoopVfx` | `Entities\HitboxBase.cs (~118+)` | RPC VFX |
| `CharPassives.RpcSpawnVfx` | `Entities\CharPassives.cs:388` | Passive proc RPC VFX |
| `Passive.ClSpawnVfxObj(int vfxId,…)` | `Entities\Passive.cs:379` | Client spawn helper |
| `VFXSpawn : MonoBehaviour` (Cast/Follow/Destroy/Impact) | `Local\VFXSpawn.cs:11` | Hitbox-attached cosmetics |
| `EntityActivateVFXHit.RpcPlayHit*` | `Entities\EntityActivateVFXHit.cs:7` | On-hit RPC VFX |
| `EntitySpawner.RpcCreateSpawnVfx` | `Entities\EntitySpawner.cs:110` | Entity spawn VFX |
| `AB_SpawnHitbox_Base.Config.hitboxPrefab` | `Entities\AB_SpawnHitbox_Base.cs:10` | Networked hitbox spawn |
| `VFXTetherAreaSpawn / VFXTetherImpactPlay : NetworkBehaviour` | `Entities\VFXTetherAreaSpawn.cs:10`, `VFXTetherImpactPlay.cs:7` | Networked tether VFX |
| **FAILED** `MedusaMod.SpawnNativeMedusaVfx` (local Instantiate) | `MedusaMod.cs:~3796/3824` | Root-cause bug |
| **FAILED** `MedusaMod.SpawnNativeMedusaHitbox` ("presentation-only") | `MedusaMod.cs:~3873/3897` | Root-cause bug |
| `CustomCharDefinition` (clone-of-Kitsu, no VFX registry use) | `CustomCharFramework.cs:13` | Failed data model |

---

## 9. Bottom line for the from-scratch design

- **VFX in BAPBAP is replicated, not local.** The engine never relies on each client independently
  instantiating ability VFX from raw prefabs. It replicates a compact `VfxEventData{ vfxId, action,
  target, pos, rot, scale, instanceId }` either through the per-entity `CharEvents` predicted-event buffer
  (cast/impact, with client prediction + server reconciliation) or through `[ClientRpc]`/`LoopVfxSubroutine`
  (server-authoritative), and resolves `vfxId` against the **shared** `VfxManager.vfxPrefabConfigs` registry.
  Prefab-carried VFX (`VFXSpawn` on a `HitboxBase`) replicate only because the carrier is Mirror-spawned.
- **A correct custom-ability VFX system must therefore:** (1) register custom VFX prefabs deterministically
  into `VfxManager.vfxPrefabConfigs` on every client; (2) emit VFX through `VfxSubroutine` /
  `AddPredictedVfxEvent` (or a `[ClientRpc]`/`LoopVfxSubroutine`, or a server-`NetworkServer.Spawn`-ed
  carrier prefab) from **server/simulation authority** — never via a bare client-side `Object.Instantiate`;
  and (3) keep `NetworkIdentity`/`VFXSpawn` intact on any prefab whose visuals must be seen by others.
- **The failed approach broke every one of those rules**, which is the direct and sufficient explanation
  for "VFX only local / despawns / frozen / wrong (green-dot) visuals."

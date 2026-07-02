# R05 — Ability Execution Flow & Authority (BAPBAP)

Stage R05 of the "networked custom characters + custom abilities" research. This
document traces, from **real decompiled C# source**, how an ability goes from
**input → command → cast lifecycle → behaviour → spawned hitbox/projectile**, and
determines the **authority model** (server-authoritative vs client-predicted),
**how spawned effects replicate to all players**, the **LMB / RMB / Space / E / Q
slot mapping**, and **why the previous clone-based graft mis-fires** (only LMB works,
RMB shows a green dot, Space bugs out, E plays Kitsu's animation).

All file paths below are under:
`C:\Users\Administrator\Downloads\neueBapbap\GameCode\ExportedProject\_DisabledScripts\Assembly-CSharp\BAPBAP\`
unless noted. The decompilation is **header-only** (IL2CPP method bodies are
stripped to stubs), so flow is reconstructed from **type hierarchy, fields,
attributes (`[Server]`, `[ClientRpc]`, `[SyncVar]`), interfaces, and serialized
inspector fields** — these are intact and authoritative.

---

## 0. TL;DR (for the synthesis stage)

- **Authority = BOTH.** Ability execution is a **deterministic tick simulation that
  is server-authoritative AND client-predicted with rollback/reconciliation.** Each
  ability is a `Mirror.NetworkBehaviour` implementing a fixed-tick `Tick(fixedDt,
  Command cmd, bool isResim)`; the client predicts locally and re-simulates
  (`isResim=true`) when the server state snapshot disagrees.
- **An ability is a `NetworkBehaviour` component on the character prefab**
  (`Ability : NetworkBehaviour`, `Entities/Ability.cs`) carrying a `CommandId cmdId`
  that binds it to one input slot. The character's predicted components are collected
  as `INetworkPredicted[] netComps` and ticked by `CharSimulation`
  (`Entities/CharSimulation.cs`), driven by `CharNetwork` (`Entities/CharNetwork.cs`).
- **Spawned effects replicate the normal Mirror way:** the cast behaviour
  (`AB_SpawnHitbox_Base.DoUse()`) instantiates a **`hitboxPrefab` that is itself a
  `NetworkBehaviour` (`HitboxBase`/`Hitbox`) with `[SyncVar]`s**, spawned on the
  **server** and observed by everyone; hit resolution is `[Server]`/`[ServerCallback]`
  only; visual impact/destroy is pushed to clients via `[ClientRpc]`.
- **Slot mapping** (from `CommandId` enum + `Ability.cmdId` tooltip + the failed
  mod's own key reader): `Ability1=LMB`, `Ability2=RMB` (tooltip says "Q" — stale),
  `Ability3=Space`, `Ability4=E`, plus `AbilityHeal`/extra slots. **Q is a secondary
  bind for Ability2** in the mod's fallback reader.
- **Why the clone mis-fires:** the clone duplicates **Kitsu's** `Ability`
  NetworkBehaviours (their `cmdId`, prefabs, animator triggers, FSM). The mod never
  adds new per-slot `Ability` components; instead it bolts a **Harmony side-driver**
  that applies damage by hand (`charHurtbox.ApplyHit`) **server-side only, outside the
  predicted simulation, with no networked spawned entity**, and spawns **neutered,
  local-only** FX/hitbox copies on render clients. Net effect: only the one
  cleanly-inherited real ability (LMB) fires correctly; the others fall back to
  primitives / inherited Kitsu behaviour / un-predicted movement.

---

## 1. The simulation backbone (how a tick is driven)

### 1.1 Input snapshot — `Command`
`Local/Command.cs`:

```csharp
[Serializable] public class Command {
    public int predTickNum;          // tick this command belongs to (prediction id)
    public float smoothedPing;
    public int keyDowns;             // bitmask indexed by CommandId
    public int keyHolds;             // bitmask indexed by CommandId
    public int keyUps;               // bitmask indexed by CommandId
    public Vector3 directionals;     // movement
    public Vector3 worldMousePos;    // aim point
    public byte inputSource;
    public bool doRandom;            // gates deterministic RNG for this tick
    public bool quickCastAbilities;
    public bool GetKeyDown(int cmdId); public void SetKeyDown(int cmdId); ...
}
```

A `Command` is the **per-tick input packet**. Buttons are stored as **bitmasks
indexed by `CommandId`** (`GetKeyDown(cmdId)` etc.). This is the classic
deterministic-netcode "command" object: the client builds one each fixed tick, runs
the simulation with it locally (prediction), and sends it to the server which runs
the **same** simulation authoritatively.

### 1.2 Command construction — `InputManager`
`Local/InputManager.cs`:
- `Command ConsumeCommand(Command pooledCmd, int tickNum, float smoothedPing, bool doRandom)` — builds the tick command.
- `void ConsumeButtons(Command cmd)` / `void ConsumeCursor(Command cmd)` — fill the key bitmasks + `worldMousePos`.
- `void PopulateCommand(CommandId cmdId)` and `static InputTarget GetInputTargetByAbilityCmd(CommandId cmdId)` — bridge **physical key (`InputTarget`) → logical `CommandId`**.
- Config fields confirm a **fixed-tick simulation shared by client and server**:
  `float simHz` ("Simulation tick rate for both client and server"),
  `float serverUpdateHz`, `float entityLerpMultiplier` ("how many ticks behind
  remote entities lerp"), `float maxPingPredRecon` ("Max ping to reconciliate
  predicted entities"), `int maxTicksPredRecon`, and a test toggle
  `bool doServerSimDesync` ("random desyncs on the server? For testing
  reconciliation/rollback only"). The presence of an explicit rollback test switch
  proves the netcode is **predict + reconcile**.

### 1.3 The predicted simulation — `CharSimulation` + `INetworkPredicted`
`Network/INetworkPredicted.cs`:

```csharp
public interface INetworkPredicted {
    void OnTick(float fixedDt, Command cmd, bool isResim);
    void OnNetSerialize(NetworkWriter netWriter);     // predicted-state snapshot out
    void OnNetDeserialize(NetworkReader netReader);   // server state in
    bool OnNetDebugCompare(NetworkReader netReader);  // desync compare
    void OnNetDebugLog(StringBuilder sb);
}
```

`Entities/CharSimulation.cs`:

```csharp
public class CharSimulation : MonoBehaviour {
    public INetworkPredicted[] netComps;          // all predicted comps on the char
    public List<IPhysicsResimulated> physResimStay;
    public Command currentCmd;
    public int predTickNum;
    public void Tick(float fixedDt, Command cmd, bool isResim = false);
    public void PhysSimulation(float fixedDt);
    public void OnNetSerialize(NetworkWriter netWriter);
    public void OnNetDeserialize(NetworkReader netReader, int remoteTickNum);
    public bool OnNetDebugCompare(byte[] state);
}
```

`CharSimulation.Tick` fans out to **every `INetworkPredicted` on the character**
(movement, abilities, status effects, aim, …) for one fixed step, with `isResim`
distinguishing first-time simulation from a **re-simulation during reconciliation**.
`PhysSimulation` + `IPhysicsResimulated` means even physics is rolled back/replayed.

### 1.4 The network driver — `CharNetwork`
`Entities/CharNetwork.cs` (a `NetworkBehaviour`):

- `bool isPredicted` ("Allow prediction to run on this entity (only if locally owned)").
- `bool predictionPhysicsResim`.
- Client path: `ClTick()`, `DoClientSidePrediction()`,
  `ReconciliatePredicted(int svPredTickNum, ArraySegment<byte> svState)`,
  `Reconciliate(...)`, plus `clLatestProcessedSvPredTickNum` /
  `clLatestReceivedSvPredTickNum` and a `ClientDeltaCompressor`.
- Server path: `SvTick()`, `ManagedSvUpdate(stateWriters, eventWriters)` (per-connection
  state + event writers), `ServerDeltaCompressor`, `svShouldDoNetStateSync`.

This is the canonical loop:
1. Client samples input → `Command` (1.1/1.2).
2. **Client** runs `CharSimulation.Tick(cmd, isResim:false)` immediately (prediction).
3. **Server** runs `CharSimulation.Tick(cmd, isResim:false)` authoritatively in
   `SvTick`, then serializes authoritative state via `ManagedSvUpdate`.
4. Client receives the snapshot, `ReconciliatePredicted` rewinds to the acked tick,
   loads server state via `OnNetDeserialize`, and **re-simulates forward**
   (`isResim:true`) over the buffered commands.

**Conclusion:** ability execution is **server-authoritative with client-side
prediction and rollback reconciliation** — not one or the other, both.

---

## 2. The ability object model

### 2.1 `Ability : NetworkBehaviour` — `Entities/Ability.cs`
Key serialized inspector fields (intact in the decompile):

```csharp
public class Ability : NetworkBehaviour {
    [Tooltip("Which command will this ability be casted with? (LMB = Ability1,
              Q = Ability2, Space = Ability3, E = Ability4)")]
    public CommandId cmdId;                 // <-- binds ability to an input slot

    public bool useCustomUIData;
    public UICharactersConfiguration.CharacterConfiguration.AbilityData customUIData;

    // Mechanics
    public bool autoCancel;                 // can auto-cancel other casts
    public int priority;                    // input-buffer priority (Low=1 .. High=4)
    public float inputBufferDuration;       // default 250ms
    public float canceledTime;
    public bool silenceable;
    public bool cancelable;
    public bool usableOnDowned;
    public bool enableCritDmg;
    public float maxTimeDilation;           // server may dilate cast time (default 200ms)

    // Wired components / FSM
    public SimulationFsm fsm;
    public AbilityStates state;
    public CastSubroutine castSubroutine;
    public CooldownSubroutine cooldownSubroutine, startCdSubroutine;
    public bool isInputBuffered; public float inputBufferTimeLeft; public byte useLocks;
    ...
}
```

Lifecycle / authority methods:

```csharp
public virtual void Tick(float fixedDt, Command cmd, bool isResim);  // predicted tick
public void SetState(AbilityStates _state);
public void SvOnAbilityTriggered();
public void FireExternalCast();  public void FireExternalInterrupt();
public virtual void ForceInterrupt();

[Server] public virtual void OnTargetHit(EntityManager otherEntityManager, HitboxBase hitboxBase);
[Server] public virtual void OnTargetKill(EntityManager otherEntityManager);
[Server] public virtual void OnWallHit(GameObject hboxObj);
[Server] public virtual void OnOtherHitboxHit(Hitbox otherHitbox, HitboxBase hitboxBase);
[Server] public virtual void OnHitboxDestroy(HitboxBase hitboxBase);

public bool IsCriticalDamage(int predTickNum, int nonce = 0);  // deterministic crit
// predicted-state serialization (Ability implements the predicted contract):
public virtual void OnNetSerialize(NetworkWriter netWriter);
public virtual void OnNetDeserialize(NetworkReader netReader);
public virtual bool OnNetDebugCompare(NetworkReader netReader);
```

Takeaways:
- **Every ability is a networked component**; abilities live on the character prefab,
  one component per ability, each tagged with a `cmdId` slot.
- **Hit/kill/wall resolution callbacks are all `[Server]`** → damage and kills are
  decided on the server only.
- `IsCriticalDamage(predTickNum, nonce)` derives crits from the **tick number**, so
  client prediction and the server agree deterministically (no per-side RNG drift).
- The ability participates in the **predicted-state snapshot** via its own
  `OnNetSerialize/Deserialize/DebugCompare`, so its cast progress reconciles.

### 2.2 `CharAbilities : NetworkBehaviour, INetworkPredicted` — `Entities/CharAbilities.cs`
The per-character ability **manager / aggregator**. Notable members:

```csharp
public class CharAbilities : NetworkBehaviour, INetworkPredicted {
    public const int CONSTANT_ITEM_OFFSET = 4;
    public Ability[] abilities;                 // all ability components, by slot
    public Ability[] abilitiesByPriority;       // input-buffer ordering
    public Ability[] abilitiesWithAutoCancel;
    public CastFlags castFlags;                 // which ability is currently casting
    public byte silenceLocks, animLocks, abilityHiddenLocks, forceFullbodyAnimLocks;

    public void OnTick(float fixedDt, Command cmd, bool isResim);   // INetworkPredicted
    public void SetCastAbility(CastFlags castFlag);
    public void ResetCastAbility(CastFlags castFlag);
    public bool IsCasting();
    public void SortAbilitiesByPriority();      // input buffering
    public void OnAbilityCast(CommandId cmdId);
    public void SvOnAbilityTriggered(CommandId cmdId);
    public bool IsCriticalDamage(int predTickNum, int nonce = 0);
    public int GetModifiedDamage(int sourceDmg, float damageScaling = 1f, bool isCrit = false);

    [ClientRpc] public void RpcCastResult(bool isSuccess);
    [ClientRpc] public void RpcAbilityReady(int cmdId);
    [ClientRpc] public void RpcResetText();
    [ClientRpc] public void RpcTriggerBushReveal();
    // INetworkPredicted serialization:
    public void OnNetSerialize(NetworkWriter); public void OnNetDeserialize(NetworkReader); ...
}
```

- `CharAbilities.OnTick(...)` is the predicted entry point that dispatches input to
  the right `Ability` (via `abilitiesByPriority` for input buffering, honoring
  `priority` and `inputBufferDuration` from §2.1).
- **`castFlags` (a `CastFlags` bitmask) tracks which ability is currently casting**,
  used for mutual exclusion. `SetCastAbility`/`ResetCastAbility` set/clear bits.
- **`SvOnAbilityTriggered(CommandId)` is the server-side confirmation** that an
  ability fired for that slot; `RpcCastResult`/`RpcAbilityReady` push success/cooldown
  back to the owning client (UI). Damage scaling/crit go through
  `GetModifiedDamage`/`IsCriticalDamage`.

### 2.3 `CastFlags` and slot encoding
`Entities/CastFlags.cs`:

```csharp
[Flags] public enum CastFlags {
    None = 0, Ability1 = 1, Ability2 = 2, Ability3 = 4, Ability4 = 8,
    Ability5 = 0x10, Ability6 = 0x20, Ability7 = 0x40, Ability8 = 0x7C
}
```

`Entities/CastFlagsHelper.cs`:

```csharp
public static CastFlags GetCastFlagByAbility(CommandId cmdId);
public static bool IsAnyActive(CastFlags flags, CastFlags flagMask);
public const CastFlags castFlagsAllNoConsumable =
    Ability1 | Ability2 | Ability3 | Ability4;
```

So a slot's `CommandId` maps to a `CastFlags` bit, and `castFlags` on `CharAbilities`
is the "currently casting" set. `GetCastFlagByAbility` is the canonical mapping used
internally (the failed mod re-implements this same `slot→bit` mapping by hand — see §6).

---

## 3. The cast lifecycle (input → cast → behaviour → spawn)

### 3.1 States — `Entities/AbilityStates.cs`

```csharp
public enum AbilityStates : byte {
    Ready = 0, Aiming = 1, Casting = 2, Active = 3, Cooldown = 4, Disabled = 5
}
```

A typical flow per ability:
`Ready → (Aiming) → Casting → Active → Cooldown → Ready`.

### 3.2 The deterministic FSM — `Network/SimulationFsm.cs` + subroutines
`SimulationFsm` is a **builder-defined, tickable state machine** whose states own
**networked subroutines**:

```csharp
public class SimulationFsm {
    public class Builder { Builder State(byte); Builder AddSubroutine(SimulationSubroutine);
                           Builder AddTransition(byte trigger, byte state); Builder Start(byte); SimulationFsm Build(); }
    public List<NetworkedSimulationSubroutine> networkedSubroutines;
    public byte currentState; public byte externalTrigger;
    public void Tick(float fixedDt, Command cmd, bool isResim);
    public void Fire(byte trigger, Command cmd, bool isResim);
    public void FireExternal(byte trigger); public void FireExternalImmediate(byte trigger);
    public void ChangeState(byte stateId);
    public void OnNetSerialize/OnNetDeserialize/OnNetDebugCompare(...);   // reconciled
}
```

`Network/SimulationSubroutine.cs`:

```csharp
public class SimulationSubroutine {
    public virtual void OnEnter(float fixedDt, Command cmd, bool isResim);
    public virtual byte OnTick(float fixedDt, Command cmd, bool isResim);  // returns a trigger
    public virtual void OnExit(float fixedDt, Command cmd, bool isResim);
}
```

`Network/NetworkedSimulationSubroutine.cs` adds `OnNetSerialize/Deserialize/DebugCompare`
so subroutine state is **part of the predicted snapshot** (reconciles like everything else).

### 3.3 The cast subroutine — `Entities/CastSubroutine.cs`

```csharp
public class CastSubroutine : NetworkedSimulationSubroutine {
    public Ability ability;
    public byte finishTrigger, silenceTrigger, cancelTrigger;
    public bool applyAtkSpeedMultiplier, doTimeDilation, isUlt, isSuccess;
    public CastFlags castFlag;
    public float timeElapsed, castingTime;
    public CastSubroutine(Ability ability, byte finishTrigger, byte silenceTrigger,
                          byte cancelTrigger, float castingTime,
                          bool applyAtkSpeedMultiplier, bool doTimeDilation);
    public override void OnEnter(float, Command, bool);
    public override byte OnTick(float, Command, bool);    // counts up to castingTime, fires finishTrigger
    public override void OnExit(float, Command, bool);
    public float GetAdjustedCastingTime();                // attack-speed + time dilation
    public void SetCastTime(float ct);
}
```

The cast is a **timed subroutine**: it enters when the slot's key is pressed, counts
`timeElapsed` to `GetAdjustedCastingTime()` (attack-speed scaled, server may dilate via
`Ability.maxTimeDilation`), then returns `finishTrigger` to advance the FSM into the
behaviour/active phase. Because it is a `NetworkedSimulationSubroutine`, the cast
**progress reconciles** — the client predicts the cast bar, the server is the truth.

### 3.4 The behaviour layer — `AbilityBehaviour` / `AbilityBehaviourSO`
`Entities/AbilityBehaviour.cs`:

```csharp
public class AbilityBehaviour {
    public class AbilityBehaviourConfig : InlineAttribute {
        public InputType inputType; public bool silenceable, cancelable, usableWhileDowned;
    }
    public Ability ability; public SimulationFsm fsm;
    public virtual void Build(Ability ability, int itemId);
    public virtual void Tick(float fixedDt, Command cmd, bool isResim);
    public virtual void OnStart();      // <-- effect fires here
    public virtual void OnDeactivate();
    public virtual void OnTargetHit(EntityManager otherCharManager, HitboxBase hitbox);
    public virtual void OnHitboxDestroy(HitboxBase hitboxBase);
    public virtual void ClSpawnVisibleIndicator(Vector3 worldPos);   // local aim UI
    // predicted serialization too
}
```

`Entities/AbilityBehaviourSO.cs` is a `ScriptableObject` factory:
`AbilityBehaviour NewInstance(EntityManager)` + `AbilityBehaviour.AbilityBehaviourConfig config`.
So an ability's *effect* is data-driven: an SO is authored in the editor, instantiated
into a runtime `AbilityBehaviour` that owns its own FSM and reacts to ticks.

### 3.5 The spawn step — `Entities/AB_SpawnHitbox_Base.cs`

```csharp
public class AB_SpawnHitbox_Base : AB_Use_Base {
    public new class Config : AB_Use_Base.Config {
        public GameObject hitboxPrefab;          // <-- networked hitbox/projectile prefab
        public float hitboxRadius; public int damage; public float damageScaling;
        public List<StatusEffectInfo> statusEffects; public float ttl;
        public bool hitboxDirectional, destroyOnCharHit,
                    allowHitToEnemies, allowHitToTeam, damageAllowedToOwnerPlayer,
                    destroyOnStaticCollision, counterable, stayOnOwnerDestroyed;
    }
    public new Config config;
    public override void DoUse();                // spawns config.hitboxPrefab
    public override void OnTargetHit(EntityManager otherEntityManager, HitboxBase hitboxBase);
}
```

`DoUse()` is the concrete spawn point: it instantiates `config.hitboxPrefab`
(a networked `HitboxBase`) with the configured `damage`, `statusEffects`, `ttl`, team
allow-flags, etc. Sibling SO bases follow the same pattern:
`AB_SpawnEntity_Base_SO`, `AB_SpawnEntityOnPos_Base_SO`, `AB_SpawnHitbox_Base_SO`
(`NewInstance(EntityManager)` → behaviour).

A concrete code-driven example, `Entities/ArrowAbility.cs` (a projectile LMB-type
ability):

```csharp
public class ArrowAbility : Ability {
    public GameObject spellPrefab;     // the networked projectile/hitbox prefab
    public Transform firingPoint; public float spread, speed, ttl;
    public int damage; public float damageScaling;
    public List<StatusEffectInfo> statusEffects;
    public float castingTime, recoveryTime, baseCooldownTime;
    public class CustomShootSubroutine : SimulationSubroutine { ... }  // fires Shoot in OnEnter
    public void Shoot(Vector3 spawnPosition, Vector3 lookDir, int predTickNum);  // <-- spawn
}
```

`Shoot(spawnPos, lookDir, predTickNum)` taking a `predTickNum` confirms the spawn
happens **inside the deterministic predicted tick**, keyed to the prediction tick id.

### 3.6 End-to-end trace

```
[client] InputManager.ConsumeButtons → Command.keyDowns bit for cmdId (e.g. Ability1)
   → CharNetwork.ClTick → CharSimulation.Tick(cmd, isResim:false)
        → CharAbilities.OnTick  (reads cmd via abilitiesByPriority, input-buffer, locks)
            → Ability.Tick → SimulationFsm.Tick
                 Ready → (Aiming) → CastSubroutine (Casting): counts castingTime
                 → finishTrigger → Active: AbilityBehaviour.OnStart / AB_SpawnHitbox_Base.DoUse()
                      → instantiate hitboxPrefab (HitboxBase NetworkBehaviour)
                 → Cooldown (CooldownSubroutine) → Ready
   client does all of the above PREDICTIVELY for the locally-owned char.

[server] CharNetwork.SvTick → CharSimulation.Tick(cmd, isResim:false)  (same code path)
   → on Active, server NetworkServer.Spawn(hitbox) so ALL observers get it
   → Hitbox [Server]/[ServerCallback] collision resolves damage (charHurtbox.ApplyHit)
   → CharAbilities.SvOnAbilityTriggered(cmdId); RpcCastResult / RpcAbilityReady to owner
   → ManagedSvUpdate serializes authoritative predicted state to each client.

[client reconcile] CharNetwork.ReconciliatePredicted(svTick, svState)
   → CharSimulation.OnNetDeserialize → re-Tick(isResim:true) forward over buffered cmds.
```

---

## 4. How a spawned effect (hitbox/projectile) replicates to ALL players

The hitbox/projectile prefab is itself a Mirror networked object.
`Entities/HitboxBase.cs`:

```csharp
public class HitboxBase : NetworkBehaviour, IPoolDespawnListener {
    [SyncVar] public int ownerPlayerId;     // replicated to all observers
    [SyncVar] public int teamId;            // replicated to all observers
    public ProjectileMove projMove; public VFXSpawn vfxSpawn; public AudioPlayFmod audioPlayFmod;
    public int damage; public bool isCriticalDamage; public List<StatusEffectInfo> _statusEffects;
    public List<PassiveSO> _passives; public Ability ability;
    public bool allowHitToEnemies, allowHitToTeam, allowHitToOwnerPlayer, ...;

    [Server] public void DestroyHitbox(bool spawnDestroyVFX = true, Vector3 destroyPos = default, float destroyDelay = 0f);
    [Server] public void TryPlayImpact(EntityManager otherEntity);
    public void OnHitSuccess(EntityManager otherEntityManager);   // server hit bookkeeping
    public void OnHitKill(EntityManager otherEntityManager);

    [ClientRpc] public void RpcOnHitboxImpact(Vector3 impactPosition);          // visual only
    [ClientRpc] public void RpcDestroyHitbox(bool spawnDestroyVFX, Vector3 destroyPos);
    [ClientRpc] public void RpcDestroyHitboxAtPosition(bool spawnDestroyVFX, Vector3 destroyPos);

    public override void SerializeSyncVars(NetworkWriter, bool forceAll);  // Mirror weaver
    public override void DeserializeSyncVars(NetworkReader, bool initialState);
}
```

`Entities/Hitbox.cs : HitboxBase`:

```csharp
public class Hitbox : HitboxBase {
    [SyncVar] public float elapsedTime;                 // replicated lifetime
    [ServerCallback] public void OnTriggerEnter(Collider collider);   // SERVER-only collision
    [Server] public void DoObstacleHit(Collider collider);
    [Server] public void DoEntityHit(EntityHit entityHit);
    [Server] public void OnHitboxImpact();
    [ClientRpc] public void RpcRestartFollowVfx();
}
```

How this guarantees **everyone sees it** and **only the server decides damage**:

1. **Spawn:** the ability behaviour spawns `hitboxPrefab` on the **server**; because
   it is a `NetworkBehaviour`/`NetworkIdentity`, Mirror replicates it to all observing
   clients (the project uses **pooled network spawns** — `IPoolDespawnListener` and
   the `BAPBAP.Pooling.NetworkPrefabPool`/`NetworkPrefabLibrary` referenced by the mod
   — i.e. `NetworkServer.Spawn` via a pool). All players instantiate the same prefab
   with the same `[SyncVar]` `ownerPlayerId`/`teamId`/`elapsedTime`.
2. **Movement:** `ProjectileMove` (+ `ProjectileInterpolatedMove`/`ProjectileMoveDirection`)
   moves the hitbox; remote clients interpolate (see `entityLerpMultiplier`, §1.2).
3. **Hit resolution:** `Hitbox.OnTriggerEnter` is **`[ServerCallback]`** and
   `DoEntityHit`/`DoObstacleHit`/`OnHitboxImpact` are **`[Server]`** → only the server
   evaluates collisions and applies damage/status (via the victim's `CharHurtbox`).
   Clients never deal damage; they only render.
4. **Feedback:** impact and destruction visuals are pushed to every client via
   `[ClientRpc] RpcOnHitboxImpact` / `RpcDestroyHitbox*` / `RpcRestartFollowVfx`.

This is the **correct, fully-networked pattern a custom ability MUST follow**: spawn a
real networked hitbox prefab on the server; let Mirror replicate it; do damage in
`[Server]` callbacks; do cosmetics in `[ClientRpc]`.

---

## 5. Input → slot mapping (LMB / RMB / Space / E / Q)

### 5.1 Logical command ids — `Local/CommandId.cs`

```csharp
public enum CommandId {
    Ability1 = 0, Ability2 = 1, Ability3 = 2, Ability4 = 3,
    Ability5 = 4, Ability6 = 5, Ability7 = 6, Ability8 = 7,
    CancelAbility = 8, AbilityHeal = 9,
    Drop1 = 10, ... Interact = 19, VehicleDrift = 20, VehicleTurbo = 21
}
```

### 5.2 Physical bind targets — `Local/InputTarget.cs`

```csharp
public enum InputTarget {
    MoveUp=0, MoveDown=1, MoveLeft=2, MoveRight=3,
    Ability1=4, Ability2=5, Ability3=6, Ability4=7, Ability5=8,
    CancelAbility=9, AbilityHeal=10, ... Ability6=25, Ability7=27, Ability8=32, ...
}
```

`InputManager.GetInputTargetByAbilityCmd(CommandId)` maps `CommandId.AbilityN` →
`InputTarget.AbilityN`; `InputMap`/`InputBinding` (`Local/InputMap.cs`,
`Local/InputBinding.cs`) hold the rebindable `KeyCode keybind` per `InputTarget`.

### 5.3 Authoritative slot table

| Ability slot | `CommandId` | `CastFlags` bit | Default key | Evidence |
|---|---|---|---|---|
| 1 | `Ability1=0` | `Ability1=1` | **LMB** | `Ability.cmdId` tooltip; mod key reader |
| 2 | `Ability2=1` | `Ability2=2` | **RMB** (tooltip text says "Q") | mod key reader; tooltip |
| 3 | `Ability3=2` | `Ability3=4` | **Space** | `Ability.cmdId` tooltip; mod key reader |
| 4 | `Ability4=3` | `Ability4=8` | **E** (ult) | `Ability.cmdId` tooltip; mod key reader |
| heal | `AbilityHeal=9` | — | (heal key) | `CommandId`, `CharAbilities` |
| Q | secondary bind for slot 2 | — | **Q** | mod `PollLocalInputCastFx` |

**Note on the LMB/RMB/Space/E vs the tooltip:** the `Ability.cs` tooltip literally
reads *"LMB = Ability1, Q = Ability2, Space = Ability3, E = Ability4"*. But the failed
mod's own input reader (`MedusaMod.PollLocalInputCastFx`,
`C:\Users\Administrator\Downloads\BAPBAPModdingAPI\bapcustomchars-mod\MedusaMod.cs`)
maps:

```csharp
if (Input.GetMouseButtonDown(0) || GetKeyDown(Alpha1))            num = 0; // LMB  -> slot 0
else if (Input.GetMouseButtonDown(1) || GetKeyDown(Q) || Alpha2)  num = 1; // RMB/Q-> slot 1
else if (GetKeyDown(Space) || GetKeyDown(F) || Alpha3)            num = 2; // Space-> slot 2
else if (GetKeyDown(E) || GetKeyDown(R) || Alpha4)                num = 3; // E    -> slot 3
```

So in practice the four player ability slots are **LMB / RMB / Space / E**, with **Q
acting as an alternate bind for slot 2 (Ability2)**. The tooltip's "Q" is stale text;
the `CommandId`/`InputTarget` ordinal mapping (slot N ↔ AbilityN) is what matters and
is consistent with the user's reported LMB/RMB/Space/E layout.

---

## 6. Why the clone-based graft mis-fires (root cause per symptom)

Source: `C:\Users\Administrator\Downloads\BAPBAPModdingAPI\bapcustomchars-mod\MedusaMod.cs`
and `...\CustomCharFramework.cs`.

### 6.1 What the failed framework actually does
- **Medusa is a clone of Kitsu** (`CustomCharDefinition`: `BaseCharId=0`,
  `BaseCharName="Kitsu"`). `RegisterPrefab` does `Object.Instantiate` of Kitsu's
  character prefab, renames it `Char_Medusa`, re-stamps the Mirror `assetId`
  (`MedusaMirrorAssetId = 0x4D454455`), `SanitizeMirrorIdentities` (zeroes `sceneId`,
  `_netId`, `hasSpawned`…), and registers it in `NetworkManager.spawnPrefabs` +
  `NetworkPrefabPool`/`NetworkPrefabLibrary`.
- **The abilities are still Kitsu's** `Ability` NetworkBehaviours
  (`CatShotAbility`, `CatMissileAbility`, `CatPolymorphAbility`, `CatJumpAbility`,
  `ArrowAbility`, `ChargedArrowsAbility`, …). The mod **does not add new per-slot
  `Ability` components** and does not change their `cmdId`/FSM/prefabs.
- Instead it bolts on a **Harmony side-driver**:
  - `CharAbilities.SetCastAbility` postfix → `TryRunMedusaAbilityDriverFromCastFlag`
    decodes the `CastFlags` bit to a slot (re-implementing `GetCastFlagByAbility`:
    `0→1, 1→2, 2→4, 3→8`) and calls `RunAuthoredMedusaAbilityDriver`.
  - `Ability.SetState` postfix → on transition into `Casting`/`Active`
    (`IsMedusaCastStartState`) also calls the driver.
  - The driver `ApplyAuthoredMedusaGameplay` (server only, gated by
    `IsAuthoritativeServer = isServer`) **hand-rolls target finding**
    (`FindObjectsOfType<EntityManager>()` + manual cone/box/dot tests in
    `FindMedusaAbilityTargets`) and applies damage **directly** via
    `charHurtbox.ApplyHit(...)`. **No networked hitbox entity is ever spawned.**
  - On render clients it spawns **presentation-only** copies
    (`SpawnNativeMedusaHitbox`/`SpawnMedusaCastFx`) that are **fully neutered**:
    `DisableNativeVfxGameplay` disables every component whose type name contains
    "Network/Hitbox/Damage/Projectile/Ability/Dps/Spawner/Collider/Follow/Expand/…",
    silences audio, and disables all colliders. These are **local-only `Instantiate`d
    meshes** (`Object.Instantiate`, never `NetworkServer.Spawn`), destroyed on a timer.
  - `CanSpawnClientFx()` returns false on the headless server (batch/null GFX), so the
    server spawns **nothing visual at all**; clients spawn only local FX.
  - The base Kitsu `Shoot` is intercepted: on a render client
    `TrySuppressInheritedKitsuShoot` returns false (lets Kitsu's real spawn run); on
    the headless server it suppresses it and runs the hand-rolled driver
    (`SuppressInheritedKitsuAbilityVfx` even nulls `spellPrefab`/`vfxCastPrefab`).

### 6.2 Why this produces exactly the observed symptoms

- **"Custom char not visible to other players; visuals/attacks only local."**
  Because real ability hitboxes/projectiles are **never `NetworkServer.Spawn`ed**.
  Damage is applied by a server-side `ApplyHit` loop with no networked entity, and all
  visuals are **local `Instantiate`** copies with `NetworkIdentity` stripped. Remote
  clients have nothing to replicate. The correct path (§4) — spawn a networked
  `HitboxBase` prefab on the server — is bypassed entirely.

- **"It despawns / frozen poses (Standbilder)."**
  The clone's `NetworkIdentity` is re-stamped/sanitized at runtime and registered
  late; Mirror spawn of a hand-cloned identity is fragile and gets torn down. The
  visual is a bundle model grafted on with `CharAnimator.animator` re-pointed
  (`CharAnimatorRebindPatch`), but the real animation parameters are driven by the
  predicted simulation/animator the graft no longer matches → the mesh isn't ticked by
  the authoritative anim state and **freezes**. The mod's own comments describe fighting
  repeated re-anchor/rebind passes that "froze the pose (Standbilder)".

- **"Only LMB works."**
  Slot 0 (`Ability1`/LMB) inherits Kitsu's **clean, fully-wired real ability**
  (`CatShotAbility`/`ArrowAbility`) whose FSM + `Shoot` + networked `spellPrefab`
  spawn and replicate normally — and on render clients the mod deliberately lets that
  base `Shoot` run. So **only the slot whose inherited ability is left intact fires a
  real networked attack.**

- **"RMB shows just a green dot."**
  Slot 1 (`Ability2`/RMB): the inherited ability's `spellPrefab`/`vfxCastPrefab` is
  **nulled** by `SuppressInheritedKitsuAbilityVfx` (server path) and/or the
  presentation-only hitbox fails to resolve, so the only thing rendered is the mod's
  **green primitive/VFX fallback** (`MedusaColor` ≈ green; `SpawnMedusaOrb`/stripped
  VFX). No real projectile spawns → a lone green dot, locally.

- **"Space bugs out."**
  Slot 2 (`Ability3`/Space): `ApplyMedusaSlitherMovement` calls
  `caster.charMove.PostMove(dir*4.25f, ...)` **directly from a Harmony callback,
  outside the predicted `CharSimulation.Tick`**. Movement applied outside the
  prediction/reconciliation loop is immediately overwritten/contested by the next
  server snapshot → rubber-banding / desync ("bugs out").

- **"E plays the base char Kitsu's animation."**
  Slot 3 (`Ability4`/E, the ult): the clone still has **Kitsu's inherited `Ability4`
  component with Kitsu's animator triggers/FSM**. Pressing E runs Kitsu's real ability,
  which drives **Kitsu's animation**. The mod's `PlayMedusaAbilityAnimation`
  `CrossFade("Ability4")` is a cosmetic afterthought that can't override the inherited
  ability's own animation events.

### 6.3 The structural lesson for a correct integration
A correct custom ability is **not** a Harmony side-driver. It must be a real
`Ability : NetworkBehaviour` component (or a data-driven `AbilityBehaviourSO`) placed
on the character prefab with:
1. a unique `cmdId` per slot,
2. a `SimulationFsm` (`CastSubroutine` + behaviour + `CooldownSubroutine`),
3. participation in `CharSimulation`'s `INetworkPredicted[]` so it is **predicted +
   reconciled** (implement `Tick`/`OnNetSerialize`/`OnNetDeserialize`/`OnNetDebugCompare`),
4. a **networked `HitboxBase` prefab** spawned on the **server**
   (`NetworkServer.Spawn` / the pool) so all players see it,
5. damage/hits only in `[Server]`/`[ServerCallback]`, cosmetics only in `[ClientRpc]`,
6. deterministic crit via `IsCriticalDamage(predTickNum, nonce)`.

Anything that applies damage with `FindObjectsOfType` + `ApplyHit` from a Harmony hook,
or that renders effects with plain `Object.Instantiate`, will always be local-only,
un-predicted, and invisible to other players — exactly the failure observed.

---

## 7. Authority verdict (explicit answer)

- **Is ability execution server-authoritative, client-predicted, or both?**
  **Both.** The same deterministic `Tick(fixedDt, Command, isResim)` runs on the
  owning client (prediction) and on the server (authority). The server is the source
  of truth: it confirms casts (`SvOnAbilityTriggered`, `RpcCastResult`), spawns the
  networked hitbox, and resolves all damage in `[Server]`/`[ServerCallback]` code.
  The client predicts cast bars, movement and spawned-effect motion, then **rolls back
  and re-simulates** (`isResim=true`) against the server snapshot
  (`CharNetwork.ReconciliatePredicted` + the `INetworkPredicted`
  `OnNetSerialize/OnNetDeserialize/OnNetDebugCompare` contract).

- **How does a spawned hitbox/projectile replicate so everyone sees it?**
  It is a `HitboxBase : NetworkBehaviour` prefab with `[SyncVar]`s
  (`ownerPlayerId`, `teamId`, `elapsedTime`), spawned on the **server** through Mirror
  (pooled `NetworkServer.Spawn`). Mirror replicates it to all observers; movement is
  interpolated on remotes; collisions/damage happen only in the server callbacks; and
  impact/destroy visuals are broadcast with `[ClientRpc]`.

---

## 8. Key file index (evidence)

| Concern | File |
|---|---|
| Ability component + slot `cmdId` + `[Server]` hit callbacks | `Entities/Ability.cs` |
| Per-char ability manager, `castFlags`, predicted `OnTick`, RPCs | `Entities/CharAbilities.cs` |
| Cast-flag bit layout | `Entities/CastFlags.cs`, `Entities/CastFlagsHelper.cs` |
| Ability lifecycle states | `Entities/AbilityStates.cs` |
| Timed cast subroutine | `Entities/CastSubroutine.cs` |
| Deterministic FSM + subroutines | `Network/SimulationFsm.cs`, `Network/SimulationSubroutine.cs`, `Network/NetworkedSimulationSubroutine.cs` |
| Behaviour layer + SO factory | `Entities/AbilityBehaviour.cs`, `Entities/AbilityBehaviourSO.cs` |
| Concrete spawn behaviour (hitbox) | `Entities/AB_SpawnHitbox_Base.cs` (+ `_SO`) |
| Concrete projectile ability | `Entities/ArrowAbility.cs` |
| Networked hitbox/projectile | `Entities/HitboxBase.cs`, `Entities/Hitbox.cs`, `Entities/ProjectileMove.cs` |
| Predicted-sim driver | `Entities/CharSimulation.cs`, `Entities/CharNetwork.cs`, `Network/INetworkPredicted.cs`, `Network/INetworkSimulated.cs` |
| Input → command | `Local/Command.cs`, `Local/CommandId.cs`, `Local/InputTarget.cs`, `Local/InputBinding.cs`, `Local/InputMap.cs`, `Local/InputManager.cs`, `Local/InputSystem.cs` |
| Character component graph | `Entities/EntityManager.cs` |
| Failed clone framework | `BAPBAPModdingAPI\bapcustomchars-mod\MedusaMod.cs`, `...\CustomCharFramework.cs` |

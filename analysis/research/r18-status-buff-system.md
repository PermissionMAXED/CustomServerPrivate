# R18 — Status / Buff System (BAPBAP)

How status effects and buffs (poison, petrify, slow, stun, shield, bleed, etc.) are
**defined**, **applied on hit**, **ticked over time**, and **networked to all clients**,
and how a *new custom ability* can apply a **real, networked** status.

> **Source note.** All citations are to the decompiled game source under
> `C:\Users\Administrator\Downloads\neueBapbap\GameCode\ExportedProject\_DisabledScripts\Assembly-CSharp\BAPBAP\`.
> This export is **header/signature-only**: classes, fields, method signatures, attributes
> (`[Server]`, `[ClientRpc]`, `[TargetRpc]`, `[SyncVar]`, `[SerializeField]`), base types and
> nested types are all real and intact, but **method bodies are stubbed** (empty/`return null`).
> Where I state behaviour I derive it from signatures + attributes + field names + the SO/asset
> wiring, and I flag anything that is inference rather than a directly-readable body.

---

## 0. TL;DR for the synthesis stage

- A status effect is **three coupled types**:
  1. `StatusEffect` (runtime instance, the live behaviour) — `Entities\StatusEffect.cs:6`
  2. `StatusEffect.StatusEffectConfiguration` (data/tuning, a nested `[Serializable]`) — `Entities\StatusEffect.cs:9`
  3. `StatusEffectSO : ScriptableObject` (the authoring asset + factory) — `Entities\StatusEffectSO.cs`
- Each concrete effect is a pair `SE_Xxx : StatusEffect` + `SE_Xxx_SO : StatusEffectSO`
  (e.g. `SE_Poisoned`/`SE_Poisoned_SO`, `SE_Petrified`, `SE_Stunned`, `SE_Slowed`, `SE_Shield`, `SE_Frozen`, `SE_Burn`, …).
- All effect SOs are registered, **priority-ordered**, in a single
  `StatusEffectManager` (`Local\StatusEffectManager.cs`), whose array index **is** the effect `id`.
- The live state per character lives on `CharStatusEffects : NetworkBehaviour, INetworkPredicted`
  (`Entities\CharStatusEffects.cs:13`) in a `SortedList<StatusEffect> statusEffects`.
- **Application is server-authoritative**: only `[Server] CharStatusEffects.ActivateStatusEffect(...)`
  creates/refreshes an effect. Hits flow:
  `HitboxBase` (carries `List<StatusEffectInfo> _statusEffects`) → `CharHurtbox.ApplyHit(...)`
  → `CharHurtbox.ApplyStatusEffects(...)` → `CharStatusEffects.ActivateStatusEffect(...)`.
- **Ticking** happens inside the rollback-netcode simulation tick:
  `CharStatusEffects.OnTick(fixedDt, cmd, isResim)` calls each `StatusEffect.OnTick(fixedDt)`.
- **Networking is via the predicted-simulation snapshot**, *not* SyncVars:
  `CharStatusEffects.OnNetSerialize/OnNetDeserialize` (the `INetworkPredicted` contract)
  serialize the active set every tick; cosmetic/UI parts go out via `[ClientRpc]`/`[TargetRpc]`.
- **A custom ability adds a status the exact same way the shipped ones do**: put
  `StatusEffectInfo[]` (an SO + duration + multiplier) on the ability/hitbox, let the hitbox carry it,
  and let the **server** apply it. The previously-failed mod broke precisely because it applied
  things client-side and never went through the server snapshot.

---

## 1. The three core types

### 1.1 `StatusEffect` — runtime instance (`Entities\StatusEffect.cs`)

```csharp
public class StatusEffect : IComparable<StatusEffect>        // line 6
{
    [Serializable]
    public class StatusEffectConfiguration : InlineAttribute  // line 9  (the tunable data block)
    {
        // --- Configs ---
        public bool onlyOneInstance;   // only one instance; re-adds reinitialize the existing one
        public bool mergeIdentical;    // only one instance *of identical properties*
        // --- Properties ---
        public bool ignoreDuration;    // not deleted when duration hits 0
        public bool isCleanseable;     // can be removed by Cleanse()
        public bool isNonImmune;       // applies even to immune entities
        public bool isMovementDebuff;  // counts as a movement debuff (slow/root/etc.)
        // --- UI Config ---
        public string nameTranslationKey, nameAppliedTranslationKey, spriteId;
        public Color  color;
        // --- FX Config ---
        public GameObject vfxLoopPrefab;   // looping while-active VFX
        public GameObject vfxEndPrefab;    // one-shot on-expiry VFX
        public bool applyCharColor; public Color charColor;
        // runtime-only localized strings...
    }

    // Injected references resolved at Activate time:
    public EntityManager   entityManager;
    public CharStatusEffects charStatusEffects;
    public CharMaterial    charMaterial;   public CharFX charFx;
    public CharHurtbox     charHurtbox;    public EntityMovement charMove;
    public CharAbilities   charAbilities;  public CharTriggerbox charTriggerbox;
    public CharAim         charAim;

    public int    id;            // == index in StatusEffectManager.statusEffects
    public bool   active;
    public float  duration;      // counts down; expiry => Deactivate (unless ignoreDuration)
    public float  multiplier;    // strength scalar (slow rate, dmg mult, shield %, …)
    public int    otherPlayerId; // attributing player (for kill credit / poison dmg source)
    public Vector3 direction;    // hit direction (knock/push/airborne use this)

    public virtual StatusEffectConfiguration statusEffectConfig => null;

    public StatusEffect(EntityManager em) { }

    public virtual void OnTick(float fixedDt) { }   // per simulation tick (poison dmg, timers)
    public virtual void OnUpdate()            { }   // per render frame (visual only)
    public virtual void Activate(float _duration, float _multiplier, int _otherPlayerId, Vector3 _direction) { }
    public virtual void Deactivate() { }
    public virtual void Reactivate(float _duration, float _multiplier, int _otherPlayerId, Vector3 _direction) { }
    public virtual void ClStartAuth() { }           // client-side authoritative-start hook
    public virtual void ClStopAuth()  { }
    public virtual float   GetMultiplier() => 0f;
    public virtual Vector3 ApplyInputDirModification(Vector3 inputDir) => default; // confuse/fear remap input
    public int CompareTo(StatusEffect other) => 0;  // ordering => priority resolution
}
```

Key takeaways:
- The **lifecycle hooks** every effect overrides are `Activate` / `Reactivate` / `Deactivate` / `OnTick` / `OnUpdate`.
- `Activate` receives `(duration, multiplier, otherPlayerId, direction)` — the four
  pieces of per-application data. Everything else (tick damage, tick interval, max stacks, …)
  is *static config* on the SO.
- `ApplyInputDirModification` is how confuse/fear-type effects warp player input — they are
  consulted by movement (see `CharStatusEffects.ApplyInputDirModifications`, §3).
- `IComparable<StatusEffect>` + `CompareTo` → effects are kept in **priority order** so the
  game can resolve "which slow wins", "which movement-lock animation plays", etc.

### 1.2 `StatusEffectSO` — authoring asset + factory (`Entities\StatusEffectSO.cs`)

```csharp
[CreateAssetMenu(fileName = "StatusEffectSO", menuName = "BAPBAP/StatusEffects/StatusEffectSO")]
public class StatusEffectSO : ScriptableObject
{
    public int id;                                              // assigned from manager index
    public virtual StatusEffect.StatusEffectConfiguration config => null;
    public virtual StatusEffect NewInstance(EntityManager em) => null;  // FACTORY
}
```

Each concrete SO subclass holds a serialized typed `Config` and overrides `NewInstance`:

```csharp
// Entities\SE_Poisoned_SO.cs
public class SE_Poisoned_SO : StatusEffectSO
{
    [SerializeField] public SE_Poisoned.Config configuration;  // tuning authored in the asset
    public static  int Id;                                     // cached numeric id (static)
    public override StatusEffect.StatusEffectConfiguration config => null;       // returns configuration
    public override StatusEffect NewInstance(EntityManager em) => null;          // new SE_Poisoned(em, configuration)
}
// Entities\SE_Stunned_SO.cs — identical shape with SE_Stunned.Config + static int Id
```

> Note the `public static int Id;` on the `_SO` classes. The shipped code caches the numeric id
> of "well-known" effects in a static so engine code can refer to e.g. `SE_Poisoned_SO.Id`
> without a lookup. (Inference from the field; the assigning body is stubbed but the only
> sensible writer is the manager's `PreAwake`.)

### 1.3 Concrete effects = `SE_Xxx` + nested `Config : StatusEffectConfiguration`

`SE_Poisoned` is the richest example and shows the canonical "damage-over-time + scaling + sub-passives" shape:

```csharp
// Entities\SE_Poisoned.cs:6
public class SE_Poisoned : StatusEffect
{
    [Serializable] public class Config : StatusEffectConfiguration
    {
        public int   poisonedDamagePerTick;
        public float tickDuration;          // seconds between ticks
        public int   maxPoisonStacks;
        public float burstMultiplier; public int burstBaseDmg;   // explosion finisher
        public float slowDuration;    public float slowRate;     // poison also slows
        // sub-passives that augment the poison (damage / slow / duration / explosion / shield):
        public P_PoisonDmg_SO       P_PoisonDmg;
        public P_PoisonSlow_SO      P_PoisonSlow;
        public P_PoisonDuration_SO  P_PoisonDuration;
        public P_PoisonExplosion_SO P_PoisonExplosion;
        public P_PoisonShield_SO    P_PoisonShield;
    }
    public Config config;
    public int   poisonStacks;   public float hitTimer;   // runtime tick accumulator
    public EntityManager otherEntity; public bool applyShield; public float shieldPercent;

    public override void Activate(float _duration, float _multiplier, int _otherPlayerId, Vector3 _direction) { }
    public override void Deactivate() { }
    public void Trigger() { }            // applies one tick of poison damage / burst
    public override void OnTick(float dt) { }   // accumulates hitTimer; calls Trigger() each tickDuration
}
```

Other concrete effects show the full taxonomy of what a "status" can be (all in `Entities\SE_*.cs`):

| Effect | Class | Kind | Notes |
|---|---|---|---|
| Poison | `SE_Poisoned` | DoT + slow + stacks | tick damage via `OnTick`/`Trigger` |
| Burn / Bleed | `SE_Burn` (+ `P_Debuff_Bleed`) | DoT | |
| Petrify | `SE_Petrified` | hard CC (root/stone) | empty `Config` = pure config block |
| Stun | `SE_Stunned` | hard CC | `ClPlayStunAnim` on hurtbox (§4) |
| Frozen / EveFrozen | `SE_Frozen`, `SE_EveFrozen` | hard CC + freeze visual | overrides `Reactivate` too |
| Slow | `SE_Slowed` | movement debuff | `FindHighestStatusEffect`, `TryApplyHighest/TryRevertHighest` → only strongest slow applies |
| Root / Snare | `SE_Rooted`, `SE_FadingSnare` | movement debuff | |
| Knock / Push / Pull / Airborne | `SE_Knocked`,`SE_Pushed`,`SE_Pulled`,`SE_Airborne` | forced movement | use `direction` |
| Shield | `SE_Shield` | **buff** (temp HP) | `OnShieldHit`, `SetOldest`; managed by `CharStatusEffects` shield helpers (§3) |
| Amplify / Energize / Sprint / Gigantify | `SE_Amplify`,`SE_Energize`,`SE_Sprint`,`SE_Gigantify` | **buffs** | |
| Silence / Blind / NearSight / Confused / Fear / Sleep | … | soft CC / perception | `Confused`/`Fear` use `ApplyInputDirModification` |
| Invulnerable / ImmuneZone | `SE_Invulnerable`,`SE_ImmuneZone` | defensive buff | |

> **Important:** "buffs" and "debuffs" are the **same mechanism** — both are `StatusEffect`s
> (Shield, Amplify, Sprint are buffs; Poison, Stun, Slow are debuffs). There is also a second,
> *separate* "Passive/Augment" system (`Passive`, `Augment`, the `P_Buff_*` classes) which
> represents permanent/conditional character modifiers — that is **not** the timed status system
> and is out of scope here except where a Passive *applies* a StatusEffect (§5).

### 1.4 `StatusEffectInfo` — the "apply this effect" payload (`Entities\StatusEffectInfo.cs`)

This is the serializable tuple that abilities/hitboxes carry to say *what* to apply:

```csharp
[Serializable]
public class StatusEffectInfo
{
    public StatusEffectSO statusEffect;   // which effect
    public float duration;                // for how long
    public float multiplier;              // how strong
    public StatusEffectInfo(StatusEffectSO statusEffect, float duration, float multiplier) { }
    public StatusEffectInfo(int statusEffectId, float duration, float multiplier) { }  // by-id overload
}
```

`StatusEffectInfo` is what you author in the inspector on an ability and what is fed into a
hitbox; it is *not* the live instance. The live `StatusEffect` is produced by
`StatusEffectSO.NewInstance(em)` at application time.

---

## 2. The registry: `StatusEffectManager` (`Local\StatusEffectManager.cs`)

```csharp
public class StatusEffectManager : MonoBehaviour
{
    [Header("Status Effects by Priority")]
    [Expandable][SerializeField] public StatusEffectSO[] statusEffects;  // THE registry, order == id/priority
    [SerializeField] public SE_NearSight_SO SE_NearSight;                // a couple of direct refs

    public void PreAwake() { }                                           // assigns each SO.id = its index
    public void Localise(Translator translator) { }                      // fills localized UI names

    public StatusEffect NewStatusEffectInstance(int statusEffectId, EntityManager entityManager) => null;
    public int          GetStatusEffectId(StatusEffectSO statusEffect)  => 0;
    public StatusEffect.StatusEffectConfiguration GetStatusEffectConfig(int statusEffectId) => null;
}
```

Critical facts for modding:
- **The array index in `statusEffects` is the canonical `id`.** `PreAwake` walks the array and
  stamps `SO.id = index` (and presumably caches `SE_Poisoned_SO.Id = index`, etc.). Ordering also
  encodes **priority** (header literally says "Status Effects by Priority").
- `NewStatusEffectInstance(id, em)` is the central factory used by `CharStatusEffects` to mint a
  live instance from an id; `GetStatusEffectId(SO)` is the reverse lookup.
- Because ids are **assigned by position at load**, they are *stable only for the shipped roster*.
  A mod that wants a new effect must either (a) append its SO to this array **before** `PreAwake`
  so it gets a real id and is networked like any other effect, or (b) reuse an existing id.
  This is the single most important integration point for "a new networked status".

---

## 3. Per-character live state: `CharStatusEffects` (`Entities\CharStatusEffects.cs:13`)

```csharp
[DisallowMultipleComponent]
public class CharStatusEffects : NetworkBehaviour, INetworkPredicted   // line 13
{
    public EntityManager      entityManager;
    public EntityMovement     charMove;
    public UIManager          uiManager;  public UIPopUp uiPopUp;
    public StatusEffectManager statusEffectManager;             // the registry (§2)
    public SortedList<StatusEffect> statusEffects;              // ACTIVE effects, priority-sorted

    // immunity / debuff suppression counters (lock-counted, not booleans):
    public int immuneToStatusEffects;
    public int immuneToSlows;
    public int immuneToMovementDebuffs;
    public int polymorphCatLocks;

    public void PreAwake(EntityManager e) { }
    public void OnTick(float fixedDt, Command cmd, bool isResim) { }   // ticks every active effect
    public void ManagedUpdate() { }                                    // per-frame OnUpdate fan-out
    public void ClStartAuth() { } public void ClStopAuth() { }

    // ---- APPLICATION (server only) ----
    [Server] public StatusEffect ActivateStatusEffect(StatusEffectInfo info, int otherPlayerId = -1,
                                                       Vector3 direction = default, bool forceApply = false) => null;
    [Server] public StatusEffect ActivateStatusEffect(int statusEffectId, float duration, float multiplier = 1f,
                                                       int otherPlayerId = -1, Vector3 direction = default,
                                                       bool forceApply = false) => null;

    // ---- REMOVAL ----
    public void DeactivateStatusEffect(int statusEffectId) { }
    public void DeactivateInstance(StatusEffect statusEffectInstance) { }
    public void RemoveAllStatusEffects() { }
    public void Cleanse() { }                                  // removes all isCleanseable effects

    // ---- QUERIES ----
    public float GetStatusEffectDuration(int id) => 0f;
    public bool  IsStatusEffectApplied(int id)   => false;
    public int   GetActivatedCount(int id)       => 0;         // stack count
    public float[] GetMultipliersOfEffect(int id) => null;
    public bool  IsNonImmuneStatusEffect(int id) => false;
    public bool  IsMovementDebuff(int id)        => false;
    public int   GetStatusEffectPriority(int id) => 0;
    public bool  CanEntityInteractWithStatusEffect(int id) => false;
    public bool  TryFindStatusEffect<T>(out T se) { se = default; return false; }
    public Vector3 ApplyInputDirModifications(Vector3 inputDir) => default;  // fan-out to effects' ApplyInputDirModification

    // ---- SHIELD (buff) helpers ----
    public SE_Shield FindOldestShield() => null;
    public void OnShieldDamaged(int dmg) { }
    public void RemoveShield(SE_Shield shield, int leftOverDmg) { }
    public SE_Shield GetShield(float multiplier) => null;

    // ---- NETWORK / UI RPCs (cosmetic + HUD only) ----
    [TargetRpc] public void TargetRpcShowStatusEffectPopUp(NetworkConnection conn, int statusEffectId) { }
    [ClientRpc] public void RpcShowStatusEffectPopUp(int statusEffectId) { }
    [ClientRpc] public void RpcShowStatusEffectHpBarProgress(int statusEffectId, float duration) { }
    [ClientRpc] public void RpcRemoveStatusEffectHpBarProgress(int statusEffectId) { }
    [TargetRpc] public void TargetRpcSetHpBarStackProgress(NetworkConnection conn, float normProgress) { }
    [TargetRpc] public void TargetRpcSetHpBarStackDisabled(NetworkConnection conn) { }
    [ClientRpc] public void RpcSpawnCementedVfx() { }     // petrify/cement visual
    [ClientRpc] public void RpcOnCementedMove() { }
    [ClientRpc] public void RpcSpawnImmunePopUp() { }
    [ClientRpc] public void RpcSpawnStatusText(string status, UIPopUp.PointType color) { }
    public void ShowStatusEffectHpBar(int id, float duration) { }
    public void UpdateStatusEffectHpBar(int id, float totalDuration, float duration) { }
    public void RemoveStatusEffectHpBar(int id, bool removeAll = false) { }

    // ---- INetworkPredicted snapshot (THE networking of the actual state) ----
    public void OnNetSerialize(NetworkWriter netWriter)   { }
    public void OnNetDeserialize(NetworkReader netReader) { }
    public bool OnNetDebugCompare(NetworkReader netReader) => false;
    public void OnNetDebugLog(StringBuilder sb) { }
}
```

What this tells us, concretely:

1. **`ActivateStatusEffect` is `[Server]`.** There is **no command/RPC for a client to request a
   status**; statuses are only created on the server and replicated down. (This is exactly why
   the previous client-side graft was invisible to others — see §7.)
2. The two overloads accept either a `StatusEffectInfo` (SO-based) or a raw `(id, duration, multiplier)`.
   `forceApply` bypasses the immunity check.
3. **Stacking & dedup** are governed by the SO config (`onlyOneInstance`, `mergeIdentical`,
   `maxPoisonStacks`) and resolved here (re-`Activate` vs `Reactivate` vs new instance).
4. **Immunity is reference-counted** (`immuneToStatusEffects`, `immuneToSlows`,
   `immuneToMovementDebuffs`). A status is rejected unless its config `isNonImmune` is set or
   `forceApply == true`.
5. **Movement debuffs** (`isMovementDebuff`) feed `EntityMovement` via `immuneToMovementDebuffs`
   and the `ImmuneToMovementDebuffSubroutine` (§5.3); slows specifically pick the strongest via
   `SE_Slowed.FindHighestStatusEffect` + `TryApplyHighest/TryRevertHighest`.

---

## 4. Networking model (the part that the failed mod got wrong)

BAPBAP uses **Mirror with a custom rollback/prediction layer**. Status state is part of that
predicted snapshot, **not** Mirror SyncVars.

- `CharStatusEffects` implements `INetworkPredicted` (`Network\INetworkPredicted.cs`):

  ```csharp
  public interface INetworkPredicted
  {
      void OnTick(float fixedDt, Command cmd, bool isResim);   // advance simulation (incl. resim during rollback)
      void OnNetSerialize(NetworkWriter netWriter);            // write authoritative state into the snapshot
      void OnNetDeserialize(NetworkReader netReader);          // read it on clients
      bool OnNetDebugCompare(NetworkReader netReader);         // desync detection
      void OnNetDebugLog(StringBuilder sb);
  }
  ```

- **Server tick (authoritative):** the simulation calls `CharStatusEffects.OnTick(fixedDt, cmd, isResim)`,
  which advances each active `StatusEffect.OnTick(fixedDt)` (poison damage, duration countdown,
  shield decay, etc.). `isResim == true` during a rollback re-simulation, so effect ticks must be
  **deterministic** (re-runnable) — they read only replicated/sim state, never `Time.time` wall clock.
- **State replication:** every snapshot, `OnNetSerialize` writes the active-effect set
  (ids + durations + multipliers + relevant runtime, e.g. poison stacks) and clients reconstruct it
  in `OnNetDeserialize`. **This is the only channel by which other players see your status.**
- **Cosmetic / HUD replication:** transient presentation (pop-ups, HP-bar timers/stacks, petrify
  "cemented" VFX, immune text) is pushed separately via the `[ClientRpc]`/`[TargetRpc]` methods
  listed in §3. These are *fire-and-forget* and not part of the deterministic state.
- Compare this with `HitboxBase` (`Entities\HitboxBase.cs`), which *does* use `[SyncVar]`
  (`ownerPlayerId`, `teamId`) and full `SerializeSyncVars/DeserializeSyncVars` — hitboxes are
  spawned networked objects, whereas status effects are sub-state of the predicted character.

**Net effect for modders:** to make a status visible to everyone you must cause the **server**
to call `ActivateStatusEffect`. Once it is in the server's `statusEffects` list, the existing
`OnNetSerialize` path replicates it and the existing RPCs drive everyone's HUD/VFX *for free* —
**provided the effect has a valid id that all clients agree on** (i.e. it is in
`StatusEffectManager.statusEffects` in the same order on every build).

---

## 5. How a status gets applied on a hit (the full chain)

### 5.1 Hitbox carries the payload — `HitboxBase` (`Entities\HitboxBase.cs`)

```csharp
public class HitboxBase : NetworkBehaviour, IPoolDespawnListener
{
    [SyncVar] public int ownerPlayerId;
    [SyncVar] public int teamId;
    public int damage; public bool isCriticalDamage; /* … lots of combat params … */

    public List<StatusEffectInfo> _statusEffects;        // <-- statuses this hitbox applies
    public List<PassiveSO>        _passives;             // <-- passives this hitbox applies
    public List<StatusEffectInfo> statusEffects { get; set; }  // public accessor over _statusEffects
    public List<PassiveSO>        passives      { get; set; }

    public Action<EntityManager, HitboxBase> OnHitSuccessAction;     // hooks fired on a successful hit
    public Action<EntityManager, HitboxBase> OnHitSuccessTempAction;

    public void OnHitSuccess(EntityManager otherEntityManager) { }   // server-side: resolves a hit
    public bool CanHitEntity(int otherTeamId, int otherPlayerId) => false;
}
```

So the hitbox is the *carrier*: an ability authors `statusEffects` on it before spawning, and on a
confirmed hit `OnHitSuccess` (server) routes damage + statuses into the victim's `CharHurtbox`.

### 5.2 Hurtbox receives and dispatches — `CharHurtbox` (`Entities\CharHurtbox.cs`)

```csharp
public class CharHurtbox : NetworkBehaviour, INetworkPredicted
{
    // The master hit entry point. Note the statusEffects + passives parameters:
    public void ApplyHit(int damage,
                         List<StatusEffectInfo> statusEffects = null,
                         int otherPlayerId = -1, GameObject otherCharObj = null,
                         bool isCrit = false, bool applyLifeSteal = true, bool applyThorns = true,
                         /* … */, Vector3 hitDir = default, /* … */,
                         List<PassiveSO> passives = null, Transform hitboxTr = null, /* … */) { }

    // Dispatches the status list to the character's CharStatusEffects:
    public void ApplyStatusEffects(List<StatusEffectInfo> statusEffects, int ownerPlayerId = -1,
                                   Vector3 pushDir = default, GameObject otherChar = null,
                                   Transform hitboxTr = null) { }

    public void ApplyPassives(List<PassiveSO> passives) { }
    [Server] public void SvSetHp(int newHp) { }   // damage path is all [Server]
}
```

`EntityManager` exposes both halves so the chain can hop between them:
`EntityManager.charHurtbox` (`Entities\EntityManager.cs:43`) and
`EntityManager.charStatusEffects` (`Entities\EntityManager.cs:58`).

**End-to-end on-hit chain (server-authoritative):**

```
Ability spawns Hitbox, sets hitbox.statusEffects = ability.statusEffects (List<StatusEffectInfo>)
        │
        ▼
HitboxBase.OnHitSuccess(victimEntity)                       // server, after CanHitEntity check
        │   victim.charHurtbox.ApplyHit(damage, _statusEffects, ownerPlayerId, …, _passives)
        ▼
CharHurtbox.ApplyHit(...)                                   // applies damage, then:
        │   ApplyStatusEffects(statusEffects, ownerPlayerId, hitDir, …)
        ▼
CharHurtbox.ApplyStatusEffects(...)                         // for each StatusEffectInfo:
        │   victim.charStatusEffects.ActivateStatusEffect(info, ownerPlayerId, hitDir)
        ▼
[Server] CharStatusEffects.ActivateStatusEffect(...)        // immunity check, dedup/stack,
        │                                                    // StatusEffectSO.NewInstance(em) -> StatusEffect
        │   effect.Activate(duration, multiplier, otherPlayerId, direction)
        ▼
statusEffects (SortedList) now holds it  ──► OnNetSerialize replicates every tick (§4)
                                         └─► RpcShowStatusEffectPopUp / HpBar / VFX to all clients
```

### 5.3 Where abilities author the payload

`StunClapAbility` (`Entities\StunClapAbility.cs`) is a clean, representative example — an `Ability`
with **inspector-authored** status lists that are copied onto its spawned hitbox:

```csharp
public class StunClapAbility : Ability
{
    [SerializeField] public int   damage;  [SerializeField] public float damageScaling;
    [SerializeField] public List<StatusEffectInfo> statusEffects;       // applied by the clap hitbox (e.g. SE_Stunned)
    [SerializeField] public PassiveSO P_SASH_CLAP;
    [SerializeField] public List<StatusEffectInfo> clapAugStatusEffects; // extra statuses when the augment is owned
    public void Shoot(Vector3 lookDir, int predTickNum) { }             // spawns hitbox, sets hitbox.statusEffects
    public class CustomShootSubroutine : SimulationSubroutine { /* runs inside the predicted tick */ }
}
```

Note the pattern: the ability's *config* is plain `[SerializeField] List<StatusEffectInfo>`; the
actual spawn/apply runs inside a **`SimulationSubroutine`** (`CustomShootSubroutine`) so it is part
of the deterministic, networked simulation tick — not an ad-hoc client call.

### 5.4 Three reusable "apply a status" building blocks (Passives/Augments)

The game already ships generic, data-driven appliers you can reuse instead of writing C#:

- **`P_HitboxApplyStatusEffect`** (`Entities\P_HitboxApplyStatusEffect.cs`) — a `Passive` that
  injects status effects into a character's spawned hitboxes:
  ```csharp
  public class Config : PassiveConfiguration {
      public CommandId abiltiyId;            // which ability slot's hitboxes to modify
      public int tooltipStatusEffectIndex;
      public StatusEffectInfo[] statusEffects;   // <-- the effects to add
  }
  public override void OnHitboxSpawned(GameObject hitboxObj, EntityManager entity, int abilityId) { }
  public void ModifyHitbox(GameObject hitboxObj) { }   // appends statusEffects to hitbox._statusEffects
  ```
- **`P_OnDamage_ApplyStatusEffect`** (`Entities\P_OnDamage_ApplyStatusEffect.cs`) — an `Augment`
  with a tiered config that applies a status whenever the owner deals damage:
  ```csharp
  public StatusEffectSO statusEffect; public bool onlyPlayerDamage;
  public class TierStats { public float duration; public float multiplier; }
  public override void OnTakeDamageTrigger(int damage, Vector3 hitDir, EntityManager otherEntity) { }
  ```
- **`P_OnHitboxSpawned_AddEffect`**, **`P_OnCrit_ApplyEffectToTarget`**,
  **`P_OnHitXTimes_ApplyStatusEffect`**, **`P_OnDamage_*_Debuff`** (NoodleCombo, ThousandCuts),
  **`EntityActivateStatusEffect`** (server-activated zone/aura, below) — the same idea triggered
  off different events.

- **`EntityActivateStatusEffect`** (`Entities\EntityActivateStatusEffect.cs`) — the *zone / aura*
  applier (used by `SE_SlowZone`, `SE_CementZone`, `SE_ImmuneZone`, ward/pool prefabs):
  ```csharp
  public class EntityActivateStatusEffect : EntityActivateBase {
      public List<StatusEffectInfo> statusEffects;
      [Server] public override void Activate() { }     // applies to entities in the trigger
  }
  ```
  Its companion `HitboxTriggerboxStatusEffects : HitboxTriggerbox`
  (`Entities\HitboxTriggerboxStatusEffects.cs`) applies/removes the status on
  `OnEnter`/`OnExit`/`OnDespawn` — i.e. a persistent area that statuses anything standing in it.

### 5.5 An ability that *self-buffs* and applies via a subroutine — `AB_PoisonInfuse`

`AB_PoisonInfuse` (`Entities\AB_PoisonInfuse.cs`, SO: `AB_PoisonInfuse_SO.cs`) is an
`AbilityBehaviour` showing the **buff-on-self / timed-buff** pattern, done entirely inside
networked subroutines:

```csharp
public class AB_PoisonInfuse : AbilityBehaviour
{
    public class Config : AbilityBehaviourConfig {
        public float buffTime; public PassiveSO additionalPassiveToActivate; /* + cast/recovery/cooldown */ }
    public class CustomUseSubroutine  : NetworkedSimulationSubroutine { public override void OnEnter(float fixedDt, Command cmd, bool isResim) { } }
    public class RemoveBuffSubroutine : NetworkedSimulationSubroutine { public override void OnEnter(float fixedDt, Command cmd, bool isResim) { } }
    public bool buffActive;
}
```

- `NetworkedSimulationSubroutine` (`Network\NetworkedSimulationSubroutine.cs`) extends
  `SimulationSubroutine` with `OnNetSerialize/OnNetDeserialize/OnNetDebugCompare` — so a buff that
  needs to survive rollback (like "poison-infuse active for buffTime") serializes its own bit of
  state into the snapshot, exactly like `CharStatusEffects` does.
- `ImmuneToMovementDebuffSubroutine` (`Entities\ImmuneToMovementDebuffSubroutine.cs`) is the
  inverse — a `SimulationSubroutine` an ability runs to **grant immunity** (`applyLocks` →
  increments `CharStatusEffects.immuneToMovementDebuffs`) for the duration of a dash/cast.

---

## 6. UI / HUD side (so a custom status shows up correctly)

- **`UIHpBarStatusEffects`** (`UI\UIHpBarStatusEffects.cs`) — per-character HP-bar status strip.
  Driven by `StatusEffectData` items: `ModifyOrAddStatusEffect(data)`,
  `RemoveAllStatusEffect(data)`, `RemoveOldestStatusEffect(data)`, `UpdateStatusEffects()`.
  Fed by the `CharStatusEffects.Rpc*HpBar*` / `TargetRpcSetHpBarStack*` calls (§3).
- **`UIEffectIconStack`** (`UI\UIEffectIconStack.cs`) and **`UIBuffButtonElement`**
  (`UI\UIBuffButtonElement.cs`) render the icon stacks; icon + colour + name come from the SO's
  `StatusEffectConfiguration` (`spriteId`, `color`, `nameTranslationKey`).
- The hard-CC **animations** are triggered on `CharHurtbox` client RPC helpers:
  `ClPlayStunAnim()`, `ClPlayAirborneAnim/ClStopAirborneAnim`, `ClPlayKnockAnim`,
  `ClPlaySpinAnim`, `RpcSpawnSkullDeathFx`, etc. (`Entities\CharHurtbox.cs`). A custom CC status
  reuses these by calling the matching effect behaviour, which already fires the RPC.

**Implication:** if your custom status reuses an existing `spriteId`/translation key and a real
manager id, the HUD "just works". A brand-new icon needs (a) the sprite registered wherever
`spriteId` resolves and (b) a translation key in the localisation table.

---

## 7. Why the previous (failed) approach broke — mapped to this system

From `CustomCharFramework.cs` (`C:\Users\Administrator\Downloads\BAPBAPModdingAPI\bapcustomchars-mod\`),
the failed Medusa mod declared `StatusOnHit = ["poison","petrify"]` and applied them via a
**Harmony patch on `HitboxBase.OnHitSuccess`** mapping the string names to effects. Cross-referencing
the real system:

1. **Client-side application = invisible to others.** `ActivateStatusEffect` is `[Server]` and the
   live set is replicated only through `CharStatusEffects.OnNetSerialize` (§4). If the graft ran on
   the local (non-server) client, the server's `statusEffects` list never changed, so nothing was
   serialized to peers — matching the "attacks/visuals only local, not visible to others" symptom.
   (Same root cause as the despawn / frozen-pose issues for the cloned character generally.)
2. **No stable id ⇒ no agreement.** Statuses are identified by their **index in
   `StatusEffectManager.statusEffects`** (§2). Mapping by ad-hoc string names without inserting an
   SO into that array (in the same order on every build) means the id is undefined/mismatched, so
   even a server-side apply would desync `OnNetDebugCompare`.
3. **Bypassing the canonical chain.** The shipped path is
   `Hitbox._statusEffects → ApplyHit → ApplyStatusEffects → ActivateStatusEffect`. Patching
   `OnHitSuccess` to call effects directly skips the immunity counters
   (`immuneToStatusEffects/Slows/MovementDebuffs`), stacking/dedup config, and the priority sort,
   producing inconsistent CC (e.g. a "green dot" with no real petrify root, abilities that "only
   LMB works"). The abilities themselves never carried `StatusEffectInfo`, so no real status flowed.

---

## 8. The correct, generalizable way to add a NEW networked status (design contract)

To add a new status effect (e.g. a custom "Curse") so it is real and networked:

1. **Author the data type.** Create `SE_Curse : StatusEffect` with a nested
   `Config : StatusEffect.StatusEffectConfiguration`, and `SE_Curse_SO : StatusEffectSO`
   (`[SerializeField] SE_Curse.Config configuration; public static int Id;` + override
   `NewInstance`). Implement `Activate/Reactivate/Deactivate/OnTick`. **`OnTick` must be
   deterministic** (no wall-clock, no per-frame randomness) so it survives `isResim` rollback (§4).
2. **Register it for a stable id.** Append the `SE_Curse_SO` asset to
   `StatusEffectManager.statusEffects` **at the correct priority slot**, on **every build** (server
   + all clients) so `PreAwake` stamps the same `id` everywhere. This is the make-or-break step for
   networking.
3. **Apply it server-side only.** Either:
   - put a `StatusEffectInfo(SE_Curse_SO, duration, multiplier)` into an ability's
     `List<StatusEffectInfo> statusEffects` and copy it onto the spawned hitbox (`HitboxBase.statusEffects`)
     — the canonical path (§5.1–5.3); **or**
   - attach a generic applier passive (`P_HitboxApplyStatusEffect`, `P_OnDamage_ApplyStatusEffect`,
     `P_OnHitboxSpawned_AddEffect`, or `EntityActivateStatusEffect` for a zone) configured with the SO; **or**
   - for a custom C# ability, call `victim.charStatusEffects.ActivateStatusEffect(info, ownerId, hitDir)`
     **inside a `SimulationSubroutine`/`[Server]` path**, never from a client-only hook.
4. **Let replication + HUD ride the existing rails.** Once in the server list, `OnNetSerialize`
   replicates it; give the SO config a `spriteId`/`color`/`nameTranslationKey` and the existing
   `Rpc*HpBar*` / `UIHpBarStatusEffects` / `UIEffectIconStack` show it. Hard-CC reuses
   `CharHurtbox.ClPlayStunAnim` etc.
5. **Respect immunity/stacking.** Set `isMovementDebuff`/`isNonImmune`/`isCleanseable`/
   `onlyOneInstance`/`mergeIdentical` honestly so it interacts correctly with
   `immuneToStatusEffects/Slows/MovementDebuffs`, `Cleanse`, and `SE_Slowed.FindHighestStatusEffect`.

### Minimum networking checklist for any "real status"
- [ ] SO present in `StatusEffectManager.statusEffects` at identical index on **all** builds.
- [ ] Application initiated on the **server** (`[Server] ActivateStatusEffect`), reached via
      hitbox/passive/subroutine — **never** a client-only Harmony graft.
- [ ] Effect's `OnTick` deterministic (rollback-safe).
- [ ] Per-application data (`duration`,`multiplier`,`otherPlayerId`,`direction`) passed through
      `StatusEffectInfo`; static tuning on the SO `Config`.

---

## 9. File index (evidence map)

| Concern | File | Note |
|---|---|---|
| Runtime instance + config block | `Entities\StatusEffect.cs` (class :6, config :9) | lifecycle hooks, config flags |
| Authoring asset + factory | `Entities\StatusEffectSO.cs` | `NewInstance`, `CreateAssetMenu` |
| Apply payload | `Entities\StatusEffectInfo.cs` | `(SO, duration, multiplier)` |
| Registry / id assignment / priority | `Local\StatusEffectManager.cs` | `statusEffects[]` index == id |
| Per-character live state + apply/remove + RPCs | `Entities\CharStatusEffects.cs:13` | `[Server] ActivateStatusEffect`, `INetworkPredicted` |
| Predicted-net contract | `Network\INetworkPredicted.cs` | `OnTick`/`OnNetSerialize`/`OnNetDeserialize` |
| Hitbox carrier | `Entities\HitboxBase.cs` | `_statusEffects`, `OnHitSuccess`, `[SyncVar]` owner/team |
| Hit receiver + dispatch | `Entities\CharHurtbox.cs` | `ApplyHit`, `ApplyStatusEffects` |
| Entity wiring | `Entities\EntityManager.cs` | `charHurtbox:43`, `charStatusEffects:58` |
| Concrete effects | `Entities\SE_*.cs` (+ `SE_*_SO.cs`) | Poisoned, Petrified, Stunned, Slowed, Shield, Frozen, Burn, … |
| Generic appliers (passives/augments) | `Entities\P_HitboxApplyStatusEffect.cs`, `P_OnDamage_ApplyStatusEffect.cs`, `P_OnHitboxSpawned_AddEffect.cs`, `P_OnCrit_ApplyEffectToTarget.cs`, `P_OnHitXTimes_ApplyStatusEffect.cs` | data-driven |
| Zone/aura applier | `Entities\EntityActivateStatusEffect.cs`, `Entities\HitboxTriggerboxStatusEffects.cs` | `[Server] Activate`, enter/exit |
| Ability authoring example | `Entities\StunClapAbility.cs` | `List<StatusEffectInfo>` + `CustomShootSubroutine` |
| Buff-on-self example | `Entities\AB_PoisonInfuse.cs` (+ `_SO`) | `NetworkedSimulationSubroutine` buff/timer |
| Movement-immunity grant | `Entities\ImmuneToMovementDebuffSubroutine.cs` | increments `immuneToMovementDebuffs` |
| Net subroutine base | `Network\NetworkedSimulationSubroutine.cs` | serializes its own rollback state |
| HUD | `UI\UIHpBarStatusEffects.cs`, `UI\UIEffectIconStack.cs`, `UI\UIBuffButtonElement.cs` | icon/timer/stack rendering |
| Failed approach (for contrast) | `BAPBAPModdingAPI\bapcustomchars-mod\CustomCharFramework.cs` | `StatusOnHit=["poison","petrify"]`, client-side graft |

> Reminder for synthesis: bodies are stubbed in this export, so exact stacking math, the precise
> serialized field set in `OnNetSerialize`, and the immunity-check order are **inferred** from
> signatures/attributes/field names, not read from executable code. The **architecture, ownership
> (server-authoritative), id model, and call chain are directly evidenced** by the types, the
> `[Server]`/`[ClientRpc]`/`[TargetRpc]` attributes, the `INetworkPredicted` implementation, and the
> `StatusEffectInfo` plumbing through `HitboxBase`/`CharHurtbox`/`CharStatusEffects`.

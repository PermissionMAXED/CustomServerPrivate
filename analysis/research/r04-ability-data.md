# R04 — Ability Data Model (BAPBAP)

Scope: how abilities are defined, how the 4 slots are structured, and the full schema an
ability/`AbilityBehaviourSO` references. Sourced from the decompiled game in
`C:\Users\Administrator\Downloads\neueBapbap\GameCode\ExportedProject\_DisabledScripts\Assembly-CSharp\BAPBAP\Entities\`
(method bodies are stubbed in this decompile, but **all fields, attributes, tooltips,
inheritance, and signatures are intact and authoritative**).

---

## 1. Executive answer: DATA or CODE?

**Player character abilities are CODE-first, not data/ScriptableObject-first.**

- Each ability is a concrete C# class deriving from `Ability : NetworkBehaviour`
  (`Entities\Ability.cs:12`). There are **~130 concrete ability classes** in
  `Entities\` (e.g. `ArrowAbility`, `KatanaMeleeAbility`, `CatJumpAbility`,
  `FireMeteoriteAbility`, `DashAbility`, `StabBlinkAbility`, plus all `Npc*Ability`
  boss/AI variants). Each is a `MonoBehaviour`/`NetworkBehaviour` **component placed on
  the character prefab**, with its tuning values exposed as `[SerializeField]` fields
  (designer-tweakable in the Inspector, but the *behaviour* is hand-written code).
- The gameplay logic of an ability lives in code: each ability builds a small **state
  machine** (`SimulationFsm`) out of reusable `SimulationSubroutine` / `CastSubroutine` /
  `CooldownSubroutine` pieces plus its own nested `Custom*Subroutine` classes
  (e.g. `ArrowAbility.CustomShootSubroutine` at `ArrowAbility.cs:13`).

**There is a SECOND, genuinely data-driven ability system — but it is for items/consumables, not the 4 main slots.**

- `AbilityBehaviourSO : ScriptableObject` (`Entities\AbilityBehaviourSO.cs`) is a
  `[CreateAssetMenu(... menuName = "BAPBAP/AbilityBehaviours/AbilityBehaviourSO")]`
  factory. It exposes `virtual AbilityBehaviour NewInstance(EntityManager)` and a
  `virtual AbilityBehaviour.AbilityBehaviourConfig config`. This is the data layer that
  spawns a runtime `AbilityBehaviour` (`Entities\AbilityBehaviour.cs`) bound to an
  *item* (`Build(Ability ability, int itemId)` at `AbilityBehaviour.cs`).
- These behaviours are grafted onto an owning `Ability` via item slots. `CharAbilities`
  defines `public const int CONSTANT_ITEM_OFFSET = 4;` (`CharAbilities.cs:14`) — i.e. the
  first 4 ability indices are the character's native code abilities, and item/consumable
  ability behaviours occupy indices ≥ 4. Concrete glue classes include
  `ConsumableBehaviourAbility`, `LootableBehaviourAbility`, `BehaviourAbilityComponent`.

**There is a THIRD, purely cosmetic data layer (UI only).**

- `UICharactersConfiguration` (a ScriptableObject,
  `UI\UICharactersConfiguration.cs`) holds per-character UI data including 4
  `AbilityData` entries (`ability1..ability4`). `AbilityData` is **icon + localization
  keys only** — no gameplay. See §5.

> **Bottom line for the synthesis stage:** a new ability = a new `Ability` subclass
> (code) compiled into / injected as a component, networked via Mirror, with a hitbox
> *prefab* (also a networked `NetworkBehaviour`) referenced through a serialized field.
> A new *item* ability can be pure data (`AbilityBehaviourSO`). The 4 character slots
> cannot be added by data alone in the stock design.

---

## 2. The base `Ability` class (`Entities\Ability.cs`)

`public class Ability : NetworkBehaviour` (`Ability.cs:12`). It is a **Mirror
`NetworkBehaviour`**, so it participates in network serialization/prediction directly.

### 2.1 Slot binding & general config (serialized, `[Header("General")]`)

| Field | Line | Type | Meaning |
|---|---|---|---|
| `cmdId` | `Ability.cs:17` | `CommandId` | **Which input slot casts this ability.** Tooltip (`Ability.cs:14`): *"LMB = Ability1, Q = Ability2, Space = Ability3, E = Ability4"*. |
| `useCustomUIData` | `:20` | `bool` | If true, ability supplies its own UI block instead of the char config. |
| `customUIData` | `:24` | `UICharactersConfiguration.CharacterConfiguration.AbilityData` | Per-ability UI override (icon + loc keys). |
| `customUIIconColor` | `:28` | `Color` | UI override. |
| `customUITitleColor` | `:32` | `Color` | UI override. |

> ⚠️ **Discrepancy to flag for synthesis:** the in-code tooltip maps slot 2 to **Q**, but
> the failed framework / user report assumes **RMB** for slot 2. The authoritative source
> says `Ability1=LMB, Ability2=Q, Ability3=Space, Ability4=E` (`Ability.cs:14`). The
> "RMB shows a green dot" bug in the clone approach is consistent with slot 2 (`cmdId`
> binding) never being wired to a real `Ability` component.

### 2.2 Mechanics config (serialized, `[Header("Mechanics")]`)

| Field | Line | Type | Meaning (from tooltip) |
|---|---|---|---|
| `autoCancel` | `:37` | `bool` | Can auto-cancel other casting abilities. |
| `priority` | `:41` | `int` | Input-buffer priority; higher casts first (Low=1, High=4). |
| `inputBufferDuration` | `:45` | `float` | Post-release input buffer window (default 250ms). |
| `canceledTime` | `:49` | `float` | Recast lockout after a cancel. |
| `silenceable` | ~`:53` | `bool` | Interrupted while silenced. |
| `cancelable` | ~`:57` | `bool` | Cancelable via Cancel button / canceler. |
| `usableOnDowned` | ~`:61` | `bool` | Castable while downed. |
| `enableCritDmg` | ~`:65` | `bool` | Can crit. |
| `maxTimeDilation` | ~`:69` | `float` | How much the server may dilate cast time (default 200ms). |

### 2.3 Injected runtime references (`[NonSerialized]`)

The ability is wired to the whole character component graph (resolved in `PreAwake`):
`entityManager`, `charSim` (`CharSimulation`), `charAbilities`, `charPassives`,
`charMove` (`EntityMovement`), `charAim`, `charAnim` (`CharAnimator`), `charHurtbox`,
`charTriggerbox`, `charEvents`, `charFx`, `charItems`, `charHidden`, `charMaterial`,
`charStatusEffects`, `CharVoicelines`, `charDowned`, `vfxM`, `audioM`, `statusEffectM`,
and crucially `fsm` (`SimulationFsm`). (`Ability.cs` `[NonSerialized]` block.)

### 2.4 FSM / state runtime fields (`[NonSerialized]`)

`stateId`, `triggerId`, `TRIGGER_NONE`, `TRIGGER_FORCEINTERRUPT_EXT`,
`npcCastExternalTrigger`, `npcInterruptExternalTrigger`, `state` (`AbilityStates`),
`dilatedTime`, `isInputBuffered`, `inputBufferTimeLeft`, `useLocks`, and three
subroutine handles:

- `cooldownSubroutine` (`CooldownSubroutine`)
- `startCdSubroutine` (`CooldownSubroutine`) — start-of-match cooldown
- `castSubroutine` (`CastSubroutine`)

### 2.5 Lifecycle / behaviour hooks (overridable)

`PreAwake(EntityManager)`, `Start()`, `Tick(float fixedDt, Command cmd, bool isResim)`,
`OnDestroy()`, `ClStartAuth()`, `ClStopAuth()`, `LoadAbilityUI()`,
`UpdateAbilityBehaviourChanged(int consumableSlot)`, `ResetInputBuffer()`,
`ResetCooldown()`, `LowerCooldownByPercent(float)`, `ChangeCastTime(float)`,
`ForceReset()`, `ForceInterrupt()`, `SetState(AbilityStates)`, `FireExternalCast()`,
`FireExternalInterrupt()`.

**Server-authoritative hit callbacks** (all `[Server]`):
`OnTargetHit(EntityManager, HitboxBase)`, `OnTargetKill(EntityManager)`,
`OnWallHit(GameObject)`, `OnOtherHitboxHit(Hitbox, HitboxBase)`,
`OnHitboxDestroy(HitboxBase)`.

**Network sync hooks** (Mirror prediction/resim):
`OnNetSerialize(NetworkWriter)`, `OnNetDeserialize(NetworkReader)`,
`OnNetDebugCompare`, `OnNetDebugLog`.

**Tooltip builders:** `GetTooltipDescription`, `GetTooltipExpandedDescription`,
`BuildTooltipDescription`, `GetTooltipScaledDamage`, `GetTooltipScaledCooldownStat`,
`GetTooltipStat`, `GetTooltipStatusEffect`, etc.

---

## 3. The 4 ability-slot structure

### 3.1 Slot identity = `CommandId` (`Local\CommandId.cs`)

```csharp
public enum CommandId {
    Ability1 = 0, Ability2 = 1, Ability3 = 2, Ability4 = 3,   // the 4 main slots
    Ability5 = 4, Ability6 = 5, Ability7 = 6, Ability8 = 7,   // item/extra slots
    CancelAbility = 8, AbilityHeal = 9,
    Drop1..Drop4 = 10..13, DropConsumable1..3 = 14..16,
    DropGold = 17, DropAbility = 18, Interact = 19,
    VehicleDrift = 20, VehicleTurbo = 21
}
```

So a slot is not an array index on the character — it is the `cmdId` field declared on
each `Ability` component (`Ability.cs:17`). The input system raises a `Command`
(`Local\Command.cs`) carrying the `CommandId`; the matching `Ability` (the one whose
`cmdId` equals it) casts.

### 3.2 Slot container = `CharAbilities` (`Entities\CharAbilities.cs`)

`public class CharAbilities : NetworkBehaviour, INetworkPredicted` (`CharAbilities.cs:12`).

- `public Ability[] abilities;` (`[NonSerialized]`) — the runtime set of `Ability`
  components on this character. (Populated at runtime; bodies stubbed, but the
  decompile shows it is non-serialized → discovered via component scan, not authored as
  a list. The `Ability` components live on the prefab.)
- `public Ability[] abilitiesByPriority;` and `public Ability[] abilitiesWithAutoCancel;`
  — pre-sorted views (`SortAbilitiesByPriority()`, `SortAbilitiesAutoCancel()`).
- `public const int CONSTANT_ITEM_OFFSET = 4;` (`CharAbilities.cs:14`) — confirms the
  **first 4 = character abilities**, indices ≥ 4 = item/consumable behaviours.
- `public CastFlags castFlags;` — bitmask of currently-casting slots (see §3.3).
- Shared stat block applied across abilities: `damage`, `attackSpeed`, `cooldown`,
  `critChance`, `critDmg`, `lifesteal`, `shred`, `luck`, `damageModifier`,
  `damageMultiplier`, `damageToPlayersMultiplier`, plus `baseCritDmg`, `baseCritChance`,
  `baseLifeSteal`, `maxAttackSpeed` (serialized base stats).
- Lock counters: `silenceLocks`, `teleportLocks`, `animLocks`,
  `forceFullbodyAnimLocks`, `abilityHiddenLocks`.
- Cast entry points: `OnAbilityCast(CommandId cmdId)`, `SvOnAbilityTriggered(CommandId)`,
  `SetCastAbility(CastFlags)`, `ResetCastAbility(CastFlags)`,
  `IsAbilityBeingCanceled(int cmdId)`, `IsCasting()`.
- Client RPCs: `RpcCastResult(bool)`, `RpcAbilityReady(int cmdId)`, `RpcResetText()`,
  `RpcTriggerBushReveal()` — these tell clients the slot is ready / cast succeeded.
- `Transform[] attachables` (serialized) — anchor points used by abilities/VFX
  (referenced by VFX subroutines via `attachableId`, e.g. `KatanaMeleeAbility.CustomVfxSubroutine`).

### 3.3 `CastFlags` (`Entities\CastFlags.cs`) — bitmask of slots

```csharp
[Flags] enum CastFlags {
    None=0, Ability1=1, Ability2=2, Ability3=4, Ability4=8,
    Ability5=0x10, Ability6=0x20, Ability7=0x40, Ability8=0x7C
}
```
Used so `CharAbilities` can track/forbid multiple simultaneous casts per slot.

### 3.4 UI side: exactly 4 main abilities

`UICharactersConfiguration.CharacterConfiguration` declares
`public const int mainAbilityNum = 4;` and four `AbilityData` fields
`ability1..ability4` with `AbilityData GetAbilityData(int abilityIndex)`. This is the
canonical "4 slots" on the presentation side.

---

## 4. Full ability schema (what a concrete `Ability` references)

The base class carries only general/mechanics/UI fields. **All combat content
(hitbox/projectile prefab, damage, VFX, cast timings, animation layer) is declared on the
concrete subclass.** The fields are highly consistent across abilities. Below is the
canonical schema, taken from `ArrowAbility` (projectile), `FireMeteoriteAbility`
(ground-target AoE), `CatJumpAbility` (mobility), `KatanaMeleeAbility` (melee combo) —
with `file:line` anchors.

### 4.1 `[Header("General")]` — spawn + locomotion + input

| Field | Type | Example source | Purpose |
|---|---|---|---|
| `spellPrefab` | `GameObject` | `ArrowAbility.cs:28` | **The networked hitbox/projectile prefab** spawned on cast (see §6). Melee combos use `spellAttack1/2/3Prefab` (`KatanaMeleeAbility.cs`). |
| `firingPoint` | `Transform` | `ArrowAbility.cs:31` | Spawn origin on the rig. |
| `spread` | `float` | `ArrowAbility.cs` | Projectile spread. |
| `castMotionLockType` | `MotionLockType` | `ArrowAbility.cs:37` | Movement lock during cast: `None/Movement/Walk/WalkConstantSpeed` (`MotionLockType.cs`). |
| `rotationLockType` | `RotationLockType` | `KatanaMeleeAbility.cs` / `CatJumpAbility.cs` | Facing lock during cast. |
| `applyAtkSpeedMultiplier` | `bool` | `ArrowAbility.cs` | Cast time scales with attack speed. |
| `applyCooldownMultiplier` | `bool` | `ArrowAbility.cs` | Cooldown scales with cooldown stat. |
| `inputType` | `InputType` | `ArrowAbility.cs:46` | `Down/Hold/Up` (`Local\InputType.cs`) — press vs hold-channel vs release. |
| `abilityRadius` | `float` | `FireMeteoriteAbility.cs` | AoE radius (ability-specific). |

### 4.2 `[Header("Hitbox-related")]` — damage & on-hit

| Field | Type | Source | Purpose |
|---|---|---|---|
| `damage` | `int` | `ArrowAbility.cs:69` | Base damage. (Melee: `damage1/2/3` per combo step.) |
| `damageScaling` | `float` | `ArrowAbility.cs:72` | Scaling vs the char `damage` stat. |
| `speed` | `float` | `ArrowAbility.cs:75` | Projectile speed (projectiles). |
| `hitboxRadius` | `float` | `FireMeteoriteAbility.cs` / `CatJumpAbility.cs` | Hit radius (AoE/melee). |
| `ttl` | `float` | `ArrowAbility.cs:78` | Hitbox lifetime. |
| `statusEffects` | `List<StatusEffectInfo>` | `ArrowAbility.cs:81` | Effects applied on hit (see §4.6). Melee also has `bonusHitStatusEffects`. |
| `knockbackIntensity` | `float` | `ArrowAbility.cs:84` | Knockback strength. |
| `hitStopDuration` | `float` | `ArrowAbility.cs` | Hit-stop / freeze frames on impact. |

### 4.3 `[Header("State-related")]` — the timing/FSM tuning

| Field | Type | Purpose |
|---|---|---|
| `castingTime` | `float` | Wind-up before the hitbox fires (drives `CastSubroutine`). Melee: `castingTime1/2/3`. |
| `recoveryTime` | `float` | Post-cast recovery before idle. |
| `baseCooldownTime` | `float` | Slot cooldown (drives `CooldownSubroutine`). Melee: `cooldownTime1/2/3`, `comboCooldownTime`, `comboResetTime`. |
| `startCooldownTime` | `float` | Initial cooldown at match start (`FireMeteoriteAbility.cs`). |
| `jumpTime`/`floatTime`/`jumpDistance`/`jumpLerpCurve` | `float`/`AnimationCurve` | Mobility-ability timing (`CatJumpAbility.cs`). |

### 4.4 `[Header("Indicator")]` — ground-target reticle (AoE abilities)

From `FireMeteoriteAbility.cs`: `indicatorPrefab` (`GameObject`),
`indicatorMouseHalfScale`/`indicatorBaseHalfScale`/`indicatorOffset` (`Vector2`),
`indicatorMaxDistance` (`float`), `indicatorRotateWithDirection` (`bool`). Driven by a
`MouseIndicatorSubroutine indicatorSubroutine`. `AbilityBehaviour` also has
`ClSpawnVisibleIndicator(Vector3)` / `ClDestroyVisibleIndicator()` hooks.

### 4.5 `[Header("Effects")]` / `[Header("VFX")]` / `[Header("SFX")]`

- VFX prefabs: `vfxMuzzlePrefab` (`ArrowAbility.cs`), `vfxJumpPrefab`/`vfxLandPrefab`
  (`CatJumpAbility.cs`), `vfxCast1/2/3Prefab`, `vfxCast3FirePrefab`
  (`KatanaMeleeAbility.cs`) — all `GameObject`.
- Camera juice: `camKickPower`, `camShakeOnHitTrauma`, `camShakeTrauma`,
  `camShakeOnHurtTrauma`, `zoomOutMultiplier` (`float`).
- SFX: `sfxCast` / `sfxHitEvent` / `sfxCast1..3` are **FMOD `EventReference`**
  (`using FMODUnity;`).
- Voicelines: `voicelineCast` / `voicelineKill` (`CharVoicelineConfig`) on
  `FireMeteoriteAbility`.

### 4.6 `StatusEffectInfo` (`Entities\StatusEffectInfo.cs`)

```csharp
[Serializable] class StatusEffectInfo {
    public StatusEffectSO statusEffect;   // the effect asset (poison, slow, root, ...)
    public float duration;
    public float multiplier;
    // ctors: (StatusEffectSO, duration, multiplier) and (int statusEffectId, duration, multiplier)
}
```
This is the data hook for on-hit effects — `StatusEffectSO` is itself a ScriptableObject
referenced by id or asset.

### 4.7 `[Header("Animation")]` — `AnimLayerIndices` (`Entities\AnimLayerIndices.cs`)

```csharp
enum AnimLayerIndices : byte { Base=0, Upperbody=1, Fullbody=2, IdleFullbody=3 }
```
Each ability exposes `public AnimLayerIndices animLayer;`. **There is no string
"animation trigger" field on the ability** — animation is driven through `CharAnimator`
(`charAnim`) on the chosen layer, invoked from inside the ability's subroutines.
This matters: the clone-graft bug where "E plays Kitsu's animation" happens because the
custom ability reuses the base character's `CharAnimator`/AnimatorController state rather
than supplying its own clips on the correct `animLayer`.

### 4.8 `[Header("Augment Passives")]` — passive/augment SO references

Abilities reference per-augment `ScriptableObject`s (e.g.
`P_CharAugment_ScatterShot_SO`, `P_CharAugment_Kitsu_TrilunarBarrage_SO`,
`P_CharAugment_SplitProjectile_SO` in `ArrowAbility.cs`; `PassiveSO P_KIDDO_CRATOR`,
`P_CharAugment_Kiddo_MeteorShower_SO` in `FireMeteoriteAbility.cs`). These are the *data*
side of passives that modify an ability's behaviour. (Detailed passive model is R-other.)

---

## 5. UI ability data — `AbilityData` (`UI\UICharactersConfiguration.cs`)

```csharp
[Serializable] public struct AbilityData {
    [SpriteVisualizer] public Sprite icon;
    [Header("Localization Keys")]
    public string titleKey;
    public string shortDescriptionKey;
    public string descriptionKey;
}
```

- Cosmetic only: an icon sprite + three localization keys. No damage/cooldown/prefab.
- `CharacterConfiguration` holds `ability1..ability4` of this type, plus ability palette:
  `abilityIconColor`, `abilityBGColor`, `titleTextColor` (`Color`), and char colors
  `Color`, `UIAccentColor`.
- An `Ability` can override this per-ability via `useCustomUIData` + `customUIData`
  (`Ability.cs:20-24`).
- This is exactly the layer the failed `CustomCharFramework` tried to fill from JSON
  (`AbilityTitles`, `AbilityDescriptions`, `AbilityPaletteHex` in
  `CustomCharFramework.cs`) — it correctly addressed *UI text/color* but did **not**
  create real `Ability` gameplay components, which is why visuals/attacks were local-only
  and slots 2–4 were broken.

---

## 6. Hitbox / projectile prefab schema (`Entities\HitboxBase.cs`, `Hitbox.cs`)

The `spellPrefab` an ability spawns is **itself a Mirror `NetworkBehaviour`**:

- `public class HitboxBase : NetworkBehaviour, IPoolDespawnListener` (`HitboxBase.cs:11`).
- `public class Hitbox : HitboxBase` (`Hitbox.cs:12`).
- `[SyncVar] int ownerPlayerId; [SyncVar] int teamId;` — networked ownership/team.
- Behaviour flags (serialized & runtime): `allowHitToEnemies`, `allowHitToTeam`,
  `allowHitToOwnerPlayer`, `destroyOnCharHit`, `destroyOnObstacleHit`, `doTtl`, `ttl`,
  `ignoreObstacles`, `ignoreInteractables`, `ignoreItems`, `rendererObj` (`GameObject`),
  `damage`, `isCriticalDamage`, `knockbackIntensity`, `damageToPlayersMultiplier`,
  `doDamagePerElapsedTime` + `damagePerElapsedTimeRange`.
- Attached behaviour components: `ProjectileMove projMove` (movement), `VFXSpawn vfxSpawn`,
  `AudioPlayFmod`, `AudioPlayIntervals`.
- Server callbacks fire back into the owning ability (`Ability.OnTargetHit`,
  `OnHitboxDestroy`, etc.) — the loop is: ability spawns networked hitbox → hitbox
  detects collision server-side → calls back ability `[Server]` handlers → effects/RPCs.

> **Critical networking implication:** because hitboxes are `NetworkBehaviour`s spawned
> through Mirror, a custom ability's `spellPrefab` **must be registered as a Mirror
> spawnable prefab (assetId)** or it will only ever exist on the local client — exactly
> the "attacks only visible locally / green dot only" symptom from the failed approach.

---

## 7. The ability state machine

### 7.1 `AbilityStates` (`Entities\AbilityStates.cs`)

```csharp
enum AbilityStates : byte {
    Ready=0, Aiming=1, Casting=2, Active=3, Cooldown=4, Disabled=5
}
```
The `Ability.state` field tracks the current high-level state; `SetState()` /
`OnStateChanged()` manage transitions and UI.

### 7.2 `SimulationFsm` (`Network\SimulationFsm.cs`)

A reusable, **networked, resimulation-aware** FSM built via a fluent `Builder`:

```csharp
fsm = new SimulationFsm.Builder()
    .State(stateId)
    .AddSubroutine(subroutine)         // SimulationSubroutine
    .AddTransition(trigger, nextState) // byte trigger -> byte state
    .Start(startState)
    .Build();
```
- `subroutinesByState`, `transitionsByState`, `allSubroutines`,
  `networkedSubroutines` (the subset that serializes over the network).
- Drive: `Tick(fixedDt, cmd, isResim)` → `OnEnter/OnTick/OnExit`. Triggers fire
  transitions: `Fire(trigger, cmd, isResim)`, `FireExternal(trigger)`,
  `FireExternalImmediate(trigger)`, `ChangeState(stateId)`.
- Net sync: `OnNetSerialize/OnNetDeserialize/OnNetDebugCompare/OnNetDebugLog` —
  **the FSM's `currentState` and networked subroutines are serialized for client
  prediction & server reconciliation.**

### 7.3 Subroutine base classes

- `SimulationSubroutine` (`Network\SimulationSubroutine.cs`): virtual
  `OnEnter`, `OnTick` (returns a `byte` trigger), `OnExit`, `DeBuild`.
- `NetworkedSimulationSubroutine : SimulationSubroutine`
  (`Network\NetworkedSimulationSubroutine.cs`): adds
  `OnNetSerialize/OnNetDeserialize/OnNetDebugCompare/OnNetDebugLog`. **Use this base for
  any per-ability state that must survive client prediction/resim** (e.g.
  `CatJumpAbility.CustomFloatSubroutine`).

### 7.4 Built-in reusable subroutines

**`CastSubroutine : NetworkedSimulationSubroutine` (`Entities\CastSubroutine.cs`)**
```csharp
CastSubroutine(Ability ability, byte finishTrigger, byte silenceTrigger,
               byte cancelTrigger, float castingTime,
               bool applyAtkSpeedMultiplier, bool doTimeDilation)
```
Fields: `finishTrigger`, `silenceTrigger`, `cancelTrigger`, `castFlag` (`CastFlags`),
`isUlt`, `isSuccess`, `timeElapsed`, `castingTime`. Methods: `GetAdjustedCastingTime()`,
`SetCastTime(float)`, `ReupdateCasting()`. This is the **cast-bar / wind-up** state; it
applies attack-speed scaling and server time dilation.

**`CooldownSubroutine : NetworkedSimulationSubroutine` (`Entities\CooldownSubroutine.cs`)**
```csharp
CooldownSubroutine(Ability ability, byte trigger, float duration,
                   bool applyCdMultiplier, bool applyAtkSpeedMultiplier)
```
Fields: `trigger`, `duration`, `applyCdMultiplier`, `resetOnEnter`, `timeElapsed`,
properties `TimeElapsed`/`Duration`. Methods: `GetAdjustedCooldownDuration()`,
`SetTimeElapsed`, `IncrementTimeElapsed`, `SetCooldownDuration`, `ResetCooldownOnEnter`,
`LowerCooldownByPercent(float)`, `ReupdateCooldown()`. This is the **cooldown** state.

> A typical ability FSM is therefore: `Ready → (input) → [Aiming] → Casting (CastSubroutine)
> → Active (Custom*Subroutine spawns the hitbox) → Cooldown (CooldownSubroutine) → Ready`,
> with `silence`/`cancel`/`forceInterrupt` triggers wiring early exits.

---

## 8. The data-driven item-ability path (`AbilityBehaviour` / `AbilityBehaviourSO`)

This is the **only place the game models abilities as pure data**, and it's for
item/consumable-granted abilities, not the 4 character slots.

**`AbilityBehaviourSO : ScriptableObject` (`Entities\AbilityBehaviourSO.cs`)**
```csharp
[CreateAssetMenu(menuName = "BAPBAP/AbilityBehaviours/AbilityBehaviourSO")]
public class AbilityBehaviourSO : ScriptableObject {
    [NonSerialized] public int id;
    public virtual AbilityBehaviour.AbilityBehaviourConfig config => null;
    public virtual AbilityBehaviour NewInstance(EntityManager _entityManager) => null;
}
```
A concrete SO subclass overrides `config` (data) and `NewInstance` (factory) — so the SO
*asset* holds tuning, and the returned `AbilityBehaviour` holds runtime logic.

**`AbilityBehaviour` (`Entities\AbilityBehaviour.cs`)** — a plain class (NOT a
`NetworkBehaviour`) attached to an owning `Ability`:
```csharp
[Serializable] class AbilityBehaviourConfig : InlineAttribute {
    public InputType inputType;
    public bool silenceable;
    public bool cancelable;
    public bool usableWhileDowned;
}
```
Runtime fields: `Ability ability`, `AbilityBehaviourConfig abilityConfig`,
`SimulationFsm fsm`, `stateId`, `triggerId`, `TRIGGER_FORCEINTERRUPT_EXT`,
`int itemId`, `CastFlags consumableCastFlags`, `otherConsumableCastFlags`.
Lifecycle mirrors `Ability`: `Build(Ability ability, int itemId)`, `Tick`, `OnUpdate`,
`OnStart`, `OnDeactivate`, `ClStartAuth/ClStopAuth`, `GetCooldownTime[Elapsed]`,
`OnStopItemRemove`, `ClSpawn/DestroyVisibleIndicator`, `OnTargetHit`, `OnHitboxDestroy`,
and the same `OnNet*` sync methods (it serializes through its owning `Ability`).

Glue classes: `ConsumableBehaviourAbility`, `LootableBehaviourAbility`,
`BehaviourAbilityComponent` (all `Ability` subclasses) host these behaviours at slot
indices ≥ `CONSTANT_ITEM_OFFSET` (4).

---

## 9. NPC ability triggering — `AbilityTriggerData` (`Entities\AbilityTriggerData.cs`)

Not for player input; it is the **AI condition block** that decides when an NPC casts an
ability. `[Serializable]` so it is authored as data on NPC configs.

| Field | Type | Meaning (tooltip) |
|---|---|---|
| `ability` | `Ability` | The ability to trigger. |
| `updateRate` | `float` | How often (per sec) conditions are checked. |
| `randomChanceRate` | `float` | Rate for the random-chance roll. |
| `randomChanceNorm` | `float` (0–0.99) | Probability to trigger; 0 = no chance check. |
| `needsLineOfSight` | `bool` | Require LoS to target. |
| `triggerDistRange` | `RangeFloat` | Distance band to trigger; max 0 = no check. |
| `minAngleDiff` | `float` (0–359) | Min facing-angle delta; 0 = no check. |
| `futurePredictTime` | `float` | Lead-target prediction time (velocity×time). |
| `randomSpread` | `float` | Random world-unit offset on target point. |
| `keepDistance` | `float` | Desired distance to hold while casting. |
| `flipDirection` | `bool` | Cast toward opposite of target. |
| `doOnTick` | `bool` | Set command pos once on enter vs every tick. |
| `extraCd` | `float` (≥0) | Extra global cooldown after this cast. |

Consumed by `NpcAbilityTriggerSubroutine` / `NpcCastAbilitySubroutine` and the
~40 `Npc*Ability` classes.

---

## 10. Why the previous clone/graft approach failed (mapped to this model)

| Observed bug | Root cause in the data model |
|---|---|
| Custom char/attacks invisible to others | `spellPrefab` hitboxes are `NetworkBehaviour`s; if not registered as Mirror spawnables and spawned server-side, they exist only locally. The clone never added real networked `Ability` components. |
| Despawns / frozen poses (Standbilder) | No `Ability` FSM (`SimulationFsm`) and no networked subroutines, so there is no `Casting/Active/Cooldown` progression to sync; the char has no driving state, and animation never advances past a pose. |
| Only LMB works | LMB = `cmdId = Ability1`. Only slot 1 was (accidentally) bound; slots `Ability2/3/4` had no `Ability` component with the matching `cmdId` (`Ability.cs:17`). |
| RMB → only a green dot | No `Ability` for that slot → only an indicator/cursor stub renders; no `CastSubroutine`/hitbox runs. (Also note slot-2 is `Q` per `Ability.cs:14`, so the input mapping assumption was wrong.) |
| Space bugs out | `Ability3` slot had no valid FSM/subroutine; state transitions never resolve. |
| E plays Kitsu's animation | The custom ability reused the base char's `CharAnimator`/AnimatorController instead of supplying its own clips on the correct `AnimLayerIndices animLayer`. |

---

## 11. Schema summary (for a from-scratch, networked custom ability)

A correct custom ability must provide **all** of:

1. **An `Ability` subclass** (`: Ability : NetworkBehaviour`) as a **component on the
   character prefab**, with:
   - `cmdId` set to the target slot (`Ability1..Ability4` → LMB/Q/Space/E).
   - General/Mechanics fields (`autoCancel`, `priority`, `inputBufferDuration`,
     `silenceable`, `cancelable`, `usableOnDowned`, `enableCritDmg`, `maxTimeDilation`).
2. **A networked hitbox/projectile prefab** (`HitboxBase`/`Hitbox` `NetworkBehaviour`)
   referenced via `spellPrefab`, **registered as a Mirror spawnable (assetId)**, spawned
   server-side.
3. **Combat data:** `damage`, `damageScaling`, `speed`/`hitboxRadius`, `ttl`,
   `statusEffects` (`List<StatusEffectInfo>` → `StatusEffectSO`), `knockbackIntensity`,
   `hitStopDuration`.
4. **Timing:** `castingTime`, `recoveryTime`, `baseCooldownTime`
   (+ optional `startCooldownTime`).
5. **An FSM** built in `PreAwake` via `SimulationFsm.Builder`, wiring `CastSubroutine`
   + `CooldownSubroutine` + ability-specific `NetworkedSimulationSubroutine`s, with
   transitions matching `AbilityStates`.
6. **Animation** routed through `CharAnimator` on a chosen `AnimLayerIndices animLayer`
   (own clips, not the base char's), and **VFX (`GameObject` prefabs) / SFX
   (`FMOD EventReference`)** triggered from the subroutines.
7. **UI:** either a `UICharactersConfiguration.AbilityData` slot (icon + loc keys) or
   per-ability `useCustomUIData` + `customUIData`.
8. **Net sync:** implement `OnNetSerialize/OnNetDeserialize` on the ability and any
   networked subroutine so the cast/cooldown state predicts & reconciles correctly.
9. **Server hit handling:** override `[Server] OnTargetHit/OnTargetKill/OnHitboxDestroy`.

Item/consumable abilities (slots ≥ 4) may instead be authored as `AbilityBehaviourSO`
data assets returning `AbilityBehaviour` instances.

---

### Primary sources (file:line)
- `Entities\Ability.cs:12` (class), `:14-17` (cmdId/slot tooltip), `:20-32` (UI),
  `:37-49`+ (mechanics), `[NonSerialized]` refs + subroutine handles, `[Server]` hit hooks.
- `Entities\AbilityBehaviour.cs` (config + lifecycle), `Entities\AbilityBehaviourSO.cs`
  (CreateAssetMenu factory).
- `Entities\AbilityStates.cs` (6-state enum), `Entities\AbilityTriggerData.cs` (NPC AI).
- `Entities\CharAbilities.cs:12` (container), `:14` (`CONSTANT_ITEM_OFFSET=4`),
  `Ability[] abilities`, `CastFlags`, RPCs.
- `Local\CommandId.cs`, `Local\InputType.cs`, `Entities\CastFlags.cs`,
  `Entities\MotionLockType.cs`, `Entities\AnimLayerIndices.cs`, `Entities\StatusEffectInfo.cs`.
- `Entities\CastSubroutine.cs`, `Entities\CooldownSubroutine.cs`,
  `Network\SimulationFsm.cs`, `Network\SimulationSubroutine.cs`,
  `Network\NetworkedSimulationSubroutine.cs`.
- `Entities\HitboxBase.cs:11`, `Entities\Hitbox.cs:12` (networked hitbox prefab).
- `UI\UICharactersConfiguration.cs` (`AbilityData`, `mainAbilityNum=4`, `ability1..4`).
- Concrete examples: `Entities\ArrowAbility.cs` (`:28,31,37,46,69,72,75,78,81,84`),
  `Entities\FireMeteoriteAbility.cs`, `Entities\KatanaMeleeAbility.cs`,
  `Entities\CatJumpAbility.cs`.
- Failed-approach contrast: `BAPBAPModdingAPI\bapcustomchars-mod\CustomCharFramework.cs`.

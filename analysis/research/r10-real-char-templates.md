# R10 — Real Shipped-Character Ability Templates (Kitsu, Eve, Chuck)

Stage R10 of the BAPBAP custom-character/ability research. This document reverse-engineers
EXACTLY how three shipped characters implement their four abilities, so a new character can be
built by following the same data/asset pattern instead of the failed clone-and-graft approach.

Sources read (all paths real, all citations verified):
- Decompiled C#: `C:\Users\Administrator\Downloads\neueBapbap\GameCode\ExportedProject\_DisabledScripts\Assembly-CSharp\BAPBAP\Entities\*.cs`
- Prefabs / colliders: `...\ExportedProject\Assets\GameObject\*.prefab`
- Config SO: `...\ExportedProject\Assets\MonoBehaviour\UICharactersConfiguration.asset`
- CharacterConfiguration type: `...\Assembly-CSharp\BAPBAP\UI\UICharactersConfiguration.cs`

---

## 0. CRITICAL EXPORT LIMITATION (read first — affects every number below)

This is an **AssetRipper export with a stub `Assembly-CSharp`**. Two consequences that the
synthesis stage MUST account for:

1. **All decompiled method bodies are stripped.** Every `.cs` here is a *header*: fields,
   signatures and attributes are real, but bodies return `null`/`0`/`{}`. Example —
   `Ability.cs` `public void SetState(AbilityStates _state) { }`. So the field *schema* is
   authoritative; the runtime *logic* is not in these files.

2. **All `MonoBehaviour` / `ScriptableObject` serialized field values are stripped from the
   exported assets.** Verified on three asset types:
   - Character prefab ability components (`Kitsu.prefab` lines 1781–1838): each ability
     `MonoBehaviour` block ends at `m_EditorClassIdentifier:` with **no field data**.
   - Hitbox prefab gameplay components (`Hitbox_Kitsu_EnergyArrow.prefab` MonoBehaviours
     `114099118695303065`, `114243736805655561`, etc.): same — script ref only.
   - `UICharactersConfiguration.asset`: ends at `m_EditorClassIdentifier:` with **no
     `_characters` array** at all.

   What *survived* the export and IS authoritative:
   - GameObject hierarchy + component lists (which scripts are attached, in what order).
   - Native Unity components with their values: `Transform`, `Rigidbody`, **all `Collider`
     sizes/radii/centers**, `Animator`, `MeshFilter`, `Renderer`.
   - A handful of FMOD audio components that kept their event GUIDs (e.g. `AudioPlayFmod`
     `_impactEvent` on `Hitbox_Kitsu_EnergyArrow`).

**Therefore:** the exact balance values (`damage`, `baseCooldownTime`, `castingTime`,
status-effect durations) and the `cmdId` slot bindings and the `spellPrefab → hitbox` links
are **NOT recoverable from this export**. They live on the (stripped) Ability `MonoBehaviour`s.
To capture them you must read the **live IL2CPP game** (global-metadata.dat field defaults are
zero; the real values come from the shipped serialized prefab data inside the AssetBundles /
`level`/`resources` files, or by dumping them at runtime through the mod API with
`il2cpp` field reflection on a loaded `CharacterConfiguration` / Ability instance).

Everything below is split into **(A) authoritative from export** and **(B) inferred** (with the
evidence chain) so the synthesis stage knows exactly how much to trust each item.

---

## 1. The ability system architecture (the actual "template")

This is the part that matters most for "easy to add new chars AND new abilities, fully
networked." It is fully authoritative — derived from the field schema + component composition.

### 1.1 Component stack of a playable character prefab

A character is a single networked prefab (`Kitsu.prefab`, `Eve.prefab`, `Chuck.prefab`) that is
registered by **`charId` = its index in `GameNetworkManager.characterPrefabsByCharId[]`**
(see `BAPBAP\Network\GameNetworkManager.cs`; the failed Medusa mod also resolved char prefabs by
this array). On the root GameObject the prefab carries the shared `Char*` component suite plus
**one `Ability`-derived `MonoBehaviour` per ability slot**:

- `CharAbilities` (`BAPBAP\Entities\CharAbilities.cs`) — the per-character ability manager.
  - `Ability[] abilities` (`[NonSerialized]`, populated at runtime from the attached `Ability`
    components), plus `abilitiesByPriority`, `abilitiesWithAutoCancel`.
  - Stat fields: `damage`, `attackSpeed`, `cooldown`, `critChance`, `critDmg`, `lifesteal`,
    `maxAttackSpeed`, `damageMultiplier`, `damageToPlayersMultiplier` (all `[NonSerialized]`,
    set at runtime). `baseCritDmg`, `baseCritChance`, `baseLifeSteal`, `maxAttackSpeed` are the
    only `[SerializeField]` stat seeds.
  - `CastFlags castFlags` — bitmask of which slots are currently casting.
  - Drives input → cast: `SetCastAbility(CastFlags)`, `OnAbilityCast(CommandId)`,
    `[Server] SvOnAbilityTriggered(CommandId)`, `[ClientRpc] RpcCastResult(bool)`,
    `[ClientRpc] RpcAbilityReady(int cmdId)`.
  - Implements `INetworkPredicted` → `OnTick(float fixedDt, Command cmd, bool isResim)` plus
    `OnNetSerialize`/`OnNetDeserialize`. **This is the prediction/rollback hook every ability
    runs inside.**
- Supporting char components referenced by every `Ability` (see the `[NonSerialized]` block in
  `Ability.cs`): `EntityManager`, `CharSimulation`, `CharPassives`, `EntityMovement` (`charMove`),
  `CharAim`, `CharAnimator`, `CharHurtbox`, `CharTriggerbox`, `CharEvents`, `CharFX`, `CharItems`,
  `CharHidden`, `CharMaterial`, `CharStatusEffects`, `CharVoicelines`, `CharDowned`, plus the
  global `VfxManager`, `AudioManager`, `StatusEffectManager`, and the `SimulationFsm fsm`.

### 1.2 The `Ability` base class (`BAPBAP\Entities\Ability.cs`)

`public class Ability : NetworkBehaviour`. Every char ability derives from this. Authoritative
serialized fields (the contract for ALL abilities):

```
[Header("General")]
CommandId cmdId;                  // LMB=Ability1, Q=Ability2, Space=Ability3, E=Ability4  *** SLOT BINDING ***
bool      useCustomUIData;        // when true, UI text/colour comes from customUIData instead of CharacterConfiguration
UICharactersConfiguration.CharacterConfiguration.AbilityData customUIData;
Color     customUIIconColor, customUITitleColor;
[Header("Mechanics")]
bool  autoCancel;  int priority;  float inputBufferDuration;  float canceledTime;
bool  silenceable; bool cancelable; bool usableOnDowned; bool enableCritDmg; float maxTimeDilation;
```

The tooltip `cmdId` comment is the authoritative slot rule:
`LMB = Ability1, Q = Ability2, Space = Ability3, E = Ability4`.

Key virtual hooks (bodies stripped, but the surface defines the lifecycle a new ability must
implement):
- `PreAwake(EntityManager)` — wire-up; every concrete ability overrides this.
- `Tick(float fixedDt, Command cmd, bool isResim)` — deterministic per-tick logic (resim-safe).
- `ClStartAuth()` / `ClStopAuth()` — client authority start/stop.
- `LoadAbilityUI()` — pushes icon/title/desc to the HUD.
- State machine: `SetState(AbilityStates)`, `state`, `dilatedTime`, `castSubroutine`,
  `cooldownSubroutine`, `startCdSubroutine` (a `CastSubroutine` + two `CooldownSubroutine`s).
- Server hit callbacks: `[Server] OnTargetHit(EntityManager, HitboxBase)`,
  `[Server] OnTargetKill(EntityManager)`, `[Server] OnWallHit(GameObject)`,
  `[Server] OnOtherHitboxHit(Hitbox, HitboxBase)`, `[Server] OnHitboxDestroy(HitboxBase)`.
- Tooltip builders: `GetTooltipDescription`, `GetTooltipExpandedDescription`,
  `GetTooltipScaledDamage(int baseDamage, float damageScaling)`, `GetTooltipScaledCooldownStat`,
  `GetTooltipStatusEffect(StatusEffectSO)`.

**Networking model (why the failed graft despawned / was local-only):** abilities are
`NetworkBehaviour`s that run inside a **predicted simulation** (`CharAbilities : INetworkPredicted`,
`SimulationFsm`, `SimulationSubroutine`, `Command`, `isResim`). Damage is applied **server-side**
through `[Server] OnTargetHit` / `HitboxBase` on a `NetworkServer.Spawn`-ed hitbox. A custom char
that only ran ability visuals on the local client (the failed approach) produced no server-spawned
hitbox and no replicated state → invisible to others, no real damage, and despawn when the
unmanaged clone fell out of the predicted set.

### 1.3 `AbilityBehaviourSO` (`BAPBAP\Entities\AbilityBehaviourSO.cs`)

```
[CreateAssetMenu(menuName = "BAPBAP/AbilityBehaviours/AbilityBehaviourSO")]
public class AbilityBehaviourSO : ScriptableObject {
    [NonSerialized] int id;
    virtual AbilityBehaviour.AbilityBehaviourConfig config => null;
    virtual AbilityBehaviour NewInstance(EntityManager _entityManager) => null;
}
```
**Important distinction:** the *character* abilities (Kitsu/Eve/Chuck) do **not** use
`AbilityBehaviourSO`. They are concrete `Ability` subclasses compiled into the game (e.g.
`ArrowAbility`), attached directly to the char prefab. `AbilityBehaviourSO`/`AB_*_SO` (e.g.
`AB_Sniper_SO`, `AB_Jetpack_SO`, `AB_BloodDive_SO`, `AB_Throwable_SO`) are the **item / consumable
/ loot-ability** data-objects — a separate, data-driven ability pipeline used for the 4 item
slots (`CharAbilities.CONSTANT_ITEM_OFFSET = 4`). A new *character* follows the compiled-subclass
pattern; a new *pickup/consumable* ability follows the `AbilityBehaviourSO` pattern.

### 1.4 The hitbox template (`HitboxBase` / `Hitbox`) — the most reusable finding

`BAPBAP\Entities\HitboxBase.cs` (`public class HitboxBase : NetworkBehaviour, IPoolDespawnListener`).
**Almost every gameplay field is `[NonSerialized]`** — i.e. the hitbox prefab stores none of them;
the casting Ability injects them at spawn time:

`[NonSerialized]` (Ability-injected at runtime): `damage`, `ttl`, `doTtl`, `knockbackIntensity`,
`hitStopDuration`, `hitShakeTrauma`/`hurtShakeTrauma`/`impactShakeTrauma`, `isCriticalDamage`,
`damageToPlayersMultiplier`, `_statusEffects` (`List<StatusEffectInfo>`), `_passives`,
`destroyOnCharHit`, `destroyOnObstacleHit`, `onlyApplyHitOncePerChar`, `ignoreObstacles`, `ability`
(back-ref to the casting `Ability`), `ownerPlayerId`/`teamId` (`[SyncVar]`), `projMove`, `vfxSpawn`,
`audioPlayFmod`.

The only `[SerializeField]` (so the only thing the prefab actually defines about hit rules):
`allowHitToEnemies`, `allowHitToTeam`, `allowHitToOwnerPlayer`, `rendererObj`.

Hit pipeline: `OnHitSuccess(EntityManager)` → `[Server] DestroyHitbox(...)` →
`[ClientRpc] RpcDestroyHitbox` / `RpcOnHitboxImpact`. `CanHitEntity(otherTeamId, otherPlayerId)`
gates friendly fire using the three serialized `allowHit*` flags. `OnHitSuccessAction` /
`OnKillAction` are the `Action` hooks the Ability subscribes to (this is exactly where the failed
Medusa mod injected poison/petrify via a `HitboxBase.OnHitSuccess` Harmony patch — see
`MedusaMod.HitboxDoEntityHitPetrifyPatch`).

**Standard hitbox prefab composition** (verified on `Hitbox_Kitsu_EnergyArrow.prefab`, the
canonical projectile template). Component list, in order, with resolved script GUIDs:

| Component | GUID / fileID | Role |
|---|---|---|
| `Transform` | — | identity at origin |
| (Mirror) NetworkIdentity | `f5de03243f0810025e7802b3b315681e` (fileID `860895539`) | network spawn identity |
| (Mirror) network behaviour | `0f09b8ddd7de68d6cd0e3586a033fe56` (fileID `-1510866737`) | replicated transform/behaviour |
| `Rigidbody` | — | `m_IsKinematic: 1`, `m_UseGravity: 0` (driven by ProjectileMove, not physics) |
| `BoxCollider` | — | `m_IsTrigger: 1`, `m_Size {0.6, 0.5, 2.5}`, `m_Center {0,0,-0.1}` — **the real Kitsu arrow hit volume** |
| `ProjectileMove` | `a16fd113c555887493f95186c1d8bafd` | forward travel (speed/ttl injected by Ability) |
| `Hitbox` | `69b6e79c7f5a8fea5fc93cd119a0c3cd` | concrete `HitboxBase` subclass (damage/SE applier) |
| `TriggerPhysicsForceAreaHitbox` | `0c910e0475b77466ec2355d0698b301c` | physics-prop knockback |
| `VFXSpawn` | `e9ad1bd7dca67e9a93a618e00e5d2e37` | spawn/impact/destroy VFX |
| `AudioPlayFmod` | `5de9ec202ac2625f47c08f8fce084170` | FMOD impact SFX (kept `_impactEvent` GUID in export) |

- Layer `14` ("Hitbox"), `m_TagString: Hitbox`. **A new char's hitbox prefab must reproduce this
  exact stack** (NetworkIdentity + Hitbox(HitboxBase) + ProjectileMove + VFXSpawn + collider on
  layer 14), and must be registered in the Mirror spawn list (`NetworkManager.spawnPrefabs` /
  `NetworkPrefabLibrary.PooledPrefabs` — exactly what `MedusaMod.TryRegisterNetworkPrefabPool`
  attempted) or it cannot replicate.

### 1.5 Animation

Every concrete ability has `[SerializeField] AnimLayerIndices animLayer;` (an enum naming which
Animator layer the cast plays on). Char animation is driven through `CharAnimator` (root) using the
character's own `AnimatorController` (`Assets\AnimatorController\<Char>.controller`, e.g.
`Kitsu.controller`, `Blitz.controller`; Eve uses the `Eve_Anim_v04Avatar` rig). The cast
subroutines play named states (the failed mod cross-faded `"Ability1".."Ability4"` — those are the
state-name convention). **A custom char must ship its own AnimatorController whose states match the
cast triggers, or animations fall back to the base char (the "E plays Kitsu's animation" /
"Standbild/frozen pose" symptoms came from grafting a foreign visual onto Kitsu's controller).**

### 1.6 `CharacterConfiguration` (UI/identity, `BAPBAP\UI\UICharactersConfiguration.cs`)

`UICharactersConfiguration` is a `ScriptableObject` holding `CharacterConfiguration[] _characters`.
Per-character fields (all real in the type; values stripped from the `.asset`):

```
string name;                         // internal roster name ("Kitsu","Eve","Chuck")
string descriptionTranslationKey;    // loc key
CharacterDetailedInfo detailedInfo;  // VoiceActorName + LorePassageKey
int    charId;                       // MUST match GameNetworkManager.characterPrefabsByCharId index
bool   enabledInLobby, enabledInDevLobby;
Color  Color, UIAccentColor;
Sprite LobbyBackground, FullSprite, MediumSprite, StandingSprite, IconSprite,
       smallSprite, CircleIcon, SquareIcon, SquareSmallIcon;
SpriteTransformModifier gameStatsLobbySpriteModifier;
SkinSO DefaultSkin;
Color  abilityIconColor, abilityBGColor, titleTextColor;   // ability HUD palette
AbilityData ability1, ability2, ability3, ability4;        // one per slot, LMB/Q/Space/E order
```

`AbilityData` = `{ Sprite icon; string titleKey; string shortDescriptionKey; string descriptionKey; }`.
So the **lobby/HUD ability presentation is data (icon + 3 loc keys) per slot**, while the **gameplay
is the compiled `Ability` subclass on the prefab**. `mainAbilityNum = 4`. Lookups:
`TryGetCharConfigByCharId`, `GetLobbyCharIndexFromCharId`. This is the asset the failed Medusa mod
cloned + appended to (`MedusaMod.CloneConfig` filled `ability1..4` via `MakeAbility(...)` with loc
keys) — that part of the approach (registering a new `CharacterConfiguration`) was correct; what
failed was the gameplay/visual/network side.

---

## 2. KITSU — charId 0 (ranged fox archer)

`Kitsu.prefab`. Four `Ability` components, prefab order matches slot order here:

| Slot | Input | Ability class | GUID | Prefab line |
|---|---|---|---|---|
| ability1 | LMB | `ArrowAbility` | `d011ae7aa58b6b5b9328a79d72b26a23` | 1790 |
| ability2 | Q | `ChargedArrowsAbility` | `9643af0f2c919d3359db8d700f88b803` | 1802 |
| ability3 | Space | `RecoilArrowAbility` | `14007e81836150ec447b3e1251b9613c` | 1814 |
| ability4 | E (ult) | `ArrowMissileAbility` | `54cd188d16c4433c03b8ba3768d2e4ce` | 1826 |

*(A) authoritative: the four classes are attached to `Kitsu.prefab`. (B) inferred: the LMB/Q/Space/E
binding — `cmdId` is stripped, but it is corroborated by (i) class semantics below, (ii) prefab
component order, and (iii) the failed Medusa mod patching exactly these four as Kitsu's slots.)*

### 2.1 LMB — `ArrowAbility` (basic arrow)
`BAPBAP\Entities\ArrowAbility.cs`. Serialized schema (the per-instance values to set):
- General: `GameObject spellPrefab` (→ the arrow hitbox), `Transform firingPoint`, `float spread`,
  `MotionLockType castMotionLockType`, `bool applyAtkSpeedMultiplier`, `bool applyCooldownMultiplier`,
  `InputType inputType`.
- Augment hooks: `P_CharAugment_ScatterShot_SO` ×3, `P_CharAugment_Kitsu_TrilunarBarrage_SO`,
  `P_CharAugment_BlindShot_SO`, `P_CharAugment_SplitProjectile_SO`.
- Hitbox-related: `int damage`, `float damageScaling`, `float speed`, `float ttl`,
  `List<StatusEffectInfo> statusEffects`, `float knockbackIntensity`, `float hitStopDuration`.
- State: `float castingTime`, `float recoveryTime`, `float baseCooldownTime`.
- FX: `float camKickPower`, `float camShakeOnHitTrauma`, `GameObject vfxMuzzlePrefab`,
  `EventReference sfxCast`, `AnimLayerIndices animLayer`.
- Logic: `Shoot(Vector3 spawnPosition, Vector3 lookDir, int predTickNum)` + nested
  `CustomShootSubroutine : SimulationSubroutine` (the deterministic per-tick shoot step).
- **Referenced prefabs (by name):** `Hitbox_Kitsu_EnergyArrow` (+ skin variant
  `Hitbox_Kitsu_EnergyArrow_Skin_KitSus`); impact VFX `VFX_Kitsu_Lmb_Impact_Fail`. Hit volume:
  BoxCollider `{0.6, 0.5, 2.5}` trigger, layer 14 (from §1.4).

### 2.2 Q — `ChargedArrowsAbility` (ground-targeted charged volley / DoT zone)
`BAPBAP\Entities\ChargedArrowsAbility.cs`. Distinctive fields prove this is the indicator-targeted
AoE: `float abilityRadius`, `GameObject indicatorPrefab` + `indicatorHalfScale`/`indicatorBaseHalfScale`/
`indicatorOffset`/`indicatorMaxDistance`, `float damageRate` (damage-per-second cadence → DoT),
`float hitboxRadius`, `float hitboxActivateTime`, plus `int damage`, `damageScaling`, `speed`, `ttl`,
`List<StatusEffectInfo> statusEffects`, `castingTime`/`recoveryTime`/`baseCooldownTime`,
`GameObject vfxCastPrefab`, `EventReference sfxCast`, voiceline configs, `AnimLayerIndices animLayer`.
Augments: `P_CharAugment_Kitsu_TrilunarBarrage_SO P_TRILUNAR_BARRAGE`, `PassiveSO P_Pulse_Increase`.
- Logic: `Shoot(Vector3 landingPos, int predTickNum)` (ground target), `SetAugmentTrilunarEnabled`,
  `MouseIndicatorSubroutine mouseIndicatorSubroutine`.
- **Referenced prefabs:** `Hitbox_Kitsu_ArrowVolley`, trail `Hitbox_Kitsu_ArrowMissile_Trail_Volley`.

### 2.3 Space — `RecoilArrowAbility` (mobility: shoot-down + float/jump + brief invis)
`BAPBAP\Entities\RecoilArrowAbility.cs`. Mobility/utility — four nested subroutines:
`CustomJumpSubroutine`, `CustomShootSubroutine`, `CustomFloatSubroutine` (networked),
`CustomInvisibilitySubroutine` (networked, holds a `sprintSE` `StatusEffect`). Fields: `spellPrefab`,
`firingPoint`, `castMotionLockType`, `RotationLockType jumpRotationLockType`, augments
`PassiveSO P_KITSU_REPEL`/`float minFloatDistanceMult`/`P_CharAugment_Kitsu_Vanish_SO P_KITSU_VANISH`,
hitbox (`int damage`, `damageScaling`, `ttl`, `float hitboxRadius`, `statusEffects`), state
(`castingTime`, `jumpTime`, `floatTime`, `recoveryTime`, `baseCooldownTime`), movement
(`AnimationCurve jumpLerpCurve`, `baseShadowAlphaCurve`, `float jumpDistance`, `jumpRadiusCheck`),
camera (`camShakeTrauma`/`camShakeOnHitTrauma`/`camShakeOnHurtTrauma`/`zoomOutMultiplier`), VFX
(`vfxJumpPrefab`, `vfxLandPrefab`), `sfxCast`, voiceline, `animLayer`. Logic:
`Shoot(Vector3 lookDir, int predTickNum)`.
- **Referenced prefab:** recoil hit `Hitbox_Kitsu_EnergyBlastRecoil_Skin_KitSus`.

### 2.4 E (ult) — `ArrowMissileAbility` (homing energy-arrow missile)
`BAPBAP\Entities\ArrowMissileAbility.cs`. Marked as ult by `float startCooldownTime` (starts on
cooldown) + heavy camera (`zoomOutMultiplier`, `camShakeTrauma`, `castVisibilityRadius`) + FoW
subroutine `CustomApplyFoWRadiusSubroutine`. Fields: `spellPrefab`, `firingPoint`,
`castMotionLockType`, `RotationLockType castRotationLockType`, augment
`P_CharAugment_Kitsu_UltTrail_SO P_ARROW_TRAIL`, indicator set, hitbox (`int damage`, `damageScaling`,
`speed`, `ttl`, `hitStopDuration`, `statusEffects`), state (`castingTime`, `recoveryTime`,
`baseCooldownTime`, `startCooldownTime`), VFX (`vfxCastPrefab`, `vfxMuzzlePrefab`), SFX
(`sfxCast`, `sfxCastEnemy`, `sfxTargetHit`), voicelines (cast/hit/kill), `animLayer`. Logic:
`Shoot(Vector3 lookDir, int predTickNum)`, `[Server] OnTargetHit(...)`, `[ClientRpc]
RpcOnTargetHit(Vector3)`, `OnTargetKill(...)`.
- **Referenced prefabs:** `Hitbox_Kitsu_ArrowMissile` (+ `_Trail`, skin `_Skin_KitSus`),
  trail `Hitbox_Kitsu_ArrowMissile_Trail`.

---

## 3. EVE — ice ranged (ice shards / freeze / ice block)

`Eve.prefab`. **Prefab component order ≠ slot order** (verified): the four ability blocks appear as
`EveShardAbility, EveSteadyShot, EveIceBlockAbility, EveFreezeAbility` (lines 2225/2237/2249/2261),
but the *gameplay* slot binding (from class semantics + hitbox/VFX naming) is:

| Slot | Input | Ability class | GUID | Prefab line |
|---|---|---|---|---|
| ability1 | LMB | `EveSteadyShot` | `ce90ca51a76baf76cd6a688d7f3ba8c2` | 2237 |
| ability2 | Q | `EveShardAbility` | `3fb2f972533c7a8abe579e371821e09b` | 2225 |
| ability3 | Space | `EveIceBlockAbility` | `073bd5a166de813daa4faa4bfcb36a06` | 2249 |
| ability4 | E (ult) | `EveFreezeAbility` | `f60d7481b0766c546b62200ddde39b71` | 2261 |

*(A) authoritative: the four classes are on `Eve.prefab`. (B) inferred slot order — `cmdId` stripped;
strongest single proof that prefab order is NOT slot order, so do not assume order==slot for a new
char. Mapping evidence is given per ability.)*

### 3.1 LMB — `EveSteadyShot` (basic shot with "steady aim")
`BAPBAP\Entities\EveSteadyShot.cs`. Basic-attack markers: `applyAtkSpeedMultiplier`, the
`SetSteadyShot(bool on, float indicatorIncrease)` channel/aim method, directional indicator
subroutine. Fields: `spellPrefab`, `firingPoint`, `spread`, `castMotionLockType`,
`applyAtkSpeedMultiplier`, `applyCooldownMultiplier`, `inputType`; hitbox `int damage`,
`damageScaling`, `speed`, `ttl`, `statusEffects`, `knockbackIntensity`; state `castingTime`/
`recoveryTime`/`baseCooldownTime`; indicator `indicatorPrefab`/`indicatorHalfScale`/`indicatorOffset`/
`indicatorDoCollision`/`indicatorClampToMouse`; FX `camKickPower`/`camShakeOnHitTrauma`/
`camShakeOnHurtTrauma`, `GameObject vfxCastPrefab`, `EventReference castSfx`, voiceline cast/kill,
`animLayer`. Logic: `Shoot(Vector3 lookDir, int predTickNum)`, `OnTargetKill`,
`DirectionalIndicatorSubroutine directionalIndicatorSubroutine`.
- **Referenced prefabs:** `Hitbox_Eve_SteadyShot` — hit volume BoxCollider `m_Size {0.5,
  1.0394876, 2.5}`, `m_Center {0,-0.26974,-0.1}`, trigger, layer 14. VFX `VFX_Eve_SteadyShot_Muzzle/
  _Cast/_Impact/_Impact_Fail` (+ `_Cast_Skin_Goth`).

### 3.2 Q — `EveShardAbility` (ice shard that shatters into fragments)
`BAPBAP\Entities\EveShardAbility.cs`. Two-stage projectile: a primary shot + spawned **shards**.
Distinctive: `GameObject shardSpellPrefab`, a whole "Shard Hitbox" block (`int shardDamage`,
`shardDmgScaling`, `shardTtl`, `shardSpeed`, `shardRadius`, `shardTargetRadius`, `shardExpandDuration`,
`List<StatusEffectInfo> shardStatusEffects`), plus the primary `damage`/`damageScaling`/`speed`/`ttl`/
`dmgScaling`/`statusEffects`/`knockbackIntensity`. State `castingTime`/`recoveryTime`/`baseCooldownTime`,
`vfx` via subroutines, `animLayer`. Logic: `Shoot(Vector3 lookDir, int predTickNum)`,
`SpawnShard(Transform spawnTr, int playerId, int teamId, GameObject otherChar, bool isCrit)`,
`[Server] OnOtherHitboxHit(Hitbox, HitboxBase)` (shatter-on-collision), `[Server]
OnHitSuccess(EntityManager, HitboxBase)`. Nested `CustomAnimSubroutine` + `CustomShootSubroutine`.
- **Referenced prefabs:** `Hitbox_Eve_Blast` (primary) + `Hitbox_Eve_Blast_Explosion` (shards) (+
  skin `Hitbox_Eve_Blast_Skin_Goth`). VFX `VFX_Eve_Shard_Muzzle/_Trail/_Impact/_Impact_Fail/
  _Explosion`.

### 3.3 Space — `EveIceBlockAbility` (defensive ice-block shield + DPS zone)
`BAPBAP\Entities\EveIceBlockAbility.cs`. The most complex (five nested subroutines:
`CustomCastSubroutine`, `CustomBlockStartSubroutine`, `CustomBlockEndSubroutine`,
`CustomBlockDestroySubroutine`, `CustomAugmentSlideSubroutine`). Defensive markers: `bool
blockCancelable`, `float minShieldTime`/`shieldTime`, `[SyncVar] GameObject blockObstacle`
(networked spawned wall) with hook `OnBlockObstacleChanged` + `NetworkblockObstacle` property +
`SerializeSyncVars`/`DeserializeSyncVars`. Fields: prefabs `hitPrefab`/`dpsPrefab`/`iceBlockPrefab`,
`castMotionLockType`/`castRotationLockType`, `float impulseVel`/`impulseDecel`, augments
`P_CharAugment_Eve_FreezingHeal_SO`/`IceBlockSlide`/`ExplosiveIceBlock`; hitbox `int damage`,
`damageRate` (DoT), `damageScaling`, `ttl`, `knockbackIntensity`, `expandDuration`,
`expandTargetScale`, `statusEffects`, `obstacleActivationTime`, `dpsBonusTtl`; state `castingTime`/
`minShieldTime`/`shieldTime`/`recoveryTime`/`recoveryTime2`/`baseCooldownTime`; FX `camShakeTrauma`/
`camShakeOnHitTrauma`/`camShakeOnHurtTrauma`/`zoomOutMultiplier`; VFX `vfxCastPrefab`/`vfxLoopPrefab`/
`vfxLoopAttachTransform`/`vfxEndPrefab`; SFX `castSfx`/`endSfx` + voicelines; `animLayer`. Logic:
`Shoot(int predTickNum)`, `DestroyBlock()`, `SetBlockCollisionIgnore(GameObject, bool)`.
- **Referenced prefabs:** `Eve_Ice_Block` (the spawned obstacle), `Hitbox_Eve_Block` (sphere
  `m_Radius 1`, trigger, layer 14), `Hitbox_Eve_Block_Zone` (DPS zone). VFX `VFX_Eve_Block/_Cast/
  _AOE/_AOE_Base/_AOE_Enemy/_end` (+ `_Cast_Skin_Goth`).

### 3.4 E (ult) — `EveFreezeAbility` (ground-targeted AoE freeze field)
`BAPBAP\Entities\EveFreezeAbility.cs`. Ult markers: ground-target via indicator + `float
indicatorMaxDistance`, DoT (`int damage`, `float damageRate`), dedicated status SO
`SE_EveFrozen_SO SE_EveFrozen`, augment `P_CharAugment_Eve_FreezingHeal_SO AugmentFrozenHeal`.
Fields: `spellPrefab`, `castMotionLockType`, `applyAtkSpeedMultiplier`/`applyCooldownMultiplier`,
`inputType`, `float abilityRadius`; indicator `indicatorPrefab`/`indicatorHalfScale`/
`indicatorBaseHalfScale`/`indicatorOffset`/`indicatorMaxDistance`/`indicatorDoCollision`/
`indicatorClampToMouse`; hitbox `damage`/`damageRate`/`damageScaling`/`ttl`/`hitboxRadius`/
`hitboxActivateTime`/`statusEffects`; state `castingTime`/`recoveryTime`/`baseCooldownTime`; FX
`camShakeOnHitTrauma`/`camShakeOnHurtTrauma`, `GameObject vfxId`, `castSfx` + voicelines, `animLayer`.
Logic: `Shoot(Vector3 landingPos, int predTickNum)`, `OnTargetKill`, custom DoT tooltip
`GetTooltipScaledDamagePerSecondEve(...)`.
- **Referenced prefabs:** `Hitbox_Eve_Freeze` (sphere `m_Radius 1`, trigger, layer 14). VFX
  `VFX_Eve_Freeze_Spawn/_Cast/_Enemy/_Base_Ally` (+ `_Cast_Skin_Goth`). Status SO
  `SE_EveFrozen_SO` (in `BAPBAP\Entities\SE_EveFrozen_SO.cs`).

---

## 4. CHUCK — melee bruiser

`Chuck.prefab`. Four ability components, prefab order = slot order here:

| Slot | Input | Ability class | GUID | Prefab line |
|---|---|---|---|---|
| ability1 | LMB | `PunchSequenceAbility` | `df65c82e2f36142b8b29fe113d107ecd` | 1597 |
| ability2 | Q | `HeavyPunchAbility` | `dc799d7e95e944c5b232049ec5665f05` | 1609 |
| ability3 | Space | `JumpPoundAbility` | `6152e9bc941928405071a2fe9e27e174` | 1621 |
| ability4 | E (ult) | `RageAbility` | `f8effce72e029b5f5b811567adb1f6aa` | 1633 |

*(A) authoritative: classes on `Chuck.prefab`. (B) inferred slot order corroborated by class
semantics + `JumpPoundAbility` holding a `[NonSerialized] RageAbility rageAbility` back-reference
and `rage*` empowerment fields, which only makes sense if Rage is the ult that buffs the kit.)*

### 4.1 LMB — `PunchSequenceAbility` (3-hit melee combo)
`BAPBAP\Entities\PunchSequenceAbility.cs`. **Three distinct combo steps** in one ability:
`GameObject spellPunch1Prefab`/`spellPunch2Prefab`/`spellPunch3Prefab`, per-step damage/ttl
(`damage1`/`damage1Scaling`/`ttl1`, `damage2`/`damage2Scaling`/`ttl2`, `damage3`/`damage3Scaling`/
`ttl3`), per-step timing (`castingTime1`/`recoveryTime1`/`cooldownTime1`, `castingTime2`/
`recoveryTime2`/`cooldownTime2`, `castingTime3`/`recoveryTime3`), `baseCooldownTime`,
`float comboResetTime`, shared `statusEffects`/`knockbackIntensity`, `firingPoint`,
`castMotionLockType`, `vfxCast1Prefab`/`vfxCast2Prefab`, `sfxCast`, `animLayer`. Nested
`CustomShootSubroutine(PunchSequenceAbility, int attackId)`. Logic:
`DoPunch(Vector3 lookDir, GameObject spellPrefab, int damage, float damageScaling, float ttl, int
predTickNum)`, `[Server] OnTargetHit(...)`. Holds `[NonSerialized] HeavyPunchAbility heavyPunchAbility`
(combo → heavy-punch interplay).
- **Referenced prefabs:** `Hitbox_Chuck_Punch` for punches 1–2 (**SphereCollider `m_Radius 1.75`,
  `m_Center {0,0,-0.4}`, trigger, layer 14**); combo finisher shares `Hitbox_Chuck_HeavyPunch`. VFX
  `VFX_Chuck_Punch_Left`, `VFX_Chuck_Punch_Right_Skin_Tiger`.

### 4.2 Q — `HeavyPunchAbility` (chargeable/stacking heavy punch with slow)
`BAPBAP\Entities\HeavyPunchAbility.cs`. Stacking markers: `int maxStacks`, `bool doStacks`,
`int damagePerStack`/`float damagePerStackScaling`, `float slowPerStack`/`slowDuration`,
`float CDRPerPunch`, `List<StatusEffectInfo> maxStacksStatusEffects`, `public int stacks` +
`AddStack()`/`DisplayStacksUI()`/`OnStacksChanged()` + custom `OnNetSerialize`/`OnNetDeserialize`
(stacks are replicated). Base hitbox `int damage`/`damageScaling`/`ttl`/`statusEffects`/
`knockbackIntensity`/`hitStopDuration`; state `castingTime`/`recoveryTime`/`baseCooldownTime`;
indicator (`indicatorPrefab` + `followMouse`); FX `camShakeOnHitTrauma`/`camShakeOnHurtTrauma`,
`vfxCastPrefab`, `sfxCast`; `castRotationLockType`, `animLayer`. Logic:
`Shoot(Vector3 lookDir, int predTickNum)`, `ResetCooldown()`, ext trigger `EXT_TRIGGER_RESET`.
- **Referenced prefab:** `Hitbox_Chuck_HeavyPunch` (**BoxCollider `m_Size {2.1, 0.5, 3.25}`,
  `m_Center {0,0,-0.35}`, trigger, layer 14** — large frontal cone-ish box).

### 4.3 Space — `JumpPoundAbility` (targeted leap + ground-slam AoE)
`BAPBAP\Entities\JumpPoundAbility.cs`. Mobility+AoE — five nested subroutines
(`CustomAimConstraintSubroutine`, `CustomMouseIndicatorSubroutine` (networked),
`CustomDestroyVisibleIndicatorSubroutine`, `CustomJumpSubroutine` (networked)). Fields: `spellPrefab`,
`castMotionLockType`/`RotationLockType jumpRotationLockType`, augments
`P_CharAugment_Chuck_DuckyJump_SO`/`P_CharAugment_Chuck_Hug_SO`; hitbox `int damage`/`damageScaling`/
`ttl`/`statusEffects`/`float hitboxRadius`/`float rageHitboxRadiusIncrease`/`hitStopDuration`; state
`castingTime`/`jumpTime`/`recoveryTime`/`baseCooldownTime`; indicator set + `visibleIndicatorPrefab`/
`visibleIndicatorEnemyPrefab`; movement `AnimationCurve jumpLerpCurve`/`baseShadowAlphaCurve`,
`float jumpRadiusCheck`/`maxJumpDistance`/`rageMaxJumpDistance`; FX `camShakeTrauma`/`zoomOutMultiplier`;
`vfxCastingPrefab`, `sfxCast`, `animLayer`. Logic: `Shoot(Vector3 landingPosition, int predTickNum)`,
`[ClientRpc] RpcSpawnVisibleIndicator(Vector3,float)` / `RpcDestroyVisibleIndicator()`,
`SetChuckHug(...)`. **`[NonSerialized] RageAbility rageAbility`** + the `rage*` fields = Rage-ult
empowerment of this ability.
- **Referenced prefab:** `Hitbox_Chuck_JumpLandAoe` (**SphereCollider `m_Radius 2`, `m_Center
  {0,0,0}`, trigger, layer 14**; expanded by `rageHitboxRadiusIncrease` when Rage active).

### 4.4 E (ult) — `RageAbility` (self-buff, no projectile hitbox)
`BAPBAP\Entities\RageAbility.cs` (GUID `f8effce72e029b5f5b811567adb1f6aa`). A **buff ability** — it
spawns **no offensive hitbox prefab**; instead it flips a rage state that `JumpPoundAbility` reads
(`rageAbility`, `rageHitboxRadiusIncrease`, `rageMaxJumpDistance`) to enlarge/extend Chuck's kit.
This is the template for a non-projectile ult: state + stat/status modification rather than a
spawned `Hitbox`. (Body stripped; classification from the cross-references in `JumpPoundAbility`
and the absence of any `Hitbox_Chuck_Rage*` prefab.)

---

## 5. Concrete template a NEW character must follow (synthesis hand-off)

1. **Identity:** add a `CharacterConfiguration` entry (name, `charId` = its index, lobby sprites,
   ability palette, and 4 × `AbilityData{icon,titleKey,shortDescriptionKey,descriptionKey}`) to
   `UICharactersConfiguration._characters`.
2. **Prefab:** build a networked char prefab with the `Char*` suite + `CharAbilities` + **exactly
   four `Ability`-subclass components**, each with its `cmdId` set (LMB=Ability1, Q=Ability2,
   Space=Ability3, E=Ability4). Register the prefab at `GameNetworkManager.characterPrefabsByCharId[charId]`
   **and** in the Mirror spawn list.
3. **Per ability,** set the serialized contract from the base `Ability` (`cmdId`, mechanics flags)
   plus the subclass fields: `spellPrefab` (→ your hitbox), `firingPoint`, `damage`/`damageScaling`,
   `speed`/`ttl`, `List<StatusEffectInfo> statusEffects`, `knockbackIntensity`, `castingTime`/
   `recoveryTime`/`baseCooldownTime`, VFX prefabs, `EventReference` SFX, and `AnimLayerIndices animLayer`.
   Pick the closest existing subclass as the base behaviour: projectile (`ArrowAbility`/`EveSteadyShot`),
   ground-target AoE/DoT (`ChargedArrowsAbility`/`EveFreezeAbility`), melee box/sphere
   (`PunchSequenceAbility`/`HeavyPunchAbility`/`JumpPoundAbility`), mobility (`RecoilArrowAbility`),
   defensive spawn (`EveIceBlockAbility`), or pure self-buff ult (`RageAbility`).
4. **Per hitbox,** build a prefab with the §1.4 stack: NetworkIdentity + a `HitboxBase` subclass
   (`Hitbox`) + `ProjectileMove` (if it travels) + `TriggerPhysicsForceAreaHitbox` + `VFXSpawn` +
   `AudioPlayFmod`, a trigger `Collider` sized for the attack, on **layer 14 / tag "Hitbox"**, kinematic
   Rigidbody. Set only `allowHitToEnemies/Team/OwnerPlayer` + `rendererObj` on it; everything else
   (damage/ttl/SE) is injected by the Ability at `Shoot()` time. Register it in the Mirror spawn pool.
5. **Animation:** ship an `AnimatorController` for the char whose states match the cast subroutines
   (the `Ability1..4` state convention), referenced by `CharAnimator`. Do NOT reuse another char's
   controller (root cause of the frozen-pose / wrong-animation failures).

## 6. Reference: collider geometry harvested (authoritative — survived the export)

| Hitbox prefab | Collider | Size / Radius | Center | Trigger | Layer |
|---|---|---|---|---|---|
| `Hitbox_Kitsu_EnergyArrow` | Box | `{0.6, 0.5, 2.5}` | `{0,0,-0.1}` | yes | 14 |
| `Hitbox_Eve_SteadyShot` | Box | `{0.5, 1.039, 2.5}` | `{0,-0.270,-0.1}` | yes | 14 |
| `Hitbox_Eve_Freeze` | Sphere | `r = 1` | `{0,0,0}` | yes | 14 |
| `Hitbox_Eve_Block` | Sphere | `r = 1` | `{0,0,0}` | yes | 14 |
| `Hitbox_Chuck_Punch` | Sphere | `r = 1.75` | `{0,0,-0.4}` | yes | 14 |
| `Hitbox_Chuck_HeavyPunch` | Box | `{2.1, 0.5, 3.25}` | `{0,0,-0.35}` | yes | 14 |
| `Hitbox_Chuck_JumpLandAoe` | Sphere | `r = 2` | `{0,0,0}` | yes | 14 |

All hitbox prefabs use a kinematic, non-gravity `Rigidbody` and tag `Hitbox`. Movement is by
`ProjectileMove`, not physics.

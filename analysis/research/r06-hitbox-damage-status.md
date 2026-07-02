# R06 — Hitbox, Damage & Status Effects (BAPBAP)

Stage R06 of the "correct networked custom characters + abilities" research. This
document explains, from real decompiled source, how BAPBAP spawns hitboxes,
detects hits, applies damage, and replicates everything over Mirror; the strict
server-vs-client split; and how status effects (poison, petrify) are applied and
networked.

All file paths below refer to the full-body decompile under:

```
C:\Users\Administrator\Downloads\neueBapbap\GEHEIMBUILD\ExportedProject\Assets\Scripts\Assembly-CSharp\BAPBAP
```

(the `_DisabledScripts\Assembly-CSharp\BAPBAP` copy under `GameCode\ExportedProject`
is signature-only stubs — method bodies are empty — so it is useless for behaviour;
use GEHEIMBUILD). The `CharHurtbox` body was also cross-checked against
`C:\Users\Administrator\Downloads\neueBapbap\_decomp\hurtbox\BAPBAP.Entities.CharHurtbox.decompiled.cs`.

---

## 0. TL;DR for the synthesis stage

- **Hitboxes are server-authoritative `NetworkBehaviour`s.** They are spawned on the
  server (`NetworkServer.Spawn` / `NetworkPrefabPool`), and only the server runs hit
  detection (`OnTriggerEnter` / `OnTriggerStay` are `[ServerCallback]`), damage
  application, and destruction. Clients only receive replicated transform/SyncVars
  and `ClientRpc` calls for impact VFX/SFX and destruction.
- **Damage is applied exclusively server-side** through `CharHurtbox.ApplyHit(...)`,
  which mutates `hp`/`shield` and pushes those values to clients via `OnNetSerialize`
  (a custom `INetworkPredicted` serializer, not a SyncVar) plus cosmetic `ClientRpc`s
  (`RpcOnHit`, `RpcWobbleHit`, etc.).
- **Status effects are server-authoritative too.** `CharStatusEffects.ActivateStatusEffect`
  is `[Server]`-only; the active status list is replicated through `OnNetSerialize` /
  `OnNetDeserialize`, and clients reconstruct local `StatusEffect` instances and play
  their `Cl*` presentation (VFX, anim disable for petrify, hp-bar timers).
- **The previous mod failed precisely because it violated this model**: it spawned
  ability hitbox prefabs as *client-side presentation only* ("gameplay/network/damage/
  collider/audio stripped", `MedusaMod.cs:1674-1681`) and bolted status effects on via
  a Harmony postfix to `HitboxBase.OnHitSuccess` (`MedusaMod.cs:1389-1518`). Because the
  real hitbox never existed on the server, other players saw nothing, no damage
  replicated, and the object despawned. Any correct custom-ability system **must spawn a
  real networked hitbox on the server**, not graft visuals onto the client.

---

## 1. Class hierarchy

```
NetworkBehaviour
└── HitboxBase                 (HitboxBase.cs)  — shared networked hitbox base
    ├── Hitbox                 (Hitbox.cs)      — collider/trigger "one-shot" hitbox (OnTriggerEnter)
    │   └── HitboxTriggerbox / HitboxTriggerboxStatusEffects / ...
    └── HitboxDps              (HitboxDps.cs)   — periodic damage-over-time field (OnTriggerStay)

NetworkBehaviour, INetworkPredicted
├── CharHurtbox                (CharHurtbox.cs)        — receives damage/heals, owns hp/shield, kills
└── CharStatusEffects          (CharStatusEffects.cs)  — owns active StatusEffect list

StatusEffect (plain C# class, IComparable)  (StatusEffect.cs)
├── SE_Poisoned                (SE_Poisoned.cs)
├── SE_Petrified               (SE_Petrified.cs)
└── ... ~40 others

ScriptableObject
└── StatusEffectSO             (StatusEffectSO.cs)
    ├── SE_Poisoned_SO / SE_Petrified_SO / SE_Stunned_SO / ...

MonoBehaviour
├── HitboxBaseSystem           (Systems\HitboxBaseSystem.cs) — drives ManagedFixed/LateFixed updates
└── StatusEffectManager        (Local\StatusEffectManager.cs) — id assignment + instance factory
```

---

## 2. How hitboxes are spawned

### 2.1 The spawn helpers (where damage/team/status get set)

Two canonical spawn paths set up a `Hitbox` from ability/entity config. Both are
**server-only** and call `NetworkServer.Spawn` at the very end.

**Ability-driven:** `AB_SpawnHitbox_Base.DoUse()` (`Entities\AB_SpawnHitbox_Base.cs:46-86`):

```csharp
public override void DoUse()
{
    EntityManager entityManager = ability.entityManager;
    GameObject gameObject = Object.Instantiate(config.hitboxPrefab, entityManager.transform.position, Quaternion.identity);
    Hitbox component = gameObject.GetComponent<Hitbox>();
    component.NetworkownerPlayerId = entityManager.GetPlayerId();   // SyncVar
    component.NetworkteamId        = entityManager.GetTeamId();     // SyncVar
    component.otherChar = entityManager.gameObject;                 // the caster (for self-hit/dir)
    if (config.damage > 0)
    {
        component.damage = ability.charAbilities.GetModifiedDamage(config.damage, config.damageScaling);
        component.damageToPlayersMultiplier = entityManager.charAbilities.damageToPlayersMultiplier;
    }
    component.allowHitToOwnerPlayer = config.damageAllowedToOwnerPlayer;
    component.onlyHitAllies        = config.onlyAllies;
    component.destroyOnCharHit     = config.destroyOnCharHit;
    component.destroyOnStaticCollision = config.destroyOnStaticCollision;
    component.statusEffects = config.statusEffects;     // List<StatusEffectInfo>
    component.counterable   = config.counterable;
    component.stayOnOwnerDestroyed = config.stayOnOwnerDestroyed;
    component.ttl = config.ttl;
    component.directional = config.hitboxDirectional;
    if (gameObject.TryGetComponent<SphereCollider>(out var sc)) sc.radius = config.hitboxRadius;
    component.SetAbility(ability);
    entityManager.charPassives.OnHitboxSpawned(gameObject, entityManager, (int)ability.cmdId);
    NetworkServer.Spawn(gameObject);   // <-- replicates to all clients
}
```

Key takeaways:
- The configured prefab carries the `Hitbox`/`HitboxDps` component, a collider
  (usually a trigger `SphereCollider`), and optional `ProjectileMove`, `VFXSpawn`,
  `AudioPlayFmod`, `AudioPlayIntervals` (cached in `HitboxBase.Awake`,
  `HitboxBase.cs:Awake`).
- `ownerPlayerId` and `teamId` are **`[SyncVar]`** so every client knows who owns the
  hitbox (used for friendly-fire filtering and damage attribution).
- `damage`, `statusEffects`, `ttl`, etc. are plain `[NonSerialized]` server fields —
  they are *never* sent to clients because clients never compute hits.
- `SetAbility(ability)` wires callbacks (`OnTargetHit`, `OnTargetKill`,
  `OnHitboxDestroy`, `OnHitboxEnd`, `OnWallHit`, `OnOtherHitboxHit`) so the owning
  ability gets server-side hooks (`HitboxBase.cs` OnHitSuccess/OnHitKill/OnWallHit/OnHitboxHit).

**Entity-driven:** `EntityActivateHitbox.SpawnHitbox(pos, rot)`
(`Entities\EntityActivateHitbox.cs:118-..`) is the same pattern for NPC/interactable
hitboxes — `[Server] Activate()` → instantiate → set `Networkowner/teamId`, `damage`,
`addDamageHpPercentage`, `statusEffects`, `OnlyApplyHitOncePerChar`, collider radius,
optional `ColliderEnableNet`, `HitboxFollowPosition.Networktarget` → `NetworkServer.Spawn`.

Note the `pullToPosition` branch (`EntityActivateHitbox.cs`): it *adds* a
`new StatusEffectInfo(SE_Pulled_SO.Id, pullTime, 1f)` into the list at runtime — the
status-effect list is just data attached to the hitbox.

### 2.2 Pooling

`HitboxBase` implements `IPoolDespawnListener`. Destruction prefers pooled despawn:

```csharp
public void SvDestroyHitbox()   // HitboxBase.cs
{
    if (NetworkPrefabPool.IsPooled(base.gameObject)) {
        NetworkPrefabPool.Despawn(base.gameObject);
        NetworkServer.UnSpawn(base.gameObject);
    } else {
        NetworkServer.Destroy(base.gameObject);
    }
}
```

`OnDespawn()` fully resets every field back to defaults (`HitboxBase.cs` OnDespawn,
`HitboxDps.cs` OnDespawn, `Hitbox.cs` OnDespawn) so a pooled instance can be reused.
**Implication for custom hitboxes:** a custom hitbox prefab must be registered with
the network/spawn system (Mirror spawnable prefabs + optionally `NetworkPrefabPool`)
or `NetworkServer.Spawn` will not replicate it and `IsPooled` will be false.

### 2.3 SpawnHitboxOnDestroy chaining

`HitboxBase.DestroyHitbox` checks `TryGetComponent<SpawnHitboxOnDestroy>` and calls
`component.SpawnHitbox()` before destroying — that is how a projectile spawns a puddle/
explosion on impact (server-side, `HitboxBase.cs` DestroyHitbox).

---

## 3. Hit detection (server only)

### 3.1 `Hitbox` (single/trigger hitbox) — `Entities\Hitbox.cs`

Detection is buffered and processed once per server frame:

- `[ServerCallback] OnTriggerEnter(Collider)` (`Hitbox.cs`): guarded by
  `NetworkServer.active`, `!Destroyed`, tag `IgnoreCollision`. Classifies the collider:
  - level obstacle (`IsLevelObstacleHit`, layer-mask test against
    `LocalManager.Obstacles_LayerMask | ObstaclesNoFoW_LayerMask`) → added to
    `obstacleHits`.
  - `EntityManager` (directly or via `collider.transform.root` when on the
    `Entity_Layer`) → added to `entityHits` and `allEntityHits`.
  - another `Hitbox` → `OnHitboxHit` (ability `OnOtherHitboxHit` hook).
- `[ServerCallback] Update()` (`Hitbox.cs`): if server & not destroyed →
  `ProcessHits()`; then handles `ttl` by advancing the **SyncVar** `elapsedTime`
  (`NetworkelapsedTime`) and calling `DestroyHitbox()` when `elapsedTime >= ttl`.
- `ProcessHits()` (`Hitbox.cs`): removes null entities, **sorts entityHits by squared
  distance to the hitbox** (closest first, caster `otherChar` pinned), then calls
  `DoEntityHit` for each; then `DoObstacleHit` for obstacles. Lists cleared after.

`DoEntityHit(EntityHit, colTransform)` (`[Server]`, `Hitbox.cs`) is the gatekeeper.
In order, it rejects/continues on:

1. Missing `charHurtbox`/`charTriggerbox`, `charHurtbox.isNonHittable`,
   target downed (`charDowned.IsDowned`), or target parrying
   (`charAbilities.isParrying && !ignoreParry`).
2. Interactable rules (`allowHitToInteractables`, same-team interactable, self).
3. Player/NPC team rules via `CanHitEntity(teamId, playerId)` (see §3.3). For
   non-players it uses `entity.entityTeamId` as the "playerId".
4. `ignoredEntities` / `whiteListEntities` membership.
5. `checkForStaticCollision && IsLineOfSightBlocked(...)` (raycast on obstacle mask
   from a point behind the hitbox to the target).
6. `charHurtbox.isDead`, `charTriggerbox.IsTriggerLocked`.
7. `OnlyApplyHitOncePerChar` dedup via `hittedEntities`.

Then it computes final damage `num` from `damage` plus:
- `selfHpPercentDamageHp` (% of caster max hp),
- `addDamageHpPercentage` (% of target max hp, capped for NPCs by
  `addDamageHpPercentageNpcsLimit`),
- `addDamageVehicleHpPercentage` (if target has `Vehicle`),
- `damageToPlayersMultiplier` (players only).

For interactables it sends `RpcWobbleHit` and returns early if `num<=0` unless
`alwaysHitInteractables`. Otherwise:
- `num > 0` (or `num==0` with `applyZeroDamageHit`/player) →
  `charHurtbox.ApplyHit(num, statusEffects.ToArray(), ownerPlayerId, otherChar, isCriticalDamage, allowLifesteal, allowThorns, interruptOutCombatTimer:true, isTrueDamage:false, hitDir, applyWobble:true, forceTriggerImmune, entityHit.collider)`.
  If the target died this hit (`hp>0 && charHurtbox.isDead`) → `OnHitKill(entity)`.
- `num < 0` → `charHurtbox.ApplyHeal(-num)`.

Finally, for real entities (npc/bot/lootbox/player, not items) or hittable
interactables, it sets `hasHitEntity`, plays impact (`TryPlayImpact` → `RpcOnHitboxImpact`),
and calls `OnHitboxImpact()`.

`OnHitboxImpact()` (`[Server]`, `Hitbox.cs`) destroys the hitbox when
`(destroyOnCharHit && hasHitEntity) || (destroyOnStaticCollision && hasHitCollision)`.

### 3.2 `HitboxDps` (damage-over-time field) — `Entities\HitboxDps.cs`

- `OnStartServer()` initializes `dmgPerTimeTimer = dmgPerTimeRate`, sets LOS obstacle
  mask, disables audio on dedicated server (`isServerOnly`).
- `FixedUpdate()` (server only): advances `elapsedTime` for TTL (destroys at
  `elapsedTime >= ttl`), and gates `doDmg` on a `dmgPerTimeRate` cadence so damage is
  applied at intervals, not every physics tick.
- `[ServerCallback] OnTriggerStay(Collider)`: while `doDmg`, resolves `EntityManager`
  and calls `ApplyHit(new Hitbox.EntityHit(component, collider))`.
- `ApplyHit(EntityHit)` mirrors `Hitbox.DoEntityHit` filtering, then calls
  `charHurtbox.ApplyHit(...)` (or `ApplyHeal`), and `RpcOnHitboxImpact` for real
  entities. It does **not** auto-destroy on hit (it's a persistent field).

Note `HitboxDps.elapsedTime` here is `[NonSerialized]` (server-local) — unlike
`Hitbox.elapsedTime` which is a SyncVar. In the disabled-stub copy it was marked
`[SyncVar]`, but the live full-body GEHEIMBUILD has it `[NonSerialized]`.

### 3.3 Friendly-fire / target filtering — `HitboxBase.CanHitEntity`

```csharp
public bool CanHitEntity(int otherTeamId, int otherPlayerId)   // HitboxBase.cs
{
    bool sameOwner = otherPlayerId == ownerPlayerId;
    bool sameTeam  = otherTeamId  == teamId;
    if (sameOwner)      return allowHitToOwnerPlayer;
    else if (sameTeam)  return onlyHitAllies || allowHitToTeam;
    else                return !onlyHitAllies;
}
```

This is the single source of truth for who a hitbox may damage and depends entirely
on the **SyncVar** `ownerPlayerId`/`teamId`. A custom ability that forgets to set
these will hit nobody (or everybody) incorrectly.

---

## 4. Damage application & replication — `CharHurtbox`

`CharHurtbox` is a `NetworkBehaviour` implementing `INetworkPredicted`. It is the only
place hp/shield change.

### 4.1 `ApplyHit(...)` (server-side, `CharHurtbox.cs`)

Order of operations (abbreviated):
1. Bail if dead / match not started.
2. Resolve attacker `EntityManager component` from `otherPlayerId`
   (`gameManager.playersByPlayerId`) or `otherCharObj`.
3. If not true damage: respect `IsTriggerLocked`; `invincibilityLocks>0` → damage=0;
   apply `GetModifiedDamage` (mitigation: `damageTakenModifer`, `…Uncapped`,
   `amplifyModifer`, attacker `shred`), `onlyTake1Damage`, npc multiplier.
4. **Status effects are applied here** for non-interactable/non-item targets:
   `ApplyStatusEffects(statusEffects, otherPlayerId, pushDir, otherCharObj, isCrit)`
   (see §5). So a status effect rides along with the damage hit.
5. Downed/immune handling (`charDowned.IsDowned`, `immuneLocks` → passive
   `OnImmuneDamageTrigger`).
6. Record attacker into `svLastPlayersWhoHit` (for assist/kill credit) if not ally.
7. Passive damage modification (`charPassives.OnTakeDamageModifyTrigger`).
8. Subtract from shield first (`SvSetShield`), then hp (`SvSetHp`), honoring `min1Hp`.
9. Fire cosmetic RPCs **only if damage>0**: `RpcOnHit(oldLife,newLife,…,isCrit,…)`,
   `RpcWobbleHit(pushDir,damage)`; update score, lifesteal (`TryApplyLifesteal`),
   thorns (`TryApplyThorns`).
10. NPC aggro (`TryAggroNpc`). If `hp<=0` → `OnCharacterKilled(...)` → downed/kill flow.

`SvSetHp` / `SvSetShield` are `[Server]`; they clamp, push hp/shield to teammate
clients (`SvUpdateHpShieldOnTeammates → TargetUpdateTeammateHp`), and if running as
host (`isClient`) immediately call the local `OnHpShieldChanged` UI hook.

### 4.2 Replication of hp/shield (NOT a SyncVar)

`CharHurtbox` replicates its core state through the predicted-serialization interface,
**not** Mirror `[SyncVar]`s:

```csharp
public void OnNetSerialize(NetworkWriter w)   // CharHurtbox.cs
{
    w.WriteInt(maxHp); w.WriteInt(hp);
    w.WriteInt(maxShield); w.WriteInt(shield);
    w.WriteFloat(thornsPercent);
    w.WriteByte(invincibilityLocks);
    w.WriteBool(isOutOfCombat); w.WriteFloat(outOfCombatTimer);
    w.WriteFloat(damageTakenModiferUncapped); w.WriteFloat(damageTakenModifer);
    w.WriteFloat(amplifyModifer); w.WriteBool(isDead);
}
public void OnNetDeserialize(NetworkReader r)
{
    // reads same order; if hp/maxHp/shield/maxShield changed -> OnHpShieldChanged(...)
    // if invincibilityLocks changed -> OnInvincibilityChanged()
}
```

So clients learn the new hp purely from the deserialized snapshot, and the cosmetic
`RpcOnHit` only drives hit-flash, damage numbers, camera shake, voicelines —
**the authoritative number is the replicated `hp`**. This is the predicted/resimulated
networking layer (`INetworkPredicted`, `OnTick(float, Command, bool isResim)`).

### 4.3 Client-side hit reaction — `RpcOnHit`

`UserCode_RpcOnHit__…` (`CharHurtbox.cs`): updates the hp bar hit effect, triggers
bush reveal, `charMaterial.TriggerHit(color)`, `charFx.OnHitFx()`, damage point pop-ups
(`ClOnHitPoints`), and for the local authoritative view applies damage screen FX +
camera shake + damage voiceline. Purely presentational.

Other cosmetic ClientRpcs on `CharHurtbox`: `RpcWobbleHit`, `RpcPushHit`, `RpcShakeHit`,
`RpcSpawnHealVFX`, `RpcSpawnThornsVFX`, `RpcSpawnExecuteVfx`, `RpcSpawnChainHitVfx`,
`RpcSpawnHealPoints`, `RpcSetInPlayerCombat`. All registered in the static ctor via
`RemoteProcedureCalls.RegisterRpc(...)`.

---

## 5. Status effects — application & networking

### 5.1 Data model

- `StatusEffectSO` (ScriptableObject, `StatusEffectSO.cs`): authoring asset; gets an
  integer `id` assigned at load and is a factory (`NewInstance(EntityManager)`).
- `StatusEffectInfo` (`StatusEffectInfo.cs`): the serializable `{ StatusEffectSO
  statusEffect; float duration; float multiplier; }` tuple carried by hitboxes. A
  ctor variant resolves an SO by id via
  `LocalManager.Instance.statusEffectManager.statusEffects[id]`.
- `StatusEffect` (plain class, `StatusEffect.cs`): the **runtime instance** with
  `id, active, duration, multiplier, otherPlayerId, direction` and virtuals
  `Activate / Deactivate / Reactivate / OnTick / ClActivate / ClDeactivate /
  ClReactivate / OnUpdate / ApplyInputDirModification`. `CompareTo` sorts by `id`.
- `StatusEffectManager` (`Local\StatusEffectManager.cs`): holds
  `StatusEffectSO[] statusEffects` ordered by priority. `PreAwake()` assigns each SO
  `id = index` **and** writes that index into the per-type static `…_SO.Id` field
  (e.g. `SE_Poisoned_SO.Id = i`, `SE_Stunned_SO.Id = i`). `NewStatusEffectInstance(id, em)`
  is the factory used by both server and client.

**Critical for custom effects:** ids are *array indices*, assigned at runtime from the
`statusEffects[]` ordering. They are **not stable constants** — code references them
through the static `SE_Xxx_SO.Id` which is filled in `PreAwake`. A custom status effect
must be added to that array (and have its static `Id` populated) or its id stays `-1`
and `ActivateStatusEffect` logs an error and returns null.

### 5.2 Two ways a hitbox applies a status

1. **Bundled with damage** — inside `CharHurtbox.ApplyHit`, for non-interactable
   targets, `ApplyStatusEffects(statusEffects, otherPlayerId, pushDir, otherChar, isCrit)`
   runs (`CharHurtbox.cs`). For items/interactables, `Hitbox.DoEntityHit` /
   `HitboxDps.ApplyHit` call `charHurtbox.ApplyStatusEffects(...)` directly before the
   damage branch.
2. **Trigger-zone effects** — `HitboxTriggerboxStatusEffects`
   (`Entities\HitboxTriggerboxStatusEffects.cs`) applies on enter / removes on exit:

   ```csharp
   public override void OnEnter(EntityManager entity) {
       if (!Destroyed && entity != null &&
           (entity.GetTeamId() != teamId || allowHitToOwnerPlayer) &&
           entity.charStatusEffects != null)
           for (int i = 0; i < statusEffects.Count; i++)
               entity.charStatusEffects.ActivateStatusEffect(statusEffects[i], ownerPlayerId);
   }
   public override void OnExit(EntityManager entity) {
       if (entity != null && entity.charStatusEffects != null)
           for (int i = 0; i < statusEffects.Count; i++)
               entity.charStatusEffects.DeactivateStatusEffect(statusEffects[i].statusEffect.id);
   }
   ```

### 5.3 `CharHurtbox.ApplyStatusEffects` (server) — `CharHurtbox.cs`

Iterates the `StatusEffectInfo[]`, skips null/`id==-1`, skips if `invincibilityLocks>0`.
Special cases:
- `SE_Pulled_SO.Id`: needs `otherChar`; uses caster position as the pull direction.
- `SE_Poisoned_SO.Id` + crit + attacker has `poisonCrits` passive: multiplies poison
  multiplier by the passive's stacks.
- Otherwise `entityManager.charStatusEffects.ActivateStatusEffect(id, duration,
  multiplier, ownerPlayerId, direction)`.
- For `Stunned`/`Rooted` it also fires `RpcShakeHit()` once.

### 5.4 `CharStatusEffects.ActivateStatusEffect` (server-authoritative) — `CharStatusEffects.cs`

`[Server]`, guarded by `NetworkServer.active`. Rejection rules (in order):
`id==-1`, `ignoreAllStatusEffects`, `immuneToStatusEffects` (unless `isNonImmune`),
`immuneToMovementDebuffs` (if movement debuff), interactable can't take it
(`CanEntityInteractWithStatusEffect`), `immuneToSlows` for slow ids. On immune it fires
`RpcSpawnStatusText("IMMUNE", …)`.

Then passive hooks (`OnStatusEffectAppliedToEnemyTrigger`, `…ToSelfTrigger`), a guard
that movement effects need a `charMove`, and merge logic:
- `onlyOneInstance` → reactivate existing instance.
- `mergeIdentical` (same id + same multiplier) → reactivate.

Otherwise it creates an instance via `statusEffectManager.NewStatusEffectInstance(id, em)`,
adds it to `statusEffects`, calls `statusEffect.Activate(...)`, and on host
(`isClient`) also `statusEffect.ClActivate(...)`.

`OnTick(fixedDt, cmd, isResim)` (server): ticks each effect; expired non-`ignoreDuration`
effects are removed and `Deactivate()`d (on host also `ClDeactivate()`). Client branch
ticks `ClOnTick`.

### 5.5 Replication of the active status list — `OnNetSerialize` / `OnNetDeserialize`

`CharStatusEffects` replicates the whole active list through `INetworkPredicted`, not
SyncVars (`CharStatusEffects.cs`):

```csharp
public void OnNetSerialize(NetworkWriter w) {
    w.WriteInt(statusEffects.Count);
    // sorted copy by id; write {id, duration, multiplier} for each
}
public void OnNetDeserialize(NetworkReader r) {
    // read N {id,duration,multiplier} into newStatusEffects
    // merge-walk against current sorted statusEffects:
    //   same id      -> update duration; if increased / ignoreDuration jump -> ClReactivate
    //   removed id   -> ClDeactivate()
    //   new id       -> NewStatusEffectInstance + ClActivate(); add to list
    // resort, replace statusEffects with reconciled list
}
```

So a remote client builds its own `StatusEffect` instances from the replicated
`{id,duration,multiplier}` stream and drives the local presentation through
`ClActivate`/`ClReactivate`/`ClDeactivate`. **This is exactly the mechanism the failed
mod bypassed** — applying a status via a Harmony hook on one machine does not enter this
serialized list, so it never reached other clients and visuals desynced.

### 5.6 Worked example: Poison — `SE_Poisoned.cs` (+ `SE_Poisoned_SO.cs`)

- `SE_Poisoned_SO.NewInstance` returns `new SE_Poisoned(em, configuration)`. `Config`
  fields: `poisonedDamagePerTick`, `tickDuration`, `maxPoisonStacks`, `burstMultiplier`,
  `burstBaseDmg`, `slowDuration`, `slowRate`, plus poison-related passive SOs.
- `Activate(...)` (server): reads attacker passives for slow/duration/shield variants,
  calls `base.Activate`, `RpcShowStatusEffectPopUp(id)`, increments `poisonStacks`
  (capped at `maxPoisonStacks`).
- `OnTick(dt)` (server): every `tickDuration`, computes
  `damage = poisonedDamagePerTick(+passive) * poisonStacks * multiplier` and calls
  `charHurtbox.ApplyHit(damage, null, otherPlayerId, …, applyThorns:false)` — i.e. DoT
  re-enters the same server damage pipeline. Optional explosion/shield passive effects.
- `ClActivate` (client/host): `charStatusEffects.ShowStatusEffectHpBar(id, duration)` +
  `charFx.EnableStatusEffectFx(id, duration)`. `ClDeactivate` removes the hp-bar entry
  and disables the FX when the last stack ends.

Poison damage is server-only; the *visuals* (hp-bar timer, poison FX) come from the
replicated list driving `ClActivate`/`ClDeactivate`.

### 5.7 Worked example: Petrify — `SE_Petrified.cs` (+ `SE_Petrified_SO.cs`)

- `Activate(...)` (server): `RpcShowStatusEffectPopUp(id)`, then **server-side gameplay
  locks**: `charMove.movementLocks++`, `charAbilities.AddSilenceLocks()`,
  `charAim.rotationLocks++`. `Deactivate()` reverses all three.
- `ClActivate(...)` (client/host): hp-bar + status FX + `charFx.EnablePetrifyFx()`, then
  **disables animation locally**: `entityManager.charAnim.animator.enabled = false` and
  `entityManager.entityAnimComponents.DisableAnimationComponents()`. `ClDeactivate`
  re-enables the animator and anim components and disables petrify FX.

This split is instructive: the *freeze of movement/abilities* is enforced on the server
(authoritative), while the *frozen pose* (animator disabled) is a client presentation
applied through the replicated effect. The previous mod's "frozen poses / Standbilder"
symptom is what happens when you disable/replace animation **without** the authoritative
state and replication backing it — i.e. animator changes applied locally with no server
state to keep all clients consistent.

---

## 6. Strict server vs client responsibility table

| Concern | Server | Client (remote) | Host (server+client) |
|---|---|---|---|
| Spawn hitbox | `NetworkServer.Spawn` after Instantiate + config | receives spawned object via Mirror | both |
| Hit detection | `OnTriggerEnter`/`OnTriggerStay` `[ServerCallback]` | none | server path runs |
| Damage math + apply | `CharHurtbox.ApplyHit`, `SvSetHp/Shield` | none | server path |
| hp/shield value | authoritative, written in `OnNetSerialize` | read in `OnNetDeserialize` | both |
| Status apply/remove | `ActivateStatusEffect` `[Server]` | reconstructed from serialized list | server path + immediate `ClActivate` |
| Status gameplay locks | server (`movementLocks++`, silence, etc.) | none | server |
| Status/hit VFX, SFX, anim, hp-bar, dmg numbers | trigger via `[ClientRpc]` / serialized hooks | run `Cl*` / `UserCode_Rpc*` | both |
| Hitbox TTL / destroy | `FixedUpdate`/`Update` + `DestroyHitbox` → `RpcDestroy*` | receive `RpcDestroyHitbox*`, play VFX, despawn | both |
| Projectile travel-to-destroy | `RpcDestroyHitboxAtPosition` computes client-side delay from `projMove.speed` | yes | yes |

`[ServerCallback]` silently no-ops on clients; `[Server]` logs a warning if called
without an active server. `[ClientRpc]` methods serialize args and call
`SendRPCInternal(...)`; their `UserCode_*` bodies guard `if (!NetworkClient.active)
LogError("called on server")`. These attributes are the contract a correct custom
ability must respect.

---

## 7. Hitbox replication & lifecycle details

- **SyncVars on `HitboxBase`**: `ownerPlayerId` (dirty bit 1), `teamId` (dirty bit 2),
  serialized in `SerializeSyncVars`/`DeserializeSyncVars` (`HitboxBase.cs`).
  `Hitbox` adds `elapsedTime` (dirty bit 4) with `syncInterval = 1f` set in `Awake`.
- **Destruction** (`HitboxBase.DestroyHitbox`, `[Server]`):
  - guards `NetworkServer.active`, `!Destroyed`, active object;
  - runs `SpawnHitboxOnDestroy`, `OnDestroyAction`, ability `OnHitboxDestroy` +
    `OnHitboxEnd(allEntityHits)`;
  - sets `destroyed = true`;
  - if it's a moving projectile (`projMove.speed > 0`) → `RpcDestroyHitboxAtPosition`
    (clients compute travel delay) + `SvDelayDestroyHitbox(1f)`;
  - else → `RpcDestroyHitbox` + `SvDelayDestroyHitbox(destroyDelay)`.
  - `SvDelayDestroyHitbox` sets `destroyTimer = Max(0.25f, delay)`; `FixedUpdate`
    counts it down and finally calls `SvDestroyHitbox()` (pool despawn or
    `NetworkServer.Destroy`).
- **Client destroy** (`ClDestroyHitbox`): marks `destroyed` on client-only, plays
  destroy VFX/SFX, updates debug viewer.
- **Impact** (`TryPlayImpact` → `RpcOnHitboxImpact` → `ClOnHitboxImpact`): spawns
  impact VFX + audio on all clients (and locally on host).
- `HitboxBaseSystem` (`Systems\HitboxBaseSystem.cs`) is a `MonoBehaviour` registry that
  calls `ManagedFixedUpdate`/`ManagedLateFixedUpdate` on registered hitboxes via a
  `WaitForFixedUpdate` coroutine (`LateFixedUpdateCoroutine`) — it is the per-frame
  driver for hitbox sub-behaviours, separate from Mirror.

---

## 8. Why the previous (clone/client-graft) approach broke — mapped to root causes

From the failed framework (`C:\Users\Administrator\Downloads\BAPBAPModdingAPI\
bapcustomchars-mod`):

- `CustomCharFramework.cs:50-67` and `MedusaMod.cs:1674-1681`: ability hitbox prefabs
  ("Hitbox_MedusaPoisonProjectile", etc.) are spawned as **client-side presentation
  only — gameplay/network/damage/collider/audio stripped**.
  → No `NetworkServer.Spawn`, no server collider, no `Hitbox`/`HitboxDps` running →
  **other players see nothing; no damage; the object is local and despawns** when the
  local presentation ends. This directly matches "not visible to others / visuals &
  attacks only local / despawns".
- `MedusaMod.cs:1389-1518`: status effects (poison/petrify) applied via a Harmony
  **postfix on `HitboxBase.OnHitSuccess`** calling `ActivateStatusEffect` on the
  victim.
  → Even if the base-char hitbox is real, this side-channel only runs where the patch
  executes; correct replication requires the effect to live in `CharStatusEffects`'
  server list so `OnNetSerialize`/`OnNetDeserialize` propagate it. Locally-applied
  animator disables (petrify) without server state cause the "frozen pose / Standbilder"
  desync.
- Abilities "only LMB works; RMB green dot; Space bugs; E plays Kitsu's animation":
  consistent with reusing the base character's ability/hitbox config and animation
  states while only overriding LMB's presentation. The real engine routes each ability
  through its own `AbilityBehaviour`/`AB_SpawnHitbox_Base.DoUse` (server) + replicated
  hitbox; grafting visuals does not re-route the other slots.

**The correct model (for the synthesis stage):**
1. Author a real **networked hitbox prefab** (carries `Hitbox`/`HitboxDps` + collider +
   optional `ProjectileMove`/`VFXSpawn`/`AudioPlayFmod`) and register it with Mirror's
   spawnable prefabs (and `NetworkPrefabPool` if pooling).
2. On the **server**, configure it exactly like `AB_SpawnHitbox_Base.DoUse`: set
   `NetworkownerPlayerId`/`NetworkteamId`, `otherChar`, `damage` (via
   `charAbilities.GetModifiedDamage`), `statusEffects`, flags, collider radius,
   `SetAbility`, then `NetworkServer.Spawn`.
3. Let the engine's server-only detection (`OnTriggerEnter`/`OnTriggerStay`) →
   `CharHurtbox.ApplyHit` → `OnNetSerialize` pipeline do damage + replication. Do not
   apply damage on the client.
4. For status effects, register custom `StatusEffectSO`s into
   `StatusEffectManager.statusEffects[]` (so they get a valid id), attach them as
   `StatusEffectInfo` on the hitbox, and let `CharStatusEffects.ActivateStatusEffect`
   (server) + the serialized list handle replication and client presentation.
5. Custom **abilities** must be real `AbilityBehaviour` instances wired per input slot
   (LMB/RMB/Space/E), each with its own server `DoUse` and hitbox, not visual overrides
   of Kitsu's slots. (This ties into the R-stages covering CharAbilities/AbilityBehaviour.)

---

## 9. Key file:line reference index

- `Entities\HitboxBase.cs` — base hitbox: SyncVars `ownerPlayerId`/`teamId`,
  `CanHitEntity`, `OnHitSuccess`/`OnHitKill`/`OnHitboxHit`/`OnWallHit`, `[Server]
  DestroyHitbox`, `SvDestroyHitbox` (pool), `[ClientRpc] RpcOnHitboxImpact /
  RpcDestroyHitbox / RpcDestroyHitboxAtPosition`, `Serialize/DeserializeSyncVars`,
  `OnDespawn` full reset.
- `Entities\Hitbox.cs` — `EntityHit` struct; `[ServerCallback] OnTriggerEnter` &
  `Update`; `ProcessHits` (distance sort); `[Server] DoEntityHit` (full filter +
  damage compute + `ApplyHit`/`ApplyHeal` + `OnHitKill`); `[Server] DoObstacleHit`;
  `OnHitboxImpact`; `IsLineOfSightBlocked`; `elapsedTime` SyncVar (bit 4).
- `Entities\HitboxDps.cs` — DoT field: `OnStartServer`, server `FixedUpdate` cadence
  (`dmgPerTimeRate`, `doDmg`, ttl), `[ServerCallback] OnTriggerStay`, `ApplyHit`,
  `IsLineOfSightBlocked`.
- `Entities\HitboxTriggerboxStatusEffects.cs` — zone status apply on `OnEnter` /
  remove on `OnExit`.
- `Entities\AB_SpawnHitbox_Base.cs` / `…_SO.cs` — canonical server spawn+config of an
  ability hitbox (`DoUse`).
- `Entities\EntityActivateHitbox.cs` — entity/NPC server spawn+config of a hitbox.
- `Entities\CharHurtbox.cs` — `ApplyHit`, `ApplyHeal`, `ApplyStatusEffects`,
  `GetModifiedDamage`, `[Server] SvSetHp/SvSetShield`, `OnCharacterKilled`/`Kill`,
  `OnNetSerialize`/`OnNetDeserialize` (hp/shield/flags), cosmetic `[ClientRpc]`s
  (`RpcOnHit`, `RpcWobbleHit`, `RpcShakeHit`, heal/thorns/execute VFX).
- `Entities\CharStatusEffects.cs` — `[Server] ActivateStatusEffect` (rules + merge),
  `DeactivateStatusEffect`, `OnTick`, `OnNetSerialize`/`OnNetDeserialize` (list
  reconciliation), status UI/VFX RPCs, `Cleanse`.
- `Entities\StatusEffect.cs` — runtime base (Activate/Deactivate/Reactivate/OnTick/
  Cl*); `StatusEffectConfiguration` (onlyOneInstance/mergeIdentical/ignoreDuration/…).
- `Entities\StatusEffectInfo.cs` — `{SO, duration, multiplier}` carrier.
- `Entities\StatusEffectSO.cs` — authoring SO + `NewInstance` factory + `id`.
- `Entities\SE_Poisoned.cs` / `SE_Poisoned_SO.cs` — DoT example.
- `Entities\SE_Petrified.cs` / `SE_Petrified_SO.cs` — lock + animator-disable example.
- `Local\StatusEffectManager.cs` — `PreAwake` id assignment into `SE_*_SO.Id` statics,
  `NewStatusEffectInstance` factory, `GetStatusEffectConfig`.
- `Systems\HitboxBaseSystem.cs` — Managed update driver for hitboxes.

Failed-framework contrast:
- `BAPBAPModdingAPI\bapcustomchars-mod\MedusaMod.cs:1389-1518` (status via Harmony
  postfix), `:1674-1681` (client-only stripped presentation hitboxes).
- `BAPBAPModdingAPI\bapcustomchars-mod\CustomCharFramework.cs:50-67` (AbilityHitboxes /
  ExtraSpawnerHitboxes presentation mapping).

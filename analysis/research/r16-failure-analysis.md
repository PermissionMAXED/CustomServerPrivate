# R16 — Root-Cause Analysis of the Failed Clone-Based Custom-Character Approach

Stage: R16 (orchestrated). Scope: explain **why** the clone-of-Kitsu + client-side-graft
approach in `MedusaMod.cs` produced each observed failure, mapped against the **real** BAPBAP
architecture (Unity 2022.3.38f1, IL2CPP, Mirror networking). A later synthesis stage depends on
this, so every claim is tied to real source with `file:line`.

Sources read for this analysis:
- Failed framework: `C:\Users\Administrator\Downloads\BAPBAPModdingAPI\bapcustomchars-mod\MedusaMod.cs`,
  `…\CustomCharFramework.cs`
- Real game (decompiled, bodies stripped but fields/attributes/hierarchy intact):
  `…\neueBapbap\GameCode\ExportedProject\_DisabledScripts\Assembly-CSharp\BAPBAP\`
  — `Entities\EntityManager.cs`, `Entities\CharAbilities.cs`, `Entities\Ability.cs`,
  `Entities\ArrowAbility.cs`, `Entities\CharAnimator.cs`, `Entities\CharMaterial.cs`,
  `Entities\HitboxBase.cs`, `Network\GameNetworkManager.cs`.

> Note on the decompile: method **bodies** are stubbed to `return null/{}`, but **field
> declarations, `[SyncVar]`/`[ClientRpc]`/`[Server]` attributes, base classes, and method
> signatures are fully present**. That is exactly what is needed to reason about the networking
> contract; no behavioral guessing is required for the conclusions below.

---

## 1. The real architecture (the contract the mod had to satisfy)

### 1.1 The character is a server-authoritative, Mirror-replicated entity keyed by `charId`

`EntityManager` is the networked character root:

```
EntityManager : NetworkBehaviour                 // EntityManager.cs:14
[SyncVar] public int charId;                     // EntityManager.cs (charId SyncVar block, ~:200)
[SyncVar(hook="OnPlayerObjChanged")] GameObject playerObj;   // EntityManager.cs:~191
[SyncVar] public int charInstanceId;             // EntityManager.cs:~205
[SyncVar(hook="OnEntityTeamIdChanged")] int entityTeamId;    // EntityManager.cs:~214
public override void OnStartClient()             // EntityManager.cs (override)
```

`charId` is a **SyncVar**: it is set on the server and replicated to every client. All the
per-character wiring (which prefab, which animator, which abilities, which UI config) is keyed off
this single replicated integer. The entity carries the full component graph as `[NonSerialized]`
references resolved at spawn: `charAbilities`, `charAnim` (`CharAnimator`), `charMaterial`
(`CharMaterial`), `charMove`, `charHurtbox`, `charStatusEffects`, etc.
(`EntityManager.cs:48-118`).

### 1.2 Which prefab is spawned is a fixed, indexed table on `GameNetworkManager`

```
GameNetworkManager : NetworkManager              // GameNetworkManager.cs:18
public const int KitsuCharId = 0;                // GameNetworkManager.cs:227
public const int AnnaCharId = 1; … EveCharId=12; // GameNetworkManager.cs:229-237
[SerializeField] NetworkPrefabLibrary networkPrefabLibrary;   // GameNetworkManager.cs:~292
[SerializeField] GameObject[] characterPrefabsByCharId;       // GameNetworkManager.cs:~295
[SerializeField] CharacterBotPrefabs[] charBotPrefabsByCharId;// GameNetworkManager.cs:~297
public override void OnStartServer()             // GameNetworkManager.cs (server bringup)
public override void OnServerAddPlayer(NetworkConnectionToClient conn)  // spawn entry
public void OnServerMatchSetup / OnServerMatchAddTeams / OnServerQueueMatched
```

`characterPrefabsByCharId[charId]` is the **authoritative spawnable**. Mirror's `NetworkManager`
spawns a player/char object from a prefab that must be registered (in `spawnPrefabs` /
`NetworkClient` prefab table / the game's `NetworkPrefabLibrary` pool) **with a stable assetId that
is identical on the server and on every client**, and that registration must exist **before**
`NetworkServer` spawns the object. Remote clients reconstruct the object purely from the spawn
message `(assetId, netId, payload)` by looking the assetId up in their own prefab table.

### 1.3 Abilities are networked, server-authoritative, tick-simulated `NetworkBehaviour`s

```
Ability : NetworkBehaviour                       // Ability.cs:13
public CommandId cmdId;  // LMB=Ability1, Q=Ability2, Space=Ability3, E=Ability4  // Ability.cs:16-19
public virtual void Tick(float fixedDt, Command cmd, bool isResim)   // Ability.cs:~190
[Server] public virtual void OnTargetHit(EntityManager other, HitboxBase hb)  // Ability.cs:~270
[Server] public virtual void OnWallHit(GameObject hboxObj)           // Ability.cs:~280
public void SetState(AbilityStates _state)       // Ability.cs:~470
public AbilityStates state; CastSubroutine castSubroutine; CooldownSubroutine cooldownSubroutine;
```

`CharAbilities` is the predicted controller:

```
CharAbilities : NetworkBehaviour, INetworkPredicted   // CharAbilities.cs:12
public Ability[] abilities;                      // CharAbilities.cs:42
public CastFlags castFlags;                      // CharAbilities.cs:~131
public void OnTick(float fixedDt, Command cmd, bool isResim)   // CharAbilities.cs (predicted tick)
public void SetCastAbility(CastFlags castFlag)   // CharAbilities.cs
[ClientRpc] public void RpcCastResult(bool isSuccess)          // CharAbilities.cs
[ClientRpc] public void RpcAbilityReady(int cmdId)             // CharAbilities.cs
public void OnNetSerialize/OnNetDeserialize(NetworkWriter/Reader)  // CharAbilities.cs
```

The implications that matter:
- Casts run through the **command/tick** pipeline (`Command cmd`, `predTickNum`,
  `INetworkPredicted`, `INetworkSimulated`), are **predicted on the owner and reconciled by the
  server**, and produce `[ClientRpc]` results. Animation/state is driven by `Ability.state` /
  `AbilityStates` and `CharAbilities.castFlags`, which are serialized.
- A concrete ability such as `ArrowAbility` spawns a **networked** projectile:
  `public GameObject spellPrefab;` (`ArrowAbility.cs:36`) and
  `public void Shoot(Vector3 spawnPosition, Vector3 lookDir, int predTickNum)`
  (`ArrowAbility.cs:~117`). `spellPrefab` is a `HitboxBase`.

### 1.4 Hitboxes/projectiles are themselves replicated objects

```
HitboxBase : NetworkBehaviour, IPoolDespawnListener   // HitboxBase.cs:11
public ProjectileMove projMove; public VFXSpawn vfxSpawn;   // HitboxBase.cs:13-15
[SyncVar] public int ownerPlayerId; [SyncVar] public int teamId;   // HitboxBase.cs:24-30
```

So the canonical attack flow is: ability tick → server spawns a `HitboxBase` prefab (pooled via
`NetworkPrefabLibrary`/`NetworkPrefabPool`) → Mirror replicates it (with its `VFXSpawn` and
`ProjectileMove`) to all clients → on overlap the server calls into the hurtbox/`OnTargetHit`. The
**visual** (mesh + particles) rides along on the replicated hitbox and on the replicated character
prefab; it is never "spawned locally per client."

### 1.5 Rendering/animation is a configured pipeline, not free Animator calls

`CharAnimator` expects a controller whose **layers, parameter hashes and state hashes** it caches
and drives every frame:

```
CharAnimator : MonoBehaviour                     // CharAnimator.cs:8
public bool customAnimator; public Animator animator; AnimatorOverrideController animatorOverrideController; // :15-25
public int[] layers; public int[] paramHashes;  // CharAnimator.cs:~120-125
int stateNoneId, stateAirborneId, stateStunId, stateGrindId, stateKnockedId, emoteAnimId …  // :~127-145
void ManagedUpdate(); void SetMecanimState(int stateHash, AnimLayerIndices, float);
void CrossFadeMecanimState(int stateHash, AnimLayerIndices, float, float);
```

`CharMaterial` owns visibility/material state and a specific renderer set:

```
CharMaterial : MonoBehaviour                     // CharMaterial.cs:8
GameObject charRigObj; Transform charAnimatedRoot; Renderer charRenderer; Renderer[] extraRenderers; // :40-60
```

Movement (`CharMove`/`EntityMovement`) and animation parameters are produced by the **simulation
tick**, not by ad-hoc `Animator.CrossFade` calls.

**Net:** a custom character is correct only if it is a properly-registered networked **prefab
variant** (consistent assetId on all peers) whose `charId`, `Ability` components, animator
controller, and hitbox/projectile prefabs are all baked-in, server-authoritative, replicated game
data. The failed mod violated essentially every line of this contract.

---

## 2. What the failed mod actually does

`MedusaMod.cs` is a MelonLoader/Harmony mod that, at runtime **inside an already-running client**:

1. **Clones Kitsu's `CharacterConfiguration`** into a synthetic charId 15 (`CloneConfig`,
   `MedusaMod.cs:4844`; base is Kitsu via `ActiveDef.BaseCharId = 0`,
   `CustomCharFramework.cs:28`). It only swaps sprites/colors/ability **UI text**; the
   `AbilityData` it builds (`MakeAbility`) copies the base icon and changes only title/description
   keys.
2. **Clones Kitsu's character prefab** at runtime (`Object.Instantiate` of
   `characterPrefabsByCharId[base]`), grafts a custom visual GameObject onto it
   (`GraftMedusaVisual`), appends it into `characterPrefabsByCharId`, and stamps a **hand-picked
   Mirror assetId** `0x4D454455` (`MedusaMirrorAssetId => ActiveDef.MirrorAssetId`,
   `MedusaMod.cs:1563`; `CustomCharDefinition.MirrorAssetId = 1296385109u`,
   `CustomCharFramework.cs:40`).
3. **Sanitizes/zeroes Mirror identity fields** on that runtime clone (`SanitizeMirrorIdentities`,
   sets `sceneId=0`, `_netId=0`, `hasSpawned=false`, `_SpawnedFromInstantiate=false`, then
   `InitializeNetworkBehaviours()`), and tries to register it into `NetworkManager.spawnPrefabs` /
   `NetworkPrefabPool` / `NetworkPrefabLibrary` at runtime.
4. **Keeps Kitsu's ability components** but tries to neuter them and run its own logic:
   - On a render-capable client it does **not** suppress the base `Shoot`; on the headless server
     it **does** (`TrySuppressInheritedKitsuShoot`, `MedusaMod.cs:2921`; gate
     `if (CanSpawnClientFx()) return false;`). The suppressors are Harmony prefixes on
     `CatShotAbility/CatMissileAbility/CatPolymorphAbility/CatJumpAbility/Arrow*…Shoot`
     (`MedusaMod.cs:955-1000`).
   - It nulls inherited VFX/`spellPrefab`/`catSpellPrefab*` references
     (`SuppressInheritedKitsuAbilityVfx`) — **server-only** (same `CanSpawnClientFx()` gate).
   - It runs a hand-rolled "authored driver" `RunAuthoredMedusaAbilityDriver`
     (`MedusaMod.cs:2986`) → `ApplyAuthoredMedusaGameplay` (`MedusaMod.cs:3178`) which manually
     `FindObjectsOfType<EntityManager>()`, cone/range-tests targets, and calls
     `charHurtbox.ApplyHit(...)` directly (`MedusaMod.cs:3433`), only when
     `((NetworkBehaviour)entity).isServer`.
5. **Spawns "attacks" as local, non-networked FX**: `SpawnMedusaCastFx` /
   `SpawnNativeMedusaHitbox` do `Object.Instantiate` of bundle VFX/hitbox prefabs and then strip
   every `NetworkIdentity`/`Hitbox`/`Projectile`/`Collider`/`AudioSource` component
   (`DisableNativeVfxGameplay`), explicitly described in-code as "CLIENT-SIDE PRESENTATION only."
   Everything is gated by `CanSpawnClientFx()` (`MedusaMod.cs:4496`), i.e. it only ever runs on a
   client with a GPU and is never `NetworkServer.Spawn`-ed.
6. **Reads raw input** to trigger those FX/driver: `PollLocalInputCastFx` (`MedusaMod.cs:2622`)
   polls `Input.GetMouseButtonDown(0/1)`, `Space`, `E` (`MedusaMod.cs:2629-2640`) on a 0.05s timer.
7. **Rebinds the animator** by Harmony: `CharAnimatorRebindPatch` sets
   `CharAnimator.animator = <medusa visual's Animator>` and `customAnimator = true`
   (`MedusaMod.cs:1325`), plus adds guard patches that **suppress** `Animator.SetLayerWeight` /
   `CrossFadeInFixedTime` when the layer index is out of range
   (`AnimatorSetLayerWeightMedusaGuardPatch`, `AnimatorCrossFadeInFixedTimeLayerGuardPatch`).
8. Manually plays one-shot clips: `PlayMedusaAbilityAnimation` does
   `animator.CrossFade("Ability1"/"Ability2"/"Ability4", 0.05f)` (`MedusaMod.cs:~3050`), and slot 2
   "Slither" calls `charMove.PostMove(...)` directly on the server (`ApplyMedusaSlitherMovement`,
   `MedusaMod.cs:3227`).

The whole design is a **client-side cosmetic graft + server-side manual damage**, bolted onto
Kitsu. None of the custom content is part of a replicated prefab. That single fact is the parent
cause of every observed symptom.

---

## 3. Failure → root cause mapping

### (a) Other players don't see the custom visuals or attacks (everything is local-only)

**Observed:** the custom character's body and its attacks are visible only to the local player;
remote players see nothing custom (and, where they see anything, they see base Kitsu).

**Root cause — visuals:** the custom visual is never part of a replicated object. Mirror
reconstructs a remote character solely from the spawn message's **assetId**, looking it up in *that
client's* prefab table to instantiate the registered prefab (§1.2). The mod's grafted visual lives
on a **runtime-instantiated clone created independently inside each process** (`RegisterPrefab` →
`Object.Instantiate` + `GraftMedusaVisual`), never authored into the shipped prefab, and the visual
graft itself (`BindMedusaVisualToCharMaterial`, `ForceMedusaCharMaterialVisible`, the live-binding
poll) is applied **per-client to whichever local entity the client *guesses* is Medusa**
(`EnsureLiveMedusaEntity`, `FindBestLocalMedusaEntity`). There is no SyncVar, RPC, or serialized
field carrying "this entity uses the Medusa visual." A remote client receives only `charId`
(`EntityManager.cs` SyncVar) and instantiates **its own** prefab at that index — which, on the
authoritative server path, is effectively still the Kitsu-derived clone with no custom mesh baked
in. So the custom mesh exists only in the process that grafted it.

**Root cause — attacks:** attacks are spawned with `Object.Instantiate` and deliberately stripped
of `NetworkIdentity` (`DisableNativeVfxGameplay`), gated to render-capable clients
(`CanSpawnClientFx()`, `MedusaMod.cs:4496`), and triggered by **local** `Input.*` polling
(`PollLocalInputCastFx`, `MedusaMod.cs:2622-2640`). They are never `NetworkServer.Spawn`-ed, so
they cannot replicate — contrast the real path where attacks are `HitboxBase : NetworkBehaviour`
prefabs spawned server-side and replicated with their `VFXSpawn`/`ProjectileMove`
(`HitboxBase.cs:11-15`). Worse, the real ability that *would* have spawned a networked projectile
is actively suppressed on the server (`TrySuppressInheritedKitsuShoot` returns `true` on headless,
`MedusaMod.cs:2921`) and its `spellPrefab` nulled (`SuppressInheritedKitsuAbilityVfx`). The only
gameplay effect that crosses the network is raw damage applied by `charHurtbox.ApplyHit(...)` on
the server (`MedusaMod.cs:3433`) with **no associated replicated hitbox**, so other players see HP
drop with no projectile, no muzzle, no impact.

**What the correct approach must do:** bake the visual into the shipped, registered character prefab
so it spawns identically from one assetId on all peers (§1.2); make every ability spawn its
projectile/AoE as a **networked** `HitboxBase` prefab via the game's server spawn/pool path so the
mesh+VFX replicate to all clients (§1.4); never `Object.Instantiate` gameplay objects client-side
as a substitute for replication.

### (b) The entity despawns

**Observed:** the custom character appears briefly, then vanishes.

**Root cause:** the clone is not a valid, consistently-registered Mirror spawnable, so the spawn
handshake breaks. Concretely:

1. **AssetId mismatch / unregistered on peers.** The mod stamps `_assetId = 0x4D454455`
   (`MedusaMod.cs:1563`, `CustomCharFramework.cs:40`) on a clone it builds at runtime, and tries to
   register it after the fact (`TryAddSpawnPrefab`, `TryRegisterNetworkPrefabPool`). Mirror requires
   the prefab to be in the spawnable table **before** spawn and **identical on server and every
   client**. A remote client that never registered `0x4D454455` (or registered a *different*
   runtime clone) cannot resolve the spawn message → the object is never created or is immediately
   discarded on that client. The mod's own log path even concedes it "delegated to spawnPrefabs …
   skipped direct NetworkClient.RegisterPrefab," meaning client registration is racy/uncertain.
2. **Identity surgery on a live graph.** `SanitizeMirrorIdentities` zeroes `sceneId`, `_netId`,
   `hasSpawned`, `_SpawnedFromInstantiate`, clears `_connectionToClient/Server`, then calls
   `InitializeNetworkBehaviours()` on a clone of an object that has nested `NetworkBehaviour`s
   (`CharAbilities`, every `Ability`, etc., all `NetworkBehaviour` per §1.3). If the live spawned
   instance's identity state is inconsistent with what the server expects, Mirror's
   `destroyCalled`/interest pipeline tears it down.
3. **Server actually spawns a different/parallel prefab.** For bots the mod *forces a fallback to
   the base charId* (`GameNetworkManagerGetCharacterBotPrefabPatch`, charId Medusa → base). The
   authoritative match-host (Wine/Linux, `-batchmode -nographics` per the CustomServer runbook) is
   a separate process; whatever it actually spawns at index 15 must match every client's table.
   The runtime-clone-per-process model cannot guarantee that, so the host/clients disagree about the
   object's identity and the AoI/interest manager (`CustomSpatialHashInterestManagement`, referenced
   on `GameNetworkManager` as `aoi`) or Mirror's own validation **despawns** it.

**What the correct approach must do:** register the character prefab as a first-class spawnable in
the shipped data with a **stable, build-time assetId present identically on server and clients**,
added to `spawnPrefabs`/`NetworkPrefabLibrary` **before `OnStartServer`/client connect**, never
mutate identity state on live clones, and never rely on per-process runtime cloning.

### (c) Frozen poses (Standbilder)

**Observed:** the custom model stands in a static/default pose; locomotion and most animation never
play.

**Root cause:** the grafted visual ships a **custom Animator + RuntimeAnimatorController whose
layer/parameter/state layout does not match what `CharAnimator` expects**. `CharAnimator` caches
`layers[]`, `paramHashes[]`, and a fixed set of state ids
(`stateNoneId/stateAirborneId/stateStunId/stateGrindId/stateKnockedId/emoteAnimId…`,
`CharAnimator.cs:120-145`) from the **base (Kitsu) controller**, and drives the rig every frame via
`SetMecanimState`/`CrossFadeMecanimState`/`ManagedUpdate` using those hashes
(`CharAnimator.cs:185-225`) with parameters produced by the simulation tick. When the mod rebinds
`CharAnimator.animator` to the foreign Medusa Animator (`MedusaMod.cs:1325`), those cached
hashes/layers no longer exist on the new controller, so:
- `Animator.SetLayerWeight`/`CrossFadeInFixedTime` target invalid layer indices — which the mod
  itself has to **suppress** with guard patches (`AnimatorSetLayerWeightMedusaGuardPatch`,
  `AnimatorCrossFadeInFixedTimeLayerGuardPatch`). Suppressing the locomotion layer blends means the
  locomotion blend tree never receives weight/parameters.
- The movement/turn parameters (`moveVel`, `localMove`, `MoveSpeedMult`, `isMoving`,
  `CharAnimator.cs:60-95`) are written to parameter hashes that don't exist on the custom
  controller → the controller stays in its default entry state = a single frozen frame.

The mod even documents (in its `IsLiveMedusaVisualStable` comment) that its earlier attempt to
repair this re-ran the heavy anchor/rebind path every frame and **"froze the pose (Standbilder)"** —
re-parenting/re-scaling/rebinding the visual repeatedly instead of letting a matching controller run.
On remote clients the problem is moot/worse because they see the base prefab anyway (§a).

**What the correct approach must do:** drive the custom character through the **same controller
topology** the engine expects — use an `AnimatorOverrideController` layered over the base controller
so all layer/parameter/state **hashes remain identical** (only the clips are swapped), and let the
normal simulation tick feed parameters. Never hand-rebind a structurally different controller and
never suppress the engine's own layer/crossfade calls.

### (d) Abilities broken: only LMB works, RMB = green dot, Space bugs out, E = Kitsu's animation

**Observed:** LMB attacks roughly work; RMB shows only a green dot; Space misbehaves; E plays
Kitsu's animation.

**Root cause — the abilities are still literally Kitsu's `Ability` components.** The clone keeps
Kitsu's `ability1..ability4` component instances (only their **UI text** is swapped in
`CloneConfig`/`MakeAbility`, `MedusaMod.cs:4844`). The mod then tries to override behavior with a
client/server-split hack that is internally inconsistent:

- **LMB (Ability1) "works":** it is a simple single-target projectile. On the client the base
  `Shoot` is **not** suppressed (`TrySuppressInheritedKitsuShoot` returns `false` when
  `CanSpawnClientFx()`), so the predicted Kitsu shot plays locally, and the server's manual
  `ApplyAuthoredMedusaGameplay`/`ApplyHit` (`MedusaMod.cs:3178/3433`) applies damage. The two
  happen to line up well enough for a basic shot to *feel* like it works (still local-only visually,
  per §a).
- **RMB (Ability2) = "green dot":** the real ability's `spellPrefab`/`vfxCastPrefab` were nulled by
  `SuppressInheritedKitsuAbilityVfx` and the client FX fallback is **intentionally disabled** (code:
  "green primitive fallback intentionally disabled"). The native bundle VFX/hitbox is gated by
  `CanSpawnClientFx()` and frequently unavailable, so nothing spawns. What remains visible is the
  ability's **targeting indicator** (the green `IndicatorMouse`/targeting reticle) with no actual
  ability firing — i.e. a "green dot" and nothing else. The networked projectile path was removed
  on the server and never replaced with a networked one.
- **Space (Ability3) bugs out:** Kitsu's slot-3 is a movement ability (`CatJumpAbility`). Its real
  flow is a **predicted/server-reconciled** state machine (`Ability.state`, `CastSubroutine`,
  `INetworkPredicted` tick, §1.3). The mod nulls its jump/land VFX and `spellPrefab`, suppresses its
  `Shoot` on the server, then on the server only calls `charMove.PostMove(...)` directly
  (`ApplyMedusaSlitherMovement`, `MedusaMod.cs:3227`) outside the prediction/reconciliation loop.
  Client prediction and server authority now disagree about position/state → rubber-banding,
  desync, "bugs out."
- **E (Ability4) plays Kitsu's animation:** slot-4 is still Kitsu's ult **component**, unchanged.
  When cast it runs Kitsu's authored ability logic and its **own animation events**; the mod's
  cosmetic `CrossFade("Ability4")` (`PlayMedusaAbilityAnimation`) cannot override the ability's
  built-in Kitsu animation driving. So E visibly plays Kitsu's ult animation — the most direct proof
  that "cloning the config + swapping UI text" does not create new abilities.

The deeper reason all four are fragile: casts are supposed to flow through the
**command/cmdId + tick + prediction** pipeline (`Ability.cmdId`, `CharAbilities.OnTick`,
`SetCastAbility(CastFlags)`, `RpcCastResult`, `RpcAbilityReady`, §1.3). The mod instead drives them
from **raw `Input` polling** (`PollLocalInputCastFx`, `MedusaMod.cs:2622-2640`) and from Harmony
hooks on `SetState`/`Shoot`, bypassing prediction, reconciliation, cooldown subroutines, and
replication. Anything not expressible as "suppress Kitsu + manually apply damage" simply breaks.

**What the correct approach must do:** define each ability as a **real `Ability`/`CharAbilities`
component** baked on the prefab with the correct `cmdId` (LMB/Q/Space/E), server-authoritative
`OnTargetHit`, tick-driven `state` machine, cooldowns, and a **networked** `spellPrefab`
(`HitboxBase`) for projectiles/AoE — i.e. author **new abilities** the same way the base game
authors Kitsu's, so they predict, reconcile, replicate, animate, and apply status correctly for all
players. New abilities should be new `Ability` subclasses (or a data-driven ability that the game
ticks), not Kitsu components with relabeled tooltips.

---

## 4. The single root cause, stated once

The clone approach treats a character and its abilities as **client-side cosmetic decorations
grafted onto a runtime clone of Kitsu**, while BAPBAP treats them as **server-authoritative,
Mirror-replicated game data**:

- identity/visual comes from a **registered spawnable prefab keyed by a stable assetId**, identical
  on server and all clients (§1.1–1.2) → graft is invisible to others and the unregistered clone
  despawns (failures a, b);
- abilities are **networked `Ability` `NetworkBehaviour`s** with `cmdId`, tick prediction, server
  authority, and networked `HitboxBase` projectiles (§1.3–1.4) → relabeled Kitsu components +
  local FX + manual damage break (failures a, d);
- animation is a **fixed controller topology** the engine caches and drives (§1.5) → a foreign
  controller with mismatched layers/params freezes the pose (failure c).

Every observed symptom is a direct consequence of standing outside that replicated-prefab contract.

## 5. Requirements handed to the synthesis stage

1. **Authoritative spawnable prefab.** Ship the custom character as a real prefab variant added to
   `GameNetworkManager.characterPrefabsByCharId` and the Mirror spawnable set
   (`spawnPrefabs`/`NetworkPrefabLibrary`) with a **build-time-stable assetId present identically on
   server and every client, before networking starts**. No runtime per-process cloning, no live
   identity surgery.
2. **`charId`-keyed registration on both sides.** Because `EntityManager.charId` is the SyncVar that
   selects the prefab/config/animator (§1.1), the new charId must resolve to the **same** prefab and
   config on the dedicated host and all clients.
3. **Baked visual + override-controller animation.** Visual mesh/skeleton baked into the prefab;
   animation via `AnimatorOverrideController` over the base controller so `CharAnimator`'s cached
   `layers/paramHashes/state ids` stay valid (§1.5) — no frozen poses, no suppressed layer writes.
4. **First-class networked abilities.** Each ability is a real `Ability`/`CharAbilities` component
   with correct `cmdId`, server `OnTargetHit`, tick/prediction, cooldowns, and a **networked
   `HitboxBase` `spellPrefab`** so projectiles/AoE + their VFX replicate to all players (§1.3–1.4).
5. **Use the engine's input/command path**, not raw `Input` polling, so casts are predicted,
   reconciled, and replicated.
6. **Damage/status through the real hitbox pathway** (`HitboxBase` → hurtbox/`OnTargetHit` →
   `CharStatusEffects`), not a server-side `FindObjectsOfType` + `ApplyHit` scan.
7. **Extensibility goal:** because everything is data on a prefab + ability components, adding a new
   character or new ability becomes "author a new prefab/ability + register its assetId/charId,"
   reproducible across server and clients — the opposite of the fragile graft.

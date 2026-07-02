# Medusa — custom character, native rig + toon shader + animator + native venom poison + petrify ult

Adds **Medusa** as a new playable character to the BAPBAP Battleroyale build. She runs
**100% native** for the parts the game's content can express:

* her real **3D model + 59-bone rig + skinned mesh + Avatar** (backported from an
  AssetRipper export of an upstream build that already had Medusa),
* her real **Animator + `Medusa.controller` + 22 animation clips**, with
  **the game's `BAPBAP.Entities.CharAnimator` driving her live** (param-compatible
  controller),
* her material re-shaded with the game's **native toon shader
  `Custom/Toon/Toon_Character_Amplify`**, lifted at runtime from a live native
  character's material (Kitsu) and re-applied with **Medusa's own Albedo and Normal
  textures** preserved,
* **v1.4.0**: her **ult (slot 3 / E key) now natively applies `SE_Petrified`** to every
  character it hits via a Harmony postfix on `HitboxBase.OnHitSuccess`, fully wiring the
  shipped `SE_Petrified.Activate` engine path — `CharFX.EnablePetrifyFx` + petrify
  material overlay + motion lock + replication all auto-fire from there.
* **v1.5.0**: her **venom attacks (slot 0 LMB / slot 1 Q) now natively apply
  `SE_Poisoned`** on hit through the same server-side hit postfix, so her basic kit
  actually poisons (DoT) — the engine's own `SE_Poisoned.Activate` brings the native
  poison FX. Both status effects ship in the BR build; no extra bundling needed.

She has her own Gorgon-themed ability identities, descriptions, tuned stats, and an
injected localization layer. Standalone mod; builds on the BAPBAP ModAPI.

## v1.5.0: Per-slot status — fully honest

Medusa has no bespoke ability scripts/SOs anywhere (verified 3 ways, below), so her
ability **mechanics** reuse the working cloned base kit. On top of that, her real,
native **status effects** are applied on the server-side hit pipeline:

| Slot | Display title    | Mechanic base        | Native status on hit |
|------|------------------|----------------------|----------------------|
| 0 (LMB)   | Serpent Bolt     | Kitsu-clone (themed) | **`SE_Poisoned`** (venom DoT) |
| 1 (Q)     | Venom Spit       | Kitsu-clone (themed) | **`SE_Poisoned`** (venom DoT) |
| 2 (Space) | Slither          | Kitsu-clone (themed) | — (mobility) |
| 3 (Ult/E) | Petrifying Gaze  | Kitsu-clone (themed) | **`SE_Petrified`** (stone-root) |

Both `SE_Poisoned` and `SE_Petrified` ship in the Battleroyale build and are reached at
runtime via `BAPBAP.Local.StatusEffectManager.statusEffects[]`; each effect's own
`Activate()` drives the game's native poison/petrify FX + motion handling + replication.

### Why slots 0–2 stay on the Kitsu scaffold (verified evidence, not assumption)

The upstream "Latest" build was scanned three independent ways for any data-driven
Medusa ability content (`AbilityBehaviourSO` instances, `SimulationFsm` graphs, or
`Ability` C# subclasses):

1. **Full IL2CPP dump search** of the Latest `GameAssembly.dll`'s 41 MB `dump.cs`
   (produced by `Il2CppDumper.exe` on the Latest GameAssembly + global-metadata):
   *0 Medusa hits*, *6 Petrify hits all generic*, *0 Gorgon/Hiss/Slither/Venom hits*,
   *109 `Ability` subclasses none of which mention Medusa*.
2. **Raw binary scan** of the Latest `GameAssembly.dll` for the literal strings
   `Medusa`/`Petrify`/`AB_Medusa`/`MedusaPoison`/`Gorgon`: *0 hits each*.
3. **Full ScriptableObject inventory** across all 4 Latest asset bundles
   (71,187 MonoBehaviours, 5,370 MonoScripts): exactly **22 `AbilityBehaviourSO`
   instances** total — *none named Medusa-anything*.

In other words: **Medusa is a visual+animation asset drop in the upstream depot. Her
runtime gameplay scripts simply do not exist yet, anywhere.** Her `Medusa.prefab` has
31 components, every one a generic `Char*` component (CharAbilities, CharSimulation,
etc.) — **no `Ability` subclass instance, no `BehaviourAbilityComponent` GameObject,
zero ability child-GOs**. By contrast `Eve.prefab` in the same export has 4 explicit
`Eve*` Ability subclasses on child GameObjects.

The Battleroyale `dump.cs` does have the entire generic ability-system palette
(45 `AB_*_SO` templates, 61 `*Subroutine` FSM-node types, full `Hitbox`/`HitboxBase`/
`ProjectileMove`/`VFXSpawn`/`SimulationFsm`/`AbilityBehaviour`/`AbilityBehaviourSO`/
38 `SE_*` status effects), so a brand-new Medusa kit could be authored from those
generics later (see "Future paths" below). v1.4.0 does **not** invent that kit — it
only wires what is *honestly* available: native petrify on the ult.

### How the petrify ult is wired (v1.4.0)

At `OnInitializeMelon` the mod installs a Harmony postfix on
`Bap.Entities.HitboxBase.OnHitSuccess(EntityManager)` (the server-side success
callback that fires from inside `Hitbox.DoEntityHit` after damage + the hitbox's
own `_statusEffects` list have been applied). The postfix:

1. Reads the hitbox's owning `Ability` (`HitboxBase.ability`).
2. Checks `Ability.entityManager.charId == MedusaCharId (= 15)` AND
   `Ability == CharAbilities.abilities[3]` — i.e. *this is Medusa's slot-3 ult cast*.
3. Lazily resolves `SE_Petrified_SO` from the live
   `BAPBAP.Local.StatusEffectManager.statusEffects[]` array.
4. Builds a `StatusEffectInfo(SE_Petrified_SO, 2.5f, 1f)` and calls
   `victim.charStatusEffects.ActivateStatusEffect(info, ownerPid, dir, false)`.
5. The engine's `SE_Petrified.Activate` path then auto-runs `CharFX.EnablePetrifyFx`,
   applies the petrify material overlay, locks motion via `EntityMovement`, and
   replicates the SE through the existing `CharStatusEffects` net plumbing.

We **do not** call `EnablePetrifyFx`/`ApplyOverlay`/motion-lock manually — the
upstream petrify-deepdive analysis of `SE_Petrified.Activate` (RVA 0x66D090) shows
those are owned by the engine and double-firing them desyncs FX with the SE
lifetime.

> ### Why the patch target is `HitboxBase.OnHitSuccess` and NOT `Hitbox.DoEntityHit`
> `Hitbox.DoEntityHit(Hitbox.EntityHit entityHit)` would have been the most direct
> hook (it's the canonical [Server]-decorated hit-application path). However, its
> argument is an IL2CPP value-type STRUCT (`Hitbox.EntityHit`, with no namespace).
> Il2CppInterop's Harmony bridge cannot compile a delegate type with an embedded
> IL2CPP struct — it raises
> ```
> System.IO.FileLoadException: Could not load file or assembly
>   'FixedSizeStructAssembly' ...
> InvalidOperationException: Dynamically emitted assemblies are unsupported
>   during host-based resolution.
> ```
> at `PatchAll` time **regardless of whether the postfix actually uses the struct
> arg**. Repointing the patch at `HitboxBase.OnHitSuccess(EntityManager)` (pure
> reference-type param, called from inside `DoEntityHit`'s success branch with the
> just-hit entity) avoids the limitation entirely.

### Live test (Battleroyale build, v1.4.0, offline-dev autostart, 90 s run, 2026-05-30)

```
[Medusa] Loaded (v1.4.0). Auto-registers at the lobby; /medusa or F7 to force, /medusa status, /medusa anim.
[Medusa] v1.4.0: native Animator + native toon shader + native petrify ult. Bundle: UserData\Medusa\medusa.bundle.
[Medusa] bundle file located: '...\Battleroyalebuild\UserData\Medusa\medusa.bundle' (1275524 bytes).
[Medusa] AssetBundle loaded (handle obtained).
[Medusa] bundle contains 30 asset(s). Sample: assets/animationclip/medusa_attack_01.anim | ...
[Medusa] visual prefab 'Medusa_Visual' loaded from bundle.
[Medusa] Harmony rebind patches installed (CharAnimator.Awake + CharFootsteps.Awake postfixes).
[Medusa] Harmony petrify-ult patch installed (HitboxBase.OnHitSuccess postfix).
[Medusa] UICharactersConfiguration first seen at poll #1 (roster=15).
[Medusa] cloning base character 'Kitsu' (charId=0).
[Medusa] graft: captured native toon template - SMR='KitsuBase', material='Kitsu_Material', shader='Custom/Toon/Toon_Character_Amplify'.
[Medusa] graft: disabled 1 base SkinnedMeshRenderer(s).
[Medusa] graft: shader applied to 'MedusaBase' (shader='Custom/Toon/Toon_Character_Amplify', albedo='Medusa_Tex_Albedo_1024', normal='Medusa_Tex_Normal_1024').
[Medusa] graft: applied native toon shader 'Custom/Toon/Toon_Character_Amplify' to 1 Medusa SkinnedMeshRenderer(s).
[Medusa] graft: wired CharAnimator.animator -> Medusa's Animator (count=1, customAnimator=true, controller='Medusa').
[Medusa] graft: wired CharFootsteps.animator -> Medusa's Animator (count=1).
[Medusa] graft: disabled 3 non-Medusa Animator(s) on the clone.
[Medusa] graft: instantiated Medusa_Visual under clone (SkinnedMeshRenderers=1, animator=yes, controller='Medusa').
[Medusa] prefab cloned -> characterPrefabsByCharId[15] (visualGrafted=True).
[Medusa] made 16 characters available in lobby (incl. Medusa).
[Medusa] tuned CharAbilities: damage 0->0, attackSpeed 1->0.9, cooldown 1->1.1, critChance 0->0.2, maxAttackSpeed 10->9.5.
[Medusa] phrases injected (added=14, updated=0, total=14). Sample MEDUSA_AB_LMB_TITLE -> 'Serpent Bolt'.
[Medusa] ✓ registered as CharId=15, name='Medusa'. Roster now 16.
[Medusa] anim(prefab): name='Medusa_Visual' enabled=True controller='Medusa' parameterCount=0
[Medusa] anim(LIVE): no Medusa instance in the active scene yet (need a match with someone selecting Medusa).
```

Game survived the full 90 s test, **no native crash**, **no Medusa exceptions**,
**no `HarmonyException`/`FixedSizeStruct` errors**. Process was cleanly stopped only
by its own PID — strict isolation. The single non-Medusa exception in the log is the
pre-existing `OfflineDevMode.OpenDevLobby` NRE (unrelated, present since v1.0).

The petrify hook is *installed and ready to fire*. It cannot be observed firing in
this automated harness because the offline-dev autostart does not select Medusa or
cast her ult — that requires a real match with a player selecting Medusa and pressing
E. The `[Medusa] PETRIFY applied (#N) to '<victim>'...` log line will fire on every
ult-hit in such a match. `/medusa status` reports the live counters
(`hitsObserved`, `applied`, `petrifyId`).

## What's in `medusa.bundle` (Standalone Win64, Unity 2022.3.38f1, ~1.22 MiB / 1,275,524 bytes)

**v1.4.0 ships the same bundle as v1.3.0** — visuals, rig, animator, animation clips,
material, textures. The bundle was *not* extended in v1.4.0 because the petrify wiring
piggy-backs entirely on assets BR already ships in `sharedassets0.assets`
(`SE_Petrified` SO at pathId 94852, plus its referenced VFX prefabs and `petrifyMaterial`),
all reachable via `BAPBAP.Local.StatusEffectManager.statusEffects[]` at runtime.

| Asset                           | Notes                                                               |
| ------------------------------- | ------------------------------------------------------------------- |
| `Medusa_Visual.prefab`          | clean visual prefab; 29 IL2CPP-stub MonoBehaviours stripped         |
| `MedusaBase.asset`              | skinned mesh, full rig                                              |
| `Medusa_Material.mat`           | Standard fallback in the bundle — replaced at runtime by the native toon material clone |
| `Medusa_Tex_Albedo_1024.png`    | albedo (kept; re-applied to the native material)                    |
| `Medusa_Tex_Normal_1024.png`    | normal map (kept; re-applied)                                       |
| `Medusa.controller`             | animator controller (param-compatible with `CharAnimator`)          |
| `Medusa_Anims_v03Avatar.asset`  | humanoid avatar                                                     |
| `Medusa_Idle.anim`, `Medusa_Idle_Blend.anim`, `Medusa_Idle_Turn_Left.anim`, `Medusa_Idle_Turn_Right.anim` | idle states |
| `Medusa_Attack_01.anim`, `_02`, `_03` | attack clips |
| `Medusa_Run_Forward.anim`, `_Forward_Left`, `_Forward_Right`, `_Backward`, `_Backward_Left`, `_Backward_Right`, `_Strafe_Left`, `_Strafe_Right` | locomotion |
| `Medusa_Walk_Forward.anim`, `_Forward_Left`, `_Forward_Right`, `_Backward`, `_Backward_Left`, `_Backward_Right`, `_Strafe_Left`, `_Strafe_Right` | locomotion |

Total: **30 assets** (1 prefab + 1 mesh + 1 material + 2 textures + 1 controller + 1 avatar + 22 clips + 1 typetree dependency).

### What was *checked*, considered for backporting, and intentionally NOT bundled

Five well-formed inert prefabs exist in the upstream export
(`...\neueBapbap\GameCode\ExportedProject\Assets\GameObject\`):
`Hitbox_MedusaPoisonProjectile`, `Hitbox_MedusaPoisonPuddle`, `Hitbox_MedusaWallPoison`,
`Hitbox_MedusaWallBoxDpsPoison`, `MedusaPuddleSpawner`. They reference only generic
script types (`ProjectileMove`/`VFXSpawn`/`Hitbox`/`HitboxDps`/`ColliderEnable*`/
`BehaviourTimedEnableSync`/`FogOfWarOcclusionMeshBuilder`) all confirmed present in
BR, plus the `SE_Petrified.asset` ScriptableObject.

These prefabs were *not* bundled in v1.4.0 because:

* They reference scripts via guid-based MonoScript references (e.g.
  `f5de03243f0810025e7802b3b315681e` for `ProjectileMove`). For Unity's bundle build
  pipeline to preserve the prefab's serialized field data through to the bundle, the
  bundle project needs **stub C# scripts whose `.meta` files carry those exact
  guids**, AND whose serialized field definitions match each script's IL2CPP shape
  (so Unity's typetree-based serializer writes the correct field-by-field binary
  blob). Without the stubs, the imported prefabs lose their MonoBehaviour data
  ("missing script" → serialized as `m_Script: {fileID:0}`).
* AssetRipper's full `Scripts/Assembly-CSharp/` stub library (thousands of `.cs`
  files) would need to be added to the bundle project, with manual fixups for the
  many compile errors stub-only mode produces.
* Without an actual Medusa **AbilityBehaviourSO** to drive these prefabs (none
  exists — see the three-way verification above), the prefabs by themselves don't
  deliver gameplay.

This is documented as the "honest gap" so future work can pick it up if the LATEST
depot ever ships real Medusa data-driven SOs (or if someone is willing to author 4
new SOs in-editor that point at these prefabs — outlined below as path A).

## How registration + graft works (full pipeline)

1. **`OnRegistered`**: eager-load `UserData/Medusa/medusa.bundle`. Cache the
   `Medusa_Visual` GameObject prefab.
2. **Harmony**: install `CharAnimatorRebindPatch` + `CharFootstepsRebindPatch`
   postfixes (rebind safety-net) and **v1.4.0** `HitboxDoEntityHitPetrifyPatch`
   postfix on `HitboxBase.OnHitSuccess(EntityManager)` (petrify-on-hit).
3. At lobby load, find `UICharactersConfiguration`.
4. Clone Kitsu's `CharacterConfiguration` (name → "Medusa", description → MEDUSA_DESC,
   snake-green color, lobby+devLobby enabled, ability1..4 keys retargeted to Medusa
   localization keys).
5. Clone Kitsu's network prefab. Then **`GraftMedusaVisual`** on the clone:
   capture the native toon shader, disable base SMRs, instantiate Medusa_Visual
   under the clone, retexture toon material with Medusa albedo/normal, wire
   `CharAnimator.animator`/`CharFootsteps.animator`, disable other animators.
6. Append the clone to `GameNetworkManager.characterPrefabsByCharId[15]`.
7. Append Medusa to `_characters` + `_lobbyCharacters`, `UpdateAvailableCharacterList`.
8. Tune `CharAbilities` on the cloned prefab.
9. Inject the 14 phrases into the live `Translator.phraseLookup`.

## The kit (theme; mechanically slots 0–2 = Kitsu)

| Slot   | Title             | Theme                                    |
| ------ | ----------------- | ---------------------------------------- |
| LMB    | Serpent Bolt      | Ranged venom bolt — applies **SE_Poisoned** (NATIVE) |
| Q      | Venom Spit        | Area venom — applies **SE_Poisoned** (NATIVE) |
| SPACE  | Slither           | Mobility, knock-up at the launch point   |
| **ULT** | **Petrifying Gaze**   | **Pierces obstacles + applies SE_Petrified to every hit (NATIVE)** |

Stat tuning on the prefab (multiplicative bumps off the Kitsu base):

```
damage          ×1.40
attackSpeed     ×0.90   (slightly slower)
cooldown        ×1.10   (slightly longer)
critChance      max(base, 0.20)   (floor at 20%)
maxAttackSpeed  ×0.95
```

## Localization

`UIAPI.Manager.translator.phraseLookup` is exposed by Il2CppInterop. The mod
inserts 14 entries on registration:

```
MEDUSA_NAME, MEDUSA_DESC,
MEDUSA_AB_LMB_TITLE   / _DESC_SHORT / _DESC,
MEDUSA_AB_Q_TITLE     / _DESC_SHORT / _DESC,
MEDUSA_AB_SPACE_TITLE / _DESC_SHORT / _DESC,
MEDUSA_AB_ULT_TITLE   / _DESC_SHORT / _DESC.
```

The mod re-resolves one of those keys via `Translator.LocalisePhrase` to verify
the write took effect.

## Honest limits (intentionally documented + logged)

* **Ability mechanics (all 4 slots) reuse the cloned base kit** — there is no real
  Medusa data-driven SO in the upstream Latest depot to backport (verified 3 ways
  above). Authoring brand-new `AB_*_SO` SOs from BR generics is separate, larger work
  (see "Future paths"). Names + descriptions + stat tuning give the slots Medusa flavour.
* **Slots 0 (LMB) + 1 (Q) apply real `SE_Poisoned` natively** on hit (v1.5.0), and
  **slot 3 (ult) applies real `SE_Petrified` natively** (v1.4.0), both via the
  server-side hit postfix. The status visuals + DoT/motion-lock + replication are the
  engine's own `SE_*.Activate` bodies — not re-implementations. Durations are tuning
  constants (`POISON_DURATION` 3.0 s, `PETRIFY_DURATION` 2.5 s).
* **Authority on official servers.** Tier C (matchmade): the server doesn't know
  CharId 15; cosmetic/roster only there. Tier B (host / dev lobby) is where this
  is fully usable. The petrify hook fires on the authoritative server — both
  `CharStatusEffects.ActivateStatusEffect` overloads are `[Server]`-decorated and
  no-op silently on the client side.
* **Live ult-hit verification requires manual play.** The offline-dev autostart
  harness boots into a dev lobby + match but does not select Medusa or cast her
  ult, so the petrify postfix's "applied" counter stays at 0 in headless test
  runs. Use `/medusa status` after a real match for the live counters.

## Build pipeline (unchanged from v1.3.0)

* `medusa-mod/backport/MedusaBundleProject/` — minimal Unity 2022.3.38f1 project
  that ships only Medusa's visual asset closure. Build via
  `Assets/Editor/BuildMedusaBundle.cs` (executes `BuildMedusaBundle.Build`) headless:
  ```
  "C:\Program Files\Unity\Hub\Editor\2022.3.38f1\Editor\Unity.exe" \
    -batchmode -nographics -quit \
    -projectPath medusa-mod\backport\MedusaBundleProject \
    -logFile medusa-mod\backport\unity_build.log \
    -executeMethod BuildMedusaBundle.Build
  ```
* Output: `medusa-mod\backport\MedusaBundleProject\BuildOutput\medusa`. Copy to:
  * `Battleroyalebuild\UserData\Medusa\medusa.bundle`  (loaded at runtime)
  * `medusa-mod\medusa.bundle`                          (kept with the source)

The mod itself:

```
dotnet build medusa-mod/BAPBAP.Medusa.csproj -c Release
```

Auto-deploys `BAPBAP.Medusa.dll` to `Battleroyalebuild/Mods/`. Requires
`BAPBAP.ModAPI.dll` in `Mods/` + `UserLibs/`, references
`UnityEngine.Il2CppAssetBundleManager.dll` from `MelonLoader/net6/`.

## Triggers

* **Auto:** registers within ~1 s of the lobby loading (1-Hz poll, runs once).
* **F7** or chat **`/medusa`** — force registration.
* **`/medusa status`** — full report, **including v1.4.0 petrify state**:
  ```
  petrify: SO='SE_Petrified' petrifyId=N lookupAttempted=True lookupSucceeded=True
           hitsObserved=… applied=…
  ```
* **`/medusa anim`** — dump prefab + live animator state.

## Future paths (NOT done in v1.4.0)

A. **Author 4 brand-new `AbilityBehaviourSO`s in the bundle project**, pointing at
   BR's existing generic SO bases (`AB_SpawnHitbox_Base_SO`, `AB_PoisonInfuse_SO`,
   `AB_SpawnEntityOnPos_Base_SO`, `AB_DimensionFollow_SO`) — clone their MonoScript
   references from BR's `sharedassets0.assets` into the bundle project's
   `Library/.../scripts.bundle`, retarget their hitbox/projectile/wall/vfx
   prefab fields to NEW Medusa-themed prefabs authored in the bundle project,
   add a `BehaviourAbilityComponent` per slot to `Medusa.prefab` referencing the
   SO's `id`, then have the runtime grafter call
   `behaviourAbilityComponent.SetAbilityBehaviour(id, SO)` per slot. Requires
   editor-time work that v1.4.0's headless `BuildMedusaBundle.cs` does not do.

B. **Backport the 5 inert Medusa hitbox prefabs** as templates for path A's
   spawned hitboxes. Needs the AssetRipper IL2CPP-stub library copied into
   the bundle project (with full field signatures to preserve serialized data
   through the bundle build pipeline) — see "What was checked..." above.

Both paths are tracked in this README so a follow-up agent has a clean starting
point. v1.4.0's petrify ult does NOT depend on either being done.


---

## Full documentation + nativeness status

See **`DOCUMENTATION.md`** for the complete native-vs-placeholder matrix. Two FAQs:

* **Does she have a native char-select icon?** She appears natively in the selection grid
  (own CharId 15, selectable), but the icon **art is a placeholder (Kitsu's)** — her own
  2D UI sprites are not in the source export (only her 3D textures are). See DOCUMENTATION.md §3.
* **Does she have an XP / progression path?** **No, and a client mod can't add a native one** —
  BAPBAP character mastery/XP is server/account-backed (`CharMasteryPreviewResponse` etc. are
  backend responses). See DOCUMENTATION.md §4.

## Live-test status

The mod is load-verified (registers, grafts model/animator/shader, installs poison + petrify
hooks, no crash). An actual **in-match** test is currently blocked by the **offline harness,
not the mod**: this build has no online backend, so both the normal launch and the offline
dev-lobby hang before spawning a playable character (the dev-lobby never creates a player
object offline). Verifying her in real gameplay needs the game's real backend/login (where
she is already in the roster). See DOCUMENTATION.md §8.

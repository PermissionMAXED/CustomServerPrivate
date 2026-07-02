# Medusa Native Backport — BR Build Compatibility Report (brcompat)

Research/scoping only. No game/mod/server files were modified. This document is the only file written.
Date: 2026-06-10. Investigator: `brcompat` orchestrated session.

## TL;DR verdict

- **Unity versions match exactly: BR build = `2022.3.38f1`, both exported projects (`GameCode` and `GEHEIMBUILD`) = `2022.3.38f1`.** An AssetBundle built from the exported project **will load** in the current BR build. There is no cross-version barrier at all — they are the *same* engine version/revision.
- **Every MonoBehaviour script type used by `Medusa.prefab` (29 components) and the 4 hitbox prefabs exists natively in the current BR build's IL2CPP metadata.** There are **no new/Medusa-specific MonoBehaviour classes** anywhere — Medusa is assembled entirely from the standard shared character/hitbox component set that all BAPBAP characters use.
- **The catch (already proven by the existing project layout): pure visual/animator/mesh/material/VFX/collider assets round-trip perfectly through a bundle and "just work". MonoBehaviour *field data* (ability stats, hitbox prefab wiring, charId, spell references) does NOT survive — AssetRipper exported the script components as empty stubs because IL2CPP strips field metadata.** So the abilities cannot "come along for free" inside the prefab; they must still be wired at runtime (as the current mod does) or rebuilt from a base character.
- charId 15 is **not** natively accepted by the BR build (it ships 15 chars, indices 0–14). The mod manually extends the roster + prefab array + Mirror registration. There is no `CharacterCatalog` class; the character system is `UICharactersConfiguration.Characters[]` + `GameNetworkManager.characterPrefabsByCharId[]`.

---

## 1. Unity version comparison & AssetBundle cross-load verdict

### How the BR build version was determined
Read the raw header of the classic serialized file
`C:\Users\Administrator\Downloads\CustomServer\Spiel\Battleroyalebuild\bapbap_Data\globalgamemanagers`
(first 120 bytes, ASCII). The embedded version string is:

```
...2022.3.38f1\0...
```

The build is IL2CPP (presence of `GameAssembly.dll`, `bapbap_Data\il2cpp_data\Metadata\global-metadata.dat`, and MelonLoader `Il2CppAssemblies`). `UnityPlayer.dll`/`GameAssembly.dll` are dated 2026‑02‑11.

### Exported project versions
- `neueBapbap\GameCode\ExportedProject\ProjectSettings\ProjectVersion.txt` → `m_EditorVersion: 2022.3.38f1`
- `neueBapbap\GEHEIMBUILD\ExportedProject\ProjectSettings\ProjectVersion.txt` → `m_EditorVersion: 2022.3.38f1`

### Corroboration from the existing bundle
The currently-shipped `medusa-mod\medusa.bundle` header contains the tags `5.x.x` (AssetBundle archive format) and `2022.3.38f1` (Unity build version). The existing native backport project `medusa-mod\backport\MedusaBundleProject` is itself a 2022.3.38f1 project (its build log: `Version is '2022.3.38f1 (c5d5a7410213) revision 12965287'`) and its `BuildOutput\medusa` (1,567,424 bytes) is byte-for-byte the size of the shipped `medusa.bundle` — i.e. the live bundle was already built with the exact BR engine version.

### Verdict
**Fully compatible.** Same major.minor.patch *and* same revision. AssetBundle serialized type trees, class IDs, and TypeTree hashes are identical, so the BR runtime's `AssetBundle.LoadFromFile` / `Il2CppAssetBundleManager.LoadFromFile` (already used by the mod) loads it without version coercion. There is zero risk on the *engine/serialization* axis. The only compatibility risks are about **MonoBehaviour script identity and serialized field recovery** (sections 2 & 4), not the engine version.

---

## 2. MonoBehaviour script types vs the BR build

Method:
1. Read the prefab YAML and extracted every `m_Script: {fileID, guid, type:3}` reference.
2. Resolved each GUID to a class by matching the `.cs.meta` / `.dll.meta` files under `ExportedProject\Assets\Scripts` and `...\Assets\Plugins`.
3. Confirmed each class name is present in the **current BR build** IL2CPP metadata by regex-scanning
   `Spiel\Battleroyalebuild\bapbap_Data\il2cpp_data\Metadata\global-metadata.dat` for the literal type-name strings.
   (Note: `findstr` gives false negatives on this file because it has no line breaks and exceeds findstr's line buffer; a full-byte regex scan was used instead and returned positive matches.)

### 2a. `Medusa.prefab` — 29 components, all native, all present in BR

| Script (class) | Source / namespace | In BR build metadata? |
|---|---|---|
| `NetworkIdentity` | `Mirror.dll` (guid `f5de0324…`, fileID 860895539) | Yes (Mirror is in BR) |
| `CharAbilities` | `BAPBAP.Entities` | **Yes** |
| `CharAim` | `BAPBAP.Entities` | **Yes** |
| `CharAnimator` | `BAPBAP.Entities` | **Yes** |
| `CharBushInteract` | `BAPBAP.Entities` | **Yes** |
| `CharEvents` | `BAPBAP.Entities` | **Yes** |
| `CharFogOfWar` | `BAPBAP.Entities` | **Yes** |
| `CharFootsteps` | `BAPBAP.Entities` | **Yes** |
| `CharFX` | `BAPBAP.Entities` | **Yes** |
| `CharHidden` | `BAPBAP.Entities` | **Yes** |
| `CharHideArea` | `BAPBAP.Entities` | **Yes** |
| `CharHpRegen` | `BAPBAP.Entities` | **Yes** |
| `CharHurtbox` | `BAPBAP.Entities` | **Yes** |
| `CharInteract` | `BAPBAP.Entities` | **Yes** |
| `CharInterpolator` | `BAPBAP.Entities` | **Yes** |
| `CharItems` | `BAPBAP.Entities` | **Yes** |
| `CharLabelNear` | `BAPBAP.Entities` | **Yes** |
| `CharMaterial` | `BAPBAP.Entities` | **Yes** |
| `CharMinimap` | `BAPBAP.Entities` | **Yes** |
| `CharNetwork` | `BAPBAP.Entities` | **Yes** |
| `CharSimulation` | `BAPBAP.Entities` | **Yes** |
| `CharStatusEffects` | `BAPBAP.Entities` | **Yes** |
| `CharTriggerbox` | `BAPBAP.Entities` | **Yes** |
| `CharWorldPosition` | `BAPBAP.Entities` | **Yes** |
| `EntityManager` | `BAPBAP.Entities` | **Yes** |
| `EntityMovement` | `BAPBAP.Entities` | **Yes** |
| `EntityEventAnimator` | `BAPBAP.Entities.View` | **Yes** |
| `CircleShapeSprite` | `BAPBAP.UI` | **Yes** |
| `IndicatorBaseMaterial` | `BAPBAP.UI` | **Yes** |

There is **no `MedusaAbility`, `PoisonAbility`, `PetrifyAbility`, or any Medusa-named MonoBehaviour** on the prefab. A glob for `**/*edusa*.cs` under the exported `Scripts` tree returned **zero** files. Medusa's kit is data-configured on the shared `CharAbilities` + `Ability` subclasses, not via bespoke code.

### 2b. The 4 hitbox prefabs — all native, all present in BR

Components found (by resolving each `m_Script` GUID against `Assets\Scripts\Assembly-CSharp\…` and `Assets\Plugins\Mirror*.dll.meta`):

| Prefab | Component classes |
|---|---|
| `Hitbox_MedusaPoisonProjectile` | `NetworkIdentity` (Mirror), `NetworkTransformFollow`*, `ProjectileMove`, `HitboxDps`, `Rigidbody`, `BoxCollider` |
| `Hitbox_MedusaPoisonPuddle` | `NetworkIdentity`, `NetworkTransformFollow`*, `TransformExpandRadius`, `VFXSpawn`(or `ColliderEnable`)†, `HitboxDps`, `SphereCollider`, `AudioSource` |
| `Hitbox_MedusaWallBoxDpsPoison` | `NetworkIdentity`, `BehaviourTimedEnableSync`, `HitboxDps`, `BoxCollider` |
| `Hitbox_MedusaWallPoison` | `NetworkIdentity`, `NetworkTransformFollow`*, `ColliderEnableNet`, `ColliderEnable`, `FogOfWarOcclusionMeshBuilder`, `HitboxDps`, `Rigidbody`, multiple `BoxCollider`s, `AudioSource` |

\* The second per-hitbox assembly reference (guid `0f09b8dd…`, fileID `-1510866737`) resolves into `Mirror.Components.dll` — a Mirror NetworkTransform-family component.
† The exact 1:1 GUID→class pairing for the puddle's two `11500000` scripts is `VFXSpawn` and `ColliderEnable`; both are present.

The complete set of distinct BAPBAP Assembly-CSharp classes used across the 4 hitboxes is:
`HitboxDps`, `ProjectileMove`, `ColliderEnable`, `ColliderEnableNet`, `NetworkTransformFollow`, `TransformExpandRadius`, `BehaviourTimedEnableSync`, `FogOfWarOcclusionMeshBuilder`, `VFXSpawn`.

**All 9 were confirmed present in the BR build's `global-metadata.dat`.** `HitboxBase` (the base class the mod patches via `HitboxBase.OnHitSuccess`) is also present. Note the hitboxes use the generic **`HitboxDps`** area-damage component — not a Medusa-specific hitbox script.

### 2c. Cross-checked ability subclasses
The mod (`MedusaMod.cs`) currently patches Kitsu's ability subclasses. All confirmed present in BR metadata: `CatShotAbility`, `CatMissileAbility`, `CatPolymorphAbility`, `CatJumpAbility`, `ArrowAbility`, `ChargedArrowsAbility`, `RecoilArrowAbility`, `ArrowMissileAbility`. The base `Ability`, `StatusEffectSO`, `CharMove`, `CharStatusEffects` are present too.

---

## 3. charId 15 / character-system acceptance

- **There is no `CharacterCatalog` class in the BR build** (regex scan returned no match). The character system the mod targets is:
  - `Il2CppBAPBAP.UI.UICharactersConfiguration.Characters[]` — the lobby/UI roster of `CharacterConfiguration` entries.
  - `Il2CppBAPBAP.Pooling`/`GameNetworkManager.characterPrefabsByCharId[]` — the runtime prefab array indexed by `charId`.
- The base game ships **15 characters (charId 0–14)**; the asset reference defaults list `0..14` (all 15). **Slot 15 does not exist by default**, so the BR build does **not** natively accept `charId 15`. `MedusaMod` hard-codes `ExpectedMedusaCharId = 15`.
- **What the current mod wires (from `MedusaMod.cs`):**
  1. `RegisterPrefab` clones a base character prefab (prefers `Kitsu`), names it `Char_Medusa`, `DontDestroyOnLoad`, and **appends it to `characterPrefabsByCharId[15]`** (grows the array if needed).
  2. `CloneConfig` builds a new `CharacterConfiguration` (name `"Medusa"`, `charId=15`, custom colors/sprites/ability `AbilityData` keys) and appends it to `UICharactersConfiguration._characters` and `_lobbyCharacters`; then `MoveMedusaIntoVisibleMatchSlot` (visible match slot index 7) and `MakeRosterAvailable`.
  3. **Mirror networking:** sets `NetworkIdentity._assetId = 1296385109` (`0x4D45_4455`-style constant `MedusaMirrorAssetId`), sanitizes scene/net ids, registers via `NetworkManager.spawnPrefabs` and `NetworkPrefabPool` (`ClientCreate`/`ServerCreate`) + `NetworkPrefabLibrary.PooledPrefabs`.
  4. **UI bypass patches:** `CharacterIsSelectable`/`CharacterIsUnlocked`/`CharacterIsInRotation` forced true for id 15; `GetCharacterListingIndexFromCharId`/`GetCharIndexByID` patched to avoid native `NullReferenceException`; phrase/localization injection for `MEDUSA_*` keys.
  5. **Bots:** `GameNetworkManager.GetCharacterBotPrefab` remaps a requested Medusa bot id back to a base char id (Medusa is not used for bots).
  6. **Ability behaviour:** because the cloned prefab is a Kitsu clone, the mod suppresses inherited Kitsu VFX on the headless server and runs an authored driver (`ApplyHit`, `StatusEffectInfo` poison/petrify, `CharMove.PostMove` for the dash) while letting render-capable clients keep real spawning projectiles.

So acceptance of charId 15 is **entirely mod-driven**; nothing in the stock BR build provides slot 15.

---

## 4. Risk list — what "just works" vs what needs script types/data

### Green — will load and work from a 2022.3.38f1 bundle with no script dependency
These are pure engine-asset types; identical Unity version guarantees them. The existing `MedusaBundleProject` already imports and bundles exactly these:
- **Mesh:** `MedusaBase.asset` (skinned mesh) and the VFX meshes (`SM_VFX_*`).
- **Animator + clips:** `Medusa.controller`, `Medusa_Anims_v03Avatar`, and all `Medusa_*.anim` (Idle/Walk/Run/Attack_01–03, strafes, turns). Animations work at the root once the controller is bound to the live `Animator`.
- **Textures/Materials:** `Medusa_Tex_Albedo_1024`, `Medusa_Tex_Normal_1024`, `Medusa_Material`, plus the VFX materials (`M_VFX_*`).
- **VFX prefabs (visual only):** `VFX_Medusa_Poison_Escape/Hit/Muzzle/Puddle/Trail/Wall` (ParticleSystems + renderers, no game scripts).
- **Visual prefab:** `Medusa_Visual.prefab` (mesh+animator only). This is the asset the current mod already loads and grafts.
- **Collider geometry** on the hitbox prefabs (Box/Sphere colliders, sizes, triggers) — engine types.

### Yellow — loads but needs care
- **MonoBehaviour script *identity* in the bundle.** For the BR runtime to attach `CharAbilities`/`HitboxDps`/etc. when loading a bundled prefab, the bundle-build project must contain script stubs with the **same class name + namespace + assembly (`Assembly-CSharp`) + matching GUID** as the BR classes. The exported `GameCode` project *has* these AssetRipper stubs; the current `MedusaBundleProject` does **not** include a `Scripts/Assembly-CSharp` folder, which is why its bundle is used for visuals only. Adding the stub scripts is required if you want script components to deserialize by type rather than appear as "missing script".
- **Shaders:** the VFX use proprietary `_Lush_Uber_Particles*` / `Uber_Particles_Trails` shaders (present in the backport project as `.shader` stubs). On render-capable clients these resolve; on the **headless/Wine dedicated match-host** the mod deliberately strips/replaces particle materials to avoid choking on unsupported particle shaders (`CanSpawnClientFx()` gating). Keep that server-side suppression — bundling the real shaders does not remove the headless risk.
- **Mirror `NetworkIdentity` assetId.** A bundled networked prefab still needs its `_assetId` set to the mod's `1296385109` and registration through `spawnPrefabs`/`NetworkPrefabPool`, exactly as the mod does today; the bundle alone does not network-register anything.

### Red — will NOT come for free; this is the core limitation of the "real assets" approach
- **MonoBehaviour serialized *field data* is not present in the exported prefab.** A whole-file scan of `Medusa.prefab` for `abilities:`, `damage:`, `cooldown`, `spellPrefab`, `vfxCast`, `Hitbox`, `charId`, `poison` returned **zero** matches; every `CharAbilities`/`CharAnimator`/etc. MonoBehaviour is an **empty stub** (just `m_Script` + empty `m_Name`/`m_EditorClassIdentifier`). AssetRipper recovered the GameObject/Transform/collider/renderer structure but **not** the IL2CPP-stripped serialized fields. Consequently:
  - Ability **stats** (damage, cooldown, attack speed, ranges), **slot→ability mapping**, and **hitbox/spell prefab references** are blank in the bundled prefab.
  - The `charId`, team/material parameters, and ability `AbilityData` are blank.
  - Therefore a bundled Medusa prefab will spawn a correctly-shaped, correctly-animated character that **does nothing on cast** until its abilities are configured.
- **Fallback (recommended):** keep the runtime wiring the mod already performs — i.e. clone a base character to inherit working `CharAbilities`/`EntityManager`/`Mirror` plumbing, then (a) graft the **real** Medusa visual/animator/mesh/material from the bundle (already done), and (b) **upgrade the ability path** by either:
  - copying/overriding the base `Ability` subclass fields to point their `spellPrefab`/hitbox references at the **real bundled `Hitbox_Medusa*` prefabs** (all their component classes exist in BR, section 2b), so casts spawn Medusa's authored projectiles/puddle/walls natively; or
  - continuing the current authored-driver approach (`ApplyHit` + `StatusEffectInfo`) for gameplay while using the bundled VFX for presentation.
  This removes the "Kitsu-clone graft" visually (root-level real mesh/anim) **without** depending on field data that the export cannot provide.

### Net assessment
- AssetBundle **engine compatibility: guaranteed** (identical 2022.3.38f1; the live bundle is already built at that version).
- Every required **script type exists** in the BR build — nothing is missing, so no class is unrepresentable.
- The real blocker is **data, not code**: the exported MonoBehaviours are field-less stubs. "Animations + visibility at the root" is achievable purely from the bundle; "abilities at the root" still requires runtime configuration (point native `Ability`/`HitboxDps` components at the bundled Medusa hitbox prefabs, or keep the authored driver). There is no scenario where a missing script type forces a fallback — only missing serialized data does.

---

## Evidence appendix (paths inspected)
- BR version: `Spiel\Battleroyalebuild\bapbap_Data\globalgamemanagers` header → `2022.3.38f1`.
- BR class presence: regex scan of `Spiel\Battleroyalebuild\bapbap_Data\il2cpp_data\Metadata\global-metadata.dat`.
- Prefabs: `neueBapbap\GameCode\ExportedProject\Assets\GameObject\{Medusa, Hitbox_MedusaPoisonProjectile, Hitbox_MedusaPoisonPuddle, Hitbox_MedusaWallBoxDpsPoison, Hitbox_MedusaWallPoison}.prefab`.
- GUID→class resolution: `…\Assets\Scripts\Assembly-CSharp\BAPBAP\**\*.cs.meta`, `…\Assets\Plugins\Mirror*.dll.meta`.
- Mod wiring: `BAPBAPModdingAPI\medusa-mod\MedusaMod.cs` (charId 15, MirrorAssetId 1296385109, prefab/roster/pool registration, ability driver).
- Existing native backport: `BAPBAPModdingAPI\medusa-mod\backport\MedusaBundleProject` (Unity 2022.3.38f1; imports real Medusa mesh/anim/material/VFX; `BuildOutput\medusa` == shipped `medusa.bundle`, 1,567,424 bytes).
- Decompiled latest-build logic available for cross-ref: `neueBapbap\_decomp\{hurtbox,br,zone,...}` (`CharHurtbox`, `GameModeBattleRoyale`, `BattleRoyaleZone`).

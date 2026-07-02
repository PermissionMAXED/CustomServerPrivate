# Medusa Native Backport — Real Asset Inventory & Bundle Plan

Research/scoping only. No game, mod, or server files were modified. This report inventories
Medusa's **real** assets as exported by AssetRipper from the latest build, so that the in-game
mod can stop relying on the current "clone-graft" hack (whose bundled controller has
`parameterCount=0`, producing frozen poses / *Standbilder*) and instead use the genuine
animator, mesh, materials, and ability hitboxes at the root.

Source root (all paths below are relative to it unless noted):
`C:\Users\Administrator\Downloads\neueBapbap\GameCode\ExportedProject\Assets\`

Engine: Unity, networking via **Mirror** (`Plugins\Mirror.dll`, `Plugins\Mirror.Components.dll`).
All gameplay scripts live in `Scripts\Assembly-CSharp\BAPBAP\...`.

---

## 0. Asset key (GUID → file)

| Asset | GUID | Resolved file |
|---|---|---|
| Character prefab | `00a97ec2da7ea2f489b0b0dc03855dff` | `GameObject\Medusa.prefab` |
| Animator controller | `86d1dd78a72569148aa56705a2f04953` | `AnimatorController\Medusa.controller` |
| Avatar | `b8c90adf9dea52d46ad695e87822d9af` | `Avatar\Medusa_Anims_v03Avatar.asset` |
| Skinned mesh | `c66444d1565189d49bc6360075acb4ec` (fileID `4300000`) | `Mesh\MedusaBase.asset` |
| Body material | `5592153df5a15114da094c14546d86c0` | `Material\Medusa_Material.mat` |
| Shader | `66def4fb3f6759f4fb70095c205334ef` (fileID `4800000`) | `Shader\Custom_Toon_Toon_Character_Amplify.shader` |
| Albedo texture (`_MainTex`) | `2eb2a4dbcd023c84caf4fe9aa74a2d0e` | `Texture2D\Medusa_Tex_Albedo_1024.png` |
| Normal texture (`_NormalTex`) | `f233be5b074a28f4e8abb95d2693e22d` | `Texture2D\Medusa_Tex_Normal_1024.png` |

---

## 1. Medusa.controller — the real animator

**This is the crux of the fix.** The current mod bundle reports `parameterCount=0`; the real
controller below has **7 parameters**, **3 layers**, and **5 blend trees**. A zero-parameter
controller cannot drive the blend trees, so every state collapses to a static pose — the
observed frozen Medusa.

### 1.1 Parameters (7)

| Name | Type | Default |
|---|---|---|
| `Forward` | Float | 0 |
| `Strafe` | Float | 0 |
| `Turn` | Float | 0 |
| `IsMoving` | Bool | false |
| `AttackSpeed` | Float | 1 |
| `MoveSpeed` | Float | 1 |
| `FootstepCurve` | Float | 0 |

`MoveSpeed` and `AttackSpeed` are read by `CharAnimator` / `CharFootsteps`; `FootstepCurve` is
an animation-curve channel the footstep system samples; `Forward`/`Strafe`/`Turn`/`IsMoving`
drive locomotion. These names must be set verbatim by the runtime, which is exactly what the
real `CharAnimator` already does — the broken bundle just never exposed them.

### 1.2 Layers (3)

| # | Layer | Default weight | Blending | Default state |
|---|---|---|---|---|
| 0 | `Fullbody` | 0* | Override | `Idle Turn Blend` |
| 1 | `UpperbodyOverwrite` | 1 | Override | `None` |
| 2 | `FullbodyOverwrite` | 0 | Override | `None` |

\* Layer 0 `m_DefaultWeight` is serialized as 0 but layer 0 is always full-weight in Unity; the
locomotion still plays. Layers 1/2 are additive-by-override ability layers.

### 1.3 States & blend trees

**Layer 0 — Fullbody**
- `Idle Turn Blend` (default state) → **1D BlendTree** on `Turn` (range -1..1):
  - `-1` → `Medusa_Idle_Turn_Left`
  - `0`  → (`f7a3b97c0cf1e9a4c80b99a5ff5361d1`, the neutral idle clip)
  - `1`  → `Medusa_Idle_Turn_Right`
  - Transition → `Movement Blend` when `IsMoving == true` (dur 0.1).
- `Movement Blend` (speed 0.7, speed param `MoveSpeed`) → **2D Freeform Cartesian BlendTree**
  (`m_BlendType: 2`) on `Strafe` (X) / `Forward` (Y), 17 children laid out on a unit/√2 grid:
  - Center `(0,0)` → `Medusa_Idle_Blend`
  - 8 **Walk** clips on the inner ring (`±1`, `±0.707`): `Medusa_Walk_Forward`,
    `Walk_Forward_Left/Right`, `Walk_Strafe_Left/Right`, `Walk_Backward`,
    `Walk_Backward_Left/Right`
  - 8 **Run** clips on the outer ring (`±2`, `±1.414`): `Medusa_Run_Forward`,
    `Run_Forward_Left/Right`, `Run_Strafe_Left/Right`, `Run_Backward`,
    `Run_Backward_Left/Right`
  - Transition → `Idle Turn Blend` when `IsMoving == false` (dur 0.25).

**Layer 1 — UpperbodyOverwrite** (ability/attack upper body)
- `None` (default, empty)
- `Ability1` (speed param `AttackSpeed`) → `Medusa_Attack_01`; exits to `None` (exitTime 0.9)
- `Ability2` → `Medusa_Attack_02`; exits to `None` (exitTime 0.583)

**Layer 2 — FullbodyOverwrite** (full-body ability / state overrides)
- `None` (default, empty)
- `Ability4` → `Medusa_Attack_03`; exits to `None` (exitTime 0.829)
- `Ability3` (empty motion — placeholder/handled elsewhere)
- `Airborne_` (empty motion — knockup/jump placeholder)
- `Stun_` (empty motion — stun placeholder)

Notes for backport:
- The controller references clips purely by GUID, so the **clips, avatar, and controller must be
  bundled together** and keep their GUIDs (or be remapped consistently) or the blend trees break.
- `Ability3/Airborne_/Stun_` have no motion in this build; they are state hooks the runtime
  cross-fades into. They do not need clips to function but the states must exist so
  `CharAnimator.CrossFade(...)` name lookups succeed.

---

## 2. Animation clips (23 total)

All under `AnimationClip\`. The Avatar is `Avatar\Medusa_Anims_v03Avatar.asset`
(GUID `b8c90adf9dea52d46ad695e87822d9af`), a **Generic/Humanoid rig avatar** that the prefab's
`Animator` binds via `m_Avatar` — required for the bones to deform correctly.

Idle / turn (4):
- `Medusa_Idle.anim`
- `Medusa_Idle_Blend.anim`
- `Medusa_Idle_Turn_Left.anim`
- `Medusa_Idle_Turn_Right.anim`

Walk (8):
- `Medusa_Walk_Forward.anim`
- `Medusa_Walk_Forward_Left.anim`
- `Medusa_Walk_Forward_Right.anim`
- `Medusa_Walk_Strafe_Left.anim`
- `Medusa_Walk_Strafe_Right.anim`
- `Medusa_Walk_Backward.anim`
- `Medusa_Walk_Backward_Left.anim`
- `Medusa_Walk_Backward_Right.anim`

Run (8):
- `Medusa_Run_Forward.anim`
- `Medusa_Run_Forward_Left.anim`
- `Medusa_Run_Forward_Right.anim`
- `Medusa_Run_Strafe_Left.anim`
- `Medusa_Run_Strafe_Right.anim`
- `Medusa_Run_Backward.anim`
- `Medusa_Run_Backward_Left.anim`
- `Medusa_Run_Backward_Right.anim`

Attacks (3):
- `Medusa_Attack_01.anim` (GUID `488f0aa7cfcae344d8728f66ee4416ea` → Ability1)
- `Medusa_Attack_02.anim` (GUID `a32afbd239a2e164aa97f351a66f8cf5` → Ability2)
- `Medusa_Attack_03.anim` (GUID `24767dab7f283a044972319fd648499f` → Ability4)

Verified GUID→clip mappings against the blend-tree children (e.g. `757d2bbf…`→`Medusa_Idle_Blend`,
`6f2edad3…`→`Medusa_Walk_Forward`, `a9981bd6…`→`Medusa_Idle_Turn_Left`).

---

## 3. Medusa.prefab hierarchy

Root GameObject **`Medusa`** — tag `PlayerCharacter`, layer `11`. Its direct children:
`Firing Point` (+`FiringPoint2/3`), `Indicator_BaseRemote` (ground decals), and `Medusa_Anims_v01`
(the visual/animation subtree) plus `MedusaBase` (the skinned mesh object).

### 3.1 Visual subtree

```
Medusa (root, PlayerCharacter, layer 11)
├── Firing Point            (muzzle anchor; +FiringPoint2, FiringPoint3 inactive)
├── Indicator_BaseRemote    (inactive; ground-targeting decal root)
│   └── ToggleHolder
│       ├── Base_BlobShadow (SpriteRenderer, blob shadow)
│       ├── Arrow           (SpriteRenderer, aim arrow)
│       └── BaseCircle      (SpriteRenderer + CircleShapeSprite)
└── Medusa_Anims_v01        (Animator: avatar + Medusa.controller)
    ├── Medusa              (armature root)
    │   ├── Def-Head → Def-Hair.L/R/M chains, Def-Shoulder/Arm/Forearm/Hand + finger bones
    │   └── Root → Def-COG → Def-Hips/Spine/Chest/Neck, Def-Thigh/Calf/Foot/Toe L+R, Def-Gun
    └── MedusaBase          (SkinnedMeshRenderer)
```

- The **`Animator`** (component `95121005239445321`) sits on **`Medusa_Anims_v01`** and binds:
  - `m_Avatar` = `Medusa_Anims_v03Avatar.asset`
  - `m_Controller` = `Medusa.controller`
  - `m_ApplyRootMotion: 0`, `m_CullingMode: 1` (cull update transforms when off-screen).
- The **`SkinnedMeshRenderer`** (component `137433013960508438`) sits on **`MedusaBase`**:
  - `m_Mesh` = `MedusaBase.asset` (GUID `c66444d1565189d49bc6360075acb4ec`, fileID `4300000`)
  - `m_Materials[0]` = `Medusa_Material.mat`
  - **47 bones**, `m_RootBone` = `Def-Head` transform; AABB center `(-0.106,-0.502,-0.256)`,
    extent `(0.676,1.027,0.731)`.
  - `m_BlendShapeWeights: []` (no blendshapes).
- The full skeleton is a standard humanoid Def-rig (COG/Hips/Spine/Chest/Neck/Head, two arms with
  fingers, two legs, hair bone chains L/M/R, plus a `Def-Gun` bone). All 47 bones must be present
  with the same names/hierarchy or the mesh skinning will misbind.

### 3.2 Root MonoBehaviour stack (the real "character brain")

The root has a `CharacterController` (height 2, radius 0.5) and a trigger `CapsuleCollider`,
an `AudioSource`, and the following scripts (all resolved from `.cs.meta` GUIDs). This is the
complete component graph the clone-graft hack was trying to fake:

| Component fileID | GUID | Class | Assembly/namespace |
|---|---|---|---|
| `114693329660128220` | `f5de0324…` | **NetworkIdentity** (fileID 860895539) | `Mirror.dll` |
| `114397768327470545` | `1460c843…` | `EntityManager` | BAPBAP.Entities |
| `114571718729274231` | `823cbae6…` | `CharEvents` | BAPBAP.Entities |
| `114581786255902400` | `6b79b1df…` | `CharNetwork` | BAPBAP.Entities |
| `114477046003934300` | `4f78996d…` | `CharSimulation` | BAPBAP.Entities |
| `114045458335737618` | `c124b5a9…` | `EntityMovement` | BAPBAP.Entities |
| `114722951815217645` | `c418ab36…` | `CharAim` | BAPBAP.Entities |
| `114924050743934937` | `fef747ef…` | `CharAbilities` | BAPBAP.Entities |
| `114215879266689626` | `3bff23b8…` | `CharItems` | BAPBAP.Entities |
| `114689364072382846` | `143f329b…` | `CharStatusEffects` | BAPBAP.Entities |
| `114043919389829319` | `932c48f6…` | `CharHurtbox` | BAPBAP.Entities |
| `114743393880019028` | `62dc36d3…` | `CharTriggerbox` | BAPBAP.Entities |
| `114094320201520353` | `6ef55e0e…` | `CharHpRegen` | BAPBAP.Entities |
| `114026196548002408` | `28fe2fb6…` | `CharHideArea` | BAPBAP.Entities |
| `114572839542275309` | `adab3e31…` | `CharMaterial` | BAPBAP.Entities |
| `114279359913592680` | `132019db…` | `CharFX` | BAPBAP.Entities |
| `114384403120170545` | `949fdc18…` | `CharHidden` | BAPBAP.Entities |
| `114149520701623706` | `ae8604a3…` | `CharBushInteract` | BAPBAP.Entities |
| `114292246286975720` | `38ca8028…` | `CharWorldPosition` | BAPBAP.Entities |
| `114630643969539439` | `9d1bca18…` | `CharFootsteps` | BAPBAP.Entities |
| `114370222726513266` | `b710ad8b…` | **`CharAnimator`** | BAPBAP.Entities |
| `114574304967836189` | `1d47e336…` | `CharMinimap` | BAPBAP.Entities |
| `114009931292380359` | `52d80048…` | `CharFogOfWar` | BAPBAP.Entities |
| `114393105877652414` | `696154ec…` | `EntityEventAnimator` *(m_Enabled: 0)* | BAPBAP.Entities.View |
| `114799762105739359` | `8a799abe…` | `CharInterpolator` | BAPBAP.Entities |
| `114829625606037309` | `9fd2bf75…` | `CharInteract` | BAPBAP.Entities |
| `114574190619683098` | `648232c9…` | `CharLabelNear` | BAPBAP.Entities |

Child-object scripts:
- `Indicator_BaseRemote` → `IndicatorBaseMaterial` (`88287e0e…`, BAPBAP.UI)
- `BaseCircle` → `CircleShapeSprite` (`1c7b1efc…`, BAPBAP.UI)

Key takeaway: **`CharAnimator`** (`b710ad8b…`) is the script that writes `Forward/Strafe/Turn/
IsMoving/MoveSpeed/AttackSpeed/FootstepCurve` into the animator every tick. The visibility bug
("works only at root") is governed by `CharHidden` + `CharHideArea` + `CharFogOfWar` +
`CharMaterial` (FoW-aware material swapping). Because the hacked clone wasn't a real root
character entity, those systems never ran, hence the visibility breakage. A native backport that
reuses the real prefab inherits all of this for free.

---

## 4. The four Hitbox_Medusa* ability prefabs

All are tag `Hitbox`, layer `14`, kinematic/trigger volumes networked via Mirror. Shared scripts:
- **NetworkIdentity** — `Mirror.dll` (`f5de0324…`, fileID 860895539) — on all 4.
- **Mirror.Components networked transform** — `Mirror.Components.dll` (`0f09b8dd…`,
  fileID -1510866737, a `NetworkTransform`-type) — on the projectile, puddle, and wall.
- `VFXSpawn` — `e9ad1bd7…` (BAPBAP.Local) — spawns the poison particle VFX; on projectile,
  puddle, wall.

### 4.1 Hitbox_MedusaPoisonProjectile
- `NetworkIdentity` (Mirror)
- `NetworkTransform` (Mirror.Components, `0f09b8dd…`)
- `Rigidbody` (kinematic, no gravity)
- `BoxCollider` (trigger, size `0.77 × 0.2 × 1`)
- `ProjectileMove` — `a16fd113…` (BAPBAP.Entities) — flight/travel logic
- `VFXSpawn` — `e9ad1bd7…`

### 4.2 Hitbox_MedusaPoisonPuddle
- `NetworkIdentity`
- `NetworkTransform` (`0f09b8dd…`)
- `SphereCollider` (trigger, radius `0.5`)
- `NetworkTransformFollow` — `c925a52b…` (BAPBAP.Entities) — follows an owner transform
- `TransformExpandRadius` — `243e4c78…` (BAPBAP.Entities) — grows the puddle over time
- `VFXSpawn` — `e9ad1bd7…`
- `AudioSource` (looping poison hiss, vol 0.1, 3D rolloff 8–20m)

### 4.3 Hitbox_MedusaWallPoison
- `NetworkIdentity`
- `NetworkTransform` (`0f09b8dd…`)
- `ColliderEnable` — `770e4051…` (BAPBAP.Entities) — toggles colliders on/off at runtime
- `BehaviourTimedEnableSync` — `8c10466e…` (BAPBAP.Local) — networked timed enable/disable
- `Rigidbody` (kinematic)
- Four root `BoxCollider`s (trigger, `~9.1` long wall segments, **disabled by default**, enabled
  by `ColliderEnable`)
- `FogOfWarOcclusionMeshBuilder` — `4c5c57b6…` (BAPBAP.Local) — *(m_Enabled: 0)* builds the wall's
  FoW occluder
- `VFXSpawn` — `e9ad1bd7…`
- `AudioSource` (looping)
- Child **`Obstacle`** (layer 9 = Obstacle, inactive by default): four tall `BoxCollider`s
  (`~9.2 × 2`) + a second `ColliderEnable` (`770e4051…`) — the solid wall that blocks movement.

### 4.4 Hitbox_MedusaWallBoxDpsPoison
- `NetworkIdentity`
- `HitboxDps` — `c753f044…` (BAPBAP.Entities) — applies damage-per-second to entities inside
- `BoxCollider` (trigger, `9.2 × 1 × 9.2`, disabled by default)
- `ColliderEnableNet` — `dd1fda3b…` (BAPBAP.Entities) — network-synced collider enable

These four together implement Medusa's poison kit: a thrown projectile, a growing poison puddle,
a poison wall (visual + solid obstacle), and the large DPS poison field inside the walled area.

---

## 5. Materials & shaders — custom, not stock

- **`Medusa_Material.mat`** uses shader
  **`Custom_Toon_Toon_Character_Amplify`** (GUID `66def4fb…`, in `Assets\Shader\`). This is the
  game's **custom Amplify-authored toon character shader — NOT a stock Unity/URP shader.** The
  property set confirms it: ramp shading (`_RampShading`, `_RampThreshold`, `_RampSmooth`),
  rim/fresnel (`_RimColor`, `_FresnelColor`), outline (`_OutlineSize`, `_OutlineColor`),
  **Fog-of-War overlay** (`_DepthMaskOverlay`, `_FoWOccludeOverlay`, `_MultiplyFoWToAlpha/Color`),
  hit-flash (`_HitColor`, `_HitBlinkColor`), and HSV variation block. The
  `_MultiplyFoWToAlpha/Color` + `_DepthMaskOverlay` properties are precisely what `CharMaterial`/
  `CharFogOfWar` drive at runtime — another reason visibility only behaves correctly on a real
  character entity.
- Textures referenced: `_MainTex` = `Medusa_Tex_Albedo_1024.png`; `_NormalTex` =
  `Medusa_Tex_Normal_1024.png` (`_NormalScale: 2`). `_EmissionMap`, `_Ramp`, `_CoverageRamp`,
  `_VariationTex` are empty.
- Indicator/shadow sprites under `Indicator_BaseRemote` use small stock sprite materials
  (`ed9c7f3d…`, `85c35e85…`) — cosmetic ground decals, low priority for the minimal bundle.

Bundling implication: the shader is **custom and shared by every character**, so it is almost
certainly already present in the live game build. The mod should **reference the existing shader
by name/GUID** rather than re-ship it, to avoid duplicate-shader / pink-material problems. Only
the two Medusa textures are Medusa-specific.

---

## 6. Bundle definitions

### 6.1 (a) MINIMAL — visual + animator (fixes the frozen-pose / Standbilder bug)

Goal: a Medusa that is visible and fully animated at the root, even before abilities work.

Must include:
1. `Mesh\MedusaBase.asset` (skinned mesh, GUID `c66444d1…`)
2. `AnimatorController\Medusa.controller` (GUID `86d1dd78…`) — **the parameterful real controller**
3. `Avatar\Medusa_Anims_v03Avatar.asset` (GUID `b8c90adf…`)
4. All **23** `AnimationClip\Medusa_*.anim` clips (Idle×4, Walk×8, Run×8, Attack×3)
5. `Material\Medusa_Material.mat` (GUID `5592153d…`)
6. Textures `Medusa_Tex_Albedo_1024.png` + `Medusa_Tex_Normal_1024.png`
7. The armature: the `Medusa_Anims_v01` → armature-root + `MedusaBase` transform subtree
   (all 47 bones with their names/hierarchy/bind poses) carrying the `Animator` + the
   `SkinnedMeshRenderer` (47 bones, rootBone `Def-Head`).

Reference (do **not** re-ship if already in the build):
- Shader `Custom_Toon_Toon_Character_Amplify` (GUID `66def4fb…`) — shared character shader.

Critical constraints:
- Preserve GUIDs (controller↔clips↔avatar↔mesh↔material) or remap every reference together.
- The runtime that sets `Forward/Strafe/Turn/IsMoving/MoveSpeed/AttackSpeed/FootstepCurve` must
  be `CharAnimator` (or an equivalent that writes the exact same parameter names). With the real
  controller present, the existing `CharAnimator` immediately drives locomotion and the frozen
  pose disappears.

Excluded from minimal: ability hitboxes, FoW occluder builders, the four poison prefabs.

### 6.2 (b) FULL — minimal + working poison abilities

Everything in (a), plus the ability hitbox prefabs and their dependency scripts/VFX:
1. `GameObject\Hitbox_MedusaPoisonProjectile.prefab`
2. `GameObject\Hitbox_MedusaPoisonPuddle.prefab`
3. `GameObject\Hitbox_MedusaWallPoison.prefab` (incl. its `Obstacle` child)
4. `GameObject\Hitbox_MedusaWallBoxDpsPoison.prefab`

Required script dependencies (must exist/load in the target assembly, by GUID):
- BAPBAP.Entities: `ProjectileMove` (`a16fd113…`), `NetworkTransformFollow` (`c925a52b…`),
  `TransformExpandRadius` (`243e4c78…`), `ColliderEnable` (`770e4051…`),
  `ColliderEnableNet` (`dd1fda3b…`), `HitboxDps` (`c753f044…`)
- BAPBAP.Local: `VFXSpawn` (`e9ad1bd7…`), `BehaviourTimedEnableSync` (`8c10466e…`),
  `FogOfWarOcclusionMeshBuilder` (`4c5c57b6…`)
- Mirror: `NetworkIdentity` (`f5de0324…`, `Mirror.dll`) and the `NetworkTransform`-type
  (`0f09b8dd…`, `Mirror.Components.dll`)
- Plus the poison VFX prefabs/particle assets and any audio clips the `VFXSpawn`/`AudioSource`
  reference (those sub-references were not expanded here; expand `VFXSpawn` serialized fields
  before final packaging).

Networking note: every poison prefab carries a `NetworkIdentity` and must be registered as a
**spawnable prefab** with the Mirror `NetworkManager` on both server and client, or `CharAbilities`
server-side spawns will fail to replicate. This is the biggest behavioral dependency beyond the
visual bundle.

---

## 7. Why the native backport fixes the three symptoms

| Symptom | Root cause in the hack | Fixed by |
|---|---|---|
| Frozen poses / *Standbilder* | bundled controller `parameterCount=0` → blend trees inert | shipping the **real `Medusa.controller`** (7 params, 5 blend trees) + avatar + 23 clips, driven by `CharAnimator` |
| Abilities don't work | clone had no `CharAbilities`/hitbox prefabs/Mirror spawn registration | FULL bundle: the four `Hitbox_Medusa*` prefabs + their scripts, registered as Mirror spawnables |
| Visibility only "at root" | grafted clone wasn't a real networked character, so `CharHidden`/`CharFogOfWar`/`CharMaterial` never ran and the FoW shader params were never set | using the real `Medusa.prefab` root with its full 27-script component stack + the FoW-aware `Custom_Toon_Toon_Character_Amplify` material |

---

## 8. Open items to expand before implementation (not yet investigated)

- Serialized field contents of each `CharXxx` script on the root (e.g. references the prefab
  expects: firing points, indicator prefabs, ability data SOs) — the prefab stores them but the
  exported MonoBehaviours here show empty `m_Name`/`m_EditorClassIdentifier`; the actual field
  values would need a deeper YAML read per component.
- `VFXSpawn` particle/audio sub-references inside the hitbox prefabs.
- Whether the live mod's target assembly already contains the `BAPBAP.Entities`/`BAPBAP.Local`
  classes (it should, since it's the same game build) — if so, only assets need bundling, not code.
- Confirm the exact Mirror component types behind fileIDs `860895539` / `-1510866737`
  (NetworkIdentity / NetworkTransform assumed from context and component ordering).

# Medusa Native Backport — Unity AssetBundle Scoping Report

Status: RESEARCH / SCOPING ONLY. No game, mod, or server files were modified.
Date: 2026-06-10
Scope: Determine how to build an AssetBundle of Medusa's REAL assets from the
exported Unity project so that model, animations, abilities, and visibility work
at the root, replacing the current Harmony "clone-graft" hack.

---

## 0. Executive summary

The situation is close to ideal for a native backport:

- A matching Unity Editor is **already installed**: `2022.3.38f1` at
  `C:\Program Files\Unity\Hub\Editor\2022.3.38f1\Editor\Unity.exe`.
- The exported project (`...\neueBapbap\GameCode\ExportedProject`) is a valid Unity
  project and declares the **exact same version** `2022.3.38f1`.
- The **live BR build** that the mod targets
  (`...\CustomServer\Spiel\Battleroyalebuild\bapbap_Data\globalgamemanagers`) is also
  built with **`2022.3.38f1`**.

=> Editor == exported project == live game = **2022.3.38f1**. There is **no cross-version
mismatch**; an AssetBundle built here will load natively in the live build. The word
"backport" here means porting Medusa (present in the newer export) into the live build,
not bridging different engine versions.

The one real obstacle is **compilation**: the export contains **2,715 decompiled C#
scripts** under `Assets\Scripts\Assembly-CSharp` (AssetRipper output). These will almost
certainly not compile, and a project with compile errors enters Safe Mode and will not
run `BuildPipeline.BuildAssetBundles`. The report below gives two build paths that work
around this:

- **Path A (recommended first): asset-only / visual bundle** — delete the decompiled
  scripts so nothing compiles, bundle the renderable + animation assets (mesh, materials,
  shaders, AnimatorController, AnimationClips, Avatar, textures, VFX prefabs). MonoBehaviour
  components drop out (they need scripts), so abilities still come from live game code, but
  you get the REAL model, skeleton, animations, and VFX.
- **Path B (full native, more work): GUID-stub bundle** — keep the prefab's MonoBehaviour
  references by providing *stub scripts that reuse the original .meta GUIDs and class
  names*. Because AssetRipper preserves the original script GUIDs and the live game's own
  `Assembly-CSharp` contains those exact classes/GUIDs, the prefab's components rebind to
  the REAL ability classes at load time in the live build. This is what makes abilities
  "work at the root".

---

## 1. Installed Unity Editor(s)

Searched `C:\Program Files\Unity`, `C:\Program Files\Unity\Hub\Editor`,
`C:\Program Files (x86)\Unity`, and Unity Hub.

| Item | Result |
|---|---|
| Unity Editor | **2022.3.38f1** |
| Unity.exe path | `C:\Program Files\Unity\Hub\Editor\2022.3.38f1\Editor\Unity.exe` (confirmed present) |
| Windows Standalone build support | Present — `...\2022.3.38f1\Editor\Data\PlaybackEngines\windowsstandalonesupport` exists, so `BuildTarget.StandaloneWindows` is usable |
| Unity Hub | Installed — `C:\Program Files\Unity Hub\Unity Hub.exe` |
| Other editors | None found (only `2022.3.38f1` under the Hub Editor dir) |

Downloaded installers present (fallbacks, **not needed** since the editor is installed):

- `C:\Users\Administrator\Downloads\UnitySetup64-2022.3.38f1.exe`
- `C:\Users\Administrator\Downloads\UnityHubSetup-x64.exe`

**Conclusion:** No installation step is required. Use the installed `2022.3.38f1` editor.

---

## 2. Is the exported project a valid, openable Unity project?

Path: `C:\Users\Administrator\Downloads\neueBapbap\GameCode\ExportedProject`

| Check | Finding |
|---|---|
| `ProjectSettings\ProjectVersion.txt` | `m_EditorVersion: 2022.3.38f1` — matches installed editor exactly |
| `Packages\manifest.json` | Present, valid JSON. Only built-in `com.unity.modules.*` (incl. `assetbundle`, `animation`, `particlesystem`, `physics`, `ui`). No external registry packages => no package-resolution risk |
| `Assets\` | Present and rich. Top-level type folders: `AnimationClip`, `AnimatorController`, `AnimatorOverrideController`, `Avatar`, `GameObject` (prefabs), `Material`, `Mesh`, `Shader`, `ShaderVariantCollection`, `Texture2D/3D`, `RenderTexture`, `PhysicMaterial`, `Font`, `TextAsset`, `VideoClip`, `Resources`, `MonoBehaviour`, `Plugins`, `Scripts`, `MainScene` (+ a 5 MB `MainScene.unity`), `StreamingAssets` |
| `Library\` | **Absent** => project has never been opened. First open triggers a full asset import (can take many minutes given the project size). Plan for a long first headless run |
| `*.sln` / `*.csproj` | None at the project root (Unity regenerates these on open; not a blocker) |
| `Assets\Plugins` | **67 precompiled managed DLLs** (Mirror networking, FMOD, GameAnalytics, Steamworks/FizzySteamworks, kcp2k, NativeWebSocket, Dreamteck Splines, etc.). These are real assemblies and compile fine as-is |
| `Assets\Scripts\Assembly-CSharp` | **2,715 decompiled `.cs` files** across namespaces `BAPBAP`, `Mirror`, `GameAnalyticsSDK`, `Gamekit3D`, `PathCreation`, etc. **This is the compile-blocking risk** |
| `*.asmdef` | None in `Scripts` => everything compiles into the default `Assembly-CSharp`, so one bad file fails the whole assembly |

### Likely compile-blocking issues (typical of AssetRipper exports)

- Decompiled bodies with illegal C# (compiler-generated names, `<>__` identifiers, broken
  goto/switch lowering, `__Gen`/closure artifacts).
- Duplicate type definitions between the decompiled `Assembly-CSharp` and the precompiled
  plugin DLLs (e.g., `Mirror.*` exists both as decompiled `.cs` **and** as `Mirror*.dll`
  in `Plugins`) => "type defined in multiple places" errors.
- References to internal/removed engine APIs and missing `using`s.
- `[InitializeOnLoad]`/editor-only attributes mixed into runtime scripts.

Because there are no `.asmdef` boundaries, any one of these failures puts the project into
Safe Mode, which **blocks batchmode `BuildAssetBundles`**. This is why the build strategy
must neutralize the decompiled scripts rather than try to fix 2,715 files.

---

## 3. Medusa asset inventory (what we want in the bundle)

Confirmed Medusa assets in the export (representative; ~108 matching files total):

- **Character prefab:** `Assets\GameObject\Medusa.prefab`
  - GUID `00a97ec2da7ea2f489b0b0dc03855dff`, tag `PlayerCharacter`, layer 11.
  - **29 MonoBehaviour components** plus child objects (`Firing Point`, `FiringPoint2/3`,
    `Indicator_BaseRemote`, etc.).
- **Animator:** `Assets\AnimatorController\Medusa.controller` (real controller with
  params `Forward`, `Strafe`, `Turn`, `IsMoving`, ...).
- **Avatar:** `Assets\Avatar\Medusa_Anims_v03Avatar.asset` (humanoid/skeleton rig).
- **Animation clips (23):** `Assets\AnimationClip\Medusa_*.anim` —
  `Idle`, `Idle_Blend`, `Idle_Turn_Left/Right`, `Walk_*`, `Run_*`, `Attack_01/02/03`,
  strafes, backward/forward variants.
- **Mesh:** `Assets\Mesh\MedusaBase.asset` (+ VFX wall meshes `SM_VFX_Medusa_Walls_*`).
- **Materials:** `Assets\Material\Medusa_Material.mat` and `M_VFX_Medusa_*` /
  `M_VFX_Slash_Medusa_01.mat`.
- **Shader:** `Assets\Shader\_Lush_Uber_Particles_Advanced_Medusa_Walls.shader`.
- **Ability/VFX prefabs:** `VFX_Medusa_Poison_{Wall,Escape,Hit,Muzzle,Puddle,Trail}.prefab`,
  `MedusaPuddleSpawner.prefab`, and hitboxes
  `Hitbox_Medusa{PoisonProjectile,PoisonPuddle,WallPoison,WallBoxDpsPoison}.prefab`.

### Script references on Medusa.prefab (the key to "abilities at the root")

The 29 components reference scripts by GUID with `type: 3` (MonoScript). Resolving a sample
against `Assets\Scripts\**\*.cs.meta`:

| m_Script GUID | Resolves to |
|---|---|
| `1460c8433876cd615dc52820edfa5045` | `BAPBAP.Entities.CharEvents` |
| `823cbae65620cefaea6e1a737cdd5299` | `BAPBAP.Entities.CharNetwork` (Mirror `NetworkBehaviour`) |
| `6b79b1dfb9205e5f03863f783caf37c8` | `BAPBAP.Entities.EntityManager` |
| `f5de03243f0810025e7802b3b315681e` (fileID `860895539`, in a plugin DLL) | a plugin-assembly script |

These are the **real game classes**, and AssetRipper preserved their original GUIDs.
The live BR build's own `Assembly-CSharp` contains the same classes under the same GUIDs.
That is what makes the GUID-stub approach (Path B) able to rebind abilities at load time.

> To enumerate all 29 class names + GUIDs for the stub project, grep each `guid:` from
> `Medusa.prefab` against the `.cs.meta` files under `Assets\Scripts`. (A helper is noted
> in section 6.)

---

## 4. Version compatibility (the "backport" question)

| Component | Unity version |
|---|---|
| Installed Editor | 2022.3.38f1 |
| Exported project (`ProjectVersion.txt`) | 2022.3.38f1 |
| Live BR build (`globalgamemanagers` header string) | 2022.3.38f1 |

A bundle's serialized format is tied to the editor version. Since all three are
**identical**, a `StandaloneWindows` bundle built in `2022.3.38f1` loads in the live build
with **no version-skew risk**. Keep `BuildAssetBundleOptions` conservative (no
`ChunkBasedCompression` quirks needed; default LZMA or `ChunkBasedCompression` LZ4 both fine).

Use `BuildTarget.StandaloneWindows` (32/64-agnostic for asset content) — the live game is
`bapbap.exe` on Windows. (`StandaloneWindows64` is equally valid; asset bundles are not
bitness-specific for non-script assets.)

---

## 5. Build design

### 5.1 Path A — asset-only / visual bundle (recommended first cut)

Goal: real model + skeleton + animations + materials + VFX, no compile required.
Abilities continue to be driven by the live game's own components (as the mod does today),
but now grafted onto the REAL Medusa renderer/animator instead of a clone.

Steps the build performs:
1. **Neutralize compilation:** before building, move/delete `Assets\Scripts\Assembly-CSharp`
   (and any other loose decompiled `.cs`). Keep `Assets\Plugins\*.dll` (they compile fine and
   some assets reference plugin types, but missing-script drops are acceptable for a visual bundle).
   - Doing this in a **copy** of the project avoids touching the original export.
2. Set `assetBundleName = "medusa"` on the visual assets:
   `Medusa.prefab`, `Medusa.controller`, `Medusa_Anims_v03Avatar.asset`, all
   `Medusa_*.anim`, `Medusa_Material.mat` + `M_VFX_Medusa_*`, `MedusaBase.asset` +
   `SM_VFX_Medusa_*`, the Lush shader, and the `VFX_Medusa_*` prefabs. The builder pulls
   asset dependencies automatically, so naming the prefabs/controller is usually enough.
3. `BuildPipeline.BuildAssetBundles(outDir, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows)`.

Result on load: the `Medusa` prefab loads with its `SkinnedMeshRenderer`, `Animator`
(+ controller + avatar + clips), materials/shader, and the particle VFX prefabs — all
**built-in Unity component types**, so they survive without scripts. The 29 `BAPBAP.*`
MonoBehaviours are recorded as missing and dropped.

### 5.2 Path B — GUID-stub bundle (full native abilities)

Goal: keep the 29 MonoBehaviour references so the live build rebinds them to the REAL
ability classes (CharNetwork, CharEvents, ability controllers, etc.).

Why it works: a MonoBehaviour serializes a `{fileID, guid, type:3}` script reference. For
Unity to *keep* that reference when building, a MonoScript with that **GUID** must exist in
the build project. It does **not** need the real implementation — only a class with the
**same full name** (namespace + class) whose `.cs.meta` carries the **original GUID**. At
load time in the live game, Unity resolves the script by GUID to the live `Assembly-CSharp`
class, which has the real fields/logic.

Steps:
1. Delete the 2,715 decompiled scripts (as in Path A).
2. Generate **stub scripts only for the classes Medusa references** (the 29 components +
   their serialized field types if those are also custom types that must round-trip). For
   each: create `Namespace/Class.cs` with a minimal class deriving from the correct base
   (`MonoBehaviour` or Mirror `NetworkBehaviour`) and matching public serialized fields,
   and write a `.cs.meta` containing the **exact original GUID** copied from the export.
   - This is ~tens of files, not thousands — tractable by hand or with a generator.
   - Mirror's `NetworkBehaviour` is available via `Plugins\Mirror*.dll`, so
     `CharNetwork`-style stubs compile.
3. Name + build the bundle as in Path A (this time the prefab keeps its components).
4. The mod loads the bundle and instantiates `Medusa.prefab`; the live game's network/ability
   systems see real components and drive abilities/visibility natively.

Risk notes for Path B:
- If a stub's serialized field layout diverges from the live class, some inspector values
  won't round-trip; but the live class re-initializes most state at runtime, so visual +
  ability wiring usually still works.
- Mirror `NetworkBehaviour` components carry `m_Script` + netid plumbing; keep the base type
  correct so Mirror's weaver/serialization on the live side is satisfied.

### 5.3 Editor C# builder script (DRAFT)

A draft is provided at `analysis\MedusaBundleBuilder.cs` (NOT placed in the Unity project).
It implements both paths (asset-only by default; a flag enables stub mode) and is invoked by
`-executeMethod MedusaBundleBuilder.Build`. Review section 6 before copying it into the
project at `Assets\Editor\MedusaBundleBuilder.cs`.

### 5.4 Exact headless command line

Recommended: build from a **copy** of the export so the original stays untouched. Replace
the projectPath with the copy if you use one.

```bat
"C:\Program Files\Unity\Hub\Editor\2022.3.38f1\Editor\Unity.exe" ^
  -batchmode -nographics -quit ^
  -projectPath "C:\Users\Administrator\Downloads\neueBapbap\GameCode\ExportedProject" ^
  -executeMethod MedusaBundleBuilder.Build ^
  -buildOut "C:\Users\Administrator\Downloads\CustomServer\artifacts\medusa-bundle" ^
  -logFile "C:\Users\Administrator\Downloads\CustomServer\logs\medusa-bundle-build.log"
```

PowerShell form:

```powershell
& 'C:\Program Files\Unity\Hub\Editor\2022.3.38f1\Editor\Unity.exe' `
  -batchmode -nographics -quit `
  -projectPath 'C:\Users\Administrator\Downloads\neueBapbap\GameCode\ExportedProject' `
  -executeMethod MedusaBundleBuilder.Build `
  -buildOut 'C:\Users\Administrator\Downloads\CustomServer\artifacts\medusa-bundle' `
  -logFile 'C:\Users\Administrator\Downloads\CustomServer\logs\medusa-bundle-build.log'
```

Notes:
- The builder script must live at `Assets\Editor\MedusaBundleBuilder.cs` (Editor folder) for
  `-executeMethod` to find it.
- First run also performs the full initial asset import (no `Library` yet) — expect minutes.
- `-quit` returns exit code `0` on success; non-zero (often `1`) on compile error / Safe Mode.
  Always read the `-logFile` for `BuildAssetBundles` results and any CS errors.
- If the project enters Safe Mode (compile errors survived), Path A's script-deletion step did
  not run early enough — ensure deletion happens via a pre-build static step or do it on disk
  in the project copy *before* launching Unity (most robust).

### 5.5 Robust ordering recommendation

Because `-executeMethod` runs **after** the editor imports/compiles, a project that fails to
compile may never reach your method. The most reliable approach:

1. Copy `ExportedProject` to a working dir.
2. **On disk, before launching Unity**, delete `Assets\Scripts\Assembly-CSharp` (and any loose
   decompiled `.cs`), and for Path B drop in the small stub-script set.
3. Place `MedusaBundleBuilder.cs` in `Assets\Editor`.
4. Run the headless command. Now the only compilation is plugins + (Path B) the stubs, which
   compile cleanly, so `-executeMethod` is guaranteed to run.

---

## 6. Helper notes

- To list every Medusa component class + GUID for stub generation, for each `guid:` value on
  a `m_Script:` line in `Medusa.prefab`, find the matching `*.cs.meta` under
  `Assets\Scripts` and read its sibling `.cs` for the `namespace`/`class`. (29 components.)
- Keep the original `.cs.meta` GUIDs verbatim in the stub project — the GUID is the rebinding key.
- Output: a single `medusa` bundle file (+ its `.manifest`) plus the per-folder bundle and
  manifest. The mod's `AssetBundle.LoadFromFile` + `LoadAsset<GameObject>("...Medusa")` consumes it.

---

## 7. Current state vs target (for context)

The existing mod (`BapCustomServerMelon\CustomServerMod.cs`) treats Medusa as character id
**15** (`MedusaCharacterId = 15`, beyond the 15 vanilla chars 0-14) and uses Harmony to
**force `charId`/`NetworkcharId` to 15** and graft player-manager state
(`ForceMedusaPlayerManager`, `ForceMedusaQueuedPlayerData`, `AddPlayerMatchmaking`
prefix/postfix guards). It also checks for a client-side `BAPBAP.Medusa.dll`. This is the
"clone-graft" hack: it borrows another character's runtime objects and rewrites ids, so the
true Medusa model/animations/VFX never load. The bundle approach above replaces that by
shipping the REAL assets.

> Out of scope for this phase: changes to the mod to consume the bundle. The mod-side
> integration (load bundle, instantiate `Medusa.prefab`, register it for char id 15) should
> be designed in a follow-up once a bundle is produced and validated.

---

## 8. Decision / recommended next steps (no changes made yet)

1. Copy `ExportedProject` to a scratch working dir (keep the original pristine).
2. Try **Path A** first (fast, low-risk): delete decompiled scripts, build the `medusa`
   visual bundle, confirm it loads in a test harness. This alone gives real model + animations
   + VFX — a large jump over the clone-graft.
3. If abilities/visibility must work natively at the root, proceed to **Path B**: generate the
   ~29 GUID-matched stub scripts and rebuild. Validate in the live build.
4. Only then design the mod-side loader/registration.

No Unity Editor installation is required (2022.3.38f1 already present). No game/mod/server
files were modified by this investigation.

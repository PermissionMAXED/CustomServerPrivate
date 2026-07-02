# Track A — Generic per-character AssetBundle tool

Status: **WORKING / VERIFIED** (Medusa builds; Eve assets confirmed present for generality).

## What was built

A reusable, config-driven AssetBundle builder that generalizes the proven
single-char `MedusaBundleBuilder.cs` so any BAPBAP character can be packaged
into a real-asset bundle from one `-charName` argument.

### Deliverables

| # | Artifact | Path |
|---|----------|------|
| 1 | Generic Unity editor builder | `C:\Users\Administrator\Downloads\neueBapbap\GameCode\ExportedProject\Assets\Editor\CharBundleBuilder.cs` |
| 2 | PowerShell driver | `C:\Users\Administrator\Downloads\CustomServer\tools\Build-CharBundle.ps1` |
| 3 | This report | `C:\Users\Administrator\Downloads\CustomServer\analysis\char-bundle-tool-report.md` |

`MedusaBundleBuilder.cs` was **not modified** — `CharBundleBuilder.cs` is purely additive.

## CharBundleBuilder.cs — how it generalizes

Invoked headless via `-executeMethod CharBundleBuilder.Build -charName <Name> [-buildOut <dir>]`.

Asset discovery by the project's stable naming conventions (instead of Medusa's hard-coded list):

| Asset type | Discovery rule |
|------------|----------------|
| Root prefab (required) | `Assets/GameObject/<Name>.prefab` |
| Real controller (required) | `Assets/AnimatorController/<Name>.controller` |
| Avatar | `Assets/Avatar/<Name>*Avatar.asset` |
| Animation clips | `Assets/AnimationClip/<Name>_*.anim` |
| Materials | `Assets/Material/<Name>*.mat` + `Assets/Material/M_VFX*.mat` filtered to the char |
| Hitboxes / VFX / spawners / skins | `Assets/GameObject/*.prefab` filtered to the char |

Then it:
1. Builds a stripped visual-only `<Name>_Visual` prefab (instantiate `<Name>.prefab`,
   `RemoveMonoBehavioursWithMissingScript` on every child + `DestroyImmediate` any
   surviving `MonoBehaviour`, keeping `Animator` + renderers, then `SaveAsPrefabAsset`).
2. Tags all discovered assets + the visual into a bundle named `<name>` (lowercase).
3. `BuildPipeline.BuildAssetBundles(outDir, ChunkBasedCompression, StandaloneWindows)`.
4. Logs the real controller's parameter count via `UnityEditor.Animations.AnimatorController`.

### Generality hardening — token-boundary matching

A naive `*<Name>*` substring filter produces false positives (e.g. `FixedEventDropSpawn`
contains "Eve", `Steve` contains "Eve"). `CharBundleBuilder` filters GameObject/M_VFX
names with a token-boundary regex `(^|[^A-Za-z])<Name>([^A-Za-z]|$)`, so `VFX_Eve_Block`
and `Eve.prefab` match while `FixedEventDropSpawn` does not. For Medusa this yields exactly
the same curated set the original builder used.

## Exact commands run

```powershell
# Build (default out folder: <repo>\artifacts\char-bundles\<Char>BundleOut)
C:\Users\Administrator\Downloads\CustomServer\tools\Build-CharBundle.ps1 -Char Medusa
```

Under the hood this runs:

```powershell
& 'C:\Program Files\Unity\Hub\Editor\2022.3.38f1\Editor\Unity.exe' `
  -batchmode -nographics -quit `
  -projectPath 'C:\Users\Administrator\Downloads\neueBapbap\GameCode\ExportedProject' `
  -executeMethod CharBundleBuilder.Build `
  -charName Medusa `
  -buildOut 'C:\Users\Administrator\Downloads\CustomServer\artifacts\char-bundles\MedusaBundleOut' `
  -logFile '<tools>\logs\char-bundle-medusa-<stamp>.log'
```

## Verified results (Medusa)

```
Unity exit code: 0
Bundle: C:\Users\Administrator\Downloads\CustomServer\artifacts\char-bundles\MedusaBundleOut\medusa
Size  : 3,495,317 bytes  (~3.50 MB)   <-- within the expected ~3.4-3.5 MB range
[CharBundleBuilder] visual-only: animators=1 skinnedMeshRenderers=1
[CharBundleBuilder] visual-only: saved Assets/GameObject/Medusa_Visual.prefab
[CharBundleBuilder] Tagged 41 asset(s).
[CharBundleBuilder] controller params=7 layers=3
[CharBundleBuilder]   param: Forward (Float)
[CharBundleBuilder]   param: Strafe (Float)
[CharBundleBuilder]   param: Turn (Float)
[CharBundleBuilder]   param: IsMoving (Bool)
[CharBundleBuilder]   param: AttackSpeed (Float)
[CharBundleBuilder]   param: MoveSpeed (Float)
[CharBundleBuilder]   param: FootstepCurve (Float)
[CharBundleBuilder] Built bundle: medusa
[CharBundleBuilder] SUCCESS: ...\MedusaBundleOut\medusa (3495317 bytes)
```

Proof checks (all PASS):
- Bundle built, ~3.5 MB ✔ (3,495,317 bytes)
- Controller params = **7** ✔ (Forward, Strafe, Turn, IsMoving, AttackSpeed, MoveSpeed, FootstepCurve)
- `Medusa_Visual` saved with **animators=1** (+ skinnedMeshRenderers=1) ✔

Bundle output dir contains: `medusa`, `medusa.manifest`, `MedusaBundleOut`, `MedusaBundleOut.manifest`.
The `medusa.manifest` lists **47** packaged assets with `Dependencies: []` (self-contained),
including `Medusa_Visual.prefab`, `Medusa.controller`, all 23 `Medusa_*.anim` clips,
`Medusa_Anims_v03Avatar.asset`, `Medusa_Material.mat` + the `M_VFX_Medusa_*` VFX materials,
and the `Hitbox_Medusa*` / `VFX_Medusa_Poison_*` / `MedusaPuddleSpawner` prefabs.

## Generality verification (Eve — no full build needed)

Confirmed by reading project assets that a second character resolves under the same rules:

- `Assets/GameObject/Eve.prefab` ✔
- `Assets/AnimatorController/Eve.controller` ✔
- `Assets/Avatar/Eve_Anim_v04Avatar.asset` ✔ (matches `Eve*Avatar.asset`)
- `Assets/AnimationClip/Eve_*.anim` ✔ (e.g. `Eve_Jetpack.anim`)
- Materials `Eve_Material.mat`, `Eve_Skin_GothEve_Material.mat`, `M_VFX_Eve_*` ✔
- Hitboxes/VFX `Hitbox_Eve_*`, `VFX_Eve_*`, `Tombstone_Eve.prefab` ✔

So `Build-CharBundle.ps1 -Char Eve` would discover and package Eve with no code changes.

## Bug found & fixed during verification

First run failed with:
`Manifest AssetBundle name "medusa" has conflict with the user predefined AssetBundle name`
→ `BuildAssetBundles returned null`.

Root cause: Unity names the auto-generated manifest bundle after the **output folder's leaf
name**. The initial default out folder was `...\char-bundles\medusa`, which collided with the
user-defined bundle `medusa`. The original Medusa builder avoided this by using a folder named
`MedusaBundleOut`. Fix: the driver now defaults the out folder to `<Char>BundleOut` and asserts
the folder leaf name never equals the lowercase bundle name. Also cached the process `.Handle`
so `Start-Process -PassThru` reports `ExitCode` reliably.

## Usage for any character

```powershell
C:\Users\Administrator\Downloads\CustomServer\tools\Build-CharBundle.ps1 -Char Eve
C:\Users\Administrator\Downloads\CustomServer\tools\Build-CharBundle.ps1 -Char Kiddo -BuildOut D:\out\kiddo-bundle
```

The produced bundle is named `<char>` (lowercase) inside the build-out folder and is the
real-asset input the companion `BAPCustomChars` lib mod (Track B) loads + grafts at runtime.

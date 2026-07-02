# A4 — medusa.bundle contents vs. real Medusa VFX (READ-ONLY findings)

Agent: `A4_bundle_vfx` · Scope: what the shipped `medusa.bundle` actually contains, and why
abilities render as **green lines + Kitsu-clone FX** instead of the real Medusa VFX that
exist in the LatestBuild. No files changed except this report.

---

## 0. TL;DR (definitive answer to SCOPE A4)

- The shipped bundle **does** contain Medusa visual assets and **6 visual-only VFX prefabs**
  named `VFX_Medusa_Poison_{Escape,Hit,Muzzle,Puddle,Trail,Wall}`, plus `Medusa_Visual`,
  the animator/anims, mesh, material, textures and VFX shaders/meshes/materials.
- The **5 "native" gameplay prefabs the task names are NOT in the bundle**:
  `Hitbox_MedusaPoisonProjectile`, `Hitbox_MedusaPoisonPuddle`, `Hitbox_MedusaWallPoison`,
  `Hitbox_MedusaWallBoxDpsPoison`, `MedusaPuddleSpawner`, and there is **no `VFXSpawn`**.
  The backport pipeline deliberately ships **cosmetic-only** VFX with all
  Hitbox/Spawner/Projectile/Dps/Network MonoBehaviours stripped or disabled.
- The mod's runtime VFX names (`NativeVfxNames`, `MedusaMod.cs:1269`) **match the bundle's
  `VFX_Medusa_Poison_*` prefab names exactly**, so when the *correct* bundle loads, native
  cast FX work. The **green lines are the placeholder fallback** `SpawnMedusaBeam` using
  `MedusaVenomFxColor = Color(0.18, 1, 0.32, 0.95)` (bright green), reached only when
  `_medusaNativeVfxPrefabs.Count == 0` (no native VFX prefab loaded).
- **Most likely root cause of the green lines in-game:** the game loads the **stale, older
  bundle** deployed at `Battleroyalebuild\UserData\Medusa\medusa.bundle` (1,275,524 bytes,
  **May 30 16:09**), NOT the current 1,567,424-byte bundle (May 31 20:21) that contains the
  6 VFX prefabs. The Medusa DLL was rebuilt **May 31 18:21** but the deployed bundle was not
  refreshed → DLL asks for `VFX_Medusa_Poison_*`, old bundle lacks them → 0 native prefabs →
  green `SpawnMedusaBeam` fallback. Confidence: **High** for "5 hitbox prefabs absent /
  green-line code path"; **Medium-High** for "stale deployed bundle is the in-game cause".

---

## 1. Files inspected

| Item | Path | Size / Date |
|---|---|---|
| Shipped dev bundle | `BAPBAPModdingAPI\medusa-mod\medusa.bundle` | 1,567,424 B · 2026-05-31 20:21 |
| Backport build output | `…\medusa-mod\backport\MedusaBundleProject\BuildOutput\medusa` | 1,567,424 B · 2026-05-31 20:21 |
| **Deployed (in-game) bundle** | `…\Battleroyalebuild\UserData\Medusa\medusa.bundle` | **1,275,524 B · 2026-05-30 16:09** |
| Deployed mod DLL | `…\Battleroyalebuild\Mods\BAPBAP.Medusa.dll` | 168,448 B · **2026-05-31 18:21** |
| Mod source | `…\medusa-mod\MedusaMod.cs` | — |
| Build manifest | `…\BuildOutput\medusa.manifest` | text |
| Builder | `…\backport\MedusaBundleProject\Assets\Editor\BuildMedusaBundle.cs` | text |
| Unity build log | `…\medusa-mod\backport\unity_build.log` | text |

SHA256: `medusa-mod\medusa.bundle` == `BuildOutput\medusa` ==
`C4872D6E124E76F9F4B4EC75482FFC2795D051D3CA65EB7C25E9FE68023B1D70`.
Deployed `UserData` bundle = `6350111185A9B1C6…8741` (**different file**, older, smaller; no
`.manifest` sits beside it).

---

## 2. Definitive asset list inside the current bundle (authoritative)

### 2a. Why a raw string-scan is invalid here
A binary string-scan of `medusa-mod\medusa.bundle` for every requested token returned **all
`False`** — including `Medusa_Visual`, `.controller`, `Albedo`, `Normal` which we *know* are
present. Reason: the bundle is **UnityFS / LZMA-compressed**
(`BuildPipeline.BuildAssetBundles(..., BuildAssetBundleOptions.None, …)` in
`BuildMedusaBundle.cs`; `unity_build.log`: "Total compressed size 1.5 MB. Total uncompressed
size 4.1 MB"). Asset names are inside the compressed block, so `findstr`/`Select-String`
cannot see them. The authoritative sources are the Unity **`.manifest`** and the build log
asset report.

### 2b. Assets actually packed (from `BuildOutput\medusa.manifest`, CRC 1880444941)
Prefabs:
- `Assets/GameObject/Medusa_Visual.prefab`
- `Assets/GameObject/MedusaVfx/VFX_Medusa_Poison_Escape.prefab`
- `Assets/GameObject/MedusaVfx/VFX_Medusa_Poison_Hit.prefab`
- `Assets/GameObject/MedusaVfx/VFX_Medusa_Poison_Muzzle.prefab`
- `Assets/GameObject/MedusaVfx/VFX_Medusa_Poison_Puddle.prefab`
- `Assets/GameObject/MedusaVfx/VFX_Medusa_Poison_Trail.prefab`
- `Assets/GameObject/MedusaVfx/VFX_Medusa_Poison_Wall.prefab`

Plus: `Medusa.controller`, `Medusa_Material.mat`, `MedusaBase.asset` (mesh),
`Medusa_Anims_v03Avatar.asset`, `Medusa_Tex_Albedo_1024.png`, `Medusa_Tex_Normal_1024.png`,
and 24 `Medusa_*.anim` clips. The build report (`unity_build.log`) additionally shows the
VFX dependency closure rode along: `T_VFX_*` textures, `M_VFX_*`/`SM_VFX_*` materials & meshes,
and `_Lush_Uber_Particles*` / `Uber_Particles_Trails` / `_Lush_Slash` shaders.

`unity_build.log` confirmation lines:
- `[BuildMedusaBundle] BuildVfxPrefabs: built 6/6 native Medusa VFX prefab(s).`
- `[BuildMedusaBundle] Bundle 'medusa' size = 1567424 bytes (1530,7 KiB).`
- `[BuildMedusaBundle] === BuildMedusaBundle SUCCESS ===`

### 2c. The 5 requested native gameplay prefabs — **NOT PRESENT**
`Hitbox_MedusaPoisonProjectile`, `Hitbox_MedusaPoisonPuddle`, `Hitbox_MedusaWallPoison`,
`Hitbox_MedusaWallBoxDpsPoison`, `MedusaPuddleSpawner`, `VFXSpawn` do not appear in the
manifest, the project asset tree, or the build report. The bundle carries **renamed,
cosmetic-only** equivalents (`VFX_Medusa_Poison_*`).

Why they are stripped — `BuildMedusaBundle.cs` `DisableGameplayComponents()` disables every
MonoBehaviour whose type name contains `Network`, **`Hitbox`**, `Damage`, **`Projectile`**,
`Ability`, `Gameplay`, **`Dps`**, or **`Spawner`**; and `RemoveMonoBehavioursWithMissingScript`
removes the AssetRipper-stubbed scripts entirely (build log: VFX prefabs written with
`removedMissingScripts=1`). So even the visual prefabs that loaded keep no hitbox/spawner
logic — purely decorative.

---

## 3. The green-line fallback path (exact file:line)

`MedusaMod.cs` constants:
- `1247: MedusaVenomFxColor = new Color(0.18f, 1f, 0.32f, 0.95f);`  ← **bright green**
- `1249: MedusaVenomPuddleColor = new Color(0.03f, 0.78f, 0.18f, 0.7f);` ← green puddle
- `1251: MedusaPetrifyFxColor = new Color(0.78f, 0.82f, 0.74f, 0.96f);` ← pale grey-green (R/W ult)
- `1257-1267:` `Vfx{Escape,Hit,Muzzle,Puddle,Trail,Wall}Name = "VFX_Medusa_Poison_*"`
- `1269-1277:` `NativeVfxNames[6]` = the six `VFX_Medusa_Poison_*` strings (match bundle exactly)

Cast flow (`SpawnMedusaCastFx`, **line 1938**):
1. `if (TrySpawnNativeMedusaCastFx(val, val2, val3, slot)) { …; return; }` — native path.
2. `TrySpawnNativeMedusaCastFx` (**2126**) first line:
   `if (_medusaNativeVfxPrefabs.Count == 0) return false;` → if no native prefab loaded it
   returns false.
3. On false, control falls to the `switch (slot)` placeholder block (~**2083+**) that calls
   `SpawnMedusaBeam(... MedusaVenomFxColor ...)` (def. **2287**), `SpawnMedusaOrb` (**2332**),
   `SpawnMedusaPuddle` (**2360**). `SpawnMedusaBeam` builds a 2-point `LineRenderer` with the
   green `MakeFxMaterial` → **the green lines the user sees**.
   Examples: `case 0 "SerpentBolt"`, `case 1 "VenomSpitArc"`, `case 2 "SlitherTrail"`,
   `case 3 "PetrifyingGaze"`.

So: **green lines ⇔ `_medusaNativeVfxPrefabs` is empty ⇔ the loaded bundle yielded zero
`VFX_Medusa_Poison_*` prefabs** (or the bundle did not load at all).

Loading chain:
- `TryLoadBundle` (**3419**) → `ResolveBundlePath` (**3566**) → `LoadFromFile` →
  loads `Medusa_Visual`, then `LoadNativeMedusaVfxPrefabs` (**3512**) →
  `TryLoadNativeVfxPrefab` (**3529**) tries short name, `Assets/GameObject/MedusaVfx/<n>.prefab`,
  `Assets/GameObject/<n>.prefab`, then substring scan.
- `SpawnNativeMedusaVfx` (**2169**) instantiates and calls `DisableNativeVfxGameplay`
  (**2198**) — same Hitbox/Spawner/Dps/Projectile disable list at runtime (belt-and-braces).
- If bundle missing, `TryLoadBundle` logs: *"bundle not found … running in **Kitsu-clone
  visual mode**"* — this is the **Kitsu/Skinny/default fallback** the prompt mentions: when
  the bundle/prefab is unavailable the mod renders Medusa using a cloned base character +
  primitive green FX instead of her real assets.

---

## 4. `ResolveBundlePath` order and the stale-bundle hypothesis

`ResolveBundlePath` (3566) probes, in order, and returns the first existing:
1. `AssetAPI.ResolvePath("Medusa\\medusa.bundle")`
2. `AppContext.BaseDirectory\UserData\Medusa\medusa.bundle`
3. `cwd\UserData\Medusa\medusa.bundle`
4. `cwd\medusa.bundle`
5. `<asmDir>\..\UserData\Medusa\medusa.bundle`
6. `<asmDir>\..\medusa.bundle`

In the deployed game, candidate #1/#2 resolve to
`Battleroyalebuild\UserData\Medusa\medusa.bundle` — which is the **older May-30
1,275,524-byte** file. The current 1,567,424-byte bundle (with the 6 VFX prefabs) exists
only under `medusa-mod\` and `backport\BuildOutput\` (dev locations), **not** in the game's
`UserData\Medusa`. The DLL beside it (`Mods\BAPBAP.Medusa.dll`) is the **newer May-31 18:21**
build that expects `VFX_Medusa_Poison_*`.

Size delta (≈291 KB) is consistent with the 6 VFX prefabs + their `T_VFX_*`/`M_VFX_*`/`SM_VFX_*`
dependency closure (build report shows ~hundreds of KB of `T_VFX_*` textures + VFX
prefabs) being **added in the May-31 build** and therefore **absent from the May-30 deployed
bundle**. I could not enumerate the old bundle's contents directly (compressed, and it has no
`.manifest`), so this is inference from size/date, not a manifest read.

**Hypothesis H1 (Medium-High):** in-game green lines = stale `UserData\Medusa\medusa.bundle`
(old build, no/partial `VFX_Medusa_Poison_*`) → `LoadNativeMedusaVfxPrefabs` loads 0/6 →
`SpawnMedusaBeam` green fallback.
**Hypothesis H2 (Medium):** even with the new bundle, real *gameplay* hitboxes
(`Hitbox_Medusa*`, `MedusaPuddleSpawner`) are intentionally absent/disabled, so abilities can
look "wrong" vs. LatestBuild regardless — the bundle is cosmetic-only by design.
**Hypothesis H3 (Low-Med):** `CanSpawnClientFx` (returns false in batch/null-GFX) or a
`LoadFromFile` null on the old bundle could also yield Kitsu-clone mode + green FX.

---

## 5. Out-of-A4-scope items (no/limited evidence here)
Transparency / FPS drops / enemies-invisible-until-damaged / red-outline match remnants,
AMP-persistence reset (live-uploaded DLL resets), and queue 3–8 min / first-attempt-fails are
**not** addressable from the bundle artifacts I inspected; they belong to other agents. The
only adjacent datum: deployed bundle (May 30) lags the deployed DLL (May 31), which is itself
a persistence/deploy-pipeline symptom worth correlating with the AMP-persistence agent.

---

## 6. Confidence summary
- 5 named native hitbox/spawner prefabs absent from bundle: **High** (manifest + build log + builder source).
- Bundle is cosmetic-only `VFX_Medusa_Poison_*` with gameplay components stripped: **High**.
- Green lines = `SpawnMedusaBeam`/`MedusaVenomFxColor` fallback when 0 native prefabs: **High** (file:line cited).
- Mod VFX names match the *current* bundle prefab names: **High** (1269 vs manifest).
- In-game cause = stale May-30 `UserData` bundle vs May-31 DLL: **Medium-High** (size/date inference; old bundle not directly enumerable).
- String-scan all-False due to LZMA compression, not absence: **High**.

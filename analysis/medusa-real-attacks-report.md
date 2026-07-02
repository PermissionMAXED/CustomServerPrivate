# Medusa REAL Spawning Poison Attacks — Phase 2 Report

Status: IN PROGRESS

## Goal
Wire Medusa's ability casts to the REAL bundled `Hitbox_Medusa*` ability prefabs so attacks
visibly spawn (real projectile / puddle / wall / DPS-field meshes + authored poison VFX) and
deal damage, while strictly preserving the headless dedicated match-host (which previously hung
when ability particle VFX were processed on the `-batchmode -nographics` server).

## Research findings

### Source availability
- `neueBapbap\GameCode\ExportedProject\Assets\GameObject\Medusa.prefab` exposes only the
  `CharAbilities` firing-point transforms (`Firing Point`, `FiringPoint2`, `FiringPoint3`).
  The ability→hitbox binding lives in the ability `ScriptableObject`s (Assets\MonoBehaviour),
  whose serialized `spellPrefab`/hitbox GUID references were stripped by AssetRipper.
- `neueBapbap\_decomp` contains no `Medusa`-named symbols (IL2CPP generic ability classes;
  per-character data is serialized, not coded).
- Conclusion: the EXACT slot→prefab binding is NOT cleanly recoverable. A sensible mapping is
  used and documented below (matches the task's suggested fallback mapping and the existing
  per-slot VFX layout already in the mod).

### Bundle contents (confirmed)
`MedusaBundleBuilder.cs` packs these ability prefabs into `medusa.bundle` at
`Assets/GameObject/*.prefab`:
- `Hitbox_MedusaPoisonProjectile` (NetworkIdentity, NetworkTransform, Rigidbody, BoxCollider trigger, ProjectileMove, VFXSpawn)
- `Hitbox_MedusaPoisonPuddle` (NetworkIdentity, NetworkTransform, SphereCollider trigger, NetworkTransformFollow, TransformExpandRadius, VFXSpawn, AudioSource)
- `Hitbox_MedusaWallPoison` (NetworkIdentity, NetworkTransform, ColliderEnable, BehaviourTimedEnableSync, Rigidbody, BoxColliders, FogOfWarOcclusionMeshBuilder, VFXSpawn, AudioSource, child Obstacle)
- `Hitbox_MedusaWallBoxDpsPoison` (NetworkIdentity, HitboxDps, BoxCollider trigger, ColliderEnableNet)
- `MedusaPuddleSpawner`
- `VFX_Medusa_Poison_{Wall,Escape,Hit,Muzzle,Puddle,Trail}`

## Ability → prefab mapping (documented assumption)

| Slot | Ability (tooltip) | Real hitbox prefab spawned (client presentation) |
|------|-------------------|--------------------------------------------------|
| 0 (LMB) | Serpent Bolt (single-target bolt) | `Hitbox_MedusaPoisonProjectile` |
| 1 (Q)   | Venom Spit (area venom)           | `Hitbox_MedusaPoisonPuddle` (+ `MedusaPuddleSpawner`) |
| 2 (Space) | Slither (movement + knockup)    | `Hitbox_MedusaWallPoison` |
| 3 (Ult) | Petrifying Gaze (piercing line)   | `Hitbox_MedusaWallBoxDpsPoison` |

Assumption rationale: the four `Hitbox_Medusa*` prefabs map 1:1 onto the four ability slots;
basic attack → projectile is unambiguous; the remaining three are assigned per the task's
suggested fallback and aligned with the mod's existing per-slot VFX layout.

## Design (headless-safe)
- DAMAGE stays exactly as today: `ApplyAuthoredMedusaGameplay` runs only on the authoritative
  server (`IsAuthoritativeServer`), uses manual hit detection, instantiates NO prefabs and NO
  particles. The proven headless match-host path is untouched.
- The REAL `Hitbox_Medusa*` prefabs are added as CLIENT-SIDE PRESENTATION only, spawned through
  the SAME `SpawnMedusaCastFx` path that already gates everything behind `CanSpawnClientFx()`
  (false on `Application.isBatchMode` / `graphicsDeviceType == Null`). On the dedicated server
  nothing is instantiated, so no particle/shader processing occurs — the previous hang cause is
  structurally avoided.
- Spawned hitbox prefabs are stripped to inert visuals (gameplay/network/damage/collider/audio
  components disabled) so they cannot run damage or networking on the client; they only render
  the authored mesh + poison particles.

## Status: BUILD COMPLETE (0 errors) — final copy blocked by running game

## Exact code changes (`bapcustomchars-mod\MedusaMod.cs` + `.csproj`)

1. **New hitbox prefab name constants + `NativeHitboxNames[5]`** (after `NativeVfxNames`):
   `Hitbox_MedusaPoisonProjectile`, `Hitbox_MedusaPoisonPuddle`, `Hitbox_MedusaWallPoison`,
   `Hitbox_MedusaWallBoxDpsPoison`, `MedusaPuddleSpawner`.

2. **Loader extended (`LoadNativeMedusaVfxPrefabs`)**: after loading the 6 VFX prefabs it now also
   resolves all 5 `NativeHitboxNames` into the same `_medusaNativeVfxPrefabs` cache via the existing
   `TryLoadNativeVfxPrefab` resolver (tries `<name>`, `Assets/GameObject/MedusaVfx/<name>.prefab`,
   `Assets/GameObject/<name>.prefab`, then substring search over `GetAllAssetNames`). LoadAsset-only
   (no instantiation). Logs `native ability hitbox prefabs loaded: N/5`.

3. **Per-slot hitbox spawn (`TrySpawnNativeMedusaCastFx`)**: each slot now also calls
   `SpawnNativeMedusaHitbox(...)` for its mapped prefab, alongside the existing VFX:
   - slot 0 → `Hitbox_MedusaPoisonProjectile` (origin + dir*1.1, ttl 1.8)
   - slot 1 → `Hitbox_MedusaPoisonPuddle` + `MedusaPuddleSpawner` (puddle point, ttl 3.2)
   - slot 2 → `Hitbox_MedusaWallPoison` (launch point, ttl 3.0)
   - slot 3 → `Hitbox_MedusaWallBoxDpsPoison` (wall point, ttl 3.0)

4. **New method `SpawnNativeMedusaHitbox(name, pos, rot, ttl)`**: re-gates on `CanSpawnClientFx()`
   (defensive double-gate), resolves the cached prefab, instantiates, scales via `NativeVfxRootScale`,
   calls `DisableNativeVfxGameplay` to neutralize it, activates, sanitizes renderers, and
   `Object.Destroy` after `ttl`. Logs `native ability hitbox spawned (presentation-only)`.

5. **`DisableNativeVfxGameplay` hardened**: the script-name disable filter now also matches
   `Collider`, `VFXSpawn`, `Follow`, `Expand`, `EnableSync`, `Occlusion` (catches `ColliderEnable`,
   `ColliderEnableNet`, `VFXSpawn`, `NetworkTransformFollow`, `TransformExpandRadius`,
   `BehaviourTimedEnableSync`, `FogOfWarOcclusionMeshBuilder`). Added an `AudioSource` loop that
   `Stop()`s + disables looping poison audio. (VFX prefabs lack these → no change to the VFX path.)

6. **`NativeVfxRootScale`**: `Hitbox_Medusa*` and `MedusaPuddleSpawner` return world scale `1.0`.

7. **`BAPCustomChars.csproj`**: added `UnityEngine.AudioModule` reference (needed for the
   `AudioSource` strip; proxy present in `MelonLoader\Il2CppAssemblies`).

## How headless-safety is preserved
- **No new server work.** Damage is unchanged: `ApplyAuthoredMedusaGameplay` runs only under
  `IsAuthoritativeServer(caster)`, uses manual hit detection, instantiates nothing.
- **All hitbox/VFX instantiation is downstream of `CanSpawnClientFx()`**, which returns `false` on
  `Application.isBatchMode` and `graphicsDeviceType == Null` — the dedicated `-batchmode -nographics`
  match-host. Call chain: `SpawnMedusaCastFx` (early-returns on `!CanSpawnClientFx()`) →
  `TrySpawnNativeMedusaCastFx` → `SpawnNativeMedusaVfx` / `SpawnNativeMedusaHitbox` (re-gates again).
  The server never instantiates a particle, shader, projectile, or hitbox prefab.
- **Bundle load adds only `LoadAsset` calls** (same cost class as the already-shipping VFX loads the
  headless host tolerates today); particle processing happens only in `SanitizeNativeMedusaVfxRenderers`,
  reached only from the gated spawn path.
- Spawned hitboxes are inert presentation (network/damage/projectile/collider/spawn/audio disabled),
  so even on a render client they cannot run gameplay or Mirror networking.

## DLL SHA256
- New build output (`bin\Release\BAPCustomChars.dll`):
  `6CBB20B989C4B4A40B4C0BBC506AB8308B8BA7D0AD3DD47B7FF6966BA8C23690`
- Previous DLL currently in the live Mods folder (to be replaced):
  `42717381FCFDC184EE5DF186159B7F90A6E323ABA6C6416DA68642C1058DCDFE`

## Build result
`dotnet build -c Release` → **0 errors** (pre-existing nullable CS86xx warnings only). DLL produced
and auto-deployed to `BAPBAPModdingAPI\Battleroyalebuild\Mods`.

## Open blocker / TODO
- **Final overwrite into `CustomServer\Spiel\Battleroyalebuild\Mods\BAPCustomChars.dll` is BLOCKED**:
  the game client `bapbap.exe` (PID 19316) is running and MelonLoader holds an open handle on the
  existing DLL, so the file is locked. I did not terminate the running game (it may be an active
  session). Complete the copy after closing the game:
  ```powershell
  Copy-Item -Force "C:\Users\Administrator\Downloads\BAPBAPModdingAPI\bapcustomchars-mod\bin\Release\BAPCustomChars.dll" `
    "C:\Users\Administrator\Downloads\CustomServer\Spiel\Battleroyalebuild\Mods\BAPCustomChars.dll"
  ```
  After copy, the deployed DLL hash must equal `6CBB20B9...C23690`.
- **In-game verification pending**: confirm on a render client that each slot spawns its mapped
  `Hitbox_Medusa*` mesh + poison VFX, and confirm a `-batchmode -nographics` dedicated match-host
  still bootstraps + completes a match (expected: zero hitbox/VFX instantiation server-side).
- **Mapping assumption** (slot 2 Slither → WallPoison, slot 3 Ult → WallBoxDpsPoison) is a documented
  guess; if real serialized ability bindings become recoverable, revisit `TrySpawnNativeMedusaCastFx`.
- **Generalization (Phase 3)**: hitbox names are currently Medusa-specific constants. Move
  `NativeHitboxNames` + the slot→prefab table into `CustomCharDefinition` (e.g. a `slotHitboxes` JSON
  array) so each character's JSON drives its own hitbox mapping.

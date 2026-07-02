# C7 — Mirror Spawn Lifecycle Race (model briefly appears then disappears)

Scope: Why the Medusa model flickers in/out at spawn. Establish the spawn order
(base char spawn vs Medusa graft vs base-renderer-disable), explain the race
causing the flicker, and judge whether the graft happens too early/late relative
to `OnStartClient`. Overlaps C1/B1.

READ-ONLY research. No source/build/deploy changes were made. This file is the
only artifact created.

## Primary sources read

- Mod: `C:\Users\Administrator\Downloads\BAPBAPModdingAPI\medusa-mod\MedusaMod.cs` (240,743 bytes)
- Decompiled (IL2CPP stubs):
  - `...\BAPBAPModAPI\reverse-engineering\decompiled\Assembly-CSharp\Il2CppBAPBAP\Game\GameMode.cs`
  - `...\Il2CppBAPBAP\Entities\EntityManager.cs`
  - `...\Il2CppBAPBAP\Entities\CharAbilities.cs`
  - `...\Il2CppMirror\Il2CppMirror\NetworkIdentity.cs`, `NetworkServer.cs`
- AssetRip reconstruction (signatures only, empty bodies):
  - `C:\Users\Administrator\Downloads\CustomServer\AssetRip\ExportedProject\Assets\Scripts\Assembly-CSharp\BAPBAP\Entities\EntityManager.cs`

> CRITICAL CAVEAT on the cross-check: both decompiled forms are **IL2CPP
> stubs**. `EntityManager.Start/OnStartClient/Awake` (EntityManager.cs:1829,
> 1840, 1851) are pure `il2cpp_runtime_invoke` wrappers, and the AssetRip copy
> (CustomServer EntityManager.cs:~470-490) has **empty bodies** (`public override
> void OnStartClient(){}`). `GameMode.SpawnPlayerChar` is likewise a stub
> (GameMode.cs:3792-3800). Therefore the *native* execution order of
> `NetworkServer.Spawn` → SyncVar deserialize → `OnStartClient` → Unity `Start`
> cannot be read from these files; it is inferred from Mirror/Unity lifecycle
> convention plus the mod's hook structure and its own `[Medusa]` log lines.
> Native internals confidence is therefore LOW; the mod-side ordering is HIGH.

## The graft entry points (Harmony postfixes) — file:line

All three fire **after** the native method, i.e. after the base character is
already instantiated/spawned:

- `GameModeSpawnPlayerCharPatch` — `MedusaMod.cs:711` (class), Postfix at
  `:731`, calls graft at **`:739`**:
  ```csharp
  EnsureLiveMedusaEntity(playerManager.primaryCharManager, "GameMode.SpawnPlayerChar.postfix");
  ```
- `EntityManagerStartPatch` — `MedusaMod.cs:801`, Postfix calls **`:808`**:
  ```csharp
  EnsureLiveMedusaEntity(__instance, "EntityManager.Start");
  ```
- `EntityManagerOnStartClientPatch` — `MedusaMod.cs:811`, Postfix calls **`:818`**:
  ```csharp
  EnsureLiveMedusaEntity(__instance, "EntityManager.OnStartClient");
  ```
- `CharAbilitiesPreAwakePatch` — `MedusaMod.cs:821`, Postfix at `:826` only does
  `ApplyMedusaAbilityRuntimeUi(__instance, "CharAbilities.PreAwake")` (`:832`) —
  it does NOT graft the visual.

Native spawn anchor (stub): `GameMode.cs:3792` `public unsafe void
SpawnPlayerChar(PlayerManager playerManager, Vector3 spawnPos = default)`.

## What the graft does, and the disable-before-instantiate order

`EnsureLiveMedusaEntity` — `MedusaMod.cs:7037`:
- `:7041` gate: `if (entity == null || !LooksLikeMedusaEntity(entity)) return;`
- `:7045-7046` forces `entity.charId / NetworkcharId = CurrentMedusaId()`
- `:7055` `instance.EnsureLiveMedusaVisual(gameObject, source);`  ← actual graft
- `:7057` `ScheduleLiveMedusaRefresh(entity, source);`

`EnsureLiveMedusaVisual` — `MedusaMod.cs:5066`. Three branches:

1. **Bundle-not-loaded guard** `:5076`:
   ```csharp
   if (root == null || !_bundleLoaded || _medusaVisualPrefab == null) return;
   ```
   (`_bundleLoaded` set at `:3500`.) Early-return here leaves the base model
   fully visible (renderers NOT yet disabled in this branch).

2. **Already-stable / existing-visual** `:5081` and `:5086`. The existing path
   re-anchors then re-disables base: `:5111`
   `DisableBaseCharacterRenderers(root, source + ".existing")`, and
   `RebindMedusaRuntime(root,...)` at `:5114`.

3. **Fresh graft** `:5121+`. Order is the smoking gun:
   - `:5138` `int value = DisableBaseCharacterRenderers(root, source + ".new");`
     **(base renderers turned OFF first)**
   - `:5139` `GameObject val2 = Object.Instantiate(_medusaVisualPrefab, root.transform, false);`
     **(Medusa visual instantiated AFTER)**
   - `:5210` `RebindMedusaRuntime(root, source + ".new")`

`DisableBaseCharacterRenderers` — `MedusaMod.cs:5228`: iterates
`root.GetComponentsInChildren<Renderer>(true)` and sets
`componentsInChild.enabled = false` for every renderer not under `Medusa_Visual`
(skip test `IsUnderMedusaVisual`, `:5264`). It only toggles `Renderer.enabled`;
it does NOT touch outline/minimap/fog components.

`RebindMedusaRuntime` — `MedusaMod.cs:5460`: finds the Medusa animator, rebinds
`CharAnimator`/`CharFootsteps`, then **disables every other Animator**
(`((Behaviour)componentsInChild3).enabled = false;`) and finally
`DisableBaseCharacterRenderers(root, source + ".rebind")`.

Delayed re-graft retries — `ScheduleLiveMedusaRefresh` `:7069`, scheduling
`Once(0.15f); Once(0.45f); Once(0.95f); Once(1.8f);` (`:7110-7113`), each
re-running `EnsureLiveMedusaVisual` + ability palette.

## Spawn order timeline (base spawn vs graft vs renderer-disable)

```
[native]  GameMode.SpawnPlayerChar  (GameMode.cs:3792)  → NetworkServer.Spawn
            └─ base char prefab (Kitsu/Skinny/default) instantiated, renderers LIVE
[native]  EntityManager.Awake → SyncVar charId deserialized (client) → OnStartClient → Unity Start
[mod]     EntityManagerStartPatch.Postfix      (MedusaMod.cs:808)  ┐ whichever
[mod]     EntityManagerOnStartClientPatch.Postfix (MedusaMod.cs:818)├ fires first
[mod]     GameModeSpawnPlayerCharPatch.Postfix (MedusaMod.cs:739)  ┘ wins
            └─ EnsureLiveMedusaEntity → EnsureLiveMedusaVisual
                 :5138 DisableBaseCharacterRenderers   (base goes INVISIBLE)
                 :5139 Instantiate Medusa_Visual        (Medusa becomes visible)
[mod]     +0.15/0.45/0.95/1.8s delayed re-grafts (MedusaMod.cs:7110-7113)
```

## The race that causes the flicker

There is a window of **≥1 render frame** between the base char becoming visible
(native spawn) and the first successful graft (`:5138` disable + `:5139`
instantiate). During that window the **base model (Kitsu/Skinny/default) is
drawn** → "model briefly appears." The instant `DisableBaseCharacterRenderers`
runs, the base disappears. If the Medusa visual then instantiates and binds
correctly, Medusa replaces it; if not, you get a hole.

Failure variants and their file:line cause:

- **Brief-appear-then-disappear (flicker)**: inherent ordering — base spawns
  first (GameMode.cs:3792), graft disables base only on the postfix
  (MedusaMod.cs:5138). HIGH confidence.
- **Appears then goes invisible (no Medusa)**: graft entered branch 3, disabled
  base at `:5138`, but Medusa instantiate/bind failed or the bundle guard at
  `:5076` returned on a *later* re-entry after a prior pass already disabled base
  → base off, Medusa absent. MEDIUM-HIGH.
- **First-attempt-fails-then-works**: see next section.

## Too early or too late relative to OnStartClient?

Both, depending on which hook wins the race:

- **TOO EARLY (Start before SyncVar):** `LooksLikeMedusaEntity` (`MedusaMod.cs:6050`)
  gates on `IsMedusaId(entity.charId)` (`:6055`). `charId` is a Mirror
  **`[SyncVar] public int charId;`** (AssetRip EntityManager.cs, SyncVar block
  ~lines 248-260). On a remote client, the SyncVar value arrives in the spawn
  payload around `OnStartClient`. If `EntityManager.Start` postfix (`:808`) runs
  before that value is applied, `charId` is still 0 → `IsMedusaId` false →
  `LooksLikeMedusaEntity` falls back to name/SMR sniffing
  (`LooksLikeMedusaObject` `:6068`, matches "Char_Medusa"/"MedusaBase"). On the
  *base* prefab clone the name is NOT Medusa yet, so the graft is **skipped on
  the first hook** and the base model shows. A later `OnStartClient` postfix
  (`:818`) or one of the delayed retries (`:7110-7113`) then succeeds → this is
  the mechanism behind "first attempt fails, then works." HIGH-MEDIUM (charId is
  confirmed SyncVar; exact Mirror Start-vs-SyncVar ordering inferred because the
  native bodies are stubs).

- **TOO LATE (bind before component graph ready):** `charMaterial`/`charAnim`
  are wired in native `Awake/Start`. If the graft binds via
  `BindMedusaVisualToCharMaterial` / `RebindMedusaRuntime` (`:5210`, `:5460`)
  before those are populated, the visual is anchored but its CharMaterial-driven
  visibility never gets primed → transparency / "visible only after damage"
  (a damage/material refresh re-runs visibility). The repeated delayed grafts
  (`:7110-7113`) and the per-frame world scan are the band-aid for this.

## Linkage to the other reported symptoms (overlap C1/B1/C6)

- **FPS drops:** the graft is re-driven from many places — three postfix hooks
  plus the local-binding world scan `EnsureLocalMedusaBindingFromWorld`
  (`MedusaMod.cs:1617`) which calls `Object.FindObjectsOfType<EntityManager>()`
  (`FindBestLocalMedusaEntity` `:1683`) and `GetComponentsInChildren<Renderer>(true)`
  / `<SkinnedMeshRenderer>(true)` repeatedly. Stable-caching exists
  (`MarkLiveMedusaVisualStable` `:4380`, `_runtimeReboundVisualRoots.Add(rootId)`
  gate at `:5113`/`:5208`, cheap-check throttle `num - value < 1f` `:5102`) but
  the world scan + cheap re-check still recur. MEDIUM-HIGH.
- **Enemies invisible / visible-only-after-damage:** the retry/world-scan path is
  **local-biased** — `EnsureLocalMedusaBindingFromWorld` returns early unless
  `PlayerAPI.Local` is Medusa (`:1622`), and `FindBestLocalMedusaEntity` resolves
  the *local* entity. Remote Medusa entities only get the three postfix hooks;
  if those lose the SyncVar race (above) there is no per-frame retry for remote
  entities, so they stay base/invisible until a material refresh. MEDIUM.
- **Persistent remnant / red outline:** `DisableBaseCharacterRenderers` only
  flips `Renderer.enabled` (`:5249`); outline/minimap/fog/hidden components are
  untouched, so an outline can persist after the mesh is hidden. (Cleanup detail
  is C6's domain — `C6_match_remnants_cleanup.md`.) MEDIUM.

## Hypotheses + confidence (C7)

1. Flicker = inherent base-spawn-first / disable-on-postfix ordering
   (GameMode.cs:3792 spawn → MedusaMod.cs:5138 disable). **HIGH.**
2. "First attempt fails then works" = `charId` SyncVar not yet applied when the
   `EntityManager.Start` postfix (`:808`) runs, so `LooksLikeMedusaEntity`
   (`:6055`) skips; later `OnStartClient` (`:818`) / delayed retries
   (`:7110-7113`) succeed. **HIGH-MEDIUM.**
3. Graft is effectively **too early** on the Start hook and is *retried late*;
   the 4 delayed re-grafts are a workaround, not a fix. **HIGH (mod-side).**
4. Native execution order cannot be confirmed from the decompiled files (IL2CPP
   stubs / empty AssetRip bodies); relies on Mirror convention. **LOW (native).**

## Concrete fix directions (NOT applied — research only)

- Gate the graft on a confirmed Medusa identity arriving (e.g. graft only once
  `charId` SyncVar == Medusa, i.e. drive it from the `OnStartClient` postfix /
  charId SyncVar hook rather than Unity `Start`), to remove the early-skip race.
- Instantiate the Medusa visual **before** disabling base renderers, or disable
  base in the same frame the Medusa renderers are confirmed active, to close the
  one-frame flicker window at MedusaMod.cs:5138→5139.
- Extend the retry/world-scan to remote entities (currently local-biased at
  MedusaMod.cs:1622) for the "enemies invisible until damaged" case.

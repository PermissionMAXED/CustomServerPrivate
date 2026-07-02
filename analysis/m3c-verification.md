# M3c Verification — Authentic Networked Medusa Poison Hitboxes

**Date:** 2026-06-12
**Scope:** Pre-live-deploy QC of the M3c layer in `C:\Users\Administrator\Downloads\BAPBAPModdingAPI\netcustomchar-mod`
(`CustomAbilityEngine.cs` M3c, `MedusaVisualGraft.cs` `LoadBundleGameObject`, `CustomCharMod.cs`
both-peer registration + palette). M3c registers 4 NEW networked hitbox prefabs
(assetIds `0xB0B0F010..0xB0B0F013`) cloned from shipped hitbox chassis with the Medusa poison VFX
grafted, and spawns them on charId‑15 casts.
**Stack:** BAPBAP, Unity 2022.3.38f1 IL2CPP, Mirror, MelonLoader + Il2CppInterop + Harmony, x86.
We own server + client; identical DLL + bundle on all peers.
**Authoritative sources used:** decompiled `Assembly-CSharp` (`neueBapbap\...\_DisabledScripts`),
IDA hexrays `CanHitEntity`, il2cpp dumps, research r02 (mirror), r06 (hitbox), r09 (lifecycle),
r15 (bundle-registration), and the proven M1 template in `CustomCharMod.cs`.

## Verdict: **GO** (after the one parity fix below; rebuilt to 0 errors)

| # | Critical gate | Result |
|---|---|---|
| 1 | Registration parity (server == client, before spawn) | PASS — after fix |
| 2 | AssetId collision (`0xB0B0F010..13` + char `0xB0B00F0F`) | PASS |
| 3 | Mirror layout parity (chassis NB set/order unchanged; graft adds no NI/NB) | PASS |
| 4 | Headless safety (`-batchmode -nographics`) | PASS |
| 5 | Pooled-despawn / lifecycle / no per-hook re-grow | PASS |
| 6 | Single damage path; HitboxBase config valid | PASS |

---

## Fix applied (critical hardening — gate #1)

**Finding (deviation from the proven M1 template):** M3c bundled the explicit Mirror registration
*inside* the one-time build path (`BuildMedusaNetworkedHitbox` → `RegisterNetworkedPrefab`), and the
build is guarded by `_medusaSlotBuilt[slot]`. M1, by contrast, splits this: it builds the prefab
once (`_built`) but re-asserts `EnsureMirrorRegistration` on **every** hook
(`GNM.Awake` / `OnStartServer` / `OnStartClient` / `GM.SpawnPlayerChar`).

Consequence as written: if a clone is built at `GNM.Awake` (the normal case, since
`networkPrefabLibrary` is serialized and populated by then), `NetworkClient.active` and
`NetworkServer.active` are both `false`, so the explicit client `NetworkClient.RegisterPrefab` and
the pool create were **skipped and never retried**. Client resolution then relied *solely* on the
native `GameNetworkManager.OnStartClient` loop iterating `networkPrefabLibrary.InstantiatedPrefabs`
(r02 §2A). That happens to work in the common case (our clone is injected into `InstantiatedPrefabs`
at Awake, before that loop runs), but it is strictly weaker than M1 and fragile to build-timing.

**Fix:** decoupled BUILD (once per slot, still guarded by `_medusaSlotBuilt`) from REGISTER
(idempotent, **every** hook), exactly matching M1's proven build-once / register-every-hook split:

- `BuildMedusaNetworkedHitbox` no longer calls `RegisterNetworkedPrefab`; it only clones, grafts +
  neutralizes (render peers), sanitizes identity, and assigns the stable assetId.
- `EnsureMedusaHitboxesRegistered` now calls `RegisterNetworkedPrefab(gnm, lib, _medusaSlotPrefab[slot], _medusaAssetId[slot])`
  on every invocation for each successfully built slot, so the explicit client `RegisterPrefab` +
  pool create run as soon as the peer goes active (`OnStartClient` / `OnStartServer` postfix),
  guaranteeing the same assetId is resolvable on the client **before** the first
  `NetworkServer.Spawn` — no longer dependent on build-timing or solely on the native loop.

**Idempotency preserved (gate #5):** `RegisterNetworkedPrefab` appends to `InstantiatedPrefabs` and
base `NetworkManager.spawnPrefabs` only if absent, and `NetworkPrefabPool.Create` is
`poolLookup`-guarded by assetId (decompiled `NetworkPrefabPool.Create`), so repeated hooks cause no
array re-grow and no duplicate pools. `NetworkClient.RegisterPrefab` re-registration of the same
prefab/assetId is a harmless overwrite.

---

## Gate-by-gate detail

### 1. Registration parity — PASS (after fix)
- Both peers reach `CustomAbilityEngine.EnsureMedusaHitboxesRegistered(gnm)` from
  `CustomCharMod.EnsureRegistered`, which is driven by the same `GNM.Awake` /
  `OnStartServer` / `OnStartClient` / `GM.SpawnPlayerChar` postfixes used by the proven M1 char.
- Client: the clone is added to `networkPrefabLibrary.InstantiatedPrefabs` (picked up by the native
  `OnStartClient` 1:1 `NetworkClient.RegisterPrefab` loop, r02 §2A) **and** explicitly registered via
  `NetworkClient.RegisterPrefab(prefab, assetId)` once `NetworkClient.active` (now re-asserted every
  hook). Two independent channels resolve the same `assetId`.
- Server: per r02/r15, `NetworkServer.Spawn` reads `assetId` directly off the spawned object's
  `NetworkIdentity`; no server-side pre-registration is required. The assetId is baked on the clone
  at build time (`SanitizeAndAssignAssetId`), identical to the client's value.
- A server `NetworkServer.Spawn(clone)` therefore emits a `SpawnMessage` carrying
  `0xB0B0F01x`, which every client resolves to its locally-registered Medusa clone. No
  invisible/dropped hitbox.

### 2. AssetId collision — PASS
- Char `0xB0B00F0F` vs hitbox `0xB0B0F010/F011/F012/F013` are mutually distinct (note `0F0F` vs
  `F010`). The 4 hitbox ids are distinct.
- `ResolveFreeAssetId` runs per slot and bumps on collision, scanning `NetworkPrefabPool.poolLookup`
  and `NetworkClient.prefabs` (same check the proven M1 `AssertAssetIdFree` uses). Distinct
  high-sentinel base values → no inter-slot cascade.
- Residual (low) risk, identical to proven M1: the "in-use" set differs between a dedicated server
  (no `NetworkClient.prefabs`) and a client. For these high sentinels neither is in use on either
  peer, so both resolve to the same base ids and parity holds. No shipped prefab is expected to bake
  ids in this range.

### 3. Mirror layout parity — PASS
- The clone is `Instantiate`d from a shipped hitbox chassis, so it keeps the real weaved
  `NetworkIdentity` + `HitboxBase` (+ `ProjectileMove`) NetworkBehaviour set and order.
- The grafted Medusa subtree is added as a child and then `NeutralizeGraftedSubtree` strips every
  `NetworkBehaviour` and `NetworkIdentity` (`DestroyImmediate`), disables colliders, and makes
  rigidbodies inert. Per r15, an IL2CPP AssetBundle cannot even carry game `NetworkBehaviour`/
  `NetworkIdentity` types, so in practice the visual prefab contributes zero networked components;
  the neutralization is defensive.
- **Order is correct and essential:** the graft + neutralization run *before*
  `SanitizeAndAssignAssetId` → `InitializeNetworkBehaviours()`, so the rebuilt `NetworkBehaviours`
  array reflects only the chassis components (grafted NBs already destroyed). Server (no graft) and
  client (graft, neutralized) therefore produce an identical per-component SyncVar serialization
  layout. The grafted child being a non-networked extra transform has no effect on Mirror.

### 4. Headless safety — PASS
- `MedusaVisualGraft.CanSpawnClientFx()` returns `false` when `Application.isBatchMode`. The graft
  (`GraftMedusaPoisonVisual` → bundle `LoadBundleGameObject` + `Instantiate` of particle/renderer
  VFX) is gated behind it, so a `-batchmode -nographics` dedicated host builds the **bare** chassis:
  no bundle instantiate, nothing rendered.
- The bare server clone keeps an identical `NetworkIdentity` + `HitboxBase` layout and the same
  baked assetId as the client's grafted clone → replication parity preserved.
- All M3c paths (scan, build, graft, sanitize, register, spawn) are wrapped in try/catch with
  per-slot fallback to the proven M3b shipped prefab, so nothing throws server-side.

### 5. Pooled-despawn / lifecycle — PASS
- Spawns are `UObject.Instantiate(prefab)` + `NetworkServer.Spawn(obj, null)` (fresh, non-pooled
  instance) — not `NetworkPrefabPool.Spawn` — so the pool's despawn bookkeeping never reaps the live
  hitbox early.
- Lifetime is governed by the chassis's own server-side `HitboxBase` ttl (`doTtl=true`,
  `ttl=3f`/`2.5f`) and hit flags (`destroyOnCharHit`/`destroyOnStaticCollision` for projectiles),
  i.e. the game's own clean self-destruct path. Verified `doTtl`/`ttl`/`destroyOnCharHit`/
  `destroyOnStaticCollision` exist on `HitboxBase` (decomp).
- No double-registration / no per-hook array re-grow: build is once-per-slot (`_medusaSlotBuilt`);
  registration appends-if-absent and is `poolLookup`-guarded (see fix idempotency note).

### 6. Damage — PASS
- Exactly one damage source per cast: in `FireServer`, when `TrySpawnNetworkedPrefab` returns true
  the authoritative `ApplyServerHit` cone is **skipped** (`if (!spawnedHitbox)`). The spawned
  hitbox's own server-only `OnTrigger*` → `CharHurtbox.ApplyHit` pipeline applies damage + status,
  replicated to all peers.
- Friendly-fire config verified against IDA `HitboxBase.CanHitEntity`: for an enemy
  (different team and owner) a hit succeeds iff `!onlyHitAllies`. The engine sets
  `onlyHitAllies=false`, `allowHitToTeam=false`, `allowHitToOwnerPlayer=false` → hits enemies only.
  **Note:** this build has NO `allowHitToEnemies` field (it exists only in a divergent dump); the
  current flag set is the correct and complete config for this build — do **not** add
  `allowHitToEnemies` (it would not compile).
- `damage`, `directional`, `ttl`, `NetworkownerPlayerId`, `NetworkteamId`, `otherChar`, and
  `statusEffects` all verified as valid `HitboxBase` members; `ProjectileMove.Networkspeed`/`ttl`
  verified. Status effects are copied onto the hitbox's server-side `statusEffects` list so poison/
  petrify replicate through the same single path.
- The grafted visual's colliders are disabled, so it cannot introduce a second/stray trigger hit.

---

## Build result

- Command: `dotnet build NetworkedCustomChar.csproj -c Release -t:Rebuild`
- Result: **Build succeeded — 0 Warning(s), 0 Error(s)** (deterministic; rebuild produced an
  identical binary).
- Output DLL: `netcustomchar-mod\bin\Release\NetworkedCustomChar.dll`
  - **SHA256:** `0E0501B27E6CFEB1E34426589914B42B190A1D261FE515EFEF4759A18E15A8A9`
  - **Size:** `57856` bytes

## Residual notes (non-blocking)
- AssetId collision-check uses peer-local "in-use" sets (server lacks `NetworkClient.prefabs`); safe
  for the chosen high sentinels and identical to proven M1. If you ever lower the sentinel range,
  re-evaluate.
- On a client that builds the clone while already active, the pool path registers a pooled handler;
  on a client that builds before active, the native loop registers it 1:1. Both are valid for the
  server's non-pooled `Instantiate` + `Spawn` and are consistent within each client; identical to M1.

**Deployment not performed (per instructions).**

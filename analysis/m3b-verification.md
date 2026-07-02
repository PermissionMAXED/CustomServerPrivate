# M3b Visible-Attack Layer — Deploy Verification (netcustomchar-mod)

Target: `C:\Users\Administrator\Downloads\BAPBAPModdingAPI\netcustomchar-mod\CustomAbilityEngine.cs`
Scope: networked custom Medusa (charId 15), IL2CPP / Mirror / MelonLoader+Il2CppInterop+Harmony, x86; server+client owned.
Reference: real proxy assemblies (`HitboxBase`/`ProjectileMove`/`NetworkPrefabLibrary`/`NetworkPrefabPool`/`EntityManager` decompiled), live-body GEHEIMBUILD (`Hitbox.cs`/`HitboxBase.cs`/`AB_SpawnHitbox_Base.cs`), r06.
Verdict date: 2026-06-12. **Do NOT deploy yet (per task) — verification only.**

---

## Result: **GO** for the live dedicated-server deploy of the M3b layer.

Rebuilt to **0 errors / 0 warnings**.
- DLL: `bin\Release\NetworkedCustomChar.dll`
- SHA256: `F4210B2BA8B324B375DF81475E963FAE440976F4C3A16961A4E8112B5CF6B570`
- Size: `49152` bytes
- Built: 2026-06-12 12:24:59

One MEDIUM correctness gap was found and FIXED in-place (friendly-fire flag normalization). No crash-level, desync, or double-damage defects were found. All member names, the Mirror spawn overload, headless gating, and dedupe verified against the real assemblies/live bodies.

---

## Findings

| # | Issue | Severity | File:Line | Status / Fix |
|---|-------|----------|-----------|--------------|
| 1 | Arbitrary library prefab is spawned with its **serialized friendly-fire flags untouched** (`onlyHitAllies`/`allowHitToTeam`/`allowHitToOwnerPlayer`). If the first hitbox in the library is an ally/heal/self hitbox, `CanHitEntity` would make enemies take **no damage** — violating the "correct damage" deploy gate. | MEDIUM (correctness) | CustomAbilityEngine.cs ~`TrySpawnNetworkedPrefab` after `otherChar` assignment | **FIXED**: force `onlyHitAllies=false`, `allowHitToTeam=false`, `allowHitToOwnerPlayer=false` before spawn, so a cast reliably damages opponents regardless of which prefab resolved. Members verified on `HitboxBase` ([SerializeField] bools). |
| 2 | Catalog selection (first hitbox in `InstantiatedPrefabs`/`PooledPrefabs`) is non-deterministic; could pick a `HitboxDps`/shield/ring hitbox with non-projectile semantics. | LOW (cosmetic/behavioral, not crash) | `EnsurePrefabCatalog` | ACCEPTED (matches documented M3b model). Mitigated by #1. Recommend a name-allowlist in a later pass; logs every candidate (`[M3b] hitbox prefab: ...`) so the live choice is auditable. |
| 3 | `statusEffects` on the picked prefab: when `BuildStatusEffects` returns empty (SO not resolved yet), the prefab's own `statusEffects` are left intact rather than cleared. | LOW | `ApplyStatusEffectsToHitbox` | ACCEPTED — early-returns before mutating, so it can only *add* the prefab's authored effects, never crash. Poison/petrify still ride the server `ApplyHit` pipeline once SOs resolve. |

No HIGH/CRITICAL issues.

---

## Point-by-point verification

### 1. HitboxBase / Hitbox / ProjectileMove member correctness — PASS
Verified against the real proxy `Il2CppBAPBAP.Entities.HitboxBase`/`ProjectileMove` (decompiled) AND the live GEHEIMBUILD bodies. Every member the engine touches exists with the exact name/type:

`HitboxBase`: `NetworkownerPlayerId` (int SyncVar setter, `GeneratedSyncVarSetter(...,1uL)`), `NetworkteamId` (int SyncVar, `2uL`), `otherChar` (GameObject), `damage` (int), `directional` (bool), `doTtl` (bool), `ttl` (float), `destroyOnCharHit` (bool), `destroyOnStaticCollision` (bool), `statusEffects` (`List<StatusEffectInfo>` get→`_statusEffects`, set = Clear+AddRange), plus the fix-added `onlyHitAllies`/`allowHitToTeam`/`allowHitToOwnerPlayer` (bool). 
`ProjectileMove`: `speed` (float), `Networkspeed` (float SyncVar), `ttl` (float). 
All match r06 and the live bodies. **No wrong names.**

### 2. NetworkServer.Spawn(GameObject, NetworkConnection) — PASS
Confirmed 3 overloads in `Il2CppMirror.NetworkServer`: `(GameObject, GameObject)`, `(GameObject, NetworkConnection ownerConnection = null)`, `(GameObject, uint, NetworkConnection = null)`. The engine declares a typed `NetworkConnection ownerConn = null!` → resolves the **2-arg `NetworkConnection`** overload unambiguously (no ambiguity with the `GameObject` overload). It is server-authoritative (`[Server]`-class API). Replication: the engine `Instantiate`s a clone of an **already-registered library prefab** and spawns the clone — identical to the game's own `AB_SpawnHitbox_Base.DoUse` (Instantiate `config.hitboxPrefab` → set SyncVars → `NetworkServer.Spawn`). The clone keeps the source prefab's `NetworkIdentity.assetId`, which every peer already knows → replicates + renders on all clients. **Confirmed.**

### 3. Double-damage — PASS (exactly one path)
`FireServer`: `spawnedHitbox = TrySpawnNetworkedPrefab(...)`; the cone (`FindTargets`→`ApplyServerHit`) runs only inside `if (!spawnedHitbox)`. When a prefab resolves, the spawned hitbox's server-only `OnTriggerEnter`→`DoEntityHit`→`CharHurtbox.ApplyHit` is the **sole** damage source; the cone is skipped. When no prefab resolves, only the cone runs. **No double damage.**

### 4. Headless safety (-batchmode -nographics) — PASS
- Our spawn path never calls `SetAbility`, so `HitboxBase.ability` stays null. Every ability-dependent server method is null-guarded in the live body: `OnHitSuccess` (`if (ability != null)`), `OnHitKill`, `OnWallHit`, `OnHitboxHit`, and `DestroyHitbox` (`if (ability != null) { OnHitboxDestroy/OnHitboxEnd }`). TTL-driven `Hitbox.Update`→`DestroyHitbox`→`SvDelayDestroyHitbox`→`SvDestroyHitbox` works without an ability and, since we `Instantiate` a fresh (non-pooled) copy, `NetworkPrefabPool.IsPooled`=false → clean `NetworkServer.Destroy` (no pool corruption).
- `HitboxBase.Awake` caches `vfxSpawn/audioPlayFmod/audioPlayIntervals` via `TryGetComponent` and only touches them when non-null; client-only presentation (`OnStartClient`, `ClDestroyHitbox`, `DebugManager.Instance`) never runs on a server-only host.
- The game itself instantiates these prefabs (incl. ParticleSystem/VFX children) server-side normally; the dedicated host instantiates but does not render. Our spawn is gated to `IsServer(caster)` = `((NetworkBehaviour)e).isServer`, and `EnsurePrefabCatalog`/`NetworkServer.Spawn` only run inside that server gate. **Safe on -batchmode -nographics.**

### 5. Catalog enumeration safety — PASS
`EnsurePrefabCatalog`: null-checks `GameNetworkManager.Instance` and `networkPrefabLibrary`; `Consider()` null-checks each GameObject and wraps `GetComponentInChildren<HitboxBase>`/`<ProjectileMove>` in try/catch (prefab lacking components → skipped, never throws); `InstantiatedPrefabs != null` and `PooledPrefabs != null` guards; `Config c == null` and `c.prefab` try/catch; whole method wrapped in try/catch with a warning. A prefab without a `HitboxBase` is silently skipped. **Won't throw.**

### 6. Throttle / resim dedupe — PASS
Hook = `Ability.SetState` (prefix captures old state, postfix runs engine). `IsCastStart` fires only on a transition from Ready/Aiming (old `<2`) into Casting/Active (new `2|3`), so steady-state/`SetState`-to-same-state calls are ignored. `Throttle` adds a per-(caster pointer, slot) 0.38s window so resim/duplicate authoritative transitions in the same cast fire the engine once. Server-gating (`isServer`) means only the authoritative host evaluates it. **One cast → one spawn.**

---

## Residual recommendations (non-blocking, post-deploy)
1. Replace first-match prefab selection with a name allowlist (e.g. prefer a known single-target projectile + a known AoE puddle) once the live `[M3b] hitbox prefab:` log is reviewed from a 2-client match.
2. Add a 2-client live smoke confirming: (a) opponent HP drops, (b) projectile/AoE VFX visible on the non-casting client, (c) no `[M3]`/`[M3b]` warnings and no server exceptions in the dedicated log, (d) poison/petrify status replicates.
3. Keep `EnableMedusaBundleHitboxes=false` (M3c) for this deploy — it is a documented no-op stub.

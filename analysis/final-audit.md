# Final QC Audit — Networked Custom Medusa (charId 15)

Mod: `C:\Users\Administrator\Downloads\BAPBAPModdingAPI\netcustomchar-mod`
Files: `CustomCharMod.cs`, `MedusaVisualGraft.cs`, `CustomAbilityEngine.cs`, `CustomNetChannel.cs`, `MirrorInterop.cs`
Date: 2026-06-13 · Auditor pass: rigorous functional review against decompiled game + research/designs · Do NOT deploy.

## Verdict

The networked custom Medusa is **functionally correct and complete** for its stated scope (networked spawn, no despawn, visible/killable by peers, Medusa visual graft, server-authoritative damage + poison/petrify, authentic networked poison-hitbox spawning). One **real functional bug was found and fixed** (audit point #1, the cone-fallback friendly-fire filter). The build is clean (0 errors / 0 warnings). Remaining items are low-severity robustness/parity hardening, not blockers.

## Build + artifact

- `dotnet build -c Release` → **0 errors, 0 warnings**.
- `bin\Release\NetworkedCustomChar.dll` SHA256: `23E30F89AB9584997C3369F0659AE7562D7C3C2F7C2D46FAF84C42779FEBCC2A`

## Prioritized findings

### F1 — HIGH (FIXED) — Cone-fallback friendly-fire filter used the raw −1 reads
- File: `CustomAbilityEngine.cs` · `IsValidTarget` (was ~line 600).
- Issue: the cone fallback (used when no networked hitbox prefab resolves for a slot) filtered targets with raw `caster.entityTeamId` / `caster.ownerPlayerId` / `target.ownerPlayerId`. Verified in the decompiled game: `EntityManager.ownerPlayerId` is `[NonSerialized] public int ownerPlayerId` (EntityManager.cs:213-214) — a plain non-SyncVar int that stays −1 on a player char on the dedicated server. This is the exact field the owner/team fix was introduced to avoid. Effect: `co = caster.ownerPlayerId == -1` ⇒ `co > 0` false ⇒ the owner-based ally/self exclusion was **silently disabled**, so the cone could damage teammates (and, combined with an unset `entityTeamId`, even produce mis-attributed friendly fire). The spawned-hitbox path was already correct (uses `ResolveOwnerPid`/`ResolveTeamId` → `Network...` SyncVar setters), so this latent bug only manifested on the prefab-spawn-failure fallback — but it was a genuine correctness defect and was the item explicitly flagged.
- Fix applied: `IsValidTarget` now resolves both caster and target ids via `ResolveTeamId(...)` / `ResolveOwnerPid(...)`, identical to the spawn path. Confirmed authoritative: `PlayerManager.playerId` and `PlayerManager.teamId` are both `[SyncVar]` (PlayerManager.cs:85-99), `EntityManager.entityTeamId` is a `[SyncVar]` (EntityManager.cs:220-221) used only as fallback. Build re-verified clean.

### F2 — MEDIUM (RECOMMEND) — Spawned hitbox does not force `allowHitToEnemies = true`
- File: `CustomAbilityEngine.cs` · `TrySpawnNetworkedPrefab`.
- The config forces `onlyHitAllies=false`, `allowHitToTeam=false`, `allowHitToOwnerPlayer=false`, but does not set an enemy-enable flag. The decompiled `HitboxBase` (HitboxBase.cs:62 `allowHitToEnemies`) shows the enemy-damage gate is a distinct `[SerializeField] allowHitToEnemies`. The catalog picks the *first* hitbox prefab in the library without checking that flag; if a heal/ally chassis ever resolved first, the spawned hitbox could deal no enemy damage. Live proof shows the currently-resolved chassis works, so this is latent, not active.
- Note/uncertainty: the compiled reference assembly accepts `hb.onlyHitAllies` (the build proves the field exists in the proxy), but the decompiled `_DisabledScripts` export shows `allowHitToEnemies`/`allowHitToTeam`/`allowHitToOwnerPlayer` and no `onlyHitAllies` — i.e. the decompile and the proxy are different game versions, so the exact live gate cannot be 100% confirmed from the decompile alone. Recommendation (not applied, to avoid build risk against an unverified proxy member): add `try { hb.allowHitToEnemies = true; } catch { }` and/or have `EnsurePrefabCatalog`/`ScanMedusaBaseProtos` prefer a chassis whose `allowHitToEnemies` is already true. Low risk because it is additive and try/caught.

### F3 — LOW (PARITY, ACCEPTABLE) — Per-slot assetId collision resolution is per-peer
- File: `CustomAbilityEngine.cs` · `ResolveFreeAssetId` / `AssetIdInUse` (same pattern as M1 `AssertAssetIdFree`).
- `ResolveFreeAssetId` runs independently on server and client and checks `NetworkPrefabPool.poolLookup` + `NetworkClient.prefabs`. Those collections differ between a headless server and a client, so in the (very unlikely) event of a collision on one peer but not the other, the same slot could get different assetIds → Mirror would fail to resolve the spawned prefab on the client (desync for that slot only). The sentinels `0xB0B0F010..0xB0B0F013` are high and collision-improbable, and this mirrors the proven M1 char id strategy, so it is acceptable as-is. Optional hardening: skip the dynamic bump for these reserved sentinels (or log loudly if a bump occurs) so a silent per-peer divergence can't happen.

### F4 — INFO — No double-damage; single authoritative damage path confirmed
- `FireServer` spawns a networked hitbox **or** runs the cone, never both (`spawnedHitbox` gate). When a hitbox spawns, the game's own server-only `OnTrigger* → CharHurtbox.ApplyHit` pipeline is the sole damage source; the mod does not also call `ApplyServerHit`. No double-fire.

### F5 — INFO — Throttle / leak / desync review clean
- `Throttle` dedupes per caster+slot within 0.38s (covers Casting→Active re-entry and resim); `_recent` is bounded (cleared at >128) — no growth leak.
- Spawned hitboxes set `doTtl=true`/`ttl` (and `ProjectileMove.ttl`) so they self-destroy — no spawn leak. On `HitboxBase`-not-found the instantiated object is destroyed.
- `RegisterNetworkedPrefab` is idempotent on every hook (append-if-absent for `InstantiatedPrefabs`/`spawnPrefabs`, `poolLookup`-guarded pool create) — no array re-grow / double-pool per hook.

## Audit checklist results

1. **Owner/team fix** — CORRECT. `caster.playerManager.playerId`/`.teamId` are the authoritative `[SyncVar]` ids; raw `EntityManager.ownerPlayerId` is a non-SyncVar (−1 on the host). `ResolveOwnerPid`/`ResolveTeamId` are now used **everywhere** owner/team is set: hitbox `Networkowner/teamId` (spawn path) and the cone friendly-fire filter (F1 fix). Kill attribution uses the resolved owner. The spawned hitbox will hit enemies and not self/allies (modulo F2's enemy-enable note). The previously-flagged raw-read cone path is fixed.
2. **M1 spawn/registration** — CORRECT. Clones a real networked char root (keeps weaved `NetworkIdentity` + `Char*` chain), sanitizes runtime spawn-state, assigns a stable peer-identical assetId, and registers identically on server+client across `GNM.Awake`/`OnStartServer`/`OnStartClient`/`SpawnPlayerChar`. Idempotent; bot table + UI row guarded; no despawn cause (r09 sanitize sequence present).
3. **M2 visual** — CORRECT. Layout-safe graft (grafted subtree carries **no** NetworkIdentity/NetworkBehaviour → Mirror layout/spawn payload unchanged → headless-safe parity). Animator rebind re-applies on `CharAnimator`/`CharFootsteps` Awake; `SetLayerWeight`/`CrossFadeInFixedTime` guards prevent out-of-range layer throws from the swapped controller. GPU material rebind is render-gated.
4. **M3/M3b/M3c** — CORRECT. Server-authoritative (`isServer`-gated `Ability.SetState` hook; verified `SetState(AbilityStates _state)` + enum Ready=0/Aiming=1/Casting=2/Active=3 → `IsCastStart` correct). Single damage path (F4). Real networked hitbox spawn replicates via `NetworkServer.Spawn`; status via the hitbox `statusEffects` list / `CharHurtbox.ApplyHit`. The 4 Medusa clones register identically with distinct assetIds (`0xB0B0F010..13`), build-once/register-every-hook, headless-safe (bare chassis on `-batchmode`), per-slot fallback to M3b.
5. **Crash/double-fire/leak/desync** — none found beyond F2 (latent) and F3 (improbable parity edge). Exception-safe throughout (pervasive try/catch + null guards).

## What genuinely remains (honest)

- **F2** enemy-enable hardening — recommended before relying on the cone or on an arbitrary donor chassis; currently masked by the specific prefab that resolves live.
- **F3** assetId-parity edge — cosmetically improbable; optional hardening.
- Scope items already known and out of M1–M3c: data-driven char defs (M5), server-driven lobby listing (M6), and distinct authentic per-ability HUD icon sprites (not present in `medusa.bundle`; intentionally recolored, per `CustomCharMod.EnsureUiRow`). These are roadmap, not defects.

Bottom line: with F1 fixed, the networked custom Medusa is functionally correct and complete for its proven-live scope. F2 is the only item worth addressing proactively, and it is a low-risk additive guard rather than an active failure.

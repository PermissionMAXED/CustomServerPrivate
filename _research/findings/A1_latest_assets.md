# A1 — Latest-Build Medusa Asset Inventory (READ-ONLY research)

**Agent:** `A1_latest_assets`
**Date:** 2026-06-01
**Scope roots:** `C:\Users\Administrator\Downloads\CustomServer`, `C:\Users\Administrator\Downloads\BAPBAPModdingAPI`
**Method:** grep on the giant dumps (never read whole), targeted reads of the per-asset JSON dumps and `.prefab.meta` files. No source/build/deploy. This is the only file created.

---

## 0. TL;DR verdict on the ABILITY_MANIFEST.md claim

> Claim under test (`...\dumps\latest\medusa\ABILITY_MANIFEST.md`): *Medusa has NO bespoke AbilityBehaviourSO / Ability / SimulationFsm, but DOES ship real hitbox/VFX prefabs.*

**VERDICT: CONFIRMED (with two corrections).**

1. **No-ability-logic half — CONFIRMED, independently.** Case-sensitive `Medusa` = **0** in the latest `dump.cs`, **0** in `stringliteral.json`, **0** in the old Battleroyale `dump.cs`. Every `Petrif*`, `Serpent*`, `Venom*` hit is a *generic* status-effect / crypto / SpiderSwarm symbol, never a Medusa class. The 22 `AB_*_SO` instances in the depot contain **zero** `AB_Medusa*`. `Medusa.prefab`'s 31 components contain **no** Ability/AbilityBehaviourSO/BehaviourAbilityComponent/SimulationFsm.
2. **Real-prefabs half — CONFIRMED but UNDERCOUNTED.** The manifest documents **5** hitbox/spawner prefabs. It missed a second, equally important layer: **6 dedicated `VFX_Medusa_Poison_*` ParticleSystem prefabs** (the actual "real Medusa VFX that exist in the LatestBuild"). These are present **in-scope** at `BAPBAPModdingAPI\medusa-mod\backport\MedusaBundleProject\...\MedusaVfx\`, are tagged `assetBundleName: medusa`, and are full ParticleSystem effects — not green lines.
3. **GUID caveat — CORRECTION.** The GUIDs printed in the manifest are **AssetRipper-export-run-specific** and do **not** match the GUIDs in other exports of the same assets (see §5). The only stable identifiers for the latest build are the **sharedassets0 pathIds**, which I verified directly from the JSON dumps.

Confidence: **0.95** on the no-ability-logic verdict; **0.9** that the 6 VFX prefabs are the intended real Medusa effects.

---

## 1. Grep counts confirming / refuting "no ability logic"

| File (in scope) | Pattern | Count | What the hits actually are | Refutes Medusa code? |
|---|---|---|---|---|
| `...\dumps\latest\dump.cs` (41 MB) | `Medusa` (case-sensitive) | **0** | — | confirms none |
| `...\dumps\latest\dump.cs` | `Petrif` | 10 | All generic: `SE_Petrified_SO` (L245342), `SE_Petrified.Config` (L245365), `SE_Petrified` (L245374), `CharFX.EnablePetrifyFx/DisablePetrifyFx` (L247498/247501), `petrifyMaterialOverride` (L247433), `VfxManager.petrifyMaterial` (L284186) | confirms (generic SE only) |
| `...\dumps\latest\dump.cs` | `Serpent` | ~17 | BouncyCastle crypto (`SerpentEngine` L63350, `Serpent128Ecb…` L93271+) | unrelated |
| `...\dumps\latest\dump.cs` | `Venom` | 3 | `venomAbility` field (L207297) + `SpiderSwarmVenomBehaviour : SpiderSwarmBehaviour` (L207692/207697) — **Spider character, not Medusa** | unrelated |
| `...\dumps\latest\dump.cs` | `Gorgon` / `Slither` / `AB_Medusa` | **0 / 0 / 0** | — | confirms none |
| `...\dumps\latest\dump.cs` | `VFXSpawn` | 15 | generic `BAPBAP.Local.VFXSpawn` class + refs | generic |
| `...\dumps\latest\stringliteral.json` (2.5 MB) | `Medusa\|Petrif\|Gorgon\|Slither\|AB_Medusa` | **0** | only `SERPENT`/`Serpent` (crypto, L76107/L105495) | **no Medusa string literal in the binary** |
| `...\dumps\latest\script.json` (118 MB) | `Medusa\|Petrif\|Gorgon\|Slither\|AB_Medusa` | 22 | all generic `SE_Petrified_SO$$*`, `SE_Petrified$$Activate/Deactivate` (L253961-254004), `CharFX$$EnablePetrifyFx/DisablePetrifyFx` (L255773-255780), `SE_Petrified_TypeInfo` (L1862406) | confirms (generic only) |
| `...\dumps\il2cppdumper\dump.cs` (OLD Battleroyale) | `Medusa\|Gorgon\|Slither\|AB_Medusa` | **0** | — | confirms none even in old build |
| `...\dumps\il2cppdumper\dump.cs` (OLD) | `Medusa\|Petrif\|Gorgon\|Serpent\|Venom\|Slither\|AB_Medusa` | 27 | all Petrif/Serpent/Venom generic | confirms |

`AssetRip\ExportedProject` does **not** exist under the live `CustomServer\` tree (glob `**/AssetRip/**` = 0). It exists in `CustomServer-Backups\source-20260527-174239\AssetRip\ExportedProject\` and several `neueBapbap\...\ExportedProject` copies (out of the two strict scope roots, noted as evidence sources only).

### 1a. `_ability_behaviour_sos.json` — full AB_*_SO inventory (22 instances, sharedassets0)
`AB_AttackSpeed, AB_BapClone, AB_BloodDive, AB_BloodKnife, AB_BrainFreeze, AB_BubbleBumper, AB_CDReset, AB_Chains, AB_FirewaveEmpower, AB_HpBonus, AB_Jetpack, AB_MoveDash, AB_OxygenDash, AB_GravityPull, AB_PoisonInfuse, AB_RCDrone, AB_RCXD, AB_ShieldZone, AB_KnockArea (AB_SpawnHitbox_Base_SO), AB_SlowArea (AB_SpawnHitbox_Base_SO), AB_Swapper, AB_Ward`. → **No `AB_Medusa*`. CONFIRMED.** (Note: the natural reuse fit for Medusa's hitboxes is the existing `AB_SpawnHitbox_Base_SO`, which already has 2 instances.)

### 1b. `_medusa_related_sos.json` — name-matched SOs are all generic
27× `Tombstone_*` (no `Tombstone_Medusa`), the Poison-Pin passive line (`P_*Poison*`), and the three shared status SOs: `SE_Petrified` (pathId 105210), `SE_Poisoned` (105211), `SE_WallStun` (105232). None are Medusa-owned ability data.

---

## 2. Medusa asset inventory (latest build)

GUIDs below are from the **`CustomServer-Backups\...\AssetRip\ExportedProject`** export (matches the scope's `AssetRip\ExportedProject` reference) and the in-scope **`medusa-mod\backport\MedusaBundleProject`**. **pathId** is the stable latest-`sharedassets0.assets` identifier verified from the JSON dumps. ⚠ GUIDs are run-specific (see §5); pathIds are authoritative.

### 2a. Gameplay / hitbox / spawner prefabs (verified from dumps)
| Asset | Type | GUID (AssetRip run) | latest pathId | Component count | Evidence file |
|---|---|---|---|---|---|
| `Medusa.prefab` (character, charId-15 candidate) | Prefab/GameObject | `411cc384d5084ab4dbed379f0d78e328` | **36260** | 31 (all generic Char*/Entity*, **no Ability**) | `medusa\Medusa_GO36260_full.json` |
| `Hitbox_MedusaPoisonProjectile.prefab` | Prefab | `fb657bbec4d1eb14ab4479e5e6df6999` | **37610** | 7 | `medusa\Hitbox_MedusaPoisonProjectile_GO37610_full.json` |
| `Hitbox_MedusaPoisonPuddle.prefab` | Prefab | `ce7fe0b843a067e4c98bf2446d2edaed` | **20756** | 8 | `medusa\Hitbox_MedusaPoisonPuddle_GO20756_full.json` |
| `Hitbox_MedusaWallPoison.prefab` | Prefab | `ff0e21f4c79787f42b34370e1766e29a` | **11451** | 13 | `medusa\Hitbox_MedusaWallPoison_GO11451_full.json` |
| `Hitbox_MedusaWallBoxDpsPoison.prefab` | Prefab | `897c041df2bb1ac449ced3385966c52d` | **7335** | 5 | `medusa\Hitbox_MedusaWallBoxDpsPoison_GO7335_full.json` |
| `MedusaPuddleSpawner.prefab` | Prefab | `df19f9d98bb079f4ab127b1cf8f3b3e5` | **13225** | 3 | `medusa\MedusaPuddleSpawner_GO13225_full.json` |

### 2b. The 6 REAL Medusa VFX prefabs (ParticleSystem — NOT inventoried by the manifest)
In scope at `BAPBAPModdingAPI\medusa-mod\backport\MedusaBundleProject\Assets\GameObject\MedusaVfx\`. All tagged `assetBundleName: medusa`. ParticleSystem/Trail/Line component counts from grep.
| VFX prefab | GUID (bundle project) | Particle/Trail/Line components |
|---|---|---|
| `VFX_Medusa_Poison_Escape.prefab` | `2ee81c0faba995c4393dc10b285e69e4` | 24 |
| `VFX_Medusa_Poison_Hit.prefab` | (AssetRip) `9ee52ddbdc0cc344282616303b3cf85e` | 20 |
| `VFX_Medusa_Poison_Muzzle.prefab` | (AssetRip) `e275fce2273e4bc49b7b741cbd035970` | 14 |
| `VFX_Medusa_Poison_Puddle.prefab` | (AssetRip) `710201833fd32894488f3981c1c468a0` | 14 |
| `VFX_Medusa_Poison_Trail.prefab` | (AssetRip) `c2b8fc7049e5bc34b9dda988586b7a04` | 6 |
| `VFX_Medusa_Poison_Wall.prefab` | `abd9e3d5846cd3449a12c9af812eb4e2` | 14 |

### 2c. Supporting Medusa-named visual assets (in-scope backport project)
- Materials: `M_VFX_Medusa_Trails_01`, `M_VFX_Medusa_Walls_01` (+ `_Cover`, `_Ext`, `_Puddle`, `_02_Puddle`), `M_VFX_Slash_Medusa_01`, `Medusa_Material.mat`
- Meshes: `MedusaBase.asset`, `SM_VFX_Medusa_Walls_03` (+ `_Cover`, `_Ext`, `_04`, `_Puddle_01`)
- Shader: `_Lush_Uber_Particles_Advanced_Medusa_Walls.shader`
- Textures: `Medusa_Tex_Albedo_1024.png`, `Medusa_Tex_Normal_1024.png`
- Animation: `Medusa.controller`, `Medusa_Anims_v03Avatar.asset`, `Medusa_Attack_01..03.anim`, 16× Idle/Walk/Run clips
- Status effect SO: `SE_Petrified.asset` (latest pathId 105210; class GUID `d137970bc7f45227b604c50a236eb124` per manifest)
- Shipped mod artifacts (in scope, not analyzed here — see other agents): `BAPBAPModdingAPI\Battleroyalebuild\Mods\BAPBAP.Medusa.dll`, `...\Battleroyalebuild\UserData\Medusa\medusa.bundle`, `...\UserData\BAPBAPMedusaBR.ini`

---

## 3. The 5 hitbox/spawner prefabs — full component lists (verified from JSON dumps)

| # | Prefab (pathId) | Components (scriptName · namespace) |
|---|---|---|
| 1 | `Hitbox_MedusaPoisonProjectile` (37610) | Transform · NetworkIdentity(Mirror) · NetworkTransform(Mirror.Components) · Rigidbody · BoxCollider · **ProjectileMove**(BAPBAP.Entities) · **VFXSpawn**(BAPBAP.Local) |
| 2 | `Hitbox_MedusaPoisonPuddle` (20756) | Transform · NetworkIdentity · NetworkTransform · SphereCollider · **NetworkTransformFollow** · **TransformExpandRadius** · **VFXSpawn** · AudioSource |
| 3 | `Hitbox_MedusaWallPoison` (11451) | Transform · NetworkIdentity · NetworkTransform · **ColliderEnable** · **BehaviourTimedEnableSync**(BAPBAP.Local) · Rigidbody · BoxCollider×4 · **FogOfWarOcclusionMeshBuilder**(BAPBAP.Local) · **VFXSpawn** · AudioSource |
| 4 | `Hitbox_MedusaWallBoxDpsPoison` (7335) | Transform · NetworkIdentity · **HitboxDps**(BAPBAP.Entities) · BoxCollider · **ColliderEnableNet** |
| 5 | `MedusaPuddleSpawner` (13225) | Transform · NetworkIdentity · **VFXSpawn** |

**Critical:** none of the 5 contains `Ability`, `AbilityBehaviour`, `AbilityBehaviourSO`, `BehaviourAbilityComponent`, or `SimulationFsm`. Every script on them is a **generic** type confirmed present in both dumps. The damage source is plain `HitboxDps` (prefab 4); motion is plain `ProjectileMove` (prefab 1); everything else is collision + VFX + net sync. This **fully matches** the manifest's "visual + collision only, no driving logic" assertion.

`Medusa.prefab` (36260) 31 components: Transform, NetworkIdentity, CharacterController, CapsuleCollider, EntityManager, CharEvents, CharNetwork, CharSimulation, EntityMovement, CharAim, **CharAbilities** (rawSize 68, no serialized SO array), CharItems, CharStatusEffects, CharHurtbox, CharTriggerbox, CharHpRegen, CharHideArea, CharMaterial, CharFX, CharHidden, CharBushInteract, CharWorldPosition, AudioSource, CharFootsteps, CharAnimator, CharMinimap, CharFogOfWar, EntityEventAnimator (disabled), CharInterpolator, CharInteract, CharLabelNear. → identical to the manifest's list; **no ability child-components**.

---

## 4. Hypotheses (A1 asset-evidence contribution to the broader questions)

**Q2 — why green lines + Kitsu FX instead of real Medusa VFX (the VFX clearly exist):**
- The real effects exist as 6 `VFX_Medusa_Poison_*` ParticleSystem prefabs in the `medusa` bundle (§2b). Because Medusa has **no native ability code** (§1), the mod drives slots 0-3 by **cloning the Kitsu ability scaffold** (per ABILITY_MANIFEST §2 + medusa-mod README). A cloned Kitsu ability spawns **Kitsu's** hitbox/VFX references, never the Medusa VFX GUIDs — so Kitsu FX render. The "green lines" are most consistent with a **default/placeholder projectile or aim-line renderer** that appears when the cloned ability's VFX slot is unset/missing rather than pointed at the Medusa prefabs. **Fix direction implied by assets:** spawn the real `Hitbox_Medusa*` prefabs (whose `VFXSpawn` is meant to fire the `VFX_Medusa_Poison_*` set) instead of cloned-Kitsu hitboxes, and ensure the 6 VFX prefabs are actually included and GUID-resolvable in the loaded bundle. Confidence **0.7** (Q2 is another agent's deep scope; I only assert the asset layer).
- Note for the bundle builder: `Medusa.prefab` does **not** reference the hitbox/VFX prefabs in its dependency closure, so a dependency-only bundle bake will **omit** them unless they are added explicitly — a plausible reason the real VFX never reach the client even though they exist on disk. Confidence **0.6**.

**Q3 — Kitsu/Skinny/default fallback:** directly downstream of §1 — with no Medusa Ability classes/SOs, any "use Medusa's real ability" path has nothing to bind to and falls back to whichever scaffold the mod cloned (Kitsu) or the engine default. Confidence **0.75** (asset layer only).

---

## 5. Discrepancies / corrections vs the manifest

1. **GUIDs are not stable.** Manifest §3.1 lists `Hitbox_MedusaPoisonProjectile` GUID `e65875d407da40f448ded29cb9fbea45` and `Medusa.prefab` `00a97ec2da7ea2f489b0b0dc03855dff`; the `CustomServer-Backups` AssetRip export gives `fb657bbec4d1eb14ab4479e5e6df6999` and `411cc384d5084ab4dbed379f0d78e328` for the same assets. AssetRipper regenerates GUIDs per run; **trust pathIds, not GUIDs** for the latest build.
2. **`Petrif` count:** manifest says 6, raw line-grep of the current latest `dump.cs` gives **10** (qualitatively identical — all generic `SE_Petrified*`/`CharFX`/`petrifyMaterial`). The difference is grouping, not substance.
3. **Missing inventory:** the manifest's §3 stops at the 5 hitbox/spawner prefabs and only mentions `VFXSpawn` generically; it never enumerates the **6 real `VFX_Medusa_Poison_*` ParticleSystem prefabs** + Medusa materials/meshes/shader that are the actual visible effects. This is the single most important addition for the "real VFX exist but don't render" question.

---

## 6. Limitations
- Live `CustomServer\AssetRip\ExportedProject` does not exist; GUIDs were sourced from a CustomServer **backup** AssetRip and the in-scope `medusa-mod\backport` project. Strict two-root scope honored for all grep/code evidence; out-of-root export copies (`neueBapbap`, `MCP`, `was`) were only used to confirm the asset set exists and were not treated as authoritative.
- `VFXSpawn` serialized fields are stripped in the AssetRipper YAML, so I could not directly read which VFX GUID each latest-build hitbox spawns; the linkage in §4 is inferred from the bundle-project layout (`assetBundleName: medusa`) and naming, not from a resolved reference.
- I did not re-verify the manifest's "109 Ability subclasses" count line-by-line; the decisive check (`Medusa`=0, no `AB_Medusa*`) is independently confirmed.

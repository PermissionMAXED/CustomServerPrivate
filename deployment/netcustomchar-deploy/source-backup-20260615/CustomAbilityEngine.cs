using System;
using System.Collections.Generic;
using MelonLoader;
using UnityEngine;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppMirror;
using Il2CppBAPBAP.Entities;
using Il2CppBAPBAP.Local;
using Il2CppBAPBAP.Network;
using Il2CppBAPBAP.Pooling;

using UObject = UnityEngine.Object;
using AnimLayerIndices = Il2CppBAPBAP.Entities.AnimLayerIndices;

namespace NetworkedCustomChar
{
    /// <summary>
    /// M3 #3 — server-authoritative custom ability engine for charId 15.
    ///
    /// IMPORTANT API CORRECTION: the design's hook `CharAbilities.SvOnAbilityTriggered(CommandId)` does
    /// NOT exist in the real reference assembly. The verified server-authoritative trigger we use instead
    /// is the PROVEN per-ability state transition `Ability.SetState(AbilityStates)` (the exact hook the old
    /// working mod used), gated to `((NetworkBehaviour)entity).isServer` so the engine only runs on the
    /// dedicated host. Slot 0..3 is resolved from the ability's index in `CharAbilities.abilities`.
    ///
    /// On a cast-start for our custom char, the engine:
    ///   1) applies REAL networked damage + status through the [Server] funnel
    ///      `CharHurtbox.ApplyHit(dmg, StatusEffectInfo[], ownerPid, src, ..., dir, ...)` — every player
    ///      sees the victim take damage / turn poisoned / petrified via the game's own HP+status replication;
    ///   2) broadcasts a cosmetic VFX cue to all observers over <see cref="CustomNetChannel"/>.
    ///
    /// StatusEffectInfo / StatusEffectSO resolution + the ApplyHit argument list + the cone targeting are
    /// copied from the PROVEN, known-compiling old mod (MedusaMod.BuildMedusaStatusEffects / ApplyAuthoredMedusaHit
    /// / FindMedusaAbilityTargets). All authoritative.
    /// </summary>
    internal static class CustomAbilityEngine
    {
        internal static bool Enabled = true;
        internal static int CustomCharId = 15;

        // M6: the active config-driven character definition. Set in Init() from CustomCharConfig.LoadActive
        // (the same active def CustomCharMod loads). Per-slot ability values (damage/status/hitbox/anim)
        // are read from here instead of the old hardcoded literals; if the def is null or an array is too
        // short for a slot, Safe*() helpers fall back to the proven defaults so behavior never regresses.
        private static CustomCharDef? _def;

        internal static void SetActiveDef(CustomCharDef? def) { _def = def; }

        // ---- M6 config-driven per-slot accessors (fall back to proven defaults) --------------------
        private static readonly int[] _defaultDamage = { 120, 85, 70, 160 };
        private static readonly string[] _defaultStatus = { "poison", "slow", "knockup", "petrify" };
        private static readonly float[] _defaultStatusDur = { 3f, 4f, 1f, 2.5f };
        // Latest-Medusa slot->clip mapping: slot0 Serpent Bolt=Attack_01, slot1 Venom Spit=Attack_02,
        // slot2 Slither=NONE (it's a dash, no cast anim in latest), slot3 Petrifying Gaze=Attack_03.
        // Empty string => PlayCastAnim early-returns (no anim), matching latest's slot-2 skip.
        private static readonly string[] _defaultAnimState = { "Ability1", "Ability2", "", "Ability4" };

        private static int SlotDamage(int slot)
        {
            try { var a = _def?.AbilityDamage; if (a != null && slot >= 0 && slot < a.Length && a[slot] > 0) return a[slot]; } catch { }
            return (slot >= 0 && slot < 4) ? _defaultDamage[slot] : 0;
        }
        private static string SlotStatus(int slot)
        {
            try { var a = _def?.StatusOnHit; if (a != null && slot >= 0 && slot < a.Length && !string.IsNullOrWhiteSpace(a[slot])) return a[slot].Trim().ToLowerInvariant(); } catch { }
            return (slot >= 0 && slot < 4) ? _defaultStatus[slot] : "";
        }
        private static float SlotStatusDuration(int slot)
        {
            try { var a = _def?.StatusDuration; if (a != null && slot >= 0 && slot < a.Length && a[slot] > 0f) return a[slot]; } catch { }
            return (slot >= 0 && slot < 4) ? _defaultStatusDur[slot] : 3f;
        }
        private static string SlotAnimState(int slot)
        {
            try { var a = _def?.AbilityAnimState; if (a != null && slot >= 0 && slot < a.Length && !string.IsNullOrWhiteSpace(a[slot])) return a[slot].Trim(); } catch { }
            return (slot >= 0 && slot < 4) ? _defaultAnimState[slot] : "";
        }

        // M3b (PRIORITY, ENABLED): on a charId-15 server cast, spawn a REAL, already-registered,
        // already-replicated networked hitbox/projectile prefab pulled from
        // GameNetworkManager.Instance.networkPrefabLibrary and configure its HitboxBase
        // (ownerPlayerId/teamId/damage/statusEffects + ProjectileMove.speed) exactly like the engine's
        // own AB_SpawnHitbox_Base.DoUse, then NetworkServer.Spawn it. Every peer sees the projectile/AoE
        // and the game's server-only OnTrigger* -> CharHurtbox.ApplyHit -> OnNetSerialize pipeline does
        // the damage + poison/petrify replication. DOUBLE-DAMAGE MODEL: when a prefab resolves for a
        // slot, the SPAWNED HITBOX is the sole damage source and the ApplyServerHit cone is skipped; the
        // cone only runs as a fallback when no prefab resolves for that slot (see FireServer).
        internal static bool EnableNetworkPrefabSpawn = true;

        // M3c (ENABLED): build AUTHENTIC Medusa poison hitboxes as their own networked prefabs. For each
        // ability slot we clone a shipped networked hitbox chassis (projectile for slot 0, AoE/ground for
        // slots 1-3) to keep the real weaved NetworkIdentity + HitboxBase + ProjectileMove, GRAFT the
        // medusa.bundle authored poison visual subtree (Hitbox_MedusaPoison* / VFX_Medusa_Poison_*) as a
        // NetworkIdentity-less child (M2 graft pattern), disable the base chassis's own visual renderers,
        // assign a stable per-slot assetId, and register the clone IDENTICALLY on server+client (exactly
        // like CustomCharMod's M1 char registration). FireServer/TrySpawnNetworkedPrefab then spawns the
        // Medusa-skinned hitbox; the engine's own server-only OnTrigger* -> CharHurtbox.ApplyHit pipeline
        // does the damage + poison/petrify (config kept from M3b). Headless-safe: the poison VFX graft is
        // gated behind MedusaVisualGraft.CanSpawnClientFx() so a dedicated -nographics host registers the
        // BARE networked chassis (no bundle instantiate, renders nothing) while the NetworkIdentity/HitboxBase
        // layout + assetId stay identical on both peers for replication parity. PER-SLOT FALLBACK: if a
        // slot's clone fails to build/register, that slot cleanly falls back to the proven M3b shipped prefab
        // (logged), so abilities never no-op and the build never breaks.
        internal static bool EnableMedusaBundleHitboxes = true;

        // ---- M3b prefab catalog (resolved lazily once GameNetworkManager.networkPrefabLibrary exists) ----
        private static bool _catalogBuilt;
        private static readonly GameObject?[] _slotPrefab = new GameObject?[4];
        private static readonly bool[] _slotIsProjectile = new bool[4];

        // ---- M3c authentic-Medusa networked hitbox templates (built+registered on BOTH peers, idempotent) ----
        private static readonly GameObject?[] _medusaSlotPrefab = new GameObject?[4];   // null => fall back to M3b
        private static readonly bool[] _medusaSlotBuilt = new bool[4];                  // tried (built or failed)
        private static bool _medusaBaseScanned;
        private static GameObject? _medusaBaseProj;   // shipped projectile-type hitbox chassis to clone (slot 0)
        private static GameObject? _medusaBaseAoe;    // shipped AoE/ground hitbox chassis to clone (slots 1-3)

        // Per-slot authored Medusa poison visual to graft (primary = the authored hitbox subtree, fallback =
        // a standalone poison VFX prefab). Defaults are the proven names; the primary list is overridden per
        // slot from the active def's AbilityHitboxes (M6) via MedusaHitboxName(slot).
        private static readonly string[] _medusaVisualName =
            { "Hitbox_MedusaPoisonProjectile", "Hitbox_MedusaPoisonPuddle", "Hitbox_MedusaWallPoison", "Hitbox_MedusaWallBoxDpsPoison" };
        private static readonly string[] _medusaVisualFallback =
            { "VFX_Medusa_Poison_Trail", "VFX_Medusa_Poison_Puddle", "VFX_Medusa_Poison_Wall", "VFX_Medusa_Poison_Wall" };

        // Resolve the authored hitbox/visual prefab name for a slot: config def wins, else proven default.
        private static string MedusaHitboxName(int slot)
        {
            try { var a = _def?.AbilityHitboxes; if (a != null && slot >= 0 && slot < a.Length && !string.IsNullOrWhiteSpace(a[slot])) return a[slot].Trim(); } catch { }
            return (slot >= 0 && slot < 4) ? _medusaVisualName[slot] : "";
        }

        // Stable, peer-identical per-slot assetIds (high sentinels above the M1 char's 0xB0B00F0F;
        // collision-checked at registration, bumped if a shipped prefab baked the same id).
        private static readonly uint[] _medusaAssetId = { 0xB0B0F010u, 0xB0B0F011u, 0xB0B0F012u, 0xB0B0F013u };

        private static readonly Dictionary<long, float> _recent = new();

        // ---- status-effect SO cache (PROVEN: MedusaMod.FindSE / TryResolvePoison/Petrify) -------------
        private static StatusEffectSO? _poisonSO;
        private static StatusEffectSO? _petrifySO;
        private static bool _poisonTried, _petrifyTried;
        // M6b: additional status SOs for the ported kit (slow on Venom Spit, knock-up on Slither).
        // Verified present in the BR build: SE_Slowed.asset, SE_Airborne.asset.
        private static StatusEffectSO? _slowSO;
        private static StatusEffectSO? _airborneSO;

        // ---- DEV AUTO-CAST (deterministic cast proof; set by --bapcustom-auto-castall) ----------------
        // The CUA test harnesses are unreliable at DRIVING casts (keypresses don't land). When enabled,
        // once a Medusa entity is in-match on the server, the mod itself calls Ability.SetState(Casting)
        // on each of its 4 abilities, which trips the SAME SetState_Postfix -> FireServer -> [M3c] spawned
        // path a real cast uses. This produces deterministic per-cast evidence with no input dependency.
        internal static bool AutoCastEnabled = false;
        private static float _autoCastNextAt;
        private static int _autoCastSlot;
        private static int _autoCastCycles;

        // Call from a MelonMod OnUpdate (gated to the server in the caller). Casts one slot per ~1.2s,
        // cycling 0..3 a few times, then stops. Idempotent + self-limiting.
        internal static void TryAutoCastAll()
        {
            try
            {
                if (!AutoCastEnabled || _autoCastCycles >= 8) return;
                float now;
                try { now = Time.unscaledTime; } catch { return; }
                if (now < _autoCastNextAt) return;
                _autoCastNextAt = now + 1.2f;

                EntityManager? medusa = FindServerMedusa();
                if (IsNull(medusa)) return;                       // not spawned yet
                CharAbilities ca = medusa!.charAbilities;
                if (IsNull(ca)) return;
                Il2CppReferenceArray<Ability> arr = ca.abilities;
                if (arr == null) return;
                int len = ((Il2CppArrayBase<Ability>)(object)arr).Length;
                if (len <= 0) return;

                int slot = _autoCastSlot % Math.Min(4, len);
                Ability ab = ((Il2CppArrayBase<Ability>)(object)arr)[slot];
                if (!IsNull(ab))
                {
                    try { ab.SetState(AbilityStates.Casting); Msg($"[AUTOCAST] SetState(Casting) slot={slot} cycle={_autoCastCycles}."); }
                    catch (Exception cex) { Warn($"[AUTOCAST] slot={slot}: {cex.Message}"); }
                }
                _autoCastSlot++;
                if (_autoCastSlot % 4 == 0) _autoCastCycles++;
            }
            catch (Exception ex) { Warn($"TryAutoCastAll: {ex.Message}"); }
        }

        // Find a server-side Medusa EntityManager (charId == CustomCharId, isServer).
        private static EntityManager? FindServerMedusa()
        {
            try
            {
                Il2CppArrayBase<EntityManager> all = UObject.FindObjectsOfType<EntityManager>();
                if (all == null) return null;
                for (int i = 0; i < all.Length; i++)
                {
                    EntityManager e = all[i];
                    if (IsNull(e)) continue;
                    if (SafeInt(() => e.charId) != CustomCharId) continue;
                    if (!IsServer(e)) continue;
                    return e;
                }
            }
            catch { }
            return null;
        }

        public static void Init()
        {
            try { if (_def == null) _def = CustomCharConfig.LoadActive(); } catch { }
            string hbx = "?", dmg = "?", st = "?", anim = "?";
            try { hbx = string.Join(",", new[] { MedusaHitboxName(0), MedusaHitboxName(1), MedusaHitboxName(2), MedusaHitboxName(3) }); } catch { }
            try { dmg = string.Join(",", new[] { SlotDamage(0), SlotDamage(1), SlotDamage(2), SlotDamage(3) }); } catch { }
            try { st = string.Join(",", new[] { SlotStatus(0), SlotStatus(1), SlotStatus(2), SlotStatus(3) }); } catch { }
            try { anim = string.Join(",", new[] { SlotAnimState(0), SlotAnimState(1), SlotAnimState(2), SlotAnimState(3) }); } catch { }
            MelonLogger.Msg($"[M3] CustomAbilityEngine ready (charId={CustomCharId}, enabled={Enabled}, " +
                            $"networkPrefabSpawn={EnableNetworkPrefabSpawn}, medusaBundleHitboxes={EnableMedusaBundleHitboxes}).");
            MelonLogger.Msg($"[M6] ability kit: hitboxes=[{hbx}] dmg=[{dmg}] status=[{st}] anim=[{anim}].");
        }

        private static bool IsNull(UObject? o) => (UObject)o! == (UObject?)null;

        // ============================================================================================
        // SERVER-AUTHORITATIVE HOOK — Ability.SetState (verified). Prefix captures old state; postfix runs
        // the engine on a cast-start transition. Routed through CustomCharMod's manual TryPatch plumbing.
        // ============================================================================================
        public static void SetState_Prefix(Ability __instance, out int __state)
        {
            try { __state = IsNull(__instance) ? -1 : (int)__instance.state; }
            catch { __state = -1; }
        }

        public static void SetState_Postfix(Ability __instance, AbilityStates _state, int __state)
        {
            try
            {
                if (!Enabled || IsNull(__instance)) return;
                int newState = (int)_state;
                if (!IsCastStart(__state, newState)) return;      // Ready/Aiming -> Casting/Active

                EntityManager caster = __instance.entityManager;
                if (IsNull(caster)) return;
                if (SafeInt(() => caster.charId) != CustomCharId) return;     // our custom char only
                if (!IsServer(caster)) return;                                // dedicated host only

                int slot = ResolveSlot(__instance, caster);
                if (slot < 0 || slot > 3) return;
                if (!Throttle(caster, slot)) return;                          // dedupe re-fires/resim

                FireServer(caster, slot);
            }
            catch (Exception ex) { Warn($"SetState_Postfix: {ex.Message}"); }
        }

        // ============================================================================================
        // REAL MEDUSA ABILITY MODEL (backported from the recovered latest source's
        // ApplyAuthoredMedusaGameplay / ApplyMedusaSlitherMovement): each of the 4 slots has a DISTINCT
        // mechanic, NOT a uniform "spawn a damaging hitbox" attack. The damage/status is applied by
        // server-side per-slot GEOMETRY hit detection (FindTargets: slot0 single-target line, slot1 cone,
        // slot2 radial-around-caster, slot3 piercing line). The networked hitbox is spawned COSMETIC-ONLY
        // (damage 0, no status) so the authentic Medusa poison VFX still replicate to every client without
        // double-applying damage. Slither (slot 2) additionally moves the caster (self-dash).
        private static void FireServer(EntityManager caster, int slot)
        {
            Vector3 origin = SafePos(caster);
            Vector3 dir = SafeForward(caster);
            int ownerPid = ResolveOwnerPid(caster);

            // 1) DISTINCT MECHANIC — Slither (slot 2) is a mobility dash: move the caster forward
            //    authoritatively (replicates via the char's own movement net path). This is the one
            //    ability that is "her own thing" beyond point-and-damage.
            bool dashed = false;
            if (slot == 2)
                dashed = ApplyMedusaSlitherMovement(caster, dir);

            // 2) REAL damage source — per-slot geometry hit detection (the authentic Medusa model).
            //    This is now the PRIMARY (sole) damage path for every slot, giving each ability its
            //    distinct shape/range instead of the old uniform hitbox spawn.
            int hits = 0;
            foreach (EntityManager target in FindTargets(caster, slot, origin, dir))
            {
                if (IsNull(target)) continue;
                if (ApplyServerHit(caster, target, slot, ownerPid, origin, dir)) hits++;
            }

            // 3) COSMETIC-ONLY networked Medusa hitbox: spawns the authentic poison projectile/puddle/wall
            //    visual (grafted from medusa.bundle) so all clients see it, but carries NO damage/status
            //    (geometry above already applied it) -> NO double damage.
            bool spawnedVisual = false;
            if (EnableNetworkPrefabSpawn)
                spawnedVisual = TrySpawnNetworkedPrefab(caster, slot, origin, dir, cosmeticOnly: true);

            // 4) cosmetic VFX cue + cast anim to all observers (render-gated on receivers).
            CustomNetChannel.Broadcast(caster, CustomNetChannel.StateAbilityCast, slot, dir);

            Msg($"server ability fired: slot={slot} mechanic={SlotMechanic(slot)} geomHits={hits} dashed={dashed} visual={spawnedVisual} owner={ownerPid}.");
        }

        private static string SlotMechanic(int slot) => slot switch
        {
            0 => "SerpentBolt(single-line)",
            1 => "VenomSpit(cone)",
            2 => "Slither(dash+radial)",
            3 => "PetrifyingGaze(pierce-line)",
            _ => "?",
        };

        // Slither self-dash (PROVEN: recovered MedusaMod.ApplyMedusaSlitherMovement). Moves the
        // authoritative caster forward dir*4.25 via CharMove.PostMove(..., PostMoveTypes.Set?, false).
        // Server-only; the char's own movement replication carries it to all clients.
        private static bool ApplyMedusaSlitherMovement(EntityManager caster, Vector3 dir)
        {
            try
            {
                if (IsNull(caster)) return false;
                var cm = caster.charMove;
                if (IsNull(cm)) return false;
                Vector3 f = dir; f.y = 0f;
                if (f.sqrMagnitude < 0.01f) f = SafeForward(caster);
                f.Normalize();
                Vector3 delta = f * 4.25f;
                cm.PostMove(delta, (PostMoveTypes)1, false);
                Msg($"[SLITHER] dashed caster by ({delta.x:F1},{delta.y:F1},{delta.z:F1}).");
                return true;
            }
            catch (Exception ex) { Warn($"ApplyMedusaSlitherMovement: {ex.Message}"); return false; }
        }

        // ---- damage + status (PROVEN: ApplyAuthoredMedusaHit) --------------------------------------
        private static bool ApplyServerHit(EntityManager caster, EntityManager target, int slot, int ownerPid, Vector3 origin, Vector3 dir)
        {
            try
            {
                CharHurtbox hb = target.charHurtbox;
                if (IsNull(hb)) return false;

                StatusEffectInfo[] effects = BuildStatusEffects(slot);
                Vector3 d = SafePos(target) - origin; d.y = 0f;
                if (d.sqrMagnitude < 0.01f) d = dir;
                d.Normalize();

                GameObject? srcGo = null;
                try { srcGo = ((Component)caster).gameObject; } catch { }

                int dmg = SlotDamage(slot);
                hb.ApplyHit(dmg, effects, ownerPid, srcGo, false, false, true, true, false, d, true, false, (Collider)null);
                return true;
            }
            catch (Exception ex) { Warn($"ApplyServerHit slot={slot}: {ex.Message}"); return false; }
        }

        private static StatusEffectInfo[] BuildStatusEffects(int slot)
        {
            var list = new List<StatusEffectInfo>();
            try
            {
                string status = SlotStatus(slot);
                float dur = SlotStatusDuration(slot);
                if (status == "poison" && TryResolvePoison() && !IsNull(_poisonSO))
                    list.Add(new StatusEffectInfo(_poisonSO, dur, 1f));
                else if (status == "petrify" && TryResolvePetrify() && !IsNull(_petrifySO))
                    list.Add(new StatusEffectInfo(_petrifySO, dur, 1f));
                else if (status == "slow" && TryResolveSE(ref _slowSO, "SE_Slowed_SO", "SE_Slowed") && !IsNull(_slowSO))
                    list.Add(new StatusEffectInfo(_slowSO, dur, 1f));
                else if ((status == "knockup" || status == "airborne") && TryResolveSE(ref _airborneSO, "SE_Airborne_SO", "SE_Airborne") && !IsNull(_airborneSO))
                    list.Add(new StatusEffectInfo(_airborneSO, dur, 1f));
            }
            catch { }
            return list.Count != 0 ? list.ToArray() : Array.Empty<StatusEffectInfo>();
        }

        // ---- status SO lookup (PROVEN: MedusaMod.FindSE) -------------------------------------------
        private static bool TryResolvePoison()
        {
            if (!IsNull(_poisonSO)) return true;
            if (_poisonTried && IsNull(_poisonSO)) { /* retry; SO managers may not exist yet */ }
            _poisonTried = true;
            _poisonSO = FindSE("SE_Poisoned_SO", "SE_Poisoned");
            return !IsNull(_poisonSO);
        }

        private static bool TryResolvePetrify()
        {
            if (!IsNull(_petrifySO)) return true;
            _petrifyTried = true;
            _petrifySO = FindSE("SE_Petrified_SO", "SE_Petrified");
            return !IsNull(_petrifySO);
        }

        // M6b: generic resolver for config-driven status names (slow/knockup). Caches into the passed-by-ref
        // field; retries each cast until the StatusEffectManager is populated (same pattern as poison/petrify).
        private static bool TryResolveSE(ref StatusEffectSO? cache, string className, string assetName)
        {
            if (!IsNull(cache)) return true;
            cache = FindSE(className, assetName);
            return !IsNull(cache);
        }

        private static StatusEffectSO? FindSE(string className, string assetName)
        {
            try
            {
                Il2CppArrayBase<StatusEffectManager> mgrs = Resources.FindObjectsOfTypeAll<StatusEffectManager>();
                if (mgrs == null) return null;
                foreach (StatusEffectManager mgr in mgrs)
                {
                    if (IsNull(mgr)) continue;
                    Il2CppReferenceArray<StatusEffectSO> arr = mgr.statusEffects;
                    if (arr == null) continue;
                    for (int i = 0; i < ((Il2CppArrayBase<StatusEffectSO>)(object)arr).Length; i++)
                    {
                        StatusEffectSO so = ((Il2CppArrayBase<StatusEffectSO>)(object)arr)[i];
                        if (IsNull(so)) continue;
                        string tn = "", an = "";
                        try { var t = so.GetIl2CppType(); tn = t != null ? t.Name : ""; } catch { }
                        try { an = so.name ?? ""; } catch { }
                        if (tn == className || an.Equals(assetName, StringComparison.OrdinalIgnoreCase))
                            return so;
                    }
                }
            }
            catch (Exception ex) { Warn($"FindSE({assetName}): {ex.Message}"); }
            return null;
        }

        // ---- M3b: spawn an EXISTING, already-networked hitbox/projectile prefab -----------------------
        //
        // Model (verified against r06 + decompiled HitboxBase/Hitbox/ProjectileMove + AB_SpawnHitbox_Base.DoUse):
        //   * choose a real prefab from GameNetworkManager.Instance.networkPrefabLibrary (already registered
        //     + replicated by the game), Instantiate at the firing origin facing the aim dir;
        //   * configure HitboxBase exactly like the engine does:
        //       NetworkownerPlayerId / NetworkteamId  (SyncVars, so every client filters friendly-fire right),
        //       otherChar = caster.gameObject, damage (int), statusEffects (List<StatusEffectInfo> via
        //       BuildStatusEffects), directional, doTtl/ttl, destroyOnCharHit/destroyOnStaticCollision;
        //   * if it carries a ProjectileMove, set Networkspeed (SyncVar) + ttl so it travels along forward;
        //   * NetworkServer.Spawn(obj, ownerConn). ownerConn is NULL (no owner) to match the engine's own
        //     ability-hitbox spawns (AB_SpawnHitbox_Base.DoUse), keeping the hitbox fully server-authoritative
        //     (server-only OnTrigger* detection drives damage; transform stays server-owned). See report.
        // Returns true iff a real damaging networked hitbox was spawned (so the cone fallback is skipped).
        private static bool TrySpawnNetworkedPrefab(EntityManager caster, int slot, Vector3 origin, Vector3 dir, bool cosmeticOnly = false)
        {
            try
            {
                if (slot < 0 || slot > 3) return false;
                if (!IsServer(caster)) return false;          // server-authoritative + headless-safe

                EnsurePrefabCatalog();

                // M3c PREFERENCE: spawn the authentic Medusa-skinned networked hitbox if its clone was
                // built+registered for this slot; otherwise fall back to the proven M3b shipped prefab.
                bool useMedusa = EnableMedusaBundleHitboxes && !IsNull(_medusaSlotPrefab[slot]);
                GameObject? prefab = useMedusa ? _medusaSlotPrefab[slot] : _slotPrefab[slot];
                if (IsNull(prefab)) return false;             // no real prefab -> caller runs cone fallback

                bool isProj = useMedusa ? (slot == 0) : _slotIsProjectile[slot];

                Vector3 fwd = dir; fwd.y = 0f;
                if (fwd.sqrMagnitude < 0.01f) fwd = Vector3.forward;
                fwd.Normalize();
                Quaternion rot = Quaternion.LookRotation(fwd, Vector3.up);
                Vector3 pos = origin + Vector3.up * 0.9f + fwd * 0.6f;

                GameObject obj = UObject.Instantiate(prefab!, pos, rot);
                if (IsNull(obj)) return false;

                HitboxBase hb = obj.GetComponent<HitboxBase>();
                if (IsNull(hb)) hb = obj.GetComponentInChildren<HitboxBase>(true);
                if (IsNull(hb)) { try { UObject.Destroy(obj); } catch { } return false; }

                int ownerPid = ResolveOwnerPid(caster);
                int teamId   = ResolveTeamId(caster);

                // SyncVar setters (verified: NetworkownerPlayerId/NetworkteamId on HitboxBase).
                try { hb.NetworkownerPlayerId = ownerPid; } catch { }
                try { hb.NetworkteamId = teamId; } catch { }
                try { hb.otherChar = ((Component)caster).gameObject; } catch { }

                // Normalize friendly-fire flags. The catalog picks the FIRST shipped hitbox prefab in the
                // library, which may be an ally/heal hitbox (onlyHitAllies) or self-affecting one. Force the
                // standard "damage enemies only" rule (CanHitEntity: !onlyHitAllies hits non-team/non-owner)
                // so a charId-15 cast reliably damages opponents regardless of which prefab resolved.
                try { hb.onlyHitAllies = false; } catch { }
                try { hb.allowHitToTeam = false; } catch { }
                try { hb.allowHitToOwnerPlayer = false; } catch { }

                bool spawnIsProj = isProj;
                // COSMETIC-ONLY MODE (real-Medusa model): geometry hit detection in FireServer already
                // applied the damage+status, so this networked hitbox is purely the authentic poison VISUAL.
                // Zero its damage, clear its status list, and disable its hit detection so it can NEVER
                // double-apply. The grafted poison VFX still renders + replicates to all clients.
                try { hb.damage = cosmeticOnly ? 0 : SlotDamage(slot); } catch { }
                try { hb.directional = spawnIsProj; } catch { }
                try { hb.doTtl = true; } catch { }
                try { hb.ttl = spawnIsProj ? 3f : 2.5f; } catch { }
                try { hb.destroyOnCharHit = !cosmeticOnly && spawnIsProj; } catch { }
                try { hb.destroyOnStaticCollision = !cosmeticOnly && spawnIsProj; } catch { }

                if (cosmeticOnly)
                {
                    // Make the visual hitbox inert: no triggers, no status, never hits anything.
                    try { hb.onlyHitAllies = true; hb.allowHitToTeam = false; hb.allowHitToOwnerPlayer = false; } catch { }
                    try
                    {
                        var cols = obj.GetComponentsInChildren<Collider>(true);
                        if (cols != null) for (int i = 0; i < cols.Length; i++) { try { if (!IsNull(cols[i])) cols[i].enabled = false; } catch { } }
                    }
                    catch { }
                    try { var sl = hb.statusEffects; if (sl != null) sl.Clear(); } catch { }
                }
                else
                {
                    // status effects ride the same server damage pipeline (poison/petrify replicate via the list).
                    ApplyStatusEffectsToHitbox(hb, slot);
                }

                // projectile travel (verified ProjectileMove.speed SyncVar via Networkspeed).
                try
                {
                    ProjectileMove pm = obj.GetComponent<ProjectileMove>();
                    if (IsNull(pm)) pm = obj.GetComponentInChildren<ProjectileMove>(true);
                    if (!IsNull(pm))
                    {
                        float spd = SafeFloat(() => pm.speed);
                        try { pm.Networkspeed = (spd > 0.01f) ? spd : 18f; } catch { }
                        try { pm.ttl = spawnIsProj ? 3f : 2.5f; } catch { }
                    }
                }
                catch { }

                // Spawn with NO owner connection (matches AB_SpawnHitbox_Base.DoUse). The 2-arg overload
                // Spawn(GameObject, NetworkConnection) is the verified one; a typed null selects it cleanly.
                NetworkConnection ownerConn = null!;
                NetworkServer.Spawn(obj, ownerConn);

                Msg($"[{(useMedusa ? "M3c" : "M3b")}] spawned {(useMedusa ? "authentic Medusa" : "shipped")} networked prefab " +
                    $"'{SafeName(prefab)}' slot={slot} proj={spawnIsProj} owner={ownerPid} team={teamId} dmg={SafeInt(() => hb.damage)}.");
                return true;
            }
            catch (Exception ex) { Warn($"[M3b] TrySpawnNetworkedPrefab slot={slot}: {ex.Message}"); return false; }
        }

        // Resolve a per-slot real prefab once GameNetworkManager.networkPrefabLibrary is populated. Logs
        // every prefab whose root carries a HitboxBase (and whether it has a ProjectileMove) so the choice
        // is auditable. Slot 0 (LMB) prefers a projectile-type hitbox; slots 1..3 prefer an AoE/ground hitbox.
        private static void EnsurePrefabCatalog()
        {
            if (_catalogBuilt) return;
            try
            {
                GameNetworkManager gnm = GameNetworkManager.Instance;
                if (IsNull(gnm)) return;
                NetworkPrefabLibrary lib = gnm.networkPrefabLibrary;
                if (IsNull(lib)) return;

                var projectiles = new List<GameObject>();
                var aoes = new List<GameObject>();
                int scanned = 0, withHitbox = 0;

                void Consider(GameObject? go)
                {
                    if (IsNull(go)) return;
                    scanned++;
                    HitboxBase hb;
                    try { hb = go!.GetComponentInChildren<HitboxBase>(true); } catch { return; }
                    if (IsNull(hb)) return;                          // not a hitbox prefab -> skip (incl. our char)
                    withHitbox++;
                    bool isProj;
                    try { isProj = !IsNull(go!.GetComponentInChildren<ProjectileMove>(true)); } catch { isProj = false; }
                    Msg($"[M3b] hitbox prefab: '{SafeName(go)}' projectile={isProj}.");
                    if (isProj) projectiles.Add(go!); else aoes.Add(go!);
                }

                Il2CppReferenceArray<GameObject> inst = lib.InstantiatedPrefabs;
                if (inst != null) for (int i = 0; i < inst.Length; i++) Consider(inst[i]);

                Il2CppReferenceArray<NetworkPrefabPool.Config> pooled = lib.PooledPrefabs;
                if (pooled != null)
                    for (int i = 0; i < pooled.Length; i++)
                    {
                        NetworkPrefabPool.Config c = pooled[i];
                        if (c == null) continue;
                        GameObject? p = null;
                        try { p = c.prefab; } catch { }
                        Consider(p);
                    }

                GameObject? proj = projectiles.Count > 0 ? projectiles[0] : null;
                GameObject? aoe  = aoes.Count > 0 ? aoes[0] : null;

                _slotPrefab[0] = proj ?? aoe;  _slotIsProjectile[0] = !IsNull(proj);
                for (int s = 1; s <= 3; s++)
                {
                    _slotPrefab[s] = aoe ?? proj;
                    _slotIsProjectile[s] = IsNull(aoe) && !IsNull(proj);
                }

                _catalogBuilt = !IsNull(proj) || !IsNull(aoe);
                Msg($"[M3b] prefab catalog built={_catalogBuilt}: scanned={scanned} withHitbox={withHitbox} " +
                    $"projectiles={projectiles.Count} aoes={aoes.Count} " +
                    $"slot0='{SafeName(_slotPrefab[0])}'(proj={_slotIsProjectile[0]}) " +
                    $"slot1..3='{SafeName(_slotPrefab[1])}'(proj={_slotIsProjectile[1]}).");

                // M3c best-effort (disabled): authentic Medusa bundle poison hitboxes.
                if (EnableMedusaBundleHitboxes) TryRegisterMedusaBundleHitboxes(gnm, lib);
            }
            catch (Exception ex) { Warn($"[M3b] EnsurePrefabCatalog: {ex.Message}"); }
        }

        // Copy the built StatusEffectInfo[] onto the hitbox's server-side statusEffects list so the engine's
        // CharHurtbox.ApplyHit applies + replicates them (verified: HitboxBase.statusEffects List getter).
        private static void ApplyStatusEffectsToHitbox(HitboxBase hb, int slot)
        {
            try
            {
                StatusEffectInfo[] effects = BuildStatusEffects(slot);
                if (effects == null || effects.Length == 0) return;
                Il2CppSystem.Collections.Generic.List<StatusEffectInfo> list = hb.statusEffects;
                if (list == null) return;
                try { list.Clear(); } catch { }
                for (int i = 0; i < effects.Length; i++)
                    if (!IsNull(effects[i].statusEffect)) list.Add(effects[i]);
            }
            catch (Exception ex) { Warn($"[M3b] status->hitbox slot={slot}: {ex.Message}"); }
        }

        // ---- M3c: authentic Medusa bundle poison hitboxes (IMPLEMENTED) ------------------------------
        //
        // Mirrors the PROVEN M1 char-clone + identical-registration pattern, applied to per-slot hitbox
        // chassis. Idempotent; called on BOTH peers from CustomCharMod.EnsureRegistered (GNM.Awake /
        // OnStartServer / OnStartClient) so server and client register the same assetIds, and also as a
        // server-side backstop from EnsurePrefabCatalog. Per-slot failures fall back to M3b (logged).
        private static void TryRegisterMedusaBundleHitboxes(GameNetworkManager gnm, NetworkPrefabLibrary lib)
        {
            EnsureMedusaHitboxesRegistered(gnm);
        }

        // BOTH-PEER entry point. Builds+registers any not-yet-built per-slot Medusa hitbox clones.
        internal static void EnsureMedusaHitboxesRegistered(GameNetworkManager gnm)
        {
            if (!EnableMedusaBundleHitboxes) return;
            try
            {
                if (IsNull(gnm)) return;
                NetworkPrefabLibrary lib = gnm.networkPrefabLibrary;
                if (IsNull(lib)) return;

                ScanMedusaBaseProtos(lib);

                for (int slot = 0; slot < 4; slot++)
                {
                    // ---- BUILD (once per slot) ----
                    if (!_medusaSlotBuilt[slot])
                    {
                        bool isProj = (slot == 0);
                        GameObject? baseProto = isProj ? (_medusaBaseProj ?? _medusaBaseAoe)
                                                       : (_medusaBaseAoe ?? _medusaBaseProj);
                        if (IsNull(baseProto)) continue;   // library not populated yet -> retry on next hook

                        GameObject? clone = BuildMedusaNetworkedHitbox(gnm, lib, slot, baseProto!, isProj);
                        if (!IsNull(clone))
                        {
                            _medusaSlotPrefab[slot] = clone;
                            _medusaSlotBuilt[slot] = true;
                            Msg($"[M3c] slot {slot} AUTHENTIC Medusa hitbox built: assetId=0x{_medusaAssetId[slot]:X8} " +
                                $"base='{SafeName(baseProto)}' proj={isProj} visual='{MedusaHitboxName(slot)}'.");
                        }
                        else
                        {
                            _medusaSlotBuilt[slot] = true;     // give up on this slot -> M3b shipped prefab used
                            Warn($"[M3c] slot {slot} build/registration failed; FALLING BACK to M3b shipped prefab.");
                            continue;
                        }
                    }

                    // ---- REGISTER (idempotent, EVERY hook) ----
                    // CRITICAL PARITY FIX: re-assert Mirror registration on every hook for each successfully
                    // built slot, exactly like the proven M1 EnsureMirrorRegistration. A clone may be BUILT at
                    // GNM.Awake while NetworkClient/NetworkServer are still inactive; in that case the explicit
                    // client RegisterPrefab + pool create must still run once the peer goes active (OnStartClient/
                    // OnStartServer postfix). Re-running RegisterNetworkedPrefab here guarantees the same assetId
                    // is resolvable on the client BEFORE the first NetworkServer.Spawn, instead of relying solely
                    // on the native OnStartClient InstantiatedPrefabs loop and on build-timing. Idempotent:
                    // InstantiatedPrefabs/spawnPrefabs are append-if-absent and NetworkPrefabPool.Create is
                    // poolLookup-guarded, so no array re-grow / no double pool per hook.
                    if (!IsNull(_medusaSlotPrefab[slot]))
                        RegisterNetworkedPrefab(gnm, lib, _medusaSlotPrefab[slot]!, _medusaAssetId[slot]);
                }
            }
            catch (Exception ex) { Warn($"[M3c] EnsureMedusaHitboxesRegistered: {ex.Message}"); }
        }

        // Find ONE shipped projectile-type hitbox chassis + ONE AoE/ground hitbox chassis to clone from.
        // Skips our own already-registered Medusa clones (named "Hitbox_Medusa_NetSlot*").
        private static void ScanMedusaBaseProtos(NetworkPrefabLibrary lib)
        {
            if (_medusaBaseScanned && !IsNull(_medusaBaseProj) && !IsNull(_medusaBaseAoe)) return;
            try
            {
                GameObject? proj = _medusaBaseProj, aoe = _medusaBaseAoe;

                void Consider(GameObject? go)
                {
                    if (IsNull(go)) return;
                    if (!IsNull(proj) && !IsNull(aoe)) return;
                    string nm = SafeName(go);
                    if (nm.StartsWith("Hitbox_Medusa_NetSlot", StringComparison.OrdinalIgnoreCase)) return; // our clone
                    HitboxBase hb;
                    try { hb = go!.GetComponentInChildren<HitboxBase>(true); } catch { return; }
                    if (IsNull(hb)) return;
                    bool isProj;
                    try { isProj = !IsNull(go!.GetComponentInChildren<ProjectileMove>(true)); } catch { isProj = false; }
                    if (isProj) { if (IsNull(proj)) proj = go; }
                    else        { if (IsNull(aoe))  aoe  = go; }
                }

                Il2CppReferenceArray<GameObject> inst = lib.InstantiatedPrefabs;
                if (inst != null) for (int i = 0; i < inst.Length; i++) Consider(inst[i]);

                Il2CppReferenceArray<NetworkPrefabPool.Config> pooled = lib.PooledPrefabs;
                if (pooled != null)
                    for (int i = 0; i < pooled.Length; i++)
                    {
                        NetworkPrefabPool.Config c = pooled[i];
                        if (c == null) continue;
                        GameObject? p = null; try { p = c.prefab; } catch { }
                        Consider(p);
                    }

                if (!IsNull(proj)) _medusaBaseProj = proj;
                if (!IsNull(aoe))  _medusaBaseAoe  = aoe;
                _medusaBaseScanned = !IsNull(_medusaBaseProj) || !IsNull(_medusaBaseAoe);
            }
            catch (Exception ex) { Warn($"[M3c] ScanMedusaBaseProtos: {ex.Message}"); }
        }

        // Clone a shipped networked hitbox chassis INERT (real NetworkIdentity + HitboxBase + ProjectileMove),
        // graft the Medusa poison visual (render-capable peers only), sanitize + assign a stable assetId, and
        // register identically server+client (M1 pattern). Returns the registered template clone or null.
        private static GameObject? BuildMedusaNetworkedHitbox(GameNetworkManager gnm, NetworkPrefabLibrary lib,
                                                              int slot, GameObject baseProto, bool isProj)
        {
            try
            {
                bool wasActive = false;
                try { wasActive = baseProto.activeSelf; if (wasActive) baseProto.SetActive(false); } catch { }
                GameObject clone;
                try { clone = UObject.Instantiate(baseProto); }
                finally { try { if (wasActive) baseProto.SetActive(true); } catch { } }

                clone.name = $"Hitbox_Medusa_NetSlot{slot}";
                clone.SetActive(false);
                UObject.DontDestroyOnLoad(clone);

                // Bake the authored Medusa poison visual into the registered template — render-capable peers
                // only. The grafted child carries NO NetworkIdentity/NetworkBehaviour, so the chassis Mirror
                // layout (and thus the spawn-payload layout) is identical to the headless host's bare clone.
                if (MedusaVisualGraft.CanSpawnClientFx())
                    GraftMedusaPoisonVisual(clone, slot);

                // Stable per-slot assetId (collision-checked; peer-identical given the same build).
                uint assetId = ResolveFreeAssetId(_medusaAssetId[slot]);
                _medusaAssetId[slot] = assetId;

                SanitizeAndAssignAssetId(clone, assetId);
                // NOTE: Mirror registration (InstantiatedPrefabs/spawnPrefabs + client RegisterPrefab + pool)
                // is performed by the caller EnsureMedusaHitboxesRegistered, idempotently on EVERY hook, so it
                // re-asserts once the peer is active (matches the proven M1 build-once / register-every-hook
                // split). Here we only BUILD + neutralize the graft + sanitize identity + assign the stable
                // assetId (exactly once per slot).
                return clone;
            }
            catch (Exception ex) { Warn($"[M3c] BuildMedusaNetworkedHitbox slot={slot}: {ex.Message}"); return null; }
        }

        // Disable the base chassis's own visual renderers (so we never see the donor char's hitbox mesh) and
        // graft the authored Medusa poison subtree as a NetworkIdentity-less child (M2 graft pattern). The
        // grafted subtree is fully neutralized (no NetworkBehaviour/NetworkIdentity, no collider, no
        // rigidbody) so it can never interfere with the chassis trigger detection or its Mirror layout.
        private static void GraftMedusaPoisonVisual(GameObject clone, int slot)
        {
            try
            {
                int disabled = 0;
                Il2CppArrayBase<Renderer> rends = clone.GetComponentsInChildren<Renderer>(true);
                if (rends != null)
                    for (int i = 0; i < rends.Length; i++)
                    {
                        Renderer r = rends[i];
                        if (IsNull(r)) continue;
                        try { if (r.enabled) disabled++; r.enabled = false; try { r.forceRenderingOff = true; } catch { } } catch { }
                    }

                GameObject? vis = MedusaVisualGraft.LoadBundleGameObject(MedusaHitboxName(slot));
                if (IsNull(vis)) vis = MedusaVisualGraft.LoadBundleGameObject(_medusaVisualFallback[slot]);
                if (IsNull(vis))
                {
                    Warn($"[M3c] slot {slot}: no Medusa poison visual in bundle " +
                         $"('{MedusaHitboxName(slot)}' / '{_medusaVisualFallback[slot]}'); base renderers disabled, no graft.");
                    return;
                }

                GameObject child = UObject.Instantiate(vis!, clone.transform, false);
                child.name = "Medusa_Poison_Visual";
                try { child.transform.localPosition = Vector3.zero; child.transform.localRotation = Quaternion.identity; } catch { }

                NeutralizeGraftedSubtree(child);

                Msg($"[M3c] slot {slot}: grafted '{SafeName(vis)}' as Medusa poison visual (baseRenderersDisabled={disabled}).");
            }
            catch (Exception ex) { Warn($"[M3c] GraftMedusaPoisonVisual slot={slot}: {ex.Message}"); }
        }

        // Strip every NetworkBehaviour/NetworkIdentity (keeps the chassis Mirror layout intact), and disable
        // colliders + make rigidbodies inert (so the visual can't add stray trigger hits or physics).
        // Renderers/particles are LEFT enabled so the poison VFX renders on render-capable peers.
        private static void NeutralizeGraftedSubtree(GameObject root)
        {
            try
            {
                Il2CppArrayBase<NetworkBehaviour> nbs = root.GetComponentsInChildren<NetworkBehaviour>(true);
                if (nbs != null)
                    for (int i = 0; i < nbs.Length; i++)
                    {
                        NetworkBehaviour nb = nbs[i];
                        if (IsNull(nb)) continue;
                        try { UObject.DestroyImmediate((Component)nb); } catch { }
                    }
            }
            catch { }
            try
            {
                Il2CppArrayBase<NetworkIdentity> nis = root.GetComponentsInChildren<NetworkIdentity>(true);
                if (nis != null)
                    for (int i = 0; i < nis.Length; i++)
                    {
                        NetworkIdentity ni = nis[i];
                        if (IsNull(ni)) continue;
                        try { UObject.DestroyImmediate((Component)ni); } catch { }
                    }
            }
            catch { }
            try
            {
                Il2CppArrayBase<Collider> cols = root.GetComponentsInChildren<Collider>(true);
                if (cols != null)
                    for (int i = 0; i < cols.Length; i++)
                    {
                        Collider c = cols[i];
                        if (IsNull(c)) continue;
                        try { c.enabled = false; } catch { }
                    }
            }
            catch { }
            try
            {
                Il2CppArrayBase<Rigidbody> rbs = root.GetComponentsInChildren<Rigidbody>(true);
                if (rbs != null)
                    for (int i = 0; i < rbs.Length; i++)
                    {
                        Rigidbody rb = rbs[i];
                        if (IsNull(rb)) continue;
                        try { rb.isKinematic = true; rb.detectCollisions = false; rb.useGravity = false; } catch { }
                    }
            }
            catch { }
        }

        // Sanitize every child NetworkIdentity's runtime spawn-state and assign the root the stable assetId
        // (verbatim port of CustomCharMod.ConfigureMirrorIdentity — all members verified in the M1 build).
        private static void SanitizeAndAssignAssetId(GameObject prefab, uint assetId)
        {
            Il2CppArrayBase<NetworkIdentity> ids = prefab.GetComponentsInChildren<NetworkIdentity>(true);
            if (ids != null)
                for (int i = 0; i < ids.Length; i++)
                {
                    NetworkIdentity id = ids[i];
                    if (IsNull(id)) continue;
                    TrySet(() => id.sceneId = 0uL);
                    TrySet(() => id._netId_k__BackingField = 0u);
                    TrySet(() => id.hasSpawned = false);
                    TrySet(() => id._SpawnedFromInstantiate_k__BackingField = false);
                    TrySet(() => id.destroyCalled = false);
                    TrySet(() => id.serverOnly = false);
                    TrySet(() => id._connectionToServer_k__BackingField = null);
                    TrySet(() => id._connectionToClient = null);
                    TrySet(() => id.InitializeNetworkBehaviours());
                }

            NetworkIdentity? root = prefab.GetComponent<NetworkIdentity>();
            if (IsNull(root)) root = prefab.GetComponentInChildren<NetworkIdentity>(true);
            if (!IsNull(root)) TrySet(() => root!._assetId = assetId);
        }

        // Register identically on whichever peer is active (M1 EnsureMirrorRegistration pattern):
        // networkPrefabLibrary.InstantiatedPrefabs + base NetworkManager.spawnPrefabs + (client)
        // NetworkClient.RegisterPrefab + NetworkPrefabPool.ClientCreate/ServerCreate.
        private static void RegisterNetworkedPrefab(GameNetworkManager gnm, NetworkPrefabLibrary lib,
                                                    GameObject prefab, uint assetId)
        {
            try
            {
                Il2CppReferenceArray<GameObject> arr = lib.InstantiatedPrefabs;
                int len = arr?.Length ?? 0;
                bool found = false;
                for (int i = 0; i < len; i++) if (arr![i] == prefab) { found = true; break; }
                if (!found)
                {
                    var grown = new Il2CppReferenceArray<GameObject>((long)(len + 1));
                    for (int i = 0; i < len; i++) grown[i] = arr![i];
                    grown[len] = prefab;
                    lib.InstantiatedPrefabs = grown;
                }
            }
            catch (Exception ex) { Warn($"[M3c] InstantiatedPrefabs inject: {ex.Message}"); }

            try
            {
                NetworkManager nm = gnm.Cast<NetworkManager>();
                var list = nm.spawnPrefabs;
                if (list != null)
                {
                    bool found = false;
                    for (int i = 0; i < list.Count; i++) if (list[i] == prefab) { found = true; break; }
                    if (!found) list.Add(prefab);
                }
            }
            catch (Exception ex) { Warn($"[M3c] spawnPrefabs append: {ex.Message}"); }

            bool clientActive = false, serverActive = false;
            try { clientActive = NetworkClient.active; } catch { }
            try { serverActive = NetworkServer.active; } catch { }

            if (clientActive)
            {
                try { NetworkClient.RegisterPrefab(prefab, assetId); }
                catch (Exception ex) { Warn($"[M3c] RegisterPrefab: {ex.Message}"); }
            }

            try
            {
                var cfg = new NetworkPrefabPool.Config
                {
                    prefab = prefab,
                    initialSizeServer = 1,
                    initialSizeClient = 1,
                    resizeStrategy = NetworkPrefabPool.ResizeStrategy.Increment
                };
                if (clientActive) { try { NetworkPrefabPool.ClientCreate(cfg); } catch (Exception ex) { Warn($"[M3c] ClientCreate: {ex.Message}"); } }
                if (serverActive) { try { NetworkPrefabPool.ServerCreate(cfg); } catch (Exception ex) { Warn($"[M3c] ServerCreate: {ex.Message}"); } }
            }
            catch (Exception ex) { Warn($"[M3c] pool create: {ex.Message}"); }
        }

        private static uint ResolveFreeAssetId(uint candidate)
        {
            try
            {
                int guard = 0;
                while (guard++ < 4096 && AssetIdInUse(candidate)) candidate++;
            }
            catch { }
            return candidate;
        }

        private static bool AssetIdInUse(uint id)
        {
            try { var pool = NetworkPrefabPool.poolLookup; if (pool != null && pool.ContainsKey(id)) return true; } catch { }
            try { var prefabs = NetworkClient.prefabs; if (prefabs != null && prefabs.ContainsKey(id)) return true; } catch { }
            return false;
        }

        private static void TrySet(Action a) { try { a(); } catch { } }

        // ---- targeting (PROVEN: FindMedusaAbilityTargets / IsValidMedusaAbilityTarget) -------------
        private static List<EntityManager> FindTargets(EntityManager caster, int slot, Vector3 origin, Vector3 dir)
        {
            var list = new List<EntityManager>();
            try
            {
                Il2CppArrayBase<EntityManager> all = UObject.FindObjectsOfType<EntityManager>();
                if (all == null) return list;
                for (int i = 0; i < all.Length; i++)
                {
                    EntityManager t = all[i];
                    if (!IsValidTarget(caster, t)) continue;
                    Vector3 to = SafePos(t) - origin; to.y = 0f;
                    float dist = to.magnitude;
                    if (dist < 0.01f) continue;
                    Vector3 f = dir; f.y = 0f;
                    if (f.sqrMagnitude < 0.01f) f = Vector3.forward;
                    f.Normalize();
                    float fwd = Vector3.Dot(to, f);
                    float lat = (to - f * fwd).magnitude;
                    bool hit = slot switch
                    {
                        0 => fwd > 0f && fwd <= 9.2f && lat <= 0.9f,
                        1 => fwd > 0f && fwd <= 6f && lat <= 2.25f,
                        2 => dist <= 2.75f,
                        3 => fwd > 0f && fwd <= 11.5f && lat <= 1.35f,
                        _ => false,
                    };
                    if (hit) list.Add(t);
                }
                if (slot == 0 && list.Count > 1)
                {
                    list.Sort((a, b) => Vector3.Distance(origin, SafePos(a)).CompareTo(Vector3.Distance(origin, SafePos(b))));
                    while (list.Count > 1) list.RemoveAt(list.Count - 1);
                }
            }
            catch { }
            return list;
        }

        private static bool IsValidTarget(EntityManager caster, EntityManager target)
        {
            if (IsNull(caster) || IsNull(target) || (UObject)caster == (UObject)target) return false;
            try { if (target.isItem || target.isLootbox || target.isInteractable) return false; } catch { }
            try { CharHurtbox hb = target.charHurtbox; if (IsNull(hb) || hb.isDead || hb.nonDamagable) return false; } catch { }
            // OWNER/TEAM FIX (parity with the spawned-hitbox path): EntityManager.ownerPlayerId is a plain
            // non-SyncVar int that stays -1 on a player char (and entityTeamId can be unset/unreliable at
            // cast time), so resolve BOTH authoritative ids from PlayerManager (SyncVar playerId/teamId) via
            // ResolveTeamId/ResolveOwnerPid for caster AND target. Using the raw reads here previously let the
            // cone fallback hit teammates/self (caster.ownerPlayerId==-1 disabled the owner filter entirely).
            int ct = ResolveTeamId(caster), tt = ResolveTeamId(target);
            if (ct >= 0 && tt >= 0 && ct == tt) return false;
            int co = ResolveOwnerPid(caster), to = ResolveOwnerPid(target);
            if (co > 0 && to > 0) return co != to;
            return true;
        }

        // ---- slot resolution (PROVEN: GetMedusaAbilitySlot) ----------------------------------------
        private static int ResolveSlot(Ability ability, EntityManager caster)
        {
            try
            {
                CharAbilities ca = ability.charAbilities;
                if (IsNull(ca)) return -1;
                Il2CppReferenceArray<Ability> arr = ca.abilities;
                if (arr == null) return -1;
                for (int i = 0; i < ((Il2CppArrayBase<Ability>)(object)arr).Length; i++)
                {
                    Ability a = ((Il2CppArrayBase<Ability>)(object)arr)[i];
                    if (IsNull(a)) continue;
                    if (((Il2CppObjectBase)a).Pointer == ((Il2CppObjectBase)ability).Pointer) return i;
                }
            }
            catch { }
            return -1;
        }

        // ---- helpers --------------------------------------------------------------------------------
        private static bool IsCastStart(int oldState, int newState)
        {
            // AbilityStates: Ready=0, Aiming=1, Casting=2, Active=3
            if (oldState >= 0 && oldState < 2) return newState == 2 || newState == 3;
            return false;
        }

        private static bool IsServer(EntityManager e)
        {
            try { return ((NetworkBehaviour)e).isServer; } catch { return false; }
        }

        private static bool Throttle(EntityManager caster, int slot)
        {
            long id;
            try { id = ((Il2CppObjectBase)caster).Pointer.ToInt64(); } catch { id = 0; }
            long key = (id << 4) ^ (slot & 0xF);
            float now;
            try { now = Time.unscaledTime; } catch { now = (float)DateTime.UtcNow.TimeOfDay.TotalSeconds; }
            if (_recent.TryGetValue(key, out float last) && now - last < 0.38f) return false;
            _recent[key] = now;
            if (_recent.Count > 128) _recent.Clear();
            return true;
        }

        // Resolve the casting player's REAL owner-player-id + team. EntityManager.ownerPlayerId is a plain
        // (non-SyncVar) int that stays -1 on a player char; the authoritative ids live on PlayerManager.
        private static int ResolveOwnerPid(EntityManager e)
        {
            try { var pm = e.playerManager; if (!IsNull(pm)) { int id = pm.playerId; if (id > 0) return id; } } catch { }
            try { int id = e.ownerPlayerId; if (id > 0) return id; } catch { }
            return -1;
        }
        private static int ResolveTeamId(EntityManager e)
        {
            try { var pm = e.playerManager; if (!IsNull(pm)) { int t = pm.teamId; if (t >= 0) return t; } } catch { }
            try { int t = e.entityTeamId; if (t >= 0) return t; } catch { }
            return -1;
        }

        private static Vector3 SafePos(EntityManager e)
        {
            try { return ((Component)e).transform.position; } catch { return Vector3.zero; }
        }

        private static Vector3 SafeForward(EntityManager e)
        {
            try { Vector3 f = ((Component)e).transform.forward; f.y = 0f; return f.sqrMagnitude > 0.01f ? f.normalized : Vector3.forward; }
            catch { return Vector3.forward; }
        }

        private static int SafeInt(Func<int> f) { try { return f(); } catch { return -1; } }
        private static float SafeFloat(Func<float> f) { try { return f(); } catch { return 0f; } }
        private static string SafeName(GameObject? go) { try { return IsNull(go) ? "<none>" : go!.name; } catch { return "?"; } }

        private static void Msg(string m) { MelonLogger.Msg($"[M3] {m}"); }
        private static void Warn(string m) { MelonLogger.Warning($"[M3] {m}"); }

        // ---- M6: play Medusa's per-slot cast animation (CLIENT-SIDE, render-gated) ------------------
        // Driven from the cosmetic RPC presenter (CustomVfxPresenter), NOT from FireServer: BR has no
        // NetworkAnimator on the char, so a server-side animator write would not replicate. Running it on
        // every observer (via the already-proven RPC) plays the cast motion in lockstep with the VFX on all
        // clients while the headless host stays renderer-free (CanSpawnClientFx() == false there).
        //
        // The Medusa.controller defines override states Ability1/Ability2 (upper-body layer) and Ability4
        // (full-body layer); Ability3 is empty. AnimLayerIndices is { Base=0, Upperbody=1, Fullbody=2,
        // IdleFullbody=3 } — the controller's "UpperbodyOverwrite"/"FullbodyOverwrite" layers sit at indices
        // 1/2. We don't hardcode which layer owns a given state: probe Upperbody then Fullbody via HasState
        // and CrossFade into whichever actually has it, so a config-renamed state still resolves.
        internal static void PlayCastAnim(EntityManager? caster, int slot)
        {
            try
            {
                if (!MedusaVisualGraft.CanSpawnClientFx()) return;     // headless host: no animation
                if (IsNull(caster)) return;
                string state = SlotAnimState(slot);
                if (string.IsNullOrWhiteSpace(state)) return;          // slot has no cast anim (e.g. Ability3 empty)

                CharAnimator ca = caster!.charAnim;
                if (IsNull(ca)) return;

                int hash = Animator.StringToHash(state);
                AnimLayerIndices[] layers = { AnimLayerIndices.Upperbody, AnimLayerIndices.Fullbody, AnimLayerIndices.Base };
                foreach (AnimLayerIndices layer in layers)
                {
                    bool has = false;
                    try { has = ca.HasState(hash, layer); } catch { has = false; }
                    if (!has) continue;
                    try { ca.CrossFadeMecanimState(hash, layer, 0f, 0.05f); } catch { continue; }
                    Msg($"cast anim slot={slot} state='{state}' layer={layer}.");
                    return;
                }
                Msg($"cast anim slot={slot} state='{state}' NOT FOUND on any layer (skipped).");
            }
            catch (Exception ex) { Warn($"PlayCastAnim slot={slot}: {ex.Message}"); }
        }
    }
}

using System;
using System.Reflection;
using HarmonyLib;
using MelonLoader;
using UnityEngine;
using Il2CppInterop.Runtime.InteropTypes.Arrays;

// --- Il2Cpp game/Mirror aliases (VERIFIED against the real reference assemblies + decomp) ---
using UObject               = UnityEngine.Object;
using NetworkIdentity       = Il2CppMirror.NetworkIdentity;
using NetworkServer         = Il2CppMirror.NetworkServer;
using NetworkClient         = Il2CppMirror.NetworkClient;
using NetworkManager        = Il2CppMirror.NetworkManager;
using GameNetworkManager    = Il2CppBAPBAP.Network.GameNetworkManager;
using CharacterBotPrefabs   = Il2CppBAPBAP.Network.GameNetworkManager.CharacterBotPrefabs;
using GameMode              = Il2CppBAPBAP.Game.GameMode;
using NetworkPrefabLibrary  = Il2CppBAPBAP.Pooling.NetworkPrefabLibrary;
using NetworkPrefabPool     = Il2CppBAPBAP.Pooling.NetworkPrefabPool;
using PoolConfig            = Il2CppBAPBAP.Pooling.NetworkPrefabPool.Config;
using ResizeStrategy        = Il2CppBAPBAP.Pooling.NetworkPrefabPool.ResizeStrategy;
using UICharactersConfiguration = Il2CppBAPBAP.UI.UICharactersConfiguration;
using CharacterConfiguration    = Il2CppBAPBAP.UI.UICharactersConfiguration.CharacterConfiguration;
using UILobbyCharacterSelectPage = Il2CppBAPBAP.UI.UILobbyCharacterSelectPage;
// M2/M3 aliases (VERIFIED against the real reference assemblies + decomp)
using Ability        = Il2CppBAPBAP.Entities.Ability;
using AbilityStates  = Il2CppBAPBAP.Entities.AbilityStates;
using CharAnimator   = Il2CppBAPBAP.Entities.CharAnimator;
using CharFootsteps  = Il2CppBAPBAP.Entities.CharFootsteps;
using EntityManager  = Il2CppBAPBAP.Entities.EntityManager;
using PlayerDebug    = Il2CppBAPBAP.Player.PlayerDebug;

[assembly: MelonInfo(typeof(NetworkedCustomChar.CustomCharMod), "NetworkedCustomChar", "0.1.0", "bapcustom")]
[assembly: MelonGame(null, null)]

namespace NetworkedCustomChar
{
    /// <summary>
    /// Data-driven custom-character definition. M1 hardcodes a single entry (charId 15,
    /// cloned from the base Kitsu networked chassis). M5 will move this to JSON.
    /// </summary>
    public sealed class CustomCharDef
    {
        public int  CharId      = 15;             // first free slot above shipped 0..14
        public int  BaseCharId  = 0;              // Kitsu networked chassis (GameNetworkManager.KitsuCharId == 0)
        public string Name      = "Custom15";
        public uint AssetId     = 0xB0B00F00u + 15u;  // 0xB0B00F0F — peer-identical (same DLL), high, collision-checked
        public bool GraftVisual = true;           // M2: graft real networked Medusa visual into the prefab

        // M5 (config-driven): visual bundle + display, loaded from UserData\CustomChars\*.json.
        public string DisplayName      = "MEDUSA";          // upper-case lobby label
        public string BundleFileName   = "medusa.bundle";   // file inside UserData\<Name>\
        public string VisualPrefabName = "Medusa_Visual";   // visual root prefab name in the bundle
        public bool   Enabled          = true;              // first enabled def is the active one

        // M6 (config-driven ability kit): per-slot (0..3) data consumed by CustomAbilityEngine +
        // CustomVfxPresenter. Defaults are the PROVEN, live Medusa values so an omitted/partial JSON
        // reproduces exactly the prior hardcoded behavior. Arrays shorter than the cast slot fall back
        // to the per-field default at read time (see CustomAbilityEngine helpers), so a partial array
        // is safe.
        //   AbilityHitboxes   : authored networked hitbox prefab name grafted+spawned per slot (M3c).
        //   AbilityDamage     : CharHurtbox.ApplyHit damage per slot.
        //   StatusOnHit       : status applied per slot ("poison"/"petrify"); "" / "none" = none.
        //   StatusDuration    : status seconds per slot.
        //   AbilityVfx        : ';'-separated cosmetic VFX prefab name(s) instantiated client-side per slot.
        //   AbilityAnimState  : Mecanim state name CrossFaded on the Medusa animator per slot ("" = none).
        public string[] AbilityHitboxes  = { "Hitbox_MedusaPoisonProjectile", "Hitbox_MedusaPoisonPuddle", "Hitbox_MedusaWallPoison", "Hitbox_MedusaWallBoxDpsPoison" };
        public int[]    AbilityDamage    = { 120, 85, 70, 160 };
        public string[] StatusOnHit      = { "poison", "slow", "knockup", "petrify" };
        public float[]  StatusDuration   = { 3f, 4f, 1f, 2.5f };
        public string[] AbilityVfx       =
        {
            "VFX_Medusa_Poison_Muzzle;VFX_Medusa_Poison_Trail;VFX_Medusa_Poison_Hit",
            "VFX_Medusa_Poison_Muzzle;VFX_Medusa_Poison_Trail;VFX_Medusa_Poison_Puddle",
            "VFX_Medusa_Poison_Escape;VFX_Medusa_Poison_Trail;VFX_Medusa_Poison_Puddle",
            "VFX_Medusa_Poison_Muzzle;VFX_Medusa_Poison_Wall;VFX_Medusa_Poison_Hit"
        };
        public string[] AbilityAnimState = { "Ability1", "Ability2", "Ability4", "Ability3" };

        // Relative bundle path the resolver uses: "<Name>\<BundleFileName>".
        public string BundleRel => Name + "\\" + BundleFileName;
    }

    /// <summary>
    /// Milestone 1: build a custom networked character prefab by cloning a real game char root
    /// (so it keeps the weaver-built NetworkIdentity + full Char* NetworkBehaviour chain), assign a
    /// stable peer-identical assetId, sanitize runtime spawn-state, and register it IDENTICALLY on
    /// server and client so the native GameMode.SpawnPlayerChar spawns it and every peer renders it.
    /// </summary>
    public sealed class CustomCharMod : MelonMod
    {
        internal static CustomCharMod? Instance;
        private CustomCharDef _def = new CustomCharDef();

        private HarmonyLib.Harmony? _harmony;

        private GameObject? _networkedPrefab;       // our composed, registered char-body prefab
        private bool _built;
        private bool _assetIdResolved;
        private bool _libraryInjected;

        // ----------------------------------------------------------------------------------------
        public override void OnInitializeMelon()
        {
            Instance = this;
            try { _def = CustomCharConfig.LoadActive(m => LoggerInstance.Msg(m)); }
            catch (Exception e) { LoggerInstance.Warning($"[M5] config load failed, using default: {e.Message}"); }
            try { CustomAbilityEngine.CustomCharId = _def.CharId; } catch { }
            try { CustomAbilityEngine.SetActiveDef(_def); } catch { }
            try { MedusaVisualGraft.VisualAssetName = _def.VisualPrefabName; MedusaVisualGraft.ActiveBundleRel = _def.BundleRel; } catch { }
            try
            {
                _harmony = new HarmonyLib.Harmony("com.bapcustom.networkedcustomchar");
                InstallPatches();
            }
            catch (Exception e) { LoggerInstance.Error($"[M1] patch install failed: {e}"); }

            // M3: register the manual ClientRpc channel IDENTICALLY on server + every client (parity required),
            // and ready the server-side ability engine. Do NOT branch on isServer here.
            try { CustomNetChannel.Register(); } catch (Exception e) { LoggerInstance.Error($"[M3] CustomNetChannel.Register: {e}"); }
            try { CustomAbilityEngine.Init(); } catch (Exception e) { LoggerInstance.Error($"[M3] CustomAbilityEngine.Init: {e}"); }
            try { if (_harmony != null) CustomMapLoader.Init(_harmony); } catch (Exception e) { LoggerInstance.Error($"[MAP] CustomMapLoader.Init: {e}"); }

            LoggerInstance.Msg($"[M1] loaded. charId={_def.CharId} baseCharId={_def.BaseCharId} assetId=0x{_def.AssetId:X8} graftVisual={_def.GraftVisual}");
        }

        public override void OnDeinitializeMelon()
        {
            try { _harmony?.UnpatchSelf(); } catch { }
        }

        // ----------------------------------------------------------------------------------------
        // PART A — reliable selectability. The earlier UICharactersConfiguration.OnEnable hook was an
        // unreliable single shot, so in addition to that postfix we POLL: every ~30 frames we find the
        // LIVE UICharactersConfiguration via Resources.FindObjectsOfTypeAll<>() and (re)inject the charId-15
        // row + push UpdateAvailableCharacterList. Also drives env-gated autoselect for automated testing.
        // ----------------------------------------------------------------------------------------
        private int _frame;
        private bool _autoSelectDone;

        public override void OnUpdate()
        {
            try
            {
                if ((_frame++ % 30) != 0) return;   // ~2x/sec at 60fps
                PollEnsureUiRow();
                if (!_autoSelectDone && AutoSelectEnabled()) TryAutoSelect();
            }
            catch { }
        }

        private void PollEnsureUiRow()
        {
            try
            {
                Il2CppArrayBase<UICharactersConfiguration> cfgs = Resources.FindObjectsOfTypeAll<UICharactersConfiguration>();
                if (cfgs == null) return;
                for (int i = 0; i < cfgs.Length; i++)
                {
                    UICharactersConfiguration cfg = cfgs[i];
                    if (!IsNull(cfg)) EnsureUiRow(cfg, "Poll");
                }
            }
            catch (Exception e) { LoggerInstance.Warning($"[A] PollEnsureUiRow: {e.Message}"); }
        }

        private static bool AutoSelectEnabled()
        {
            try { return (Environment.GetEnvironmentVariable("BAPBAP_NETCUSTOM_AUTOSELECT") ?? "") == "1"; }
            catch { return false; }
        }

        // Server-authoritative selection path (research r14). VERIFIED real method:
        //   PlayerDebug.SwitchCharacter(int charToSwitchId, int skinAssetId = -1)   [Il2CppBAPBAP.Player]
        // (host-authority fallback PlayerDebug.CmdSwitchCharacter(int) also verified).
        private void TryAutoSelect()
        {
            try
            {
                PlayerDebug dbg = UObject.FindObjectOfType<PlayerDebug>();
                if (IsNull(dbg)) return;
                try { dbg.SwitchCharacter(_def.CharId, -1); }
                catch
                {
                    try { dbg.CmdSwitchCharacter(_def.CharId); } catch { return; }
                }
                _autoSelectDone = true;
                LoggerInstance.Msg($"[A] autoselect: PlayerDebug.SwitchCharacter({_def.CharId}, -1) invoked.");
            }
            catch (Exception e) { LoggerInstance.Warning($"[A] TryAutoSelect: {e.Message}"); }
        }

        // ----------------------------------------------------------------------------------------
        // MANUAL HARMONY PATCHING (per AGENTS.md conventions): each target wrapped in try/catch so a
        // single missing method never disables the rest.
        // ----------------------------------------------------------------------------------------
        private void InstallPatches()
        {
            TryPatch(typeof(GameNetworkManager), "Awake",
                postfix: nameof(GNM_Awake_Postfix));
            TryPatch(typeof(GameNetworkManager), "OnStartServer",
                postfix: nameof(GNM_OnStartServer_Postfix));
            TryPatch(typeof(GameNetworkManager), "OnStartClient",
                postfix: nameof(GNM_OnStartClient_Postfix));
            TryPatch(typeof(GameNetworkManager), "GetCharacterBotPrefab",
                prefix: nameof(GNM_GetCharacterBotPrefab_Prefix));
            TryPatch(typeof(GameMode), "SpawnPlayerChar",
                prefix: nameof(GM_SpawnPlayerChar_Prefix));
            TryPatch(typeof(UICharactersConfiguration), "OnEnable",
                postfix: nameof(UICfg_OnEnable_Postfix));
            TryPatch(typeof(UILobbyCharacterSelectPage), "GetCharacterListingIndexFromCharId",
                prefix: nameof(LobbyListingIndex_Prefix));

            // ---- M3: server-authoritative ability trigger (Ability.SetState — the REAL verified hook;
            //          the design's CharAbilities.SvOnAbilityTriggered does NOT exist). pre captures old
            //          state, post runs the engine on a cast-start transition (server + charId 15 gated). ----
            TryPatch(typeof(Ability), "SetState",
                prefix: nameof(Ability_SetState_Prefix), postfix: nameof(Ability_SetState_Postfix));

            // ---- M2: re-wire CharAnimator/CharFootsteps to Medusa's Animator on each live instance
            //          (Awake resets .animator to the serialized value, so we re-apply). ----
            TryPatch(typeof(CharAnimator), "Awake", postfix: nameof(CharAnimator_Awake_Postfix));
            TryPatch(typeof(CharFootsteps), "Awake", postfix: nameof(CharFootsteps_Awake_Postfix));

            // ---- M2: guard Animator layer calls so a swapped Medusa controller (fewer layers) can't throw. ----
            TryPatchOverload(typeof(Animator), "SetLayerWeight",
                new[] { typeof(int), typeof(float) }, prefix: nameof(Animator_SetLayerWeight_Guard));
            TryPatchOverload(typeof(Animator), "CrossFadeInFixedTime",
                new[] { typeof(int), typeof(float), typeof(int), typeof(float) }, prefix: nameof(Animator_CrossFadeInFixedTime_Guard));
        }

        private void TryPatch(Type targetType, string method, string? prefix = null, string? postfix = null)
        {
            try
            {
                MethodBase? target = AccessTools.Method(targetType, method);
                if (target == null)
                {
                    LoggerInstance.Warning($"[M1] patch target not found: {targetType.Name}.{method}");
                    return;
                }
                HarmonyMethod? pre  = prefix  != null ? Local(prefix)  : null;
                HarmonyMethod? post = postfix != null ? Local(postfix) : null;
                _harmony!.Patch(target, prefix: pre, postfix: post);
                LoggerInstance.Msg($"[M1] patched {targetType.Name}.{method} (pre={prefix != null} post={postfix != null}).");
            }
            catch (Exception e) { LoggerInstance.Warning($"[M1] patch {targetType.Name}.{method} failed: {e.Message}"); }
        }

        private static HarmonyMethod Local(string name)
            => new HarmonyMethod(typeof(CustomCharMod).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic)!);

        // Overload-aware variant (needed for Animator.SetLayerWeight / CrossFadeInFixedTime).
        private void TryPatchOverload(Type targetType, string method, Type[] paramTypes, string? prefix = null, string? postfix = null)
        {
            try
            {
                MethodBase? target = AccessTools.Method(targetType, method, paramTypes);
                if (target == null)
                {
                    LoggerInstance.Warning($"[M2] patch target not found (overload): {targetType.Name}.{method}");
                    return;
                }
                HarmonyMethod? pre  = prefix  != null ? Local(prefix)  : null;
                HarmonyMethod? post = postfix != null ? Local(postfix) : null;
                _harmony!.Patch(target, prefix: pre, postfix: post);
                LoggerInstance.Msg($"[M2] patched {targetType.Name}.{method} (overload; pre={prefix != null} post={postfix != null}).");
            }
            catch (Exception e) { LoggerInstance.Warning($"[M2] patch {targetType.Name}.{method} (overload) failed: {e.Message}"); }
        }

        // ----------------------------------------------------------------------------------------
        // HOOK BODIES
        // ----------------------------------------------------------------------------------------
        private static void GNM_Awake_Postfix()        => Instance?.EnsureRegistered("GNM.Awake");
        private static void GNM_OnStartServer_Postfix() => Instance?.EnsureRegistered("GNM.OnStartServer");
        private static void GNM_OnStartClient_Postfix() => Instance?.EnsureRegistered("GNM.OnStartClient");
        private static void GM_SpawnPlayerChar_Prefix() => Instance?.EnsureRegistered("GM.SpawnPlayerChar");

        // Bots: DO NOT rewrite charId (the old mod's fatal mistake). Only ensure the slot exists.
        private static void GNM_GetCharacterBotPrefab_Prefix(int charId)
        {
            if (Instance != null && charId == Instance._def.CharId)
                Instance.EnsureRegistered("GNM.GetCharacterBotPrefab");
        }

        // Resolve the char-select listing index WITHOUT ever running the native original.
        //
        // BUGFIX (2026-06-15): the native GetCharacterListingIndexFromCharId NREs on a custom server
        // (its internal listing data isn't populated the way the stock client expects). The old prefix
        // only short-circuited for our custom char (Medusa) and did `return true` for every other charId,
        // which ran the crashy original. That NRE aborts UILobbyCharacterSelectPage.UpdateData mid-populate,
        // so the WHOLE char-select page falls back to defaults => every character shows LOCKED and every
        // portrait shows charId 0 (Kitsu). We now handle ALL charIds and never fall through to the original.
        //
        // The custom server's character listing is charId-ordered and contiguous (0..N), so the listing
        // index equals the charId. Out-of-range ids return -1 (the native "not found" sentinel, which the
        // callers handle gracefully) so a bad id can never index a button array out of bounds.
        private static bool LobbyListingIndex_Prefix(int charId, ref int __result)
        {
            int maxId = (Instance != null) ? Instance._def.CharId : 15;
            if (maxId < 15) maxId = 15;                 // 0..14 shipped + 15 Medusa at minimum
            __result = (charId >= 0 && charId <= maxId) ? charId : -1;
            return false;                               // never run the NRE-prone original
        }

        private static void UICfg_OnEnable_Postfix(UICharactersConfiguration __instance)
            => Instance?.EnsureUiRow(__instance, "UICfg.OnEnable");

        // ---- M3: ability hook forwards to the server-side engine -------------------------------------
        private static void Ability_SetState_Prefix(Ability __instance, out int __state)
            => CustomAbilityEngine.SetState_Prefix(__instance, out __state);

        private static void Ability_SetState_Postfix(Ability __instance, AbilityStates _state, int __state)
            => CustomAbilityEngine.SetState_Postfix(__instance, _state, __state);

        // ---- M2: re-wire CharAnimator/CharFootsteps to Medusa's Animator on each spawned instance -----
        private static void CharAnimator_Awake_Postfix(CharAnimator __instance)
        {
            try
            {
                if ((UObject)__instance == (UObject?)null || Instance == null || !Instance._def.GraftVisual) return;
                if (!IsOurEntity(__instance.entityManager)) return;
                Animator? med = MedusaVisualGraft.FindMedusaAnimator(__instance.transform);
                if ((UObject)med! == (UObject?)null) return;
                try { __instance.animator = med; } catch { return; }
                try { __instance.customAnimator = true; } catch { }
            }
            catch (Exception e) { Instance?.LoggerInstance.Warning($"[M2] CharAnimator.Awake rebind: {e.Message}"); }
        }

        private static void CharFootsteps_Awake_Postfix(CharFootsteps __instance)
        {
            try
            {
                if ((UObject)__instance == (UObject?)null || Instance == null || !Instance._def.GraftVisual) return;
                Animator? med = MedusaVisualGraft.FindMedusaAnimator(__instance.transform);
                if ((UObject)med! == (UObject?)null) return;
                try { __instance.animator = med; } catch { }
            }
            catch { }
        }

        private static bool IsOurEntity(EntityManager? e)
        {
            try { return (UObject)e! != (UObject?)null && Instance != null && e!.charId == Instance._def.CharId; }
            catch { return false; }
        }

        // ---- M2: suppress out-of-range Animator layer calls from a swapped Medusa controller ----------
        private static bool Animator_SetLayerWeight_Guard(Animator __instance, int layerIndex)
        {
            try
            {
                if ((UObject)__instance == (UObject?)null) return true;
                int lc = __instance.layerCount;
                if (layerIndex >= 0 && layerIndex < lc) return true;  // valid -> run original
                return false;                                          // out of range -> skip
            }
            catch { return true; }
        }

        private static bool Animator_CrossFadeInFixedTime_Guard(Animator __instance, int layer)
        {
            try
            {
                if ((UObject)__instance == (UObject?)null) return true;
                int lc = __instance.layerCount;
                if (layer < 0 || layer < lc) return true;             // valid (or auto-layer) -> run original
                return false;                                          // out of range -> skip
            }
            catch { return true; }
        }

        // ========================================================================================
        // BUILD + REGISTER  (idempotent; safe to call from every hook)
        // ========================================================================================
        internal bool EnsureRegistered(string src)
        {
            try
            {
                GameNetworkManager? gnm = FindGameNetworkManager();
                if (IsNull(gnm)) return false;

                if (!_built && !BuildNetworkedPrefab(gnm!, src)) return false;
                InstallIntoCharIdTables(gnm!, src);
                InjectIntoPrefabLibrary(gnm!, src);
                EnsureMirrorRegistration(gnm!, src);

                // M3c: build+register the authentic Medusa poison hitbox prefabs IDENTICALLY on this peer
                // (server AND client both reach EnsureRegistered via the GNM hooks). Idempotent; per-slot
                // failures fall back to M3b inside the engine. Guarded so it can never break M1/M2/M3.
                try { CustomAbilityEngine.EnsureMedusaHitboxesRegistered(gnm!); }
                catch (Exception e) { LoggerInstance.Warning($"[M3c] EnsureMedusaHitboxesRegistered via {src}: {e.Message}"); }
                return true;
            }
            catch (Exception e) { LoggerInstance.Error($"[M1] EnsureRegistered({src}): {e}"); return false; }
        }

        private bool BuildNetworkedPrefab(GameNetworkManager gnm, string src)
        {
            Il2CppReferenceArray<GameObject> table = gnm.characterPrefabsByCharId;
            if (table == null || _def.BaseCharId < 0 || _def.BaseCharId >= table.Length) return false;
            GameObject baseRoot = table[_def.BaseCharId];
            if (IsNull(baseRoot)) return false;

            // Clone the REAL networked root inert (carries weaved NetworkIdentity + Char* chain).
            bool wasActive = false;
            try { wasActive = baseRoot.activeSelf; if (wasActive) baseRoot.SetActive(false); } catch { }
            GameObject clone;
            try { clone = UObject.Instantiate(baseRoot); }
            finally { try { if (wasActive) baseRoot.SetActive(true); } catch { } }

            clone.name = $"Char_{_def.Name}";
            clone.SetActive(false);
            UObject.DontDestroyOnLoad(clone);

            // M2: bake the real networked Medusa visual into the prefab TEMPLATE. Same DLL+bundle on every
            // peer => identical child layout; the grafted subtree carries NO NetworkIdentity, so Mirror's
            // component layout on the networked chassis is unchanged and the visual replicates with the prefab.
            if (_def.GraftVisual)
            {
                bool ok = MedusaVisualGraft.Graft(clone, src);
                LoggerInstance.Msg($"[M2] graft {(ok ? "applied" : "skipped")} on prefab template via {src}.");
            }

            ConfigureMirrorIdentity(gnm, clone, src);  // stable assetId + sanitize runtime state
            _networkedPrefab = clone;
            _built = true;
            LoggerInstance.Msg($"[M1] built networked prefab 'Char_{_def.Name}' via {src} (baseCharId={_def.BaseCharId}).");
            return true;
        }

        // STEP 4 — stable assetId + runtime-state sanitize (clone is a TEMPLATE, never a live object).
        private void ConfigureMirrorIdentity(GameNetworkManager gnm, GameObject prefab, string src)
        {
            Il2CppArrayBase<NetworkIdentity> ids = prefab.GetComponentsInChildren<NetworkIdentity>(true);
            int n = 0;
            if (ids != null)
            {
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
                    n++;
                }
            }

            NetworkIdentity? root = prefab.GetComponent<NetworkIdentity>();
            if (IsNull(root)) root = prefab.GetComponentInChildren<NetworkIdentity>(true);
            if (!IsNull(root))
            {
                AssertAssetIdFree(gnm, src);
                TrySet(() => root!._assetId = _def.AssetId);
            }
            LoggerInstance.Msg($"[M1] sanitized {n} identity(ies); root assetId=0x{_def.AssetId:X8} via {src}.");
        }

        // Scan NetworkPrefabPool.poolLookup keys + NetworkClient.prefabs keys; bump on collision.
        private void AssertAssetIdFree(GameNetworkManager gnm, string src)
        {
            if (_assetIdResolved) return;
            try
            {
                uint candidate = _def.AssetId;
                int guard = 0;
                while (guard++ < 4096 && AssetIdInUse(candidate))
                    candidate++;
                if (candidate != _def.AssetId)
                    LoggerInstance.Warning($"[M1] assetId 0x{_def.AssetId:X8} collided; bumped to 0x{candidate:X8} via {src}.");
                _def.AssetId = candidate;
            }
            catch (Exception e) { LoggerInstance.Warning($"[M1] AssertAssetIdFree via {src}: {e.Message}"); }
            finally { _assetIdResolved = true; }
        }

        private static bool AssetIdInUse(uint id)
        {
            try
            {
                var pool = NetworkPrefabPool.poolLookup;
                if (pool != null && pool.ContainsKey(id)) return true;
            }
            catch { }
            try
            {
                var prefabs = NetworkClient.prefabs;
                if (prefabs != null && prefabs.ContainsKey(id)) return true;
            }
            catch { }
            return false;
        }

        // STEP 5 — install at charId index (player table + bot table).
        private void InstallIntoCharIdTables(GameNetworkManager gnm, string src)
        {
            if (IsNull(_networkedPrefab)) return;

            // player prefab table (GameObject[])
            Il2CppReferenceArray<GameObject> table = gnm.characterPrefabsByCharId;
            if (table == null) return;
            bool present = _def.CharId < table.Length && !IsNull(table[_def.CharId]) && table[_def.CharId] == _networkedPrefab;
            if (!present)
            {
                int len = Math.Max(table.Length, _def.CharId + 1);
                var grown = new Il2CppReferenceArray<GameObject>((long)len);
                for (int i = 0; i < table.Length; i++) grown[i] = table[i];
                grown[_def.CharId] = _networkedPrefab!;
                gnm.characterPrefabsByCharId = grown;
                LoggerInstance.Msg($"[M1] characterPrefabsByCharId[{_def.CharId}] = our prefab via {src} (len {table.Length}->{len}).");
            }

            // bot prefab table (CharacterBotPrefabs[]) — ensure slot resolves so bots don't NRE.
            EnsureBotPrefabEntry(gnm, src);
        }

        private void EnsureBotPrefabEntry(GameNetworkManager gnm, string src)
        {
            try
            {
                Il2CppReferenceArray<CharacterBotPrefabs> bots = gnm.charBotPrefabsByCharId;
                if (bots == null) return;
                bool present = _def.CharId < bots.Length && bots[_def.CharId] != null;
                if (present) return;

                var entry = new CharacterBotPrefabs();
                entry.charBotEasy   = _networkedPrefab!;
                entry.charBotMedium = _networkedPrefab!;
                entry.charBotHard   = _networkedPrefab!;
                entry.charBotExpert = _networkedPrefab!;

                int len = Math.Max(bots.Length, _def.CharId + 1);
                var grown = new Il2CppReferenceArray<CharacterBotPrefabs>((long)len);
                for (int i = 0; i < bots.Length; i++) grown[i] = bots[i];
                grown[_def.CharId] = entry;
                gnm.charBotPrefabsByCharId = grown;
                LoggerInstance.Msg($"[M1] charBotPrefabsByCharId[{_def.CharId}] populated via {src} (len {bots.Length}->{len}).");
            }
            catch (Exception e) { LoggerInstance.Warning($"[M1] EnsureBotPrefabEntry via {src}: {e.Message}"); }
        }

        // STEP 6 — add to NetworkPrefabLibrary.InstantiatedPrefabs so the native client/server loops register it.
        private void InjectIntoPrefabLibrary(GameNetworkManager gnm, string src)
        {
            if (IsNull(_networkedPrefab) || _libraryInjected) return;
            NetworkPrefabLibrary lib = gnm.networkPrefabLibrary;
            if (IsNull(lib)) return;

            Il2CppReferenceArray<GameObject> arr = lib.InstantiatedPrefabs;
            int len = arr?.Length ?? 0;
            for (int i = 0; i < len; i++) if (arr![i] == _networkedPrefab) { _libraryInjected = true; return; }

            var grown = new Il2CppReferenceArray<GameObject>((long)(len + 1));
            for (int i = 0; i < len; i++) grown[i] = arr![i];
            grown[len] = _networkedPrefab!;
            lib.InstantiatedPrefabs = grown;
            _libraryInjected = true;
            LoggerInstance.Msg($"[M1] added to InstantiatedPrefabs via {src} (len {len}->{len + 1}).");
        }

        // STEP 7 — explicit Mirror registration when a peer is already active (race guard).
        //   client: NetworkClient.RegisterPrefab(prefab, assetId) + NetworkPrefabPool.ClientCreate
        //   server: NetworkServer reads assetId from the identity on Spawn; pool ServerCreate as backstop.
        private void EnsureMirrorRegistration(GameNetworkManager gnm, string src)
        {
            if (IsNull(_networkedPrefab)) return;

            // belt-and-suspenders: keep base NetworkManager.spawnPrefabs in sync too.
            try
            {
                NetworkManager nm = gnm.Cast<NetworkManager>();
                var list = nm.spawnPrefabs;
                if (list != null)
                {
                    bool found = false;
                    for (int i = 0; i < list.Count; i++) if (list[i] == _networkedPrefab) { found = true; break; }
                    if (!found) list.Add(_networkedPrefab!);
                }
            }
            catch (Exception e) { LoggerInstance.Warning($"[M1] spawnPrefabs append via {src}: {e.Message}"); }

            bool clientActive = false, serverActive = false;
            try { clientActive = NetworkClient.active; } catch { }
            try { serverActive = NetworkServer.active; } catch { }

            if (clientActive)
            {
                try { NetworkClient.RegisterPrefab(_networkedPrefab!, _def.AssetId); }
                catch (Exception e) { LoggerInstance.Warning($"[M1] NetworkClient.RegisterPrefab via {src}: {e.Message}"); }
            }

            // pool registration (mirrors the proven path: ClientCreate when client, ServerCreate when server).
            try
            {
                var cfg = new PoolConfig
                {
                    prefab = _networkedPrefab!,
                    initialSizeServer = 1,
                    initialSizeClient = 1,
                    resizeStrategy = ResizeStrategy.Increment
                };
                if (clientActive) { try { NetworkPrefabPool.ClientCreate(cfg); } catch (Exception e) { LoggerInstance.Warning($"[M1] ClientCreate via {src}: {e.Message}"); } }
                if (serverActive) { try { NetworkPrefabPool.ServerCreate(cfg); } catch (Exception e) { LoggerInstance.Warning($"[M1] ServerCreate via {src}: {e.Message}"); } }
            }
            catch (Exception e) { LoggerInstance.Warning($"[M1] pool create via {src}: {e.Message}"); }
        }

        // ========================================================================================
        // STEP 8 — UI CharacterConfiguration row + AvailableCharacterIds (client UI; harmless on server)
        // ========================================================================================
        internal void EnsureUiRow(UICharactersConfiguration cfg, string src)
        {
            try
            {
                if (IsNull(cfg)) return;
                Il2CppReferenceArray<CharacterConfiguration> chars = cfg._characters;
                if (chars == null) return;

                for (int i = 0; i < chars.Length; i++)
                    if (chars[i] != null && chars[i].charId == _def.CharId) { PushAvailability(cfg); return; }

                CharacterConfiguration baseRow = FindRowByCharId(chars, _def.BaseCharId) ?? chars[0];
                if (baseRow == null) return;

                var row = new CharacterConfiguration
                {
                    name = _def.Name,
                    charId = _def.CharId,
                    enabledInLobby = true,
                    enabledInDevLobby = true,
                    descriptionTranslationKey = baseRow.descriptionTranslationKey,
                    Color = baseRow.Color,
                    UIAccentColor = baseRow.UIAccentColor,
                    LobbyBackground = baseRow.LobbyBackground,
                    FullSprite = baseRow.FullSprite,
                    StandingSprite = baseRow.StandingSprite,
                    IconSprite = baseRow.IconSprite,
                    smallSprite = baseRow.smallSprite,
                    CircleIcon = baseRow.CircleIcon,
                    SquareIcon = baseRow.SquareIcon,
                    SquareSmallIcon = baseRow.SquareSmallIcon,
                    DefaultSkin = baseRow.DefaultSkin,
                    abilityIconColor = baseRow.abilityIconColor,
                    abilityBGColor = baseRow.abilityBGColor,
                    titleTextColor = baseRow.titleTextColor,
                    ability1 = baseRow.ability1,
                    ability2 = baseRow.ability2,
                    ability3 = baseRow.ability3,
                    ability4 = baseRow.ability4,
                };

                // M3c UI polish (low-risk, asset-free): theme the charId-15 ability HUD with Medusa's green
                // palette. NOTE: distinct authentic per-ability ICON SPRITES are NOT swapped — they do not
                // exist in medusa.bundle (the proven old mod also copied the base char's ability icon, and
                // the Medusa portrait sprites are external PNGs loaded via ImageConversion, not bundle Sprite
                // assets). The base ability icon shapes are retained but recolored to Medusa green.
                try { row.abilityIconColor = new Color(0.30f, 0.95f, 0.42f, 1f); } catch { }
                try { row.abilityBGColor   = new Color(0.05f, 0.20f, 0.10f, 0.95f); } catch { }
                try { row.titleTextColor   = new Color(0.78f, 1f, 0.62f, 1f); } catch { }

                var grown = new Il2CppReferenceArray<CharacterConfiguration>((long)(chars.Length + 1));
                for (int i = 0; i < chars.Length; i++) grown[i] = chars[i];
                grown[chars.Length] = row;
                cfg._characters = grown;
                PushAvailability(cfg);
                LoggerInstance.Msg($"[M1] UI row added (charId={_def.CharId}) via {src}; roster {chars.Length}->{grown.Length}.");
            }
            catch (Exception e) { LoggerInstance.Error($"[M1] EnsureUiRow({src}): {e}"); }
        }

        private void PushAvailability(UICharactersConfiguration cfg)
        {
            try
            {
                Il2CppReferenceArray<CharacterConfiguration> chars = cfg._characters;
                if (chars == null) return;
                var ids = new Il2CppStructArray<int>((long)chars.Length);
                for (int i = 0; i < chars.Length; i++) ids[i] = chars[i] != null ? chars[i].charId : -1;
                cfg.UpdateAvailableCharacterList(ids);
            }
            catch (Exception e) { LoggerInstance.Warning($"[M1] PushAvailability: {e.Message}"); }
        }

        // ---- helpers ----------------------------------------------------------------------------
        private static GameNetworkManager? FindGameNetworkManager()
        {
            try { var inst = GameNetworkManager.Instance; if (!IsNull(inst)) return inst; } catch { }
            try { return UObject.FindObjectOfType<GameNetworkManager>(); } catch { return null; }
        }

        private static CharacterConfiguration? FindRowByCharId(Il2CppReferenceArray<CharacterConfiguration> rows, int charId)
        {
            for (int i = 0; i < rows.Length; i++)
                if (rows[i] != null && rows[i].charId == charId) return rows[i];
            return null;
        }

        private static bool IsNull(UObject? o) => (UObject)o! == (UObject?)null;
        private static void TrySet(Action a) { try { a(); } catch { } }
    }
}

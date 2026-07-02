using System;
using System.Collections.Generic;
using System.IO;
using MelonLoader;
using HarmonyLib;
using UnityEngine;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Newtonsoft.Json.Linq;

using UObject = UnityEngine.Object;
using LevelRuntimeManager = Il2CppBAPBAP.Maps.LevelRuntimeManager;
using SerializedLevelHolder = Il2CppBAPBAP.Maps.SerializedLevelHolder;
using GameNetworkManager = Il2CppBAPBAP.Network.GameNetworkManager;
using MatchmakingGameData = Il2CppBAPBAP.Network.MatchmakingGameData;

namespace NetworkedCustomChar
{
    /// <summary>
    /// Custom-map loader (Phase 1 MVP). Mirrors the proven custom-CHARACTER pipeline:
    ///   - per-map JSON in UserData\CustomMaps\*.json  (CustomMapDef)
    ///   - an AssetBundle in UserData\CustomMaps\<Name>\<bundle> holding the baked
    ///     <Name>_SvData / <Name>_ClData SerializedLevelHolder prefab pair
    ///   - a Harmony hook on LevelRuntimeManager.LoadLevel that, for a custom level NAME,
    ///     loads the Sv/Cl holders from the bundle and calls the PUBLIC
    ///     LevelRuntimeManager.SpawnLevel(levelName, isServerOnly, isClientOnly, svData, clData)
    ///     directly, skipping the native Resources.LoadAsync path (which has no asset for our map).
    ///
    /// Verified from the decompile (Maps/LevelRuntimeManager.cs):
    ///   public void LoadLevel(string levelName, int levelId, bool isServerOnly, bool isClientOnly)
    ///   public void SpawnLevel(string levelName, bool isServerOnly, bool isClientOnly,
    ///                          SerializedLevelHolder svData, SerializedLevelHolder clData)
    ///   public void InitializeNavMesh(string levelName, bool isClientOnly)
    /// The LoadLevelCoroutine state machine loads svData/clData via Resources(.LoadAsync) from a
    /// levelName-derived dir, then calls SpawnLevel + InitializeNavMesh. We reproduce that with the
    /// bundle-loaded holders.
    ///
    /// RUNTIME RESIDUAL TO CONFIRM (flagged in the plan): the EXACT post-load call ordering inside
    /// LoadLevelCoroutine (whether SpawnLevel alone suffices or InitializeNavMesh / MMCache steps must
    /// also be invoked, and Sv-vs-Cl selection on dedicated host vs client). The hook logs every step so
    /// the first live load pins this down; ordering can then be adjusted without structural change.
    /// </summary>
    internal static class CustomMapLoader
    {
        public sealed class CustomMapDef
        {
            public int MapId = 5;
            public string Name = "CustomFlat";
            public string DisplayName = "CUSTOM FLAT";
            public string BundleFileName = "customflat.bundle";
            public string SvPrefabName = "CustomFlat_SvData";
            public string ClPrefabName = "CustomFlat_ClData";
            public bool Enabled = true;

            // LIVE-BASE approach (sidesteps the script-dead-bundle wall): the Resources key of a SHIPPED map
            // whose SerializedLevelHolder binds to the runtime Il2Cpp type. We load THIS live holder via
            // Resources.Load (not the script-stubbed bundle), optionally mutate its public spawnPoints /
            // mapSettings from config, and hand it to SpawnLevel. Default = blank_test (smallest shipped map).
            // Keys are the folder/asset under Assets/Resources/ (no extension), e.g.
            //   levels/maps/blank_test_bakedata/Blank_Test_SvData
            public string BaseSvResource = "levels/maps/blank_test_bakedata/Blank_Test_SvData";
            public string BaseClResource = "levels/maps/blank_test_bakedata/Blank_Test_ClData";

            // Config-driven data mutations applied to the LIVE base holder (the map-maker emits these).
            // SpawnPoints: world positions to place the holder's spawnPoints[] at. If empty, spawns are left
            // as the base map's. Format in JSON: "spawnPoints": [[x,y,z],[x,y,z],...].
            public List<float[]> SpawnPoints = new List<float[]>();

            // MapSettings mutations applied to the live holder's _serializedLevel.mapSettings. Empty => unchanged.
            public string MapSettingsDisplayName = "";

            // Relative bundle path the resolver uses: "<Name>\<BundleFileName>".
            public string BundleRel => Name + "\\" + BundleFileName;
        }

        private static readonly List<CustomMapDef> _defs = new List<CustomMapDef>();
        private static readonly Dictionary<string, CustomMapDef> _byLevelName =
            new Dictionary<string, CustomMapDef>(StringComparer.OrdinalIgnoreCase);

        private static Il2CppAssetBundle? _bundle;        // single active map bundle (MVP: one custom map)
        private static string? _loadedBundleForMap;
        private static bool _initialized;

        private static bool IsNull(UObject? o) => (UObject)o! == (UObject?)null;
        private static void Msg(string m) => MelonLogger.Msg($"[MAP] {m}");
        private static void Warn(string m) => MelonLogger.Warning($"[MAP] {m}");

        /// <summary>Load configs + install the load hooks + diagnostic probes. Call once at mod init on BOTH peers.</summary>
        public static void Init(HarmonyLib.Harmony harmony)
        {
            if (_initialized) return;
            _initialized = true;
            try
            {
                LoadConfigs();
                if (_defs.Count == 0) { Msg("no custom map definitions found; map loader idle."); return; }

                var bf = System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic;

                // PRIMARY hook: synchronous LoadLevel (handles the custom map by feeding SpawnLevel).
                var loadLevel = AccessTools.Method(typeof(LevelRuntimeManager), "LoadLevel");
                if (loadLevel != null)
                    harmony.Patch(loadLevel, prefix: new HarmonyMethod(typeof(CustomMapLoader).GetMethod(nameof(LoadLevel_Prefix), bf)));
                else Warn("LevelRuntimeManager.LoadLevel not found.");

                // PROBE 1: LoadLevelCoroutine — the IEnumerator path the headless match-host likely uses.
                // We log when it fires + its args; if it carries our custom level name we ALSO handle it here
                // (load bundle -> SpawnLevel) and skip the native coroutine, since the sync LoadLevel hook may
                // never fire on the dedicated host.
                var loadCoro = AccessTools.Method(typeof(LevelRuntimeManager), "LoadLevelCoroutine");
                if (loadCoro != null)
                    harmony.Patch(loadCoro, prefix: new HarmonyMethod(typeof(CustomMapLoader).GetMethod(nameof(LoadLevelCoroutine_Prefix), bf)));
                else Warn("LevelRuntimeManager.LoadLevelCoroutine not found.");

                // PROBE 2: SpawnLevel — log every native level spawn (levelName + whether holders are non-null),
                // so a normal blank_test match reveals the exact call shape the host uses.
                var spawn = AccessTools.Method(typeof(LevelRuntimeManager), "SpawnLevel");
                if (spawn != null)
                    harmony.Patch(spawn, prefix: new HarmonyMethod(typeof(CustomMapLoader).GetMethod(nameof(SpawnLevel_Probe), bf)));

                // LATCH: read the match's MapId from OnServerMatchSetup so SpawnLevel knows which custom map.
                var setup = AccessTools.Method(typeof(GameNetworkManager), "OnServerMatchSetup");
                if (setup != null)
                    harmony.Patch(setup, prefix: new HarmonyMethod(typeof(CustomMapLoader).GetMethod(nameof(OnServerMatchSetup_Prefix), bf)));
                else Warn("GameNetworkManager.OnServerMatchSetup not found (mapId latch unavailable).");

                foreach (var d in _defs)
                    Msg($"custom map registered: name='{d.Name}' mapId={d.MapId} bundle='{d.BundleRel}' " +
                        $"sv='{d.SvPrefabName}' cl='{d.ClPrefabName}' enabled={d.Enabled}.");
                Msg($"hooks installed (LoadLevel={loadLevel!=null} LoadLevelCoroutine={loadCoro!=null} SpawnLevel={spawn!=null} OnServerMatchSetup={setup!=null}) for {_byLevelName.Count} custom level name(s).");
            }
            catch (Exception ex) { Warn($"Init failed: {ex.Message}"); }
        }

        // PROBE: log every LoadLevelCoroutine call; handle the custom map if the sync path didn't.
        private static bool LoadLevelCoroutine_Prefix(LevelRuntimeManager __instance, string levelName, int levelId, bool isServerOnly, bool isClientOnly)
        {
            try
            {
                Msg($"PROBE LoadLevelCoroutine: name='{levelName}' id={levelId} svOnly={isServerOnly} clOnly={isClientOnly}.");
                if (!_byLevelName.TryGetValue(levelName ?? "", out CustomMapDef def)) return true;
                if (TryHandleCustomMap(__instance, def, levelName!, isServerOnly, isClientOnly))
                {
                    Msg($"handled custom map '{def.Name}' via LoadLevelCoroutine; skipping native coroutine.");
                    return false;
                }
                return true;
            }
            catch (Exception ex) { Warn($"LoadLevelCoroutine_Prefix: {ex.Message}; native fallback."); return true; }
        }

        // PROBE + FIX: native SpawnLevel. The dedicated host resolves the bootstrap mapId to a level NAME
        // via an IL2CPP path that does NOT honor our patched GameMode.levelNames (observed: mapId 5 still
        // arrives here as "Map2_BazaarCity 3"). So when the active bootstrap mapId is one of our custom
        // maps, REWRITE the levelName arg + supply the bundle holders, then let the native SpawnLevel run
        // with the corrected inputs. CurrentBootstrapMapId is latched by the bootstrap listener (set via
        // CustomMapLoader.SetBootstrapMapId from the /setup-game payload in the BapCustomServerMelon mod).
        private static bool SpawnLevel_Probe(LevelRuntimeManager __instance, ref string levelName,
            bool isServerOnly, bool isClientOnly, ref SerializedLevelHolder svData, ref SerializedLevelHolder clData)
        {
            try
            {
                Msg($"PROBE SpawnLevel: name='{levelName}' bootstrapMapId={CurrentBootstrapMapId} svOnly={isServerOnly} clOnly={isClientOnly} svNull={IsNull(svData)} clNull={IsNull(clData)}.");

                CustomMapDef? def = null;
                if (CurrentBootstrapMapId > 0) foreach (var d in _defs) if (d.MapId == CurrentBootstrapMapId) { def = d; break; }
                if (def == null && _byLevelName.TryGetValue(levelName ?? "", out var byName)) def = byName;
                if (def == null) return true;  // not a custom map -> native SpawnLevel unchanged

                // PRIMARY: load a LIVE shipped-map holder via Resources.Load. Its SerializedLevelHolder binds
                // to the runtime Il2Cpp type (unlike a bundled prefab from the script-stubbed ExportedProject,
                // whose holder is a dead missing-script). This proves custom-map SELECTION end-to-end; custom
                // DATA (spawn points / mapSettings mutation from config) is layered on top of this live holder.
                SerializedLevelHolder? sv = LoadLiveHolder(def.BaseSvResource);
                SerializedLevelHolder? cl = LoadLiveHolder(def.BaseClResource);

                // FALLBACK: a bundled holder (only useful once we have a project whose scripts bind).
                if (IsNull(sv)) { if (EnsureBundle(def)) sv = LoadHolder(def.SvPrefabName); }
                if (IsNull(cl)) { if (EnsureBundle(def)) cl = LoadHolder(def.ClPrefabName); }

                if (IsNull(sv)) { Warn($"SpawnLevel: no live/bundled sv holder for '{def.Name}'; native fallback."); return true; }

                // Apply config-driven data mutations to the LIVE holder (additive customization).
                try { MutateHolder(sv!, def); } catch (Exception mex) { Warn($"MutateHolder: {mex.Message}"); }

                // Rewrite the inputs in place: correct name + our holders. Preserve the host's sv/cl-null
                // pattern (dedicated host passes clData=null) — only override non-null sides.
                levelName = def.Name;
                svData = sv!;
                if (!IsNull(cl) && !IsNull(clData)) clData = cl!;
                Msg($"SpawnLevel REWRITE -> name='{def.Name}' mapId={def.MapId} svLive={!IsNull(sv)} clLive={!IsNull(cl)}; native SpawnLevel will build it.");
                return true;  // run native SpawnLevel with corrected args
            }
            catch (Exception ex) { Warn($"SpawnLevel_Probe: {ex.Message}; native unchanged."); return true; }
        }

        /// <summary>Latched by the bootstrap listener (BapCustomServerMelon) from the /setup-game
        /// MatchmakingGameData.MapId, so the SpawnLevel hook knows which custom map (if any) this match is.</summary>
        public static int CurrentBootstrapMapId = 0;
        public static void SetBootstrapMapId(int mapId)
        {
            CurrentBootstrapMapId = mapId;
            try { MelonLogger.Msg($"[MAP] bootstrap mapId latched = {mapId}."); } catch { }
        }

        // Self-contained latch: hook GameNetworkManager.OnServerMatchSetup(MatchmakingGameData) so we read
        // the match's MapId directly (no cross-mod dependency on the BapCustomServerMelon bootstrap listener).
        // Fires on the dedicated host right before the level loads.
        private static void OnServerMatchSetup_Prefix(MatchmakingGameData mgd)
        {
            try { if (mgd != null) SetBootstrapMapId(mgd.mapId); }
            catch (Exception ex) { Warn($"OnServerMatchSetup_Prefix: {ex.Message}"); }
        }

        // ---- config (mirror CustomCharConfig: scan UserData\CustomMaps\*.json) ----------------------
        private static void LoadConfigs()
        {
            foreach (string dir in CandidateConfigDirs())
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(dir) || !Directory.Exists(dir)) continue;
                    string[] files = Directory.GetFiles(dir, "*.json");
                    Array.Sort(files, (a, b) => string.CompareOrdinal(Path.GetFileName(a), Path.GetFileName(b)));
                    foreach (string file in files)
                    {
                        CustomMapDef? def = ParseFile(file);
                        if (def == null || !def.Enabled) continue;
                        _defs.Add(def);
                        if (!string.IsNullOrWhiteSpace(def.Name)) _byLevelName[def.Name] = def;
                    }
                    if (_defs.Count > 0) break;   // first dir with defs wins (peer-deterministic)
                }
                catch (Exception ex) { Warn($"scan '{dir}': {ex.Message}"); }
            }
        }

        private static IEnumerable<string> CandidateConfigDirs()
        {
            yield return Path.Combine(AppContext.BaseDirectory, "UserData", "CustomMaps");
            string? root = SafeGameRoot();
            if (!string.IsNullOrWhiteSpace(root)) yield return Path.Combine(root!, "UserData", "CustomMaps");
            string cwd = SafeCwd();
            if (!string.IsNullOrWhiteSpace(cwd)) yield return Path.Combine(cwd, "UserData", "CustomMaps");
        }

        private static CustomMapDef? ParseFile(string path)
        {
            try
            {
                string text = File.ReadAllText(path);
                if (string.IsNullOrWhiteSpace(text)) return null;
                JObject jo = JObject.Parse(text);
                var d = new CustomMapDef();
                d.MapId          = GetInt(jo, "mapId", d.MapId);
                d.Name           = GetStr(jo, "name", d.Name);
                d.DisplayName    = GetStr(jo, "displayName", d.DisplayName);
                d.BundleFileName = GetStr(jo, "bundleFileName", d.BundleFileName);
                d.SvPrefabName   = GetStr(jo, "svPrefabName", d.SvPrefabName);
                d.ClPrefabName   = GetStr(jo, "clPrefabName", d.ClPrefabName);
                d.BaseSvResource = GetStr(jo, "baseSvResource", d.BaseSvResource);
                d.BaseClResource = GetStr(jo, "baseClResource", d.BaseClResource);
                d.MapSettingsDisplayName = GetStr(jo, "mapSettingsDisplayName", d.MapSettingsDisplayName);
                d.Enabled        = GetBool(jo, "enabled", d.Enabled);
                // spawnPoints: [[x,y,z],...] -> List<float[]>
                try
                {
                    if (jo["spawnPoints"] is Newtonsoft.Json.Linq.JArray sps)
                    {
                        var list = new List<float[]>();
                        foreach (var e in sps)
                        {
                            if (e is Newtonsoft.Json.Linq.JArray coord && coord.Count >= 3)
                                list.Add(new[] { (float)coord[0], (float)coord[1], (float)coord[2] });
                        }
                        if (list.Count > 0) d.SpawnPoints = list;
                    }
                }
                catch (Exception sex) { Warn($"parse spawnPoints in '{path}': {sex.Message}"); }
                return d;
            }
            catch (Exception ex) { Warn($"parse '{path}': {ex.Message}"); return null; }
        }

        // ---- the hook: feed bundle-loaded holders to the public SpawnLevel, skip Resources ----------
        private static bool LoadLevel_Prefix(LevelRuntimeManager __instance, string levelName, int levelId, bool isServerOnly, bool isClientOnly)
        {
            try
            {
                if (!_byLevelName.TryGetValue(levelName ?? "", out CustomMapDef def))
                    return true;  // not a custom map -> run the native loader

                Msg($"intercept LoadLevel: name='{levelName}' id={levelId} svOnly={isServerOnly} clOnly={isClientOnly}.");
                return !TryHandleCustomMap(__instance, def, levelName!, isServerOnly, isClientOnly);  // handled => skip native
            }
            catch (Exception ex) { Warn($"LoadLevel_Prefix: {ex.Message}; native fallback."); return true; }
        }

        // Shared: load Sv/Cl holders from the bundle and drive SpawnLevel + nav init. Returns true if the
        // custom map was fully handled (caller skips the native path); false to fall back to native.
        private static bool TryHandleCustomMap(LevelRuntimeManager mgr, CustomMapDef def, string levelName, bool isServerOnly, bool isClientOnly)
        {
            if (!EnsureBundle(def)) { Warn($"bundle unavailable for '{def.Name}'; native fallback."); return false; }

            SerializedLevelHolder? sv = LoadHolder(def.SvPrefabName);
            SerializedLevelHolder? cl = LoadHolder(def.ClPrefabName);
            if (IsNull(sv) || IsNull(cl))
            {
                Warn($"missing holder(s) sv='{def.SvPrefabName}'({!IsNull(sv)}) cl='{def.ClPrefabName}'({!IsNull(cl)}); native fallback.");
                return false;
            }

            mgr.SpawnLevel(levelName, isServerOnly, isClientOnly, sv, cl);
            Msg($"SpawnLevel invoked for custom map '{def.Name}'.");

            // Mirror the coroutine's post-load nav init (exact ordering is the flagged runtime residual;
            // guarded so a signature/order mismatch logs rather than aborts the load).
            try { mgr.InitializeNavMesh(levelName, isClientOnly); Msg("InitializeNavMesh invoked."); }
            catch (Exception nex) { Warn($"InitializeNavMesh: {nex.Message}"); }

            return true;
        }

        // ---- bundle load (reuse the proven MedusaVisualGraft accessors) -----------------------------
        private static bool EnsureBundle(CustomMapDef def)
        {
            if (_bundle != null && _loadedBundleForMap == def.Name) return true;
            string path = ResolveBundlePath(def);
            if (string.IsNullOrEmpty(path) || !File.Exists(path))
            {
                Warn($"map bundle not found for '{def.Name}' (looked at '{path}').");
                return false;
            }
            try
            {
                _bundle = Il2CppAssetBundleManager.LoadFromFile(path);
                if (_bundle == null) { Warn($"LoadFromFile returned null for '{path}'."); return false; }
                _loadedBundleForMap = def.Name;
                Msg($"loaded map bundle '{path}' ({new FileInfo(path).Length} bytes).");
                return true;
            }
            catch (Exception ex) { Warn($"LoadFromFile('{path}'): {ex.Message}"); return false; }
        }

        // Load a LIVE SerializedLevelHolder from a SHIPPED map via Resources.Load (binds to the runtime
        // Il2Cpp type, unlike a script-stubbed bundle prefab). Returns null if the resource/holder is absent.
        private static SerializedLevelHolder? LoadLiveHolder(string resourceKey)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceKey)) return null;
                Il2CppSystem.Type goType = Il2CppType.Of<GameObject>();
                UObject? res = Resources.Load(resourceKey, goType);
                if (IsNull(res)) { Msg($"LoadLiveHolder('{resourceKey}'): Resources.Load miss."); return null; }
                GameObject go = ((Il2CppObjectBase)res!).Cast<GameObject>();
                SerializedLevelHolder h = go.GetComponent<SerializedLevelHolder>();
                if (IsNull(h)) h = go.GetComponentInChildren<SerializedLevelHolder>(true);
                if (IsNull(h)) { Warn($"LoadLiveHolder('{resourceKey}'): loaded but no SerializedLevelHolder."); return null; }
                Msg($"LoadLiveHolder('{resourceKey}'): live holder OK (go='{SafeGoName(go)}').");
                return h;
            }
            catch (Exception ex) { Warn($"LoadLiveHolder('{resourceKey}'): {ex.Message}"); return null; }
        }

        // Apply config-driven data mutations to a LIVE holder. Currently: reposition the holder's existing
        // spawnPoints[] GameObjects to the config's world positions (the simplest verifiable customization,
        // and the data the map-maker emits first). Geometry/zone/tile edits layer on here next.
        private static void MutateHolder(SerializedLevelHolder holder, CustomMapDef def)
        {
            try
            {
                int spawnCount = 0;
                Il2CppArrayBase<GameObject>? sp = null;
                try { var arr = holder.spawnPoints; if (arr != null) { sp = (Il2CppArrayBase<GameObject>)(object)arr; spawnCount = sp.Length; } } catch { }
                string ms = "absent";
                try { var lvl = holder._serializedLevel; if (lvl != null && lvl.mapSettings != null) ms = "present"; } catch { }

                // MapSettings mutation: set displayName from config (proves the mapSettings edit path).
                bool msEdited = false;
                if (!string.IsNullOrEmpty(def.MapSettingsDisplayName))
                {
                    try
                    {
                        var lvl = holder._serializedLevel;
                        if (lvl != null && lvl.mapSettings != null)
                        { lvl.mapSettings.displayName = def.MapSettingsDisplayName; msEdited = true; }
                    }
                    catch (Exception mex) { Warn($"mapSettings.displayName: {mex.Message}"); }
                }

                int moved = 0;
                if (def.SpawnPoints != null && def.SpawnPoints.Count > 0 && sp != null)
                {
                    int n = Math.Min(def.SpawnPoints.Count, spawnCount);
                    for (int i = 0; i < n; i++)
                    {
                        float[] p = def.SpawnPoints[i];
                        if (p == null || p.Length < 3) continue;
                        GameObject go = sp[i];
                        if (IsNull(go)) continue;
                        try { go.transform.position = new Vector3(p[0], p[1], p[2]); moved++; }
                        catch (Exception pex) { Warn($"spawn[{i}] move: {pex.Message}"); }
                    }
                }
                Msg($"MutateHolder '{def.Name}': spawnPoints={spawnCount} mapSettings={ms} configSpawns={def.SpawnPoints?.Count ?? 0} moved={moved} displayNameEdited={msEdited}.");
            }
            catch (Exception ex) { Warn($"MutateHolder('{def.Name}'): {ex.Message}"); }
        }

        private static SerializedLevelHolder? LoadHolder(string assetName)
        {
            try
            {
                if (_bundle == null || string.IsNullOrEmpty(assetName)) return null;
                Il2CppSystem.Type goType = Il2CppType.Of<GameObject>();
                // Try the short asset name first; bundles built from a *_bakedata folder index assets by
                // full path, so fall back to a case-insensitive contains-scan over GetAllAssetNames()
                // (the proven MedusaVisualGraft pattern) which matches
                // "Assets/Resources/levels/maps/<map>_bakedata/<assetName>.prefab".
                UObject? val = _bundle.LoadAsset(assetName, goType);
                if (IsNull(val))
                {
                    var names = _bundle.GetAllAssetNames();
                    int count = names != null ? ((Il2CppArrayBase<string>)(object)names).Length : -1;
                    Msg($"LoadHolder('{assetName}'): short-name miss; bundle exposes {count} asset name(s).");
                    if (names != null)
                        for (int i = 0; i < ((Il2CppArrayBase<string>)(object)names).Length; i++)
                        {
                            string n = ((Il2CppArrayBase<string>)(object)names)[i];
                            Msg($"  bundle asset[{i}]='{n}'");   // diagnostic: see actual indexed names + casing
                            if (n != null && n.IndexOf(assetName, StringComparison.OrdinalIgnoreCase) >= 0)
                            { val = _bundle.LoadAsset(n, goType); if (!IsNull(val)) { Msg($"  matched -> '{n}'"); break; } }
                        }
                }
                if (IsNull(val)) { Warn($"asset '{assetName}' not loadable from bundle."); return null; }
                GameObject go = ((Il2CppObjectBase)val!).Cast<GameObject>();
                SerializedLevelHolder h = go.GetComponent<SerializedLevelHolder>();
                if (IsNull(h)) h = go.GetComponentInChildren<SerializedLevelHolder>(true);
                if (IsNull(h))
                {
                    // Diagnostic: the prefab loaded but has no live SerializedLevelHolder. Most likely the
                    // map prefab was authored in the script-STUBBED ExportedProject, so its holder component
                    // is a missing-script that doesn't bind to the runtime Il2Cpp type. Log the components.
                    int compCount = 0;
                    try { compCount = go.GetComponentsInChildren<Component>(true).Length; } catch { }
                    Warn($"prefab '{assetName}' loaded (name='{SafeGoName(go)}') but NO live SerializedLevelHolder (childComps={compCount}). " +
                         $"Likely a missing-script holder from the script-stubbed ExportedProject.");
                    return null;
                }
                return h;
            }
            catch (Exception ex) { Warn($"LoadHolder('{assetName}'): {ex.Message}"); return null; }
        }

        private static string ResolveBundlePath(CustomMapDef def)
        {
            foreach (string root in CandidateRoots())
            {
                if (string.IsNullOrEmpty(root)) continue;
                var rels = new List<string>
                {
                    Path.Combine("UserData", def.BundleRel),
                    Path.Combine("UserData", "CustomMaps", def.Name, def.BundleFileName),
                    Path.Combine("UserData", "CustomMaps", def.BundleFileName),
                    Path.Combine("UserData", def.BundleFileName),
                };
                foreach (string rel in rels)
                {
                    try { string p = Path.Combine(root, rel); if (File.Exists(p)) return p; } catch { }
                }
            }
            return "";
        }

        private static List<string> CandidateRoots()
        {
            var roots = new List<string>();
            try { string r = MelonLoader.Utils.MelonEnvironment.GameRootDirectory; if (!string.IsNullOrEmpty(r)) roots.Add(r); } catch { }
            try { string r = AppDomain.CurrentDomain.BaseDirectory; if (!string.IsNullOrEmpty(r)) roots.Add(r); } catch { }
            try { string r = Directory.GetCurrentDirectory(); if (!string.IsNullOrEmpty(r)) roots.Add(r); } catch { }
            return roots;
        }

        private static string SafeGameRoot() { try { return MelonLoader.Utils.MelonEnvironment.GameRootDirectory; } catch { return ""; } }
        private static string SafeGoName(GameObject go) { try { return IsNull(go) ? "<null>" : go.name; } catch { return "?"; } }
        private static string SafeCwd() { try { return Directory.GetCurrentDirectory(); } catch { return ""; } }

        private static int GetInt(JObject o, string k, int d) { var t = o[k]; return (t != null && t.Type != JTokenType.Null) ? (int)t : d; }
        private static bool GetBool(JObject o, string k, bool d) { var t = o[k]; return (t != null && t.Type != JTokenType.Null) ? (bool)t : d; }
        private static string GetStr(JObject o, string k, string d) { var t = o[k]; return (t != null && t.Type != JTokenType.Null) ? ((string?)t ?? d) : d; }
    }
}

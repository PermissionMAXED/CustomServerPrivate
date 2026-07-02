#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Minimal custom-map authoring window for the live-holder map pipeline.
///
/// This does not try to author a standalone SerializedLevelHolder prefab: the exported project has
/// script-stubbed BAPBAP components, so bundled holders do not bind to the runtime Il2Cpp type. Instead the
/// runtime mod loads a shipped live holder and applies JSON mutations. This window emits that JSON and can
/// clone the tiny blank_test bakedata folder so MapBundleBuilder still produces a parity bundle shell.
/// </summary>
public sealed class MapMakerWindow : EditorWindow
{
    private const string DefaultGameRoot = @"C:\Users\Administrator\Downloads\CustomServer\Spiel\Battleroyalebuild";
    private const string DefaultDeployRoot = @"C:\Users\Administrator\Downloads\CustomServer\deployment\netcustomchar-deploy\stage\game";

    [Serializable]
    private sealed class MapConfig
    {
        public int mapId = 5;
        public string name = "CustomFlat";
        public string displayName = "CUSTOM FLAT";
        public string bundleFileName = "customflat.bundle";
        public string svPrefabName = "CustomFlat_SvData";
        public string clPrefabName = "CustomFlat_ClData";
        public string baseSvResource = "levels/maps/blank_test_bakedata/Blank_Test_SvData";
        public string baseClResource = "levels/maps/blank_test_bakedata/Blank_Test_ClData";
        public string mapSettingsDisplayName = "CUSTOM FLAT ARENA";
        public int mapType = 0;
        public bool customZoneRounds = true;
        public bool excludeNavMeshFloor = false;
        public bool excludeWaterPerimeter = false;
        public int[] mapSize = { 48, 48 };
        public List<Vector3> spawnPoints = new List<Vector3> { new Vector3(10f, 0f, 10f), new Vector3(-10f, 0f, -10f) };
        public bool enabled = true;
    }

    private readonly MapConfig cfg = new MapConfig();
    private string gameRoot = DefaultGameRoot;
    private string deployRoot = DefaultDeployRoot;
    private Vector2 scroll;
    private int selectedSpawn = -1;
    private bool showSceneHandles = true;

    [MenuItem("BAPBAP/Custom Map Maker")]
    public static void Open() => GetWindow<MapMakerWindow>("Custom Map Maker");

    private void OnEnable() => SceneView.duringSceneGui += OnSceneGUI;
    private void OnDisable() => SceneView.duringSceneGui -= OnSceneGUI;

    private void OnGUI()
    {
        scroll = EditorGUILayout.BeginScrollView(scroll);
        EditorGUILayout.LabelField("BAPBAP Custom Map Maker", EditorStyles.boldLabel);
        EditorGUILayout.HelpBox("Phase 2 MVP: emits JSON mutations for the live-holder custom-map pipeline. Geometry/tile painting can layer on this once runtime tile mutation is implemented.", MessageType.Info);

        DrawGeneral();
        DrawMapSettings();
        DrawSpawns();
        DrawOutput();

        EditorGUILayout.Space(12);
        using (new EditorGUILayout.HorizontalScope())
        {
            if (GUILayout.Button("Save JSON to Local Game", GUILayout.Height(32))) SaveJson(gameRoot);
            if (GUILayout.Button("Save JSON to Deploy Stage", GUILayout.Height(32))) SaveJson(deployRoot);
        }
        using (new EditorGUILayout.HorizontalScope())
        {
            if (GUILayout.Button("Save JSON to Both", GUILayout.Height(32))) { SaveJson(gameRoot); SaveJson(deployRoot); }
            if (GUILayout.Button("Ensure Bakedata Clone", GUILayout.Height(32))) EnsureBakedataClone();
        }
        if (GUILayout.Button("Build Bundle Shell", GUILayout.Height(32))) BuildBundleShell();

        EditorGUILayout.EndScrollView();
    }

    private void DrawGeneral()
    {
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Identity", EditorStyles.boldLabel);
        cfg.mapId = EditorGUILayout.IntField("Map Id", cfg.mapId);
        cfg.name = EditorGUILayout.TextField("Name", cfg.name);
        cfg.displayName = EditorGUILayout.TextField("Display Name", cfg.displayName);
        cfg.enabled = EditorGUILayout.Toggle("Enabled", cfg.enabled);
        cfg.bundleFileName = EditorGUILayout.TextField("Bundle File", cfg.bundleFileName);
        cfg.svPrefabName = EditorGUILayout.TextField("Sv Prefab Name", cfg.svPrefabName);
        cfg.clPrefabName = EditorGUILayout.TextField("Cl Prefab Name", cfg.clPrefabName);
        cfg.baseSvResource = EditorGUILayout.TextField("Base Sv Resource", cfg.baseSvResource);
        cfg.baseClResource = EditorGUILayout.TextField("Base Cl Resource", cfg.baseClResource);
    }

    private void DrawMapSettings()
    {
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Live MapSettings Mutations", EditorStyles.boldLabel);
        cfg.mapSettingsDisplayName = EditorGUILayout.TextField("MapSettings Display", cfg.mapSettingsDisplayName);
        cfg.mapType = EditorGUILayout.IntField("Map Type", cfg.mapType);
        cfg.customZoneRounds = EditorGUILayout.Toggle("Custom Zone Rounds", cfg.customZoneRounds);
        cfg.excludeNavMeshFloor = EditorGUILayout.Toggle("Exclude NavMesh Floor", cfg.excludeNavMeshFloor);
        cfg.excludeWaterPerimeter = EditorGUILayout.Toggle("Exclude Water Perimeter", cfg.excludeWaterPerimeter);
        using (new EditorGUILayout.HorizontalScope())
        {
            EditorGUILayout.PrefixLabel("Map Size");
            cfg.mapSize[0] = EditorGUILayout.IntField(cfg.mapSize[0]);
            cfg.mapSize[1] = EditorGUILayout.IntField(cfg.mapSize[1]);
        }
    }

    private void DrawSpawns()
    {
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Spawn Points", EditorStyles.boldLabel);
        showSceneHandles = EditorGUILayout.Toggle("Scene Handles", showSceneHandles);
        EditorGUILayout.HelpBox("Select a spawn row, then move its handle in Scene view. Shift-click in Scene view adds a spawn at the clicked ground-plane position.", MessageType.None);
        int remove = -1;
        for (int i = 0; i < cfg.spawnPoints.Count; i++)
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                bool selected = selectedSpawn == i;
                if (GUILayout.Toggle(selected, "", GUILayout.Width(18)) != selected) selectedSpawn = i;
                cfg.spawnPoints[i] = EditorGUILayout.Vector3Field("Spawn " + i, cfg.spawnPoints[i]);
                if (GUILayout.Button("Frame", GUILayout.Width(52))) { selectedSpawn = i; FrameSpawn(i); }
                if (GUILayout.Button("-", GUILayout.Width(28))) remove = i;
            }
        }
        if (remove >= 0)
        {
            cfg.spawnPoints.RemoveAt(remove);
            if (selectedSpawn >= cfg.spawnPoints.Count) selectedSpawn = cfg.spawnPoints.Count - 1;
        }
        if (GUILayout.Button("Add Spawn"))
        {
            cfg.spawnPoints.Add(Vector3.zero);
            selectedSpawn = cfg.spawnPoints.Count - 1;
            SceneView.RepaintAll();
        }
    }

    private void DrawOutput()
    {
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Output", EditorStyles.boldLabel);
        gameRoot = EditorGUILayout.TextField("Local Game Root", gameRoot);
        deployRoot = EditorGUILayout.TextField("Deploy Stage Root", deployRoot);
    }

    private void OnSceneGUI(SceneView view)
    {
        if (!showSceneHandles) return;

        Handles.color = new Color(0.2f, 1f, 0.35f, 0.9f);
        for (int i = 0; i < cfg.spawnPoints.Count; i++)
        {
            Vector3 p = cfg.spawnPoints[i];
            float size = HandleUtility.GetHandleSize(p) * 0.18f;
            Handles.color = i == selectedSpawn ? Color.yellow : new Color(0.2f, 1f, 0.35f, 0.9f);
            if (Handles.Button(p + Vector3.up * size, Quaternion.identity, size, size * 1.25f, Handles.SphereHandleCap))
            {
                selectedSpawn = i;
                Repaint();
            }
            Handles.Label(p + Vector3.up * (size * 2.2f), "Spawn " + i);

            EditorGUI.BeginChangeCheck();
            Vector3 next = Handles.PositionHandle(p, Quaternion.identity);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(this, "Move custom-map spawn");
                cfg.spawnPoints[i] = next;
                selectedSpawn = i;
                Repaint();
            }
        }

        Event e = Event.current;
        if (e.type == EventType.MouseDown && e.button == 0 && e.shift)
        {
            Ray ray = HandleUtility.GUIPointToWorldRay(e.mousePosition);
            Plane ground = new Plane(Vector3.up, Vector3.zero);
            if (ground.Raycast(ray, out float enter))
            {
                Undo.RecordObject(this, "Add custom-map spawn");
                cfg.spawnPoints.Add(ray.GetPoint(enter));
                selectedSpawn = cfg.spawnPoints.Count - 1;
                e.Use();
                Repaint();
            }
        }
    }

    private void FrameSpawn(int index)
    {
        if (index < 0 || index >= cfg.spawnPoints.Count || SceneView.lastActiveSceneView == null) return;
        SceneView.lastActiveSceneView.LookAt(cfg.spawnPoints[index], Quaternion.Euler(45f, 45f, 0f), 24f);
        SceneView.lastActiveSceneView.Repaint();
    }

    private void SaveJson(string root)
    {
        try
        {
            string mapsDir = Path.Combine(root, "UserData", "CustomMaps");
            Directory.CreateDirectory(mapsDir);
            string path = Path.Combine(mapsDir, cfg.name.ToLowerInvariant() + ".json");
            File.WriteAllText(path, BuildJson());
            AssetDatabase.Refresh();
            Debug.Log("[MapMakerWindow] wrote " + path);
        }
        catch (Exception ex) { Debug.LogError("[MapMakerWindow] SaveJson failed: " + ex); }
    }

    private string BuildJson()
    {
        using (var sw = new StringWriter())
        {
            sw.WriteLine("{");
            sw.WriteLine($"  \"mapId\": {cfg.mapId},");
            sw.WriteLine($"  \"name\": \"{Esc(cfg.name)}\",");
            sw.WriteLine($"  \"displayName\": \"{Esc(cfg.displayName)}\",");
            sw.WriteLine($"  \"bundleFileName\": \"{Esc(cfg.bundleFileName)}\",");
            sw.WriteLine($"  \"svPrefabName\": \"{Esc(cfg.svPrefabName)}\",");
            sw.WriteLine($"  \"clPrefabName\": \"{Esc(cfg.clPrefabName)}\",");
            sw.WriteLine($"  \"baseSvResource\": \"{Esc(cfg.baseSvResource)}\",");
            sw.WriteLine($"  \"baseClResource\": \"{Esc(cfg.baseClResource)}\",");
            sw.WriteLine($"  \"mapSettingsDisplayName\": \"{Esc(cfg.mapSettingsDisplayName)}\",");
            sw.WriteLine($"  \"mapType\": {cfg.mapType},");
            sw.WriteLine($"  \"customZoneRounds\": {JsonBool(cfg.customZoneRounds)},");
            sw.WriteLine($"  \"excludeNavMeshFloor\": {JsonBool(cfg.excludeNavMeshFloor)},");
            sw.WriteLine($"  \"excludeWaterPerimeter\": {JsonBool(cfg.excludeWaterPerimeter)},");
            sw.WriteLine($"  \"mapSize\": [ {cfg.mapSize[0]}, {cfg.mapSize[1]} ],");
            sw.WriteLine("  \"spawnPoints\": [");
            for (int i = 0; i < cfg.spawnPoints.Count; i++)
            {
                Vector3 p = cfg.spawnPoints[i];
                string comma = i == cfg.spawnPoints.Count - 1 ? "" : ",";
                sw.WriteLine($"    [ {F(p.x)}, {F(p.y)}, {F(p.z)} ]{comma}");
            }
            sw.WriteLine("  ],");
            sw.WriteLine($"  \"enabled\": {JsonBool(cfg.enabled)}");
            sw.WriteLine("}");
            return sw.ToString();
        }
    }

    private void BuildBundleShell()
    {
        try
        {
            EnsureBakedataClone();
            string bundleName = cfg.name.ToLowerInvariant();
            string bakedataRel = "Resources/levels/maps/" + bundleName + "_bakedata";
            string bakedataAbs = Path.Combine(Application.dataPath, bakedataRel);
            if (!Directory.Exists(bakedataAbs)) throw new DirectoryNotFoundException(bakedataAbs);

            int tagged = 0;
            foreach (string file in Directory.GetFiles(bakedataAbs, "*.*", SearchOption.TopDirectoryOnly)
                         .Where(p => !p.EndsWith(".meta", StringComparison.OrdinalIgnoreCase)))
            {
                string assetPath = "Assets/" + bakedataRel.Replace('\\', '/') + "/" + Path.GetFileName(file);
                var importer = AssetImporter.GetAtPath(assetPath);
                if (importer == null) continue;
                importer.assetBundleName = bundleName;
                importer.assetBundleVariant = string.Empty;
                tagged++;
            }
            if (tagged == 0) throw new InvalidOperationException("No assets tagged in " + bakedataRel);

            string outDir = Path.Combine(Directory.GetCurrentDirectory(), "MapMakerBundleOut-" + bundleName);
            Directory.CreateDirectory(outDir);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            var manifest = BuildPipeline.BuildAssetBundles(outDir, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneWindows);
            if (manifest == null) throw new InvalidOperationException("BuildAssetBundles returned null");

            string produced = Path.Combine(outDir, bundleName);
            if (!File.Exists(produced)) throw new FileNotFoundException("Expected bundle not found", produced);
            CopyBundleToRoots(produced);
            Debug.Log("[MapMakerWindow] built bundle shell " + produced);
        }
        catch (Exception ex) { Debug.LogError("[MapMakerWindow] BuildBundleShell failed: " + ex); }
    }

    private void CopyBundleToRoots(string produced)
    {
        foreach (string root in new[] { gameRoot, deployRoot })
        {
            if (string.IsNullOrWhiteSpace(root)) continue;
            string dstDir = Path.Combine(root, "UserData", "CustomMaps", cfg.name);
            Directory.CreateDirectory(dstDir);
            File.Copy(produced, Path.Combine(dstDir, cfg.bundleFileName), true);
        }
    }

    private void EnsureBakedataClone()
    {
        try
        {
            string maps = Path.Combine(Application.dataPath, "Resources", "levels", "maps");
            string src = Path.Combine(maps, "blank_test_bakedata");
            string dst = Path.Combine(maps, cfg.name.ToLowerInvariant() + "_bakedata");
            if (!Directory.Exists(src)) throw new DirectoryNotFoundException(src);
            if (!Directory.Exists(dst)) Directory.CreateDirectory(dst);
            foreach (string file in Directory.GetFiles(src))
            {
                if (file.EndsWith(".meta", StringComparison.OrdinalIgnoreCase)) continue;
                string leaf = Path.GetFileName(file).Replace("Blank_Test", cfg.name);
                File.Copy(file, Path.Combine(dst, leaf), true);
            }
            AssetDatabase.Refresh();
            Debug.Log("[MapMakerWindow] ensured bakedata clone at " + dst);
        }
        catch (Exception ex) { Debug.LogError("[MapMakerWindow] EnsureBakedataClone failed: " + ex); }
    }

    private static string Esc(string s) => (s ?? "").Replace("\\", "\\\\").Replace("\"", "\\\"");
    private static string JsonBool(bool b) => b ? "true" : "false";
    private static string F(float f) => f.ToString("0.###", System.Globalization.CultureInfo.InvariantCulture);
}
#endif

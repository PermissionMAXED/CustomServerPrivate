using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace BapMapEditor
{
    // The map authoring window. Open via "BAPBAP/Map Editor".
    // Flow: New/Load -> place markers in the 3D scene with native gizmos ->
    // Validate -> Export JSON. Scene transforms are the source of truth for
    // entity/spawn/tile positions; this window owns identity + settings + zone rounds.
    public sealed class BapMapEditorWindow : EditorWindow
    {
        const string DefaultMapsDir = @"C:\Users\Administrator\Downloads\CustomServer\Spiel\Battleroyalebuild\UserData\CustomMaps";

        Vector2 scroll;
        string lastExportPath = "";
        string statusLine = "";
        MessageType statusType = MessageType.Info;
        List<BapIssue> lastIssues = new List<BapIssue>();
        int paletteEntityIndex = 0;
        int paletteTileIndex = 0;

        // Collapsible sections so a finished map's window isn't a wall of fields.
        bool foldIdentity = true, foldSettings = true, foldZones = false, foldPlace = true, foldIO = true;

        [MenuItem("BAPBAP/Map Editor")]
        public static void Open()
        {
            var w = GetWindow<BapMapEditorWindow>("BAP Map Editor");
            w.minSize = new Vector2(360, 520);
        }

        BapMapRoot FindRoot() => UnityEngine.Object.FindObjectOfType<BapMapRoot>();

        void OnGUI()
        {
            DrawHeaderBar();
            scroll = EditorGUILayout.BeginScrollView(scroll);

            var root = FindRoot();
            if (root == null)
            {
                EditorGUILayout.Space(8);
                EditorGUILayout.HelpBox(
                    "No map in this scene yet.\n\n1. Create a new map (adds the grid root + 2 spawns).\n" +
                    "2. Add entities/spawns/tiles and move them in the Scene view.\n" +
                    "3. Validate, then Export to Game.",
                    MessageType.Info);
                EditorGUILayout.Space(4);
                if (GUILayout.Button("Create New Map", GUILayout.Height(38))) CreateNewMap();
                EditorGUILayout.Space(4);
                if (GUILayout.Button("Load Existing Map JSON...", GUILayout.Height(30))) LoadMapDialog();
                DrawStatus();
                EditorGUILayout.EndScrollView();
                return;
            }

            if (Section("Identity", ref foldIdentity)) DrawIdentity(root);
            if (Section("Map Settings", ref foldSettings)) DrawSettings(root);
            if (Section($"Zone Rounds ({root.zoneRounds.Length})", ref foldZones)) DrawZoneRounds(root);
            if (Section("Place in Scene", ref foldPlace)) DrawPlacement(root);
            if (Section("Validate & Export", ref foldIO)) DrawIO(root);
            DrawStatus();

            EditorGUILayout.EndScrollView();
        }

        void DrawHeaderBar()
        {
            using (new EditorGUILayout.HorizontalScope(EditorStyles.toolbar))
            {
                GUILayout.Label("BAPBAP Custom Map Editor", EditorStyles.boldLabel);
                GUILayout.FlexibleSpace();
                if (GUILayout.Button("Validate", EditorStyles.toolbarButton))
                {
                    var r = FindRoot();
                    if (r != null) RunValidate(r);
                }
                if (GUILayout.Button("Export to Game", EditorStyles.toolbarButton))
                {
                    var r = FindRoot();
                    if (r != null) ExportToGame(r);
                }
            }
        }

        // A bold foldout header drawn in a help-box strip; returns whether the body should draw.
        static bool Section(string title, ref bool open)
        {
            EditorGUILayout.Space(4);
            var rect = EditorGUILayout.GetControlRect(false, 20f);
            EditorGUI.DrawRect(rect, new Color(0.20f, 0.22f, 0.26f, 0.5f));
            open = EditorGUI.Foldout(new Rect(rect.x + 4, rect.y, rect.width - 4, rect.height), open, title, true, EditorStyles.foldoutHeader);
            return open;
        }

        void DrawIdentity(BapMapRoot r)
        {
            EditorGUILayout.Space(8);
            EditorGUILayout.LabelField("Identity", EditorStyles.boldLabel);
            EditorGUI.BeginChangeCheck();
            r.mapId = EditorGUILayout.IntField("Map Id (>= 5)", r.mapId);
            r.mapName = EditorGUILayout.TextField("Name", r.mapName);
            r.displayName = EditorGUILayout.TextField("Display Name", r.displayName);
            r.mapSettingsDisplayName = EditorGUILayout.TextField("In-Match Name", r.mapSettingsDisplayName);
            r.enabled = EditorGUILayout.Toggle("Enabled", r.enabled);
            if (EditorGUI.EndChangeCheck()) EditorUtility.SetDirty(r);
        }

        void DrawSettings(BapMapRoot r)
        {
            EditorGUILayout.Space(8);
            EditorGUILayout.LabelField("Map Settings", EditorStyles.boldLabel);
            EditorGUI.BeginChangeCheck();
            r.mapType = EditorGUILayout.IntField("Map Type", r.mapType);
            using (new EditorGUILayout.HorizontalScope())
            {
                EditorGUILayout.PrefixLabel("Map Size (cells)");
                r.mapSizeX = EditorGUILayout.IntField(r.mapSizeX);
                r.mapSizeY = EditorGUILayout.IntField(r.mapSizeY);
            }
            r.customZoneRounds = EditorGUILayout.Toggle("Custom Zone Rounds", r.customZoneRounds);
            r.excludeNavMeshFloor = EditorGUILayout.Toggle("Exclude NavMesh Floor", r.excludeNavMeshFloor);
            r.excludeWaterPerimeter = EditorGUILayout.Toggle("Exclude Water Perimeter", r.excludeWaterPerimeter);
            r.enableEntities = EditorGUILayout.Toggle("Enable Entities", r.enableEntities);
            r.enableTileEdits = EditorGUILayout.Toggle("Enable Tile Edits", r.enableTileEdits);
            using (new EditorGUI.DisabledScope(!r.enableTileEdits))
                r.useLevelDataTileMutations = EditorGUILayout.Toggle("  Use LevelData Tile Path", r.useLevelDataTileMutations);
            if (EditorGUI.EndChangeCheck()) EditorUtility.SetDirty(r);
        }

        void DrawZoneRounds(BapMapRoot r)
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                EditorGUILayout.LabelField("Shrinking-zone rounds", EditorStyles.miniLabel);
                if (GUILayout.Button("+ Add Round", GUILayout.Width(90)))
                {
                    var list = new List<BapZoneRoundUnity>(r.zoneRounds) { new BapZoneRoundUnity() };
                    r.zoneRounds = list.ToArray();
                    EditorUtility.SetDirty(r);
                }
            }
            int removeAt = -1;
            for (int i = 0; i < r.zoneRounds.Length; i++)
            {
                var z = r.zoneRounds[i];
                EditorGUI.BeginChangeCheck();
                using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
                {
                    using (new EditorGUILayout.HorizontalScope())
                    {
                        EditorGUILayout.LabelField($"Round {i}", EditorStyles.miniBoldLabel);
                        if (GUILayout.Button("-", GUILayout.Width(24))) removeAt = i;
                    }
                    z.secondsUntilZoneStart = EditorGUILayout.IntField("Seconds Until Start", z.secondsUntilZoneStart);
                    z.secondsZoneMoveDuration = EditorGUILayout.IntField("Move Duration", z.secondsZoneMoveDuration);
                    z.closePercentage = EditorGUILayout.IntSlider("Close %", z.closePercentage, 0, 100);
                    z.damagePercentage = EditorGUILayout.IntSlider("Damage %", z.damagePercentage, 0, 100);
                    z.doAugments = EditorGUILayout.Toggle("Do Augments", z.doAugments);
                }
                if (EditorGUI.EndChangeCheck()) EditorUtility.SetDirty(r);
            }
            if (removeAt >= 0)
            {
                var list = new List<BapZoneRoundUnity>(r.zoneRounds);
                list.RemoveAt(removeAt);
                r.zoneRounds = list.ToArray();
                EditorUtility.SetDirty(r);
            }
        }

        void DrawPlacement(BapMapRoot r)
        {
            EditorGUILayout.LabelField("Add markers, then move them with the Scene-view tools.", EditorStyles.miniLabel);

            using (new EditorGUILayout.HorizontalScope())
            {
                paletteEntityIndex = EditorGUILayout.Popup(paletteEntityIndex, BapMapPalette.Entities);
                if (GUILayout.Button("Add Entity", GUILayout.Width(110)))
                    AddEntity(r, BapMapPalette.Entities[paletteEntityIndex]);
            }
            if (GUILayout.Button("Add Spawn Point"))
                AddSpawn(r);

            using (new EditorGUI.DisabledScope(!r.enableTileEdits))
            using (new EditorGUILayout.HorizontalScope())
            {
                string[] tileLabels = Array.ConvertAll(BapMapPalette.SafeGroundTileIds, id => "id " + id);
                paletteTileIndex = EditorGUILayout.Popup(paletteTileIndex, tileLabels);
                if (GUILayout.Button("Add Tile", GUILayout.Width(110)))
                    AddTile(r, BapMapPalette.SafeGroundTileIds[paletteTileIndex]);
            }

            int ents = 0, spawns = 0, tiles = 0;
            foreach (var m in UnityEngine.Object.FindObjectsOfType<BapEntityMarker>()) ents++;
            foreach (var m in UnityEngine.Object.FindObjectsOfType<BapSpawnMarker>()) spawns++;
            foreach (var m in UnityEngine.Object.FindObjectsOfType<BapTileMarker>()) tiles++;
            EditorGUILayout.LabelField($"In scene: {ents} entities, {spawns} spawns, {tiles} tiles", EditorStyles.miniLabel);
        }

        void DrawIO(BapMapRoot r)
        {
            EditorGUILayout.Space(10);
            EditorGUILayout.LabelField("Validate & Export", EditorStyles.boldLabel);
            if (GUILayout.Button("Validate", GUILayout.Height(26))) RunValidate(r);
            using (new EditorGUILayout.HorizontalScope())
            {
                if (GUILayout.Button("Export JSON...", GUILayout.Height(30))) ExportDialog(r);
                if (GUILayout.Button("Export to Game", GUILayout.Height(30))) ExportToGame(r);
            }
            if (GUILayout.Button("Load Map JSON...")) LoadMapDialog();

            if (lastIssues.Count > 0)
            {
                EditorGUILayout.Space(4);
                foreach (var issue in lastIssues)
                {
                    var t = issue.level == BapIssueLevel.Error ? MessageType.Error
                          : issue.level == BapIssueLevel.Warning ? MessageType.Warning : MessageType.Info;
                    EditorGUILayout.HelpBox(issue.message, t);
                }
            }
        }

        void DrawStatus()
        {
            if (string.IsNullOrEmpty(statusLine)) return;
            EditorGUILayout.Space(6);
            EditorGUILayout.HelpBox(statusLine, statusType);
            if (!string.IsNullOrEmpty(lastExportPath))
                EditorGUILayout.SelectableLabel(lastExportPath, EditorStyles.miniLabel, GUILayout.Height(16));
        }

        // --- actions ---

        void CreateNewMap()
        {
            var go = new GameObject("BAP Map");
            var root = go.AddComponent<BapMapRoot>();
            Undo.RegisterCreatedObjectUndo(go, "Create BAP Map");
            // Visible reference ground so entities/spawns have a surface to sit on.
            // Not exported — it's an editor aid only.
            var ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
            ground.name = "_ReferenceGround (not exported)";
            ground.transform.SetParent(go.transform, false);
            float planeUnits = root.mapSizeX * root.cellWorldSize / 10f; // Unity plane is 10x10
            ground.transform.localScale = new Vector3(planeUnits, 1f, root.mapSizeY * root.cellWorldSize / 10f);
            // Sensible default: one zone round and two spawns.
            root.zoneRounds = new[] { new BapZoneRoundUnity() };
            AddSpawn(root, new Vector3(10, 0, 10));
            AddSpawn(root, new Vector3(-10, 0, -10));
            Selection.activeGameObject = go;
            SetStatus("New map created. Add entities/spawns, then Export.", MessageType.Info);
        }

        void AddEntity(BapMapRoot r, string prefab)
        {
            var go = new GameObject("Entity_" + prefab);
            go.transform.SetParent(r.transform, false);
            var m = go.AddComponent<BapEntityMarker>();
            m.prefab = prefab;
            go.transform.localPosition = Vector3.zero;
            Undo.RegisterCreatedObjectUndo(go, "Add Entity");
            Selection.activeGameObject = go;
            EditorUtility.SetDirty(r);
        }

        void AddSpawn(BapMapRoot r) => AddSpawn(r, Vector3.zero);
        void AddSpawn(BapMapRoot r, Vector3 pos)
        {
            var go = new GameObject("Spawn");
            go.transform.SetParent(r.transform, false);
            go.AddComponent<BapSpawnMarker>();
            go.transform.localPosition = pos;
            Undo.RegisterCreatedObjectUndo(go, "Add Spawn");
            Selection.activeGameObject = go;
            EditorUtility.SetDirty(r);
        }

        void AddTile(BapMapRoot r, int rotPrefabId)
        {
            var go = new GameObject("Tile_" + rotPrefabId);
            go.transform.SetParent(r.transform, false);
            var m = go.AddComponent<BapTileMarker>();
            m.rotPrefabId = rotPrefabId;
            go.transform.localPosition = Vector3.zero;
            Undo.RegisterCreatedObjectUndo(go, "Add Tile");
            Selection.activeGameObject = go;
            EditorUtility.SetDirty(r);
        }

        void ExportDialog(BapMapRoot r)
        {
            string dir = Directory.Exists(DefaultMapsDir) ? DefaultMapsDir : Application.dataPath;
            string path = EditorUtility.SaveFilePanel("Export Map JSON", dir, r.mapName.ToLowerInvariant() + ".json", "json");
            if (string.IsNullOrEmpty(path)) return;
            DoExport(r, path);
        }

        void ExportToGame(BapMapRoot r)
        {
            if (!Directory.Exists(DefaultMapsDir))
            {
                SetStatus("Game CustomMaps dir not found: " + DefaultMapsDir, MessageType.Error);
                return;
            }
            DoExport(r, Path.Combine(DefaultMapsDir, r.mapName.ToLowerInvariant() + ".json"));
        }

        void RunValidate(BapMapRoot r)
        {
            var data = BapMapSceneIO.ToData(r);
            lastIssues = BapMapValidator.Validate(data);
            bool err = BapMapValidator.HasErrors(lastIssues);
            SetStatus(err ? "Validation found errors — see below." : $"Valid. {lastIssues.Count} note(s).",
                err ? MessageType.Error : MessageType.Info);
        }

        void DoExport(BapMapRoot r, string path)
        {
            var data = BapMapSceneIO.ToData(r);
            lastIssues = BapMapValidator.Validate(data);
            if (BapMapValidator.HasErrors(lastIssues))
            {
                SetStatus("Export blocked: fix errors first (see below).", MessageType.Error);
                return;
            }
            File.WriteAllText(path, BapMapJson.Write(data));
            lastExportPath = path;
            SetStatus("Exported map JSON.", MessageType.Info);
        }

        void LoadMapDialog()
        {
            string dir = Directory.Exists(DefaultMapsDir) ? DefaultMapsDir : Application.dataPath;
            string path = EditorUtility.OpenFilePanel("Load Map JSON", dir, "json");
            if (string.IsNullOrEmpty(path)) return;
            try
            {
                var data = BapMapJson.Read(File.ReadAllText(path));
                BapMapSceneIO.ToScene(data);
                lastExportPath = path;
                SetStatus("Loaded map into scene.", MessageType.Info);
            }
            catch (Exception ex) { SetStatus("Load failed: " + ex.Message, MessageType.Error); }
        }

        void SetStatus(string msg, MessageType t) { statusLine = msg; statusType = t; Repaint(); }
    }
}

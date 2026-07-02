using UnityEditor;
using UnityEngine;

namespace BapMapEditor
{
    // Custom inspectors give markers clean, guided UI instead of raw fields:
    // a prefab dropdown for entities, a tile-id dropdown plus live grid-cell readout
    // for tiles, and a spawn index for spawns. The root gets a compact header that
    // points authors at the Map Editor window for the heavy settings.

    [CustomEditor(typeof(BapEntityMarker))]
    sealed class BapEntityMarkerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            var e = (BapEntityMarker)target;
            EditorGUILayout.LabelField("Entity (NPC)", EditorStyles.boldLabel);

            int cur = Mathf.Max(0, System.Array.IndexOf(BapMapPalette.Entities, e.prefab));
            EditorGUI.BeginChangeCheck();
            int next = EditorGUILayout.Popup("Prefab", cur, BapMapPalette.Entities);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(e, "Change Entity Prefab");
                e.prefab = BapMapPalette.Entities[next];
                e.gameObject.name = "Entity_" + e.prefab;
                EditorUtility.SetDirty(e);
            }

            if (!BapMapPalette.IsKnownEntity(e.prefab))
                EditorGUILayout.HelpBox("Custom prefab name — must exist in the match asset palette.", MessageType.Info);

            EditorGUILayout.LabelField("Facing (rotY)", e.transform.eulerAngles.y.ToString("0.#") + "°");
            EditorGUILayout.HelpBox("Move/rotate in the Scene view. Position is read on export.", MessageType.None);
        }
    }

    [CustomEditor(typeof(BapSpawnMarker))]
    sealed class BapSpawnMarkerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            var s = (BapSpawnMarker)target;
            EditorGUILayout.LabelField("Team Spawn Point", EditorStyles.boldLabel);
            var root = s.GetComponentInParent<BapMapRoot>();
            if (root != null)
            {
                int i = 0, idx = -1;
                foreach (var sp in root.GetComponentsInChildren<BapSpawnMarker>())
                { if (sp == s) { idx = i; break; } i++; }
                EditorGUILayout.LabelField("Spawn Index", idx >= 0 ? idx.ToString() : "?");
            }
            Vector3 p = root != null ? s.transform.position - root.transform.position : s.transform.position;
            EditorGUILayout.LabelField("World Pos", $"({p.x:0.#}, {p.y:0.#}, {p.z:0.#})");
            EditorGUILayout.HelpBox("Only position is exported (y = up). Drag it in the Scene view.", MessageType.None);
        }
    }

    [CustomEditor(typeof(BapTileMarker))]
    sealed class BapTileMarkerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            var t = (BapTileMarker)target;
            EditorGUILayout.LabelField("Ground Tile Edit", EditorStyles.boldLabel);

            int cur = Mathf.Max(0, System.Array.IndexOf(BapMapPalette.SafeGroundTileIds, t.rotPrefabId));
            string[] labels = System.Array.ConvertAll(BapMapPalette.SafeGroundTileIds, id => "id " + id);
            EditorGUI.BeginChangeCheck();
            int next = EditorGUILayout.Popup("Tile Id", cur, labels);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(t, "Change Tile Id");
                t.rotPrefabId = BapMapPalette.SafeGroundTileIds[next];
                t.gameObject.name = "Tile_" + t.rotPrefabId;
                EditorUtility.SetDirty(t);
            }

            var root = t.GetComponentInParent<BapMapRoot>();
            if (root != null)
            {
                float cell = root.cellWorldSize <= 0f ? 1f : root.cellWorldSize;
                Vector3 p = t.transform.position - root.transform.position;
                int gx = Mathf.RoundToInt(p.x / cell) + root.GridCenterX;
                int gy = Mathf.RoundToInt(p.z / cell) + root.GridCenterY;
                EditorGUILayout.LabelField("Grid Cell", $"({gx}, {gy})");
                if (gx < 0 || gy < 0 || gx >= root.mapSizeX || gy >= root.mapSizeY)
                    EditorGUILayout.HelpBox("Outside the map grid — move it inside the green boundary.", MessageType.Warning);
            }
            if (!BapMapPalette.IsSafeGroundTileId(t.rotPrefabId))
                EditorGUILayout.HelpBox("Not a known safe Ground id (242-249). May not resolve.", MessageType.Warning);

            EditorGUILayout.HelpBox("Drag in the Scene view — snaps to the grid automatically (y locked to ground).", MessageType.None);
        }

        // Keep the tile aligned to whole grid cells while it's being moved, so the
        // scene always matches what export writes (which rounds to the nearest cell).
        void OnSceneGUI()
        {
            var t = (BapTileMarker)target;
            var root = t.GetComponentInParent<BapMapRoot>();
            if (root == null) return;
            float cell = root.cellWorldSize <= 0f ? 1f : root.cellWorldSize;
            Vector3 local = t.transform.position - root.transform.position;
            float sx = Mathf.Round(local.x / cell) * cell;
            float sz = Mathf.Round(local.z / cell) * cell;
            Vector3 snapped = root.transform.position + new Vector3(sx, 0f, sz);
            if ((t.transform.position - snapped).sqrMagnitude > 0.0001f)
            {
                Undo.RecordObject(t.transform, "Snap Tile to Grid");
                t.transform.position = snapped;
            }
        }
    }

    [CustomEditor(typeof(BapMapRoot))]
    sealed class BapMapRootEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            var r = (BapMapRoot)target;
            EditorGUILayout.LabelField("BAP Map", EditorStyles.boldLabel);
            EditorGUILayout.LabelField("Map Id", r.mapId.ToString());
            EditorGUILayout.LabelField("Name", r.mapName);
            EditorGUILayout.LabelField("Grid", $"{r.mapSizeX} x {r.mapSizeY} cells");

            int ents = r.GetComponentsInChildren<BapEntityMarker>().Length;
            int spawns = r.GetComponentsInChildren<BapSpawnMarker>().Length;
            int tiles = r.GetComponentsInChildren<BapTileMarker>().Length;
            EditorGUILayout.LabelField("Contents", $"{ents} entities · {spawns} spawns · {tiles} tiles");

            EditorGUILayout.Space(6);
            if (GUILayout.Button("Open Map Editor Window", GUILayout.Height(28)))
                BapMapEditorWindow.Open();

            EditorGUILayout.Space(6);
            EditorGUILayout.LabelField("Raw Fields", EditorStyles.miniBoldLabel);
            DrawDefaultInspector();
        }
    }
}

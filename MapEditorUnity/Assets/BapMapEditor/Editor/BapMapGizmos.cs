using UnityEditor;
using UnityEngine;

namespace BapMapEditor
{
    // Scene-view text labels. Handles is editor-only, so labels live here rather than
    // in the runtime marker components. [DrawGizmo] lets us draw for objects even when
    // they aren't selected, so every marker stays identified at a glance.
    static class BapMapGizmos
    {
        static GUIStyle _label;
        static GUIStyle Label(Color c)
        {
            if (_label == null)
            {
                _label = new GUIStyle(EditorStyles.miniBoldLabel) { fontSize = 11 };
                _label.normal.background = Texture2D.blackTexture;
                _label.padding = new RectOffset(4, 4, 1, 1);
            }
            _label.normal.textColor = c;
            return _label;
        }

        [DrawGizmo(GizmoType.NotInSelectionHierarchy | GizmoType.InSelectionHierarchy)]
        static void DrawEntityLabel(BapEntityMarker e, GizmoType _)
        {
            Handles.Label(e.transform.position + Vector3.up * 1.5f, e.prefab, Label(BapEntityMarker.Orange));
        }

        [DrawGizmo(GizmoType.NotInSelectionHierarchy | GizmoType.InSelectionHierarchy)]
        static void DrawSpawnLabel(BapSpawnMarker s, GizmoType _)
        {
            int idx = SiblingSpawnIndex(s);
            string txt = idx >= 0 ? "Spawn " + idx : "Spawn";
            Handles.Label(s.transform.position + Vector3.up * 1.9f, txt, Label(BapSpawnMarker.Green));
        }

        [DrawGizmo(GizmoType.NotInSelectionHierarchy | GizmoType.InSelectionHierarchy)]
        static void DrawTileLabel(BapTileMarker t, GizmoType _)
        {
            var root = t.GetComponentInParent<BapMapRoot>();
            string txt = "id " + t.rotPrefabId;
            if (root != null)
            {
                float cell = root.cellWorldSize <= 0f ? 1f : root.cellWorldSize;
                Vector3 p = t.transform.position - root.transform.position;
                int gx = Mathf.RoundToInt(p.x / cell) + root.GridCenterX;
                int gy = Mathf.RoundToInt(p.z / cell) + root.GridCenterY;
                txt = $"id {t.rotPrefabId} @({gx},{gy})";
            }
            Handles.Label(t.transform.position + Vector3.up * 0.3f, txt, Label(BapTileMarker.Blue));
        }

        static int SiblingSpawnIndex(BapSpawnMarker s)
        {
            var root = s.GetComponentInParent<BapMapRoot>();
            if (root == null) return -1;
            int i = 0;
            foreach (var sp in root.GetComponentsInChildren<BapSpawnMarker>())
            {
                if (sp == s) return i;
                i++;
            }
            return -1;
        }
    }
}

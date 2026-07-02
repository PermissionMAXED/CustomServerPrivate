using UnityEngine;

// Scene markers the editor places as real GameObjects so you can move/rotate them
// with Unity's native gizmos. On export their transforms are read back into BapMapData.
// These compile only in Unity (UnityEngine dependency); the pure-C# core does not need them.
namespace BapMapEditor
{
    // Marks the map origin + grid. One per scene; entities/spawns are placed relative to it.
    [DisallowMultipleComponent]
    public sealed class BapMapRoot : MonoBehaviour
    {
        [Header("Identity")]
        public int mapId = 30;
        public string mapName = "CustomFlat";
        public string displayName = "CUSTOM FLAT";
        public string mapSettingsDisplayName = "CUSTOM FLAT ARENA";

        [Header("Holder / bundle (advanced — leave defaults unless you know why)")]
        public string bundleFileName = "customflat.bundle";
        public string svPrefabName = "CustomFlat_SvData";
        public string clPrefabName = "CustomFlat_ClData";
        public string baseSvResource = "levels/maps/blank_test_bakedata/Blank_Test_SvData";
        public string baseClResource = "levels/maps/blank_test_bakedata/Blank_Test_ClData";

        [Header("Map settings")]
        public int mapType = 0;
        public bool customZoneRounds = true;
        public bool excludeNavMeshFloor = false;
        public bool excludeWaterPerimeter = false;
        public int mapSizeX = 48;
        public int mapSizeY = 48;
        // True => emit "mapSize": null so the loader keeps the shipped carrier's real grid
        // (Arena_Map2 = 130x130). Forcing 48x48 onto that carrier corrupts the live match.
        public bool useCarrierMapSize = true;
        public bool enableTileEdits = false;
        public bool useLevelDataTileMutations = false;
        public bool enableEntities = true;
        public bool enabled = true;

        [Header("Zone rounds")]
        public BapZoneRoundUnity[] zoneRounds = new BapZoneRoundUnity[0];

        // World size of one grid cell. Used only to draw the grid and convert tile
        // markers to grid coordinates. The shipped 48-unit maps render ~1 world unit
        // per cell for a 48x48 grid, so 1.0 keeps editor coords readable.
        public float cellWorldSize = 1f;

        // Grid cell that maps to world origin (where the root sits).
        public int GridCenterX => mapSizeX / 2;
        public int GridCenterY => mapSizeY / 2;

        // Draw a subtle full grid only when this root is selected — a constant full
        // grid is noisy, but a bright outline + center cross is always useful.
        void OnDrawGizmos()
        {
            float halfX = mapSizeX * cellWorldSize * 0.5f;
            float halfZ = mapSizeY * cellWorldSize * 0.5f;
            Vector3 c = transform.position;

            // Bright boundary outline (always visible).
            Gizmos.color = new Color(0.18f, 0.95f, 0.6f, 0.9f);
            Gizmos.DrawLine(c + new Vector3(-halfX, 0, -halfZ), c + new Vector3(halfX, 0, -halfZ));
            Gizmos.DrawLine(c + new Vector3(halfX, 0, -halfZ), c + new Vector3(halfX, 0, halfZ));
            Gizmos.DrawLine(c + new Vector3(halfX, 0, halfZ), c + new Vector3(-halfX, 0, halfZ));
            Gizmos.DrawLine(c + new Vector3(-halfX, 0, halfZ), c + new Vector3(-halfX, 0, -halfZ));

            // Center cross marks world origin = grid center cell.
            Gizmos.color = new Color(0.95f, 0.45f, 0.3f, 0.9f);
            Gizmos.DrawLine(c + new Vector3(-2, 0.02f, 0), c + new Vector3(2, 0.02f, 0));
            Gizmos.DrawLine(c + new Vector3(0, 0.02f, -2), c + new Vector3(0, 0.02f, 2));
        }

        void OnDrawGizmosSelected()
        {
            float halfX = mapSizeX * cellWorldSize * 0.5f;
            float halfZ = mapSizeY * cellWorldSize * 0.5f;
            Vector3 c = transform.position;

            // Faint full grid so authors can see cell boundaries while editing.
            Gizmos.color = new Color(0.18f, 0.95f, 0.6f, 0.12f);
            for (int gx = 0; gx <= mapSizeX; gx++)
            {
                float x = -halfX + gx * cellWorldSize;
                Gizmos.DrawLine(c + new Vector3(x, 0, -halfZ), c + new Vector3(x, 0, halfZ));
            }
            for (int gy = 0; gy <= mapSizeY; gy++)
            {
                float z = -halfZ + gy * cellWorldSize;
                Gizmos.DrawLine(c + new Vector3(-halfX, 0, z), c + new Vector3(halfX, 0, z));
            }
        }
    }

    [System.Serializable]
    public sealed class BapZoneRoundUnity
    {
        public int secondsUntilZoneStart = 45;
        public int secondsZoneMoveDuration = 30;
        [Range(0, 100)] public int closePercentage = 35;
        [Range(0, 100)] public int damagePercentage = 5;
        public float untilStartPlayerFactorInfluence = 0f;
        public float moveDurationPlayerFactorInfluence = 0f;
        public bool doAugments = false;
    }

    // An NPC/entity placement. Position/rotation come from the transform.
    [DisallowMultipleComponent]
    public sealed class BapEntityMarker : MonoBehaviour
    {
        public string prefab = "Npc_Boss_Chad";

        public static readonly Color Orange = new Color(0.98f, 0.62f, 0.12f, 1f);

        void OnDrawGizmos()
        {
            Vector3 p = transform.position;
            // Solid body + facing arrow so it's easy to see and grab in 3D.
            Gizmos.color = new Color(Orange.r, Orange.g, Orange.b, 0.55f);
            Gizmos.DrawSphere(p + Vector3.up * 0.6f, 0.55f);
            Gizmos.color = Orange;
            Gizmos.DrawWireSphere(p + Vector3.up * 0.6f, 0.55f);
            // Facing arrow (rotY).
            Vector3 tip = p + transform.forward * 1.4f + Vector3.up * 0.6f;
            Gizmos.DrawLine(p + Vector3.up * 0.6f, tip);
            Gizmos.DrawSphere(tip, 0.12f);
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(transform.position + Vector3.up * 0.6f, 0.7f);
        }
    }

    // A team spawn point. Only position is used (y is up).
    [DisallowMultipleComponent]
    public sealed class BapSpawnMarker : MonoBehaviour
    {
        public static readonly Color Green = new Color(0.16f, 0.9f, 0.42f, 1f);

        void OnDrawGizmos()
        {
            Vector3 p = transform.position;
            // Solid pad + vertical stalk so spawns read clearly from above and the side.
            Gizmos.color = new Color(Green.r, Green.g, Green.b, 0.5f);
            Gizmos.DrawCube(p + Vector3.up * 0.05f, new Vector3(1.1f, 0.1f, 1.1f));
            Gizmos.color = Green;
            Gizmos.DrawWireCube(p + Vector3.up * 0.05f, new Vector3(1.1f, 0.1f, 1.1f));
            Gizmos.DrawLine(p, p + Vector3.up * 1.6f);
            Gizmos.DrawSphere(p + Vector3.up * 1.6f, 0.16f);
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireCube(transform.position + Vector3.up * 0.05f, new Vector3(1.3f, 0.12f, 1.3f));
        }
    }

    // A ground tile edit. Snaps to grid; only its grid cell + rotPrefabId are exported.
    [DisallowMultipleComponent]
    public sealed class BapTileMarker : MonoBehaviour
    {
        public string layer = "Ground";
        public int rotPrefabId = 242;

        public static readonly Color Blue = new Color(0.3f, 0.72f, 1f, 1f);

        void OnDrawGizmos()
        {
            Vector3 p = transform.position;
            // Solid flat slab filling the cell so tiled areas read as a surface.
            Gizmos.color = new Color(Blue.r, Blue.g, Blue.b, 0.4f);
            Gizmos.DrawCube(p, new Vector3(0.96f, 0.08f, 0.96f));
            Gizmos.color = Blue;
            Gizmos.DrawWireCube(p, new Vector3(0.96f, 0.08f, 0.96f));
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireCube(transform.position, new Vector3(1f, 0.1f, 1f));
        }
    }
}

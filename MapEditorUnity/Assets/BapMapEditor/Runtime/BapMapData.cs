using System.Collections.Generic;

// Pure-C# data model for a BAPBAP custom map. No UnityEngine dependency, so it
// compiles both inside Unity (Assembly-CSharp) and in the standalone test harness.
// Mirrors the JSON the game's CustomMapLoader reads (see README for the spec).
namespace BapMapEditor
{
    public sealed class BapMapData
    {
        public int mapId = 30;
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
        public int mapSizeX = 48;
        public int mapSizeY = 48;
        // Emit "mapSize": null so the loader keeps the shipped carrier's real grid (Arena_Map2 is
        // 130x130). Forcing a 48x48 size onto that carrier corrupts it ("Array length do not match").
        public bool useCarrierMapSize = false;
        public List<BapZoneRound> zoneRounds = new List<BapZoneRound>();
        public bool enableTileEdits = false;
        public bool useLevelDataTileMutations = false;
        public List<BapTileEdit> tileEdits = new List<BapTileEdit>();
        public bool enableEntities = false;
        public List<BapEntity> entities = new List<BapEntity>();
        public List<BapSpawn> spawnPoints = new List<BapSpawn>();
        public bool enabled = true;

        // Grid cell (0..mapSize-1) that maps to world origin. Used only for the
        // editor's world<->grid conversion of tile markers; not serialized.
        public int GridCenterX => mapSizeX / 2;
        public int GridCenterY => mapSizeY / 2;
    }

    public sealed class BapZoneRound
    {
        public int secondsUntilZoneStart = 45;
        public int secondsZoneMoveDuration = 30;
        public int closePercentage = 35;
        public int damagePercentage = 5;
        public float untilStartPlayerFactorInfluence = 0f;
        public float moveDurationPlayerFactorInfluence = 0f;
        public bool doAugments = false;
    }

    public sealed class BapTileEdit
    {
        public string layer = "Ground";
        public int x = 0;
        public int y = 0;
        public int rotPrefabId = 0;
    }

    public sealed class BapEntity
    {
        public string prefab = "";
        public float x = 0f;
        public float y = 0f;
        public float z = 0f;
        public float rotY = 0f;
    }

    public sealed class BapSpawn
    {
        public float x = 0f;
        public float y = 0f;
        public float z = 0f;

        public BapSpawn() { }
        public BapSpawn(float x, float y, float z) { this.x = x; this.y = y; this.z = z; }
    }
}

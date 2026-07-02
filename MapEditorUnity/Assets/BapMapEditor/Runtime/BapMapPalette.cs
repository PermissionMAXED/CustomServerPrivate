using System.Collections.Generic;

// Catalog of entities/tiles known to resolve in the shipped blank_test base holder.
// The loader matches entities by name against the live assetPalette and tile ids
// against the base holder's prefabIdLibrary, so these are the values proven to work
// in the shipped maps. Custom names still work if present on the live host.
namespace BapMapEditor
{
    public static class BapMapPalette
    {
        // NPC prefabs referenced by the shipped maps (resolve in the live assetPalette).
        public static readonly string[] Entities =
        {
            "Npc_Boss_Chad",
            "Npc_SlimeBoss_A",
            "Npc_SlimeBoss_C",
            "Npc_SlimeBoss_Ba",
            "Npc_SlimeBoss_Bb",
            "Npc_Roaming_Wolf",
        };

        // Ground tile rotPrefabIds used by the shipped maps. In the blank_test base
        // holder these map to grass/ground/floor prefabs, so they pass the loader's
        // IsSafeGroundTilePrefab name check on the Ground fallback path.
        public static readonly int[] SafeGroundTileIds =
        {
            242, 243, 244, 245, 246, 247, 248, 249,
        };

        // Valid tileEdit layer names (Il2CppBAPBAP.Maps.MapLayer). Only Ground applies
        // on the serialized-tiles fallback path; all layers apply when
        // useLevelDataTileMutations=true.
        public static readonly string[] Layers =
        {
            "Ground", "Obstacles", "Decoration", "HideAreas", "Entities", "Ceiling",
        };

        public static bool IsKnownEntity(string prefab)
        {
            if (string.IsNullOrEmpty(prefab)) return false;
            foreach (var e in Entities)
                if (string.Equals(e, prefab, System.StringComparison.OrdinalIgnoreCase)) return true;
            return false;
        }

        public static bool IsSafeGroundTileId(int id)
        {
            foreach (var i in SafeGroundTileIds) if (i == id) return true;
            return false;
        }

        public static bool IsValidLayer(string layer)
        {
            if (string.IsNullOrEmpty(layer)) return true; // loader defaults empty -> Ground
            foreach (var l in Layers)
                if (string.Equals(l, layer, System.StringComparison.OrdinalIgnoreCase)) return true;
            return false;
        }
    }
}

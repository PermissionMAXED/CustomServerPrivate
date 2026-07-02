using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace BapMapEditor
{
    // Bridges the live scene (BapMapRoot + marker GameObjects) and the pure-C# BapMapData.
    // ToData reads transforms back into data for export; ToScene rebuilds markers from
    // loaded data. Entity/spawn positions come from world transforms; tile markers snap
    // to grid cells relative to the root.
    public static class BapMapSceneIO
    {
        public static BapMapData ToData(BapMapRoot root)
        {
            var m = new BapMapData
            {
                mapId = root.mapId,
                name = root.mapName,
                displayName = root.displayName,
                bundleFileName = root.bundleFileName,
                svPrefabName = root.svPrefabName,
                clPrefabName = root.clPrefabName,
                baseSvResource = root.baseSvResource,
                baseClResource = root.baseClResource,
                mapSettingsDisplayName = root.mapSettingsDisplayName,
                mapType = root.mapType,
                customZoneRounds = root.customZoneRounds,
                excludeNavMeshFloor = root.excludeNavMeshFloor,
                excludeWaterPerimeter = root.excludeWaterPerimeter,
                mapSizeX = root.mapSizeX,
                mapSizeY = root.mapSizeY,
                useCarrierMapSize = root.useCarrierMapSize,
                enableTileEdits = root.enableTileEdits,
                useLevelDataTileMutations = root.useLevelDataTileMutations,
                enableEntities = root.enableEntities,
                enabled = root.enabled,
            };

            m.zoneRounds = new List<BapZoneRound>();
            foreach (var z in root.zoneRounds)
            {
                m.zoneRounds.Add(new BapZoneRound
                {
                    secondsUntilZoneStart = z.secondsUntilZoneStart,
                    secondsZoneMoveDuration = z.secondsZoneMoveDuration,
                    closePercentage = z.closePercentage,
                    damagePercentage = z.damagePercentage,
                    untilStartPlayerFactorInfluence = z.untilStartPlayerFactorInfluence,
                    moveDurationPlayerFactorInfluence = z.moveDurationPlayerFactorInfluence,
                    doAugments = z.doAugments,
                });
            }

            Vector3 origin = root.transform.position;
            float cell = root.cellWorldSize <= 0f ? 1f : root.cellWorldSize;

            // Only markers parented under this root belong to the map. Using
            // GetComponentsInChildren (not FindObjectsOfType) keeps a scene with more
            // than one map — or stray leftover markers — from leaking into the export.
            m.entities = new List<BapEntity>();
            foreach (var e in SortedByName(root.GetComponentsInChildren<BapEntityMarker>()))
            {
                Vector3 p = e.transform.position - origin;
                m.entities.Add(new BapEntity
                {
                    prefab = e.prefab,
                    x = Round(p.x), y = Round(p.y), z = Round(p.z),
                    rotY = Round(e.transform.eulerAngles.y),
                });
            }

            m.spawnPoints = new List<BapSpawn>();
            foreach (var s in root.GetComponentsInChildren<BapSpawnMarker>())
            {
                Vector3 p = s.transform.position - origin;
                m.spawnPoints.Add(new BapSpawn(Round(p.x), Round(p.y), Round(p.z)));
            }

            m.tileEdits = new List<BapTileEdit>();
            foreach (var t in root.GetComponentsInChildren<BapTileMarker>())
            {
                Vector3 p = t.transform.position - origin;
                // grid cell: center cell = mapSize/2 at world origin
                int gx = Mathf.RoundToInt(p.x / cell) + root.GridCenterX;
                int gy = Mathf.RoundToInt(p.z / cell) + root.GridCenterY;
                m.tileEdits.Add(new BapTileEdit { layer = t.layer, x = gx, y = gy, rotPrefabId = t.rotPrefabId });
            }

            return m;
        }

        public static void ToScene(BapMapData m)
        {
            // Clear any existing map in the scene.
            var existing = Object.FindObjectOfType<BapMapRoot>();
            if (existing != null) Undo.DestroyObjectImmediate(existing.gameObject);

            var go = new GameObject("BAP Map");
            Undo.RegisterCreatedObjectUndo(go, "Load BAP Map");
            var root = go.AddComponent<BapMapRoot>();
            root.mapId = m.mapId;
            root.mapName = m.name;
            root.displayName = m.displayName;
            root.bundleFileName = m.bundleFileName;
            root.svPrefabName = m.svPrefabName;
            root.clPrefabName = m.clPrefabName;
            root.baseSvResource = m.baseSvResource;
            root.baseClResource = m.baseClResource;
            root.mapSettingsDisplayName = m.mapSettingsDisplayName;
            root.mapType = m.mapType;
            root.customZoneRounds = m.customZoneRounds;
            root.excludeNavMeshFloor = m.excludeNavMeshFloor;
            root.excludeWaterPerimeter = m.excludeWaterPerimeter;
            root.mapSizeX = m.mapSizeX;
            root.mapSizeY = m.mapSizeY;
            root.useCarrierMapSize = m.useCarrierMapSize;
            root.enableTileEdits = m.enableTileEdits;
            root.useLevelDataTileMutations = m.useLevelDataTileMutations;
            root.enableEntities = m.enableEntities;
            root.enabled = m.enabled;

            var zr = new List<BapZoneRoundUnity>();
            foreach (var z in m.zoneRounds)
            {
                zr.Add(new BapZoneRoundUnity
                {
                    secondsUntilZoneStart = z.secondsUntilZoneStart,
                    secondsZoneMoveDuration = z.secondsZoneMoveDuration,
                    closePercentage = z.closePercentage,
                    damagePercentage = z.damagePercentage,
                    untilStartPlayerFactorInfluence = z.untilStartPlayerFactorInfluence,
                    moveDurationPlayerFactorInfluence = z.moveDurationPlayerFactorInfluence,
                    doAugments = z.doAugments,
                });
            }
            root.zoneRounds = zr.ToArray();

            float cell = root.cellWorldSize <= 0f ? 1f : root.cellWorldSize;

            foreach (var e in m.entities)
            {
                var eg = new GameObject("Entity_" + e.prefab);
                eg.transform.SetParent(go.transform, false);
                eg.transform.localPosition = new Vector3(e.x, e.y, e.z);
                eg.transform.localRotation = Quaternion.Euler(0, e.rotY, 0);
                eg.AddComponent<BapEntityMarker>().prefab = e.prefab;
            }
            foreach (var s in m.spawnPoints)
            {
                var sg = new GameObject("Spawn");
                sg.transform.SetParent(go.transform, false);
                sg.transform.localPosition = new Vector3(s.x, s.y, s.z);
                sg.AddComponent<BapSpawnMarker>();
            }
            foreach (var t in m.tileEdits)
            {
                var tg = new GameObject("Tile_" + t.rotPrefabId);
                tg.transform.SetParent(go.transform, false);
                float wx = (t.x - root.GridCenterX) * cell;
                float wz = (t.y - root.GridCenterY) * cell;
                tg.transform.localPosition = new Vector3(wx, 0, wz);
                var tm = tg.AddComponent<BapTileMarker>();
                tm.layer = t.layer;
                tm.rotPrefabId = t.rotPrefabId;
            }

            Selection.activeGameObject = go;
        }

        static float Round(float f) => Mathf.Round(f * 1000f) / 1000f;

        static IEnumerable<BapEntityMarker> SortedByName(BapEntityMarker[] arr)
        {
            var list = new List<BapEntityMarker>(arr);
            list.Sort((a, b) => a.gameObject.name.CompareTo(b.gameObject.name));
            return list;
        }
    }
}

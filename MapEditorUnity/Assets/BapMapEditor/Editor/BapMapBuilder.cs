using System.IO;
using UnityEditor;
using UnityEngine;

namespace BapMapEditor
{
    // Headless builder for an advanced reference map. Runs the SAME code path the
    // editor GUI uses: place marker GameObjects in a scene, then ToData -> Write.
    // This proves the editor itself produces the map (not hand-authored JSON).
    //   Unity.exe -batchmode -nographics -quit -projectPath <proj>
    //     -executeMethod BapMapEditor.BapMapBuilder.BuildCitadel -logFile <log>
    public static class BapMapBuilder
    {
        const string GameMapsDir = @"C:\Users\Administrator\Downloads\CustomServer\Spiel\Battleroyalebuild\UserData\CustomMaps";

        public static void BuildCitadel()
        {
            int failures = 0;
            Debug.Log("[Builder] === Build CustomCitadel (mapId 34) via editor scene-IO ===");

            // 1. Root with identity + settings (what the GUI's DrawIdentity/DrawSettings own).
            var go = new GameObject("BAP Map");
            var root = go.AddComponent<BapMapRoot>();
            root.mapId = 34;
            root.mapName = "CustomCitadel";
            root.displayName = "CUSTOM CITADEL (ADVANCED)";
            root.mapSettingsDisplayName = "CUSTOM CITADEL";
            root.mapType = 0;
            // Carrier-safe profile: the live loader dresses a shipped carrier (Arena_Map2, 130x130) with
            // this map's ENTITIES + spawns. Forcing a 48x48 mapSize, tile edits, or custom zone rounds onto
            // that carrier corrupts the match (grid/navmesh/zone mismatch), so the advanced map drives drama
            // through clustered networked entities instead — the part that actually replicates to clients.
            root.customZoneRounds = false;
            root.excludeNavMeshFloor = false;
            root.excludeWaterPerimeter = false;
            root.useCarrierMapSize = true;     // emit "mapSize": null -> keep the carrier's real grid
            root.mapSizeX = 48;
            root.mapSizeY = 48;
            root.enableEntities = true;
            root.enableTileEdits = false;
            root.useLevelDataTileMutations = false;
            root.enabled = true;
            root.zoneRounds = new BapZoneRoundUnity[0];

            // 2. Inner boss ring at radius 3 (navmesh-safe so they move on client screens).
            string[] inner = { "Npc_SlimeBoss_A", "Npc_SlimeBoss_C", "Npc_SlimeBoss_Ba", "Npc_SlimeBoss_Bb" };
            for (int i = 0; i < inner.Length; i++)
            {
                float ang = i * 90f * Mathf.Deg2Rad;
                AddEntity(root, inner[i], new Vector3(Mathf.Cos(ang) * 3f, 0, Mathf.Sin(ang) * 3f), (i * 90f + 180f) % 360f);
            }
            // Center boss + roaming wolves at radius 4.5 (still on navmesh).
            AddEntity(root, "Npc_Boss_Chad", Vector3.zero, 0f);
            for (int i = 0; i < 4; i++)
            {
                float ang = (i * 90f + 45f) * Mathf.Deg2Rad;
                AddEntity(root, "Npc_Roaming_Wolf", new Vector3(Mathf.Cos(ang) * 4.5f, 0, Mathf.Sin(ang) * 4.5f), (i * 90f + 45f + 180f) % 360f);
            }

            // 3. Four spawns at the corners (>=3 needed; engine asked for index 2 before).
            AddSpawn(root, new Vector3(14, 0, 14));
            AddSpawn(root, new Vector3(-14, 0, -14));
            AddSpawn(root, new Vector3(14, 0, -14));
            AddSpawn(root, new Vector3(-14, 0, 14));

            // 4. A diamond tile ring around the arena center (host-side ground texture).
            int[] ids = BapMapPalette.SafeGroundTileIds; // 242..249
            AddTile(root, Vector3.zero, ids[0]);
            int k = 1;
            for (int r = 1; r <= 3; r++)
            {
                AddTile(root, new Vector3(r, 0, 0), ids[k++ % ids.Length]);
                AddTile(root, new Vector3(-r, 0, 0), ids[k++ % ids.Length]);
                AddTile(root, new Vector3(0, 0, r), ids[k++ % ids.Length]);
                AddTile(root, new Vector3(0, 0, -r), ids[k++ % ids.Length]);
            }

            // 5. Export via the editor's real serialize path.
            var data = BapMapSceneIO.ToData(root);
            var issues = BapMapValidator.Validate(data);
            foreach (var iss in issues) Debug.Log($"[Builder] {iss.level}: {iss.message}");
            Check(ref failures, !BapMapValidator.HasErrors(issues), "map validates without errors");
            Check(ref failures, data.entities.Count == 9, $"9 entities (got {data.entities.Count})");
            Check(ref failures, data.spawnPoints.Count == 4, $"4 spawns (got {data.spawnPoints.Count})");
            Check(ref failures, data.tileEdits.Count == 13, $"13 tiles (got {data.tileEdits.Count})");

            string json = BapMapJson.Write(data);
            var reparsed = BapMapJson.Read(json);
            Check(ref failures, reparsed.mapId == 34 && reparsed.entities.Count == 9, "json round-trips");

            Directory.CreateDirectory(GameMapsDir);
            string path = Path.Combine(GameMapsDir, "customcitadel.json");
            File.WriteAllText(path, json);
            Check(ref failures, File.Exists(path), "wrote " + path);

            // Also drop a copy into the project's SelfTestOut for inspection.
            string outDir = @"C:\Users\Administrator\Downloads\CustomServer\MapEditorUnity\SelfTestOut";
            Directory.CreateDirectory(outDir);
            File.WriteAllText(Path.Combine(outDir, "customcitadel.json"), json);

            if (failures == 0) Debug.Log("[Builder] CITADEL BUILD OK");
            else Debug.LogError($"[Builder] {failures} CHECK(S) FAILED");
            EditorApplication.Exit(failures == 0 ? 0 : 1);
        }

        static void AddEntity(BapMapRoot r, string prefab, Vector3 localPos, float rotY)
        {
            var go = new GameObject("Entity_" + prefab);
            go.transform.SetParent(r.transform, false);
            go.transform.localPosition = localPos;
            go.transform.localRotation = Quaternion.Euler(0, rotY, 0);
            go.AddComponent<BapEntityMarker>().prefab = prefab;
        }

        static void AddSpawn(BapMapRoot r, Vector3 localPos)
        {
            var go = new GameObject("Spawn");
            go.transform.SetParent(r.transform, false);
            go.transform.localPosition = localPos;
            go.AddComponent<BapSpawnMarker>();
        }

        static void AddTile(BapMapRoot r, Vector3 localPos, int rotPrefabId)
        {
            var go = new GameObject("Tile_" + rotPrefabId);
            go.transform.SetParent(r.transform, false);
            go.transform.localPosition = localPos;
            var tm = go.AddComponent<BapTileMarker>();
            tm.layer = "Ground";
            tm.rotPrefabId = rotPrefabId;
        }

        static void Check(ref int failures, bool cond, string label)
        {
            if (cond) Debug.Log($"[Builder] PASS  {label}");
            else { Debug.LogError($"[Builder] FAIL  {label}"); failures++; }
        }
    }
}

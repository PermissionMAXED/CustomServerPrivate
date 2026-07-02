using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace BapMapEditor
{
    // Headless self-test. Run via:
    //   Unity.exe -batchmode -nographics -quit -projectPath <proj> -executeMethod BapMapEditor.BapMapSelfTest.Run
    // Builds a map in the scene, round-trips through JSON + scene IO, validates,
    // and writes a sample map. Exits non-zero on failure so CI/batch can detect it.
    public static class BapMapSelfTest
    {
        static int failures = 0;

        static void Check(bool cond, string label)
        {
            if (cond) Debug.Log($"[SelfTest] PASS  {label}");
            else { Debug.LogError($"[SelfTest] FAIL  {label}"); failures++; }
        }

        public static void Run()
        {
            failures = 0;
            Debug.Log("[SelfTest] === BapMapEditor Unity self-test ===");
            try
            {
                TestSceneRoundTrip();
                TestLoadShipped();
                TestSampleExport();
            }
            catch (Exception ex)
            {
                Debug.LogError("[SelfTest] EXCEPTION " + ex);
                failures++;
            }

            if (failures == 0) Debug.Log("[SelfTest] ALL CHECKS PASSED");
            else Debug.LogError($"[SelfTest] {failures} CHECK(S) FAILED");

            EditorApplication.Exit(failures == 0 ? 0 : 1);
        }

        // Build markers in the scene, export to data, re-import to scene, export again — must be stable.
        static void TestSceneRoundTrip()
        {
            Debug.Log("[SelfTest] [1] Scene <-> data round-trip");

            var go = new GameObject("BAP Map");
            var root = go.AddComponent<BapMapRoot>();
            root.mapId = 36;
            root.mapName = "UnitySelfTest";
            root.displayName = "UNITY SELF TEST";
            root.mapSettingsDisplayName = "UNITY SELF TEST";
            root.enableEntities = true;
            root.enableTileEdits = true;
            root.useLevelDataTileMutations = true;
            root.zoneRounds = new[] { new BapZoneRoundUnity { secondsUntilZoneStart = 50, closePercentage = 30 } };

            // entity at a known world position relative to root (root at origin)
            var e = new GameObject("Entity_Npc_Boss_Chad");
            e.transform.SetParent(go.transform, false);
            e.transform.localPosition = new Vector3(3.5f, 0f, -2f);
            e.transform.localRotation = Quaternion.Euler(0, 90, 0);
            e.AddComponent<BapEntityMarker>().prefab = "Npc_Boss_Chad";

            var s = new GameObject("Spawn");
            s.transform.SetParent(go.transform, false);
            s.transform.localPosition = new Vector3(12, 0, 12);
            s.AddComponent<BapSpawnMarker>();

            // tile at grid center (24,24) => world origin
            var t = new GameObject("Tile_242");
            t.transform.SetParent(go.transform, false);
            t.transform.localPosition = Vector3.zero;
            var tm = t.AddComponent<BapTileMarker>();
            tm.rotPrefabId = 242;

            var data = BapMapSceneIO.ToData(root);
            Check(data.mapId == 36, "mapId carried from root");
            Check(data.entities.Count == 1 && data.entities[0].prefab == "Npc_Boss_Chad", "entity captured");
            Check(Math.Abs(data.entities[0].x - 3.5f) < 0.01f && Math.Abs(data.entities[0].rotY - 90f) < 0.01f, "entity transform read back");
            Check(data.spawnPoints.Count == 1 && Math.Abs(data.spawnPoints[0].x - 12f) < 0.01f, "spawn captured");
            Check(data.tileEdits.Count == 1 && data.tileEdits[0].x == 24 && data.tileEdits[0].y == 24, "tile snapped to grid center (24,24)");

            string json = BapMapJson.Write(data);
            var reparsed = BapMapJson.Read(json);
            Check(reparsed.entities.Count == 1 && reparsed.tileEdits.Count == 1, "json round-trips");

            // Now rebuild scene from data and re-export — structure must be identical.
            BapMapSceneIO.ToScene(reparsed);
            var root2 = UnityEngine.Object.FindObjectOfType<BapMapRoot>();
            Check(root2 != null, "scene rebuilt from data");
            var data2 = BapMapSceneIO.ToData(root2);
            Check(data2.entities.Count == 1 && data2.spawnPoints.Count == 1 && data2.tileEdits.Count == 1, "re-export stable");
            Check(Math.Abs(data2.tileEdits[0].x - 24) < 0.5f && Math.Abs(data2.entities[0].x - 3.5f) < 0.01f, "positions survive scene rebuild");
        }

        static void TestLoadShipped()
        {
            Debug.Log("[SelfTest] [2] Load a shipped map into the scene");
            string dir = @"C:\Users\Administrator\Downloads\CustomServer\Spiel\Battleroyalebuild\UserData\CustomMaps";
            string file = Path.Combine(dir, "customgauntlet.json");
            if (!File.Exists(file)) { Check(false, "customgauntlet.json present"); return; }

            var data = BapMapJson.Read(File.ReadAllText(file));
            BapMapSceneIO.ToScene(data);
            var root = UnityEngine.Object.FindObjectOfType<BapMapRoot>();
            Check(root != null && root.mapId == 33, "loaded customgauntlet (mapId 33)");

            int ents = UnityEngine.Object.FindObjectsOfType<BapEntityMarker>().Length;
            int tiles = UnityEngine.Object.FindObjectsOfType<BapTileMarker>().Length;
            int spawns = UnityEngine.Object.FindObjectsOfType<BapSpawnMarker>().Length;
            Check(ents == 12, $"12 entity markers created (got {ents})");
            Check(tiles == 13, $"13 tile markers created (got {tiles})");
            Check(spawns == 4, $"4 spawn markers created (got {spawns})");

            // re-export and confirm it still parses with same counts
            var back = BapMapSceneIO.ToData(root);
            Check(back.entities.Count == 12 && back.tileEdits.Count == 13 && back.spawnPoints.Count == 4,
                "re-export preserves counts");
        }

        static void TestSampleExport()
        {
            Debug.Log("[SelfTest] [3] Export a sample map to disk");
            var go = new GameObject("BAP Map");
            var root = go.AddComponent<BapMapRoot>();
            root.mapId = 37;
            root.mapName = "UnitySample";
            root.displayName = "UNITY SAMPLE";
            root.mapSettingsDisplayName = "UNITY SAMPLE";
            root.enableEntities = true;
            root.zoneRounds = new[] { new BapZoneRoundUnity() };

            var e = new GameObject("Entity_Npc_Boss_Chad");
            e.transform.SetParent(go.transform, false);
            e.AddComponent<BapEntityMarker>().prefab = "Npc_Boss_Chad";
            var s1 = new GameObject("Spawn"); s1.transform.SetParent(go.transform, false); s1.transform.localPosition = new Vector3(10,0,10); s1.AddComponent<BapSpawnMarker>();
            var s2 = new GameObject("Spawn"); s2.transform.SetParent(go.transform, false); s2.transform.localPosition = new Vector3(-10,0,-10); s2.AddComponent<BapSpawnMarker>();

            var data = BapMapSceneIO.ToData(root);
            var issues = BapMapValidator.Validate(data);
            Check(!BapMapValidator.HasErrors(issues), "sample validates without errors");

            string outDir = @"C:\Users\Administrator\Downloads\CustomServer\MapEditorUnity\SelfTestOut";
            Directory.CreateDirectory(outDir);
            string path = Path.Combine(outDir, "unitysample.json");
            File.WriteAllText(path, BapMapJson.Write(data));
            Check(File.Exists(path), "wrote sample json: " + path);

            var reload = BapMapJson.Read(File.ReadAllText(path));
            Check(reload.mapId == 37 && reload.entities.Count == 1, "sample reloads from disk");
        }
    }
}

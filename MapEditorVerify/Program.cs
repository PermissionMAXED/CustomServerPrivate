using System;
using System.Collections.Generic;
using System.IO;
using BapMapEditor;

namespace BapMapEditor.Verify
{
    // Standalone format check: builds a map in code, writes JSON, reads it back,
    // confirms a clean round-trip, and parses the 4 shipped maps to prove the
    // reader/writer match the real game format. No Unity required.
    internal static class Program
    {
        static int failures = 0;

        static int Main(string[] args)
        {
            string shippedDir = args.Length > 0
                ? args[0]
                : @"C:\Users\Administrator\Downloads\CustomServer\Spiel\Battleroyalebuild\UserData\CustomMaps";

            Console.WriteLine("=== BapMapEditor format verification ===\n");

            TestRoundTrip();
            TestShippedMaps(shippedDir);
            TestValidatorCatchesBadMap();
            TestSampleBuild();

            Console.WriteLine();
            if (failures == 0) { Console.WriteLine("ALL CHECKS PASSED"); return 0; }
            Console.WriteLine($"{failures} CHECK(S) FAILED"); return 1;
        }

        static void Check(bool cond, string label)
        {
            if (cond) Console.WriteLine($"  PASS  {label}");
            else { Console.WriteLine($"  FAIL  {label}"); failures++; }
        }

        // Build a fully-populated map, serialize, parse back, compare every field.
        static void TestRoundTrip()
        {
            Console.WriteLine("[1] Round-trip a fully-populated map");
            var m = new BapMapData
            {
                mapId = 34, name = "RoundTrip", displayName = "ROUND TRIP",
                mapSettingsDisplayName = "ROUND TRIP ARENA", mapType = 0,
                customZoneRounds = true, excludeNavMeshFloor = true, excludeWaterPerimeter = false,
                mapSizeX = 48, mapSizeY = 48,
                enableTileEdits = true, useLevelDataTileMutations = true,
                enableEntities = true, enabled = true,
            };
            m.zoneRounds.Add(new BapZoneRound { secondsUntilZoneStart = 50, closePercentage = 30, doAugments = false });
            m.tileEdits.Add(new BapTileEdit { layer = "Ground", x = 24, y = 24, rotPrefabId = 242 });
            m.tileEdits.Add(new BapTileEdit { layer = "Ground", x = 23, y = 25, rotPrefabId = 243 });
            m.entities.Add(new BapEntity { prefab = "Npc_Boss_Chad", x = 0, y = 0, z = 0, rotY = 0 });
            m.entities.Add(new BapEntity { prefab = "Npc_SlimeBoss_A", x = 3.5f, y = 0, z = -3.5f, rotY = 270 });
            m.spawnPoints.Add(new BapSpawn(12, 0, 12));
            m.spawnPoints.Add(new BapSpawn(-12, 0, -12));

            string json = BapMapJson.Write(m);
            var r = BapMapJson.Read(json);

            Check(r.mapId == m.mapId, "mapId");
            Check(r.name == m.name, "name");
            Check(r.mapSettingsDisplayName == m.mapSettingsDisplayName, "mapSettingsDisplayName");
            Check(r.excludeNavMeshFloor == m.excludeNavMeshFloor, "excludeNavMeshFloor");
            Check(r.mapSizeX == 48 && r.mapSizeY == 48, "mapSize");
            Check(r.zoneRounds.Count == 1 && r.zoneRounds[0].secondsUntilZoneStart == 50, "zoneRounds");
            Check(r.tileEdits.Count == 2 && r.tileEdits[1].rotPrefabId == 243, "tileEdits");
            Check(r.enableTileEdits && r.useLevelDataTileMutations, "tile flags");
            Check(r.entities.Count == 2 && r.entities[1].prefab == "Npc_SlimeBoss_A", "entities");
            Check(Math.Abs(r.entities[1].x - 3.5f) < 0.001f && Math.Abs(r.entities[1].rotY - 270f) < 0.001f, "entity transform");
            Check(r.spawnPoints.Count == 2 && Math.Abs(r.spawnPoints[0].x - 12f) < 0.001f, "spawnPoints");
            Check(r.enabled, "enabled");

            // Re-serialize and confirm idempotency (write -> read -> write is stable).
            string json2 = BapMapJson.Write(r);
            Check(json == json2, "idempotent re-serialize");
        }

        // Parse every shipped map; the reader must not throw and must recover key fields.
        static void TestShippedMaps(string dir)
        {
            Console.WriteLine("[2] Parse shipped maps from " + dir);
            if (!Directory.Exists(dir)) { Check(false, "shipped maps dir exists"); return; }

            string[] files = Directory.GetFiles(dir, "*.json");
            Check(files.Length >= 4, $"found {files.Length} shipped map json(s)");

            foreach (var f in files)
            {
                string fn = Path.GetFileName(f);
                try
                {
                    var m = BapMapJson.Read(File.ReadAllText(f));
                    bool ok = m.mapId > 0 && !string.IsNullOrEmpty(m.name);
                    Check(ok, $"{fn}: mapId={m.mapId} name={m.name} entities={m.entities.Count} tiles={m.tileEdits.Count} spawns={m.spawnPoints.Count}");

                    // Round-trip the shipped map through our model and reparse — structure must survive.
                    var r = BapMapJson.Read(BapMapJson.Write(m));
                    Check(r.mapId == m.mapId && r.entities.Count == m.entities.Count
                          && r.tileEdits.Count == m.tileEdits.Count && r.spawnPoints.Count == m.spawnPoints.Count,
                          $"{fn}: round-trips with stable structure");

                    // Byte-level proof: write the round-tripped map next to the originals
                    // so we can diff editor output vs a map the game already loads.
                    string rtDir = @"C:\Users\Administrator\Downloads\CustomServer\MapEditorVerify\out\roundtrip";
                    Directory.CreateDirectory(rtDir);
                    File.WriteAllText(Path.Combine(rtDir, fn), BapMapJson.Write(m));
                }
                catch (Exception ex) { Check(false, $"{fn}: parse threw {ex.Message}"); }
            }
        }

        static void TestValidatorCatchesBadMap()
        {
            Console.WriteLine("[3] Validator flags loader gotchas");
            var bad = new BapMapData
            {
                mapId = 2,             // built-in slot -> error
                name = "",             // missing -> error
                enableTileEdits = false,
            };
            bad.tileEdits.Add(new BapTileEdit { layer = "Ground", x = 24, y = 24, rotPrefabId = 242 }); // present but disabled -> warn
            bad.entities.Add(new BapEntity { prefab = "Npc_Boss_Chad" }); // enableEntities false -> warn
            bad.enableEntities = false;

            var issues = BapMapValidator.Validate(bad);
            Check(BapMapValidator.HasErrors(issues), "detects errors on a bad map (mapId<5, blank name)");
            bool warnsDisabledTiles = issues.Exists(i => i.message.Contains("enableTileEdits=false"));
            Check(warnsDisabledTiles, "warns tileEdits present but disabled");

            var good = MakeSample();
            var goodIssues = BapMapValidator.Validate(good);
            Check(!BapMapValidator.HasErrors(goodIssues), "sample map has no errors");
        }

        // Build the sample map the Unity self-test also produces; write it to disk for inspection.
        static void TestSampleBuild()
        {
            Console.WriteLine("[4] Build + write sample map");
            var m = MakeSample();
            string outDir = @"C:\Users\Administrator\Downloads\CustomServer\MapEditorVerify\out";
            Directory.CreateDirectory(outDir);
            string path = Path.Combine(outDir, m.name.ToLowerInvariant() + ".json");
            File.WriteAllText(path, BapMapJson.Write(m));
            Console.WriteLine("  wrote " + path);
            var r = BapMapJson.Read(File.ReadAllText(path));
            Check(r.name == m.name && r.entities.Count == m.entities.Count, "sample reloads from disk");
        }

        static BapMapData MakeSample()
        {
            var m = new BapMapData
            {
                mapId = 35, name = "SampleForge", displayName = "SAMPLE FORGE (EDITOR TEST)",
                mapSettingsDisplayName = "SAMPLE FORGE", mapType = 0,
                customZoneRounds = true, mapSizeX = 48, mapSizeY = 48,
                enableTileEdits = true, useLevelDataTileMutations = true,
                enableEntities = true, enabled = true,
            };
            m.zoneRounds.Add(new BapZoneRound { secondsUntilZoneStart = 45, secondsZoneMoveDuration = 30, closePercentage = 35, damagePercentage = 5 });
            // a small cross of safe ground tiles at center
            m.tileEdits.Add(new BapTileEdit { layer = "Ground", x = 24, y = 24, rotPrefabId = 242 });
            m.tileEdits.Add(new BapTileEdit { layer = "Ground", x = 23, y = 24, rotPrefabId = 243 });
            m.tileEdits.Add(new BapTileEdit { layer = "Ground", x = 25, y = 24, rotPrefabId = 244 });
            m.tileEdits.Add(new BapTileEdit { layer = "Ground", x = 24, y = 23, rotPrefabId = 245 });
            m.tileEdits.Add(new BapTileEdit { layer = "Ground", x = 24, y = 25, rotPrefabId = 246 });
            m.entities.Add(new BapEntity { prefab = "Npc_Boss_Chad", x = 0, y = 0, z = 0, rotY = 0 });
            m.entities.Add(new BapEntity { prefab = "Npc_SlimeBoss_A", x = 4, y = 0, z = 0, rotY = 270 });
            m.entities.Add(new BapEntity { prefab = "Npc_SlimeBoss_C", x = -4, y = 0, z = 0, rotY = 90 });
            m.spawnPoints.Add(new BapSpawn(12, 0, 12));
            m.spawnPoints.Add(new BapSpawn(-12, 0, -12));
            m.spawnPoints.Add(new BapSpawn(12, 0, -12));
            m.spawnPoints.Add(new BapSpawn(-12, 0, 12));
            return m;
        }
    }
}

using System.Collections.Generic;
using System.Globalization;
using System.Text;

// Reads/writes BapMapData as the exact JSON the game's CustomMapLoader expects.
// Key order and formatting match the shipped maps (customflat.json etc.) for
// clean diffs. Parsing is order-independent (loader uses key lookups).
namespace BapMapEditor
{
    public static class BapMapJson
    {
        static string F(float f) => f.ToString("0.###", CultureInfo.InvariantCulture);
        static string B(bool b) => b ? "true" : "false";
        static string Esc(string s) => (s ?? "").Replace("\\", "\\\\").Replace("\"", "\\\"");

        public static string Write(BapMapData m)
        {
            var sb = new StringBuilder();
            sb.Append("{\n");
            sb.Append($"  \"mapId\": {m.mapId},\n");
            sb.Append($"  \"name\": \"{Esc(m.name)}\",\n");
            sb.Append($"  \"displayName\": \"{Esc(m.displayName)}\",\n");
            sb.Append($"  \"bundleFileName\": \"{Esc(m.bundleFileName)}\",\n");
            sb.Append($"  \"svPrefabName\": \"{Esc(m.svPrefabName)}\",\n");
            sb.Append($"  \"clPrefabName\": \"{Esc(m.clPrefabName)}\",\n");
            sb.Append($"  \"baseSvResource\": \"{Esc(m.baseSvResource)}\",\n");
            sb.Append($"  \"baseClResource\": \"{Esc(m.baseClResource)}\",\n");
            sb.Append($"  \"mapSettingsDisplayName\": \"{Esc(m.mapSettingsDisplayName)}\",\n");
            sb.Append($"  \"mapType\": {m.mapType},\n");
            sb.Append($"  \"customZoneRounds\": {B(m.customZoneRounds)},\n");
            sb.Append($"  \"excludeNavMeshFloor\": {B(m.excludeNavMeshFloor)},\n");
            sb.Append($"  \"excludeWaterPerimeter\": {B(m.excludeWaterPerimeter)},\n");
            if (m.useCarrierMapSize)
                sb.Append("  \"mapSize\": null,\n");
            else
                sb.Append($"  \"mapSize\": [ {m.mapSizeX}, {m.mapSizeY} ],\n");

            // zoneRounds
            if (m.zoneRounds == null || m.zoneRounds.Count == 0)
            {
                sb.Append("  \"zoneRounds\": [],\n");
            }
            else
            {
                sb.Append("  \"zoneRounds\": [\n");
                for (int i = 0; i < m.zoneRounds.Count; i++)
                {
                    var z = m.zoneRounds[i];
                    sb.Append("    {\n");
                    sb.Append($"      \"secondsUntilZoneStart\": {z.secondsUntilZoneStart},\n");
                    sb.Append($"      \"secondsZoneMoveDuration\": {z.secondsZoneMoveDuration},\n");
                    sb.Append($"      \"closePercentage\": {z.closePercentage},\n");
                    sb.Append($"      \"damagePercentage\": {z.damagePercentage},\n");
                    sb.Append($"      \"untilStartPlayerFactorInfluence\": {F(z.untilStartPlayerFactorInfluence)},\n");
                    sb.Append($"      \"moveDurationPlayerFactorInfluence\": {F(z.moveDurationPlayerFactorInfluence)},\n");
                    sb.Append($"      \"doAugments\": {B(z.doAugments)}\n");
                    sb.Append(i == m.zoneRounds.Count - 1 ? "    }\n" : "    },\n");
                }
                sb.Append("  ],\n");
            }

            sb.Append($"  \"enableTileEdits\": {B(m.enableTileEdits)},\n");
            sb.Append($"  \"useLevelDataTileMutations\": {B(m.useLevelDataTileMutations)},\n");

            // tileEdits
            if (m.tileEdits == null || m.tileEdits.Count == 0)
            {
                sb.Append("  \"tileEdits\": [],\n");
            }
            else
            {
                sb.Append("  \"tileEdits\": [\n");
                for (int i = 0; i < m.tileEdits.Count; i++)
                {
                    var t = m.tileEdits[i];
                    string comma = i == m.tileEdits.Count - 1 ? "" : ",";
                    sb.Append($"    {{ \"layer\": \"{Esc(t.layer)}\", \"x\": {t.x}, \"y\": {t.y}, \"rotPrefabId\": {t.rotPrefabId} }}{comma}\n");
                }
                sb.Append("  ],\n");
            }

            sb.Append($"  \"enableEntities\": {B(m.enableEntities)},\n");

            // entities
            if (m.entities == null || m.entities.Count == 0)
            {
                sb.Append("  \"entities\": [],\n");
            }
            else
            {
                sb.Append("  \"entities\": [\n");
                for (int i = 0; i < m.entities.Count; i++)
                {
                    var e = m.entities[i];
                    string comma = i == m.entities.Count - 1 ? "" : ",";
                    sb.Append($"    {{ \"prefab\": \"{Esc(e.prefab)}\", \"x\": {F(e.x)}, \"y\": {F(e.y)}, \"z\": {F(e.z)}, \"rotY\": {F(e.rotY)} }}{comma}\n");
                }
                sb.Append("  ],\n");
            }

            // spawnPoints
            if (m.spawnPoints == null || m.spawnPoints.Count == 0)
            {
                sb.Append("  \"spawnPoints\": [],\n");
            }
            else
            {
                sb.Append("  \"spawnPoints\": [\n");
                for (int i = 0; i < m.spawnPoints.Count; i++)
                {
                    var s = m.spawnPoints[i];
                    string comma = i == m.spawnPoints.Count - 1 ? "" : ",";
                    sb.Append($"    [ {F(s.x)}, {F(s.y)}, {F(s.z)} ]{comma}\n");
                }
                sb.Append("  ],\n");
            }

            sb.Append($"  \"enabled\": {B(m.enabled)}\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        public static BapMapData Read(string json)
        {
            var root = BapJson.Parse(json) as Dictionary<string, object>;
            if (root == null) throw new System.FormatException("Top-level JSON is not an object");
            var m = new BapMapData();

            m.mapId = BapJson.Int(root, "mapId", m.mapId);
            m.name = BapJson.Str(root, "name", m.name);
            m.displayName = BapJson.Str(root, "displayName", m.displayName);
            m.bundleFileName = BapJson.Str(root, "bundleFileName", m.bundleFileName);
            m.svPrefabName = BapJson.Str(root, "svPrefabName", m.svPrefabName);
            m.clPrefabName = BapJson.Str(root, "clPrefabName", m.clPrefabName);
            m.baseSvResource = BapJson.Str(root, "baseSvResource", m.baseSvResource);
            m.baseClResource = BapJson.Str(root, "baseClResource", m.baseClResource);
            m.mapSettingsDisplayName = BapJson.Str(root, "mapSettingsDisplayName", m.mapSettingsDisplayName);
            m.mapType = BapJson.Int(root, "mapType", m.mapType);
            m.customZoneRounds = BapJson.Bool(root, "customZoneRounds", m.customZoneRounds);
            m.excludeNavMeshFloor = BapJson.Bool(root, "excludeNavMeshFloor", m.excludeNavMeshFloor);
            m.excludeWaterPerimeter = BapJson.Bool(root, "excludeWaterPerimeter", m.excludeWaterPerimeter);

            // "mapSize": null (or absent) means keep the carrier's real grid; only an explicit
            // [w,h] array overrides it. Round-trips back to null via useCarrierMapSize.
            var size = BapJson.Arr(root, "mapSize");
            if (size != null && size.Count >= 2)
            {
                m.useCarrierMapSize = false;
                m.mapSizeX = (int)System.Math.Round((double)size[0]);
                m.mapSizeY = (int)System.Math.Round((double)size[1]);
            }
            else
            {
                m.useCarrierMapSize = true;
            }

            m.zoneRounds = new List<BapZoneRound>();
            var zr = BapJson.Arr(root, "zoneRounds");
            if (zr != null)
            {
                foreach (var item in zr)
                {
                    if (item is Dictionary<string, object> zo)
                    {
                        m.zoneRounds.Add(new BapZoneRound
                        {
                            secondsUntilZoneStart = BapJson.Int(zo, "secondsUntilZoneStart", 45),
                            secondsZoneMoveDuration = BapJson.Int(zo, "secondsZoneMoveDuration", 30),
                            closePercentage = BapJson.Int(zo, "closePercentage", 35),
                            damagePercentage = BapJson.Int(zo, "damagePercentage", 5),
                            untilStartPlayerFactorInfluence = BapJson.Flt(zo, "untilStartPlayerFactorInfluence", 0f),
                            moveDurationPlayerFactorInfluence = BapJson.Flt(zo, "moveDurationPlayerFactorInfluence", 0f),
                            doAugments = BapJson.Bool(zo, "doAugments", false)
                        });
                    }
                }
            }

            m.enableTileEdits = BapJson.Bool(root, "enableTileEdits", m.enableTileEdits);
            m.useLevelDataTileMutations = BapJson.Bool(root, "useLevelDataTileMutations", m.useLevelDataTileMutations);

            m.tileEdits = new List<BapTileEdit>();
            var te = BapJson.Arr(root, "tileEdits");
            if (te != null)
            {
                foreach (var item in te)
                {
                    if (item is Dictionary<string, object> to)
                    {
                        m.tileEdits.Add(new BapTileEdit
                        {
                            layer = BapJson.Str(to, "layer", "Ground"),
                            x = BapJson.Int(to, "x", 0),
                            y = BapJson.Int(to, "y", 0),
                            rotPrefabId = BapJson.Int(to, "rotPrefabId", 0)
                        });
                    }
                }
            }

            m.enableEntities = BapJson.Bool(root, "enableEntities", m.enableEntities);

            m.entities = new List<BapEntity>();
            var en = BapJson.Arr(root, "entities");
            if (en != null)
            {
                foreach (var item in en)
                {
                    if (item is Dictionary<string, object> eo)
                    {
                        m.entities.Add(new BapEntity
                        {
                            prefab = BapJson.Str(eo, "prefab", ""),
                            x = BapJson.Flt(eo, "x", 0f),
                            y = BapJson.Flt(eo, "y", 0f),
                            z = BapJson.Flt(eo, "z", 0f),
                            rotY = BapJson.Flt(eo, "rotY", 0f)
                        });
                    }
                }
            }

            m.spawnPoints = new List<BapSpawn>();
            var sp = BapJson.Arr(root, "spawnPoints");
            if (sp != null)
            {
                foreach (var item in sp)
                {
                    if (item is List<object> arr && arr.Count >= 3)
                    {
                        m.spawnPoints.Add(new BapSpawn(
                            (float)(double)arr[0],
                            (float)(double)arr[1],
                            (float)(double)arr[2]));
                    }
                }
            }

            m.enabled = BapJson.Bool(root, "enabled", m.enabled);
            return m;
        }
    }
}

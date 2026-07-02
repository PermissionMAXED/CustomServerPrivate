using System.Collections.Generic;

// Validates a BapMapData against the loader's gating rules so the editor can warn
// before export. Mirrors CustomMapLoader.cs behavior: which fields gate what, and
// when an edit will be silently skipped at load time.
namespace BapMapEditor
{
    public enum BapIssueLevel { Error, Warning, Info }

    public sealed class BapIssue
    {
        public BapIssueLevel level;
        public string message;
        public BapIssue(BapIssueLevel l, string m) { level = l; message = m; }
        public override string ToString() => $"[{level}] {message}";
    }

    public static class BapMapValidator
    {
        public static List<BapIssue> Validate(BapMapData m)
        {
            var issues = new List<BapIssue>();

            // Identity
            if (m.mapId < 5)
                issues.Add(new BapIssue(BapIssueLevel.Error,
                    $"mapId {m.mapId} is a built-in slot. Custom maps must use mapId >= 5 (shipped customs use 30-33)."));
            if (string.IsNullOrWhiteSpace(m.name))
                issues.Add(new BapIssue(BapIssueLevel.Error, "name is required (used as the level lookup key)."));
            if (!m.enabled)
                issues.Add(new BapIssue(BapIssueLevel.Warning, "enabled=false: the loader drops this map at load."));

            if (m.mapSizeX < 2 || m.mapSizeY < 2)
                issues.Add(new BapIssue(BapIssueLevel.Error, $"mapSize [{m.mapSizeX},{m.mapSizeY}] must be at least 2x2."));

            // Spawns
            if (m.spawnPoints == null || m.spawnPoints.Count == 0)
                issues.Add(new BapIssue(BapIssueLevel.Warning,
                    "No spawnPoints: players fall back to the base holder's default spawns."));
            else if (m.spawnPoints.Count < 2)
                issues.Add(new BapIssue(BapIssueLevel.Warning,
                    "Only 1 spawnPoint defined; multi-team matches need several."));

            // Zone rounds
            if (m.zoneRounds != null)
            {
                for (int i = 0; i < m.zoneRounds.Count; i++)
                {
                    var z = m.zoneRounds[i];
                    if (z.closePercentage < 0 || z.closePercentage > 100)
                        issues.Add(new BapIssue(BapIssueLevel.Warning, $"zoneRounds[{i}].closePercentage {z.closePercentage} outside 0-100."));
                    if (z.secondsUntilZoneStart < 0)
                        issues.Add(new BapIssue(BapIssueLevel.Warning, $"zoneRounds[{i}].secondsUntilZoneStart is negative."));
                }
            }

            // Tile edits
            if (m.tileEdits != null && m.tileEdits.Count > 0 && !m.enableTileEdits)
                issues.Add(new BapIssue(BapIssueLevel.Warning,
                    $"{m.tileEdits.Count} tileEdit(s) present but enableTileEdits=false: they will be skipped at load."));

            if (m.enableTileEdits && m.tileEdits != null)
            {
                for (int i = 0; i < m.tileEdits.Count; i++)
                {
                    var t = m.tileEdits[i];
                    if (!BapMapPalette.IsValidLayer(t.layer))
                        issues.Add(new BapIssue(BapIssueLevel.Warning,
                            $"tileEdits[{i}].layer '{t.layer}' is not a known MapLayer; the loader will skip it."));
                    bool nonGround = !string.IsNullOrEmpty(t.layer) &&
                                     !string.Equals(t.layer, "Ground", System.StringComparison.OrdinalIgnoreCase);
                    if (nonGround && !m.useLevelDataTileMutations)
                        issues.Add(new BapIssue(BapIssueLevel.Warning,
                            $"tileEdits[{i}] targets layer '{t.layer}' but useLevelDataTileMutations=false; only Ground applies on the fallback path."));
                    if (!m.useLevelDataTileMutations &&
                        (string.IsNullOrEmpty(t.layer) || string.Equals(t.layer, "Ground", System.StringComparison.OrdinalIgnoreCase)) &&
                        !BapMapPalette.IsSafeGroundTileId(t.rotPrefabId))
                        issues.Add(new BapIssue(BapIssueLevel.Warning,
                            $"tileEdits[{i}].rotPrefabId {t.rotPrefabId} is not a known-safe Ground id (242-249); the loader may reject it on the fallback path."));
                    if (t.x < 0 || t.x >= m.mapSizeX || t.y < 0 || t.y >= m.mapSizeY)
                        issues.Add(new BapIssue(BapIssueLevel.Warning,
                            $"tileEdits[{i}] cell ({t.x},{t.y}) is outside the {m.mapSizeX}x{m.mapSizeY} grid."));
                }
            }

            // Entities
            if (m.entities != null && m.entities.Count > 0 && !m.enableEntities)
                issues.Add(new BapIssue(BapIssueLevel.Warning,
                    $"{m.entities.Count} entit(ies) present but enableEntities=false: they will be skipped at load."));

            if (m.enableEntities && m.entities != null)
            {
                for (int i = 0; i < m.entities.Count; i++)
                {
                    var e = m.entities[i];
                    if (string.IsNullOrWhiteSpace(e.prefab))
                        issues.Add(new BapIssue(BapIssueLevel.Error, $"entities[{i}].prefab is blank; the loader drops it."));
                    else if (!BapMapPalette.IsKnownEntity(e.prefab))
                        issues.Add(new BapIssue(BapIssueLevel.Info,
                            $"entities[{i}].prefab '{e.prefab}' is not in the known catalog; it will only resolve if present in the live assetPalette."));
                }
            }

            return issues;
        }

        public static bool HasErrors(List<BapIssue> issues)
        {
            foreach (var i in issues) if (i.level == BapIssueLevel.Error) return true;
            return false;
        }
    }
}

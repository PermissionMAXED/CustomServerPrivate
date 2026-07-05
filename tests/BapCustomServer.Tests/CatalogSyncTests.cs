using System.Text.Json;
using System.Text.RegularExpressions;
using BapCustomServerMelon;
using Xunit;

namespace BapCustomServer.Tests;

// HC5 invariant lock: the server's CharacterCatalog/MapCatalog (CustomServerOptions.cs), the mod's
// MelonMapHelpers carrier table (link-compiled from BapCustomServerMelon), and the AMP config JSON
// (deployment/amp-github-autoinstall/bapcustomservergithubconfig.json, copied to Fixtures/ at build)
// describe the SAME ids and MUST stay in sync — the catalogs are the single source of truth for
// name<->id resolution (see the MapCatalog doc comment). These tests fail if any of the three
// drifts, instead of leaving the mismatch to be discovered on a live match host.
public class CatalogSyncTests
{
    // ===== server catalog <-> mod carrier table (no file dependency) ========================

    [Fact] // B25 out-of-bounds coupling: the catalog ceiling IS the carrier array's last index
    public void MapCatalog_Ceiling_EqualsCarrierTableSizeMinusOne()
    {
        Assert.Equal(MelonMapHelpers.LevelNameCount, MelonMapHelpers.BuildKnownLevelNames().Length);
        // Any mapId above this indexes out of bounds in the mod's KnownLevelNames and crashes the
        // match host's level-load. If LevelNameCount changes, MaxCustomMapId must move in lockstep.
        Assert.Equal(MelonMapHelpers.LevelNameCount - 1, MapCatalog.MaxCustomMapId);
    }

    [Fact] // shipped mapIds resolve to the exact engine level names the mod's carrier loads
    public void MapCatalog_ShippedIds_MatchCarrierLevelNames()
    {
        string[] carrier = MelonMapHelpers.BuildKnownLevelNames();
        foreach (int id in new[] { MapCatalog.BazaarCityId, MapCatalog.LyceumId, MapCatalog.ArenaMap2Id, MapCatalog.OpenBetaBoccatoId })
        {
            Assert.Equal(MapCatalog.IdToName[id], carrier[id]);
        }
    }

    [Fact] // custom slots all load the Arena_Map2 carrier; IsCustomMapId bounds are exact
    public void MapCatalog_CustomSlots_AllUseCarrier_AndBoundsAreExact()
    {
        string[] carrier = MelonMapHelpers.BuildKnownLevelNames();
        for (int id = MapCatalog.FirstCustomMapId; id <= MapCatalog.MaxCustomMapId; id++)
        {
            Assert.Equal("Arena_Map2", carrier[id]);
        }

        Assert.False(MapCatalog.IsCustomMapId(MapCatalog.OpenBetaBoccatoId));
        Assert.True(MapCatalog.IsCustomMapId(MapCatalog.FirstCustomMapId));
        Assert.True(MapCatalog.IsCustomMapId(MapCatalog.MaxCustomMapId));
        Assert.False(MapCatalog.IsCustomMapId(MapCatalog.MaxCustomMapId + 1));

        // Deliberate asymmetry: the catalog names slot 5 "CustomFlat" (player-facing custom map)
        // while the mod's carrier loads "Arena_Map2" underneath it. Do NOT unify these.
        Assert.Equal("CustomFlat", MapCatalog.IdToName[MapCatalog.CustomFlatId]);
        Assert.Equal("Arena_Map2", carrier[MapCatalog.CustomFlatId]);
    }

    [Fact] // CharacterCatalog shape: 16 chars, Medusa is the custom id 15, no cursed skin ids
    public void CharacterCatalog_ShapeInvariants()
    {
        Assert.Equal(16, CharacterCatalog.Names.Length);
        Assert.Equal(15, CharacterCatalog.MedusaCharId);
        Assert.Equal("Medusa", CharacterCatalog.Names[CharacterCatalog.MedusaCharId]);
        Assert.Equal(CharacterCatalog.Names.Length, CharacterCatalog.DefaultSkinAssetIds.Length);
        Assert.Equal(Enumerable.Range(0, CharacterCatalog.Names.Length), CharacterCatalog.AllIds);

        // 300001/300004/300006 are empty SkinData slots that crash the in-game locker UI.
        int[] cursedSkinIds = [300001, 300004, 300006];
        Assert.DoesNotContain(CharacterCatalog.DefaultSkinAssetIds, id => cursedSkinIds.Contains(id));
    }

    // ===== server catalog <-> AMP config JSON =================================================

    private static JsonElement[] LoadAmpConfigEntries()
    {
        string path = Path.Combine(AppContext.BaseDirectory, "Fixtures", "bapcustomservergithubconfig.json");
        Assert.True(File.Exists(path),
            $"AMP config fixture not found at {path}. It is link-copied at build time from " +
            "deployment/amp-github-autoinstall/bapcustomservergithubconfig.json via the test csproj's " +
            "Content include — rebuild the test project, or restore the deployment file if it was moved.");
        // File.ReadAllText strips the file's UTF-8 BOM; JsonDocument.Parse(string) would reject it.
        using var doc = JsonDocument.Parse(File.ReadAllText(path));
        return doc.RootElement.EnumerateArray().Select(e => e.Clone()).ToArray();
    }

    private static string Field(JsonElement entry, string name) =>
        entry.TryGetProperty(name, out var v) && v.ValueKind == JsonValueKind.String ? v.GetString()! : "";

    [Fact] // every roster toggle maps FieldName -> catalog name -> the charId its Description claims
    public void AmpConfig_CharacterToggles_MatchCharacterCatalog()
    {
        var roster = LoadAmpConfigEntries()
            .Where(e => Field(e, "Category") == "BAPBAP - Characters" && Field(e, "Subcategory") == "Roster")
            .ToArray();
        Assert.Equal(CharacterCatalog.Names.Length, roster.Length); // exactly 16, one per character

        var idsSeen = new List<int>();
        foreach (var entry in roster)
        {
            string fieldName = Field(entry, "FieldName");
            var nameMatch = Regex.Match(fieldName, @"^Enable(\w+)$");
            Assert.True(nameMatch.Success, $"Roster FieldName '{fieldName}' does not match ^Enable(\\w+)$");
            string charName = nameMatch.Groups[1].Value;
            Assert.True(CharacterCatalog.NameToId.TryGetValue(charName, out int catalogId),
                $"Roster toggle '{fieldName}' names '{charName}', which is not in CharacterCatalog.NameToId");

            string description = Field(entry, "Description");
            var idMatch = Regex.Match(description, @"\((?:custom )?charId (\d+)\)");
            Assert.True(idMatch.Success, $"Roster Description '{description}' carries no '(charId N)' tag");
            int describedId = int.Parse(idMatch.Groups[1].Value);

            Assert.Equal(catalogId, describedId);
            idsSeen.Add(describedId);
        }

        Assert.Equal(CharacterCatalog.AllIds, idsSeen.OrderBy(i => i));
    }

    [Fact] // the default price list prices EVERY catalog charId, no extras and no gaps
    public void AmpConfig_CharacterPricesCsv_CoversAllCatalogIds()
    {
        var entry = Assert.Single(LoadAmpConfigEntries(), e => Field(e, "FieldName") == "CharacterPricesCsv");

        int[] pricedIds = Field(entry, "DefaultValue")
            .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(pair => int.Parse(pair.Split(':')[0]))
            .OrderBy(i => i)
            .ToArray();

        Assert.Equal(CharacterCatalog.AllIds, pricedIds);
    }

    [Fact] // map toggles: one per catalog id; shipped labels name the exact carrier level name
    public void AmpConfig_MapToggles_MatchMapCatalogAndCarrier()
    {
        string[] carrier = MelonMapHelpers.BuildKnownLevelNames();
        var toggles = LoadAmpConfigEntries()
            .Where(e => Field(e, "Category") == "BAPBAP - Maps" && Field(e, "FieldName").StartsWith("EnableMap", StringComparison.Ordinal))
            .ToArray();
        Assert.Equal(MapCatalog.IdToName.Count, toggles.Length); // exactly 5: shipped 1..4 + custom 5

        var shippedIdsSeen = new List<int>();
        var customIdsSeen = new List<int>();
        foreach (var entry in toggles)
        {
            string description = Field(entry, "Description");
            var shipped = Regex.Match(description, @"mapId (\d+) \(internal level name: (.+?)\)");
            if (shipped.Success)
            {
                int mapId = int.Parse(shipped.Groups[1].Value);
                string levelName = shipped.Groups[2].Value;
                Assert.Equal(MapCatalog.IdToName[mapId], levelName);
                Assert.Equal(carrier[mapId], levelName);
                shippedIdsSeen.Add(mapId);
                continue;
            }

            var custom = Regex.Match(description, @"\(mapId (\d+), (\w+)\)");
            Assert.True(custom.Success,
                $"Map toggle Description '{description}' matches neither the shipped nor the custom label format");
            Assert.Equal(MapCatalog.FirstCustomMapId, int.Parse(custom.Groups[1].Value));
            Assert.Equal(MapCatalog.IdToName[MapCatalog.CustomFlatId], custom.Groups[2].Value);
            customIdsSeen.Add(int.Parse(custom.Groups[1].Value));
        }

        Assert.Equal(
            new[] { MapCatalog.BazaarCityId, MapCatalog.LyceumId, MapCatalog.ArenaMap2Id, MapCatalog.OpenBetaBoccatoId },
            shippedIdsSeen.OrderBy(i => i));
        Assert.Equal(new[] { MapCatalog.FirstCustomMapId }, customIdsSeen);
    }
}

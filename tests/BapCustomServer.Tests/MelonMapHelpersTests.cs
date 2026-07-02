using BapCustomServerMelon;
using Xunit;

namespace BapCustomServer.Tests;

// F170 — GameMode level-name carrier table. KnownLevelNames maps shipped maps to their engine
// names and routes every custom slot (5..40) to the "Arena_Map2" carrier so the level-load
// coroutine never NullReferences before the custom-map hook runs. Pure logic from CustomServerMod,
// linked via MelonMapHelpers.cs.
public class MelonMapHelpersTests
{
    [Fact] // F170 — table is exactly 41 entries (indices 0..40); the cap that bug B25 depends on
    public void KnownLevelNames_HasExactly41Entries()
    {
        Assert.Equal(41, MelonMapHelpers.BuildKnownLevelNames().Length);
        Assert.Equal(41, MelonMapHelpers.LevelNameCount);
    }

    [Fact] // F170 — shipped maps map to their real engine level names
    public void KnownLevelNames_ShippedMapsResolve()
    {
        string[] n = MelonMapHelpers.BuildKnownLevelNames();
        Assert.Equal("Map2_BazaarCity 3", n[1]);
        Assert.Equal("Map3_Lyceum", n[2]);
        Assert.Equal("Arena_Map2", n[3]);
        Assert.Equal("OpenBetaMap#J02_P_Boccato", n[4]);
    }

    [Fact] // F170 — every custom slot (5..40) loads the Arena_Map2 carrier
    public void KnownLevelNames_CustomSlotsUseCarrier()
    {
        string[] n = MelonMapHelpers.BuildKnownLevelNames();
        for (int i = 5; i < n.Length; i++)
        {
            Assert.Equal("Arena_Map2", n[i]);
        }
    }

    [Fact] // F170 — no slot is left null (a null would NullReference the load coroutine)
    public void KnownLevelNames_NoNullEntries()
    {
        Assert.All(MelonMapHelpers.BuildKnownLevelNames(), name => Assert.False(string.IsNullOrEmpty(name)));
    }
}

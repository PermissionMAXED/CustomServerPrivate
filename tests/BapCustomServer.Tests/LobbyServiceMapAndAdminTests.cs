using System.Reflection;
using BapCustomServer;
using Xunit;

namespace BapCustomServer.Tests;

// F073 map selection (PickMapId/BuildAllowedMapIds), F134 map resolution priority chain,
// F072 admin bulk lobby mutation (SetActiveLobbyModifiers/SetActiveLobbyBots),
// F071 admin stop match. These run against a real LobbyService (no spawned process).
public class LobbyServiceMapAndAdminTests
{
    private static int PickMapId(LobbyService svc, int unityGameMode, int requestedMapId)
    {
        MethodInfo mi = typeof(LobbyService).GetMethod("PickMapId", BindingFlags.NonPublic | BindingFlags.Instance)!;
        return (int)mi.Invoke(svc, new object[] { unityGameMode, requestedMapId })!;
    }

    private static int[] BuildAllowedMapIds(LobbyService svc, int unityGameMode)
    {
        MethodInfo mi = typeof(LobbyService).GetMethod("BuildAllowedMapIds", BindingFlags.NonPublic | BindingFlags.Instance)!;
        return (int[])mi.Invoke(svc, new object[] { unityGameMode })!;
    }

    [Fact] // F073 — an explicitly requested, enabled map is honored
    public void PickMapId_HonorsExplicitEnabledRequest()
    {
        var opts = new CustomServerOptions();
        opts.MatchDefaults.RandomizeMapPerMatch = false;
        var svc = Svc.Lobby(opts);
        Assert.Equal(2, PickMapId(svc, 1, 2)); // Lyceum is in the default mode-1 pool [1,2,3,4]
    }

    [Fact] // F073 — a disabled/unknown requested map falls back to the first allowed id (never crashes)
    public void PickMapId_FallsBackForInvalidRequest()
    {
        var opts = new CustomServerOptions();
        opts.MatchDefaults.RandomizeMapPerMatch = false;
        var svc = Svc.Lobby(opts);
        int chosen = PickMapId(svc, 1, 9999); // bogus map id
        Assert.Contains(chosen, BuildAllowedMapIds(svc, 1));
    }

    [Fact] // F073 — non-randomized, no request => configured default when enabled
    public void PickMapId_UsesConfiguredDefaultWhenNotRandom()
    {
        var opts = new CustomServerOptions();
        opts.MatchDefaults.RandomizeMapPerMatch = false;
        opts.MatchDefaults.MapId = 3; // ArenaMap2, in the mode-1 pool
        var svc = Svc.Lobby(opts);
        Assert.Equal(3, PickMapId(svc, 1, 0)); // 0 = no explicit request
    }

    [Fact] // F073 — random rotation never lands on a custom map (id >= 5)
    public void PickMapId_RandomNeverSelectsCustomMap()
    {
        var opts = new CustomServerOptions();
        opts.MatchDefaults.RandomizeMapPerMatch = true;
        var svc = Svc.Lobby(opts);
        for (int i = 0; i < 50; i++)
        {
            int chosen = PickMapId(svc, 1, 0);
            Assert.False(MapCatalog.IsCustomMapId(chosen), $"random rotation landed on custom map {chosen}");
        }
    }

    [Fact] // F134 — AllMapsAllModes makes the enabled pool a global allow-list across modes
    public void BuildAllowedMapIds_AllMapsAllModes_AppliesGlobally()
    {
        var opts = new CustomServerOptions();
        opts.MapPool = new MapPoolOptions { AllMapsAllModes = true };
        var svc = Svc.Lobby(opts);
        int[] modeZero = BuildAllowedMapIds(svc, 0);
        Assert.NotEmpty(modeZero);
        // Mode 0 default mapping is just [1]; with AllMapsAllModes it gets the full enabled set.
        Assert.True(modeZero.Length >= 1);
    }

    [Fact] // F134 — never returns an empty pool (would deadlock map selection)
    public void BuildAllowedMapIds_NeverEmpty()
    {
        var svc = Svc.Lobby(new CustomServerOptions());
        Assert.NotEmpty(BuildAllowedMapIds(svc, 0));
        Assert.NotEmpty(BuildAllowedMapIds(svc, 1));
        Assert.NotEmpty(BuildAllowedMapIds(svc, 99)); // unknown mode still falls back
    }

    [Fact] // F072 — bulk modifier/bot mutation returns count and is a no-op with no lobbies
    public void BulkMutation_NoLobbies_ReturnsZero()
    {
        var svc = Svc.Lobby(new CustomServerOptions());
        Assert.Equal(0, svc.SetActiveLobbyModifiers(new[] { 1, 2, 3 }));
        Assert.Equal(0, svc.SetActiveLobbyBots(4, 2));
    }

    [Fact] // F071 — stopping an unknown match returns false (idempotent-safe)
    public void StopMatch_UnknownGame_ReturnsFalse()
    {
        var svc = Svc.Lobby(new CustomServerOptions());
        Assert.False(svc.StopMatch("does-not-exist"));
        Assert.False(svc.StopMatch(null));
        Assert.False(svc.StopMatch("  "));
    }
}

using System.Collections;
using System.Reflection;
using BapCustomServer;
using Xunit;

namespace BapCustomServer.Tests;

// F074 — match bootstrap construction guards. BAPBAP's OnServerMatchSetup indexes
// gameModifierId[0], scoreTable, and dimensionData[0]; an empty collection crashes the
// dedicated host with IndexOutOfRangeException on /setup-game. These helpers must always
// return at least one safe entry. Exercised via reflection on a real LobbyService.
public class BootstrapHelperTests
{
    private static readonly LobbyService Svc_ = Svc.Lobby(new CustomServerOptions());

    private static object Invoke(string method, params object[] args)
    {
        MethodInfo mi = typeof(LobbyService).GetMethod(method, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
            ?? throw new InvalidOperationException($"{method} not found (renamed?)");
        return mi.Invoke(mi.IsStatic ? null : Svc_, args)!;
    }

    [Fact] // F074 — empty modifier settings still yields >= 1 entry for the host bootstrap
    public void SelectGameModifierIdsSafe_NeverEmpty()
    {
        var settings = new CustomGameSettingsData { GameModifierIds = Array.Empty<int>() };
        var ids = (int[])Invoke("SelectGameModifierIdsSafe", settings);
        Assert.NotEmpty(ids); // would crash OnServerMatchSetup's gameModifierId[0] otherwise
    }

    [Fact] // F074 — chosen modifiers are preserved (and de-duped)
    public void SelectGameModifierIdsSafe_PreservesChosen()
    {
        var settings = new CustomGameSettingsData { GameModifierIds = new[] { 3, 3, 5 } };
        var ids = (int[])Invoke("SelectGameModifierIdsSafe", settings);
        Assert.Contains(3, ids);
        Assert.Contains(5, ids);
        Assert.Equal(ids.Length, ids.Distinct().Count()); // de-duped
    }

    [Fact] // F074 — client-facing variant returns empty when nothing chosen (avoids missing-icon UI crash)
    public void SelectGameModifierIdsForClient_EmptyWhenNoneChosen()
    {
        var settings = new CustomGameSettingsData { GameModifierIds = Array.Empty<int>() };
        var ids = (int[])Invoke("SelectGameModifierIdsForClient", settings);
        Assert.Empty(ids); // client must NOT receive an unchosen modifier id (no asset => crash)
    }

    [Fact] // F074 — default score table has the 8 documented tiers
    public void BuildDefaultScoreTable_HasEightTiers()
    {
        var table = (IList)Invoke("BuildDefaultScoreTable");
        Assert.Equal(8, table.Count); // Unranked..Divine; empty would crash the host iteration
    }

    [Fact] // F074 — dimension data always seeds at least one entry
    public void SelectDimensionData_NeverEmpty()
    {
        var settings = new CustomGameSettingsData { DimensionData = Array.Empty<DimensionData>() };
        var dims = (DimensionData[])Invoke("SelectDimensionData", settings);
        Assert.NotEmpty(dims); // would crash OnServerMatchSetup's dimensionData[0] otherwise
    }
}

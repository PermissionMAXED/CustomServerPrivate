using BapCustomServer;
using Xunit;

namespace BapCustomServer.Tests;

// F095 account JSON persistence + secret auth, F096 economy/stats/ranked fields, F097 admin actions.
public class PlayerStorageServiceTests
{
    [Fact] // F095
    public void GetOrCreate_PersistsAndReloads()
    {
        var dir = Svc.TempDir();
        var p1 = Svc.Players(dir);
        p1.GetOrCreatePlayer("a", "Alice", 1001);
        var p2 = Svc.Players(dir); // reload from disk
        var loaded = p2.GetPlayer("a");
        Assert.NotNull(loaded);
        Assert.Equal("Alice", loaded!.Username);
        Assert.Equal("a", p2.LookupAccountId("Alice"));
    }

    [Fact] // F095 secret auth
    public void Secret_SetValidateReset()
    {
        var dir = Svc.TempDir();
        var p = Svc.Players(dir);
        p.GetOrCreatePlayer("a", "Alice", 1001);
        Assert.False(p.ValidateSecret("a", "anything")); // no secret set yet
        string secret = p.GenerateAndSetSecret("a");
        Assert.True(p.ValidateSecret("a", secret));
        Assert.False(p.ValidateSecret("a", secret + "x"));
        p.ResetSecret("a", "admin");
        Assert.False(p.ValidateSecret("a", secret));
    }

    [Fact] // F096
    public void Economy_PurchaseGuardsBalanceAndDuplicate()
    {
        var dir = Svc.TempDir();
        var p = Svc.Players(dir);
        p.GetOrCreatePlayer("a", "Alice", 1001); // starts with 1000
        Assert.False(p.PurchaseAsset("a", 300010, 5000)); // too expensive
        Assert.True(p.PurchaseAsset("a", 300010, 400));
        Assert.True(p.HasAsset("a", 300010));
        Assert.False(p.PurchaseAsset("a", 300010, 100)); // already owned
        Assert.Equal(600, p.GetGold("a"));
    }

    [Fact] // F096
    public void RecordMatchResult_UpdatesStatsAndRanked()
    {
        var dir = Svc.TempDir();
        var p = Svc.Players(dir);
        p.GetOrCreatePlayer("a", "Alice", 1001);
        p.RecordMatchResult("a", kills: 4, deaths: 1, assists: 2, damageDealt: 1500, placement: 1, goldEarned: 300, rankedPointsDelta: 50);
        var d = p.GetPlayer("a")!;
        Assert.Equal(4, d.TotalKills);
        Assert.Equal(1, d.TotalWins);
        Assert.Equal(50, p.GetRankedPoints("a"));
    }

    [Fact] // F097 admin actions
    public void AdminActions_RenameBanWipeList()
    {
        var dir = Svc.TempDir();
        var p = Svc.Players(dir);
        p.GetOrCreatePlayer("a", "Alice", 1001);
        p.GetOrCreatePlayer("b", "Bob", 2002);
        p.RenamePlayer("a", "Alicia", "admin");
        Assert.Equal("Alicia", p.GetPlayer("a")!.Username);
        p.BanPlayer("b", "cheating", "admin");
        Assert.True(p.GetPlayer("b")!.IsBanned);
        p.UnbanPlayer("b", "admin");
        Assert.False(p.GetPlayer("b")!.IsBanned);
        Assert.Equal(2, p.ListAllPlayers().Length);
        p.WipePlayer("a", "admin");
        Assert.Null(p.GetPlayer("a"));
    }
}

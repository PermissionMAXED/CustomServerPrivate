using BapCustomServer;
using Xunit;

namespace BapCustomServer.Tests;

// F081 Economy currency balance, F082 owned assets, F083 match rewards,
// F084 mastery XP, F085 admin set/give gold + leaderboard, B14 regression.
public class EconomyServiceTests
{
    [Fact] // F081
    public void NewPlayer_StartsWithConfiguredGold()
    {
        var dir = Svc.TempDir();
        var e = Svc.Economy(dir, startingGold: 1000);
        e.GetOrCreatePlayer("a", "A");
        Assert.Equal(1000, e.GetGold("a"));
        Assert.Equal(0, e.GetGold("unknown")); // unknown account => 0
    }

    [Fact]
    public void NewPlayer_StartsWithConfiguredCharTokens()
    {
        var dir = Svc.TempDir();
        var e = Svc.Economy(dir, startingCharTokens: 7);
        e.GetOrCreatePlayer("a", "A");
        Assert.Equal(7, e.GetCharTokens("a"));
    }

    [Fact]
    public void CharacterPurchase_DeductsTokensPersistsAndIsIdempotent()
    {
        var dir = Svc.TempDir();
        var e = Svc.Economy(dir, startingCharTokens: 3);
        e.GetOrCreatePlayer("a", "A");

        int[] grants = CharacterUnlockService.UnlockAssetIdsFor(15);
        var first = e.PurchaseCharacter("a", "A", 15, 2, grants, "test");
        Assert.True(first.Ok);
        Assert.False(first.AlreadyOwned);
        Assert.Equal(1, first.NewCharTokenBalance);
        Assert.True(grants.All(assetId => e.HasAsset("a", assetId)));

        var second = e.PurchaseCharacter("a", "A", 15, 2, grants, "retry");
        Assert.True(second.Ok);
        Assert.True(second.AlreadyOwned);
        Assert.Equal(1, second.NewCharTokenBalance);

        var reloaded = Svc.Economy(dir, startingCharTokens: 3);
        Assert.Equal(1, reloaded.GetCharTokens("a"));
        Assert.True(grants.All(assetId => reloaded.HasAsset("a", assetId)));
    }

    [Fact]
    public void CharacterPurchase_InsufficientTokensDoesNotUnlock()
    {
        var dir = Svc.TempDir();
        var e = Svc.Economy(dir, startingCharTokens: 1);
        e.GetOrCreatePlayer("a", "A");

        int[] grants = CharacterUnlockService.UnlockAssetIdsFor(15);
        var result = e.PurchaseCharacter("a", "A", 15, 2, grants, "test");

        Assert.False(result.Ok);
        Assert.Equal(1, result.NewCharTokenBalance);
        Assert.DoesNotContain(grants, assetId => e.HasAsset("a", assetId));
    }

    [Fact] // F081
    public void AddGold_And_RemoveGold_RespectBalance()
    {
        var dir = Svc.TempDir();
        var e = Svc.Economy(dir);
        e.GetOrCreatePlayer("a", "A");
        Assert.True(e.AddGold("a", 500, "test").Ok);
        Assert.Equal(1500, e.GetGold("a"));
        Assert.False(e.RemoveGold("a", 99999, "test").Ok); // insufficient funds rejected
        Assert.Equal(1500, e.GetGold("a"));
        Assert.True(e.RemoveGold("a", 500, "test").Ok);
        Assert.Equal(1000, e.GetGold("a"));
    }

    [Fact] // F082
    public void PurchaseGrantRevoke_AssetOwnership()
    {
        var dir = Svc.TempDir();
        var e = Svc.Economy(dir);
        e.GetOrCreatePlayer("a", "A");
        Assert.True(e.GrantAsset("a", 500001, "test").Ok);
        Assert.True(e.HasAsset("a", 500001));
        Assert.False(e.GrantAsset("a", 500001, "test").Ok); // duplicate rejected
        Assert.True(e.RevokeAsset("a", 500001, "test").Ok);
        Assert.False(e.HasAsset("a", 500001));
        Assert.False(e.RevokeAsset("a", 500001, "test").Ok); // not-owned rejected
    }

    [Fact] // F082
    public void Purchase_DeductsGold_AndRejectsWhenBroke()
    {
        var dir = Svc.TempDir();
        var e = Svc.Economy(dir, startingGold: 100);
        e.GetOrCreatePlayer("a", "A");
        Assert.False(e.PurchaseAsset("a", 300010, 500).Ok); // can't afford
        Assert.True(e.PurchaseAsset("a", 300010, 100).Ok);
        Assert.Equal(0, e.GetGold("a"));
        Assert.True(e.HasAsset("a", 300010));
    }

    [Fact] // F083
    public void MatchReward_ScalesWithPlacementAndKills()
    {
        var dir = Svc.TempDir();
        var e = Svc.Economy(dir);
        var first = e.CalculateMatchReward("a", placement: 1, kills: 3, totalPlayers: 8);
        var last = e.CalculateMatchReward("a", placement: 8, kills: 0, totalPlayers: 8);
        Assert.True(first.TotalGold > last.TotalGold); // winning + kills pays more
    }

    [Fact] // F084
    public void RecordCharacterXp_LevelsUp_AndClampsAt100()
    {
        var dir = Svc.TempDir();
        var e = Svc.Economy(dir);
        var p = e.RecordCharacterXp("a", "A", 15, 50, "test");
        Assert.Equal(1, p.CurrentLevel);
        p = e.RecordCharacterXp("a", "A", 15, 250, "test"); // 300 xp total => level 4
        Assert.Equal(4, p.CurrentLevel);
        e.RecordCharacterXp("a", "A", 15, 100000, "test"); // way over cap
        Assert.Equal(100, e.GetCharacterMasteryProgress("a", 15).CurrentLevel);
    }

    [Fact] // F084 — unknown charId rejected
    public void RecordCharacterXp_UnknownChar_Throws()
    {
        var dir = Svc.TempDir();
        var e = Svc.Economy(dir);
        Assert.ThrowsAny<Exception>(() => e.RecordCharacterXp("a", "A", 999, 50, "test"));
    }

    [Fact] // F085 + B14 regression: over-draw must not over-count TotalGoldSpent
    public void AdminGiveGold_NegativeOverDraw_ClampsSpentToActualRemoved()
    {
        var dir = Svc.TempDir();
        var e = Svc.Economy(dir, startingGold: 100);
        e.GetOrCreatePlayer("a", "A");
        e.AdminGiveGold("a", -500, "admin"); // take 500 from a player with 100
        var player = e.GetAllPlayers().Single(p => p.AccountId == "a");
        Assert.Equal(0, player.Gold);
        Assert.Equal(100, player.TotalGoldSpent); // only the 100 actually held, not 500
    }

    [Fact] // Phase-3 regression: int.MinValue must not throw or corrupt persisted gold
    public void AdminGiveGold_IntMinValue_ClampsAndCountsActualSpent()
    {
        var dir = Svc.TempDir();
        var e = Svc.Economy(dir, startingGold: 100);
        e.GetOrCreatePlayer("a", "A");

        var result = e.AdminGiveGold("a", int.MinValue, "admin");

        Assert.True(result.Ok);
        var player = e.GetAllPlayers().Single(p => p.AccountId == "a");
        Assert.Equal(0, player.Gold);
        Assert.Equal(100, player.TotalGoldSpent);
    }

    [Fact] // Phase-3 regression: huge positive grant clamps instead of overflowing negative
    public void AdminGiveGold_PositiveOverflow_ClampsToIntMax()
    {
        var dir = Svc.TempDir();
        var e = Svc.Economy(dir, startingGold: int.MaxValue - 10);
        e.GetOrCreatePlayer("a", "A");

        var result = e.AdminGiveGold("a", 100, "admin");

        Assert.True(result.Ok);
        Assert.Equal(int.MaxValue, e.GetGold("a"));
    }

    [Fact] // F085
    public void Leaderboard_OrdersByGoldDescending()
    {
        var dir = Svc.TempDir();
        var e = Svc.Economy(dir, startingGold: 0);
        e.GetOrCreatePlayer("a", "A"); e.AddGold("a", 300, "t");
        e.GetOrCreatePlayer("b", "B"); e.AddGold("b", 900, "t");
        e.GetOrCreatePlayer("c", "C"); e.AddGold("c", 600, "t");
        var board = e.GetLeaderboard(10);
        Assert.Equal(new[] { "b", "c", "a" }, board.Select(p => p.AccountId).ToArray());
    }

    [Fact] // F081 persistence: state survives a reload from disk
    public void State_PersistsAcrossInstances()
    {
        var dir = Svc.TempDir();
        var e1 = Svc.Economy(dir);
        e1.GetOrCreatePlayer("a", "A");
        e1.AddGold("a", 250, "t");
        var e2 = Svc.Economy(dir); // reloads same StateFile
        Assert.Equal(1250, e2.GetGold("a"));
    }
}

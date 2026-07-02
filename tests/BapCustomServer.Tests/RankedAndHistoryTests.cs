using BapCustomServer;
using Xunit;

namespace BapCustomServer.Tests;

// F092 per-match rating, F093 leaderboard/position/admin overrides.
public class RankedServiceTests
{
    [Fact] // F092
    public void NewPlayer_StartsAtConfiguredPoints()
    {
        var r = Svc.Ranked(Svc.TempDir(), starting: 1000);
        var p = r.GetOrCreatePlayer("a", "A");
        Assert.Equal(1000, p.Points);
    }

    [Fact] // F092
    public void ProcessMatch_WinGainsPoints_LossCanLose()
    {
        var r = Svc.Ranked(Svc.TempDir());
        r.ProcessMatchResult("a", "A", placement: 1, kills: 5, totalPlayers: 8);
        Assert.True(r.GetOrCreatePlayer("a", "A").Points > 1000); // winning gains
        Assert.Equal(1, r.GetOrCreatePlayer("a", "A").Wins);
        // Placing beyond the points table (here 8 slots) applies LossPoints.
        r.ProcessMatchResult("b", "B", placement: 12, kills: 0, totalPlayers: 16);
        Assert.True(r.GetOrCreatePlayer("b", "B").Points < 1000); // eliminated early loses
    }

    [Fact] // F092 points floored at minimum
    public void Points_NeverGoBelowFloor()
    {
        var r = Svc.Ranked(Svc.TempDir(), starting: 5);
        for (int i = 0; i < 20; i++) r.ProcessMatchResult("a", "A", placement: 8, kills: 0, totalPlayers: 8);
        Assert.True(r.GetOrCreatePlayer("a", "A").Points >= 0);
    }

    [Fact] // F093
    public void Leaderboard_OrdersByPoints_PositionIsOneBased()
    {
        var r = Svc.Ranked(Svc.TempDir(), starting: 1000);
        r.ProcessMatchResult("a", "A", 1, 10, 8); // gains most
        r.ProcessMatchResult("b", "B", 4, 1, 8);
        var board = r.GetLeaderboard(10);
        Assert.Equal("a", board[0].AccountId);
        Assert.True(r.GetPlayerPosition("a") >= 1);
        Assert.Equal(-1, r.GetPlayerPosition("nobody"));
    }

    [Fact] // F093 admin overrides
    public void AdminSetPoints_And_Reset()
    {
        var r = Svc.Ranked(Svc.TempDir());
        r.GetOrCreatePlayer("a", "A");
        r.AdminSetPoints("a", 2500, "admin");
        Assert.Equal(2500, r.GetOrCreatePlayer("a", "A").Points);
        r.AdminResetPlayer("a", "admin");
        // After reset the profile is recreated at starting points on next access.
        Assert.Equal(1000, r.GetOrCreatePlayer("a", "A").Points);
    }

    [Fact] // F093 tier helpers are pure + monotonic
    public void RankTier_IsMonotonic()
    {
        Assert.True(RankedService.GetRankTier(2000) >= RankedService.GetRankTier(500));
        Assert.False(string.IsNullOrWhiteSpace(RankedService.GetRankTierName(RankedService.GetRankTier(1000))));
    }
}

// F094 match history recording + query.
public class MatchHistoryServiceTests
{
    [Fact] // F094
    public void RecordAndQuery_RecentByGameByPlayer()
    {
        var h = Svc.History(Svc.TempDir());
        h.RecordMatch(new MatchHistoryEntry
        {
            GameId = "g1",
            Players = new() { new MatchPlayerEntry { AccountId = "a", Username = "A" } }
        });
        Assert.Single(h.GetRecentMatches(10));
        Assert.NotNull(h.GetMatch("g1"));
        Assert.Null(h.GetMatch("missing"));
        Assert.Single(h.GetPlayerMatches("a", 10));
    }

    [Fact] // F094 ignores entries with no GameId
    public void RecordMatch_IgnoresMissingGameId()
    {
        var h = Svc.History(Svc.TempDir());
        h.RecordMatch(new MatchHistoryEntry { GameId = "" });
        Assert.Empty(h.GetRecentMatches(10));
    }

    [Fact] // F094 in-memory ring buffer capped, newest first
    public void RecentMatches_AreNewestFirst()
    {
        var h = Svc.History(Svc.TempDir());
        h.RecordMatch(new MatchHistoryEntry { GameId = "old", EndedUtc = DateTimeOffset.UtcNow.AddMinutes(-10) });
        h.RecordMatch(new MatchHistoryEntry { GameId = "new", EndedUtc = DateTimeOffset.UtcNow });
        Assert.Equal("new", h.GetRecentMatches(10)[0].GameId);
    }
}

using System.Text.RegularExpressions;
using BapCustomServer;
using Xunit;

namespace BapCustomServer.Tests;

// F144 — AMP analytics regexes. These extract player/match time series from the server's
// log lines, so each default regex must actually match the log format LobbyService emits.
public class AnalyticsRegexTests
{
    private static Match M(string pattern, string line) => Regex.Match(line, pattern);

    [Fact] // join regex matches the real "Client {id} connected. admin=..." line and captures the id
    public void PlayerJoinRegex_MatchesRealLine()
    {
        var o = new AnalyticsOptions();
        var m = M(o.PlayerJoinRegex, "Client custom-3 connected. admin=False");
        Assert.True(m.Success);
        Assert.Equal("custom-3", m.Groups["player"].Value);
    }

    [Fact] // leave regex matches "Client {id} disconnected."
    public void PlayerLeaveRegex_MatchesRealLine()
    {
        var o = new AnalyticsOptions();
        var m = M(o.PlayerLeaveRegex, "Client custom-7 disconnected.");
        Assert.True(m.Success);
        Assert.Equal("custom-7", m.Groups["player"].Value);
    }

    [Fact] // B26 regression: match-start regex must match the ACTUAL "[Analytics] Match started:" line
    public void MatchStartRegex_MatchesRealLine()
    {
        var o = new AnalyticsOptions();
        // This is the literal format LobbyService logs at match start.
        var m = M(o.MatchStartRegex, "[Analytics] Match started: custom-20260622-1234 mapId=1 players=8");
        Assert.True(m.Success);
        Assert.Equal("custom-20260622-1234", m.Groups["match"].Value);
    }

    [Fact] // end regex matches "Game ended: {id}"
    public void MatchEndRegex_MatchesRealLine()
    {
        var o = new AnalyticsOptions();
        var m = M(o.MatchEndRegex, "Game ended: custom-20260622-1234");
        Assert.True(m.Success);
        Assert.Equal("custom-20260622-1234", m.Groups["match"].Value);
    }

    [Fact] // all default regexes must be valid patterns (no ArgumentException on compile)
    public void AllDefaultRegexes_AreValid()
    {
        var o = new AnalyticsOptions();
        foreach (string p in new[] { o.PlayerJoinRegex, o.PlayerLeaveRegex, o.MatchStartRegex, o.MatchEndRegex })
        {
            _ = new Regex(p); // throws if invalid
        }
    }
}

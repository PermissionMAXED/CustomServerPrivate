using BapCustomServer;
using Xunit;

namespace BapCustomServer.Tests;

// Pure config-option logic: F132 match defaults, F137 port ranges, F138 queue/concurrency,
// F139 bootstrap timeouts, F140 prewarm options, F141 unlock ownership, F142 AMP shop slots,
// F143 network tuning, F144 analytics, F135 launch toggles, F136 launcher templates.
public class ConfigOptionsTests
{
    [Fact] // F141 — master switch forces every Effective* flag on
    public void UnlockOptions_MasterSwitchOverridesPerCategory()
    {
        var u = new UnlockOptions
        {
            UnlockEverything = true,
            UnlockAllEmotes = false,
            UnlockAllTombstones = false,
            GrantAllCurrencies = false
        };
        Assert.True(u.EffectiveUnlockSkins);
        Assert.True(u.EffectiveUnlockEmotes);       // forced on by master
        Assert.True(u.EffectiveUnlockTombstones);   // forced on by master
        Assert.True(u.EffectiveGrantCurrencies);    // forced on by master
    }

    [Fact] // F141 — per-category defaults when master off (skins/banners on, emotes/mastery/tombstones off)
    public void UnlockOptions_PerCategoryDefaults()
    {
        var u = new UnlockOptions(); // master off
        Assert.True(u.EffectiveUnlockSkins);
        Assert.True(u.EffectiveUnlockBanners);
        Assert.False(u.EffectiveUnlockEmotes);      // fragile emote IDs default off
        Assert.False(u.EffectiveUnlockMasteryBadges);
        Assert.False(u.EffectiveUnlockTombstones);
        Assert.True(u.EffectiveGrantCurrencies);
    }

    [Fact] // F142 — AnySlotConfigured detects an operator-set slot
    public void ShopSlotOptions_AnySlotConfigured()
    {
        Assert.False(new ShopSlotOptions().AnySlotConfigured); // all zero
        Assert.True(new ShopSlotOptions { Slot2AssetId = 500121 }.AnySlotConfigured);
        Assert.True(new ShopSlotOptions { FreebieAssetId = 500002 }.AnySlotConfigured);
    }

    [Fact] // F132 — match defaults expose the documented baseline + the 20s char-select minimum
    public void MatchDefaults_HaveExpectedBaseline()
    {
        var m = new MatchDefaults();
        Assert.Equal("custom", m.RegionId);
        Assert.Equal(8, m.MaxTeams);
        Assert.Equal(20000, m.CharSelectMillis);
        Assert.True(m.RandomizeMapPerMatch);
        Assert.Equal("0,3,4,5,9,10", m.EnabledGameModeIdsCsv); // Warmup/Training, Solos, Duos, Trios, FFA, Custom
        Assert.Equal(CharacterCatalog.AllIds, m.AvailableCharacters);
    }

    [Fact] // F143 — network tuning defaults (forwarded to dedicated server; no lobby effect)
    public void NetworkTuningOptions_Defaults()
    {
        var n = new NetworkTuningOptions();
        Assert.True(n.Enabled);
        Assert.Equal(60, n.SendRate);
        Assert.Equal(4096, n.KcpSendWindow);
        Assert.True(n.DisableInterpolationForProjectiles); // AI-projectile desync workaround
    }

    [Fact] // F137 — external game-server endpoint defaults
    public void ExternalGameServerOptions_Defaults()
    {
        var e = new ExternalGameServerOptions();
        Assert.Equal("127.0.0.1", e.Hostname);
        Assert.Equal(7777, e.WsPort);
        Assert.Equal(7778, e.KcpPort);
        Assert.Equal(7779, e.TcpPort);
    }

    [Fact] // F137/F138/F139/F140/F135/F136 — top-level server option defaults are sane
    public void CustomServerOptions_TopLevelDefaults()
    {
        var o = new CustomServerOptions();
        Assert.Equal(MatchmakingPolicy.Both, o.MatchmakingPolicy);   // F129
        Assert.True(o.LaunchGameServers);                            // F135
        Assert.True(o.RequireGameServerBootstrap);                   // F135 fail-closed
        Assert.Equal(7850, o.BaseHttpPort);                          // F137
        Assert.Equal(200, o.PortSearchRange);                        // F137
        Assert.Equal(0, o.MaxConcurrentMatches);                     // F138 unlimited
        Assert.False(string.IsNullOrEmpty(o.BootstrapConnectPath));  // F136/F139
    }

    [Fact] // F047 — matchmaking queue default match settings match the documented baseline
    public void MatchmakingQueueOptions_DefaultMatchSettings()
    {
        var q = new MatchmakingQueueOptions();
        Assert.Equal(30, q.QueueTimerSeconds);
        Assert.Equal(5, q.FailedStartRetryDelaySeconds);
        Assert.Equal(5, q.MaxMatchStartFailures);
        Assert.Equal(1, q.MinPlayersToStart);
        Assert.Equal(4, q.DefaultBotCount);
        Assert.Equal(4, q.MaxBotCount);
        Assert.Equal(1, q.DefaultBotDifficulty);
        Assert.Equal(1, q.DefaultMapId);
        Assert.Equal(3, q.DefaultGameMode);   // Solos
        Assert.Equal(8, q.DefaultMaxTeams);
        Assert.Equal(1, q.DefaultTeamSize);
    }

    [Fact] // F151 — AMP analytics default regexes compile and match the real log lines LobbyService emits
    public void AnalyticsOptions_DefaultRegexesCompileAndMatchLogLines()
    {
        var a = new AnalyticsOptions();
        Assert.True(a.Enabled);
        Assert.Equal("", a.ChatMessageRegex); // chat disabled by default

        var join = System.Text.RegularExpressions.Regex.Match("Client custom-3 connected. admin=False", a.PlayerJoinRegex);
        Assert.True(join.Success);
        Assert.Equal("custom-3", join.Groups["player"].Value);

        var leave = System.Text.RegularExpressions.Regex.Match("Client custom-3 disconnected.", a.PlayerLeaveRegex);
        Assert.True(leave.Success);
        Assert.Equal("custom-3", leave.Groups["player"].Value);

        var start = System.Text.RegularExpressions.Regex.Match("[Analytics] Match started: GAME123 mapId=1 players=4", a.MatchStartRegex);
        Assert.True(start.Success);
        Assert.Equal("GAME123", start.Groups["match"].Value);

        var end = System.Text.RegularExpressions.Regex.Match("Game ended: GAME123", a.MatchEndRegex);
        Assert.True(end.Success);
        Assert.Equal("GAME123", end.Groups["match"].Value);
    }

    [Fact] // F158 — static shop item DTO holds the AMP-supplied listing shape
    public void StaticShopItem_HoldsListingShape()
    {
        var item = new StaticShopItem { AssetId = 500121, Name = "Banner_Foo", Price = 250, Category = "banner" };
        Assert.Equal(500121, item.AssetId);
        Assert.Equal("Banner_Foo", item.Name);
        Assert.Equal(250, item.Price);
        Assert.Equal("banner", item.Category);
        Assert.Equal("", new StaticShopItem().Name); // empty defaults, not null
        Assert.Equal("", new StaticShopItem().Category);
    }
}

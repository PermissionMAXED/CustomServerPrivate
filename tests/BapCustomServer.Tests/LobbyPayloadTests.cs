using System.Reflection;
using BapCustomServer;
using Xunit;

namespace BapCustomServer.Tests;

// F014 QUEUE_MATCHED pre-match payload, F015 match bootstrap construction.
// CreateQueueMatchedPayload / CreateBootstrap are pure construction methods on LobbyService (no socket,
// no spawn) that turn a CustomLobby into the payloads the client/dedicated server need. They are private,
// so we invoke them via reflection against a real LobbyService built with LaunchGameServers=false.
// Internal types (CustomLobby, LobbyPlayer) are reachable here via InternalsVisibleTo.
public class LobbyPayloadTests
{
    private static LobbyService NewLobbyService() => Svc.Lobby(new CustomServerOptions { LaunchGameServers = false });

    private static CustomLobby BuildLobby()
    {
        var lobby = new CustomLobby
        {
            Id = "TESTLOBBY",
            LeaderAccountId = "leader",
            CustomSettings = new CustomGameSettingsData
            {
                Gamemode = 3,        // Solos
                MapId = 1,
                TeamSize = 1,
                MaxTeams = 4,
                BotCount = 2,
                BotDifficulty = 1,
                CharSelectMillis = 5000 // below the 20000 minimum on purpose -> must be normalized up
            }
        };
        lobby.Players["leader"] = new LobbyPlayer(
            new PlayerData { AccountId = "leader", Username = "Leader", CharId = 7, TeamId = 1, Level = 5, BannerId = 42 },
            "auth-leader");
        lobby.Players["b"] = new LobbyPlayer(
            new PlayerData { AccountId = "b", Username = "Bee", CharId = 15, TeamId = 2, Level = 3 },
            "auth-b");
        return lobby;
    }

    private static QueueMatchedPayload InvokeCreateQueueMatchedPayload(LobbyService svc, CustomLobby lobby, int mapId)
    {
        MethodInfo mi = typeof(LobbyService).GetMethod("CreateQueueMatchedPayload", BindingFlags.NonPublic | BindingFlags.Instance)
            ?? throw new InvalidOperationException("CreateQueueMatchedPayload not found (renamed?)");
        return (QueueMatchedPayload)mi.Invoke(svc, new object[] { lobby, mapId })!;
    }

    private static MatchBootstrap InvokeCreateBootstrap(LobbyService svc, CustomLobby lobby, string gameId, int mapId)
    {
        MethodInfo mi = typeof(LobbyService).GetMethod("CreateBootstrap", BindingFlags.NonPublic | BindingFlags.Instance)
            ?? throw new InvalidOperationException("CreateBootstrap not found (renamed?)");
        return (MatchBootstrap)mi.Invoke(svc, new object[] { lobby, gameId, mapId })!;
    }

    [Fact] // F014 — every pre-match field is populated; arrays non-empty; char-select clamped to >=20000ms
    public void QueueMatchedPayload_AllFieldsPopulated()
    {
        var svc = NewLobbyService();
        var payload = InvokeCreateQueueMatchedPayload(svc, BuildLobby(), mapId: 1);

        Assert.Equal(2, payload.Players.Length);
        Assert.Equal(2, payload.CurrentPlayerCount);
        Assert.True(payload.MaxPlayerCount >= 2);
        Assert.True(payload.CharSelectMillis >= 20000, "char-select millis must be normalized up to the 20s minimum");
        Assert.NotEmpty(payload.AvailableCharacters);            // never a null/empty array (client NRE guard)
        Assert.NotEmpty(payload.DimensionData);                  // at least one dimension
        Assert.Equal(1, payload.LevelId);
        Assert.True(payload.UnityGameMode > 0);                  // matchmaking id mapped to a Unity gamemode
    }

    [Fact] // F015 — bootstrap forces SkinAssetId=-1 for every player (root-cause fix for "always spawn as Skinny")
    public void Bootstrap_ForcesDefaultSkinAndOrdersPlayers()
    {
        var svc = NewLobbyService();
        MatchBootstrap bootstrap = InvokeCreateBootstrap(svc, BuildLobby(), "GAME99", mapId: 1);

        Assert.Equal("GAME99", bootstrap.GameData.QueueId == "TESTLOBBY" ? "GAME99" : bootstrap.TeamData.GameId);
        var players = bootstrap.TeamData.Players;
        Assert.Equal(2, players.Count);
        Assert.All(players, p => Assert.Equal(-1, p.SkinAssetId));      // -1 => selected charId's prefab spawns
        Assert.All(players, p => Assert.True(p.PlayerId >= 1));         // 1-based PlayerId assigned
        // Ordered by team then account: leader(team1) before b(team2).
        Assert.Equal("leader", players[0].AccountId);
        Assert.Equal("b", players[1].AccountId);
        Assert.Equal(7, players[0].CharId);                            // selected char carried through
        Assert.Equal(15, players[1].CharId);
    }

    [Fact] // F015 — bootstrap game data carries a non-empty modifier id, an 8-tier score table, and >=1 dimension
    public void Bootstrap_GameDataHasSafeDefaults()
    {
        var svc = NewLobbyService();
        MatchBootstrap bootstrap = InvokeCreateBootstrap(svc, BuildLobby(), "GAME99", mapId: 3);

        Assert.Equal(3, bootstrap.GameData.MapId);
        Assert.True(bootstrap.GameData.UnityGameModeId > 0);
        Assert.NotEmpty(bootstrap.GameData.GameModifierId);            // Safe variant guarantees >=1
        Assert.Equal(8, bootstrap.GameData.ScoreTable.Count);         // 8-tier default score table
        Assert.NotEmpty(bootstrap.GameData.DimensionData);            // at least one dimension
        Assert.Equal(2, bootstrap.TeamData.BotTeams);                 // bot count carried from CustomSettings
    }
}

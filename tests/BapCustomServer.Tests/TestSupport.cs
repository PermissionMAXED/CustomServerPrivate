using BapCustomServer;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Xunit;

namespace BapCustomServer.Tests;

// Shared helpers: build services pointed at a throwaway temp directory so tests never
// touch the repo's real data/ files and don't collide with each other.
internal static class Svc
{
    public static string TempDir()
    {
        string dir = Path.Combine(Path.GetTempPath(), "bapcustom-tests", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(dir);
        return dir;
    }

    public static EconomyService Economy(string dir, int startingGold = 1000, int startingCharTokens = 10)
    {
        var opts = new EconomyOptions { StateFile = Path.Combine(dir, "economy.json"), StartingGold = startingGold, StartingCharTokens = startingCharTokens };
        return new EconomyService(Options.Create(opts), NullLogger<EconomyService>.Instance);
    }

    public static FriendsService Friends(string dir, int maxFriends = 100, int maxPending = 50)
    {
        var opts = new FriendsOptions { StateFile = Path.Combine(dir, "friends.json"), MaxFriendsPerPlayer = maxFriends, MaxPendingRequests = maxPending };
        return new FriendsService(Options.Create(opts), NullLogger<FriendsService>.Instance);
    }

    public static RankedService Ranked(string dir, int starting = 1000)
    {
        var opts = new RankedOptions { StateFile = Path.Combine(dir, "ranked.json"), StartingPoints = starting };
        return new RankedService(Options.Create(opts), NullLogger<RankedService>.Instance);
    }

    public static MatchHistoryService History(string dir, int max = 200)
    {
        var opts = new MatchHistoryOptions { LogFile = Path.Combine(dir, "history.jsonl"), MaxInMemoryEntries = max };
        return new MatchHistoryService(Options.Create(opts), NullLogger<MatchHistoryService>.Instance);
    }

    public static PlayerStorageService Players(string dir)
    {
        var opts = new PlayerStorageOptions { PlayersDirectory = Path.Combine(dir, "players") };
        return new PlayerStorageService(Options.Create(opts), NullLogger<PlayerStorageService>.Instance);
    }

    public static MatchmakingQueueService Queue(int timer = 30, int minPlayers = 1, int retryDelay = 5, int maxFailures = 5)
    {
        var opts = new MatchmakingQueueOptions
        {
            QueueTimerSeconds = timer,
            MinPlayersToStart = minPlayers,
            FailedStartRetryDelaySeconds = retryDelay,
            MaxMatchStartFailures = maxFailures
        };
        return new MatchmakingQueueService(Options.Create(opts), NullLogger<MatchmakingQueueService>.Instance);
    }

    private sealed class StubHttpClientFactory : System.Net.Http.IHttpClientFactory
    {
        public HttpClient CreateClient(string name) => new();
    }

    // Build a real LobbyService against the given options. No game process is spawned by
    // construction; only the start paths spawn, which these tests do not call.
    public static LobbyService Lobby(CustomServerOptions opts)
    {
        string dir = TempDir();
        var prewarm = new GameServerPrewarmService(Options.Create(opts), new StubEnv(dir), NullLogger<GameServerPrewarmService>.Instance);
        var gameServers = new GameServerProcessManager(
            Options.Create(opts), new StubEnv(dir), new PortAllocator(),
            new StubHttpClientFactory(), prewarm, NullLogger<GameServerProcessManager>.Instance);
        var admin = new ServerAdminService(Options.Create(new AdminOptions
        {
            StateFile = System.IO.Path.Combine(dir, "admin.json"),
            AuditLogFile = System.IO.Path.Combine(dir, "audit.jsonl")
        }), new StubEnv(dir), NullLogger<ServerAdminService>.Instance);
        var economy = Economy(dir);
        var friends = Friends(dir);
        var ranked = Ranked(dir);
        var history = History(dir);
        var queue = Queue();
        var queueOpts = Options.Create(new MatchmakingQueueOptions());
        var overrides = new PlayerOverridesService(Options.Create(new PlayerOverridesOptions
        {
            StateFile = System.IO.Path.Combine(dir, "player-overrides.json")
        }), NullLogger<PlayerOverridesService>.Instance);
        var characterUnlocks = new CharacterUnlockService(Options.Create(opts), overrides);
        var adminOpts = Options.Create(new AdminOptions
        {
            StateFile = System.IO.Path.Combine(dir, "admin.json"),
            AuditLogFile = System.IO.Path.Combine(dir, "audit.jsonl"),
            AttestationSecret = "test-attestation-secret"
        });
        return new LobbyService(
            Options.Create(opts), gameServers, admin, friends, economy, history,
            ranked, queue, queueOpts, adminOpts, characterUnlocks, NullLogger<LobbyService>.Instance);
    }
}

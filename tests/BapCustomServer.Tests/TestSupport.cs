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

    // ---- WebApplicationFactory host-fixture helpers -----------------------------------------

    /// <summary>
    /// EVERY persisted-state config key the server writes, redirected into the fixture's
    /// throwaway <paramref name="dataDir"/>. Host factories must merge the FULL set: any service
    /// left at its default path resolves against AppContext.BaseDirectory and re-contaminates the
    /// shared test-bin data/ dir. PlayerOverridesService is the worst offender — it regenerates an
    /// unlockEverything:true default document at any missing StateFile path. Layer test-specific
    /// keys on top of the returned dictionary before AddInMemoryCollection.
    /// </summary>
    public static Dictionary<string, string?> StateFileRedirects(string dataDir) => new()
    {
        ["CustomServer:Economy:StateFile"] = Path.Combine(dataDir, "economy.json"),
        ["CustomServer:Friends:StateFile"] = Path.Combine(dataDir, "friends.json"),
        ["CustomServer:Ranked:StateFile"] = Path.Combine(dataDir, "ranked.json"),
        ["CustomServer:MatchHistory:LogFile"] = Path.Combine(dataDir, "history.jsonl"),
        ["CustomServer:Admin:StateFile"] = Path.Combine(dataDir, "admin.json"),
        ["CustomServer:Admin:AuditLogFile"] = Path.Combine(dataDir, "audit.jsonl"),
        ["CustomServer:PlayerStorage:PlayersDirectory"] = Path.Combine(dataDir, "players"),
        ["CustomServer:PlayerOverrides:StateFile"] = Path.Combine(dataDir, "player-overrides.json"),
        ["CustomServer:Shop:StateFile"] = Path.Combine(dataDir, "shop-state.json"),
    };

    /// <summary>
    /// Pre-seeds a NEUTRAL player-overrides document (empty defaults) at the path
    /// <see cref="StateFileRedirects"/> points PlayerOverrides:StateFile at, so
    /// PlayerOverridesService loads it verbatim at boot instead of regenerating its
    /// unlockEverything:true default (which would make every character owned in the fixture).
    /// Call after Directory.CreateDirectory(DataDir), before the host boots.
    /// </summary>
    public static void WriteNeutralPlayerOverrides(string dataDir) =>
        File.WriteAllText(
            Path.Combine(dataDir, "player-overrides.json"),
            """{ "defaults": {}, "players": {} }""");

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

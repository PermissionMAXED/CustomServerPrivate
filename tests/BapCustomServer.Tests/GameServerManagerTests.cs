using System.Net;
using System.Net.Sockets;
using System.Reflection;
using BapCustomServer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Xunit;

namespace BapCustomServer.Tests;

// F108 external game-server passthrough (no spawn), F124 prewarm readiness signalling,
// F123 prewarm run gating (skips when not enabled). These manager paths do NOT spawn a
// real game process, so they are executable here.
public class GameServerManagerTests
{
    private sealed class StubHttpClientFactory : IHttpClientFactory
    {
        public HttpClient CreateClient(string name) => new();
    }

    private static GameServerPrewarmService Prewarm(CustomServerOptions opts)
        => new(Options.Create(opts), new StubEnv(Svc.TempDir()), NullLogger<GameServerPrewarmService>.Instance);

    private static GameServerProcessManager Manager(CustomServerOptions opts)
        => new(
            Options.Create(opts),
            new StubEnv(Svc.TempDir()),
            new PortAllocator(),
            new StubHttpClientFactory(),
            Prewarm(opts),
            NullLogger<GameServerProcessManager>.Instance);

    private static MatchBootstrap Bootstrap() => new(
        "test-game-1",
        new MatchmakingGameData { MapId = 3, UnityGameModeId = 1 },
        new MatchmakingTeamData(),
        new QueueMatchedData());

    [Fact] // F108 — LaunchGameServers=false returns the configured external endpoint, no process
    public async Task ExternalPassthrough_ReturnsConfiguredEndpoint()
    {
        var opts = new CustomServerOptions
        {
            LaunchGameServers = false,
            ExternalGameServer = new ExternalGameServerOptions
            {
                Hostname = "game.example.com",
                WsPort = 9001,
                KcpPort = 9002,
                TcpPort = 9003
            }
        };
        var mgr = Manager(opts);
        GameServerSession session = await mgr.StartMatchServerAsync(Bootstrap(), CancellationToken.None);

        Assert.Equal("game.example.com", session.Hostname);
        Assert.Equal(9001, session.WsPort);
        Assert.Equal(9002, session.KcpPort);
        Assert.Equal(9003, session.TcpPort);
        Assert.Null(session.Process);          // nothing spawned
        Assert.Equal(3, session.MapId);        // bootstrap data carried through
        Assert.Equal(1, session.UnityGameModeId);
    }

    [Fact] // F124 — prewarm disabled => WaitForStartupPrewarmAsync returns immediately (current Ready)
    public async Task PrewarmWait_ReturnsImmediatelyWhenDisabled()
    {
        var opts = new CustomServerOptions { GameServerPrewarmOnStartup = false };
        var prewarm = Prewarm(opts);
        bool ready = await prewarm.WaitForStartupPrewarmAsync(TimeSpan.FromSeconds(5), CancellationToken.None);
        Assert.False(ready); // not-started => not ready, and it did not block
    }

    [Fact] // F124 — GetStatus reports a starting state of "not-started" before any run
    public void PrewarmStatus_DefaultsToNotStarted()
    {
        var prewarm = Prewarm(new CustomServerOptions());
        var status = prewarm.GetStatus();
        Assert.Equal("not-started", status.State);
        Assert.False(status.Ready);
    }

    [Fact] // F123 — ShouldRun returns false (skip) when launching is disabled, with a reason
    public void Prewarm_ShouldRun_SkipsWhenLaunchDisabled()
    {
        var prewarm = Prewarm(new CustomServerOptions { LaunchGameServers = false });
        MethodInfo mi = typeof(GameServerPrewarmService).GetMethod("ShouldRun", BindingFlags.NonPublic | BindingFlags.Instance)!;
        object?[] args = { null };
        bool run = (bool)mi.Invoke(prewarm, args)!;
        Assert.False(run);
        Assert.False(string.IsNullOrWhiteSpace((string)args[0]!)); // a skip reason was given
    }

    [Fact] // F123 — ShouldRun skips when prewarm-on-startup is off
    public void Prewarm_ShouldRun_SkipsWhenPrewarmDisabled()
    {
        var prewarm = Prewarm(new CustomServerOptions { LaunchGameServers = true, GameServerPrewarmOnStartup = false });
        MethodInfo mi = typeof(GameServerPrewarmService).GetMethod("ShouldRun", BindingFlags.NonPublic | BindingFlags.Instance)!;
        object?[] args = { null };
        Assert.False((bool)mi.Invoke(prewarm, args)!);
    }

    private static bool InvokeIsTcpPortListening(int port)
    {
        MethodInfo mi = typeof(GameServerProcessManager).GetMethod("IsTcpPortListening", BindingFlags.NonPublic | BindingFlags.Static)
            ?? throw new InvalidOperationException("IsTcpPortListening not found (renamed?)");
        return (bool)mi.Invoke(null, new object[] { port })!;
    }

    [Fact] // F036 — IsTcpPortListening detects a bound listener and ignores a free port (port<=0 short-circuits false)
    public void TcpListenerReadiness_DetectsBoundListener()
    {
        Assert.False(InvokeIsTcpPortListening(0)); // port<=0 short-circuits to false

        var listener = new TcpListener(IPAddress.Loopback, 0);
        listener.Start();
        int boundPort = ((IPEndPoint)listener.LocalEndpoint).Port;
        try
        {
            Assert.True(InvokeIsTcpPortListening(boundPort)); // an active listener is detected
        }
        finally
        {
            listener.Stop();
        }

        // After Stop() the port is no longer listening (active-listener probe; procfs fallback also won't match a closed port).
        Assert.False(InvokeIsTcpPortListening(boundPort));
    }

    [Fact] // F028 — per-attempt log file naming: single attempt is plain, multi-attempt disambiguates by N
    public void AttemptLogFileName_DisambiguatesRetries()
    {
        // Single-attempt launch (maxAttempts==1) => plain "{GameId}.log".
        Assert.Equal("GAME7.log", GameServerProcessManager.BuildAttemptLogFileName("GAME7", attempt: 1, maxAttempts: 1));
        // Multi-attempt launch => each try gets its own "{GameId}.attempt{N}.log" so retries don't clobber.
        Assert.Equal("GAME7.attempt1.log", GameServerProcessManager.BuildAttemptLogFileName("GAME7", 1, 3));
        Assert.Equal("GAME7.attempt2.log", GameServerProcessManager.BuildAttemptLogFileName("GAME7", 2, 3));
        Assert.Equal("GAME7.attempt3.log", GameServerProcessManager.BuildAttemptLogFileName("GAME7", 3, 3));
    }

    [Fact] // F033 — listener-only detection: listener active + setup NOT applied => true (triggers replay/cold-stale)
    public void ListenerOnlyDetection_FlagsActiveListenerBeforeSetupApplied()
    {
        // Listener is up but /setup-game hasn't been applied yet => listener-only (Unity still warming).
        Assert.True(GameServerProcessManager.IsManagedBootstrapListenerOnly(
            setupGameApplied: false, lastStatus: "Managed match bootstrap listener is active, waiting for setup"));
        // Once setup is applied, it is no longer listener-only regardless of the status text.
        Assert.False(GameServerProcessManager.IsManagedBootstrapListenerOnly(
            setupGameApplied: true, lastStatus: "Managed match bootstrap listener is active"));
        // A different status (not the listener-active marker) is not listener-only.
        Assert.False(GameServerProcessManager.IsManagedBootstrapListenerOnly(
            setupGameApplied: false, lastStatus: "applying setup payload"));
        // Null/empty status is not listener-only.
        Assert.False(GameServerProcessManager.IsManagedBootstrapListenerOnly(false, null));
        Assert.False(GameServerProcessManager.IsManagedBootstrapListenerOnly(false, ""));
    }
}

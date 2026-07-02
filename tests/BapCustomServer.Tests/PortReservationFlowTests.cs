using System.Net;
using System.Net.Sockets;
using BapCustomServer;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Xunit;

namespace BapCustomServer.Tests;

// F111 — per-match port quad reservation with release-on-failure. StartMatchServerAttemptAsync
// reserves http/ws/kcp/tcp, spawns the game, and on a fail-closed bootstrap (RequireGameServerBootstrap
// = true) must kill the process AND ReleaseImmediately the quad so the next match can reuse it.
// We force the failure path WITHOUT the real game by pointing GameExecutablePath at a stub that exits
// instantly: spawn succeeds, process exits, bootstrap finds no listener, ports must be released.
public class PortReservationFlowTests
{
    private sealed class RealHttpClientFactory : IHttpClientFactory
    {
        public HttpClient CreateClient(string name) => new() { Timeout = TimeSpan.FromSeconds(2) };
    }

    private static int FreeTcpPortBase()
    {
        var l = new TcpListener(IPAddress.Loopback, 0);
        l.Start();
        int port = ((IPEndPoint)l.LocalEndpoint).Port;
        l.Stop();
        return port;
    }

    [Fact]
    public async Task FailedBootstrap_ReleasesPortQuad_NoLeak()
    {
        // A stub "game" that exits immediately (cmd.exe /c exit on Windows).
        string exe = Environment.GetEnvironmentVariable("ComSpec") ?? @"C:\Windows\System32\cmd.exe";
        if (!File.Exists(exe))
        {
            // Non-Windows / no cmd available: skip rather than assert a false negative.
            return;
        }

        string dir = Svc.TempDir();
        int baseHttp = FreeTcpPortBase();
        var ports = new PortAllocator();
        var opts = new CustomServerOptions
        {
            LaunchGameServers = true,
            RequireGameServerBootstrap = true,        // fail-closed
            GameServerStartAttempts = 1,              // fail fast
            GameServerReadyTimeoutSeconds = 3,        // short bootstrap deadline (process is already gone)
            GameServerManagedBootstrapStatusTimeoutSeconds = 2,
            GameServerReadyPollMillis = 100,
            GameServerStopWaitMillis = 500,
            RequireGameServerKcpPort = false,
            GameExecutablePath = exe,
            GameWorkingDirectory = dir,
            GameLogDirectory = dir,
            GameLauncherPath = "",                    // launch the exe directly
            HeadlessArguments = "/c exit",            // cmd just exits 0
            AdditionalGameArguments = "",
            BaseHttpPort = baseHttp,
            BaseWsPort = baseHttp + 1000,
            BaseKcpPort = baseHttp + 2000,
            BaseTcpPort = baseHttp + 3000,
            PortSearchRange = 50
        };

        var prewarm = new GameServerPrewarmService(Options.Create(opts), new StubEnv(dir), NullLogger<GameServerPrewarmService>.Instance);
        var mgr = new GameServerProcessManager(
            Options.Create(opts), new StubEnv(dir), ports,
            new RealHttpClientFactory(), prewarm, NullLogger<GameServerProcessManager>.Instance);

        var bootstrap = new MatchBootstrap(
            "leak-test",
            new MatchmakingGameData { MapId = 1, UnityGameModeId = 1 },
            new MatchmakingTeamData(),
            new QueueMatchedData());

        // The fail-closed path throws after exhausting attempts.
        await Assert.ThrowsAnyAsync<Exception>(() => mgr.StartMatchServerAsync(bootstrap, CancellationToken.None));

        // No leak: the http base port the failed attempt reserved must be handed back out again.
        int reHttp = ports.ReserveFrom(baseHttp, opts.PortSearchRange);
        Assert.Equal(baseHttp, reHttp);
    }
}

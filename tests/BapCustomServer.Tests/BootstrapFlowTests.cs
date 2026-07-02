using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.Json;
using BapCustomServer;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Xunit;

namespace BapCustomServer.Tests;

// F114 fail-closed three-step bootstrap (/setup-game -> /add-teams -> /queue-matched),
// F116 managed bootstrap status polling. TryBootstrapServerAsync POSTs to a plain HTTP port
// (session.HttpPort) and polls GET /status; it only null-checks session.Process. So it is fully
// integration-testable against a loopback HttpListener stub that mimics the in-game bootstrap
// listener — NO real bapbap.exe needed.
[Collection("ProxyIntegration")] // serialize: binds loopback HttpListener ports
public class BootstrapFlowTests
{
    private sealed class StubHttpClientFactory : IHttpClientFactory
    {
        public HttpClient CreateClient(string name) => new() { Timeout = TimeSpan.FromSeconds(10) };
    }

    private static int FreeTcpPort()
    {
        var l = new TcpListener(IPAddress.Loopback, 0);
        l.Start();
        int port = ((IPEndPoint)l.LocalEndpoint).Port;
        l.Stop();
        return port;
    }

    private static GameServerProcessManager Manager(CustomServerOptions opts)
    {
        string dir = Svc.TempDir();
        var prewarm = new GameServerPrewarmService(Options.Create(opts), new StubEnv(dir), NullLogger<GameServerPrewarmService>.Instance);
        return new GameServerProcessManager(
            Options.Create(opts), new StubEnv(dir), new PortAllocator(),
            new StubHttpClientFactory(), prewarm, NullLogger<GameServerProcessManager>.Instance);
    }

    private static MatchBootstrap Bootstrap() => new(
        "test-game-1",
        new MatchmakingGameData { MapId = 1, UnityGameModeId = 1 },
        new MatchmakingTeamData(),
        new QueueMatchedData());

    private static async Task<bool> InvokeBootstrap(GameServerProcessManager mgr, GameServerSession session, MatchBootstrap bootstrap)
    {
        MethodInfo mi = typeof(GameServerProcessManager).GetMethod("TryBootstrapServerAsync", BindingFlags.NonPublic | BindingFlags.Instance)
            ?? throw new InvalidOperationException("TryBootstrapServerAsync not found (renamed?)");
        return await (Task<bool>)mi.Invoke(mgr, new object[] { session, bootstrap, CancellationToken.None })!;
    }

    // Stub in-game bootstrap listener: tracks which POSTs arrived and reports /status accordingly.
    private sealed class StubBootstrapListener : IDisposable
    {
        private readonly HttpListener _listener = new();
        private readonly CancellationTokenSource _cts = new();
        private readonly bool _everApplies;
        private readonly bool _networkStarts;
        public int Port { get; }
        public bool SetupGameApplied;
        public bool AddTeamsApplied;
        public bool QueueMatchedApplied;
        public int SetupGamePostCount;

        public StubBootstrapListener(int port, bool everApplies, bool networkStarts = true)
        {
            Port = port;
            _everApplies = everApplies;
            _networkStarts = networkStarts;
            _listener.Prefixes.Add($"http://127.0.0.1:{port}/");
            _listener.Start();
            _ = Task.Run(LoopAsync);
        }

        private async Task LoopAsync()
        {
            while (!_cts.IsCancellationRequested)
            {
                HttpListenerContext ctx;
                try { ctx = await _listener.GetContextAsync(); }
                catch { break; }

                string path = ctx.Request.Url?.AbsolutePath.TrimEnd('/').ToLowerInvariant() ?? "";
                string method = ctx.Request.HttpMethod;
                byte[] body;

                if (method == "POST")
                {
                    // Drain the request body, then mark the corresponding stage applied (only when everApplies).
                    using (var r = new StreamReader(ctx.Request.InputStream)) { await r.ReadToEndAsync(); }
                    if (path == "/setup-game") SetupGamePostCount++;
                    if (_everApplies)
                    {
                        if (path == "/setup-game") SetupGameApplied = true;
                        else if (path == "/add-teams") AddTeamsApplied = true;
                        else if (path == "/queue-matched") QueueMatchedApplied = true;
                    }
                    body = Encoding.UTF8.GetBytes("{\"ok\":true}");
                }
                else // GET /status
                {
                    var status = new
                    {
                        ok = true,
                        networkStarted = _networkStarts,
                        setupGameApplied = SetupGameApplied,
                        addTeamsApplied = AddTeamsApplied,
                        queueMatchedApplied = QueueMatchedApplied,
                        bootstrapRepairComplete = QueueMatchedApplied,
                        lastStatus = _everApplies ? "applying" : "waiting",
                        realtime = 1.0
                    };
                    body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(status));
                    ctx.Response.ContentType = "application/json";
                }

                ctx.Response.StatusCode = 200;
                ctx.Response.ContentLength64 = body.Length;
                try { await ctx.Response.OutputStream.WriteAsync(body); ctx.Response.Close(); } catch { }
            }
        }

        public void Dispose()
        {
            _cts.Cancel();
            try { _listener.Stop(); } catch { }
            _cts.Dispose();
        }
    }

    private static CustomServerOptions FastOpts() => new()
    {
        GameServerReadyTimeoutSeconds = 15,
        GameServerManagedBootstrapStatusTimeoutSeconds = 3,
        GameServerReadyPollMillis = 100,
        RequireGameServerKcpPort = false
    };

    [Fact] // F114/F116 — happy path: all three stages POST + each /status flag flips => bootstrap succeeds
    public async Task Bootstrap_AllThreeStagesApply_Succeeds()
    {
        int port = FreeTcpPort();
        using var stub = new StubBootstrapListener(port, everApplies: true);
        var mgr = Manager(FastOpts());
        var session = new GameServerSession("g1", "127.0.0.1", 7777, 7778, 7779, null, port, 1, 1, Path.Combine(Svc.TempDir(), "g1.log"));

        bool ok = await InvokeBootstrap(mgr, session, Bootstrap());

        Assert.True(ok, "bootstrap should succeed when all stages apply");
        Assert.True(stub.SetupGameApplied);
        Assert.True(stub.AddTeamsApplied);
        Assert.True(stub.QueueMatchedApplied); // all three stages were driven in order
    }

    [Fact] // F114 fail-closed — setup-game POST accepted but status never applies => bootstrap FAILS (no live match)
    public async Task Bootstrap_StatusNeverApplies_FailsClosed()
    {
        int port = FreeTcpPort();
        using var stub = new StubBootstrapListener(port, everApplies: false);
        var mgr = Manager(FastOpts());
        var session = new GameServerSession("g2", "127.0.0.1", 7777, 7778, 7779, null, port, 1, 1, Path.Combine(Svc.TempDir(), "g2.log"));

        bool ok = await InvokeBootstrap(mgr, session, Bootstrap());

        Assert.False(ok, "bootstrap must fail-closed when setupGameApplied never becomes true");
    }

    [Fact] // Regression: applied bootstrap flags alone are not enough; networkStarted must become true before GAME_STARTED.
    public async Task Bootstrap_AppliedButNetworkNeverStarts_FailsClosed()
    {
        int port = FreeTcpPort();
        using var stub = new StubBootstrapListener(port, everApplies: true, networkStarts: false);
        var mgr = Manager(FastOpts());
        var session = new GameServerSession("g-no-network", "127.0.0.1", 7777, 7778, 7779, null, port, 1, 1, Path.Combine(Svc.TempDir(), "g-no-network.log"));

        bool ok = await InvokeBootstrap(mgr, session, Bootstrap());

        Assert.False(ok, "bootstrap must fail-closed when payloads apply but the game network never starts");
        Assert.True(stub.SetupGameApplied);
    }

    [Fact] // F114 — nothing listening on the http port => bootstrap fails (does not hang past deadline)
    public async Task Bootstrap_NoListener_Fails()
    {
        int port = FreeTcpPort(); // free but unbound: connections refused
        var opts = FastOpts();
        opts.GameServerReadyTimeoutSeconds = 4; // short overall deadline so the test is quick
        var mgr = Manager(opts);
        var session = new GameServerSession("g3", "127.0.0.1", 7777, 7778, 7779, null, port, 1, 1, Path.Combine(Svc.TempDir(), "g3.log"));

        bool ok = await InvokeBootstrap(mgr, session, Bootstrap());

        Assert.False(ok, "bootstrap must fail when the game http port never accepts connections");
    }

    [Fact] // Phase-3 regression: process exit during managed-status wait aborts immediately
    public async Task Bootstrap_ProcessExitedAfterSetup_DoesNotWaitFullManagedTimeout()
    {
        if (!OperatingSystem.IsWindows())
        {
            return;
        }

        int port = FreeTcpPort();
        using var stub = new StubBootstrapListener(port, everApplies: false);
        var opts = FastOpts();
        opts.GameServerManagedBootstrapStatusTimeoutSeconds = 30;
        opts.GameServerReadyPollMillis = 100;
        var mgr = Manager(opts);
        using Process exited = Process.Start(new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = "/c ping 127.0.0.1 -n 2 > nul",
            UseShellExecute = false,
            CreateNoWindow = true
        }) ?? throw new InvalidOperationException("could not start exited-process stub");
        var session = new GameServerSession("g-exit", "127.0.0.1", 7777, 7778, 7779, exited, port, 1, 1, Path.Combine(Svc.TempDir(), "g-exit.log"));
        var sw = Stopwatch.StartNew();

        bool ok = await InvokeBootstrap(mgr, session, Bootstrap());

        Assert.False(ok);
        Assert.True(stub.SetupGamePostCount >= 1);
        Assert.True(sw.Elapsed < TimeSpan.FromSeconds(5), $"bootstrap waited too long after process exit: {sw.Elapsed}");
    }
}

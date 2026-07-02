using System.Text.Json;
using BapCustomServer;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Xunit;

namespace BapCustomServer.Tests;

// F121 stop match server (releases the port quad; null-process session is the no-game branch),
// F067 match-end on an unknown game is a safe no-op (no match removed, no throw).
public class MatchLifecycleTests
{
    private sealed class StubHttpClientFactory : IHttpClientFactory
    {
        public HttpClient CreateClient(string name) => new();
    }

    private static GameServerProcessManager Manager(PortAllocator ports)
    {
        var opts = new CustomServerOptions();
        string dir = Svc.TempDir();
        var prewarm = new GameServerPrewarmService(Options.Create(opts), new StubEnv(dir), NullLogger<GameServerPrewarmService>.Instance);
        return new GameServerProcessManager(
            Options.Create(opts), new StubEnv(dir), ports,
            new StubHttpClientFactory(), prewarm, NullLogger<GameServerProcessManager>.Instance);
    }

    [Fact] // F121 — stopping a null-process session releases its port quad back to the allocator
    public void StopMatchServer_ReleasesPorts()
    {
        var ports = new PortAllocator();
        int http = ports.ReserveFrom(41000, 50);
        int ws = ports.ReserveFrom(41100, 50);
        int kcp = ports.ReserveUdpFrom(41200, 50);
        int tcp = ports.ReserveFrom(41300, 50);

        var mgr = Manager(ports);
        var session = new GameServerSession("g1", "127.0.0.1", ws, kcp, tcp, null, http, 1, 1);
        mgr.StopMatchServer(session); // no process to kill => just releases ports

        // The released http port is handed back out from the same base (proves it left _reserved).
        Assert.Equal(http, ports.ReserveFrom(41000, 50));
    }

    [Fact] // F067 — RecordGameEnded for an unknown gameId removes nothing and does not throw
    public void RecordGameEnded_UnknownGame_IsSafeNoOp()
    {
        var svc = Svc.Lobby(new CustomServerOptions());
        var payload = new GameEndedPayload { GameId = "never-started", Data = default };
        svc.RecordGameEnded(payload); // must not throw
        Assert.Equal(0, svc.GetActiveMatchCount());
    }

    [Fact] // F067 — RecordGameEnded tolerates a null/blank gameId
    public void RecordGameEnded_BlankGame_DoesNotThrow()
    {
        var svc = Svc.Lobby(new CustomServerOptions());
        svc.RecordGameEnded(new GameEndedPayload { GameId = null, Data = default });
        svc.RecordGameEnded(new GameEndedPayload { GameId = "   ", Data = default });
        Assert.Equal(0, svc.GetActiveMatchCount());
    }
}

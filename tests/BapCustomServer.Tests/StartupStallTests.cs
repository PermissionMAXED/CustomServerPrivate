using System.Reflection;
using BapCustomServer;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Xunit;

namespace BapCustomServer.Tests;

// F119 — startup stall detection. TryDetectStartupStall reads the per-match Unity log from disk
// and decides, from elapsed/grace/stall/idle time thresholds, whether a launched game process is
// stuck producing only noise. Fully testable here: write a temp log, control its mtime, and call
// via reflection. (Disabled / fresh-marker / within-grace / genuine-stall paths.)
public class StartupStallTests
{
    private sealed class StubHttpClientFactory : IHttpClientFactory
    {
        public HttpClient CreateClient(string name) => new();
    }

    private static GameServerProcessManager Manager(CustomServerOptions opts)
    {
        string dir = Svc.TempDir();
        var prewarm = new GameServerPrewarmService(Options.Create(opts), new StubEnv(dir), NullLogger<GameServerPrewarmService>.Instance);
        return new GameServerProcessManager(
            Options.Create(opts), new StubEnv(dir), new PortAllocator(),
            new StubHttpClientFactory(), prewarm, NullLogger<GameServerProcessManager>.Instance);
    }

    private static GameServerSession Session(string logFile)
        => new("g1", "127.0.0.1", 7777, 7778, 7779, null, 7850, 1, 1, logFile);

    private static bool Detect(GameServerProcessManager mgr, GameServerSession session, DateTimeOffset startedAt, DateTimeOffset now, out string reason)
    {
        MethodInfo mi = typeof(GameServerProcessManager).GetMethod("TryDetectStartupStall", BindingFlags.NonPublic | BindingFlags.Instance)
            ?? throw new InvalidOperationException("TryDetectStartupStall not found (renamed?)");
        object?[] args = { session, startedAt, now, null };
        bool result = (bool)mi.Invoke(mgr, args)!;
        reason = (string)(args[3] ?? "");
        return result;
    }

    private static string WriteLog(string contents, DateTimeOffset mtimeUtc)
    {
        string path = System.IO.Path.Combine(Svc.TempDir(), "match.log");
        System.IO.File.WriteAllText(path, contents);
        System.IO.File.SetLastWriteTimeUtc(path, mtimeUtc.UtcDateTime);
        return path;
    }

    [Fact] // F119 — disabled when GameServerStartupStallSeconds <= 0
    public void Disabled_NeverStalls()
    {
        var mgr = Manager(new CustomServerOptions { GameServerStartupStallSeconds = 0 });
        var now = DateTimeOffset.UtcNow;
        string log = WriteLog("noise only", now.AddSeconds(-50));
        Assert.False(Detect(mgr, Session(log), now.AddSeconds(-60), now, out _));
    }

    [Fact] // F119 — a fresh mod/bootstrap marker means the process is alive => NOT a stall
    public void FreshMarker_NotStalled()
    {
        var mgr = Manager(new CustomServerOptions());
        var now = DateTimeOffset.UtcNow;
        var startedAt = now.AddSeconds(-60);
        // marker present, file written after startedAt => fresh
        string log = WriteLog("blah\n[BAP_Custom_Server] Started game bootstrap\n", startedAt.AddSeconds(10));
        Assert.False(Detect(mgr, Session(log), startedAt, now, out _));
    }

    [Fact] // F119 — within the grace window => not yet a stall
    public void WithinGrace_NotStalled()
    {
        var mgr = Manager(new CustomServerOptions());
        var now = DateTimeOffset.UtcNow;
        var startedAt = now.AddSeconds(-10); // elapsed 10s < noisy grace 45s
        string log = WriteLog("only shader noise here", startedAt.AddSeconds(2));
        Assert.False(Detect(mgr, Session(log), startedAt, now, out _));
    }

    [Fact] // F119 — past grace, idle longer than stall threshold, no marker => STALL reported
    public void NoiseAndIdlePastThreshold_Stalls()
    {
        var mgr = Manager(new CustomServerOptions()); // grace 45s, stall 25s
        var now = DateTimeOffset.UtcNow;
        var startedAt = now.AddSeconds(-60);          // elapsed 60s > grace 45s
        // fresh-but-noise log last written 50s ago => idle 50s > stall 25s
        string log = WriteLog("Shader Unsupported: x\nALSA lib pcm\n", now.AddSeconds(-50));
        bool stalled = Detect(mgr, Session(log), startedAt, now, out string reason);
        Assert.True(stalled, "should detect a stall");
        Assert.False(string.IsNullOrWhiteSpace(reason)); // a diagnostic reason is provided
    }
}

using System.Reflection;
using BapCustomServer;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Xunit;

namespace BapCustomServer.Tests;

// F109 — wait for startup prewarm before the first real match. WaitForStartupPrewarmAsync blocks
// up to maxWait while prewarm is starting/running, then returns the latest Ready on timeout (or the
// completion result if prewarm finishes first). No game process: we drive the status via reflection.
public class PrewarmWaitTests
{
    private static GameServerPrewarmService Prewarm(CustomServerOptions opts)
        => new(Options.Create(opts), new StubEnv(Svc.TempDir()), NullLogger<GameServerPrewarmService>.Instance);

    private static void ForceState(GameServerPrewarmService svc, string state, bool ready)
    {
        MethodInfo mi = typeof(GameServerPrewarmService).GetMethod("UpdateStatus", BindingFlags.NonPublic | BindingFlags.Instance)
            ?? throw new InvalidOperationException("UpdateStatus not found (renamed?)");
        // (state, ready, completed, startedUtc, completedUtc, processId, exitCode, readySource, logFile, melonLogFile, error)
        mi.Invoke(svc, new object?[] { state, ready, false, null, null, null, null, null, null, null, null });
    }

    [Fact] // F109 — while "running" and prewarm never completes, the wait returns at maxWait (does not hang)
    public async Task Wait_RunningButNeverCompletes_ReturnsAtTimeout()
    {
        var svc = Prewarm(new CustomServerOptions { GameServerPrewarmOnStartup = true });
        ForceState(svc, "running", ready: false);

        var sw = System.Diagnostics.Stopwatch.StartNew();
        bool ready = await svc.WaitForStartupPrewarmAsync(TimeSpan.FromMilliseconds(400), CancellationToken.None);
        sw.Stop();

        Assert.False(ready);                            // latest Ready on timeout
        Assert.True(sw.ElapsedMilliseconds >= 300, $"should have waited ~maxWait, waited {sw.ElapsedMilliseconds}ms");
        Assert.True(sw.ElapsedMilliseconds < 5000, "must not hang well past maxWait");
    }

    [Fact] // F109 — prewarm disabled => returns immediately without waiting
    public async Task Wait_PrewarmDisabled_ReturnsImmediately()
    {
        var svc = Prewarm(new CustomServerOptions { GameServerPrewarmOnStartup = false });
        var sw = System.Diagnostics.Stopwatch.StartNew();
        bool ready = await svc.WaitForStartupPrewarmAsync(TimeSpan.FromSeconds(10), CancellationToken.None);
        sw.Stop();
        Assert.False(ready);
        Assert.True(sw.ElapsedMilliseconds < 1000, "disabled prewarm must not block on the wait");
    }

    [Fact] // F109 — when prewarm already finished (state not running/starting), returns its Ready at once
    public async Task Wait_AlreadyCompleted_ReturnsReadyImmediately()
    {
        var svc = Prewarm(new CustomServerOptions { GameServerPrewarmOnStartup = true });
        ForceState(svc, "ready", ready: true);
        var sw = System.Diagnostics.Stopwatch.StartNew();
        bool ready = await svc.WaitForStartupPrewarmAsync(TimeSpan.FromSeconds(10), CancellationToken.None);
        sw.Stop();
        Assert.True(ready);
        Assert.True(sw.ElapsedMilliseconds < 1000, "already-ready prewarm must not block");
    }
}

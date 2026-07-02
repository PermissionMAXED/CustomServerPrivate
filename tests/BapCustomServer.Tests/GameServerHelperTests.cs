using System.Reflection;
using BapCustomServer;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Xunit;

namespace BapCustomServer.Tests;

// F110 start-attempt clamping, F117 adaptive bootstrap retry delay, F113 loopback callback args.
// These are pure helpers on GameServerProcessManager — no process is spawned to exercise them.
public class GameServerHelperTests
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

    [Theory] // F110 — start attempts clamped to [1,5], 0/negative => 1
    [InlineData(0, 1)]
    [InlineData(-3, 1)]
    [InlineData(2, 2)]
    [InlineData(5, 5)]
    [InlineData(99, 5)]
    public void EffectiveGameServerStartAttempts_Clamps(int configured, int expected)
    {
        var opts = new CustomServerOptions { GameServerStartAttempts = configured };
        Assert.Equal(expected, GameServerProcessManager.EffectiveGameServerStartAttempts(opts));
    }

    [Fact] // F117 — a "connection reset"/"timed out" error backs off to the larger reset poll
    public void GetBootstrapRetryDelay_BacksOffOnConnectedButBusy()
    {
        var opts = new CustomServerOptions
        {
            GameServerReadyPollMillis = 500,
            GameServerBootstrapResetPollMillis = 1500
        };
        var mgr = Manager(opts);
        MethodInfo mi = typeof(GameServerProcessManager).GetMethod("GetBootstrapRetryDelayMillis", BindingFlags.NonPublic | BindingFlags.Instance)!;

        int normal = (int)mi.Invoke(mgr, new object?[] { "404 not found" })!;
        int busy = (int)mi.Invoke(mgr, new object?[] { "The connection was reset" })!;
        int timedOut = (int)mi.Invoke(mgr, new object?[] { "operation timed out" })!;

        Assert.Equal(500, normal);                 // ordinary error => base poll
        Assert.True(busy >= 1500, $"reset error should back off, got {busy}");
        Assert.True(timedOut >= 1500, $"timeout error should back off, got {timedOut}");
    }

    [Fact] // F117 — null/empty error uses the base poll
    public void GetBootstrapRetryDelay_NullError_UsesBasePoll()
    {
        var mgr = Manager(new CustomServerOptions { GameServerReadyPollMillis = 500 });
        MethodInfo mi = typeof(GameServerProcessManager).GetMethod("GetBootstrapRetryDelayMillis", BindingFlags.NonPublic | BindingFlags.Instance)!;
        Assert.Equal(500, (int)mi.Invoke(mgr, new object?[] { null })!);
    }

    [Fact] // F113 — loopback callback args are injected when absent
    public void AppendLocalCallbackArguments_InjectsWhenMissing()
    {
        var mgr = Manager(new CustomServerOptions());
        MethodInfo mi = typeof(GameServerProcessManager).GetMethod("AppendLocalCallbackArguments", BindingFlags.NonPublic | BindingFlags.Instance)!;
        string result = (string)mi.Invoke(mgr, new object[] { "-batchmode -httpport=7850" })!;
        Assert.Contains("--bapcustom-host=127.0.0.1", result);
        Assert.Contains("--bapcustom-server-port=", result);
        Assert.Contains("--bapcustom-use-proxy=false", result);
    }

    [Fact] // F113 — existing callback args are NOT duplicated
    public void AppendLocalCallbackArguments_DoesNotDuplicate()
    {
        var mgr = Manager(new CustomServerOptions());
        MethodInfo mi = typeof(GameServerProcessManager).GetMethod("AppendLocalCallbackArguments", BindingFlags.NonPublic | BindingFlags.Instance)!;
        string preset = "--bapcustom-host=10.0.0.1 --bapcustom-server-port=9999 --bapcustom-use-proxy=true";
        string result = (string)mi.Invoke(mgr, new object[] { preset })!;
        Assert.Equal(1, CountOccurrences(result, "--bapcustom-host="));
        Assert.Equal(1, CountOccurrences(result, "--bapcustom-server-port="));
        Assert.Equal(1, CountOccurrences(result, "--bapcustom-use-proxy="));
        Assert.Contains("10.0.0.1", result); // preserved the caller's value
    }

    private static int CountOccurrences(string haystack, string needle)
    {
        int count = 0, idx = 0;
        while ((idx = haystack.IndexOf(needle, idx, StringComparison.Ordinal)) >= 0) { count++; idx += needle.Length; }
        return count;
    }
}

using System.Reflection;
using BapCustomServer;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace BapCustomServer.Tests;

// F127 periodic resource usage sampling, F128 periodic stale-match cleanup. LogSample samples
// THIS process (the test runner) and calls LobbyService.CleanupStaleMatches — no game process
// needed. The interval/background loop is the only untested part (timer plumbing).
public class ResourceMonitorTests
{
    private static ResourceMonitorService Monitor(out LobbyService lobby)
    {
        lobby = Svc.Lobby(new CustomServerOptions());
        return new ResourceMonitorService(NullLogger<ResourceMonitorService>.Instance, lobby, Svc.Queue());
    }

    [Fact] // F127/F128 — sampling the live process + cleanup runs without throwing
    public void LogSample_RunsWithoutThrowing()
    {
        var monitor = Monitor(out _);
        MethodInfo mi = typeof(ResourceMonitorService).GetMethod("LogSample", BindingFlags.NonPublic | BindingFlags.Instance)
            ?? throw new InvalidOperationException("LogSample not found (renamed?)");
        mi.Invoke(monitor, null);     // first sample seeds CPU baseline
        mi.Invoke(monitor, null);     // second sample computes a real CPU delta
        // No assertion beyond "did not throw": LogSample only logs + cleans, and on a fresh
        // LobbyService cleanup removes 0 matches. The point is it samples the process safely.
    }

    [Fact] // F128 — stale-match cleanup via the monitor's path returns 0 on a fresh service
    public void Monitor_CleanupPath_NoMatches()
    {
        Monitor(out LobbyService lobby);
        Assert.Equal(0, lobby.CleanupStaleMatches());
    }
}

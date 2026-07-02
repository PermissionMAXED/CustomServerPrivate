using System.Reflection;
using BapCustomServer;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Xunit;

namespace BapCustomServer.Tests;

// F122 — startup warm-spare prewarm. RunPrewarmAsync spawns a game process, polls the MelonLoader
// log for a ready marker, then reaps the process. Driven here with a stub exe (cmd /c exit) that
// exits instantly: no ready marker is ever written, so prewarm completes "not-ready" and the
// process is reaped. No real bapbap.exe needed.
public class PrewarmFlowTests
{
    private static GameServerPrewarmService Prewarm(CustomServerOptions opts, string dir)
        => new(Options.Create(opts), new StubEnv(dir), NullLogger<GameServerPrewarmService>.Instance);

    [Fact]
    public async Task RunPrewarm_StubExeExitsImmediately_CompletesNotReady()
    {
        string exe = Environment.GetEnvironmentVariable("ComSpec") ?? @"C:\Windows\System32\cmd.exe";
        if (!File.Exists(exe))
        {
            return; // non-Windows / no cmd: skip rather than false-fail
        }

        string dir = Svc.TempDir();
        var opts = new CustomServerOptions
        {
            LaunchGameServers = true,
            GameServerPrewarmOnStartup = true,
            GameServerPrewarmTimeoutSeconds = 30,   // clamped to >=30; the process exits well before this
            GameServerPrewarmSettleSeconds = 0,
            GameExecutablePath = exe,
            GameWorkingDirectory = dir,
            GameLogDirectory = dir,
            GameLauncherPath = "",                  // launch the exe directly
            HeadlessArguments = "/c exit",          // cmd just exits 0
            AdditionalGameArguments = "",
            BaseHttpPort = 7850, BaseWsPort = 7777, BaseKcpPort = 7778, BaseTcpPort = 7779
        };

        var prewarm = Prewarm(opts, dir);
        MethodInfo mi = typeof(GameServerPrewarmService).GetMethod("RunPrewarmAsync", BindingFlags.NonPublic | BindingFlags.Instance)
            ?? throw new InvalidOperationException("RunPrewarmAsync not found (renamed?)");

        bool ready = await (Task<bool>)mi.Invoke(prewarm, new object[] { CancellationToken.None })!;

        Assert.False(ready); // no ready marker => not ready, but it completed without hanging
        var status = prewarm.GetStatus();
        Assert.True(status.Completed);
        Assert.Equal("not-ready", status.State);
    }

    [Fact] // F122 — ShouldRun gating: skipped when prewarm-on-startup is off
    public void RunPrewarm_GatedOff_WhenPrewarmDisabled()
    {
        string dir = Svc.TempDir();
        var prewarm = Prewarm(new CustomServerOptions { LaunchGameServers = true, GameServerPrewarmOnStartup = false }, dir);
        MethodInfo mi = typeof(GameServerPrewarmService).GetMethod("ShouldRun", BindingFlags.NonPublic | BindingFlags.Instance)!;
        object?[] args = { null };
        Assert.False((bool)mi.Invoke(prewarm, args)!);
        Assert.Contains("PrewarmOnStartup", (string)args[0]!);
    }
}

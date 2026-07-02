using System.Reflection;
using BapCustomServer;
using Xunit;

namespace BapCustomServer.Tests;

// F120 — filtered startup diagnostics log tail. BuildStartupDiagnostics / BuildFilteredLogTail
// are static and read files from disk, so they are fully testable: write temp logs with noise
// + important lines and assert the noise is suppressed and important lines are surfaced.
public class StartupDiagnosticsTests
{
    private static string BuildStartupDiagnostics(string? path, int maxLines)
    {
        MethodInfo mi = typeof(GameServerProcessManager).GetMethod("BuildStartupDiagnostics", BindingFlags.NonPublic | BindingFlags.Static)
            ?? throw new InvalidOperationException("BuildStartupDiagnostics not found (renamed?)");
        return (string)mi.Invoke(null, new object?[] { path, maxLines })!;
    }

    [Fact] // F120 — known Unity noise is suppressed, important bootstrap/error lines surface
    public void FiltersNoise_SurfacesImportant()
    {
        string dir = Svc.TempDir();
        string unityLog = System.IO.Path.Combine(dir, "match.log");
        System.IO.File.WriteAllLines(unityLog, new[]
        {
            "Shader Unsupported: some/shader",            // known noise
            "ALSA lib pcm.c: cannot open device",          // known noise
            "[KCP] Server: RawSend invalid connectionId=5",// known noise
            "[BAP_Custom_Server] Started game bootstrap",  // important
            "GameNetworkManager StartServer ws=7777",      // important
            "NullReferenceException at Foo.Bar",           // important (error)
        });

        string diag = BuildStartupDiagnostics(unityLog, 50);

        Assert.Contains("Started game bootstrap", diag);   // important surfaced
        Assert.Contains("StartServer", diag);
        Assert.Contains("NullReferenceException", diag);
        Assert.DoesNotContain("ALSA lib", diag);           // noise suppressed
        Assert.DoesNotContain("RawSend", diag);
        Assert.Contains("suppressedKnownNoise=", diag);    // unity noise summary present
    }

    [Fact] // F120 — missing unity log is reported, not thrown
    public void MissingLog_ReportsGracefully()
    {
        string diag = BuildStartupDiagnostics(System.IO.Path.Combine(Svc.TempDir(), "does-not-exist.log"), 50);
        Assert.Contains("unity log missing", diag);
    }

    [Fact] // F120 — null path yields a placeholder, never an exception
    public void NullPath_ReturnsPlaceholder()
    {
        Assert.Equal("<no log path>", BuildStartupDiagnostics(null, 50));
    }
}

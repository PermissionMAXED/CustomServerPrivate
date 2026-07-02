using System.Net;
using System.Net.Sockets;
using System.Reflection;
using BapCustomServer;
using Xunit;

namespace BapCustomServer.Tests;

// F118 — KCP UDP port readiness gate. The gate's core is IsUdpPortActive(port), a static OS
// probe. Bind a real UDP socket and assert detection; this is the testable kernel of the gate
// (the surrounding WaitForUdpPortAsync polling loop is exercised end-to-end only with a real host).
public class UdpPortDetectionTests
{
    private static bool IsUdpPortActive(int port)
    {
        MethodInfo mi = typeof(GameServerProcessManager).GetMethod("IsUdpPortActive", BindingFlags.NonPublic | BindingFlags.Static)
            ?? throw new InvalidOperationException("IsUdpPortActive not found (renamed?)");
        return (bool)mi.Invoke(null, new object[] { port })!;
    }

    [Fact] // F118 — a bound UDP socket is detected as active
    public void DetectsBoundUdpPort()
    {
        using var udp = new UdpClient(0, AddressFamily.InterNetwork); // OS-assigned free port
        int port = ((IPEndPoint)udp.Client.LocalEndPoint!).Port;
        Assert.True(IsUdpPortActive(port), $"bound UDP port {port} should be detected active");
    }

    [Fact] // F118 — port <= 0 is never active (guard)
    public void NonPositivePort_IsNotActive()
    {
        Assert.False(IsUdpPortActive(0));
        Assert.False(IsUdpPortActive(-1));
    }

    [Fact] // F118 — releasing the socket stops it being detected
    public void ReleasedPort_IsNoLongerActive()
    {
        int port;
        using (var udp = new UdpClient(0, AddressFamily.InterNetwork))
        {
            port = ((IPEndPoint)udp.Client.LocalEndPoint!).Port;
            Assert.True(IsUdpPortActive(port));
        }
        // After dispose the OS frees the port; detection should flip to false.
        Assert.False(IsUdpPortActive(port));
    }
}

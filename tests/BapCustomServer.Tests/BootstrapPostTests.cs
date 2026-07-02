using System.Net;
using System.Reflection;
using System.Text;
using BapCustomServer;
using Xunit;

namespace BapCustomServer.Tests;

// F115 — explicit Content-Length bootstrap POSTs. PostJsonAsync must send the body with an
// explicit Content-Length (NOT Transfer-Encoding: chunked), because the mod's hand-rolled HTTP
// parser only understands Content-Length. Verified against a real loopback HttpListener that
// captures the request headers — no game process needed.
[Collection("ProxyIntegration")] // serialize: binds a loopback HttpListener port
public class BootstrapPostTests
{
    private static int FreeTcpPort()
    {
        var l = new System.Net.Sockets.TcpListener(IPAddress.Loopback, 0);
        l.Start();
        int port = ((IPEndPoint)l.LocalEndpoint).Port;
        l.Stop();
        return port;
    }

    [Fact]
    public async Task PostJsonAsync_SendsExplicitContentLength_NotChunked()
    {
        int port = FreeTcpPort();
        using var listener = new HttpListener();
        listener.Prefixes.Add($"http://127.0.0.1:{port}/");
        listener.Start();

        long? capturedContentLength = null;
        string? capturedTransferEncoding = null;
        string? capturedContentType = null;
        string? capturedBody = null;

        var serverTask = Task.Run(async () =>
        {
            HttpListenerContext ctx = await listener.GetContextAsync();
            capturedContentLength = ctx.Request.ContentLength64;
            capturedTransferEncoding = ctx.Request.Headers["Transfer-Encoding"];
            capturedContentType = ctx.Request.ContentType;
            using (var reader = new StreamReader(ctx.Request.InputStream, Encoding.UTF8))
            {
                capturedBody = await reader.ReadToEndAsync();
            }
            byte[] ok = Encoding.UTF8.GetBytes("{\"ok\":true}");
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentLength64 = ok.Length;
            await ctx.Response.OutputStream.WriteAsync(ok);
            ctx.Response.Close();
        });

        MethodInfo mi = typeof(GameServerProcessManager).GetMethod("PostJsonAsync", BindingFlags.NonPublic | BindingFlags.Static)
            ?? throw new InvalidOperationException("PostJsonAsync not found (renamed?)");

        using var client = new HttpClient();
        var payload = new { gameId = "match-1", mapId = 3 };
        var task = (Task)mi.Invoke(null, new object?[]
        {
            client, new Uri($"http://127.0.0.1:{port}/"), "setup-game", payload, CancellationToken.None
        })!;
        await task;
        await serverTask;
        listener.Stop();

        Assert.True(capturedContentLength.HasValue && capturedContentLength.Value > 0,
            "request must carry an explicit Content-Length");
        Assert.True(string.IsNullOrEmpty(capturedTransferEncoding),
            $"request must NOT use Transfer-Encoding (was '{capturedTransferEncoding}')");
        Assert.Contains("application/json", capturedContentType ?? "");
        Assert.Contains("match-1", capturedBody ?? ""); // body actually serialized + sent
    }
}

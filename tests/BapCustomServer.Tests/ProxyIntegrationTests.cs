using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using BapCustomClientProxy;
using Xunit;

namespace BapCustomServer.Tests;

// F176 fixed local listener on 127.0.0.1:5055, F178 request-body forwarding (POST),
// F181 bidirectional WebSocket proxying. Real end-to-end: an HttpListener echo upstream,
// the proxy launched as a subprocess pointed at it, and traffic driven through 127.0.0.1:5055.
// The proxy binds 5055 unconditionally, so all assertions live in one serialized test.
[Collection("ProxyIntegration")]
public class ProxyIntegrationTests
{
    private static int FreeTcpPort()
    {
        var l = new TcpListener(IPAddress.Loopback, 0);
        l.Start();
        int port = ((IPEndPoint)l.LocalEndpoint).Port;
        l.Stop();
        return port;
    }

    // Minimal upstream: echoes POST bodies and echoes WS frames. Pure BCL (no ASP.NET dep).
    private static async Task RunUpstreamAsync(HttpListener listener, CancellationToken ct)
    {
        while (!ct.IsCancellationRequested)
        {
            HttpListenerContext ctx;
            try { ctx = await listener.GetContextAsync(); }
            catch { break; } // listener stopped

            _ = Task.Run(async () =>
            {
                try
                {
                    if (ctx.Request.IsWebSocketRequest)
                    {
                        HttpListenerWebSocketContext wsCtx = await ctx.AcceptWebSocketAsync(null);
                        WebSocket ws = wsCtx.WebSocket;
                        var buf = new byte[4096];
                        while (ws.State == WebSocketState.Open)
                        {
                            WebSocketReceiveResult r = await ws.ReceiveAsync(buf, CancellationToken.None);
                            if (r.MessageType == WebSocketMessageType.Close)
                            {
                                await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "bye", CancellationToken.None);
                                break;
                            }
                            // echo the frame back
                            await ws.SendAsync(buf.AsMemory(0, r.Count), r.MessageType, r.EndOfMessage, CancellationToken.None);
                        }
                    }
                    else
                    {
                        using var reader = new StreamReader(ctx.Request.InputStream, Encoding.UTF8);
                        string body = await reader.ReadToEndAsync();
                        byte[] echo = Encoding.UTF8.GetBytes("upstream-saw:" + body);
                        ctx.Response.StatusCode = 200;
                        ctx.Response.ContentType = "text/plain";
                        ctx.Response.ContentLength64 = echo.Length;
                        await ctx.Response.OutputStream.WriteAsync(echo);
                        ctx.Response.Close();
                    }
                }
                catch { /* best-effort echo */ }
            }, ct);
        }
    }

    [Fact]
    public async Task Proxy_ForwardsHttpBody_AndWebSocketFrames()
    {
        int upstreamPort = FreeTcpPort();
        using var listener = new HttpListener();
        listener.Prefixes.Add($"http://127.0.0.1:{upstreamPort}/");
        listener.Start();

        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(60));
        Task upstream = RunUpstreamAsync(listener, cts.Token);

        // Launch the proxy subprocess pointed at our upstream. The referenced assembly's
        // location is the freshly built proxy dll (same configuration as this test run).
        string proxyDll = typeof(ProxyHelpers).Assembly.Location;

        // Use an OS-assigned free port so the test never collides with a real proxy or
        // another test run on 127.0.0.1:5055 — the env var is the only port override path.
        int proxyPort = FreeTcpPort();
        var psi = new ProcessStartInfo("dotnet", $"\"{proxyDll}\" http://127.0.0.1:{upstreamPort}")
        {
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true
        };
        psi.EnvironmentVariables["BAP_CUSTOM_PROXY_PORT"] = proxyPort.ToString();
        using var proxy = Process.Start(psi)!;
        try
        {
            using var http = new HttpClient { Timeout = TimeSpan.FromSeconds(5) };

            // F176 — poll until the proxy's listener (on the free port) is accepting.
            string proxyBase = $"http://127.0.0.1:{proxyPort}";
            bool up = false;
            for (int i = 0; i < 50 && !up; i++)
            {
                if (proxy.HasExited)
                {
                    string err = await proxy.StandardError.ReadToEndAsync();
                    Assert.Fail($"proxy exited early (code {proxy.ExitCode}): {err}");
                }
                try
                {
                    using var resp = await http.PostAsync($"{proxyBase}/ping", new StringContent("warmup"));
                    up = true;
                }
                catch { await Task.Delay(200); }
            }
            Assert.True(up, $"proxy did not start listening on {proxyBase}");

            // F178 — POST body is forwarded to the upstream intact.
            using var bodyResp = await http.PostAsync($"{proxyBase}/echo", new StringContent("hello-body-123"));
            string echoed = await bodyResp.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.OK, bodyResp.StatusCode);
            Assert.Equal("upstream-saw:hello-body-123", echoed); // body made it through the proxy

            // F181 — bidirectional WebSocket proxying: a frame round-trips through the proxy.
            using var ws = new ClientWebSocket();
            await ws.ConnectAsync(new Uri($"ws://127.0.0.1:{proxyPort}/ws"), CancellationToken.None);
            byte[] payload = Encoding.UTF8.GetBytes("ws-roundtrip");
            await ws.SendAsync(payload, WebSocketMessageType.Text, true, CancellationToken.None);
            var rbuf = new byte[4096];
            WebSocketReceiveResult rr = await ws.ReceiveAsync(rbuf, new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);
            Assert.Equal("ws-roundtrip", Encoding.UTF8.GetString(rbuf, 0, rr.Count));
            await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "done", CancellationToken.None);
        }
        finally
        {
            cts.Cancel();
            try { if (!proxy.HasExited) proxy.Kill(entireProcessTree: true); } catch { }
            listener.Stop();
            try { await upstream; } catch { }
        }
    }
}

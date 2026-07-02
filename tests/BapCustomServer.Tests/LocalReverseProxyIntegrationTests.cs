using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using BapCustomServerMelon;
using Xunit;

namespace BapCustomServer.Tests;

// F153 — in-process reverse proxy (HTTP + WebSocket forwarding). This drives the REAL
// LocalReverseProxy class (linked from the mod; it's pure System.Net with no Unity deps) against
// a loopback echo upstream: HTTP body+method forwarding, identity-header injection through the
// live request path (F154), socket-discovery rewrite through the live response path (F155), and
// bidirectional WebSocket frame relay. Each test binds its own free ports, so no [Collection] gate.
public class LocalReverseProxyIntegrationTests
{
    private static int FreeTcpPort()
    {
        var l = new TcpListener(IPAddress.Loopback, 0);
        l.Start();
        int port = ((IPEndPoint)l.LocalEndpoint).Port;
        l.Stop();
        return port;
    }

    // Upstream echo: POST -> "upstream-saw:<body>"; GET /api/lobbies/socket -> a socketUrl JSON
    // document; WS -> echoes frames back. Pure BCL HttpListener.
    private static async Task RunUpstreamAsync(HttpListener listener, CancellationToken ct)
    {
        while (!ct.IsCancellationRequested)
        {
            HttpListenerContext ctx;
            try { ctx = await listener.GetContextAsync(); }
            catch { break; }

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
                            await ws.SendAsync(buf.AsMemory(0, r.Count), r.MessageType, r.EndOfMessage, CancellationToken.None);
                        }
                        return;
                    }

                    string path = ctx.Request.Url?.AbsolutePath ?? "";
                    byte[] payload;
                    if (path.Contains("socket", StringComparison.OrdinalIgnoreCase))
                    {
                        // The upstream advertises its OWN socket URL; the proxy must rewrite it to loopback.
                        payload = Encoding.UTF8.GetBytes("{\"socketUrl\":\"wss://upstream.example.com/ws\"}");
                        ctx.Response.ContentType = "application/json";
                    }
                    else
                    {
                        using var reader = new StreamReader(ctx.Request.InputStream, Encoding.UTF8);
                        string body = await reader.ReadToEndAsync();
                        // Echo back the body AND the identity header the proxy injected, so we can assert both.
                        string acct = ctx.Request.Headers["X-BAP-AccountId"] ?? "";
                        payload = Encoding.UTF8.GetBytes($"upstream-saw:{body}|acct:{acct}");
                        ctx.Response.ContentType = "text/plain";
                    }
                    ctx.Response.StatusCode = 200;
                    ctx.Response.ContentLength64 = payload.Length;
                    await ctx.Response.OutputStream.WriteAsync(payload);
                    ctx.Response.Close();
                }
                catch { }
            }, ct);
        }
    }

    [Fact]
    public async Task Proxy_ForwardsHttp_InjectsIdentity_RewritesSocket_AndRelaysWebSocket()
    {
        int upstreamPort = FreeTcpPort();
        int proxyPort = FreeTcpPort();

        using var listener = new HttpListener();
        listener.Prefixes.Add($"http://127.0.0.1:{upstreamPort}/");
        listener.Start();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(60));
        Task upstream = RunUpstreamAsync(listener, cts.Token);

        var proxy = new LocalReverseProxy(
            proxyPort,
            new Uri($"http://127.0.0.1:{upstreamPort}/"),
            () => ("custom-99", "Tester", "4321"),
            _ => { }, _ => { }, _ => { });
        try
        {
            proxy.Start();
            using var http = new HttpClient { Timeout = TimeSpan.FromSeconds(5) };
            string basePfx = $"http://127.0.0.1:{proxyPort}";

            // F153 + F154 — POST body forwarded AND identity header injected on the upstream request.
            using var post = await http.PostAsync($"{basePfx}/api/load", new StringContent("hello-123"));
            string echoed = await post.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.OK, post.StatusCode);
            Assert.Contains("upstream-saw:hello-123", echoed);
            Assert.Contains("acct:custom-99", echoed); // identity header reached the upstream

            // F153 + F155 — socket-discovery response rewritten to the loopback proxy URL.
            using var sock = await http.GetAsync($"{basePfx}/api/lobbies/socket");
            string sockBody = await sock.Content.ReadAsStringAsync();
            Assert.Contains($"ws://127.0.0.1:{proxyPort}/ws", sockBody);
            Assert.DoesNotContain("upstream.example.com", sockBody);

            // F153 — bidirectional WebSocket relay through the proxy.
            using var ws = new ClientWebSocket();
            await ws.ConnectAsync(new Uri($"ws://127.0.0.1:{proxyPort}/ws"), CancellationToken.None);
            byte[] frame = Encoding.UTF8.GetBytes("ws-roundtrip");
            await ws.SendAsync(frame, WebSocketMessageType.Text, true, CancellationToken.None);
            var rbuf = new byte[4096];
            WebSocketReceiveResult rr = await ws.ReceiveAsync(rbuf, new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);
            Assert.Equal("ws-roundtrip", Encoding.UTF8.GetString(rbuf, 0, rr.Count));
            await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "done", CancellationToken.None);
        }
        finally
        {
            proxy.Dispose();
            cts.Cancel();
            listener.Stop();
            try { await upstream; } catch { }
        }
    }

    [Fact] // F153 — blank identity means no X-BAP headers are added (the upstream sees acct:"")
    public async Task Proxy_BlankIdentity_NoHeadersInjected()
    {
        int upstreamPort = FreeTcpPort();
        int proxyPort = FreeTcpPort();

        using var listener = new HttpListener();
        listener.Prefixes.Add($"http://127.0.0.1:{upstreamPort}/");
        listener.Start();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
        Task upstream = RunUpstreamAsync(listener, cts.Token);

        var proxy = new LocalReverseProxy(
            proxyPort,
            new Uri($"http://127.0.0.1:{upstreamPort}/"),
            () => ("", "", ""), // no identity
            _ => { }, _ => { }, _ => { });
        try
        {
            proxy.Start();
            using var http = new HttpClient { Timeout = TimeSpan.FromSeconds(5) };
            using var post = await http.PostAsync($"http://127.0.0.1:{proxyPort}/api/load", new StringContent("x"));
            string echoed = await post.Content.ReadAsStringAsync();
            // Echo format is "upstream-saw:<body>|acct:<acct>"; blank identity => empty tail after "acct:".
            Assert.EndsWith("|acct:", echoed); // no account id injected
            Assert.DoesNotContain("acct:custom", echoed);
        }
        finally
        {
            proxy.Dispose();
            cts.Cancel();
            listener.Stop();
            try { await upstream; } catch { }
        }
    }
}

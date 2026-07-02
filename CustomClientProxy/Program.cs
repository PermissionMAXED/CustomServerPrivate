using System.Net.WebSockets;
using System.Text;
using BapCustomClientProxy;

string? rawTarget = args.FirstOrDefault()
    ?? Environment.GetEnvironmentVariable("BAP_CUSTOM_SERVER");

if (string.IsNullOrWhiteSpace(rawTarget))
{
    Console.Write("Custom server URL or IP:port: ");
    rawTarget = Console.ReadLine();
}

if (string.IsNullOrWhiteSpace(rawTarget))
{
    Console.Error.WriteLine("No custom server was provided.");
    return 2;
}

Uri? targetBase = ProxyHelpers.ResolveTarget(rawTarget);
if (targetBase is null)
{
    Console.Error.WriteLine($"Invalid custom server URL: {rawTarget}");
    return 2;
}

var builder = WebApplication.CreateBuilder(args);

// Listen port: env var BAP_CUSTOM_PROXY_PORT, or a static default of 5055.
// The test suite overrides this to a free OS-assigned port to avoid collisions.
int proxyPort = int.TryParse(Environment.GetEnvironmentVariable("BAP_CUSTOM_PROXY_PORT"), out int p) ? p : 5055;
builder.WebHost.UseUrls($"http://127.0.0.1:{proxyPort}");
builder.Logging.ClearProviders();
builder.Logging.AddSimpleConsole();
builder.Logging.SetMinimumLevel(LogLevel.Warning);
builder.Services.AddHttpClient("proxy")
    .ConfigurePrimaryHttpMessageHandler(() => new SocketsHttpHandler
    {
        AllowAutoRedirect = false
        // No AutomaticDecompression — the proxy is a transparent pass-through forwarding
        // bytes verbatim (including compressed bodies with their original Content-Encoding).
        // Auto-decompression would decompress the body but leave Content-Encoding headers
        // intact, sending the client decompressed bytes labeled as compressed — a mismatch
        // that corrupts every gzip/br/deflate response. Matches LocalReverseProxy behavior.
    });

WebApplication app = builder.Build();
app.UseWebSockets();

app.Map("/{**path}", async (HttpContext context, IHttpClientFactory httpClientFactory) =>
{
    Uri upstreamUri = ProxyHelpers.BuildUpstreamUri(targetBase, context.Request.Path.Value, context.Request.QueryString.Value);

    if (context.WebSockets.IsWebSocketRequest)
    {
        await ProxyWebSocketAsync(context, upstreamUri);
        return;
    }

    using var request = new HttpRequestMessage(new HttpMethod(context.Request.Method), upstreamUri);
    CopyRequestHeaders(context, request);

    if (HttpMethods.IsPost(context.Request.Method) ||
        HttpMethods.IsPut(context.Request.Method) ||
        HttpMethods.IsPatch(context.Request.Method))
    {
        request.Content = new StreamContent(context.Request.Body);
        CopyContentHeaders(context, request);
    }

    using HttpResponseMessage response = await httpClientFactory.CreateClient("proxy").SendAsync(
        request,
        HttpCompletionOption.ResponseHeadersRead,
        context.RequestAborted);

    context.Response.StatusCode = (int)response.StatusCode;
    CopyResponseHeaders(context, response);

    if (ProxyHelpers.ShouldRewriteSocketDiscovery(context.Request.Path.Value, response.Content.Headers.ContentType?.MediaType))
    {
        string body = await response.Content.ReadAsStringAsync(context.RequestAborted);
        string rewritten = ProxyHelpers.RewriteSocketDiscovery(body);
        byte[] bytes = Encoding.UTF8.GetBytes(rewritten);
        context.Response.Headers.ContentLength = bytes.Length;
        await context.Response.Body.WriteAsync(bytes, context.RequestAborted);
        return;
    }

    await response.Content.CopyToAsync(context.Response.Body, context.RequestAborted);
});

Console.WriteLine($"Forwarding game client traffic from http://127.0.0.1:5055 to {targetBase}");
Console.WriteLine("Keep this window open while the game is running.");
await app.RunAsync();
return 0;

static void CopyRequestHeaders(HttpContext context, HttpRequestMessage request)
{
    foreach (var header in context.Request.Headers)
    {
        if (ProxyHelpers.ShouldSkipRequestHeader(header.Key))
        {
            continue;
        }

        request.Headers.TryAddWithoutValidation(header.Key, header.Value.ToArray());
    }
}

static void CopyContentHeaders(HttpContext context, HttpRequestMessage request)
{
    if (request.Content is null)
    {
        return;
    }

    foreach (var header in context.Request.Headers)
    {
        request.Content.Headers.TryAddWithoutValidation(header.Key, header.Value.ToArray());
    }
}

static void CopyResponseHeaders(HttpContext context, HttpResponseMessage response)
{
    foreach (var header in response.Headers)
    {
        context.Response.Headers[header.Key] = header.Value.ToArray();
    }

    foreach (var header in response.Content.Headers)
    {
        context.Response.Headers[header.Key] = header.Value.ToArray();
    }

    context.Response.Headers.Remove("transfer-encoding");
}

static async Task ProxyWebSocketAsync(HttpContext context, Uri upstreamUri)
{
    var builder = new UriBuilder(upstreamUri)
    {
        Scheme = upstreamUri.Scheme == Uri.UriSchemeHttps ? "wss" : "ws"
    };

    using WebSocket clientSocket = await context.WebSockets.AcceptWebSocketAsync();
    using var upstreamSocket = new ClientWebSocket();

    foreach (var protocol in context.WebSockets.WebSocketRequestedProtocols)
    {
        upstreamSocket.Options.AddSubProtocol(protocol);
    }

    await upstreamSocket.ConnectAsync(builder.Uri, context.RequestAborted);

    Task clientToServer = PumpWebSocketAsync(clientSocket, upstreamSocket, context.RequestAborted);
    Task serverToClient = PumpWebSocketAsync(upstreamSocket, clientSocket, context.RequestAborted);
    await Task.WhenAny(clientToServer, serverToClient);

    await CloseSocketAsync(clientSocket, context.RequestAborted);
    await CloseSocketAsync(upstreamSocket, context.RequestAborted);
}

static async Task PumpWebSocketAsync(WebSocket source, WebSocket destination, CancellationToken cancellationToken)
{
    byte[] buffer = new byte[64 * 1024];

    while (!cancellationToken.IsCancellationRequested &&
           source.State == WebSocketState.Open &&
           destination.State == WebSocketState.Open)
    {
        WebSocketReceiveResult result = await source.ReceiveAsync(buffer, cancellationToken);
        if (result.MessageType == WebSocketMessageType.Close)
        {
            break;
        }

        await destination.SendAsync(
            buffer.AsMemory(0, result.Count),
            result.MessageType,
            result.EndOfMessage,
            cancellationToken);
    }
}

static async Task CloseSocketAsync(WebSocket socket, CancellationToken cancellationToken)
{
    if (socket.State is WebSocketState.Open or WebSocketState.CloseReceived)
    {
        await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "proxy closed", cancellationToken);
    }
}

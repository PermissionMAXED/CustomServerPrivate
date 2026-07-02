using System.Net;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;

namespace BapCustomServerMelon;

internal sealed class LocalReverseProxy : IDisposable
{
    private static readonly HashSet<string> HopByHopHeaders = new(StringComparer.OrdinalIgnoreCase)
    {
        "Connection",
        "Keep-Alive",
        "Proxy-Authenticate",
        "Proxy-Authorization",
        "TE",
        "Trailer",
        "Transfer-Encoding",
        "Upgrade",
        "Host",
        "Content-Length"
    };

    private readonly int _listenPort;
    private readonly Uri _upstreamBaseUri;
    private readonly Func<(string AccountId, string Username, string Discriminator)> _identityProvider;
    private readonly Action<string> _log;
    private readonly Action<string> _warn;
    private readonly Action<string> _error;
    private readonly HttpListener _listener = new();
    private readonly HttpClient _httpClient;
    private readonly CancellationTokenSource _shutdown = new();
    private Task? _acceptLoop;
    private int _interestingWebSocketLogCount;
    private const int MaxInterestingWebSocketLogs = 80;

    // Cached result of the Medusa auto-select probe. The uncached version ran an env-var read plus
    // up to four File.Exists syscalls on EVERY outgoing WS text frame (lobby send path) — disk I/O
    // jitter for a value that never changes while the game is running. 0 = unknown, 1 = on, 2 = off.
    private static int s_medusaAutoSelectCache;

    public LocalReverseProxy(
        int listenPort,
        Uri upstreamBaseUri,
        Func<(string AccountId, string Username, string Discriminator)> identityProvider,
        Action<string> log,
        Action<string> warn,
        Action<string> error)
    {
        _listenPort = listenPort;
        _upstreamBaseUri = upstreamBaseUri;
        _identityProvider = identityProvider;
        _log = log;
        _warn = warn;
        _error = error;
        _httpClient = new HttpClient(new SocketsHttpHandler
        {
            AllowAutoRedirect = false,
            UseCookies = false
        });
    }

    public void Start()
    {
        _listener.Prefixes.Add($"http://127.0.0.1:{_listenPort}/");
        _listener.Prefixes.Add($"http://localhost:{_listenPort}/");
        _listener.Start();
        _acceptLoop = Task.Run(AcceptLoopAsync);
        _log($"Local proxy ready (port {_listenPort})");
    }

    public void Dispose()
    {
        _shutdown.Cancel();

        try
        {
            _listener.Close();
        }
        catch
        {
            // Listener shutdown can race with pending requests.
        }

        _httpClient.Dispose();
        _shutdown.Dispose();
    }

    private async Task AcceptLoopAsync()
    {
        while (!_shutdown.IsCancellationRequested)
        {
            HttpListenerContext context;
            try
            {
                context = await _listener.GetContextAsync().ConfigureAwait(false);
            }
            catch (ObjectDisposedException)
            {
                break;
            }
            catch (HttpListenerException)
            {
                break;
            }
            catch (InvalidOperationException)
            {
                break;
            }
            catch (Exception ex)
            {
                _warn($"Proxy accept failed: {ex.Message}");
                continue;
            }

            _ = Task.Run(() => HandleContextAsync(context), _shutdown.Token);
        }
    }

    private async Task HandleContextAsync(HttpListenerContext context)
    {
        try
        {
            if (context.Request.IsWebSocketRequest)
            {
                await ProxyWebSocketAsync(context).ConfigureAwait(false);
            }
            else
            {
                await ProxyHttpAsync(context).ConfigureAwait(false);
            }
        }
        catch (Exception ex)
        {
            _warn($"Proxy request failed: {ex.Message}");
            TryWriteError(context.Response, 502, ex.Message);
        }
    }

    private async Task ProxyHttpAsync(HttpListenerContext context)
    {
        Uri upstreamUri = BuildUpstreamUri(context.Request.Url, websocket: false);

        using var upstreamRequest = new HttpRequestMessage(new HttpMethod(context.Request.HttpMethod), upstreamUri);
        CopyRequestHeaders(context.Request, upstreamRequest);
        ApplyIdentityHeaders(upstreamRequest);

        string requestBody = "";
        bool hasRequestBody = HasRequestBody(context.Request);

        if (hasRequestBody)
        {
            using var reader = new System.IO.StreamReader(context.Request.InputStream, Encoding.UTF8);
            requestBody = await reader.ReadToEndAsync().ConfigureAwait(false);
            upstreamRequest.Content = new StringContent(requestBody, Encoding.UTF8);
            CopyContentHeaders(context.Request, upstreamRequest.Content.Headers);
        }

        using HttpResponseMessage upstreamResponse = await _httpClient.SendAsync(
            upstreamRequest,
            HttpCompletionOption.ResponseHeadersRead,
            _shutdown.Token).ConfigureAwait(false);

        context.Response.StatusCode = (int)upstreamResponse.StatusCode;
        CopyResponseHeaders(upstreamResponse, context.Response);

        if (ShouldRewriteLoadResponse(context.Request.Url, upstreamResponse))
        {
            string body = await upstreamResponse.Content.ReadAsStringAsync(_shutdown.Token).ConfigureAwait(false);
            byte[] bytes = Encoding.UTF8.GetBytes(RewriteLoadResponse(body));
            context.Response.ContentType = "application/json; charset=utf-8";
            context.Response.ContentLength64 = bytes.Length;
            await context.Response.OutputStream.WriteAsync(bytes, _shutdown.Token).ConfigureAwait(false);
        }
        else if (ShouldRewriteSocketDiscovery(context.Request.Url, upstreamResponse))
        {
            string body = await upstreamResponse.Content.ReadAsStringAsync(_shutdown.Token).ConfigureAwait(false);
            byte[] bytes = Encoding.UTF8.GetBytes(RewriteSocketDiscovery(body));
            context.Response.ContentType = "application/json; charset=utf-8";
            context.Response.ContentLength64 = bytes.Length;
            await context.Response.OutputStream.WriteAsync(bytes, _shutdown.Token).ConfigureAwait(false);
        }
        else if (ShouldRewriteCharListing(context.Request.Url, upstreamResponse))
        {
            string body = await upstreamResponse.Content.ReadAsStringAsync(_shutdown.Token).ConfigureAwait(false);
            byte[] bytes = Encoding.UTF8.GetBytes(RewriteCharListingResponse(body));
            context.Response.ContentType = "application/json; charset=utf-8";
            context.Response.ContentLength64 = bytes.Length;
            await context.Response.OutputStream.WriteAsync(bytes, _shutdown.Token).ConfigureAwait(false);
        }
        else
        {
            // PERF: stream the upstream response straight through. The old path buffered every
            // response into a MemoryStream, copied it to a byte[] AND decoded it into a UTF-8
            // string purely to hand it to the (now body-less) traffic log — per-poll garbage that
            // showed up as in-game micro-stutter.
            await using Stream stream = await upstreamResponse.Content.ReadAsStreamAsync(_shutdown.Token)
                .ConfigureAwait(false);
            await stream.CopyToAsync(context.Response.OutputStream, _shutdown.Token).ConfigureAwait(false);
        }

        context.Response.OutputStream.Close();

        LogAllHttpTraffic("HTTP", context.Request.HttpMethod, upstreamUri.ToString(),
            (int)upstreamResponse.StatusCode);
    }

    private async Task ProxyWebSocketAsync(HttpListenerContext context)
    {
        Uri upstreamUri = BuildUpstreamUri(context.Request.Url, websocket: true);
        HttpListenerWebSocketContext clientContext = await context.AcceptWebSocketAsync(subProtocol: null)
            .ConfigureAwait(false);

        using WebSocket clientSocket = clientContext.WebSocket;
        using var upstreamSocket = new ClientWebSocket();

        foreach (string? headerName in context.Request.Headers.AllKeys)
        {
            if (string.IsNullOrWhiteSpace(headerName) ||
                HopByHopHeaders.Contains(headerName) ||
                headerName.StartsWith("Sec-WebSocket", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            string? headerValue = context.Request.Headers[headerName];
            if (!string.IsNullOrWhiteSpace(headerValue))
            {
                TrySetWebSocketHeader(upstreamSocket, headerName, headerValue);
            }
        }

        ApplyIdentityHeaders(upstreamSocket);

        await upstreamSocket.ConnectAsync(upstreamUri, _shutdown.Token).ConfigureAwait(false);
        _log($"Proxy WS connected: local {context.Request.RawUrl} -> {upstreamUri}");

        // Linked CTS so the losing pump is cancelled (and awaited) instead of being abandoned to
        // throw an unobserved exception when the using blocks dispose the sockets underneath it.
        using var pumpCts = CancellationTokenSource.CreateLinkedTokenSource(_shutdown.Token);
        Task clientToServer = PumpWebSocketAsync(clientSocket, upstreamSocket, "client->server", LogInterestingWebSocketFrame, pumpCts.Token);
        Task serverToClient = PumpWebSocketAsync(upstreamSocket, clientSocket, "server->client", LogInterestingWebSocketFrame, pumpCts.Token);
        await Task.WhenAny(clientToServer, serverToClient).ConfigureAwait(false);
        pumpCts.Cancel();

        await CloseSocketAsync(clientSocket).ConfigureAwait(false);
        await CloseSocketAsync(upstreamSocket).ConfigureAwait(false);

        // Observe both pump results so a receive/send fault never surfaces as an unobserved task
        // exception after the sockets are disposed.
        try { await clientToServer.ConfigureAwait(false); } catch { }
        try { await serverToClient.ConfigureAwait(false); } catch { }
    }

    private Uri BuildUpstreamUri(Uri? requestUri, bool websocket)
    {
        string requestPath = requestUri?.AbsolutePath ?? "/";
        string basePath = _upstreamBaseUri.AbsolutePath.TrimEnd('/');
        string path = CombinePath(basePath, requestPath);

        string query = requestUri?.Query.TrimStart('?') ?? "";
        if (websocket)
        {
            // Carry identity on the WS URL query (server's ClientIdentityResolver reads ?username/
            // ?accountId). This is immune to ClientWebSocket restricted-header rejection on Mono,
            // which is why the X-BAP-Username header alone was unreliable and players showed as
            // "Player{N}".
            query = AppendIdentityQuery(query);
        }

        var builder = new UriBuilder(_upstreamBaseUri)
        {
            Scheme = websocket
                ? (_upstreamBaseUri.Scheme == Uri.UriSchemeHttps ? "wss" : "ws")
                : _upstreamBaseUri.Scheme,
            Path = path,
            Query = query
        };

        return builder.Uri;
    }

    private string AppendIdentityQuery(string existingQuery)
    {
        (string accountId, string username, string discriminator) = _identityProvider();
        var parts = new List<string>();
        if (!string.IsNullOrWhiteSpace(existingQuery)) parts.Add(existingQuery);
        if (!string.IsNullOrWhiteSpace(accountId) && !existingQuery.Contains("accountId=", StringComparison.OrdinalIgnoreCase))
            parts.Add($"accountId={Uri.EscapeDataString(accountId)}");
        if (!string.IsNullOrWhiteSpace(username) && !existingQuery.Contains("username=", StringComparison.OrdinalIgnoreCase))
            parts.Add($"username={Uri.EscapeDataString(username)}");
        if (!string.IsNullOrWhiteSpace(discriminator) && !existingQuery.Contains("discriminator=", StringComparison.OrdinalIgnoreCase))
            parts.Add($"discriminator={Uri.EscapeDataString(discriminator)}");
        return string.Join("&", parts);
    }

    private static string CombinePath(string basePath, string requestPath)
    {
        if (string.IsNullOrWhiteSpace(basePath) || basePath == "/")
        {
            return string.IsNullOrWhiteSpace(requestPath) ? "/" : requestPath;
        }

        if (string.IsNullOrWhiteSpace(requestPath) || requestPath == "/")
        {
            return basePath;
        }

        return $"{basePath.TrimEnd('/')}/{requestPath.TrimStart('/')}";
    }

    private static bool HasRequestBody(HttpListenerRequest request)
    {
        if (string.Equals(request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase) ||
            string.Equals(request.HttpMethod, "HEAD", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        return request.ContentLength64 > 0 ||
               string.Equals(request.Headers["Transfer-Encoding"], "chunked", StringComparison.OrdinalIgnoreCase) ||
               request.HasEntityBody;
    }

    private static void CopyRequestHeaders(HttpListenerRequest source, HttpRequestMessage target)
    {
        foreach (string? headerName in source.Headers.AllKeys)
        {
            if (string.IsNullOrWhiteSpace(headerName) || HopByHopHeaders.Contains(headerName))
            {
                continue;
            }

            string? value = source.Headers[headerName];
            if (string.IsNullOrWhiteSpace(value))
            {
                continue;
            }

            if (!target.Headers.TryAddWithoutValidation(headerName, value) && target.Content != null)
            {
                target.Content.Headers.TryAddWithoutValidation(headerName, value);
            }
        }
    }

    private static void CopyContentHeaders(HttpListenerRequest source, HttpContentHeaders target)
    {
        foreach (string? headerName in source.Headers.AllKeys)
        {
            if (string.IsNullOrWhiteSpace(headerName) || HopByHopHeaders.Contains(headerName))
            {
                continue;
            }

            string? value = source.Headers[headerName];
            if (!string.IsNullOrWhiteSpace(value))
            {
                target.TryAddWithoutValidation(headerName, value);
            }
        }
    }

    private void ApplyIdentityHeaders(HttpRequestMessage request)
    {
        (string accountId, string username, string discriminator) = _identityProvider();
        MelonProxyHelpers.ApplyIdentityHeaders(request, accountId, username, discriminator);
    }

    private void ApplyIdentityHeaders(ClientWebSocket socket)
    {
        (string accountId, string username, string discriminator) = _identityProvider();

        // Best-effort secondary carrier (the WS query string in BuildUpstreamUri is primary, since
        // ClientWebSocket can reject these custom headers on Mono). Send username independently of
        // accountId so a username-only INI still names the player.
        if (!string.IsNullOrWhiteSpace(accountId))
        {
            TrySetWebSocketHeader(socket, "X-BAP-AccountId", accountId);
            TrySetWebSocketHeader(socket, "X-BAP-UserId", accountId);
        }

        if (!string.IsNullOrWhiteSpace(username))
        {
            TrySetWebSocketHeader(socket, "X-BAP-Username", username);
        }

        if (!string.IsNullOrWhiteSpace(discriminator))
        {
            TrySetWebSocketHeader(socket, "X-BAP-Discriminator", discriminator);
        }
    }

    private static void CopyResponseHeaders(HttpResponseMessage source, HttpListenerResponse target)
    {
        foreach (KeyValuePair<string, IEnumerable<string>> header in source.Headers)
        {
            TrySetResponseHeader(target, header.Key, header.Value);
        }

        foreach (KeyValuePair<string, IEnumerable<string>> header in source.Content.Headers)
        {
            TrySetResponseHeader(target, header.Key, header.Value);
        }
    }

    private static void TrySetResponseHeader(HttpListenerResponse target, string headerName, IEnumerable<string> values)
    {
        if (HopByHopHeaders.Contains(headerName))
        {
            return;
        }

        try
        {
            string value = string.Join(", ", values);
            if (!string.IsNullOrWhiteSpace(value))
            {
                target.Headers[headerName] = value;
            }
        }
        catch
        {
            // HttpListener owns a few restricted headers; skipping them is safer than failing the request.
        }
    }

    private bool ShouldRewriteSocketDiscovery(Uri? requestUri, HttpResponseMessage response)
    {
        string path = requestUri?.AbsolutePath ?? "";
        if (!path.Contains("socket", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        string? mediaType = response.Content.Headers.ContentType?.MediaType;
        return string.IsNullOrWhiteSpace(mediaType) ||
               mediaType.Contains("json", StringComparison.OrdinalIgnoreCase) ||
               mediaType.Contains("text", StringComparison.OrdinalIgnoreCase);
    }

    private bool ShouldRewriteCharListing(Uri? requestUri, HttpResponseMessage response)
    {
        string path = requestUri?.AbsolutePath ?? "";
        if (!path.Contains("chars", StringComparison.OrdinalIgnoreCase) ||
            !path.Contains("listing", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        string? mediaType = response.Content.Headers.ContentType?.MediaType;
        return string.IsNullOrWhiteSpace(mediaType) ||
               mediaType.Contains("json", StringComparison.OrdinalIgnoreCase);
    }

    private bool ShouldRewriteLoadResponse(Uri? requestUri, HttpResponseMessage response)
    {
        string path = requestUri?.AbsolutePath.TrimEnd('/') ?? "";
        if (!IsLoadLikePath(path))
        {
            return false;
        }

        string? mediaType = response.Content.Headers.ContentType?.MediaType;
        return string.IsNullOrWhiteSpace(mediaType) ||
               mediaType.Contains("json", StringComparison.OrdinalIgnoreCase);
    }

    private static bool IsLoadLikePath(string path)
    {
        return path.Equals("/api/load", StringComparison.OrdinalIgnoreCase) ||
               path.Equals("/load", StringComparison.OrdinalIgnoreCase) ||
               path.Equals("/api/login", StringComparison.OrdinalIgnoreCase) ||
               path.Equals("/login", StringComparison.OrdinalIgnoreCase) ||
               path.Equals("/api/guest", StringComparison.OrdinalIgnoreCase) ||
               path.Equals("/guest", StringComparison.OrdinalIgnoreCase) ||
               path.Equals("/api/auth/guest", StringComparison.OrdinalIgnoreCase) ||
               path.Equals("/auth/guest", StringComparison.OrdinalIgnoreCase) ||
               path.Equals("/api/auth/steam-ticket/login", StringComparison.OrdinalIgnoreCase);
    }

    private string RewriteLoadResponse(string body)
    {
        return MelonProxyHelpers.RewriteLoadResponse(body);
    }

    private string RewriteCharListingResponse(string body)
    {
        string rewritten = MelonProxyHelpers.RewriteCharListingResponse(body);
        if (ReferenceEquals(rewritten, body) || string.Equals(rewritten, body, StringComparison.Ordinal))
        {
            return body;
        }

        return rewritten;
    }

    private string RewriteSocketDiscovery(string body)
    {
        return MelonProxyHelpers.RewriteSocketDiscovery(body, _listenPort);
    }

    private static void TrySetWebSocketHeader(ClientWebSocket socket, string headerName, string headerValue)
    {
        try
        {
            socket.Options.SetRequestHeader(headerName, headerValue);
        }
        catch
        {
            // ClientWebSocket can reject restricted custom headers on Mono. This is best-effort only:
            // identity is carried primarily via the WS URL query string (BuildUpstreamUri), so a
            // rejected header here is harmless.
        }
    }

    private async Task PumpWebSocketAsync(
        WebSocket source,
        WebSocket destination,
        string direction,
        Action<string, WebSocketMessageType, ArraySegment<byte>, bool> inspectFrame,
        CancellationToken cancellationToken)
    {
        byte[] buffer = new byte[64 * 1024];

        while (!cancellationToken.IsCancellationRequested &&
               source.State == WebSocketState.Open &&
               destination.State == WebSocketState.Open)
        {
            WebSocketReceiveResult result = await source.ReceiveAsync(buffer, cancellationToken).ConfigureAwait(false);
            if (result.MessageType == WebSocketMessageType.Close)
            {
                break;
            }

            var segment = new ArraySegment<byte>(buffer, 0, result.Count);
            ArraySegment<byte> outboundSegment = RewriteClientToServerFrame(direction, result.MessageType, segment, result.EndOfMessage);
            inspectFrame(direction, result.MessageType, outboundSegment, result.EndOfMessage);

            await destination.SendAsync(
                outboundSegment,
                result.MessageType,
                result.EndOfMessage,
                cancellationToken).ConfigureAwait(false);
        }
    }

    private ArraySegment<byte> RewriteClientToServerFrame(
        string direction,
        WebSocketMessageType messageType,
        ArraySegment<byte> data,
        bool endOfMessage)
    {
        if (!direction.Equals("client->server", StringComparison.OrdinalIgnoreCase) ||
            messageType != WebSocketMessageType.Text ||
            !endOfMessage ||
            data.Array == null ||
            data.Count <= 0 ||
            !ShouldForceMedusaCharacterId())
        {
            return data;
        }

        string text;
        try
        {
            text = Encoding.UTF8.GetString(data.Array, data.Offset, data.Count);
        }
        catch
        {
            return data;
        }

        try
        {
            if (MelonProxyHelpers.TryRewriteMedusaCharId(text, out string rewritten, out int oldCharId))
            {
                _log($"Proxy WS Medusa auto-select rewrite: charId {oldCharId}->15.");
                byte[] bytes = Encoding.UTF8.GetBytes(rewritten);
                return new ArraySegment<byte>(bytes, 0, bytes.Length);
            }
            return data;
        }
        catch (Exception ex)
        {
            _warn($"Proxy WS Medusa auto-select rewrite failed: {ex.Message}");
            return data;
        }
    }

    private static bool ShouldForceMedusaCharacterId()
    {
        int cached = Volatile.Read(ref s_medusaAutoSelectCache);
        if (cached != 0)
        {
            return cached == 1;
        }

        bool result = ProbeMedusaAutoSelect();
        Volatile.Write(ref s_medusaAutoSelectCache, result ? 1 : 2);
        return result;
    }

    private static bool ProbeMedusaAutoSelect()
    {
        try
        {
            string? env = Environment.GetEnvironmentVariable("BAPBAP_MEDUSA_AUTOSELECT");
            if (!string.IsNullOrWhiteSpace(env) &&
                (env == "1" || env.Equals("true", StringComparison.OrdinalIgnoreCase) || env.Equals("yes", StringComparison.OrdinalIgnoreCase)))
            {
                return IsMedusaInstalled();
            }
        }
        catch { }

        try
        {
            foreach (string root in new[] { Environment.CurrentDirectory, AppContext.BaseDirectory })
            {
                if (string.IsNullOrWhiteSpace(root)) continue;
                if (File.Exists(Path.Combine(root, "UserData", "Medusa", "auto-select.txt")) && IsMedusaInstalled(root))
                {
                    return true;
                }
            }
        }
        catch { }

        return false;
    }

    private static bool IsMedusaInstalled(string? root = null)
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(root) &&
                File.Exists(Path.Combine(root, "Mods", "BAPBAP.Medusa.dll")))
            {
                return true;
            }

            foreach (string candidate in new[] { Environment.CurrentDirectory, AppContext.BaseDirectory })
            {
                if (string.IsNullOrWhiteSpace(candidate)) continue;
                if (File.Exists(Path.Combine(candidate, "Mods", "BAPBAP.Medusa.dll"))) return true;
            }
        }
        catch { }

        return false;
    }

    private void LogAllHttpTraffic(string direction, string method, string url, int statusCode)
    {
        // PERF: only the one-line status is logged. Dumping the full REQ/RES JSON bodies of every
        // metagame poll (IAP/pass/profile listings are multi-KB) wrote megabytes to the MelonLoader
        // log file synchronously every few seconds, causing periodic in-game stutter/standbild. The
        // bodies were diagnostic-only; the status line is enough to see traffic without the lag.
        string safeUrl = SanitizeUrlForLog(url);
        _log($"[NET] {direction} {method} {safeUrl} -> {statusCode}");
    }

    private static string SanitizeUrlForLog(string url)
    {
        // Only show path + query, hide tokens/keys
        try
        {
            var uri = new Uri(url);
            string path = uri.AbsolutePath;
            string query = uri.Query;
            if (query.Length > 0)
            {
                // Redact values of known sensitive query params
                var parts = query.TrimStart('?').Split('&')
                    .Select(p =>
                    {
                        var eq = p.IndexOf('=');
                        return eq > 0 ? p[..(eq + 1)] + "<redacted>" : p;
                    });
                return path + "?" + string.Join("&", parts);
            }
            return path;
        }
        catch
        {
            // If URL parsing fails, just truncate
            return url.Length <= 200 ? url : url[..200] + "...";
        }
    }

    private void LogInterestingWebSocketFrame(string direction, WebSocketMessageType messageType, ArraySegment<byte> data, bool endOfMessage)
    {
        // Volatile read is fine here; the hard cap below uses Interlocked so two pump tasks can't
        // exceed the limit together.
        if (messageType != WebSocketMessageType.Text ||
            data.Array == null ||
            data.Count <= 0 ||
            Volatile.Read(ref _interestingWebSocketLogCount) >= MaxInterestingWebSocketLogs)
        {
            return;
        }

        string text;
        try
        {
            text = Encoding.UTF8.GetString(data.Array, data.Offset, data.Count);
        }
        catch
        {
            return;
        }

        if (!IsInterestingWebSocketPayload(text))
        {
            return;
        }

        int count = Interlocked.Increment(ref _interestingWebSocketLogCount);
        if (count > MaxInterestingWebSocketLogs)
        {
            return;
        }

        _log($"Proxy WS {direction} #{count} end={endOfMessage}: {SanitizeWebSocketPayload(text)}");
    }

    private static bool IsInterestingWebSocketPayload(string text)
    {
        return text.Contains("QUEUE", StringComparison.OrdinalIgnoreCase) ||
               text.Contains("MATCH", StringComparison.OrdinalIgnoreCase) ||
               text.Contains("GAME_STARTED", StringComparison.OrdinalIgnoreCase) ||
               text.Contains("GAME_START", StringComparison.OrdinalIgnoreCase) ||
               text.Contains("JOIN_LOBBY", StringComparison.OrdinalIgnoreCase) ||
               text.Contains("SWITCH_CHAR", StringComparison.OrdinalIgnoreCase) ||
               text.Contains("CHAR_UPDATED", StringComparison.OrdinalIgnoreCase) ||
               text.Contains("START_CUSTOM_GAME", StringComparison.OrdinalIgnoreCase) ||
               text.Contains("warningMessage", StringComparison.OrdinalIgnoreCase) ||
               text.Contains("gameAuthId", StringComparison.OrdinalIgnoreCase);
    }

    private static string SanitizeWebSocketPayload(string text)
    {
        string compact = string.Join(' ', text.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries));
        compact = Regex.Replace(
            compact,
            "(\"(?:gameAuthId|auth|token|sessionId)\"\\s*:\\s*\")([^\"]+)(\")",
            "$1<redacted>$3",
            RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

        return compact.Length <= 1200
            ? compact
            : compact[..1200] + "...<truncated>";
    }

    private static async Task CloseSocketAsync(WebSocket socket)
    {
        try
        {
            if (socket.State is WebSocketState.Open or WebSocketState.CloseReceived)
            {
                await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "proxy closed", CancellationToken.None)
                    .ConfigureAwait(false);
            }
        }
        catch
        {
            // Ignore close races.
        }
    }

    private static void TryWriteError(HttpListenerResponse response, int statusCode, string message)
    {
        try
        {
            response.StatusCode = statusCode;
            byte[] body = Encoding.UTF8.GetBytes(message);
            response.ContentType = "text/plain; charset=utf-8";
            response.ContentLength64 = body.Length;
            response.OutputStream.Write(body, 0, body.Length);
            response.OutputStream.Close();
        }
        catch
        {
            // Response may already be closed.
        }
    }
}

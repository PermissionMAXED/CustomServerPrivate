using System.Text.Json;
using System.Text.Json.Nodes;

namespace BapCustomClientProxy;

// Pure forwarding helpers, extracted so they can be unit-tested without a live web host.
public static class ProxyHelpers
{
    public const string LocalSocketUrl = "ws://127.0.0.1:5055/ws";

    // Normalize a raw target (arg/env/prompt) into an absolute http/https URI, or null if invalid.
    public static Uri? ResolveTarget(string? target)
    {
        if (string.IsNullOrWhiteSpace(target))
        {
            return null;
        }

        if (!target.Contains("://", StringComparison.Ordinal))
        {
            target = "http://" + target;
        }

        if (!Uri.TryCreate(target, UriKind.Absolute, out Uri? uri) ||
            (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
        {
            return null;
        }

        return uri;
    }

    public static string CombinePath(string basePath, string requestPath)
    {
        string left = string.IsNullOrWhiteSpace(basePath) ? "" : basePath.TrimEnd('/');
        string right = requestPath.TrimStart('/');
        return string.IsNullOrEmpty(right) ? left : $"{left}/{right}";
    }

    public static Uri BuildUpstreamUri(Uri targetBase, string? path, string? query)
    {
        var builder = new UriBuilder(targetBase)
        {
            Path = CombinePath(targetBase.AbsolutePath, path ?? ""),
            Query = !string.IsNullOrEmpty(query) && query.StartsWith('?') ? query[1..] : (query ?? "")
        };

        return builder.Uri;
    }

    // Host and Sec-WebSocket-* headers must not be relayed verbatim to the upstream.
    public static bool ShouldSkipRequestHeader(string headerName)
    {
        return headerName.Equals("Host", StringComparison.OrdinalIgnoreCase) ||
               headerName.StartsWith("Sec-WebSocket", StringComparison.OrdinalIgnoreCase);
    }

    // Only rewrite when the path looks like socket discovery and the body is JSON (or unknown).
    public static bool ShouldRewriteSocketDiscovery(string? requestPath, string? mediaType)
    {
        if (string.IsNullOrEmpty(requestPath) ||
            !requestPath.Contains("socket", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        return mediaType is null || mediaType.Contains("json", StringComparison.OrdinalIgnoreCase);
    }

    public static string RewriteSocketDiscovery(string body)
    {
        try
        {
            JsonNode? node = JsonNode.Parse(body);
            if (node is JsonObject obj)
            {
                if (obj.ContainsKey("socketUrl"))
                {
                    obj["socketUrl"] = LocalSocketUrl;
                }
                else if (obj.ContainsKey("socket_url"))
                {
                    obj["socket_url"] = LocalSocketUrl;
                }

                return obj.ToJsonString(new JsonSerializerOptions(JsonSerializerDefaults.Web));
            }
        }
        catch (JsonException)
        {
            // Leave unexpected responses untouched.
        }

        return body;
    }
}

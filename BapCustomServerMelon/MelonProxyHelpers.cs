using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;

namespace BapCustomServerMelon;

// Pure (Unity-free) string/JSON helpers for the in-game reverse proxy, extracted so the
// socket-discovery rewrite (F155) and Medusa auto-select rewrite (F168) can be unit-tested
// without loading MelonLoader / Unity. LocalReverseProxy delegates to these.
internal static class MelonProxyHelpers
{
    // F155 — rewrite the lobby socket-discovery URL so the game connects its WebSocket back
    // through the local proxy. Tries JSON first (socketUrl / socket_url), falls back to a narrow
    // regex for minified/non-object bodies. Non-matching bodies are returned unchanged.
    public static string RewriteSocketDiscovery(string body, int listenPort)
    {
        string socketUrl = $"ws://127.0.0.1:{listenPort}/ws";

        try
        {
            JsonNode? node = JsonNode.Parse(body);
            if (node is JsonObject obj)
            {
                if (obj.ContainsKey("socketUrl")) obj["socketUrl"] = socketUrl;
                if (obj.ContainsKey("socket_url")) obj["socket_url"] = socketUrl;
                return obj.ToJsonString(new JsonSerializerOptions { WriteIndented = false });
            }
        }
        catch (JsonException)
        {
            // Fall back to a narrow string replacement for older/minified responses.
        }

        string rewritten = Regex.Replace(
            body,
            "\"socketUrl\"\\s*:\\s*\"[^\"]*\"",
            $"\"socketUrl\":\"{socketUrl}\"",
            RegexOptions.CultureInvariant);

        return Regex.Replace(
            rewritten,
            "\"socket_url\"\\s*:\\s*\"[^\"]*\"",
            $"\"socket_url\":\"{socketUrl}\"",
            RegexOptions.CultureInvariant);
    }

    // F168 — rewrite an outgoing lobby WS frame's payload.charId to Medusa (15) for JOIN_LOBBY /
    // SWITCH_CHAR events. Returns true (with the rewritten JSON) only when a change was made;
    // returns false for non-matching events, already-15, or unparseable frames (caller keeps original).
    public static bool TryRewriteMedusaCharId(string text, out string rewritten, out int oldCharId)
    {
        rewritten = text;
        oldCharId = -1;

        if (!text.Contains("JOIN_LOBBY", StringComparison.OrdinalIgnoreCase) &&
            !text.Contains("SWITCH_CHAR", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        try
        {
            JsonNode? node = JsonNode.Parse(text);
            if (node is not JsonObject obj || obj["payload"] is not JsonObject payload)
            {
                return false;
            }

            string? eventName = obj["event"]?.GetValue<string>();
            if (!string.Equals(eventName, "JOIN_LOBBY", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(eventName, "SWITCH_CHAR", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            try { oldCharId = payload["charId"]?.GetValue<int>() ?? -1; } catch { }
            if (oldCharId == 15)
            {
                return false;
            }

            payload["charId"] = 15;
            rewritten = obj.ToJsonString(new JsonSerializerOptions { WriteIndented = false });
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static int[] ExtractJsonIntArray(string body, string key)
    {
        if (string.IsNullOrWhiteSpace(body) || string.IsNullOrWhiteSpace(key))
        {
            return Array.Empty<int>();
        }

        try
        {
            JsonNode? node = JsonNode.Parse(body);
            if (node is not JsonObject obj)
            {
                return Array.Empty<int>();
            }

            JsonNode? value = null;
            foreach (KeyValuePair<string, JsonNode?> property in obj)
            {
                if (string.Equals(property.Key, key, StringComparison.OrdinalIgnoreCase))
                {
                    value = property.Value;
                    break;
                }
            }

            if (value is not JsonArray array)
            {
                return Array.Empty<int>();
            }

            var ids = new List<int>();
            foreach (JsonNode? item in array)
            {
                if (item == null)
                {
                    continue;
                }

                try
                {
                    ids.Add(item.GetValue<int>());
                }
                catch
                {
                    if (int.TryParse(item.ToString(), out int parsed))
                    {
                        ids.Add(parsed);
                    }
                }
            }

            return ids.ToArray();
        }
        catch
        {
            return Array.Empty<int>();
        }
    }

    public static int[] NormalizeCharacterIds(IEnumerable<int> ids, int maxCharacterId)
    {
        return ids
            .Where(id => id >= 0 && id <= maxCharacterId)
            .Distinct()
            .OrderBy(id => id)
            .ToArray();
    }

    public static bool HasKnownCustomCharacterRuntime(string root)
    {
        if (string.IsNullOrWhiteSpace(root))
        {
            return false;
        }

        string[] dllNames =
        {
            "NetworkedCustomChar.dll",
            "BAPCustomChars.dll",
            "BAPBAP.Medusa.dll",
            "BAPBAPModAPI.dll",
            "BAPBAPModdingAPI.dll",
            "ModdingAPI.dll"
        };

        foreach (string dllName in dllNames)
        {
            if (File.Exists(Path.Combine(root, "Mods", dllName)) ||
                File.Exists(Path.Combine(root, dllName)))
            {
                return true;
            }
        }

        return false;
    }

    public static string RewriteCharListingResponse(string body)
    {
        try
        {
            JsonNode? node = JsonNode.Parse(body);
            if (node is not JsonObject root || root["charListings"] is not JsonArray sourceListings)
            {
                return body;
            }

            var listings = new JsonArray();
            foreach (JsonNode? item in sourceListings)
            {
                if (item is not JsonObject listing)
                {
                    listings.Add(item == null ? null : JsonNode.Parse(item.ToJsonString()));
                    continue;
                }

                var rewritten = new JsonObject();
                foreach (KeyValuePair<string, JsonNode?> property in listing)
                {
                    switch (property.Key)
                    {
                        case "purchases":
                            rewritten[property.Key] = 1;
                            break;
                        case "costs":
                            rewritten[property.Key] = new JsonArray();
                            break;
                        default:
                            rewritten[property.Key] = property.Value == null ? null : JsonNode.Parse(property.Value.ToJsonString());
                            break;
                    }
                }

                if (!rewritten.ContainsKey("purchases"))
                {
                    rewritten["purchases"] = 1;
                }

                if (!rewritten.ContainsKey("costs"))
                {
                    rewritten["costs"] = new JsonArray();
                }

                listings.Add(rewritten);
            }

            root["charListings"] = listings;
            return root.ToJsonString(new JsonSerializerOptions { WriteIndented = false });
        }
        catch
        {
            return body;
        }
    }

    public static string RewriteLoadResponse(string body)
    {
        try
        {
            JsonNode? node = JsonNode.Parse(body);
            if (node is not JsonObject root || root["assets"] is not JsonArray assets)
            {
                return body;
            }

            int[] charIds = NormalizeCharacterIds(ExtractJsonIntArray(body, "availableCharacters"), maxCharacterId: 15);
            if (charIds.Length == 0)
            {
                charIds = Enumerable.Range(0, 16).ToArray();
            }

            root["isCompleted"] = true;
            root["availableCharacters"] = ToJsonArray(charIds);
            root["assets"] = RewriteLoadAssets(assets, charIds);
            EnsureLoadoutSkins(root, charIds);

            return root.ToJsonString(new JsonSerializerOptions { WriteIndented = false });
        }
        catch
        {
            return body;
        }
    }

    private static JsonArray RewriteLoadAssets(JsonArray assets, int[] charIds)
    {
        var balances = new SortedDictionary<int, int>();

        foreach (JsonNode? item in assets)
        {
            if (item is not JsonObject asset)
            {
                continue;
            }

            int? assetId = TryGetInt(asset, "assetId");
            if (!assetId.HasValue || IsUnsafeLoadAsset(assetId.Value))
            {
                continue;
            }

            int balance = Math.Max(0, TryGetInt(asset, "balance") ?? 1);
            UpsertMax(balances, assetId.Value, balance);
        }

        foreach (int charId in charIds)
        {
            UpsertMax(balances, charId, 1);
            UpsertMax(balances, 100000 + charId, 1);
            UpsertMax(balances, GetDefaultSkinAssetId(charId), 1);
        }

        var rewritten = new JsonArray();
        foreach ((int assetId, int balance) in balances)
        {
            rewritten.Add(new JsonObject
            {
                ["assetId"] = assetId,
                ["balance"] = balance
            });
        }

        return rewritten;
    }

    private static bool IsUnsafeLoadAsset(int assetId)
    {
        return assetId == 300001 || assetId == 300004 || assetId == 300006;
    }

    private static void EnsureLoadoutSkins(JsonObject root, int[] charIds)
    {
        JsonObject loadout = root["loadout"] as JsonObject ?? new JsonObject();
        int maxCharId = Math.Max(15, charIds.Length == 0 ? 15 : charIds.Max());
        int[] skins = new int[maxCharId + 1];

        if (loadout["skins"] is JsonArray existingSkins)
        {
            for (int i = 0; i < existingSkins.Count && i < skins.Length; i++)
            {
                try
                {
                    skins[i] = existingSkins[i]?.GetValue<int>() ?? 0;
                }
                catch
                {
                    skins[i] = 0;
                }
            }
        }

        foreach (int charId in charIds)
        {
            if (charId >= 0 && charId < skins.Length)
            {
                skins[charId] = GetDefaultSkinAssetId(charId);
            }
        }

        for (int charId = 0; charId < skins.Length; charId++)
        {
            if (skins[charId] <= 0)
            {
                skins[charId] = GetDefaultSkinAssetId(charId);
            }
        }

        loadout["skins"] = ToJsonArray(skins);
        if (!loadout.ContainsKey("bannerId"))
        {
            loadout["bannerId"] = 0;
        }

        root["loadout"] = loadout;
    }

    private static JsonArray ToJsonArray(IEnumerable<int> values)
    {
        var array = new JsonArray();
        foreach (int value in values)
        {
            array.Add(value);
        }

        return array;
    }

    private static int? TryGetInt(JsonObject obj, string key)
    {
        if (!obj.TryGetPropertyValue(key, out JsonNode? node) || node == null)
        {
            return null;
        }

        try
        {
            return node.GetValue<int>();
        }
        catch
        {
            return int.TryParse(node.ToString(), out int parsed) ? parsed : null;
        }
    }

    private static void UpsertMax(IDictionary<int, int> balances, int assetId, int balance)
    {
        balances[assetId] = balances.TryGetValue(assetId, out int existing)
            ? Math.Max(existing, balance)
            : balance;
    }

    private static int GetDefaultSkinAssetId(int charId)
    {
        int[] defaultSkins =
        {
            300018,
            300000,
            300007,
            300020,
            300017,
            300026,
            300021,
            300013,
            300025,
            300023,
            300015,
            300003,
            300005,
            300016,
            300019,
            300018
        };

        return charId >= 0 && charId < defaultSkins.Length ? defaultSkins[charId] : defaultSkins[0];
    }

    // F154 — inject the player's identity headers on a proxied HTTP request so the custom server
    // can attribute the request. No-op when accountId is blank; existing copies are removed first
    // so a relayed request never carries a stale identity. UserId mirrors AccountId.
    public static void ApplyIdentityHeaders(HttpRequestMessage request, string accountId, string username, string discriminator)
    {
        if (string.IsNullOrWhiteSpace(accountId))
        {
            return;
        }

        request.Headers.Remove("X-BAP-AccountId");
        request.Headers.Remove("X-BAP-UserId");
        request.Headers.Remove("X-BAP-Username");
        request.Headers.Remove("X-BAP-Discriminator");

        request.Headers.TryAddWithoutValidation("X-BAP-AccountId", accountId);
        request.Headers.TryAddWithoutValidation("X-BAP-UserId", accountId);
        if (!string.IsNullOrWhiteSpace(username))
        {
            request.Headers.TryAddWithoutValidation("X-BAP-Username", username);
        }

        if (!string.IsNullOrWhiteSpace(discriminator))
        {
            request.Headers.TryAddWithoutValidation("X-BAP-Discriminator", discriminator);
        }
    }

    // F167 — compose the server-policy fetch URL (/api/server-config) from the client's routing
    // config. In proxy mode the client always hits the loopback proxy; in direct mode it builds
    // scheme://host:port from the configured upstream. A wrong URL silently disables matchmaking
    // gating, so the composition is pinned by tests.
    public static string BuildServerPolicyUrl(bool useLocalProxy, int localPort, string host, int upstreamPort, bool useHttps)
    {
        if (useLocalProxy)
        {
            return $"http://127.0.0.1:{localPort}/api/server-config";
        }

        string resolvedHost = string.IsNullOrWhiteSpace(host) ? "127.0.0.1" : host;
        string scheme = useHttps ? "https" : "http";
        return $"{scheme}://{resolvedHost}:{upstreamPort}/api/server-config";
    }

    // F149 — normalize a configured host value: strip any scheme prefix down to the bare host, and
    // fall back to loopback when blank. A wrong host means the ApiHost-patched game connects nowhere.
    public static string NormalizeHost(string? host)
    {
        host = (host ?? "").Trim();

        if (host.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
            host.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
        {
            if (Uri.TryCreate(host, UriKind.Absolute, out Uri? parsed))
            {
                return parsed.Host;
            }
        }

        return string.IsNullOrWhiteSpace(host) ? "127.0.0.1" : host;
    }

    public static bool IsLoopbackHost(string host)
    {
        return string.Equals(host, "localhost", StringComparison.OrdinalIgnoreCase) ||
               string.Equals(host, "127.0.0.1", StringComparison.OrdinalIgnoreCase) ||
               string.Equals(host, "::1", StringComparison.OrdinalIgnoreCase);
    }

    // F126 — decide whether a UnityWebRequest URL should be rewritten to the configured API host.
    // Pure guard extracted from RewriteUnityWebRequestCallbackUrl so the loopback/callback decision is
    // testable without Unity. Returns true only for an absolute loopback URL on a known local API port
    // (default proxy/server port or the configured server/local ports) that is EITHER a /api/internal
    // callback OR any loopback URL while the local proxy is disabled (direct mode). On true it yields
    // isCallback (callback vs direct-mode loopback, for logging) and pathAndQuery (to compose the new
    // URL). The actual apiHost fetch + URL swap stays in production so its lazy/side-effecting behavior
    // is unchanged.
    public static bool ShouldRewriteCallbackUrl(
        string? url,
        int defaultProxyPort,
        int defaultServerPort,
        int serverPort,
        int localPort,
        bool localProxyEnabled,
        out bool isCallback,
        out string pathAndQuery)
    {
        isCallback = false;
        pathAndQuery = "";

        if (url is null ||
            !Uri.TryCreate(url, UriKind.Absolute, out Uri? uri) ||
            !IsLoopbackHost(uri.Host))
        {
            return false;
        }

        bool knownLocalApiPort =
            uri.Port == defaultProxyPort ||
            uri.Port == defaultServerPort ||
            uri.Port == serverPort ||
            uri.Port == localPort;
        if (!knownLocalApiPort)
        {
            return false;
        }

        isCallback = uri.AbsolutePath.StartsWith("/api/internal", StringComparison.OrdinalIgnoreCase);
        bool proxyDisabled = !localProxyEnabled;
        if (!isCallback && !proxyDisabled)
        {
            return false;
        }

        pathAndQuery = uri.PathAndQuery;
        return true;
    }

    // F149 — resolve the API host the game's NetworkConfig is patched to. In proxy mode the game
    // talks to the loopback proxy; in direct mode it talks to scheme://host:port of the upstream.
    public static string ResolveConfiguredApiHost(bool useLocalProxy, int localPort, string host, int upstreamPort, bool useHttps)
    {
        if (useLocalProxy)
        {
            return $"http://127.0.0.1:{localPort}";
        }

        string scheme = useHttps ? Uri.UriSchemeHttps : Uri.UriSchemeHttp;
        return new UriBuilder(scheme, NormalizeHost(host), upstreamPort).Uri.ToString().TrimEnd('/');
    }
}

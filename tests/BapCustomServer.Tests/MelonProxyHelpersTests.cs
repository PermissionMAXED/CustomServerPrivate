using BapCustomServerMelon;
using System.Net.Http;
using Xunit;

namespace BapCustomServer.Tests;

// F155 socket-discovery response rewriting, F168 Medusa auto-select WebSocket rewrite.
// Pure (Unity-free) logic from the Melon mod's LocalReverseProxy, linked into this net10 test
// project via MelonProxyHelpers.cs. The full mod targets net6/x86 with Unity refs and can't run
// here, but these string/JSON transforms are the testable kernel of those two features.
public class MelonProxyHelpersTests
{
    // ---- F155 ----
    [Fact]
    public void RewriteSocketDiscovery_ReplacesSocketUrl_ToLocalPort()
    {
        string body = "{\"socketUrl\":\"wss://official.bapbap.gg/ws\",\"region\":\"eu\"}";
        string result = MelonProxyHelpers.RewriteSocketDiscovery(body, 5055);
        Assert.Contains("ws://127.0.0.1:5055/ws", result);
        Assert.DoesNotContain("official.bapbap.gg", result);
        Assert.Contains("\"region\":\"eu\"", result); // unrelated fields preserved
    }

    [Fact]
    public void RewriteSocketDiscovery_HandlesSnakeCaseKey()
    {
        string body = "{\"socket_url\":\"wss://official/ws\"}";
        Assert.Contains("ws://127.0.0.1:5055/ws", MelonProxyHelpers.RewriteSocketDiscovery(body, 5055));
    }

    [Fact]
    public void RewriteSocketDiscovery_HonorsListenPort()
    {
        string body = "{\"socketUrl\":\"wss://x/ws\"}";
        Assert.Contains("ws://127.0.0.1:9090/ws", MelonProxyHelpers.RewriteSocketDiscovery(body, 9090));
    }

    [Fact]
    public void RewriteSocketDiscovery_MinifiedNonObject_FallsBackToRegex()
    {
        // A non-JSON-object body still gets the narrow regex replacement.
        string body = "garbage-prefix \"socketUrl\":\"wss://x/ws\" garbage-suffix";
        string result = MelonProxyHelpers.RewriteSocketDiscovery(body, 5055);
        Assert.Contains("\"socketUrl\":\"ws://127.0.0.1:5055/ws\"", result);
    }

    [Fact]
    public void RewriteSocketDiscovery_NoSocketKey_Unchanged()
    {
        string body = "{\"foo\":\"bar\"}";
        // round-trips through JsonNode but has no socket key, so the URL is absent either way
        Assert.DoesNotContain("127.0.0.1", MelonProxyHelpers.RewriteSocketDiscovery(body, 5055));
    }

    // ---- F168 ----
    [Fact]
    public void TryRewriteMedusaCharId_JoinLobby_ForcesCharId15()
    {
        string frame = "{\"event\":\"JOIN_LOBBY\",\"payload\":{\"lobbyId\":\"ABC\",\"charId\":3}}";
        bool changed = MelonProxyHelpers.TryRewriteMedusaCharId(frame, out string rewritten, out int oldCharId);
        Assert.True(changed);
        Assert.Equal(3, oldCharId);
        Assert.Contains("\"charId\":15", rewritten);
        Assert.Contains("\"lobbyId\":\"ABC\"", rewritten); // other payload fields preserved
    }

    [Fact]
    public void TryRewriteMedusaCharId_SwitchChar_ForcesCharId15()
    {
        string frame = "{\"event\":\"SWITCH_CHAR\",\"payload\":{\"charId\":7}}";
        Assert.True(MelonProxyHelpers.TryRewriteMedusaCharId(frame, out string rewritten, out _));
        Assert.Contains("\"charId\":15", rewritten);
    }

    [Fact]
    public void TryRewriteMedusaCharId_AlreadyMedusa_NoChange()
    {
        string frame = "{\"event\":\"JOIN_LOBBY\",\"payload\":{\"charId\":15}}";
        Assert.False(MelonProxyHelpers.TryRewriteMedusaCharId(frame, out _, out int oldCharId));
        Assert.Equal(15, oldCharId);
    }

    [Fact]
    public void TryRewriteMedusaCharId_UnrelatedEvent_NoChange()
    {
        string frame = "{\"event\":\"UPDATE_CUSTOM_SETTINGS\",\"payload\":{\"charId\":3}}";
        Assert.False(MelonProxyHelpers.TryRewriteMedusaCharId(frame, out _, out _));
    }

    [Fact]
    public void TryRewriteMedusaCharId_NonLobbyFrame_NoChange()
    {
        Assert.False(MelonProxyHelpers.TryRewriteMedusaCharId("{\"event\":\"PING\"}", out _, out _));
        Assert.False(MelonProxyHelpers.TryRewriteMedusaCharId("not json", out _, out _));
    }

    // ---- F154 ----
    [Fact]
    public void ApplyIdentityHeaders_InjectsAccountAndUser()
    {
        using var req = new HttpRequestMessage(HttpMethod.Get, "http://x/api/load");
        MelonProxyHelpers.ApplyIdentityHeaders(req, "custom-5", "Alice", "1234");
        Assert.Equal("custom-5", req.Headers.GetValues("X-BAP-AccountId").Single());
        Assert.Equal("custom-5", req.Headers.GetValues("X-BAP-UserId").Single()); // UserId mirrors AccountId
        Assert.Equal("Alice", req.Headers.GetValues("X-BAP-Username").Single());
        Assert.Equal("1234", req.Headers.GetValues("X-BAP-Discriminator").Single());
    }

    [Fact]
    public void ApplyIdentityHeaders_BlankAccount_NoHeaders()
    {
        using var req = new HttpRequestMessage(HttpMethod.Get, "http://x/");
        MelonProxyHelpers.ApplyIdentityHeaders(req, "", "Alice", "1234");
        Assert.False(req.Headers.Contains("X-BAP-AccountId")); // no-op when accountId blank
    }

    [Fact]
    public void ApplyIdentityHeaders_OptionalFieldsOmittedWhenBlank()
    {
        using var req = new HttpRequestMessage(HttpMethod.Get, "http://x/");
        MelonProxyHelpers.ApplyIdentityHeaders(req, "custom-5", "", "");
        Assert.True(req.Headers.Contains("X-BAP-AccountId"));
        Assert.False(req.Headers.Contains("X-BAP-Username"));      // blank username omitted
        Assert.False(req.Headers.Contains("X-BAP-Discriminator")); // blank discriminator omitted
    }

    [Fact]
    public void ApplyIdentityHeaders_RemovesStaleCopiesFirst()
    {
        using var req = new HttpRequestMessage(HttpMethod.Get, "http://x/");
        req.Headers.TryAddWithoutValidation("X-BAP-AccountId", "stale-old");
        MelonProxyHelpers.ApplyIdentityHeaders(req, "custom-5", "Alice", "1234");
        Assert.Equal("custom-5", req.Headers.GetValues("X-BAP-AccountId").Single()); // not duplicated
    }

    // ---- F167 ----
    [Fact]
    public void BuildServerPolicyUrl_ProxyMode_AlwaysLoopback()
    {
        // In proxy mode the client always hits the loopback proxy at its local port, regardless of host/https.
        string url = MelonProxyHelpers.BuildServerPolicyUrl(useLocalProxy: true, localPort: 5055, host: "ignored.example.com", upstreamPort: 9999, useHttps: true);
        Assert.Equal("http://127.0.0.1:5055/api/server-config", url);
    }

    [Fact]
    public void BuildServerPolicyUrl_DirectMode_BuildsFromUpstream()
    {
        string url = MelonProxyHelpers.BuildServerPolicyUrl(useLocalProxy: false, localPort: 5055, host: "my.server.gg", upstreamPort: 5198, useHttps: false);
        Assert.Equal("http://my.server.gg:5198/api/server-config", url);
    }

    [Fact]
    public void BuildServerPolicyUrl_DirectMode_HttpsScheme()
    {
        string url = MelonProxyHelpers.BuildServerPolicyUrl(useLocalProxy: false, localPort: 5055, host: "my.server.gg", upstreamPort: 443, useHttps: true);
        Assert.Equal("https://my.server.gg:443/api/server-config", url);
    }

    [Fact]
    public void BuildServerPolicyUrl_DirectMode_BlankHostFallsBackToLoopback()
    {
        string url = MelonProxyHelpers.BuildServerPolicyUrl(useLocalProxy: false, localPort: 5055, host: "", upstreamPort: 5198, useHttps: false);
        Assert.Equal("http://127.0.0.1:5198/api/server-config", url);
    }

    // ---- F149 ----
    [Theory] // F149 — a configured host with a scheme prefix is stripped to the bare host
    [InlineData("http://my.server.gg", "my.server.gg")]
    [InlineData("https://my.server.gg/", "my.server.gg")]
    [InlineData("my.server.gg", "my.server.gg")]
    [InlineData("  127.0.0.1  ", "127.0.0.1")]
    public void NormalizeHost_StripsSchemePrefix(string input, string expected)
    {
        Assert.Equal(expected, MelonProxyHelpers.NormalizeHost(input));
    }

    [Fact] // F149 — blank/null host falls back to loopback (game must connect somewhere)
    public void NormalizeHost_BlankFallsBackToLoopback()
    {
        Assert.Equal("127.0.0.1", MelonProxyHelpers.NormalizeHost(""));
        Assert.Equal("127.0.0.1", MelonProxyHelpers.NormalizeHost(null));
    }

    [Theory] // F149 — loopback detection
    [InlineData("localhost", true)]
    [InlineData("127.0.0.1", true)]
    [InlineData("::1", true)]
    [InlineData("my.server.gg", false)]
    public void IsLoopbackHost_DetectsLoopback(string host, bool expected)
    {
        Assert.Equal(expected, MelonProxyHelpers.IsLoopbackHost(host));
    }

    [Fact] // F149 — proxy mode patches ApiHost to the loopback proxy regardless of upstream host
    public void ResolveConfiguredApiHost_ProxyMode_Loopback()
    {
        string host = MelonProxyHelpers.ResolveConfiguredApiHost(useLocalProxy: true, localPort: 5055, host: "remote.gg", upstreamPort: 9999, useHttps: true);
        Assert.Equal("http://127.0.0.1:5055", host);
    }

    [Fact] // F149 — direct mode patches ApiHost to scheme://host:port of the upstream
    public void ResolveConfiguredApiHost_DirectMode_BuildsUpstream()
    {
        Assert.Equal("http://my.server.gg:5198", MelonProxyHelpers.ResolveConfiguredApiHost(false, 5055, "my.server.gg", 5198, false));
        // UriBuilder omits the scheme-default port (443 for https), matching the original behavior.
        Assert.Equal("https://my.server.gg", MelonProxyHelpers.ResolveConfiguredApiHost(false, 5055, "https://my.server.gg", 443, true));
        // A non-default https port survives.
        Assert.Equal("https://my.server.gg:8443", MelonProxyHelpers.ResolveConfiguredApiHost(false, 5055, "https://my.server.gg", 8443, true));
    }

    // ---- F126 ----
    [Fact] // F126 — a /api/internal callback on a known local port is rewritten (proxy enabled)
    public void ShouldRewriteCallbackUrl_InternalCallback_OnKnownPort_Rewrites()
    {
        bool should = MelonProxyHelpers.ShouldRewriteCallbackUrl(
            "http://127.0.0.1:5055/api/internal/game-ended",
            defaultProxyPort: 5055, defaultServerPort: 5055, serverPort: 5055, localPort: 5055,
            localProxyEnabled: true, out bool isCallback, out string pathAndQuery);
        Assert.True(should);
        Assert.True(isCallback);
        Assert.Equal("/api/internal/game-ended", pathAndQuery);
    }

    [Fact] // F126 — a non-internal loopback URL is rewritten ONLY when the proxy is disabled (direct mode)
    public void ShouldRewriteCallbackUrl_NonInternalLoopback_OnlyWhenProxyDisabled()
    {
        // proxy enabled => a non-/api/internal loopback URL is left alone (the proxy already handles it)
        Assert.False(MelonProxyHelpers.ShouldRewriteCallbackUrl(
            "http://127.0.0.1:5055/api/load",
            5055, 5055, 5055, 5055, localProxyEnabled: true, out _, out _));

        // proxy disabled (direct mode) => the same URL must be rewritten to the upstream host
        bool should = MelonProxyHelpers.ShouldRewriteCallbackUrl(
            "http://127.0.0.1:5055/api/load",
            5055, 5055, 5055, 5055, localProxyEnabled: false, out bool isCallback, out string pathAndQuery);
        Assert.True(should);
        Assert.False(isCallback);
        Assert.Equal("/api/load", pathAndQuery);
    }

    [Fact] // F126 — non-loopback host, unknown port, and non-absolute/null URLs are never rewritten
    public void ShouldRewriteCallbackUrl_IgnoresNonLoopbackUnknownPortAndBadUrls()
    {
        // remote host
        Assert.False(MelonProxyHelpers.ShouldRewriteCallbackUrl(
            "http://example.com:5055/api/internal/x", 5055, 5055, 5055, 5055, true, out _, out _));
        // loopback but a port that is not one of the four known local API ports
        Assert.False(MelonProxyHelpers.ShouldRewriteCallbackUrl(
            "http://127.0.0.1:6000/api/internal/x", 5055, 5055, 5055, 5055, true, out _, out _));
        // null + relative URLs
        Assert.False(MelonProxyHelpers.ShouldRewriteCallbackUrl(
            null, 5055, 5055, 5055, 5055, true, out _, out _));
        Assert.False(MelonProxyHelpers.ShouldRewriteCallbackUrl(
            "/api/internal/x", 5055, 5055, 5055, 5055, true, out _, out _));
    }

    [Fact] // F126 — the configured server/local ports (not just the 5055 defaults) also count as known
    public void ShouldRewriteCallbackUrl_HonorsConfiguredPorts()
    {
        bool should = MelonProxyHelpers.ShouldRewriteCallbackUrl(
            "http://127.0.0.1:5163/api/internal/game-ping",
            defaultProxyPort: 5055, defaultServerPort: 5055, serverPort: 5163, localPort: 5055,
            localProxyEnabled: true, out bool isCallback, out _);
        Assert.True(should);
        Assert.True(isCallback);
    }

    [Fact]
    public void ExtractJsonIntArray_ParsesAndNormalizesServerConfigCharacters()
    {
        string body = "{\"matchmakingPolicy\":\"Both\",\"availableCharacters\":[15,0,15,\"2\",-1,99]}";

        int[] parsed = MelonProxyHelpers.ExtractJsonIntArray(body, "availableCharacters");
        int[] normalized = MelonProxyHelpers.NormalizeCharacterIds(parsed, maxCharacterId: 15);

        Assert.Equal(new[] { 0, 2, 15 }, normalized);
    }

    [Fact]
    public void HasKnownCustomCharacterRuntime_DetectsNetworkedCustomCharAndLegacyDlls()
    {
        string dir = Path.Combine(Path.GetTempPath(), "bapcustom-runtime-detect", Guid.NewGuid().ToString("N"));
        string mods = Path.Combine(dir, "Mods");
        Directory.CreateDirectory(mods);
        try
        {
            Assert.False(MelonProxyHelpers.HasKnownCustomCharacterRuntime(dir));

            File.WriteAllText(Path.Combine(mods, "NetworkedCustomChar.dll"), "stub");
            Assert.True(MelonProxyHelpers.HasKnownCustomCharacterRuntime(dir));

            File.Delete(Path.Combine(mods, "NetworkedCustomChar.dll"));
            File.WriteAllText(Path.Combine(mods, "BAPCustomChars.dll"), "stub");
            Assert.True(MelonProxyHelpers.HasKnownCustomCharacterRuntime(dir));
        }
        finally
        {
            try { Directory.Delete(dir, recursive: true); } catch { }
        }
    }

    [Fact]
    public void RewriteCharListingResponse_ForcesPurchasesAndClearsCosts()
    {
        string body = "{\"charListings\":[{\"listingId\":\"custom-char-15\",\"charId\":15,\"purchases\":0,\"costs\":[{\"assetId\":2,\"amount\":1}],\"rewards\":[{\"assetId\":100015,\"amount\":1}]}],\"other\":true}";

        string rewritten = MelonProxyHelpers.RewriteCharListingResponse(body);

        using var doc = System.Text.Json.JsonDocument.Parse(rewritten);
        var listing = doc.RootElement.GetProperty("charListings")[0];
        Assert.Equal(1, listing.GetProperty("purchases").GetInt32());
        Assert.Empty(listing.GetProperty("costs").EnumerateArray());
        Assert.Equal(15, listing.GetProperty("charId").GetInt32());
        Assert.True(doc.RootElement.GetProperty("other").GetBoolean());
    }

    [Fact]
    public void RewriteLoadResponse_StabilizesCharacterOwnershipAndPreservesSafeAssets()
    {
        string body = "{" +
            "\"accountId\":\"custom-test\"," +
            "\"username\":\"Test\"," +
            "\"isCompleted\":false," +
            "\"assets\":[" +
                "{\"assetId\":2,\"balance\":0}," +
                "{\"assetId\":100015,\"balance\":1}," +
                "{\"assetId\":300001,\"balance\":1}," +
                "{\"assetId\":500999,\"balance\":1}" +
            "]," +
            "\"loadout\":{\"bannerId\":0,\"skins\":[]}," +
            "\"availableCharacters\":[0,1,2,15]" +
        "}";

        string rewritten = MelonProxyHelpers.RewriteLoadResponse(body);

        using var doc = System.Text.Json.JsonDocument.Parse(rewritten);
        Assert.True(doc.RootElement.GetProperty("isCompleted").GetBoolean());
        int[] availableCharacters = doc.RootElement.GetProperty("availableCharacters").EnumerateArray().Select(e => e.GetInt32()).ToArray();
        Assert.Equal(new[] { 0, 1, 2, 15 }, availableCharacters);

        var assets = doc.RootElement.GetProperty("assets").EnumerateArray().ToArray();
        Assert.Contains(assets, e => e.GetProperty("assetId").GetInt32() == 2 && e.GetProperty("balance").GetInt32() == 1);
        Assert.Contains(assets, e => e.GetProperty("assetId").GetInt32() == 100015);
        Assert.Contains(assets, e => e.GetProperty("assetId").GetInt32() == 300018);
        Assert.DoesNotContain(assets, e => e.GetProperty("assetId").GetInt32() == 300001);
        Assert.Contains(assets, e => e.GetProperty("assetId").GetInt32() == 500999);

        int[] skins = doc.RootElement.GetProperty("loadout").GetProperty("skins").EnumerateArray().Select(e => e.GetInt32()).ToArray();
        Assert.True(skins.Length > 15);
        Assert.True(skins[15] > 0);
    }
}

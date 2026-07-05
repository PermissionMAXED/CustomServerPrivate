using System.Net;
using System.Net.Http.Json;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace BapCustomServer.Tests;

// F051-F072 endpoint coverage. The previous test layer only exercised services directly; nothing
// drove Program.cs's minimal-API routes over real HTTP. This boots the WHOLE app in-process via
// WebApplicationFactory<Program> with LaunchGameServers=false (no bapbap.exe ever spawns) and
// every persisted-state file redirected into a throwaway temp dir, so the metagame/auth/queue
// routes are tested end-to-end through Kestrel's pipeline.
[Collection("HttpIntegration")] // serialize: the factory boots a full host with hosted services
public sealed class EndpointIntegrationTests : IClassFixture<EndpointIntegrationTests.AppFactory>
{
    private readonly AppFactory _factory;

    public EndpointIntegrationTests(AppFactory factory) => _factory = factory;

    public sealed class AppFactory : WebApplicationFactory<ApiEntryPoint>
    {
        public const string AdminToken = "test-admin-token";
        public const string BannedAccountId = "wsbanned";
        public readonly string DataDir = Path.Combine(Path.GetTempPath(), "bapcustom-http", Guid.NewGuid().ToString("N"));

        protected override IHost CreateHost(IHostBuilder builder)
        {
            Directory.CreateDirectory(DataDir);
            // Neutral (empty-defaults) player-overrides doc, so PlayerOverridesService doesn't
            // regenerate its unlockEverything:true default and defeat the UnlockAllCharacters=false
            // setups below. See Svc.WriteNeutralPlayerOverrides.
            Svc.WriteNeutralPlayerOverrides(DataDir);
            // Override config BEFORE the app's WebApplication.CreateBuilder binds CustomServerOptions.
            // CustomServer__* env-var style maps onto the CustomServer config section.
            builder.UseEnvironment("Testing");
            builder.ConfigureHostConfiguration(cfg =>
            {
                var settings = Svc.StateFileRedirects(DataDir);
                settings["CustomServer:LaunchGameServers"] = "false";
                settings["CustomServer:GameServerPrewarmOnStartup"] = "false";
                settings["CustomServer:Admin:ApiToken"] = AdminToken;
                settings["CustomServer:Admin:BannedAccountIds:0"] = BannedAccountId;
                cfg.AddInMemoryCollection(settings);
            });
            return base.CreateHost(builder);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            try { if (Directory.Exists(DataDir)) Directory.Delete(DataDir, recursive: true); } catch { }
        }
    }

    private static async Task<JsonElement> ReadJson(HttpResponseMessage resp)
    {
        string body = await resp.Content.ReadAsStringAsync();
        return JsonDocument.Parse(body).RootElement;
    }

    [Fact] // F051 health endpoint returns ok + runtime/queue diagnostics
    public async Task Health_ReturnsOk_WithDiagnostics()
    {
        var client = _factory.CreateClient();

        var resp = await client.GetAsync("/health");

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        var json = await ReadJson(resp);
        Assert.True(json.GetProperty("ok").GetBoolean());
        Assert.True(json.TryGetProperty("runtime", out _));
        Assert.True(json.TryGetProperty("queue", out _));
    }

    [Fact] // F052/F053 metagame load returns a JSON profile (stub satisfies the client bootstrap)
    public async Task ApiLoad_ReturnsProfileJson()
    {
        var client = _factory.CreateClient();

        var resp = await client.GetAsync("/api/load");

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        var json = await ReadJson(resp);
        Assert.Equal(JsonValueKind.Object, json.ValueKind);
    }

    [Fact]
    public async Task ApiLoad_ContainsCharacterUnlockAssetsEvenWhenAllFlagsAreFalse()
    {
        var client = _factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureAppConfiguration((context, cfg) =>
            {
                cfg.AddInMemoryCollection(new Dictionary<string, string?>
                {
                    ["CustomServer:Unlocks:UnlockEverything"] = "false",
                    ["CustomServer:Unlocks:UnlockAllSkins"] = "false",
                    ["CustomServer:Unlocks:UnlockAllBanners"] = "false",
                    ["CustomServer:Unlocks:UnlockAllEmotes"] = "false",
                    ["CustomServer:Unlocks:UnlockAllMasteryBadges"] = "false",
                    ["CustomServer:Unlocks:UnlockAllTombstones"] = "false"
                });
            });
        }).CreateClient();

        var resp = await client.GetAsync("/api/load");

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        var json = await ReadJson(resp);

        Assert.True(json.TryGetProperty("assets", out var assetsProp));
        Assert.Equal(JsonValueKind.Array, assetsProp.ValueKind);

        var assetIds = new HashSet<int>();
        foreach (var element in assetsProp.EnumerateArray())
        {
            if (element.TryGetProperty("assetId", out var idProp) && idProp.ValueKind == JsonValueKind.Number)
            {
                assetIds.Add(idProp.GetInt32());
            }
        }

        // Assert that both the raw charId and 100000 + charId are present for all known characters
        // Kitsu (0) to Medusa (15)
        for (int charId = 0; charId <= 15; charId++)
        {
            Assert.Contains(charId, assetIds);
            Assert.Contains(100000 + charId, assetIds);
        }
    }

    [Fact]
    public async Task ApiLoad_AdvertisesAllPlayableCharactersIncludingMedusa()
    {
        var client = _factory.CreateClient();

        var json = await ReadJson(await client.GetAsync("/api/load"));

        int[] availableCharacters = json.GetProperty("availableCharacters").EnumerateArray().Select(e => e.GetInt32()).ToArray();
        for (int charId = 0; charId <= 15; charId++)
        {
            Assert.Contains(charId, availableCharacters);
        }

        int[] skins = json.GetProperty("loadout").GetProperty("skins").EnumerateArray().Select(e => e.GetInt32()).ToArray();
        Assert.True(skins.Length > 15);
        Assert.True(skins[15] > 0);
    }

    [Fact]
    public async Task ApiLoad_CharacterUnlockMarkersRemainTruthyAfterCurrencyBalances()
    {
        var client = _factory.CreateClient();

        var json = await ReadJson(await client.GetAsync("/api/load"));
        var assets = json.GetProperty("assets").EnumerateArray().ToArray();

        Assert.Contains(assets, e => e.GetProperty("assetId").GetInt32() == 2 && e.GetProperty("balance").GetInt32() >= 1);
        Assert.Contains(assets, e => e.GetProperty("assetId").GetInt32() == 100002 && e.GetProperty("balance").GetInt32() >= 1);
    }

    [Fact]
    public async Task ServerConfig_AdvertisesEffectiveRosterForNormalPlayer()
    {
        var client = _factory.CreateClient();

        var json = await ReadJson(await client.GetAsync("/api/server-config"));

        int[] availableCharacters = json.GetProperty("availableCharacters").EnumerateArray().Select(e => e.GetInt32()).ToArray();
        Assert.NotEmpty(availableCharacters);
        Assert.Contains(15, availableCharacters);
        Assert.True(json.GetProperty("medusa").GetProperty("available").GetBoolean());
    }

    [Fact]
    public async Task CharacterListing_DefaultUnlockAllCharactersMarksRosterOwned()
    {
        var client = _factory.CreateClient();

        var json = await ReadJson(await client.GetAsync("/api/chars/listing"));
        var listings = json.GetProperty("charListings").EnumerateArray().ToArray();

        Assert.Contains(listings, e => e.GetProperty("charId").GetInt32() == 15);
        foreach (var listing in listings)
        {
            Assert.Equal(1, listing.GetProperty("purchases").GetInt32());
            Assert.Empty(listing.GetProperty("costs").EnumerateArray());
        }
    }

    [Fact] // F053 login alias resolves to the same load result
    public async Task ApiLogin_ReturnsProfileJson()
    {
        var client = _factory.CreateClient();

        var resp = await client.PostAsync("/api/login", new StringContent("{}", Encoding.UTF8, "application/json"));

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        var json = await ReadJson(resp);
        Assert.Equal(JsonValueKind.Object, json.ValueKind);
    }

    [Fact] // F060 shop listing renders without auth (private server: cosmetics owned)
    public async Task Shop_ReturnsListing()
    {
        var client = _factory.CreateClient();

        var resp = await client.GetAsync("/api/shop");

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        var json = await ReadJson(resp);
        Assert.Equal(JsonValueKind.Object, json.ValueKind);
    }

    [Fact]
    public async Task CharacterListing_ShowsConfiguredPriceForLockedCharacter()
    {
        var client = _factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureAppConfiguration((context, cfg) =>
            {
                cfg.AddInMemoryCollection(new Dictionary<string, string?>
                {
                    ["CustomServer:CharacterUnlocks:UnlockAllCharacters"] = "false",
                    ["CustomServer:CharacterUnlocks:StartingCharTokens"] = "3",
                    ["CustomServer:CharacterUnlocks:DefaultPrice"] = "2",
                    ["CustomServer:CharacterUnlocks:InitiallyUnlockedCharacterIds:0"] = "0",
                    ["CustomServer:CharacterUnlocks:PricesCsv"] = "15:2"
                });
            });
        }).CreateClient();
        using var req = new HttpRequestMessage(HttpMethod.Get, "/api/chars/listing");
        req.Headers.Add("X-BAP-AccountId", "char-listing-test");
        req.Headers.Add("X-BAP-Username", "CharListingTest");

        var resp = await client.SendAsync(req);

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        var json = await ReadJson(resp);
        var medusa = json.GetProperty("charListings").EnumerateArray().Single(e => e.GetProperty("charId").GetInt32() == 15);
        Assert.Equal(0, medusa.GetProperty("purchases").GetInt32());
        Assert.Equal(2, medusa.GetProperty("costs")[0].GetProperty("assetId").GetInt32());
        Assert.Equal(2, medusa.GetProperty("costs")[0].GetProperty("amount").GetInt32());
    }

    [Fact]
    public async Task CharacterPurchase_DebitsTokensAndLoadShowsUnlockAsset()
    {
        var client = _factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureAppConfiguration((context, cfg) =>
            {
                cfg.AddInMemoryCollection(new Dictionary<string, string?>
                {
                    ["CustomServer:CharacterUnlocks:UnlockAllCharacters"] = "false",
                    ["CustomServer:CharacterUnlocks:StartingCharTokens"] = "3",
                    ["CustomServer:CharacterUnlocks:DefaultPrice"] = "2",
                    ["CustomServer:CharacterUnlocks:InitiallyUnlockedCharacterIds:0"] = "0",
                    ["CustomServer:CharacterUnlocks:PricesCsv"] = "15:2"
                });
            });
        }).CreateClient();
        const string accountId = "char-purchase-test";

        using var buy = new HttpRequestMessage(HttpMethod.Post, "/api/chars/listing/purchase")
        {
            Content = new StringContent("{\"listingId\":\"custom-char-15\",\"costIndex\":0}", Encoding.UTF8, "application/json")
        };
        buy.Headers.Add("X-BAP-AccountId", accountId);
        buy.Headers.Add("X-BAP-Username", "CharPurchaseTest");
        var buyResp = await client.SendAsync(buy);

        Assert.Equal(HttpStatusCode.OK, buyResp.StatusCode);
        var buyJson = await ReadJson(buyResp);
        Assert.True(buyJson.GetProperty("ok").GetBoolean());
        Assert.Equal(1, buyJson.GetProperty("purchases").GetInt32());
        Assert.Equal(1, buyJson.GetProperty("cost").GetProperty("balance").GetInt32());

        using var load = new HttpRequestMessage(HttpMethod.Get, "/api/load");
        load.Headers.Add("X-BAP-AccountId", accountId);
        load.Headers.Add("X-BAP-Username", "CharPurchaseTest");
        var loadJson = await ReadJson(await client.SendAsync(load));
        var assets = loadJson.GetProperty("assets").EnumerateArray().ToArray();
        Assert.Contains(assets, e => e.GetProperty("assetId").GetInt32() == 100015);
        Assert.Contains(assets, e => e.GetProperty("assetId").GetInt32() == 15);
        Assert.Contains(assets, e => e.GetProperty("assetId").GetInt32() == 2 && e.GetProperty("balance").GetInt32() == 1);
    }

    [Fact] // F065 queue status reports an empty, inactive queue at rest
    public async Task QueueStatus_ReportsEmptyAtRest()
    {
        var client = _factory.CreateClient();

        var resp = await client.GetAsync("/api/queue/status");

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        var json = await ReadJson(resp);
        Assert.Equal(0, json.GetProperty("playerCount").GetInt32());
    }

    [Fact] // F066 join then status reflects the joined player; leave clears it
    public async Task QueueJoinLeave_RoundTrips()
    {
        var client = _factory.CreateClient();

        var join = await client.PostAsync("/api/queue/join", new StringContent("{\"charId\":1}", Encoding.UTF8, "application/json"));
        Assert.Equal(HttpStatusCode.OK, join.StatusCode);
        var joinJson = await ReadJson(join);
        Assert.True(joinJson.GetProperty("ok").GetBoolean());

        var status = await ReadJson(await client.GetAsync("/api/queue/status"));
        Assert.Equal(1, status.GetProperty("playerCount").GetInt32());

        var leave = await client.PostAsync("/api/queue/leave", new StringContent("{}", Encoding.UTF8, "application/json"));
        Assert.Equal(HttpStatusCode.OK, leave.StatusCode);

        var after = await ReadJson(await client.GetAsync("/api/queue/status"));
        Assert.Equal(0, after.GetProperty("playerCount").GetInt32());
    }

    [Fact] // F067 join with an unknown character id is rejected (catalog gate)
    public async Task QueueJoin_UnknownCharId_Rejected()
    {
        var client = _factory.CreateClient();

        var resp = await client.PostAsync("/api/queue/join", new StringContent("{\"charId\":99999}", Encoding.UTF8, "application/json"));

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        var json = await ReadJson(resp);
        Assert.False(json.GetProperty("ok").GetBoolean());
    }

    [Fact] // F070 match history starts empty and returns a matches array
    public async Task MatchHistory_ReturnsArray()
    {
        var client = _factory.CreateClient();

        var resp = await client.GetAsync("/api/matches/history");

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        var json = await ReadJson(resp);
        Assert.Equal(JsonValueKind.Array, json.GetProperty("matches").ValueKind);
    }

    [Fact] // F071 unknown match id returns 404
    public async Task MatchHistory_UnknownId_Returns404()
    {
        var client = _factory.CreateClient();

        var resp = await client.GetAsync("/api/matches/history/does-not-exist");

        Assert.Equal(HttpStatusCode.NotFound, resp.StatusCode);
    }

    [Fact] // F065 server-config exposes matchmaking policy flags + Medusa roster state
    public async Task ServerConfig_ReturnsPolicyFlags()
    {
        var client = _factory.CreateClient();

        var resp = await client.GetAsync("/api/server-config");

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        var json = await ReadJson(resp);
        Assert.True(json.TryGetProperty("matchmakingPolicy", out _));
        Assert.True(json.TryGetProperty("allowMatchmaking", out _));
        Assert.True(json.TryGetProperty("allowCustomMatch", out _));
        Assert.True(json.TryGetProperty("medusa", out _));
    }

    [Fact] // F065 root banner returns service name + ws url + lobby snapshots
    public async Task Root_ReturnsServiceBanner()
    {
        var client = _factory.CreateClient();

        var resp = await client.GetAsync("/");

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        var json = await ReadJson(resp);
        Assert.Equal("BAPBAP custom match server", json.GetProperty("service").GetString());
        Assert.False(json.GetProperty("launchGameServers").GetBoolean()); // harness disabled game launch
        Assert.Equal(JsonValueKind.Array, json.GetProperty("lobbies").ValueKind);
    }

    [Fact] // F062 ranked leaderboard renders over HTTP
    public async Task RankedLeaderboard_ReturnsJson()
    {
        var client = _factory.CreateClient();

        var resp = await client.GetAsync("/api/ranked/leaderboard");

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        var json = await ReadJson(resp);
        Assert.Equal(JsonValueKind.Object, json.ValueKind);
    }

    [Fact] // F068 admin bots config without a token is rejected (auth gate)
    public async Task AdminBots_NoToken_Unauthorized()
    {
        var client = _factory.CreateClient();

        var resp = await client.GetAsync("/api/admin/bots");

        Assert.Equal(HttpStatusCode.Unauthorized, resp.StatusCode);
    }

    [Fact] // F068 admin bots config WITH the configured token succeeds
    public async Task AdminBots_WithToken_ReturnsConfig()
    {
        var client = _factory.CreateClient();
        var req = new HttpRequestMessage(HttpMethod.Get, "/api/admin/bots");
        req.Headers.Add(AdminAuth.TokenHeader, AppFactory.AdminToken);

        var resp = await client.SendAsync(req);

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        var json = await ReadJson(resp);
        Assert.True(json.TryGetProperty("customMatch", out _));
        Assert.True(json.TryGetProperty("matchmakingQueue", out _));
    }

    [Fact] // F068 admin modifiers config WITH the configured token succeeds
    public async Task AdminModifiers_WithToken_ReturnsConfig()
    {
        var client = _factory.CreateClient();
        var req = new HttpRequestMessage(HttpMethod.Get, "/api/admin/modifiers");
        req.Headers.Add(AdminAuth.TokenHeader, AppFactory.AdminToken);

        var resp = await client.SendAsync(req);

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        var json = await ReadJson(resp);
        Assert.Equal(JsonValueKind.Object, json.ValueKind);
    }

    [Fact] // F067 admin state view without a token is rejected
    public async Task AdminState_NoToken_Unauthorized()
    {
        var client = _factory.CreateClient();

        var resp = await client.GetAsync("/admin/state");

        Assert.Equal(HttpStatusCode.Unauthorized, resp.StatusCode);
    }

    [Fact] // F067 admin state/audit/lobbies/matches views WITH the token render
    public async Task AdminReadOnlyViews_WithToken_Render()
    {
        var client = _factory.CreateClient();
        foreach (var route in new[] { "/admin/state", "/admin/logs/audit", "/admin/lobbies", "/admin/matches" })
        {
            var req = new HttpRequestMessage(HttpMethod.Get, route);
            req.Headers.Add(AdminAuth.TokenHeader, AppFactory.AdminToken);

            var resp = await client.SendAsync(req);

            Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
            var json = await ReadJson(resp);
            Assert.True(json.ValueKind is JsonValueKind.Object or JsonValueKind.Array, $"{route} returned {json.ValueKind}");
        }
    }

    [Fact] // F066 admin command bus rejects without a token
    public async Task AdminCommand_NoToken_Unauthorized()
    {
        var client = _factory.CreateClient();

        var resp = await client.PostAsync("/admin/commands", new StringContent("{\"command\":\"list-modifiers\"}", Encoding.UTF8, "application/json"));

        Assert.Equal(HttpStatusCode.Unauthorized, resp.StatusCode);
    }

    [Fact] // F066 admin command bus runs a read-only command WITH the token
    public async Task AdminCommand_ListModifiers_WithToken_Succeeds()
    {
        var client = _factory.CreateClient();
        var req = new HttpRequestMessage(HttpMethod.Post, "/admin/commands")
        {
            Content = new StringContent("{\"command\":\"list-modifiers\"}", Encoding.UTF8, "application/json")
        };
        req.Headers.Add(AdminAuth.TokenHeader, AppFactory.AdminToken);

        var resp = await client.SendAsync(req);

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        var json = await ReadJson(resp);
        Assert.Equal(JsonValueKind.Object, json.ValueKind);
    }

    [Fact] // F069 admin asset-index rejects without a token
    public async Task AssetIndex_NoToken_Unauthorized()
    {
        var client = _factory.CreateClient();

        var resp = await client.GetAsync("/api/admin/asset-index");

        Assert.Equal(HttpStatusCode.Unauthorized, resp.StatusCode);
    }

    [Fact] // F069 admin asset-index WITH the token returns 200 (content or not-found stub)
    public async Task AssetIndex_WithToken_Returns200()
    {
        var client = _factory.CreateClient();
        var req = new HttpRequestMessage(HttpMethod.Get, "/api/admin/asset-index");
        req.Headers.Add(AdminAuth.TokenHeader, AppFactory.AdminToken);

        var resp = await client.SendAsync(req);

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode); // not 401, not 404; fail-soft JSON stub when file absent
    }

    [Fact] // F070 diagnostics runtime rejects without a token
    public async Task DiagnosticsRuntime_NoToken_Unauthorized()
    {
        var client = _factory.CreateClient();

        var resp = await client.GetAsync("/api/diagnostics/runtime");

        Assert.Equal(HttpStatusCode.Unauthorized, resp.StatusCode);
    }

    [Fact] // F070 diagnostics runtime + server-log WITH the token render
    public async Task DiagnosticsViews_WithToken_Render()
    {
        var client = _factory.CreateClient();
        foreach (var route in new[] { "/api/diagnostics/runtime", "/api/diagnostics/server-log" })
        {
            var req = new HttpRequestMessage(HttpMethod.Get, route);
            req.Headers.Add(AdminAuth.TokenHeader, AppFactory.AdminToken);

            var resp = await client.SendAsync(req);

            Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
            var json = await ReadJson(resp);
            Assert.Equal(JsonValueKind.Object, json.ValueKind);
        }
    }

    [Fact] // F071 internal game-ended callback is rejected from a non-loopback caller (TestServer has no loopback peer)
    public async Task InternalGameEnded_NonLoopback_Unauthorized()
    {
        var client = _factory.CreateClient();

        var resp = await client.PostAsync("/api/internal/game-ended", new StringContent("{\"gameId\":\"x\"}", Encoding.UTF8, "application/json"));

        Assert.Equal(HttpStatusCode.Unauthorized, resp.StatusCode);
    }

    [Fact] // F072 internal economy no-ops succeed without auth (debug/admin-build code paths must not 404)
    public async Task InternalEconomyNoOps_ReturnOk()
    {
        var client = _factory.CreateClient();
        foreach (var route in new[] { "/api/internal/gold", "/api/internal/reset-metagame" })
        {
            var resp = await client.PostAsync(route, new StringContent("{}", Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
            var json = await ReadJson(resp);
            Assert.True(json.GetProperty("ok").GetBoolean(), $"{route} should return ok=true");
        }
    }

    [Fact] // F052 auth completion returns a trimmed identity payload + sets the sid cookie
    public async Task AuthComplete_ReturnsIdentityAndSetsCookie()
    {
        var client = _factory.CreateClient();

        var resp = await client.GetAsync("/api/complete");

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        var json = await ReadJson(resp);
        Assert.True(json.TryGetProperty("accountId", out _));
        Assert.True(json.TryGetProperty("isCompleted", out _));
        Assert.Contains("sid=bapcustom-", string.Join(";", resp.Headers.GetValues("Set-Cookie")));
    }

    [Fact] // F052 account-link stub echoes the provider path param
    public async Task AuthLink_EchoesProvider()
    {
        var client = _factory.CreateClient();

        var resp = await client.GetAsync("/api/link/steam");

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        var json = await ReadJson(resp);
        Assert.Equal("steam", json.GetProperty("provider").GetString());
    }

    [Fact] // F053 loadout equip (banner & skins) echoes back the load shape so the client treats it applied
    public async Task LoadoutEquip_ReturnsLoadShape()
    {
        var client = _factory.CreateClient();
        foreach (var route in new[] { "/api/loadout/banner", "/api/loadout/skins" })
        {
            var resp = await client.PostAsync(route, new StringContent("{}", Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
            var json = await ReadJson(resp);
            Assert.Equal(JsonValueKind.Object, json.ValueKind);
        }
    }

    [Fact] // F056 internal server discovery returns a servers array
    public async Task InternalServers_ReturnsServersArray()
    {
        var client = _factory.CreateClient();

        var resp = await client.GetAsync("/api/internal/servers");

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        var json = await ReadJson(resp);
        Assert.True(json.TryGetProperty("servers", out var servers));
        Assert.Equal(JsonValueKind.Array, servers.ValueKind);
    }

    [Fact] // F063 metagame bootstrap stubs return success JSON so the client doesn't stall on a 404
    public async Task MetagameStubs_ReturnJson()
    {
        var client = _factory.CreateClient();
        foreach (var route in new[] { "/api/profile", "/api/daily", "/api/iap/listing", "/api/challenge/preview" })
        {
            var resp = await client.GetAsync(route);

            Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
            var json = await ReadJson(resp);
            Assert.Equal(JsonValueKind.Object, json.ValueKind);
        }
    }

    [Fact] // F064 community challenge & code stubs: creator-code empty, redeem returns ok with a not-used message
    public async Task CodeStubs_ReturnExpected()
    {
        var client = _factory.CreateClient();

        var creator = await ReadJson(await client.GetAsync("/api/code/creator-code"));
        Assert.Equal("", creator.GetProperty("creatorCode").GetString());

        var redeem = await client.PostAsync("/api/code/redeem", new StringContent("{}", Encoding.UTF8, "application/json"));
        Assert.Equal(HttpStatusCode.OK, redeem.StatusCode);
        var redeemJson = await ReadJson(redeem);
        Assert.True(redeemJson.GetProperty("ok").GetBoolean());
    }

    // ---- WebSocket lobby path (F001 handshake, ban-reject; F002 join) ----

    private static async Task<(string Event, JsonElement Payload)> ReceiveEnvelope(WebSocket socket, CancellationToken ct)
    {
        var buffer = new byte[16 * 1024];
        using var ms = new MemoryStream();
        WebSocketReceiveResult result;
        do
        {
            result = await socket.ReceiveAsync(buffer, ct);
            if (result.MessageType == WebSocketMessageType.Close) return ("__CLOSE__", default);
            ms.Write(buffer, 0, result.Count);
        } while (!result.EndOfMessage);

        var root = JsonDocument.Parse(ms.ToArray()).RootElement;
        string evt = root.GetProperty("event").GetString() ?? "";
        JsonElement payload = root.TryGetProperty("payload", out var p) ? p.Clone() : default;
        return (evt, payload);
    }

    private static async Task SendEnvelope(WebSocket socket, string evt, object? payload, CancellationToken ct)
    {
        string json = JsonSerializer.Serialize(new { @event = evt, payload });
        await socket.SendAsync(Encoding.UTF8.GetBytes(json), WebSocketMessageType.Text, true, ct);
    }

    private Uri WsUri() => new UriBuilder(_factory.Server.BaseAddress) { Scheme = "ws", Path = "/ws" }.Uri;

    // Reads envelopes until one matching `expected` arrives (the lobby broadcasts several events per
    // action, sometimes interleaved), or throws on timeout.
    private static async Task<JsonElement> ReceiveUntil(WebSocket socket, string expected, CancellationToken ct)
    {
        for (int i = 0; i < 30; i++)
        {
            var (evt, payload) = await ReceiveEnvelope(socket, ct);
            if (evt == expected) return payload;
            if (evt == "__CLOSE__") throw new InvalidOperationException($"socket closed while waiting for {expected}");
        }
        throw new InvalidOperationException($"did not receive {expected} within 30 messages");
    }

    // Connect, drain the SOCKET_READY + GAME_MODES_UPDATED handshake, send JOIN_LOBBY and wait for success.
    private async Task<WebSocket> ConnectAndJoinAsync(CancellationToken ct)
    {
        var (socket, _) = await ConnectAndJoinWithLobbyAsync(ct, null);
        return socket;
    }

    // Variant that returns the JOIN_LOBBY_SUCCESS lobby payload and accepts a target lobbyId so a
    // second client can join the SAME lobby (for leader-reassignment / broadcast tests).
    private async Task<(WebSocket Socket, JsonElement Lobby)> ConnectAndJoinWithLobbyAsync(CancellationToken ct, string? lobbyId)
    {
        var wsClient = _factory.Server.CreateWebSocketClient();
        var socket = await wsClient.ConnectAsync(WsUri(), ct);
        await ReceiveEnvelope(socket, ct); // SOCKET_READY
        await ReceiveEnvelope(socket, ct); // GAME_MODES_UPDATED
        await SendEnvelope(socket, "JOIN_LOBBY", lobbyId is null ? new { charId = 1 } : (object)new { charId = 1, lobbyId }, ct);
        var success = await ReceiveUntil(socket, "JOIN_LOBBY_SUCCESS", ct);
        return (socket, success.GetProperty("lobby").Clone());
    }

    [Fact] // F001 connect handshake: server sends SOCKET_READY then GAME_MODES_UPDATED
    public async Task WebSocket_Connect_SendsHandshake()
    {
        var ct = new CancellationTokenSource(TimeSpan.FromSeconds(10)).Token;
        var wsClient = _factory.Server.CreateWebSocketClient();
        using var socket = await wsClient.ConnectAsync(WsUri(), ct);

        var first = await ReceiveEnvelope(socket, ct);
        var second = await ReceiveEnvelope(socket, ct);

        Assert.Equal("SOCKET_READY", first.Event);
        Assert.Equal("GAME_MODES_UPDATED", second.Event);
        await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "done", ct);
    }

    [Fact] // F001 banned account is rejected at connect with JOIN_LOBBY_FAIL / ERR_BANNED
    public async Task WebSocket_BannedAccount_RejectedWithErrBanned()
    {
        var ct = new CancellationTokenSource(TimeSpan.FromSeconds(10)).Token;
        var wsClient = _factory.Server.CreateWebSocketClient();
        wsClient.ConfigureRequest = req => req.Headers["X-BAP-AccountId"] = AppFactory.BannedAccountId;
        using var socket = await wsClient.ConnectAsync(WsUri(), ct);

        var msg = await ReceiveEnvelope(socket, ct);

        Assert.Equal("JOIN_LOBBY_FAIL", msg.Event);
        Assert.Equal("ERR_BANNED", msg.Payload.GetProperty("errorCode").GetString());
    }

    [Fact] // F002 JOIN_LOBBY drives a JOIN_LOBBY_SUCCESS with a lobby payload (note: handler has a 6s pre-send delay)
    public async Task WebSocket_JoinLobby_Succeeds()
    {
        var ct = new CancellationTokenSource(TimeSpan.FromSeconds(20)).Token;
        var wsClient = _factory.Server.CreateWebSocketClient();
        using var socket = await wsClient.ConnectAsync(WsUri(), ct);

        // Drain the connect handshake first.
        await ReceiveEnvelope(socket, ct); // SOCKET_READY
        await ReceiveEnvelope(socket, ct); // GAME_MODES_UPDATED

        await SendEnvelope(socket, "JOIN_LOBBY", new { charId = 1 }, ct);

        // The first message after JOIN_LOBBY should be JOIN_LOBBY_SUCCESS (after the handler's 6s delay).
        var msg = await ReceiveEnvelope(socket, ct);

        Assert.Equal("JOIN_LOBBY_SUCCESS", msg.Event);
        Assert.True(msg.Payload.TryGetProperty("lobby", out _), "JOIN_LOBBY_SUCCESS payload should carry a lobby");
        await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "done", ct);
    }

    [Fact] // F010 switch char + F006 change team: in-lobby actions broadcast their *_SUCCESS back to the sender
    public async Task WebSocket_SwitchCharAndTeam_Succeed()
    {
        var ct = new CancellationTokenSource(TimeSpan.FromSeconds(20)).Token;
        using var socket = await ConnectAndJoinAsync(ct);

        await SendEnvelope(socket, "SWITCH_CHAR", new { charId = 15 }, ct); // Medusa
        var charMsg = await ReceiveUntil(socket, "SWITCH_CHAR_SUCCESS", ct);
        Assert.Equal(15, charMsg.GetProperty("charId").GetInt32());

        await SendEnvelope(socket, "UPDATE_CUSTOM_TEAM", new { teamId = 3 }, ct);
        var teamMsg = await ReceiveUntil(socket, "UPDATE_CUSTOM_TEAM_SUCCESS", ct);
        Assert.Equal(3, teamMsg.GetProperty("player").GetProperty("teamId").GetInt32());

        await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "done", ct);
    }

    [Fact] // F008 switch game mode + F007 update settings: leader (the fresh joiner) can drive both
    public async Task WebSocket_GameModeAndSettings_Succeed()
    {
        var ct = new CancellationTokenSource(TimeSpan.FromSeconds(20)).Token;
        using var socket = await ConnectAndJoinAsync(ct);

        // Switch to mode 3 (Solos) — the mode the test fixture advertises (appsettings EnabledGameModeIdsCsv).
        // SwitchGameMode now validates against the advertised set, so an un-advertised id is rejected.
        await SendEnvelope(socket, "SWITCH_GAME_MODE", new { gameModeId = 3 }, ct);
        await ReceiveUntil(socket, "SWITCH_GAME_MODE_SUCCESS", ct);

        // The mode switch must also broadcast UPDATE_CUSTOM_SETTINGS_SUCCESS carrying the new mode,
        // otherwise the lobby UI never re-renders the picked mode tile (root cause of "can't switch mode").
        var switchSettings = await ReceiveUntil(socket, "UPDATE_CUSTOM_SETTINGS_SUCCESS", ct);
        Assert.Equal(3, switchSettings.GetProperty("settings").GetProperty("gamemode").GetInt32());

        await SendEnvelope(socket, "UPDATE_CUSTOM_SETTINGS", new { settings = new { mapId = 1, teamSize = 2, maxTeams = 4, botCount = 2, botDifficulty = 1 } }, ct);
        var settingsMsg = await ReceiveUntil(socket, "UPDATE_CUSTOM_SETTINGS_SUCCESS", ct);
        Assert.True(settingsMsg.TryGetProperty("settings", out _), "settings success should echo the applied settings");

        await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "done", ct);
    }

    [Fact] // F004 ready toggle broadcasts READY_UPDATED and (non-custom lobby) wires the matchmaking queue
    public async Task WebSocket_ReadyToggle_BroadcastsReadyUpdated()
    {
        var ct = new CancellationTokenSource(TimeSpan.FromSeconds(20)).Token;
        using var socket = await ConnectAndJoinAsync(ct);

        await SendEnvelope(socket, "SWITCH_READY", new { isReady = true }, ct);
        var readyMsg = await ReceiveUntil(socket, "READY_UPDATED", ct);
        Assert.True(readyMsg.GetProperty("isReady").GetBoolean());

        await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "done", ct);
    }

    [Fact] // F009 switch region: leader joiner changes region and gets SWITCH_REGION_SUCCESS
    public async Task WebSocket_SwitchRegion_Succeeds()
    {
        var ct = new CancellationTokenSource(TimeSpan.FromSeconds(20)).Token;
        using var socket = await ConnectAndJoinAsync(ct);

        await SendEnvelope(socket, "SWITCH_REGION", new { regionId = "us-west" }, ct);
        var regionMsg = await ReceiveUntil(socket, "SWITCH_REGION_SUCCESS", ct);
        Assert.Equal("us-west", regionMsg.GetProperty("regionId").GetString());

        await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "done", ct);
    }

    [Fact] // F005 cancel matchmaking: ready up (joins queue) then cancel, expect CANCEL_MATCHMAKING_SUCCESS, stay in lobby
    public async Task WebSocket_CancelMatchmaking_AcknowledgesAndStaysInLobby()
    {
        var ct = new CancellationTokenSource(TimeSpan.FromSeconds(20)).Token;
        using var socket = await ConnectAndJoinAsync(ct);

        await SendEnvelope(socket, "SWITCH_READY", new { isReady = true }, ct);
        await ReceiveUntil(socket, "READY_UPDATED", ct); // now in queue

        await SendEnvelope(socket, "CANCEL_MATCHMAKING", new { }, ct);
        var cancelMsg = await ReceiveUntil(socket, "CANCEL_MATCHMAKING_SUCCESS", ct);
        Assert.True(cancelMsg.TryGetProperty("lobbyId", out var lobbyId) && lobbyId.ValueKind == JsonValueKind.String,
            "cancel ack should carry the lobbyId so the client stays in the lobby ready screen");

        await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "done", ct);
    }

    [Fact] // F073 post-match auto-requeue suppression: the auto-ready that the game client sends after a
    // match must NOT re-queue the player (they stay in lobby); a CANCEL_MATCHMAKING_SUCCESS is sent and
    // the queue stays empty. Regression guard for the "exit-to-lobby re-spawns char-select" bug.
    public async Task WebSocket_AutoReadyAfterMatch_SuppressedAndStaysInLobby()
    {
        var ct = new CancellationTokenSource(TimeSpan.FromSeconds(40)).Token;
        var queue = _factory.Services.GetRequiredService<MatchmakingQueueService>();
        queue.ClearQueue();

        // Leader joins, then force-starts a match — this ARMS the post-match suppression flag.
        var (socket, _) = await ConnectAndJoinWithLobbyAsync(ct, null);
        await SendEnvelope(socket, "START_CUSTOM_GAME", new { forceStart = true }, ct);
        await ReceiveUntil(socket, "GAME_STARTED", ct);

        // Simulate the game client's automatic post-match ready. It must be suppressed: no JoinQueue.
        await SendEnvelope(socket, "SWITCH_CUSTOM_READY", new { isReady = true }, ct);
        var cancel = await ReceiveUntil(socket, "CANCEL_MATCHMAKING_SUCCESS", ct);
        Assert.Equal("CANCEL_MATCHMAKING_SUCCESS", cancel.ValueKind == JsonValueKind.Object ? "CANCEL_MATCHMAKING_SUCCESS" : "");
        Assert.Equal(0, queue.GetQueueSize()); // the auto-ready did NOT enter the matchmaking queue

        await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "done", ct);
    }

    [Fact] // F017 leave cleanup reassigns leadership and broadcasts LOBBY_LEFT to remaining members
    public async Task WebSocket_LeaderLeaves_ReassignsLeadershipAndBroadcastsLeft()
    {
        // Two sequential JOIN_LOBBY calls (~6s each); allow generous margin under batch load.
        var ct = new CancellationTokenSource(TimeSpan.FromSeconds(60)).Token;

        // Client A joins first -> becomes leader and creates the lobby.
        var (socketA, lobbyA) = await ConnectAndJoinWithLobbyAsync(ct, null);
        string lobbyId = lobbyA.GetProperty("lobbyId").GetString()!;
        string leaderA = lobbyA.GetProperty("leaderAccountId").GetString()!;

        // Client B joins the SAME lobby.
        var (socketB, _) = await ConnectAndJoinWithLobbyAsync(ct, lobbyId);

        // A (the leader) leaves via LOBBIES_LEAVE -> server runs RemoveFromLobbyAsync cleanup.
        // We use the message path rather than a socket close so both client sockets stay alive
        // (a raw close races the TestHost's paired-buffer teardown and throws ObjectDisposedException).
        await SendEnvelope(socketA, "LOBBIES_LEAVE", new { }, ct);

        // B should receive LOBBY_LEFT with leadership reassigned away from A.
        var left = await ReceiveUntil(socketB, "LOBBY_LEFT", ct);
        Assert.Equal(leaderA, left.GetProperty("accountId").GetString()); // A is the member who left
        Assert.NotEqual(leaderA, left.GetProperty("leaderAccountId").GetString()); // leadership moved to B

        await socketA.CloseAsync(WebSocketCloseStatus.NormalClosure, "done", ct);
        await socketB.CloseAsync(WebSocketCloseStatus.NormalClosure, "done", ct);
    }

    [Fact] // F011 start-game guards (fail-closed, no spawn): non-leader -> ERR_NOT_LEADER; leader w/ unready peer -> ERR_NOTREADY
    public async Task WebSocket_StartCustomGame_GuardsRejectBeforeSpawn()
    {
        // Two sequential JOIN_LOBBY calls (~6s each); allow generous margin under batch load.
        var ct = new CancellationTokenSource(TimeSpan.FromSeconds(60)).Token;

        // A joins first -> leader. B joins the same lobby -> non-leader, unready.
        var (socketA, lobbyA) = await ConnectAndJoinWithLobbyAsync(ct, null);
        string lobbyId = lobbyA.GetProperty("lobbyId").GetString()!;
        var (socketB, _) = await ConnectAndJoinWithLobbyAsync(ct, lobbyId);

        // Non-leader B presses PLAY -> rejected with ERR_NOT_LEADER (guard fires before any spawn path).
        await SendEnvelope(socketB, "START_CUSTOM_GAME", new { forceStart = false }, ct);
        var bFail = await ReceiveUntil(socketB, "START_CUSTOM_GAME_FAIL", ct);
        Assert.Equal("ERR_NOT_LEADER", bFail.GetProperty("errorCode").GetString());

        // Leader A presses PLAY while peer B is unready and forceStart=false -> ERR_NOTREADY (still no spawn).
        await SendEnvelope(socketA, "START_CUSTOM_GAME", new { forceStart = false }, ct);
        var aFail = await ReceiveUntil(socketA, "START_CUSTOM_GAME_FAIL", ct);
        Assert.Equal("ERR_NOTREADY", aFail.GetProperty("errorCode").GetString());

        await socketA.CloseAsync(WebSocketCloseStatus.NormalClosure, "done", ct);
        await socketB.CloseAsync(WebSocketCloseStatus.NormalClosure, "done", ct);
    }

    [Fact] // F021 game-modes advertisement: the connect-handshake GAME_MODES_UPDATED carries an array of mode entries
    public async Task WebSocket_GameModesUpdated_AdvertisesModes()
    {
        var ct = new CancellationTokenSource(TimeSpan.FromSeconds(10)).Token;
        var wsClient = _factory.Server.CreateWebSocketClient();
        using var socket = await wsClient.ConnectAsync(WsUri(), ct);

        await ReceiveEnvelope(socket, ct); // SOCKET_READY
        var modes = await ReceiveEnvelope(socket, ct); // GAME_MODES_UPDATED

        Assert.Equal("GAME_MODES_UPDATED", modes.Event);
        Assert.Equal(JsonValueKind.Array, modes.Payload.ValueKind);
        Assert.True(modes.Payload.GetArrayLength() >= 1, "at least one game mode should be advertised");
        Assert.True(modes.Payload[0].TryGetProperty("gameModeId", out _), "each mode entry carries a gameModeId");

        await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "done", ct);
    }

    [Fact] // F022 discovery & snapshots: a live joined lobby appears in the admin /admin/lobbies snapshot
    public async Task WebSocket_JoinedLobby_AppearsInAdminSnapshot()
    {
        var ct = new CancellationTokenSource(TimeSpan.FromSeconds(20)).Token;
        var (socket, lobby) = await ConnectAndJoinWithLobbyAsync(ct, null);
        string lobbyId = lobby.GetProperty("lobbyId").GetString()!;

        var client = _factory.CreateClient();
        var req = new HttpRequestMessage(HttpMethod.Get, "/admin/lobbies");
        req.Headers.Add(AdminAuth.TokenHeader, AppFactory.AdminToken);
        var resp = await client.SendAsync(req, ct);

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        var snapshot = await ReadJson(resp);
        Assert.Equal(JsonValueKind.Array, snapshot.ValueKind);
        bool found = false;
        foreach (var entry in snapshot.EnumerateArray())
        {
            if (entry.TryGetProperty("id", out var id) && id.GetString() == lobbyId) { found = true; break; }
        }
        Assert.True(found, $"live lobby {lobbyId} should appear in the admin snapshot");

        await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "done", ct);
    }
}

[CollectionDefinition("HttpIntegration", DisableParallelization = true)]
public sealed class HttpIntegrationCollection { }

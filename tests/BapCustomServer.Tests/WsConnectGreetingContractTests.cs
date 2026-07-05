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

// Phase 0 protocol lock: the unsolicited connect greeting ORDER is a frozen contract
// (LobbyService.HandleSocketAsync ~734-737):
//   SOCKET_READY -> GAME_MODES_UPDATED -> SET_FRIENDS (one per friend)
//   -> SET_FRIEND_REQUESTS (only when pending requests exist)
// The shipped game client drains these frames positionally, so reordering or inserting
// frames breaks the client's connect handshake.
[Collection("HttpIntegration")] // serialize: the factory boots a full host with hosted services
public sealed class WsConnectGreetingContractTests : IClassFixture<WsConnectGreetingContractTests.AppFactory>
{
    private readonly AppFactory _factory;

    public WsConnectGreetingContractTests(AppFactory factory) => _factory = factory;

    public sealed class AppFactory : WebApplicationFactory<ApiEntryPoint>
    {
        public readonly string DataDir = Path.Combine(Path.GetTempPath(), "bapcustom-greeting", Guid.NewGuid().ToString("N"));

        protected override IHost CreateHost(IHostBuilder builder)
        {
            Directory.CreateDirectory(DataDir);
            // Neutral player-overrides doc + full state-file redirects (see TestSupport.cs).
            Svc.WriteNeutralPlayerOverrides(DataDir);
            builder.UseEnvironment("Testing");
            builder.ConfigureHostConfiguration(cfg =>
            {
                var settings = Svc.StateFileRedirects(DataDir);
                settings["CustomServer:LaunchGameServers"] = "false";
                settings["CustomServer:GameServerPrewarmOnStartup"] = "false";
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

    // --- WS plumbing (duplicated from EndpointIntegrationTests for this increment) ---

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

    [Fact] // greeting order with friends + pending request: 4 frames, fixed order, fixed shapes
    public async Task Greeting_WithFriendsAndPendingRequest_SendsOrderedSequence()
    {
        var ct = new CancellationTokenSource(TimeSpan.FromSeconds(10)).Token;

        // Seed the REAL FriendsService: greet-friend is an accepted friend of greet-main,
        // greet-requester leaves a pending request for greet-main. Assert Ok to fail fast.
        var friends = _factory.Services.GetRequiredService<FriendsService>();
        Assert.True(friends.SendRequest("greet-friend", "GreetFriend", 1, "greet-main").Ok);
        Assert.True(friends.AcceptRequest("greet-main", "greet-friend").Ok);
        Assert.True(friends.SendRequest("greet-requester", "GreetRequester", 2, "greet-main").Ok);

        var wsClient = _factory.Server.CreateWebSocketClient();
        wsClient.ConfigureRequest = req =>
        {
            req.Headers["X-BAP-AccountId"] = "greet-main";
            req.Headers["X-BAP-Username"] = "GreetMain";
        };
        using var socket = await wsClient.ConnectAsync(WsUri(), ct);

        var first = await ReceiveEnvelope(socket, ct);
        Assert.Equal("SOCKET_READY", first.Event);
        Assert.True(first.Payload.ValueKind is JsonValueKind.Undefined or JsonValueKind.Null,
            $"SOCKET_READY payload should be absent/null, got {first.Payload.ValueKind}");

        var second = await ReceiveEnvelope(socket, ct);
        Assert.Equal("GAME_MODES_UPDATED", second.Event);
        Assert.Equal(JsonValueKind.Array, second.Payload.ValueKind);

        var third = await ReceiveEnvelope(socket, ct);
        Assert.Equal("SET_FRIENDS", third.Event);
        Assert.Equal("greet-friend", third.Payload.GetProperty("accountId").GetString());
        Assert.True(third.Payload.TryGetProperty("status", out _), "SET_FRIENDS should carry a status");

        var fourth = await ReceiveEnvelope(socket, ct);
        Assert.Equal("SET_FRIEND_REQUESTS", fourth.Event);
        var requests = fourth.Payload.GetProperty("friendRequests");
        Assert.Equal(JsonValueKind.Array, requests.ValueKind);
        Assert.Equal(1, requests.GetArrayLength());
        Assert.Equal("greet-requester", requests[0].GetProperty("accountId").GetString());

        await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "done", ct);
    }

    [Fact] // a friendless fresh account gets EXACTLY 2 greeting frames — proven via the SOCKET_READY echo
    public async Task Greeting_FreshAccount_SendsExactlyTwoFramesBeforeEcho()
    {
        var ct = new CancellationTokenSource(TimeSpan.FromSeconds(10)).Token;
        string accountId = $"greet-fresh-{Guid.NewGuid():N}";

        var wsClient = _factory.Server.CreateWebSocketClient();
        wsClient.ConfigureRequest = req =>
        {
            req.Headers["X-BAP-AccountId"] = accountId;
            req.Headers["X-BAP-Username"] = "GreetFresh";
        };
        using var socket = await wsClient.ConnectAsync(WsUri(), ct);

        var first = await ReceiveEnvelope(socket, ct);
        Assert.Equal("SOCKET_READY", first.Event);
        var second = await ReceiveEnvelope(socket, ct);
        Assert.Equal("GAME_MODES_UPDATED", second.Event);

        // The server echoes a client-sent SOCKET_READY (LobbyService ~908-910). All greeting frames
        // were queued before the receive loop started, so if a SET_FRIENDS/SET_FRIEND_REQUESTS frame
        // had been sent for this friendless account it would arrive BEFORE this echo.
        await SendEnvelope(socket, "SOCKET_READY", new { }, ct);
        var echo = await ReceiveEnvelope(socket, ct);
        Assert.Equal("SOCKET_READY", echo.Event);

        await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "done", ct);
    }
}

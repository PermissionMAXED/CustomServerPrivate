using System.Diagnostics;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace BapCustomServer.Tests;

// Phase 0 protocol lock: the JOIN_LOBBY_SUCCESS payload contract. Two frozen oddities the
// shipped game client depends on (LobbyService.JoinLobbyAsync):
//  - a deliberate 6s delay before ANY join response (~1150-1155) so the client finishes
//    processing its initial HTTP responses first — never remove/shorten;
//  - join FAILURES for invalid codes are reported as JOIN_LOBBY_SUCCESS with lobby=null and
//    a wasInvalid flag (~1186-1195), NOT as JOIN_LOBBY_FAIL.
[Collection("HttpIntegration")] // serialize: the factory boots a full host with hosted services
public sealed class JoinLobbyContractTests : IClassFixture<JoinLobbyContractTests.AppFactory>
{
    private readonly AppFactory _factory;

    public JoinLobbyContractTests(AppFactory factory) => _factory = factory;

    public sealed class AppFactory : WebApplicationFactory<ApiEntryPoint>
    {
        public readonly string DataDir = Path.Combine(Path.GetTempPath(), "bapcustom-joinlobby", Guid.NewGuid().ToString("N"));

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

    private async Task<WebSocket> ConnectAndDrainGreetingAsync(CancellationToken ct)
    {
        var wsClient = _factory.Server.CreateWebSocketClient();
        var socket = await wsClient.ConnectAsync(WsUri(), ct);
        await ReceiveEnvelope(socket, ct); // SOCKET_READY
        await ReceiveEnvelope(socket, ct); // GAME_MODES_UPDATED
        return socket;
    }

    [Fact] // success payload carries all four flags + the full camelCased LobbyData shape (Contracts.cs ~163-175)
    public async Task JoinLobby_Success_CarriesFullContractPayload()
    {
        var ct = new CancellationTokenSource(TimeSpan.FromSeconds(30)).Token;
        using var socket = await ConnectAndDrainGreetingAsync(ct);

        await SendEnvelope(socket, "JOIN_LOBBY", new { charId = 1 }, ct);
        var payload = await ReceiveUntil(socket, "JOIN_LOBBY_SUCCESS", ct);

        // Contract flags: all four keys present, false on the happy path.
        Assert.True(payload.TryGetProperty("lobby", out var lobby), "payload should carry a lobby");
        Assert.Equal(JsonValueKind.Object, lobby.ValueKind);
        Assert.False(payload.GetProperty("wasFull").GetBoolean());
        Assert.False(payload.GetProperty("wasInvalid").GetBoolean());
        Assert.False(payload.GetProperty("wasKicked").GetBoolean());

        // LobbyData keys, camelCased by JsonContract (presence, not values — values are config-driven).
        Assert.Equal(JsonValueKind.String, lobby.GetProperty("lobbyId").ValueKind);
        Assert.False(string.IsNullOrEmpty(lobby.GetProperty("lobbyId").GetString()));
        Assert.True(lobby.TryGetProperty("leaderAccountId", out _), "lobby should carry leaderAccountId");
        Assert.True(lobby.TryGetProperty("lobbyOpen", out _), "lobby should carry lobbyOpen");
        var players = lobby.GetProperty("players");
        Assert.Equal(JsonValueKind.Array, players.ValueKind);
        Assert.Equal(1, players.GetArrayLength());
        Assert.Equal(JsonValueKind.Object, lobby.GetProperty("settings").ValueKind);
        Assert.Equal(JsonValueKind.Number, lobby.GetProperty("gold").ValueKind);
        Assert.Equal(JsonValueKind.Number, lobby.GetProperty("fractals").ValueKind);
        Assert.Equal(JsonValueKind.Number, lobby.GetProperty("charTokens").ValueKind);
        Assert.Equal(JsonValueKind.Number, lobby.GetProperty("accountXp").ValueKind);

        await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "done", ct);
    }

    [Fact] // invalid-code joins answer JOIN_LOBBY_SUCCESS + wasInvalid=true with a null lobby — NOT JOIN_LOBBY_FAIL
    public async Task JoinLobby_ByUnknownCode_ReturnsSuccessWithWasInvalid_NotFail()
    {
        var ct = new CancellationTokenSource(TimeSpan.FromSeconds(30)).Token;
        using var socket = await ConnectAndDrainGreetingAsync(ct);

        await SendEnvelope(socket, "JOIN_LOBBY", new { charId = 1, lobbyId = "ZZZZZZ" }, ct);

        // The first frame after the handler's deliberate 6s delay is the join response itself.
        var (evt, payload) = await ReceiveEnvelope(socket, ct);
        Assert.Equal("JOIN_LOBBY_SUCCESS", evt); // explicitly NOT "JOIN_LOBBY_FAIL"
        Assert.True(payload.GetProperty("wasInvalid").GetBoolean());
        Assert.False(payload.GetProperty("wasFull").GetBoolean());
        Assert.False(payload.GetProperty("wasKicked").GetBoolean());
        // Server sets lobby=null; JsonContract's WhenWritingNull omits the key entirely.
        Assert.True(!payload.TryGetProperty("lobby", out var lobby) || lobby.ValueKind == JsonValueKind.Null,
            "invalid-code join must carry an absent-or-null lobby");

        await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "done", ct);
    }

    [Fact] // the deliberate 6s pre-response delay (LobbyService.JoinLobbyAsync ~1150-1155) is a frozen contract
    public async Task JoinLobby_ResponseIsDelayedByAtLeastFiveSeconds()
    {
        var ct = new CancellationTokenSource(TimeSpan.FromSeconds(30)).Token;
        using var socket = await ConnectAndDrainGreetingAsync(ct);

        // Invalid-code path: exactly ONE response frame follows the delay (no lobby broadcasts),
        // so the elapsed time measures the JOIN_LOBBY handler and nothing else.
        var stopwatch = Stopwatch.StartNew();
        await SendEnvelope(socket, "JOIN_LOBBY", new { charId = 1, lobbyId = "ZZZZZZ" }, ct);
        var (evt, _) = await ReceiveEnvelope(socket, ct);
        stopwatch.Stop();

        Assert.Equal("JOIN_LOBBY_SUCCESS", evt);
        // Lower bound only: the server-side Task.Delay is a fixed 6000ms, so >=5s can never be
        // flaky on the low side; an upper bound WOULD be flaky under load, so none is asserted.
        Assert.True(stopwatch.Elapsed >= TimeSpan.FromSeconds(5),
            $"JOIN_LOBBY answered in {stopwatch.Elapsed.TotalMilliseconds:F0}ms — the deliberate 6s " +
            "delay before ANY join response was removed or shortened. The shipped client needs it " +
            "to finish processing its initial HTTP responses before JOIN_LOBBY_SUCCESS arrives.");

        await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "done", ct);
    }

    [Fact] // the frame immediately after JOIN_LOBBY_SUCCESS must be the GAME_MODES_UPDATED re-send
    public async Task JoinLobby_Success_IsImmediatelyFollowedByGameModesUpdated()
    {
        var ct = new CancellationTokenSource(TimeSpan.FromSeconds(30)).Token;
        using var socket = await ConnectAndDrainGreetingAsync(ct);

        await SendEnvelope(socket, "JOIN_LOBBY", new { charId = 1 }, ct);
        var (first, _) = await ReceiveEnvelope(socket, ct);
        Assert.Equal("JOIN_LOBBY_SUCCESS", first);

        // Load-bearing re-send (LobbyService ~1286-1287): the client resets gameModeId to -1 while
        // joining and only this frame moves it back to a valid mode. Per-connection sends are
        // strictly ordered, so on the joiner's socket it must be the VERY NEXT frame (the
        // LOBBY_JOINED broadcast excludes the joiner and cannot interleave here).
        var (second, payload) = await ReceiveEnvelope(socket, ct);
        Assert.Equal("GAME_MODES_UPDATED", second);
        Assert.Equal(JsonValueKind.Array, payload.ValueKind);

        await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "done", ct);
    }
}

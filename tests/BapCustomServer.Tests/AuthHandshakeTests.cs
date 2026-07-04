using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace BapCustomServer.Tests;

// F170 — admin auth 3-step handshake over WebSocket.
// Verifies the full MOD_HELLO → MOD_CHALLENGE → MOD_AUTH → MOD_AUTH_OK →
// ADMIN_AUTH → ADMIN_AUTH_RESULT flow end-to-end through Kestrel's pipeline.
[Collection("HttpIntegration")]
public sealed class AuthHandshakeTests : IClassFixture<AuthHandshakeTests.AuthAppFactory>
{
    private readonly AuthAppFactory _factory;

    public AuthHandshakeTests(AuthAppFactory factory) => _factory = factory;

    public sealed class AuthAppFactory : WebApplicationFactory<ApiEntryPoint>
    {
        public const string TestAttestationSecret = "test-attestation-secret-for-hmac-signing";
        public const string AdminToken = "test-admin-token-for-auth-test";
        public const string AdminAccountId = "admin-test-1";
        public const string NonAdminAccountId = "regular-player-42";
        public readonly string DataDir = Path.Combine(Path.GetTempPath(), "bapcustom-auth", Guid.NewGuid().ToString("N"));

        protected override IHost CreateHost(IHostBuilder builder)
        {
            Directory.CreateDirectory(DataDir);
            // Full redirect set + neutral overrides doc: this fixture previously redirected only
            // Admin/Economy/PlayerStorage, so PlayerOverridesService regenerated its
            // unlockEverything:true default into the shared test-bin data/ dir on every run.
            Svc.WriteNeutralPlayerOverrides(DataDir);
            builder.UseEnvironment("Testing");
            builder.ConfigureHostConfiguration(cfg =>
            {
                var settings = Svc.StateFileRedirects(DataDir);
                settings["CustomServer:LaunchGameServers"] = "false";
                settings["CustomServer:GameServerPrewarmOnStartup"] = "false";
                settings["CustomServer:Admin:ApiToken"] = AdminToken;
                settings["CustomServer:Admin:AttestationSecret"] = TestAttestationSecret;
                settings["CustomServer:Admin:AdminAccountIds:0"] = AdminAccountId;
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

    private Uri WsUri(string accountId, string username) =>
        new UriBuilder(_factory.Server.BaseAddress)
        {
            Scheme = "ws",
            Path = "/ws",
            Query = $"accountId={Uri.EscapeDataString(accountId)}&username={Uri.EscapeDataString(username)}"
        }.Uri;

    /// <summary>Computes the same HMAC-SHA256 the mod's AdminAuthClient sends:
    /// HMAC-SHA256(secret, nonce + accountId), hex-encoded lowercase.</summary>
    private static string ComputeHmac(string secret, string nonce, string accountId)
    {
        byte[] secretBytes = Encoding.UTF8.GetBytes(secret);
        byte[] messageBytes = Encoding.UTF8.GetBytes(nonce + accountId);
        byte[] hmac = HMACSHA256.HashData(secretBytes, messageBytes);
        return Convert.ToHexString(hmac).ToLowerInvariant();
    }

    private static async Task SendJsonAsync(WebSocket ws, object obj, CancellationToken ct)
    {
        string json = JsonSerializer.Serialize(obj);
        await ws.SendAsync(Encoding.UTF8.GetBytes(json), WebSocketMessageType.Text, true, ct);
    }

    private static async Task<JsonElement> ReceiveJsonAsync(WebSocket ws, CancellationToken ct)
    {
        var buffer = new byte[16 * 1024];
        using var ms = new MemoryStream();
        WebSocketReceiveResult result;
        do
        {
            result = await ws.ReceiveAsync(buffer, ct);
            if (result.MessageType == WebSocketMessageType.Close)
                throw new InvalidOperationException("WS closed during receive");
            ms.Write(buffer, 0, result.Count);
        } while (!result.EndOfMessage);
        return JsonDocument.Parse(ms.ToArray()).RootElement.Clone();
    }

    private static string? GetString(JsonElement root, params string[] path)
    {
        JsonElement el = root;
        foreach (var seg in path)
        {
            if (!el.TryGetProperty(seg, out el)) return null;
        }
        return el.ValueKind == JsonValueKind.String ? el.GetString() : null;
    }

    private static bool GetBool(JsonElement root, params string[] path)
    {
        JsonElement el = root;
        foreach (var seg in path)
        {
            if (!el.TryGetProperty(seg, out el)) return false;
        }
        return el.ValueKind is JsonValueKind.True;
    }

    // ===== Tests ===========================================================

    [Fact] // F170a — full auth handshake with valid admin account
    public async Task AuthHandshake_FullFlow_WithValidAdmin_GrantsAccess()
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(15));
        var wsClient = _factory.Server.CreateWebSocketClient();
        var socket = await wsClient.ConnectAsync(WsUri(AuthAppFactory.AdminAccountId, "AdminTest"), cts.Token);

        // Drain the initial handshake messages
        var ready = await ReceiveJsonAsync(socket, cts.Token); // SOCKET_READY
        Assert.Equal("SOCKET_READY", GetString(ready, "event"));
        var modes = await ReceiveJsonAsync(socket, cts.Token); // GAME_MODES_UPDATED
        Assert.Equal("GAME_MODES_UPDATED", GetString(modes, "event"));

        // Step 1: MOD_HELLO
        await SendJsonAsync(socket, new { @event = "MOD_HELLO", payload = new { version = "1.0.6" } }, cts.Token);

        // Step 2: Receive MOD_CHALLENGE
        JsonElement challenge = await ReceiveJsonAsync(socket, cts.Token);
        Assert.Equal("MOD_CHALLENGE", GetString(challenge, "event"));
        string? nonce = GetString(challenge, "payload", "nonce");
        Assert.NotNull(nonce);
        Assert.NotEmpty(nonce);

        // Step 3: Compute HMAC and send MOD_AUTH
        string signature = ComputeHmac(AuthAppFactory.TestAttestationSecret, nonce, AuthAppFactory.AdminAccountId);
        await SendJsonAsync(socket, new { @event = "MOD_AUTH", payload = new { nonce, signature } }, cts.Token);

        // Step 4: Receive MOD_AUTH_OK
        JsonElement authOk = await ReceiveJsonAsync(socket, cts.Token);
        Assert.Equal("MOD_AUTH_OK", GetString(authOk, "event"));
        Assert.True(GetBool(authOk, "payload", "ok"), "Attestation should pass");

        // Step 5: Send ADMIN_AUTH with valid token
        await SendJsonAsync(socket, new { @event = "ADMIN_AUTH", payload = new { token = AuthAppFactory.AdminToken } }, cts.Token);

        // Step 6: Receive ADMIN_AUTH_RESULT
        JsonElement result = await ReceiveJsonAsync(socket, cts.Token);
        Assert.Equal("ADMIN_AUTH_RESULT", GetString(result, "event"));
        Assert.True(GetBool(result, "payload", "ok"), "Admin auth should pass");
    }

    [Fact] // F170b — wrong HMAC signature is rejected
    public async Task AuthHandshake_InvalidSignature_Rejected()
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(15));
        var wsClient = _factory.Server.CreateWebSocketClient();
        var socket = await wsClient.ConnectAsync(WsUri(AuthAppFactory.AdminAccountId, "AdminTest"), cts.Token);

        // Drain handshake
        await ReceiveJsonAsync(socket, cts.Token); // SOCKET_READY
        await ReceiveJsonAsync(socket, cts.Token); // GAME_MODES_UPDATED

        // MOD_HELLO
        await SendJsonAsync(socket, new { @event = "MOD_HELLO" }, cts.Token);

        // Receive MOD_CHALLENGE
        JsonElement challenge = await ReceiveJsonAsync(socket, cts.Token);
        Assert.Equal("MOD_CHALLENGE", GetString(challenge, "event"));
        string? nonce = GetString(challenge, "payload", "nonce");

        // Send MOD_AUTH with WRONG signature (tampered)
        await SendJsonAsync(socket, new { @event = "MOD_AUTH", payload = new { nonce, signature = "0000000000000000000000000000000000000000000000000000000000000000" } }, cts.Token);

        // Receive MOD_AUTH_OK with ok=false
        JsonElement authOk = await ReceiveJsonAsync(socket, cts.Token);
        Assert.Equal("MOD_AUTH_OK", GetString(authOk, "event"));
        Assert.False(GetBool(authOk, "payload", "ok"), "Bad signature should be rejected");
    }

    [Fact] // F170c — wrong admin token is rejected
    public async Task AuthHandshake_WrongToken_Rejected()
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(15));
        var wsClient = _factory.Server.CreateWebSocketClient();
        var socket = await wsClient.ConnectAsync(WsUri(AuthAppFactory.AdminAccountId, "AdminTest"), cts.Token);

        // Drain + attest
        await ReceiveJsonAsync(socket, cts.Token); // SOCKET_READY
        await ReceiveJsonAsync(socket, cts.Token); // GAME_MODES_UPDATED
        await SendJsonAsync(socket, new { @event = "MOD_HELLO" }, cts.Token);
        JsonElement challenge = await ReceiveJsonAsync(socket, cts.Token);
        string? nonce = GetString(challenge, "payload", "nonce");
        Assert.NotNull(nonce);
        string signature = ComputeHmac(AuthAppFactory.TestAttestationSecret, nonce, AuthAppFactory.AdminAccountId);
        await SendJsonAsync(socket, new { @event = "MOD_AUTH", payload = new { nonce, signature } }, cts.Token);
        await ReceiveJsonAsync(socket, cts.Token); // MOD_AUTH_OK

        // Send ADMIN_AUTH with WRONG token
        await SendJsonAsync(socket, new { @event = "ADMIN_AUTH", payload = new { token = "wrong-token" } }, cts.Token);

        JsonElement result = await ReceiveJsonAsync(socket, cts.Token);
        Assert.Equal("ADMIN_AUTH_RESULT", GetString(result, "event"));
        Assert.False(GetBool(result, "payload", "ok"), "Wrong token should be rejected");
    }

    [Fact] // F170d — non-admin accountId is rejected even with valid token
    public async Task AuthHandshake_NonAdminAccount_Rejected()
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(15));
        var wsClient = _factory.Server.CreateWebSocketClient();
        var socket = await wsClient.ConnectAsync(WsUri(AuthAppFactory.NonAdminAccountId, "RegularPlayer"), cts.Token);

        // Drain + attest
        await ReceiveJsonAsync(socket, cts.Token); // SOCKET_READY
        await ReceiveJsonAsync(socket, cts.Token); // GAME_MODES_UPDATED
        await SendJsonAsync(socket, new { @event = "MOD_HELLO" }, cts.Token);
        JsonElement challenge = await ReceiveJsonAsync(socket, cts.Token);
        string? nonce = GetString(challenge, "payload", "nonce");
        Assert.NotNull(nonce);
        string signature = ComputeHmac(AuthAppFactory.TestAttestationSecret, nonce, AuthAppFactory.NonAdminAccountId);
        await SendJsonAsync(socket, new { @event = "MOD_AUTH", payload = new { nonce, signature } }, cts.Token);
        await ReceiveJsonAsync(socket, cts.Token); // MOD_AUTH_OK

        // Send ADMIN_AUTH with valid token but non-admin account
        await SendJsonAsync(socket, new { @event = "ADMIN_AUTH", payload = new { token = AuthAppFactory.AdminToken } }, cts.Token);

        JsonElement result = await ReceiveJsonAsync(socket, cts.Token);
        Assert.Equal("ADMIN_AUTH_RESULT", GetString(result, "event"));
        Assert.False(GetBool(result, "payload", "ok"), "Non-admin account should be rejected");
    }

    [Fact] // F170e — MOD_AUTH without prior MOD_HELLO is rejected
    public async Task AuthHandshake_AuthWithoutHello_Rejected()
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(15));
        var wsClient = _factory.Server.CreateWebSocketClient();
        var socket = await wsClient.ConnectAsync(WsUri(AuthAppFactory.AdminAccountId, "AdminTest"), cts.Token);

        // Drain
        await ReceiveJsonAsync(socket, cts.Token); // SOCKET_READY
        await ReceiveJsonAsync(socket, cts.Token); // GAME_MODES_UPDATED

        // Send MOD_AUTH directly (no prior MOD_HELLO)
        await SendJsonAsync(socket, new { @event = "MOD_AUTH", payload = new { nonce = "fake", signature = "fake" } }, cts.Token);

        // Should get MOD_AUTH_OK with ok=false
        JsonElement result = await ReceiveJsonAsync(socket, cts.Token);
        Assert.Equal("MOD_AUTH_OK", GetString(result, "event"));
        Assert.False(GetBool(result, "payload", "ok"), "Auth without hello should be rejected");
    }

    [Fact] // F170f — MOD_HELLO sent immediately without draining initial frames
    public async Task AuthHandshake_ModHelloWithoutDrain_Succeeds()
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(15));
        var wsClient = _factory.Server.CreateWebSocketClient();
        var socket = await wsClient.ConnectAsync(WsUri(AuthAppFactory.AdminAccountId, "AdminTest"), cts.Token);

        // Send MOD_HELLO immediately — do NOT drain SOCKET_READY/GAME_MODES_UPDATED
        // first. This simulates the real AdminAuthClient behaviour.
        await SendJsonAsync(socket, new { @event = "MOD_HELLO", payload = new { version = "1.0.6" } }, cts.Token);

        // Keep reading until MOD_CHALLENGE arrives, ignoring initial frames.
        string nonce = "";
        while (true)
        {
            JsonElement resp = await ReceiveJsonAsync(socket, cts.Token);
            string? evt = GetString(resp, "event");
            if (evt == "MOD_CHALLENGE")
            {
                nonce = GetString(resp, "payload", "nonce") ?? "";
                break;
            }
            // Otherwise this is SOCKET_READY or GAME_MODES_UPDATED — ignore and continue
        }
        Assert.NotEmpty(nonce);

        // Complete the attestation handshake
        string signature = ComputeHmac(AuthAppFactory.TestAttestationSecret, nonce, AuthAppFactory.AdminAccountId);
        await SendJsonAsync(socket, new { @event = "MOD_AUTH", payload = new { nonce, signature } }, cts.Token);
        JsonElement authOk = await ReceiveJsonAsync(socket, cts.Token);
        Assert.Equal("MOD_AUTH_OK", GetString(authOk, "event"));
        Assert.True(GetBool(authOk, "payload", "ok"), "Full attestation should pass after MOD_HELLO without drain");
    }

    [Fact] // F170g — ADMIN_AUTH without prior MOD_AUTH is rejected
    public async Task AuthHandshake_AdminAuthWithoutModAuth_Rejected()
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(15));
        var wsClient = _factory.Server.CreateWebSocketClient();
        var socket = await wsClient.ConnectAsync(WsUri(AuthAppFactory.AdminAccountId, "AdminTest"), cts.Token);

        // Drain initial frames
        await ReceiveJsonAsync(socket, cts.Token); // SOCKET_READY
        await ReceiveJsonAsync(socket, cts.Token); // GAME_MODES_UPDATED

        // Send ADMIN_AUTH directly — no MOD_HELLO/MOD_AUTH first
        await SendJsonAsync(socket, new { @event = "ADMIN_AUTH", payload = new { token = AuthAppFactory.AdminToken } }, cts.Token);

        JsonElement result = await ReceiveJsonAsync(socket, cts.Token);
        Assert.Equal("ADMIN_AUTH_RESULT", GetString(result, "event"));
        Assert.False(GetBool(result, "payload", "ok"), "ADMIN_AUTH without MOD_AUTH should be rejected");
    }
}

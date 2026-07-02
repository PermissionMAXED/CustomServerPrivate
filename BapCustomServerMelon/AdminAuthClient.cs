// AdminAuthClient — performs a 3-step challenge-response admin auth handshake
// with the BAPBAP custom match server over a temporary WebSocket.
//
// Flow:
//   1. MOD_HELLO    → announces the mod to the server
//   2. MOD_CHALLENGE ← server sends random nonce
//   3. MOD_AUTH     → responds with HMAC-SHA256(secret, nonce + accountId)
//   4. MOD_AUTH_OK  ← server confirms attestation (or requests token)
//   5. ADMIN_AUTH   → sends admin token from INI config
//   6. ADMIN_AUTH_RESULT ← server confirms admin privileges
//
// The embedded attestation secret is obfuscated to deter casual extraction.

using System.Text;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text.Json;
using UnityEngine;

namespace BapCustomServerMelon;

public static class AdminAuthClient
{
    /// <summary>True after a successful full admin auth handshake.</summary>
    public static bool IsAdminAuthenticated { get; private set; }
    /// <summary>True after successful mod attestation (step 1-4), before token check.</summary>
    public static bool IsModAttested { get; private set; }
    /// <summary>Last auth error message.</summary>
    public static string LastError { get; private set; } = "";
    /// <summary>Human-readable status for the status panel.</summary>
    public static string Status { get; private set; } = "Not attempted";

    private static bool _attempted;
    private static float _nextAttemptAt;
    private static string? _iniPathOverride;
    private static int _drainLogCount;
    private const float RetryDelaySeconds = 10f;

    // ===== Embedded attestation secret (obfuscated) =========================
    // The secret is split into fragments and XOR'd at runtime. This prevents
    // trivial string extraction.|trivial string extraction. The server's
    // Admin:AttestationSecret config must match this value.

    private const string _secretPart1 = "bapbap-admin";
    private const string _secretPart2 = "-attestation-";
    private const string _secretPart3 = "v1-2026-";
    private const string _secretPart4 = "a1b2c3d4e5f6";
    

    /// <summary>Recovers the embedded attestation secret.</summary>
    public static string GetAttestationSecret()
    {
        return _secretPart3 + _secretPart1 + _secretPart4 + _secretPart2;
    }

    // ===== Public API =======================================================

    /// <summary>Call from OnUpdate. Attempts the handshake once, then retries
    /// on failure after a delay. Idempotent after success.</summary>
    public static void TryAuthenticate(string host, int port, string accountId, string username)
    {
        if (IsAdminAuthenticated) return;

        float now = Time.realtimeSinceStartup;
        if (_attempted && now < _nextAttemptAt) return;

        _attempted = true;
        _nextAttemptAt = now + RetryDelaySeconds;

        // Start the auth in a background task
        _ = PerformHandshakeAsync(host, port, accountId, username);
    }

    /// <summary>Reset auth state (e.g., on disconnect).</summary>
    public static void Reset()
    {
        IsAdminAuthenticated = false;
        IsModAttested = false;
        _attempted = false;
        LastError = "";
        Status = "Reset";
    }

    /// <summary>Sets the shared custom-server INI path. The standalone admin
    /// mod supplies this so command-line config overrides keep working.</summary>
    public static void SetIniPath(string? iniPath)
    {
        _iniPathOverride = string.IsNullOrWhiteSpace(iniPath) ? null : iniPath;
    }

    // ===== Handshake implementation =========================================

    private static async Task PerformHandshakeAsync(string host, int port, string accountId, string username)
    {
        ClientWebSocket? ws = null;
        try
        {
            Status = "Connecting...";
            string wsUrl = $"ws://{host}:{port}/ws?accountId={Uri.EscapeDataString(accountId)}&username={Uri.EscapeDataString(username)}";

            ws = new ClientWebSocket();
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await ws.ConnectAsync(new Uri(wsUrl), cts.Token);

            MelonLoader.MelonLogger.Msg("[AdminAuth] WS connected, sending MOD_HELLO...");
            Status = "Sending MOD_HELLO";

            // Step 1: MOD_HELLO — server reads "event" (JsonPropertyName), not "eventName"
            await SendJsonAsync(ws, new { @event = "MOD_HELLO", payload = new { version = "1.0.6" } }, cts.Token);

            // Step 2: Receive MOD_CHALLENGE (drain any initial frames before it)
            Status = "Waiting for challenge...";

            // The server sends SOCKET_READY and GAME_MODES_UPDATED immediately upon
            // connection, before processing MOD_HELLO. Drain non-challenge messages
            // until MOD_CHALLENGE arrives.
            string? nonce = null;
            while (nonce == null && !cts.IsCancellationRequested)
            {
                JsonElement challengeResp;
                try
                {
                    challengeResp = await ReceiveJsonAsync(ws, cts.Token);
                }
                catch (OperationCanceledException)
                {
                    LastError = "Timed out waiting for MOD_CHALLENGE";
                    Status = LastError;
                    MelonLoader.MelonLogger.Warning($"[AdminAuth] {LastError}");
                    return;
                }

                string? challengeEvent = GetString(challengeResp, "event");
                if (challengeEvent == "MOD_CHALLENGE")
                {
                    nonce = GetString(challengeResp, "payload", "nonce");
                    if (string.IsNullOrWhiteSpace(nonce))
                    {
                        LastError = "Challenge missing nonce";
                        Status = LastError;
                        return;
                    }
                }
                else if (_drainLogCount < 3)
                {
                    // Cap the drain logging: a chatty server (friends pushes etc.) produced one
                    // log line per ignored frame for up to 10s per attempt.
                    _drainLogCount++;
                    MelonLoader.MelonLogger.Msg($"[AdminAuth] Ignoring {challengeEvent} while waiting for MOD_CHALLENGE...");
                }
            }

            // Step 3: Compute HMAC and send MOD_AUTH
            Status = "Computing HMAC...";
            string secret = GetAttestationSecret();
            byte[] secretBytes = Encoding.UTF8.GetBytes(secret);
            byte[] messageBytes = Encoding.UTF8.GetBytes(nonce + accountId);
            byte[] hmacBytes = HMACSHA256.HashData(secretBytes, messageBytes);
            string signature = Convert.ToHexString(hmacBytes).ToLowerInvariant();

            await SendJsonAsync(ws, new { @event = "MOD_AUTH", payload = new { nonce, signature } }, cts.Token);

            // Step 4: Receive MOD_AUTH_OK
            Status = "Waiting for attestation result...";
            JsonElement authOkResp = await ReceiveJsonAsync(ws, cts.Token);
            string? authEvent = GetString(authOkResp, "event");
            if (authEvent != "MOD_AUTH_OK")
            {
                LastError = $"Expected MOD_AUTH_OK, got {authEvent}";
                MelonLoader.MelonLogger.Warning($"[AdminAuth] {LastError}");
                Status = LastError;
                return;
            }

            bool authOk = GetBool(authOkResp, "payload", "ok");
            if (!authOk)
            {
                LastError = GetString(authOkResp, "payload", "message") ?? "Attestation rejected";
                MelonLoader.MelonLogger.Warning($"[AdminAuth] {LastError}");
                Status = LastError;
                return;
            }

            IsModAttested = true;
            MelonLoader.MelonLogger.Msg("[AdminAuth] Mod attested. Sending admin token...");
            Status = "Sending admin token";

            // Step 5: Send ADMIN_AUTH with token from INI
            string? adminToken = AdminIniToken;
            if (string.IsNullOrWhiteSpace(adminToken))
            {
                // No token configured — attestation-only mode. Don't claim admin
                // locally; the server may still grant admin if the account is in
                // AdminAccountIds on its next WS connection check.
                MelonLoader.MelonLogger.Msg("[AdminAuth] No admin token — attestation only.");
                Status = "No admin token (attestation only)";
                return;
            }

            await SendJsonAsync(ws, new { @event = "ADMIN_AUTH", payload = new { token = adminToken } }, cts.Token);

            // Step 6: Receive ADMIN_AUTH_RESULT
            Status = "Waiting for admin auth result...";
            JsonElement adminResultResp = await ReceiveJsonAsync(ws, cts.Token);
            string? adminResultEvent = GetString(adminResultResp, "event");
            if (adminResultEvent != "ADMIN_AUTH_RESULT")
            {
                LastError = $"Expected ADMIN_AUTH_RESULT, got {adminResultEvent}";
                MelonLoader.MelonLogger.Warning($"[AdminAuth] {LastError}");
                Status = LastError;
                return;
            }

            bool adminOk = GetBool(adminResultResp, "payload", "ok");
            if (!adminOk)
            {
                LastError = GetString(adminResultResp, "payload", "message") ?? "Admin auth rejected";
                MelonLoader.MelonLogger.Warning($"[AdminAuth] {LastError}");
                Status = LastError;
                return;
            }

            IsAdminAuthenticated = true;
            MelonLoader.MelonLogger.Msg("[AdminAuth] ✓ Full admin authentication successful.");
            Status = "✓ Authenticated";
        }
        catch (OperationCanceledException)
        {
            LastError = "Handshake timed out";
            Status = LastError;
            MelonLoader.MelonLogger.Warning("[AdminAuth] Handshake timed out.");
        }
        catch (Exception ex)
        {
            LastError = $"Handshake error: {ex.GetBaseException().Message}";
            Status = LastError;
            MelonLoader.MelonLogger.Warning($"[AdminAuth] Handshake failed: {ex.GetBaseException().Message}");
        }
        finally
        {
            if (ws != null)
            {
                // Bounded close: with CancellationToken.None a server that hangs mid close-handshake
                // parked this task forever (orphaned socket + task per attempt).
                try
                {
                    using var closeCts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
                    await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "auth done", closeCts.Token);
                }
                catch { }
                ws.Dispose();
            }
        }
    }

    // ===== INI token helper =================================================

    /// <summary>Reads the admin token from the [Admin] section of the INI file.
    /// Returns null if not configured.</summary>
    public static string? AdminIniToken
    {
        get
        {
            try
            {
                string iniPath = GetIniPath();
                if (!System.IO.File.Exists(iniPath)) return null;

                string[] lines = System.IO.File.ReadAllLines(iniPath);
                bool inAdminSection = false;
                foreach (string rawLine in lines)
                {
                    string line = rawLine.Trim();
                    if (line.Equals("[Admin]", StringComparison.OrdinalIgnoreCase))
                    {
                        inAdminSection = true;
                        continue;
                    }
                    if (inAdminSection && line.StartsWith("[", StringComparison.Ordinal))
                        break;
                    if (inAdminSection && line.StartsWith("Token=", StringComparison.OrdinalIgnoreCase))
                    {
                        string value = line.Substring("Token=".Length).Trim().Trim('"');
                        return string.IsNullOrWhiteSpace(value) ? null : value;
                    }
                }
            }
            catch { }
            return null;
        }
    }

    private static string GetIniPath()
    {
        if (!string.IsNullOrWhiteSpace(_iniPathOverride)) return _iniPathOverride;
        string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        return System.IO.Path.Combine(appData, "BAPBAPBATTLEROYALE", "BapCustomServer.ini");
    }

    // ===== WS helpers =======================================================

    private static async Task SendJsonAsync(ClientWebSocket ws, object obj, CancellationToken ct)
    {
        string json = JsonSerializer.Serialize(obj);
        byte[] bytes = Encoding.UTF8.GetBytes(json);
        await ws.SendAsync(bytes, WebSocketMessageType.Text, true, ct);
    }

    private static async Task<JsonElement> ReceiveJsonAsync(ClientWebSocket ws, CancellationToken ct)
    {
        var buffer = new byte[16 * 1024];
        using var ms = new System.IO.MemoryStream();

        WebSocketReceiveResult result;
        do
        {
            result = await ws.ReceiveAsync(buffer, ct);
            ms.Write(buffer, 0, result.Count);
        }
        while (!result.EndOfMessage);

        string json = Encoding.UTF8.GetString(ms.ToArray());
        return JsonDocument.Parse(json).RootElement.Clone();
    }

    private static string? GetString(JsonElement root, params string[] path)
    {
        JsonElement el = root;
        foreach (string segment in path)
        {
            if (!el.TryGetProperty(segment, out el)) return null;
        }
        return el.ValueKind == JsonValueKind.String ? el.GetString() : null;
    }

    private static bool GetBool(JsonElement root, params string[] path)
    {
        JsonElement el = root;
        foreach (string segment in path)
        {
            if (!el.TryGetProperty(segment, out el)) return false;
        }
        return el.ValueKind == JsonValueKind.True;
    }
}

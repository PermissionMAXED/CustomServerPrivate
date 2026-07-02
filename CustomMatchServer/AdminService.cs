using Microsoft.Extensions.Options;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace BapCustomServer;

public sealed class AdminOptions
{
    public string ApiToken { get; set; } = "";
    public bool AllowLoopbackAdminWithoutToken { get; set; } = false;
    public string StateFile { get; set; } = "data/admin-state.json";
    public string AuditLogFile { get; set; } = "logs/admin-audit.jsonl";
    public string[] AdminAccountIds { get; set; } = [];
    public string AdminAccountIdsCsv { get; set; } = "";
    public string[] BannedAccountIds { get; set; } = [];
    public string BannedAccountIdsCsv { get; set; } = "";
    /// <summary>Shared secret for mod attestation challenge-response. Must match the
    /// embedded key in BapCustomServerMelon.dll. The mod proves it is genuine by
    /// computing HMAC-SHA256(secret, nonce + accountId).</summary>
    public string AttestationSecret { get; set; } = "";
}

public sealed class ServerAdminService
{
    private readonly object _sync = new();
    private readonly HashSet<string> _admins = new(StringComparer.OrdinalIgnoreCase);
    private readonly Dictionary<string, BanEntry> _bans = new(StringComparer.OrdinalIgnoreCase);
    private readonly HashSet<string> _configBanExclusions = new(StringComparer.OrdinalIgnoreCase);
    private readonly string _statePath;
    private readonly string _auditLogPath;
    private readonly ILogger<ServerAdminService> _logger;

    public ServerAdminService(
        IOptions<AdminOptions> options,
        IWebHostEnvironment environment,
        ILogger<ServerAdminService> logger)
    {
        _logger = logger;
        _statePath = ResolvePath(environment, options.Value.StateFile);
        _auditLogPath = ResolvePath(environment, options.Value.AuditLogFile);

        LoadState();
        SeedFromOptions(options.Value);
    }

    public bool IsAdmin(string? accountId)
    {
        string normalized = NormalizeAccountId(accountId);
        if (string.IsNullOrWhiteSpace(normalized))
        {
            return false;
        }

        lock (_sync)
        {
            return _admins.Contains(normalized);
        }
    }

    public bool IsBanned(string? accountId)
    {
        string normalized = NormalizeAccountId(accountId);
        if (string.IsNullOrWhiteSpace(normalized))
        {
            return false;
        }

        lock (_sync)
        {
            if (!_bans.TryGetValue(normalized, out BanEntry? ban))
            {
                return false;
            }

            if (ban.ExpiresUtc is { } expires && expires <= DateTimeOffset.UtcNow)
            {
                _bans.Remove(normalized);
                SaveStateLocked();
                Audit("ban-expired", "system", normalized, ban.Reason);
                return false;
            }

            return true;
        }
    }

    public AdminStateSnapshot GetSnapshot()
    {
        lock (_sync)
        {
            return new AdminStateSnapshot(
                _admins.Order(StringComparer.OrdinalIgnoreCase).ToArray(),
                _bans.Values.OrderBy(entry => entry.AccountId, StringComparer.OrdinalIgnoreCase).ToArray(),
                _statePath,
                _auditLogPath);
        }
    }

    public AdminMutationResult AddAdmin(string? accountId, string actor)
    {
        string normalized = NormalizeAccountId(accountId);
        if (string.IsNullOrWhiteSpace(normalized))
        {
            return new AdminMutationResult(false, "AccountId is required.");
        }

        lock (_sync)
        {
            bool changed = _admins.Add(normalized);
            SaveStateLocked();
            Audit(changed ? "admin-added" : "admin-already-present", actor, normalized, null);
            return new AdminMutationResult(true, changed ? "Admin added." : "Account was already admin.");
        }
    }

    public AdminMutationResult RemoveAdmin(string? accountId, string actor)
    {
        string normalized = NormalizeAccountId(accountId);
        if (string.IsNullOrWhiteSpace(normalized))
        {
            return new AdminMutationResult(false, "AccountId is required.");
        }

        lock (_sync)
        {
            bool changed = _admins.Remove(normalized);
            SaveStateLocked();
            Audit(changed ? "admin-removed" : "admin-not-present", actor, normalized, null);
            return new AdminMutationResult(true, changed ? "Admin removed." : "Account was not admin.");
        }
    }

    public AdminMutationResult Ban(string? accountId, string? reason, DateTimeOffset? expiresUtc, string actor)
    {
        string normalized = NormalizeAccountId(accountId);
        if (string.IsNullOrWhiteSpace(normalized))
        {
            return new AdminMutationResult(false, "AccountId is required.");
        }

        var entry = new BanEntry(
            normalized,
            string.IsNullOrWhiteSpace(reason) ? "Banned by server admin." : reason.Trim(),
            DateTimeOffset.UtcNow,
            expiresUtc,
            actor);

        lock (_sync)
        {
            _configBanExclusions.Remove(normalized);
            _bans[normalized] = entry;
            SaveStateLocked();
            Audit("account-banned", actor, normalized, entry.Reason);
            return new AdminMutationResult(true, "Account banned.");
        }
    }

    public AdminMutationResult Unban(string? accountId, string actor)
    {
        string normalized = NormalizeAccountId(accountId);
        if (string.IsNullOrWhiteSpace(normalized))
        {
            return new AdminMutationResult(false, "AccountId is required.");
        }

        lock (_sync)
        {
            bool changed = _bans.Remove(normalized);
            _configBanExclusions.Add(normalized);
            SaveStateLocked();
            Audit(changed ? "account-unbanned" : "account-not-banned", actor, normalized, null);
            return new AdminMutationResult(true, changed ? "Account unbanned." : "Account was not banned.");
        }
    }

    public string[] ReadAuditTail(int maxLines)
    {
        int limit = Math.Clamp(maxLines, 1, 1000);
        try
        {
            if (!File.Exists(_auditLogPath))
            {
                return [];
            }

            return File.ReadLines(_auditLogPath).TakeLast(limit).ToArray();
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Could not read admin audit log {AuditLogPath}.", _auditLogPath);
            return [];
        }
    }

    public void Audit(string action, string actor, string? targetAccountId, string? detail)
    {
        var entry = new AuditLogEntry(
            DateTimeOffset.UtcNow,
            action,
            string.IsNullOrWhiteSpace(actor) ? "unknown" : actor,
            NormalizeAccountId(targetAccountId),
            detail ?? "");

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_auditLogPath)!);
            string json = JsonSerializer.Serialize(entry, JsonContract.Options);
            File.AppendAllText(_auditLogPath, json + Environment.NewLine, Encoding.UTF8);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Could not append admin audit log {AuditLogPath}.", _auditLogPath);
        }
    }

    private void LoadState()
    {
        try
        {
            if (!File.Exists(_statePath))
            {
                return;
            }

            string json = File.ReadAllText(_statePath, Encoding.UTF8);
            AdminStateDocument state = JsonSerializer.Deserialize<AdminStateDocument>(json, JsonContract.Options)
                ?? throw new JsonException("The document is empty or contains JSON null.");

            foreach (string admin in (state.AdminAccountIds ?? [])
                .Select(NormalizeAccountId)
                .Where(id => !string.IsNullOrWhiteSpace(id)))
            {
                _admins.Add(admin);
            }

            foreach (BanEntry ban in (state.Bans ?? [])
                .Where(entry => !string.IsNullOrWhiteSpace(entry.AccountId)))
            {
                _bans[NormalizeAccountId(ban.AccountId)] = ban with { AccountId = NormalizeAccountId(ban.AccountId) };
            }

            foreach (string accountId in (state.ConfigBanExclusions ?? []).Select(NormalizeAccountId).Where(id => !string.IsNullOrWhiteSpace(id)))
            {
                _configBanExclusions.Add(accountId);
            }
        }
        catch (JsonException ex)
        {
            RecoverInvalidStateFile(ex);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Could not load admin state {StatePath}. Starting with configured defaults.", _statePath);
        }
    }

    private void RecoverInvalidStateFile(Exception ex)
    {
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_statePath)!);
            string backupPath = _statePath + ".invalid-" + DateTime.UtcNow.ToString("yyyyMMddHHmmss") + ".json";
            if (File.Exists(_statePath))
            {
                File.Copy(_statePath, backupPath, overwrite: false);
            }

            string json = JsonSerializer.Serialize(new AdminStateDocument([], [], []), JsonContract.PrettyOptions);
            File.WriteAllText(_statePath, json, Encoding.UTF8);
            _logger.LogWarning(
                "Invalid admin state at {StatePath} was backed up to {BackupPath} and replaced with an empty valid state; configured admin defaults will be seeded: {Message}",
                _statePath,
                backupPath,
                ex.Message);
        }
        catch (Exception recoveryEx)
        {
            _logger.LogWarning(
                recoveryEx,
                "Invalid admin state at {StatePath} could not be recovered automatically; configured admin defaults will be used in memory.",
                _statePath);
        }
    }

    private void SeedFromOptions(AdminOptions options)
    {
        bool changed = false;
        lock (_sync)
        {
            foreach (string accountId in ExpandAccountIds(options.AdminAccountIds, options.AdminAccountIdsCsv))
            {
                changed = _admins.Add(accountId) || changed;
            }

            foreach (string accountId in ExpandAccountIds(options.BannedAccountIds, options.BannedAccountIdsCsv))
            {
                if (!_bans.ContainsKey(accountId) && !_configBanExclusions.Contains(accountId))
                {
                    _bans[accountId] = new BanEntry(accountId, "Seeded from server configuration.", DateTimeOffset.UtcNow, null, "config");
                    changed = true;
                }
            }

            if (changed)
            {
                SaveStateLocked();
            }
        }
    }

    private void SaveStateLocked()
    {
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_statePath)!);
            var state = new AdminStateDocument(
                _admins.Order(StringComparer.OrdinalIgnoreCase).ToArray(),
                _bans.Values.OrderBy(entry => entry.AccountId, StringComparer.OrdinalIgnoreCase).ToArray(),
                _configBanExclusions.Order(StringComparer.OrdinalIgnoreCase).ToArray());
            string json = JsonSerializer.Serialize(state, JsonContract.PrettyOptions);
            File.WriteAllText(_statePath, json, Encoding.UTF8);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Could not save admin state {StatePath}.", _statePath);
        }
    }

    private static string ResolvePath(IWebHostEnvironment environment, string path)
    {
        if (Path.IsPathRooted(path))
        {
            return Path.GetFullPath(path);
        }

        return Path.GetFullPath(Path.Combine(environment.ContentRootPath, path));
    }

    public static string NormalizeAccountId(string? accountId)
    {
        return string.IsNullOrWhiteSpace(accountId) ? "" : accountId.Trim();
    }

    private static IEnumerable<string> ExpandAccountIds(string[] values, string csv)
    {
        foreach (string accountId in values.Select(NormalizeAccountId).Where(id => !string.IsNullOrWhiteSpace(id)))
        {
            yield return accountId;
        }

        foreach (string accountId in (csv ?? "")
            .Split([',', ';', '\r', '\n'], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(NormalizeAccountId)
            .Where(id => !string.IsNullOrWhiteSpace(id)))
        {
            yield return accountId;
        }
    }
}

public static class AdminAuth
{
    public const string TokenHeader = "X-BAP-Admin-Token";

    public static bool IsAuthorized(HttpContext context, AdminOptions options)
    {
        string provided = GetToken(context);

        if (!string.IsNullOrWhiteSpace(options.ApiToken))
        {
            return FixedTimeEquals(provided, options.ApiToken);
        }

        return options.AllowLoopbackAdminWithoutToken && IsLoopback(context);
    }

    public static string GetActor(HttpContext context)
    {
        string headerActor = context.Request.Headers["X-BAP-Admin-Actor"].FirstOrDefault() ?? "";
        if (!string.IsNullOrWhiteSpace(headerActor))
        {
            return headerActor.Trim();
        }

        string queryActor = context.Request.Query["actor"].FirstOrDefault() ?? "";
        if (!string.IsNullOrWhiteSpace(queryActor))
        {
            return queryActor.Trim();
        }

        return IsLoopback(context) ? "loopback-admin" : "remote-admin";
    }

    private static string GetToken(HttpContext context)
    {
        // Header X-BAP-Admin-Token only. Query string fallback removed to prevent
        // tokens leaking into proxy/access logs and browser history.
        string header = context.Request.Headers[TokenHeader].FirstOrDefault() ?? "";
        return header.Trim();
    }

    /// <summary>
    /// Returns true only when the connection originates from the local machine
    /// AND no proxy/forwarded headers are present. Any X-Forwarded-For,
    /// X-Real-IP, or RFC-7239 Forwarded header disqualifies the request from
    /// loopback trust, even if the connection peer is 127.0.0.1, because that
    /// peer is then a reverse proxy speaking on behalf of an external client.
    /// </summary>
    public static bool IsLoopback(HttpContext context)
    {
        IPAddress? address = context.Connection.RemoteIpAddress;
        if (address?.IsIPv4MappedToIPv6 == true)
        {
            address = address.MapToIPv4();
        }

        if (address is null || !IPAddress.IsLoopback(address))
        {
            return false;
        }

        if (HasAny(context.Request.Headers, "X-Forwarded-For") ||
            HasAny(context.Request.Headers, "X-Real-IP") ||
            HasAny(context.Request.Headers, "X-Forwarded-Host") ||
            HasAny(context.Request.Headers, "Forwarded"))
        {
            return false;
        }

        return true;
    }

    private static bool HasAny(IHeaderDictionary headers, string name)
    {
        if (!headers.TryGetValue(name, out Microsoft.Extensions.Primitives.StringValues values))
        {
            return false;
        }

        foreach (string? value in values)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                return true;
            }
        }

        return false;
    }

    public static bool FixedTimeEquals(string provided, string expected)
    {
        // Hash both sides with SHA-256 so the comparison runs on a fixed 32-byte
        // buffer regardless of input length. This eliminates the length-leak
        // implicit in CryptographicOperations.FixedTimeEquals which requires
        // equal-length inputs and otherwise short-circuits.
        byte[] providedBytes = Encoding.UTF8.GetBytes(provided ?? "");
        byte[] expectedBytes = Encoding.UTF8.GetBytes(expected ?? "");
        Span<byte> providedHash = stackalloc byte[32];
        Span<byte> expectedHash = stackalloc byte[32];
        SHA256.HashData(providedBytes, providedHash);
        SHA256.HashData(expectedBytes, expectedHash);
        return CryptographicOperations.FixedTimeEquals(providedHash, expectedHash);
    }

    /// <summary>Verify a mod-attestation HMAC. The mod embeds a shared secret and
    /// sends HMAC-SHA256(secret, nonce + accountId) as proof it is the genuine mod.
    /// Both nonce and signature are hex-encoded strings.</summary>
    public static bool VerifyModAttestation(string secret, string nonce, string accountId, string signature)
    {
        if (string.IsNullOrWhiteSpace(secret) || string.IsNullOrWhiteSpace(signature))
            return false;

        try
        {
            byte[] secretBytes = Encoding.UTF8.GetBytes(secret);
            byte[] messageBytes = Encoding.UTF8.GetBytes(nonce + accountId);

            byte[] computed = HMACSHA256.HashData(secretBytes, messageBytes);
            byte[] provided = Convert.FromHexString(signature);

            return CryptographicOperations.FixedTimeEquals(computed, provided);
        }
        catch
        {
            return false;
        }
    }

    /// <summary>Generate a random nonce for the attestation challenge.</summary>
    public static string GenerateNonce()
    {
        Span<byte> bytes = stackalloc byte[32];
        RandomNumberGenerator.Fill(bytes);
        return Convert.ToHexString(bytes).ToLowerInvariant();
    }
}

public static class ClientIdentityResolver
{
    public static ClientIdentity Resolve(HttpContext context, string fallbackAccountId, string fallbackUsername, int fallbackDiscriminator)
    {
        string accountId = FirstNonEmpty(
            context.Request.Headers["X-BAP-AccountId"].FirstOrDefault(),
            context.Request.Headers["X-BAP-UserId"].FirstOrDefault(),
            context.Request.Query["accountId"].FirstOrDefault(),
            context.Request.Query["userId"].FirstOrDefault(),
            TryReadBapCustomSession(context.Request.Cookies["sid"]),
            fallbackAccountId);

        string username = FirstNonEmpty(
            context.Request.Headers["X-BAP-Username"].FirstOrDefault(),
            context.Request.Query["username"].FirstOrDefault(),
            fallbackUsername);

        int discriminator = fallbackDiscriminator;
        string discriminatorText = FirstNonEmpty(
            context.Request.Headers["X-BAP-Discriminator"].FirstOrDefault(),
            context.Request.Query["discriminator"].FirstOrDefault());
        if (int.TryParse(discriminatorText, out int parsed))
        {
            discriminator = parsed;
        }

        return new ClientIdentity(
            ServerAdminService.NormalizeAccountId(accountId),
            string.IsNullOrWhiteSpace(username) ? fallbackUsername : username.Trim(),
            discriminator);
    }

    private static string FirstNonEmpty(params string?[] values)
    {
        foreach (string? value in values)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                return value.Trim();
            }
        }

        return "";
    }

    private static string? TryReadBapCustomSession(string? sessionId)
    {
        const string prefix = "bapcustom-";
        if (string.IsNullOrWhiteSpace(sessionId) ||
            !sessionId.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
        {
            return null;
        }

        return sessionId[prefix.Length..].Trim();
    }
}

public sealed record ClientIdentity(string AccountId, string Username, int Discriminator);

public sealed record AdminStateDocument(string[] AdminAccountIds, BanEntry[] Bans, string[] ConfigBanExclusions);

public sealed record AdminStateSnapshot(string[] AdminAccountIds, BanEntry[] Bans, string StateFile, string AuditLogFile);

public sealed record BanEntry(string AccountId, string Reason, DateTimeOffset CreatedUtc, DateTimeOffset? ExpiresUtc, string Source);

public sealed record AdminMutationResult(bool Ok, string Message);

public sealed record AuditLogEntry(DateTimeOffset TimestampUtc, string Action, string Actor, string TargetAccountId, string Detail);

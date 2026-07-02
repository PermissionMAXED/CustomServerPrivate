using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace BapCustomServer;

// ===== Options ============================================================

public sealed class PlayerOverridesOptions
{
    public string StateFile { get; set; } = "data/player-overrides.json";
}

// ===== Config models ======================================================

/// <summary>One custom shop item in a per-player shop override.</summary>
public sealed class PlayerShopItemOverride
{
    /// <summary>Unique id for this listing, e.g. "custom-sonic-300005".</summary>
    public string? ListingId { get; set; }

    /// <summary>The BAPBAP asset id being sold.</summary>
    public int AssetId { get; set; }

    /// <summary>Gold price. 0 = free.</summary>
    public int Price { get; set; }

    /// <summary>Category hint for the shop UI: "skin", "emote", "banner", "masterybadge", "tombstone".</summary>
    public string? Category { get; set; }
}

/// <summary>Per-player shop override. When <c>overrideGlobal</c> is true the global shop
/// is replaced entirely; otherwise custom items are merged into the global rotation.</summary>
public sealed class PlayerShopOverride
{
    public bool OverrideGlobal { get; set; }
    public PlayerShopItemOverride[]? Items { get; set; }
}

/// <summary>Settings that apply per player (or as defaults). Every field is nullable
/// so the merge logic can distinguish "not set" from "explicitly empty".</summary>
public sealed class PlayerOverrideEntry
{
    // === Identity ===
    public string? Username { get; set; }

    // === Economy ===
    public int? Gold { get; set; }
    public int? Fractals { get; set; }
    public int? CharTokens { get; set; }

    // === Unlock master switches ===
    public bool? UnlockEverything { get; set; }
    public bool? UnlockAllSkins { get; set; }
    public bool? UnlockAllEmotes { get; set; }
    public bool? UnlockAllBanners { get; set; }
    public bool? UnlockAllMasteryBadges { get; set; }
    public bool? UnlockAllTombstones { get; set; }

    // === Per-character toggles ===
    /// <summary>Explicit list of enabled character ids.
    /// Empty array = no characters unlocked. null = fall through to global default.</summary>
    public int[]? EnabledCharacterIds { get; set; }

    // === Extra assets ===
    /// <summary>Asset ids to additionally report as owned for this player.</summary>
    public int[]? ExtraOwnedAssetIds { get; set; }

    // === Custom shop ===
    public PlayerShopOverride? Shop { get; set; }
}

/// <summary>Root config document for <c>data/player-overrides.json</c>.</summary>
public sealed class PlayerOverridesDocument
{
    /// <summary>Applied to every player not listed in <c>players</c>.</summary>
    public PlayerOverrideEntry Defaults { get; set; } = new();

    /// <summary>Per-accountId overrides.</summary>
    public Dictionary<string, PlayerOverrideEntry> Players { get; set; } = new(StringComparer.OrdinalIgnoreCase);
}

// ===== Service ============================================================

/// <summary>
/// Loads <c>data/player-overrides.json</c> on startup, watches for changes,
/// and provides per-account merge lookups.
///
/// Config is hot-reloaded on file change (polled via FileSystemWatcher).
/// </summary>
public sealed class PlayerOverridesService
{
    private readonly string _filePath;
    private readonly ILogger<PlayerOverridesService> _logger;
    private PlayerOverridesDocument _doc = new();
    private readonly object _lock = new();
    private FileSystemWatcher? _watcher;
    private DateTime _lastFileChange = DateTime.MinValue;

    private static readonly JsonSerializerOptions ReadOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public PlayerOverridesService(IOptions<PlayerOverridesOptions> options, ILogger<PlayerOverridesService> logger)
    {
        _filePath = ResolvePath(options.Value.StateFile);
        _logger = logger;
        LoadDoc(recoverInvalidFile: true);
        StartWatching();
    }

    private static string ResolvePath(string path)
    {
        if (Path.IsPathRooted(path)) return path;
        return Path.Combine(AppContext.BaseDirectory, path);
    }

    private void StartWatching()
    {
        try
        {
            string dir = Path.GetDirectoryName(_filePath) ?? ".";
            string file = Path.GetFileName(_filePath);
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

            // Touch the file if it doesn't exist yet so the admin knows where to write.
            if (!File.Exists(_filePath))
            {
                WriteDefaultDocumentFile();
                _logger.LogInformation("Created default player-overrides at {Path}", _filePath);
            }

            _watcher = new FileSystemWatcher(dir, file)
            {
                EnableRaisingEvents = true,
                NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName
            };
            _watcher.Changed += (_, _) => ReloadOnChange();
            _watcher.Created += (_, _) => ReloadOnChange();
            _logger.LogInformation("Watching player-overrides at {Path}", _filePath);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "File watching for player-overrides not available; config is read-once.");
        }
    }

    private void ReloadOnChange()
    {
        try
        {
            var now = DateTime.UtcNow;
            if ((now - _lastFileChange).TotalMilliseconds < 1500) return; // debounce
            _lastFileChange = now;
            LoadDoc();
            _logger.LogInformation("Player-overrides hot-reloaded from {Path}", _filePath);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to hot-reload player-overrides from {Path}", _filePath);
        }
    }

    public void LoadDoc(bool recoverInvalidFile = false)
    {
        try
        {
            if (!File.Exists(_filePath))
            {
                lock (_lock) { _doc = CreateDefaultDocument(); }
                return;
            }

            string json = File.ReadAllText(_filePath, Encoding.UTF8);
            var doc = JsonSerializer.Deserialize<PlayerOverridesDocument>(json, ReadOptions)
                ?? throw new JsonException("The document is empty or contains JSON null.");

            NormalizeDocument(doc);
            lock (_lock) { _doc = doc; }
        }
        catch (JsonException ex) when (recoverInvalidFile)
        {
            RecoverInvalidFile(ex);
        }
        catch (JsonException ex)
        {
            // A file-system change may be observed while an administrator is still saving the file.
            // Keep the last known good settings instead of replacing them with a locked-down default.
            _logger.LogWarning("Ignoring invalid player-overrides at {Path}: {Message}", _filePath, ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to load player-overrides from {Path}; keeping the last known good settings.", _filePath);
        }
    }

    private static PlayerOverridesDocument CreateDefaultDocument()
    {
        return new PlayerOverridesDocument
        {
            // No Gold here (see WriteDefaultDocumentFile): a defaults-level gold override froze
            // every account's balance and made the earn/spend economy a no-op.
            Defaults = new PlayerOverrideEntry
            {
                UnlockEverything = true,
                UnlockAllSkins = true,
                UnlockAllEmotes = true,
                UnlockAllBanners = true,
                UnlockAllMasteryBadges = true,
                UnlockAllTombstones = true,
                EnabledCharacterIds = CharacterCatalog.AllIds.ToArray()
            },
            Players = new Dictionary<string, PlayerOverrideEntry>(StringComparer.OrdinalIgnoreCase)
        };
    }

    private static void NormalizeDocument(PlayerOverridesDocument doc)
    {
        doc.Defaults ??= new PlayerOverrideEntry();
        doc.Players = doc.Players is null
            ? new Dictionary<string, PlayerOverrideEntry>(StringComparer.OrdinalIgnoreCase)
            : new Dictionary<string, PlayerOverrideEntry>(doc.Players, StringComparer.OrdinalIgnoreCase);
    }

    private void RecoverInvalidFile(JsonException ex)
    {
        string backupPath = _filePath + ".invalid-" + DateTime.UtcNow.ToString("yyyyMMddHHmmss") + ".json";

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_filePath) ?? ".");
            File.Copy(_filePath, backupPath, overwrite: false);
            WriteDefaultDocumentFile();

            lock (_lock) { _doc = CreateDefaultDocument(); }
            _logger.LogWarning(
                "Invalid player-overrides at {Path} was backed up to {BackupPath} and replaced with unlocked defaults: {Message}",
                _filePath,
                backupPath,
                ex.Message);
        }
        catch (Exception recoveryEx)
        {
            _logger.LogWarning(
                recoveryEx,
                "Invalid player-overrides at {Path} could not be recovered automatically; using in-memory unlocked defaults.",
                _filePath);
            lock (_lock) { _doc = CreateDefaultDocument(); }
        }
    }

    private void WriteDefaultDocumentFile()
    {
        // NOTE: deliberately NO "gold" in defaults. EconomyService.GetGold treats a non-null
        // override as absolute truth, so a defaults-level gold pinned EVERY account to that value
        // forever — match rewards and shop purchases changed nothing. Per-player gold overrides
        // (players.<accountId>.gold) still work as documented.
        const string defaultJson = /*lang=json*/ """
{
  "defaults": {
    "unlockEverything": true,
    "unlockAllSkins": true,
    "unlockAllEmotes": true,
    "unlockAllBanners": true,
    "unlockAllMasteryBadges": true,
    "unlockAllTombstones": true,
    "enabledCharacterIds": [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]
  },
  "players": {}
}
""";
        File.WriteAllText(_filePath, defaultJson, Encoding.UTF8);
    }

    // ===== Public lookups =================================================

    /// <summary>Get the raw entry for a specific account, or null.</summary>
    public PlayerOverrideEntry? GetPlayer(string accountId)
    {
        lock (_lock)
        {
            return _doc.Players.TryGetValue(accountId, out var entry) ? entry : null;
        }
    }

    /// <summary>Merge player + defaults into one effective entry.</summary>
    public PlayerOverrideEntry GetEffective(string accountId)
    {
        lock (_lock)
        {
            var player = GetPlayer(accountId);
            var d = _doc.Defaults;
            return new PlayerOverrideEntry
            {
                Username           = player?.Username         ?? d.Username,
                Gold               = player?.Gold             ?? d.Gold,
                Fractals           = player?.Fractals         ?? d.Fractals,
                CharTokens         = player?.CharTokens       ?? d.CharTokens,
                UnlockEverything   = player?.UnlockEverything ?? d.UnlockEverything,
                UnlockAllSkins     = player?.UnlockAllSkins   ?? d.UnlockAllSkins,
                UnlockAllEmotes   = player?.UnlockAllEmotes  ?? d.UnlockAllEmotes,
                UnlockAllBanners  = player?.UnlockAllBanners  ?? d.UnlockAllBanners,
                UnlockAllMasteryBadges = player?.UnlockAllMasteryBadges ?? d.UnlockAllMasteryBadges,
                UnlockAllTombstones    = player?.UnlockAllTombstones    ?? d.UnlockAllTombstones,
                EnabledCharacterIds    = player?.EnabledCharacterIds    ?? d.EnabledCharacterIds,
                ExtraOwnedAssetIds     = player?.ExtraOwnedAssetIds     ?? d.ExtraOwnedAssetIds,
                Shop = player?.Shop ?? d.Shop,
            };
        }
    }

    /// <summary>Returns the resolved set of enabled character ids for this player.</summary>
    public int[] GetEnabledCharacterIds(string accountId)
    {
        var e = GetEffective(accountId);
        if (e.EnabledCharacterIds is { Length: > 0 }) return e.EnabledCharacterIds;
        return CharacterCatalog.AllIds;
    }

    /// <summary>Check whether a specific character is enabled for this player.</summary>
    public bool IsCharacterEnabled(string accountId, int charId)
    {
        return Array.IndexOf(GetEnabledCharacterIds(accountId), charId) >= 0;
    }

    /// <summary>Resolve a per-player unlock flag, falling back to server defaults.</summary>
    public bool ResolveFlag(string accountId, Func<PlayerOverrideEntry, bool?> pick, bool serverDefault)
    {
        var e = GetEffective(accountId);
        bool? val = pick(e);
        if (val.HasValue) return val.Value;
        if (e.UnlockEverything == true) return true;
        return serverDefault;
    }

    /// <summary>Get per-player shop override, or null if none.</summary>
    public PlayerShopOverride? GetShopOverride(string accountId)
    {
        var e = GetEffective(accountId);
        return e.Shop;
    }

    /// <summary>Get per-player extra owned assets.</summary>
    public int[] GetExtraOwnedAssetIds(string accountId)
    {
        var e = GetEffective(accountId);
        return e.ExtraOwnedAssetIds ?? [];
    }

    /// <summary>Get per-player gold override, or null.</summary>
    public int? GetGoldOverride(string accountId)
    {
        return GetEffective(accountId).Gold;
    }

    /// <summary>Get per-player charTokens override, or null.</summary>
    public int? GetCharTokensOverride(string accountId)
    {
        return GetEffective(accountId).CharTokens;
    }

    /// <summary>Get per-player username override, or null.</summary>
    public string? GetUsernameOverride(string accountId)
    {
        return GetEffective(accountId).Username;
    }
}

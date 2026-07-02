using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace BapCustomServer;

public sealed class PlayerStorageOptions
{
    public string PlayersDirectory { get; set; } = "data/players";
    public int StartingGold { get; set; } = 1000;
}

public sealed class StoredPlayerData
{
    // Identity
    public string AccountId { get; set; } = "";
    public string Username { get; set; } = "";
    public int Discriminator { get; set; }

    // Security
    public string SecretHash { get; set; } = "";  // SHA256(secret+salt)
    public string SecretSalt { get; set; } = "";  // random salt

    // Economy
    public int Gold { get; set; }
    public List<int> OwnedAssetIds { get; set; } = [];

    // Stats
    public int TotalGamesPlayed { get; set; }
    public int TotalKills { get; set; }
    public int TotalDeaths { get; set; }
    public int TotalAssists { get; set; }
    public int TotalWins { get; set; }
    public int TotalDamageDealt { get; set; }
    public int TotalGoldEarned { get; set; }
    public int TotalGoldSpent { get; set; }

    // Ranked
    public int RankedPoints { get; set; }
    public int RankedPeakPoints { get; set; }
    public int RankedGamesPlayed { get; set; }
    public int RankedWins { get; set; }

    // Loadout (equipped items)
    public int EquippedBannerId { get; set; }
    public int[] EquippedSkins { get; set; } = [];  // per character

    // Metadata
    public DateTimeOffset CreatedUtc { get; set; }
    public DateTimeOffset LastLoginUtc { get; set; }
    public DateTimeOffset LastMatchUtc { get; set; }
    public string LastIpAddress { get; set; } = "";
    public bool IsBanned { get; set; }
    public string BanReason { get; set; } = "";
}

public sealed class PlayerIndex
{
    // Username (lowercase) → AccountId
    public Dictionary<string, string> UsernameToAccountId { get; set; } = new(StringComparer.OrdinalIgnoreCase);
}

public sealed class PlayerStorageService
{
    private readonly SemaphoreSlim _lock = new(1, 1);
    private readonly string _playersDir;
    private readonly PlayerStorageOptions _options;
    private readonly ILogger<PlayerStorageService> _logger;

    private PlayerIndex _index = new();

    public PlayerStorageService(IOptions<PlayerStorageOptions> options, ILogger<PlayerStorageService> logger)
    {
        _options = options.Value;
        _logger = logger;
        _playersDir = ResolvePath(_options.PlayersDirectory);
        Directory.CreateDirectory(_playersDir);
        LoadIndex();
        RebuildIndexFromDisk();
    }

    // === Account Management ===

    public StoredPlayerData GetOrCreatePlayer(string accountId, string username, int discriminator)
    {
        if (string.IsNullOrWhiteSpace(accountId)) throw new ArgumentException("accountId is required.");

        _lock.Wait();
        try
        {
            StoredPlayerData? existing = LoadPlayerFromDisk(accountId);
            if (existing is not null)
            {
                // Update username/discriminator if changed
                if (!string.Equals(existing.Username, username, StringComparison.Ordinal) || existing.Discriminator != discriminator)
                {
                    // Remove old username from index
                    string oldKey = existing.Username.ToLowerInvariant();
                    if (_index.UsernameToAccountId.ContainsKey(oldKey))
                        _index.UsernameToAccountId.Remove(oldKey);

                    existing.Username = username;
                    existing.Discriminator = discriminator;
                    SavePlayerToDisk(existing);
                }

                // Ensure index is up to date
                _index.UsernameToAccountId[username.ToLowerInvariant()] = accountId;
                SaveIndexToDisk();
                return existing;
            }

            // Create new player
            var player = new StoredPlayerData
            {
                AccountId = accountId,
                Username = username,
                Discriminator = discriminator,
                Gold = _options.StartingGold,
                CreatedUtc = DateTimeOffset.UtcNow,
                LastLoginUtc = DateTimeOffset.UtcNow
            };

            string playerDir = Path.Combine(_playersDir, accountId);
            Directory.CreateDirectory(playerDir);
            SavePlayerToDisk(player);

            _index.UsernameToAccountId[username.ToLowerInvariant()] = accountId;
            SaveIndexToDisk();

            _logger.LogInformation("Created new player: {AccountId} ({Username}#{Discriminator}) with {Gold}g.",
                accountId, username, discriminator, _options.StartingGold);

            return player;
        }
        finally
        {
            _lock.Release();
        }
    }

    public StoredPlayerData? GetPlayer(string accountId)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return null;

        _lock.Wait();
        try
        {
            return LoadPlayerFromDisk(accountId);
        }
        finally
        {
            _lock.Release();
        }
    }

    public StoredPlayerData? GetPlayerByUsername(string username)
    {
        if (string.IsNullOrWhiteSpace(username)) return null;

        _lock.Wait();
        try
        {
            if (!_index.UsernameToAccountId.TryGetValue(username.ToLowerInvariant(), out string? accountId))
                return null;

            return LoadPlayerFromDisk(accountId);
        }
        finally
        {
            _lock.Release();
        }
    }

    public bool ValidateSecret(string accountId, string providedSecret)
    {
        if (string.IsNullOrWhiteSpace(accountId) || string.IsNullOrWhiteSpace(providedSecret)) return false;

        _lock.Wait();
        try
        {
            StoredPlayerData? player = LoadPlayerFromDisk(accountId);
            if (player is null) return false;

            // No secret set — cannot validate (caller should use GenerateAndSetSecret)
            if (string.IsNullOrEmpty(player.SecretHash)) return false;

            string computedHash = ComputeHash(providedSecret, player.SecretSalt);
            return string.Equals(computedHash, player.SecretHash, StringComparison.Ordinal);
        }
        finally
        {
            _lock.Release();
        }
    }

    public string GenerateAndSetSecret(string accountId)
    {
        if (string.IsNullOrWhiteSpace(accountId)) throw new ArgumentException("accountId is required.");

        _lock.Wait();
        try
        {
            StoredPlayerData? player = LoadPlayerFromDisk(accountId);
            if (player is null) throw new InvalidOperationException($"Player not found: {accountId}");

            string secret = RandomNumberGenerator.GetHexString(32);
            string salt = RandomNumberGenerator.GetHexString(16);
            string hash = ComputeHash(secret, salt);

            player.SecretHash = hash;
            player.SecretSalt = salt;
            SavePlayerToDisk(player);

            _logger.LogInformation("Generated new secret for player {AccountId}.", accountId);
            return secret;
        }
        finally
        {
            _lock.Release();
        }
    }

    public void ResetSecret(string accountId, string actor)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return;

        _lock.Wait();
        try
        {
            StoredPlayerData? player = LoadPlayerFromDisk(accountId);
            if (player is null) return;

            player.SecretHash = "";
            player.SecretSalt = "";
            SavePlayerToDisk(player);

            _logger.LogInformation("Secret reset for player {AccountId} by {Actor}.", accountId, actor);
        }
        finally
        {
            _lock.Release();
        }
    }

    // === Economy ===

    public int GetGold(string accountId)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return 0;

        _lock.Wait();
        try
        {
            StoredPlayerData? player = LoadPlayerFromDisk(accountId);
            return player?.Gold ?? 0;
        }
        finally
        {
            _lock.Release();
        }
    }

    public bool AddGold(string accountId, int amount, string reason)
    {
        if (string.IsNullOrWhiteSpace(accountId) || amount <= 0) return false;

        _lock.Wait();
        try
        {
            StoredPlayerData? player = LoadPlayerFromDisk(accountId);
            if (player is null) return false;

            player.Gold += amount;
            player.TotalGoldEarned += amount;
            SavePlayerToDisk(player);

            _logger.LogDebug("Added {Amount}g to {AccountId}: {Reason}. New balance: {Gold}g.",
                amount, accountId, reason, player.Gold);
            return true;
        }
        finally
        {
            _lock.Release();
        }
    }

    public bool RemoveGold(string accountId, int amount, string reason)
    {
        if (string.IsNullOrWhiteSpace(accountId) || amount <= 0) return false;

        _lock.Wait();
        try
        {
            StoredPlayerData? player = LoadPlayerFromDisk(accountId);
            if (player is null) return false;
            if (player.Gold < amount) return false;

            player.Gold -= amount;
            player.TotalGoldSpent += amount;
            SavePlayerToDisk(player);

            _logger.LogDebug("Removed {Amount}g from {AccountId}: {Reason}. New balance: {Gold}g.",
                amount, accountId, reason, player.Gold);
            return true;
        }
        finally
        {
            _lock.Release();
        }
    }

    public bool PurchaseAsset(string accountId, int assetId, int price)
    {
        if (string.IsNullOrWhiteSpace(accountId) || price < 0) return false;

        _lock.Wait();
        try
        {
            StoredPlayerData? player = LoadPlayerFromDisk(accountId);
            if (player is null) return false;
            if (player.Gold < price) return false;
            if (player.OwnedAssetIds.Contains(assetId)) return false;

            player.Gold -= price;
            player.TotalGoldSpent += price;
            player.OwnedAssetIds.Add(assetId);
            SavePlayerToDisk(player);

            _logger.LogInformation("Player {AccountId} purchased asset {AssetId} for {Price}g.",
                accountId, assetId, price);
            return true;
        }
        finally
        {
            _lock.Release();
        }
    }

    public bool GrantAsset(string accountId, int assetId)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return false;

        _lock.Wait();
        try
        {
            StoredPlayerData? player = LoadPlayerFromDisk(accountId);
            if (player is null) return false;
            if (player.OwnedAssetIds.Contains(assetId)) return false;

            player.OwnedAssetIds.Add(assetId);
            SavePlayerToDisk(player);

            _logger.LogInformation("Granted asset {AssetId} to player {AccountId}.", assetId, accountId);
            return true;
        }
        finally
        {
            _lock.Release();
        }
    }

    public bool RevokeAsset(string accountId, int assetId)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return false;

        _lock.Wait();
        try
        {
            StoredPlayerData? player = LoadPlayerFromDisk(accountId);
            if (player is null) return false;
            if (!player.OwnedAssetIds.Contains(assetId)) return false;

            player.OwnedAssetIds.Remove(assetId);
            SavePlayerToDisk(player);

            _logger.LogInformation("Revoked asset {AssetId} from player {AccountId}.", assetId, accountId);
            return true;
        }
        finally
        {
            _lock.Release();
        }
    }

    public bool HasAsset(string accountId, int assetId)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return false;

        _lock.Wait();
        try
        {
            StoredPlayerData? player = LoadPlayerFromDisk(accountId);
            return player?.OwnedAssetIds.Contains(assetId) ?? false;
        }
        finally
        {
            _lock.Release();
        }
    }

    public int[] GetOwnedAssets(string accountId)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return [];

        _lock.Wait();
        try
        {
            StoredPlayerData? player = LoadPlayerFromDisk(accountId);
            return player?.OwnedAssetIds.ToArray() ?? [];
        }
        finally
        {
            _lock.Release();
        }
    }

    // === Stats ===

    public void RecordMatchResult(string accountId, int kills, int deaths, int assists, int damageDealt, int placement, int goldEarned, int rankedPointsDelta)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return;

        _lock.Wait();
        try
        {
            StoredPlayerData? player = LoadPlayerFromDisk(accountId);
            if (player is null) return;

            player.TotalGamesPlayed++;
            player.TotalKills += kills;
            player.TotalDeaths += deaths;
            player.TotalAssists += assists;
            player.TotalDamageDealt += damageDealt;
            player.TotalGoldEarned += goldEarned;
            player.Gold += goldEarned;
            player.LastMatchUtc = DateTimeOffset.UtcNow;

            if (placement == 1)
                player.TotalWins++;

            // Ranked
            if (rankedPointsDelta != 0)
            {
                player.RankedGamesPlayed++;
                player.RankedPoints += rankedPointsDelta;
                if (player.RankedPoints < 0) player.RankedPoints = 0;
                if (player.RankedPoints > player.RankedPeakPoints)
                    player.RankedPeakPoints = player.RankedPoints;
                if (placement == 1)
                    player.RankedWins++;
            }

            SavePlayerToDisk(player);

            _logger.LogDebug("Recorded match for {AccountId}: K{Kills}/D{Deaths}/A{Assists}, placement {Placement}, +{Gold}g.",
                accountId, kills, deaths, assists, placement, goldEarned);
        }
        finally
        {
            _lock.Release();
        }
    }

    // === Ranked ===

    public int GetRankedPoints(string accountId)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return 0;

        _lock.Wait();
        try
        {
            StoredPlayerData? player = LoadPlayerFromDisk(accountId);
            return player?.RankedPoints ?? 0;
        }
        finally
        {
            _lock.Release();
        }
    }

    public void SetRankedPoints(string accountId, int points)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return;

        _lock.Wait();
        try
        {
            StoredPlayerData? player = LoadPlayerFromDisk(accountId);
            if (player is null) return;

            player.RankedPoints = points;
            if (points > player.RankedPeakPoints)
                player.RankedPeakPoints = points;

            SavePlayerToDisk(player);
        }
        finally
        {
            _lock.Release();
        }
    }

    // === Admin ===

    public void RenamePlayer(string accountId, string newUsername, string actor)
    {
        if (string.IsNullOrWhiteSpace(accountId) || string.IsNullOrWhiteSpace(newUsername)) return;

        _lock.Wait();
        try
        {
            StoredPlayerData? player = LoadPlayerFromDisk(accountId);
            if (player is null) return;

            string oldKey = player.Username.ToLowerInvariant();
            if (_index.UsernameToAccountId.ContainsKey(oldKey))
                _index.UsernameToAccountId.Remove(oldKey);

            string oldUsername = player.Username;
            player.Username = newUsername;
            SavePlayerToDisk(player);

            _index.UsernameToAccountId[newUsername.ToLowerInvariant()] = accountId;
            SaveIndexToDisk();

            _logger.LogInformation("Player {AccountId} renamed from '{OldName}' to '{NewName}' by {Actor}.",
                accountId, oldUsername, newUsername, actor);
        }
        finally
        {
            _lock.Release();
        }
    }

    public void BanPlayer(string accountId, string reason, string actor)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return;

        _lock.Wait();
        try
        {
            StoredPlayerData? player = LoadPlayerFromDisk(accountId);
            if (player is null) return;

            player.IsBanned = true;
            player.BanReason = reason ?? "";
            SavePlayerToDisk(player);

            _logger.LogWarning("Player {AccountId} banned by {Actor}. Reason: {Reason}.", accountId, actor, reason);
        }
        finally
        {
            _lock.Release();
        }
    }

    public void UnbanPlayer(string accountId, string actor)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return;

        _lock.Wait();
        try
        {
            StoredPlayerData? player = LoadPlayerFromDisk(accountId);
            if (player is null) return;

            player.IsBanned = false;
            player.BanReason = "";
            SavePlayerToDisk(player);

            _logger.LogInformation("Player {AccountId} unbanned by {Actor}.", accountId, actor);
        }
        finally
        {
            _lock.Release();
        }
    }

    public void WipePlayer(string accountId, string actor)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return;

        _lock.Wait();
        try
        {
            StoredPlayerData? player = LoadPlayerFromDisk(accountId);
            if (player is not null)
            {
                string key = player.Username.ToLowerInvariant();
                if (_index.UsernameToAccountId.ContainsKey(key))
                    _index.UsernameToAccountId.Remove(key);
            }

            string playerDir = Path.Combine(_playersDir, accountId);
            if (Directory.Exists(playerDir))
            {
                Directory.Delete(playerDir, recursive: true);
            }

            SaveIndexToDisk();
            _logger.LogWarning("Player {AccountId} wiped by {Actor}.", accountId, actor);
        }
        finally
        {
            _lock.Release();
        }
    }

    public StoredPlayerData[] ListAllPlayers()
    {
        _lock.Wait();
        try
        {
            var players = new List<StoredPlayerData>();

            if (!Directory.Exists(_playersDir)) return [];

            foreach (string dir in Directory.GetDirectories(_playersDir))
            {
                string playerFile = Path.Combine(dir, "player.json");
                if (!File.Exists(playerFile)) continue;

                try
                {
                    string json = File.ReadAllText(playerFile, Encoding.UTF8);
                    StoredPlayerData? player = JsonSerializer.Deserialize<StoredPlayerData>(json, JsonContract.Options);
                    if (player is not null)
                        players.Add(player);
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Failed to read player file: {Path}", playerFile);
                }
            }

            return players.ToArray();
        }
        finally
        {
            _lock.Release();
        }
    }

    public string? LookupAccountId(string username)
    {
        if (string.IsNullOrWhiteSpace(username)) return null;

        _lock.Wait();
        try
        {
            return _index.UsernameToAccountId.TryGetValue(username.ToLowerInvariant(), out string? accountId)
                ? accountId
                : null;
        }
        finally
        {
            _lock.Release();
        }
    }

    // === Persistence ===

    public void SavePlayer(StoredPlayerData player)
    {
        if (player is null) return;

        _lock.Wait();
        try
        {
            SavePlayerToDisk(player);
        }
        finally
        {
            _lock.Release();
        }
    }

    public void SaveIndex()
    {
        _lock.Wait();
        try
        {
            SaveIndexToDisk();
        }
        finally
        {
            _lock.Release();
        }
    }

    // === Private Helpers ===

    private StoredPlayerData? LoadPlayerFromDisk(string accountId)
    {
        string playerFile = Path.Combine(_playersDir, accountId, "player.json");
        if (!File.Exists(playerFile)) return null;

        try
        {
            string json = File.ReadAllText(playerFile, Encoding.UTF8);
            return JsonSerializer.Deserialize<StoredPlayerData>(json, JsonContract.Options);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to load player {AccountId} from disk.", accountId);
            return null;
        }
    }

    private void SavePlayerToDisk(StoredPlayerData player)
    {
        try
        {
            string playerDir = Path.Combine(_playersDir, player.AccountId);
            Directory.CreateDirectory(playerDir);

            string playerFile = Path.Combine(playerDir, "player.json");
            string json = JsonSerializer.Serialize(player, JsonContract.PrettyOptions);
            string tmpPath = playerFile + ".tmp";
            File.WriteAllText(tmpPath, json, Encoding.UTF8);
            File.Move(tmpPath, playerFile, overwrite: true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to save player {AccountId} to disk.", player.AccountId);
        }
    }

    private void LoadIndex()
    {
        string indexPath = Path.Combine(_playersDir, "index.json");
        try
        {
            if (!File.Exists(indexPath))
            {
                _logger.LogInformation("Player index not found at {Path}. Starting fresh.", indexPath);
                return;
            }

            string json = File.ReadAllText(indexPath, Encoding.UTF8);
            PlayerIndex? loaded = JsonSerializer.Deserialize<PlayerIndex>(json, JsonContract.Options);
            if (loaded is not null)
            {
                _index = loaded;
                _logger.LogInformation("Loaded player index: {Count} entries.", _index.UsernameToAccountId.Count);
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Could not load player index from {Path}. Will rebuild.", indexPath);
            _index = new PlayerIndex();
        }
    }

    private void RebuildIndexFromDisk()
    {
        if (!Directory.Exists(_playersDir)) return;

        bool changed = false;

        foreach (string dir in Directory.GetDirectories(_playersDir))
        {
            string playerFile = Path.Combine(dir, "player.json");
            if (!File.Exists(playerFile)) continue;

            try
            {
                string json = File.ReadAllText(playerFile, Encoding.UTF8);
                StoredPlayerData? player = JsonSerializer.Deserialize<StoredPlayerData>(json, JsonContract.Options);
                if (player is null || string.IsNullOrWhiteSpace(player.Username)) continue;

                string key = player.Username.ToLowerInvariant();
                if (!_index.UsernameToAccountId.ContainsKey(key))
                {
                    _index.UsernameToAccountId[key] = player.AccountId;
                    changed = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to read player file during index rebuild: {Path}", playerFile);
            }
        }

        if (changed)
        {
            SaveIndexToDisk();
            _logger.LogInformation("Rebuilt player index: {Count} entries.", _index.UsernameToAccountId.Count);
        }
    }

    private void SaveIndexToDisk()
    {
        try
        {
            string indexPath = Path.Combine(_playersDir, "index.json");
            string json = JsonSerializer.Serialize(_index, JsonContract.PrettyOptions);
            string tmpPath = indexPath + ".tmp";
            File.WriteAllText(tmpPath, json, Encoding.UTF8);
            File.Move(tmpPath, indexPath, overwrite: true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to save player index.");
        }
    }

    private static string ComputeHash(string secret, string salt)
    {
        byte[] input = Encoding.UTF8.GetBytes(secret + salt);
        byte[] hash = SHA256.HashData(input);
        return Convert.ToHexString(hash).ToLowerInvariant();
    }

    private static string ResolvePath(string path)
    {
        if (Path.IsPathRooted(path))
        {
            return Path.GetFullPath(path);
        }

        return Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), path));
    }
}

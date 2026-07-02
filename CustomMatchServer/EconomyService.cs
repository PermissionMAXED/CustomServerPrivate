using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace BapCustomServer;

public sealed class EconomyOptions
{
    public string StateFile { get; set; } = "data/economy-state.json";
    public int StartingGold { get; set; } = 1000;
    public int WinGold { get; set; } = 500;
    public int KillGold { get; set; } = 50;
    public int[] PlacementGold { get; set; } = [500, 350, 250, 200, 150, 100, 75, 50];
    public string PlacementGoldCsv { get; set; } = "";
    public int ParticipationGold { get; set; } = 25;
    public int StartingCharTokens { get; set; } = 10;
}

public sealed class PlayerEconomyState
{
    public string AccountId { get; set; } = "";
    public string Username { get; set; } = "";
    public int Gold { get; set; }
    public int TotalGamesPlayed { get; set; }
    public int TotalKills { get; set; }
    public int TotalWins { get; set; }
    public int TotalGoldEarned { get; set; }
    public int TotalGoldSpent { get; set; }
    public int CharTokens { get; set; }
    public int TotalCharTokensEarned { get; set; }
    public int TotalCharTokensSpent { get; set; }
    public List<int> OwnedAssetIds { get; set; } = [];
    public Dictionary<int, CharacterMasteryProgress> CharacterMastery { get; set; } = [];
    public DateTimeOffset CreatedUtc { get; set; }
    public DateTimeOffset LastPlayedUtc { get; set; }
}

public sealed class EconomyStateDocument
{
    public Dictionary<string, PlayerEconomyState> Players { get; set; } = new(StringComparer.OrdinalIgnoreCase);
}

public sealed record EconomyResult(bool Ok, string Message, int? NewBalance = null);

public sealed record CharacterPurchaseResult(
    bool Ok,
    string Message,
    int CharId,
    int Price,
    int NewCharTokenBalance,
    bool AlreadyOwned,
    int[] GrantedAssetIds);

public sealed class CharacterMasteryProgress
{
    public int CharId { get; set; }
    public int Xp { get; set; }
    public int CurrentLevel { get; set; } = 1;
    public int CurrentXp { get; set; }
    public int CurrentXpNeeded { get; set; } = 100;
    public int PrevCurrentLevel { get; set; } = 1;
    public int PrevCurrentXp { get; set; }
    public List<int> ClaimedLevels { get; set; } = [];
    public List<int> UnlockedBadgeAssetIds { get; set; } = [];
    public DateTimeOffset UpdatedUtc { get; set; }
}

public sealed class MatchRewardResult
{
    public string AccountId { get; set; } = "";
    public int PlacementGold { get; set; }
    public int KillGold { get; set; }
    public int ParticipationGold { get; set; }
    public int TotalGold { get; set; }
    public int Placement { get; set; }
    public int Kills { get; set; }
}

public sealed class EconomyService
{
    private readonly SemaphoreSlim _lock = new(1, 1);
    private readonly string _statePath;
    private readonly EconomyOptions _options;
    private readonly PlayerOverridesService? _overrides;
    private readonly ILogger<EconomyService> _logger;

    private EconomyStateDocument _state = new();

    public EconomyService(IOptions<EconomyOptions> options, ILogger<EconomyService> logger, PlayerOverridesService? overrides = null)
    {
        _options = options.Value;
        _logger = logger;
        _overrides = overrides;
        _statePath = ResolvePath(_options.StateFile);
        LoadState();
    }

    // === Player State ===

    public PlayerEconomyState GetOrCreatePlayer(string accountId, string username)
    {
        if (string.IsNullOrWhiteSpace(accountId))
            throw new ArgumentException("Account ID cannot be empty.", nameof(accountId));

        _lock.Wait();
        try
        {
            if (_state.Players.TryGetValue(accountId, out PlayerEconomyState? existing))
            {
                bool changed = false;
                if (!string.IsNullOrWhiteSpace(username) && !string.Equals(existing.Username, username, StringComparison.Ordinal))
                {
                    existing.Username = username;
                    changed = true;
                }
                if (existing.CharTokens == 0 && existing.TotalCharTokensEarned == 0 && _options.StartingCharTokens > 0)
                {
                    existing.CharTokens = Math.Max(0, _options.StartingCharTokens);
                    existing.TotalCharTokensEarned = existing.CharTokens;
                    changed = true;
                }
                if (changed) SaveState();
                return existing;
            }

            // Check PlayerOverrides for initial gold
            int initialGold = _options.StartingGold;
            if (_overrides != null)
            {
                int? overrideGold = _overrides.GetGoldOverride(accountId);
                if (overrideGold.HasValue)
                    initialGold = overrideGold.Value;
            }

            var player = new PlayerEconomyState
            {
                AccountId = accountId,
                Username = username,
                Gold = initialGold,
                TotalGoldEarned = initialGold,
                CharTokens = Math.Max(0, _options.StartingCharTokens),
                TotalCharTokensEarned = Math.Max(0, _options.StartingCharTokens),
                CreatedUtc = DateTimeOffset.UtcNow,
                LastPlayedUtc = DateTimeOffset.UtcNow
            };

            _state.Players[accountId] = player;
            SaveState();

            _logger.LogInformation("Created new economy profile for {AccountId} ({Username}) with {Gold} starting gold.",
                accountId, username, initialGold);

            return player;
        }
        finally
        {
            _lock.Release();
        }
    }

    public int GetGold(string accountId)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return 0;

        // PlayerOverrides gold always wins if set
        if (_overrides != null)
        {
            int? overrideGold = _overrides.GetGoldOverride(accountId);
            if (overrideGold.HasValue)
                return overrideGold.Value;
        }

        _lock.Wait();
        try
        {
            if (_state.Players.TryGetValue(accountId, out PlayerEconomyState? player))
                return player.Gold;
            return 0;
        }
        finally
        {
            _lock.Release();
        }
    }

    /// <summary>Get char token balance. Checks PlayerOverrides first, then persisted economy currency.</summary>
    public int GetCharTokens(string accountId)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return 0;

        // PlayerOverrides charTokens always wins if set
        if (_overrides != null)
        {
            int? overrideTokens = _overrides.GetCharTokensOverride(accountId);
            if (overrideTokens.HasValue)
                return overrideTokens.Value;
        }

        _lock.Wait();
        try
        {
            if (_state.Players.TryGetValue(accountId, out PlayerEconomyState? player))
                return player.CharTokens;
            return 0;
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
            if (_state.Players.TryGetValue(accountId, out PlayerEconomyState? player))
                return player.OwnedAssetIds.Contains(assetId);
            return false;
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
            if (_state.Players.TryGetValue(accountId, out PlayerEconomyState? player))
                return player.OwnedAssetIds.ToArray();
            return [];
        }
        finally
        {
            _lock.Release();
        }
    }

    public bool HasAnyAsset(string accountId, IEnumerable<int> assetIds)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return false;
        int[] ids = assetIds.Distinct().ToArray();
        if (ids.Length == 0) return false;

        _lock.Wait();
        try
        {
            return _state.Players.TryGetValue(accountId, out PlayerEconomyState? player) &&
                   ids.Any(player.OwnedAssetIds.Contains);
        }
        finally
        {
            _lock.Release();
        }
    }

    // === Transactions ===

    public EconomyResult AddCharTokens(string accountId, int amount, string reason)
    {
        if (string.IsNullOrWhiteSpace(accountId))
            return new EconomyResult(false, "Invalid account ID.");

        if (amount <= 0)
            return new EconomyResult(false, "Amount must be positive.");

        _lock.Wait();
        try
        {
            if (!_state.Players.TryGetValue(accountId, out PlayerEconomyState? player))
                return new EconomyResult(false, "Player not found. Call GetOrCreatePlayer first.");

            player.CharTokens = (int)Math.Min((long)player.CharTokens + amount, int.MaxValue);
            player.TotalCharTokensEarned = (int)Math.Min((long)player.TotalCharTokensEarned + amount, int.MaxValue);
            SaveState();

            _logger.LogInformation("Added {Amount} char token(s) to {AccountId} ({Username}). Reason: {Reason}. New balance: {Balance}.",
                amount, accountId, player.Username, reason, player.CharTokens);

            return new EconomyResult(true, $"Added {amount} char token(s). Reason: {reason}", player.CharTokens);
        }
        finally
        {
            _lock.Release();
        }
    }

    public EconomyResult SetCharTokens(string accountId, int amount, string reason)
    {
        if (string.IsNullOrWhiteSpace(accountId))
            return new EconomyResult(false, "Invalid account ID.");

        if (amount < 0)
            return new EconomyResult(false, "Amount cannot be negative.");

        _lock.Wait();
        try
        {
            if (!_state.Players.TryGetValue(accountId, out PlayerEconomyState? player))
                return new EconomyResult(false, "Player not found. Call GetOrCreatePlayer first.");

            int old = player.CharTokens;
            player.CharTokens = amount;
            if (amount > old)
                player.TotalCharTokensEarned = (int)Math.Min((long)player.TotalCharTokensEarned + (amount - old), int.MaxValue);
            else if (amount < old)
                player.TotalCharTokensSpent = (int)Math.Min((long)player.TotalCharTokensSpent + (old - amount), int.MaxValue);
            SaveState();

            _logger.LogInformation("Set char tokens for {AccountId} ({Username}) from {Old} to {New}. Reason: {Reason}.",
                accountId, player.Username, old, amount, reason);

            return new EconomyResult(true, $"Set char tokens from {old} to {amount}. Reason: {reason}", player.CharTokens);
        }
        finally
        {
            _lock.Release();
        }
    }

    public CharacterPurchaseResult PurchaseCharacter(string accountId, string username, int charId, int price, int[] unlockAssetIds, string reason)
    {
        if (string.IsNullOrWhiteSpace(accountId))
            return new CharacterPurchaseResult(false, "Invalid account ID.", charId, price, 0, false, []);
        if (!CharacterCatalog.IsKnownId(charId))
            return new CharacterPurchaseResult(false, $"Unknown character id {charId}.", charId, price, GetCharTokens(accountId), false, []);
        if (price < 0)
            return new CharacterPurchaseResult(false, "Price cannot be negative.", charId, price, GetCharTokens(accountId), false, []);

        int[] grants = unlockAssetIds.Where(id => id >= 0).Distinct().ToArray();
        if (grants.Length == 0)
            grants = CharacterUnlockService.UnlockAssetIdsFor(charId);

        _lock.Wait();
        try
        {
            if (!_state.Players.TryGetValue(accountId, out PlayerEconomyState? player))
            {
                player = new PlayerEconomyState
                {
                    AccountId = accountId,
                    Username = username,
                    Gold = _options.StartingGold,
                    TotalGoldEarned = _options.StartingGold,
                    CharTokens = Math.Max(0, _options.StartingCharTokens),
                    TotalCharTokensEarned = Math.Max(0, _options.StartingCharTokens),
                    CreatedUtc = DateTimeOffset.UtcNow,
                    LastPlayedUtc = DateTimeOffset.UtcNow
                };
                _state.Players[accountId] = player;
            }

            if (!string.IsNullOrWhiteSpace(username) && !string.Equals(player.Username, username, StringComparison.Ordinal))
            {
                player.Username = username;
            }

            bool alreadyOwned = grants.Any(player.OwnedAssetIds.Contains);
            if (alreadyOwned)
            {
                foreach (int grant in grants)
                {
                    if (!player.OwnedAssetIds.Contains(grant)) player.OwnedAssetIds.Add(grant);
                }
                SaveState();
                return new CharacterPurchaseResult(true, "Character already unlocked.", charId, price, player.CharTokens, true, grants);
            }

            if (player.CharTokens < price)
            {
                return new CharacterPurchaseResult(false,
                    $"Insufficient char tokens. Current balance: {player.CharTokens}, price: {price}.",
                    charId, price, player.CharTokens, false, []);
            }

            player.CharTokens -= price;
            player.TotalCharTokensSpent += price;
            foreach (int grant in grants)
            {
                if (!player.OwnedAssetIds.Contains(grant)) player.OwnedAssetIds.Add(grant);
            }
            player.LastPlayedUtc = DateTimeOffset.UtcNow;
            SaveState();

            _logger.LogInformation("Player {AccountId} ({Username}) purchased character {CharId} for {Price} char token(s). New balance: {Balance}. Reason: {Reason}.",
                accountId, player.Username, charId, price, player.CharTokens, reason);

            return new CharacterPurchaseResult(true, $"Purchased character {charId}.", charId, price, player.CharTokens, false, grants);
        }
        finally
        {
            _lock.Release();
        }
    }

    public EconomyResult AddGold(string accountId, int amount, string reason)
    {
        if (string.IsNullOrWhiteSpace(accountId))
            return new EconomyResult(false, "Invalid account ID.");

        if (amount <= 0)
            return new EconomyResult(false, "Amount must be positive.");

        _lock.Wait();
        try
        {
            if (!_state.Players.TryGetValue(accountId, out PlayerEconomyState? player))
                return new EconomyResult(false, "Player not found. Call GetOrCreatePlayer first.");

            player.Gold += amount;
            player.TotalGoldEarned += amount;
            SaveState();

            _logger.LogInformation("Added {Amount} gold to {AccountId} ({Username}). Reason: {Reason}. New balance: {Balance}.",
                amount, accountId, player.Username, reason, player.Gold);

            return new EconomyResult(true, $"Added {amount} gold. Reason: {reason}", player.Gold);
        }
        finally
        {
            _lock.Release();
        }
    }

    public EconomyResult RemoveGold(string accountId, int amount, string reason)
    {
        if (string.IsNullOrWhiteSpace(accountId))
            return new EconomyResult(false, "Invalid account ID.");

        if (amount <= 0)
            return new EconomyResult(false, "Amount must be positive.");

        _lock.Wait();
        try
        {
            if (!_state.Players.TryGetValue(accountId, out PlayerEconomyState? player))
                return new EconomyResult(false, "Player not found.");

            if (player.Gold < amount)
                return new EconomyResult(false, $"Insufficient gold. Current balance: {player.Gold}, required: {amount}.", player.Gold);

            player.Gold -= amount;
            player.TotalGoldSpent += amount;
            SaveState();

            _logger.LogInformation("Removed {Amount} gold from {AccountId} ({Username}). Reason: {Reason}. New balance: {Balance}.",
                amount, accountId, player.Username, reason, player.Gold);

            return new EconomyResult(true, $"Removed {amount} gold. Reason: {reason}", player.Gold);
        }
        finally
        {
            _lock.Release();
        }
    }

    public EconomyResult PurchaseAsset(string accountId, int assetId, int price)
    {
        if (string.IsNullOrWhiteSpace(accountId))
            return new EconomyResult(false, "Invalid account ID.");

        if (price < 0)
            return new EconomyResult(false, "Price cannot be negative.");

        _lock.Wait();
        try
        {
            if (!_state.Players.TryGetValue(accountId, out PlayerEconomyState? player))
                return new EconomyResult(false, "Player not found.");

            if (player.OwnedAssetIds.Contains(assetId))
                return new EconomyResult(false, "You already own this asset.", player.Gold);

            if (player.Gold < price)
                return new EconomyResult(false, $"Insufficient gold. Current balance: {player.Gold}, price: {price}.", player.Gold);

            player.Gold -= price;
            player.TotalGoldSpent += price;
            player.OwnedAssetIds.Add(assetId);
            SaveState();

            _logger.LogInformation("Player {AccountId} ({Username}) purchased asset {AssetId} for {Price} gold. New balance: {Balance}.",
                accountId, player.Username, assetId, price, player.Gold);

            return new EconomyResult(true, $"Purchased asset {assetId} for {price} gold.", player.Gold);
        }
        finally
        {
            _lock.Release();
        }
    }

    public EconomyResult GrantAsset(string accountId, int assetId, string reason)
    {
        if (string.IsNullOrWhiteSpace(accountId))
            return new EconomyResult(false, "Invalid account ID.");

        _lock.Wait();
        try
        {
            if (!_state.Players.TryGetValue(accountId, out PlayerEconomyState? player))
                return new EconomyResult(false, "Player not found.");

            if (player.OwnedAssetIds.Contains(assetId))
                return new EconomyResult(false, "Player already owns this asset.", player.Gold);

            player.OwnedAssetIds.Add(assetId);
            SaveState();

            _logger.LogInformation("Granted asset {AssetId} to {AccountId} ({Username}). Reason: {Reason}.",
                assetId, accountId, player.Username, reason);

            return new EconomyResult(true, $"Granted asset {assetId}. Reason: {reason}", player.Gold);
        }
        finally
        {
            _lock.Release();
        }
    }

    public EconomyResult RevokeAsset(string accountId, int assetId, string reason)
    {
        if (string.IsNullOrWhiteSpace(accountId))
            return new EconomyResult(false, "Invalid account ID.");

        _lock.Wait();
        try
        {
            if (!_state.Players.TryGetValue(accountId, out PlayerEconomyState? player))
                return new EconomyResult(false, "Player not found.");

            if (!player.OwnedAssetIds.Contains(assetId))
                return new EconomyResult(false, "Player does not own this asset.", player.Gold);

            player.OwnedAssetIds.Remove(assetId);
            SaveState();

            _logger.LogInformation("Revoked asset {AssetId} from {AccountId} ({Username}). Reason: {Reason}.",
                assetId, accountId, player.Username, reason);

            return new EconomyResult(true, $"Revoked asset {assetId}. Reason: {reason}", player.Gold);
        }
        finally
        {
            _lock.Release();
        }
    }

    // === Match Rewards ===

    public MatchRewardResult CalculateMatchReward(string accountId, int placement, int kills, int totalPlayers)
    {
        int placementGold = 0;
        if (placement >= 1 && _options.PlacementGold.Length > 0)
        {
            int index = Math.Min(placement - 1, _options.PlacementGold.Length - 1);
            placementGold = _options.PlacementGold[index];
        }

        int killGold = kills * _options.KillGold;
        int participationGold = _options.ParticipationGold;
        int totalGold = placementGold + killGold + participationGold;

        return new MatchRewardResult
        {
            AccountId = accountId,
            PlacementGold = placementGold,
            KillGold = killGold,
            ParticipationGold = participationGold,
            TotalGold = totalGold,
            Placement = placement,
            Kills = kills
        };
    }

    public void ApplyMatchRewards(MatchRewardResult reward)
    {
        if (reward is null || string.IsNullOrWhiteSpace(reward.AccountId))
            return;

        _lock.Wait();
        try
        {
            if (!_state.Players.TryGetValue(reward.AccountId, out PlayerEconomyState? player))
            {
                _logger.LogWarning("Cannot apply match rewards: player {AccountId} not found.", reward.AccountId);
                return;
            }

            player.Gold += reward.TotalGold;
            player.TotalGoldEarned += reward.TotalGold;
            player.TotalGamesPlayed++;
            player.TotalKills += reward.Kills;
            player.LastPlayedUtc = DateTimeOffset.UtcNow;

            if (reward.Placement == 1)
                player.TotalWins++;

            SaveState();

            _logger.LogInformation(
                "Match rewards applied for {AccountId} ({Username}): placement={Placement} kills={Kills} " +
                "gold=+{TotalGold} (placement:{PlacementGold} kills:{KillGold} participation:{ParticipationGold}). New balance: {Balance}.",
                reward.AccountId, player.Username, reward.Placement, reward.Kills,
                reward.TotalGold, reward.PlacementGold, reward.KillGold, reward.ParticipationGold, player.Gold);
        }
        finally
        {
            _lock.Release();
        }
    }

    public CharacterMasteryProgress RecordCharacterXp(string accountId, string username, int charId, int xp, string reason)
    {
        if (string.IsNullOrWhiteSpace(accountId))
            throw new ArgumentException("Account ID cannot be empty.", nameof(accountId));

        if (!CharacterCatalog.IsKnownId(charId))
            throw new ArgumentOutOfRangeException(nameof(charId), charId, "Unknown character id.");

        xp = Math.Max(0, xp);

        _lock.Wait();
        try
        {
            if (!_state.Players.TryGetValue(accountId, out PlayerEconomyState? player))
            {
                player = new PlayerEconomyState
                {
                    AccountId = accountId,
                    Username = username,
                    Gold = _options.StartingGold,
                    TotalGoldEarned = _options.StartingGold,
                    CharTokens = Math.Max(0, _options.StartingCharTokens),
                    TotalCharTokensEarned = Math.Max(0, _options.StartingCharTokens),
                    CreatedUtc = DateTimeOffset.UtcNow,
                    LastPlayedUtc = DateTimeOffset.UtcNow
                };
                _state.Players[accountId] = player;
            }

            if (!string.IsNullOrWhiteSpace(username) && !string.Equals(player.Username, username, StringComparison.Ordinal))
            {
                player.Username = username;
            }

            if (!player.CharacterMastery.TryGetValue(charId, out CharacterMasteryProgress? progress))
            {
                progress = CreateDefaultCharacterMasteryProgress(charId);
                player.CharacterMastery[charId] = progress;
            }

            progress.PrevCurrentLevel = progress.CurrentLevel;
            progress.PrevCurrentXp = progress.CurrentXp;
            progress.Xp += xp;
            RecalculateCharacterMastery(progress);
            progress.UpdatedUtc = DateTimeOffset.UtcNow;
            player.LastPlayedUtc = DateTimeOffset.UtcNow;

            SaveState();

            _logger.LogInformation(
                "Character mastery XP applied for {AccountId} ({Username}): charId={CharId} xp=+{Xp} total={TotalXp} level={Level}. Reason: {Reason}.",
                accountId,
                player.Username,
                charId,
                xp,
                progress.Xp,
                progress.CurrentLevel,
                reason);

            return CloneCharacterMasteryProgress(progress);
        }
        finally
        {
            _lock.Release();
        }
    }

    public CharacterMasteryProgress GetCharacterMasteryProgress(string accountId, int charId)
    {
        if (!CharacterCatalog.IsKnownId(charId))
            return CreateDefaultCharacterMasteryProgress(charId);

        if (string.IsNullOrWhiteSpace(accountId))
            return CreateDefaultCharacterMasteryProgress(charId);

        _lock.Wait();
        try
        {
            if (_state.Players.TryGetValue(accountId, out PlayerEconomyState? player) &&
                player.CharacterMastery.TryGetValue(charId, out CharacterMasteryProgress? progress))
            {
                return CloneCharacterMasteryProgress(progress);
            }
        }
        finally
        {
            _lock.Release();
        }

        return CreateDefaultCharacterMasteryProgress(charId);
    }

    public CharacterMasteryProgress[] GetAllCharacterMastery(string accountId)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return [];

        _lock.Wait();
        try
        {
            if (!_state.Players.TryGetValue(accountId, out PlayerEconomyState? player))
            {
                return [];
            }

            return player.CharacterMastery.Values
                .OrderBy(progress => progress.CharId)
                .Select(CloneCharacterMasteryProgress)
                .ToArray();
        }
        finally
        {
            _lock.Release();
        }
    }

    // === Admin ===

    public EconomyResult AdminSetGold(string accountId, int amount, string actor)
    {
        if (string.IsNullOrWhiteSpace(accountId))
            return new EconomyResult(false, "Invalid account ID.");

        if (amount < 0)
            return new EconomyResult(false, "Amount cannot be negative.");

        _lock.Wait();
        try
        {
            if (!_state.Players.TryGetValue(accountId, out PlayerEconomyState? player))
                return new EconomyResult(false, "Player not found.");

            int oldGold = player.Gold;
            player.Gold = amount;

            if (amount > oldGold)
                player.TotalGoldEarned += (amount - oldGold);

            SaveState();

            _logger.LogInformation("Admin {Actor} set gold for {AccountId} ({Username}) from {OldGold} to {NewGold}.",
                actor, accountId, player.Username, oldGold, amount);

            return new EconomyResult(true, $"Set gold from {oldGold} to {amount}.", player.Gold);
        }
        finally
        {
            _lock.Release();
        }
    }

    public EconomyResult AdminGiveGold(string accountId, int amount, string actor)
    {
        if (string.IsNullOrWhiteSpace(accountId))
            return new EconomyResult(false, "Invalid account ID.");

        if (amount == 0)
            return new EconomyResult(false, "Amount cannot be zero.");

        _lock.Wait();
        try
        {
            if (!_state.Players.TryGetValue(accountId, out PlayerEconomyState? player))
                return new EconomyResult(false, "Player not found.");

            int oldGold = player.Gold;
            long newGold = (long)oldGold + amount;

            if (amount > 0)
            {
                player.TotalGoldEarned = (int)Math.Min((long)player.TotalGoldEarned + amount, int.MaxValue);
            }
            else
            {
                // Count only the gold actually removed, not the requested amount, so an
                // over-draw clamped to zero doesn't inflate TotalGoldSpent past what the
                // player ever held. Cast before Math.Abs so int.MinValue is safe.
                long removed = Math.Min(Math.Abs((long)amount), Math.Max(0, (long)oldGold));
                player.TotalGoldSpent = (int)Math.Min((long)player.TotalGoldSpent + removed, int.MaxValue);
            }

            player.Gold = (int)Math.Clamp(newGold, 0, int.MaxValue);

            SaveState();

            _logger.LogInformation("Admin {Actor} gave {Amount} gold to {AccountId} ({Username}). New balance: {Balance}.",
                actor, amount, accountId, player.Username, player.Gold);

            return new EconomyResult(true, $"Gave {amount} gold. New balance: {player.Gold}.", player.Gold);
        }
        finally
        {
            _lock.Release();
        }
    }

    public PlayerEconomyState[] GetAllPlayers()
    {
        _lock.Wait();
        try
        {
            return _state.Players.Values.ToArray();
        }
        finally
        {
            _lock.Release();
        }
    }

    public PlayerEconomyState[] GetLeaderboard(int top)
    {
        if (top <= 0) top = 10;

        _lock.Wait();
        try
        {
            return _state.Players.Values
                .OrderByDescending(p => p.Gold)
                .Take(top)
                .ToArray();
        }
        finally
        {
            _lock.Release();
        }
    }

    // === Private Helpers ===

    private void LoadState()
    {
        try
        {
            if (!File.Exists(_statePath))
            {
                _logger.LogInformation("Economy state file not found at {Path}. Starting fresh.", _statePath);
                return;
            }

            string json = File.ReadAllText(_statePath, Encoding.UTF8);
            EconomyStateDocument? loaded = JsonSerializer.Deserialize<EconomyStateDocument>(json, JsonContract.Options);
            if (loaded is not null)
            {
                _state = loaded;
                _logger.LogInformation("Loaded economy state: {PlayerCount} players.", _state.Players.Count);
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Could not load economy state from {Path}. Starting fresh.", _statePath);
            _state = new EconomyStateDocument();
        }
    }

    private void SaveState()
    {
        try
        {
            string? directory = Path.GetDirectoryName(_statePath);
            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string json = JsonSerializer.Serialize(_state, JsonContract.PrettyOptions);
            string tmpPath = _statePath + ".tmp";
            File.WriteAllText(tmpPath, json, Encoding.UTF8);
            File.Move(tmpPath, _statePath, overwrite: true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to save economy state to {Path}.", _statePath);
        }
    }

    private static CharacterMasteryProgress CreateDefaultCharacterMasteryProgress(int charId)
    {
        var progress = new CharacterMasteryProgress
        {
            CharId = charId,
            UpdatedUtc = DateTimeOffset.UtcNow
        };
        RecalculateCharacterMastery(progress);
        return progress;
    }

    private static void RecalculateCharacterMastery(CharacterMasteryProgress progress)
    {
        progress.Xp = Math.Max(0, progress.Xp);
        progress.CurrentLevel = Math.Clamp((progress.Xp / 100) + 1, 1, 100);
        int levelBaseXp = (progress.CurrentLevel - 1) * 100;
        progress.CurrentXp = progress.CurrentLevel >= 100 ? 100 : progress.Xp - levelBaseXp;
        progress.CurrentXpNeeded = progress.CurrentLevel >= 100 ? 0 : 100;
    }

    private static CharacterMasteryProgress CloneCharacterMasteryProgress(CharacterMasteryProgress progress)
    {
        return new CharacterMasteryProgress
        {
            CharId = progress.CharId,
            Xp = progress.Xp,
            CurrentLevel = progress.CurrentLevel,
            CurrentXp = progress.CurrentXp,
            CurrentXpNeeded = progress.CurrentXpNeeded,
            PrevCurrentLevel = progress.PrevCurrentLevel,
            PrevCurrentXp = progress.PrevCurrentXp,
            ClaimedLevels = progress.ClaimedLevels.ToList(),
            UnlockedBadgeAssetIds = progress.UnlockedBadgeAssetIds.ToList(),
            UpdatedUtc = progress.UpdatedUtc
        };
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

using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace BapCustomServer;

public sealed class RankedOptions
{
    public string StateFile { get; set; } = "data/ranked-state.json";
    public int StartingPoints { get; set; } = 1000;
    public int[] PlacementPoints { get; set; } = [100, 70, 50, 40, 30, 20, 15, 10]; // index 0 = 1st
    public string PlacementPointsCsv { get; set; } = "";
    public int KillPoints { get; set; } = 15;
    public int MinPointsFloor { get; set; } = 0; // can't go below this
    public int LossPoints { get; set; } = -20; // deducted for last place / being eliminated early
}

public sealed class PlayerRankedState
{
    public string AccountId { get; set; } = "";
    public string Username { get; set; } = "";
    public int Points { get; set; }
    public int PeakPoints { get; set; }
    public int GamesPlayed { get; set; }
    public int Wins { get; set; }
    public int TotalKills { get; set; }
    public DateTimeOffset LastMatchUtc { get; set; }
}

public sealed class RankedStateDocument
{
    public Dictionary<string, PlayerRankedState> Players { get; set; } = new(StringComparer.OrdinalIgnoreCase);
}

public sealed class RankedMatchResult
{
    public string AccountId { get; set; } = "";
    public int PreviousPoints { get; set; }
    public int NewPoints { get; set; }
    public int PointsDelta { get; set; }
    public int PlacementPoints { get; set; }
    public int KillPoints { get; set; }
    public int Placement { get; set; }
    public int Kills { get; set; }
    public bool IsPromotion { get; set; } // crossed a 500-point tier boundary upward
    public bool IsDemotion { get; set; }  // crossed a 500-point tier boundary downward
}

public sealed class RankedService
{
    private readonly SemaphoreSlim _lock = new(1, 1);
    private readonly string _statePath;
    private readonly RankedOptions _options;
    private readonly ILogger<RankedService> _logger;

    private RankedStateDocument _state = new();

    public RankedService(IOptions<RankedOptions> options, ILogger<RankedService> logger)
    {
        _options = options.Value;
        _logger = logger;
        _statePath = ResolvePath(_options.StateFile);
        LoadState();
    }

    // === Player State ===

    public PlayerRankedState GetOrCreatePlayer(string accountId, string username)
    {
        if (string.IsNullOrWhiteSpace(accountId))
            throw new ArgumentException("Account ID is required.", nameof(accountId));

        _lock.Wait();
        try
        {
            if (_state.Players.TryGetValue(accountId, out PlayerRankedState? existing))
            {
                if (!string.IsNullOrWhiteSpace(username))
                    existing.Username = username;
                return existing;
            }

            var player = new PlayerRankedState
            {
                AccountId = accountId,
                Username = username,
                Points = _options.StartingPoints,
                PeakPoints = _options.StartingPoints
            };

            _state.Players[accountId] = player;
            SaveState();
            _logger.LogInformation("Created ranked profile for {AccountId} ({Username}) with {Points} starting points.",
                accountId, username, _options.StartingPoints);
            return player;
        }
        finally
        {
            _lock.Release();
        }
    }

    // === Match Processing ===

    public RankedMatchResult ProcessMatchResult(string accountId, string username, int placement, int kills, int totalPlayers)
    {
        if (string.IsNullOrWhiteSpace(accountId))
            throw new ArgumentException("Account ID is required.", nameof(accountId));

        _lock.Wait();
        try
        {
            PlayerRankedState player = GetOrCreatePlayerInternal(accountId, username);

            int previousPoints = player.Points;
            int previousTier = GetRankTier(previousPoints);

            // Calculate placement points
            int placementPts = 0;
            int placementIndex = placement - 1; // convert 1-based to 0-based

            if (placementIndex >= 0 && placementIndex < _options.PlacementPoints.Length)
            {
                placementPts = _options.PlacementPoints[placementIndex];
            }
            else if (placement > _options.PlacementPoints.Length)
            {
                // Player placed outside the points range - apply loss points
                placementPts = _options.LossPoints;
            }

            // Calculate kill points
            int killPts = kills * _options.KillPoints;

            // Total delta
            int delta = placementPts + killPts;

            // Apply points with floor
            int newPoints = Math.Max(_options.MinPointsFloor, player.Points + delta);

            // Update player state
            player.Points = newPoints;
            player.GamesPlayed++;
            player.TotalKills += kills;
            player.LastMatchUtc = DateTimeOffset.UtcNow;

            if (newPoints > player.PeakPoints)
                player.PeakPoints = newPoints;

            if (placement == 1)
                player.Wins++;

            int newTier = GetRankTier(newPoints);

            var result = new RankedMatchResult
            {
                AccountId = accountId,
                PreviousPoints = previousPoints,
                NewPoints = newPoints,
                PointsDelta = newPoints - previousPoints,
                PlacementPoints = placementPts,
                KillPoints = killPts,
                Placement = placement,
                Kills = kills,
                IsPromotion = newTier > previousTier,
                IsDemotion = newTier < previousTier
            };

            SaveState();

            _logger.LogInformation(
                "Ranked result for {AccountId}: placement={Placement}/{Total}, kills={Kills}, " +
                "delta={Delta} ({PrevPoints} -> {NewPoints}), tier {PrevTier} -> {NewTier}",
                accountId, placement, totalPlayers, kills,
                result.PointsDelta, previousPoints, newPoints, previousTier, newTier);

            return result;
        }
        finally
        {
            _lock.Release();
        }
    }

    // === Leaderboard ===

    public PlayerRankedState[] GetLeaderboard(int top, int offset = 0)
    {
        _lock.Wait();
        try
        {
            return _state.Players.Values
                .OrderByDescending(p => p.Points)
                .ThenByDescending(p => p.Wins)
                .ThenByDescending(p => p.TotalKills)
                .Skip(offset)
                .Take(top)
                .ToArray();
        }
        finally
        {
            _lock.Release();
        }
    }

    public int GetPlayerPosition(string accountId)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return -1;

        _lock.Wait();
        try
        {
            var sorted = _state.Players.Values
                .OrderByDescending(p => p.Points)
                .ThenByDescending(p => p.Wins)
                .ThenByDescending(p => p.TotalKills)
                .ToList();

            for (int i = 0; i < sorted.Count; i++)
            {
                if (string.Equals(sorted[i].AccountId, accountId, StringComparison.OrdinalIgnoreCase))
                    return i + 1; // 1-based position
            }

            return -1; // not found
        }
        finally
        {
            _lock.Release();
        }
    }

    // === Rank Tiers ===

    public static int GetRankTier(int points)
    {
        // Every 500 points = new tier, capped at Master (6)
        // 0 = Unranked (0-499)
        // 1 = Bronze (500-999)
        // 2 = Silver (1000-1499)
        // 3 = Gold (1500-1999)
        // 4 = Platinum (2000-2499)
        // 5 = Diamond (2500-2999)
        // 6 = Master (3000+)
        int tier = points / 500;
        return Math.Min(tier, 6);
    }

    public static string GetRankTierName(int tier)
    {
        return tier switch
        {
            0 => "Unranked",
            1 => "Bronze",
            2 => "Silver",
            3 => "Gold",
            4 => "Platinum",
            5 => "Diamond",
            6 => "Master",
            _ => "Unknown"
        };
    }

    // === Admin ===

    public void AdminResetPlayer(string accountId, string actor)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return;

        _lock.Wait();
        try
        {
            if (_state.Players.Remove(accountId))
            {
                SaveState();
                _logger.LogWarning("Admin {Actor} reset ranked state for {AccountId}.", actor, accountId);
            }
        }
        finally
        {
            _lock.Release();
        }
    }

    public void AdminSetPoints(string accountId, int points, string actor)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return;

        _lock.Wait();
        try
        {
            if (_state.Players.TryGetValue(accountId, out PlayerRankedState? player))
            {
                int oldPoints = player.Points;
                player.Points = Math.Max(_options.MinPointsFloor, points);
                if (player.Points > player.PeakPoints)
                    player.PeakPoints = player.Points;

                SaveState();
                _logger.LogWarning("Admin {Actor} set points for {AccountId}: {OldPoints} -> {NewPoints}.",
                    actor, accountId, oldPoints, player.Points);
            }
            else
            {
                _logger.LogWarning("Admin {Actor} tried to set points for unknown player {AccountId}.", actor, accountId);
            }
        }
        finally
        {
            _lock.Release();
        }
    }

    // === API Response Builders ===

    public object[] BuildProfileRankStats(string accountId)
    {
        _lock.Wait();
        try
        {
            if (!_state.Players.TryGetValue(accountId, out PlayerRankedState? player))
            {
                // Return default stats for a player with no ranked history
                return [new
                {
                    mode = 0,
                    points = _options.StartingPoints,
                    peakPoints = _options.StartingPoints,
                    tier = GetRankTier(_options.StartingPoints),
                    tierName = GetRankTierName(GetRankTier(_options.StartingPoints)),
                    gamesPlayed = 0,
                    wins = 0,
                    totalKills = 0,
                    position = 0
                }];
            }

            int position = GetPlayerPositionInternal(accountId);
            int tier = GetRankTier(player.Points);

            return [new
            {
                mode = 0,
                points = player.Points,
                peakPoints = player.PeakPoints,
                tier,
                tierName = GetRankTierName(tier),
                gamesPlayed = player.GamesPlayed,
                wins = player.Wins,
                totalKills = player.TotalKills,
                position
            }];
        }
        finally
        {
            _lock.Release();
        }
    }

    public object BuildLeaderboardResponse(int mode, int page, int pageSize = 20)
    {
        _lock.Wait();
        try
        {
            int offset = page * pageSize;

            var sorted = _state.Players.Values
                .OrderByDescending(p => p.Points)
                .ThenByDescending(p => p.Wins)
                .ThenByDescending(p => p.TotalKills)
                .ToList();

            int totalPlayers = sorted.Count;
            int totalPages = totalPlayers > 0 ? (int)Math.Ceiling((double)totalPlayers / pageSize) : 1;

            var entries = sorted
                .Skip(offset)
                .Take(pageSize)
                .Select((p, i) => new
                {
                    position = offset + i + 1,
                    accountId = p.AccountId,
                    username = p.Username,
                    points = p.Points,
                    tier = GetRankTier(p.Points),
                    tierName = GetRankTierName(GetRankTier(p.Points)),
                    gamesPlayed = p.GamesPlayed,
                    wins = p.Wins,
                    totalKills = p.TotalKills
                })
                .ToArray();

            return new
            {
                mode,
                page,
                pageSize,
                totalPages,
                totalPlayers,
                entries
            };
        }
        finally
        {
            _lock.Release();
        }
    }

    public object BuildLeaderboardSelfResponse(string accountId, int mode)
    {
        _lock.Wait();
        try
        {
            if (!_state.Players.TryGetValue(accountId, out PlayerRankedState? player))
            {
                return new
                {
                    mode,
                    position = 0,
                    accountId,
                    username = "",
                    points = _options.StartingPoints,
                    tier = GetRankTier(_options.StartingPoints),
                    tierName = GetRankTierName(GetRankTier(_options.StartingPoints)),
                    gamesPlayed = 0,
                    wins = 0,
                    totalKills = 0
                };
            }

            int position = GetPlayerPositionInternal(accountId);
            int tier = GetRankTier(player.Points);

            return new
            {
                mode,
                position,
                accountId = player.AccountId,
                username = player.Username,
                points = player.Points,
                tier,
                tierName = GetRankTierName(tier),
                gamesPlayed = player.GamesPlayed,
                wins = player.Wins,
                totalKills = player.TotalKills
            };
        }
        finally
        {
            _lock.Release();
        }
    }

    // === Private Helpers ===

    private PlayerRankedState GetOrCreatePlayerInternal(string accountId, string username)
    {
        if (_state.Players.TryGetValue(accountId, out PlayerRankedState? existing))
        {
            if (!string.IsNullOrWhiteSpace(username))
                existing.Username = username;
            return existing;
        }

        var player = new PlayerRankedState
        {
            AccountId = accountId,
            Username = username,
            Points = _options.StartingPoints,
            PeakPoints = _options.StartingPoints
        };

        _state.Players[accountId] = player;
        return player;
    }

    private int GetPlayerPositionInternal(string accountId)
    {
        var sorted = _state.Players.Values
            .OrderByDescending(p => p.Points)
            .ThenByDescending(p => p.Wins)
            .ThenByDescending(p => p.TotalKills)
            .ToList();

        for (int i = 0; i < sorted.Count; i++)
        {
            if (string.Equals(sorted[i].AccountId, accountId, StringComparison.OrdinalIgnoreCase))
                return i + 1;
        }

        return -1;
    }

    private void LoadState()
    {
        try
        {
            if (!File.Exists(_statePath))
            {
                _logger.LogInformation("Ranked state file not found at {Path}. Starting fresh.", _statePath);
                return;
            }

            string json = File.ReadAllText(_statePath, Encoding.UTF8);
            RankedStateDocument? loaded = JsonSerializer.Deserialize<RankedStateDocument>(json, JsonContract.Options);
            if (loaded is not null)
            {
                _state = loaded;
                _logger.LogInformation("Loaded ranked state: {PlayerCount} players.", _state.Players.Count);
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Could not load ranked state from {Path}. Starting fresh.", _statePath);
            _state = new RankedStateDocument();
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
            _logger.LogError(ex, "Failed to save ranked state to {Path}.", _statePath);
        }
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

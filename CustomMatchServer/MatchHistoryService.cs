using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace BapCustomServer;

public sealed class MatchHistoryOptions
{
    public string LogFile { get; set; } = "logs/match-history.jsonl";
    public int MaxInMemoryEntries { get; set; } = 200;
}

public sealed class MatchHistoryEntry
{
    public string GameId { get; set; } = "";
    public string LobbyId { get; set; } = "";
    public int MapId { get; set; }
    public int GameModeId { get; set; }
    public int BotCount { get; set; }
    public int BotDifficulty { get; set; }
    public int PlayerCount { get; set; }
    public DateTimeOffset StartedUtc { get; set; }
    public DateTimeOffset EndedUtc { get; set; }
    public int DurationSeconds { get; set; }
    public List<MatchPlayerEntry> Players { get; set; } = [];
}

public sealed class MatchPlayerEntry
{
    public string AccountId { get; set; } = "";
    public string Username { get; set; } = "";
    public int CharId { get; set; }
    public int TeamId { get; set; }
    public int Kills { get; set; }
    public int Deaths { get; set; }
    public int Assists { get; set; }
    public int DamageDealt { get; set; }
    public int Placement { get; set; }
    public int GoldEarned { get; set; }
    public int RankPointsDelta { get; set; }
}

public sealed class MatchHistoryService
{
    private readonly SemaphoreSlim _lock = new(1, 1);
    private readonly LinkedList<MatchHistoryEntry> _recentMatches = new();
    private readonly string _logPath;
    private readonly MatchHistoryOptions _options;
    private readonly ILogger<MatchHistoryService> _logger;

    public MatchHistoryService(IOptions<MatchHistoryOptions> options, ILogger<MatchHistoryService> logger)
    {
        _options = options.Value;
        _logger = logger;
        _logPath = ResolvePath(_options.LogFile);
        LoadRecentFromDisk();
    }

    // === Public API ===

    public void RecordMatch(MatchHistoryEntry entry)
    {
        if (entry is null || string.IsNullOrWhiteSpace(entry.GameId)) return;

        _lock.Wait();
        try
        {
            // Append to JSONL file
            AppendToLog(entry);

            // Add to in-memory ring buffer
            _recentMatches.AddFirst(entry);
            while (_recentMatches.Count > _options.MaxInMemoryEntries)
            {
                _recentMatches.RemoveLast();
            }

            _logger.LogInformation(
                "Match recorded: GameId={GameId}, Map={MapId}, Mode={GameModeId}, Players={PlayerCount}, Duration={Duration}s",
                entry.GameId, entry.MapId, entry.GameModeId, entry.PlayerCount, entry.DurationSeconds);
        }
        finally
        {
            _lock.Release();
        }
    }

    public MatchHistoryEntry[] GetRecentMatches(int count)
    {
        if (count <= 0) return [];

        _lock.Wait();
        try
        {
            return _recentMatches.Take(count).ToArray();
        }
        finally
        {
            _lock.Release();
        }
    }

    public MatchHistoryEntry? GetMatch(string gameId)
    {
        if (string.IsNullOrWhiteSpace(gameId)) return null;

        _lock.Wait();
        try
        {
            return _recentMatches.FirstOrDefault(m =>
                string.Equals(m.GameId, gameId, StringComparison.OrdinalIgnoreCase));
        }
        finally
        {
            _lock.Release();
        }
    }

    public MatchHistoryEntry[] GetPlayerMatches(string accountId, int count)
    {
        if (string.IsNullOrWhiteSpace(accountId) || count <= 0) return [];

        _lock.Wait();
        try
        {
            return _recentMatches
                .Where(m => m.Players.Any(p =>
                    string.Equals(p.AccountId, accountId, StringComparison.OrdinalIgnoreCase)))
                .Take(count)
                .ToArray();
        }
        finally
        {
            _lock.Release();
        }
    }

    // === Private Helpers ===

    private void AppendToLog(MatchHistoryEntry entry)
    {
        try
        {
            string? directory = Path.GetDirectoryName(_logPath);
            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string line = JsonSerializer.Serialize(entry, JsonContract.Options);
            using FileStream fs = new(_logPath, FileMode.Append, FileAccess.Write, FileShare.Read);
            using StreamWriter writer = new(fs, Encoding.UTF8);
            writer.WriteLine(line);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to append match to log at {Path}.", _logPath);
        }
    }

    private void LoadRecentFromDisk()
    {
        try
        {
            if (!File.Exists(_logPath))
            {
                _logger.LogInformation("Match history log not found at {Path}. Starting fresh.", _logPath);
                return;
            }

            // Read the file and take the last N entries
            string[] lines = File.ReadAllLines(_logPath, Encoding.UTF8);
            int startIndex = Math.Max(0, lines.Length - _options.MaxInMemoryEntries);

            int loaded = 0;
            for (int i = startIndex; i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line)) continue;

                try
                {
                    MatchHistoryEntry? entry = JsonSerializer.Deserialize<MatchHistoryEntry>(line, JsonContract.Options);
                    if (entry is not null)
                    {
                        _recentMatches.AddLast(entry);
                        loaded++;
                    }
                }
                catch (JsonException ex)
                {
                    _logger.LogWarning(ex, "Skipping malformed line {LineNumber} in match history log.", i + 1);
                }
            }

            // Reverse so newest are first
            var temp = _recentMatches.ToList();
            _recentMatches.Clear();
            foreach (var entry in temp.AsEnumerable().Reverse())
            {
                _recentMatches.AddLast(entry);
            }
            // Actually we want newest-first for GetRecentMatches, so re-reverse
            var ordered = _recentMatches.OrderByDescending(m => m.EndedUtc).ToList();
            _recentMatches.Clear();
            foreach (var entry in ordered)
            {
                _recentMatches.AddLast(entry);
            }

            _logger.LogInformation("Loaded {Count} recent matches from history log.", loaded);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Could not load match history from {Path}. Starting fresh.", _logPath);
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

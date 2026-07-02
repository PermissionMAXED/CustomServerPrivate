using Microsoft.Extensions.Options;
using System.Collections.Concurrent;

namespace BapCustomServer;

public sealed class MatchmakingQueueOptions
{
    public int QueueTimerSeconds { get; set; } = 30;
    public int FailedStartRetryDelaySeconds { get; set; } = 5;
    public int MaxMatchStartFailures { get; set; } = 5; // drop a player from the queue after this many failed starts (0 = unlimited)
    public int MinPlayersToStart { get; set; } = 1; // start even with 1 player (bots fill)
    public int DefaultBotCount { get; set; } = 4;
    public int MaxBotCount { get; set; } = 4;
    public int DefaultBotDifficulty { get; set; } = 1;
    public int DefaultMapId { get; set; } = 1;
    public int DefaultGameMode { get; set; } = 3;
    public int DefaultMaxTeams { get; set; } = 8;
    public int DefaultTeamSize { get; set; } = 1;
}

public sealed class QueueEntry
{
    public string AccountId { get; set; } = "";
    public string Username { get; set; } = "";
    public int Discriminator { get; set; }
    public int CharId { get; set; } = 1;
    public int GameModeId { get; set; } = 3; // matchmaking mode id (3=Solos default)
    public int Points { get; set; } // ranked points for matchmaking
    public DateTimeOffset JoinedUtc { get; set; }
    public int MatchStartFailures { get; set; }
}

public sealed record QueueJoinResult(bool Ok, string Message, int QueuePosition, int SecondsRemaining);

public sealed class QueueStatus
{
    public int PlayerCount { get; set; }
    public int SecondsRemaining { get; set; }
    public bool IsActive { get; set; }
    public QueueEntry[] Players { get; set; } = [];
}

public sealed class MatchmakingQueueService
{
    private const int MaxQueueTimerSeconds = 420;
    private readonly SemaphoreSlim _lock = new(1, 1);
    private readonly List<QueueEntry> _queue = [];
    private readonly HashSet<string> _inFlightMatchStart = new(StringComparer.OrdinalIgnoreCase);

    public int GetQueueSize()
    {
        // Must use the same SemaphoreSlim every other member uses; lock(_queue) synchronized
        // with nothing and could observe the list mid-mutation.
        _lock.Wait();
        try { return _queue.Count; }
        finally { _lock.Release(); }
    }
    private readonly MatchmakingQueueOptions _options;
    private readonly ILogger<MatchmakingQueueService> _logger;

    private DateTimeOffset? _queueStartedUtc;
    private int EffectiveQueueTimerSeconds => Math.Clamp(_options.QueueTimerSeconds, 0, MaxQueueTimerSeconds);

    public MatchmakingQueueService(IOptions<MatchmakingQueueOptions> options, ILogger<MatchmakingQueueService> logger)
    {
        _options = options.Value;
        _logger = logger;
        if (_options.QueueTimerSeconds > MaxQueueTimerSeconds)
        {
            _logger.LogWarning(
                "QueueTimerSeconds={ConfiguredSeconds} exceeds the supported maximum. Capping matchmaking countdown at {MaxSeconds}s.",
                _options.QueueTimerSeconds,
                MaxQueueTimerSeconds);
        }
    }

    // === Queue Operations ===

    public QueueJoinResult JoinQueue(string accountId, string username, int discriminator, int charId, int points, int gameModeId = 3)
    {
        if (string.IsNullOrWhiteSpace(accountId))
            return new QueueJoinResult(false, "Invalid account ID.", 0, 0);

        _lock.Wait();
        try
        {
            // Check if player is already in queue
            bool alreadyInQueue = _queue.Any(e =>
                string.Equals(e.AccountId, accountId, StringComparison.OrdinalIgnoreCase)) ||
                _inFlightMatchStart.Contains(accountId);

            if (alreadyInQueue)
            {
                int existingPos = GetPositionInternal(accountId);
                int remaining = GetSecondsRemainingInternal();
                return new QueueJoinResult(false, "You are already in the queue.", existingPos, remaining);
            }

            var entry = new QueueEntry
            {
                AccountId = accountId,
                Username = username,
                Discriminator = discriminator,
                CharId = charId,
                GameModeId = gameModeId,
                Points = points,
                JoinedUtc = DateTimeOffset.UtcNow
            };

            _queue.Add(entry);

            // Start timer if this is the first player
            if (_queueStartedUtc is null)
            {
                _queueStartedUtc = DateTimeOffset.UtcNow;
                _logger.LogInformation("Matchmaking queue timer started. First player: {AccountId} ({Username}).",
                    accountId, username);
            }

            int position = _queue.Count;
            int secondsRemaining = GetSecondsRemainingInternal();

            _logger.LogInformation("Player {AccountId} ({Username}) joined queue. charId={CharId} points={Points} pos={Position} timer={Seconds}s.",
                accountId, username, charId, points, position, secondsRemaining);

            return new QueueJoinResult(true, "Joined the matchmaking queue.", position, secondsRemaining);
        }
        finally
        {
            _lock.Release();
        }
    }

    public bool UpdateQueuedCharacter(string accountId, int charId)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return false;

        _lock.Wait();
        try
        {
            QueueEntry? entry = _queue.FirstOrDefault(e =>
                string.Equals(e.AccountId, accountId, StringComparison.OrdinalIgnoreCase));

            if (entry is null)
            {
                return false;
            }

            int oldCharId = entry.CharId;
            entry.CharId = charId;
            _logger.LogInformation("Updated queued character for {AccountId}: {OldCharId}->{NewCharId}.",
                accountId, oldCharId, charId);
            return true;
        }
        finally
        {
            _lock.Release();
        }
    }

    public bool LeaveQueue(string accountId)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return false;

        _lock.Wait();
        try
        {
            int removed = _queue.RemoveAll(e =>
                string.Equals(e.AccountId, accountId, StringComparison.OrdinalIgnoreCase));

            bool removedInFlight = _inFlightMatchStart.Remove(accountId);
            if (removed == 0 && !removedInFlight)
                return false;

            _logger.LogDebug("Player {AccountId} left the matchmaking queue. Remaining: {Count}. inFlight={InFlight}.", accountId, _queue.Count, removedInFlight);

            // If queue is now empty, reset timer
            if (_queue.Count == 0)
            {
                _queueStartedUtc = null;
                _logger.LogDebug("Queue is empty. Timer reset.");
            }

            return true;
        }
        finally
        {
            _lock.Release();
        }
    }

    public (bool ShouldStart, QueueEntry[] Players) CheckQueueReady()
    {
        _lock.Wait();
        try
        {
            if (!IsReadyInternal(out int secondsElapsed))
            {
                return (false, []);
            }

            _logger.LogInformation(
                "Matchmaking queue ready! {PlayerCount} players after {Seconds}s.",
                _queue.Count, secondsElapsed);

            return (true, _queue.ToArray());
        }
        finally
        {
            _lock.Release();
        }
    }

    public (bool ShouldStart, QueueEntry[] Players) TakeReadyMatch()
    {
        _lock.Wait();
        try
        {
            if (!IsReadyInternal(out int secondsElapsed))
            {
                return (false, []);
            }

            QueueEntry[] players = _queue.ToArray();
            _queue.Clear();
            _inFlightMatchStart.Clear();
            foreach (QueueEntry player in players)
            {
                _inFlightMatchStart.Add(player.AccountId);
            }
            _queueStartedUtc = null;

            _logger.LogInformation(
                "Matchmaking queue taken for match start. {PlayerCount} players after {Seconds}s.",
                players.Length, secondsElapsed);

            return (true, players);
        }
        finally
        {
            _lock.Release();
        }
    }

    public void RequeuePlayers(IEnumerable<QueueEntry> players, string reason = "failed match start")
    {
        _lock.Wait();
        try
        {
            int added = 0;
            int dropped = 0;
            // If the queue already held entries (a fresh joiner during the failed-start window),
            // we must not shorten their countdown when applying the retry rewind below.
            bool queueHadOtherEntries = _queue.Count > 0;
            DateTimeOffset now = DateTimeOffset.UtcNow;
            foreach (QueueEntry player in players)
            {
                if (_queue.Any(entry => string.Equals(entry.AccountId, player.AccountId, StringComparison.OrdinalIgnoreCase)))
                {
                    _inFlightMatchStart.Remove(player.AccountId);
                    continue;
                }

                if (!_inFlightMatchStart.Remove(player.AccountId))
                {
                    _logger.LogInformation(
                        "Skipping matchmaking requeue for {AccountId} after {Reason}; player left during the match-start window.",
                        player.AccountId,
                        reason);
                    continue;
                }

                player.MatchStartFailures++;

                // Circuit breaker: drop players whose match has failed to start too many times
                // rather than requeueing forever (MaxMatchStartFailures <= 0 = unlimited retries).
                if (_options.MaxMatchStartFailures > 0 && player.MatchStartFailures >= _options.MaxMatchStartFailures)
                {
                    dropped++;
                    continue;
                }

                _queue.Add(player);
                added++;
            }

            if (_queue.Count > 0 && !queueHadOtherEntries)
            {
                // Only rewind the timer when the queue is made up solely of requeued players, so a
                // fresh joiner who set a full-length countdown isn't pulled into a retry match early.
                int queueTimerSeconds = EffectiveQueueTimerSeconds;
                int retryDelaySeconds = Math.Clamp(_options.FailedStartRetryDelaySeconds, 0, queueTimerSeconds);
                _queueStartedUtc = now.AddSeconds(-Math.Max(0, queueTimerSeconds - retryDelaySeconds));
            }

            if (added > 0 || dropped > 0)
            {
                _logger.LogWarning(
                    "Requeued {Count} matchmaking player(s) after {Reason} (dropped {Dropped} over failure cap). retryDelay={RetryDelay}s failures={Failures}.",
                    added,
                    reason,
                    dropped,
                    Math.Clamp(_options.FailedStartRetryDelaySeconds, 0, EffectiveQueueTimerSeconds),
                    string.Join(",", _queue.Select(player => $"{player.AccountId}:{player.MatchStartFailures}")));
            }
        }
        finally
        {
            _lock.Release();
        }
    }

    public QueueStatus GetStatus()
    {
        _lock.Wait();
        try
        {
            return new QueueStatus
            {
                PlayerCount = _queue.Count,
                SecondsRemaining = GetSecondsRemainingInternal(),
                IsActive = _queue.Count > 0 && _queueStartedUtc is not null,
                Players = _queue.ToArray()
            };
        }
        finally
        {
            _lock.Release();
        }
    }

    public void ClearQueue()
    {
        _lock.Wait();
        try
        {
            int count = _queue.Count;
            _queue.Clear();
            _inFlightMatchStart.Clear();
            _queueStartedUtc = null;

            _logger.LogInformation("Matchmaking queue cleared. {Count} players were in queue.", count);
        }
        finally
        {
            _lock.Release();
        }
    }

    public void CompleteMatchStart(IEnumerable<QueueEntry> players)
    {
        _lock.Wait();
        try
        {
            foreach (QueueEntry player in players)
            {
                _inFlightMatchStart.Remove(player.AccountId);
            }
        }
        finally
        {
            _lock.Release();
        }
    }

    public void ResetTimer()
    {
        _lock.Wait();
        try
        {
            if (_queue.Count > 0)
            {
                _queueStartedUtc = DateTimeOffset.UtcNow;
                _logger.LogDebug("Matchmaking queue timer reset. {Count} players in queue.", _queue.Count);
            }
            else
            {
                _queueStartedUtc = null;
            }
        }
        finally
        {
            _lock.Release();
        }
    }

    public int GetSecondsRemaining()
    {
        _lock.Wait();
        try
        {
            return GetSecondsRemainingInternal();
        }
        finally
        {
            _lock.Release();
        }
    }

    // === Private Helpers ===

    private int GetSecondsRemainingInternal()
    {
        if (_queueStartedUtc is null)
            return EffectiveQueueTimerSeconds;

        int elapsed = (int)(DateTimeOffset.UtcNow - _queueStartedUtc.Value).TotalSeconds;
        int remaining = EffectiveQueueTimerSeconds - elapsed;
        return Math.Max(0, remaining);
    }

    private int GetPositionInternal(string accountId)
    {
        for (int i = 0; i < _queue.Count; i++)
        {
            if (string.Equals(_queue[i].AccountId, accountId, StringComparison.OrdinalIgnoreCase))
                return i + 1;
        }

        return 0;
    }

    private bool IsReadyInternal(out int secondsElapsed)
    {
        secondsElapsed = 0;
        if (_queue.Count == 0 || _queueStartedUtc is null)
            return false;

        secondsElapsed = (int)(DateTimeOffset.UtcNow - _queueStartedUtc.Value).TotalSeconds;

        if (secondsElapsed < EffectiveQueueTimerSeconds)
            return false;

        return _queue.Count >= _options.MinPlayersToStart;
    }
}

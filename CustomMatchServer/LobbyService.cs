using Microsoft.Extensions.Options;
using System.Buffers;
using System.Collections.Concurrent;
using System.Net.Http;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace BapCustomServer;

public sealed class LobbyService
{
    // Must be one of the advertised modes (EnabledGameModeIdsCsv). A lobby that defaults to a
    // non-advertised mode leaves the picker with no matching tile, so it falls back to highlighting
    // the first tile (0=Warmup="Training") and looks "stuck on Training". 3=Solos is always advertised.
    private const int DefaultLobbyGameModeId = 3;
    private const int MinimumCharSelectMillis = 20000;

    private int PickMapId(int unityGameMode, int customSettingsMapId)
    {
        int[] enabled = BuildAllowedMapIds(unityGameMode);
        bool customMapsAllowed = _options.MapPool?.EnableMapCustomFlat ?? true;

        // An explicit CUSTOM-map (>=5) selection is always a deliberate choice -> honor it.
        if (customSettingsMapId > 0
            && MapCatalog.IsCustomMapId(customSettingsMapId)
            && customMapsAllowed)
        {
            return customSettingsMapId;
        }

        // When the server is configured to rotate, rotation is AUTHORITATIVE over an incoming
        // shipped-map id. This is what RandomizeMapPerMatch means, and it stops the lobby's default
        // mapId (CustomGameSettingsData.MapId, which the client sends as a fixed shipped id) from
        // pinning every match to one map -- the long-standing "always BazaarCity" bug.
        if (_options.MatchDefaults.RandomizeMapPerMatch)
        {
            int[] randomPool = (_options.MapPool?.AllMapsAllModes == true || _options.MapPool?.HasCustomization == true)
                ? _options.MapPool!.BuildRandomMapIds()
                : enabled.Where(id => !MapCatalog.IsCustomMapId(id)).DefaultIfEmpty(enabled[0]).ToArray();
            return randomPool[Random.Shared.Next(randomPool.Length)];
        }

        // Not rotating: honor an enabled shipped-map request, else fall back.
        if (customSettingsMapId > 0)
        {
            if (enabled.Contains(customSettingsMapId))
            {
                return customSettingsMapId;
            }

            _logger.LogWarning(
                "Requested mapId {RequestedMapId} is disabled or unknown for UnityGameMode {UnityGameMode}; falling back to {FallbackMapId} ({FallbackMapName}).",
                customSettingsMapId,
                unityGameMode,
                enabled[0],
                MapCatalog.IdToName.GetValueOrDefault(enabled[0], "unknown"));
            return enabled[0];
        }

        int configuredDefault = _options.MatchDefaults.MapId > 0
            ? _options.MatchDefaults.MapId
            : MapCatalog.BazaarCityId;
        return enabled.Contains(configuredDefault) ? configuredDefault : enabled[0];
    }

    private int[] BuildAllowedMapIds(int unityGameMode)
    {
        // 1. AllMapsAllModes: MapPool toggles ALWAYS apply to every game mode (even Solos can spawn on a Trios-default map).
        if (_options.MapPool?.AllMapsAllModes == true)
        {
            return _options.MapPool.BuildEnabledMapIds();
        }

        // 2. AMP MapPool toggles take precedence when ANY map was disabled in AMP UI.
        if (_options.MapPool?.HasCustomization == true)
        {
            return _options.MapPool.BuildEnabledMapIds();
        }

        // 3. Friendly name/ID pools are supported for hand-edited configs and future AMP renderers.
        var namedEntry = _options.MatchDefaults.NamedMapPool?
            .FirstOrDefault(m => m.UnityGameModeId == unityGameMode);
        if (namedEntry is not null)
        {
            int[] ids = namedEntry.MapIds.Length > 0
                ? namedEntry.MapIds
                : MapCatalog.ResolveAll(namedEntry.MapNames);
            ids = NormalizeMapIds(ids);
            if (ids.Length > 0) return ids;
        }

        int[] enabledByName = MapCatalog.ResolveAll(_options.MatchDefaults.EnabledMapsByName);
        if (enabledByName.Length > 0) return enabledByName;

        int[] enabledById = NormalizeMapIds(_options.MatchDefaults.EnabledMapIds);
        if (enabledById.Length > 0) return enabledById;

        // 4. Otherwise use the legacy per-game-mode MapMapping pool from MatchDefaults.
        var entry = _options.MatchDefaults.MapMapping?.FirstOrDefault(m => m.UnityGameModeId == unityGameMode);
        int[] mapped = NormalizeMapIds(entry?.MapIds ?? []);
        if (mapped.Length > 0)
        {
            return mapped;
        }

        int fallback = _options.MatchDefaults.MapId > 0 ? _options.MatchDefaults.MapId : MapCatalog.BazaarCityId;
        return NormalizeMapIds([fallback]).Length > 0
            ? [fallback]
            : [MapCatalog.BazaarCityId];
    }

    private static int[] NormalizeMapIds(IEnumerable<int> ids)
    {
        return ids
            .Where(MapCatalog.IdToName.ContainsKey)
            .Distinct()
            .OrderBy(id => id)
            .ToArray();
    }

    private const long MaxIncomingMessageBytes = 4 * 1024 * 1024;

    private readonly ConcurrentDictionary<Guid, ClientConnection> _clients = [];
    // Stores pending attestation nonces keyed by connection ID.
    // A non-null entry means the client has been challenged but hasn't
    // responded yet (or the response failed). Null/absent = no pending auth.
    // Stores pending attestation nonces keyed by connection ID.
    private readonly ConcurrentDictionary<Guid, string> _pendingAttestations = [];
    // Admin auth grants by accountId (set by successful ADMIN_AUTH via auth WS,
    // consumed on the game WS connection or expired after AdminGrantTtl).
    private readonly ConcurrentDictionary<string, DateTime> _adminGrants = new(StringComparer.OrdinalIgnoreCase);
    private static readonly TimeSpan AdminGrantTtl = TimeSpan.FromMinutes(30);

    private readonly ConcurrentDictionary<string, CustomLobby> _lobbies = [];
    private readonly ConcurrentDictionary<string, GameServerSession> _matches = [];
    private readonly ConcurrentDictionary<string, string[]> _matchAccountIds = [];
    private readonly ConcurrentDictionary<string, DateTimeOffset> _emptyLobbyMatchSinceUtc = [];
    // Per-account stamp written when a match this account was in ends OR when the account disconnects
    // out of a live match. On "Exit to Lobby" the BAPBAP client fully disconnects, reconnects, and
    // auto-sends a ready frame ~15-20s later (after the 6s JoinLobby delay) into a FRESH lobby where the
    // match-state signals are already gone. The window must outlast that whole reconnect cycle so the
    // auto-ready is recognized as a post-match return and suppressed (user wants to stay in lobby).
    private readonly ConcurrentDictionary<string, DateTimeOffset> _postMatchReturnUtc = new(StringComparer.OrdinalIgnoreCase);
    private static readonly TimeSpan PostMatchRequeueSuppression = TimeSpan.FromSeconds(30);
    // PRIMARY, timing-independent post-match suppression: armed when a match STARTS for an account and
    // consumed by the FIRST ready that arrives afterward. The BAPBAP client auto-readies after a match
    // ends; that auto-ready (whenever it arrives — even after a full disconnect/reconnect + 6s JoinLobby
    // delay) trips this flag and the player STAYS IN LOBBY instead of being re-matched. A later deliberate
    // Play finds no flag and queues normally. Keyed by stable accountId so it survives the reconnect,
    // which is exactly what the time-window approach could not guarantee.
    // The value is the arm timestamp: entries are only honored within SuppressFlagTtl. Without the
    // TTL, a player whose client never auto-readied (e.g. quit the game right after the match)
    // kept the flag forever and their FIRST deliberate Play of the next session was silently
    // swallowed. Expired entries are pruned in CleanupStaleMatches.
    private readonly ConcurrentDictionary<string, DateTimeOffset> _suppressNextReadyAfterMatch = new(StringComparer.OrdinalIgnoreCase);
    // Long enough to span the longest realistic match + exit/reconnect cycle (flag is armed at
    // match START), short enough that a returning player's next-session Play is never eaten.
    private static readonly TimeSpan SuppressFlagTtl = TimeSpan.FromMinutes(30);
    private int _matchReservations;

    private bool HasValidSuppressFlag(string accountId) =>
        _suppressNextReadyAfterMatch.TryGetValue(accountId, out DateTimeOffset armedAt) &&
        (DateTimeOffset.UtcNow - armedAt) <= SuppressFlagTtl;

    /// <summary>
    /// Stamp the 30s post-match return window for every account recorded for <paramref name="gameId"/>.
    /// MUST be called BEFORE the corresponding <c>_matchAccountIds.TryRemove</c>. Every cleanup path
    /// that forgets a match has to stamp; the paths that skipped it (stale sweep, empty-lobby cleanup,
    /// abandoned-match release, admin stop) were exactly the "un-guarded" routes that let the client's
    /// post-match auto-ready burst slip back into the queue.
    /// </summary>
    private void StampPostMatchReturnWindow(string gameId)
    {
        if (string.IsNullOrWhiteSpace(gameId) ||
            !_matchAccountIds.TryGetValue(gameId, out string[]? accounts))
        {
            return;
        }

        DateTimeOffset now = DateTimeOffset.UtcNow;
        foreach (string account in accounts)
        {
            if (!string.IsNullOrWhiteSpace(account))
            {
                _postMatchReturnUtc[account] = now;
            }
        }
    }

    private int EmptyLobbyMatchCleanupGraceSeconds =>
        Math.Clamp(_options.EmptyLobbyMatchCleanupGraceSeconds, 0, 300);

    private int EmptyLobbyMatchConnectedCleanupGraceSeconds =>
        Math.Clamp(
            _options.EmptyLobbyMatchConnectedCleanupGraceSeconds,
            EmptyLobbyMatchCleanupGraceSeconds,
            300);

    private TimeSpan EmptyLobbyMatchCleanupGrace =>
        TimeSpan.FromSeconds(EmptyLobbyMatchCleanupGraceSeconds);

    private TimeSpan EmptyLobbyMatchConnectedCleanupGrace =>
        TimeSpan.FromSeconds(EmptyLobbyMatchConnectedCleanupGraceSeconds);

    public int GetClientCount() => _clients.Count;
    public int GetLobbyCount() => _lobbies.Count;

    /// <summary>
    /// One-shot check+consume of the post-match auto-requeue suppression for an account, for the HTTP
    /// /api/queue/join path (the WS SwitchReadyAsync path consumes the flag itself). Returns true if the
    /// account was flagged as just-returned-from-a-match (so the queue-join should be ignored, keeping
    /// the player in the lobby); a later deliberate Play finds no flag and queues normally.
    /// </summary>
    public bool TryConsumePostMatchRequeueSuppression(string accountId)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return false;
        // Mirror the WS path semantics: consume ONLY the one-shot flag and LEAVE the 30s window intact so
        // it absorbs the WHOLE post-match burst. The client fires queue-joins in bursts; if this removed
        // the window, join #1 would suppress but join #2 (~1s later) would find nothing armed and re-match.
        // The window self-expires after PostMatchRequeueSuppression, so a later deliberate Play still queues.
        bool flag = _suppressNextReadyAfterMatch.TryRemove(accountId, out DateTimeOffset armedAt) &&
                    (DateTimeOffset.UtcNow - armedAt) <= SuppressFlagTtl;
        bool window = _postMatchReturnUtc.TryGetValue(accountId, out DateTimeOffset endedAt) &&
                      (DateTimeOffset.UtcNow - endedAt) <= PostMatchRequeueSuppression;
        return flag || window;
    }

    /// <summary>
    /// The matchmaking game mode the given account currently has selected in its lobby, or null if
    /// the account is not in a lobby. Lets /api/queue/join carry the lobby-selected mode into the queue
    /// when the client doesn't send gameModeId in the request body.
    /// </summary>
    public int? GetAccountLobbyMode(string accountId)
    {
        if (string.IsNullOrWhiteSpace(accountId))
        {
            return null;
        }

        foreach (CustomLobby lobby in _lobbies.Values)
        {
            if (lobby.ActiveGameId == null && lobby.Players.ContainsKey(accountId))
            {
                return lobby.CustomSettings.Gamemode;
            }
        }

        return null;
    }

    /// <summary>
    /// Set GameModifierIds on ALL active lobbies' CustomSettings. Used by admin /api/admin/modifiers/apply.
    /// Returns the number of lobbies updated.
    /// </summary>
    public int SetActiveLobbyModifiers(int[] modifierIds)
    {
        int count = 0;
        foreach (var lobby in _lobbies.Values)
        {
            lobby.CustomSettings.GameModifierIds = modifierIds.Distinct().ToArray();
            count++;
        }
        return count;
    }

    /// <summary>
    /// Set BotCount + BotDifficulty on ALL active lobbies. Used by admin /api/admin/bots.
    /// </summary>
    public int SetActiveLobbyBots(int botCount, int botDifficulty)
    {
        int count = 0;
        foreach (var lobby in _lobbies.Values)
        {
            lobby.CustomSettings.BotCount = Math.Max(0, botCount);
            lobby.CustomSettings.BotDifficulty = Math.Max(0, Math.Min(4, botDifficulty));
            count++;
        }
        return count;
    }
    public int GetActiveMatchCount() => _matches.Count;

    /// <summary>Remove matches whose dedicated game-server process has exited. Called periodically.</summary>
    public int CleanupStaleMatches()
    {
        int removed = 0;
        DateTimeOffset now = DateTimeOffset.UtcNow;
        foreach (string gameId in _matches.Keys.ToArray())
        {
            if (!_matches.TryGetValue(gameId, out GameServerSession? session)) continue;
            try
            {
                if (session.Process != null && session.Process.HasExited)
                {
                    if (_matches.TryRemove(gameId, out GameServerSession? removedSession))
                    {
                        _gameServers.StopMatchServer(removedSession);
                    }
                    _emptyLobbyMatchSinceUtc.TryRemove(gameId, out _);
                    StampPostMatchReturnWindow(gameId);
                    _matchAccountIds.TryRemove(gameId, out _);
                    _logger.LogInformation("Cleaned up stale match {GameId} (process exited).", gameId);
                    removed++;
                    continue;
                }

                if (_emptyLobbyMatchSinceUtc.TryGetValue(gameId, out DateTimeOffset emptySince))
                {
                    TimeSpan emptyFor = now - emptySince;
                    bool hasConnectedMatchPlayer = HasConnectedMatchPlayer(gameId, out int connectedPlayers);
                    TimeSpan grace = hasConnectedMatchPlayer
                        ? EmptyLobbyMatchConnectedCleanupGrace
                        : EmptyLobbyMatchCleanupGrace;

                    if (emptyFor < grace) continue;

                    if (_matches.TryRemove(gameId, out GameServerSession? removedSession))
                    {
                        _gameServers.StopMatchServer(removedSession);
                    }
                    _emptyLobbyMatchSinceUtc.TryRemove(gameId, out _);
                    StampPostMatchReturnWindow(gameId);
                    _matchAccountIds.TryRemove(gameId, out _);
                    _logger.LogInformation(
                        "Cleaned up empty-lobby match {GameId} after {EmptyForSeconds:F0}s empty; grace={GraceSeconds:F0}s connectedMatchPlayers={ConnectedPlayers}.",
                        gameId,
                        emptyFor.TotalSeconds,
                        grace.TotalSeconds,
                        connectedPlayers);
                    removed++;
                }
            }
            catch
            {
                // process may be gone entirely
                if (_matches.TryRemove(gameId, out GameServerSession? removedSession))
                {
                    _gameServers.StopMatchServer(removedSession);
                }
                _emptyLobbyMatchSinceUtc.TryRemove(gameId, out _);
                StampPostMatchReturnWindow(gameId);
                _matchAccountIds.TryRemove(gameId, out _);
                removed++;
            }
        }

        PruneExpiredSuppressionState(now);
        return removed;
    }

    /// <summary>
    /// Drop expired post-match suppression entries. Both dictionaries are keyed by accountId and
    /// were previously never cleaned: identity-less sockets mint a fresh "custom-{N}" account per
    /// connection, so on a long-running server they grew without bound. Runs from
    /// CleanupStaleMatches (every ~10s via ResourceMonitorService).
    /// </summary>
    private void PruneExpiredSuppressionState(DateTimeOffset now)
    {
        foreach (KeyValuePair<string, DateTimeOffset> entry in _postMatchReturnUtc)
        {
            if (now - entry.Value > SuppressFlagTtl)
            {
                _postMatchReturnUtc.TryRemove(entry.Key, out _);
            }
        }

        foreach (KeyValuePair<string, DateTimeOffset> entry in _suppressNextReadyAfterMatch)
        {
            if (now - entry.Value > SuppressFlagTtl)
            {
                _suppressNextReadyAfterMatch.TryRemove(entry.Key, out _);
            }
        }

        foreach (KeyValuePair<string, DateTime> entry in _adminGrants)
        {
            if (now.UtcDateTime - entry.Value > AdminGrantTtl)
            {
                _adminGrants.TryRemove(entry.Key, out _);
            }
        }
    }

    private async Task DelayAfterMatchCleanupAsync(string startKind, int prunedMatches, CancellationToken cancellationToken)
    {
        int delayMillis = Math.Clamp(_options.GameServerPostCleanupStartDelayMillis, 0, 30_000);
        if (delayMillis <= 0)
        {
            return;
        }

        _logger.LogInformation(
            "Waiting {DelayMillis}ms before {StartKind} game-server start after cleaning {PrunedMatches} match(es), so fixed AMP ports can settle after Wine/Unity teardown.",
            delayMillis,
            startKind,
            prunedMatches);
        await Task.Delay(delayMillis, cancellationToken);
    }

    private readonly SemaphoreSlim _gate = new(1, 1);
    private readonly CustomServerOptions _options;
    private readonly GameServerProcessManager _gameServers;
    private readonly ServerAdminService _adminService;
    private readonly FriendsService _friendsService;
    private readonly EconomyService _economyService;
    private readonly MatchHistoryService _matchHistoryService;
    private readonly RankedService _rankedService;
    private readonly MatchmakingQueueService _queueService;
    private readonly MatchmakingQueueOptions _queueOptions;
    private readonly AdminOptions _adminOptions;
    private readonly CharacterUnlockService _characterUnlocks;
    private readonly ILogger<LobbyService> _logger;
    private int _playerCounter;
    private int _requestCounter;

    public LobbyService(
        IOptions<CustomServerOptions> options,
        GameServerProcessManager gameServers,
        ServerAdminService adminService,
        FriendsService friendsService,
        EconomyService economyService,
        MatchHistoryService matchHistoryService,
        RankedService rankedService,
        MatchmakingQueueService queueService,
        IOptions<MatchmakingQueueOptions> queueOptions,
        IOptions<AdminOptions> adminOptions,
        CharacterUnlockService characterUnlocks,
        ILogger<LobbyService> logger)
    {
        _options = options.Value;
        _gameServers = gameServers;
        _adminService = adminService;
        _friendsService = friendsService;
        _economyService = economyService;
        _matchHistoryService = matchHistoryService;
        _rankedService = rankedService;
        _queueService = queueService;
        _queueOptions = queueOptions.Value;
        _adminOptions = adminOptions.Value;
        _characterUnlocks = characterUnlocks;
        _logger = logger;
    }

    public string BuildSocketUrl(HttpContext? context)
    {
        if (!string.IsNullOrWhiteSpace(_options.PublicBaseUrl))
        {
            var publicBase = new Uri(_options.PublicBaseUrl.TrimEnd('/') + "/");
            string scheme = publicBase.Scheme.Equals("https", StringComparison.OrdinalIgnoreCase) ? "wss" : "ws";
            return $"{scheme}://{publicBase.Authority}/ws";
        }

        if (context is null)
        {
            return "ws://127.0.0.1:5055/ws";
        }

        string requestScheme = context.Request.Scheme.Equals("https", StringComparison.OrdinalIgnoreCase) ? "wss" : "ws";
        return $"{requestScheme}://{context.Request.Host}/ws";
    }

    public InternalServerData[] GetInternalServers()
    {
        if (_matches.IsEmpty && !_options.LaunchGameServers)
        {
            var external = _options.ExternalGameServer;
            return [new InternalServerData(external.Hostname, external.KcpPort, external.TcpPort, external.WsPort)];
        }

        return _matches.Values
            .Select(match => new InternalServerData(match.Hostname, match.KcpPort, match.TcpPort, match.WsPort))
            .ToArray();
    }

    public object[] GetLobbySnapshots()
    {
        return _lobbies.Values
            .Select(lobby => new
            {
                lobby.Id,
                lobby.LeaderAccountId,
                lobby.Starting,
                lobby.Settings,
                Players = lobby.Players.Values.Select(p => p.Player).ToArray()
            })
            .ToArray();
    }

    /// <summary>
    /// Lobby overview for the UNAUTHENTICATED root endpoint. Never expose accountIds here: the
    /// WS admin tier trusts X-BAP-AccountId, so a leaked admin accountId is effectively a lobby
    /// admin credential. The authorized /admin/lobbies endpoint keeps the full snapshot.
    /// </summary>
    public object[] GetPublicLobbySnapshots()
    {
        return _lobbies.Values
            .Select(lobby => new
            {
                lobby.Id,
                lobby.Starting,
                PlayerCount = lobby.Players.Count,
                Players = lobby.Players.Values
                    .Select(p => new
                    {
                        p.Player.Username,
                        p.Player.CharId,
                        p.Player.IsLeader,
                        p.Player.IsReady,
                        p.Player.TeamId
                    })
                    .ToArray()
            })
            .ToArray();
    }

    public object[] GetMatchSnapshots()
    {
        return _matches.Values
            .Select(match => new
            {
                match.GameId,
                match.Hostname,
                match.WsPort,
                match.KcpPort,
                match.TcpPort,
                match.HttpPort,
                ProcessId = match.Process?.Id,
                HasExited = match.Process?.HasExited
            })
            .ToArray();
    }

    public void RecordGamePing(GamePing ping)
    {
        _logger.LogDebug("Game ping from {GameId} at {Host}:{Ws}/{Kcp}/{Tcp}.",
            ping.GameId,
            ping.Hostname,
            ping.WsPort,
            ping.KcpPort,
            ping.TcpPort);
    }

    public void RecordGameEnded(GameEndedPayload payload)
    {
        int? endedMapId = null;
        int? endedUnityGameModeId = null;
        string[] endedAccounts = [];
        if (!string.IsNullOrWhiteSpace(payload.GameId))
        {
            // Claim the match atomically FIRST (TryRemove) — every other cleanup path does this.
            // The old stop-before-remove order raced the 10s stale sweep: both saw the session,
            // both called StopMatchServer, and the double port release could strip a port quad
            // that a NEW match had already reserved (two matches on the same ports).
            if (_matches.TryRemove(payload.GameId, out GameServerSession? session))
            {
                endedMapId = session.MapId;
                endedUnityGameModeId = session.UnityGameModeId;
                _emptyLobbyMatchSinceUtc.TryRemove(payload.GameId, out _);
                if (_matchAccountIds.TryGetValue(payload.GameId, out string[]? accounts))
                {
                    // Capture BEFORE removing: match-end rewards are scoped to these accounts.
                    // (The old code removed the entry first, so ApplyMatchEndRewards always saw
                    // an empty set and nobody ever received the participation reward.)
                    endedAccounts = accounts;
                    DateTimeOffset endedNow = DateTimeOffset.UtcNow;
                    foreach (string acct in accounts)
                    {
                        if (!string.IsNullOrWhiteSpace(acct)) _postMatchReturnUtc[acct] = endedNow;
                    }
                }
                _matchAccountIds.TryRemove(payload.GameId, out _);

                // Clear the owning lobby's ActiveGameId now that the match is over. It was
                // previously only cleared when a player pressed ready again, so until then the
                // lobby rejected every join-by-code with "already in a match".
                foreach (CustomLobby candidate in _lobbies.Values)
                {
                    if (string.Equals(candidate.ActiveGameId, payload.GameId, StringComparison.OrdinalIgnoreCase))
                    {
                        candidate.ActiveGameId = null;
                    }
                }

                // Grace-stop instead of instant kill: the host POSTs /game-ended and then still has
                // to deliver its end-of-match flow (scoreboard/return-to-lobby RPCs) to connected
                // clients. Killing it in the same instant raced that delivery — clients whose KCP
                // timeout is 60s could sit in the dead match scene until the transport gave up.
                ScheduleMatchServerStop(session, TimeSpan.FromSeconds(10), "game-ended grace");
            }
        }

        // Find the lobby that started this match and apply rewards
        try
        {
            ApplyMatchEndRewards(payload.GameId, endedAccounts, endedMapId, endedUnityGameModeId);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to apply match-end rewards for {GameId}.", payload.GameId);
        }

        _logger.LogInformation("Game ended: {GameId}", payload.GameId);
        _logger.LogInformation("[Analytics] Match ended: {GameId}", payload.GameId);
    }

    /// <summary>
    /// Stop a match host after a short grace period, off the caller's thread. The session must
    /// already be claimed (removed from <c>_matches</c>) so no other cleanup path can double-stop
    /// it. StopMatchServer blocks up to GameServerStopWaitMillis on the process kill, which is
    /// why it must never run inline in a WS/HTTP handler.
    /// </summary>
    private void ScheduleMatchServerStop(GameServerSession session, TimeSpan grace, string reason)
    {
        _ = Task.Run(async () =>
        {
            try
            {
                if (grace > TimeSpan.Zero)
                {
                    await Task.Delay(grace);
                }

                _gameServers.StopMatchServer(session);
                _logger.LogInformation("Stopped match server {GameId} after {Reason}.", session.GameId, reason);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Delayed stop of match server {GameId} failed ({Reason}).", session.GameId, reason);
            }
        });
    }

    private void ApplyMatchEndRewards(string? gameId, string[] matchAccounts, int? mapId = null, int? unityGameModeId = null)
    {
        if (string.IsNullOrWhiteSpace(gameId)) return;

        // Record basic match history
        var historyEntry = new MatchHistoryEntry
        {
            GameId = gameId,
            EndedUtc = DateTimeOffset.UtcNow,
            StartedUtc = DateTimeOffset.UtcNow.AddMinutes(-2), // approximate
            MapId = mapId ?? _options.MatchDefaults.MapId,
            GameModeId = unityGameModeId ?? _options.MatchDefaults.UnityGameMode,
            PlayerCount = 0,
            Players = []
        };

        // Reward only the accounts that were actually in this match (captured at match
        // start in _matchAccountIds and passed in by the caller BEFORE it removed the
        // entry), not every currently-connected socket. Without this scoping, an
        // unauthenticated game-ended call rewards all connected clients.
        ClientConnection[] connectedPlayers;
        if (matchAccounts.Length > 0)
        {
            HashSet<string> matchSet = new(matchAccounts, StringComparer.OrdinalIgnoreCase);
            connectedPlayers = _clients.Values
                .Where(client => matchSet.Contains(client.AccountId))
                .ToArray();
        }
        else
        {
            connectedPlayers = [];
        }
        // The dedicated host reports match completion but NOT per-player standings
        // (GameEndedPayload.Data carries no placements, and the mod only signals a
        // winnerTeamId). Assigning placement by _clients enumeration order would credit
        // an arbitrary socket with the win and silently corrupt ranked ratings every
        // match, so every participant is rewarded equally as a participant and ranked
        // rating is left untouched until real standings are available.
        const int participationPlacement = 0;
        const int participationXp = 75;
        foreach (var client in connectedPlayers)
        {
            // Ensure player exists in economy system before applying rewards
            _economyService.GetOrCreatePlayer(client.AccountId, client.Username);

            // Flat participation reward (no fabricated win/placement ordering).
            var reward = _economyService.CalculateMatchReward(client.AccountId, participationPlacement, 0, connectedPlayers.Length);
            _economyService.ApplyMatchRewards(reward);
            _economyService.RecordCharacterXp(client.AccountId, client.Username, client.CharId, participationXp, "match-end");

            historyEntry.Players.Add(new MatchPlayerEntry
            {
                AccountId = client.AccountId,
                Username = client.Username,
                CharId = client.CharId,
                TeamId = 1,
                Placement = participationPlacement,
                GoldEarned = reward.TotalGold
            });
        }

        historyEntry.PlayerCount = historyEntry.Players.Count;
        _matchHistoryService.RecordMatch(historyEntry);
    }

    public async Task HandleSocketAsync(WebSocket socket, HttpContext context, CancellationToken cancellationToken)
    {
        var connection = CreateConnection(socket, context);

        if (_adminService.IsBanned(connection.AccountId))
        {
            _adminService.Audit("websocket-banned-rejected", "server", connection.AccountId, null);
            try
            {
                await SendAsync(connection, Events.JoinLobbyFail, new
                {
                    warningMessage = "This account is banned from this custom server.",
                    errorCode = "ERR_BANNED"
                }, cancellationToken);
                await socket.CloseAsync(WebSocketCloseStatus.PolicyViolation, "banned", cancellationToken);
            }
            catch (Exception ex)
            {
                // A banned client that drops mid-rejection is not an error worth surfacing.
                _logger.LogDebug(ex, "Banned-connection rejection for {AccountId} failed.", connection.AccountId);
            }
            return;
        }

        _clients[connection.Id] = connection;

        _logger.LogInformation("Client {AccountId} connected. admin={IsAdmin}", connection.AccountId, connection.IsAdmin);
        _logger.LogInformation("[Analytics] Player joined: {Username} (accountId={AccountId})", connection.Username, connection.AccountId);

        try
        {
            // The initial sends MUST live inside this try: a client that disconnects right after
            // the upgrade (port scans, proxy probes) makes SendAsync throw, and outside the try
            // that skipped the finally — leaking the _clients entry (broadcast to a dead socket
            // forever), a phantom "online" friends status, and the queue entry.
            await SendAsync(connection, Events.SocketReady, null, cancellationToken);
            await SendAsync(connection, Events.GameModesUpdated, BuildGameModesUpdatedPayload(), cancellationToken);
            await PushFriendsStateAsync(connection, cancellationToken);
            await NotifyFriendsOfStatusAsync(connection.AccountId, 1, cancellationToken);

            await ReceiveLoopAsync(connection, cancellationToken);
        }
        catch (WebSocketException)
        {
            // Network-level failure during the initial sends: treat as an ordinary disconnect.
        }
        catch (OperationCanceledException)
        {
            // Host shutting down or client gone during the initial sends.
        }
        finally
        {
            _clients.TryRemove(connection.Id, out _);
            _pendingAttestations.TryRemove(connection.Id, out _); // Clean up stale mod challenge nonce
            // If this connection was tied to a live/just-ended match, stamp the post-match window keyed
            // by the stable accountId. On "Exit to Lobby" the client fully disconnects and reconnects,
            // and the cleanup below wipes ActiveGameId/_matchAccountIds — so this accountId stamp is the
            // only signal that survives into the reconnected session, letting the auto-ready that fires
            // right after rejoin be recognized as a post-match return and suppressed (stay in lobby).
            bool wasInTrackedMatch =
                _matchAccountIds.Values.Any(ids => ids.Contains(connection.AccountId, StringComparer.OrdinalIgnoreCase)) ||
                (!string.IsNullOrWhiteSpace(connection.LobbyId) &&
                 _lobbies.TryGetValue(connection.LobbyId, out CustomLobby? disconnectLobby) &&
                 !string.IsNullOrWhiteSpace(disconnectLobby.ActiveGameId));
            if (wasInTrackedMatch)
            {
                _postMatchReturnUtc[connection.AccountId] = DateTimeOffset.UtcNow;
            }
            try
            {
                // Defensive: ensure the queue never holds a phantom entry for a disconnected
                // websocket. RemoveFromLobbyAsync also does this, but if the player was queued
                // without a lobby (or LobbyId was already null) that path early-returns.
                _queueService.LeaveQueue(connection.AccountId);
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Disconnect: queue cleanup raised for {AccountId}.", connection.AccountId);
            }
            try
            {
                await RemoveFromLobbyAsync(connection, CancellationToken.None);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Error during cleanup removal from lobby for {AccountId}.", connection.AccountId);
            }
            _friendsService.RegisterOffline(connection.AccountId);
            try { await NotifyFriendsOfStatusAsync(connection.AccountId, 0, CancellationToken.None); }
            catch (Exception ex) { _logger.LogDebug(ex, "Offline fan-out failed for {AccountId}.", connection.AccountId); }
            // Deliberately NOT disposing connection.SendLock: a broadcast that grabbed this
            // connection from _clients just before removal may still be awaiting the semaphore,
            // and disposing it under that waiter throws ObjectDisposedException into an innocent
            // sender's handler. A plain SemaphoreSlim holds no unmanaged state, so letting the GC
            // collect it is safe.
            _logger.LogInformation("Client {AccountId} disconnected.", connection.AccountId);
            _logger.LogInformation("[Analytics] Player left: {Username} (accountId={AccountId})", connection.Username, connection.AccountId);
        }
    }

    private ClientConnection CreateConnection(WebSocket socket, HttpContext context)
    {
        int number = Interlocked.Increment(ref _playerCounter);
        ClientIdentity identity = ClientIdentityResolver.Resolve(
            context,
            $"custom-{number}",
            $"Player{number}",
            1000 + number);

        _friendsService.RegisterOnline(identity.AccountId, identity.Username, identity.Discriminator);

        // Check if this account has a valid admin grant from a prior WS auth handshake.
        // The auth WS connection performs the 3-step mod attestation + token handshake and
        // stores a timestamped grant in _adminGrants. Any subsequent WS connection (including
        // the game's actual lobby WS) inherits that grant within the AdminGrantTtl window.
        bool hasGrant = _adminGrants.TryGetValue(identity.AccountId, out DateTime grantedAt) &&
                        (DateTime.UtcNow - grantedAt) < AdminGrantTtl;

        // A header-less probe/discovery socket falls back to the minted "Player{N}"/"custom-{N}"
        // names; a genuine client carries X-BAP-Username/accountId through the proxy. Track this so
        // we don't fire phantom "Player 13 joined the lobby" toasts for identity-less connections.
        bool hasRealIdentity = !string.Equals(identity.Username, $"Player{number}", StringComparison.Ordinal) ||
                               !string.Equals(identity.AccountId, ServerAdminService.NormalizeAccountId($"custom-{number}"), StringComparison.Ordinal);

        return new ClientConnection
        {
            Id = Guid.NewGuid(),
            Socket = socket,
            AccountId = identity.AccountId,
            Username = identity.Username,
            Discriminator = identity.Discriminator,
            PlayerId = number,
            HasRealIdentity = hasRealIdentity,
            // WS admin grants come from either:
            // 1. Account in AdminAccountIds (traditional, no token required for WS ops)
            // 2. Successful admin auth handshake (mod attestation + token, stored in _adminGrants)
            IsAdmin = _adminService.IsAdmin(identity.AccountId) || hasGrant
        };
    }

    private async Task ReceiveLoopAsync(ClientConnection connection, CancellationToken cancellationToken)
    {
        byte[] rented = ArrayPool<byte>.Shared.Rent(16 * 1024);
        try
        {
            while (connection.Socket.State == WebSocketState.Open && !cancellationToken.IsCancellationRequested)
            {
                using var message = new MemoryStream();
                WebSocketReceiveResult result;
                do
                {
                    result = await connection.Socket.ReceiveAsync(rented, cancellationToken);
                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await CloseSocketUnderLockAsync(connection, WebSocketCloseStatus.NormalClosure, "closed", cancellationToken);
                        return;
                    }

                    message.Write(rented, 0, result.Count);
                    if (message.Length > MaxIncomingMessageBytes)
                    {
                        // Guard against an unbounded fragmented message exhausting memory.
                        await CloseSocketUnderLockAsync(connection, WebSocketCloseStatus.MessageTooBig, "message too large", cancellationToken);
                        return;
                    }
                }
                while (!result.EndOfMessage);

                string json = Encoding.UTF8.GetString(message.ToArray());
                await HandleMessageAsync(connection, json, cancellationToken);
            }
        }
        catch (OperationCanceledException)
        {
            // Host is shutting down or the client disconnected.
        }
        catch (WebSocketException)
        {
            // Treat network disconnects as ordinary client leave events.
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(rented);
        }
    }

    private async Task HandleMessageAsync(ClientConnection connection, string json, CancellationToken cancellationToken)
    {
        SocketEnvelope? envelope;
        try
        {
            envelope = JsonSerializer.Deserialize<SocketEnvelope>(json, JsonContract.Options);
        }
        catch (JsonException ex)
        {
            _logger.LogWarning(ex, "Ignoring malformed websocket message: {Json}", json);
            return;
        }

        if (envelope is null || string.IsNullOrWhiteSpace(envelope.Event))
        {
            return;
        }

        string evt = NormalizeEvent(envelope.Event);
        _logger.LogDebug("WS RECV {Event} from {AccountId}: {Json}", evt, connection.AccountId, json);

        switch (evt)
        {
            case Events.SocketReady:
                await SendAsync(connection, Events.SocketReady, null, cancellationToken);
                break;
            case Events.JoinLobby:
                await JoinLobbyAsync(connection, DeserializePayload<JoinLobbyPayload>(envelope.Payload), cancellationToken);
                break;
            case Events.SwitchReady:
            case Events.SwitchCustomReady:
                await SwitchReadyAsync(connection, DeserializePayload<BoolPayload>(envelope.Payload), evt, cancellationToken);
                break;
            case Events.UpdateCustomTeam:
                await UpdateTeamAsync(connection, DeserializePayload<TeamPayload>(envelope.Payload), cancellationToken);
                break;
            case Events.UpdateCustomSettings:
                await UpdateSettingsAsync(connection, DeserializePayload<CustomSettingsPayload>(envelope.Payload), cancellationToken);
                break;
            case Events.StartCustomGame:
                await StartCustomGameAsync(connection, DeserializePayload<BoolPayload>(envelope.Payload), cancellationToken);
                break;
            case Events.SwitchGameMode:
                await SwitchGameModeAsync(connection, DeserializePayload<GameModePayload>(envelope.Payload), cancellationToken);
                break;
            case Events.SwitchRegion:
                await SwitchRegionAsync(connection, DeserializePayload<RegionPayload>(envelope.Payload), cancellationToken);
                break;
            case Events.SwitchCharacter:
                await SwitchCharacterAsync(connection, DeserializePayload<CharacterPayload>(envelope.Payload), cancellationToken);
                break;
            case Events.CancelMatchmaking:
            case Events.CancelQueue:
            case Events.LeaveQueue:
            case "QUEUE_LEAVE":
            case "LEAVE_MATCHMAKING":
                await CancelMatchmakingAsync(connection, evt, cancellationToken);
                break;
            case "LOBBIES_LEAVE":
                _logger.LogInformation("LOBBIES_LEAVE from {AccountId} (lobby={LobbyId}) - removing from lobby and queue.",
                    connection.AccountId, connection.LobbyId);
                await RemoveFromLobbyAsync(connection, cancellationToken);
                break;
            case Events.FriendInviteLobby:
                await HandleFriendInviteLobbyAsync(connection, envelope.Payload, cancellationToken);
                break;
            case Events.JoinFriendLobby:
                await HandleJoinFriendLobbyAsync(connection, envelope.Payload, cancellationToken);
                break;
            case Events.AdminAuth:
                await HandleAdminAuthAsync(connection, envelope.Payload, cancellationToken);
                break;
            case Events.ModHello:
                await HandleModHelloAsync(connection, cancellationToken);
                break;
            case Events.ModAuth:
                await HandleModAuthAsync(connection, envelope.Payload, cancellationToken);
                break;
            default:
                // PING is a known keepalive — ignore quietly so it doesn't bury real unknowns.
                if (string.Equals(envelope.Event, "PING", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                // Surface unrecognized events at Information level so a real client session reveals
                // the exact friend/invite WS event strings (the IL2CPP build stripped string
                // literals, so these can't be read statically). Payload kind only — no PII.
                _logger.LogInformation(
                    "Unhandled websocket event '{Event}' from {AccountId} (payloadKind={PayloadKind}).",
                    envelope.Event, connection.AccountId, envelope.Payload.ValueKind);
                break;
        }
    }

    private static T DeserializePayload<T>(JsonElement payload) where T : new()
    {
        if (payload.ValueKind is JsonValueKind.Undefined or JsonValueKind.Null)
        {
            return new T();
        }

        return payload.Deserialize<T>(JsonContract.Options) ?? new T();
    }

    // ===== Admin Auth Handlers =============================================

    /// <summary>Step 1: Client sends MOD_HELLO announcing it has the admin mod.
    /// Server responds with a random challenge nonce.</summary>
    private async Task HandleModHelloAsync(ClientConnection connection, CancellationToken cancellationToken)
    {
        // Generate a random 32-byte nonce and store it for this connection
        string nonce = AdminAuth.GenerateNonce();
        _pendingAttestations[connection.Id] = nonce;

        _logger.LogInformation("MOD_HELLO from {AccountId} — issued challenge.", connection.AccountId);

        await SendAsync(connection, Events.ModChallenge, new { nonce }, cancellationToken);
    }

    /// <summary>Step 2: Client responds to the challenge with
    /// HMAC-SHA256(secret, nonce + accountId). Server verifies and
    /// marks the connection as mod-authenticated.</summary>
    private async Task HandleModAuthAsync(ClientConnection connection, JsonElement payload, CancellationToken cancellationToken)
    {
        if (!_pendingAttestations.TryRemove(connection.Id, out string? expectedNonce) || expectedNonce == null)
        {
            _logger.LogWarning("MOD_AUTH from {AccountId} with no pending challenge.", connection.AccountId);
            await SendAsync(connection, Events.ModAuthOk, new { ok = false, message = "No pending challenge." }, cancellationToken);
            return;
        }

        string? receivedNonce = ReadOptionalString(payload, "nonce");
        string? signature = ReadOptionalString(payload, "signature");

        if (string.IsNullOrWhiteSpace(receivedNonce) || string.IsNullOrWhiteSpace(signature))
        {
            _logger.LogWarning("MOD_AUTH from {AccountId} missing nonce or signature.", connection.AccountId);
            await SendAsync(connection, Events.ModAuthOk, new { ok = false, message = "Missing nonce or signature." }, cancellationToken);
            return;
        }

        // Constant-time compare nonces before verifying HMAC
        if (!CryptographicOperations.FixedTimeEquals(
            Encoding.UTF8.GetBytes(expectedNonce),
            Encoding.UTF8.GetBytes(receivedNonce)))
        {
            await SendAsync(connection, Events.ModAuthOk, new { ok = false, message = "Nonce mismatch." }, cancellationToken);
            return;
        }

        string secret = _adminOptions.AttestationSecret;
        if (string.IsNullOrWhiteSpace(secret))
        {
            _logger.LogWarning("MOD_AUTH: AttestationSecret not configured on server. Skipping attestation for {AccountId}.", connection.AccountId);
            // If no secret is configured, skip attestation and allow admin token auth directly
            connection.IsModAuthenticated = true;
            await SendAsync(connection, Events.ModAuthOk, new { ok = true, message = "Attestation bypassed (no server secret)." }, cancellationToken);
            return;
        }

        bool valid = AdminAuth.VerifyModAttestation(secret, expectedNonce, connection.AccountId, signature);
        if (!valid)
        {
            _logger.LogWarning("MOD_AUTH from {AccountId} — invalid signature.", connection.AccountId);
            await SendAsync(connection, Events.ModAuthOk, new { ok = false, message = "Invalid signature." }, cancellationToken);
            return;
        }

        connection.IsModAuthenticated = true;
        _logger.LogInformation("MOD_AUTH from {AccountId} — attestation passed.", connection.AccountId);

        // After successful attestation, tell the mod to send its admin token
        await SendAsync(connection, Events.ModAuthOk, new { ok = true, requestToken = true }, cancellationToken);
    }

    /// <summary>Step 3: Client sends its admin token. Server validates
    /// token + accountId and grants admin privileges if all checks pass.</summary>
    private async Task HandleAdminAuthAsync(ClientConnection connection, JsonElement payload, CancellationToken cancellationToken)
    {
        // Extract token from payload
        string? token = ReadOptionalString(payload, "token");

        // Require mod attestation first — enforce the 3-step handshake order
        // (MOD_HELLO → MOD_AUTH → ADMIN_AUTH) documented in the protocol.
        if (!connection.IsModAuthenticated)
        {
            _logger.LogWarning("ADMIN_AUTH from {AccountId} — mod attestation required.", connection.AccountId);
            await SendAsync(connection, Events.AdminAuthResult, new { ok = false, message = "Mod attestation required." }, cancellationToken);
            return;
        }

        if (string.IsNullOrWhiteSpace(token))
        {
            await SendAsync(connection, Events.AdminAuthResult, new { ok = false, message = "Token is required." }, cancellationToken);
            return;
        }

        // Validate token if ApiToken is configured
        if (!string.IsNullOrWhiteSpace(_adminOptions.ApiToken))
        {
            if (!AdminAuth.FixedTimeEquals(token, _adminOptions.ApiToken))
            {
                _logger.LogWarning("ADMIN_AUTH from {AccountId} — token mismatch.", connection.AccountId);
                await SendAsync(connection, Events.AdminAuthResult, new { ok = false, message = "Invalid admin token." }, cancellationToken);
                return;
            }
        }

        // Check that account is an admin account
        if (!_adminService.IsAdmin(connection.AccountId))
        {
            _logger.LogWarning("ADMIN_AUTH from {AccountId} — not in AdminAccountIds.", connection.AccountId);
            await SendAsync(connection, Events.AdminAuthResult, new { ok = false, message = "Account is not an admin." }, cancellationToken);
            return;
        }

        // All checks passed — grant admin on this connection AND store
        // in the account-level grant cache so the game's WS (which may
        // connect separately) also gets admin privileges.
        connection.IsAdmin = true;
        _adminGrants[connection.AccountId] = DateTime.UtcNow;
        _logger.LogInformation("ADMIN_AUTH from {AccountId} — admin privileges granted.", connection.AccountId);
        await SendAsync(connection, Events.AdminAuthResult, new { ok = true }, cancellationToken);
    }

    private static string? ReadOptionalString(JsonElement element, string propertyName)
    {
        if (element.ValueKind == JsonValueKind.Undefined || element.ValueKind == JsonValueKind.Null)
            return null;
        if (element.TryGetProperty(propertyName, out JsonElement prop) && prop.ValueKind == JsonValueKind.String)
            return prop.GetString();
        return null;
    }

    private static string NormalizeEvent(string evt)
    {
        string lower = evt.Trim().ToLowerInvariant();
        return lower switch
        {
            "lobbies:join" => Events.JoinLobby,
            "lobbies:leave" => "LOBBIES_LEAVE",
            "lobbies:start" => Events.StartCustomGame,
            "lobbies:cancel" => Events.CancelMatchmaking,
            "lobbies:matchmaking_cancel" => Events.CancelMatchmaking,
            "matchmaking:cancel" => Events.CancelMatchmaking,
            "matchmaking:leave" => Events.CancelMatchmaking,
            "queue:cancel" => Events.CancelQueue,
            "queue:leave" => Events.LeaveQueue,
            "cancel_matchmaking" => Events.CancelMatchmaking,
            "cancel_queue" => Events.CancelQueue,
            "leave_queue" => Events.LeaveQueue,
            "leave_matchmaking" => Events.CancelMatchmaking,
            "join_lobby" => Events.JoinLobby,
            "switch_ready" => Events.SwitchReady,
            "switch_custom_ready" => Events.SwitchCustomReady,
            "update_custom_team" => Events.UpdateCustomTeam,
            "update_custom_settings" => Events.UpdateCustomSettings,
            "start_custom_game" => Events.StartCustomGame,
            "switch_game_mode" => Events.SwitchGameMode,
            "switch_region" => Events.SwitchRegion,
            "switch_char" => Events.SwitchCharacter,
            _ => evt.Trim().Replace('-', '_').ToUpperInvariant()
        };
    }

    private async Task JoinLobbyAsync(ClientConnection connection, JoinLobbyPayload payload, CancellationToken cancellationToken)
    {
        // Delay to ensure the client has processed all initial HTTP responses
        // (chars/listing, profile/levels, etc.) before we send JOIN_LOBBY_SUCCESS
        // which triggers UI initialization that depends on that data.
        await Task.Delay(6000, cancellationToken);

        var normalizationRemovals = new List<(CustomLobby Lobby, LobbyPlayer Removed)>();
        try
        {
            await _gate.WaitAsync(cancellationToken);
            try
            {
                int removedStale = RemoveAccountFromAllLobbiesLocked(connection.AccountId, keepLobbyId: null, normalizationRemovals);
                bool staleQueue = _queueService.LeaveQueue(connection.AccountId);
                if (removedStale > 0 || staleQueue)
                {
                    _logger.LogInformation(
                        "JoinLobby normalized stale state for {AccountId}: removedLobbies={RemovedLobbies} staleQueue={StaleQueue}.",
                        connection.AccountId,
                        removedStale,
                        staleQueue);
                }

            bool joiningByCode = !string.IsNullOrWhiteSpace(payload.LobbyId);
            string lobbyId = joiningByCode ? payload.LobbyId!.Trim().ToUpperInvariant() : CreateLobbyId();
            int lobbyGameModeId = ResolveLobbyGameModeId(payload.GameModeId);

            CustomLobby lobby;
            if (joiningByCode)
            {
                // Join-by-code / invite: resolve an EXISTING lobby, never create one. A typo, stale,
                // or in-match code must fail (wasInvalid) instead of silently minting a phantom solo
                // lobby — that silent-create was why "lobby codes don't work".
                if (!_lobbies.TryGetValue(lobbyId, out CustomLobby? existing))
                {
                    await SendAsync(connection, Events.JoinLobbySuccess, new
                    {
                        lobby = (object?)null,
                        wasFull = false,
                        wasInvalid = true,
                        wasKicked = false
                    }, cancellationToken);
                    _logger.LogInformation("JoinLobby by code {Code} from {AccountId} failed: no such lobby.", lobbyId, connection.AccountId);
                    return;
                }

                if (existing.ActiveGameId != null || existing.Starting)
                {
                    // Starting counts as in-a-match: the bootstrap snapshot (teams/gameAuthIds) is
                    // taken when the leader presses PLAY. A player joining during the multi-second
                    // spawn would receive GAME_STARTED with a gameAuthId the dedicated host never
                    // saw and hang on a dead connect.
                    await SendAsync(connection, Events.JoinLobbySuccess, new
                    {
                        lobby = (object?)null,
                        wasFull = false,
                        wasInvalid = true,
                        wasKicked = false
                    }, cancellationToken);
                    _logger.LogInformation("JoinLobby by code {Code} from {AccountId} failed: lobby already in a match (starting={Starting}).", lobbyId, connection.AccountId, existing.Starting);
                    return;
                }

                int cap = Math.Max(1, existing.CustomSettings.MaxTeams) * Math.Max(1, existing.CustomSettings.TeamSize);
                if (existing.Players.Count >= cap)
                {
                    await SendAsync(connection, Events.JoinLobbySuccess, new
                    {
                        lobby = (object?)null,
                        wasFull = true,
                        wasInvalid = false,
                        wasKicked = false
                    }, cancellationToken);
                    _logger.LogInformation("JoinLobby by code {Code} from {AccountId} failed: lobby full ({Count}/{Cap}).", lobbyId, connection.AccountId, existing.Players.Count, cap);
                    return;
                }

                lobby = existing;
            }
            else
            {
                lobby = _lobbies.GetOrAdd(lobbyId, id => new CustomLobby
                {
                    Id = id,
                    LeaderAccountId = connection.AccountId,
                    Settings = new SettingsData
                    {
                        RegionId = string.IsNullOrWhiteSpace(payload.RegionId) ? _options.MatchDefaults.RegionId : payload.RegionId!,
                        GameModeId = lobbyGameModeId,
                        IsAutoFill = payload.IsAutoFill
                    },
                    CustomSettings = new CustomGameSettingsData
                    {
                        Gamemode = _options.MatchDefaults.UnityGameMode,
                        MapId = 0, // 0 = let PickMapId pick from MapMapping pool
                        TeamSize = _options.MatchDefaults.TeamSize,
                        MaxTeams = _options.MatchDefaults.MaxTeams,
                        BotCount = _options.MatchDefaults.BotTeams,
                        BotDifficulty = _options.MatchDefaults.BotDifficulty,
                        GameModifierIds = (_options.MatchDefaults.GameModifierIds ?? Array.Empty<int>()).ToArray()
                    }
                });
            }

            connection.LobbyId = lobby.Id;
            _economyService.GetOrCreatePlayer(connection.AccountId, connection.Username);
            connection.CharId = _characterUnlocks.ResolveSelectableCharacter(connection.AccountId, payload.CharId, null, _economyService);
            _friendsService.UpdatePlayerLobby(connection.AccountId, lobby.Id);

            var player = connection.ToPlayerData(lobby.LeaderAccountId == connection.AccountId);
            player.TeamId = lobby.NextTeamId(_options.MatchDefaults.MaxTeams);
            lobby.Players[connection.AccountId] = new LobbyPlayer(player, CreateGameAuthId(connection.AccountId));

            var lobbyData = lobby.ToLobbyData();
            // Inject leader's gold and char token balance into lobby payload so client UI
            // shows correct balances for shop, character unlock, and locker access.
            try
            {
                int gold = _economyService.GetGold(connection.AccountId);
                int charTokens = _economyService.GetCharTokens(connection.AccountId);
                lobbyData.Gold = gold;
                lobbyData.Fractals = 0;
                lobbyData.CharTokens = charTokens;
                lobbyData.AccountXp = 100000;
            }
            catch { }

            await SendAsync(connection, Events.JoinLobbySuccess, new
            {
                lobby = lobbyData,
                wasFull = false,
                wasInvalid = false,
                wasKicked = false
            }, cancellationToken);

            // Re-send GAME_MODES_UPDATED after join so the client updates gameModeId from -1 to valid
            await SendAsync(connection, Events.GameModesUpdated, BuildGameModesUpdatedPayload(), cancellationToken);

            // Only announce real players. Header-less probe/discovery sockets fall back to a minted
            // "Player{N}" name; broadcasting their join produced the phantom "Player 13 joined the
            // lobby" toasts. Their slot still exists in the lobby; we just don't toast it.
            if (connection.HasRealIdentity)
            {
                await BroadcastAsync(lobby, Events.LobbyJoined, new { player }, cancellationToken, except: connection.Id);
            }
            else
            {
                _logger.LogInformation(
                    "Suppressed LOBBY_JOINED broadcast for identity-less connection {AccountId} ({Username}).",
                    connection.AccountId, connection.Username);
            }
            }
            finally
            {
                _gate.Release();
            }
        }
        finally
        {
            // Tell the old lobbies (outside the gate) that this player left during join
            // normalization; without this their UIs kept a ghost slot until the next event.
            if (normalizationRemovals.Count > 0)
            {
                await NotifyLobbyRemovalsAsync(normalizationRemovals, CancellationToken.None);
            }
        }
    }

    private async Task SwitchReadyAsync(ClientConnection connection, BoolPayload payload, string requestEvent, CancellationToken cancellationToken)
    {
        if (!TryGetLobby(connection, out CustomLobby? lobby, out LobbyPlayer? lobbyPlayer))
        {
            return;
        }

        if (payload.IsReady)
        {
            // RemoveAccountFromAllLobbiesLocked does compound read-modify-write across _lobbies
            // (removes empty lobbies, reassigns leadership), so it must run under _gate like its
            // other callers. Without the gate it can race a concurrent join/leave and throw from
            // Players.Keys.First() on a lobby emptied mid-iteration.
            int removedStale;
            var staleRemovals = new List<(CustomLobby Lobby, LobbyPlayer Removed)>();
            await _gate.WaitAsync(cancellationToken);
            try
            {
                removedStale = RemoveAccountFromAllLobbiesLocked(connection.AccountId, lobby.Id, staleRemovals);
            }
            finally
            {
                _gate.Release();
            }
            if (staleRemovals.Count > 0)
            {
                await NotifyLobbyRemovalsAsync(staleRemovals, cancellationToken);
            }
            if (removedStale > 0)
            {
                _logger.LogInformation(
                    "Ready event removed {Count} stale lobby membership(s) for {AccountId}; activeLobby={LobbyId}.",
                    removedStale,
                    connection.AccountId,
                    lobby.Id);
            }
        }

        lobbyPlayer.Player.IsReady = payload.IsReady;

        if (requestEvent == Events.SwitchCustomReady)
        {
            await BroadcastAsync(lobby, Events.SwitchCustomReadySuccess, new
            {
                accountId = connection.AccountId,
                isReady = payload.IsReady
            }, cancellationToken);
        }

        await BroadcastAsync(lobby, Events.SwitchReadySuccess, new { isReady = payload.IsReady }, cancellationToken, only: connection.Id);
        await BroadcastAsync(lobby, Events.ReadyUpdated, new
        {
            accountId = connection.AccountId,
            isReady = payload.IsReady
        }, cancellationToken);

        // The retail lobby can send SWITCH_CUSTOM_READY from the normal OPEN/SOLO ready
        // button. Only true CustomGame lobbies should avoid matchmaking queue wiring.
        bool isCustomReadyEvent = requestEvent == Events.SwitchCustomReady;
        bool isCustomGameLobby = lobby.Settings.GameModeId == 10 || lobby.CustomSettings.Gamemode == 10;
        bool shouldWireMatchmakingQueue =
            !isCustomReadyEvent ||
            (!isCustomGameLobby && _options.MatchmakingPolicy != MatchmakingPolicy.CustomOnly);
        _logger.LogInformation(
            "Ready event for {AccountId}: event={Event} ready={Ready} gameMode={GameModeId} customGameMode={CustomGameMode} customLobby={IsCustomLobby} queueWire={QueueWire}.",
            connection.AccountId,
            requestEvent,
            payload.IsReady,
            lobby.Settings.GameModeId,
            lobby.CustomSettings.Gamemode,
            isCustomGameLobby,
            shouldWireMatchmakingQueue);
        if (shouldWireMatchmakingQueue)
        {
            try
            {
                if (payload.IsReady)
                {
                    // Detect a post-match auto-requeue: the BAPBAP client auto-sends a ready frame after a
                    // match, which would otherwise re-queue the player straight into a new prematch/char-
                    // select. Capture the "returning from a match" signal BEFORE the release calls clear it.
                    bool suppressFlag = HasValidSuppressFlag(connection.AccountId);
                    bool returningFromMatch =
                        !string.IsNullOrWhiteSpace(lobby.ActiveGameId) ||
                        _matchAccountIds.Values.Any(ids => ids.Contains(connection.AccountId, StringComparer.OrdinalIgnoreCase));
                    bool withinSuppressWindow =
                        _postMatchReturnUtc.TryGetValue(connection.AccountId, out DateTimeOffset endedAt) &&
                        (DateTimeOffset.UtcNow - endedAt) <= PostMatchRequeueSuppression;

                    // A ready/queue event on the lobby socket while a match is still tracked means the
                    // player is back in the lobby (returned or kicked from that match). The match's slot
                    // is otherwise never freed (lobby.ActiveGameId is never cleared), so under
                    // MaxConcurrentMatches=1 the phantom match blocks this re-queue forever.
                    ReleaseAbandonedMatchForLobby(lobby, "ready/queue after returning to lobby");
                    // Matchmaking stores ActiveGameId on a synthetic MM lobby, not this one, so also
                    // release by account so a returning matchmaking player frees the slot immediately
                    // instead of waiting minutes for the empty-lobby cleanup grace to prune it.
                    ReleaseAbandonedMatchesForAccount(connection.AccountId, "ready/queue after returning to lobby");

                    if (suppressFlag || returningFromMatch || withinSuppressWindow)
                    {
                        // Keep the player in the lobby instead of auto-requeueing. The BAPBAP client sends
                        // a BURST of ready frames after a match/reconnect, so we must NOT clear the 30s
                        // window here — clearing it let the FIRST auto-ready be suppressed but the SECOND
                        // (~1s later) sail through into JoinQueue and re-match. The time window absorbs the
                        // whole burst; a deliberate Play after the window expires queues normally. The
                        // one-shot flag is consumed (harmless — the window does the durable work).
                        _suppressNextReadyAfterMatch.TryRemove(connection.AccountId, out _);
                        _queueService.LeaveQueue(connection.AccountId);
                        lobbyPlayer.Player.IsReady = false;
                        await BroadcastAsync(lobby, Events.SwitchReadySuccess, new { isReady = false }, cancellationToken, only: connection.Id);
                        // SWITCH_CUSTOM_READY_SUCCESS is the channel that actually repaints the lobby
                        // ready button; without it the button can stay stuck showing "in queue" / the
                        // brief "match found" even though the requeue was suppressed.
                        await BroadcastAsync(lobby, Events.SwitchCustomReadySuccess, new { accountId = connection.AccountId, isReady = false }, cancellationToken);
                        await BroadcastAsync(lobby, Events.ReadyUpdated, new { accountId = connection.AccountId, isReady = false }, cancellationToken);
                        await BroadcastAsync(lobby, Events.MatchmakingExited, new { accountId = connection.AccountId, isCounting = false }, cancellationToken, only: connection.Id);
                        await BroadcastAsync(lobby, Events.MatchmakingLeftLegacy, new { isCounting = false }, cancellationToken, only: connection.Id);
                        // Explicit cancel-success so the button leaves the InQueue state (mirrors the
                        // proven CancelMatchmakingAsync reset set).
                        await BroadcastAsync(lobby, Events.CancelMatchmakingSuccess, new { accountId = connection.AccountId }, cancellationToken, only: connection.Id);
                        _logger.LogInformation(
                            "Suppressed post-match auto-requeue for {AccountId} (flag={Flag} returningFromMatch={Returning} window={Window}); staying in lobby.",
                            connection.AccountId, suppressFlag, returningFromMatch, withinSuppressWindow);
                        return;
                    }

                    int charId = _characterUnlocks.ResolveSelectableCharacter(connection.AccountId, lobbyPlayer.Player.CharId, lobbyPlayer.Player.CharId, _economyService);
                    lobbyPlayer.Player.CharId = charId;
                    connection.CharId = charId;
                    var rankedPlayer = _rankedService.GetOrCreatePlayer(connection.AccountId, connection.Username);
                    var qResult = _queueService.JoinQueue(connection.AccountId, connection.Username, lobbyPlayer.Player.Discriminator, charId, rankedPlayer.Points);
                    _logger.LogInformation("Ready->Queue join for {AccountId}: ok={Ok} charId={CharId} pos={Pos} secs={Secs}",
                        connection.AccountId, qResult.Ok, charId, qResult.QueuePosition, qResult.SecondsRemaining);

                    // Send queue status events so the client's Ready button enters InQueue state
                    await BroadcastAsync(lobby, Events.MatchmakingEntered, new
                    {
                        players = lobby.Players.Values.Select(p => p.Player).ToArray()
                    }, cancellationToken);
                }
                else
                {
                    bool wasInQueue = _queueService.LeaveQueue(connection.AccountId);
                    int readyCleared = await MarkAccountUnreadyEverywhereAsync(connection.AccountId, "ready-false", cancellationToken);
                    _logger.LogInformation("Ready->Unready for {AccountId} (lobby={LobbyId}) wasInQueue={WasInQueue} readyCleared={ReadyCleared}",
                        connection.AccountId, lobby.Id, wasInQueue, readyCleared);

                    // BAPBAP client handler is HandleMatchmakingExitedMessage. The previous
                    // MATCHMAKING_LEFT name was a no-op on the client - the cancel UI never
                    // got the signal, so the player UI hung in queue mode forever.
                    await BroadcastAsync(lobby, Events.MatchmakingExited, new
                    {
                        accountId = connection.AccountId,
                        isCounting = false
                    }, cancellationToken, only: connection.Id);

                    // Legacy alias for any older client path that listens on MATCHMAKING_LEFT.
                    await BroadcastAsync(lobby, Events.MatchmakingLeftLegacy, new { isCounting = false }, cancellationToken, only: connection.Id);
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Ready->Queue wiring failed for {AccountId}", connection.AccountId);
            }
        }
    }

    /// <summary>
    /// Cancel matchmaking / leave queue WITHOUT removing the player from their lobby.
    /// BAPBAP's "Cancel" button on the queue/ready screen sends CANCEL_MATCHMAKING and
    /// expects to land back in the lobby ready-screen, not back at the main menu.
    ///
    /// Previously this event was aliased to LOBBIES_LEAVE which destroyed the lobby state
    /// server-side while the client UI still showed the lobby - the textbook "queue glitch /
    /// requires restart" symptom.
    /// </summary>
    private async Task CancelMatchmakingAsync(ClientConnection connection, string requestEvent, CancellationToken cancellationToken)
    {
        // Always pull this player out of the matchmaking queue, even if the lobby state is
        // already broken. This is the safety-net for "stuck in queue" reports.
        bool wasInQueue = _queueService.LeaveQueue(connection.AccountId);
        int readyCleared = await MarkAccountUnreadyEverywhereAsync(connection.AccountId, requestEvent, cancellationToken);

        if (!TryGetLobby(connection, out CustomLobby? lobby, out LobbyPlayer? lobbyPlayer))
        {
            _logger.LogInformation(
                "{Event} from {AccountId}: not in any lobby (lobbyId={LobbyId}). wasInQueue={WasInQueue} readyCleared={ReadyCleared}. Sending CANCEL_MATCHMAKING_SUCCESS so client unsticks.",
                requestEvent, connection.AccountId, connection.LobbyId, wasInQueue, readyCleared);

            // Even with no lobby, acknowledge so the client UI exits the queue/ready state.
            await SendAsync(connection, Events.CancelMatchmakingSuccess, new
            {
                accountId = connection.AccountId,
                wasInQueue,
                lobbyId = (string?)null
            }, cancellationToken);
            return;
        }

        // Flip the player back to unready so the lobby ready screen shows the right state
        // when the client UI returns to it.
        lobbyPlayer.Player.IsReady = false;

        _logger.LogInformation(
            "{Event} from {AccountId} (lobby={LobbyId}, leader={LeaderId}). wasInQueue={WasInQueue} readyCleared={ReadyCleared}. Marked unready, staying in lobby.",
            requestEvent, connection.AccountId, lobby.Id, lobby.LeaderAccountId, wasInQueue, readyCleared);

        // 1) Acknowledge to the requesting client so the queue UI dismisses.
        //    Client handler: HandleCancelMatchmakingSuccessMessage.
        await SendAsync(connection, Events.CancelMatchmakingSuccess, new
        {
            accountId = connection.AccountId,
            wasInQueue,
            lobbyId = lobby.Id,
            isReady = false
        }, cancellationToken);

        // 2) Tell every lobby member the queue/matchmaking session for this player is over.
        //    Client handler: HandleMatchmakingExitedMessage.
        await BroadcastAsync(lobby, Events.MatchmakingExited, new
        {
            accountId = connection.AccountId,
            isCounting = false
        }, cancellationToken);

        // 3) Legacy alias.
        await BroadcastAsync(lobby, Events.MatchmakingLeftLegacy, new { isCounting = false }, cancellationToken, only: connection.Id);

        // 4) Reflect the unready state to the lobby so the panel updates.
        await BroadcastAsync(lobby, Events.SwitchReadySuccess, new { isReady = false }, cancellationToken, only: connection.Id);
        // The friends/lobby ready button is driven by the CUSTOM-ready channel on ready-up (see SwitchReadyAsync),
        // so it must be reset on the same channel here or it stays stuck "in queue" until the player leaves the lobby.
        await BroadcastAsync(lobby, Events.SwitchCustomReadySuccess, new
        {
            accountId = connection.AccountId,
            isReady = false
        }, cancellationToken);
        await BroadcastAsync(lobby, Events.ReadyUpdated, new
        {
            accountId = connection.AccountId,
            isReady = false
        }, cancellationToken);

        // 5) Push a fresh queue snapshot so any client showing queue stats updates immediately.
        try
        {
            var status = _queueService.GetStatus();
            await BroadcastAsync(lobby, Events.QueueUpdated, new
            {
                playerCount = status.PlayerCount,
                secondsRemaining = status.SecondsRemaining,
                isActive = status.IsActive
            }, cancellationToken, only: connection.Id);
        }
        catch (Exception ex)
        {
            _logger.LogDebug(ex, "QUEUE_UPDATED broadcast skipped after cancel for {AccountId}.", connection.AccountId);
        }
    }

    private async Task UpdateTeamAsync(ClientConnection connection, TeamPayload payload, CancellationToken cancellationToken)
    {
        if (!TryGetLobby(connection, out CustomLobby? lobby, out LobbyPlayer? lobbyPlayer))
        {
            return;
        }

        lobbyPlayer.Player.TeamId = Math.Max(0, payload.TeamId);
        await BroadcastAsync(lobby, Events.UpdateCustomTeamSuccess, new
        {
            player = lobbyPlayer.Player,
            warningMessage = ""
        }, cancellationToken);
    }

    private async Task UpdateSettingsAsync(ClientConnection connection, CustomSettingsPayload payload, CancellationToken cancellationToken)
    {
        if (!TryGetLobby(connection, out CustomLobby? lobby, out _))
        {
            return;
        }

        if (!CanControlLobby(connection, lobby))
        {
            await SendAsync(connection, Events.UpdateCustomSettingsFail, new
            {
                warningMessage = "Only the lobby leader or a configured server admin can change custom game settings.",
                errorCode = "ERR_NOT_LEADER"
            }, cancellationToken);
            return;
        }

        if (payload.Settings is not null)
        {
            lobby.CustomSettings = payload.Settings;
            lobby.Settings.GameModeId = ResolveLobbyGameModeId(lobby.Settings.GameModeId);
        }

        await BroadcastAsync(lobby, Events.UpdateCustomSettingsSuccess, new
        {
            settings = lobby.CustomSettings,
            warningMessage = "",
            errorCode = "",
            maxTeams = lobby.CustomSettings.MaxTeams,
            mapMapping = BuildAdvertisedMapMapping()
        }, cancellationToken);
    }

    private async Task SwitchGameModeAsync(ClientConnection connection, GameModePayload payload, CancellationToken cancellationToken)
    {
        if (!TryGetLobby(connection, out CustomLobby? lobby, out _))
        {
            _logger.LogWarning("SWITCH_GAME_MODE from {AccountId} rejected: not in a lobby.", connection.AccountId);
            return;
        }

        if (!CanControlLobby(connection, lobby))
        {
            _logger.LogWarning(
                "SWITCH_GAME_MODE from {AccountId} rejected: not lobby controller. lobby={LobbyId} leader={Leader} admin={IsAdmin}.",
                connection.AccountId, lobby.Id, lobby.LeaderAccountId, connection.IsAdmin);
            await SendAsync(connection, Events.UpdateCustomSettingsFail, new
            {
                warningMessage = "Only the lobby leader or a configured server admin can change custom game settings.",
                errorCode = "ERR_NOT_LEADER"
            }, cancellationToken);
            return;
        }

        // Only accept a mode the server actually advertises (includes 0=Warmup). A non-advertised
        // or negative id leaves the lobby unchanged rather than silently snapping to Solos.
        int requested = payload.GameModeId;
        int[] enabled = ParseEnabledGameModeIds();
        if (requested < 0 || !enabled.Contains(requested))
        {
            _logger.LogWarning(
                "SWITCH_GAME_MODE from {AccountId} rejected: mode {Requested} not in enabled set [{Enabled}].",
                connection.AccountId, requested, string.Join(",", enabled));
            await SendAsync(connection, Events.UpdateCustomSettingsFail, new
            {
                warningMessage = $"Game mode {requested} is not available on this server.",
                errorCode = "ERR_MODE_DISABLED"
            }, cancellationToken);
            return;
        }

        _logger.LogInformation(
            "SWITCH_GAME_MODE from {AccountId} ACCEPTED: lobby={LobbyId} mode {Old}->{New}; broadcasting success+updated+settings.",
            connection.AccountId, lobby.Id, lobby.CustomSettings.Gamemode, requested);

        lobby.Settings.GameModeId = requested;
        lobby.CustomSettings.Gamemode = requested;

        // Team size + player cap + bots come from the per-mode config (falls back to derived team
        // size and queue bot defaults). Picking "Duos" boots 2-per-team instead of all-solo.
        (int teamSize, int maxTeams, int botCount, int botDifficulty) = ResolveModeSettings(requested);
        lobby.CustomSettings.TeamSize = teamSize;
        lobby.CustomSettings.MaxTeams = maxTeams;
        lobby.CustomSettings.BotCount = botCount;
        lobby.CustomSettings.BotDifficulty = botDifficulty;

        await BroadcastAsync(lobby, Events.SwitchGameModeSuccess, new { gameModeId = requested }, cancellationToken, only: connection.Id);
        await BroadcastAsync(lobby, Events.GameModeUpdated, new { gameModeId = requested }, cancellationToken);
        // The lobby UI re-renders mode/teams from UPDATE_CUSTOM_SETTINGS_SUCCESS, not GAME_MODE_UPDATED,
        // so without this broadcast the picked mode tile never visually updates.
        await BroadcastAsync(lobby, Events.UpdateCustomSettingsSuccess, new
        {
            settings = lobby.CustomSettings,
            warningMessage = "",
            errorCode = "",
            maxTeams = lobby.CustomSettings.MaxTeams,
            mapMapping = BuildAdvertisedMapMapping()
        }, cancellationToken);
    }

    private async Task SwitchRegionAsync(ClientConnection connection, RegionPayload payload, CancellationToken cancellationToken)
    {
        if (!TryGetLobby(connection, out CustomLobby? lobby, out _))
        {
            return;
        }

        if (!CanControlLobby(connection, lobby))
        {
            await SendAsync(connection, Events.UpdateCustomSettingsFail, new
            {
                warningMessage = "Only the lobby leader or a configured server admin can change custom game settings.",
                errorCode = "ERR_NOT_LEADER"
            }, cancellationToken);
            return;
        }

        lobby.Settings.RegionId = string.IsNullOrWhiteSpace(payload.RegionId) ? _options.MatchDefaults.RegionId : payload.RegionId!;
        await BroadcastAsync(lobby, Events.SwitchRegionSuccess, new { regionId = lobby.Settings.RegionId }, cancellationToken, only: connection.Id);
        await BroadcastAsync(lobby, Events.RegionUpdated, new { regionId = lobby.Settings.RegionId }, cancellationToken);
    }

    private async Task SwitchCharacterAsync(ClientConnection connection, CharacterPayload payload, CancellationToken cancellationToken)
    {
        if (!TryGetLobby(connection, out CustomLobby? lobby, out LobbyPlayer? lobbyPlayer))
        {
            return;
        }

        int effectiveCharId = _characterUnlocks.ResolveSelectableCharacter(connection.AccountId, payload.CharId, lobbyPlayer.Player.CharId, _economyService);
        lobbyPlayer.Player.CharId = effectiveCharId;
        connection.CharId = lobbyPlayer.Player.CharId;
        bool updatedQueuedEntry = _queueService.UpdateQueuedCharacter(connection.AccountId, lobbyPlayer.Player.CharId);
        _logger.LogInformation("Character switch for {AccountId} in lobby {LobbyId}: requested={RequestedCharId} effective={CharId} updatedQueuedEntry={UpdatedQueuedEntry}.",
            connection.AccountId, lobby.Id, payload.CharId, lobbyPlayer.Player.CharId, updatedQueuedEntry);
        await BroadcastAsync(lobby, Events.SwitchCharacterSuccess, new { charId = lobbyPlayer.Player.CharId }, cancellationToken, only: connection.Id);
        await BroadcastAsync(lobby, Events.CharacterUpdated, new
        {
            accountId = connection.AccountId,
            charId = lobbyPlayer.Player.CharId
        }, cancellationToken);
    }

    private async Task StartCustomGameAsync(ClientConnection connection, BoolPayload payload, CancellationToken cancellationToken)
    {
        if (_options.MatchmakingPolicy == MatchmakingPolicy.MatchmakingOnly)
        {
            await SendAsync(connection, Events.StartCustomGameFail, new
            {
                warningMessage = "Custom matches are disabled on this server. Use the matchmaking queue.",
                errorCode = "ERR_CUSTOM_DISABLED",
                showForceStartModal = false
            }, cancellationToken);
            return;
        }

        if (!TryGetLobby(connection, out CustomLobby? lobby, out _))
        {
            return;
        }

        if (!CanControlLobby(connection, lobby))
        {
            await SendAsync(connection, Events.StartCustomGameFail, new
            {
                warningMessage = "Only the lobby leader or a configured server admin can start the game.",
                errorCode = "ERR_NOT_LEADER",
                showForceStartModal = false
            }, cancellationToken);
            return;
        }

        if (!payload.ForceStart && lobby.Players.Values.Any(player => !player.Player.IsReady && player.Player.AccountId != lobby.LeaderAccountId))
        {
            await SendAsync(connection, Events.StartCustomGameFail, new
            {
                warningMessage = "Not every player is ready.",
                errorCode = "ERR_NOTREADY",
                showForceStartModal = true
            }, cancellationToken);
            return;
        }

        // Claim the start atomically so two concurrent START_CUSTOM_GAME calls for the same
        // lobby (e.g. the leader pressing PLAY while an admin issues force-start on a separate
        // socket) can't both spawn a dedicated server and orphan the first.
        bool claimedStart = false;
        await _gate.WaitAsync(cancellationToken);
        try
        {
            if (!lobby.Starting && string.IsNullOrWhiteSpace(lobby.ActiveGameId))
            {
                lobby.Starting = true;
                claimedStart = true;
            }
        }
        finally
        {
            _gate.Release();
        }

        if (!claimedStart)
        {
            await SendAsync(connection, Events.StartCustomGameFail, new
            {
                warningMessage = "A match is already starting or running for this lobby.",
                errorCode = "ERR_ALREADY_STARTING",
                showForceStartModal = false
            }, cancellationToken);
            return;
        }

        try
        {
            int prunedMatches = CleanupStaleMatches();
            if (prunedMatches > 0)
            {
                _logger.LogInformation(
                    "Pruned {PrunedMatches} stale/empty match(es) before custom match capacity check.",
                    prunedMatches);
                await DelayAfterMatchCleanupAsync("custom", prunedMatches, cancellationToken);
            }
        }
        catch
        {
            // The start claim is held but no process exists yet. Without this rollback a leader
            // disconnect during the cleanup delay (OperationCanceledException from Task.Delay)
            // left lobby.Starting stuck true and every later START_CUSTOM_GAME failed with
            // ERR_ALREADY_STARTING until the lobby emptied.
            lobby.Starting = false;
            throw;
        }

        bool slotReserved = false;
        if (_options.MaxConcurrentMatches > 0)
        {
            // Reserve a slot atomically so two concurrent START_CUSTOM_GAME calls can't both
            // pass the check before either is recorded in _matches (which only happens after
            // the multi-second game-process spawn below).
            int reserved = Interlocked.Increment(ref _matchReservations);
            if (_matches.Count + reserved > _options.MaxConcurrentMatches)
            {
                Interlocked.Decrement(ref _matchReservations);
                lobby.Starting = false;
                _logger.LogWarning(
                    "Custom match start blocked: server at capacity ({Active}/{Max}). Account={AccountId} Lobby={LobbyId} ERR_SERVER_FULL.",
                    _matches.Count, _options.MaxConcurrentMatches, connection.AccountId, lobby.Id);
                await SendAsync(connection, Events.StartCustomGameFail, new
                {
                    warningMessage = $"Server is at capacity ({_matches.Count}/{_options.MaxConcurrentMatches} active matches). Try again in a moment.",
                    errorCode = "ERR_SERVER_FULL",
                    showForceStartModal = false
                }, cancellationToken);
                return;
            }
            slotReserved = true;
        }

        string gameId = $"custom-{DateTimeOffset.UtcNow:yyyyMMddHHmmss}-{RandomNumberGenerator.GetInt32(1000, 9999)}";
        int unityGameMode = MapMatchmakingToUnityGameMode(lobby.CustomSettings.Gamemode);
        int mapId = PickMapId(unityGameMode, lobby.CustomSettings.MapId);
        MatchBootstrap bootstrap = CreateBootstrap(lobby, gameId, mapId);
        GameServerSession session;
        try
        {
            lobby.Starting = true;
            session = await _gameServers.StartMatchServerAsync(bootstrap, cancellationToken);
        }
        catch (Exception ex)
        {
            if (slotReserved) Interlocked.Decrement(ref _matchReservations);
            lobby.Starting = false;
            _logger.LogWarning(ex, "Failed to start custom game for lobby {LobbyId}.", lobby.Id);
            await SendAsync(connection, Events.StartCustomGameFail, new
            {
                warningMessage = "The game server could not be started or did not accept match bootstrap data.",
                errorCode = "ERR_GAME_SERVER_BOOTSTRAP",
                showForceStartModal = false
            }, cancellationToken);
            return;
        }

        // The lobby is still live in _lobbies during the multi-second spawn above but has no
        // ActiveGameId yet, so if every player disconnected while it spawned, RemoveFromLobbyAsync
        // already removed the lobby and StopLobbyMatchIfEmpty early-returned (ActiveGameId null).
        // Re-check liveness before recording the match, mirroring the matchmaking path, so the
        // freshly spawned game process isn't orphaned with no lobby pointing at it.
        try
        {
            // Once a game process exists, this cleanup/recording section must run even if the
            // leader's per-socket token cancels. Otherwise the reservation, process, and Starting
            // flag can leak in the tiny window after StartMatchServerAsync returns.
            await _gate.WaitAsync(CancellationToken.None);
            try
            {
                if (!_lobbies.TryGetValue(lobby.Id, out CustomLobby? activeLobby) ||
                    activeLobby.Players.IsEmpty ||
                    !activeLobby.Players.Keys.Any(accountId => _clients.Values.Any(client =>
                        string.Equals(client.AccountId, accountId, StringComparison.OrdinalIgnoreCase))))
                {
                    if (slotReserved) Interlocked.Decrement(ref _matchReservations);
                    slotReserved = false;
                    lobby.Starting = false;
                    // Off-thread: this branch holds the global _gate; a synchronous kill+wait here
                    // (up to GameServerStopWaitMillis, longer under Wine) stalls every lobby
                    // operation on the server.
                    ScheduleMatchServerStop(session, TimeSpan.Zero, "custom start with no connected players");
                    _logger.LogWarning(
                        "Custom game {GameId} bootstrapped after all lobby players disconnected. Stopped empty server. lobby={LobbyId}",
                        gameId,
                        lobby.Id);
                    return;
                }
            }
            finally
            {
                _gate.Release();
            }

            _matches[gameId] = session;
            // The match is now counted in _matches; release the pre-spawn reservation.
            if (slotReserved) Interlocked.Decrement(ref _matchReservations);
            slotReserved = false;
            _matchAccountIds[gameId] = lobby.Players.Keys.ToArray();
            foreach (string matchAcct in lobby.Players.Keys) _suppressNextReadyAfterMatch[matchAcct] = DateTimeOffset.UtcNow;
            _emptyLobbyMatchSinceUtc.TryRemove(gameId, out _);
            lobby.ActiveGameId = gameId;
            lobby.Starting = false;
        }
        catch
        {
            if (slotReserved) Interlocked.Decrement(ref _matchReservations);
            lobby.Starting = false;
            ScheduleMatchServerStop(session, TimeSpan.Zero, "custom start recording failed");
            throw;
        }

        await BroadcastAsync(lobby, Events.StartCustomGameSuccess, new
        {
            message = "Starting custom game."
        }, cancellationToken);

        QueueMatchedPayload queuePayload = CreateQueueMatchedPayload(lobby, mapId);
        await BroadcastAsync(lobby, Events.QueueMatched, queuePayload, cancellationToken);
        _logger.LogInformation("[Analytics] Match started: {GameId} mapId={MapId} players={PlayerCount}", gameId, mapId, lobby.Players.Count);

        LogImmediateGameStartDispatch(gameId, session, lobby.Players.Count, "custom");

        foreach (LobbyPlayer lobbyPlayer in lobby.Players.Values)
        {
            // Multicast GAME_STARTED to ALL connections of this account so visible game clients
            // AND test/admin sockets all receive it (multiple sockets per account are allowed).
            ClientConnection[] targets = _clients.Values
                .Where(client => string.Equals(client.AccountId, lobbyPlayer.Player.AccountId, StringComparison.OrdinalIgnoreCase))
                .ToArray();
            if (targets.Length == 0)
            {
                continue;
            }

            foreach (ClientConnection target in targets)
            {
                try
                {
                    await SendAsync(target, Events.GameStarted, new GameStartedPayload
                    {
                        GameId = gameId,
                        GameAuthId = lobbyPlayer.GameAuthId,
                        GameDns = session.Hostname,
                        WsPort = session.WsPort,
                        KcpPort = session.KcpPort,
                        TcpPort = session.TcpPort,
                        MapId = mapId,
                        LevelId = mapId,
                        UnityGameMode = unityGameMode
                    }, cancellationToken);
                }
                catch (Exception ex)
                {
                    // One dead peer socket must not abort GAME_STARTED dispatch to the rest of the match.
                    _logger.LogWarning(ex, "Failed to send GAME_STARTED to {AccountId} in {GameId}.", target.AccountId, gameId);
                }
            }
        }

    }

    public async Task<bool> StartMatchmakingGameAsync(QueueEntry[] entries, CancellationToken cancellationToken)
    {
        if (entries.Length == 0)
        {
            return false;
        }

        int prunedMatches = CleanupStaleMatches();
        if (prunedMatches > 0)
        {
            _logger.LogInformation(
                "Pruned {PrunedMatches} stale/empty match(es) before matchmaking capacity check.",
                prunedMatches);
            await DelayAfterMatchCleanupAsync("matchmaking", prunedMatches, cancellationToken);
        }

        // Factor in custom-match reservations in flight (spawned but not yet in _matches) so the
        // two start paths share one capacity accounting and can't together overshoot MaxConcurrentMatches.
        int inFlightReservations = Volatile.Read(ref _matchReservations);
        if (_options.MaxConcurrentMatches > 0 && _matches.Count + inFlightReservations >= _options.MaxConcurrentMatches)
        {
            _logger.LogWarning(
                "Matchmaking match start skipped: server at capacity ({Active}+{Reserved}/{Max}). Players will remain in queue.",
                _matches.Count, inFlightReservations, _options.MaxConcurrentMatches);
            return false;
        }

        bool slotReserved = false;
        if (_options.MaxConcurrentMatches > 0)
        {
            int reserved = Interlocked.Increment(ref _matchReservations);
            if (_matches.Count + reserved > _options.MaxConcurrentMatches)
            {
                Interlocked.Decrement(ref _matchReservations);
                _logger.LogWarning(
                    "Matchmaking match start skipped: server at capacity after reservation ({Active}+{Reserved}/{Max}). Players will remain in queue.",
                    _matches.Count, reserved, _options.MaxConcurrentMatches);
                return false;
            }
            slotReserved = true;
        }

        CustomLobby lobby;
        var mmStaleRemovals = new List<(CustomLobby Lobby, LobbyPlayer Removed)>();
        await _gate.WaitAsync(cancellationToken);
        try
        {
            ClientConnection[] connectedPlayers = entries
                .Select(entry => _clients.Values.FirstOrDefault(client =>
                    string.Equals(client.AccountId, entry.AccountId, StringComparison.OrdinalIgnoreCase)))
                .Where(client => client is not null)
                .Cast<ClientConnection>()
                .DistinctBy(client => client.AccountId)
                .ToArray();

            if (connectedPlayers.Length == 0)
            {
                _logger.LogWarning(
                    "Matchmaking queue was ready, but no queued players had an active websocket. Dropping {Count} stale entry(ies) - returning success so they are NOT requeued.",
                    entries.Length);
                // Returning `true` makes MatchmakingHostedService skip RequeuePlayers, which is
                // exactly what we want: no live sockets means the entries are truly dead and
                // would otherwise create a zombie loop (queue fires every 30s, no players, requeue,
                // fire again, ...).
                if (slotReserved) Interlocked.Decrement(ref _matchReservations);
                slotReserved = false;
                return true;
            }

            int removedOldLobbyMemberships = 0;
            foreach (ClientConnection client in connectedPlayers)
            {
                removedOldLobbyMemberships += RemoveAccountFromAllLobbiesLocked(client.AccountId, keepLobbyId: null, mmStaleRemovals);
            }

            if (removedOldLobbyMemberships > 0)
            {
                _logger.LogInformation(
                    "Matchmaking start normalized stale lobby memberships before creating the match lobby: removed={RemovedCount} accounts=[{Accounts}].",
                    removedOldLobbyMemberships,
                    string.Join(",", connectedPlayers.Select(client => client.AccountId)));
            }

            string lobbyId = $"MM{CreateLobbyId()}";
            // Mode + team size come from the queued players (first entry's mode wins for a mixed
            // queue — a fine interim for a small private server). Duos->2/team, Trios->3/team.
            int queuedMode = entries.Length > 0 ? entries[0].GameModeId : _queueOptions.DefaultGameMode;
            // Team size + cap + bots come from the per-mode config (falls back to derived team size
            // and queue defaults). Picking Duos/Trios in the lobby now drives 2/3-per-team matches.
            (int queuedTeamSize, int modeMaxTeams, int requestedBotCount, int modeBotDifficulty) = ResolveModeSettings(queuedMode);
            int maxBotCount = Math.Max(0, _queueOptions.MaxBotCount);
            int effectiveBotCount = maxBotCount > 0
                ? Math.Min(requestedBotCount, maxBotCount)
                : requestedBotCount;
            if (effectiveBotCount != requestedBotCount)
            {
                _logger.LogWarning(
                    "Matchmaking bot count clamped for stability: requested={RequestedBotCount} max={MaxBotCount} effective={EffectiveBotCount}.",
                    requestedBotCount,
                    maxBotCount,
                    effectiveBotCount);
            }

            lobby = new CustomLobby
            {
                Id = lobbyId,
                LeaderAccountId = connectedPlayers[0].AccountId,
                Settings = new SettingsData
                {
                    RegionId = _options.MatchDefaults.RegionId,
                    GameModeId = DefaultLobbyGameModeId,
                    IsAutoFill = true
                },
                CustomSettings = new CustomGameSettingsData
                {
                    Gamemode = queuedMode,
                    MapId = Math.Max(0, _queueOptions.DefaultMapId),
                    TeamSize = queuedTeamSize,
                    // Honor the per-mode cap, but never fewer teams than needed to fit everyone queued.
                    MaxTeams = Math.Max(modeMaxTeams, (connectedPlayers.Length + queuedTeamSize - 1) / queuedTeamSize),
                    BotCount = effectiveBotCount,
                    BotDifficulty = modeBotDifficulty,
                    MatchmakingGameMode = _options.MatchDefaults.MatchmakingGameMode,
                    GameModifierIds = (_options.MatchDefaults.GameModifierIds ?? Array.Empty<int>()).ToArray()
                }
            };

            int teamId = 1;
            foreach (ClientConnection client in connectedPlayers)
            {
                QueueEntry? entry = entries.FirstOrDefault(queueEntry =>
                    string.Equals(queueEntry.AccountId, client.AccountId, StringComparison.OrdinalIgnoreCase));

                client.LobbyId = lobby.Id;
                int requestedCharId = entry is not null && CharacterCatalog.IsKnownId(entry.CharId) ? entry.CharId : client.CharId;
                client.CharId = _characterUnlocks.ResolveSelectableCharacter(client.AccountId, requestedCharId, client.CharId, _economyService);
                _friendsService.UpdatePlayerLobby(client.AccountId, lobby.Id);

                PlayerData player = client.ToPlayerData(lobby.LeaderAccountId == client.AccountId);
                player.IsReady = true;
                player.TeamId = teamId++;
                lobby.Players[client.AccountId] = new LobbyPlayer(player, CreateGameAuthId(client.AccountId));
                _logger.LogInformation(
                    "Matchmaking player seeded: lobby={LobbyId} account={AccountId} username={Username} queueCharId={QueueCharId} lobbyCharId={LobbyCharId} teamId={TeamId}.",
                    lobby.Id,
                    client.AccountId,
                    client.Username,
                    entry?.CharId,
                    player.CharId,
                    player.TeamId);
            }

            _lobbies[lobby.Id] = lobby;
        }
        finally
        {
            _gate.Release();
        }

        if (mmStaleRemovals.Count > 0)
        {
            await NotifyLobbyRemovalsAsync(mmStaleRemovals, cancellationToken);
        }

        string gameId = $"matchmaking-{DateTimeOffset.UtcNow:yyyyMMddHHmmss}-{RandomNumberGenerator.GetInt32(1000, 9999)}";
        int unityGameMode = MapMatchmakingToUnityGameMode(lobby.CustomSettings.Gamemode);
        int mapId = PickMapId(unityGameMode, lobby.CustomSettings.MapId);
        MatchBootstrap bootstrap = CreateBootstrap(lobby, gameId, mapId);
        GameServerSession session;
        try
        {
            lobby.Starting = true;
            session = await _gameServers.StartMatchServerAsync(bootstrap, cancellationToken);
        }
        catch (Exception ex)
        {
            if (slotReserved) Interlocked.Decrement(ref _matchReservations);
            slotReserved = false;
            lobby.Starting = false;
            _lobbies.TryRemove(lobby.Id, out _);
            _logger.LogWarning(ex, "Failed to start matchmaking game for lobby {LobbyId}.", lobby.Id);
            return false;
        }

        await _gate.WaitAsync(cancellationToken);
        try
        {
            if (!_lobbies.TryGetValue(lobby.Id, out CustomLobby? activeLobby) ||
                activeLobby.Players.IsEmpty ||
                !activeLobby.Players.Keys.Any(accountId => _clients.Values.Any(client =>
                    string.Equals(client.AccountId, accountId, StringComparison.OrdinalIgnoreCase))))
            {
                if (slotReserved) Interlocked.Decrement(ref _matchReservations);
                slotReserved = false;
                _lobbies.TryRemove(lobby.Id, out _);
                // Off-thread: this branch holds the global _gate (see StartCustomGameAsync note).
                ScheduleMatchServerStop(session, TimeSpan.Zero, "matchmaking start with no connected players");
                _logger.LogWarning(
                    "Matchmaking game {GameId} bootstrapped after all queued players disconnected. Stopped empty server and skipped requeue. lobby={LobbyId}",
                    gameId,
                    lobby.Id);
                return true;
            }
        }
        finally
        {
            _gate.Release();
        }

        _matches[gameId] = session;
        if (slotReserved) Interlocked.Decrement(ref _matchReservations);
        slotReserved = false;
        _matchAccountIds[gameId] = lobby.Players.Keys.ToArray();
        foreach (string matchAcct in lobby.Players.Keys) _suppressNextReadyAfterMatch[matchAcct] = DateTimeOffset.UtcNow;
        _emptyLobbyMatchSinceUtc.TryRemove(gameId, out _);
        lobby.ActiveGameId = gameId;
        lobby.Starting = false;

        QueueMatchedPayload queuePayload = CreateQueueMatchedPayload(lobby, mapId);
        try
        {
            await BroadcastAsync(lobby, Events.QueueMatched, queuePayload, cancellationToken);
        }
        catch (Exception ex)
        {
            // Once the match is recorded, one dead peer socket must not unwind into
            // MatchmakingHostedService's failure path and requeue already-started players.
            _logger.LogWarning(ex, "Failed to broadcast QUEUE_MATCHED for {GameId}; match is already recorded.", gameId);
        }
        _logger.LogInformation("[Analytics] Match started: {GameId} mapId={MapId} players={PlayerCount}", gameId, mapId, lobby.Players.Count);

        LogImmediateGameStartDispatch(gameId, session, lobby.Players.Count, "matchmaking");

        foreach (LobbyPlayer lobbyPlayer in lobby.Players.Values)
        {
            // Multicast GAME_STARTED to ALL connections of this account so visible game clients
            // AND test/admin sockets all receive it (multiple sockets per account are allowed).
            ClientConnection[] targets = _clients.Values
                .Where(client => string.Equals(client.AccountId, lobbyPlayer.Player.AccountId, StringComparison.OrdinalIgnoreCase))
                .ToArray();
            if (targets.Length == 0)
            {
                continue;
            }

            foreach (ClientConnection target in targets)
            {
                try
                {
                    await SendAsync(target, Events.GameStarted, new GameStartedPayload
                    {
                        GameId = gameId,
                        GameAuthId = lobbyPlayer.GameAuthId,
                        GameDns = session.Hostname,
                        WsPort = session.WsPort,
                        KcpPort = session.KcpPort,
                        TcpPort = session.TcpPort,
                        MapId = mapId,
                        LevelId = mapId,
                        UnityGameMode = unityGameMode
                    }, cancellationToken);
                }
                catch (Exception ex)
                {
                    // One dead peer socket must not abort GAME_STARTED dispatch to the rest of the match.
                    _logger.LogWarning(ex, "Failed to send GAME_STARTED to {AccountId} in {GameId}.", target.AccountId, gameId);
                }
            }
        }

        _logger.LogInformation("Started matchmaking game {GameId} for {PlayerCount} queued player(s).", gameId, lobby.Players.Count);
        return true;
    }

    private void LogImmediateGameStartDispatch(
        string gameId,
        GameServerSession session,
        int playerCount,
        string mode)
    {
        _logger.LogInformation(
            "Game server {GameId} bootstrap fully applied; dispatching GAME_STARTED after setup/add-teams/queue-matched. mode={Mode} players={PlayerCount} pid={Pid} http={HttpPort} ws={WsPort} kcp={KcpPort} tcp={TcpPort} mapId={MapId} unityGameMode={UnityGameMode}",
            gameId,
            mode,
            playerCount,
            session.Process?.Id,
            session.HttpPort,
            session.WsPort,
            session.KcpPort,
            session.TcpPort,
            session.MapId,
            session.UnityGameModeId);
    }

    private MatchBootstrap CreateBootstrap(CustomLobby lobby, string gameId, int mapId)
    {
        int reqId = Interlocked.Increment(ref _requestCounter);
        List<MatchmakingPlayerData> players = lobby.Players.Values
            .OrderBy(player => player.Player.TeamId)
            .ThenBy(player => player.Player.AccountId)
            .Select((player, index) => new MatchmakingPlayerData
            {
                Username = player.Player.Username,
                Discriminator = player.Player.Discriminator,
                AccountId = player.Player.AccountId,
                GameAuthId = player.GameAuthId,
                LobbyCode = lobby.Id,
                Points = 0,
                CharId = player.Player.CharId,
                // Root-cause fix for the "always spawn as Skinny" bug: in BAPBAP the spawn uses
                // characterPrefabsByCharId[charId] UNLESS skinAssetId != -1 and that skin's
                // SkinConfig.characterPrefab is set, in which case the SKIN's prefab overrides the
                // selected character (RE: CHARACTERS_RESEARCH.md). The equipped/default skin id we
                // sent (e.g. 300018) resolved to a fixed model regardless of the chosen char.
                // -1 = default skin => the game spawns the SELECTED charId's prefab. (Medusa already
                // relied on this; all chars need it.)
                SkinAssetId = -1,
                TeamId = NormalizeDedicatedTeamId(player.Player.TeamId),
                BannerId = player.Player.BannerId,
                Level = player.Player.Level,
                PlayerId = index + 1
            })
            .ToList();

        _logger.LogInformation("Match bootstrap {GameId}/{LobbyId} players: {Players}",
            gameId,
            lobby.Id,
            string.Join("; ", players.Select(player =>
                $"{player.AccountId}:{player.Username} charId={player.CharId} skinAssetId={player.SkinAssetId} playerId={player.PlayerId} team={player.TeamId}")));
        _logger.LogInformation(
            "Match bootstrap {GameId}/{LobbyId} settings: gamemode={Gamemode} unityMode={UnityGameMode} mapId={MapId} teamSize={TeamSize} maxTeams={MaxTeams} botTeams={BotCount} botDifficulty={BotDifficulty}.",
            gameId,
            lobby.Id,
            lobby.CustomSettings.Gamemode,
            MapMatchmakingToUnityGameMode(lobby.CustomSettings.Gamemode),
            mapId,
            lobby.CustomSettings.TeamSize,
            lobby.CustomSettings.MaxTeams,
            lobby.CustomSettings.BotCount,
            lobby.CustomSettings.BotDifficulty);

        var gameData = new MatchmakingGameData
        {
            ReqId = reqId,
            QueueId = lobby.Id,
            MatchmakingGameModeId = lobby.CustomSettings.MatchmakingGameMode ?? _options.MatchDefaults.MatchmakingGameMode,
            UnityGameModeId = MapMatchmakingToUnityGameMode(lobby.CustomSettings.Gamemode),
            UnityTeamSize = Math.Max(1, lobby.CustomSettings.TeamSize),
            AvgPoints = 0,
            MapId = mapId,
            GameModifierId = SelectGameModifierIdsSafe(lobby.CustomSettings),
            ScoreTable = BuildDefaultScoreTable(),
            DimensionData = SelectDimensionData(lobby.CustomSettings)
                .Select(dimension => new MatchmakingDimensionData
                {
                    DimensionId = dimension.DimensionId,
                    Rounds = dimension.Rounds,
                    SpawnPoint = new Vector2Data { X = 0f, Y = 0f },
                    Radius = 100f
                })
                .ToList(),
            CharSelectMillis = NormalizeCharSelectMillis(lobby.CustomSettings.CharSelectMillis ?? _options.MatchDefaults.CharSelectMillis),
            SpawnSelectMillis = lobby.CustomSettings.SpawnSelectMillis ?? _options.MatchDefaults.SpawnSelectMillis,
            SpawnShowMillis = lobby.CustomSettings.SpawnShowMillis ?? _options.MatchDefaults.SpawnShowMillis
        };

        var teamData = new MatchmakingTeamData
        {
            ReqId = reqId,
            GameId = gameId,
            BotTeams = Math.Max(0, lobby.CustomSettings.BotCount),
            BotDifficulty = lobby.CustomSettings.BotDifficulty,
            SpawnLocationPerTeam = BuildDedicatedSpawnLocationPerTeam(lobby, players),
            Players = players
        };

        var queueMatchedData = new QueueMatchedData
        {
            ReqId = reqId,
            GameId = gameId,
            Players = players,
            BotTeams = teamData.BotTeams,
            BotDifficulty = teamData.BotDifficulty,
            AvailableCharacters = _options.Roster?.HasCustomization == true
                ? _options.Roster.BuildEnabledCharIds()
                : _options.MatchDefaults.AvailableCharacters
        };

        return new MatchBootstrap(gameId, gameData, teamData, queueMatchedData);
    }

    private static int NormalizeDedicatedTeamId(int lobbyTeamId)
    {
        // Lobby/custom-game UI uses 1-based teams, but the dedicated match server indexes
        // spawnLocationPerTeam directly by MatchmakingPlayerData.teamId.
        return Math.Max(0, lobbyTeamId - 1);
    }

    private static int[] BuildDedicatedSpawnLocationPerTeam(CustomLobby lobby, List<MatchmakingPlayerData> players)
    {
        int highestPlayerTeamId = players.Count == 0 ? 0 : players.Max(player => Math.Max(0, player.TeamId));
        int configuredTeamSlots = Math.Max(1, lobby.CustomSettings.MaxTeams);
        int botTeamSlots = Math.Max(0, lobby.CustomSettings.BotCount);
        int requiredSlots = Math.Max(highestPlayerTeamId + 1, configuredTeamSlots + botTeamSlots);
        return Enumerable.Range(0, Math.Max(1, requiredSlots)).ToArray();
    }

    private QueueMatchedPayload CreateQueueMatchedPayload(CustomLobby lobby, int mapId)
    {
        // Client BAPBAP.Network.QueueMatchedMessage.Payload + PopulatePreMatchUI requires every
        // field to be populated and non-empty. Null/empty arrays trigger NullReferenceException
        // and the loading screen "bleeds" while pre-match UI fails to mount.
        PlayerData[] players = lobby.Players.Values.Select(player => player.Player).ToArray()
            ?? Array.Empty<PlayerData>();
        int maxPlayers = Math.Max(players.Length, lobby.CustomSettings.MaxTeams * Math.Max(1, lobby.CustomSettings.TeamSize));
        if (maxPlayers <= 0)
        {
            maxPlayers = Math.Max(1, players.Length);
        }

        // AMP Roster toggles take precedence; otherwise fall back to MatchDefaults.AvailableCharacters
        int[] availableChars = _options.Roster?.HasCustomization == true
            ? _options.Roster.BuildEnabledCharIds()
            : _options.MatchDefaults.AvailableCharacters;
        if (availableChars == null || availableChars.Length == 0)
        {
            availableChars = CharacterCatalog.AllIds;
        }

        int[] modifierIds = SelectGameModifierIdsForClient(lobby.CustomSettings); // empty if user didn't choose

        // Map matchmaking-id -> Unity gamemode id (1=BR, 2=Training, 3=FFA). Raw matchmaking id
        // would not match Unity's gamemode enum and breaks PopulatePreMatchUI.
        int unityGameMode = MapMatchmakingToUnityGameMode(lobby.CustomSettings.Gamemode);

        int levelId = mapId;

        DimensionData[] dims = SelectDimensionData(lobby.CustomSettings); // guarantees at least one entry

        int charSelectMillis = NormalizeCharSelectMillis(lobby.CustomSettings.CharSelectMillis ?? _options.MatchDefaults.CharSelectMillis);

        return new QueueMatchedPayload
        {
            Players = players,
            CurrentPlayerCount = players.Length,
            MaxPlayerCount = maxPlayers,
            CharSelectMillis = charSelectMillis,
            AvailableCharacters = availableChars,
            GameModifierIds = modifierIds,
            LevelId = levelId,
            UnityGameMode = unityGameMode,
            DimensionData = dims
        };
    }

    private static int NormalizeCharSelectMillis(int configuredMillis)
    {
        return configuredMillis < MinimumCharSelectMillis
            ? MinimumCharSelectMillis
            : configuredMillis;
    }

    public async Task<bool> KickAccountAsync(string? accountId, string reason, CancellationToken cancellationToken)
    {
        string normalized = ServerAdminService.NormalizeAccountId(accountId);
        if (string.IsNullOrWhiteSpace(normalized))
        {
            return false;
        }

        // An account may hold multiple concurrent sockets (visible client + test/admin sockets);
        // close every one, otherwise the kick/ban leaves live sockets still in the lobby/queue.
        ClientConnection[] connections = _clients.Values
            .Where(client => string.Equals(client.AccountId, normalized, StringComparison.OrdinalIgnoreCase))
            .ToArray();
        if (connections.Length == 0)
        {
            return false;
        }

        foreach (ClientConnection connection in connections)
        {
            // Fully guarded per connection: this runs on an admin HTTP request, and a dead target
            // socket must neither fail the admin call nor skip the remaining connections.
            try
            {
                await SendAsync(connection, Events.LobbyLeft, new
                {
                    accountId = normalized,
                    username = connection.Username,
                    warningMessage = reason
                }, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Kick notify failed for {AccountId}.", normalized);
            }

            await RemoveFromLobbyAsync(connection, cancellationToken);

            await CloseSocketUnderLockAsync(connection, WebSocketCloseStatus.PolicyViolation, reason, cancellationToken);

            _clients.TryRemove(connection.Id, out _);
        }

        return true;
    }

    public bool StopMatch(string? gameId)
    {
        if (string.IsNullOrWhiteSpace(gameId))
        {
            return false;
        }

        if (!_matches.TryRemove(gameId.Trim(), out GameServerSession? session))
        {
            return false;
        }

        _emptyLobbyMatchSinceUtc.TryRemove(session.GameId, out _);
        StampPostMatchReturnWindow(session.GameId);
        _matchAccountIds.TryRemove(session.GameId, out _);
        // Off-thread: StopMatchServer blocks up to GameServerStopWaitMillis on the process kill;
        // this runs inside an admin HTTP request.
        ScheduleMatchServerStop(session, TimeSpan.Zero, "admin stop");
        _logger.LogInformation("Admin stopped match {GameId}.", session.GameId);
        return true;
    }

    public void StopAllMatches()
    {
        foreach (string gameId in _matches.Keys.ToArray())
        {
            if (_matches.TryRemove(gameId, out GameServerSession? session))
            {
                _emptyLobbyMatchSinceUtc.TryRemove(session.GameId, out _);
                _matchAccountIds.TryRemove(session.GameId, out _);
                _gameServers.StopMatchServer(session);
                _logger.LogInformation("Shutdown: stopped match {GameId}.", session.GameId);
            }
        }
    }

    public async Task<bool> SetLobbySettingsAsync(string? lobbyId, CustomGameSettingsData settings, CancellationToken cancellationToken)
    {
        string normalizedLobbyId = string.IsNullOrWhiteSpace(lobbyId) ? "" : lobbyId.Trim().ToUpperInvariant();
        if (string.IsNullOrWhiteSpace(normalizedLobbyId) || !_lobbies.TryGetValue(normalizedLobbyId, out CustomLobby? lobby))
        {
            return false;
        }

        lobby.CustomSettings = settings;
        lobby.Settings.GameModeId = ResolveLobbyGameModeId(lobby.Settings.GameModeId);
        await BroadcastAsync(lobby, Events.UpdateCustomSettingsSuccess, new
        {
            settings = lobby.CustomSettings,
            warningMessage = "",
            errorCode = "",
            maxTeams = lobby.CustomSettings.MaxTeams,
            mapMapping = BuildAdvertisedMapMapping()
        }, cancellationToken);
        return true;
    }

    private static int ResolveLobbyGameModeId(int requestedGameModeId)
    {
        return requestedGameModeId > 0 ? requestedGameModeId : DefaultLobbyGameModeId;
    }

    /// <summary>
    /// Maps a matchmaking game mode id (0..10, drives lobby UI mode picker) to the
    /// corresponding unity game mode id (0..3, drives the actual match runtime).
    ///   - MatchmakingGameModes from GameModesConfiguration.asset:
    ///       0=Warmup, 1=MiniDuos, 2=MiniTrios, 3=Solos, 4=Duos, 5=Trios,
    ///       6=RankedDuos, 7=RankedTrios, 8=OpenBetaChallenge, 9=FreeForAll, 10=CustomGame
    ///   - UnityGameModes (BAPBAP\Game\GameModes.cs):
    ///       0=None, 1=BattleRoyale, 2=Training, 3=FFA
    /// The dedicated game server indexes runtime arrays by UnityGameMode, so passing the
    /// matchmaking id directly causes IndexOutOfRangeException in OnServerMatchSetup
    /// (e.g. matchmaking 4 -> unity None, matchmaking 3 -> unity FFA).
    /// </summary>
    private static int MapMatchmakingToUnityGameMode(int matchmakingId)
    {
        return matchmakingId switch
        {
            0 => 2,  // Warmup            -> Training
            1 => 1,  // MiniDuos          -> BattleRoyale
            2 => 1,  // MiniTrios         -> BattleRoyale
            3 => 1,  // Solos             -> BattleRoyale
            4 => 1,  // Duos              -> BattleRoyale
            5 => 1,  // Trios             -> BattleRoyale
            6 => 1,  // RankedDuos        -> BattleRoyale
            7 => 1,  // RankedTrios       -> BattleRoyale
            8 => 1,  // OpenBetaChallenge -> BattleRoyale
            9 => 3,  // FreeForAll        -> FFA
            10 => 1, // CustomGame        -> BattleRoyale (default)
            _ => 1   // Unknown           -> BattleRoyale (safe default)
        };
    }

    // Team size per matchmaking mode id. Duos -> 2, Trios -> 3, everything else (Solos/FFA/
    // Warmup/Custom) -> 1. Keeps MaxTeams * TeamSize bounded to the lobby cap (8 players).
    private static int GetTeamSizeForMatchmakingMode(int matchmakingId)
    {
        return matchmakingId switch
        {
            1 => 2,  // MiniDuos
            4 => 2,  // Duos
            6 => 2,  // RankedDuos
            2 => 3,  // MiniTrios
            5 => 3,  // Trios
            7 => 3,  // RankedTrios
            _ => 1
        };
    }

    // Resolve team size + player cap + bots for a matchmaking mode. Honors a configured
    // PerModeSettings entry; otherwise derives team size and uses the matchmaking queue bot defaults.
    private (int TeamSize, int MaxTeams, int BotCount, int BotDifficulty) ResolveModeSettings(int matchmakingMode)
    {
        int defaultBotCount = Math.Max(0, _queueOptions.DefaultBotCount);
        int defaultBotDifficulty = _queueOptions.DefaultBotDifficulty;

        PerModeSettingsEntry? entry = _options.MatchDefaults.PerModeSettings
            .FirstOrDefault(e => e.MatchmakingGameModeId == matchmakingMode);

        int teamSize = entry is { TeamSize: > 0 }
            ? entry.TeamSize
            : Math.Max(1, GetTeamSizeForMatchmakingMode(matchmakingMode));

        int maxPlayers = entry is { MaxPlayers: > 0 } ? entry.MaxPlayers : 32;
        int maxTeams = Math.Max(1, maxPlayers / teamSize);

        int botCount = entry is { BotCount: >= 0 } ? entry.BotCount : defaultBotCount;
        int botDifficulty = entry is { BotDifficulty: >= 0 } ? entry.BotDifficulty : defaultBotDifficulty;

        return (teamSize, maxTeams, botCount, botDifficulty);
    }

    private static int GetEquippedSkinForCharacter(PlayerData player)
    {
        if (player.CharId == CharacterCatalog.MedusaCharId)
        {
            return -1;
        }

        if (player.Skins is { Length: > 0 } skins &&
            player.CharId >= 0 &&
            player.CharId < skins.Length &&
            skins[player.CharId] > 0)
        {
            return skins[player.CharId];
        }

        return CharacterCatalog.GetDefaultSkinAssetId(player.CharId);
    }

    private object[] BuildGameModesUpdatedPayload()
    {
        // Server-driven list of advertised game modes. Without entries here, the lobby UI
        // shows nothing. With entries, the user sees one button per mode.
        // BAPBAP modes (from GameModesConfiguration.asset):
        //   0=Warmup, 1=MiniDuos, 2=MiniTrios, 3=Solos, 4=Duos, 5=Trios,
        //   6=RankedDuos, 7=RankedTrios, 8=OpenBetaChallenge, 9=FreeForAll, 10=CustomGame
        int[] enabledIds = ParseEnabledGameModeIds();
        return enabledIds.Select(id => (object)new
        {
            gameModeId = id,
            status = 0,                  // 0 = available
            message = "",
            timestampStart = "",
            timestampEnd = "",
            isPasswordProtected = false  // never password-lock - that opens UIGameModePasswordWindow
        }).ToArray();
    }

    private int[] ParseEnabledGameModeIds()
    {
        string csv = _options.MatchDefaults.EnabledGameModeIdsCsv;
        if (!string.IsNullOrWhiteSpace(csv))
        {
            int[] parsed = csv
                .Split([',', ';', ' '], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Select(s => int.TryParse(s, out int n) ? n : (int?)null)
                .Where(n => n.HasValue)
                .Select(n => n!.Value)
                .Distinct()
                .ToArray();
            if (parsed.Length > 0) return parsed;
        }
        // Default: a fuller mode set (Warmup/Training, Solos, Duos, Trios, FFA, Custom) so a blank
        // config is not silently Solos-only.
        return [0, 3, 4, 5, 9, 10];
    }

    // The lobby map picker indexes the broadcast mapMapping by the MATCHMAKING mode id the lobby is in
    // (Solos=3, Duos=4, ...), NOT the UnityGameModeId. The static MatchDefaults.MapMapping is keyed by
    // UnityGameModeId (0,1), so the lookup misses for mode 3/4 and the picker collapses to the single
    // current map (bazaarcity). Build one entry per advertised mode from the real map pool instead, so
    // every mode offers the full set. Custom maps (id>=5) are explicit-select only -> excluded.
    private MapMappingEntry[] BuildAdvertisedMapMapping()
    {
        int[] realMaps = _options.MapPool?.BuildRandomMapIds() ?? new[] { MapCatalog.BazaarCityId };
        return ParseEnabledGameModeIds()
            .Select(modeId => new MapMappingEntry { UnityGameModeId = modeId, MapIds = realMaps })
            .ToArray();
    }

    private int RemoveAccountFromAllLobbiesLocked(string accountId, string? keepLobbyId, List<(CustomLobby Lobby, LobbyPlayer Removed)>? notifyAfterGate = null)
    {
        if (string.IsNullOrWhiteSpace(accountId))
        {
            return 0;
        }

        int removed = 0;
        foreach (KeyValuePair<string, CustomLobby> pair in _lobbies.ToArray())
        {
            CustomLobby lobby = pair.Value;
            if (!string.IsNullOrWhiteSpace(keepLobbyId) && string.Equals(lobby.Id, keepLobbyId, StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            if (!lobby.Players.TryRemove(accountId, out LobbyPlayer? removedPlayer))
            {
                continue;
            }

            removed++;
            if (lobby.Players.IsEmpty)
            {
                _lobbies.TryRemove(lobby.Id, out _);
                StopLobbyMatchIfEmpty(lobby);
                continue;
            }

            if (string.Equals(lobby.LeaderAccountId, accountId, StringComparison.OrdinalIgnoreCase))
            {
                lobby.LeaderAccountId = lobby.Players.Keys.First();
                lobby.Players[lobby.LeaderAccountId].Player.IsLeader = true;
            }

            // The remaining members must hear about the removal or their UI keeps showing the
            // ghost slot. Caller broadcasts AFTER releasing the gate (never send under _gate).
            notifyAfterGate?.Add((lobby, removedPlayer));
        }

        return removed;
    }

    /// <summary>Broadcast LOBBY_LEFT for lobby normalizations collected under the gate.</summary>
    private async Task NotifyLobbyRemovalsAsync(List<(CustomLobby Lobby, LobbyPlayer Removed)> removals, CancellationToken cancellationToken)
    {
        foreach ((CustomLobby lobby, LobbyPlayer removedPlayer) in removals)
        {
            try
            {
                await BroadcastAsync(lobby, Events.LobbyLeft, new
                {
                    accountId = removedPlayer.Player.AccountId,
                    username = removedPlayer.Player.Username,
                    leaderAccountId = lobby.LeaderAccountId
                }, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "LOBBY_LEFT normalization broadcast failed for lobby {LobbyId}.", lobby.Id);
            }
        }
    }

    private async Task<int> MarkAccountUnreadyEverywhereAsync(string accountId, string source, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(accountId))
        {
            return 0;
        }

        int changed = 0;
        foreach (CustomLobby lobby in _lobbies.Values.ToArray())
        {
            if (!lobby.Players.TryGetValue(accountId, out LobbyPlayer? player))
            {
                continue;
            }

            if (player.Player.IsReady)
            {
                player.Player.IsReady = false;
                changed++;
            }

            await BroadcastAsync(lobby, Events.MatchmakingExited, new
            {
                accountId,
                isCounting = false
            }, cancellationToken);

            await BroadcastAsync(lobby, Events.ReadyUpdated, new
            {
                accountId,
                isReady = false
            }, cancellationToken);
        }

        if (changed > 0)
        {
            _logger.LogInformation(
                "Cleared ready state for {AccountId} in {Count} lobby membership(s) via {Source}.",
                accountId,
                changed,
                source);
        }

        return changed;
    }

    private async Task RemoveFromLobbyAsync(ClientConnection connection, CancellationToken cancellationToken)
    {
        // Always pull this account out of the matchmaking queue. Leaving a lobby while still
        // queued caused the queue timer to fire on a phantom player, then StartMatchmakingGameAsync
        // would find no live websocket and abort - which left the queue jammed for everyone.
        try
        {
            bool wasInQueue = _queueService.LeaveQueue(connection.AccountId);
            if (wasInQueue)
            {
                _logger.LogInformation("RemoveFromLobby cleared queue entry for {AccountId}.", connection.AccountId);
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "RemoveFromLobby: queue cleanup failed for {AccountId}.", connection.AccountId);
        }

        if (string.IsNullOrWhiteSpace(connection.LobbyId))
        {
            return;
        }

        _friendsService.UpdatePlayerLobby(connection.AccountId, null);

        await _gate.WaitAsync(cancellationToken);
        try
        {
            if (!_lobbies.TryGetValue(connection.LobbyId, out CustomLobby? lobby))
            {
                return;
            }

            if (!lobby.Players.TryRemove(connection.AccountId, out LobbyPlayer? removed))
            {
                return;
            }

            if (lobby.Players.IsEmpty)
            {
                _lobbies.TryRemove(lobby.Id, out _);
                StopLobbyMatchIfEmpty(lobby);
                return;
            }

            if (lobby.LeaderAccountId == connection.AccountId)
            {
                lobby.LeaderAccountId = lobby.Players.Keys.First();
                lobby.Players[lobby.LeaderAccountId].Player.IsLeader = true;
            }

            await BroadcastAsync(lobby, Events.LobbyLeft, new
            {
                accountId = removed.Player.AccountId,
                username = removed.Player.Username,
                leaderAccountId = lobby.LeaderAccountId
            }, cancellationToken);
        }
        finally
        {
            connection.LobbyId = null;
            _gate.Release();
        }
    }

    private void StopLobbyMatchIfEmpty(CustomLobby lobby)
    {
        try
        {
            if (!lobby.Players.IsEmpty || string.IsNullOrWhiteSpace(lobby.ActiveGameId))
            {
                return;
            }

            if (!_matches.TryGetValue(lobby.ActiveGameId, out GameServerSession? session))
            {
                return;
            }

            if (session.Process is { } process && process.HasExited)
            {
                if (_matches.TryRemove(lobby.ActiveGameId, out GameServerSession? removedSession))
                {
                    _emptyLobbyMatchSinceUtc.TryRemove(removedSession.GameId, out _);
                    StampPostMatchReturnWindow(removedSession.GameId);
                    _matchAccountIds.TryRemove(removedSession.GameId, out _);
                    _gameServers.StopMatchServer(removedSession);
                    _logger.LogInformation(
                        "Stopped match {GameId} because lobby {LobbyId} is empty and the game process has exited.",
                        removedSession.GameId,
                        lobby.Id);
                }
                return;
            }

            bool marked = _emptyLobbyMatchSinceUtc.TryAdd(lobby.ActiveGameId, DateTimeOffset.UtcNow);
            _logger.LogInformation(
                marked
                    ? "Lobby {LobbyId} is empty while match {GameId} is active; keeping game process alive for {GraceSeconds:F0}s grace ({ConnectedGraceSeconds:F0}s if the match account socket is still connected). matchAccounts={MatchAccounts}"
                    : "Lobby {LobbyId} remains empty while match {GameId} is active; game process is already in empty-lobby grace ({GraceSeconds:F0}s / connected {ConnectedGraceSeconds:F0}s). matchAccounts={MatchAccounts}",
                lobby.Id,
                lobby.ActiveGameId,
                EmptyLobbyMatchCleanupGrace.TotalSeconds,
                EmptyLobbyMatchConnectedCleanupGrace.TotalSeconds,
                _matchAccountIds.TryGetValue(lobby.ActiveGameId, out string[]? accountIds)
                    ? string.Join(",", accountIds)
                    : "");
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to handle empty-lobby match for lobby {LobbyId}.", lobby.Id);
        }
    }

    /// <summary>
    /// Release a match a lobby started once its players are demonstrably back on the lobby socket
    /// (e.g. re-queueing after being returned/kicked to the lobby). lobby.ActiveGameId is otherwise
    /// never cleared, so the match lingers in _matches forever; under MaxConcurrentMatches=1 that one
    /// phantom match blocks every subsequent start with "server at capacity (1+0/1)".
    /// </summary>
    private void ReleaseAbandonedMatchForLobby(CustomLobby lobby, string reason)
    {
        string? gameId = lobby.ActiveGameId;
        if (string.IsNullOrWhiteSpace(gameId))
        {
            return;
        }

        // Guard against killing a live multiplayer match: if a match account that is NOT a member of
        // this lobby still has a connected socket, a teammate may still be playing. Leave that match to
        // the normal empty-lobby cleanup instead of stopping its host out from under them.
        if (_matchAccountIds.TryGetValue(gameId, out string[]? matchAccounts))
        {
            bool otherConnectedPlayer = matchAccounts.Any(accountId =>
                !lobby.Players.ContainsKey(accountId) &&
                _clients.Values.Any(client =>
                    string.Equals(client.AccountId, accountId, StringComparison.OrdinalIgnoreCase) &&
                    client.Socket.State is WebSocketState.Open or WebSocketState.CloseReceived));
            if (otherConnectedPlayer)
            {
                _logger.LogInformation(
                    "Skipped releasing match {GameId} for lobby {LobbyId} ({Reason}): another match account is still connected.",
                    gameId,
                    lobby.Id,
                    reason);
                return;
            }
        }

        lobby.ActiveGameId = null;
        _emptyLobbyMatchSinceUtc.TryRemove(gameId, out _);
        StampPostMatchReturnWindow(gameId);
        _matchAccountIds.TryRemove(gameId, out _);
        if (_matches.TryRemove(gameId, out GameServerSession? removedSession))
        {
            // Off-thread: this runs inside the ready/queue WS handler; a synchronous kill+wait
            // here stalls that player's receive loop for seconds.
            ScheduleMatchServerStop(removedSession, TimeSpan.Zero, $"abandoned by lobby ({reason})");
            _logger.LogInformation(
                "Released abandoned match {GameId} for lobby {LobbyId} ({Reason}); freed match slot for re-queue.",
                gameId,
                lobby.Id,
                reason);
        }
    }

    /// <summary>
    /// Release any match this account was part of once it is demonstrably back on a lobby socket
    /// (e.g. re-queueing). Matchmaking stores ActiveGameId on a synthetic "MM..." lobby, NOT the
    /// player's normal lobby, so ReleaseAbandonedMatchForLobby (keyed on the normal lobby) never sees
    /// it and the phantom match holds the only slot for minutes. This sweeps _matchAccountIds by
    /// account instead, so the returning player's stale match is freed immediately.
    /// </summary>
    private void ReleaseAbandonedMatchesForAccount(string accountId, string reason)
    {
        if (string.IsNullOrWhiteSpace(accountId))
        {
            return;
        }

        foreach (string gameId in _matchAccountIds.Keys.ToArray())
        {
            if (!_matchAccountIds.TryGetValue(gameId, out string[]? matchAccounts) ||
                !matchAccounts.Any(id => string.Equals(id, accountId, StringComparison.OrdinalIgnoreCase)))
            {
                continue;
            }

            // Don't kill a live match: if any OTHER match account still has an open socket, a
            // teammate may still be playing. Leave it to the normal empty-lobby cleanup.
            bool otherConnectedPlayer = matchAccounts.Any(id =>
                !string.Equals(id, accountId, StringComparison.OrdinalIgnoreCase) &&
                _clients.Values.Any(client =>
                    string.Equals(client.AccountId, id, StringComparison.OrdinalIgnoreCase) &&
                    client.Socket.State is WebSocketState.Open or WebSocketState.CloseReceived));
            if (otherConnectedPlayer)
            {
                continue;
            }

            _emptyLobbyMatchSinceUtc.TryRemove(gameId, out _);
            StampPostMatchReturnWindow(gameId);
            _matchAccountIds.TryRemove(gameId, out _);
            foreach (CustomLobby candidate in _lobbies.Values)
            {
                if (string.Equals(candidate.ActiveGameId, gameId, StringComparison.OrdinalIgnoreCase))
                {
                    candidate.ActiveGameId = null;
                }
            }
            if (_matches.TryRemove(gameId, out GameServerSession? removedSession))
            {
                // Off-thread: this runs inside the ready/queue WS handler; a synchronous
                // kill+wait here stalls that player's receive loop for seconds.
                ScheduleMatchServerStop(removedSession, TimeSpan.Zero, $"abandoned by account ({reason})");
                _logger.LogInformation(
                    "Released abandoned match {GameId} for account {AccountId} ({Reason}); freed match slot for re-queue.",
                    gameId,
                    accountId,
                    reason);
            }
        }
    }

    // Test-only seam: register a lobby with an active match (null-process session, no spawn) so the
    // abandoned-match release path can be unit-tested without driving the full WebSocket flow.
    internal CustomLobby SeedActiveMatchForTest(string lobbyId, string gameId, GameServerSession session, params string[] matchAccountIds)
    {
        var lobby = new CustomLobby
        {
            Id = lobbyId,
            LeaderAccountId = matchAccountIds.Length > 0 ? matchAccountIds[0] : "host",
            ActiveGameId = gameId
        };
        _lobbies[lobbyId] = lobby;
        _matches[gameId] = session;
        if (matchAccountIds.Length > 0)
        {
            _matchAccountIds[gameId] = matchAccountIds;
        }
        return lobby;
    }

    // Test-only seam: invoke the real release path against a previously seeded lobby.
    internal void ReleaseAbandonedMatchForTest(CustomLobby lobby, string reason) =>
        ReleaseAbandonedMatchForLobby(lobby, reason);

    private bool TryGetLobby(ClientConnection connection, out CustomLobby lobby, out LobbyPlayer player)
    {
        lobby = null!;
        player = null!;

        if (string.IsNullOrWhiteSpace(connection.LobbyId) || !_lobbies.TryGetValue(connection.LobbyId, out CustomLobby? foundLobby))
        {
            return false;
        }

        lobby = foundLobby;
        if (!lobby.Players.TryGetValue(connection.AccountId, out LobbyPlayer? foundPlayer))
        {
            return false;
        }

        player = foundPlayer;
        return true;
    }

    private bool CanControlLobby(ClientConnection connection, CustomLobby lobby)
    {
        return connection.IsAdmin ||
               string.Equals(lobby.LeaderAccountId, connection.AccountId, StringComparison.OrdinalIgnoreCase);
    }

    private bool HasConnectedMatchPlayer(string gameId, out int connectedPlayers)
    {
        connectedPlayers = 0;
        if (!_matchAccountIds.TryGetValue(gameId, out string[]? matchAccounts) || matchAccounts.Length == 0)
        {
            return false;
        }

        HashSet<string> accountSet = new(matchAccounts, StringComparer.OrdinalIgnoreCase);
        connectedPlayers = _clients.Values.Count(client =>
            accountSet.Contains(client.AccountId) &&
            client.Socket.State is WebSocketState.Open or WebSocketState.CloseReceived);
        return connectedPlayers > 0;
    }

    private int[] SelectGameModifierIds(CustomGameSettingsData settings)
    {
        // Only use modifiers explicitly chosen in lobby. Do NOT auto-apply MatchDefaults
        // because BAPBAP's client UI crashes if the QueueMatched payload contains a
        // modifier ID that isn't actually present in the runtime gameModifiers[] array.
        // Modifiers must be enabled per-lobby via SetLobbyModifiers admin endpoint or
        // directly via UPDATE_CUSTOM_SETTINGS from the lobby leader.
        return settings.GameModifierIds.Distinct().ToArray();
    }

    /// <summary>
    /// SelectGameModifierIds, but always returns at least one entry. BAPBAP's OnServerMatchSetup
    /// indexes gameModifierId[0] - an empty array crashes the dedicated server.
    /// Use this for bootstrap payloads (server-side, no client UI rendering).
    /// </summary>
    private int[] SelectGameModifierIdsSafe(CustomGameSettingsData settings)
    {
        int[] ids = SelectGameModifierIds(settings);
        return ids.Length > 0 ? ids : new[] { 0 };
    }

    /// <summary>
    /// SelectGameModifierIds for client-facing payloads (e.g. QUEUE_MATCHED).
    /// Returns empty array when no modifier is chosen so the client UI doesn't try to render
    /// modifier icons it doesn't have assets for. Sending [1] when player didn't choose
    /// it crashes UI lobby loading on missing GameModifierSO icon.
    /// </summary>
    private int[] SelectGameModifierIdsForClient(CustomGameSettingsData settings)
    {
        return SelectGameModifierIds(settings);
    }

    /// <summary>
    /// 8 default tier rows for the score sheet (Unranked..Divine).
    /// BAPBAP's OnServerMatchSetup iterates this list; an empty list is one likely cause
    /// of IndexOutOfRangeException during /setup-game bootstrap.
    /// </summary>
    private static List<MatchmakingScoreSheetData> BuildDefaultScoreTable()
    {
        // Reasonable placement-points per tier (1st place gold, 2nd silver, etc).
        int[] placements = { 100, 70, 50, 40, 30, 20, 15, 10 };
        string[] tiers = { "Unranked", "Bronze", "Silver", "Gold", "Platinum", "Diamond", "Royal", "Divine" };
        var list = new List<MatchmakingScoreSheetData>(tiers.Length);
        foreach (string tier in tiers)
        {
            list.Add(new MatchmakingScoreSheetData
            {
                Tier = tier,
                Max = 99999,
                Placements = placements.ToList(),
                Kills = 15
            });
        }
        return list;
    }

    private DimensionData[] SelectDimensionData(CustomGameSettingsData settings)
    {
        DimensionData[] result = settings.DimensionData.Length > 0
            ? settings.DimensionData
            : _options.MatchDefaults.DimensionData;
        // BAPBAP's OnServerMatchSetup indexes dimensionData[0]; an empty list crashes
        // the dedicated game with IndexOutOfRangeException. Always seed at least one.
        if (result.Length == 0)
        {
            result = new[] { new DimensionData { DimensionId = 0, Rounds = new[] { 0 } } };
        }
        return result;
    }

    private async Task BroadcastAsync(
        CustomLobby lobby,
        string evt,
        object? payload,
        CancellationToken cancellationToken,
        Guid? except = null,
        Guid? only = null)
    {
        // Build a HashSet of accountIds in the lobby so we can hit all connections per account.
        var lobbyAccountIds = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (LobbyPlayer lobbyPlayer in lobby.Players.Values)
        {
            lobbyAccountIds.Add(lobbyPlayer.Player.AccountId);
        }

        // Send to EVERY connection whose accountId is in the lobby (multicast across multiple sockets per account).
        foreach (ClientConnection client in _clients.Values.Where(c => lobbyAccountIds.Contains(c.AccountId)))
        {
            if (except.HasValue && client.Id == except.Value)
            {
                continue;
            }

            if (only.HasValue && client.Id != only.Value)
            {
                continue;
            }

            try
            {
                await SendAsync(client, evt, payload, cancellationToken);
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {
                throw; // The CALLER is gone/shutting down - stop the whole broadcast.
            }
            catch (Exception ex)
            {
                // One dead/half-closed recipient must not abort the rest of the fan-out (later
                // recipients would silently miss READY_UPDATED etc.) nor unwind into the SENDING
                // player's receive loop and disconnect an innocent client.
                _logger.LogDebug(ex, "Broadcast {Event} to {AccountId} failed; skipping recipient.", evt, client.AccountId);
            }
        }
    }

    // Send a WS event to every live connection for an account (an account may have >1 socket).
    // Used by friends presence fan-out and lobby-invite delivery. Fully guarded — a friends-layer
    // failure must never break the caller (connect path, HTTP invite endpoint).
    private async Task SendToAccountAsync(string accountId, string evt, object? payload, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return;
        ClientConnection[] targets = _clients.Values
            .Where(c => string.Equals(c.AccountId, accountId, StringComparison.OrdinalIgnoreCase))
            .ToArray();
        foreach (ClientConnection target in targets)
        {
            try { await SendAsync(target, evt, payload, cancellationToken); }
            catch (Exception ex) { _logger.LogDebug(ex, "SendToAccount {AccountId} {Event} failed.", accountId, evt); }
        }
    }

    // Public entry for the /api/friends/invite HTTP endpoint to push a lobby invite over WS.
    public Task NotifyLobbyInviteAsync(string toAccountId, string fromAccountId, string lobbyId)
        => SendToAccountAsync(toAccountId, Events.InviteLobby,
            new { receiverAccountId = toAccountId, senderAccountId = fromAccountId, lobbyId },
            CancellationToken.None);

    // On connect: push the player's friend list + pending requests so the panel populates. Event
    // strings are INFERRED (IL2CPP stripped literals) — see Events.SetFriends. Guarded so a wrong
    // string is a silent no-op, never a connect-path failure.
    private async Task PushFriendsStateAsync(ClientConnection connection, CancellationToken cancellationToken)
    {
        try
        {
            foreach (FriendInfo f in _friendsService.GetFriends(connection.AccountId))
            {
                await SendAsync(connection, Events.SetFriends, new
                {
                    accountId = f.AccountId,
                    username = f.Username,
                    discriminator = f.Discriminator,
                    avatarId = 0,
                    lobbyOpen = false,
                    status = f.IsOnline ? 1 : 0,
                    timestampStart = "",
                    playerCount = 0,
                    maxPlayers = 0
                }, cancellationToken);
            }

            FriendRequest[] requests = _friendsService.GetPendingRequests(connection.AccountId);
            // Only push when there's something to show — an empty push just adds a connect-time
            // frame that callers (and the auth handshake) would have to drain for no benefit.
            if (requests.Length > 0)
            {
                await SendAsync(connection, Events.SetFriendRequests, new
                {
                    friendRequests = requests.Select(r => new
                    {
                        accountId = r.FromAccountId,
                        username = r.FromUsername,
                        discriminator = r.FromDiscriminator
                    }).ToArray()
                }, cancellationToken);
            }
        }
        catch (Exception ex)
        {
            _logger.LogDebug(ex, "PushFriendsState failed for {AccountId}.", connection.AccountId);
        }
    }

    // Fan a status change (1=online, 0=offline) out to each of this account's friends' live sockets.
    private async Task NotifyFriendsOfStatusAsync(string accountId, int status, CancellationToken cancellationToken)
    {
        try
        {
            foreach (FriendInfo f in _friendsService.GetFriends(accountId))
            {
                await SendToAccountAsync(f.AccountId, Events.FriendStatus, new { accountId, status }, cancellationToken);
            }
        }
        catch (Exception ex)
        {
            _logger.LogDebug(ex, "NotifyFriendsOfStatus failed for {AccountId}.", accountId);
        }
    }

    private static string? TryGetPayloadString(JsonElement payload, string field)
    {
        if (payload.ValueKind == JsonValueKind.Object &&
            payload.TryGetProperty(field, out JsonElement el) &&
            el.ValueKind == JsonValueKind.String)
        {
            return el.GetString();
        }
        return null;
    }

    // C->S FRIEND_INVITE_LOBBY {accountId, lobbyId}: sender invites a friend to their lobby. Push
    // an INVITE_LOBBY to the target's live socket(s). Fully guarded.
    private async Task HandleFriendInviteLobbyAsync(ClientConnection connection, JsonElement payload, CancellationToken cancellationToken)
    {
        try
        {
            string? toAccountId = TryGetPayloadString(payload, "accountId");
            string lobbyId = TryGetPayloadString(payload, "lobbyId") ?? connection.LobbyId ?? "";
            if (string.IsNullOrWhiteSpace(toAccountId) || string.IsNullOrWhiteSpace(lobbyId)) return;
            await NotifyLobbyInviteAsync(toAccountId, connection.AccountId, lobbyId);
        }
        catch (Exception ex) { _logger.LogDebug(ex, "HandleFriendInviteLobby failed for {AccountId}.", connection.AccountId); }
    }

    // C->S JOIN_FRIEND_LOBBY {accountId}: caller joins the friend's current lobby. Resolve the
    // friend's lobbyId, run the validated join path, and reply JOIN_FRIEND_LOBBY_SUCCESS.
    private async Task HandleJoinFriendLobbyAsync(ClientConnection connection, JsonElement payload, CancellationToken cancellationToken)
    {
        try
        {
            string? friendAccountId = TryGetPayloadString(payload, "accountId");
            if (string.IsNullOrWhiteSpace(friendAccountId)) return;
            string? lobbyId = _friendsService.GetPlayerLobbyId(friendAccountId);
            if (string.IsNullOrWhiteSpace(lobbyId)) return;
            await JoinLobbyAsync(connection, new JoinLobbyPayload { LobbyId = lobbyId, CharId = connection.CharId }, cancellationToken);
            await SendAsync(connection, Events.JoinFriendLobbySuccess, new { lobbyId }, cancellationToken);
        }
        catch (Exception ex) { _logger.LogDebug(ex, "HandleJoinFriendLobby failed for {AccountId}.", connection.AccountId); }
    }

    // Upper bound for a single WS send (lock wait + frame write). Without it, ONE peer with a
    // full TCP send buffer (WLAN drop, frozen client) blocked SendAsync forever — and because
    // joins/broadcasts run under the global _gate, that single stuck client could wedge every
    // lobby operation on the server. On timeout the socket is aborted so its receive loop
    // unwinds and the connection is cleaned up like any other disconnect.
    private static readonly TimeSpan SendTimeout = TimeSpan.FromSeconds(10);

    private static async Task SendAsync(ClientConnection connection, string evt, object? payload, CancellationToken cancellationToken)
    {
        if (connection.Socket.State != WebSocketState.Open)
        {
            return;
        }

        var envelope = new OutgoingEnvelope(evt, payload);
        byte[] bytes = JsonSerializer.SerializeToUtf8Bytes(envelope, JsonContract.Options);

        using var timeoutCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        timeoutCts.CancelAfter(SendTimeout);
        bool lockTaken = false;
        try
        {
            await connection.SendLock.WaitAsync(timeoutCts.Token);
            lockTaken = true;
            await connection.Socket.SendAsync(bytes, WebSocketMessageType.Text, true, timeoutCts.Token);
        }
        catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
        {
            // Timed out (not caller-cancelled): the peer's send pipe is wedged. Abort so every
            // path (gate holders, broadcasts) is released and the connection dies cleanly.
            try { connection.Socket.Abort(); } catch { /* already dead */ }
            throw new WebSocketException(WebSocketError.Faulted, $"WS send to {connection.AccountId} timed out after {SendTimeout.TotalSeconds:0}s; socket aborted.");
        }
        finally
        {
            if (lockTaken)
            {
                connection.SendLock.Release();
            }
        }
    }

    /// <summary>
    /// Close the socket under the connection's SendLock. CloseAsync writes a close frame; racing
    /// it against a concurrent SendAsync on the same ManagedWebSocket throws
    /// InvalidOperationException ("already one outstanding send operation").
    /// </summary>
    private static async Task CloseSocketUnderLockAsync(
        ClientConnection connection,
        WebSocketCloseStatus status,
        string reason,
        CancellationToken cancellationToken)
    {
        using var timeoutCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        timeoutCts.CancelAfter(SendTimeout);
        try
        {
            await connection.SendLock.WaitAsync(timeoutCts.Token);
        }
        catch (OperationCanceledException)
        {
            try { connection.Socket.Abort(); } catch { /* already dead */ }
            return;
        }

        try
        {
            if (connection.Socket.State is WebSocketState.Open or WebSocketState.CloseReceived)
            {
                await connection.Socket.CloseAsync(status, reason, timeoutCts.Token);
            }
        }
        catch
        {
            // Close handshake races (peer already gone) are not actionable.
        }
        finally
        {
            connection.SendLock.Release();
        }
    }

    private static string CreateLobbyId()
    {
        const string alphabet = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
        Span<char> chars = stackalloc char[6];
        for (int i = 0; i < chars.Length; i++)
        {
            chars[i] = alphabet[RandomNumberGenerator.GetInt32(alphabet.Length)];
        }

        return new string(chars);
    }

    private static string CreateGameAuthId(string accountId)
    {
        return Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes($"{accountId}:{Guid.NewGuid():N}")))[..32].ToLowerInvariant();
    }
}

internal sealed class ClientConnection
{
    public Guid Id { get; init; }
    public required WebSocket Socket { get; init; }
    public SemaphoreSlim SendLock { get; } = new(1, 1);
    public required string AccountId { get; init; }
    public required string Username { get; init; }
    public int Discriminator { get; init; }
    public int PlayerId { get; init; }
    public int CharId { get; set; } = 1;
    public string? LobbyId { get; set; }
    public bool IsAdmin { get; set; }
    /// <summary>False when the socket supplied no identity header/query and the server
    /// minted a fallback "Player{N}"/"custom-{N}" name. Used to suppress phantom
    /// LOBBY_JOINED toasts from header-less probe/discovery sockets.</summary>
    public bool HasRealIdentity { get; init; }
    /// <summary>True after the client passed mod attestation challenge-response.
    /// Persists for the WS session lifetime.</summary>
    public bool IsModAuthenticated { get; set; }

    public PlayerData ToPlayerData(bool isLeader)
    {
        return new PlayerData
        {
            AccountId = AccountId,
            Username = Username,
            Discriminator = Discriminator,
            Level = 1,
            CharId = CharId,
            BannerId = 0,
            Skins = CharacterCatalog.DefaultSkinAssetIds.ToArray(),
            PlayerStatus = 0,
            IsLeader = isLeader,
            IsReady = false,
            TeamId = 1,
            SpawnPosition = 0
        };
    }
}

internal sealed record LobbyPlayer(PlayerData Player, string GameAuthId);

internal sealed class CustomLobby
{
    public required string Id { get; init; }
    public required string LeaderAccountId { get; set; }
    public bool Starting { get; set; }
    public string? ActiveGameId { get; set; }
    public SettingsData Settings { get; set; } = new();
    public CustomGameSettingsData CustomSettings { get; set; } = new();
    public ConcurrentDictionary<string, LobbyPlayer> Players { get; } = [];

    public LobbyData ToLobbyData()
    {
        foreach (LobbyPlayer player in Players.Values)
        {
            player.Player.IsLeader = player.Player.AccountId == LeaderAccountId;
        }

        return new LobbyData
        {
            LobbyId = Id,
            LeaderAccountId = LeaderAccountId,
            LobbyOpen = true,
            Players = Players.Values.Select(p => p.Player).ToArray(),
            Settings = Settings
        };
    }

    public int NextTeamId(int maxTeams)
    {
        int limit = Math.Max(1, maxTeams);
        for (int team = 1; team <= limit; team++)
        {
            if (Players.Values.All(player => player.Player.TeamId != team))
            {
                return team;
            }
        }

        int count = Players.Count;
        return (count % limit) + 1;
    }
}

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
    private const int DefaultLobbyGameModeId = 1;
    private const int MinimumCharSelectMillis = 20000;

    private int PickMapId(int unityGameMode, int customSettingsMapId)
    {
        int[] enabled = BuildAllowedMapIds(unityGameMode);

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

        if (!_options.MatchDefaults.RandomizeMapPerMatch)
        {
            int configuredDefault = _options.MatchDefaults.MapId > 0
                ? _options.MatchDefaults.MapId
                : MapCatalog.BazaarCityId;
            return enabled.Contains(configuredDefault) ? configuredDefault : enabled[0];
        }

        return enabled[Random.Shared.Next(enabled.Length)];
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

    private readonly ConcurrentDictionary<Guid, ClientConnection> _clients = [];
    private readonly ConcurrentDictionary<string, CustomLobby> _lobbies = [];
    private readonly ConcurrentDictionary<string, GameServerSession> _matches = [];
    private readonly ConcurrentDictionary<string, string[]> _matchAccountIds = [];
    private readonly ConcurrentDictionary<string, DateTimeOffset> _emptyLobbyMatchSinceUtc = [];

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
                _matchAccountIds.TryRemove(gameId, out _);
                removed++;
            }
        }
        return removed;
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
        if (!string.IsNullOrWhiteSpace(payload.GameId))
        {
            if (_matches.TryGetValue(payload.GameId, out GameServerSession? session))
            {
                endedMapId = session.MapId;
                endedUnityGameModeId = session.UnityGameModeId;
                _gameServers.StopMatchServer(session);
                _matches.TryRemove(payload.GameId, out _);
                _emptyLobbyMatchSinceUtc.TryRemove(payload.GameId, out _);
                _matchAccountIds.TryRemove(payload.GameId, out _);
            }
        }

        // Find the lobby that started this match and apply rewards
        try
        {
            ApplyMatchEndRewards(payload.GameId, endedMapId, endedUnityGameModeId);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to apply match-end rewards for {GameId}.", payload.GameId);
        }

        _logger.LogInformation("Game ended: {GameId}", payload.GameId);
        _logger.LogInformation("[Analytics] Match ended: {GameId}", payload.GameId);
    }

    private void ApplyMatchEndRewards(string? gameId, int? mapId = null, int? unityGameModeId = null)
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

        // Find players that were connected (from clients list who had this match's lobby)
        // For now, give all currently connected players participation rewards
        var connectedPlayers = _clients.Values.ToArray();
        int placement = 1;
        foreach (var client in connectedPlayers)
        {
            // Ensure player exists in economy system before applying rewards
            _economyService.GetOrCreatePlayer(client.AccountId, client.Username);

            // Economy reward
            var reward = _economyService.CalculateMatchReward(client.AccountId, placement, 0, connectedPlayers.Length);
            _economyService.ApplyMatchRewards(reward);
            int characterXp = placement == 1 ? 150 : 75;
            _economyService.RecordCharacterXp(client.AccountId, client.Username, client.CharId, characterXp, "match-end");

            // Ranked processing
            _rankedService.ProcessMatchResult(client.AccountId, client.Username, placement, 0, connectedPlayers.Length);

            historyEntry.Players.Add(new MatchPlayerEntry
            {
                AccountId = client.AccountId,
                Username = client.Username,
                CharId = client.CharId,
                TeamId = 1,
                Placement = placement,
                GoldEarned = reward.TotalGold
            });

            placement++;
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
            await SendAsync(connection, Events.JoinLobbyFail, new
            {
                warningMessage = "This account is banned from this custom server.",
                errorCode = "ERR_BANNED"
            }, cancellationToken);
            await socket.CloseAsync(WebSocketCloseStatus.PolicyViolation, "banned", cancellationToken);
            return;
        }

        _clients[connection.Id] = connection;

        _logger.LogInformation("Client {AccountId} connected. admin={IsAdmin}", connection.AccountId, connection.IsAdmin);
        _logger.LogInformation("[Analytics] Player joined: {Username} (accountId={AccountId})", connection.Username, connection.AccountId);

        await SendAsync(connection, Events.SocketReady, null, cancellationToken);
        await SendAsync(connection, Events.GameModesUpdated, BuildGameModesUpdatedPayload(), cancellationToken);

        try
        {
            await ReceiveLoopAsync(connection, cancellationToken);
        }
        finally
        {
            _clients.TryRemove(connection.Id, out _);
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
            connection.SendLock.Dispose();
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

        return new ClientConnection
        {
            Id = Guid.NewGuid(),
            Socket = socket,
            AccountId = identity.AccountId,
            Username = identity.Username,
            Discriminator = identity.Discriminator,
            PlayerId = number,
            IsAdmin = _adminService.IsAdmin(identity.AccountId)
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
                        await connection.Socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "closed", cancellationToken);
                        return;
                    }

                    message.Write(rented, 0, result.Count);
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
        _logger.LogDebug("Received {Event} from {AccountId}: {Json}", evt, connection.AccountId, json);

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
            default:
                _logger.LogDebug("Unhandled websocket event {Event}.", envelope.Event);
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

        await _gate.WaitAsync(cancellationToken);
        try
        {
            int removedStale = RemoveAccountFromAllLobbiesLocked(connection.AccountId, keepLobbyId: null);
            bool staleQueue = _queueService.LeaveQueue(connection.AccountId);
            if (removedStale > 0 || staleQueue)
            {
                _logger.LogInformation(
                    "JoinLobby normalized stale state for {AccountId}: removedLobbies={RemovedLobbies} staleQueue={StaleQueue}.",
                    connection.AccountId,
                    removedStale,
                    staleQueue);
            }

            string lobbyId = string.IsNullOrWhiteSpace(payload.LobbyId) ? CreateLobbyId() : payload.LobbyId!.Trim().ToUpperInvariant();
            int lobbyGameModeId = ResolveLobbyGameModeId(payload.GameModeId);
            CustomLobby lobby = _lobbies.GetOrAdd(lobbyId, id => new CustomLobby
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

            connection.LobbyId = lobby.Id;
            connection.CharId = CharacterCatalog.IsKnownId(payload.CharId) ? payload.CharId : 1;
            _friendsService.UpdatePlayerLobby(connection.AccountId, lobby.Id);

            var player = connection.ToPlayerData(lobby.LeaderAccountId == connection.AccountId);
            player.TeamId = lobby.NextTeamId(_options.MatchDefaults.MaxTeams);
            lobby.Players[connection.AccountId] = new LobbyPlayer(player, CreateGameAuthId(connection.AccountId));

            var lobbyData = lobby.ToLobbyData();
            // Inject leader's gold balance into lobby payload so client UI shows correct gold
            try
            {
                int gold = _economyService.GetGold(connection.AccountId);
                lobbyData.Gold = gold;
                lobbyData.Fractals = 0;
                lobbyData.CharTokens = 0;
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

            await BroadcastAsync(lobby, Events.LobbyJoined, new { player }, cancellationToken, except: connection.Id);
        }
        finally
        {
            _gate.Release();
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
            int removedStale = RemoveAccountFromAllLobbiesLocked(connection.AccountId, lobby.Id);
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
                    int charId = CharacterCatalog.IsKnownId(lobbyPlayer.Player.CharId) ? lobbyPlayer.Player.CharId : 1;
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
            mapMapping = _options.MatchDefaults.MapMapping
        }, cancellationToken);
    }

    private async Task SwitchGameModeAsync(ClientConnection connection, GameModePayload payload, CancellationToken cancellationToken)
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

        int gameModeId = ResolveLobbyGameModeId(payload.GameModeId);
        lobby.Settings.GameModeId = gameModeId;
        lobby.CustomSettings.Gamemode = payload.GameModeId;
        await BroadcastAsync(lobby, Events.SwitchGameModeSuccess, new { gameModeId }, cancellationToken, only: connection.Id);
        await BroadcastAsync(lobby, Events.GameModeUpdated, new { gameModeId }, cancellationToken);
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

        lobbyPlayer.Player.CharId = CharacterCatalog.IsKnownId(payload.CharId) ? payload.CharId : lobbyPlayer.Player.CharId;
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

        int prunedMatches = CleanupStaleMatches();
        if (prunedMatches > 0)
        {
            _logger.LogInformation(
                "Pruned {PrunedMatches} stale/empty match(es) before custom match capacity check.",
                prunedMatches);
            await DelayAfterMatchCleanupAsync("custom", prunedMatches, cancellationToken);
        }

        if (_options.MaxConcurrentMatches > 0 && _matches.Count >= _options.MaxConcurrentMatches)
        {
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

        _matches[gameId] = session;
        _matchAccountIds[gameId] = lobby.Players.Keys.ToArray();
        _emptyLobbyMatchSinceUtc.TryRemove(gameId, out _);
        lobby.ActiveGameId = gameId;
        lobby.Starting = false;

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

        if (_options.MaxConcurrentMatches > 0 && _matches.Count >= _options.MaxConcurrentMatches)
        {
            _logger.LogWarning(
                "Matchmaking match start skipped: server at capacity ({Active}/{Max}). Players will remain in queue.",
                _matches.Count, _options.MaxConcurrentMatches);
            return false;
        }

        CustomLobby lobby;
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
                return true;
            }

            int removedOldLobbyMemberships = 0;
            foreach (ClientConnection client in connectedPlayers)
            {
                removedOldLobbyMemberships += RemoveAccountFromAllLobbiesLocked(client.AccountId, keepLobbyId: null);
            }

            if (removedOldLobbyMemberships > 0)
            {
                _logger.LogInformation(
                    "Matchmaking start normalized stale lobby memberships before creating the match lobby: removed={RemovedCount} accounts=[{Accounts}].",
                    removedOldLobbyMemberships,
                    string.Join(",", connectedPlayers.Select(client => client.AccountId)));
            }

            string lobbyId = $"MM{CreateLobbyId()}";
            int requestedBotCount = Math.Max(0, _queueOptions.DefaultBotCount);
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
                    Gamemode = _queueOptions.DefaultGameMode,
                    MapId = Math.Max(0, _queueOptions.DefaultMapId),
                    TeamSize = Math.Max(1, _queueOptions.DefaultTeamSize),
                    MaxTeams = Math.Max(_queueOptions.DefaultMaxTeams, connectedPlayers.Length),
                    BotCount = effectiveBotCount,
                    BotDifficulty = _queueOptions.DefaultBotDifficulty,
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
                client.CharId = entry is not null && CharacterCatalog.IsKnownId(entry.CharId) ? entry.CharId : 1;
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
                _lobbies.TryRemove(lobby.Id, out _);
                _gameServers.StopMatchServer(session);
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
        _matchAccountIds[gameId] = lobby.Players.Keys.ToArray();
        _emptyLobbyMatchSinceUtc.TryRemove(gameId, out _);
        lobby.ActiveGameId = gameId;
        lobby.Starting = false;

        QueueMatchedPayload queuePayload = CreateQueueMatchedPayload(lobby, mapId);
        await BroadcastAsync(lobby, Events.QueueMatched, queuePayload, cancellationToken);
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
                SkinAssetId = GetEquippedSkinForCharacter(player.Player),
                TeamId = player.Player.TeamId,
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
            SpawnLocationPerTeam = Enumerable.Range(0, Math.Max(2, lobby.CustomSettings.MaxTeams + 1)).ToArray(),
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

        ClientConnection? connection = _clients.Values.FirstOrDefault(client =>
            string.Equals(client.AccountId, normalized, StringComparison.OrdinalIgnoreCase));
        if (connection is null)
        {
            return false;
        }

        await SendAsync(connection, Events.LobbyLeft, new
        {
            accountId = normalized,
            username = connection.Username,
            warningMessage = reason
        }, cancellationToken);

        await RemoveFromLobbyAsync(connection, cancellationToken);

        if (connection.Socket.State == WebSocketState.Open)
        {
            await connection.Socket.CloseAsync(WebSocketCloseStatus.PolicyViolation, reason, cancellationToken);
        }

        _clients.TryRemove(connection.Id, out _);
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
        _matchAccountIds.TryRemove(session.GameId, out _);
        _gameServers.StopMatchServer(session);
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
            mapMapping = _options.MatchDefaults.MapMapping
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
        // Default: only Solos when nothing configured (user wanted "erstmal nur solo")
        return [3];
    }

    private int RemoveAccountFromAllLobbiesLocked(string accountId, string? keepLobbyId)
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

            if (!lobby.Players.TryRemove(accountId, out _))
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
        }

        return removed;
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

            await SendAsync(client, evt, payload, cancellationToken);
        }
    }

    private static async Task SendAsync(ClientConnection connection, string evt, object? payload, CancellationToken cancellationToken)
    {
        if (connection.Socket.State != WebSocketState.Open)
        {
            return;
        }

        var envelope = new OutgoingEnvelope(evt, payload);
        byte[] bytes = JsonSerializer.SerializeToUtf8Bytes(envelope, JsonContract.Options);

        await connection.SendLock.WaitAsync(cancellationToken);
        try
        {
            await connection.Socket.SendAsync(bytes, WebSocketMessageType.Text, true, cancellationToken);
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
    public bool IsAdmin { get; init; }

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

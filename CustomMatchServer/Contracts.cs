using System.Text.Json;
using System.Text.Json.Serialization;

namespace BapCustomServer;

public static class JsonContract
{
    public static readonly JsonSerializerOptions Options = new(JsonSerializerDefaults.Web)
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        WriteIndented = false
    };

    public static readonly JsonSerializerOptions PrettyOptions = new(JsonSerializerDefaults.Web)
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        WriteIndented = true
    };
}

public static class Events
{
    public const string SocketReady = "SOCKET_READY";
    public const string JoinLobby = "JOIN_LOBBY";
    public const string JoinLobbySuccess = "JOIN_LOBBY_SUCCESS";
    public const string JoinLobbyFail = "JOIN_LOBBY_FAIL";
    public const string LobbyJoined = "LOBBY_JOINED";
    public const string LobbyLeft = "LOBBY_LEFT";
    public const string SwitchReady = "SWITCH_READY";
    public const string SwitchReadySuccess = "SWITCH_READY_SUCCESS";
    public const string ReadyUpdated = "READY_UPDATED";
    public const string SwitchCustomReady = "SWITCH_CUSTOM_READY";
    public const string SwitchCustomReadySuccess = "SWITCH_CUSTOM_READY_SUCCESS";
    public const string UpdateCustomTeam = "UPDATE_CUSTOM_TEAM";
    public const string UpdateCustomTeamSuccess = "UPDATE_CUSTOM_TEAM_SUCCESS";
    public const string UpdateCustomTeamFail = "UPDATE_CUSTOM_TEAM_FAIL";
    public const string UpdateCustomSettings = "UPDATE_CUSTOM_SETTINGS";
    public const string UpdateCustomSettingsSuccess = "UPDATE_CUSTOM_SETTINGS_SUCCESS";
    public const string UpdateCustomSettingsFail = "UPDATE_CUSTOM_SETTINGS_FAIL";
    public const string StartCustomGame = "START_CUSTOM_GAME";
    public const string StartCustomGameSuccess = "START_CUSTOM_GAME_SUCCESS";
    public const string StartCustomGameFail = "START_CUSTOM_GAME_FAIL";
    public const string SwitchGameMode = "SWITCH_GAME_MODE";
    public const string SwitchGameModeSuccess = "SWITCH_GAME_MODE_SUCCESS";
    public const string GameModeUpdated = "GAME_MODE_UPDATED";
    public const string GameModesUpdated = "GAME_MODES_UPDATED";
    public const string SwitchRegion = "SWITCH_REGION";
    public const string SwitchRegionSuccess = "SWITCH_REGION_SUCCESS";
    public const string RegionUpdated = "REGION_UPDATED";
    public const string SwitchCharacter = "SWITCH_CHAR";
    public const string SwitchCharacterSuccess = "SWITCH_CHAR_SUCCESS";
    public const string CharacterUpdated = "CHAR_UPDATED";
    public const string QueueMatched = "QUEUE_MATCHED";
    public const string QueueUpdated = "QUEUE_UPDATED";
    public const string GameStarted = "GAME_STARTED";
    public const string GameCompleted = "GAME_COMPLETED";
    public const string CancelMatchmaking = "CANCEL_MATCHMAKING";
    public const string CancelMatchmakingSuccess = "CANCEL_MATCHMAKING_SUCCESS";
    public const string CancelMatchmakingFail = "CANCEL_MATCHMAKING_FAIL";
    // BAPBAP client handler is HandleMatchmakingExitedMessage / HandleMatchmakingEnteredMessage /
    // HandleMatchmakingErroredMessage. The event names below match those handlers exactly.
    public const string MatchmakingEntered = "MATCHMAKING_ENTERED";
    public const string MatchmakingExited = "MATCHMAKING_EXITED";
    public const string MatchmakingErrored = "MATCHMAKING_ERRORED";
    // Legacy alias kept so any older client paths that use MATCHMAKING_LEFT still see a payload.
    public const string MatchmakingLeftLegacy = "MATCHMAKING_LEFT";
    // Aliases for queue cancel/leave intent. BAPBAP itself uses CANCEL_MATCHMAKING but we also
    // accept these in case any tooling, mod patch, or proxy uses them.
    public const string LeaveQueue = "LEAVE_QUEUE";
    public const string CancelQueue = "CANCEL_QUEUE";
    public const string FriendRequestReceived = "FRIEND_REQUEST_RECEIVED";
    public const string FriendRequestAccepted = "FRIEND_REQUEST_ACCEPTED";
    public const string PartyInviteReceived = "PARTY_INVITE_RECEIVED";
    public const string FriendOnline = "FRIEND_ONLINE";
    public const string FriendOffline = "FRIEND_OFFLINE";

    // Friends WS push/receive event strings. INFERRED from the client's DTO + handler names
    // (SetFriendsResponse/HandleSetFriendResponse, etc.) — the IL2CPP build stripped the string
    // literals so they can't be confirmed statically. The default-case diagnostic logger in
    // HandleMessageAsync captures the real client->server strings on a live friends-panel session;
    // confirm + correct these in one place if a capture shows otherwise.
    public const string SetFriends = "SET_FRIENDS";                       // S->C: full friend list (per friend)
    public const string SetFriendRequests = "SET_FRIEND_REQUESTS";       // S->C: pending requests list
    public const string FriendStatus = "FRIEND_STATUS";                  // S->C: one friend's status change
    public const string UpdateFriendRequests = "UPDATE_FRIEND_REQUESTS"; // S->C: incremental request update
    public const string FriendRemoved = "FRIEND_REMOVED";                // S->C: a friend was removed
    public const string FriendInviteLobby = "FRIEND_INVITE_LOBBY";       // C->S: invite a friend to my lobby
    public const string JoinFriendLobby = "JOIN_FRIEND_LOBBY";           // C->S: join a friend's lobby
    public const string JoinFriendLobbySuccess = "JOIN_FRIEND_LOBBY_SUCCESS"; // S->C: join-friend ok
    public const string InviteLobby = "INVITE_LOBBY";                    // S->C: deliver a lobby invite

    // Admin auth handshake — 3-step challenge-response over WS
    public const string ModHello = "MOD_HELLO";
    public const string ModChallenge = "MOD_CHALLENGE";
    public const string ModAuth = "MOD_AUTH";
    public const string ModAuthOk = "MOD_AUTH_OK";
    public const string AdminAuth = "ADMIN_AUTH";
    public const string AdminAuthResult = "ADMIN_AUTH_RESULT";
}

public sealed record LobbySocketResponse(string SocketUrl);

public sealed record InternalServersResponse(InternalServerData[] Servers);

public sealed record InternalServerData(string Hostname, int KcpPort, int TcpPort, int WsPort);

public sealed class SocketEnvelope
{
    [JsonPropertyName("event")]
    public string Event { get; set; } = "";

    public JsonElement Payload { get; set; }
}

public sealed record OutgoingEnvelope(
    [property: JsonPropertyName("event")] string Event,
    object? Payload = null);

public sealed class JoinLobbyPayload
{
    public string? LobbyId { get; set; }
    public int CharId { get; set; } = 1;
    public string? Version { get; set; }
    public string? RegionId { get; set; }
    public int GameModeId { get; set; }
    public bool IsAutoFill { get; set; }
    public bool IsInvite { get; set; }
    public bool WasKicked { get; set; }
}

public sealed class BoolPayload
{
    public bool IsReady { get; set; }
    public bool ForceStart { get; set; }
}

public sealed class TeamPayload
{
    public int TeamId { get; set; }
}

public sealed class GameModePayload
{
    public int GameModeId { get; set; }
    public string? Password { get; set; }
}

public sealed class RegionPayload
{
    public string? RegionId { get; set; }
}

public sealed class CharacterPayload
{
    public int CharId { get; set; }
}

public sealed class CustomSettingsPayload
{
    public CustomGameSettingsData? Settings { get; set; }
}

public sealed class LobbyData
{
    public string LobbyId { get; set; } = "";
    public string LeaderAccountId { get; set; } = "";
    public bool LobbyOpen { get; set; } = true;
    public PlayerData[] Players { get; set; } = [];
    public SettingsData Settings { get; set; } = new();
    // Currency fields the BAPBAP client UI reads from this payload (not from /api/load)
    public int Gold { get; set; }
    public int Fractals { get; set; }
    public int CharTokens { get; set; }
    public int AccountXp { get; set; }
}

public sealed class PlayerData
{
    public string AccountId { get; set; } = "";
    public string Username { get; set; } = "";
    public int Discriminator { get; set; }
    public int Level { get; set; } = 1;
    public int CharId { get; set; } = 1;
    public int BannerId { get; set; }
    public int[] Skins { get; set; } = [];
    public int PlayerStatus { get; set; }
    public bool IsLeader { get; set; }
    public bool IsReady { get; set; }
    public int TeamId { get; set; } = 1;
    public int SpawnPosition { get; set; }
}

public sealed class SettingsData
{
    public string RegionId { get; set; } = "custom";
    public int GameModeId { get; set; }
    public bool IsAutoFill { get; set; }
}

public sealed class CustomGameSettingsData
{
    public int Gamemode { get; set; }
    public int MapId { get; set; } = 1;
    public int TeamSize { get; set; } = 1;
    public int MaxTeams { get; set; } = 8;
    public int BotCount { get; set; }
    public int BotDifficulty { get; set; } = 1;
    public int[] GameModifierIds { get; set; } = [];
    public DimensionData[] DimensionData { get; set; } = [];
    public int? MatchmakingGameMode { get; set; }
    public int? CharSelectMillis { get; set; }
    public int? SpawnSelectMillis { get; set; }
    public int? SpawnShowMillis { get; set; }
}

public sealed class MapMappingEntry
{
    public int UnityGameModeId { get; set; }
    public int[] MapIds { get; set; } = [];
}

public sealed class QueueMatchedPayload
{
    public PlayerData[] Players { get; set; } = [];
    public int CurrentPlayerCount { get; set; }
    public int MaxPlayerCount { get; set; }
    public int CharSelectMillis { get; set; }
    public int[] AvailableCharacters { get; set; } = [];
    public int[] GameModifierIds { get; set; } = [];
    public int LevelId { get; set; }
    public int UnityGameMode { get; set; }
    public DimensionData[] DimensionData { get; set; } = [];
}

public sealed class DimensionData
{
    public int DimensionId { get; set; }
    public int[] Rounds { get; set; } = [];
}

public sealed class GameStartedPayload
{
    public string GameId { get; set; } = "";
    public string GameAuthId { get; set; } = "";
    public string GameDns { get; set; } = "";
    public int WsPort { get; set; }
    public int KcpPort { get; set; }
    public int TcpPort { get; set; }
    public int MapId { get; set; }
    public int LevelId { get; set; }
    public int UnityGameMode { get; set; }
}

public sealed class MatchmakingGameData
{
    public int ReqId { get; set; }
    public string QueueId { get; set; } = "";
    public int MatchmakingGameModeId { get; set; }
    public int UnityGameModeId { get; set; }
    public int UnityTeamSize { get; set; }
    public float AvgPoints { get; set; }
    public List<MatchmakingScoreSheetData> ScoreTable { get; set; } = [];
    public int MapId { get; set; }
    public int[] GameModifierId { get; set; } = [];
    public List<MatchmakingDimensionData> DimensionData { get; set; } = [];
    public int CharSelectMillis { get; set; }
    public int SpawnSelectMillis { get; set; }
    public int SpawnShowMillis { get; set; }
}

public sealed class MatchmakingTeamData
{
    public int ReqId { get; set; }
    public string GameId { get; set; } = "";
    public int BotTeams { get; set; }
    public int BotDifficulty { get; set; }
    public int[] SpawnLocationPerTeam { get; set; } = [];
    public List<MatchmakingPlayerData> Players { get; set; } = [];
}

public sealed class QueueMatchedData
{
    public int ReqId { get; set; }
    public string GameId { get; set; } = "";
    public List<MatchmakingPlayerData> Players { get; set; } = [];
    public int BotTeams { get; set; }
    public int BotDifficulty { get; set; }
    public int[] AvailableCharacters { get; set; } = [];
}

public sealed class MatchmakingPlayerData
{
    public string Username { get; set; } = "";
    public int Discriminator { get; set; }
    public string AccountId { get; set; } = "";
    public string GameAuthId { get; set; } = "";
    public string LobbyCode { get; set; } = "";
    public int Points { get; set; }
    public int CharId { get; set; }
    public int SkinAssetId { get; set; }
    public int TeamId { get; set; }
    public int BannerId { get; set; }
    public int Level { get; set; }
    public int PlayerId { get; set; }
}

public sealed class MatchmakingScoreSheetData
{
    // BAPBAP expects: string tier, int max, List<int> placements, int kills.
    public string Tier { get; set; } = "";
    public int Max { get; set; }
    public List<int> Placements { get; set; } = [];
    public int Kills { get; set; }
    // Legacy fields (no longer sent in standard payloads, kept to avoid breaking other code paths).
    public int Placement { get; set; }
    public int Points { get; set; }
}

public sealed class MatchmakingDimensionData
{
    public int DimensionId { get; set; }
    // BAPBAP expects: Vector2 spawnPoint + float radius (not int[] rounds).
    public Vector2Data SpawnPoint { get; set; } = new();
    public float Radius { get; set; } = 100f;
    // Keep Rounds for backwards compatibility with custom-server-side admin commands; not sent in standard payloads.
    public int[] Rounds { get; set; } = [];
}

public sealed class Vector2Data
{
    public float X { get; set; }
    public float Y { get; set; }
}

public sealed class GamePing
{
    public string? GameId { get; set; }
    public string? Hostname { get; set; }
    public int WsPort { get; set; }
    public int KcpPort { get; set; }
    public int TcpPort { get; set; }
    public int PlayerCount { get; set; }
}

public sealed class GameEndedPayload
{
    public string? GameId { get; set; }
    public JsonElement Data { get; set; }
}

public sealed class LoadResponse
{
    public string AccountId { get; set; } = "";
    public string Username { get; set; } = "";
    public int Discriminator { get; set; }
    public bool IsGuest { get; set; }
    public int Level { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsCompleted { get; set; } = true;
    public string Email { get; set; } = "";
    public LoadAsset[] Assets { get; set; } = [];
    public LoadInviteCode InviteCode { get; set; } = new();
    public Loadout Loadout { get; set; } = new();
    public int TotalGames { get; set; }
    public bool FriendRequestsOpen { get; set; }
    public int[] AvailableCharacters { get; set; } = [];
    public bool Blocked { get; set; }
    public string CreatorCode { get; set; } = "";
    public string CreatorName { get; set; } = "";
}

public sealed class LoadAsset
{
    public int AssetId { get; set; }
    public int Balance { get; set; }
}

public sealed class LoadInviteCode
{
    public string Code { get; set; } = "CUSTOM";
    public int UsesLeft { get; set; }
    public int UsesTotal { get; set; }
}

public sealed class Loadout
{
    public int BannerId { get; set; }
    public int[] Skins { get; set; } = [];
}

public sealed class AdminCommandRequest
{
    public string Command { get; set; } = "";
    public string? AccountId { get; set; }
    public string? LobbyId { get; set; }
    public string? GameId { get; set; }
    public string? Reason { get; set; }
    public DateTimeOffset? ExpiresUtc { get; set; }
    public CustomGameSettingsData? Settings { get; set; }
}

public sealed record AdminCommandResult(bool Ok, string Command, string Message, object? Data = null);

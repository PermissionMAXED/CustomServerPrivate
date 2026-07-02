using Microsoft.Extensions.Options;
using System.Collections.Concurrent;
using System.Text;
using System.Text.Json;

namespace BapCustomServer;

public sealed class FriendsOptions
{
    public bool Enabled { get; set; } = true;
    public string StateFile { get; set; } = "data/friends-state.json";
    public int MaxFriendsPerPlayer { get; set; } = 100;
    public int MaxPendingRequests { get; set; } = 50;
    public int MaxPartyInvites { get; set; } = 10;
    public int PartyInviteExpiryMinutes { get; set; } = 5;
}

public sealed class FriendsStateDocument
{
    public List<FriendRelationship> Friends { get; set; } = [];
    public List<FriendRequest> PendingRequests { get; set; } = [];
}

public sealed class FriendRelationship
{
    public string AccountId1 { get; set; } = "";
    public string AccountId2 { get; set; } = "";
    public DateTimeOffset CreatedUtc { get; set; }
    // Last-known display names captured at accept time so offline friends render with a
    // name/discriminator instead of blank (the originating friend request is deleted on accept).
    public string Username1 { get; set; } = "";
    public int Discriminator1 { get; set; }
    public string Username2 { get; set; } = "";
    public int Discriminator2 { get; set; }
}

public sealed class FriendRequest
{
    public string FromAccountId { get; set; } = "";
    public string FromUsername { get; set; } = "";
    public int FromDiscriminator { get; set; }
    public string ToAccountId { get; set; } = "";
    public DateTimeOffset CreatedUtc { get; set; }
}

public sealed record FriendRequestResult(bool Ok, string Message);

public sealed class FriendInfo
{
    public string AccountId { get; set; } = "";
    public string Username { get; set; } = "";
    public int Discriminator { get; set; }
    public bool IsOnline { get; set; }
    public string? LobbyId { get; set; }
}

public sealed class FriendPresenceInfo
{
    public string AccountId { get; set; } = "";
    public string Username { get; set; } = "";
    public int Discriminator { get; set; }
    public string? LobbyId { get; set; }
}

public sealed class PartyInvite
{
    public string FromAccountId { get; set; } = "";
    public string FromUsername { get; set; } = "";
    public string LobbyId { get; set; } = "";
    public DateTimeOffset CreatedUtc { get; set; }
}

public sealed class PartyInviteResult
{
    public bool Ok { get; set; }
    public string Message { get; set; } = "";
}

public sealed class OnlinePlayerInfo
{
    public string AccountId { get; set; } = "";
    public string Username { get; set; } = "";
    public int Discriminator { get; set; }
    public string? LobbyId { get; set; }
}

public sealed class FriendsService
{
    private readonly SemaphoreSlim _lock = new(1, 1);
    private readonly ConcurrentDictionary<string, OnlinePlayerInfo> _onlinePlayers = new(StringComparer.OrdinalIgnoreCase);
    private readonly ConcurrentDictionary<string, List<PartyInvite>> _partyInvites = new(StringComparer.OrdinalIgnoreCase);
    private readonly ConcurrentDictionary<string, bool> _friendRequestsOpen = new(StringComparer.OrdinalIgnoreCase);
    private readonly ConcurrentDictionary<string, bool> _closedParty = new(StringComparer.OrdinalIgnoreCase);

    private readonly string _statePath;
    private readonly FriendsOptions _options;
    private readonly ILogger<FriendsService> _logger;

    private FriendsStateDocument _state = new();

    public FriendsService(IOptions<FriendsOptions> options, ILogger<FriendsService> logger)
    {
        _options = options.Value;
        _logger = logger;
        _statePath = ResolvePath(_options.StateFile);
        LoadState();
    }

    // === Presence ===

    public void RegisterOnline(string accountId, string username, int discriminator)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return;

        var info = new OnlinePlayerInfo
        {
            AccountId = accountId,
            Username = username,
            Discriminator = discriminator
        };

        _onlinePlayers[accountId] = info;
        _logger.LogDebug("Player online: {AccountId} ({Username}#{Discriminator})", accountId, username, discriminator);
    }

    public void RegisterOffline(string accountId)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return;

        _onlinePlayers.TryRemove(accountId, out _);
        _partyInvites.TryRemove(accountId, out _);
        _logger.LogDebug("Player offline: {AccountId}", accountId);
    }

    public bool IsOnline(string accountId)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return false;
        return _onlinePlayers.ContainsKey(accountId);
    }

    public void UpdatePlayerLobby(string accountId, string? lobbyId)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return;

        if (_onlinePlayers.TryGetValue(accountId, out OnlinePlayerInfo? info))
        {
            info.LobbyId = lobbyId;
        }
    }

    public FriendPresenceInfo[] GetOnlineFriends(string accountId)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return [];

        _lock.Wait();
        try
        {
            var friendIds = GetFriendAccountIds(accountId);
            var result = new List<FriendPresenceInfo>();

            foreach (string friendId in friendIds)
            {
                if (_onlinePlayers.TryGetValue(friendId, out OnlinePlayerInfo? info))
                {
                    result.Add(new FriendPresenceInfo
                    {
                        AccountId = info.AccountId,
                        Username = info.Username,
                        Discriminator = info.Discriminator,
                        LobbyId = info.LobbyId
                    });
                }
            }

            return result.ToArray();
        }
        finally
        {
            _lock.Release();
        }
    }

    // === Friend Requests ===

    public FriendRequestResult SendRequest(string fromAccountId, string fromUsername, int fromDiscriminator, string toAccountId)
    {
        if (string.IsNullOrWhiteSpace(fromAccountId) || string.IsNullOrWhiteSpace(toAccountId))
            return new FriendRequestResult(false, "Invalid account ID.");

        if (string.Equals(fromAccountId, toAccountId, StringComparison.OrdinalIgnoreCase))
            return new FriendRequestResult(false, "Cannot send a friend request to yourself.");

        if (!AreFriendRequestsOpen(toAccountId))
            return new FriendRequestResult(false, "This player is not accepting friend requests.");

        _lock.Wait();
        try
        {
            if (AreFriends(fromAccountId, toAccountId))
                return new FriendRequestResult(false, "You are already friends with this player.");

            int fromFriendCount = CountFriends(fromAccountId);
            if (fromFriendCount >= _options.MaxFriendsPerPlayer)
                return new FriendRequestResult(false, "You have reached the maximum number of friends.");

            int toFriendCount = CountFriends(toAccountId);
            if (toFriendCount >= _options.MaxFriendsPerPlayer)
                return new FriendRequestResult(false, "This player has reached the maximum number of friends.");

            bool alreadyPending = _state.PendingRequests.Any(r =>
                string.Equals(r.FromAccountId, fromAccountId, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(r.ToAccountId, toAccountId, StringComparison.OrdinalIgnoreCase));

            if (alreadyPending)
                return new FriendRequestResult(false, "A friend request is already pending.");

            // Check if the other player already sent us a request - auto accept
            FriendRequest? reverseRequest = _state.PendingRequests.FirstOrDefault(r =>
                string.Equals(r.FromAccountId, toAccountId, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(r.ToAccountId, fromAccountId, StringComparison.OrdinalIgnoreCase));

            if (reverseRequest is not null)
            {
                _state.PendingRequests.Remove(reverseRequest);
                _state.Friends.Add(new FriendRelationship
                {
                    AccountId1 = fromAccountId,
                    AccountId2 = toAccountId,
                    CreatedUtc = DateTimeOffset.UtcNow,
                    Username1 = fromUsername,
                    Discriminator1 = fromDiscriminator,
                    Username2 = reverseRequest.FromUsername,
                    Discriminator2 = reverseRequest.FromDiscriminator
                });
                SaveState();
                _logger.LogInformation("Friend request auto-accepted (mutual): {From} <-> {To}", fromAccountId, toAccountId);
                return new FriendRequestResult(true, "Friend request accepted (mutual request).");
            }

            int pendingToCount = _state.PendingRequests.Count(r =>
                string.Equals(r.ToAccountId, toAccountId, StringComparison.OrdinalIgnoreCase));

            if (pendingToCount >= _options.MaxPendingRequests)
                return new FriendRequestResult(false, "This player has too many pending friend requests.");

            _state.PendingRequests.Add(new FriendRequest
            {
                FromAccountId = fromAccountId,
                FromUsername = fromUsername,
                FromDiscriminator = fromDiscriminator,
                ToAccountId = toAccountId,
                CreatedUtc = DateTimeOffset.UtcNow
            });

            SaveState();
            _logger.LogInformation("Friend request sent: {From} -> {To}", fromAccountId, toAccountId);
            return new FriendRequestResult(true, "Friend request sent.");
        }
        finally
        {
            _lock.Release();
        }
    }

    public FriendRequestResult AcceptRequest(string accountId, string fromAccountId)
    {
        if (string.IsNullOrWhiteSpace(accountId) || string.IsNullOrWhiteSpace(fromAccountId))
            return new FriendRequestResult(false, "Invalid account ID.");

        _lock.Wait();
        try
        {
            FriendRequest? request = _state.PendingRequests.FirstOrDefault(r =>
                string.Equals(r.FromAccountId, fromAccountId, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(r.ToAccountId, accountId, StringComparison.OrdinalIgnoreCase));

            if (request is null)
                return new FriendRequestResult(false, "No pending friend request found.");

            int myFriendCount = CountFriends(accountId);
            if (myFriendCount >= _options.MaxFriendsPerPlayer)
                return new FriendRequestResult(false, "You have reached the maximum number of friends.");

            int theirFriendCount = CountFriends(fromAccountId);
            if (theirFriendCount >= _options.MaxFriendsPerPlayer)
                return new FriendRequestResult(false, "The other player has reached the maximum number of friends.");

            // Capture the accepter's name from the online registry if available (the requester's
            // name comes from the request being accepted), so both sides render when offline.
            string accepterUsername = "";
            int accepterDiscriminator = 0;
            if (_onlinePlayers.TryGetValue(accountId, out OnlinePlayerInfo? accepterInfo))
            {
                accepterUsername = accepterInfo.Username;
                accepterDiscriminator = accepterInfo.Discriminator;
            }

            _state.PendingRequests.Remove(request);
            _state.Friends.Add(new FriendRelationship
            {
                AccountId1 = fromAccountId,
                AccountId2 = accountId,
                CreatedUtc = DateTimeOffset.UtcNow,
                Username1 = request.FromUsername,
                Discriminator1 = request.FromDiscriminator,
                Username2 = accepterUsername,
                Discriminator2 = accepterDiscriminator
            });

            SaveState();
            _logger.LogInformation("Friend request accepted: {From} <-> {To}", fromAccountId, accountId);
            return new FriendRequestResult(true, "Friend request accepted.");
        }
        finally
        {
            _lock.Release();
        }
    }

    public FriendRequestResult DeclineRequest(string accountId, string fromAccountId)
    {
        if (string.IsNullOrWhiteSpace(accountId) || string.IsNullOrWhiteSpace(fromAccountId))
            return new FriendRequestResult(false, "Invalid account ID.");

        _lock.Wait();
        try
        {
            FriendRequest? request = _state.PendingRequests.FirstOrDefault(r =>
                string.Equals(r.FromAccountId, fromAccountId, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(r.ToAccountId, accountId, StringComparison.OrdinalIgnoreCase));

            if (request is null)
                return new FriendRequestResult(false, "No pending friend request found.");

            _state.PendingRequests.Remove(request);
            SaveState();
            _logger.LogInformation("Friend request declined: {From} -> {To}", fromAccountId, accountId);
            return new FriendRequestResult(true, "Friend request declined.");
        }
        finally
        {
            _lock.Release();
        }
    }

    public FriendRequest[] GetPendingRequests(string accountId)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return [];

        _lock.Wait();
        try
        {
            return _state.PendingRequests
                .Where(r => string.Equals(r.ToAccountId, accountId, StringComparison.OrdinalIgnoreCase))
                .ToArray();
        }
        finally
        {
            _lock.Release();
        }
    }

    // === Friends List ===

    public FriendInfo[] GetFriends(string accountId)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return [];

        _lock.Wait();
        try
        {
            var friendIds = GetFriendAccountIds(accountId);
            var result = new List<FriendInfo>();

            foreach (string friendId in friendIds)
            {
                string username = "";
                int discriminator = 0;
                bool isOnline = false;
                string? lobbyId = null;

                if (_onlinePlayers.TryGetValue(friendId, out OnlinePlayerInfo? onlineInfo))
                {
                    username = onlineInfo.Username;
                    discriminator = onlineInfo.Discriminator;
                    isOnline = true;
                    lobbyId = onlineInfo.LobbyId;
                }
                else if (TryGetPersistedFriendName(accountId, friendId, out string persistedName, out int persistedDiscriminator))
                {
                    // Names captured on the relationship at accept time; the originating
                    // friend request was deleted on accept so it can't be mined here.
                    username = persistedName;
                    discriminator = persistedDiscriminator;
                }

                result.Add(new FriendInfo
                {
                    AccountId = friendId,
                    Username = username,
                    Discriminator = discriminator,
                    IsOnline = isOnline,
                    LobbyId = lobbyId
                });
            }

            return result.ToArray();
        }
        finally
        {
            _lock.Release();
        }
    }

    public FriendRequestResult RemoveFriend(string accountId, string friendAccountId)
    {
        if (string.IsNullOrWhiteSpace(accountId) || string.IsNullOrWhiteSpace(friendAccountId))
            return new FriendRequestResult(false, "Invalid account ID.");

        _lock.Wait();
        try
        {
            FriendRelationship? relationship = _state.Friends.FirstOrDefault(f =>
                (string.Equals(f.AccountId1, accountId, StringComparison.OrdinalIgnoreCase) &&
                 string.Equals(f.AccountId2, friendAccountId, StringComparison.OrdinalIgnoreCase)) ||
                (string.Equals(f.AccountId1, friendAccountId, StringComparison.OrdinalIgnoreCase) &&
                 string.Equals(f.AccountId2, accountId, StringComparison.OrdinalIgnoreCase)));

            if (relationship is null)
                return new FriendRequestResult(false, "You are not friends with this player.");

            _state.Friends.Remove(relationship);
            SaveState();
            _logger.LogInformation("Friend removed: {AccountId} removed {FriendId}", accountId, friendAccountId);
            return new FriendRequestResult(true, "Friend removed.");
        }
        finally
        {
            _lock.Release();
        }
    }

    // === Party Invites ===

    public PartyInviteResult SendPartyInvite(string fromAccountId, string fromUsername, string toLobbyId, string toAccountId)
    {
        if (string.IsNullOrWhiteSpace(fromAccountId) || string.IsNullOrWhiteSpace(toAccountId))
            return new PartyInviteResult { Ok = false, Message = "Invalid account ID." };

        if (string.IsNullOrWhiteSpace(toLobbyId))
            return new PartyInviteResult { Ok = false, Message = "Invalid lobby ID." };

        if (string.Equals(fromAccountId, toAccountId, StringComparison.OrdinalIgnoreCase))
            return new PartyInviteResult { Ok = false, Message = "Cannot invite yourself." };

        if (!IsOnline(toAccountId))
            return new PartyInviteResult { Ok = false, Message = "Player is not online." };

        if (IsPartyClosed(toAccountId))
            return new PartyInviteResult { Ok = false, Message = "Player is not accepting party invites." };

        List<PartyInvite> invites = _partyInvites.GetOrAdd(toAccountId, _ => new List<PartyInvite>());

        lock (invites)
        {
            PurgeExpiredInvites(invites);

            bool alreadyInvited = invites.Any(i =>
                string.Equals(i.FromAccountId, fromAccountId, StringComparison.OrdinalIgnoreCase));

            if (alreadyInvited)
                return new PartyInviteResult { Ok = false, Message = "You already have a pending invite to this player." };

            if (invites.Count >= _options.MaxPartyInvites)
                return new PartyInviteResult { Ok = false, Message = "Player has too many pending party invites." };

            invites.Add(new PartyInvite
            {
                FromAccountId = fromAccountId,
                FromUsername = fromUsername,
                LobbyId = toLobbyId,
                CreatedUtc = DateTimeOffset.UtcNow
            });
        }

        _logger.LogDebug("Party invite sent: {From} -> {To} (lobby: {LobbyId})", fromAccountId, toAccountId, toLobbyId);
        return new PartyInviteResult { Ok = true, Message = "Party invite sent." };
    }

    public PartyInvite[] GetPendingPartyInvites(string accountId)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return [];

        if (!_partyInvites.TryGetValue(accountId, out List<PartyInvite>? invites))
            return [];

        lock (invites)
        {
            PurgeExpiredInvites(invites);
            return invites.ToArray();
        }
    }

    public void ClearPartyInvite(string accountId, string fromAccountId)
    {
        if (string.IsNullOrWhiteSpace(accountId) || string.IsNullOrWhiteSpace(fromAccountId)) return;

        if (!_partyInvites.TryGetValue(accountId, out List<PartyInvite>? invites))
            return;

        lock (invites)
        {
            invites.RemoveAll(i => string.Equals(i.FromAccountId, fromAccountId, StringComparison.OrdinalIgnoreCase));
        }
    }

    // === Settings ===

    public void SetFriendRequestsOpen(string accountId, bool open)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return;
        _friendRequestsOpen[accountId] = open;
    }

    public void SetClosedParty(string accountId, bool closed)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return;
        _closedParty[accountId] = closed;
    }

    public bool AreFriendRequestsOpen(string accountId)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return true;
        return _friendRequestsOpen.GetValueOrDefault(accountId, true);
    }

    public bool IsPartyClosed(string accountId)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return false;
        return _closedParty.GetValueOrDefault(accountId, false);
    }

    public string? GetPlayerLobbyId(string accountId)
    {
        if (string.IsNullOrWhiteSpace(accountId)) return null;
        if (_onlinePlayers.TryGetValue(accountId, out OnlinePlayerInfo? info))
            return info.LobbyId;
        return null;
    }

    // === Private Helpers ===

    private List<string> GetFriendAccountIds(string accountId)
    {
        var friends = new List<string>();

        foreach (FriendRelationship rel in _state.Friends)
        {
            if (string.Equals(rel.AccountId1, accountId, StringComparison.OrdinalIgnoreCase))
                friends.Add(rel.AccountId2);
            else if (string.Equals(rel.AccountId2, accountId, StringComparison.OrdinalIgnoreCase))
                friends.Add(rel.AccountId1);
        }

        return friends;
    }

    private bool TryGetPersistedFriendName(string accountId, string friendId, out string username, out int discriminator)
    {
        foreach (FriendRelationship rel in _state.Friends)
        {
            if (string.Equals(rel.AccountId1, accountId, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(rel.AccountId2, friendId, StringComparison.OrdinalIgnoreCase))
            {
                username = rel.Username2;
                discriminator = rel.Discriminator2;
                return !string.IsNullOrEmpty(username);
            }
            if (string.Equals(rel.AccountId2, accountId, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(rel.AccountId1, friendId, StringComparison.OrdinalIgnoreCase))
            {
                username = rel.Username1;
                discriminator = rel.Discriminator1;
                return !string.IsNullOrEmpty(username);
            }
        }
        username = "";
        discriminator = 0;
        return false;
    }

    private bool AreFriends(string accountId1, string accountId2)
    {
        return _state.Friends.Any(f =>
            (string.Equals(f.AccountId1, accountId1, StringComparison.OrdinalIgnoreCase) &&
             string.Equals(f.AccountId2, accountId2, StringComparison.OrdinalIgnoreCase)) ||
            (string.Equals(f.AccountId1, accountId2, StringComparison.OrdinalIgnoreCase) &&
             string.Equals(f.AccountId2, accountId1, StringComparison.OrdinalIgnoreCase)));
    }

    private int CountFriends(string accountId)
    {
        return _state.Friends.Count(f =>
            string.Equals(f.AccountId1, accountId, StringComparison.OrdinalIgnoreCase) ||
            string.Equals(f.AccountId2, accountId, StringComparison.OrdinalIgnoreCase));
    }

    private void PurgeExpiredInvites(List<PartyInvite> invites)
    {
        DateTimeOffset cutoff = DateTimeOffset.UtcNow.AddMinutes(-_options.PartyInviteExpiryMinutes);
        invites.RemoveAll(i => i.CreatedUtc < cutoff);
    }

    private void LoadState()
    {
        try
        {
            if (!File.Exists(_statePath))
            {
                _logger.LogInformation("Friends state file not found at {Path}. Starting fresh.", _statePath);
                return;
            }

            string json = File.ReadAllText(_statePath, Encoding.UTF8);
            FriendsStateDocument? loaded = JsonSerializer.Deserialize<FriendsStateDocument>(json, JsonContract.Options);
            if (loaded is not null)
            {
                _state = loaded;
                _logger.LogInformation(
                    "Loaded friends state: {FriendCount} relationships, {RequestCount} pending requests.",
                    _state.Friends.Count, _state.PendingRequests.Count);
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Could not load friends state from {Path}. Starting fresh.", _statePath);
            _state = new FriendsStateDocument();
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
            _logger.LogError(ex, "Failed to save friends state to {Path}.", _statePath);
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

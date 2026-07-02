using BapCustomServer;
using Xunit;

namespace BapCustomServer.Tests;

// F089 requests + mutual auto-accept, F090 list/remove, F091 presence + party invites, B13 regression.
public class FriendsServiceTests
{
    [Fact] // F089
    public void SendRequest_ThenAccept_CreatesFriendship()
    {
        var f = Svc.Friends(Svc.TempDir());
        Assert.True(f.SendRequest("a", "Alice", 1001, "b").Ok);
        Assert.Single(f.GetPendingRequests("b"));
        Assert.True(f.AcceptRequest("b", "a").Ok);
        Assert.Contains(f.GetFriends("a"), x => x.AccountId == "b");
        Assert.Contains(f.GetFriends("b"), x => x.AccountId == "a");
    }

    [Fact] // F089 mutual auto-accept
    public void SendRequest_Reverse_AutoAccepts()
    {
        var f = Svc.Friends(Svc.TempDir());
        f.SendRequest("a", "Alice", 1001, "b");
        var result = f.SendRequest("b", "Bob", 1002, "a"); // reverse => auto-accept
        Assert.True(result.Ok);
        Assert.Contains(f.GetFriends("a"), x => x.AccountId == "b");
        Assert.Empty(f.GetPendingRequests("a"));
    }

    [Fact] // F089
    public void SendRequest_RejectsSelfAndDuplicate()
    {
        var f = Svc.Friends(Svc.TempDir());
        Assert.False(f.SendRequest("a", "Alice", 1001, "a").Ok); // self
        f.SendRequest("a", "Alice", 1001, "b");
        Assert.False(f.SendRequest("a", "Alice", 1001, "b").Ok); // duplicate pending
    }

    [Fact] // F090
    public void RemoveFriend_BreaksBothDirections()
    {
        var f = Svc.Friends(Svc.TempDir());
        f.SendRequest("a", "Alice", 1001, "b");
        f.AcceptRequest("b", "a");
        Assert.True(f.RemoveFriend("a", "b").Ok);
        Assert.Empty(f.GetFriends("a"));
        Assert.Empty(f.GetFriends("b"));
        Assert.False(f.RemoveFriend("a", "b").Ok); // already gone
    }

    [Fact] // B13 regression: offline friend keeps a known username/discriminator
    public void GetFriends_OfflineFriend_ShowsPersistedName()
    {
        var f = Svc.Friends(Svc.TempDir());
        // Alice online sends, Bob (online) accepts; then both go offline.
        f.RegisterOnline("a", "Alice", 1001);
        f.RegisterOnline("b", "Bob", 2002);
        f.SendRequest("a", "Alice", 1001, "b");
        f.AcceptRequest("b", "a");
        f.RegisterOffline("a");
        f.RegisterOffline("b");
        var bobsFriends = f.GetFriends("b");
        var alice = Assert.Single(bobsFriends);
        Assert.Equal("Alice", alice.Username); // not blank
        Assert.Equal(1001, alice.Discriminator); // not 0
        Assert.False(alice.IsOnline);
    }

    [Fact] // F091
    public void PartyInvite_RequiresOnlineTarget()
    {
        var f = Svc.Friends(Svc.TempDir());
        // target offline => invite rejected
        Assert.False(f.SendPartyInvite("a", "Alice", "LOBBY1", "b").Ok);
        f.RegisterOnline("b", "Bob", 2002);
        Assert.True(f.SendPartyInvite("a", "Alice", "LOBBY1", "b").Ok);
        Assert.Single(f.GetPendingPartyInvites("b"));
    }

    [Fact] // F091 closed-party blocks invites
    public void PartyInvite_BlockedWhenPartyClosed()
    {
        var f = Svc.Friends(Svc.TempDir());
        f.RegisterOnline("b", "Bob", 2002);
        f.SetClosedParty("b", true);
        Assert.False(f.SendPartyInvite("a", "Alice", "LOBBY1", "b").Ok);
    }

    [Fact] // F089 friend cap enforced
    public void SendRequest_RejectsWhenFriendCapReached()
    {
        var f = Svc.Friends(Svc.TempDir(), maxFriends: 1);
        f.SendRequest("a", "Alice", 1, "b");
        f.AcceptRequest("b", "a"); // a now has 1 friend (cap)
        Assert.False(f.SendRequest("a", "Alice", 1, "c").Ok);
    }
}

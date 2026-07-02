using BapCustomServer;
using Xunit;

namespace BapCustomServer.Tests;

// F068 stale/empty match cleanup, F070 admin kick. Run against a real LobbyService with
// no active matches/clients (the reachable, no-spawn branches: empty registries).
public class LobbyCleanupTests
{
    [Fact] // F068 — cleanup with no matches removes nothing and does not throw
    public void CleanupStaleMatches_NoMatches_ReturnsZero()
    {
        var svc = Svc.Lobby(new CustomServerOptions());
        Assert.Equal(0, svc.CleanupStaleMatches());
        Assert.Equal(0, svc.GetActiveMatchCount());
    }

    [Fact] // F070 — kicking an unknown/blank account returns false (no live socket to close)
    public async Task KickAccount_Unknown_ReturnsFalse()
    {
        var svc = Svc.Lobby(new CustomServerOptions());
        Assert.False(await svc.KickAccountAsync("nobody", "test", CancellationToken.None));
        Assert.False(await svc.KickAccountAsync(null, "test", CancellationToken.None));
        Assert.False(await svc.KickAccountAsync("  ", "test", CancellationToken.None));
    }

    [Fact] // F068/F071 — counts start at zero on a fresh service
    public void FreshService_HasNoLobbiesOrMatches()
    {
        var svc = Svc.Lobby(new CustomServerOptions());
        Assert.Equal(0, svc.GetLobbyCount());
        Assert.Equal(0, svc.GetActiveMatchCount());
        Assert.Equal(0, svc.GetClientCount());
    }

    [Fact] // F071 — StopAllMatches on an empty service is a safe no-op
    public void StopAllMatches_Empty_DoesNotThrow()
    {
        var svc = Svc.Lobby(new CustomServerOptions());
        svc.StopAllMatches(); // must not throw
        Assert.Equal(0, svc.GetActiveMatchCount());
    }

    [Fact] // Match-slot leak — an abandoned match (player back in lobby) must release its slot so a
    // re-queue can start under MaxConcurrentMatches=1, instead of "server at capacity (1+0/1)".
    public void ReleaseAbandonedMatch_FreesSlotForRequeue()
    {
        var svc = Svc.Lobby(new CustomServerOptions { MaxConcurrentMatches = 1 });
        var session = new GameServerSession("leak-1", "127.0.0.1", 7777, 7778, 7779, null, 7850, 1, 1);
        CustomLobby lobby = svc.SeedActiveMatchForTest("MMLEAK01", "leak-1", session, "acct-1");
        Assert.Equal(1, svc.GetActiveMatchCount());

        svc.ReleaseAbandonedMatchForTest(lobby, "test re-queue");

        Assert.Equal(0, svc.GetActiveMatchCount()); // slot freed
        Assert.Null(lobby.ActiveGameId);            // not re-released on a second call
    }

    [Fact] // The release is idempotent: calling it again after the match is gone does nothing.
    public void ReleaseAbandonedMatch_Idempotent()
    {
        var svc = Svc.Lobby(new CustomServerOptions { MaxConcurrentMatches = 1 });
        var session = new GameServerSession("leak-2", "127.0.0.1", 7777, 7778, 7779, null, 7850, 1, 1);
        CustomLobby lobby = svc.SeedActiveMatchForTest("MMLEAK02", "leak-2", session, "acct-1");

        svc.ReleaseAbandonedMatchForTest(lobby, "first");
        svc.ReleaseAbandonedMatchForTest(lobby, "second"); // must not throw, no underflow

        Assert.Equal(0, svc.GetActiveMatchCount());
    }
}

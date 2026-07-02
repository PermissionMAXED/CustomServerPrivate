using BapCustomServer;
using Xunit;

namespace BapCustomServer.Tests;

// F098 join, F099 update char, F100 leave/reset, F101 timer, F102 readiness gate,
// F103 atomic take, F104 requeue (+B9 cap, +B10 fresh-joiner timer), F105 status, F106 clear/reset.
public class MatchmakingQueueServiceTests
{
    [Fact] // F098
    public void Join_AddsPlayer_DedupesSameAccount()
    {
        var q = Svc.Queue();
        var r1 = q.JoinQueue("a", "A", 1001, 1, 1000);
        Assert.True(r1.Ok);
        Assert.Equal(1, r1.QueuePosition);
        var r2 = q.JoinQueue("a", "A", 1001, 1, 1000); // already queued
        Assert.False(r2.Ok);
        Assert.Equal(1, q.GetQueueSize());
    }

    [Fact] // F099
    public void UpdateQueuedCharacter_ChangesEntry()
    {
        var q = Svc.Queue();
        q.JoinQueue("a", "A", 1001, 1, 1000);
        Assert.True(q.UpdateQueuedCharacter("a", 15));
        Assert.False(q.UpdateQueuedCharacter("nobody", 15));
        Assert.Equal(15, q.GetStatus().Players.Single().CharId);
    }

    [Fact] // F050 — ranked points supplied at JoinQueue are stored on the entry and carried through status + take
    public void JoinQueue_StoresRankedPoints_CarriedThroughStatusAndTake()
    {
        var q = Svc.Queue(timer: 0, minPlayers: 1);
        q.JoinQueue("a", "A", 1001, 1, points: 1337);
        Assert.Equal(1337, q.GetStatus().Players.Single().Points); // stored on the queued entry
        var taken = q.TakeReadyMatch();
        Assert.True(taken.ShouldStart);
        Assert.Equal(1337, taken.Players.Single().Points); // carried into the started match
    }

    [Fact] // F100
    public void Leave_RemovesPlayer_ResetsTimerWhenEmpty()
    {
        var q = Svc.Queue();
        q.JoinQueue("a", "A", 1001, 1, 1000);
        Assert.True(q.LeaveQueue("a"));
        Assert.False(q.LeaveQueue("a")); // already gone
        Assert.Equal(0, q.GetQueueSize());
        Assert.False(q.GetStatus().IsActive); // timer reset
    }

    [Fact] // F101 + F102: full timer until elapsed, then ready
    public void ReadinessGate_RequiresTimerElapsed()
    {
        var q = Svc.Queue(timer: 0, minPlayers: 1); // timer 0 => instantly ready once joined
        Assert.False(q.TakeReadyMatch().ShouldStart); // empty queue not ready
        q.JoinQueue("a", "A", 1001, 1, 1000);
        var taken = q.TakeReadyMatch();
        Assert.True(taken.ShouldStart);
        Assert.Single(taken.Players);
    }

    [Fact] // F102: min-players gate blocks start
    public void ReadinessGate_BlocksBelowMinPlayers()
    {
        var q = Svc.Queue(timer: 0, minPlayers: 3);
        q.JoinQueue("a", "A", 1001, 1, 1000);
        Assert.False(q.TakeReadyMatch().ShouldStart); // only 1 of 3
    }

    [Fact] // F103: take clears queue and resets timer
    public void TakeReadyMatch_ClearsQueue()
    {
        var q = Svc.Queue(timer: 0);
        q.JoinQueue("a", "A", 1001, 1, 1000);
        q.TakeReadyMatch();
        Assert.Equal(0, q.GetQueueSize());
    }

    [Fact] // F104 + B9 regression: failure cap drops a player instead of requeueing forever
    public void Requeue_DropsPlayerAfterFailureCap()
    {
        var q = Svc.Queue(timer: 30, maxFailures: 3);
        var entry = new QueueEntry { AccountId = "a", Username = "A", CharId = 1 };
        // Mimic the real take-then-requeue cycle: a failed start pulls players out
        // (TakeReadyMatch) and requeues them, bumping MatchStartFailures each round.
        for (int i = 0; i < 3; i++)
        {
            q.LeaveQueue("a"); // player was taken for the failed start attempt
            q.RequeuePlayers(new[] { entry });
        }
        // After hitting the failure cap the player is dropped instead of requeued forever.
        Assert.DoesNotContain(q.GetStatus().Players, p => p.AccountId == "a");
    }

    [Fact] // B10 regression: requeue must not shorten a fresh joiner's full timer
    public void Requeue_DoesNotClobberFreshJoinerTimer()
    {
        var q = Svc.Queue(timer: 30, retryDelay: 5);
        // A fresh joiner sets a full 30s timer.
        q.JoinQueue("fresh", "Fresh", 1001, 1, 1000);
        int beforeSecs = q.GetSecondsRemaining();
        // A previously-taken player is requeued (failed start) while the fresh joiner waits.
        q.RequeuePlayers(new[] { new QueueEntry { AccountId = "retry", Username = "R", CharId = 1 } });
        int afterSecs = q.GetSecondsRemaining();
        // The fresh joiner's countdown must not be slashed to the retry delay (~5s).
        Assert.True(afterSecs >= beforeSecs - 2, $"timer was clobbered: {beforeSecs} -> {afterSecs}");
    }

    [Fact] // Phase-3 regression: cancelling while the match is in-flight must suppress requeue
    public void LeaveDuringInFlightStart_PreventsFailureRequeue()
    {
        var q = Svc.Queue(timer: 0, maxFailures: 5);
        q.JoinQueue("a", "A", 1001, 1, 1000);
        var taken = q.TakeReadyMatch();
        Assert.True(taken.ShouldStart);
        Assert.True(q.LeaveQueue("a")); // player cancels while StartMatchmakingGameAsync is running

        q.RequeuePlayers(taken.Players, "failed matchmaking game start");

        Assert.Empty(q.GetStatus().Players);
    }

    [Fact] // Phase-3 regression: successful match start clears in-flight marker so player can queue later
    public void CompleteMatchStart_AllowsLaterJoin()
    {
        var q = Svc.Queue(timer: 0, maxFailures: 5);
        q.JoinQueue("a", "A", 1001, 1, 1000);
        var taken = q.TakeReadyMatch();
        q.CompleteMatchStart(taken.Players);

        var joinedAgain = q.JoinQueue("a", "A", 1001, 1, 1000);

        Assert.True(joinedAgain.Ok);
        Assert.Single(q.GetStatus().Players);
    }

    [Fact] // F105
    public void Status_ReportsCountAndActivity()
    {
        var q = Svc.Queue();
        var empty = q.GetStatus();
        Assert.Equal(0, empty.PlayerCount);
        Assert.False(empty.IsActive);
        q.JoinQueue("a", "A", 1001, 1, 1000);
        var active = q.GetStatus();
        Assert.Equal(1, active.PlayerCount);
        Assert.True(active.IsActive);
    }

    [Fact] // F106
    public void ClearQueue_EmptiesAndResets()
    {
        var q = Svc.Queue();
        q.JoinQueue("a", "A", 1001, 1, 1000);
        q.JoinQueue("b", "B", 1002, 1, 1000);
        q.ClearQueue();
        Assert.Equal(0, q.GetQueueSize());
        Assert.False(q.GetStatus().IsActive);
    }
}

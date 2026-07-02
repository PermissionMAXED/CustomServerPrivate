using BapCustomServer;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace BapCustomServer.Tests;

// F045 hosted matchmaking loop: MatchmakingHostedService runs a 1s PeriodicTimer that calls
// TakeReadyMatch and, when ready, StartMatchmakingGameAsync. With LaunchGameServers=false and no
// connected websockets, StartMatchmakingGameAsync returns true WITHOUT spawning a game process
// (the "ready queue but no live sockets" drop path), so the full loop wiring is testable here:
// tick -> TakeReadyMatch -> StartMatchmakingGameAsync(started) -> CompleteMatchStart -> queue drained.
public class MatchmakingHostedServiceTests
{
    [Fact] // F045 — a ready queue is taken by the loop and drained (started path: no requeue)
    public async Task HostedLoop_ReadyQueue_StartsAndDrainsWithoutRequeue()
    {
        var queue = Svc.Queue(timer: 0, minPlayers: 1); // timer 0 => instantly ready once a player joins
        var lobby = Svc.Lobby(new CustomServerOptions { LaunchGameServers = false });
        var svc = new MatchmakingHostedService(queue, lobby, NullLogger<MatchmakingHostedService>.Instance);

        queue.JoinQueue("a", "A", 1001, 1, 1000);
        Assert.Equal(1, queue.GetQueueSize());

        // BackgroundService.StartAsync invokes ExecuteAsync; the PeriodicTimer fires its first tick
        // after ~1s, so give it a generous margin under load (3× the timer interval).
        await svc.StartAsync(CancellationToken.None);
        await Task.Delay(3000);
        await svc.StopAsync(CancellationToken.None);

        // The loop took the ready player and, since no live socket exists, StartMatchmakingGameAsync
        // returned true => CompleteMatchStart cleared the in-flight marker; the player is NOT requeued.
        Assert.Equal(0, queue.GetQueueSize());
        Assert.Empty(queue.GetStatus().Players);
    }

    [Fact] // F045 — an empty queue makes the loop a no-op (no exceptions, nothing started)
    public async Task HostedLoop_EmptyQueue_NoOp()
    {
        var queue = Svc.Queue(timer: 0, minPlayers: 1);
        var lobby = Svc.Lobby(new CustomServerOptions { LaunchGameServers = false });
        var svc = new MatchmakingHostedService(queue, lobby, NullLogger<MatchmakingHostedService>.Instance);

        await svc.StartAsync(CancellationToken.None);
        await Task.Delay(1600);
        await svc.StopAsync(CancellationToken.None);

        Assert.Equal(0, queue.GetQueueSize());
    }
}

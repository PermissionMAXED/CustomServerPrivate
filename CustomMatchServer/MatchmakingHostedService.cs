namespace BapCustomServer;

public sealed class MatchmakingHostedService : BackgroundService
{
    private readonly MatchmakingQueueService _queueService;
    private readonly LobbyService _lobbyService;
    private readonly ILogger<MatchmakingHostedService> _logger;

    public MatchmakingHostedService(
        MatchmakingQueueService queueService,
        LobbyService lobbyService,
        ILogger<MatchmakingHostedService> logger)
    {
        _queueService = queueService;
        _lobbyService = lobbyService;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var timer = new PeriodicTimer(TimeSpan.FromSeconds(1));

        while (await timer.WaitForNextTickAsync(stoppingToken))
        {
            QueueEntry[] players = [];
            try
            {
                var ready = _queueService.TakeReadyMatch();
                if (!ready.ShouldStart)
                {
                    continue;
                }

                players = ready.Players;
                var startWatch = System.Diagnostics.Stopwatch.StartNew();
                _logger.LogInformation(
                    "Matchmaking start attempt begin. players={PlayerCount} accounts={Accounts}",
                    players.Length,
                    string.Join(",", players.Select(player => $"{player.AccountId}:char{player.CharId}:fail{player.MatchStartFailures}")));
                bool started = await _lobbyService.StartMatchmakingGameAsync(players, stoppingToken);
                _logger.LogInformation(
                    "Matchmaking start attempt finished. started={Started} elapsed={ElapsedSeconds:F1}s players={PlayerCount}",
                    started,
                    startWatch.Elapsed.TotalSeconds,
                    players.Length);
                if (!started)
                {
                    _queueService.RequeuePlayers(players, "failed matchmaking game start");
                }
                else
                {
                    _queueService.CompleteMatchStart(players);
                }
            }
            catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
            {
                break;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Automatic matchmaking start failed.");
                if (players.Length > 0)
                {
                    _queueService.RequeuePlayers(players, "matchmaking start exception");
                }
            }
        }
    }
}

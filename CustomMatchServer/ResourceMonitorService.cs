using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BapCustomServer;

/// <summary>
/// Periodically logs server resource usage: CPU%, working-set RAM, GC heap, plus
/// active match/connection counts. Default interval is 10 seconds.
/// </summary>
public sealed class ResourceMonitorService : BackgroundService
{
    private readonly ILogger<ResourceMonitorService> _logger;
    private readonly LobbyService _lobbyService;
    private readonly MatchmakingQueueService _queue;

    private TimeSpan _lastCpuTime;
    private DateTime _lastSampleAt;

    public ResourceMonitorService(
        ILogger<ResourceMonitorService> logger,
        LobbyService lobbyService,
        MatchmakingQueueService queue)
    {
        _logger = logger;
        _lobbyService = lobbyService;
        _queue = queue;
        _lastCpuTime = Process.GetCurrentProcess().TotalProcessorTime;
        _lastSampleAt = DateTime.UtcNow;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Wait a few seconds before first log so the server has fully started up.
        try { await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken); } catch { return; }

        var interval = TimeSpan.FromSeconds(10);
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                LogSample();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "ResourceMonitor sample failed.");
            }

            try { await Task.Delay(interval, stoppingToken); }
            catch (OperationCanceledException) { return; }
        }
    }

    private void LogSample()
    {
        // Periodic stale-match cleanup: removes matches whose dedicated server process has exited.
        try
        {
            int removed = _lobbyService.CleanupStaleMatches();
            if (removed > 0)
            {
                _logger.LogInformation("[Resource] Cleaned {Count} stale match(es).", removed);
            }
        }
        catch { }

        var process = Process.GetCurrentProcess();
        var now = DateTime.UtcNow;

        TimeSpan cpu = process.TotalProcessorTime;
        TimeSpan cpuDelta = cpu - _lastCpuTime;
        TimeSpan wallDelta = now - _lastSampleAt;
        _lastCpuTime = cpu;
        _lastSampleAt = now;

        double cpuPercent = 0;
        if (wallDelta.TotalMilliseconds > 0)
        {
            cpuPercent = cpuDelta.TotalMilliseconds / wallDelta.TotalMilliseconds * 100.0 / Math.Max(1, Environment.ProcessorCount);
        }

        long workingSetMb = process.WorkingSet64 / 1024 / 1024;
        long privateMb = process.PrivateMemorySize64 / 1024 / 1024;
        long gcHeapMb = GC.GetTotalMemory(false) / 1024 / 1024;
        int threads = process.Threads.Count;
        int handles = process.HandleCount;

        int activeLobbies = _lobbyService.GetLobbyCount();
        int activeMatches = _lobbyService.GetActiveMatchCount();
        int connections = _lobbyService.GetClientCount();
        int queueSize = _queue.GetQueueSize();

        _logger.LogInformation(
            "[Resource] cpu={Cpu:F1}% rss={Rss}MB priv={Priv}MB gc={Gc}MB threads={Th} handles={Hd} | lobbies={Lobbies} matches={Matches} conns={Conns} queue={Queue}",
            cpuPercent, workingSetMb, privateMb, gcHeapMb, threads, handles,
            activeLobbies, activeMatches, connections, queueSize);

        // Also log bapbap.exe instances (game client + dedicated game servers)
        try
        {
            var bapbapProcs = Process.GetProcessesByName("bapbap");
            if (bapbapProcs.Length > 0)
            {
                var entries = bapbapProcs.Take(5).Select(p =>
                {
                    try
                    {
                        long rss = p.WorkingSet64 / 1024 / 1024;
                        return $"PID={p.Id} rss={rss}MB threads={p.Threads.Count}";
                    }
                    catch { return $"PID={p.Id} (?)"; }
                }).ToArray();
                _logger.LogInformation("[Resource] bapbap.exe: {Procs}", string.Join(" | ", entries));
            }
        }
        catch { }
    }
}

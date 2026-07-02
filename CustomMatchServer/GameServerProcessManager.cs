using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Net.Http.Json;
using System.Net.Sockets;

namespace BapCustomServer;

public sealed class GameServerProcessManager
{
    public const string HttpClientName = "game-server";

    private readonly CustomServerOptions _options;
    private readonly IWebHostEnvironment _environment;
    private readonly PortAllocator _ports;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly GameServerPrewarmService _prewarm;
    private readonly ILogger<GameServerProcessManager> _logger;

    public GameServerProcessManager(
        IOptions<CustomServerOptions> options,
        IWebHostEnvironment environment,
        PortAllocator ports,
        IHttpClientFactory httpClientFactory,
        GameServerPrewarmService prewarm,
        ILogger<GameServerProcessManager> logger)
    {
        _options = options.Value;
        _environment = environment;
        _ports = ports;
        _httpClientFactory = httpClientFactory;
        _prewarm = prewarm;
        _logger = logger;
    }

    public async Task<GameServerSession> StartMatchServerAsync(MatchBootstrap bootstrap, CancellationToken cancellationToken)
    {
        if (!_options.LaunchGameServers)
        {
            var external = _options.ExternalGameServer;
            return new GameServerSession(
                bootstrap.GameId,
                external.Hostname,
                external.WsPort,
                external.KcpPort,
                external.TcpPort,
                null,
                0,
                bootstrap.GameData.MapId,
                bootstrap.GameData.UnityGameModeId);
        }

        TimeSpan prewarmWait = TimeSpan.FromSeconds(Math.Clamp(_options.GameServerPrewarmMatchWaitSeconds, 0, 120));
        if (prewarmWait > TimeSpan.Zero)
        {
            GameServerPrewarmStatus beforePrewarm = _prewarm.GetStatus();
            if (beforePrewarm.State is "starting" or "running")
            {
                _logger.LogInformation(
                    "Waiting up to {PrewarmWaitSeconds}s for startup prewarm before starting real match {GameId}. state={PrewarmState} ready={PrewarmReady} log={PrewarmLog}",
                    prewarmWait.TotalSeconds,
                    bootstrap.GameId,
                    beforePrewarm.State,
                    beforePrewarm.Ready,
                    beforePrewarm.LogFile ?? "<none>");
                bool prewarmReady = await _prewarm.WaitForStartupPrewarmAsync(prewarmWait, cancellationToken);
                GameServerPrewarmStatus afterPrewarm = _prewarm.GetStatus();
                _logger.LogInformation(
                    "Startup prewarm wait finished for {GameId}. ready={PrewarmReady} state={PrewarmState} source={PrewarmSource} log={PrewarmLog}",
                    bootstrap.GameId,
                    prewarmReady,
                    afterPrewarm.State,
                    afterPrewarm.ReadySource,
                    afterPrewarm.LogFile ?? "<none>");
            }
        }

        int maxAttempts = EffectiveGameServerStartAttempts(_options);
        int retryDelaySeconds = Math.Clamp(_options.GameServerStartRetryDelaySeconds, 0, 30);

        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                return await StartMatchServerAttemptAsync(bootstrap, attempt, maxAttempts, cancellationToken);
            }
            catch (Exception ex) when (attempt < maxAttempts &&
                                       ex is not OperationCanceledException &&
                                       !cancellationToken.IsCancellationRequested)
            {
                _logger.LogWarning(
                    ex,
                    "Game server {GameId} start attempt {Attempt}/{MaxAttempts} failed; retrying after {RetryDelaySeconds}s.",
                    bootstrap.GameId,
                    attempt,
                    maxAttempts,
                    retryDelaySeconds);

                if (retryDelaySeconds > 0)
                {
                    await Task.Delay(TimeSpan.FromSeconds(retryDelaySeconds), cancellationToken);
                }
            }
        }

        throw new InvalidOperationException($"Game server {bootstrap.GameId} did not start after {maxAttempts} attempt(s).");
    }

    private async Task<GameServerSession> StartMatchServerAttemptAsync(
        MatchBootstrap bootstrap,
        int attempt,
        int maxAttempts,
        CancellationToken cancellationToken)
    {
        int httpPort = 0;
        int wsPort = 0;
        int kcpPort = 0;
        int tcpPort = 0;
        Process? process = null;
        bool releaseStartupPorts = true;
        try
        {
            httpPort = _ports.ReserveFrom(_options.BaseHttpPort, _options.PortSearchRange);
            wsPort = _ports.ReserveFrom(_options.BaseWsPort, _options.PortSearchRange);
            kcpPort = _ports.ReserveUdpFrom(_options.BaseKcpPort, _options.PortSearchRange);
            tcpPort = _ports.ReserveFrom(_options.BaseTcpPort, _options.PortSearchRange);

            string workingDirectory = ResolvePath(_options.GameWorkingDirectory);
            string executable = ResolvePath(_options.GameExecutablePath);
            string logDirectory = ResolvePath(_options.GameLogDirectory);
            Directory.CreateDirectory(logDirectory);

            string logFileName = BuildAttemptLogFileName(bootstrap.GameId, attempt, maxAttempts);
            string logFile = Path.Combine(logDirectory, logFileName);
            string gameArguments = SubstituteLaunchTokens(
                _options.HeadlessArguments, bootstrap.GameId, httpPort, wsPort, kcpPort, tcpPort, logFile);

            if (!string.IsNullOrWhiteSpace(_options.AdditionalGameArguments))
            {
                gameArguments = $"{gameArguments} {_options.AdditionalGameArguments}";
            }

            gameArguments = AppendLocalCallbackArguments(gameArguments);

            string processFileName = executable;
            string processArguments = gameArguments;
            if (!string.IsNullOrWhiteSpace(_options.GameLauncherPath))
            {
                processFileName = ResolveExecutableOrCommand(_options.GameLauncherPath);
                processArguments = SubstituteLaunchTokens(
                    _options.GameLauncherArguments, bootstrap.GameId, httpPort, wsPort, kcpPort, tcpPort, logFile,
                    gameExecutable: executable, gameArguments: gameArguments);
            }

            var startInfo = new ProcessStartInfo
            {
                FileName = processFileName,
                WorkingDirectory = workingDirectory,
                Arguments = processArguments,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            // Isolate WINEPREFIX for the match attempt to prevent lock and wineserver contention.
            string isolatedPrefix = Path.Combine(workingDirectory, "wineprefixes", $"wineprefix_{bootstrap.GameId}_attempt{attempt}");
            startInfo.Environment["BAPCUSTOM_WINEPREFIX"] = isolatedPrefix;

            process = Process.Start(startInfo) ?? throw new InvalidOperationException("Process.Start returned null.");

            _logger.LogInformation(
                "Started game server {GameId} attempt {Attempt}/{MaxAttempts} as PID {Pid}. executable={Executable} ws={WsPort} kcp={KcpPort} tcp={TcpPort} http={HttpPort}",
                bootstrap.GameId,
                attempt,
                maxAttempts,
                process.Id,
                processFileName,
                wsPort,
                kcpPort,
                tcpPort,
                httpPort);

            _logger.LogInformation(
                "Game server launch details {GameId} attempt {Attempt}/{MaxAttempts}: cwd={WorkingDirectory} args={Arguments} logFile={LogFile} wrapperLog={WrapperLog} containsNoGraphics={ContainsNoGraphics}",
                bootstrap.GameId,
                attempt,
                maxAttempts,
                workingDirectory,
                processArguments,
                logFile,
                Path.ChangeExtension(logFile, ".wrapper.log"),
                processArguments.Contains("-nographics", StringComparison.OrdinalIgnoreCase));

            var session = new GameServerSession(
                bootstrap.GameId,
                _options.PublicGameHost,
                wsPort,
                kcpPort,
                tcpPort,
                process,
                httpPort,
                bootstrap.GameData.MapId,
                bootstrap.GameData.UnityGameModeId,
                logFile);

            bool bootstrapped = await TryBootstrapServerAsync(session, bootstrap, cancellationToken);
            if (!bootstrapped && _options.RequireGameServerBootstrap)
            {
                TryKillAndWait(process);
                TryDisposeProcess(process);
                TryCleanupWinePrefixes(bootstrap.GameId);
                _ports.ReleaseImmediately(httpPort, wsPort, kcpPort, tcpPort);
                releaseStartupPorts = false;
                throw new InvalidOperationException($"Game server {bootstrap.GameId} did not accept match bootstrap data on attempt {attempt}/{maxAttempts}.");
            }

            releaseStartupPorts = false;
            return session;
        }
        catch
        {
            if (releaseStartupPorts)
            {
                if (process is not null)
                {
                    TryKillAndWait(process);
                    TryDisposeProcess(process);
                }

                TryCleanupWinePrefixes(bootstrap.GameId);
                _ports.ReleaseImmediately(httpPort, wsPort, kcpPort, tcpPort);
            }

            throw;
        }
    }

    private static void TryDisposeProcess(Process process)
    {
        try
        {
            process.Dispose();
        }
        catch
        {
            // Handle may already be released; nothing actionable.
        }
    }

    public void StopMatchServer(GameServerSession session)
    {
        if (session.Process is { } process)
        {
            TryKillAndWait(process);
            try
            {
                process.Dispose();
            }
            catch
            {
                // Best effort cleanup; the process has already been asked to stop.
            }
        }

        TryCleanupWinePrefixes(session.GameId);
        _ports.Release(session.HttpPort, session.WsPort, session.KcpPort, session.TcpPort);
    }

    private async Task<bool> TryBootstrapServerAsync(GameServerSession session, MatchBootstrap bootstrap, CancellationToken cancellationToken)
    {
        using HttpClient client = _httpClientFactory.CreateClient(HttpClientName);
        Uri baseUri = new($"http://127.0.0.1:{session.HttpPort}");
        DateTimeOffset startedAt = DateTimeOffset.UtcNow;
        DateTimeOffset deadline = startedAt.AddSeconds(_options.GameServerReadyTimeoutSeconds);
        DateTimeOffset nextProgressLog = startedAt.AddSeconds(Math.Max(5, _options.GameServerBootstrapProgressLogSeconds));
        string? lastBootstrapError = null;
        int attempts = 0;

        _logger.LogInformation(
            "Waiting for game server bootstrap {GameId}. baseUri={BaseUri} timeout={TimeoutSeconds}s poll={PollMillis}ms resetPoll={ResetPollMillis}ms httpTimeout={HttpTimeoutSeconds}s logFile={LogFile} wrapperLog={WrapperLog}",
            session.GameId,
            baseUri,
            _options.GameServerReadyTimeoutSeconds,
            _options.GameServerReadyPollMillis,
            _options.GameServerBootstrapResetPollMillis,
            _options.GameServerBootstrapHttpTimeoutSeconds,
            session.LogFile,
            Path.ChangeExtension(session.LogFile, ".wrapper.log"));

        while (DateTimeOffset.UtcNow < deadline && !cancellationToken.IsCancellationRequested)
        {
            if (session.Process is { } process && process.HasExited)
            {
                _logger.LogWarning(
                    "Game server {GameId} exited before accepting bootstrap data. exitCode={ExitCode} attempts={Attempts} diagnostics={Diagnostics}",
                    session.GameId,
                    SafeExitCode(process),
                    attempts,
                    BuildStartupDiagnostics(session.LogFile, _options.GameServerDiagnosticTailLines));
                return false;
            }

                attempts++;
            try
            {
                await PostJsonAsync(client, baseUri, _options.BootstrapConnectPath, bootstrap.GameData, cancellationToken);
                _logger.LogInformation(
                    "Game server {GameId} accepted /setup-game HTTP after {ElapsedSeconds:F1}s and {Attempts} attempt(s). Waiting for managed setupGameApplied status timeout={ManagedBootstrapTimeoutSeconds}s.",
                    session.GameId,
                    (DateTimeOffset.UtcNow - startedAt).TotalSeconds,
                    attempts,
                    EffectiveManagedBootstrapStatusTimeoutSeconds());

                if (!await WaitForManagedBootstrapStatusAsync(
                    session,
                    client,
                    baseUri,
                    status => status.SetupGameApplied,
                    "setupGameApplied",
                    allowListenerOnlyEarlyStall: true,
                    replayOnListenerOnlyAsync: retryCancellationToken =>
                        PostJsonAsync(client, baseUri, _options.BootstrapConnectPath, bootstrap.GameData, retryCancellationToken),
                    replayDescription: _options.BootstrapConnectPath,
                    bootstrapDeadline: deadline,
                    cancellationToken: cancellationToken))
                {
                    _logger.LogWarning(
                        "Game server {GameId} accepted /setup-game, but managed setupGameApplied+networkStarted status did not become true before timeout. diagnostics={Diagnostics}",
                        session.GameId,
                        BuildStartupDiagnostics(session.LogFile, _options.GameServerDiagnosticTailLines));
                    return false;
                }

                await PostJsonAsync(client, baseUri, _options.BootstrapAddTeamsPath, bootstrap.TeamData, cancellationToken);
                if (!await WaitForManagedBootstrapStatusAsync(
                    session,
                    client,
                    baseUri,
                    status => status.AddTeamsApplied,
                    "addTeamsApplied",
                    allowListenerOnlyEarlyStall: false,
                    replayOnListenerOnlyAsync: null,
                    replayDescription: null,
                    bootstrapDeadline: deadline,
                    cancellationToken: cancellationToken))
                {
                    _logger.LogWarning(
                        "Game server {GameId} accepted /add-teams, but managed addTeamsApplied+networkStarted status did not become true before timeout. diagnostics={Diagnostics}",
                        session.GameId,
                        BuildStartupDiagnostics(session.LogFile, _options.GameServerDiagnosticTailLines));
                    return false;
                }

                await PostJsonAsync(client, baseUri, _options.BootstrapQueueMatchedPath, bootstrap.QueueMatchedData, cancellationToken);
                if (!await WaitForManagedBootstrapStatusAsync(
                    session,
                    client,
                    baseUri,
                    status => status.QueueMatchedApplied,
                    "queueMatchedApplied",
                    allowListenerOnlyEarlyStall: false,
                    replayOnListenerOnlyAsync: null,
                    replayDescription: null,
                    bootstrapDeadline: deadline,
                    cancellationToken: cancellationToken))
                {
                    _logger.LogWarning(
                        "Game server {GameId} accepted /queue-matched, but managed queueMatchedApplied+networkStarted status did not become true before timeout. diagnostics={Diagnostics}",
                        session.GameId,
                        BuildStartupDiagnostics(session.LogFile, _options.GameServerDiagnosticTailLines));
                    return false;
                }

                _logger.LogInformation(
                    "Game server {GameId} managed bootstrap fully applied before GAME_STARTED. ws={WsPort} kcp={KcpPort} tcp={TcpPort}",
                    session.GameId,
                    session.WsPort,
                    session.KcpPort,
                    session.TcpPort);

                if (_options.RequireGameServerKcpPort && !await WaitForUdpPortAsync(session, session.KcpPort, deadline, cancellationToken))
                {
                    _logger.LogWarning(
                        "Game server {GameId} accepted bootstrap, but KCP UDP port {KcpPort} did not become visible before timeout. diagnostics={Diagnostics}",
                        session.GameId,
                        session.KcpPort,
                        BuildStartupDiagnostics(session.LogFile, _options.GameServerDiagnosticTailLines));
                    return false;
                }

                if (!_options.RequireGameServerKcpPort)
                {
                    _logger.LogInformation(
                        "Game server {GameId} accepted bootstrap HTTP; KCP UDP {KcpPort} listener check is diagnostic-only.",
                        session.GameId,
                        session.KcpPort);
                }

                _logger.LogInformation("Bootstrapped game server {GameId}.", bootstrap.GameId);
                return true;
            }
            catch (Exception ex) when (ex is HttpRequestException or TaskCanceledException)
            {
                lastBootstrapError = ex.GetBaseException().Message;
                DateTimeOffset now = DateTimeOffset.UtcNow;
                if (!IsBootstrapWarmingUpResponse(lastBootstrapError) &&
                    TryDetectStartupStall(session, startedAt, now, out string stallReason))
                {
                    _logger.LogWarning(
                        "Game server {GameId} startup appears stalled before bootstrap. elapsed={ElapsedSeconds:F1}s attempts={Attempts} lastError={LastError} stall={StallReason} diagnostics={Diagnostics}",
                        session.GameId,
                        (now - startedAt).TotalSeconds,
                        attempts,
                        lastBootstrapError,
                        stallReason,
                        BuildStartupDiagnostics(session.LogFile, _options.GameServerDiagnosticTailLines));
                    return false;
                }

                if (now >= nextProgressLog)
                {
                    _logger.LogInformation(
                        "Still waiting for game server bootstrap {GameId}. elapsed={ElapsedSeconds:F1}s remaining={RemainingSeconds:F1}s attempts={Attempts} lastError={LastError} logStatus={LogStatus}",
                        session.GameId,
                        (now - startedAt).TotalSeconds,
                        Math.Max(0, (deadline - now).TotalSeconds),
                        attempts,
                        lastBootstrapError,
                        DescribeLogFiles(session.LogFile));
                    nextProgressLog = now.AddSeconds(Math.Max(5, _options.GameServerBootstrapProgressLogSeconds));
                }

                await Task.Delay(GetBootstrapRetryDelayMillis(lastBootstrapError), cancellationToken);
            }
        }

        _logger.LogWarning(
            "Game server {GameId} did not accept bootstrap data before timeout. attempts={Attempts} elapsed={ElapsedSeconds:F1}s lastError={LastError} diagnostics={Diagnostics}",
            bootstrap.GameId,
            attempts,
            (DateTimeOffset.UtcNow - startedAt).TotalSeconds,
            lastBootstrapError ?? "<none>",
            BuildStartupDiagnostics(session.LogFile, _options.GameServerDiagnosticTailLines));
        return false;
    }

    private int GetBootstrapRetryDelayMillis(string? lastError)
    {
        int basePollMillis = Math.Clamp(_options.GameServerReadyPollMillis, 100, 10_000);
        if (!LooksLikeConnectedButBusyBootstrap(lastError))
        {
            return basePollMillis;
        }

        return Math.Max(
            basePollMillis,
            Math.Clamp(_options.GameServerBootstrapResetPollMillis, basePollMillis, 10_000));
    }

    private static bool LooksLikeConnectedButBusyBootstrap(string? lastError)
    {
        if (string.IsNullOrWhiteSpace(lastError))
        {
            return false;
        }

        return IsBootstrapWarmingUpResponse(lastError)
            || lastError.Contains("reset", StringComparison.OrdinalIgnoreCase)
            || lastError.Contains("timed out", StringComparison.OrdinalIgnoreCase)
            || lastError.Contains("timeout", StringComparison.OrdinalIgnoreCase)
            || lastError.Contains("canceled", StringComparison.OrdinalIgnoreCase);
    }

    private static bool IsBootstrapWarmingUpResponse(string? lastError)
    {
        if (string.IsNullOrWhiteSpace(lastError))
        {
            return false;
        }

        return lastError.Contains("503", StringComparison.OrdinalIgnoreCase)
            || lastError.Contains("Service Unavailable", StringComparison.OrdinalIgnoreCase)
            || lastError.Contains("warmingUp", StringComparison.OrdinalIgnoreCase)
            || lastError.Contains("warming up", StringComparison.OrdinalIgnoreCase);
    }

    private async Task<bool> WaitForManagedBootstrapStatusAsync(
        GameServerSession session,
        HttpClient client,
        Uri baseUri,
        Func<ManagedBootstrapStatus, bool> isReady,
        string label,
        bool allowListenerOnlyEarlyStall,
        Func<CancellationToken, Task>? replayOnListenerOnlyAsync,
        string? replayDescription,
        DateTimeOffset bootstrapDeadline,
        CancellationToken cancellationToken)
    {
        DateTimeOffset now = DateTimeOffset.UtcNow;
        DateTimeOffset waitStartedAt = now;
        int configuredTimeout = EffectiveManagedBootstrapStatusTimeoutSeconds();
        DateTimeOffset deadline = configuredTimeout > 0
            ? now.AddSeconds(Math.Max(3, configuredTimeout))
            : bootstrapDeadline;
        DateTimeOffset nextProgressLog = now.AddSeconds(Math.Max(5, _options.GameServerBootstrapProgressLogSeconds));
        string? lastStatus = null;
        string? lastError = null;
        double lastRealtime = 0;
        DateTimeOffset nextListenerOnlyReplay = waitStartedAt.AddSeconds(6);
        int listenerOnlyReplayCount = 0;
        const int maxListenerOnlyReplays = 4;

        if (deadline > bootstrapDeadline)
        {
            deadline = bootstrapDeadline;
        }

        while (DateTimeOffset.UtcNow < deadline && !cancellationToken.IsCancellationRequested)
        {
            if (HasProcessExited(session, label))
            {
                return false;
            }

            try
            {
                ManagedBootstrapStatus? status = await client.GetFromJsonAsync<ManagedBootstrapStatus>(
                    new Uri(baseUri, "/status"),
                    cancellationToken);

                lastStatus = status?.LastStatus;
                lastRealtime = status?.Realtime ?? lastRealtime;
                lastError = null;
                if (status != null && status.NetworkStarted && isReady(status))
                {
                    _logger.LogInformation(
                        "Game server managed bootstrap status ready. label={Label} networkStarted={NetworkStarted} setup={SetupApplied} addTeams={AddTeamsApplied} queueMatched={QueueMatchedApplied} lastStatus={LastStatus}",
                        label,
                        status.NetworkStarted,
                        status.SetupGameApplied,
                        status.AddTeamsApplied,
                        status.QueueMatchedApplied,
                        status.LastStatus ?? "<none>");
                    return true;
                }

                if (allowListenerOnlyEarlyStall && IsManagedBootstrapListenerOnly(status))
                {
                    DateTimeOffset listenerNow = DateTimeOffset.UtcNow;
                    if (replayOnListenerOnlyAsync != null &&
                        listenerOnlyReplayCount < maxListenerOnlyReplays &&
                        listenerNow >= nextListenerOnlyReplay)
                    {
                        listenerOnlyReplayCount++;
                        try
                        {
                            await replayOnListenerOnlyAsync(cancellationToken);
                            lastError = null;
                            _logger.LogInformation(
                                "Managed bootstrap status {Label} is listener-only; replayed {ReplayDescription} ({ReplayCount}/{MaxReplayCount}) after {ElapsedSeconds:F1}s. realtime={RealtimeSeconds:F1}s lastStatus={LastStatus}",
                                label,
                                replayDescription ?? "bootstrap payload",
                                listenerOnlyReplayCount,
                                maxListenerOnlyReplays,
                                (listenerNow - waitStartedAt).TotalSeconds,
                                status?.Realtime ?? 0,
                                status?.LastStatus ?? "<none>");
                        }
                        catch (Exception ex) when (ex is HttpRequestException or TaskCanceledException)
                        {
                            lastError = ex.GetBaseException().Message;
                            _logger.LogInformation(
                                "Managed bootstrap status {Label} is listener-only; replay of {ReplayDescription} failed after {ElapsedSeconds:F1}s: {LastError}",
                                label,
                                replayDescription ?? "bootstrap payload",
                                (listenerNow - waitStartedAt).TotalSeconds,
                                lastError);
                        }

                        nextListenerOnlyReplay = listenerNow.AddSeconds(10);
                    }

                    if (HasListenerOnlyWaitExpired(waitStartedAt, listenerNow))
                    {
                        _logger.LogWarning(
                            "Managed bootstrap status {Label} is still listener-only after {ElapsedSeconds:F1}s; treating this game-server attempt as cold/stale so the next attempt can use the warmed Wine/Unity cache. timeout={ListenerOnlyTimeoutSeconds}s replayed={ReplayCount} realtime={RealtimeSeconds:F1}s lastStatus={LastStatus}",
                            label,
                            (listenerNow - waitStartedAt).TotalSeconds,
                            EffectiveManagedBootstrapListenerOnlyTimeoutSeconds(),
                            listenerOnlyReplayCount,
                            status?.Realtime ?? 0,
                            status?.LastStatus ?? "<none>");
                        return false;
                    }
                }
            }
            catch (Exception ex) when (ex is HttpRequestException or TaskCanceledException or System.Text.Json.JsonException)
            {
                lastError = ex.GetBaseException().Message;
            }

            now = DateTimeOffset.UtcNow;
            if (now >= nextProgressLog)
            {
                _logger.LogInformation(
                    "Still waiting for managed bootstrap status {Label}. remaining={RemainingSeconds:F1}s realtime={RealtimeSeconds:F1}s lastStatus={LastStatus} lastError={LastError}",
                    label,
                    Math.Max(0, (deadline - now).TotalSeconds),
                    lastRealtime,
                    lastStatus ?? "<none>",
                    lastError ?? "<none>");
                nextProgressLog = now.AddSeconds(Math.Max(5, _options.GameServerBootstrapProgressLogSeconds));
            }

            await Task.Delay(_options.GameServerReadyPollMillis, cancellationToken);
        }

        return false;
    }

    private bool HasListenerOnlyWaitExpired(DateTimeOffset waitStartedAt, DateTimeOffset now)
    {
        int timeoutSeconds = EffectiveManagedBootstrapListenerOnlyTimeoutSeconds();
        return timeoutSeconds > 0 && (now - waitStartedAt).TotalSeconds >= timeoutSeconds;
    }

    private int EffectiveManagedBootstrapListenerOnlyTimeoutSeconds()
    {
        return EffectiveManagedBootstrapListenerOnlyTimeoutSeconds(_options);
    }

    public static int EffectiveManagedBootstrapListenerOnlyTimeoutSeconds(CustomServerOptions options)
    {
        int configured = options.GameServerManagedBootstrapListenerOnlyTimeoutSeconds;
        if (configured <= 0)
        {
            return 0;
        }

        return Math.Clamp(configured, 1, 120);
    }

    private static bool IsManagedBootstrapListenerOnly(ManagedBootstrapStatus? status)
    {
        if (status == null)
        {
            return false;
        }

        return IsManagedBootstrapListenerOnly(status.SetupGameApplied, status.LastStatus);
    }

    // F033 — listener-only detection: the game's bootstrap HTTP listener is up but /setup-game hasn't
    // been applied yet (Unity still warming). Pure overload reading only the two fields the predicate
    // needs, so the "replay the setup POST / treat as cold-stale" gate is unit-testable without the
    // private ManagedBootstrapStatus type.
    internal static bool IsManagedBootstrapListenerOnly(bool setupGameApplied, string? lastStatus)
    {
        if (setupGameApplied)
        {
            return false;
        }

        return (lastStatus ?? "").Contains("Managed match bootstrap listener is active", StringComparison.OrdinalIgnoreCase);
    }

    private int EffectiveManagedBootstrapStatusTimeoutSeconds()
    {
        if (_options.GameServerManagedBootstrapStatusTimeoutSeconds > 0)
        {
            return _options.GameServerManagedBootstrapStatusTimeoutSeconds;
        }

        return _options.GameServerTcpPortReadyTimeoutSeconds;
    }

    public static int EffectiveGameServerStartAttempts(CustomServerOptions options)
    {
        return Math.Clamp(options.GameServerStartAttempts <= 0 ? 1 : options.GameServerStartAttempts, 1, 5);
    }

    public static int EffectiveNoisyStartupStallGraceSeconds(CustomServerOptions options)
    {
        return Math.Clamp(Math.Max(0, options.GameServerStartupStallGraceSeconds), 0, 300);
    }

    public static int EffectiveNoisyStartupStallSeconds(CustomServerOptions options)
    {
        int configured = Math.Max(0, options.GameServerStartupStallSeconds);
        return configured == 0 ? 0 : Math.Clamp(configured, 1, 300);
    }

    public static int EffectiveWrapperOnlyStartupStallGraceSeconds(CustomServerOptions options)
    {
        int configured = options.GameServerWrapperOnlyStartupStallGraceSeconds;
        return Math.Clamp(Math.Max(0, configured > 0 ? configured : options.GameServerStartupStallGraceSeconds), 0, 300);
    }

    public static int EffectiveWrapperOnlyStartupStallSeconds(CustomServerOptions options)
    {
        int configured = Math.Max(0, options.GameServerWrapperOnlyStartupStallSeconds > 0
            ? options.GameServerWrapperOnlyStartupStallSeconds
            : options.GameServerStartupStallSeconds);
        return configured == 0 ? 0 : Math.Clamp(configured, 1, 300);
    }

    private static int? SafeExitCode(Process process)
    {
        try
        {
            return process.ExitCode;
        }
        catch
        {
            return null;
        }
    }

    private bool HasProcessExited(GameServerSession session, string waitLabel)
    {
        if (session.Process is not { } process || !process.HasExited)
        {
            return false;
        }

        _logger.LogWarning(
            "Game server {GameId} exited during {WaitLabel} wait. exitCode={ExitCode} diagnostics={Diagnostics}",
            session.GameId,
            waitLabel,
            SafeExitCode(process),
            BuildStartupDiagnostics(session.LogFile, _options.GameServerDiagnosticTailLines));
        return true;
    }

    private void TryKillAndWait(Process process)
    {
        TryKill(process);
        int waitMillis = Math.Clamp(_options.GameServerStopWaitMillis, 0, 30_000);
        if (waitMillis <= 0)
        {
            return;
        }

        try
        {
            if (!process.HasExited && !process.WaitForExit(waitMillis))
            {
                _logger.LogWarning(
                    "Game server process {Pid} did not exit within {WaitMillis}ms after kill; ports will be released but the next fixed-port start may need retry.",
                    process.Id,
                    waitMillis);
            }
        }
        catch (Exception ex)
        {
            _logger.LogDebug(
                ex,
                "Ignoring process wait failure after game-server kill. pid={Pid}",
                SafeProcessId(process));
        }
    }

    private static int? SafeProcessId(Process process)
    {
        try
        {
            return process.Id;
        }
        catch
        {
            return null;
        }
    }

    private static string ReadLogTail(string? path, int maxLines)
    {
        if (string.IsNullOrWhiteSpace(path) || maxLines <= 0)
        {
            return "<no log path>";
        }

        try
        {
            if (!File.Exists(path))
            {
                string wrapperLog = Path.ChangeExtension(path, ".wrapper.log");
                return File.Exists(wrapperLog)
                    ? string.Join('\n', File.ReadLines(wrapperLog).TakeLast(maxLines))
                    : $"<log not found: {path}>";
            }

            return string.Join('\n', File.ReadLines(path).TakeLast(maxLines));
        }
        catch (Exception ex)
        {
            return $"<could not read log: {ex.GetBaseException().Message}>";
        }
    }

    private static string DescribeLogFiles(string? path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            return "<no log path>";
        }

        string wrapperLog = Path.ChangeExtension(path, ".wrapper.log");
        return $"unityLog={DescribeFile(path)} wrapperLog={DescribeFile(wrapperLog)}";
    }

    private static string DescribeFile(string path)
    {
        try
        {
            var file = new FileInfo(path);
            return file.Exists
                ? $"{path} size={file.Length} updated={file.LastWriteTimeUtc:O}"
                : $"{path} missing";
        }
        catch (Exception ex)
        {
            return $"{path} unknown({ex.GetBaseException().Message})";
        }
    }

    private static string BuildStartupDiagnostics(string? path, int maxLines)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            return "<no log path>";
        }

        maxLines = Math.Clamp(maxLines, 20, 200);
        string wrapperLog = Path.ChangeExtension(path, ".wrapper.log");
        string wrapperTail = File.Exists(wrapperLog)
            ? BuildFilteredLogTail(wrapperLog, Math.Min(maxLines, 50), includeUnityNoiseSummary: false)
            : $"<wrapper log missing: {wrapperLog}>";
        string unityTail = File.Exists(path)
            ? BuildFilteredLogTail(path, maxLines, includeUnityNoiseSummary: true)
            : $"<unity log missing: {path}>";

        return $"wrapper={wrapperTail} unity={unityTail}";
    }

    private bool TryDetectStartupStall(GameServerSession session, DateTimeOffset startedAt, DateTimeOffset now, out string reason)
    {
        reason = "";
        int configuredStallSeconds = _options.GameServerStartupStallSeconds;
        if (configuredStallSeconds <= 0)
        {
            return false;
        }

        double elapsedSeconds = (now - startedAt).TotalSeconds;

        string[] logPaths = GetStartupLogPaths(session)
            .Where(path => !string.IsNullOrWhiteSpace(path))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToArray();

        if (HasFreshStartupMarker(logPaths, startedAt))
        {
            return false;
        }

        DateTimeOffset? latestWrite = GetLatestFreshLogWriteUtc(logPaths, startedAt);
        bool hasFreshLogWrite = latestWrite.HasValue;
        bool hasFreshUnityLog = HasFreshUnityLogWrite(session.LogFile, startedAt);
        int graceSeconds = !hasFreshUnityLog
            ? EffectiveWrapperOnlyStartupStallGraceSeconds(_options)
            : hasFreshLogWrite
            ? EffectiveNoisyStartupStallGraceSeconds(_options)
            : Math.Max(0, _options.GameServerStartupStallGraceSeconds);
        if (elapsedSeconds < graceSeconds)
        {
            return false;
        }

        int stallSeconds = !hasFreshUnityLog
            ? EffectiveWrapperOnlyStartupStallSeconds(_options)
            : hasFreshLogWrite
            ? EffectiveNoisyStartupStallSeconds(_options)
            : Math.Max(0, configuredStallSeconds);
        if (stallSeconds <= 0)
        {
            return false;
        }

        double idleSeconds = latestWrite is { } latest
            ? (now - latest).TotalSeconds
            : elapsedSeconds;

        if (idleSeconds < stallSeconds)
        {
            return false;
        }

        reason = latestWrite is { } write
            ? $"no mod/bootstrap marker after {elapsedSeconds:F1}s; latest fresh log write {idleSeconds:F1}s ago at {write:O}; freshUnityLog={hasFreshUnityLog}; grace={graceSeconds}s stall={stallSeconds}s logs={DescribeStartupLogFiles(logPaths)}"
            : $"no mod/bootstrap marker and no fresh log writes after {elapsedSeconds:F1}s; freshUnityLog={hasFreshUnityLog}; grace={graceSeconds}s stall={stallSeconds}s logs={DescribeStartupLogFiles(logPaths)}";
        return true;
    }

    private static bool HasFreshUnityLogWrite(string? path, DateTimeOffset startedAt)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            return false;
        }

        try
        {
            var file = new FileInfo(path);
            if (!file.Exists || file.Length <= 0)
            {
                return false;
            }

            var writeTime = new DateTimeOffset(DateTime.SpecifyKind(file.LastWriteTimeUtc, DateTimeKind.Utc));
            return writeTime >= startedAt.AddSeconds(-2);
        }
        catch
        {
            return false;
        }
    }

    private IEnumerable<string> GetStartupLogPaths(GameServerSession session)
    {
        if (!string.IsNullOrWhiteSpace(session.LogFile))
        {
            yield return session.LogFile;
            yield return Path.ChangeExtension(session.LogFile, ".wrapper.log");
        }

        // Do not use the shared MelonLoader/Latest.log for startup-stall detection.
        // It can contain fresh markers from a previous prewarm or match process, which
        // hides the actual per-match Unity process that only emitted shader/AppUI noise.
    }

    private static DateTimeOffset? GetLatestFreshLogWriteUtc(IEnumerable<string> paths, DateTimeOffset startedAt)
    {
        DateTimeOffset freshThreshold = startedAt.AddSeconds(-2);
        DateTimeOffset? latest = null;
        foreach (string path in paths)
        {
            try
            {
                var file = new FileInfo(path);
                if (!file.Exists)
                {
                    continue;
                }

                var writeTime = new DateTimeOffset(DateTime.SpecifyKind(file.LastWriteTimeUtc, DateTimeKind.Utc));
                if (writeTime < freshThreshold)
                {
                    continue;
                }

                if (latest is null || writeTime > latest)
                {
                    latest = writeTime;
                }
            }
            catch
            {
            }
        }

        return latest;
    }

    private static bool HasFreshStartupMarker(IEnumerable<string> paths, DateTimeOffset startedAt)
    {
        DateTimeOffset freshThreshold = startedAt.AddSeconds(-2);
        string[] markers =
        [
            "[BAP_Custom_Server]",
            "[BAPBAP_ModAPI]",
            "[Medusa]",
            "Started game bootstrap",
            "Game bootstrap HTTP listener is active",
            "TcpListener"
        ];

        foreach (string path in paths)
        {
            try
            {
                var file = new FileInfo(path);
                if (!file.Exists)
                {
                    continue;
                }

                var writeTime = new DateTimeOffset(DateTime.SpecifyKind(file.LastWriteTimeUtc, DateTimeKind.Utc));
                if (writeTime < freshThreshold)
                {
                    continue;
                }

                if (File.ReadLines(path)
                    .TakeLast(300)
                    .Any(line => markers.Any(marker => line.Contains(marker, StringComparison.OrdinalIgnoreCase))))
                {
                    return true;
                }
            }
            catch
            {
            }
        }

        return false;
    }

    private static string DescribeStartupLogFiles(IEnumerable<string> paths)
    {
        return string.Join("; ", paths.Select(DescribeFile));
    }

    private static string BuildFilteredLogTail(string path, int maxLines, bool includeUnityNoiseSummary)
    {
        try
        {
            string[] lines = File.ReadLines(path).TakeLast(maxLines).ToArray();
            int knownNoise = 0;
            int blankNoise = 0;
            var important = new List<string>();
            var fallback = new List<string>();

            foreach (string rawLine in lines)
            {
                string line = CompactLogLine(rawLine);
                if (string.IsNullOrWhiteSpace(line))
                {
                    blankNoise++;
                    continue;
                }

                if (IsKnownLogNoise(line))
                {
                    knownNoise++;
                    continue;
                }

                fallback.Add(line);
                if (IsImportantStartupLine(line))
                {
                    important.Add(line);
                }
            }

            IEnumerable<string> selected = important.Count > 0
                ? important.TakeLast(18)
                : fallback.TakeLast(12);

            string summary = string.Join(" | ", selected);
            if (string.IsNullOrWhiteSpace(summary))
            {
                summary = "<no useful lines in tail>";
            }

            if (includeUnityNoiseSummary)
            {
                summary = $"suppressedKnownNoise={knownNoise} blankLines={blankNoise} tail={summary}";
            }

            return TruncateForLog(summary, 3500);
        }
        catch (Exception ex)
        {
            return $"<could not read {path}: {ex.GetBaseException().Message}>";
        }
    }

    private static bool IsKnownLogNoise(string line)
    {
        return line.Contains("shader is not supported on this GPU", StringComparison.OrdinalIgnoreCase) ||
               line.Contains("Shader Unsupported:", StringComparison.OrdinalIgnoreCase) ||
               line.Contains("All subshaders removed", StringComparison.OrdinalIgnoreCase) ||
               line.Contains("#pragma only_renderers", StringComparison.OrdinalIgnoreCase) ||
               line.Contains("Fallback off", StringComparison.OrdinalIgnoreCase) ||
               line.Contains("Could not find material Hidden/Video", StringComparison.OrdinalIgnoreCase) ||
               line.Contains("Could not find video decode shader pass", StringComparison.OrdinalIgnoreCase) ||
               line.Contains("Video shaders not found", StringComparison.OrdinalIgnoreCase) ||
               line.Contains("Microsoft Media Foundation video decoding to texture disabled", StringComparison.OrdinalIgnoreCase) ||
               line.Contains("WindowsVideoMedia error", StringComparison.OrdinalIgnoreCase) ||
               line.Contains("Unable to find an AppUISettings instance", StringComparison.OrdinalIgnoreCase) ||
               line.Contains("ALSA lib ", StringComparison.OrdinalIgnoreCase) ||
               line.Contains("[KCP] Server: RawSend invalid connectionId=", StringComparison.OrdinalIgnoreCase) ||
               line.Contains("kcp2k.KcpServer:RawSend", StringComparison.OrdinalIgnoreCase) ||
               line.Contains("kcp2k.KcpServerConnection:RawSend", StringComparison.OrdinalIgnoreCase) ||
               line.Contains("kcp2k.KcpPeer:SendDisconnect", StringComparison.OrdinalIgnoreCase);
    }

    private static bool IsImportantStartupLine(string line)
    {
        string[] markers =
        [
            "BAP_Custom",
            "Bootstrap",
            "bootstrap",
            "Started game bootstrap",
            "WebServer",
            "httpport",
            "ListenPort",
            "GameNetworkManager",
            "StartServer",
            "Mirror",
            "KCP",
            "TcpListener",
            "Melon",
            "wine",
            "xvfb",
            "ERROR",
            "Error",
            "Exception",
            "failed",
            "not found",
            "graphics device is Null",
            "NullReference",
            "crash",
            "fatal"
        ];

        return markers.Any(marker => line.Contains(marker, StringComparison.OrdinalIgnoreCase));
    }

    private static string CompactLogLine(string line)
    {
        return string.Join(' ', (line ?? "").Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries));
    }

    private static string TruncateForLog(string text, int maxChars)
    {
        if (text.Length <= maxChars)
        {
            return text;
        }

        return text[..maxChars] + "...<truncated>";
    }

    private async Task<bool> WaitForUdpPortAsync(GameServerSession session, int port, DateTimeOffset bootstrapDeadline, CancellationToken cancellationToken)
    {
        DateTimeOffset now = DateTimeOffset.UtcNow;
        int configuredTimeout = _options.GameServerKcpPortReadyTimeoutSeconds;
        DateTimeOffset deadline = configuredTimeout > 0
            ? now.AddSeconds(Math.Max(3, configuredTimeout))
            : bootstrapDeadline;

        if (deadline > bootstrapDeadline)
        {
            deadline = bootstrapDeadline;
        }

        while (DateTimeOffset.UtcNow < deadline && !cancellationToken.IsCancellationRequested)
        {
            if (HasProcessExited(session, $"KCP UDP port {port}"))
            {
                return false;
            }

            if (IsUdpPortActive(port))
            {
                _logger.LogInformation("Game server KCP UDP port {KcpPort} is visible.", port);
                return true;
            }

            await Task.Delay(_options.GameServerReadyPollMillis, cancellationToken);
        }

        return false;
    }

    private async Task<bool> WaitForTcpListenerAsync(
        GameServerSession session,
        string label,
        int port,
        DateTimeOffset bootstrapDeadline,
        CancellationToken cancellationToken)
    {
        DateTimeOffset now = DateTimeOffset.UtcNow;
        int configuredTimeout = _options.GameServerTcpPortReadyTimeoutSeconds;
        DateTimeOffset deadline = configuredTimeout > 0
            ? now.AddSeconds(Math.Max(3, configuredTimeout))
            : bootstrapDeadline;
        DateTimeOffset nextProgressLog = now.AddSeconds(Math.Max(5, _options.GameServerBootstrapProgressLogSeconds));

        if (deadline > bootstrapDeadline)
        {
            deadline = bootstrapDeadline;
        }

        while (DateTimeOffset.UtcNow < deadline && !cancellationToken.IsCancellationRequested)
        {
            if (HasProcessExited(session, $"{label} TCP port {port}"))
            {
                return false;
            }

            if (IsTcpPortListening(port))
            {
                _logger.LogInformation("Game server {Label} TCP port {Port} is listening.", label, port);
                return true;
            }

            now = DateTimeOffset.UtcNow;
            if (now >= nextProgressLog)
            {
                _logger.LogInformation(
                    "Still waiting for game server {Label} TCP port {Port}. remaining={RemainingSeconds:F1}s",
                    label,
                    port,
                    Math.Max(0, (deadline - now).TotalSeconds));
                nextProgressLog = now.AddSeconds(Math.Max(5, _options.GameServerBootstrapProgressLogSeconds));
            }

            await Task.Delay(_options.GameServerReadyPollMillis, cancellationToken);
        }

        return false;
    }

    private static bool IsUdpPortActive(int port)
    {
        if (port <= 0)
        {
            return false;
        }

        try
        {
            if (IPGlobalProperties.GetIPGlobalProperties()
                .GetActiveUdpListeners()
                .Any(endpoint => endpoint.Port == port))
            {
                return true;
            }
        }
        catch
        {
            // Fall through to procfs on Linux containers.
        }

        return IsUdpPortInProcNet("/proc/net/udp", port) ||
               IsUdpPortInProcNet("/proc/net/udp6", port);
    }

    private static bool IsTcpPortListening(int port)
    {
        if (port <= 0)
        {
            return false;
        }

        try
        {
            if (IPGlobalProperties.GetIPGlobalProperties()
                .GetActiveTcpListeners()
                .Any(endpoint => endpoint.Port == port))
            {
                return true;
            }
        }
        catch (SocketException)
        {
            // Fall through to procfs on Linux containers.
        }
        catch
        {
        }

        return IsTcpPortListeningInProcNet("/proc/net/tcp", port) ||
               IsTcpPortListeningInProcNet("/proc/net/tcp6", port);
    }

    private static bool IsUdpPortInProcNet(string path, int port)
    {
        try
        {
            if (!File.Exists(path))
            {
                return false;
            }

            foreach (string line in File.ReadLines(path).Skip(1))
            {
                string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 2)
                {
                    continue;
                }

                string[] addressParts = parts[1].Split(':');
                if (addressParts.Length != 2)
                {
                    continue;
                }

                if (int.TryParse(addressParts[1], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int parsedPort) &&
                    parsedPort == port)
                {
                    return true;
                }
            }
        }
        catch
        {
        }

        return false;
    }

    private static bool IsTcpPortListeningInProcNet(string path, int port)
    {
        try
        {
            if (!File.Exists(path))
            {
                return false;
            }

            foreach (string line in File.ReadLines(path).Skip(1))
            {
                string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 4)
                {
                    continue;
                }

                string[] addressParts = parts[1].Split(':');
                if (addressParts.Length != 2)
                {
                    continue;
                }

                if (int.TryParse(addressParts[1], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int parsedPort) &&
                    parsedPort == port &&
                    string.Equals(parts[3], "0A", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
        }
        catch
        {
        }

        return false;
    }

    private static async Task PostJsonAsync(HttpClient client, Uri baseUri, string path, object payload, CancellationToken cancellationToken)
    {
        Uri uri = new(baseUri, path);
        // Pre-serialize JSON to a byte buffer with explicit Content-Length so the mod's
        // managed bootstrap listener (which only understands Content-Length, not chunked
        // encoding) can read the body. JsonContent / PostAsJsonAsync defaults to streaming
        // / Transfer-Encoding: chunked which the mod's hand-rolled HTTP parser drops.
        byte[] bodyBytes = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(payload, payload?.GetType() ?? typeof(object), JsonContract.Options);
        using ByteArrayContent content = new(bodyBytes);
        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json") { CharSet = "utf-8" };
        content.Headers.ContentLength = bodyBytes.Length;
        using HttpResponseMessage response = await client.PostAsync(uri, content, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    private sealed class ManagedBootstrapStatus
    {
        public bool Ok { get; set; }
        public bool NetworkStarted { get; set; }
        public bool SetupGameApplied { get; set; }
        public bool AddTeamsApplied { get; set; }
        public bool QueueMatchedApplied { get; set; }
        public bool BootstrapRepairComplete { get; set; }
        public string? LastStatus { get; set; }
        public double Realtime { get; set; }
    }

    public static string SubstituteLaunchTokens(
        string template,
        string gameId,
        int httpPort,
        int wsPort,
        int kcpPort,
        int tcpPort,
        string logFile,
        string? gameExecutable = null,
        string? gameArguments = null)
    {
        string result = template ?? "";
        if (gameExecutable != null)
        {
            result = result.Replace("{gameExecutable}", gameExecutable, StringComparison.OrdinalIgnoreCase);
        }
        if (gameArguments != null)
        {
            result = result.Replace("{gameArguments}", gameArguments, StringComparison.OrdinalIgnoreCase);
        }
        return result
            .Replace("{gameId}", gameId, StringComparison.OrdinalIgnoreCase)
            .Replace("{httpPort}", httpPort.ToString(), StringComparison.OrdinalIgnoreCase)
            .Replace("{wsPort}", wsPort.ToString(), StringComparison.OrdinalIgnoreCase)
            .Replace("{kcpPort}", kcpPort.ToString(), StringComparison.OrdinalIgnoreCase)
            .Replace("{tcpPort}", tcpPort.ToString(), StringComparison.OrdinalIgnoreCase)
            .Replace("{logFile}", logFile, StringComparison.OrdinalIgnoreCase);
    }

    private string AppendLocalCallbackArguments(string gameArguments)
    {
        List<string> additions = [];
        if (!ContainsArgument(gameArguments, "--bapcustom-host="))
        {
            additions.Add("--bapcustom-host=127.0.0.1");
        }

        if (!ContainsArgument(gameArguments, "--bapcustom-server-port="))
        {
            additions.Add($"--bapcustom-server-port={ResolveLobbyCallbackPort()}");
        }

        if (!ContainsArgument(gameArguments, "--bapcustom-use-proxy="))
        {
            additions.Add("--bapcustom-use-proxy=false");
        }

        return additions.Count == 0
            ? gameArguments
            : $"{gameArguments} {string.Join(' ', additions)}";
    }

    private static bool ContainsArgument(string arguments, string prefix)
    {
        return arguments.Contains(prefix, StringComparison.OrdinalIgnoreCase);
    }

    private int ResolveLobbyCallbackPort()
    {
        int? envPort = TryResolvePortFromUrls(Environment.GetEnvironmentVariable("ASPNETCORE_URLS")) ??
                       TryResolvePortFromUrls(Environment.GetEnvironmentVariable("URLS"));
        if (envPort is > 0)
        {
            return envPort.Value;
        }

        if (Uri.TryCreate((_options.PublicBaseUrl ?? "").TrimEnd('/') + "/", UriKind.Absolute, out Uri? publicBase))
        {
            if (!publicBase.IsDefaultPort)
            {
                return publicBase.Port;
            }

            return publicBase.Scheme.Equals(Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase) ? 443 : 80;
        }

        return 5055;
    }

    private static int? TryResolvePortFromUrls(string? urls)
    {
        if (string.IsNullOrWhiteSpace(urls))
        {
            return null;
        }

        foreach (string rawUrl in urls.Split([';', ','], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
        {
            if (!Uri.TryCreate(rawUrl, UriKind.Absolute, out Uri? uri))
            {
                continue;
            }

            if (!uri.IsDefaultPort)
            {
                return uri.Port;
            }

            return uri.Scheme.Equals(Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase) ? 443 : 80;
        }

        return null;
    }

    // F028 — per-attempt log file name. A single-attempt launch gets "{GameId}.log"; a multi-attempt
    // (retrying) launch disambiguates each try as "{GameId}.attempt{N}.log" so retry diagnostics don't
    // clobber each other. Pure so the naming contract is unit-testable without spawning a process.
    internal static string BuildAttemptLogFileName(string gameId, int attempt, int maxAttempts)
    {
        return maxAttempts > 1
            ? $"{gameId}.attempt{attempt}.log"
            : $"{gameId}.log";
    }

    private string ResolvePath(string path)
    {
        if (Path.IsPathRooted(path))
        {
            return Path.GetFullPath(path);
        }

        return Path.GetFullPath(Path.Combine(_environment.ContentRootPath, path));
    }

    private string ResolveExecutableOrCommand(string path)
    {
        if (!path.Contains(Path.DirectorySeparatorChar) &&
            !path.Contains(Path.AltDirectorySeparatorChar) &&
            !Path.IsPathRooted(path))
        {
            return path;
        }

        return ResolvePath(path);
    }

    private static void TryKill(Process process)
    {
        try
        {
            if (!process.HasExited)
            {
                process.Kill(entireProcessTree: true);
            }
        }
        catch
        {
            // Best effort cleanup; the caller already has the startup failure.
        }
    }

    private void TryCleanupWinePrefixes(string gameId)
    {
        try
        {
            string workingDirectory = ResolvePath(_options.GameWorkingDirectory);
            string prefixesDir = Path.Combine(workingDirectory, "wineprefixes");
            if (Directory.Exists(prefixesDir))
            {
                var prefixDirs = Directory.GetDirectories(prefixesDir, $"wineprefix_{gameId}_attempt*");
                foreach (var dir in prefixDirs)
                {
                    try
                    {
                        Directory.Delete(dir, recursive: true);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning(ex, "Failed to delete temporary wineprefix directory: {Dir}", dir);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to scan or cleanup wineprefixes for game: {GameId}", gameId);
        }
    }
}

public sealed record GameServerSession(
    string GameId,
    string Hostname,
    int WsPort,
    int KcpPort,
    int TcpPort,
    Process? Process,
    int HttpPort,
    int MapId,
    int UnityGameModeId,
    string? LogFile = null);

public sealed record MatchBootstrap(
    string GameId,
    MatchmakingGameData GameData,
    MatchmakingTeamData TeamData,
    QueueMatchedData QueueMatchedData);

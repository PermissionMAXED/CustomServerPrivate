using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace BapCustomServer;

public sealed class GameServerPrewarmService : BackgroundService
{
    private static readonly string[] ReadyMarkers =
    [
        "[SceneLoaded] Scene 'MainScene'",
        "Requested dedicated server start through GameNetworkManager",
        "Dedicated network start is pending",
        "post-StartServer"
    ];

    private readonly CustomServerOptions _options;
    private readonly IWebHostEnvironment _environment;
    private readonly ILogger<GameServerPrewarmService> _logger;
    private readonly TaskCompletionSource<bool> _completion = new(TaskCreationOptions.RunContinuationsAsynchronously);
    private readonly object _gate = new();
    private GameServerPrewarmStatus _status = new() { State = "not-started" };

    public GameServerPrewarmService(
        IOptions<CustomServerOptions> options,
        IWebHostEnvironment environment,
        ILogger<GameServerPrewarmService> logger)
    {
        _options = options.Value;
        _environment = environment;
        _logger = logger;
    }

    public GameServerPrewarmStatus GetStatus()
    {
        lock (_gate)
        {
            return _status with { };
        }
    }

    public async Task<bool> WaitForStartupPrewarmAsync(TimeSpan maxWait, CancellationToken cancellationToken)
    {
        if (!_options.GameServerPrewarmOnStartup || maxWait <= TimeSpan.Zero)
        {
            return GetStatus().Ready;
        }

        GameServerPrewarmStatus status = GetStatus();
        if (status.State is not ("starting" or "running"))
        {
            return status.Ready;
        }

        using var waitCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        Task timeout = Task.Delay(maxWait, waitCts.Token);
        Task completed = await Task.WhenAny(_completion.Task, timeout);
        if (completed == _completion.Task)
        {
            waitCts.Cancel();
            return await _completion.Task;
        }

        return GetStatus().Ready;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if (!ShouldRun(out string skipReason))
        {
            UpdateStatus(state: "skipped", ready: false, completed: true, error: skipReason);
            _completion.TrySetResult(false);
            _logger.LogInformation("Game-server startup prewarm skipped: {Reason}", skipReason);
            return;
        }

        try
        {
            await Task.Delay(TimeSpan.FromSeconds(2), stoppingToken);
            bool ready = await RunPrewarmAsync(stoppingToken);
            _completion.TrySetResult(ready);
        }
        catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
        {
            UpdateStatus(state: "cancelled", ready: false, completed: true);
            _completion.TrySetResult(false);
        }
        catch (Exception ex)
        {
            UpdateStatus(state: "failed", ready: false, completed: true, error: ex.GetBaseException().Message);
            _completion.TrySetResult(false);
            _logger.LogWarning(ex, "Game-server startup prewarm failed.");
        }
    }

    private async Task<bool> RunPrewarmAsync(CancellationToken cancellationToken)
    {
        DateTimeOffset startedAt = DateTimeOffset.UtcNow;
        string workingDirectory = ResolvePath(_options.GameWorkingDirectory);
        string executable = ResolvePath(_options.GameExecutablePath);
        string logDirectory = ResolvePath(_options.GameLogDirectory);
        Directory.CreateDirectory(logDirectory);

        string logFile = Path.Combine(logDirectory, $"prewarm-managed-{startedAt:yyyyMMddTHHmmssZ}.log");
        string melonLog = Path.Combine(workingDirectory, "MelonLoader", "Latest.log");
        int portOffset = Math.Clamp(_options.GameServerPrewarmPortOffset, 20, 2000);
        int httpPort = _options.BaseHttpPort + portOffset;
        int wsPort = _options.BaseWsPort + portOffset;
        int kcpPort = _options.BaseKcpPort + portOffset;
        int tcpPort = _options.BaseTcpPort + portOffset;

        string gameArguments = _options.HeadlessArguments
            .Replace("{gameId}", "prewarm", StringComparison.OrdinalIgnoreCase)
            .Replace("{httpPort}", httpPort.ToString(), StringComparison.OrdinalIgnoreCase)
            .Replace("{wsPort}", wsPort.ToString(), StringComparison.OrdinalIgnoreCase)
            .Replace("{kcpPort}", kcpPort.ToString(), StringComparison.OrdinalIgnoreCase)
            .Replace("{tcpPort}", tcpPort.ToString(), StringComparison.OrdinalIgnoreCase)
            .Replace("{logFile}", logFile, StringComparison.OrdinalIgnoreCase);

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
            processArguments = _options.GameLauncherArguments
                .Replace("{gameExecutable}", executable, StringComparison.OrdinalIgnoreCase)
                .Replace("{gameArguments}", gameArguments, StringComparison.OrdinalIgnoreCase)
                .Replace("{gameId}", "prewarm", StringComparison.OrdinalIgnoreCase)
                .Replace("{httpPort}", httpPort.ToString(), StringComparison.OrdinalIgnoreCase)
                .Replace("{wsPort}", wsPort.ToString(), StringComparison.OrdinalIgnoreCase)
                .Replace("{kcpPort}", kcpPort.ToString(), StringComparison.OrdinalIgnoreCase)
                .Replace("{tcpPort}", tcpPort.ToString(), StringComparison.OrdinalIgnoreCase)
                .Replace("{logFile}", logFile, StringComparison.OrdinalIgnoreCase);
        }

        var startInfo = new ProcessStartInfo
        {
            FileName = processFileName,
            WorkingDirectory = workingDirectory,
            Arguments = processArguments,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        UpdateStatus(
            state: "starting",
            ready: false,
            completed: false,
            startedUtc: startedAt,
            logFile: logFile,
            melonLogFile: melonLog);

        _logger.LogInformation(
            "Starting game-server startup prewarm. executable={Executable} cwd={WorkingDirectory} http={HttpPort} ws={WsPort} kcp={KcpPort} tcp={TcpPort} timeout={TimeoutSeconds}s log={LogFile}",
            processFileName,
            workingDirectory,
            httpPort,
            wsPort,
            kcpPort,
            tcpPort,
            EffectivePrewarmTimeoutSeconds(),
            logFile);

        using Process process = Process.Start(startInfo) ?? throw new InvalidOperationException("Prewarm Process.Start returned null.");
        UpdateStatus(state: "running", ready: false, completed: false, processId: process.Id);

        bool ready = false;
        string readySource = "none";
        try
        {
            DateTimeOffset deadline = startedAt.AddSeconds(EffectivePrewarmTimeoutSeconds());
            while (!cancellationToken.IsCancellationRequested && DateTimeOffset.UtcNow < deadline)
            {
                if (process.HasExited)
                {
                    break;
                }

                if (HasReadyMarker(melonLog, startedAt, out readySource))
                {
                    ready = true;
                    break;
                }

                await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
            }

            if (ready)
            {
                int settleSeconds = Math.Clamp(_options.GameServerPrewarmSettleSeconds, 0, 30);
                if (settleSeconds > 0)
                {
                    await Task.Delay(TimeSpan.FromSeconds(settleSeconds), cancellationToken);
                }
            }
        }
        finally
        {
            // Always terminate the spawned game process, even when host shutdown cancels the
            // awaits above. Without this, a shutdown during prewarm leaks an orphaned headless
            // Wine/Unity process holding the prewarm port quad.
            TryKill(process);
            await WaitForExitAsync(process);
        }

        string state = ready ? "ready" : "not-ready";
        UpdateStatus(
            state: state,
            ready: ready,
            completed: true,
            completedUtc: DateTimeOffset.UtcNow,
            exitCode: SafeExitCode(process),
            readySource: readySource);

        _logger.LogInformation(
            "Game-server startup prewarm finished. ready={Ready} source={ReadySource} elapsed={ElapsedSeconds:F1}s exitCode={ExitCode} log={LogFile}",
            ready,
            readySource,
            (DateTimeOffset.UtcNow - startedAt).TotalSeconds,
            SafeExitCode(process)?.ToString() ?? "<running>",
            logFile);

        return ready;
    }

    private bool ShouldRun(out string reason)
    {
        if (!_options.LaunchGameServers)
        {
            reason = "LaunchGameServers=false";
            return false;
        }

        if (!_options.GameServerPrewarmOnStartup)
        {
            reason = "GameServerPrewarmOnStartup=false";
            return false;
        }

        if (string.IsNullOrWhiteSpace(_options.GameLauncherPath))
        {
            reason = "GameLauncherPath is empty";
            return false;
        }

        string executable = ResolvePath(_options.GameExecutablePath);
        if (!File.Exists(executable))
        {
            reason = $"game executable missing: {executable}";
            return false;
        }

        string launcher = ResolveExecutableOrCommand(_options.GameLauncherPath);
        if (Path.IsPathFullyQualified(launcher) && !File.Exists(launcher))
        {
            reason = $"game launcher missing: {launcher}";
            return false;
        }

        reason = "";
        return true;
    }

    private int EffectivePrewarmTimeoutSeconds()
    {
        return Math.Clamp(_options.GameServerPrewarmTimeoutSeconds, 30, 600);
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

        if (!ContainsArgument(gameArguments, "--bapcustom-show-ui="))
        {
            additions.Add("--bapcustom-show-ui=false");
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

    private static bool HasReadyMarker(string melonLog, DateTimeOffset startedAt, out string readySource)
    {
        readySource = "none";
        try
        {
            var file = new FileInfo(melonLog);
            if (!file.Exists)
            {
                return false;
            }

            var writeTime = new DateTimeOffset(DateTime.SpecifyKind(file.LastWriteTimeUtc, DateTimeKind.Utc));
            if (writeTime < startedAt.AddSeconds(-2))
            {
                return false;
            }

            foreach (string line in File.ReadLines(melonLog).Reverse().Take(400))
            {
                foreach (string marker in ReadyMarkers)
                {
                    if (line.Contains(marker, StringComparison.OrdinalIgnoreCase))
                    {
                        readySource = marker;
                        return true;
                    }
                }
            }
        }
        catch
        {
            return false;
        }

        return false;
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

    private void UpdateStatus(
        string state,
        bool ready,
        bool completed,
        DateTimeOffset? startedUtc = null,
        DateTimeOffset? completedUtc = null,
        int? processId = null,
        int? exitCode = null,
        string? readySource = null,
        string? logFile = null,
        string? melonLogFile = null,
        string? error = null)
    {
        lock (_gate)
        {
            _status = _status with
            {
                Enabled = _options.GameServerPrewarmOnStartup,
                State = state,
                Ready = ready,
                Completed = completed,
                StartedUtc = startedUtc ?? _status.StartedUtc,
                CompletedUtc = completedUtc ?? _status.CompletedUtc,
                ProcessId = processId ?? _status.ProcessId,
                ExitCode = exitCode ?? _status.ExitCode,
                ReadySource = readySource ?? _status.ReadySource,
                LogFile = logFile ?? _status.LogFile,
                MelonLogFile = melonLogFile ?? _status.MelonLogFile,
                Error = error ?? _status.Error
            };
        }
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
            // Best-effort cleanup; the match start path has its own port/process guards.
        }
    }

    private static async Task WaitForExitAsync(Process process)
    {
        try
        {
            await process.WaitForExitAsync();
        }
        catch
        {
            // Ignore cleanup races.
        }
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
}

public sealed record GameServerPrewarmStatus
{
    public bool Enabled { get; init; }
    public string State { get; init; } = "not-started";
    public bool Ready { get; init; }
    public bool Completed { get; init; }
    public DateTimeOffset? StartedUtc { get; init; }
    public DateTimeOffset? CompletedUtc { get; init; }
    public int? ProcessId { get; init; }
    public int? ExitCode { get; init; }
    public string ReadySource { get; init; } = "none";
    public string? LogFile { get; init; }
    public string? MelonLogFile { get; init; }
    public string? Error { get; init; }
}

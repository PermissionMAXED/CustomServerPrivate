using System.Collections.Concurrent;

namespace BapCustomServer;

public sealed class DiagnosticsLogBuffer
{
    private readonly ConcurrentQueue<DiagnosticsLogEntry> _entries = new();
    private readonly int _capacity;

    public DiagnosticsLogBuffer(int capacity = 1200)
    {
        _capacity = Math.Max(100, capacity);
    }

    public void Add(LogLevel level, string category, string message, string? exception)
    {
        _entries.Enqueue(new DiagnosticsLogEntry(
            DateTimeOffset.UtcNow,
            level.ToString(),
            category,
            message,
            exception));

        while (_entries.Count > _capacity && _entries.TryDequeue(out _))
        {
        }
    }

    public DiagnosticsLogEntry[] Tail(int count)
    {
        count = Math.Clamp(count, 1, _capacity);
        return _entries.ToArray().TakeLast(count).ToArray();
    }
}

public sealed record DiagnosticsLogEntry(
    DateTimeOffset Utc,
    string Level,
    string Category,
    string Message,
    string? Exception);

public sealed class DiagnosticsLogBufferProvider : ILoggerProvider
{
    private readonly DiagnosticsLogBuffer _buffer;

    public DiagnosticsLogBufferProvider(DiagnosticsLogBuffer buffer)
    {
        _buffer = buffer;
    }

    public ILogger CreateLogger(string categoryName) => new DiagnosticsLogBufferLogger(_buffer, categoryName);

    public void Dispose()
    {
    }
}

internal sealed class DiagnosticsLogBufferLogger : ILogger
{
    private readonly DiagnosticsLogBuffer _buffer;
    private readonly string _category;

    public DiagnosticsLogBufferLogger(DiagnosticsLogBuffer buffer, string category)
    {
        _buffer = buffer;
        _category = category;
    }

    public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

    public bool IsEnabled(LogLevel logLevel)
    {
        return logLevel >= LogLevel.Warning ||
               _category.StartsWith("BapCustomServer", StringComparison.Ordinal);
    }

    public void Log<TState>(
        LogLevel logLevel,
        EventId eventId,
        TState state,
        Exception? exception,
        Func<TState, Exception?, string> formatter)
    {
        if (!IsEnabled(logLevel))
        {
            return;
        }

        string message;
        try
        {
            message = formatter(state, exception);
        }
        catch
        {
            message = state?.ToString() ?? "";
        }

        if (string.IsNullOrWhiteSpace(message) && exception is null)
        {
            return;
        }

        _buffer.Add(logLevel, _category, message, exception?.ToString());
    }
}

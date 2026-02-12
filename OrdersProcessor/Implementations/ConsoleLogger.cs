using OrdersProcessor.Interfaces;
using Microsoft.Extensions.Configuration;

namespace OrdersProcessor.Implementations;

/// <inheritdoc />
public class ConsoleLogger : ILogger
{
    private readonly HashSet<string> _configuredLogLevel;

    public ConsoleLogger(IConfiguration configuration)
    {
        var section = configuration.GetSection("Logging:LogLevels");
        _configuredLogLevel = section.GetChildren()
            .Select(x => x.Value!.ToLowerInvariant())
            .ToHashSet();        
    }

    /// <inheritdoc />
    public void LogInfo(string message)
    {
        if (!_configuredLogLevel.Contains("info"))
            return;

        var fullLogMessage = FormatMessage(message, "INFO");
        Console.WriteLine(fullLogMessage);
    }

    /// <inheritdoc />
    public void LogError(string message, Exception ex)
    {
        if (!_configuredLogLevel.Contains("error"))
            return;

        var fullLogMessage = FormatMessage(message, "ERROR");
        Console.WriteLine($"{fullLogMessage}\n----Exception details----\n{ex}");
    }

    private string FormatMessage(string message, string severity)
    {
        return $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] {severity}: {message}";
    }
}
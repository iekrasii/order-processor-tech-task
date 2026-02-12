using OrdersProcessor.Interfaces;

namespace OrdersProcessor.Implementations;

/// <inheritdoc />
public class ConsoleLogger : ILogger
{
    /// <inheritdoc />
    public void LogInfo(string message)
    {
        var fullLogMessage = FormatMessage(message, "INFO");
        Console.WriteLine(fullLogMessage);
    }

    /// <inheritdoc />
    public void LogError(string message, Exception ex)
    {
        var fullLogMessage = FormatMessage(message, "ERROR");
        Console.WriteLine($"{fullLogMessage}\n----Exception details----\n{ex}");
    }

    private string FormatMessage(string message, string severity)
    {
        return $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] {severity}: {message}";
    }
}
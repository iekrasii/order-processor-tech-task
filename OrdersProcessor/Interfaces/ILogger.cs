namespace OrdersProcessor.Interfaces;

/// <summary>
/// Represents the logic of logging to a specific target 
/// </summary>
public interface ILogger
{
    /// <summary>
    /// Logs information message
    /// </summary>
    /// <param name="message"></param>
    void LogInfo(string message);

    /// <summary>
    /// Logs error message
    /// </summary>
    /// <param name="message"></param>
    /// <param name="ex"></param>
    void LogError(string message, Exception ex);
}
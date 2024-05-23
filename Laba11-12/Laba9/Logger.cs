using Serilog;

public static class Logger
{
    public static void LogInfo(string message)
    {
        Log.Information(message);
    }

    public static void LogWarning(string message)
    {
        Log.Warning(message);
    }

    public static void LogError(string message, Exception ex)
    {
        Log.Error(ex, message);
    }
}

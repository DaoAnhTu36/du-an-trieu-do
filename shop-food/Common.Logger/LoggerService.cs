using Serilog;

namespace Common.Logger
{
    public static class LoggerService
    {
        public static void LogInfo(string message)
        {
            Log.Information(message);
        }

        public static void LogError(string message, Exception ex)
        {
            if (ex != null)
            {
                Log.Error(ex, message);
            }
            else
            {
                Log.Error(message);
            }
        }

        public static void LogWarning(string message)
        {
            Log.Warning(message);
        }

        public static void LogDebug(string message)
        {
            Log.Debug(message);
        }
    }
}
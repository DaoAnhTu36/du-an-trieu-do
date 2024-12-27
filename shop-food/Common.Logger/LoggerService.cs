using Common.StatusCode;
using Serilog;

namespace Common.Logger
{
    public static class LoggerService
    {
        public static void LogInfo(string message)
        {
            Log.Information(message);
        }

        public static void LogInfo(string? className, string? methodName, string? message, bool isStart = false)
        {
            message = FormatLogger(className, methodName, message, isStart);
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

        public static void LogWarning(string? className, string? methodName, string? message, bool isStart = false)
        {
            message = FormatLogger(className, methodName, message, isStart);
            Log.Warning(message);
        }

        public static void LogDebug(string? className, string? methodName, string? message, bool isStart = false)
        {
            message = FormatLogger(className, methodName, message, isStart);
            Log.Debug(message);
        }

        private static string FormatLogger(string? className, string? methodName, string? message, bool isStart = false)
        {
            var totalTime = string.Empty;
            var type = isStart ? "start" : "end";
            if (isStart)
            {
                return string.Format(StatusLogger.FormatLoggerStartStr, className, methodName, type, message);
            }
            return string.Format(StatusLogger.FormatLoggerEndStr, className, methodName, totalTime, type, message);
        }
    }
}
using System.Diagnostics;

namespace Common.StatusCode
{
    public static class StatusLogger
    {
        public static string FormatLoggerStartStr = "CLassName={0}.MethodName={1}.Status={2}.Message={3}";
        public static string FormatLoggerEndStr = "CLassName={0}.MethodName={1}.TotalTime={2}.Status={3}.Message={4}";

        public static DataTime DataTimeRef = new()
        {
            ClassName = "",
            IsStart = false,
            MethodName = "",
            TimeStart = new DateTime(),
        };

        public static string FormatLogger(string? className, string? methodName, string? message, bool isStart = false)
        {
            var totalTime = string.Empty;
            var type = isStart ? "start" : "end";
            if (DataTimeRef.ClassName == className && DataTimeRef.MethodName == methodName && isStart == false)
            {
                var timeEnd = DateTime.Now;
                TimeSpan timeSpan = timeEnd - DataTimeRef.TimeStart;
                totalTime = Math.Round(timeSpan.TotalMilliseconds / 1000, 3).ToString();
            }
            else
            {
                var stopwatch = Stopwatch.GetTimestamp();
                DataTimeRef = new()
                {
                    ClassName = className,
                    MethodName = methodName,
                    IsStart = isStart,
                    TimeStart = DateTime.Now,
                };
            }
            if (isStart)
            {
                return string.Format(FormatLoggerStartStr, className, methodName, type, message);
            }
            return string.Format(FormatLoggerEndStr, className, methodName, totalTime, type, message);
        }
    }

    public class DataTime
    {
        public string? ClassName { get; set; } = string.Empty;
        public string? MethodName { get; set; } = string.Empty;
        public bool IsStart { get; set; } = false;
        public DateTime TimeStart { get; set; } = DateTime.Now;
    }
}
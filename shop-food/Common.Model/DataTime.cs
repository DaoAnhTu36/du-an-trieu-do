namespace Common.Model
{
    public class DataTime
    {
        public string? ClassName { get; set; } = string.Empty;
        public string? MethodName { get; set; } = string.Empty;
        public bool IsStart { get; set; } = false;
        public DateTime TimeStart { get; set; } = DateTime.Now;
    }
}
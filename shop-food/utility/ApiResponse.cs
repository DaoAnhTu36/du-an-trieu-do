namespace utility
{
    public class ApiResponse
    {
        public bool IsNormal { get; set; }
        public MetaData? MetaData { get; set; }
    }

    public class ApiResponse<T>
    {
        public T? Data { get; set; }
        public bool IsNormal { get; set; }
        public MetaData? MetaData { get; set; }
    }

    public class MetaData
    {
        public string? StatusCode { get; set; }
        public string? Message { get; set; }
    }
}
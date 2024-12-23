namespace Common.Model.Config
{
    public class AppConfig
    {
        public string? ServiceName { get; set; }
        public string? ServiceVersion { get; set; }
        public int ServicePort { get; set; }
        public string? ServiceBasePath { get; set; }
        public ApplicationSetting? ApplicationSetting { get; set; }
        public ConnectionStrings? ConnectionStrings { get; set; }
        public LoggingSetting? Logging { get; set; }
        public PreferenceSetting? Preference { get; set; }
    }
}
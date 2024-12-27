namespace Common.Model.Config
{
    public class ApplicationMode
    {
        /// <summary>
        /// system enviroment of ASPNETCORE_ENVIRONMENT is different "Production" & "Staging" (case-sensitive)
        /// </summary>
        /// <returns></returns>
        public static bool IsDevelopment => EnvironmentName != "Production" && EnvironmentName != "Staging";

        public static bool IsLocal => EnvironmentName == "Local";

        public static string EnvironmentName => Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
    }
}
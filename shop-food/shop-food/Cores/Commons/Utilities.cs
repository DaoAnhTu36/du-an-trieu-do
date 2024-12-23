namespace shop_food.Cores.Commons
{
    public static class Helper
    {
        /// <summary>
        /// sinh code tự động bằng thời gian hiện tại chuyển sang milisecond
        /// </summary>
        /// <returns></returns>
        public static string GenCode()
        {
            var code = new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds();
            return code.ToString();
        }

        /// <summary>
        /// mã hóa mật khẩu
        /// </summary>
        /// <param name="password">mật khẩu</param>
        /// <returns></returns>
        public static string HashedPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        /// <summary>
        /// xác thực mật khẩu
        /// </summary>
        /// <param name="userSubmittedPassword">mật khẩu user nhập</param>
        /// <param name="hashedPassword">mật khẩu đã được mã hóa</param>
        /// <returns></returns>
        public static bool ValidPassword(string userSubmittedPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(userSubmittedPassword, hashedPassword);
        }
    }

    public static class TimeSpanUtil
    {
        #region To days

        public static double ConvertMillisecondsToDays(double milliseconds)
        {
            return TimeSpan.FromMilliseconds(milliseconds).TotalDays;
        }

        public static double ConvertSecondsToDays(double seconds)
        {
            return TimeSpan.FromSeconds(seconds).TotalDays;
        }

        public static double ConvertMinutesToDays(double minutes)
        {
            return TimeSpan.FromMinutes(minutes).TotalDays;
        }

        public static double ConvertHoursToDays(double hours)
        {
            return TimeSpan.FromHours(hours).TotalDays;
        }

        #endregion To days

        #region To hours

        public static double ConvertMillisecondsToHours(double milliseconds)
        {
            return TimeSpan.FromMilliseconds(milliseconds).TotalHours;
        }

        public static double ConvertSecondsToHours(double seconds)
        {
            return TimeSpan.FromSeconds(seconds).TotalHours;
        }

        public static double ConvertMinutesToHours(double minutes)
        {
            return TimeSpan.FromMinutes(minutes).TotalHours;
        }

        public static double ConvertDaysToHours(double days)
        {
            return TimeSpan.FromHours(days).TotalHours;
        }

        #endregion To hours

        #region To minutes

        public static double ConvertMillisecondsToMinutes(double milliseconds)
        {
            return TimeSpan.FromMilliseconds(milliseconds).TotalMinutes;
        }

        public static double ConvertSecondsToMinutes(double seconds)
        {
            return TimeSpan.FromSeconds(seconds).TotalMinutes;
        }

        public static double ConvertHoursToMinutes(double hours)
        {
            return TimeSpan.FromHours(hours).TotalMinutes;
        }

        public static double ConvertDaysToMinutes(double days)
        {
            return TimeSpan.FromDays(days).TotalMinutes;
        }

        #endregion To minutes

        #region To seconds

        public static double ConvertMillisecondsToSeconds(double milliseconds)
        {
            return TimeSpan.FromMilliseconds(milliseconds).TotalSeconds;
        }

        public static double ConvertMinutesToSeconds(double minutes)
        {
            return TimeSpan.FromMinutes(minutes).TotalSeconds;
        }

        public static double ConvertHoursToSeconds(double hours)
        {
            return TimeSpan.FromHours(hours).TotalSeconds;
        }

        public static double ConvertDaysToSeconds(double days)
        {
            return TimeSpan.FromDays(days).TotalSeconds;
        }

        #endregion To seconds

        #region To milliseconds

        public static double ConvertSecondsToMilliseconds(double seconds)
        {
            return TimeSpan.FromSeconds(seconds).TotalMilliseconds;
        }

        public static double ConvertMinutesToMilliseconds(double minutes)
        {
            return TimeSpan.FromMinutes(minutes).TotalMilliseconds;
        }

        public static double ConvertHoursToMilliseconds(double hours)
        {
            return TimeSpan.FromHours(hours).TotalMilliseconds;
        }

        public static double ConvertDaysToMilliseconds(double days)
        {
            return TimeSpan.FromDays(days).TotalMilliseconds;
        }

        #endregion To milliseconds
    }

}
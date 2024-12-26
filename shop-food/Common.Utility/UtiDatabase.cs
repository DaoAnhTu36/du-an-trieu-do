using Common.Model.Config;
using Microsoft.Extensions.Options;

namespace Common.Utility
{
    public static class UtiDatabase
    {
        public static List<T> PaginationExtension<T>(IOptions<AppConfig> options, int pageNumber, List<T> data)
        {
            var retVal = new List<T>();
            var pageSize = options.Value.PaginationSetting?.PageSize ?? 10;
            var skipNumber = (pageNumber - 1) * pageSize;
            return data.Skip(skipNumber).Take(pageSize).ToList();
        }
    }
}
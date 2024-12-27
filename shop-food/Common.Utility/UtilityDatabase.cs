using Common.Model.Config;
using Microsoft.Extensions.Options;

namespace Common.Utility
{
    public static class UtilityDatabase
    {
        public static IEnumerable<T> PaginationExtension<T>(IOptions<AppConfig> options, IQueryable<T> data, int? pageNumber, int? pageSize)
        {
            var retVal = new List<T>();
            pageNumber ??= 1;
            pageSize ??= options.Value.PaginationSetting?.PageSize ?? 10;
            var skipNumber = (pageNumber - 1) * pageSize ?? 1;
            return data.ToList().Skip(skipNumber).Take(pageSize ?? 10);
        }
    }
}
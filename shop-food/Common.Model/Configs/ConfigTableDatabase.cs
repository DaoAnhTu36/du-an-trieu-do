using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Configs
{
    public static class ConfigSchemaTableDatabase
    {
        public const string WH = "WH";
        public const string SHOP = "SHOP";
    }

    public enum ConfigTypeTransaction
    {
        IMPORT,
        EXPORT
    }
}

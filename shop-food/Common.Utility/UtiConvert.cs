using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Common.Utility
{
    public static class UtiConvert
    {
        public static string Seri(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        public static string Deseri(object obj)
        {
            var a = JsonConvert.DeserializeObject<List<string>>("a");
            return JsonConvert.SerializeObject(obj);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace shop_food_api.Services
{
    public class ServiceAssembly
    {
        public static Assembly Assembly => typeof(ServiceAssembly).Assembly;
    }
}

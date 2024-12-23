using System.Reflection;

namespace shop_food_authen.Services
{
    public class ServiceAssembly
    {
        public static Assembly Assembly => typeof(ServiceAssembly).Assembly;
    }
}
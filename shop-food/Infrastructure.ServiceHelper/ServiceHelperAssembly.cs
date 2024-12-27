using System.Reflection;

namespace Infrastructure.ServiceHelper
{
    public class ServiceHelperAssembly
    {
        public static Assembly Assembly => typeof(ServiceHelperAssembly).Assembly;
    }
}
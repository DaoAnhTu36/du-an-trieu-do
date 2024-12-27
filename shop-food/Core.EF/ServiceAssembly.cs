using System.Reflection;

namespace Core.EF
{
    public class ServiceCoreAssembly
    {
        public static Assembly Assembly => typeof(ServiceCoreAssembly).Assembly;
    }
}
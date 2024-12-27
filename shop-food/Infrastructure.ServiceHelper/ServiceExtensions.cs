using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.ServiceHelper
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddScopedInterfaceInstances<TInterface>(this IServiceCollection services, Assembly assembly)
        {
            var classTypes = assembly.GetTypes()
                .Where(t => t.IsClass && t.GetInterfaces().Contains(typeof(TInterface)))
                .ToArray();

            foreach (var classType in classTypes)
            {
                services.AddScoped(classType);
            }

            return services;
        }

        public static IServiceCollection AddScopedInterfaces(this IServiceCollection services, string interfaceSuffix, Assembly assembly)
        {
            var classTypes = assembly.GetTypes()
                .Where(t => t.IsClass && t.Name.EndsWith(interfaceSuffix))
                .ToArray();

            foreach (var classType in classTypes)
            {
                var interfaceType = classType.GetInterface("I" + classType.Name);
                if (interfaceType != null)
                {
                    services.AddScoped(interfaceType, classType);
                }
            }

            return services;
        }
    }
}
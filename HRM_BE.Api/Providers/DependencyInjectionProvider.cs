using System.Reflection;
using System.Runtime.CompilerServices;

namespace HRM_BE.Api.Providers
{
    public static class DependencyInjectionProvider
    {
        public static IServiceCollection AddDependencyInjectionProvider(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var serviceProjectNamespace = $"{Assembly.GetCallingAssembly().GetName().Name}.Services";

            var serviceTypes = assembly.GetTypes()
                .Where(type =>
                    type.Namespace == serviceProjectNamespace &&
                    !type.IsAbstract &&
                    !type.IsInterface &&
                    !type.IsNested &&
                    !type.IsGenericType &&
                    !type.Name.Contains("<") &&
                    !type.IsDefined(typeof(CompilerGeneratedAttribute), inherit: false)
                );

            foreach (var serviceType in serviceTypes)
            {
                services.AddScoped(serviceType);
            }

            return services;
        }
    }
}

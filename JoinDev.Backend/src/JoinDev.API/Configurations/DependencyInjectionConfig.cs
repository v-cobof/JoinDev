using JoinDev.Infra.CrossCutting.IoC;

namespace JoinDev.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeDependencyInjectionConfig.RegisterServices(services);
        }
    }
}

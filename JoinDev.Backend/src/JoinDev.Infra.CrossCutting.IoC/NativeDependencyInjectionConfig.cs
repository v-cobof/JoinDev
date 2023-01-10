using JoinDev.Domain.Data;
using JoinDev.Infra.CrossCutting.Bus;
using JoinDev.Infra.CrossCutting.Bus.Mediator;
using JoinDev.Infra.Data;
using JoinDev.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace JoinDev.Infra.CrossCutting.IoC
{
    public class NativeDependencyInjectionConfig
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Mediator (In memory bus)
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
        }
    }
}

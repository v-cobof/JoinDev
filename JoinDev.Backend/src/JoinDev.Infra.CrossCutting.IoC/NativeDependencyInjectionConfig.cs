using JoinDev.Application.Commands;
using JoinDev.Application.Commands.Handlers;
using JoinDev.Application.Pipeline;
using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Communication.Messages;
using JoinDev.Domain.Core.Validation.Results;
using JoinDev.Domain.Data;
using JoinDev.Infra.CrossCutting.Bus;
using JoinDev.Infra.Data;
using JoinDev.Infra.Data.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace JoinDev.Infra.CrossCutting.IoC
{
    public class NativeDependencyInjectionConfig
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Mediator (In memory bus)
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddScoped<IRequestHandler<CreateUserCommand, CommandResult>, UserCommandHandler>();

            // Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
        }
    }
}

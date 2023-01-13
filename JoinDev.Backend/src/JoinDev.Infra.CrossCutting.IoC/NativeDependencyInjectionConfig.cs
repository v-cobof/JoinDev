using JoinDev.Application.Commands;
using JoinDev.Application.Commands.Handlers;
using JoinDev.Application.Consumers;
using JoinDev.Application.Pipeline;
using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Communication.Messages;
using JoinDev.Domain.Core.Validation.Results;
using JoinDev.Domain.Data;
using JoinDev.Infra.CrossCutting.Bus;
using JoinDev.Infra.Data;
using JoinDev.Infra.Data.Repositories;
using MassTransit;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace JoinDev.Infra.CrossCutting.IoC
{
    public class NativeDependencyInjectionConfig
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Mediator (In memory bus)
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(QueueBehaviour<,>));

            services.AddScoped<IRequestHandler<CreateUserCommand, CommandResult>, UserCommandHandler>();

            // Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();

            services.AddMassTransit(x =>
            {
                var assembly = Assembly.GetAssembly(typeof(CommandConsumer));

                x.AddConsumers(assembly);

                x.UsingInMemory((context, cfg) =>
                {
                    cfg.ReceiveEndpoint("commands", e =>
                    {
                        e.ConfigureConsumer<CommandConsumer>(context);
                    });
                });
            });
        }
    }
}

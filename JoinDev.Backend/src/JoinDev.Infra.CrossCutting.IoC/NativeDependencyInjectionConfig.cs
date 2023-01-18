using FluentValidation;
using JoinDev.Application;
using JoinDev.Application.Commands;
using JoinDev.Application.Commands.Handlers;
using JoinDev.Application.Commands.Validations;
using JoinDev.Application.Pipeline;
using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Communication.Messages.Notifications;
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
            services.AddMediatR(typeof(BaseCommandHandler<,>));
            services.AddScoped<IBusHandler, MediatorHandler>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(QueueBehaviour<,>));

            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();

            // Fluent Validation
            services.AddValidatorsFromAssembly(typeof(RegisterUserCommandValidation).Assembly);

            // Mass Transit
            services.AddMassTransit(x =>
            {
                var assembly = Assembly.GetAssembly(typeof(RegisterUserCommandHandler));

                x.AddConsumers(assembly);

                x.UsingInMemory((context, cfg) =>
                {
                    cfg.ReceiveEndpoint("commands", e =>
                    {
                        //e.ConfigureConsumer<CommandConsumer>(context);
                        //e.ConfigureConsumer<UserCommandHandler>(context);
                        e.ConfigureConsumers(context);
                    });
                });
            });
        }
    }
}

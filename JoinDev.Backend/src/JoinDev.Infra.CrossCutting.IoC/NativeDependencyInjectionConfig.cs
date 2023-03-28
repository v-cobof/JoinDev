using FluentValidation;
using JoinDev.Application;
using JoinDev.Application.Commands;
using JoinDev.Application.Commands.Handlers;
using JoinDev.Application.Commands.Validations;
using JoinDev.Application.Data;
using JoinDev.Application.Pipeline;
using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Communication.Messages.Notifications;
using JoinDev.Domain.Data;
using JoinDev.Infra.CrossCutting.Bus;
using JoinDev.Infra.Data;
using JoinDev.Infra.Data.DAO;
using JoinDev.Infra.Data.Read;
using JoinDev.Infra.Data.Repositories;
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
            services.AddMediatR(typeof(BaseCommandHandler<>));
            services.AddScoped<IBusHandler, BusHandler>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(QueueBehaviour<,>));

            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Data
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IThemeCategoryDAO, ThemeCategoryDAO>();
            services.AddScoped<ILinkSourceDAO, LinkSourceDAO>();


            services.AddScoped(typeof(IReplicationRepository<>), typeof(ReplicationRepository<>));

            // Fluent Validation
            services.AddValidatorsFromAssembly(typeof(RegisterUserCommandValidation).Assembly);
        }
    }
}

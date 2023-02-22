using JoinDev.Application.Commands;
using JoinDev.Application.Commands.Handlers;
using JoinDev.Application.Events;
using JoinDev.Application.Events.Handlers;
using JoinDev.Domain.Core.Communication.Messages;
using MassTransit;
using MediatR;

namespace JoinDev.API.Configurations
{
    public static class BusConfig
    {
        public static void AddBusConfiguration(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumersFromNamespaceContaining<UserRegisteredEventHandler>();
                x.AddConsumersFromNamespaceContaining<RegisterUserCommandHandler>();
                x.SetKebabCaseEndpointNameFormatter();

                x.UsingRabbitMq((context, rabbit) =>
                {
                    rabbit.Publish<INotification>(p => p.Exclude = true);
                    rabbit.Publish<Message>(p => p.Exclude = true);

                    //rabbit.UseMessageRetry(x => x.Interval(2, 1000));

                    rabbit.Host("localhost", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    rabbit.ReceiveEndpoint("commands-queue", endpoint =>
                    {
                        endpoint.ConfigureConsumer<RegisterUserCommandHandler>(context);
                    });

                    rabbit.ReceiveEndpoint("events-queue", endpoint =>
                    {
                        endpoint.ConfigureConsumer<UserRegisteredEventHandler>(context);
                    });
                });
            });
        }
    }
}

using JoinDev.Application.Commands;
using JoinDev.Application.Commands.Handlers;
using JoinDev.Application.Events;
using JoinDev.Application.Events.Handlers;
using JoinDev.Domain.Core.Communication.Messages;
using MassTransit;

namespace JoinDev.API.Configurations
{
    public static class BusConfig
    {
        public static void AddBusConfiguration(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                //x.AddConsumer<UpdateGameRankConsumer>();

                // Set endpoint name construction with kebab case
                x.SetKebabCaseEndpointNameFormatter();

                x.UsingRabbitMq((context, rabbit) =>
                {
                    //rabbit.UseMessageRetry(x => x.Interval(2, 1000));

                    rabbit.Host("localhost", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    rabbit.ReceiveEndpoint("commands-queue", endpoint =>
                    {
                        // Sets the consumer to be used for the endpoint
                        endpoint.Consumer(t => t.Message<>)
                    });
                });
            });
        }
    }
}

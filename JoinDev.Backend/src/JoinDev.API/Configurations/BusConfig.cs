using JoinDev.Application.Commands;
using JoinDev.Application.Commands.Handlers;
using JoinDev.Application.Events;
using JoinDev.Application.Events.Handlers;
using JoinDev.Domain.Core.Communication.Messages;
using Rebus.Bus;
using Rebus.Config;
using Rebus.Persistence.InMem;
using Rebus.Routing.TypeBased;
using Rebus.Transport.InMem;

namespace JoinDev.API.Configurations
{
    public static class BusConfig
    {
        public static void AddBusConfiguration(this IServiceCollection services)
        {
            var defaultQueue = "join-dev";
            var commandQueue = "commands";
            var eventsQueue = "events";

            services.AddRebus(configure => configure
                .Transport(t => t.UseInMemoryTransport(new InMemNetwork(true), defaultQueue))
                //.Transport(t => t.UseRabbitMq("amqp://localhost", defaultQueue))
                .Routing(r =>
                {
                    r.TypeBased()
                        .MapAssemblyOf<Command>(defaultQueue)
                        .MapAssemblyOf<RegisterUserCommand>(defaultQueue)
                        .MapAssemblyOf<UserRegisteredEvent>(defaultQueue);
                })
                .Subscriptions(s => s.StoreInMemory())
                .Options(o =>
                {
                    o.SetNumberOfWorkers(1);
                    o.SetMaxParallelism(1);
                    o.SetBusName("join-dev");
                }),
            true,
            AddBusSubscriptions()
            );

            services.AutoRegisterHandlersFromAssemblyOf<RegisterUserCommandHandler>();
            services.AutoRegisterHandlersFromAssemblyOf<UserRegisteredEventHandler>();
        }

        private static Func<IBus, Task> AddBusSubscriptions()
        {
            return delegate (IBus bus)
            {
                return bus.Subscribe<UserRegisteredEvent>();
            };
        }
    }
}

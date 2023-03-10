using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Communication.Messages;
using JoinDev.Domain.Core.Communication.Messages.Notifications;
using JoinDev.Domain.Core.Validation.Results;
using MediatR;
using Rebus.Bus;

namespace JoinDev.Infra.CrossCutting.Bus
{
    public class BusHandler : IBusHandler
    {
        private readonly IMediator _mediator;
        private readonly IBus _bus;

        public BusHandler(IMediator mediator, IBus bus)
        {
            _mediator = mediator;
            _bus = bus;
        }

        public async Task PublishEvent<T>(T @event) where T : Event
        {
            await _bus.Publish(@event);
        }

        public async Task PublishEventsBatch<T>(IEnumerable<T> events) where T : Event
        {
            var tasks = events.Select(t => PublishEvent(t)).ToList();

            await Task.WhenAll(tasks);
        }

        public async Task PublishNotification<T>(T notification) where T : DomainNotification
        {
            await _mediator.Publish(notification);
        }

        public async Task PublishNotificationsBatch<T>(IEnumerable<T> notifications) where T : DomainNotification
        {
            var tasks = notifications.Select(t => PublishNotification(t)).ToList();

            await Task.WhenAll(tasks);
        }

        public async Task<CommandResult> SendCommand<T>(T command) where T : Command
        {
            return await _mediator.Send(command);
        }
    }
}

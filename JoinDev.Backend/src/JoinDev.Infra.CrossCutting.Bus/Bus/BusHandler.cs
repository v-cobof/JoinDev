using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Communication.Messages;
using JoinDev.Domain.Core.Communication.Messages.Notifications;
using JoinDev.Domain.Core.Validation.Results;
using MassTransit;
using MediatR;

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

        public async Task PublishEvent<T>(T @event) where T : Domain.Core.Communication.Messages.Event
        {
            await _bus.Publish(@event, @event.GetType());
        }

        public async Task PublishEventsBatch<T>(IEnumerable<T> events) where T : Domain.Core.Communication.Messages.Event
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

        public async Task<TRes> SendQuery<TRes>(Query<TRes> query)
        {
            return await _mediator.Send(query);
        }
    }
}

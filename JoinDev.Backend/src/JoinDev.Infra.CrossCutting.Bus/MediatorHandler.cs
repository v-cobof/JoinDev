using JoinDev.Domain.Core.Communication.Messages;
using JoinDev.Infra.CrossCutting.Bus.Mediator;
using MediatR;

namespace JoinDev.Infra.CrossCutting.Bus
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishEvent<T>(T @event) where T : Event
        {
            await _mediator.Publish(@event);
        }

        public async Task<Unit> SendCommand<T>(T command) where T : ICommand
        {
            return await _mediator.Send(command);
        }
    }
}

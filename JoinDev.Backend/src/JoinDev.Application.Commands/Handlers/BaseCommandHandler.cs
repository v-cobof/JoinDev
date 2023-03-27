using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Communication.Messages;
using JoinDev.Domain.Core.Communication.Messages.Notifications;
using JoinDev.Domain.Core.Validation.Results;
using JoinDev.Domain.Data;
using MassTransit;
using MediatR;

namespace JoinDev.Application.Commands.Handlers
{
    public abstract class BaseCommandHandler<TReq> : IConsumer<TReq>, IRequestHandler<TReq, CommandResult> where TReq : Command, IRequest<CommandResult>
    {
        protected readonly IBusHandler _bus;

        public BaseCommandHandler(IBusHandler bus)
        {
            _bus = bus;
        }

        public abstract Task<CommandResult> Execute(TReq request);

        protected async Task Notify(Command command, string message)
        {
            var notification = new DomainNotification(command.MessageType, message);

            await _bus.PublishNotification(notification);
        }

        public async Task Consume(ConsumeContext<TReq> context)
        {
            await Execute(context.Message);
        }

        public async Task<CommandResult> Handle(TReq request, CancellationToken cancellationToken)
        {
            return await Execute(request);
        }
    }
}

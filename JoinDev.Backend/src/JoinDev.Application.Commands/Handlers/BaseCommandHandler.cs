using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Communication.Messages;
using JoinDev.Domain.Core.Communication.Messages.Notifications;
using JoinDev.Domain.Core.Validation.Results;
using JoinDev.Domain.Data;
using MassTransit;
using MediatR;

namespace JoinDev.Application.Commands.Handlers
{
    public abstract class BaseCommandHandler<TReq, TRes> : IConsumer<TReq>, IRequestHandler<TReq, TRes> where TReq : Command, IRequest<TRes> where TRes : CommandResult
    {
        protected readonly IBusHandler _bus;

        public BaseCommandHandler(IBusHandler bus)
        {
            _bus = bus;
        }

        public async Task<TRes> Handle(TReq request, CancellationToken cancellationToken)
        {
            return await Execute(request);
        }

        public abstract Task<TRes> Execute(TReq request);

        protected async Task Notify(Command command, string message)
        {
            var notification = new DomainNotification(command.MessageType, message);

            await _bus.PublishNotification(notification);
        }

        public async Task Consume(ConsumeContext<TReq> context)
        {
            await Execute(context.Message);
        }
    }
}

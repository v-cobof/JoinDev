using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Communication.Messages;
using JoinDev.Domain.Core.Communication.Messages.Notifications;
using JoinDev.Domain.Core.Validation.Results;
using JoinDev.Domain.Data;
using MediatR;
using Rebus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Application.Commands.Handlers
{
    public abstract class BaseCommandHandler<TReq, TRes> : IHandleMessages<TReq>, IRequestHandler<TReq, TRes> where TReq : Command, IRequest<TRes> where TRes : CommandResult
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IBusHandler _bus;

        public BaseCommandHandler(IUnitOfWork uow, IBusHandler bus)
        {
            _uow = uow;
            _bus = bus;
        }

        public async Task Handle(TReq message)
        {
            await Execute(message);
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
    }
}

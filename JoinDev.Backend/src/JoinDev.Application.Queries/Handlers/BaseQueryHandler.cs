using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Communication.Messages;
using JoinDev.Domain.Core.Communication.Messages.Notifications;
using JoinDev.Domain.Core.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Application.Queries.Handlers
{
    public abstract class BaseQueryHandler<TReq, TRes> : IRequestHandler<TReq, QueryResult<TRes>> 
        where TReq : Query<TRes>, IRequest<QueryResult<TRes>> 
    {
        protected readonly IBusHandler _bus;

        public BaseQueryHandler(IBusHandler bus)
        {
            _bus = bus;
        }

        public abstract Task<QueryResult<TRes>> Handle(TReq request, CancellationToken cancellationToken);

        protected async Task Notify(Message request, string message)
        {
            var notification = new DomainNotification(request.MessageType, message);

            await _bus.PublishNotification(notification);
        }

        protected QueryResult<TRes> Failure()
        {
            return QueryResult<TRes>.Failure();
        }
    }
}

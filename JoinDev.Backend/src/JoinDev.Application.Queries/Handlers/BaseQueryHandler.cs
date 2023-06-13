using JoinDev.Application.Models;
using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Communication.Messages;
using JoinDev.Domain.Core.Communication.Messages.Notifications;
using JoinDev.Domain.Core.Results;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        protected FilterDefinition<ProjectReadModel> BuildFilter(List<Func<ProjectReadModel, bool>> conditions)
        {
            var expressions = MapFuncToExpressions(conditions);
            var builder = Builders<ProjectReadModel>.Filter;

            return expressions.Aggregate(
                builder.Empty,
                (current, condition) => current & builder.Where(condition));
        }

        protected List<Func<ProjectReadModel, bool>> GetValidFilters((bool, Func<ProjectReadModel, bool>)[] conditionsAndFilters)
        {
            return conditionsAndFilters
                .Where(t => t.Item1)
                .Select(t => t.Item2)
                .ToList();
        }

        protected QueryResult<TRes> Failure()
        {
            return QueryResult<TRes>.Failure();
        }

        private List<Expression<Func<ProjectReadModel, bool>>> MapFuncToExpressions(List<Func<ProjectReadModel, bool>> conditions)
        {
            return conditions.Select(condition =>
            {
                Expression<Func<ProjectReadModel, bool>> expression = x => condition(x);
                return expression;
            }).ToList();
        }
    }
}

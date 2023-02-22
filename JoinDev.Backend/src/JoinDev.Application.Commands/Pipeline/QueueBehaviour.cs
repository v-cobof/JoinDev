using JoinDev.Domain.Core.Communication.Messages;
using JoinDev.Domain.Core.Validation.Results;
using MassTransit;
using MediatR;
using Newtonsoft.Json;

namespace JoinDev.Application.Pipeline
{
    public class QueueBehaviour<TReq, TRes> : IPipelineBehavior<TReq, TRes> where TReq : Command, IRequest<TRes>, IQueueable where TRes : CommandResult
    {
        private readonly IBus _bus;

        public QueueBehaviour(IBus bus)
        {
            _bus = bus;
        }

        public async Task<TRes> Handle(TReq request, RequestHandlerDelegate<TRes> next, CancellationToken cancellationToken)
        {
            await _bus.Publish(request);

            return await Task.FromResult((TRes)CommandResult.Successful());
        }
    }
}

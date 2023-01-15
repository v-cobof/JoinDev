using JoinDev.Domain.Core.Communication.Messages;
using JoinDev.Domain.Core.Validation.Results;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Application.Commands.Handlers
{
    public abstract class BaseCommandHandler<TReq, TRes> : IConsumer<TReq>, IRequestHandler<TReq, TRes> where TReq : Command, IRequest<TRes> where TRes : CommandResult
    {
        public Task Consume(ConsumeContext<TReq> context)
        {
            return Execute(context.Message, context.CancellationToken);
        }

        public Task<TRes> Handle(TReq request, CancellationToken cancellationToken)
        {
            return Execute(request, cancellationToken);
        }

        public abstract Task<TRes> Execute(TReq request, CancellationToken cancellationToken);
    }
}

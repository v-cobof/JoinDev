using JoinDev.Domain.Core.Communication.Messages;
using JoinDev.Domain.Core.Validation.Results;
using MediatR;

namespace JoinDev.Application.Pipeline
{
    public class ValidationBehaviour<TReq, TRes> : IPipelineBehavior<TReq, TRes> where TReq : Command, IRequest<TRes> where TRes : CommandResult
    {
        public Task<TRes> Handle(TReq request, RequestHandlerDelegate<TRes> next, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return Task.FromResult((TRes)request.ValidationResult);
          
            return next();
        }
    }
}

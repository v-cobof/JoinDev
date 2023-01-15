using FluentValidation;
using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Communication.Messages;
using JoinDev.Domain.Core.Communication.Messages.Notifications;
using JoinDev.Domain.Core.Validation.Results;
using MediatR;

namespace JoinDev.Application.Pipeline
{
    public class ValidationBehaviour<TReq, TRes> : IPipelineBehavior<TReq, TRes> where TReq : Command, IRequest<TRes> where TRes : CommandResult
    {
        private readonly IEnumerable<IValidator<TReq>> _validators;
        private readonly IMediatorHandler _mediator;


        public ValidationBehaviour(IEnumerable<IValidator<TReq>> validators, IMediatorHandler mediator)
        {
            _validators = validators;
            _mediator = mediator;
        }

        public async Task<TRes> Handle(TReq request, RequestHandlerDelegate<TRes> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TReq>(request);

            var notifications = _validators
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .Select(x => new DomainNotification(request.MessageType, x.ErrorMessage))
                .ToList();

            if (notifications.Any())
            {
                await _mediator.PublishNotificationsBatch(notifications);

                return await Task.FromResult((TRes) CommandResult.Failure());
            }

            return await next();
        }
    }
}

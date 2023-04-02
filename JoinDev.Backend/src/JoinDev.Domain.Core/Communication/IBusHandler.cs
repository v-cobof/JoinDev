using JoinDev.Domain.Core.Communication.Messages;
using JoinDev.Domain.Core.Communication.Messages.Notifications;
using JoinDev.Domain.Core.Validation.Results;
using MediatR;

namespace JoinDev.Domain.Core.Communication
{
    public interface IBusHandler
    {
        Task PublishEvent<T>(T @event) where T : Event;

        Task<CommandResult> SendCommand<T>(T command) where T : Command;

        Task<TRes> SendQuery<TRes>(Query<TRes> query);

        Task PublishNotification<T>(T notificacao) where T : DomainNotification;

        Task PublishNotificationsBatch<T>(IEnumerable<T> notifications) where T : DomainNotification;

        Task PublishEventsBatch<T>(IEnumerable<T> notifications) where T : Event;
    }
}

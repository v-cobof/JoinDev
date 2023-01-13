using JoinDev.Domain.Core.Communication.Messages;
using JoinDev.Domain.Core.Validation.Results;
using MediatR;

namespace JoinDev.Domain.Core.Communication
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T @event) where T : Event;

        Task<CommandResult> SendCommand<T>(T command) where T : Command;
    }
}

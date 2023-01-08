using JoinDev.Domain.Core.Communication.Messages;
using MediatR;

namespace JoinDev.Infra.CrossCutting.Bus.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T @event) where T : Event;

        Task<Unit> SendCommand<T>(T command) where T : ICommand;
    }
}

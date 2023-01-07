using JoinDev.Domain.Core.Communication.Messages;

namespace JoinDev.Infra.CrossCutting.Bus.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T @event) where T : IEvent;

        Task<bool> SendCommand<T>(T command) where T : ICommand;
    }
}

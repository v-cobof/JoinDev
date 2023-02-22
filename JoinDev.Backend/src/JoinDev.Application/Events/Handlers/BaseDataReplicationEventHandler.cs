using JoinDev.Application.Data;
using MassTransit;

namespace JoinDev.Application.Events.Handlers
{
    public abstract class BaseDataReplicationEventHandler<TEvent, TModel> : IConsumer<TEvent> where TEvent : Domain.Core.Communication.Messages.Event
    {
        protected readonly IReplicationRepository<TModel> _repository;

        public BaseDataReplicationEventHandler(IReplicationRepository<TModel> repository)
        {
            _repository = repository;
        }

        public abstract Task Consume(ConsumeContext<TEvent> context);
    }
}

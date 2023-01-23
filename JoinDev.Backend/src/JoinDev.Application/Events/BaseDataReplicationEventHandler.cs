using JoinDev.Application.Data;
using Rebus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Application.Events
{
    public abstract class BaseDataReplicationEventHandler<TEvent, TModel> : IHandleMessages<TEvent> where TEvent : Domain.Core.Communication.Messages.Event
    {
        protected readonly IReplicationRepository<TModel> _repository;

        public BaseDataReplicationEventHandler(IReplicationRepository<TModel> repository)
        {
            _repository = repository;
        }

        public abstract Task Handle(TEvent message);
    }
}

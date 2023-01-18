using JoinDev.Domain.Core.Validation.Results;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Application.Events.Base
{
    public abstract class BaseEventHandler<T> : IConsumer<T>, INotificationHandler<T> where T : Domain.Core.Communication.Messages.Event
    {
        protected ConsumeContext<T> _context;

        public async Task Consume(ConsumeContext<T> context)
        {
            _context = context;
            await Execute(_context.Message, _context.CancellationToken);
        }

        public async Task Handle(T notification, CancellationToken cancellationToken)
        {
            await Execute(notification, cancellationToken);
        }

        public abstract Task Execute(T notification, CancellationToken cancellationToken);
    }
}

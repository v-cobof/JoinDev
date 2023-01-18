using MediatR;

namespace JoinDev.Domain.Core.Communication.Messages
{
    public abstract class Event : Message, INotification
    {
        public Guid AggregateId { get; protected set; }

        public DateTime Timestamp { get; protected set; }

        public Event()
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}

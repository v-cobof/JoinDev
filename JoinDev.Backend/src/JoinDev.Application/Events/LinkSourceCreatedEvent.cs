using JoinDev.Domain.Core.Communication.Messages;

namespace JoinDev.Application.Events
{
    public class LinkSourceCreatedEvent : Event
    {
        public string Name { get; set; }

        public LinkSourceCreatedEvent(Guid Id, string name)
        {
            AggregateId = Id;
            Name = name;
        }
    }
}

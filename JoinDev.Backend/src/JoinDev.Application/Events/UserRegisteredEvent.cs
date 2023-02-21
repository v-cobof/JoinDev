using JoinDev.Application.Models;
using JoinDev.Domain.Core.Communication.Messages;

namespace JoinDev.Application.Events
{
    public class UserRegisteredEvent : Event
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public UserRegisteredEvent(Guid aggregateId, string name, string email)
        {
            AggregateId = aggregateId;
            Name = name;
            Email = email;
        }

        protected UserRegisteredEvent() { }
    }
}

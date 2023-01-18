using JoinDev.Domain.Core.Communication.Messages;

namespace JoinDev.Domain.Events
{
    public class UserRegisteredEvent : Event
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserRegisteredEvent(Guid aggregateId, string fullName, string email, string password)
        {
            AggregateId = aggregateId;
            Name = fullName;
            Email = email;
            Password = password;
        }
    }
}

using JoinDev.Application.Models;
using JoinDev.Domain.Core.Communication.Messages;
using JoinDev.Domain.Entities;

namespace JoinDev.Application.Events
{
    public class UserRegisteredEvent : Event
    {
        public UserModel User { get; set; }

        public UserRegisteredEvent(User user)
        {
            User = user;
        }

        protected UserRegisteredEvent() { }
    }
}

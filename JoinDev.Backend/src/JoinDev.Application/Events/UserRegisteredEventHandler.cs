using JoinDev.Application.Data;
using JoinDev.Application.Models;
using JoinDev.Domain.Events;
using MassTransit;

namespace JoinDev.Application.Events
{
    public class UserRegisteredEventHandler : BaseDataReplicationEventHandler<UserRegisteredEvent, User>
    {
        public UserRegisteredEventHandler(IReplicationRepository<User> repository) : base(repository)
        {
        }

        public override Task Consume(ConsumeContext<UserRegisteredEvent> context)
        {
            
        }
    }
}

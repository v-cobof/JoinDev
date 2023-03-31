using JoinDev.Application.Data;
using JoinDev.Application.Models;
using JoinDev.Application.Events;
using MassTransit;

namespace JoinDev.Application.Events.Handlers
{
    public class UserRegisteredEventHandler : BaseDataReplicationEventHandler<UserRegisteredEvent, UserModel>
    {
        public UserRegisteredEventHandler(IReplicationRepository<UserModel> repository) : base(repository)
        {
        }

        public async override Task Consume(ConsumeContext<UserRegisteredEvent> context)
        {
            var user = context.Message.User;

            await _repository.Create(user);
        }
    }
}

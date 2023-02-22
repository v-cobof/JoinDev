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
            var message = context.Message;

            var user = new UserModel()
            {
                Id = message.AggregateId,
                Name = message.Name,
                Email = message.Email,
            };

            await _repository.Create(user);
        }
    }
}

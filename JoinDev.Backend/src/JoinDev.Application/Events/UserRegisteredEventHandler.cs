using JoinDev.Application.Data;
using JoinDev.Application.Models;
using JoinDev.Domain.Events;
using MassTransit;

namespace JoinDev.Application.Events
{
    public class UserRegisteredEventHandler : BaseDataReplicationEventHandler<UserRegisteredEvent, UserModel>
    {
        public UserRegisteredEventHandler(IReplicationRepository<UserModel> repository) : base(repository)
        {
        }

        public async override Task Consume(ConsumeContext<UserRegisteredEvent> context)
        {
            var msg = context.Message;

            var user = new UserModel()
            {
                Id = msg.AggregateId,
                Name = msg.Name,
                Email = msg.Email,
            };

            await _repository.Create(user);
        }
    }
}

using JoinDev.Application.Data;
using JoinDev.Application.Models;
using JoinDev.Domain.Events;

namespace JoinDev.Application.Events
{
    public class UserRegisteredEventHandler : BaseDataReplicationEventHandler<UserRegisteredEvent, UserModel>
    {
        public UserRegisteredEventHandler(IReplicationRepository<UserModel> repository) : base(repository)
        {
        }

        public async override Task Handle(UserRegisteredEvent message)
        {
            var user = new UserModel()
            {
                _id = message.AggregateId,
                Name = message.Name,
                Email = message.Email,
            };

            await _repository.Create(user);
        }
    }
}

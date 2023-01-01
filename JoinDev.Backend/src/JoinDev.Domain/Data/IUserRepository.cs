using JoinDev.Domain.Core.Data;
using JoinDev.Domain.Entities;


namespace JoinDev.Domain.Data
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetById(Guid id);

        void Create(User user);

    }
}

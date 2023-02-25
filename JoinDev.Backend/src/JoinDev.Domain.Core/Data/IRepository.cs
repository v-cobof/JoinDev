using JoinDev.Domain.Core.DomainObjects;

namespace JoinDev.Domain.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }

        Task<T> GetById(Guid id);

        void Create(T entity);

        void Update(T entity);
    }
}

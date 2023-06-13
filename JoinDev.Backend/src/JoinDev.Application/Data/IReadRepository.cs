using MongoDB.Driver;
using System.Linq.Expressions;

namespace JoinDev.Application.Data
{
    public interface IReadRepository<T>
    {
        Task<IAsyncCursor<T>> FindAsync(Expression<Func<T, bool>> filter, FindOptions<T, T> options = null, CancellationToken cancellationToken = default(CancellationToken));

        Task<IAsyncCursor<T>> FindAsync(FilterDefinition<T> filter, FindOptions<T, T> options = null, CancellationToken cancellationToken = default(CancellationToken));

        IFindFluent<T, T> Find(FilterDefinition<T> filter, FindOptions options = null);

        IFindFluent<T, T> Find(Expression<Func<T, bool>> filter, FindOptions options = null);
    }
}

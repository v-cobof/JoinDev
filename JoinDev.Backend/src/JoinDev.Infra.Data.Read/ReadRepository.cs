using JoinDev.Application.Data;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Infra.Data.Read
{
    public class ReadRepository<T> : IReadRepository<T>
    {
        private readonly MongoDbContext _context;
        private IMongoCollection<T> Collection => _context.Database.GetCollection<T>(typeof(T).Name);

        public ReadRepository(MongoDbContext context)
        {
            _context = context;
        }

        public Task<IAsyncCursor<T>> FindAsync(Expression<Func<T, bool>> filter, FindOptions<T, T> options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Collection.FindAsync(filter, options, cancellationToken);
        }

        public Task<IAsyncCursor<T>> FindAsync(FilterDefinition<T> filter, FindOptions<T, T> options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Collection.FindAsync(filter, options, cancellationToken);
        }

        public IFindFluent<T, T> Find(FilterDefinition<T> filter, FindOptions options = null)
        {
            return Collection.Find(filter, options);
        }

        public IFindFluent<T, T> Find(Expression<Func<T, bool>> filter, FindOptions options = null)
        {
            return Collection.Find(filter, options);
        }
    }
}

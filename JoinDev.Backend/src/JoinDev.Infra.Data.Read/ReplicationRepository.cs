using JoinDev.Application.Data;
using MongoDB.Driver;

namespace JoinDev.Infra.Data.Read
{
    public class ReplicationRepository<T> : IReplicationRepository<T>
    {
        private readonly MongoDbContext _context;
        private IMongoCollection<T> _collection => _context.Database.GetCollection<T>(typeof(T).Name);

        public ReplicationRepository(MongoDbContext context)
        {
            _context = context;
        }

        public async Task Create(T model)
        {
            await _collection.InsertOneAsync(model);
        }

        public Task Update(T model)
        {
            throw new Exception();
        }
    }
}
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace JoinDev.Infra.Data.Read
{
    public class MongoDbContext
    {
        public IMongoDatabase Database { get; }

        public MongoDbContext(IOptions<ReadDatabaseSettings> mongoDBSettings)
        {
            var client = new MongoClient(mongoDBSettings.Value.ConnectionURI);

            Database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        }
    }
}

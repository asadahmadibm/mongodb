using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MongoDbWithEf.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;
        public MongoDbContext(IOptions<MongoDbConfiguration> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }
        public IMongoCollection<Article> Articles =>
       _database.GetCollection<Article>("Articles");
    }
}

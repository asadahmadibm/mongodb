using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbWithEf.Data
{
    public class Article
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}

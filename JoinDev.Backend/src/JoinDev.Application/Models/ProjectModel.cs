using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JoinDev.Application.Models
{
    public class ProjectModel
    {
        [BsonId]
        public ObjectId _id { get; }


    }
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JoinDev.Application.Models
{
    public abstract class BaseModel
    {
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        [BsonId]
        public Guid Id { get; set; }
    }
}

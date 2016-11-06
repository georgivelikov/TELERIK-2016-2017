using Chat.Models.Contracts;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Chat.Models
{
    public class Message : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; set; }

        public string Username { get; set; }

        public string Text { get; set; }
    }
}

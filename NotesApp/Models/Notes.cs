using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NotesAppAPI.Models
{
    public class Note
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        
        [BsonElement("Title")]
        public string Title { get; set; } = null!;
        
        [BsonElement("Content")]
        public string Content { get; set; } = null!;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

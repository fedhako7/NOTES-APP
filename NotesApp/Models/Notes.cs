using System;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title can't be longer than 100 characters")]
        public string Title { get; set; } = null!;

        [BsonElement("Content")]
        [Required(ErrorMessage = "Content is required")]
        [StringLength(1500, ErrorMessage = "Content can't be longer than 1500 characters")]
        public string Content { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

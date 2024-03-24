using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ToDoListAPI.Entities
{
    public class TaskItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Title")]
        public string? Title { get; set; }

        [BsonElement("Description")]
        public string? Description { get; set; }

        [BsonElement("CreateDate")]
        public DateTime CreateDate { get; set; }

        [BsonElement("Status")]
        public string? Status { get; set; }
    }
}
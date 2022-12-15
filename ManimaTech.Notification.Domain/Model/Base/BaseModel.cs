using MongoDB.Bson.Serialization.Attributes;

namespace ManimaTech.Notification.Domain.Model.Base
{
    public class BaseModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? UpdatedAt { get; set; }
    }
}

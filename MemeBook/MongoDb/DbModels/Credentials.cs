using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MemeBook.MongoDb.DbModels
{
    public class Credentials
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int User_ID { get; set; }
        [BsonElement("UserName")]public string UserName { get; set; }
        [BsonElement("Password")]public string Password { get; set; }
    }
}
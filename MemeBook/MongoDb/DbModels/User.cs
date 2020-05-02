using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MemeBook.MongoDb.DbModels
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int User_ID { get; set; }
        [BsonElement("FName")] public string FName { get; set; }
        [BsonElement("LName")]public string LName { get; set; }
        [BsonElement("Age")]public int Age { get; set; }
        [BsonElement("Post_ID")]public List<int> Post_ID { get; set; }
        [BsonElement("Logged_in")]public bool Logged_in { get; set; }
        [BsonElement("Blocked")]public List<int> Blocked { get; set; }
    }
}
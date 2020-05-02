using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MemeBook.MongoDb.DbModels
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Post_id { get; set; }
        [BsonElement("Owner_id")] public int Owner_id { get; set; }
        [BsonElement("Content")] public string Content { get; set; }
        [BsonElement("Circle_ID")]public int Circle_ID { get; set; }
        [BsonElement("Comment_ID")]public int Comment_ID { get; set; }
        [BsonElement("IsPublic")] public bool IsPublic { get; set; } = true;
        [BsonElement("Likes")] public int Likes { get; set; } = 0;
        [BsonElement("Dislikes")] public int Dislikes { get; set; } = 0;
    }
}

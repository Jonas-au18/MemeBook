using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MemeBook.MongoDb.DbModels
{
    public class Comment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Comment_ID { get; set; }
        [BsonElement("Comment_owner")] public int Comment_owner { get; set; }
        [BsonElement("Content")] public string Content { get; set; }
        [BsonElement("Likes")] public int Likes { get; set; }
        [BsonElement("Dislikes")] public int Dislikes { get; set; }
    }
}

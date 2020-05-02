using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MemeBook.MongoDb.DbModels
{
    public class Circles
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Circle_ID { get; set; }
        [BsonElement("Circle_members")] public List<int> Circle_members { get; set; }

    }
}

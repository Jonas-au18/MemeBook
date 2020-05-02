using System.Collections.Generic;
using MemeBook.MongoDb.DbModels;
using MemeBook.MongoDb.Services;

namespace MemeBook.MongoDb.Queries
{
    public class Create
    {
        private readonly CircleService _Circle;
        private readonly UserService _User;
        private readonly PostService _Post;

        public Create()
        {
            _Circle = new CircleService();
            _User = new UserService();
            _Post = new PostService();
        }

        
    }
}
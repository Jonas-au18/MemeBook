using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemeBook.MongoDb.DbModels;
using Microsoft.AspNetCore.Components.Forms;
using MongoDB.Driver;

namespace MemeBook.MongoDb.Services
{
    public class PostService
    {
        private readonly IMongoCollection<Post> _posts;

        public PostService()
        {
            var client = new MongoClient("mongodb://localhost:50000");
            var database = client.GetDatabase("MemeBook");

            _posts = database.GetCollection<Post>("Post");
        }

        public List<Post> GetCirclePost(Circles cirle)
        {
            return _posts.Find(m => m.Circle_ID == cirle.Circle_ID).ToList();
        }

        public List<Post> GetPostsForUser(User user)
        {
            return _posts.Find(m => m.Owner_id == user.User_ID).ToList();
        }

        public List<Post> GetPostsByUserID(int id)
        {
            return _posts.Find(m => m.Owner_id == id && m.IsPublic == true).ToList();
        }

        public void UpdatePost(Post post, User user)
        {
            _posts.ReplaceOne(m => m.Post_id == post.Post_id && m.Owner_id == user.User_ID, post);
        }

        public void DeletePost(Post post, User user)
        {
            _posts.DeleteOne(m => m.Post_id == post.Post_id && m.Owner_id == user.User_ID);
        }

        public void CreatePost(Post post)
        {
            _posts.InsertOne(post);
        }

    }
}

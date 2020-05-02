using System.Collections.Generic;
using MemeBook.MongoDb.DbModels;
using MemeBook.MongoDb.Services;
using MongoDB.Driver.Core.Operations;

namespace MemeBook.MongoDb.Queries
{
    public class View
    {
        private readonly CircleService _circle;
        private readonly UserService _user;
        private readonly PostService _post;

        public View()
        {
            _circle = new CircleService();
            _user = new UserService();
            _post = new PostService();
        }

        public List<Post> Feed(User user)
        {
            List<Post> FeedPosts = new List<Post>();
            var usersCircles = _circle.GetByUser(user);
            foreach (var i in usersCircles)
            {
                List<Post> temp = _post.GetCirclePost(i);
                foreach (var j in temp)
                {
                    FeedPosts.Add(j);   
                }
            }
            return FeedPosts;
        }

        public List<Post> Wall(int userid,int guestid)
        {
            List<Post> WallPosts = new List<Post>();
            var user = _user.GetUser(userid);
            if (!user.Blocked.Contains(guestid))
            {
                WallPosts = _post.GetPostsByUserID(userid);
                return WallPosts;
            }

            return null;
        }
    }
}



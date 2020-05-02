using System.Collections.Generic;
using MemeBook.MongoDb.DbModels;
using MongoDB.Driver;

namespace MemeBook.MongoDb.Services
{
    public class CircleService
    {
        private readonly IMongoCollection<Circles> _Circles;

        public CircleService()
        {
            var client = new MongoClient("mongodb://localhost:50000");
            var database = client.GetDatabase("MemeBook");

            _Circles = database.GetCollection<Circles>("Circles");
        }

        public Circles GetById(int id)
        {
            return _Circles.Find(Circles => Circles.Circle_ID == id).FirstOrDefault();
        }

        public List<Circles> GetByUser(User user)
        {
            return _Circles.Find(m => m.Circle_members.Contains(user.User_ID)).ToList();

      
        }

        public void AddUser(User user,Circles circle)
        {
            circle.Circle_members.Add(user.User_ID);
            _Circles.ReplaceOne(m => m.Circle_ID == circle.Circle_ID,circle);
        }

        public void CreateCircle(User user)
        {
            Circles myCircles = new Circles();
            myCircles.Circle_members.Add(user.User_ID);
            _Circles.InsertOne(myCircles);
        }

        public void RemoveUser(User user, Circles circle)
        {
            _Circles.DeleteOne(m => m.Circle_members.Contains(user.User_ID));
        }

        public void RemoveCircle(Circles circle)
        {
            _Circles.DeleteOne(m => m.Circle_ID == circle.Circle_ID);
        }
    }
}
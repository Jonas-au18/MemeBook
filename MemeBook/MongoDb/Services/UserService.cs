using System;
using System.Collections.Generic;
using MemeBook.MongoDb.DbModels;
using MongoDB.Driver;

namespace MemeBook.MongoDb.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _Users;
        public UserService()
        {
            var client = new MongoClient("mongodb://localhost:50000");
            var database = client.GetDatabase("MemeBook");
            _Users = database.GetCollection<User>("Users");
        }

        public User GetUser(int userID)
        {
            return _Users.Find(User => User.User_ID == userID).FirstOrDefault();
        }

        public List<User> FindUsers(string Fname)
        {
            return _Users.Find(m => m.FName == Fname).ToList();
        }

        public List<User> FindUsers(string Fname, string Lname)
        {
            return _Users.Find(m => m.FName == Fname && m.LName == Lname).ToList();
        }

        public void CreateUser(User user)
        {
            _Users.InsertOne(user);
        }

        public void UpdateUser(User user)
        {
            _Users.ReplaceOne(m => m.User_ID == user.User_ID, user);
        }

        public void RemoveUser(User user)
        {
            _Users.DeleteOne(m => m.User_ID == user.User_ID);
        }
    }
}
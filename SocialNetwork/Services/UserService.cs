using System;
using System.Collections.Generic;
using MongoDB.Driver;
using SocialNetwork.Models;

namespace SocialNetwork.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("SocialNetworkDb");

            _users = database.GetCollection<User>("Users");
        }

        public List<User> Get()
        {
            return _users.Find(user => true).ToList();
        }

        public User Get(string id)
        {
            return _users.Find(user => user.Id == id).FirstOrDefault();
        }

        public User GetUserFromName(string name)
        {
            var listUsers = _users.Find(x => x.Name == name).ToList();
            return listUsers[0]; 
        }

        public Circle GetCircleFromCircleNumber(User user, int number)
        {
            return user.Circles.Find(x => x.CircleNumber == number);
        }

        public List<Circle> GetCirclesThatIncludeUser(User user)
        {
            var users = Get();
            var circleList = new List<Circle>();
            foreach (var u in users)
            {
                var hasUser = u.Circles.Find(x => x.CircleMembers.Contains(user.Id));
                if (hasUser != null)
                {
                    circleList.Add(hasUser);
                }
            }

            return circleList;
        }

        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void Update(string id, User userIn)
        {
            _users.ReplaceOne(user => user.Id == id, userIn);
        }

        public void Remove(User userIn)
        {
            _users.DeleteOne(user => user.Id == userIn.Id);
        }

        public void Remove(string id)
        {
            _users.DeleteOne(user => user.Id == id);
        }

        public void RemoveAll()
        {
            _users.DeleteMany(user => user.Id != null);
        }
    }
}
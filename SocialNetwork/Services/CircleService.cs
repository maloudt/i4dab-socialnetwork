using System.Collections.Generic;
using MongoDB.Driver;
using SocialNetwork.Models;

namespace SocialNetwork.Services
{
    public class CircleService
    {
        private readonly IMongoCollection<Circle> _circles;

        public CircleService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("SocialNetworkDb");

            _circles = database.GetCollection<Circle>("Circles");
        }

        public List<Circle> Get()
        {
            return _circles.Find(circle => true).ToList();
        }

        public Circle Get(string id)
        {
            return _circles.Find(circle => circle.Id == id).FirstOrDefault();
        }

        public Circle Create(Circle circle)
        {
            _circles.InsertOne(circle);
            return circle;
        }

        public void Update(string id, Circle circleIn)
        {
            _circles.ReplaceOne(circle => circle.Id == id, circleIn);
        }

        public void Remove(Circle circleIn)
        {
            _circles.DeleteOne(circle => circle.Id == circleIn.Id);
        }

        public void Remove(string id)
        {
            _circles.DeleteOne(circle => circle.Id == id);
        }
    }
}
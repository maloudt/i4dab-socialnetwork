using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SocialNetwork.Services;

namespace SocialNetwork.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")] public string Name { get; set; }
        [BsonElement("Age")] public int Age { get; set; }
        [BsonElement("Gender")] public string Gender { get; set; }
        [BsonElement("Circles")] public List<Circle> Circles { get; set; }
        [BsonElement("Blocked Users")] public List<string> BlockedUsers { get; set; }
    }
}
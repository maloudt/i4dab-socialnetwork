using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SocialNetwork.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Age")]
        public int Age { get; set; }
        [BsonElement("Gender")]
        public string Gender { get; set; }

        [BsonElement("Circle Members")]
        public List<string> CircleMembers { get; set; }
        [BsonElement("Blocked Users")]
        public List<string> BlockedUsers { get; set; }

        public override string ToString()
        {
            return $"User({Id}, {Name}, {Age}, {Gender}, {CircleMembers}, {BlockedUsers})";
        }
    }
}
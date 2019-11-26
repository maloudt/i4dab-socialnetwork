using System;
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
        public BsonArray CircleMembers { get; set; }
        [BsonElement("Blocked Users")]
        public BsonArray BlockedUsers { get; set; }

        public override string ToString()
        {
            return $"User({Id}, {Name}, {Age}, {Gender}, {CircleMembers}, {BlockedUsers})";
        }
    }
}
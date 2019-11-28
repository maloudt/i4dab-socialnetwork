using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SocialNetwork.Models
{
    public class Circle
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("User")] public string User { get; set; }
        [BsonElement("Members")] public List<string> Members { get; set; }

        public override string ToString()
        {
            return $"User({Id}, {User}, {Members})";
        }

    }
}
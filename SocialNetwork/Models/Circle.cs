using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SocialNetwork.Models
{
    public class Circle
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        //public string Id { get; set; }

        [BsonElement("CircleNumber")] public int CircleNumber { get; set; }
        [BsonElement("Circle Members")] public List<string> CircleMembers { get; set; }

        //public override string ToString()
        //{
        //    return $"User({CircleNumber}, {CircleMembers})";
        //}

    }
}
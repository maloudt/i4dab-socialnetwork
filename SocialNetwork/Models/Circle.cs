using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SocialNetwork.Models
{
    public class Circle
    {
        [BsonElement("Circle Number")] public int CircleNumber { get; set; }
        [BsonElement("Circle Members")] public List<string> CircleMembers { get; set; }
    }
}
﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SocialNetwork.Models
{
    public class Comment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Author")]
        public string Author { get; set; }
        [BsonElement("Text")]
        public string Text { get; set; }
    }
}
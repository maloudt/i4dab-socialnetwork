using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SocialNetwork.Models
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Author")]
        public string Author { get; set; }
        [BsonElement("Post Type")]
        public string PostType { get; set; }
        [BsonElement("Visibility")]
        public string Visibility { get; set; }
        [BsonElement("Content")]
        public string Content { get; set; }
        [BsonElement("Creation Time")]
        public DateTime CreationTime { get; set; }
        
        [BsonElement("Comments")]
        public BsonArray Comments { get; set; }
    }
}
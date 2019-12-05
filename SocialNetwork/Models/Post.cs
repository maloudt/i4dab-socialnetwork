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

        [BsonElement("Post Author ID")] public string PostAuthor { get; set; }
        [BsonElement("Post Type")] public string PostType { get; set; }
        [BsonElement("Post Content")] public string PostContent { get; set; }
        [BsonElement("Creation Time")] public DateTime CreationTime { get; set; }
        [BsonElement("Circles")] public List<Circle> Circles { get; set; }
        [BsonElement("Comments")] public List<Comment> Comments { get; set; }

        //public override string ToString()
        //{
        //    return $"Post({Id}, {PostAuthor}, {PostType}, {PostContent}, {CreationTime}, {Circles}, {Comments})";
        //}
    }
}
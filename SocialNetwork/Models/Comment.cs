using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SocialNetwork.Models
{
    public class Comment
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        //public string Id { get; set; }

        [BsonElement("Comment Author ID")] public string CommentAuthor { get; set; }
        [BsonElement("Comment Text")] public string CommentText { get; set; }
        [BsonElement("Creation Time")] public DateTime CreationTime { get; set; }

        //public override string ToString()
        //{
        //    return $"User({CommentAuthor}, {CommentText}, {CreationTime})";
        //}

    }
}
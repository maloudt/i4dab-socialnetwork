using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SocialNetwork.Models
{
    public class Comment
    {
        [BsonElement("Comment Author")] public string CommentAuthor { get; set; }
        [BsonElement("Comment Text")] public string CommentText { get; set; }
        [BsonElement("Creation Time")] public DateTime CreationTime { get; set; }

        //public override string ToString()
        //{
        //    return $"User({CommentAuthor}, {CommentText}, {CreationTime})";
        //}

    }
}
using System;
using System.Collections.Generic;
using MongoDB.Bson;
using SocialNetwork.Models;

namespace SocialNetwork.DataSeeder
{
    class SeedPosts : ISeed
    {
        public void Seed()
        {
            var post1 = new Post
            {
                PostAuthor = new User(),
                PostType = "Text",
                PostContent = "Hello everyone!",
                CreationTime = DateTime.Now,
                Circles = new List<Circle>(),
                Comments = new List<Comment>()
            };

            post1.Comments.Add(new Comment
                {
                    CommentAuthor = "Lars Kolund",
                    CommentText = "",
                    CreationTime = DateTime.Now
                }
            );

            Program.postService.Create(post1);

        }
    }
}

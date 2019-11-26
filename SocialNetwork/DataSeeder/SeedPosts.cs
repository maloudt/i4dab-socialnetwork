using System;
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
                Author = "some-id",
                PostType = "Text",
                Visibility = "Public",
                Content = "Hello everyone!",
                CreationTime = DateTime.Now,
                Comments = new BsonArray() { "4a", "3b" }
            };
            Program.postService.Create(post1);

        }
    }
}

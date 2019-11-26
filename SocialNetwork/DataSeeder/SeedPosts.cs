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
                Author = "some-id",
                PostType = "Text",
                Visibility = "Public",
                Content = "Hello everyone!",
                CreationTime = DateTime.Now,
                Comments = new List<string>() {}
            };
            Program.postService.Create(post1);

        }
    }
}

using System;
using System.Collections.Generic;
using MongoDB.Bson;
using SocialNetwork.Models;
using SocialNetwork.Services;

namespace SocialNetwork
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var userService = new UserService();
            var postService = new PostService();
            var commentService = new CommentService();

            var users = userService.Get();
            var posts = postService.Get();
            var comments = commentService.Get();

            var user1 = new User {Name = "Lars Kolund", Age = 27, Gender = "Male", CircleMembers = new BsonArray(){"1a", "1b"}, BlockedUsers = new BsonArray(){"1c", "1d"} };

            userService.Create(user1);

            foreach (var u in users) Console.WriteLine(u);
        }
    }
}
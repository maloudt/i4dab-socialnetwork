using System;
using System.Collections.Generic;
using MongoDB.Bson;
using SocialNetwork.DataSeeder;
using SocialNetwork.Models;
using SocialNetwork.Services;

namespace SocialNetwork
{
    internal class Program
    {
        public static UserService userService;
        public static PostService postService;
        public static CommentService commentService;
        public static List<User> users;
        public static List<Post> posts;
        public static List<Comment> comments;

        private static void Main(string[] args)
        {
            //var userService = new UserService();
            //var postService = new PostService();
            //var commentService = new CommentService();

            //var users = userService.Get();
            //var posts = postService.Get();
            //var comments = commentService.Get();

            userService = new UserService();
            postService = new PostService();
            commentService = new CommentService();

            var userSeeder = new SeedUsers();
            var postSeeder = new SeedPosts();
            var commentSeeder = new SeedComments();
            userSeeder.Seed();
            //postSeeder.Seed();
            //commentSeeder.Seed();


            users = userService.Get();
            posts = postService.Get();
            comments = commentService.Get();

            var printer = new Printer();
            printer.PrintStartScreen();

            

            //foreach (var u in users) Console.WriteLine(u);
            //foreach (var p in posts) Console.WriteLine(p);

        }
    }
}
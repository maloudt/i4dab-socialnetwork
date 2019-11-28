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
        public static CircleService circleService;
        public static List<User> users;
        public static List<Post> posts;
        public static List<Comment> comments;
        public static List<Circle> circles;

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
            circleService = new CircleService();

            var userSeeder = new SeedUsers();
            var postSeeder = new SeedPosts();
            var commentSeeder = new SeedComments();
            var circleSeeder = new SeedCircles();
            //userSeeder.Seed();
            //postSeeder.Seed();
            //commentSeeder.Seed();
            //circleSeeder.Seed();


            users = userService.Get();
            posts = postService.Get();
            comments = commentService.Get();
            circles = circleService.Get();

            var printer = new Printer();
            printer.PrintStartScreen();

            

            //foreach (var u in users) Console.WriteLine(u);
            //foreach (var p in posts) Console.WriteLine(p);

        }
    }
}
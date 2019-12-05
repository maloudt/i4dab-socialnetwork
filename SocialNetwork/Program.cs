using System;
using System.Collections.Generic;
using MongoDB.Bson;
using SocialNetwork.Models;
using SocialNetwork.Services;

namespace SocialNetwork
{
    internal class Program
    {
        //public static UserService userService;
        //public static PostService postService;
        //public static List<User> users;
        //public static List<Post> posts;

        private static void Main(string[] args)
        {
            // create services
            //var userService = new UserService();
            //var postService = new PostService();

            // create seeders
            var seeder = new DataSeeder();


            // seed database
            seeder.Seed();
            
            
            //userService.RemoveAll(); // remove all users
            //postService.RemoveAll(); // remove all posts

            // get all documents for each entity
            //var users = userService.Get();
            //var posts = postService.Get();

            // change age of user with id 5ddf94f488c93b464c45dc34
            //var userTest = userService.Get("5ddf94f488c93b464c45dc34");
            //userTest.Age = 35;
            //userService.Update("5ddf94f488c93b464c45dc34", userTest);

            // print result
            var printer = new Printer();
            printer.PrintStartScreen();


            //foreach (var u in users) Console.WriteLine(u);
            //foreach (var p in posts) Console.WriteLine(p);

        }
    }
}
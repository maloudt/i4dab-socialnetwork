using System;
using System.Collections.Generic;
using System.Text;
using SocialNetwork.Models;
using SocialNetwork.Services;

namespace SocialNetwork
{
    class Printer
    {
        private readonly List<User> _users;
        private readonly List<Post> _posts;

        public Printer()
        {
            var userService = new UserService();
            var postService = new PostService();
            _users = userService.Get();
            _posts = postService.Get();
        }

        public void PrintStartScreen()
        {
            

            Console.WriteLine("All users:");
            foreach (var u in _users) Console.WriteLine($"{u.Id}, {u.Name}, {u.Age}, {u.Gender}, #C: {u.Circles.Count}, #B: {u.BlockedUsers.Count}");
            //Console.WriteLine();
            //Console.WriteLine("Enter a user name to log in");
            //var currentUser = Console.ReadLine();
        }

        public void PrintCreatePost()
        {
            Console.WriteLine("Create new post:");
            Console.WriteLine("Parameters: author ID, postType (text, image or video), [circle1, circle2, circleN]");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using SocialNetwork.Models;
using SocialNetwork.Queries;
using SocialNetwork.Services;
using static System.ConsoleKey;

namespace SocialNetwork
{
    class Printer
    {
        private readonly UserService _userService;
        private readonly List<User> _users;
        private readonly Views _view;
        private readonly Creations _creation;

        public Printer()
        {
            _userService = new UserService();
            _users = _userService.Get();
            _view = new Views();
            _creation = new Creations();
        }

        public void PrintStartScreen()
        {
            Console.WriteLine("All users:");
            foreach (var u in _users) Console.WriteLine($"  {u.Name}, {u.Age}, {u.Gender}");

            Console.WriteLine("What do you wish to do?");
            Console.WriteLine(" 1: View feed");
            Console.WriteLine(" 2: View wall");
            Console.WriteLine(" 3: Create post");


            var input = Console.ReadKey();
            Console.WriteLine();

            switch (input.Key)
            {
                case D1:
                    PrintFeed();
                    break;
                case D2:
                    PrintWall();
                    break;
                case D3:
                    PrintCreatePost();
                    break;
            }
        }

        public void PrintWall()
        {
            Console.WriteLine("Who do you wish to log in as?");
            var loggedIn = _userService.GetUserFromName(Console.ReadLine());

            Console.WriteLine("Which users wall do you want to see?");
            var user = _userService.GetUserFromName(Console.ReadLine());

            _view.ViewUserWall(loggedIn, user);
        }

        public void PrintFeed()
        {
            Console.WriteLine("Which users feed do you want to see?");
            var user = _userService.GetUserFromName(Console.ReadLine());

            _view.ViewUserFeed(user);
        }

        public void PrintCreatePost()
        {
            Console.WriteLine("Create new post:");
            Console.WriteLine("Who is the author of the post?");
            var name = Console.ReadLine();
            var user = _userService.GetUserFromName(name);
            Console.WriteLine("What type of post? (text, image or video)");
            var type = Console.ReadLine();
            Console.WriteLine("What of the following circles should the post be visible in? (input fx: '1, 2')");
            foreach (var c in user.Circles)
            {
                Console.Write($"{c.CircleNumber}, ");
            }

            Console.WriteLine();
            var circleString = Console.ReadLine();
            var circleSplit = circleString.Split(",").Select(int.Parse).ToList();
            var circleList = new List<Circle>();

            foreach (var c in circleSplit)
            {
                circleList.Add(_userService.GetCircleFromCircleNumber(user, c));
            }

            Console.WriteLine("Enter post content (text, image url or video url)");
            var content = Console.ReadLine();

            _creation.CreatePost(user, type, content, circleList);
            
            Console.WriteLine("Post created");
        }

        public void PrintCreateComment()
        {
            Console.WriteLine("Create new comment:");

            Console.WriteLine("Who is the author of the comment?");
            var name = Console.ReadLine();

            var user = _userService.GetUserFromName(name);

            Console.WriteLine("Enter comment text:");
            var content = Console.ReadLine();

            //creation.CreateComment(user, post, content);
            //Console.WriteLine("Comment created");
        }
    }
}

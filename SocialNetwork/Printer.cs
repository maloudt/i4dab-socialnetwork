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
        public User LoggedIn { get; set; } = null;

        public Printer()
        {
            _userService = new UserService();
            _users = _userService.Get();
            _view = new Views();
            _creation = new Creations();
        }

        public void PrintStartScreen()
        {
            if (LoggedIn == null)
            {
                Console.WriteLine(" 1: Log in");
                Console.WriteLine(" 2: Create user");
                Console.WriteLine(" 3: View user profile/wall");
            }

            else
            {
                Console.WriteLine(" 1: View feed");
                Console.WriteLine(" 2: View user profile/wall");
                Console.WriteLine(" 3: View/edit circles");
                Console.WriteLine(" 4: Create post");
                Console.WriteLine(" 5: Log out");
            }


            var input = Console.ReadKey();
            Console.WriteLine();

            if (LoggedIn == null)
            {
                try
                {
                    switch (input.Key)
                    {
                        case D1:
                            PrintLogin();
                            break;
                        case D2:
                            PrintCreateUser();
                            break;
                        case D3:
                            PrintWall();
                            break;
                        default:
                            break;
                    }
                }

                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine("---\nUknown command, please try again\n---\n");
                }
            }
            else
            {
                try
                {
                    switch (input.Key)
                    {
                        case D1:
                            PrintFeed();
                            break;
                        case D2:
                            PrintWall();
                            break;
                        case D3:
                            PrintCircles();
                            break;
                        case D4:
                            PrintCreatePost();
                            break;
                        case D5:
                            PrintLogout();
                            break;
                        default:
                            break;
                    }
                }

                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine("---\nUknown command, please try again\n---\n");
                }
            }

        }

        public void PrintLogin()
        {
            Console.WriteLine("Log in as:");
            LoggedIn = _userService.GetUserFromName(Console.ReadLine());
        }

        public void PrintLogout()
        {
            LoggedIn = null;
            PrintStartScreen();
        }

        public void PrintCreateUser()
        {
            Console.WriteLine("Name:");
            var name = Console.ReadLine();
            Console.WriteLine("Age:");
            var age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Gender:");
            var gender = Console.ReadLine();

            _creation.CreateUser(name, age, gender);
        }

        public void PrintCircles()
        {
            _view.ViewUserCircles(LoggedIn);

            Console.WriteLine(" 1: Add user to circle");
            Console.WriteLine(" 2: Remove user from circle");
            Console.WriteLine(" 3: Add circle");
            Console.WriteLine(" 4: Remove circle");

            var input = Console.ReadKey();
            Console.WriteLine();

            try
            {
                switch (input.Key)
                {
                    case D1:
                        PrintAddToCircle();
                        break;
                    case D2:
                        PrintRemoveFromCircle();
                        break;
                    case D3:
                        PrintAddCircle();
                        break;
                    case D4:
                        PrintRemoveCircle();
                        break;
                    case D5:
                        PrintLogout();
                        break;
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("---\nUknown command, please try again\n---\n");
            }

        }

        public void PrintWall()
        {
            Console.WriteLine("Which users wall do you want to see?");
            var user = _userService.GetUserFromName(Console.ReadLine());

            _view.ViewUserWall(LoggedIn, user);
        }

        public void PrintFeed()
        {
            _view.ViewUserFeed(LoggedIn);
        }

        public void PrintCreatePost()
        {
            var user = LoggedIn;
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

            var user = LoggedIn;

            Console.WriteLine("Enter comment text:");
            var content = Console.ReadLine();

            //creation.CreateComment(user, post, content);
            //Console.WriteLine("Comment created");
        }

        public void PrintAddToCircle()
        {
            Console.WriteLine("Which circle?");
            var circle = _userService.GetCircleFromCircleNumber(LoggedIn, Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("Which user do you want to add to the circle?");
            circle.CircleMembers.Add(_userService.GetUserFromName(Console.ReadLine()).Id);
        }

        public void PrintRemoveFromCircle()
        {
            Console.WriteLine("Which circle?");
            var circle = _userService.GetCircleFromCircleNumber(LoggedIn, Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("Which user do you want to remove from the circle?");
            circle.CircleMembers.Remove(_userService.GetUserFromName(Console.ReadLine()).Id);
        }

        public void PrintAddCircle()
        {
            _creation.CreateCircle(LoggedIn);
        }

        public void PrintRemoveCircle()
        {
            Console.WriteLine("Which circle do you wish to delete?");
            var circle = _userService.GetCircleFromCircleNumber(LoggedIn, Console.ReadKey().KeyChar);
            LoggedIn.Circles.Remove(circle);
        }
    }
}

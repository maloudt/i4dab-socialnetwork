using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using SocialNetwork.Models;
using SocialNetwork.Services;
using Console = System.Console;

namespace SocialNetwork.Queries
{
    internal class Views
    {
        private readonly UserService _userService;
        private readonly PostService _postService;
        private readonly Creations _creation;

        public Views()
        {
            _userService = new UserService();
            _postService = new PostService();
            _creation = new Creations();

        }
        public void ViewUserFeed(User loggedInAs)
        {
            var circles = _userService.GetCirclesThatIncludeUser(loggedInAs);
            
            Console.WriteLine($"{loggedInAs.Name} is in {circles.Count} circles");

            var posts = new List<Post>();
            
            foreach (var c in circles)
            {
                var circlePosts = _postService.GetPostsFromCircle(c);

                posts.AddRange(circlePosts);
            }

            posts.AddRange(_postService.GetPostsFromUser(loggedInAs));

            posts.Sort((x, y) => DateTime.Compare(x.CreationTime, y.CreationTime));

            Console.WriteLine();
            Console.WriteLine($"%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
            Console.WriteLine($"Viewing feed of {loggedInAs.Name}");
            Console.WriteLine($"%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");

            for (int i = 0; i < posts.Count; i++)
            {
                Console.WriteLine($"---------------------------------------------------");
                Console.WriteLine($"Post #:");
                Console.WriteLine($"  {i}");
                Console.WriteLine($"Date:");
                Console.WriteLine($"  {posts[i].CreationTime}");
                Console.WriteLine();
                Console.WriteLine($"Post:");
                Console.WriteLine($"  {posts[i].PostContent}");
                Console.WriteLine();

                Console.WriteLine($"Comments:");
                foreach (var c in posts[i].Comments)
                {
                    Console.WriteLine($"  Date:    {c.CreationTime} ");
                    Console.WriteLine($"  Author:  {_userService.Get(c.CommentAuthor).Name} ");
                    Console.WriteLine($"  Comment: {c.CommentText}\n");
                }
            }
            CreateComment(posts, loggedInAs);
        }

        public void ViewUserWall(User loggedInAs, User viewing)
        {
            if (!viewing.BlockedUsers.Contains(loggedInAs.Id))
            {
                var allPosts = _postService.GetPostsFromUser(viewing);
                var posts = new List<Post>();
                foreach (var p in allPosts)
                {
                    var circles = p.Circles;

                    var containsViewing = false;

                    foreach (var c in circles)
                    {
                        if (c.CircleMembers.Contains(loggedInAs.Id))
                        {
                            containsViewing = true;
                        }
                    }

                    if (containsViewing == true)
                    {
                        posts.Add(p);
                    }

                    if (p.IsPublic == true)
                    {
                        if (!posts.Contains(p))
                        {
                            posts.Add(p);
                        }
                    }
                }

                Console.WriteLine();
                Console.WriteLine($"%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
                Console.WriteLine($"Viewing wall of {viewing.Name}");
                Console.WriteLine($"%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");

                for (int i = 0; i < posts.Count; i++)
                {
                    Console.WriteLine($"---------------------------------------------------");

                    Console.WriteLine($"Post #:");
                    Console.WriteLine($"  {i}");
                    Console.WriteLine($"Date:");
                    Console.WriteLine($"  {posts[i].CreationTime}");
                    Console.WriteLine();
                    Console.WriteLine($"Post:");
                    Console.WriteLine($"  {posts[i].PostContent}");
                    Console.WriteLine();

                    Console.WriteLine($"Comments:");

                    foreach (var c in posts[i].Comments)
                    {
                        Console.WriteLine($"  Date:    {c.CreationTime} ");
                        Console.WriteLine($"  Author:  {_userService.Get(c.CommentAuthor).Name} ");
                        Console.WriteLine($"  Comment: {c.CommentText}\n");
                    }
                }
                CreateComment(posts, loggedInAs);
            }
            else
            {
                Console.WriteLine("This user has blocked you");
            }

        }

        public void CreateComment(List<Post> posts, User loggedInAs)
        {
            Console.WriteLine(" 1: Comment on post");
            Console.WriteLine(" Press enter to go back");


            var input = Console.ReadKey();
            Console.WriteLine();

            try
            {
                switch (input.Key)
                {
                    case ConsoleKey.D1:

                        Console.WriteLine("On which post?");
                        var post = posts[Convert.ToInt32(Console.ReadLine())];

                        Console.WriteLine("Enter comment text:");
                        var content = Console.ReadLine();

                        _creation.CreateComment(loggedInAs, post, content);
                        Console.WriteLine("Comment created");
                        break;
                    default:
                        break;
                }
            }

            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("---\nUnknown command, please try again\n---\n");
            }
        }

        public void ViewUserCircles(User user)
        {
            foreach (var c in user.Circles)
            {
                Console.Write($"Circle # {c.CircleNumber}: ");
                foreach (var m in c.CircleMembers)
                {
                    Console.Write($"{_userService.Get(m).Name}, ");
                }
            }
        }

    }
}

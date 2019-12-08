using System;
using System.Collections.Generic;
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
        public Views()
        {
            _userService = new UserService();
            _postService = new PostService();
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

            foreach (var p in posts)
            {
                Console.WriteLine($"---------------------------------------------------");

                Console.WriteLine($"Date:");
                Console.WriteLine($"  {p.CreationTime}");
                Console.WriteLine();
                Console.WriteLine($"Post:");
                Console.WriteLine($"  {p.PostContent}");
                Console.WriteLine();

                Console.WriteLine($"Comments:");
                foreach (var c in p.Comments)
                {
                    Console.WriteLine($"  Date:    {c.CreationTime} ");
                    Console.WriteLine($"  Author:  {_userService.Get(c.CommentAuthor).Name} ");
                    Console.WriteLine($"  Comment: {c.CommentText}\n");
                }
            }
        }

        public void ViewUserWall(User loggedInAs, User viewing)
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
            }

            Console.WriteLine();
            Console.WriteLine($"%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
            Console.WriteLine($"Viewing wall of {viewing.Name}");
            Console.WriteLine($"%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");

            foreach (var p in posts)
            {
                Console.WriteLine($"---------------------------------------------------");

                Console.WriteLine($"Date:");
                Console.WriteLine($"  {p.CreationTime}");
                Console.WriteLine();
                Console.WriteLine($"Post:");
                Console.WriteLine($"  {p.PostContent}");
                Console.WriteLine();

                Console.WriteLine($"Comments:");
                foreach (var c in p.Comments)
                {
                    Console.WriteLine($"  Date:    {c.CreationTime} ");
                    Console.WriteLine($"  Author:  {_userService.Get(c.CommentAuthor).Name} ");
                    Console.WriteLine($"  Comment: {c.CommentText}\n");
                }
            }

        }

    }
}

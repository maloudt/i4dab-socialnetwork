using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using SocialNetwork.Models;
using SocialNetwork.Services;

namespace SocialNetwork.Queries
{
    internal class Creations
    {
        private readonly PostService _postService;
        private readonly UserService _userService;
        public Creations()
        {
            _postService = new PostService();
            _userService = new UserService();
        }

        public void CreateUser(string name, int age, string gender)
        {
            var newUser = new User
            {
                Name = name,
                Age = age,
                Gender = gender,
                Circles = new List<Circle>(),
                BlockedUsers = new List<string>()
            };

            _userService.Create(newUser);
        }

        public void CreatePost(User author, string postType, string content, bool isPublic, List<Circle> circles)
        {
            var newPost = new Post
            {
                PostAuthor = author.Id,
                PostType = postType,
                PostContent = content,
                CreationTime = DateTime.Now,
                IsPublic = isPublic,
                Circles = circles,
                Comments = new List<Comment>()
            };

            _postService.Create(newPost);
        }

        public void CreateComment(User author, Post post, string comment)
        {
            var newComment = new Comment
            {
                CommentAuthor = author.Id,
                CommentText = comment,
                CreationTime = DateTime.Now
            };

            post.Comments.Add(newComment);
            _postService.Update(post.Id, post);
        }

        public void CreateCircle(User user)
        {
            var newCircle = new Circle
            {
                CircleNumber = user.Circles.Count + 1,
                CircleMembers = new List<string>()
            };

            user.Circles.Add(newCircle);
            _userService.Update(user.Id, user);
        }

    }
}

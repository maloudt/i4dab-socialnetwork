using System;
using System.Collections.Generic;
using System.Text;
using SocialNetwork.Models;
using SocialNetwork.Services;

namespace SocialNetwork.Queries
{
    internal class Creations
    {
        private readonly PostService _postService;
        public Creations()
        {
            _postService = new PostService();
        }

        public void CreatePost(User author, string postType, string content, List<Circle> circles)
        {
            var newPost = new Post
            {
                PostAuthor = author.Id,
                PostType = postType,
                PostContent = content,
                CreationTime = DateTime.Now,
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
                CommentText = comment
            };

            post.Comments.Add(newComment);
            _postService.Update(post.Id, post);
        }

    }
}

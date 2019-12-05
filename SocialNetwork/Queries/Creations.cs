using System;
using System.Collections.Generic;
using System.Text;
using SocialNetwork.Models;
using SocialNetwork.Services;

namespace SocialNetwork.Queries
{
    class Creations
    {
        public void CreatePost(string authorId, string postType, List<string> circles)
        {
            var userService = new UserService();
            var postService = new PostService();

            var currentUser = userService.Get(authorId);
            //var ucircles = currentUser.Circles.Find;

            var newPost = new Post
            {
                PostAuthor = currentUser.Id,
                PostType = postType,
                PostContent = "Hello everyone!",
                CreationTime = DateTime.Now,
                Circles = new List<Circle>(),
                Comments = new List<Comment>()
            };

            postService.Create(newPost);


            // create_post(owner_id, content, cicles)
            // type must be either text, picture, video, poll etch
        }

        public void CreateComment()
        {
        // create _comment(post_id, comment)
        }

    }
}

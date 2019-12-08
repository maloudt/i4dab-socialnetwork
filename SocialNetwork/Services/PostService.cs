using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using SocialNetwork.Models;

namespace SocialNetwork.Services
{
    public class PostService
    {
        private readonly IMongoCollection<Post> _posts;

        public PostService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("SocialNetworkDb");

            _posts = database.GetCollection<Post>("Posts");
        }

        public List<Post> Get()
        {
            return _posts.Find(post => true).ToList();
        }

        public Post Get(string id)
        {
            return _posts.Find(post => post.Id == id).FirstOrDefault();
        }

        public List<Post> GetPostsFromUser(User user)
        {
            return _posts.Find(post => post.PostAuthor == user.Id).ToList();
        }

        public List<Post> GetPostsFromCircle(Circle circle)
        {
            return _posts.Find(post => post.Circles.Contains(circle)).ToList();
        }

        public Post Create(Post post)
        {
            _posts.InsertOne(post);
            return post;
        }

        public void Update(string id, Post postIn)
        {
            _posts.ReplaceOne(post => post.Id == id, postIn);
        }

        public void Remove(Post postIn)
        {
            _posts.DeleteOne(post => post.Id == postIn.Id);
        }

        public void Remove(string id)
        {
            _posts.DeleteOne(post => post.Id == id);
        }

        public void RemoveAll()
        {
            _posts.DeleteMany(post => post.Id != null);
        }
    }
}
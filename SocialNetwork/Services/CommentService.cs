using MongoDB.Driver;
using System.Collections.Generic;
using SocialNetwork.Models;

namespace SocialNetwork.Services
{
  public class CommentService
  {
    private readonly IMongoCollection<Comment> _comments;

    public CommentService()
    {
      var client = new MongoClient("mongodb://localhost:27017");
      var database = client.GetDatabase("SocialNetworkDb");

      _comments = database.GetCollection<Comment>("Comments");
    }

    public List<Comment> Get() =>
        _comments.Find(comment => true).ToList();

    public Comment Get(string id) =>
        _comments.Find<Comment>(comment => comment.Id == id).FirstOrDefault();

    public Comment Create(Comment comment)
    {
      _comments.InsertOne(comment);
      return comment;
    }

    public void Update(string id, Comment commentIn) =>
        _comments.ReplaceOne(comment => comment.Id == id, commentIn);

    public void Remove(Comment commentIn) =>
        _comments.DeleteOne(comment => comment.Id == commentIn.Id);

    public void Remove(string id) =>
        _comments.DeleteOne(comment => comment.Id == id);
  }
}
namespace SocialNetwork.Models
{
    public class SocialNetworkDatabaseSettings : ISocialNetworkDatabaseSettings
    {
        public string UsersCollectionName { get; set; }
        public string PostsCollectionName { get; set; }
        public string CommentsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ISocialNetworkDatabaseSettings
    {
        string UsersCollectionName { get; set; }
        string PostsCollectionName { get; set; }
        string CommentsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
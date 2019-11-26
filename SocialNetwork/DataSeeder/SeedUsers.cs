using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using SocialNetwork.Models;

namespace SocialNetwork.DataSeeder
{
    class SeedUsers : ISeed
    {
        public void Seed()
        {
            var user1 = new User
            {
                Name = "Lars Kolund",
                Age = 27,
                Gender = "Male",
                CircleMembers = new BsonArray() { "1a", "1b" },
                BlockedUsers = new BsonArray() { "1c", "1d" }
            };
            Program.userService.Create(user1);

            var user2 = new User
            {
                Name = "Mikkel Brambus",
                Age = 19,
                Gender = "Male",
                CircleMembers = new BsonArray() {},
                BlockedUsers = new BsonArray() {}
            };
            Program.userService.Create(user2);
        }
    }
}

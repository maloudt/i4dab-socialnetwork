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
            List<User> userList = new List<User>();

            userList.Add(new User
                {
                    Name = "Lars Kolund",
                    Age = 27,
                    Gender = "Male",
                    CircleMembers = new List<string>() {"a", "b"},
                    BlockedUsers = new List<string>() { "c", "d" }
            }
            );

            userList.Add(new User
                {
                    Name = "Mikkel Brambus",
                    Age = 19,
                    Gender = "Male",
                    CircleMembers = new List<string>() { "a", "b" },
                    BlockedUsers = new List<string>() { "c", "d" }
            }
            );

            foreach (var u in userList)
            {
                Program.userService.Create(u);
            }
            
            //var user1 = new User
            //{
            //    Name = "Lars Kolund",
            //    Age = 27,
            //    Gender = "Male",
            //    CircleMembers = new BsonArray() {},
            //    BlockedUsers = new BsonArray() {}
            //};
            //Program.userService.Create(user1);

            //var user2 = new User
            //{
            //    Name = "Mikkel Brambus",
            //    Age = 19,
            //    Gender = "Male",
            //    CircleMembers = new BsonArray() {},
            //    BlockedUsers = new BsonArray() {}
            //};
            //Program.userService.Create(user2);
        }
    }
}

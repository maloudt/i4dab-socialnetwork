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
            // create a list of users and add users to it
            var userList = new List<User>
            {
                new User
                {
                    Name = "Lars Kolund",
                    Age = 33,
                    Gender = "Male",
                    Circles = new List<Circle>(),
                    BlockedUsers = new List<string>()
                },

                new User
                {
                    Name = "Orla Mouritsen",
                    Age = 19,
                    Gender = "Male",
                    Circles = new List<Circle>(),
                    BlockedUsers = new List<string>()
                },

                new User
                {
                    Name = "Tonny Krogh",
                    Age = 23,
                    Gender = "Male",
                    Circles = new List<Circle>(),
                    BlockedUsers = new List<string>()
                },

                new User
                {
                    Name = "Ester Brink",
                    Age = 18,
                    Gender = "Female",
                    Circles = new List<Circle>(),
                    BlockedUsers = new List<string>()
                },

                new User
                {
                    Name = "Lisbeth Therkelsen",
                    Age = 25,
                    Gender = "Female",
                    Circles = new List<Circle>(),
                    BlockedUsers = new List<string>()
                },

                new User
                {
                    Name = "Winnie Andersen",
                    Age = 40,
                    Gender = "Female",
                    Circles = new List<Circle>(),
                    BlockedUsers = new List<string>()
                },

                new User
                {
                    Name = "Georg Aagaard",
                    Age = 31,
                    Gender = "Male",
                    Circles = new List<Circle>(),
                    BlockedUsers = new List<string>()
                },

                new User
                {
                    Name = "Steffen Fuglsang",
                    Age = 20,
                    Gender = "Male",
                    Circles = new List<Circle>(),
                    BlockedUsers = new List<string>()
                },

                new User
                {
                    Name = "Sabine Lauridsen",
                    Age = 19,
                    Gender = "Female",
                    Circles = new List<Circle>(),
                    BlockedUsers = new List<string>()
                },

                new User
                {
                    Name = "Margit Mogensen",
                    Age = 26,
                    Gender = "Female",
                    Circles = new List<Circle>(),
                    BlockedUsers = new List<string>()
                }
            };

            // **************************************************

            // add users to database as
            foreach (var u in userList)
            {
                Program.userService.Create(u);
            }


            // then update all users to include circles and blocked users
            // no way to add circles+blocked until users (and thus IDs) have been created


            // user 0 circles + blocked users *******************
            // create circles
            var user0circle1 = new Circle
            {
               CircleNumber = 1,
               CircleMembers = new List<string>() { userList[1].Id, userList[2].Id }
            };

            var user0circle2 = new Circle
            {
                CircleNumber = 2,
                CircleMembers = new List<string> { userList[3].Id, userList[4].Id, userList[5].Id }
            };

            // get db user from id
            var updateUser = Program.userService.Get(userList[0].Id);
            // add circles to user
            updateUser.Circles.Add(user0circle1);
            updateUser.Circles.Add(user0circle2);
            // add blocked user to block list
            updateUser.BlockedUsers.Add(userList[9].Id);
            // update db user to the new version that includes circles + blocked
            Program.userService.Update(userList[0].Id, updateUser);


            // user 1 circles + blocked users *******************
            var user1circle1 = new Circle
            {
                CircleNumber = 1,
                CircleMembers = new List<string> { userList[0].Id, userList[1].Id, userList[3].Id }
            };

            var user1circle2 = new Circle
            {
                CircleNumber = 2,
                CircleMembers = new List<string> { userList[1].Id, userList[5].Id }
            };

            updateUser = Program.userService.Get(userList[1].Id);
            updateUser.Circles.Add(user1circle1);
            updateUser.Circles.Add(user1circle2);
            updateUser.BlockedUsers.Add(userList[9].Id);
            Program.userService.Update(userList[1].Id, updateUser);


            // user 2 circles + blocked users *******************
            var user2circle1 = new Circle
            {
                CircleNumber = 1,
                CircleMembers = new List<string> { userList[1].Id, userList[5].Id, userList[6].Id, userList[8].Id }
            };

            updateUser = Program.userService.Get(userList[2].Id);
            updateUser.Circles.Add(user2circle1);
            updateUser.BlockedUsers.Add(userList[9].Id);
            Program.userService.Update(userList[2].Id, updateUser);


            // user 3 circles + blocked users *******************
            var user3circle1 = new Circle
            {
                CircleNumber = 1,
                CircleMembers = new List<string> { userList[1].Id, userList[5].Id, userList[6].Id, userList[8].Id, userList[9].Id }
            };
            var user3circle2 = new Circle
            {
                CircleNumber = 2,
                CircleMembers = new List<string> { userList[0].Id, userList[1].Id, userList[2].Id }
            };

            updateUser = Program.userService.Get(userList[3].Id);
            updateUser.Circles.Add(user3circle1);
            updateUser.Circles.Add(user3circle2);
            updateUser.BlockedUsers.Add(userList[9].Id);
            Program.userService.Update(userList[3].Id, updateUser);


            // user 4 circles + blocked users *******************
            var user4circle1 = new Circle
            {
                CircleNumber = 1,
                CircleMembers = new List<string> { userList[2].Id, userList[3].Id, userList[7].Id }
            };
            var user4circle2 = new Circle
            {
                CircleNumber = 2,
                CircleMembers = new List<string> {userList[6].Id, userList[8].Id }
            };

            updateUser = Program.userService.Get(userList[4].Id);
            updateUser.Circles.Add(user4circle1);
            updateUser.Circles.Add(user4circle2);
            // no blocked users
            Program.userService.Update(userList[4].Id, updateUser);


            // user 5 circles + blocked users *******************
            var user5circle1 = new Circle
            {
                CircleNumber = 1,
                CircleMembers = new List<string> { userList[3].Id, userList[4].Id, userList[9].Id }
            };


            updateUser = Program.userService.Get(userList[5].Id);
            updateUser.Circles.Add(user5circle1);
            // no blocked users
            Program.userService.Update(userList[5].Id, updateUser);


            // user 6 circles + blocked users *******************
            var user6circle1 = new Circle
            {
                CircleNumber = 1,
                CircleMembers = new List<string> { userList[2].Id, userList[3].Id, userList[5].Id, userList[7].Id }
            };

            updateUser = Program.userService.Get(userList[6].Id);
            updateUser.Circles.Add(user6circle1);
            updateUser.BlockedUsers.Add(userList[8].Id);
            Program.userService.Update(userList[6].Id, updateUser);


            // user 7 circles + blocked users *******************
            var user7circle1 = new Circle
            {
                CircleNumber = 1,
                CircleMembers = new List<string> { userList[1].Id, userList[5].Id, userList[8].Id }
            };
            var user7circle2 = new Circle
            {
                CircleNumber = 2,
                CircleMembers = new List<string> { userList[1].Id }
            };
            var user7circle3 = new Circle
            {
                CircleNumber = 3,
                CircleMembers = new List<string> { userList[1].Id, userList[3].Id }
            };

            updateUser = Program.userService.Get(userList[7].Id);
            updateUser.Circles.Add(user7circle1);
            updateUser.Circles.Add(user7circle2);
            updateUser.Circles.Add(user7circle3);
            // no blocked users
            Program.userService.Update(userList[7].Id, updateUser);


            // user 8 circles + blocked users *******************
            var user8circle1 = new Circle
            {
                CircleNumber = 1,
                CircleMembers = new List<string> { userList[0].Id, userList[4].Id, userList[5].Id, userList[9].Id }
            };
            var user8circle2 = new Circle
            {
                CircleNumber = 2,
                CircleMembers = new List<string> { userList[1].Id, userList[4].Id, userList[5].Id }
            };

            updateUser = Program.userService.Get(userList[8].Id);
            updateUser.Circles.Add(user8circle1);
            updateUser.Circles.Add(user8circle2);
            // no blocked users
            Program.userService.Update(userList[8].Id, updateUser);


            // user 9 circles + blocked users *******************
            var user9circle1 = new Circle
            {
                CircleNumber = 1,
                CircleMembers = new List<string> { userList[2].Id, userList[3].Id }
            };
            var user9circle2 = new Circle
            {
                CircleNumber = 2,
                CircleMembers = new List<string> { userList[0].Id, userList[1].Id, userList[3].Id, userList[6].Id }
            };

            updateUser = Program.userService.Get(userList[9].Id);
            updateUser.Circles.Add(user9circle1);
            updateUser.Circles.Add(user9circle2);
            updateUser.BlockedUsers.Add(userList[7].Id);
            Program.userService.Update(userList[9].Id, updateUser);


        }
        
    }
}

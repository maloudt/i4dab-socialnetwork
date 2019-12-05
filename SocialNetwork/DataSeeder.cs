using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using SocialNetwork.Models;
using SocialNetwork.Services;

namespace SocialNetwork
{
    class DataSeeder
    {
        private readonly UserService _userService;
        private readonly PostService _postService;
        private List<User> _userList;
        private List<Post> _postList;

        public DataSeeder()
        {
            _userService = new UserService();
            _postService = new PostService();
        }

        public void Seed()
        {
            _userService.RemoveAll();
            _postService.RemoveAll();

            // create a list of users and add users to it
            _userList = new List<User>
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
            foreach (var u in _userList)
            {
                _userService.Create(u);
            }


            // then update all users to include circles and blocked users
            // no way to add circles+blocked until users (and thus IDs) have been created


            // user 0 circles + blocked users *******************
            // create circles
            var user0circle1 = new Circle
            {
               CircleNumber = 1,
               CircleMembers = new List<string>() { _userList[1].Id, _userList[2].Id }
            };

            var user0circle2 = new Circle
            {
                CircleNumber = 2,
                CircleMembers = new List<string> { _userList[3].Id, _userList[4].Id, _userList[5].Id }
            };

            // get db user from id
            var updateUser = _userService.Get(_userList[0].Id);
            // add circles to user
            updateUser.Circles.Add(user0circle1);
            updateUser.Circles.Add(user0circle2);
            // add blocked user to block list
            updateUser.BlockedUsers.Add(_userList[9].Id);
            // update db user to the new version that includes circles + blocked
            _userService.Update(_userList[0].Id, updateUser);


            // user 1 circles + blocked users *******************
            var user1circle1 = new Circle
            {
                CircleNumber = 1,
                CircleMembers = new List<string> { _userList[0].Id, _userList[1].Id, _userList[3].Id }
            };

            var user1circle2 = new Circle
            {
                CircleNumber = 2,
                CircleMembers = new List<string> { _userList[1].Id, _userList[5].Id }
            };

            updateUser = _userService.Get(_userList[1].Id);
            updateUser.Circles.Add(user1circle1);
            updateUser.Circles.Add(user1circle2);
            updateUser.BlockedUsers.Add(_userList[9].Id);
            _userService.Update(_userList[1].Id, updateUser);


            // user 2 circles + blocked users *******************
            var user2circle1 = new Circle
            {
                CircleNumber = 1,
                CircleMembers = new List<string> { _userList[1].Id, _userList[5].Id, _userList[6].Id, _userList[8].Id }
            };

            updateUser = _userService.Get(_userList[2].Id);
            updateUser.Circles.Add(user2circle1);
            updateUser.BlockedUsers.Add(_userList[9].Id);
            _userService.Update(_userList[2].Id, updateUser);


            // user 3 circles + blocked users *******************
            var user3circle1 = new Circle
            {
                CircleNumber = 1,
                CircleMembers = new List<string> { _userList[1].Id, _userList[5].Id, _userList[6].Id, _userList[8].Id, _userList[9].Id }
            };
            var user3circle2 = new Circle
            {
                CircleNumber = 2,
                CircleMembers = new List<string> { _userList[0].Id, _userList[1].Id, _userList[2].Id }
            };

            updateUser = _userService.Get(_userList[3].Id);
            updateUser.Circles.Add(user3circle1);
            updateUser.Circles.Add(user3circle2);
            updateUser.BlockedUsers.Add(_userList[9].Id);
            _userService.Update(_userList[3].Id, updateUser);


            // user 4 circles + blocked users *******************
            var user4circle1 = new Circle
            {
                CircleNumber = 1,
                CircleMembers = new List<string> { _userList[2].Id, _userList[3].Id, _userList[7].Id }
            };
            var user4circle2 = new Circle
            {
                CircleNumber = 2,
                CircleMembers = new List<string> {_userList[6].Id, _userList[8].Id }
            };

            updateUser = _userService.Get(_userList[4].Id);
            updateUser.Circles.Add(user4circle1);
            updateUser.Circles.Add(user4circle2);
            // no blocked users
            _userService.Update(_userList[4].Id, updateUser);


            // user 5 circles + blocked users *******************
            var user5circle1 = new Circle
            {
                CircleNumber = 1,
                CircleMembers = new List<string> { _userList[3].Id, _userList[4].Id, _userList[9].Id }
            };


            updateUser = _userService.Get(_userList[5].Id);
            updateUser.Circles.Add(user5circle1);
            // no blocked users
            _userService.Update(_userList[5].Id, updateUser);


            // user 6 circles + blocked users *******************
            var user6circle1 = new Circle
            {
                CircleNumber = 1,
                CircleMembers = new List<string> { _userList[2].Id, _userList[3].Id, _userList[5].Id, _userList[7].Id }
            };

            updateUser = _userService.Get(_userList[6].Id);
            updateUser.Circles.Add(user6circle1);
            updateUser.BlockedUsers.Add(_userList[8].Id);
            _userService.Update(_userList[6].Id, updateUser);


            // user 7 circles + blocked users *******************
            var user7circle1 = new Circle
            {
                CircleNumber = 1,
                CircleMembers = new List<string> { _userList[1].Id, _userList[5].Id, _userList[8].Id }
            };
            var user7circle2 = new Circle
            {
                CircleNumber = 2,
                CircleMembers = new List<string> { _userList[1].Id }
            };
            var user7circle3 = new Circle
            {
                CircleNumber = 3,
                CircleMembers = new List<string> { _userList[1].Id, _userList[3].Id }
            };

            updateUser = _userService.Get(_userList[7].Id);
            updateUser.Circles.Add(user7circle1);
            updateUser.Circles.Add(user7circle2);
            updateUser.Circles.Add(user7circle3);
            // no blocked users
            _userService.Update(_userList[7].Id, updateUser);


            // user 8 circles + blocked users *******************
            var user8circle1 = new Circle
            {
                CircleNumber = 1,
                CircleMembers = new List<string> { _userList[0].Id, _userList[4].Id, _userList[5].Id, _userList[9].Id }
            };
            var user8circle2 = new Circle
            {
                CircleNumber = 2,
                CircleMembers = new List<string> { _userList[1].Id, _userList[4].Id, _userList[5].Id }
            };

            updateUser = _userService.Get(_userList[8].Id);
            updateUser.Circles.Add(user8circle1);
            updateUser.Circles.Add(user8circle2);
            // no blocked users
            _userService.Update(_userList[8].Id, updateUser);


            // user 9 circles + blocked users *******************
            var user9circle1 = new Circle
            {
                CircleNumber = 1,
                CircleMembers = new List<string> { _userList[2].Id, _userList[3].Id }
            };
            var user9circle2 = new Circle
            {
                CircleNumber = 2,
                CircleMembers = new List<string> { _userList[0].Id, _userList[1].Id, _userList[3].Id, _userList[6].Id }
            };

            updateUser = _userService.Get(_userList[9].Id);
            updateUser.Circles.Add(user9circle1);
            updateUser.Circles.Add(user9circle2);
            updateUser.BlockedUsers.Add(_userList[7].Id);
            _userService.Update(_userList[9].Id, updateUser);

            //////////////////////////////////////////////////////

            var user0 = _userService.Get(_userList[0].Id);
            var user1 = _userService.Get(_userList[1].Id);
            var user2 = _userService.Get(_userList[2].Id);
            var user3 = _userService.Get(_userList[3].Id);
            var user4 = _userService.Get(_userList[4].Id);
            var user5 = _userService.Get(_userList[5].Id);
            var user6 = _userService.Get(_userList[6].Id);
            var user7 = _userService.Get(_userList[7].Id);
            var user8 = _userService.Get(_userList[8].Id);
            var user9 = _userService.Get(_userList[9].Id);

            _postList = new List<Post>
            {
                new Post
                {
                    PostAuthor = user0.Id,
                    PostType = "text",
                    PostContent = "My first post!",
                    CreationTime = DateTime.Now,
                    Circles = new List<Circle> { user0.Circles[0] },
                    Comments = new List<Comment>
                    {
                        new Comment
                        {
                            CommentAuthor = user1.Id,
                            CommentText = "Great first post!",
                            CreationTime = DateTime.Now
                        },

                        new Comment
                        {
                            CommentAuthor = user2.Id,
                            CommentText = "Nice",
                            CreationTime = DateTime.Now
                        }
                    }
                },
            };

            foreach (var p in _postList)
            {
                _postService.Create(p);

            }






        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork
{
    class Printer
    {
        public void PrintStartScreen()
        {
            Console.WriteLine("All users:");
            foreach (var u in Program.users) Console.WriteLine($"{u.Id}, {u.Name}, {u.Age}, {u.Gender}, C: {u.Circles.Count}, B: {u.BlockedUsers.Count}");
            //Console.WriteLine();
            //Console.WriteLine("Enter a user name to log in");
            //var currentUser = Console.ReadLine();
        }

        public void PrintCreatePost()
        {
            Console.WriteLine("Create new post:");
            Console.WriteLine("Parameters: author ID, postType (text, image or video), [circle1, circle2, circleN]");
        }
    }
}

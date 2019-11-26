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
            foreach (var u in Program.users) Console.WriteLine(u.Name);
            Console.WriteLine();
            Console.WriteLine("Enter the name of the user to log in");
            var currentUser = Console.ReadLine();
        }
    }
}

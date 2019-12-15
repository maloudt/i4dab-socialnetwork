using System;
using System.Collections.Generic;
using MongoDB.Bson;
using SocialNetwork.Models;
using SocialNetwork.Services;

namespace SocialNetwork
{
    internal class Program
    {
        private static UserService _userService;
        private static List<User> _users;
        private static void Main(string[] args)
        {

            _userService = new UserService();
            _users = _userService.Get();

            // create seeders
            var seeder = new DataSeeder();

            // seed database
            seeder.Seed();
            
            // print result
            var printer = new Printer();

            Console.WriteLine("All users:");
            foreach (var u in _users) Console.WriteLine($"  {u.Name}, {u.Age}, {u.Gender}");


            while (true)
            {
                printer.PrintStartScreen();

            }

        }
    }
}
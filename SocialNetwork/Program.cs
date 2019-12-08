using System;
using System.Collections.Generic;
using MongoDB.Bson;
using SocialNetwork.Models;
using SocialNetwork.Services;

namespace SocialNetwork
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            // create seeders
            var seeder = new DataSeeder();

            // seed database
            seeder.Seed();
            
            // print result
            var printer = new Printer();

            while (true)
            {
                printer.PrintStartScreen();

            }

        }
    }
}
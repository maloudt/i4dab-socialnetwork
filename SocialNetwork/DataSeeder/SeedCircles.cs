using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using SocialNetwork.Models;

namespace SocialNetwork.DataSeeder
{
    class SeedCircles : ISeed
    {
        public void Seed()
        {
            var circleList = new List<Circle>();

            circleList.Add(new Circle
                {
                    User = "Lars Kolund",
                    Members = new List<string>() {"a", "b"},
                }
            );


            foreach (var c in circleList)
            {
                Program.circleService.Create(c);
            }
        }
    }
}

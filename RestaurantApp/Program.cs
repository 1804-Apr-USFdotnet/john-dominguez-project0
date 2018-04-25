using System;
using System.Collections.Generic;
using Library;

namespace RestaurantApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Serializer.Serialize(Restaurant.MakeRestaurants(), "test.txt");
            var restaurants = Serializer.Deserialize<Restaurant>("test.txt");
            foreach (var r in restaurants)
            {
                Console.WriteLine(r.ToString());
            }
            Console.Read();
        }
    }
}

/*
 Project 0
   Restaurant - Console
   Restaurant 
   -name
   - +2 info : loc, desc
   Review
   -numerical rating
   -2 info: reviewer name, date
 */

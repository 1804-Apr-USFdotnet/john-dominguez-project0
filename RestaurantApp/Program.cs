using System;
using System.Collections.Generic;
using library;
using Library;

namespace RestaurantApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Serializer.Serialize(Restaurant.MakeRestaurants(), "test.txt");
            var restaurants = Serializer.Deserialize<Restaurant>("test.txt");
            Console.WriteLine("All Restaurants");
            foreach (var r in restaurants)
            {
                Console.WriteLine(r.ToString());
            }

            Console.WriteLine("\nTop 3 Restaurants");
            int i = 1;
            foreach (var r in Restaurant.TopThree(restaurants))
            {
                Console.WriteLine($"{i}: {r.ToString()}");
                i++;
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

using System;
using System.Collections.Generic;
using library;

namespace RestaurantApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Restaurant> list = new List<Restaurant>()
            {
                new Restaurant("johns", "asdf")
            };

            SerializeMe.SerializeMeNow(list, "test.txt");
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

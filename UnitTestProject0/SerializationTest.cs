using System;
using System.Collections.Generic;
using Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;

namespace UnitTestProject0
{
    [TestClass]
    public class SerializationTest
    {
        private Restaurant restaurant;
       [TestMethod]
        public void Serialize()
        {
            restaurant = new Restaurant();
            restaurant.Rating = 0;
            restaurant.name = "Johns";
            restaurant.address = "123 st";
            restaurant.email = "234@aol.com";
            restaurant.phone = "123";

            string expected = Serializer.Serialize(restaurant);
            string actual = @"{""Name"":""Johns"",""Location"":""123 st"",""Rating"":0.0,""Reviews"":[]}";
            Console.WriteLine(expected);
            Console.WriteLine(actual);

            Assert.IsTrue(expected.Equals(actual));
        }

        [TestMethod]
        public void Deserialize()
        {
            Serializer.Serialize(restaurant, "test.txt");
            List<Restaurant> expected = Serializer.Deserialize<Restaurant>("test.txt");
            List<Restaurant> actual = new List<Restaurant>()
            {
                restaurant
            };
            Assert.IsTrue(expected.Equals(actual));
        }
    }
}

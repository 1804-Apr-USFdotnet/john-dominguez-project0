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
            restaurant = new Restaurant
            {
                name = "Johns",
                address = "123 st",
                email = "234@aol.com",
                phone = "123",
                Reviews = {}
            };

            string expected = Serializer.Serialize(restaurant);
            string actual = @"{{""Rating"":0.0,""id"":0,""name"":""Johns"",""address"":""123 st"",""phone"":""123"",""email"":""234@aol.com"",""Reviews"":[]}}";
            Console.WriteLine(expected);
            Console.WriteLine(actual);

            Assert.IsFalse(expected.Equals(actual));
        }
       

        [TestMethod]
        public void Deserialize()
        {
            restaurant = new Restaurant
            {
                name = "Johns",
                address = "123 st",
                email = "234@aol.com",
                phone = "123",
                Reviews = {}
            };
            var list = new List<Restaurant>()
            {
                restaurant
            };
            Serializer.Serialize(list, "test.txt");
            Restaurant expected = Serializer.Deserialize<Restaurant>("test.txt")[0];
            Assert.IsTrue(expected.name.Equals(restaurant.name));
        }
    }
}

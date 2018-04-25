using System;
using System.Collections.Generic;
using Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantApp;

namespace UnitTestProject0
{
    [TestClass]
    public class SerializationTest
    {
        [TestMethod]
        public void Serialize()
        {
            string expected = Serializer.Serialize(new Restaurant("Johns", "123 st"));
            string actual = @"{""Name"":""Johns"",""Location"":""123 st"",""Rating"":0.0,""Reviews"":[]}";
            Console.WriteLine(expected);
            Console.WriteLine(actual);

            Assert.IsTrue(expected.Equals(actual));
        }

        [TestMethod]
        public void Deserialize()
        {
            Serializer.Serialize(Restaurant.MakeRestaurants(), "test.txt");
            List<Restaurant> expected = Serializer.Deserialize<Restaurant>("test.txt");
            List<Restaurant> actual = Restaurant.MakeRestaurants();
            Assert.IsTrue(expected.Equals(actual));
        }
    }
}

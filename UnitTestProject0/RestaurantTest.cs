using System;
using System.Collections.Generic;
using System.IO;
using Data;
using library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace UnitTestProject0
{
    [TestClass]
    public class RestaurantTest
    {
        readonly List<Restaurant> _restaurants = Library.Serializer.DeserializeRestaurantJSON();
        [TestMethod]
        public void RestaurantTestName()
        {
            string expected = "Wisozk-Funk";
            string actual = _restaurants[0].name;

            Assert.IsTrue(expected.Equals(actual));
        }

        [TestMethod]
        public void RestaurantTestTopThree()
        {
            var expected = RestaurantLibrary.TopThreeRestaurants();
            var actual = _restaurants[0].name;

            Assert.IsTrue(expected.Equals(actual));

            /*
                7 - Johns-Purdy, 6.8 rating, 15 Reviews
                5 - Homenick Group, 6.4 rating, 5 Reviews
                1 - Wisozk-Funk, 6.23076923076923 rating, 13 Reviews
             */
        }
    }
}

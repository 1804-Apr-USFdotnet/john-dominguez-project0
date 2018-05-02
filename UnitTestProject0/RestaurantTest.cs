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
        public void RestaurantTestTopRestaurant()
        {
            var expected = RestaurantLibrary.TopThreeRestaurants(_restaurants)[0].name;
            var actual = "Johns-Purdy";

            Assert.IsTrue(expected.Equals(actual));

            /*
                7 - Johns-Purdy, 6.8 rating, 15 Reviews
                5 - Homenick Group, 6.4 rating, 5 Reviews
                1 - Wisozk-Funk, 6.23076923076923 rating, 13 Reviews
             */
        }

        [TestMethod]
        public void RestaurantTestLowestRatedRestaurant()
        {
            var expected = RestaurantLibrary.LowestRatedRestaurant(_restaurants).name;
            var actual = "Osinski, Goyette and Gerlach";

            Assert.IsTrue(expected.Equals(actual));
        }

        [TestMethod]
        public void RestaurantTestSearchRestaurant()
        {
            var expected = Data.Restaurant.SearchRestaurants(_restaurants, "John")[0].name;
            var actual = "Johns-Purdy";

            Assert.IsTrue(expected.Equals(actual));
        }
    }
}

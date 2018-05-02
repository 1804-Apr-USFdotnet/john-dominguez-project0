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
       [TestMethod]
        public void Serialize()
       {
            Restaurant restaurant = Serializer.DeserializeRestaurantJSON()[1];
            string expected = Serializer.Serialize(restaurant);
            string actual = GetRestaurantAsString();

            Assert.IsTrue(expected.Equals(actual));
        }
       

        [TestMethod]
        public void Deserialize()
        {
            var restaurant = Library.Serializer.DeserializeRestaurantJSON()[1];
            var list = new List<Restaurant>()
            {
                restaurant
            };
            Serializer.Serialize(list, "test.txt");
            Restaurant expected = Serializer.Deserialize<Restaurant>("test.txt")[0];
            Assert.IsTrue(expected.name.Equals(restaurant.name));
        }


        private string GetRestaurantAsString()
        {
            return @"{""id"":2,""name"":""Jakubowski Inc"",""address"":""14 Ronald Regan Hill"",""phone"":""156-543-2202"",""email"":""jhugett1@wisc.edu"",""Reviews"":[{""id"":2,""rating"":8,""body"":""Bill's Neoparrya"",""username"":""mwoliter1"",""restaurant_id"":2,""Restaurant"":null},{""id"":11,""rating"":6,""body"":""Dahurian Lespedeza"",""username"":""skempsona"",""restaurant_id"":2,""Restaurant"":null},{""id"":17,""rating"":4,""body"":""Serrasuela"",""username"":""eogarag"",""restaurant_id"":2,""Restaurant"":null},{""id"":38,""rating"":8,""body"":""Cliff Goldenbush"",""username"":""scrutcher11"",""restaurant_id"":2,""Restaurant"":null},{""id"":45,""rating"":3,""body"":""Rinodina Lichen"",""username"":""mclother18"",""restaurant_id"":2,""Restaurant"":null},{""id"":67,""rating"":4,""body"":""Whiteleaf Sunflower"",""username"":""bbiggins1u"",""restaurant_id"":2,""Restaurant"":null},{""id"":80,""rating"":2,""body"":""Velvetseed Milkwort"",""username"":""cpickance27"",""restaurant_id"":2,""Restaurant"":null},{""id"":88,""rating"":5,""body"":""Silky Lupine"",""username"":""tledford2f"",""restaurant_id"":2,""Restaurant"":null},{""id"":97,""rating"":4,""body"":""Baker's Stickyseed"",""username"":""bjoysey2o"",""restaurant_id"":2,""Restaurant"":null}]}";
        }
    }
}

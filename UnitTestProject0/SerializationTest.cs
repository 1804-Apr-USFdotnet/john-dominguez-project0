using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject0
{
    [TestClass]
    class SerializationTest
    {
        [TestMethod]
        public void TestSerialization()
        {
            Restaurant restaurant = new Restaurant("McDeath", "123  st");
        }

    }
}

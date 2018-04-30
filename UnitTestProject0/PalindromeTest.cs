using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;

namespace UnitTestProject0
{
    [TestClass]
    public class PalindromeTest
    {
        [TestMethod]
        public void TestPalindrome1()
        {
            //arrange
            string text = "racecar";
            bool expected = true;
            //act
            bool actual = CodeChallenge.isPalindrome(text);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPalindrome2()
        {
            //arrange
            string text = "Racecar";
            bool expected = true;
            //act
            bool actual = CodeChallenge.isPalindrome(text);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPalindrome3()
        {
            //arrange
            string text = "never Odd, or Even.";
            bool expected = true;
            //act
            bool actual = CodeChallenge.isPalindrome(text);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPalindrome4()
        {
            //arrange
            string text = "john";
            bool expected = false;
            //act
            bool actual = CodeChallenge.isPalindrome(text);
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}

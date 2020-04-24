using System.Linq;
using Core.Models.Ciphers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests
{
    [TestClass]
    public class KeyTests
    {
        private string _text = "ابتثجحخدذرزسشصضطظعغفقكلمنهوي";

        [TestMethod]
        public void Key_Shift()
        {
            var cipher = new RegularCipher
            {
                Key = new Key { Base = 9 },
                Characters = {"1",   "2",  "3",  "4",  "5",  "6",  "7",
                              "8",   "9", "10", "11", "12", "13", "14",
                              "15", "16", "17", "18", "19", "20", "21",
                              "22", "23", "24", "25", "26", "27", "28"}
            };

            var result = cipher.Encode(_text, " ", "");

            Assert.AreEqual("10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 1 2 3 4 5 6 7 8 9", result);
        }

        [TestMethod]
        public void Key_Weight()
        {
            var cipher = new RegularCipher
            {
                Key = new Key { Base = 1, Weight = 9 },
                Characters = {"1",   "2",  "3",  "4",  "5",  "6",  "7",
                              "8",   "9", "10", "11", "12", "13", "14",
                              "15", "16", "17", "18", "19", "20", "21",
                              "22", "23", "24", "25", "26", "27", "28"}
            };

            var result = cipher.Encode(_text, " ", "");

            Assert.AreEqual("10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 1 2 3 4 5 6 7 8 9", result);
        }

        [TestMethod]
        public void Key_NormalList()
        {
            var cipher = new RegularCipher
            {
                Characters = {"1",   "2",  "3",  "4",  "5",  "6",  "7",
                              "8",   "9", "10", "11", "12", "13", "14",
                              "15", "16", "17", "18", "19", "20", "21",
                              "22", "23", "24", "25", "26", "27", "28"}
            };

            var result = cipher.KeysList.ToList().Count;

            Assert.AreEqual(28, result);
        }

        [TestMethod]
        public void Key_WeightedList()
        {
            var cipher = new RegularCipher
            {
                Key = new Key { Weight = 7 },
                Characters = {"1",   "2",  "3",  "4",  "5",  "6",  "7",
                              "8",   "9", "10", "11", "12", "13", "14",
                              "15", "16", "17", "18", "19", "20", "21",
                              "22", "23", "24", "25", "26", "27", "28"}
            };

            var result = cipher.KeysList.ToList().Count;

            Assert.AreEqual(4, result);
        }

    }
}

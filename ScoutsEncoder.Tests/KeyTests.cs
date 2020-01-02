using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScoutsEncoder.Models;

namespace Tests
{
    [TestClass]
    public class KeyTests
    {
        private string _text = "ابتثجحخدذرزسشصضطظعغفقكلمنهوي";

        [TestMethod]
        public void Key_Shift()
        {
            var cipher = new Cipher
            {
                Key = 9,
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
            var cipher = new Cipher
            {
                Key = 1,
                KeyWeight = 9,
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
            var cipher = new Cipher
            {
                HasKeys = true,
                Characters = {"1",   "2",  "3",  "4",  "5",  "6",  "7",
                              "8",   "9", "10", "11", "12", "13", "14",
                              "15", "16", "17", "18", "19", "20", "21",
                              "22", "23", "24", "25", "26", "27", "28"}
            };

            var result = cipher.KeysList.Count;

            Assert.AreEqual(28, result);
        }

        [TestMethod]
        public void Key_WeightedList()
        {
            var cipher = new Cipher
            {
                HasKeys = true,
                KeyWeight = 7,
                Characters = {"1",   "2",  "3",  "4",  "5",  "6",  "7",
                              "8",   "9", "10", "11", "12", "13", "14",
                              "15", "16", "17", "18", "19", "20", "21",
                              "22", "23", "24", "25", "26", "27", "28"}
            };

            var result = cipher.KeysList.Count;

            Assert.AreEqual(4, result);
        }

    }
}

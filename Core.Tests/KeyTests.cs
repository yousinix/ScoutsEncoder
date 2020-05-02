using System.Linq;
using Core.Models.Ciphers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests
{
    [TestClass]
    public class KeyTests
    {
        private const string Text = "ابتثجحخدذرزسشصضطظعغفقكلمنهوي";
        private static readonly CharactersSet Set = new CharactersSet
        {
            Characters = 
            {
                "1",   "2",  "3",  "4",  "5",  "6",  "7",
                "8",   "9", "10", "11", "12", "13", "14",
                "15", "16", "17", "18", "19", "20", "21",
                "22", "23", "24", "25", "26", "27", "28"
            }
        };

        [TestMethod]
        public void Key_Shift()
        {
            var cipher = new Cipher
            {
                Key = new Key { Base = 9 },
                CharactersSets = { Set }
            };

            var result = cipher.Encode(Text, " ", "");
            Assert.AreEqual("10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 1 2 3 4 5 6 7 8 9", result);
        }

        [TestMethod]
        public void Key_Weight()
        {
            var cipher = new Cipher
            {
                Key = new Key { Base = 1, Weight = 9 },
                CharactersSets = { Set }
            };

            var result = cipher.Encode(Text, " ", "");
            Assert.AreEqual("10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 1 2 3 4 5 6 7 8 9", result);
        }

        [TestMethod]
        public void Key_NormalList()
        {
            var cipher = new Cipher
            {
                CharactersSets = { Set }
            };

            var result = cipher.KeysList.ToList().Count;
            Assert.AreEqual(28, result);
        }

        [TestMethod]
        public void Key_WeightedList()
        {
            var cipher = new Cipher
            {
                Key = new Key { Weight = 7 },
                CharactersSets = { Set }
            };

            var result = cipher.KeysList.ToList().Count;
            Assert.AreEqual(4, result);
        }

    }
}

using Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests
{
    [TestClass]
    public class EncodeTests
    {
        private readonly string _charDelimiter = "-";
        private readonly string _text = "ابجد هوز حطي كلمن سعفص قرشت ثخذ ضظغ";
        private readonly string _wordDelimiter = " / ";


        [TestMethod]
        public void Encode_JesusCipher()
        {
            var cipher = new Cipher
            {
                Characters =
                {
                    "ي١", "ي٢", "ي٣", "ي٤", "ي٥", "ي٦", "ي٧",
                    "س١", "س٢", "س٣", "س٤", "س٥", "س٦", "س٧",
                    "و١", "و٢", "و٣", "و٤", "و٥", "و٦", "و٧",
                    "ع١", "ع٢", "ع٣", "ع٤", "ع٥", "ع٦", "ع٧"
                }
            };

            var result = cipher.Encode(_text, _charDelimiter, _wordDelimiter);

            Assert.AreEqual("ي١-ي٢-ي٥-س١ / ع٥-ع٦-س٤ / ي٦-و٢-ع٧ / ع١-ع٢-ع٣-ع٤ " + 
                            "/ س٥-و٤-و٦-س٧ / و٧-س٣-س٦-ي٣ / ي٤-ي٧-س٢ / و١-و٣-و٥", result);
        }

        [TestMethod]
        public void Encode_NumericCipher()
        {
            var cipher = new Cipher
            {
                Characters =
                {
                    "١", "٢", "٣", "٤", "٥", "٦", "٧",
                    "٨", "٩", "١٠", "١١", "١٢", "١٣", "١٤",
                    "١٥", "١٦", "١٧", "١٨", "١٩", "٢٠", "٢١",
                    "٢٢", "٢٣", "٢٤", "٢٥", "٢٦", "٢٧", "٢٨"
                }
            };

            var result = cipher.Encode(_text, _charDelimiter, _wordDelimiter);

            Assert.AreEqual("١-٢-٥-٨ / ٢٦-٢٧-١١ / ٦-١٦-٢٨ / ٢٢-٢٣-٢٤-٢٥ " +
                            "/ ١٢-١٨-٢٠-١٤ / ٢١-١٠-١٣-٣ / ٤-٧-٩ / ١٥-١٧-١٩", result);
        }

        [TestMethod]
        public void Encode_BinaryCipher()
        {
            var cipher = new Cipher
            {
                Characters =
                {
                    "00001", "00010", "00011", "00100", "00101", "00110", "00111",
                    "01000", "01001", "01010", "01011", "01100", "01101", "01110",
                    "01111", "10000", "10001", "10010", "10011", "10100", "10101",
                    "10110", "10111", "11000", "11001", "11010", "11011", "11100"
                }
            };

            var result = cipher.Encode(_text, _charDelimiter, _wordDelimiter);

            Assert.AreEqual(
                "00001-00010-00101-01000 / 11010-11011-01011 / 00110-10000-11100 / 10110-10111-11000-11001 " +
                "/ 01100-10010-10100-01110 / 10101-01010-01101-00011 / 00100-00111-01001 / 01111-10001-10011", result);
        }

        [TestMethod]
        public void Encode_ReverseCipher()
        {
            var cipher = new Cipher
            {
                Characters =
                {
                    "ي", "و", "ه", "ن", "م", "ل", "ك",
                    "ق", "ف", "غ", "ع", "ظ", "ط", "ض",
                    "ص", "ش", "س", "ز", "ر", "ذ", "د",
                    "خ", "ح", "ج", "ث", "ت", "ب", "ا"
                }
            };

            var result = cipher.Encode(_text, _charDelimiter, _wordDelimiter);

            Assert.AreEqual("ي-و-م-ق / ت-ب-ع / ل-ش-ا / خ-ح-ج-ث / ظ-ز-ذ-ض / د-غ-ط-ه / ن-ك-ف / ص-س-ر", result);
        }

        [TestMethod]
        public void Encode_CaesarCipher()
        {
            var cipher = new Cipher
            {
                Characters =
                {
                    "ب", "ت", "ث", "ج", "ح", "خ", "د",
                    "ذ", "ر", "ز", "س", "ش", "ص", "ض",
                    "ط", "ظ", "ع", "غ", "ف", "ق", "ك",
                    "ل", "م", "ن", "ه", "و", "ي", "ا"
                }
            };

            var result = cipher.Encode(_text, _charDelimiter, _wordDelimiter);

            Assert.AreEqual("ب-ت-ح-ذ / و-ي-س / خ-ظ-ا / ل-م-ن-ه / ش-غ-ق-ض / ك-ز-ص-ث / ج-د-ر / ط-ع-ف", result);
        }

        [TestMethod]
        public void Encode_MorseCipher()
        {
            var cipher = new Cipher
            {
                Characters =
                {
                    "(•-)", "(-•••)", "(-)", "(-•-•)", "(•---)", "(••••)", "(---)",
                    "(-••)", "(--••)", "(•-•)", "(---•)", "(•••)", "(----)", "(-••-)",
                    "(•••-)", "(••-)", "(-•--)", "(•-•-)", "(--•)", "(••-•)", "(--•-)",
                    "(-•-)", "(•-••)", "(--)", "(-•)", "(••-••)", "(•--)", "(••)"
                }
            };

            var result = cipher.Encode(_text, _charDelimiter, _wordDelimiter);

            Assert.AreEqual(
                "(•-)-(-•••)-(•---)-(-••) / (••-••)-(•--)-(---•) / (••••)-(••-)-(••) / (-•-)-(•-••)-(--)-(-•) / " +
                "(•••)-(•-•-)-(••-•)-(-••-) / (--•-)-(•-•)-(----)-(-) / (-•-•)-(---)-(--••) / (•••-)-(-•--)-(--•)",
                result);
        }

        [TestMethod]
        public void Encode_CompassCipher()
        {
            var cipher = new Cipher
            {
                Characters =
                {
                    "N(١)", "NE(١)", "E(١)", "SE(١)", "S(١)", "SW(١)", "W(١)", "NW(١)",
                    "N(٢)", "NE(٢)", "E(٢)", "SE(٢)", "S(٢)", "SW(٢)", "W(٢)", "NW(٢)",
                    "N(٣)", "NE(٣)", "E(٣)", "SE(٣)", "S(٣)", "SW(٣)", "W(٣)", "NW(٣)",
                    "N(٤)", "NE(٤)", "E(٤)", "SE(٤)"
                }
            };

            var result = cipher.Encode(_text, _charDelimiter, _wordDelimiter);

            Assert.AreEqual("N(١)-NE(١)-S(١)-NW(١) / NE(٤)-E(٤)-E(٢) / SW(١)-NW(٢)-SE(٤) / SW(٣)-W(٣)-NW(٣)-N(٤) / " +
                            "SE(٢)-NE(٣)-SE(٣)-SW(٢) / S(٣)-NE(٢)-S(٢)-E(١) / SE(١)-W(١)-N(٢) / W(٢)-N(٣)-E(٣)", result);
        }

        [TestMethod]
        public void Encode_ClockCWCipher()
        {
            var cipher = new Cipher
            {
                Characters =
                {
                    "١:١٢", "١:١", "١:٢", "١:٣", "١:٤", "١:٥", "١:٦",
                    "١:٧", "١:٨", "١:٩", "١:١٠", "١:١١", "٢:١٢", "٢:١",
                    "٢:٢", "٢:٣", "٢:٤", "٢:٥", "٢:٦", "٢:٧", "٢:٨",
                    "٢:٩", "٢:١٠", "٢:١١", "٣:١٢", "٣:١", "٣:٢", "٣:٣"
                }
            };

            var result = cipher.Encode(_text, _charDelimiter, _wordDelimiter);

            Assert.AreEqual("١:١٢-١:١-١:٤-١:٧ / ٣:١-٣:٢-١:١٠ / ١:٥-٢:٣-٣:٣ / ٢:٩-٢:١٠-٢:١١-٣:١٢ /" + 
                            " ١:١١-٢:٥-٢:٧-٢:١ / ٢:٨-١:٩-٢:١٢-١:٢ / ١:٣-١:٦-١:٨ / ٢:٢-٢:٤-٢:٦", result);
        }

        [TestMethod]
        public void Encode_ClockCCWCipher()
        {
            var cipher = new Cipher
            {
                Characters =
                {
                    "١:١٢", "١:١١", "١:١٠", "١:٩", "١:٨", "١:٧", "١:٦",
                    "١:٥", "١:٤", "١:٣", "١:٢", "١:١", "٢:١٢", "٢:١١",
                    "٢:١٠", "٢:٩", "٢:٨", "٢:٧", "٢:٦", "٢:٥", "٢:٤",
                    "٢:٣", "٢:٢", "٢:١", "٣:١٢", "٣:١١", "٣:١٠", "٣:٩"
                }
            };

            var result = cipher.Encode(_text, _charDelimiter, _wordDelimiter);

            Assert.AreEqual("١:١٢-١:١١-١:٨-١:٥ / ٣:١١-٣:١٠-١:٢ / ١:٧-٢:٩-٣:٩ / ٢:٣-٢:٢-٢:١-٣:١٢ /" + 
                            " ١:١-٢:٧-٢:٥-٢:١١ / ٢:٤-١:٣-٢:١٢-١:١٠ / ١:٩-١:٦-١:٤ / ٢:١٠-٢:٨-٢:٦", result);
        }

        [TestMethod]
        public void Encode_Mobile1stCipher()
        {
            var cipher = new Cipher
            {
                Characters =
                {
                    "٣", "٢", "٢٢", "٢٢٢", "٦", "٦٦", "٦٦٦",
                    "٥", "٥٥", "٥٥٥", "٥٥٥٥", "٤", "٤٤", "٤٤٤",
                    "٤٤٤٤", "٩", "٩٩", "٩٩٩", "٩٩٩٩", "٨", "٨٨",
                    "٨٨٨", "٨٨٨٨", "٨٨٨٨٨", "٧", "٧٧", "٧٧٧", "٧٧٧٧"
                }
            };

            var result = cipher.Encode(_text, _charDelimiter, _wordDelimiter);

            Assert.AreEqual("٣-٢-٦-٥ / ٧٧-٧٧٧-٥٥٥٥ / ٦٦-٩-٧٧٧٧ / ٨٨٨-٨٨٨٨-٨٨٨٨٨-٧ " + 
                            "/ ٤-٩٩٩-٨-٤٤٤ / ٨٨-٥٥٥-٤٤-٢٢ / ٢٢٢-٦٦٦-٥٥ / ٤٤٤٤-٩٩-٩٩٩٩", result);
        }

        [TestMethod]
        public void Encode_Mobile2ndCipher()
        {
            var cipher = new Cipher
            {
                Characters =
                {
                    "٣^١", "٢^١", "٢^٢", "٢^٣", "٦^١", "٦^٢", "٦^٣",
                    "٥^١", "٥^٢", "٥^٣", "٥^٤", "٤^١", "٤^٢", "٤^٣",
                    "٤^٤", "٩^١", "٩^٢", "٩^٣", "٩^٤", "٨^١", "٨^٢",
                    "٨^٣", "٨^٤", "٨^٥", "٧^١", "٧^٢", "٧^٣", "٧^٤"
                }
            };

            var result = cipher.Encode(_text, _charDelimiter, _wordDelimiter);

            Assert.AreEqual("٣^١-٢^١-٦^١-٥^١ / ٧^٢-٧^٣-٥^٤ / ٦^٢-٩^١-٧^٤ / ٨^٣-٨^٤-٨^٥-٧^١ " + 
                            "/ ٤^١-٩^٣-٨^١-٤^٣ / ٨^٢-٥^٣-٤^٢-٢^٢ / ٢^٣-٦^٣-٥^٢ / ٤^٤-٩^٢-٩^٤", result);
        }

        [TestMethod]
        public void Encode_XCipher()
        {
            var cipher = new Cipher
            {
                Characters =
                {
                    "˅١", "˅٢", "˅٣", "˅٤", "˅٥", "˅٦", "˅٧",
                    "˂١", "˂٢", "˂٣", "˂٤", "˂٥", "˂٦", "˂٧",
                    "˄١", "˄٢", "˄٣", "˄٤", "˄٥", "˄٦", "˄٧",
                    "˃١", "˃٢", "˃٣", "˃٤", "˃٥", "˃٦", "˃٧"
                }
            };

            var result = cipher.Encode(_text, _charDelimiter, _wordDelimiter);

            Assert.AreEqual("˅١-˅٢-˅٥-˂١ / ˃٥-˃٦-˂٤ / ˅٦-˄٢-˃٧ / ˃١-˃٢-˃٣-˃٤ " +
                            "/ ˂٥-˄٤-˄٦-˂٧ / ˄٧-˂٣-˂٦-˅٣ / ˅٤-˅٧-˂٢ / ˄١-˄٣-˄٥", result);
        }

        [TestMethod]
        public void Encode_StarCipher()
        {
            var cipher = new Cipher
            {
                Characters =
                {
                    "▲١", "▲٢", "▲٣", "▲٤", "▲٥", "▲٦", "▲٧",
                    "▶١", "▶٢", "▶٣", "▶٤", "▶٥", "▶٦", "▶٧",
                    "▼١", "▼٢", "▼٣", "▼٤", "▼٥", "▼٦", "▼٧",
                    "◀١", "◀٢", "◀٣", "◀٤", "◀٥", "◀٦", "◀٧"
                }
            };

            var result = cipher.Encode(_text, _charDelimiter, _wordDelimiter);

            Assert.AreEqual("▲١-▲٢-▲٥-▶١ / ◀٥-◀٦-▶٤ / ▲٦-▼٢-◀٧ / ◀١-◀٢-◀٣-◀٤ / " +
                            "▶٥-▼٤-▼٦-▶٧ / ▼٧-▶٣-▶٦-▲٣ / ▲٤-▲٧-▶٢ / ▼١-▼٣-▼٥", result);
        }

        [TestMethod]
        public void Encode_RhombusCipher()
        {
            var cipher = new Cipher
            {
                Characters =
                {
                    "١◣", "١◢", "١◤", "١◥",
                    "٢◣", "٢◢", "٢◤", "٢◥",
                    "٣◣", "٣◢", "٣◤", "٣◥",
                    "٤◣", "٤◢", "٤◤", "٤◥",
                    "٥◣", "٥◢", "٥◤", "٥◥",
                    "٦◣", "٦◢", "٦◤", "٦◥",
                    "٧◣", "٧◢", "٧◤", "٧◥"
                }
            };

            var result = cipher.Encode(_text, _charDelimiter, _wordDelimiter);

            Assert.AreEqual("١◣-١◢-٢◣-٢◥ / ٧◢-٧◤-٣◤ / ٢◢-٤◥-٧◥ / ٦◢-٦◤-٦◥-٧◣" + 
                            " / ٣◥-٥◢-٥◥-٤◢ / ٦◣-٣◢-٤◣-١◤ / ١◥-٢◤-٣◣ / ٤◤-٥◣-٥◤", result);
        }

        [TestMethod]
        public void Encode_TriangleCipher()
        {
            var cipher = new Cipher
            {
                Characters =
                {
                    "١▲",
                    "٢◣◼", "٢◼◢",
                    "٣◣◼", "٣◼(١)", "٣◼◢",
                    "٤◣◼", "٤◼(١)", "٤◼(٢)", "٤◼◢",
                    "٥◣◼", "٥◼(١)", "٥◼(٢)", "٥◼(٣)", "٥◼◢",
                    "٦◣◼", "٦◼(١)", "٦◼(٢)", "٦◼(٣)", "٦◼(٤)", "٦◼◢",
                    "٧◣◼", "٧◼(١)", "٧◼(٢)", "٧◼(٣)", "٧◼(٤)", "٧◼(٥)", "٧◼◢"
                }
            };

            var result = cipher.Encode(_text, _charDelimiter, _wordDelimiter);

            Assert.AreEqual("١▲-٢◣◼-٣◼(١)-٤◼(١) / ٧◼(٤)-٧◼(٥)-٥◣◼ / ٣◼◢-٦◣◼-٧◼◢ /" +
                            " ٧◣◼-٧◼(١)-٧◼(٢)-٧◼(٣) / ٥◼(١)-٦◼(٢)-٦◼(٤)-٥◼(٣) /" +
                            " ٦◼◢-٤◼◢-٥◼(٢)-٢◼◢ / ٣◣◼-٤◣◼-٤◼(٢) / ٥◼◢-٦◼(١)-٦◼(٣)", result);
        }

        [TestMethod]
        public void Encode_PunctuationMarks()
        {
            var cipher = new Cipher();

            var result = cipher.Encode(".,:\"\"''-?؟!()[]", _charDelimiter, _wordDelimiter);

            Assert.AreEqual(" .  ,  :  \"  \"  '  '  -  ?  ؟  !  (  )  [  ] ", result);
        }

        [TestMethod]
        public void Encode_OddCharacters()
        {
            var cipher = new Cipher
            {
                Characters =
                {
                    "ا", "ب", "ت", "ث", "ج", "ح", "خ",
                    "د", "ذ", "ر", "ز", "س", "ش", "ص",
                    "ض", "ط", "ظ", "ع", "غ", "ف", "ق",
                    "ك", "ل", "م", "ن", "ه", "و", "ي"
                }
            };

            var result = cipher.Encode("اإأآءةؤئيى", "", "");

            Assert.AreEqual("اااااهوييي", result);
        }
    }
}
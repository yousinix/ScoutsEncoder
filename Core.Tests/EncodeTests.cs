using System.Linq;
using Core.Data;
using Core.Models.Ciphers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests
{
    [TestClass]
    public class EncodeTests
    {
        private const string Text = "ابجد هوز حطي كلمن سعفص قرشت ثخذ ضظغ";
        private const string CharDelimiter = "-";
        private const string WordDelimiter = " / ";

        [TestMethod]
        public void Encode_JesusCipher()
        {
            var cipher = CiphersList.Instance.First(c => c.Name == "يسوع");
            var result = cipher.Encode(Text, CharDelimiter, WordDelimiter);
            Assert.AreEqual("ي١-ي٢-ي٥-س١ / ع٥-ع٦-س٤ / ي٦-و٢-ع٧ / ع١-ع٢-ع٣-ع٤ " + 
                            "/ س٥-و٤-و٦-س٧ / و٧-س٣-س٦-ي٣ / ي٤-ي٧-س٢ / و١-و٣-و٥", result);
        }

        [TestMethod]
        public void Encode_NumericCipher()
        {
            var cipher = CiphersList.Instance.First(c => c.Name == "الرقمية");
            var result = cipher.Encode(Text, CharDelimiter, WordDelimiter);
            Assert.AreEqual("١-٢-٥-٨ / ٢٦-٢٧-١١ / ٦-١٦-٢٨ / ٢٢-٢٣-٢٤-٢٥ " +
                            "/ ١٢-١٨-٢٠-١٤ / ٢١-١٠-١٣-٣ / ٤-٧-٩ / ١٥-١٧-١٩", result);
        }

        [TestMethod]
        public void Encode_BinaryCipher()
        {
            var cipher = CiphersList.Instance.First(c => c.Name == "الأعداد الثنائية");
            var result = cipher.Encode(Text, CharDelimiter, WordDelimiter);
            Assert.AreEqual(
                "00001-00010-00101-01000 / 11010-11011-01011 / 00110-10000-11100 / 10110-10111-11000-11001 " +
                "/ 01100-10010-10100-01110 / 10101-01010-01101-00011 / 00100-00111-01001 / 01111-10001-10011", result);
        }

        [TestMethod]
        public void Encode_ReverseCipher()
        {
            var cipher = CiphersList.Instance.First(c => c.Name == "العكسية");
            var result = cipher.Encode(Text, CharDelimiter, WordDelimiter);
            Assert.AreEqual("ي-و-م-ق / ت-ب-ع / ل-ش-ا / خ-ح-ج-ث / ظ-ز-ذ-ض / د-غ-ط-ه / ن-ك-ف / ص-س-ر", result);
        }

        [TestMethod]
        public void Encode_CaesarCipher()
        {
            var cipher = CiphersList.Instance.First(c => c.Name == "قيصر");
            var result = cipher.Encode(Text, CharDelimiter, WordDelimiter);
            Assert.AreEqual("ب-ت-ح-ذ / و-ي-س / خ-ظ-ا / ل-م-ن-ه / ش-غ-ق-ض / ك-ز-ص-ث / ج-د-ر / ط-ع-ف", result);
        }

        [TestMethod]
        public void Encode_MorseCipher()
        {
            var cipher = CiphersList.Instance.First(c => c.Name == "المورس");
            var result = cipher.Encode(Text, CharDelimiter, WordDelimiter);
            Assert.AreEqual(
                "(•-)-(-•••)-(•---)-(-••) / (••-••)-(•--)-(---•) / (••••)-(••-)-(••) / (-•-)-(•-••)-(--)-(-•) / " +
                "(•••)-(•-•-)-(••-•)-(-••-) / (--•-)-(•-•)-(----)-(-) / (-•-•)-(---)-(--••) / (•••-)-(-•--)-(--•)",
                result);
        }

        [TestMethod]
        public void Encode_CompassCipher()
        {
            var cipher = CiphersList.Instance.First(c => c.Name == "البوصلة");
            var result = cipher.Encode(Text, CharDelimiter, WordDelimiter);
            Assert.AreEqual("N(١)-NE(١)-S(١)-NW(١) / NE(٤)-E(٤)-E(٢) / SW(١)-NW(٢)-SE(٤) / SW(٣)-W(٣)-NW(٣)-N(٤) / " +
                            "SE(٢)-NE(٣)-SE(٣)-SW(٢) / S(٣)-NE(٢)-S(٢)-E(١) / SE(١)-W(١)-N(٢) / W(٢)-N(٣)-E(٣)", result);
        }

        [TestMethod]
        public void Encode_ClockCWCipher()
        {
            var cipher = CiphersList.Instance.First(c => c.Name == "الساعة");
            cipher.SetIndex = 0;
            var result = cipher.Encode(Text, CharDelimiter, WordDelimiter);
            Assert.AreEqual("١:١٢-١:١-١:٤-١:٧ / ٣:١-٣:٢-١:١٠ / ١:٥-٢:٣-٣:٣ / ٢:٩-٢:١٠-٢:١١-٣:١٢ /" + 
                            " ١:١١-٢:٥-٢:٧-٢:١ / ٢:٨-١:٩-٢:١٢-١:٢ / ١:٣-١:٦-١:٨ / ٢:٢-٢:٤-٢:٦", result);
        }

        [TestMethod]
        public void Encode_ClockCCWCipher()
        {
            var cipher = CiphersList.Instance.First(c => c.Name == "الساعة");
            cipher.SetIndex = 1;
            var result = cipher.Encode(Text, CharDelimiter, WordDelimiter);
            Assert.AreEqual("١:١٢-١:١١-١:٨-١:٥ / ٣:١١-٣:١٠-١:٢ / ١:٧-٢:٩-٣:٩ / ٢:٣-٢:٢-٢:١-٣:١٢ /" + 
                            " ١:١-٢:٧-٢:٥-٢:١١ / ٢:٤-١:٣-٢:١٢-١:١٠ / ١:٩-١:٦-١:٤ / ٢:١٠-٢:٨-٢:٦", result);
        }

        [TestMethod]
        public void Encode_Mobile1stCipher()
        {
            var cipher = CiphersList.Instance.First(c => c.Name == "الجوال");
            cipher.SetIndex = 0;
            var result = cipher.Encode(Text, CharDelimiter, WordDelimiter);
            Assert.AreEqual("٣-٢-٦-٥ / ٧٧-٧٧٧-٥٥٥٥ / ٦٦-٩-٧٧٧٧ / ٨٨٨-٨٨٨٨-٨٨٨٨٨-٧ " + 
                            "/ ٤-٩٩٩-٨-٤٤٤ / ٨٨-٥٥٥-٤٤-٢٢ / ٢٢٢-٦٦٦-٥٥ / ٤٤٤٤-٩٩-٩٩٩٩", result);
        }

        [TestMethod]
        public void Encode_Mobile2ndCipher()
        {
            var cipher = CiphersList.Instance.First(c => c.Name == "الجوال");
            cipher.SetIndex = 1;
            var result = cipher.Encode(Text, CharDelimiter, WordDelimiter);
            Assert.AreEqual("٣^١-٢^١-٦^١-٥^١ / ٧^٢-٧^٣-٥^٤ / ٦^٢-٩^١-٧^٤ / ٨^٣-٨^٤-٨^٥-٧^١ " + 
                            "/ ٤^١-٩^٣-٨^١-٤^٣ / ٨^٢-٥^٣-٤^٢-٢^٢ / ٢^٣-٦^٣-٥^٢ / ٤^٤-٩^٢-٩^٤", result);
        }

        [TestMethod]
        public void Encode_XCipher()
        {
            var cipher = CiphersList.Instance.First(c => c.Name == "إكس");
            var result = cipher.Encode(Text, CharDelimiter, WordDelimiter);
            Assert.AreEqual("˅١-˅٢-˅٥-˂١ / ˃٥-˃٦-˂٤ / ˅٦-˄٢-˃٧ / ˃١-˃٢-˃٣-˃٤ " +
                            "/ ˂٥-˄٤-˄٦-˂٧ / ˄٧-˂٣-˂٦-˅٣ / ˅٤-˅٧-˂٢ / ˄١-˄٣-˄٥", result);
        }

        [TestMethod]
        public void Encode_StarCipher()
        {
            var cipher = CiphersList.Instance.First(c => c.Name == "النجمة");
            var result = cipher.Encode(Text, CharDelimiter, WordDelimiter);
            Assert.AreEqual("▲١-▲٢-▲٥-▶١ / ◀٥-◀٦-▶٤ / ▲٦-▼٢-◀٧ / ◀١-◀٢-◀٣-◀٤ / " +
                            "▶٥-▼٤-▼٦-▶٧ / ▼٧-▶٣-▶٦-▲٣ / ▲٤-▲٧-▶٢ / ▼١-▼٣-▼٥", result);
        }

        [TestMethod]
        public void Encode_RhombusCipher()
        {
            var cipher = CiphersList.Instance.First(c => c.Name == "المعين");
            var result = cipher.Encode(Text, CharDelimiter, WordDelimiter);
            Assert.AreEqual("١◣-١◢-٢◣-٢◥ / ٧◢-٧◤-٣◤ / ٢◢-٤◥-٧◥ / ٦◢-٦◤-٦◥-٧◣" + 
                            " / ٣◥-٥◢-٥◥-٤◢ / ٦◣-٣◢-٤◣-١◤ / ١◥-٢◤-٣◣ / ٤◤-٥◣-٥◤", result);
        }

        [TestMethod]
        public void Encode_TriangleCipher()
        {
            var cipher = CiphersList.Instance.First(c => c.Name == "المثلث");
            var result = cipher.Encode(Text, CharDelimiter, WordDelimiter);
            Assert.AreEqual("١▲-٢◣◼-٣◼(١)-٤◼(١) / ٧◼(٤)-٧◼(٥)-٥◣◼ / ٣◼◢-٦◣◼-٧◼◢ /" +
                            " ٧◣◼-٧◼(١)-٧◼(٢)-٧◼(٣) / ٥◼(١)-٦◼(٢)-٦◼(٤)-٥◼(٣) /" +
                            " ٦◼◢-٤◼◢-٥◼(٢)-٢◼◢ / ٣◣◼-٤◣◼-٤◼(٢) / ٥◼◢-٦◼(١)-٦◼(٣)", result);
        }

        [TestMethod]
        public void Encode_PunctuationMarks()
        {
            var cipher = new Cipher();
            var result = cipher.Encode(".,:\"\"''-?؟!()[]", CharDelimiter, WordDelimiter);
            Assert.AreEqual(" .  ,  :  \"  \"  '  '  -  ?  ؟  !  (  )  [  ] ", result);
        }

        [TestMethod]
        public void Encode_OddCharacters()
        {
            var cipher = new Cipher
            {
                CharactersSets =
                {
                    new CharactersSet
                    {
                        Characters =
                        {
                            "ا", "ب", "ت", "ث", "ج", "ح", "خ",
                            "د", "ذ", "ر", "ز", "س", "ش", "ص",
                            "ض", "ط", "ظ", "ع", "غ", "ف", "ق",
                            "ك", "ل", "م", "ن", "ه", "و", "ي"
                        }
                    }
                }
            };

            var result = cipher.Encode("اإأآءةؤئيى", "", "");

            Assert.AreEqual("اااااهوييي", result);
        }
    }
}
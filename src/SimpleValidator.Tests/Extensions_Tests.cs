using System;
using SimpleValidator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using SimpleValidator.Extensions;

namespace SimpleValidator.Tests
{
    [TestClass]
    public class Extensions_Tests
    {
        #region " Helpers "

        public static List<object> GetTestListObjectNullEmptyAndWhiteSpace()
        {
            List<object> objects = new List<object>();

            objects.Add(null);
            objects.Add(string.Empty);
            objects.Add("");
            objects.Add(" ");
            objects.Add("  ");
            objects.Add(@"\t");
            objects.Add(@"\n\r");
            objects.Add(@"\r");
            objects.Add(Guid.NewGuid());
            objects.Add(true);
            objects.Add("null");

            return objects;
        }

        public static List<string> GetTestListStringNullEmptyAndWhiteSpace()
        {
            List<string> objects = new List<string>();

            objects.Add(null);
            objects.Add(string.Empty);
            objects.Add("");
            objects.Add(" ");
            objects.Add("  ");
            objects.Add(@"\t");
            objects.Add(@"\n\r");
            objects.Add(@"\r");
            objects.Add(Guid.NewGuid().ToString());
            objects.Add("null");

            return objects;
        }

        #endregion

        [TestMethod]
        public void Test_IsNotNullOrEmpty()
        {
            List<string> inputs = new List<string>()
            {
                null,  // fail
                string.Empty,  // fail
                "",  // fail
                " ",
                "   ",
                "\t",
                "\n\r",
                "\r",
                "&nbsp;",
                "abcdef",
                "null",
                "⁰⁴⁵₀₁₂",
                "田中さんにあげて下さい",
                "😍",
                "﷽",
                " ",
                "␣"
            };

            int fails = 0;

            foreach (var item in inputs)
            {
                if (!item.IsNotNullOrEmpty())
                {
                    fails++;
                }
            }

            Assert.IsTrue(fails == 3);
        }

        [TestMethod]
        public void Test_IsNotNullOrWhiteSpace()
        {
            List<string> inputs = new List<string>()
            {
                null, // fail
                string.Empty, // fail
                "", // fail
                " ", // fail
                "   ", // fail
                "\t", // fail
                "\n\r", // fail
                "\r", // fail
                "&nbsp;",
                "abcdef",
                "null",
                "⁰⁴⁵₀₁₂",
                "田中さんにあげて下さい",
                "😍",
                "﷽",
                " ", // fail
                "␣",
                Environment.NewLine // fail
            };

            int fails = 0;

            foreach (var item in inputs)
            {
                if (!item.IsNotNullOrWhiteSpace())
                {
                    fails++;
                }
            }

            Assert.IsTrue(fails == 10);
        }

        [TestMethod]
        public void Test_IsBetweenLength()
        {
            List<string> inputs = new List<string>()
            {
                null, // fail
                string.Empty, // fail
                "", // fail
                " ", // fail
                "   ",
                "1", // fail
                "12", // fail
                "123",
                "12345",
                "123456",  // fail
                "1234567",  // fail
                "       "  // fail
            };

            int fails = 0;

            foreach (var item in inputs)
            {
                if (!item.IsBetweenLength(3, 5))
                {
                    fails++;
                }
            }

            Assert.IsTrue(fails == 9);
        }

        [TestMethod]
        public void Test_IsMaxLength()
        {
            List<string> inputs = new List<string>()
            {
                null,
                string.Empty,
                "",
                " ",
                "   ",
                "1",
                "12",
                "123",
                "12345",
                "123456",  // fail
                "1234567",  // fail
                "       "  // fail
            };

            int fails = 0;

            foreach (var item in inputs)
            {
                if (!item.IsMaxLength(5))
                {
                    fails++;
                }
            }

            Assert.IsTrue(fails == 3);
        }

        [TestMethod]
        public void Test_IsMinLength()
        {
            List<string> inputs = new List<string>()
            {
                null,   // fail
                string.Empty, // fail
                "", // fail
                " ", // fail
                "   ",
                "1", // fail
                "12", // fail
                "123",
                "12345",
                "123456",
                "1234567",
                "       "
            };

            int fails = 0;

            foreach (var item in inputs)
            {
                if (!item.IsMinLength(0))
                {
                    fails++;
                }
            }

            foreach (var item in inputs)
            {
                if (!item.IsMinLength(3))
                {
                    fails++;
                }
            }

            Assert.IsTrue(fails == 6);
        }

        [TestMethod]
        public void Test_IsExactLength()
        {
            List<string> inputs = new List<string>()
            {
                null,
                string.Empty,
                "",
                " ",
                "   ",
                "1",
                "12",
                "123",
                "12345",
                "123456",
                "1234567",
                "       "
            };

            int fails = 0;

            foreach (var item in inputs)
            {
                if (!item.IsExactLength(0))
                {
                    fails++;
                }
            } // 9 fails

            foreach (var item in inputs)
            {
                if (!item.IsExactLength(3))
                {
                    fails++;
                }
            } // 10 fails

            Assert.IsTrue(fails == 19);
        }
    }
}

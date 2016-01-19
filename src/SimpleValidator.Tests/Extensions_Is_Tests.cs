using System;
using SimpleValidator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32;
using SimpleValidator.Extensions;
using SimpleValidator.Results;

namespace SimpleValidator.Tests
{
    [TestClass]
    public class Extensions_Is_Tests
    {
        public static List<string> GetTestData()
        {
            return new List<string>()
            {
                "",
                "a",
                "abc",
                "1",
                "0",
                "1.1",
                "1.1.1",
                "1000000000000",
                "0.000000001",
                "true",
                "True",
                "False",
                "false",
                "blah blah",
                " ",
                "      ",
                "0.9999",
                "123",
                "-234"
            };
        }

        [TestMethod]
        public void Test_IsInt()
        {
            int pass = GetTestData().Count(input => input.IsInt());

            Assert.IsTrue(pass == 4);
        }

        [TestMethod]
        public void Test_IsShort()
        {
            int pass = GetTestData().Count(input => input.IsShort());

            Assert.IsTrue(pass == 4);
        }

        [TestMethod]
        public void Test_IsLong()
        {
            int pass = GetTestData().Count(input => input.IsLong());

            Assert.IsTrue(pass == 5);
        }

        [TestMethod]
        public void Test_IsDouble()
        {
            int pass = GetTestData().Count(input => input.IsDouble());

            Assert.IsTrue(pass == 8);
        }

        [TestMethod]
        public void Test_IsDecimal()
        {
            int pass = GetTestData().Count(input => input.IsDecimal());

            Assert.IsTrue(pass == 8);
        }

        [TestMethod]
        public void Test_IsBool()
        {
            int pass = GetTestData().Count(input => input.IsBool());

            Assert.IsTrue(pass == 4);
        }
    }
}

using System;
using SimpleValidator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SimpleValidator.Tests
{
    [TestClass]
    public class Validator_IsMatch_Tests
    {
        [TestMethod]
        public void Test_Matches()
        {
            string input = "abc123";

            Validator validator = new Validator();

            validator.IsMatch(input, "");
            validator.IsMatch(input, "a");
            validator.IsMatch(input, "ab");
            validator.IsMatch(input, "abc");
            validator.IsMatch(input, "1");
            validator.IsMatch(input, "12");
            validator.IsMatch(input, "123");
            validator.IsMatch(input, "abc123");
            validator.IsMatch(input, "Abc123");
            validator.IsMatch(input, "aBc123");
            validator.IsMatch(input, "abC123");
            validator.IsMatch(input, "abc123 ");
            validator.IsMatch(input, " abc123");
            validator.IsMatch(input, null);
            validator.IsMatch(input, "****");

            Assert.IsTrue(validator.Errors.Count == 14);
        }

        [TestMethod]
        public void Test_Inputs()
        {
            string match = "abc123";

            Validator validator = new Validator();

            validator.IsMatch("", match);
            validator.IsMatch("a", match);
            validator.IsMatch("ab", match);
            validator.IsMatch("abc", match);
            validator.IsMatch("1", match);
            validator.IsMatch("12", match);
            validator.IsMatch("123", match);
            validator.IsMatch("abc123", match);
            validator.IsMatch("Abc123", match);
            validator.IsMatch("aBc123", match);
            validator.IsMatch("abC123", match);
            validator.IsMatch("abc123 ", match);
            validator.IsMatch(" abc123", match);
            validator.IsMatch(null, match);
            validator.IsMatch("****", match);

            Assert.IsTrue(validator.Errors.Count == 14);
        }
    }
}

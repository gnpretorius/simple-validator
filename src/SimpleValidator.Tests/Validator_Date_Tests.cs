using System;
using SimpleValidator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SimpleValidator.Tests
{
    [TestClass]
    public class Validator_Date_Tests
    {
        [TestMethod]
        public void Test_IsGreaterThan()
        {
            Validator validator = new Validator();

            validator.IsGreaterThan(DateTime.Now, DateTime.Now.AddSeconds(-5));
            validator.IsGreaterThan(DateTime.Now, DateTime.Now.AddMinutes(-5));
            validator.IsGreaterThan(DateTime.Now.Date, DateTime.Now.AddDays(-1));
            validator.IsGreaterThan(DateTime.Now, DateTime.Now.AddSeconds(1)); // fail

            Assert.IsTrue(validator.Errors.Count == 1);
        }

        [TestMethod]
        public void Test_IsGreaterThanOrEqualTo()
        {
            Validator validator = new Validator();

            validator.IsGreaterThanOrEqualTo(DateTime.Now, DateTime.Now.AddSeconds(-5));
            validator.IsGreaterThanOrEqualTo(DateTime.Now, DateTime.Now.AddMinutes(-5));
            validator.IsGreaterThanOrEqualTo(DateTime.Now.Date, DateTime.Now.AddDays(-1));
            validator.IsGreaterThanOrEqualTo(DateTime.Now, DateTime.Now);
            validator.IsGreaterThanOrEqualTo(DateTime.Now.Date, DateTime.Now.AddDays(-1).Date);
            validator.IsGreaterThanOrEqualTo(DateTime.Now.Date, DateTime.Now.Date);
            validator.IsGreaterThan(DateTime.Now, DateTime.Now.AddSeconds(1)); // fail

            Assert.IsTrue(validator.Errors.Count == 1);
        }

        [TestMethod]
        public void Test_IsLessThan()
        {
            Validator validator = new Validator();

            validator.IsLessThan(DateTime.Now, DateTime.Now.AddSeconds(5));
            validator.IsLessThan(DateTime.Now, DateTime.Now.AddMinutes(5));
            validator.IsLessThan(DateTime.Now.Date, DateTime.Now.AddDays(1));
            validator.IsLessThan(DateTime.Now, DateTime.Now.AddSeconds(-1)); // fail

            Assert.IsTrue(validator.Errors.Count == 1);
        }

        [TestMethod]
        public void Test_IsLessThanOrEqualTo()
        {
            Validator validator = new Validator();

            validator.IsLessThanOrEqualTo(DateTime.Now, DateTime.Now.AddSeconds(5));
            validator.IsLessThanOrEqualTo(DateTime.Now, DateTime.Now.AddMinutes(5));
            validator.IsLessThanOrEqualTo(DateTime.Now.Date, DateTime.Now.AddDays(1));
            validator.IsLessThanOrEqualTo(DateTime.Now, DateTime.Now);
            validator.IsLessThanOrEqualTo(DateTime.Now.Date, DateTime.Now.AddDays(1).Date);
            validator.IsLessThanOrEqualTo(DateTime.Now.Date, DateTime.Now.Date);
            validator.IsLessThanOrEqualTo(DateTime.Now, DateTime.Now.AddSeconds(-1)); // fail

            Assert.IsTrue(validator.Errors.Count == 1);
        }

        [TestMethod]
        public void Test_IsEqualTo()
        {
            Validator validator = new Validator();

            validator.IsEqualTo(DateTime.Now, DateTime.Now.AddSeconds(5));  // fail
            validator.IsEqualTo(DateTime.Now, DateTime.Now);
            validator.IsEqualTo(DateTime.Now.Date, DateTime.Now.Date);
            validator.IsEqualTo(DateTime.Now, DateTime.Now.AddMilliseconds(-1)); // fail

            Assert.IsTrue(validator.Errors.Count == 2);
        }

        [TestMethod]
        public void Test_IsBetweenInclusive()
        {
            Validator validator = new Validator();

            validator.IsBetweenInclusive(new DateTime(2016, 1, 10), new DateTime(2016, 1, 8), new DateTime(2016, 1, 12));
            validator.IsBetweenInclusive(new DateTime(2016, 1, 8), new DateTime(2016, 1, 8), new DateTime(2016, 1, 12));
            validator.IsBetweenInclusive(new DateTime(2016, 1, 6), new DateTime(2016, 1, 8), new DateTime(2016, 1, 12)); // fail
            validator.IsBetweenInclusive(new DateTime(2016, 1, 12), new DateTime(2016, 1, 8), new DateTime(2016, 1, 12));
            validator.IsBetweenInclusive(new DateTime(2016, 1, 14), new DateTime(2016, 1, 8), new DateTime(2016, 1, 12)); // fail

            Assert.IsTrue(validator.Errors.Count == 2);
        }

        [TestMethod]
        public void Test_IsBetweenExclusive()
        {
            Validator validator = new Validator();

            validator.IsBetweenExclusive(new DateTime(2016, 1, 10), new DateTime(2016, 1, 8), new DateTime(2016, 1, 12));
            validator.IsBetweenExclusive(new DateTime(2016, 1, 8), new DateTime(2016, 1, 8), new DateTime(2016, 1, 12)); // fail
            validator.IsBetweenExclusive(new DateTime(2016, 1, 6), new DateTime(2016, 1, 8), new DateTime(2016, 1, 12)); // fail
            validator.IsBetweenExclusive(new DateTime(2016, 1, 12), new DateTime(2016, 1, 8), new DateTime(2016, 1, 12)); // fail
            validator.IsBetweenExclusive(new DateTime(2016, 1, 14), new DateTime(2016, 1, 8), new DateTime(2016, 1, 12)); // fail

            Assert.IsTrue(validator.Errors.Count == 4);
        }


    }
}

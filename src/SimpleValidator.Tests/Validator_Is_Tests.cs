using System;
using SimpleValidator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SimpleValidator.Extensions;

namespace SimpleValidator.Tests
{
    [TestClass]
    public class Validator_Is_Tests
    {
        [TestMethod]
        public void Test_IsGreaterThan()
        {
            Validator validator = new Validator();

            validator.Is(() => 5.IsGreaterThan(1));

            Assert.IsTrue(validator.Errors.Count == 0);
        }

    }
}

using System;
using SimpleValidator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SimpleValidator.Tests
{
	[TestClass]
	public class Validator_Init_Tests
	{
		[TestMethod]
		public void Test_Object_Creation()
		{
            Validator val = new Validator();

            Assert.IsNotNull(val);
            Assert.IsNotNull(val.Errors);
            Assert.IsTrue(val.Errors.Count == 0);
		}

        [TestMethod]
        public void Test_Error_Message_Returns()
        {
            Validator val = new Validator();
            val.IsMatch("abc", "abc").WithMessage("This is a message");
            Assert.IsNotNull(val.Errors.Count == 0);
        }
	}
}

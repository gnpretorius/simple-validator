using System;
using SimpleValidator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SimpleValidator.Tests
{
	[TestClass]
	public class ValidatorTests
	{
		[TestMethod]
		public void Test_Object_Creation()
		{
            Validator val = new Validator();

            Assert.IsNotNull(val);
            Assert.IsNotNull(val.Errors);
            Assert.IsTrue(val.Errors.Count == 0);
		}
	}
}

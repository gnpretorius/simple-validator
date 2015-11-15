using System;
using SimpleValidator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SimpleValidator.Tests
{
	[TestClass]
	public class EmailTests
	{
		[TestMethod]
		public void Test_Invalid_Email()
		{
			string email = "InvalidEmail";

			Validator validator = new Validator();

			validator.IsEmail(email);

			Assert.IsTrue(validator.Errors.Count == 1);
		}

		[TestMethod]
		public void Test_Invalid_Emails()
		{
			List<string> emails = new List<string>()
			{
				"valid@test.com", // valid
				"valid@t.com", // valid
				"v@v.co", // valid
				"@v.com", // invalid
				"v@.co", // invalid
				"v@v" // invalid
			};

			Validator validator = new Validator();

			foreach (var email in emails)
			{
				validator.IsEmail(email);
			}

			Assert.IsTrue(validator.Errors.Count == 3);
		}

		[TestMethod]
		public void Test_Email_Message()
		{
			string email = "InvalidEmail";

			Validator validator = new Validator();

			validator.IsEmail(email).WithMessage("Test message");

			Assert.AreEqual(validator.Errors[0].Message, "Test message");
		}

		[TestMethod]
		public void Test_Multiple_Email_Message()
		{
			List<string> emails = new List<string>()
			{
				"v@v.co", // valid
				"@v.com", // invalid
				"valid@t.com", // valid
				"v@.co", // invalid
				"valid@test.com", // valid
				"v@v" // invalid
			};

			Validator validator = new Validator();

			for (int i = 0; i < emails.Count; i++)
			{
				validator.IsEmail(emails[i]).WithMessage("Message " + i);
			}

			Assert.IsTrue(validator.Errors.Count == 3);
			Assert.AreEqual(validator.Errors[0].Message, "Message 1");
			Assert.AreEqual(validator.Errors[1].Message, "Message 3");
			Assert.AreEqual(validator.Errors[2].Message, "Message 5");
		}
	}
}

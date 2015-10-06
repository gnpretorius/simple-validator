using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleValidator;

namespace SimpleValidator.Tests
{
    [TestClass]
    public class Validator_IsMinLength_Tests
    {
        [TestMethod]
        public void Test_IsMinLength()
        {
            string input = "12345";

            Validator validator = new Validator();

            validator.IsMinLength(input, 1);
            validator.IsMinLength(input, 2);
            validator.IsMinLength(input, 3);
            validator.IsMinLength(input, 4);
            validator.IsMinLength(input, 5);
            validator.IsMinLength(input, 6);
            validator.IsMinLength(input, 7);

            Assert.IsTrue(validator.Errors.Count == 2);
        }

        [TestMethod]
        public void Test_IsMinLength_Null()
        {
            string input = null;

            Validator validator = new Validator();

            validator.IsMinLength(input, 1);
            validator.IsMinLength(input, 2);
            validator.IsMinLength(input, 3);
            validator.IsMinLength(input, 4);
            validator.IsMinLength(input, 5);
            validator.IsMinLength(input, 6);
            validator.IsMinLength(input, 7);

            Assert.IsTrue(validator.Errors.Count == 7);
        }

        [TestMethod]
        public void Test_IsMinLength_String_Empty()
        {
            string input = string.Empty;

            Validator validator = new Validator();

            validator.IsMinLength(input, 1);
            validator.IsMinLength(input, 2);
            validator.IsMinLength(input, 3);
            validator.IsMinLength(input, 4);
            validator.IsMinLength(input, 5);
            validator.IsMinLength(input, 6);
            validator.IsMinLength(input, 7);

            Assert.IsTrue(validator.Errors.Count == 7);
        }

        [TestMethod]
        public void Test_IsMinLength_With_Name()
        {
            string input = "12345";

            Validator validator = new Validator();

            validator.IsMinLength("Input1", input, 1);
            validator.IsMinLength("Input2", input, 2);
            validator.IsMinLength("Input3", input, 3);
            validator.IsMinLength("Input4", input, 4);
            validator.IsMinLength("Input5", input, 5);
            validator.IsMinLength("Input6", input, 6);
            validator.IsMinLength("Input7", input, 7);

            Assert.IsTrue(validator.Errors.Count == 2, "Error Count");
            Assert.IsTrue(validator.Errors[0].Name == "Input6", "Error 1 Name");
            Assert.IsTrue(validator.Errors[1].Name == "Input7", "Error 2 Name");
        }

        [TestMethod]
        public void Test_IsMinLength_With_Name_Message()
        {
            string input = "12345";

            Validator validator = new Validator();

            validator.IsMinLength("Input", input, 1, "Message1");
            validator.IsMinLength("Input", input, 2, "Message2");
            validator.IsMinLength("Input", input, 3, "Message3");
            validator.IsMinLength("Input", input, 4, "Message4");
            validator.IsMinLength("Input", input, 5, "Message5");
            validator.IsMinLength("Input", input, 6, "Message6");
            validator.IsMinLength("Input", input, 7, "Message7");

            Assert.IsTrue(validator.Errors.Count == 2);
            Assert.IsTrue(validator.Errors[0].Message == "Message6");
            Assert.IsTrue(validator.Errors[1].Message == "Message7");
        }
    }
}

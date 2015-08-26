using System;
using SimpleValidator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SimpleValidator.Extensions;

namespace SimpleValidator.Tests
{
    [TestClass]
    public class Validator_IsNotNull_Tests
    {
        #region " Helpers "

        public static List<object> GetTestObjects()
        {
            List<object> objects = new List<object>();

            objects.Add(null);
            objects.Add(string.Empty);
            objects.Add("");
            objects.Add(Guid.NewGuid());
            objects.Add(true);
            objects.Add("null");

            return objects;
        }

        #endregion

        [TestMethod]
        public void Test_IsNotNull()
        {
            Validator validator = new Validator();

            foreach (var obj in GetTestObjects())
            {
                validator.IsNotNull(obj);
            }

            Assert.IsTrue(validator.Errors.Count == 1);
        }

        [TestMethod]
        public void Test_IsNotNull_With_Name()
        {
            Validator validator = new Validator();

            foreach (var obj in GetTestObjects())
            {
                validator.IsNotNull("Object", obj);
            }

            Assert.IsTrue(validator.Errors.Count == 1);
            Assert.IsTrue(validator.Errors[0].Name == "Object");
        }

        [TestMethod]
        public void Test_IsNotNull_With_Name_Message()
        {
            Validator validator = new Validator();

            foreach (var obj in GetTestObjects())
            {
                validator.IsNotNull("Object", obj, "Error");
            }

            Assert.IsTrue(validator.Errors.Count == 1);
            Assert.IsTrue(validator.Errors[0].Name == "Object");
            Assert.IsTrue(validator.Errors[0].Message == "Error");
        }
    }
}

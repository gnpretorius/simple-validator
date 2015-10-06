using System;
using SimpleValidator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SimpleValidator.Extensions;

namespace SimpleValidator.Tests
{
    [TestClass]
    public class Extensions_IsNotNull_Tests
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
            List<object> objects = GetTestObjects();

            Assert.IsFalse(objects[0].IsNotNull());
            Assert.IsTrue(objects[1].IsNotNull());
            Assert.IsTrue(objects[2].IsNotNull());
            Assert.IsTrue(objects[3].IsNotNull());
            Assert.IsTrue(objects[4].IsNotNull());
            Assert.IsTrue(objects[5].IsNotNull());
        }
    }
}

using System;
using Common;
using Day14.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day14.Tests
{
    [TestClass]
    public class HashGeneratorTests
    {
        #region Triple Tests

        [TestMethod]
        public void Validate_Contains_Triple_Test_1()
        {
            string result = HashGenerator.GetHashedString(18, "abc");
            Console.WriteLine(result);
            Assert.AreEqual("888", KeyValidator.GetFirstTriple(result));
        }

        [TestMethod]
        public void Validate_Contains_Triple_Test_2()
        {
            string result = HashGenerator.GetHashedString(39, "abc");
            Console.WriteLine(result);
            Assert.AreEqual("eee", KeyValidator.GetFirstTriple(result));
        }

        #endregion
    }
}

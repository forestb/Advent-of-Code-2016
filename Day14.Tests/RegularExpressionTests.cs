using System;
using Common;
using Day14.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HashGenerator = Day14.Classes.HashGenerator;

namespace Day14.Tests
{
    [TestClass]
    public class RegularExpressionTests
    {
        #region Triple Tests

        [TestMethod]
        public void Validate_Contains_Triple_Test_1()
        {
            string result = HashGenerator.GetHashedString(18, "abc");
            Console.WriteLine(result);
            Assert.IsTrue(KeyValidator.HasTriple(result));
        }

        [TestMethod]
        public void Validate_Contains_Triple_Test_2()
        {
            string result = HashGenerator.GetHashedString(39, "abc");
            Console.WriteLine(result);
            Assert.IsTrue(KeyValidator.HasTriple(result));
        }

        #endregion

        #region Five-Finder Tests

        [TestMethod]
        public void Validate_Contains_5_Beginning()
        {
            Assert.IsTrue(KeyValidator.HasFive("EEEEEVABC", "E"));
        }

        [TestMethod]
        public void Validate_Contains_5_Middle()
        {
            Assert.IsTrue(KeyValidator.HasFive("ABCVEEEEEVXYZ", "E"));
        }

        [TestMethod]
        public void Validate_Contains_5_End()
        {
            Assert.IsTrue(KeyValidator.HasFive("ABCVEEEEE", "E"));
        }

        #endregion
    }
}

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
            Assert.IsTrue(KeyValidator.HasTriple(result));
            Assert.AreEqual("eee", KeyValidator.GetFirstTriple(result));
        }

        #endregion

        #region Ridiculously Hashed Tests (Part 2)

        [TestMethod]
        public void Verify_Ridiculous_Hash_Valid_1()
        {
            string result = HashGenerator.GetRidiculouslyHashedString(5, "abc");
            Assert.IsTrue(KeyValidator.HasTriple(result));
        }

        [TestMethod]
        public void Verify_Ridiculous_Hash_Valid_2()
        {
            string candidate = HashGenerator.GetRidiculouslyHashedString(10, "abc");
            string validatedCandidate = HashGenerator.GetRidiculouslyHashedString(89, "abc");

            Assert.IsTrue(KeyValidator.HasTriple(candidate));
            Assert.IsTrue(KeyValidator.HasFive(validatedCandidate, KeyValidator.GetFirstTriple(candidate).Substring(0, 1)));
        }

        [TestMethod]
        public void Verify_Ridiculous_Hash_Valid_3()
        {
            string candidate = HashGenerator.GetRidiculouslyHashedString(22551, "abc");
            string validatedCandidate = HashGenerator.GetRidiculouslyHashedString(22859, "abc");

            Console.WriteLine($"Candidate: {candidate}");
            Console.WriteLine($"ValidatedCandidate: {validatedCandidate}");

            Assert.IsTrue(KeyValidator.HasTriple(candidate));
            Assert.IsTrue(KeyValidator.HasFive(validatedCandidate, KeyValidator.GetFirstTriple(candidate).Substring(0, 1)));
        }

        #endregion
    }
}

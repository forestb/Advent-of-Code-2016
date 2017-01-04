using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Tests
{
    [TestClass]
    public class HashGeneratorTests
    {
        #region HashSet Tests

        [TestMethod]
        public void Validate_Hash_Generator_Output_NoSalt_1()
        {
            string expectedOutput = "ced9fc52441937264674bca3f4ba7588";

            string hashResult = HashGenerator.GetHashedString("hijkl");
            Console.WriteLine(hashResult);
            Assert.AreEqual(expectedOutput, hashResult);
        }

        #endregion
    }
}

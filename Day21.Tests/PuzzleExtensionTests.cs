using System;
using Day21.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day21.Tests
{
    [TestClass]
    public class PuzzleExtensionTests
    {
        [TestMethod]
        public void TestMethod_MoveByPosition_1()
        {
            // put the r after the e
            // so, put character 2 at position 3
            Assert.AreEqual("foerst", "forest".MoveByPosition(2, 3));
        }

        [TestMethod]
        public void TestMethod_MoveByPosition_2()
        {
            // put the e before the r
            // so, put character 3 at position 2
            Assert.AreEqual("foerst", "forest".MoveByPosition(2, 3));
        }

        [TestMethod]
        public void TestMethod_MoveByPosition_3()
        {
            // leave the second character alone
            Assert.AreEqual("forest", "forest".MoveByPosition(2, 2));
        }

        [TestMethod]
        public void TestMethod_ReverseByPositions_1()
        {
            // leave the second character alone
            Assert.AreEqual("agfedcbh", "abcdefgh".ReverseByPositions(1, 6));
        }

        [TestMethod]
        public void TestMethod_ReverseByPositions_2()
        {
            // leave the second character alone
            Assert.AreEqual("abcdhgfe", "abcdefgh".ReverseByPositions(4, 7));
        }
    }
}

using System;
using Day13.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day13.Tests
{
    [TestClass]
    public class CoordinateCalculatorTests
    {
        #region Wall Tests

        [TestMethod]
        public void TestMethod_Wall1()
        {
            Assert.AreEqual((int)CoordinateType.WALL, CoordinateCalculator.GetCoordinateType(1, 0, 10));
        }

        [TestMethod]
        public void TestMethod_Wall2()
        {
            Assert.AreEqual((int)CoordinateType.WALL, CoordinateCalculator.GetCoordinateType(0, 6, 10));
        }

        [TestMethod]
        public void TestMethod_Wall3()
        {
            Assert.AreEqual((int)CoordinateType.WALL, CoordinateCalculator.GetCoordinateType(8, 0, 10));
        }

        [TestMethod]
        public void TestMethod_Wall4()
        {
            Assert.AreEqual((int)CoordinateType.WALL, CoordinateCalculator.GetCoordinateType(9, 1, 10));
        }

        #endregion

        #region Open Space Tests

        [TestMethod]
        public void TestMethod_OpenSpace1()
        {
            Assert.AreEqual((int)CoordinateType.OPEN_SPACE, CoordinateCalculator.GetCoordinateType(0, 1, 10));
        }

        [TestMethod]
        public void TestMethod_OpenSpace2()
        {
            Assert.AreEqual((int)CoordinateType.OPEN_SPACE, CoordinateCalculator.GetCoordinateType(9, 5, 10));
        }

        [TestMethod]
        public void TestMethod_OpenSpace3()
        {
            Assert.AreEqual((int)CoordinateType.OPEN_SPACE, CoordinateCalculator.GetCoordinateType(6, 4, 10));
        }

        [TestMethod]
        public void TestMethod_OpenSpace4()
        {
            Assert.AreEqual((int)CoordinateType.OPEN_SPACE, CoordinateCalculator.GetCoordinateType(7, 0, 10));
        }

        #endregion
    }
}

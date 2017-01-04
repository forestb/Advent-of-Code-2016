using System;
using Day16.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day16.Tests
{
    [TestClass]
    public class DragonCurveContainerTests
    {
        [TestMethod]
        public void Validate_ToString_1()
        {
            string input = "1";
            string output = "100";

            DragonCurveContainer c = new DragonCurveContainer(input);
            Assert.AreEqual(output, c.ToString());
        }

        [TestMethod]
        public void Validate_ToString_2()
        {
            string input = "0";
            string output = "001";

            DragonCurveContainer c = new DragonCurveContainer(input);
            Assert.AreEqual(output, c.ToString());
        }

        [TestMethod]
        public void Validate_ToString_3()
        {
            string input = "11111";
            string output = "11111000000";

            DragonCurveContainer c = new DragonCurveContainer(input);
            Assert.AreEqual(output, c.ToString());
        }

        [TestMethod]
        public void Validate_ToString_4()
        {
            string input = "111100001010";
            string output = "1111000010100101011110000";

            DragonCurveContainer c = new DragonCurveContainer(input);
            Assert.AreEqual(output, c.ToString());
        }

        [TestMethod]
        public void Validate_CheckSum_Calculation_1()
        {
            string input = "110010110100";
            string output = "100";
            
            Assert.AreEqual(output, DragonCurveCheckSumCalculator.CalculateCheckSum(input));
        }
    }
}

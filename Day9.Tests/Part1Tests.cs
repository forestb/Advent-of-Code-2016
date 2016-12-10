using Day9.Part1;
using Day9.PuzzleInput;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day9.Tests
{
    [TestClass]
    public class Part1Tests
    {
        [TestMethod]
        public void TestSampleInput1()
        {
            Qa puzzleInput = PuzzleQa.PuzzleInputPart1Sample1;
            Assert.AreEqual(puzzleInput.ExpectedOutputLength, InstructionProcessor.Process(puzzleInput.Input));
        }

        [TestMethod]
        public void TestSampleInput2()
        {
            
        }

        [TestMethod]
        public void TestSampleInput3()
        {
            
        }

        [TestMethod]
        public void TestSampleInput4()
        {
            
        }

        [TestMethod]
        public void TestSampleInput5()
        {
            
        }

        [TestMethod]
        public void TestSampleInput6()
        {
            
        }
    }
}

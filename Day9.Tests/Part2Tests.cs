using Day9.Part2;
using Day9.PuzzleInput;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Marker = Day9.Part2.Marker;

namespace Day9.Tests
{
    [TestClass]
    public class Part2Tests
    {
        [TestMethod]
        public void TestMarker2Parser()
        {
            // the substring is 18
            // the multiplier is 9
            string input = "(18x9)(3x2)";

            Assert.AreEqual(18, Marker.GetFirstMarker(input).SubstringLength);
            Assert.AreEqual(9, Marker.GetFirstMarker(input).Multiplier);
            Assert.AreEqual(6, Marker.GetFirstMarker(input).OriginalMarkerStrLength);
        }

        [TestMethod]
        public void TestMarker2Parser2()
        {
            // the substring is 18
            // the multiplier is 9
            string input = "(3x2)";

            Assert.AreEqual(3, Marker.GetFirstMarker(input).SubstringLength);
            Assert.AreEqual(2, Marker.GetFirstMarker(input).Multiplier);
            Assert.AreEqual(5, Marker.GetFirstMarker(input).OriginalMarkerStrLength);
        }

        [TestMethod]
        public void TestSampleInput1Length()
        {
            Qa puzzleInput = PuzzleQa.PuzzleInputPart2Sample1;

            Assert.AreEqual(puzzleInput.ExpectedOutputLength.GetValueOrDefault(0),
                InstructionProcessor.Process(puzzleInput.Input));
        }

        [TestMethod]
        public void TestSampleInput2Length()
        {
            Qa puzzleInput = PuzzleQa.PuzzleInputPart2Sample2;
            Assert.AreEqual(puzzleInput.ExpectedOutputLength.GetValueOrDefault(0),
                InstructionProcessor.Process(puzzleInput.Input));
        }

        [TestMethod]
        public void TestSampleInput3Length()
        {
            Qa puzzleInput = PuzzleQa.PuzzleInputPart2Sample3;

            Assert.AreEqual(puzzleInput.ExpectedOutputLength.GetValueOrDefault(0),
                InstructionProcessor.Process(puzzleInput.Input));
        }

        [TestMethod]
        public void TestSampleInput4Length()
        {
            Qa puzzleInput = PuzzleQa.PuzzleInputPart2Sample4;

            Assert.AreEqual(puzzleInput.ExpectedOutputLength.GetValueOrDefault(0),
                InstructionProcessor.Process(puzzleInput.Input));
        }
    }
}

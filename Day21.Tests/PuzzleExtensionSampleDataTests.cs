using System;
using Day21.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day21.Tests
{
    /// <summary>
    /// Based on the sample puzzle input story
    /// </summary>
    [TestClass]
    public class PuzzleExtensionSampleDataTests
    {
        [TestMethod]
        public void TestMethod_IndexSwap_1()
        {
            // swap position 4 with position 0 swaps the first and last letters, producing the input for the next 
            // step, ebcda.
            Assert.AreEqual("ebcda", "abcde".IndexSwap(0, 4));
        }

        [TestMethod]
        public void TestMethod_LetterSwap_1()
        {
            // swap letter d with letter b swaps the positions of d and b: edcba.
            Assert.AreEqual("edcba", "ebcda".LetterSwap('d', 'b'));
        }

        [TestMethod]
        public void TestMethod_RotateDirection_Right_1()
        {
            // rotate left 1 step shifts all letters left one position, causing the first letter to wrap to the end of 
            // the string: bcdea.
            Assert.AreEqual("dabc", "abcd".RotateDirection(StringRotateDirection.Right, 1));
            Assert.AreEqual("abcd", "dabc".RotateDirection(StringRotateDirection.Left, 1));
        }

        [TestMethod]
        public void TestMethod_RotateBasedOn_1()
        {
            // rotate based on position of letter b finds the index of letter b (1), then rotates the string right once 
            // plus a number of times equal to that index (2)
            Assert.AreEqual("ecabd", "abdec".RotateRightBasedOnPositionOf('b'));
        }

        [TestMethod]
        public void TestMethod_RotateBasedOn_2()
        {
            // rotate based on position of letter d finds the index of letter d (4), then rotates the string right 
            // once, plus a number of times equal to that index, plus an additional time because the index was at 
            // least 4, for a total of 6 right rotations: decab
            Assert.AreEqual("decab", "ecabd".RotateRightBasedOnPositionOf('d'));
        }

        [TestMethod]
        public void TestMethod_ReverseByPositions_1()
        {
            // reverse positions 0 through 4 causes the entire string to be reversed, producing abcde
            Assert.AreEqual("abcde", "edcba".ReverseByPositions(0, 4));
        }

        [TestMethod]
        public void TestMethod_MoveByPosition_1()
        {
            // move position 1 to position 4 removes the letter at position 1 (c), then inserts it at position 4 
            // (the end of the string): bdeac
            Assert.AreEqual("bdeac", "bcdea".MoveByPosition(1, 4));
        }

        [TestMethod]
        public void TestMethod_MoveByPosition_2()
        {
            // move position 3 to position 0 removes the letter at position 3 (a), then inserts it at position 0 
            // (the front of the string): abdec.
            Assert.AreEqual("abdec", "bdeac".MoveByPosition(3, 0));
        }
    }
}

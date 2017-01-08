using System;
using System.Collections.Generic;
using Day20.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day20.Tests
{
    [TestClass]
    public class Part2SmallValuedTests
    {
        // Rule: 0 is an allowed, inclusive value
        // Rule: MaxValue is an allowed, inclusive value

        [TestMethod]
        public void TestMethod_Validate_Empty_List()
        {
            Int64 maxValidValue = 10;
            Int64 expectedResultAllowedRange = 11; // All are allowed, 0 - 10, inclusive
            List<IpRangeSet> rangeSets = new List<IpRangeSet>();

            PuzzleCalculator puzzleCalculator = new PuzzleCalculator(rangeSets, maxValidValue);
            Assert.AreEqual(expectedResultAllowedRange, puzzleCalculator.SitesAllowedCount);
        }

        [TestMethod]
        public void TestMethod_Validate_Full_List()
        {
            Int64 maxValidValue = 10;
            Int64 expectedResultAllowedRange = 0; // All are allowed, 0 - 10, inclusive
            List<IpRangeSet> rangeSets = new List<IpRangeSet>()
            {
                new IpRangeSet("0-10")
            };

            PuzzleCalculator puzzleCalculator = new PuzzleCalculator(rangeSets, maxValidValue);
            Assert.AreEqual(expectedResultAllowedRange, puzzleCalculator.SitesAllowedCount);
        }

        [TestMethod]
        public void TestMethod_Validate_Full_List_Combination_1()
        {
            Int64 maxValidValue = 10;
            Int64 expectedResultAllowedRange = 0; // All are allowed, 0 - 10, inclusive
            List<IpRangeSet> rangeSets = new List<IpRangeSet>()
            {
                new IpRangeSet("0-5"),
                new IpRangeSet("5-10")
            };

            PuzzleCalculator puzzleCalculator = new PuzzleCalculator(rangeSets, maxValidValue);
            Assert.AreEqual(expectedResultAllowedRange, puzzleCalculator.SitesAllowedCount);

            // Reverse the puzzle input
            rangeSets.Reverse();
            puzzleCalculator = new PuzzleCalculator(rangeSets, maxValidValue);
            Assert.AreEqual(expectedResultAllowedRange, puzzleCalculator.SitesAllowedCount);
        }

        [TestMethod]
        public void TestMethod_Validate_Full_List_Combination_2()
        {
            Int64 maxValidValue = 10;
            Int64 expectedResultAllowedRange = 0; // All are allowed, 0 - 10, inclusive
            List<IpRangeSet> rangeSets = new List<IpRangeSet>()
            {
                new IpRangeSet("5-10"),
                new IpRangeSet("0-5")
            };

            PuzzleCalculator puzzleCalculator = new PuzzleCalculator(rangeSets, maxValidValue);
            Assert.AreEqual(expectedResultAllowedRange, puzzleCalculator.SitesAllowedCount);

            // Reverse the puzzle input
            rangeSets.Reverse();
            puzzleCalculator = new PuzzleCalculator(rangeSets, maxValidValue);
            Assert.AreEqual(expectedResultAllowedRange, puzzleCalculator.SitesAllowedCount);
        }

        [TestMethod]
        public void TestMethod_Validate_Single_Blacklist()
        {
            Int64 maxValidValue = 10;
            Int64 expectedResultAllowedRange = 9; // Only 2 and 3 are blocked, so 0 - 10 (inclusive) are allowed except those
            List<IpRangeSet> rangeSets = new List<IpRangeSet>()
            {
                new IpRangeSet("2-3")
            };

            PuzzleCalculator puzzleCalculator = new PuzzleCalculator(rangeSets, maxValidValue);
            Assert.AreEqual(expectedResultAllowedRange, puzzleCalculator.SitesAllowedCount);
        }

        [TestMethod]
        public void TestMethod_Validate_Combinations_1()
        {
            Int64 maxValidValue = 10;
            Int64 expectedResultAllowedRange = 1; // Only 10 is allowed
            List<IpRangeSet> rangeSets = new List<IpRangeSet>()
            {
                new IpRangeSet("0-9"),
                new IpRangeSet("0-2"),
                new IpRangeSet("4-7")
            };

            PuzzleCalculator puzzleCalculator = new PuzzleCalculator(rangeSets, maxValidValue);
            Assert.AreEqual(expectedResultAllowedRange, puzzleCalculator.SitesAllowedCount);

            // Reverse the puzzle input
            rangeSets.Reverse();
            puzzleCalculator = new PuzzleCalculator(rangeSets, maxValidValue);
            Assert.AreEqual(expectedResultAllowedRange, puzzleCalculator.SitesAllowedCount);
        }

        [TestMethod]
        public void TestMethod_Validate_Combinations_2()
        {
            Int64 maxValidValue = 10;
            Int64 expectedResultAllowedRange = 3; // 3, 9, and 10 are allowed
            List<IpRangeSet> rangeSets = new List<IpRangeSet>()
            {
                new IpRangeSet("5-8"),
                new IpRangeSet("0-2"),
                new IpRangeSet("4-7")
            };

            PuzzleCalculator puzzleCalculator = new PuzzleCalculator(rangeSets, maxValidValue);
            Assert.AreEqual(expectedResultAllowedRange, puzzleCalculator.SitesAllowedCount);

            // Reverse the puzzle input
            rangeSets.Reverse();
            puzzleCalculator = new PuzzleCalculator(rangeSets, maxValidValue);
            Assert.AreEqual(expectedResultAllowedRange, puzzleCalculator.SitesAllowedCount);
        }

        [TestMethod]
        public void TestMethod_Validate_Combinations_3()
        {
            Int64 maxValidValue = 10;
            Int64 expectedResultAllowedRange = 10; // 3, 9, and 10 are allowed
            List<IpRangeSet> rangeSets = new List<IpRangeSet>()
            {
                new IpRangeSet("5-5")
            };

            PuzzleCalculator puzzleCalculator = new PuzzleCalculator(rangeSets, maxValidValue);
            Assert.AreEqual(expectedResultAllowedRange, puzzleCalculator.SitesAllowedCount);
        }

        //[Ignore]
        [TestMethod]
        public void TestMethod_Validate_Combinations_4()
        {
            Int64 maxValidValue = 10;
            Int64 expectedResultAllowedRange = 8; // Everything but 4, 5, and 6 are allowed.
            List<IpRangeSet> rangeSets = new List<IpRangeSet>()
            {
                new IpRangeSet("5-5"),
                new IpRangeSet("4-6")
            };

            PuzzleCalculator puzzleCalculator = new PuzzleCalculator(rangeSets, maxValidValue);
            Assert.AreEqual(expectedResultAllowedRange, puzzleCalculator.SitesAllowedCount);

            // Reverse the puzzle input
            rangeSets.Reverse();
            puzzleCalculator = new PuzzleCalculator(rangeSets, maxValidValue);
            Assert.AreEqual(expectedResultAllowedRange, puzzleCalculator.SitesAllowedCount);
        }

        [TestMethod]
        public void TestMethod_Validate_Combinations_4_Reversed()
        {
            Int64 maxValidValue = 10;
            Int64 expectedResultAllowedRange = 8; // Everything but 4, 5, and 6 are allowed.
            List<IpRangeSet> rangeSets = new List<IpRangeSet>()
            {
                new IpRangeSet("4-6"),
                new IpRangeSet("5-5")
            };

            PuzzleCalculator puzzleCalculator = new PuzzleCalculator(rangeSets, maxValidValue);
            Assert.AreEqual(expectedResultAllowedRange, puzzleCalculator.SitesAllowedCount);

            // Reverse the puzzle input
            rangeSets.Reverse();
            puzzleCalculator = new PuzzleCalculator(rangeSets, maxValidValue);
            Assert.AreEqual(expectedResultAllowedRange, puzzleCalculator.SitesAllowedCount);
        }

        [TestMethod]
        public void TestMethod_Validate_Combinations_5()
        {
            Int64 maxValidValue = 10;
            Int64 expectedResultAllowedRange = 1; // Only 10 is allowed
            List<IpRangeSet> rangeSets = new List<IpRangeSet>()
            {
                new IpRangeSet("1-9"),
                new IpRangeSet("0-0"),
                new IpRangeSet("9-9")
            };

            PuzzleCalculator puzzleCalculator = new PuzzleCalculator(rangeSets, maxValidValue);
            Assert.AreEqual(expectedResultAllowedRange, puzzleCalculator.SitesAllowedCount);

            // Reverse the puzzle input
            rangeSets.Reverse();
            puzzleCalculator = new PuzzleCalculator(rangeSets, maxValidValue);
            Assert.AreEqual(expectedResultAllowedRange, puzzleCalculator.SitesAllowedCount);
        }

        [TestMethod]
        public void TestMethod_Validate_Permutation_1()
        {
            Int64 maxValidValue = 10;
            Int64 expectedResultAllowedRange = 7; // 4, 5, 6, and 7 are blocked
            List<IpRangeSet> rangeSets = new List<IpRangeSet>()
            {
                new IpRangeSet("4-6"),
                new IpRangeSet("5-7")
            };

            PuzzleCalculator puzzleCalculator = new PuzzleCalculator(rangeSets, maxValidValue);
            Assert.AreEqual(expectedResultAllowedRange, puzzleCalculator.SitesAllowedCount);

            // Reverse the puzzle input
            rangeSets.Reverse();
            puzzleCalculator = new PuzzleCalculator(rangeSets, maxValidValue);
            Assert.AreEqual(expectedResultAllowedRange, puzzleCalculator.SitesAllowedCount);
        }

        [TestMethod]
        public void TestMethod_Validate_Permutation_2()
        {
            Int64 maxValidValue = 10;
            Int64 expectedResultAllowedRange = 6; // 3, 4, 5, 6, and 7 are blocked
            List<IpRangeSet> rangeSets = new List<IpRangeSet>()
            {
                new IpRangeSet("4-6"),
                new IpRangeSet("5-7"),
                new IpRangeSet("3-5")
            };

            PuzzleCalculator puzzleCalculator = new PuzzleCalculator(rangeSets, maxValidValue);
            Assert.AreEqual(expectedResultAllowedRange, puzzleCalculator.SitesAllowedCount);

            // Reverse the puzzle input
            rangeSets.Reverse();
            puzzleCalculator = new PuzzleCalculator(rangeSets, maxValidValue);
            Assert.AreEqual(expectedResultAllowedRange, puzzleCalculator.SitesAllowedCount);
        }

        [TestMethod]
        public void TestMethod_Validate_Permutation_3()
        {
            Int64 maxValidValue = 10;
            Int64 expectedResultAllowedRange = 5; // 0, 3, 4, 5, 6, and 7 are blocked
            List<IpRangeSet> rangeSets = new List<IpRangeSet>()
            {
                new IpRangeSet("0-0"),
                new IpRangeSet("5-5"),
                new IpRangeSet("4-6"),
                new IpRangeSet("5-7"),
                new IpRangeSet("3-5")
            };

            PuzzleCalculator puzzleCalculator = new PuzzleCalculator(rangeSets, maxValidValue);
            Assert.AreEqual(expectedResultAllowedRange, puzzleCalculator.SitesAllowedCount);

            // Reverse the puzzle input
            rangeSets.Reverse();
            puzzleCalculator = new PuzzleCalculator(rangeSets, maxValidValue);
            Assert.AreEqual(expectedResultAllowedRange, puzzleCalculator.SitesAllowedCount);
        }
    }
}

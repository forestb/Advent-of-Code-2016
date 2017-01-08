using System;
using System.Collections.Generic;
using Day20.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day20.Tests
{
    [TestClass]
    public class Part2LargeValuedTests
    {
        // Rule: 0 is an allowed, inclusive value
        // Rule: MaxValue is an allowed, inclusive value

        [TestMethod]
        public void TestMethod_Validate_Empty_List()
        {
            Int64 maxValidValue = 100;
            Int64 expectedResultAllowedRange = 101; // All are allowed, 0 - 10, inclusive
            List<IpRangeSet> rangeSets = new List<IpRangeSet>();

            PuzzleCalculator puzzleCalculator = new PuzzleCalculator(rangeSets, maxValidValue);
            Assert.AreEqual(expectedResultAllowedRange, puzzleCalculator.SitesAllowedCount);
        }

        [TestMethod]
        public void TestMethod_Validate_Full_List()
        {
            Int64 maxValidValue = 100;
            Int64 expectedResultAllowedRange = 0; // No IPs are allowed
            List<IpRangeSet> rangeSets = new List<IpRangeSet>()
            {
                new IpRangeSet("0-100")
            };

            PuzzleCalculator puzzleCalculator = new PuzzleCalculator(rangeSets, maxValidValue);
            Assert.AreEqual(expectedResultAllowedRange, puzzleCalculator.SitesAllowedCount);
        }

        [TestMethod]
        public void TestMethod_Validate_Combination_1()
        {
            Int64 maxValidValue = 100;
            Int64 expectedResultAllowedRange = 90; // Only 0 - 10 are blocked (11 values, inclusive)
            List<IpRangeSet> rangeSets = new List<IpRangeSet>()
            {
                new IpRangeSet("0-10")
            };

            PuzzleCalculator puzzleCalculator = new PuzzleCalculator(rangeSets, maxValidValue);
            Assert.AreEqual(expectedResultAllowedRange, puzzleCalculator.SitesAllowedCount);
        }

        [TestMethod]
        public void TestMethod_Validate_Combination_2()
        {
            Int64 maxValidValue = 100;
            Int64 expectedResultAllowedRange = 89; // Only 0 - 10 are blocked (11 values, inclusive)
            List<IpRangeSet> rangeSets = new List<IpRangeSet>()
            {
                 new IpRangeSet("40-50")
                ,new IpRangeSet("40-50")
                ,new IpRangeSet("39-40")
            };

            Console.WriteLine($"Processing the list forwards...");
            PuzzleCalculator puzzleCalculator = new PuzzleCalculator(rangeSets, maxValidValue);
            Assert.AreEqual(expectedResultAllowedRange, puzzleCalculator.SitesAllowedCount);

            // Reverse the puzzle input
            Console.WriteLine($"Processing the list in reverse...");
            rangeSets.Reverse();
            puzzleCalculator = new PuzzleCalculator(rangeSets, maxValidValue);
            Assert.AreEqual(expectedResultAllowedRange, puzzleCalculator.SitesAllowedCount);
        }
    }
}

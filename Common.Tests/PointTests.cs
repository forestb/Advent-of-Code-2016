using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Tests
{
    [TestClass]
    public class PointTests
    {
        List<Point> PointsListUnique = new List<Point>(new[] { new Point(1, 1), new Point(2, 0), new Point(0, 5) });
        List<Point> PointsListWithDuplicates = new List<Point>(new[] { new Point(1, 1), new Point(1, 1), new Point(0, 5) });

        #region HashSet Tests

        [TestMethod]
        public void TestMethod_Validate_Unique_Points()
        {
            HashSet<Point> pointsHashSet = new HashSet<Point>();

            foreach (Point p in PointsListUnique)
            {
                pointsHashSet.Add(p);
            }

            Assert.AreEqual(PointsListUnique.Count, pointsHashSet.Count);
        }

        [TestMethod]
        public void TestMethod_Validate_Duplicate_Points_1()
        {
            HashSet<Point> pointsHashSet = new HashSet<Point>();

            foreach (Point p in PointsListUnique)
            {
                pointsHashSet.Add(p);
            }

            // Add the list again
            foreach (Point p in PointsListUnique)
            {
                pointsHashSet.Add(p);
            }

            Assert.AreEqual(PointsListUnique.Count, pointsHashSet.Count);
        }

        [TestMethod]
        public void TestMethod_Validate_Duplicate_Points_2()
        {
            HashSet<Point> pointsHashSet = new HashSet<Point>();

            foreach (Point p in PointsListWithDuplicates)
            {
                pointsHashSet.Add(p);
            }

            Assert.AreNotEqual(PointsListUnique.Count, pointsHashSet.Count);
        }

        #endregion
    }
}

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

        // Validate struct vs class points
        [TestMethod]
        public void TestMethod_Validate_Points_Reference_Test_1()
        {
            Point p1 = new Point(1, 1);
            Point p2 = p1;

            p1.X++;

            // If Point is a struct, we should be able to modify p1 without it affecting p2
            Assert.IsFalse(p1.Equals(p2));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Day22.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day22.Tests
{
    /// <summary>
    /// Summary description for GridTests
    /// </summary>
    [TestClass]
    public class GridTests
    {
        [TestMethod]
        public void TestMethod_Viability_1()
        {
            Node x = new Node(new Point(1, 1), 500, 20);
            Node y = new Node(new Point(2, 2), 500, 30);

            HashSet<Node> nodeSet1 = new HashSet<Node>() {x, y, x, y};
            HashSet<Node> nodeSet2 = new HashSet<Node>() {x, y, x, y};
            Assert.IsTrue(nodeSet1.Count == 2);
            Assert.IsTrue(nodeSet2.Count == 2);

            Grid grid1 = new Grid() {x, y, x, y};
            Grid grid2 = new Grid() {x, y, x, y};

            Console.WriteLine(grid1.Equals(grid2));
            Console.WriteLine(grid1.GetHashCode());
            Console.WriteLine(grid2.GetHashCode());

            HashSet<Grid> gridSet1 = new HashSet<Grid>() {grid1, grid2};
            Assert.IsTrue(gridSet1.Count == 1);
        }

        [TestMethod]
        public void TestMethod_Accept_1()
        {
            Node n1 = new Node(new Point(0, 0), 500, 10);
            Node n1Copy = n1.Copy();
            Node n2 = new Node(new Point(0, 1), 500, 20);
            Node n2Copy = n2.Copy();

            n1.Accept(n2);

            Assert.IsTrue(n1.Id == n2Copy.Id);
            Assert.IsTrue(n2.Used == 0);
            Assert.IsTrue(n1.CurrentPoint.Equals(n1Copy.CurrentPoint));
            Assert.IsTrue(n2.CurrentPoint.Equals(n2Copy.CurrentPoint));

            n1Copy.Accept(n2Copy);

            Grid grid1 = new Grid() {n1};
            Grid grid2 = new Grid() {n1Copy};

            HashSet<Grid> gridSet = new HashSet<Grid>() {grid1, grid2};
            Assert.IsTrue(gridSet.Count == 1);
        }

        [TestMethod]
        public void TestMethod_Accept_2()
        {
            Node n1 = new Node(new Point(0, 0), 500, 10);
            Node n1Copy = n1.Copy();
            Node n2 = new Node(new Point(0, 1), 500, 20);
            Node n2Copy = n2.Copy();

            n1.Accept(n2);
            n2Copy.Accept(n1);

            Console.WriteLine(n1);
            Console.WriteLine(n2);
        }

        [TestMethod]
        public void TestMethod_Grid_Copy_Value_1()
        {
            const string NEW_ID = "TEST";

            Node n1 = new Node(new Point(0, 0), 500, 10);
            Node n2 = new Node(new Point(0, 1), 500, 20);

            Grid grid1 = new Grid() {n1, n2};
            Grid grid2 = new Grid(grid1);

            grid1.Nodes[0].Id = NEW_ID;

            int grid1ModifiedCount = grid1.Count(x => x.Id == NEW_ID);
            int grid2ModifiedCount = grid2.Count(x => x.Id == NEW_ID);

            Console.WriteLine($"There were {grid1ModifiedCount} records matching an updated id for {nameof(grid1ModifiedCount)}");
            Console.WriteLine($"There were {grid2ModifiedCount} records matching an updated id for {nameof(grid2ModifiedCount)}");

            Assert.AreEqual(1, grid1ModifiedCount);
            Assert.AreEqual(0, grid2ModifiedCount);
        }
    }
}

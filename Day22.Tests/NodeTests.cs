using System;
using System.Collections.Generic;
using Common;
using Day22.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day22.Tests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void TestMethod_Viability_1()
        {
            Node x = new Node(new Point(1, 1), 500, 20);
            Node y = new Node(new Point(2, 2), 500, 30);

            Assert.IsTrue(x.IsViableWith(y));
            Assert.IsTrue(y.IsViableWith(x));
        }

        [TestMethod]
        public void TestMethod_Viability_2_Fringe_Case()
        {
            Node x = new Node(new Point(1, 1), 500, 470);
            Node y = new Node(new Point(2, 2), 30, 30);

            Assert.IsFalse(x.IsViableWith(y));
            Assert.IsTrue(y.IsViableWith(x));
        }

        [TestMethod]
        public void TestMethod_Equality_AreNotEqual_1()
        {
            Node x = new Node(new Point(1, 1), 500, 470);
            Node y = new Node(new Point(2, 2), 30, 30);

            Assert.IsFalse(x.Equals(y));
        }

        [TestMethod]
        public void TestMethod_Equality_AreEqual_1()
        {
            Node x = new Node(new Point(1, 1), 500, 470);
            Node y = new Node(new Point(1, 1), 30, 30);

            Assert.IsTrue(x.Equals(y));
        }

        [TestMethod]
        public void TestHashCount_1()
        {
            Node x = new Node(new Point(1, 1), 500, 470);
            Node y = new Node(new Point(1, 1), 500, 470);

            HashSet<Node> NodeSet1 = new HashSet<Node>() { x, y };

            Assert.IsTrue(NodeSet1.Count == 1);
        }

        [TestMethod]
        public void TestHashCount_2()
        {
            Node x = new Node(new Point(1, 1), 500, 470);
            Node y = new Node(new Point(1, 1), 500, 471);

            HashSet<Node> NodeSet1 = new HashSet<Node>() { x, y };

            Assert.IsTrue(NodeSet1.Count == 1);
        }

        [TestMethod]
        public void TestHashCount_3()
        {
            Node x = new Node(new Point(1, 1), 500, 470);
            Node y = new Node(new Point(1, 2), 500, 470);

            HashSet<Node> NodeSet1 = new HashSet<Node>() { x, y };

            Assert.IsTrue(NodeSet1.Count == 2);
        }
    }
}

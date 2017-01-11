using System;
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
            Node x = new Node(string.Empty, 1, 1, 500, 20);
            Node y = new Node(string.Empty, 2, 2, 500, 30);

            Assert.IsTrue(x.IsViableWith(y));
            Assert.IsTrue(y.IsViableWith(x));
        }

        [TestMethod]
        public void TestMethod_Viability_2_Fringe_Case()
        {
            Node x = new Node(string.Empty, 1, 1, 500, 470);
            Node y = new Node(string.Empty, 2, 2, 30, 30);

            Assert.IsFalse(x.IsViableWith(y));
            Assert.IsTrue(y.IsViableWith(x));
        }
    }
}

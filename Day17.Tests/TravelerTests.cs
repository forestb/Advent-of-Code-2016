using System;
using Common;
using Day17.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day17.Tests
{
    [TestClass]
    public class TravelerTests
    {
        public static PuzzleData SamplePuzzleInput = new PuzzleData("hijkl", 4, 4);
        public static Point SamplePuzzleInputStartingPoint = new Point(0, 0);

        [TestMethod]
        public void Validate_Sample_Traveler_Directions_1_Starting_Position()
        {
            Traveler t1 = new Traveler(SamplePuzzleInput, SamplePuzzleInputStartingPoint, string.Empty);

            Assert.IsFalse(t1.CanMoveUp);
            Assert.IsTrue(t1.CanMoveDown);
            Assert.IsFalse(t1.CanMoveLeft);
            Assert.IsFalse(t1.CanMoveRight);
            

            // 1st Iteration
            Traveler t2 = t1.MoveDown();
            Assert.AreEqual(Directions.Down, t2.PathSoFar);

            Assert.IsTrue(t2.CanMoveUp);
            Assert.IsFalse(t2.CanMoveDown);
            Assert.IsFalse(t2.CanMoveLeft);
            Assert.IsTrue(t2.CanMoveRight);


            // 2nd Iteration
            // Move Right; all doors should be locked
            Traveler t3 = t2.MoveRight();
            Assert.AreEqual(string.Concat(Directions.Down, Directions.Right), t3.PathSoFar);

            Assert.IsFalse(t3.CanMoveUp);
            Assert.IsFalse(t3.CanMoveDown);
            Assert.IsFalse(t3.CanMoveLeft);
            Assert.IsFalse(t3.CanMoveRight);

            // Move Up
            Traveler t4 = t2.MoveUp();
            Assert.AreEqual(string.Concat(Directions.Down, Directions.Up), t4.PathSoFar);

            Assert.IsFalse(t4.CanMoveUp);
            Assert.IsFalse(t4.CanMoveDown);
            Assert.IsFalse(t4.CanMoveLeft);
            Assert.IsTrue(t4.CanMoveRight);


            // 3rd Iteration
            Traveler t5 = t4.MoveRight();
            Assert.AreEqual(string.Concat(Directions.Down, Directions.Up, Directions.Right), t5.PathSoFar);

            Assert.IsFalse(t5.CanMoveUp);
            Assert.IsFalse(t5.CanMoveDown);
            Assert.IsFalse(t5.CanMoveLeft);
            Assert.IsFalse(t5.CanMoveRight);

            // All doors are locked; can't travel anymore. Nooooooo...
        }
    }
}

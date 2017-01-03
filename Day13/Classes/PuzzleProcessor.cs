using System;
using System.Collections.Generic;
using Common;

namespace Day13.Classes
{
    public class PuzzleProcessor
    {
        public static void ProcessPart1(PuzzleData puzzleInput)
        {
            puzzleInput.ClearVisited();

            // Prepare the iteration list
            int iteration = 0;
            HashSet<Point> currentPositionsToProcess = new HashSet<Point>();
            HashSet<Point> nextPositionsToProcess = new HashSet<Point>();

            // First iteration
            currentPositionsToProcess.Add(puzzleInput.StartingPoint);

            while (true)
            {
                foreach (Point p in currentPositionsToProcess)
                {
                    if (p.Equals(puzzleInput.EndingPoint))
                    {
                        Console.WriteLine($"Reached the ending condition in {iteration} steps.");
                        return;
                    }

                    Point moveUp = new Point(p.X, p.Y - 1);
                    Point moveRight = new Point(p.X + 1, p.Y);
                    Point moveDown = new Point(p.X, p.Y + 1);
                    Point moveLeft = new Point(p.X - 1, p.Y);

                    InsertIfValid(puzzleInput, nextPositionsToProcess, moveUp);
                    InsertIfValid(puzzleInput, nextPositionsToProcess, moveRight);
                    InsertIfValid(puzzleInput, nextPositionsToProcess, moveDown);
                    InsertIfValid(puzzleInput, nextPositionsToProcess, moveLeft);
                }

                currentPositionsToProcess = nextPositionsToProcess;
                nextPositionsToProcess = new HashSet<Point>();
                iteration++;
            }
        }

        /// <summary>
        /// We're looking for the maximum number of distinct x,y coordinate pairs which we could possibly visit in 50
        /// steps.  It makes sense that the grid should never have a width or height greater than 50 for this.  Instead
        /// of short-circuiting at the condition defined within p1, let's simply short circuit when the iteration
        /// is greater than 50.
        /// </summary>
        /// <param name="puzzleData"></param>
        public static void ProcessPart2(PuzzleData puzzleData)
        {
            puzzleData.ClearVisited();

            // Prepare the iteration list
            HashSet<Point> currentPositionsToProcess = new HashSet<Point>();
            HashSet<Point> nextPositionsToProcess = new HashSet<Point>();

            // First iteration
            currentPositionsToProcess.Add(puzzleData.StartingPoint);
            puzzleData.Visit(puzzleData.StartingPoint);

            for(int i = 0; i < 50; i++)
            {
                foreach (Point p in currentPositionsToProcess)
                {
                    Point moveUp = new Point(p.X, p.Y - 1);
                    Point moveRight = new Point(p.X + 1, p.Y);
                    Point moveDown = new Point(p.X, p.Y + 1);
                    Point moveLeft = new Point(p.X - 1, p.Y);

                    InsertIfValid(puzzleData, nextPositionsToProcess, moveUp);
                    InsertIfValid(puzzleData, nextPositionsToProcess, moveRight);
                    InsertIfValid(puzzleData, nextPositionsToProcess, moveDown);
                    InsertIfValid(puzzleData, nextPositionsToProcess, moveLeft);
                }

                currentPositionsToProcess = nextPositionsToProcess;
                nextPositionsToProcess = new HashSet<Point>();
            }

            // Either of these could be used to determine distinct visitors
            // Unfortunately I had guessed around the correct answer and second guessing myself led me to keep track
            // of which specific nodes I had visited.
            Console.WriteLine($"Visited {puzzleData.VisitedPointCount} distinct positions.");
        }

        private static void InsertIfValid(PuzzleData puzzleInput, HashSet<Point> set, Point p)
        {
            if (puzzleInput.IsPointWithinBounds(p) && puzzleInput.IsOpenSpace(p) && !puzzleInput.WasPointVisited(p))
            {
                set.Add(p);
                puzzleInput.Visit(p);
            }
        }
    }
}

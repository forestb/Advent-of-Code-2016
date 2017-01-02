using System;
using System.Collections.Generic;
using Common;

namespace Day13.Classes
{
    public class PuzzleProcessor
    {
        public static void Process(PuzzleInput puzzleInput)
        {
            // Prepare the iteration list
            int iteration = 0;
            HashSet<Point> currentPositionsToProcess = new HashSet<Point>();
            HashSet<Point> nextPositionsToProcess = new HashSet<Point>();

            // First iteration
            currentPositionsToProcess.Add(puzzleInput.StartingPoint);

            while (true)
            {
                Console.WriteLine($"{currentPositionsToProcess.Count} positions to process for iteration {iteration}.");

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

        private static void InsertIfValid(PuzzleInput puzzleInput, HashSet<Point> set, Point p)
        {
            if (p.X >= 0 && p.Y > 0 && p.X < puzzleInput.Columns && p.Y < puzzleInput.Rows && puzzleInput.IsOpenSpace(p))
            {
                set.Add(p);
            }
        }
    }
}

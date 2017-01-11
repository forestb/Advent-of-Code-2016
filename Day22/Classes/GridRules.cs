using System;
using System.Collections.Generic;
using Common;

namespace Day22.Classes
{
    public class GridRules
    {
        /// <summary>
        /// Inspects each node in a grid. If that node has 0 viable neighbords, it's removed from the grid.
        /// </summary>
        /// <param name="grid"></param>
        public static Grid PruneWallsBasic(Grid grid)
        {
            // we make a copy for iteration
            // we can't alter a list of which we're iterating
            Grid copy = new Grid(grid);

            foreach (Node n in grid)
            {
                if (!HasViableNeighbor(grid, n))
                {
                    copy.Remove(n);
                }
            }

            return copy;
        }

        private static bool HasViableNeighbor(Grid grid, Node node)
        {
            Node neighborUp = grid.GetNodeAtLocation(node.Up);
            Node neighborRight = grid.GetNodeAtLocation(node.Right);
            Node neighborDown = grid.GetNodeAtLocation(node.Down);
            Node neighborLeft = grid.GetNodeAtLocation(node.Left);

            return node.CouldFitOnNeighbors(neighborUp, neighborRight, neighborDown, neighborLeft);
        }

        /// <summary>
        /// For each node
        /// Take it's current value
        /// Walk it in each 
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static Grid PruneWallsAdvanced(Grid grid)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            // we make a copy for iteration
            // we can't alter a list of which we're iterating
            Grid copy = new Grid(grid);

            foreach (Node n in grid)
            {
                Console.WriteLine($"Processing node {n.Id}; {watch.ElapsedMilliseconds / 1000}s/{watch.ElapsedMilliseconds} ms so far.");

                if (!CanTraverse(grid, n, 0, new List<Point>()))
                {
                    ConsoleColor current = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"Removing node {n.Id}; {watch.ElapsedMilliseconds / 1000}s/{watch.ElapsedMilliseconds} ms so far.");
                    Console.ForegroundColor = current;
                    copy.Remove(n);
                }
            }

            watch.Stop();

            Console.WriteLine($"Advanced pruning took {watch.ElapsedMilliseconds / 1000}s/{watch.ElapsedMilliseconds}.");

            return copy;
        }

        // Is the data a node is carrying capable of traveling in *any* direction for "n" steps
        // If not, the node is a wall and should be removed from our list for consideration
        private const int MAX_STEPS = 5;

        public static bool CanTraverse(Grid grid, Node node, int currentStepCount, List<Point> pointsVisited)
        {
            if (currentStepCount == MAX_STEPS)
            {
                return true;
            }

            if(node.CurrentPoint.X == 0 && node.CurrentPoint.Y == 0)
            {
                return true;
            }

            // if the node travels to any point it's already been, that proves nothing...
            if (pointsVisited.Contains(node.CurrentPoint))
            {
                return false;
            }

            pointsVisited.Add(node.CurrentPoint);

            Grid gridCopy = null;
            Node nodeCopy = null;
            List<Point> pointsCopy = null;

            Node neighborUp = grid.GetNodeAtLocation(node.Up);
            Node neighborRight = grid.GetNodeAtLocation(node.Right);
            Node neighborDown = grid.GetNodeAtLocation(node.Down);
            Node neighborLeft = grid.GetNodeAtLocation(node.Left);

            bool canTraverseUp = false;
            bool canTraverseRight = false;
            bool canTraverseDown = false;
            bool canTraverseLeft = false;

            // up
            if (node.CouldFitOn(neighborUp))
            {
                gridCopy = grid.Copy();
                pointsCopy = new List<Point>(pointsVisited);

                neighborUp = gridCopy.GetNodeAtLocation(neighborUp.CurrentPoint);
                nodeCopy = grid.GetNodeAtLocation(node.CurrentPoint);

                neighborUp.Accept(nodeCopy);

                canTraverseUp = CanTraverse(gridCopy, neighborUp, currentStepCount + 1, pointsCopy);
            }

            // right
            if (!canTraverseUp)
            {
                if (node.CouldFitOn(neighborRight))
                {
                    gridCopy = grid.Copy();
                    pointsCopy = new List<Point>(pointsVisited);

                    neighborRight = gridCopy.GetNodeAtLocation(neighborRight.CurrentPoint);
                    nodeCopy = grid.GetNodeAtLocation(node.CurrentPoint);

                    neighborRight.Accept(nodeCopy);

                    canTraverseRight = CanTraverse(gridCopy, neighborRight, currentStepCount + 1, pointsCopy);
                }
            }

            // down
            if (!canTraverseUp && !canTraverseRight)
            {
                if (node.CouldFitOn(neighborDown))
                {
                    gridCopy = grid.Copy();
                    pointsCopy = new List<Point>(pointsVisited);

                    neighborDown = gridCopy.GetNodeAtLocation(neighborDown.CurrentPoint);
                    nodeCopy = grid.GetNodeAtLocation(node.CurrentPoint);

                    neighborDown.Accept(nodeCopy);

                    canTraverseDown = CanTraverse(gridCopy, neighborDown, currentStepCount + 1, pointsCopy);
                }
            }

            // left
            if (!canTraverseUp && !canTraverseRight && !canTraverseDown)
            {
                if (node.CouldFitOn(neighborLeft))
                {
                    gridCopy = grid.Copy();
                    pointsCopy = new List<Point>(pointsVisited);

                    neighborLeft = gridCopy.GetNodeAtLocation(neighborLeft.CurrentPoint);
                    nodeCopy = grid.GetNodeAtLocation(node.CurrentPoint);

                    neighborLeft.Accept(nodeCopy);

                    canTraverseLeft = CanTraverse(gridCopy, neighborLeft, currentStepCount + 1, pointsCopy);
                }
            }

            // finished
            // if any of these conditions are true, the node is not a wall
            return canTraverseUp || canTraverseRight || canTraverseDown || canTraverseLeft;
        }
    }
}

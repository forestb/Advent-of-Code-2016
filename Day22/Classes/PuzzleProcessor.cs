using System;
using System.Collections.Generic;
using System.Linq;

namespace Day22.Classes
{
    public class PuzzleProcessor
    {
        #region Node Parsing

        private static List<Node> GetParsedNodes(string input)
        {
            // get each line
            string[] entries = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            // parse each individual node
            List<Node> nodes = new List<Node>();

            foreach (string entry in entries)
            {
                nodes.Add(NodeParser.Parse(entry));
            }

            return nodes;
        }

        #endregion

        #region Part 1

        public static void Process_Part1(string input)
        {
            // retrive the parsed nodes
            List<Node> nodes = GetParsedNodes(input);

            // sort the list
            List<Tuple<Node, Node>> viablePairsTuples = new List<Tuple<Node, Node>>();

            // iterate through each node
            for (int i = 0; i < nodes.Count; i++)
            {
                Node a = nodes[i].Copy();

                for (int j = 0; j < nodes.Count; j++)
                {
                    Node b = nodes[j].Copy();

                    if (a.IsViableWith(b) &&
                        viablePairsTuples.Count(
                            x =>
                                (Equals(x.Item1, a) && Equals(x.Item2, b)) ||
                                (Equals(x.Item1, b) && Equals(x.Item2, a))) == 0)
                    {
                        viablePairsTuples.Add(new Tuple<Node, Node>(a, b));
                    }
                }
            }

            Console.WriteLine($"Parsed {nodes?.Count} nodes.");
            Console.WriteLine($"There are {viablePairsTuples.Count} viable pairs. * Answer to part 1.");
        }

        #endregion

        #region Part 2

        private static readonly HashSet<Grid> GLOBAL_UNIQUE_GRID_STATES = new HashSet<Grid>();
        private static readonly Queue<Grid> GRID_QUEUE = new Queue<Grid>();

        public static void Process_Part2(string input)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            // retrive the parsed nodes
            Grid startingGrid = new Grid();
            startingGrid.AddRange(GetParsedNodes(input));

            // which node are we looking for, eventually?
            Node targetNode =
                startingGrid.FirstOrDefault(n => n.CurrentPoint.Y == 0 && n.CurrentPoint.X == startingGrid.Max(nMax => nMax.CurrentPoint.X));

            if (targetNode == null)
            {
                throw new Exception("Could not find the end-state node.");
            }

            Console.WriteLine($"Looking for node {nameof(targetNode.Id)}={targetNode.Id}");

            // prune nodes that are too big to move...
            Console.WriteLine($"{startingGrid.Count} before calling PruneBasic();");
            startingGrid = GridRules.PruneWallsBasic(startingGrid);
            Console.WriteLine($"{startingGrid.Count} after calling PruneBasic();");

            // advanced pruning
            //Console.WriteLine($"{startingGrid.Count} before calling PruneAdvanced();");
            //startingGrid = GridRules.PruneWallsAdvanced(startingGrid);
            //Console.WriteLine($"{startingGrid.Count} after calling PruneAdvanced();");

            // Print the puzzle
            //startingGrid.Print();
            //return;

            // Prepare the list to process
            GRID_QUEUE.Enqueue(startingGrid);
            int count = 0;

            // Generate all possible grids from the current grid
            while (GRID_QUEUE.Count > 0)
            {
                Grid currentGrid = GRID_QUEUE.Dequeue();
                count++;

                // base case
                if (currentGrid.FirstOrDefault(x => x.CurrentPoint.X == 0 && x.CurrentPoint.Y == 0)?.Id == targetNode.Id)
                {
                    Console.WriteLine($"Reached the base case in {currentGrid.ProcessCount} iterations.");
                    break;
                }

                // Process the current state
                // Queue up additional states needed for processing
                int countBefore = GRID_QUEUE.Count;
                GenerateGridStates(currentGrid);
                int countAfter = GRID_QUEUE.Count;
                int countDifference = countAfter - countBefore;

                Console.WriteLine($"Found {countDifference} more grid states; {GRID_QUEUE.Count} remaining, inclusive." +
                                  $" {watch.ElapsedMilliseconds / 1000}s/{watch.ElapsedMilliseconds} ms so far." +
                                  $" {count} grids processed. " +
                                  $"Previous grid had been processed {currentGrid.ProcessCount} times.");
            }

            watch.Stop();
        }

        private static void GenerateGridStates(Grid grid)
        {
            // based off a grid, generate all possible new grid states
            foreach (Node n in grid)
            {
                Node neighborUp = grid.GetNodeAtLocation(n.Up);
                Node neighborRight = grid.GetNodeAtLocation(n.Right);
                Node neighborDown = grid.GetNodeAtLocation(n.Down);
                Node neighborLeft = grid.GetNodeAtLocation(n.Left);

                // can we move the node into the neighbor node?
                Grid alternateRealityUp = GenerateGridState(grid, n, neighborUp);
                Grid alternateRealityRight = GenerateGridState(grid, n, neighborRight);
                Grid alternateRealityDown = GenerateGridState(grid, n, neighborDown);
                Grid alternateRealityLeft = GenerateGridState(grid, n, neighborLeft);

                // save viable states
                if (alternateRealityUp != null)
                    if (GLOBAL_UNIQUE_GRID_STATES.Add(alternateRealityUp))
                        GRID_QUEUE.Enqueue(alternateRealityUp);

                if (alternateRealityRight != null)
                    if (GLOBAL_UNIQUE_GRID_STATES.Add(alternateRealityRight))
                        GRID_QUEUE.Enqueue(alternateRealityRight);

                if (alternateRealityDown != null)
                    if (GLOBAL_UNIQUE_GRID_STATES.Add(alternateRealityDown))
                        GRID_QUEUE.Enqueue(alternateRealityDown);

                if (alternateRealityLeft != null)
                    if (GLOBAL_UNIQUE_GRID_STATES.Add(alternateRealityLeft))
                        GRID_QUEUE.Enqueue(alternateRealityLeft);
            }
        }

        private static Grid GenerateGridState(Grid grid, Node node, Node neighborNode)
        {
            if (grid != null && node != null && neighborNode != null && node.IsViableWith(neighborNode))
            {
                Grid gridCopy = grid.Copy();

                gridCopy.FirstOrDefault(x => x.Id == neighborNode.Id)
                    .Accept(gridCopy.FirstOrDefault(y => y.Id == node.Id));

                gridCopy.ProcessCount++;

                return gridCopy;
            }

            return null;
        }

        #endregion

        #region Part 2, Attempt 2

        public static void Process_Part2_Math(string input)
        {
            // retrive the parsed nodes
            Grid startingGrid = new Grid();
            startingGrid.AddRange(GetParsedNodes(input));

            // Print the puzzle
            startingGrid.Print();
        }

        #endregion
    }
}

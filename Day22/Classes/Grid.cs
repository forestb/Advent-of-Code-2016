using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace Day22.Classes
{
    public class Grid : IEnumerable<Node>
    {
        public List<Node> Nodes { get; }
        public int Count => Nodes?.Count ?? 0;
        public int ProcessCount { get; set; }

        private const int MIN_X = 0;
        private const int MIN_Y = 0;
        private int MaxX => Nodes.Max(x => x.CurrentPoint.X);
        private int MaxY => Nodes.Max(x => x.CurrentPoint.Y);

        private Node HomeNode => Nodes.FirstOrDefault(n => n.CurrentPoint.Equals(new Point(0, 0)));
        private Node GoalNode => Nodes.FirstOrDefault(x => x.CurrentPoint.X == MaxX);
        private Node EmptyNode => Nodes.FirstOrDefault(x => x.Used == 0);

        private Node WallStartNode => Nodes.Where(n => n.Used > 100)
                    .OrderBy(m => m.CurrentPoint.Y)
                    .ThenBy(o => o.CurrentPoint.X)
                    .FirstOrDefault();

        private Node WallEndNode => Nodes.Where(n => n.Used > 100)
                    .OrderByDescending(m => m.CurrentPoint.Y)
                    .ThenByDescending(o => o.CurrentPoint.X)
                    .FirstOrDefault();

        public Grid()
        {
            Nodes = new List<Node>();
            ProcessCount = 0;
        }

        public Grid(Grid g)
        {
            Nodes = new List<Node>();

            foreach (Node n in g.Nodes)
            {
                Nodes.Add(n.Copy());
            }

            //Nodes = new List<Node>(g.Nodes);
            ProcessCount = g.ProcessCount;
        }
        
        public Grid Copy() => new Grid(this);

        public void Add(Node node) => Nodes.Add(node);
        public void AddRange(IEnumerable<Node> nodes) => Nodes.AddRange(nodes);
        public void Remove(Node node) => Nodes.Remove(node);

        public Node GetNode(Node node) => Nodes.FirstOrDefault(x => x.Equals(node));
        public Node GetNodeAtLocation(Point p)
            => IsWithinBounds(p) ? Nodes.FirstOrDefault(x => x.CurrentPoint.Equals(p)) : null;

        public bool IsWithinBounds(Point p) => p.X >= MIN_X && p.X <= MaxX && p.Y >= MIN_Y && p.Y <= MaxY;
        
        public IEnumerator<Node> GetEnumerator() => Nodes.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        // http://stackoverflow.com/questions/8094867/good-gethashcode-override-for-list-of-foo-objects-respecting-the-order
        public override int GetHashCode()
        {
            int hash = 19;

            foreach (Node node in Nodes)
            {
                hash = hash * 31 + node.GetHashCode();
            }

            return hash;
        }

        public override bool Equals(object obj)
        {
            Grid hGrid = (Grid) obj;

            if (hGrid != null)
            {
                // http://stackoverflow.com/questions/371328/why-is-it-important-to-override-gethashcode-when-equals-method-is-overridden
                // It may be bad practice to check equality this way, but it seems like it should in our case since
                // we're testing a combination of unique coordinates paired with unique ids (based off the set of unique coordinates)
                //...return this.GetHashCode() == hGrid.GetHashCode();
                foreach (Node n1 in this.Nodes)
                {
                    if (!hGrid.Nodes.Contains(n1))
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        public void Print()
        {
            int cols = Nodes.Max(x => x.CurrentPoint.X);
            int rows = Nodes.Max(x => x.CurrentPoint.Y);

            const string HOME = "H";
            const string GOAL = "G";
            const string EMPTY = "E";
            const string WALL_START = "W";
            const string WALL_END = "]";

            for (int i = 0; i <= rows; i++)
            {
                for (int j = 0; j <= cols; j++)
                {
                    Node n = GetNodeAtLocation(new Point(j, i));

                    // types
                    // home = H
                    // goal = G
                    // wall = #
                    // stnd = .
                    ConsoleColor current = Console.ForegroundColor;

                    if (n.CurrentPoint.Equals(new Point(0, 0)))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(HOME);
                    }
                    else if (n.CurrentPoint.Equals(new Point(MaxX, 0)))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(GOAL);
                    }
                    else if (n.Size >= 100)
                    {
                        if (n.Equals(WallStartNode))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"{WALL_START}");
                        }
                        else if(n.Equals(WallEndNode))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"{WALL_END}");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("#");
                        }
                    }
                    else if (n.Used == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(EMPTY);
                    }
                    else
                    {
                        Console.Write(".");
                    }

                    Console.ForegroundColor = current;
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            
            // Print out miscellaneous details
            Console.WriteLine($"{HOME} resides at {HomeNode.CurrentPoint} (Home node)");
            Console.WriteLine($"{GOAL} resides at {GoalNode.CurrentPoint} (Goal node)");
            Console.WriteLine($"{EMPTY} resides at {EmptyNode.CurrentPoint} (Empty space)");
            Console.WriteLine($"The max point in the grid is {new Point(MaxX, MaxY)}.");
            Console.WriteLine($"The wall begins at {WallStartNode.CurrentPoint} and ends at {WallEndNode.CurrentPoint}.");
            Console.WriteLine($"The grid is {MaxX + 1}x{MaxY + 1}.");     
            Console.WriteLine();     

            Console.WriteLine($"The solution should follow the forumla: (E.X - W.X + 1) + E.Y + (WIDTH - W.X + 1) + (WIDTH - 1) * 5");

            int emptyNodeTravelLeft = (EmptyNode.X - WallStartNode.X + 1);
            int emptyNodyTravelUp = EmptyNode.Y;
            int emptyNodeTravelRight = (MaxX - WallStartNode.X + 1);
            int emptyNodeTravelLeftWithSwaps = ((MaxX - 1) * 5);

            int result = emptyNodeTravelLeft + emptyNodyTravelUp + emptyNodeTravelRight + emptyNodeTravelLeftWithSwaps;

            Console.WriteLine($"The solution is: {result}. * Answer to part 2.");
        }
    }
}

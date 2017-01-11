using System;

namespace Day22.Classes
{
    public class Node
    {
        public string OriginalInstruction { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Size { get; set; }
        public int Used { get; set; }
        public int Available { get; set; }
        public decimal UsePercentage { get; }



        public Node(string originalInstruction, int x, int y, int size, int used, int available)
        {
            OriginalInstruction = originalInstruction;
            X = x;
            Y = y;
            Size = size;
            Used = used;
            Available = available;
            UsePercentage = ((decimal)used / (decimal)size) * 100;
        }

        public Node(string originalInstruction, int x, int y, int size, int used)
        {
            OriginalInstruction = originalInstruction;
            X = x;
            Y = y;
            Size = size;
            Used = used;
            Available = size - used;
            UsePercentage = ((decimal)used / (decimal)size) * 100;
        }

        public Node(Node n) : this(n.OriginalInstruction, n.X, n.Y, n.Size, n.Used, n.Available)
        {
            
        }

        public override bool Equals(object obj)
        {
            Node node = obj as Node;

            if (node != null)
            {
                return (this.X == node.X && this.Y == node.Y);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override string ToString()
        {
            return OriginalInstruction;
        }

        public static Node Parse(string input)
        {
            // an input string looks like
            // Filesystem              Size  Used  Avail  Use%
            // /dev/grid/node-x0-y0     88T   66T    22T   75%
            string[] results = input.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            string[] coordinateStrings = results[0].Split(new[] {"-"}, StringSplitOptions.RemoveEmptyEntries);

            return new Node(
                input,
                int.Parse(coordinateStrings[1].Replace("x", string.Empty)),
                int.Parse(coordinateStrings[2].Replace("y", string.Empty)),
                int.Parse(results[1].Replace("T", string.Empty)),
                int.Parse(results[2].Replace("T", string.Empty)),
                int.Parse(results[3].Replace("T", string.Empty))
                );
        }
    }
}

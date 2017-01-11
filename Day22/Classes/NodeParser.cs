using System;
using Common;

namespace Day22.Classes
{
    public class NodeParser
    {
        public static Node Parse(string input)
        {
            // an input string looks like
            // Filesystem              Size  Used  Avail  Use%
            // /dev/grid/node-x0-y0     88T   66T    22T   75%
            string[] results = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            string[] coordinateStrings = results[0].Split(new[] { "-" }, StringSplitOptions.RemoveEmptyEntries);

            Point p = new Point(
                int.Parse(coordinateStrings[1].Replace("x", string.Empty)),
                int.Parse(coordinateStrings[2].Replace("y", string.Empty))
                );

            return new Node(
                p,
                int.Parse(results[1].Replace("T", string.Empty)),
                int.Parse(results[2].Replace("T", string.Empty))
                );
        }
    }
}

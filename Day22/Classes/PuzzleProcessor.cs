using System;
using System.Collections.Generic;
using System.Linq;

namespace Day22.Classes
{
    public class PuzzleProcessor
    {
        public static void Process(string input)
        {
            // retrive the parsed nodes
            List<Node> nodes = GetParsedNodes(input);

            // sort the list
            List<Tuple<Node, Node>> viablePairsTuples = new List<Tuple<Node, Node>>();

            // iterate through each node
            for (int i = 0; i < nodes.Count; i++)
            {
                Node a = new Node(nodes[i]);

                for (int j = 0; j < nodes.Count; j++)
                {
                    Node b = new Node(nodes[j]);

                    if (a.IsViableWith(b) && viablePairsTuples.Count(x => (Equals(x.Item1, a) && Equals(x.Item2, b)) || (Equals(x.Item1, b) && Equals(x.Item2, a))) == 0)
                    {
                        viablePairsTuples.Add(new Tuple<Node, Node>(a, b));
                    }
                }
            }

            Console.WriteLine($"Parsed {nodes?.Count} nodes.");
            Console.WriteLine($"There are {viablePairsTuples.Count} viable pairs.");
        }

        private static List<Node> GetParsedNodes(string input)
        {
            // get each line
            string[] entries = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            // parse each individual node
            List<Node> nodes = new List<Node>();

            foreach (string entry in entries)
            {
                nodes.Add(Node.Parse(entry));
            }

            return nodes;
        }

        
    }
}

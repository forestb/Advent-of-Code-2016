using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Common;
using Day7.Classes;

namespace Day7
{
    class Program
    {
        public static string PuzzleInput => PuzzleInputHelper.ReadFile("PuzzleInput.txt");
        public static string PuzzleInputSample => PuzzleInputHelper.ReadFile("PuzzleInput_Sample.txt");
        public static string PuzzleInputSample_Part2 => PuzzleInputHelper.ReadFile("PuzzleInput_Sample_Part2.txt");

        static void Main(string[] args)
        {
            string[] puzzleInputParsed = PuzzleInput.Split(new[] {Environment.NewLine},
                StringSplitOptions.RemoveEmptyEntries);

            List<IPv7> Ipv7s = new List<IPv7>();

            foreach (string s in puzzleInputParsed)
            {
                Ipv7s.Add(new IPv7(s));
            }

            // Day 7, Part 1
            Console.WriteLine($"There are {Ipv7s.Count(x => x.IsValid)} valid IPv7 records.");

            // Day 7, Part 2
            Console.WriteLine($"There are {Ipv7s.Count(x => x.SupportsSsl)} IPv7 records which support SSL.");
        }
        
    }
}

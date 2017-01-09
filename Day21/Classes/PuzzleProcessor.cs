using System;
using System.Collections.Generic;
using System.Linq;

namespace Day21.Classes
{
    public class PuzzleProcessor
    {
        public static string Process_Part1(string startingString, string puzzleInput)
        {
            // parse the lines of puzzle input
            string[] instructionStrings = puzzleInput.Split(new[] { Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries);

            // process the rules against the starting string
            string resultString = startingString;

            foreach (string s in instructionStrings)
            {
                resultString = PuzzleRules.ProcessRule(resultString, s);
            }

            // finished
            return resultString;
        }

        public static string Process_Part2(string startingString, string puzzleInput)
        {
            // parse the lines of puzzle input
            string[] instructionStrings = puzzleInput.Split(new[] { Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries);

            // Reverse the instructions
            List<string> instructionsReversedList = new List<string>(instructionStrings.Reverse());

            // process the rules against the starting string
            string resultString = startingString;

            foreach (string s in instructionsReversedList)
            {
                resultString = PuzzleRules.ProcessRule(resultString, s, true);
            }

            // finished
            return resultString;
        }
    }
}

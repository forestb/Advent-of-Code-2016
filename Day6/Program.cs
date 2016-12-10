using System;
using System.Collections.Generic;
using System.Linq;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] parsedPuzzleInput = GetParsedPuzzleInput(Properties.Settings.Default.Setting_PuzzleInput);

            ProcessPuzzlePart1(parsedPuzzleInput);
        }

        public static string[] GetParsedPuzzleInput(string puzzleInput)
        {
            return puzzleInput.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
        }

        public static void ProcessPuzzlePart1(string[] parsedPuzzleInput)
        {
            string errorCorrectedString = string.Empty;

            // foreach column
            for (int j = 0; j < parsedPuzzleInput?[0]?.Length; j++)
            {
                Dictionary<string, int> characterCount = new Dictionary<string, int>();

                // foreach row
                for (int i = 0; i < parsedPuzzleInput.Length; i++)
                {
                    string character = parsedPuzzleInput[i][j].ToString();

                    if (!characterCount.ContainsKey(character))
                    {
                        characterCount.Add(character, 1);
                    }
                    else
                    {
                        characterCount[character] = characterCount[character] + 1;
                    }
                }

                // process the list
                errorCorrectedString +=
                    characterCount.OrderBy(x => x.Value).Select(y => y.Key).Take(1).FirstOrDefault();
            }

            Console.WriteLine(errorCorrectedString);
        }
    }
}

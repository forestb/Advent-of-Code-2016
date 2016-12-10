using System;
using Day2.Classes;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables/input
            string puzzleInput = Properties.Settings.Default.Setting_RealInput;
            string startingValue = "5";
            // end

            string[] splitStrings = {Environment.NewLine};
            string[] splitResults = puzzleInput.Split(splitStrings, StringSplitOptions.RemoveEmptyEntries);

            GridPoint currentPosition = Grid.GetNewTraveler(startingValue);

            // process each instruction set
            foreach (string instructionSet in splitResults)
            {
                // process each instruction
                ProcessInstructionSet(instructionSet, currentPosition);
            }

            Console.WriteLine(string.Empty);
        }

        public static void ProcessInstructionSet(string instructionSet, GridPoint currentPosition)
        {
            foreach (char instructionChar in instructionSet)
            {
                // We know where the traveler is
                int rowsToAdd = 0;
                int colsToAdd = 0;

                switch (instructionChar)
                {
                    case ('U'):
                        rowsToAdd--;
                        break;

                    case ('D'):
                        rowsToAdd++;
                        break;

                    case ('R'):
                        colsToAdd++;
                        break;

                    case ('L'):
                        colsToAdd--;
                        break;

                    default:
                        throw new Exception("Error; Should not have reached the default case.");
                }

                // Where are the directions trying to send the traveler?
                GridPoint proposedPosition = new GridPoint(currentPosition.Row + rowsToAdd, currentPosition.Col + colsToAdd);

                // Traverse the point
                Grid.TraversePuzzle(currentPosition, proposedPosition);
            }

            // The traversal is finished
            Console.Write(Grid.FindGridPointByCoordinates(currentPosition).Value);
        }
    }
}

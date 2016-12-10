using System;
using System.Collections.Generic;
using System.Text;

namespace Day3
{
    class Program
    {
        // Globals
        public static List<PotentialTriangle> Triangles = new List<PotentialTriangle>();

        // Main
        static void Main(string[] args)
        {
            string puzzleInput = Properties.Settings.Default.Setting_PuzzleInput;

            string[] dataSet = GetDataSetsVeritcal(puzzleInput);


            int rowsProcessed = 0;

            foreach (string inputLine in dataSet)
            {
                ProcessPuzzleInput(inputLine);
                rowsProcessed++;
            }

            Console.WriteLine($"There were {rowsProcessed} rows processed.");
            Console.WriteLine($"There are {Triangles.Count} triangles.");
        }

        public static string[] GetRows(string puzzleInputDataSet)
        {
            return puzzleInputDataSet.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string[] GetCols(string puzzleInputRow)
        {
            return puzzleInputRow.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string[] GetDataSetsHorizontal(string puzzleInputDataSet)
        {
            return GetRows(puzzleInputDataSet);
        }

        public static string[] GetDataSetsVeritcal(string puzzleInputDataSet)
        {
            List<string> augmentedDataSet = new List<string>();

            string[] rows = GetDataSetsHorizontal(puzzleInputDataSet);

            int rowsToProcess = rows.Length;
            int colsToProcess = 3;

            string[,] dataSetArray = new string[rowsToProcess, colsToProcess];

            for (int i = 0; i < rowsToProcess; i++)
            {
                string[] cols = GetCols(rows[i]);

                for (int j = 0; j < cols.Length; j++)
                {
                    Console.Write($"{cols[j]} ");
                    dataSetArray[i, j] = cols[j];
                }

                Console.Write(Environment.NewLine);
            }

            Console.Write(Environment.NewLine);

            if (rowsToProcess % 3 != 0)
            {
                throw new Exception("Error: The number of rows to process must be divisible by 3 to crete a data set from the puzzle input.");
            }

            for (int i = 0; i < rowsToProcess; i++)
            {
                StringBuilder shiftedRecord = new StringBuilder();

                for (int j = 0; j < colsToProcess; j++)
                {
                    int m = i + (j % colsToProcess) - (i % colsToProcess);
                    int n = i % colsToProcess;

                    shiftedRecord.Append($"{dataSetArray[m,n]} ");
                }

                augmentedDataSet.Add(shiftedRecord.ToString());
            }

            return augmentedDataSet.ToArray();
        }

        public static void ProcessPuzzleInput(string inputLine)
        {
            PotentialTriangle potentialTriangle = GetPotentialTriangle(inputLine);

            if (potentialTriangle.CanBeTriangle)
            {
                Triangles.Add(potentialTriangle);
            }
        }

        public static PotentialTriangle GetPotentialTriangle(string puzzleInputRow)
        {
            // Retrieve the three different triangle sides
            string[] sides = GetCols(puzzleInputRow);

            return new PotentialTriangle(
                int.Parse(sides[0]?.ToString()),
                int.Parse(sides[1]?.ToString()),
                int.Parse(sides[2]?.ToString()));
        }

        public class PotentialTriangle
        {
            public int A { get; }
            public int B { get; }
            public int C { get; }

            public PotentialTriangle(int a, int b, int c)
            {
                this.A = a;
                this.B = b;
                this.C = c;
            }

            public bool CanBeTriangle => (A + B) > C && (A + C) > B && (B + C) > A;

            public override string ToString()
            {
                return $"{A};{B};{C}";
            }
        }
    }
}

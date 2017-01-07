using System;

namespace Day18.Better.Classes
{
    public class Floor
    {
        const bool TRAP = true;
        const bool SAFE = false;

        private readonly int trapCount = 0;
        public int SafeCount => (Rows*Columns) - trapCount;

        private bool[,] Grid = null;

        private int Rows { get; }
        private int Columns { get; }

        public Floor(string firstRow, int rowCount)
        {
            Rows = rowCount;
            Columns = firstRow.Length;

            Grid = new bool[Rows, Columns];

            // process the grid
            int row = 0;
            int col = 0;

            // initialize the first row
            for (col = 0; col < Columns; col++)
            {
                bool isTrap = firstRow[col] == '^';

                trapCount += isTrap ? 1 : 0;
                Grid[row, col] = isTrap;
            }

            // process all the later rows
            for (row = 1; row < Rows; row++)
            {
                for (col = 0; col < Columns; col++)
                {
                    bool leftEdge = col == 0;
                    bool rightEdge = col == Columns - 1;

                    // inspect previous row
                    bool left = leftEdge ? SAFE : Grid[row - 1, col - 1];
                    bool right = rightEdge ? SAFE : Grid[row - 1, col + 1];

                    // assign the value
                    bool isTrap = (left && !right) || (!left && right);
                    trapCount += isTrap ? 1 : 0;
                    Grid[row, col] = isTrap;
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Console.Write(Grid[i, j] == true ? "^" : ".");
                }

                Console.WriteLine();
            }
        }
    }
}

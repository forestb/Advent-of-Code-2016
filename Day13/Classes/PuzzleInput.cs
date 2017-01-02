using System;
using Common;

namespace Day13.Classes
{
    public class PuzzleInput
    {
        private uint[,] Grid { get; set; }

        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public uint FavoriteNumber { get; private set; }
        public Point StartingPoint { get; private set; }
        public Point EndingPoint { get; private set; }

        public PuzzleInput(int rows, int columns, uint favoriteNumber, Point startingPoint, Point endingPoint)
        {
            this.Rows = rows;
            this.Columns = columns;
            this.FavoriteNumber = favoriteNumber;
            this.StartingPoint = startingPoint;
            this.EndingPoint = endingPoint;

            // Prepare the grid
            Grid = new uint[rows, columns];

            for (uint i = 0; i < rows; i++) // y
            {
                for (uint j = 0; j < columns; j++) // x
                {
                    Grid[i, j] = CoordinateCalculator.GetCoordinateType(j, i, favoriteNumber);
                }
            }
        }

        private void PrintGrid(uint[,] grid)
        {
            for (uint i = 0; i < Rows; i++) // y
            {
                for (uint j = 0; j < Columns; j++) // x
                {
                    if (grid[i, j] == (uint)CoordinateType.OPEN_SPACE)
                    {
                        Console.Write(". ");
                    }
                    else
                    {
                        Console.Write("# ");
                    }
                }

                Console.WriteLine();
            }
        }

        public bool IsOpenSpace(Point p) => Grid[p.Y, p.X] == (uint)CoordinateType.OPEN_SPACE;
    }
}

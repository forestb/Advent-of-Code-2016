using System;
using Common;

namespace Day13.Classes
{
    public class PuzzleData
    {
        private uint[,] Grid { get; set; }
        private uint[,] VisitedGrid { get; set; }

        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public uint FavoriteNumber { get; private set; }
        public Point StartingPoint { get; private set; }
        public Point EndingPoint { get; private set; }

        public PuzzleData(int rows, int columns, uint favoriteNumber, Point startingPoint, Point endingPoint)
        {
            this.Rows = rows;
            this.Columns = columns;
            this.FavoriteNumber = favoriteNumber;
            this.StartingPoint = startingPoint;
            this.EndingPoint = endingPoint;

            // Prepare the grid
            Grid = new uint[rows, columns];
            VisitedGrid = new uint[rows, columns];

            for (uint i = 0; i < rows; i++) // y
            {
                for (uint j = 0; j < columns; j++) // x
                {
                    Grid[i, j] = CoordinateCalculator.GetCoordinateType(j, i, favoriteNumber);
                    VisitedGrid[i, j] = Grid[i, j];
                }
            }
        }

        public void PrintGrid()
        {
            for (uint i = 0; i < Rows; i++) // y
            {
                for (uint j = 0; j < Columns; j++) // x
                {
                    if (Grid[i, j] == (uint) CoordinateType.OPEN_SPACE)
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

        public void PrintVisitedGrid()
        {
            for (uint i = 0; i < Rows; i++) // y
            {
                for (uint j = 0; j < Columns; j++) // x
                {
                    if (Grid[i, j] == (uint) CoordinateType.OPEN_SPACE)
                    {
                        if (VisitedGrid[i, j] == 2)
                        {
                            if (StartingPoint.Equals(new Point((int)j, (int)i)))
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            }
                            
                            Console.Write("o ");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("  ");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("# ");
                    }
                }

                Console.WriteLine();
            }
        }

        public bool IsOpenSpace(Point p) => Grid[p.Y, p.X] == (uint) CoordinateType.OPEN_SPACE;
        public bool IsPointWithinBounds(Point p) => p.X >= 0 && p.Y >= 0 && p.X < Columns && p.Y < Rows;
        public void Visit(Point p) => VisitedGrid[p.Y, p.X] = 2;

        public int VisitedPointCount => GetVisitedPointCount();
        private int GetVisitedPointCount()
        {
            int count = 0;

            for (uint i = 0; i < Rows; i++) // y
            {
                for (uint j = 0; j < Columns; j++) // x
                {
                    if (VisitedGrid[i, j] == 2)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public void ClearVisited()
        {
            for (uint i = 0; i < Rows; i++) // y
            {
                for (uint j = 0; j < Columns; j++) // x
                {
                    VisitedGrid[i, j] = 0;
                }
            }
        }

        public bool WasPointVisited(Point p) => VisitedGrid[p.Y, p.X] == 2;
    }
}

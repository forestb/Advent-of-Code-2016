using System;
using System.Collections.Generic;

namespace Day1
{
    class Program
    {
        public static List<GridPoint> GridPointLog = new List<GridPoint>();

        public static bool HasVisited(GridPoint gp)
        {
            foreach (GridPoint gpl in GridPointLog)
            {
                if (gp.ToString() == gpl.ToString())
                {
                    return true;
                }
            }

            return false;
        }

        static void Main(string[] args)
        {
            string puzzleInput =
                //$"R2, L3";
                //$"R2, R2, R2";
                //$"R2, R2, R2, R2, R150";
                //$"R5, L5, R5, R3";
                $"R5, L2, L1, R1, R3, R3, L3, R3, R4, L2, R4, L4, R4, R3, L2, L1, L1, R2, R4, R4, L4, R3, L2, R1, L4, R1, R3, L5, L4, L5, R3, L3, L1, L1, R4, R2, R2, L1, L4, R191, R5, L2, R46, R3, L1, R74, L2, R2, R187, R3, R4, R1, L4, L4, L2, R4, L5, R4, R3, L2, L1, R3, R3, R3, R1, R1, L4, R4, R1, R5, R2, R1, R3, L4, L2, L2, R1, L3, R1, R3, L5, L3, R5, R3, R4, L1, R3, R2, R1, R2, L4, L1, L1, R3, L3, R4, L2, L4, L5, L5, L4, R2, R5, L4, R4, L2, R3, L4, L3, L5, R5, L4, L2, R3, R5, R5, L1, L4, R3, L1, R2, L5, L1, R4, L1, R5, R1, L4, L4, L4, R4, R3, L5, R1, L3, R4, R3, L2, L1, R1, R2, R2, R2, L1, L1, L2, L5, L3, L1";
            
            string[] splitChars = new[] {",", " "};
            string[] splitResults = puzzleInput.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);

            GridPoint gridPoint = new GridPoint(0, 0);

            Direction currentDirection = Direction.NORTH;

            foreach (string s in splitResults)
            {
                string instruction = s[0].ToString();
                int distance = int.Parse(s.Substring(1, s.Length-1));
                
                Turn(ref currentDirection, instruction);
                Travel(gridPoint, currentDirection, distance);
            }

            Console.WriteLine($"Total blocks away: {gridPoint.CartesianDistance}");
        }

        public static void Turn(ref Direction currentDirection, string instruction)
        {
            switch (currentDirection)
            {
                case (Direction.NORTH):
                    // facing north
                    currentDirection =(instruction == "R") ? Direction.EAST : Direction.WEST;
                    break;

                case (Direction.EAST):
                    currentDirection = (instruction == "R") ? Direction.SOUTH : Direction.NORTH;
                    break;

                case (Direction.SOUTH):
                    currentDirection = (instruction == "R") ? Direction.WEST : Direction.EAST;
                    break;

                case (Direction.WEST):
                    currentDirection = (instruction == "R") ? Direction.NORTH : Direction.SOUTH;
                    break;
            }
        }

        public static void Travel(GridPoint gridPoint, Direction currentDirection, int distance)
        {
            for (int i = 0; i < distance; i++)
            {
                switch (currentDirection)
                {
                    case (Direction.EAST):
                        gridPoint.x += 1;
                        break;

                    case (Direction.NORTH):
                        gridPoint.y += 1;
                        break;

                    case (Direction.SOUTH):
                        gridPoint.y -= 1;
                        break;

                    case (Direction.WEST):
                        gridPoint.x -= 1;
                        break;
                }

                // we have a "new point"
                // have we been here before?
                if (HasVisited(gridPoint))
                {
                    Console.WriteLine($"We've been here! {gridPoint.CartesianDistance} blocks away at {gridPoint}.");
                    Console.ReadLine();
                }

                // log each point
                GridPointLog.Add(new GridPoint(gridPoint.x, gridPoint.y));
            }
        }

        public class GridPoint
        {
            public GridPoint(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public int x;
            public int y;

            public int CartesianDistance => Math.Abs(this.x) + Math.Abs(this.y);

            public override string ToString()
            {
                return $"{this.x},{this.y}";
            }
        }

        public enum Direction
        {
            NORTH = 1,
            EAST = 2,
            SOUTH = 3,
            WEST = 4,
            UNKNOWN = 5
        }
    }
}

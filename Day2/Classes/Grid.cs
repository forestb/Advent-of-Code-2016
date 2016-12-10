using System.Collections.Generic;

namespace Day2.Classes
{
    public class Grid
    {
        private const int rows = 5;
        private const int cols = 5;

        private static readonly List<GridPoint> PUZZLE = new List<GridPoint>()
        {
            new GridPoint(1, 3, "1"),
            new GridPoint(2, 2, "2"),
            new GridPoint(2, 3, "3"),
            new GridPoint(2, 4, "4"),
            new GridPoint(3, 1, "5"),
            new GridPoint(3, 2, "6"),
            new GridPoint(3, 3, "7"),
            new GridPoint(3, 4, "8"),
            new GridPoint(3, 5, "9"),
            new GridPoint(4, 2, "A"),
            new GridPoint(4, 3, "B"),
            new GridPoint(4, 4, "C"),
            new GridPoint(5, 3, "D")
        };

        public static GridPoint GetNewTraveler(string startingValue)
        {
            GridPoint pointToFind = FindGridPointByValue(startingValue);

            return pointToFind == null ? null : new GridPoint(pointToFind.Row, pointToFind.Col);
        }

        /// <summary>
        /// If the proposed position is not found in the grid, the currentPosition cannot update.
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <param name="proposedPosition"></param>
        public static void TraversePuzzle(GridPoint currentPosition, GridPoint proposedPosition)
        {
            GridPoint gridPointToFind = FindGridPointByCoordinates(proposedPosition);

            if (gridPointToFind != null)
            {
                currentPosition.Row = proposedPosition.Row;
                currentPosition.Col = proposedPosition.Col;
            }
        }

        public static GridPoint FindGridPointByCoordinates(GridPoint point)
        {
            foreach (GridPoint gp in PUZZLE)
            {
                if (gp.Row == point.Row && gp.Col == point.Col)
                {
                    return gp;
                }
            }

            return null;
        }

        public static GridPoint FindGridPointByValue(string value)
        {
            foreach (GridPoint gp in PUZZLE)
            {
                if (gp.Value == value)
                {
                    return gp;
                }
            }

            return null;
        }
    }
}

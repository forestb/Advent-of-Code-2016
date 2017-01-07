using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace Day18.Classes
{
    public class Floor
    {
        Dictionary<Point, TileState> Tiles = new Dictionary<Point, TileState>();

        private int RowCount { get; }
        private int ColumnCount { get; }

        public Floor(string firstRow, int rowCount)
        {
            this.RowCount = rowCount;
            this.ColumnCount = firstRow.Length;

            int row = 0;    // rows, y
            int col = 0;    // columns = x

            // Each character in the 'firstRow' counts as a tile
            // All rows have the same number of tiles
            int tileCount = ColumnCount;

            // Add the initial row
            for (col = 0; col < tileCount; col++)
            {
                Tiles.Add(new Point(col, row), GetStateFromChar(firstRow[col]));
            }

            // Process the following rows
            for (row = 1; row < rowCount; row++)
            {
                for (col = 0; col < tileCount; col++)
                {
                    KeyValuePair<Point, TileState> previousPointLeft =
                        Tiles.FirstOrDefault(x => Equals(x.Key, new Point(col - 1, row - 1)));

                    KeyValuePair<Point, TileState> previousPointCenter =
                        Tiles.FirstOrDefault(x => Equals(x.Key, new Point(col, row - 1)));

                    KeyValuePair<Point, TileState> previousPointRight =
                        Tiles.FirstOrDefault(x => Equals(x.Key, new Point(col + 1, row - 1)));

                    TileStateGroup tileStateGroup = new TileStateGroup(
                        previousPointLeft.IsDefault() ? TileState.SAFE : previousPointLeft.Value,
                        previousPointCenter.IsDefault() ? TileState.SAFE : previousPointCenter.Value,
                        previousPointRight.IsDefault() ? TileState.SAFE : previousPointRight.Value
                        );

                    // The new tile is based on a set of rules from the previous
                    Tiles.Add(new Point(col, row), tileStateGroup.GetNextTileState());
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    string valueToPrint = Tiles[new Point(j, i)] == TileState.SAFE ? "." : "^";

                    Console.Write(valueToPrint);
                }

                Console.WriteLine();
            }
        }

        private TileState GetStateFromChar(char c)
        {
            return c == '.' ? TileState.SAFE : TileState.TRAP;
        }

        public int SafeTileCount => Tiles.Count(x => x.Value == TileState.SAFE);
    }
}

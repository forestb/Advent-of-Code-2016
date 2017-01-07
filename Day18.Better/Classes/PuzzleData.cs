﻿namespace Day18.Better.Classes
{
    public class PuzzleData
    {
        public string PuzzleInput { get; set; }
        public int RowCount { get; set; }

        public PuzzleData(string puzzleInput, int rowCount)
        {
            PuzzleInput = puzzleInput;
            RowCount = rowCount;
        }
    }
}

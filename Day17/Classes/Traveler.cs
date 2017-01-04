using System;
using System.Text.RegularExpressions;
using Common;

namespace Day17.Classes
{
    public class Traveler
    {
        public PuzzleData TravelerPuzzleData { get; }
        public Point CurrentPoint { get; }
        public string PathSoFar { get; }
        public string PathHash { get; }

        public Traveler(PuzzleData puzzleData, Point currentPoint, string pathSoFar)
        {
            this.TravelerPuzzleData = puzzleData;
            this.CurrentPoint = currentPoint;
            this.PathSoFar = pathSoFar;
            this.PathHash = HashGenerator.GetHashedString(TravelerPuzzleData.Passcode, pathSoFar);
        }

        public Traveler MoveUp()
            => new Traveler(TravelerPuzzleData, ShiftUp(CurrentPoint), string.Concat(PathSoFar, Directions.Up));

        public Traveler MoveDown()
            => new Traveler(TravelerPuzzleData, ShiftDown(CurrentPoint), string.Concat(PathSoFar, Directions.Down));

        public Traveler MoveLeft()
            => new Traveler(TravelerPuzzleData, ShiftLeft(CurrentPoint), string.Concat(PathSoFar, Directions.Left));

        public Traveler MoveRight()
            => new Traveler(TravelerPuzzleData, ShiftRight(CurrentPoint), string.Concat(PathSoFar, Directions.Right));

        public bool CanMoveUp => IsWithinBounds(ShiftUp(CurrentPoint)) && IsUpOpen(PathHash);
        public bool CanMoveDown => IsWithinBounds(ShiftDown(CurrentPoint)) && IsDownOpen(PathHash);
        public bool CanMoveLeft => IsWithinBounds(ShiftLeft(CurrentPoint)) && IsLeftOpen(PathHash);
        public bool CanMoveRight => IsWithinBounds(ShiftRight(CurrentPoint)) && IsRightOpen(PathHash);

        private bool IsOutsideBounds(Point p)
            => p.X < 0 || p.X >= TravelerPuzzleData.Columns || p.Y < 0 || p.Y >= TravelerPuzzleData.Rows;

        private bool IsWithinBounds(Point p) => !IsOutsideBounds(p);

        private bool IsDoorOpen(char c) => new Regex("([b-f])").IsMatch(c.ToString());
        private bool IsDoorClosed(char c) => new Regex("([a0-9])").IsMatch(c.ToString());

        private bool IsUpOpen(string hashStr) => IsDoorOpen(hashStr[0]);
        private bool IsDownOpen(string hashStr) => IsDoorOpen(hashStr[1]);
        private bool IsLeftOpen(string hashStr) => IsDoorOpen(hashStr[2]);
        private bool IsRightOpen(string hashStr) => IsDoorOpen(hashStr[3]);

        private Point ShiftUp(Point p) => new Point(p.X, p.Y - 1);
        private Point ShiftDown(Point p) => new Point(p.X, p.Y + 1);
        private Point ShiftLeft(Point p) => new Point(p.X - 1, p.Y);
        private Point ShiftRight(Point p) => new Point(p.X + 1, p.Y);
    }
}

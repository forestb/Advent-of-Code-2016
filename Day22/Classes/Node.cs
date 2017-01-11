using System;
using Common;
using static System.Decimal;

namespace Day22.Classes
{
    public class Node
    {
        public string Id { get; set; }
        public Point CurrentPoint { get; set; }
        public int X => CurrentPoint.X;
        public int Y => CurrentPoint.Y;
        public int Size { get; set; }
        public int Used { get; set; }
        public int Available => Size - Used;
        public int PercentUsed => Available == 0 ? 0 : ToInt32(((decimal) Used/(decimal) Available)*100M);

        #region Constructors

        public Node(Point p, int size, int used)
        {
            Id = p.ToString();
            CurrentPoint = p;
            Size = size;
            Used = used;
        }

        #endregion

        #region Overrides

        public override bool Equals(object obj)
        {
            var node = obj as Node;

            if (node != null)
            {
                return this.CurrentPoint.X == node.CurrentPoint.X && this.CurrentPoint.Y == node.CurrentPoint.Y && this.Id == node.Id;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override string ToString()
        {
            return $"point={CurrentPoint};id={Id}";
        }

        #endregion

        public Point Up => GetNeighborLocation(Direction.UP);
        public Point Right => GetNeighborLocation(Direction.RIGHT);
        public Point Down => GetNeighborLocation(Direction.DOWN);
        public Point Left => GetNeighborLocation(Direction.LEFT);

        private Point GetNeighborLocation(Direction d)
        {
            switch (d)
            {
                case (Direction.UP):
                    return new Point(CurrentPoint.X, CurrentPoint.Y - 1);

                case (Direction.RIGHT):
                    return new Point(CurrentPoint.X + 1, CurrentPoint.Y);

                case (Direction.DOWN):
                    return new Point(CurrentPoint.X, CurrentPoint.Y + 1);

                case (Direction.LEFT):
                    return new Point(CurrentPoint.X - 1, CurrentPoint.Y);

                default:
                    throw new Exception("Invalid direction.");
            }
        }
    }
}

namespace Common
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return $"{X},{Y}";
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Point)
            {
                Point p = (Point) obj;

                if (p.X == this.X && p.Y == this.Y)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

namespace Day2.Classes
{
    public class GridPoint
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public string Value { get; set; }

        public GridPoint(int row, int col)
        {
            this.Row = row;
            this.Col = col;
            this.Value = string.Empty;
        }

        public GridPoint(int row, int col, string value)
        {
            this.Row = row;
            this.Col = col;
            this.Value = value;
        }

        public override string ToString()
        {
            return $"Row={Row};Col={Col}";
        }
    }
}

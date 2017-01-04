namespace Day17.Classes
{
    public class PuzzleData
    {
        public string Passcode { get; private set; }
        public int Columns { get; }
        public int Rows { get; }

        public PuzzleData(string passcode, int columns, int rows)
        {
            this.Passcode = passcode;
            this.Columns = columns;
            this.Rows = rows;
        }
    }
}

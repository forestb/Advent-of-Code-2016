namespace Day15.Classes
{
    public class Disc
    {
        public int Index { get; private set; }
        public int PositionCount { get; private set; }
        public int StartingPosition { get; private set; }

        public Disc(int index, int positionCount, int startingPosition)
        {
            this.Index = index;
            this.PositionCount = positionCount;
            this.StartingPosition = startingPosition;
        }

        public int CalculatePositionAtTime(int time)
        {
            return ((time + Index + StartingPosition) % PositionCount);
        }
    }
}

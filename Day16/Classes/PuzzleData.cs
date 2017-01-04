namespace Day16.Classes
{
    public class PuzzleData
    {
        public string InitialState { get; private set; }
        public int TargetDiskSize { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="initialState">Puzzle input</param>
        /// <param name="targetDiskSize"></param>
        public PuzzleData(string initialState, int targetDiskSize)
        {
            this.InitialState = initialState;
            this.TargetDiskSize = targetDiskSize;
        }
    }
}

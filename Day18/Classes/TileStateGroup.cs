namespace Day18.Classes
{
    public class TileStateGroup
    {
        public readonly TileState Left;
        public readonly TileState Center;
        public readonly TileState Right;

        public TileStateGroup(TileState left, TileState center, TileState right)
        {
            this.Left = left;
            this.Center = center;
            this.Right = right;
        }

        public TileState GetNextTileState()
        {
            return (IsTrapRule1() ||
                    IsTrapRule2() ||
                    IsTrapRule3() ||
                    IsTrapRule4())
                ? TileState.TRAP
                : TileState.SAFE;
        }

        // Could shorten rules to the following two:
        //  left == trap && right != trap
        //  left != trap && right == trap
        // Its left and center tiles are traps, but its right tile is not.
        private bool IsTrapRule1() =>
            Left == TileState.TRAP && Center == TileState.TRAP && Right != TileState.TRAP;

        // Its center and right tiles are traps, but its left tile is not.
        private bool IsTrapRule2() =>
            Left != TileState.TRAP && Center == TileState.TRAP && Right == TileState.TRAP;

        // Only its left tile is a trap.
        private bool IsTrapRule3() =>
            Left == TileState.TRAP && Center != TileState.TRAP && Right != TileState.TRAP;

        // Only its right tile is a trap.
        private bool IsTrapRule4() =>
            Left != TileState.TRAP && Center != TileState.TRAP && Right == TileState.TRAP;
    }
}

namespace Day22.Classes
{
    public static class NodeExtensions
    {
        public static bool IsViableWith(this Node a, Node b)
        {
            /* Node A is not empty (its Used is not zero).
             * Nodes A and B are not the same node.
             * The data on node A (its Used) would fit on node B (its Avail). */

            bool aIsNotEmpty = a.Used > 0;
            bool aIsNotB = !a.Equals(b);
            bool aFitsOnB = a.Used <= b.Available;

            return aIsNotEmpty && aIsNotB && aFitsOnB;
        }
    }
}

namespace Day22.Classes
{
    public static class NodeExtensions
    {
        public static Node Copy(this Node node) => new Node(node.CurrentPoint, node.Size, node.Used) {Id = node.Id};

        public static bool IsViableWith(this Node a, Node b)
        {
            if (a == null || b == null)
            {
                return false;
            }

            /* Node A is not empty (its Used is not zero).
             * Nodes A and B are not the same node.
             * The data on node A (its Used) would fit on node B (its Avail). */
            bool aIsNotEmpty = a.Used > 0;
            bool aIsNotB = !a.Equals(b);
            bool aFitsOnB = a.Used <= b.Available;

            return aIsNotEmpty && aIsNotB && aFitsOnB;
        }

        public static bool CouldFitOnNeighbors(this Node a, Node up, Node right, Node down, Node left)
        {
            // given the current amount of data, if the capacity of all neighboring nodes is less than that data
            // then we'll never be able to move the data around
            return a.CouldFitOn(up) || a.CouldFitOn(right) || a.CouldFitOn(down) || a.CouldFitOn(left);
        }

        public static bool CouldFitOn(this Node a, Node b)
        {
            return a != null && b != null && a.Used < b.Size;
        }

        // The sending node is left empty after this operation.
        public static void Accept(this Node a, Node b)
        {
            // if node a accepts node b, then all of node b's data must be transfered, it must fit
            string tempId = a.Id;

            a.Id = b.Id;
            a.Used += b.Used;

            b.Id = tempId;
            b.Used = 0;
        }
    }
}

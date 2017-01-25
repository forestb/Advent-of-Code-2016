using System;

namespace Day23.Classes
{
    public class Common
    {
        private static readonly string[] SPLIT_WHITE_SPACE = new[] {" "};

        public static string[] SplitOnWhiteSpace(string s)
            => s.Split(SPLIT_WHITE_SPACE, StringSplitOptions.RemoveEmptyEntries);
    }
}

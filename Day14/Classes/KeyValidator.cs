using System.Text.RegularExpressions;

namespace Day14.Classes
{
    public class KeyValidator
    {
        // private
        // http://regexr.com/
        private static readonly Regex TRIPLE_FINDER_REGEX = new Regex(@"([a-f0-9])\1\1");

        // public methods
        public static bool HasTriple(string source) => TRIPLE_FINDER_REGEX.IsMatch(source.ToLowerInvariant());
        public static string GetFirstTriple(string source) => TRIPLE_FINDER_REGEX.Match(source.ToLowerInvariant()).Value.ToLowerInvariant();

        public static bool HasFive(string source, string find)
            => new Regex($@"([{find.ToLowerInvariant()}])\1\1\1\1").IsMatch(source.ToLowerInvariant());
    }
}

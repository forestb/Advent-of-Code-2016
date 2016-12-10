using System;

namespace Day9.Part1
{
    public class Marker
    {
        /// <summary>
        /// The original string of a marker looks like (10x2), meaning take the following 10 characters and repeat 
        /// them twice. 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="inputIndexStart"></param>
        public Marker(string input, int inputIndexStart)
        {
            OriginalMarkerStr = input;
            OriginalMarkerStrIndexStart = inputIndexStart;

            // parse the input
            string[] splitResults = input.Split(new[] {"(", ")", "x"}, StringSplitOptions.RemoveEmptyEntries);

            ProcessCharacterCount = int.Parse(splitResults?[0]);
            ProcessTimesToRepeat = int.Parse(splitResults?[1]);
        }

        /// <summary>
        /// The original string of a marker looks like (10x2), meaning take the following 10 characters and repeat 
        /// them twice. 
        /// </summary>
        public string OriginalMarkerStr { get; private set; }

        public int OriginalMarkerStrLength => OriginalMarkerStr.Length;

        /// <summary>
        /// Index of the original non-parsed input string where the marker begins
        /// </summary>
        public int OriginalMarkerStrIndexStart { get; set; }

        public int OriginalMarkerStrIndexEnd => OriginalMarkerStrIndexStart + OriginalMarkerStr.Length;

        /// <summary>
        /// Character count to expand
        /// </summary>
        public int ProcessCharacterCount { get; set; }

        /// <summary>
        /// Times to repeat the character expansion
        /// </summary>
        public int ProcessTimesToRepeat { get; set; }

        public override string ToString()
        {
            return $"{OriginalMarkerStr}";
        }
    }
}

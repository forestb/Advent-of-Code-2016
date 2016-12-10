using System;
using System.Text;

namespace Day9.Part2
{
    public class Marker
    {
        public string OriginalMarkerStr { get; private set; }
        public int OriginalMarkerStrLength => OriginalMarkerStr.Length;
        public int Multiplier { get; private set; }
        public int SubstringLength { get; private set; }

        public Marker(string originalStr, int substringLength, int multiplier)
        {
            OriginalMarkerStr = originalStr;
            SubstringLength = substringLength;
            Multiplier = multiplier;
        }

        public static Marker GetFirstMarker(string input)
        {
            StringBuilder originalMarkerStr = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                originalMarkerStr.Append(input[i].ToString());

                if (input[i] == ')')
                {
                    break;
                }
            }

            string[] splitResults = input.Split(new[] { "(", ")", "x" }, StringSplitOptions.RemoveEmptyEntries);

            // we only care about the first marker in the string
            // example, (18x9)(3x2)
            // the split should have 4 results, we just want the first two
            return new Marker(
                originalMarkerStr.ToString(),
                int.Parse(splitResults[0]),
                int.Parse(splitResults[1])
                );
        }
    }
}

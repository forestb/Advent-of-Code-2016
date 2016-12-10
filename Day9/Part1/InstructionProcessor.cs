using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day9.Part1
{
    public class InstructionProcessor
    {
        public static ulong Process(string compressedInput)
        {
            List<Marker> markers = MarkerParser.GetMarkers(MarkerParser.GetPotentialMarkers(compressedInput));
            StringBuilder decompressedInput = new StringBuilder();

            // traverse the compressed string
            // whenever a marker has been found, process the marker and incriment the index of the compressedInput by
            // the length of that marker
            for (int i = 0; i < compressedInput.Length; i++)
            {
                string currentCharacter = compressedInput[i].ToString();
                Marker markerToProcess = markers.FirstOrDefault(x => x.OriginalMarkerStrIndexStart == i);

                if (ShouldProcessMarker(markerToProcess))
                {
                    // get the substring we want to copy
                    string subString = compressedInput
                        .Substring(i + markerToProcess.OriginalMarkerStrLength, markerToProcess.ProcessCharacterCount);

                    i += markerToProcess.OriginalMarkerStrLength + markerToProcess.ProcessCharacterCount
                        - 1;    // subtract 1 because once we jump back to the top of the loop, we'll add 1

                    for (int count = 0; count < markerToProcess.ProcessTimesToRepeat; count++)
                    {
                        decompressedInput.Append(subString);
                    }
                }
                else
                {
                    decompressedInput.Append(currentCharacter);
                }
            }

            return (ulong) decompressedInput.ToString().Length;
        }

        private static bool ShouldProcessMarker(Marker m) => m != null;
    }
}

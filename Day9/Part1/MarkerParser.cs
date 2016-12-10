using System.Collections.Generic;
using System.Text;

namespace Day9.Part1
{
    public class MarkerParser
    {
        public static List<Marker> GetPotentialMarkers(string input)
        {
            List<Marker> potentialMarkers = new List<Marker>();

            // given some input, identify all the possible markers
            // markers are "invalid" (not to be processed as markers) if they're preceded directly by another marker
            // returning a list of actual markers will simplify how we process the puzzle input
            bool markerStartFound = false;
            bool markerEndFound = false;
            int markerIndex = -1;

            StringBuilder potentialMarkerString = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                switch (c)
                {
                    case ('('):
                        markerStartFound = true;
                        markerEndFound = false;
                        potentialMarkerString = new StringBuilder(c.ToString());
                        markerIndex = i;
                        break;

                    case (')'):
                        markerEndFound = true;
                        potentialMarkerString.Append(c);
                        potentialMarkers.Add(new Marker(potentialMarkerString.ToString(), markerIndex));
                        break;

                    default:
                        if (markerStartFound && !markerEndFound)
                        {
                            potentialMarkerString.Append(c);
                        }
                        break;
                }
            }

            return potentialMarkers;
        }

        public static List<Marker> GetMarkers(List<Marker> potentialMarkers)
        {
            List<Marker> markers = new List<Marker>();

            /* (6x1)(1x3)A simply becomes (1x3)A - the (1x3) looks like a marker, but because it's within a data 
             * section of another marker, it is not treated any differently from the A that comes after it. It has 
             * a decompressed length of 6. */

            // process markers that don't violate the rule above
            // we can find this by looking through the potential list in reverse. If the instruction before had an
            // (index + characterCount >= index), it's invalid
            if (potentialMarkers.Count <= 1)
            {
                return potentialMarkers;
            }

            markers.Add(potentialMarkers[0]);
            potentialMarkers.Reverse();

            for (int i = 0; i < potentialMarkers.Count - 1; i++)
            {
                Marker currentInstruction = potentialMarkers[i];
                Marker previousInstruction = potentialMarkers[i + 1];

                bool isCurrentMarkerInvalid =
                    (previousInstruction.OriginalMarkerStrIndexStart + previousInstruction.ProcessCharacterCount) >
                        currentInstruction.OriginalMarkerStrIndexStart;

                if (!isCurrentMarkerInvalid)
                {
                    markers.Add(currentInstruction);
                }
            }

            return markers;
        }
    }
}

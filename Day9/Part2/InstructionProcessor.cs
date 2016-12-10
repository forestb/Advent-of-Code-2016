namespace Day9.Part2
{
    public class InstructionProcessor
    {
        /// <summary>
        /// Recursively processes instructions.
        /// </summary>
        /// <param name="compressedInput"></param>
        /// <returns></returns>
        public static ulong Process(string compressedInput)
        {
            ulong characterCount = 0;

            for (int i = 0; i < compressedInput.Length; i++)
            {
                if (compressedInput[i] == '(')
                {
                    // we have a marker
                    Marker m = Marker.GetFirstMarker(compressedInput.Substring(i, compressedInput.Length - i));
                    string compressedInputSubstr = compressedInput.Substring(i + m.OriginalMarkerStrLength,
                        m.SubstringLength);

                    // parse the potential substring
                    characterCount += (ulong)m.Multiplier * Process(compressedInputSubstr);
                    i += m.OriginalMarkerStrLength + m.SubstringLength - 1;
                }
                else
                {
                    characterCount++;
                }
            }

            return characterCount;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Day14.Classes
{
    public class PuzzleProcessor
    {
        public static void Process(string puzzleData)
        {
            Dictionary<uint, string> verifiedKeys = GetVerifiedKeys(puzzleData);

            foreach (KeyValuePair<uint, string> pair in verifiedKeys.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{pair.Value} at {pair.Key}");
            }

            Console.WriteLine($"{verifiedKeys.Count} verified keys found.");
        }

        private static Dictionary<uint, string> GetVerifiedKeys(string puzzleData)
        {
            Dictionary<uint, string> candidateKeys = new Dictionary<uint, string>();
            Dictionary<uint, string> verifiedKeys = new Dictionary<uint, string>();

            const int EXIT_CONDITION = 64;

            uint iterator = 0;

            // while (Keys.Count < 64)
            while (true)
            {
                // Generator The Hash
                string value = HashGenerator.GetHashedString(iterator, puzzleData).ToLowerInvariant();

                // Candidate Keys Have Triples
                if (KeyValidator.HasTriple(value))
                {
                    // Since a Five-Set will also be a Triple, let's validate any candidates waiting for validation
                    // against the one we're about to add
                    foreach (KeyValuePair<uint, string> pair in candidateKeys)
                    {
                        string charToFind = KeyValidator.GetFirstTriple(pair.Value);

                        if (KeyValidator.HasFive(value, charToFind))
                        {
                            verifiedKeys.Add(pair.Key, pair.Value);

                            if (verifiedKeys.Count >= EXIT_CONDITION)
                            {
                                return verifiedKeys;
                            }
                        }
                    }

                    // add it
                    candidateKeys.Add(iterator, value);
                }

                // Remove any candidate keys to validate with an index of (iterator - 1000) that haven't already been validated
                candidateKeys.Remove(candidateKeys.FirstOrDefault(x => x.Key <= ((int)iterator - 1000)).Key);

                iterator++;
            }
        }
    }
}

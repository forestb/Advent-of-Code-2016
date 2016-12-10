using System;
using System.Collections.Generic;

namespace Day7.Classes
{
    public class IPv7
    {
        public List<string> SupernetSequences = new List<string>();
        public List<string> HypernetSequences = new List<string>();
        public bool IsValid { get; private set; }
        public bool SupportsSsl { get; private set; }

        public static bool IsSupernetSequencePosition(int position) => position % 2 == 0;
        public static bool IsHypernetSequencePosition(int position) => position % 2 == 1;

        public IPv7(string possibleIpSequence)
        {
            // parse the input on brackets
            // if outside, add to ip list
            // if inside, add to hypernet sequences
            ParseInput(possibleIpSequence);

            // for all strings in supernet, see if there is an abba
            // for all strings in hypernet, make sure there are no abba
            // mark as valid or invalid
            bool hasValidIp = false;

            foreach (string s in SupernetSequences)
            {
                if (ContainsAbba(s))
                {
                    hasValidIp = true;
                    break;
                }
            }

            bool hasInvalidHypernetSequence = false;

            foreach (string s in HypernetSequences)
            {
                if (ContainsAbba(s))
                {
                    hasInvalidHypernetSequence = true;
                }
            }

            IsValid = hasValidIp && !hasInvalidHypernetSequence;
            SupportsSsl = DoesSupportSsl();
        }

        private void ParseInput(string input)
        {
            string[] splitResults = input.Split(new[] {"[", "]"}, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < splitResults?.Length ; i++)
            {
                if (IsSupernetSequencePosition(i))
                {
                    // Supernet Sequence
                    SupernetSequences.Add(splitResults[i]);
                }
                else
                {
                    // Hypernet Sequence
                    HypernetSequences.Add(splitResults[i]);
                }
            }
        }

        private bool ContainsAbba(string input)
        {
            const int ABBA_CHARACTER_COUNT = 4;
            bool containsAbba = false;

            for (int i = 0; i + ABBA_CHARACTER_COUNT <= input.Length; i++)
            {
                char c1 = input[i];
                char c2 = input[i + 1];
                char c3 = input[i + 2];
                char c4 = input[i + 3];

                if (c1 == c4 && c2 == c3 && c1 != c2)
                {
                    containsAbba = true;
                    break;
                }
            }

            return containsAbba;
        }

        private HashSet<string> GetAbas(string input)
        {
            const int ABA_CHARACTER_COUNT = 3;
            HashSet<string> potentialAbas = new HashSet<string>();

            for (int i = 0; i + ABA_CHARACTER_COUNT <= input.Length; i++)
            {
                char c1 = input[i];
                char c2 = input[i + 1];
                char c3 = input[i + 2];

                if (c1 == c3 && c1 != c2)
                {
                    potentialAbas.Add($"{c1}{c2}{c3}");
                }
            }

            return potentialAbas;
        }

        private bool HasAbaBabSet(string supernetSequence, string hypernetSequence)
        {
            HashSet<string> supernetAbas = GetAbas(supernetSequence);
            HashSet<string> hypernetAbas = GetAbas(hypernetSequence);

            // an ABA is any three-character sequence which consists of the same character twice with a different character between them, such as xyx or aba
            // A corresponding BAB is the same characters but in reversed positions: yxy and bab
            foreach (string s in supernetAbas)
            {
                foreach (string t in hypernetAbas)
                {
                    if (s[0] == t[1] && s[1] == t[0])
                    {
                        // we have an aba/bab pair
                        return true;
                    }
                }
            }

            return false;
        }

        private bool DoesSupportSsl()
        {
            // This approach is much simpler than 'DoesSupportSslStrict'
            // Search for *any* aba/bab pairs anywhere in the original input string
            foreach (string s in SupernetSequences)
            {
                foreach (string t in HypernetSequences)
                {
                    if (HasAbaBabSet(s, t))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Day14.Classes
{
    public class PuzzleProcessor
    {
        public static void ProcessPart1(string puzzleData)
        {
            Dictionary<uint, string> verifiedKeys = GetVerifiedKeys(puzzleData);

            var lastValue = verifiedKeys.OrderByDescending(x => x.Key).Take(1).FirstOrDefault();

            Console.WriteLine($"Last key found at index {lastValue.Key}.");
            Console.WriteLine($"{verifiedKeys.Count} verified keys found.");
        }

        public static void ProcessPart2(string puzzleData)
        {
            Dictionary<uint, string> verifiedKeys = GetVerifiedKeys(puzzleData, true);

            var lastValue = verifiedKeys.OrderByDescending(x => x.Key).Take(1).FirstOrDefault();

            Console.WriteLine($"Last key found at index {lastValue.Key}.");
            Console.WriteLine($"{verifiedKeys.Count} verified keys found.");
        }

        private static Dictionary<uint, string> GetVerifiedKeys(string puzzleData, bool useRidiculousEncryption = false)
        {
            const int EXIT_CONDITION = 64;

            Queue<KeyValuePair<uint, string>> hashQueue = new Queue<KeyValuePair<uint, string>>();
            Dictionary<uint, string> candidateKeys = new Dictionary<uint, string>();
            Dictionary<uint, string> verifiedKeys = new Dictionary<uint, string>();

            // Load up the hash queue
            uint iterator = 0;

            for(iterator = 0; iterator < 1000; iterator++)
            {
                string hashValue =
                    useRidiculousEncryption
                        ? HashGenerator.GetRidiculouslyHashedString(iterator, puzzleData)
                        : HashGenerator.GetHashedString(iterator, puzzleData);

                if (KeyValidator.HasTriple(hashValue))
                {
                    hashQueue.Enqueue(new KeyValuePair<uint, string>(iterator, hashValue));
                }
            }

            // Attempt to find the target number of valid keys
            while (verifiedKeys.Count < EXIT_CONDITION)
            {
                // get the next value we want to verify
                KeyValuePair<uint, string> candidateHash = hashQueue.Dequeue();

                // load up all other candidates up to 1000 more than the current hash
                // todo: put an additional conditional, "|| hashQueue.Count == 0" in case the queue is empty
                while (iterator < candidateHash.Key + 1000)
                {
                    iterator++;

                    string hashValue =
                        useRidiculousEncryption
                            ? HashGenerator.GetRidiculouslyHashedString(iterator, puzzleData)
                            : HashGenerator.GetHashedString(iterator, puzzleData);

                    if (KeyValidator.HasTriple(hashValue))
                    {
                        hashQueue.Enqueue(new KeyValuePair<uint, string>(iterator, hashValue));
                    }
                }

                // compare those candidates
                string charToFind = KeyValidator.GetFirstTriple(candidateHash.Value);

                foreach (KeyValuePair<uint, string> pair in hashQueue.ToList())
                {
                    if (KeyValidator.HasFive(pair.Value, charToFind))
                    {
                        verifiedKeys.Add(candidateHash.Key, candidateHash.Value);
                        Console.WriteLine($"Found key at {candidateHash.Key} verified by hash at index {pair.Key}. {verifiedKeys.Count} verified keys, so far.");
                    }
                }
            }

            return verifiedKeys;
        }
    }
}

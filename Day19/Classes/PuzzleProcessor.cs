using System;
using System.Collections.Generic;
using System.Linq;

namespace Day19.Classes
{
    public class PuzzleProcessor
    {
        public static void Process_Part1(int elfCount)
        {
            List<Elf> currentRound = new List<Elf>(elfCount);

            // initialize all elves
            for (int i = 1; i <= elfCount; i++)
            {
                currentRound.Add(new Elf(i, true));
            }

            while (currentRound.Count > 1)
            {
                List<Elf> nextRound = new List<Elf>();

                // When the count is even, remove all odd placed elves
                // When the count is odd, remove all odd placed elves, and additionally, the first elf
                int countStart = (currentRound.Count % 2 == 0) ? 0 : 2;

                for (int count = countStart; count < currentRound.Count; count += 2)
                {
                    nextRound.Add(currentRound[count]);
                }

                currentRound = nextRound;
            }

            Console.WriteLine($"With {elfCount} elves, elf #{currentRound.FirstOrDefault()?.Position} gets all the presents.");
        }

        public static void Process_Part2(int elfCount)
        {
            List<uint> elves = new List<uint>();

            // initialize the list
            for (uint i = 1; i <= elfCount; i++)
            {
                elves.Add(i);
            }

            while (elves.Count > 1)
            {
                // remove the elf across from the current elf
                elves.RemoveAt((int)Math.Floor(elves.Count / 2.0));

                // remove the current elf and stick him back at the end of the list
                elves.Add(elves[0]);
                elves.RemoveAt(0);
            }

            Console.WriteLine($"With {elfCount} elves, for the newer game, elf #{elves.FirstOrDefault()} gets all the presents.");
        }
    }
}

using System;
using System.Collections.Generic;
using Day4.Classes;
using Day4.PuzzleInput;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] parsedDataSet = GetParsedDataSet(Properties.Settings.Default.Setting_PuzzleInput_Part2_Test2);
            string[] parsedDataSet = GetParsedDataSet(PuzzleInputData.PuzzleInput);
            List<Room> rooms = GetRoomList(parsedDataSet);

            int runningTotal = 0;

            foreach (Room r in rooms)
            {
                runningTotal += r.IsRoomReal ? r.SectorId : 0;
                Console.WriteLine(r);
            }

            Console.WriteLine($"Running total: {runningTotal}");
        }

        public static string[] GetParsedDataSet(string puzzleInput)
        {
            return puzzleInput?.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
        }

        public static List<Room> GetRoomList(string[] parsedPuzzleInput)
        {
            List<Room> rooms = new List<Room>();

            string encryptedData = string.Empty;
            string sectorId = string.Empty;
            string checkSum = string.Empty;

            foreach (string s in parsedPuzzleInput)
            {
                // retrieve the checksum
                checkSum = s.Split(new[] {"["}, StringSplitOptions.RemoveEmptyEntries)?[1];
                checkSum = checkSum.Substring(0, checkSum.Length - 1);

                // retrieve the sector id
                int sectorIdStart = s.LastIndexOf("-", StringComparison.Ordinal) + 1;
                int sectorIdEnd = s.LastIndexOf("[", StringComparison.Ordinal);

                sectorId = s.Substring(sectorIdStart, sectorIdEnd - sectorIdStart);

                // retrieve the encrypted data
                encryptedData = s.Substring(0, sectorIdStart - 1);

                // finished
                // add the Room object
                rooms.Add(new Room(encryptedData, sectorId, checkSum));
            }

            return rooms;
        }
    }
}

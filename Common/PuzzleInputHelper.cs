using System;
using System.IO;

namespace Common
{
    public class PuzzleInputHelper
    {
        public static string ReadFile(string filename)
        {
            string fileNameToProcess = Path.Combine(Environment.CurrentDirectory, "PuzzleInput", filename);
            return File.ReadAllText(fileNameToProcess);
        }
    }
}

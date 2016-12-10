using System;
using System.Diagnostics;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Stopwatch
            #region Stopwatch Start
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            #endregion

            //string puzzleInput = "abc";
            string puzzleInput = "ffykfhsq";

            // step 1, calculate MD5 hash from input
            //...String password = HackingMoviePasswordGenerator.GeneratePassword(puzzleInput);
            String password = HackingMoviePasswordGenerator.GenerateTheBestPassword(puzzleInput);

            Console.WriteLine(password.ToLowerInvariant());

            // Stopwatch
            #region Stopwatch End
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            string elapsedTime = $"{ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds/10:00}";
            Console.WriteLine("RunTime " + elapsedTime);
            #endregion
        }
    }
}

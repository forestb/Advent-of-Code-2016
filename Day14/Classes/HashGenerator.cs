using System;
using System.Security.Cryptography;
using System.Text;

namespace Day14.Classes
{
    public class HashGenerator
    {
        private static readonly MD5 MD5 = MD5.Create();

        public static string GetHashedString(uint input, string salt)
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(String.Concat(salt, input.ToString()));

            byte[] hash = MD5.ComputeHash(inputBytes);

            return GetString(hash);
        }

        public static string GetRidiculouslyHashedString(uint input, string salt)
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(String.Concat(salt, input.ToString()));

            byte[] hash = MD5.ComputeHash(inputBytes);

            // Added for Part2 of puzzle
            for (int i = 0; i < 2016; i++)
            {
                hash = MD5.ComputeHash(GetAsciiBytes(GetString(hash)));
            }

            return GetString(hash);
        }

        #region Helper Methods

        private static string GetString(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();

            foreach (byte t in bytes)
            {
                // x2 = lowercase; X2 = uppercase
                sb.Append(t.ToString("x2"));
            }

            return sb.ToString();
        }

        private static byte[] GetAsciiBytes(string s)
        {
            return Encoding.ASCII.GetBytes(s);
        }

        #endregion
    }
}

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

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();

            foreach (byte t in hash)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString();
        }
    }
}

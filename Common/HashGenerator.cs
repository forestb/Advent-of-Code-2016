using System;
using System.Security.Cryptography;
using System.Text;

namespace Common
{
    public class HashGenerator
    {
        private static readonly MD5 MD5 = MD5.Create();

        public static string GetHashedString(string input)
        {
            return GetHashedString(input, string.Empty);
        }

        public static string GetHashedString(string input, string salt)
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(String.Concat(input, salt));

            byte[] hash = MD5.ComputeHash(inputBytes);

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

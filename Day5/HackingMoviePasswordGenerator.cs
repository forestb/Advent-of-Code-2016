using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Day5
{
    public class HackingMoviePasswordGenerator
    {
        private const int PASSWORD_LENGTH_I = 8;

        private static readonly MD5 MD5 = MD5.Create();

        public static string GeneratePassword(string input)
        {
            int counter = 0;
            string password = string.Empty;

            do
            {
                string hash = GetHashedString(input, counter);

                if (hash.Substring(0, 5) == "00000")
                {
                    password += hash.Substring(5, 1);
                }

                counter++;
            } while (password.Length < PASSWORD_LENGTH_I);
            
            return password;
        }

        public static string GenerateTheBestPassword(string input)
        {
            int counter = 0;
            Dictionary<int, string> passwordDictionary = new Dictionary<int, string>();
            string password = string.Empty;

            do
            {
                string hash = GetHashedString(input, counter);

                if (hash.Substring(0, 5) == "00000")
                {
                    // candidate password
                    int positionInt = -1;
                    string positionStr = hash.Substring(5, 1);

                    if (int.TryParse(positionStr, out positionInt))
                    {
                        // if we don't already have a character at this position...
                        if ((positionInt >=0 && positionInt <= 7) && !passwordDictionary.ContainsKey(positionInt))
                        {
                            string passwordCharacter = hash.Substring(6, 1);
                            passwordDictionary.Add(positionInt, passwordCharacter);
                        }
                    }
                }

                counter++;
            } while (passwordDictionary.Count < PASSWORD_LENGTH_I);

            password = string.Join(";", passwordDictionary.OrderBy(z => z.Key).Select(x => x.Key + "=" + x.Value).ToArray());

            return password;
        }

        private static string GetHashedString(string input, int salt)
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(input + salt.ToString());
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

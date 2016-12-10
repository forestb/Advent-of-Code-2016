using System.Collections.Generic;
using System.Linq;

namespace Day4.Classes
{
    public class Room
    {
        public string EncryptedData { get; }
        public string EncrytpedDataShifted { get; private set; }
        public int SectorId { get; }
        public string CheckSum { get; }
        public bool IsRoomReal { get; private set; }

        public Room(string encryptedData, string sectorId, string checkSum)
        {
            this.EncryptedData = encryptedData;

            int sectorIdInt = -1;
            SectorId = int.TryParse(sectorId, out sectorIdInt) ? sectorIdInt : -1;

            CheckSum = checkSum;

            ProcessEncryptedData(encryptedData, checkSum);
            ShiftEncryptedData(encryptedData);
        }

        public override string ToString()
        {
            return $"{EncryptedData};{SectorId};{CheckSum};{IsRoomReal};{EncrytpedDataShifted}";
        }

        private void ProcessEncryptedData(string encryptedData, string checkSum)
        {
            SortedList<string, int> sortedCharacterList = new SortedList<string, int>();

            foreach (char c in encryptedData)
            {
                if (c != '-')
                {
                    int characterCount = 0;

                    if (sortedCharacterList.TryGetValue(c.ToString(), out characterCount))
                    {
                        sortedCharacterList[c.ToString()] = sortedCharacterList[c.ToString()] + 1;
                    }
                    else
                    {
                        sortedCharacterList.Add(c.ToString(), 1);
                    }
                }
            }

            // process each CheckSum
            foreach (char c in checkSum)
            {
                var result =
                    sortedCharacterList
                        .OrderBy(x => x.Key)
                        .Reverse()
                        .OrderBy(y => y.Value)
                        .Reverse()
                        .Take(5).FirstOrDefault(z => z.Key == c.ToString());

                if (string.IsNullOrEmpty(result.Key))
                {
                    IsRoomReal = false;
                    return;
                }
            }

            IsRoomReal = true;
        }

        private void ShiftEncryptedData(string encryptedData)
        {
            foreach (char c in encryptedData)
            {
                EncrytpedDataShifted += GetShiftedCharacter(c);
            }
        }

        private string GetShiftedCharacter(char c)
        {
            if (c == '-')
            {
                return " ";
            }

            const int LETTERS_IN_ALPHABET = 26;
            const int LOWER_CASE_START = 97;
            const int LOWER_CASE_END = 122;
            SortedList<string, int> alphabet = new SortedList<string, int>();

            // build a list of characters
            for (int i = LOWER_CASE_START; i <= LOWER_CASE_END; i++)
            {
                string letter = ((char)i).ToString();
                int value = i - LOWER_CASE_START;

                alphabet.Add(letter, value);
            }

            // for each
            int currentValue = alphabet.FirstOrDefault(x => x.Key == c.ToString()).Value;
            int shiftBy = SectorId % LETTERS_IN_ALPHABET;
            int newValue = (currentValue + shiftBy) % LETTERS_IN_ALPHABET;
            string newCharacter = alphabet.FirstOrDefault(x => x.Value == newValue).Key;

            return newCharacter;
        }
    }
}

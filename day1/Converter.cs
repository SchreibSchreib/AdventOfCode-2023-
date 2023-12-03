using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day1
{
    internal class Converter
    {
        private string _encryptedString;
        public string Get { get; }

        public Converter(string encryptedString)
        {
            _encryptedString = encryptedString;
            EncryptStringt();
            Get = _encryptedString;
        }

        private void EncryptStringt()
        {
            string[] numbers = new string[]
            {
                "oneight",
                "twone",
                "threeight",
                "fiveight",
                "eightwo",
                "eighthree",
                "nineight",
                "one",
                "two",
                "three",
                "four",
                "five",
                "six",
                "seven",
                "eight",
                "nine"
            };

            foreach (string wordValue in numbers)
            {
                if (_encryptedString.Contains(wordValue))
                {
                    _encryptedString = ChangeValue(wordValue);
                }
            }
        }

        private string? ChangeValue(string wordValue)
        {
            StringBuilder createString = new StringBuilder();
            string[] multipleOccurences = _encryptedString.Split(wordValue);
            int index = 0;
            foreach (string wordPart in multipleOccurences)
            {
                if (index++ != multipleOccurences.Length -1)
                {
                    switch (wordValue)
                    {
                        case "oneight":
                            createString.Append(wordPart + 1 + wordValue);
                            continue;
                        case "twone":
                        case "threeight":
                        case "fiveight":
                        case "eightwo":
                        case "eighthree":
                        case "nineight":
                        case "one":
                            createString.Append(wordPart + 1 + wordValue);
                            continue;
                        case "two":
                            createString.Append(wordPart + 2 + wordValue);
                            continue;
                        case "three":
                            createString.Append(wordPart + 3 + wordValue);
                            continue;
                        case "four":
                            createString.Append(wordPart + 4 + wordValue);
                            continue;
                        case "five":
                            createString.Append(wordPart + 5 + wordValue);
                            continue;
                        case "six":
                            createString.Append(wordPart + 6 + wordValue);
                            continue;
                        case "seven":
                            createString.Append(wordPart + 7 + wordValue);
                            continue;
                        case "eight":
                            createString.Append(wordPart + 8 + wordValue);
                            continue;
                        case "nine":
                            createString.Append(wordPart + 9 + wordValue);
                            continue;
                    }
                }
                else
                {
                    createString.Append(wordPart);
                }
            }
            return createString.ToString();
        }
    }
}

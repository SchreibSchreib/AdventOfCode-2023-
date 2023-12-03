using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day1
{
    internal class Converter2
    {
        private string _line;
        private Dictionary<string, List<int>> _ints;
        private string[] _numbers = new string[]
            {
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

        public int FirstNumber { get; private set; }
        public int LastNumber { get; private set; }

        public Converter2(string line)
        {
            _line = line;
            _ints = LoadList(_line);
            FirstNumber = GetMin();
            LastNumber = GetMax();
        }

        private int GetMin()
        {

            int minNumber = _line.FirstOrDefault(char.IsDigit) - '0';
            int index = _line.IndexOf(minNumber.ToString());
            var result = _ints
            .OrderBy(entry => entry.Value.Min())
            .FirstOrDefault();

            if (result.Key != null)
            {
                if (index < result.Value[0])
                {
                    return minNumber;
                }
            }
            return ExtractNumeric(result.Key);
        }

       
        private int GetMax()
        {

            int maxNumber = _line.LastOrDefault(char.IsDigit) - '0';
            int index = _line.IndexOf(maxNumber.ToString());
            var result = _ints
           .OrderBy(entry => entry.Value.Max())
           .LastOrDefault();

            if (result.Key != null)
            {
                if (index > result.Value[result.Value.Count - 1])
                {
                    return maxNumber;
                }
            }
            return ExtractNumeric(result.Key);
        }

        private int ExtractNumeric(string numericWord)
        {
            switch (numericWord)
            {
                case "one":
                    return 1;
                case "two":
                    return 2;
                case "three":
                    return 3;
                case "four":
                    return 4;
                case "five":
                    return 5;
                case "six":
                    return 6;
                case "seven":
                    return 7;
                case "eight":
                    return 8;
                case "nine":
                    return 9;
                default:
                    return default;
            }
        }

        private Dictionary<string, List<int>> LoadList(string line)
        {
            Dictionary<string, List<int>> occurences = new Dictionary<string, List<int>>();

            foreach (string wordValue in _numbers)
            {
                if (line.Contains(wordValue))
                {
                    occurences.Add(wordValue, AddIndex(line, wordValue));
                }
            }

            return occurences;
        }

        private List<int> AddIndex(string line,
        string targetWord)
        {
            List<int> indices = new List<int>();
            int index = line.IndexOf(targetWord);

            while (index != -1)
            {
                indices.Add(index);
                index = line.IndexOf(targetWord, index + 1);
            }

            return indices;
        }
    }
}

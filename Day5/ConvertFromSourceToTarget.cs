using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    internal class ConvertFromSourceToTarget
    {

        public string Get { get; }

        public ConvertFromSourceToTarget(string source, string[] convertToNumbers)
        {
            Get = ConvertFromTo(source, convertToNumbers);
        }

        private string ConvertFromTo(string source, string[] convertToNumbers)
        {
            Dictionary<long, long> rangeOfInts = GetMatchingNumber(source, convertToNumbers);
            string result = GetNewString(source, rangeOfInts);
            return result;
        }

        private Dictionary<long, long> GetMatchingNumber(string source, string[] convertToNumbers)
        {
            long[] fromNumbers = source.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => long.Parse(x))
                .ToArray();

            return GetRange(convertToNumbers, fromNumbers);
        }

        private Dictionary<long, long> GetRange(string[] convertToNumbers, long[] fromNumbers)
        {
            Dictionary<long, long> range = new Dictionary<long, long>();

            foreach (string str in convertToNumbers)
            {
                long[] rangeNumbers = str.Split(' ').Select(x => long.Parse(x)).ToArray();
                foreach (long numberFrom in fromNumbers)
                {
                    if (IsInRange(numberFrom, rangeNumbers[1], rangeNumbers[2]) && !range.ContainsKey(numberFrom))
                    {
                        long difference = numberFrom - rangeNumbers[1];
                        long target = difference + rangeNumbers[0];
                        range.Add(numberFrom, target);
                    }
                }
            }
            return range;
        }

        private bool IsInRange(long numberFrom, long sourceStart, long range)
        {
            return numberFrom >= sourceStart && numberFrom < sourceStart + range;
        }

        private string GetNewString(string from, Dictionary<long, long> rangeOfInts)
        {
            long[] numbersToConvert = from.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(from => long.Parse(from)).ToArray();
            StringBuilder buildNewString = new StringBuilder();
            foreach (long number in numbersToConvert)
            {
                if (rangeOfInts.ContainsKey(number))
                {
                    buildNewString.Append($"{rangeOfInts[number]} ");
                }
                else
                {
                    buildNewString.Append($"{number} ");
                }
            }
            return buildNewString.ToString();
        }
    }
}

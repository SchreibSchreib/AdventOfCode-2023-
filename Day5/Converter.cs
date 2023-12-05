using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    internal class Converter
    {

        public string Get { get; }

        public Converter(string from, string[] convertNumbers)
        {
            Get = ConvertFromTo(from, convertNumbers);
        }

        private string ConvertFromTo(string from, string[] convertNumbers)
        {
            Dictionary<long, long> rangeOfInts = GetMatchingNumber(from, convertNumbers);
            string result = GetNewString(from, rangeOfInts);
            return result;
        }

        private Dictionary<long, long> GetMatchingNumber(string from, string[] convertNumbers)
        {
            long[] fromNumbers = from.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => long.Parse(x)).ToArray();
            Dictionary<long, long> range = new Dictionary<long, long>();
            foreach (string str in convertNumbers)
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

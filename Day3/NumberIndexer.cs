using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day3
{
    internal class NumberIndexer
    {
        public Tuple<int, Dictionary<int, int>> Get { get; }

        public NumberIndexer(string line, int indexOfLine)
        {
            Get = LoadDictionary(line, indexOfLine);
        }

        private Tuple<int, Dictionary<int, int>> LoadDictionary(string line, int indexOfLine) => new Tuple<int, Dictionary<int, int>>
            (indexOfLine,
            GetIndizes(line));

        private Dictionary<int, int> GetIndizes(string line)
        {
            var matches = Regex.Matches(line, @"\d+");

            Dictionary<int, int> result = matches
            .Cast<Match>()
            .Select(match => new { Index = match.Index, Value = int.Parse(match.Value) })
            .ToDictionary(item => item.Index, item => item.Value);

            return result;
        }
    }
}

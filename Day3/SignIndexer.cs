using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    internal class SignIndexer
    {
        public Tuple<int, int[]> Get { get; }

        public SignIndexer(string line, int indexOfLine)
        {
            Get = LoadDictionary(line, indexOfLine);
        }

        private Tuple<int, int[]> LoadDictionary(string line, int indexOfLine) => new Tuple<int, int[]>
            (indexOfLine,
            GetIndizes(line));

        private int[] GetIndizes(string line)
        {
            return line.Select((ch, index) => new { Char = ch, Index = index })
                .Where(item => item.Char != '.' && !char.IsLetterOrDigit(item.Char))
                .Select(item => item.Index)
                .ToArray();
        }
    }
}

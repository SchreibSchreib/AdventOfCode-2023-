using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Day9
{
    internal class DictionaryLineAdder
    {
        public Dictionary<int, List<int>> Get { get; }

        public DictionaryLineAdder(List<int> expression)
        {
            Get = GetAllNeededLines(expression);
        }

        private Dictionary<int, List<int>> GetAllNeededLines(List<int> expression)
        {
            Dictionary<int, List<int>> lineToNumbers = new Dictionary<int, List<int>>();
            lineToNumbers.Add(0, expression);

            for (int lineInDictionary = 0; lineInDictionary < lineToNumbers.Count; lineInDictionary++)
            {
                if (!IsLineZeroLine(lineToNumbers[lineInDictionary]))
                {
                    lineToNumbers.Add(lineInDictionary + 1, GetNextLine(lineToNumbers[lineInDictionary]));
                    continue;
                }
            }
            return lineToNumbers;
        }

        private List<int> GetNextLine(List<int> ints) => ints.Zip(ints.Skip(1), (current, next) => next - current).ToList();

        private bool IsLineZeroLine(List<int> ints) => ints.All(x => x == 0);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    internal class BroadSearch
    {
        public List<int> NumbersForSum { get; }

        private string[] _fieldToCheck;

        public BroadSearch(string[] fieldToCheck, NumberIndexer indicesOfNumbers)
        {
            _fieldToCheck = fieldToCheck;
            NumbersForSum = GetAllNumbers(indicesOfNumbers);
        }

        private List<int> GetAllNumbers(NumberIndexer indicesOfSymbols)
        {
            var result = new List<int>();
            var indices = indicesOfSymbols.Get;

            foreach (var tuple in indices)
            {
                var numberOfSymbolsNearby = GetNeighbourSymbols(tuple);
                result.Add(tuple.Item1 * numberOfSymbolsNearby);
            }
            return result;
        }

        private int GetNeighbourSymbols(Tuple<int, int, int, int> tuple)
        {
            int yStartIndex = tuple.Item2;
            int xStartIndex = tuple.Item3;
            int xEndIndex = tuple.Item4;

            int result = 0;

            for (int y = yStartIndex - 1; y <= yStartIndex + 1; y++)
            {
                if (y >= 0 && y < _fieldToCheck.Length)
                {
                    for (int x = xStartIndex - 1; x <= xEndIndex + 1; x++)
                    {
                        if (x >= 0 && x < _fieldToCheck[y].Length)
                        {
                            if (_fieldToCheck[y][x] != '.' && !Char.IsNumber(_fieldToCheck[y][x]))
                            {
                                result++;
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    internal class SearchMatrix
    {

        public List<int> GetAvailableNumbers { get; }

        public SearchMatrix(
            Dictionary<int, int[]> indicesOfSymbols,
            Dictionary<int, Dictionary<int, int>> indicesOfNumbers)
        {
            GetAvailableNumbers = SearchForNumbers(indicesOfSymbols, indicesOfNumbers);
        }

        private List<int> SearchForNumbers(
            Dictionary<int, int[]> indicesOfSymbols,
            Dictionary<int, Dictionary<int, int>> indicesOfNumbers)
        {
            List<int> availableNumbers = new List<int>();

            foreach (KeyValuePair<int, int[]> pair in indicesOfSymbols)
            {
                foreach (int indexes in pair.Value)
                {
                    foreach ((int i, int j) in GetNeighbours(pair.Key, indexes))
                    {
                        if (indicesOfNumbers.ContainsKey(i) && indicesOfNumbers[i].ContainsKey(j))
                        {
                            int foundNumber = indicesOfNumbers[i][j];
                            availableNumbers.Add(foundNumber);

                            indicesOfNumbers[i].Remove(j);
                        }
                    }
                }
            }
            return availableNumbers;
        }

        private IEnumerable<(int, int)> GetNeighbours(int line, int index)
        {
            for (int i = line - 1; i <= line + 1; i++)
            {
                for (var j = index - 1; j <= index + 1; j++)
                {
                    if (i != line || j != index)
                    {
                        yield return (i, j);
                    }
                }
            }
        }
    }
}
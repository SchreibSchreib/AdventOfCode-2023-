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

        public BroadSearch(NumberIndexer indicesOfNumbers)
        {
            NumbersForSum = GetAllNumbers(indicesOfNumbers);
        }

        private List<int> GetAllNumbers(NumberIndexer indicesOfSymbols)
        {
            var result = new List<int>();
            var indices = indicesOfSymbols.Get;

            foreach (var tuple in indices)
            {

            }

            return result;
        }
    }
}

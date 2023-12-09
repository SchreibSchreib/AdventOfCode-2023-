using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    internal class ExpressionExtrapolator
    {
        private Dictionary<int, List<int>> _calculatedDictionary; 

        public int Result { get; }

        public ExpressionExtrapolator(List<int> expression)
        {
            _calculatedDictionary = new DictionaryLineAdder(expression).Get;
            _calculatedDictionary = new NumberAdder(_calculatedDictionary).Get;
            Result = Extrapolate();
        }

        private int Extrapolate() => _calculatedDictionary[0].Last();
    }
}

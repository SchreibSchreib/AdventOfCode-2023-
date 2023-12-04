using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    internal class Converter
    {
        public int GetNumber { get; }

        public Converter(int first, int last)
        {
            GetNumber = ConcatNumbers(first, last);
        }

        private int ConcatNumbers(int first, int last) => int.Parse($"{first}{last}");
    }
}

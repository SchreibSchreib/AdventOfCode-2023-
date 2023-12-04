
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    internal class HandCards
    {
        public int[] Get { get; }

        public HandCards(string winningNumbersString)
        {
            Get = GetNumbers(winningNumbersString);
        }

        private int[] GetNumbers(string handNumbersString) =>
            handNumbersString
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
    }
}


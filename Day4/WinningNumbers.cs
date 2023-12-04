using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    internal class WinningNumbers
    {
        public int[] Get { get; }

        public WinningNumbers(string winningNumbersString)
        {
            Get = GetNumbers(winningNumbersString);
        }

        private int[] GetNumbers(string winningNumbersString) => 
            winningNumbersString.Split(':')[1]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
    }
}

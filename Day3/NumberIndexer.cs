using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Day3
{
    internal class NumberIndexer
    {
        public List<Tuple<int, int, int, int>> Get { get; }

        public NumberIndexer(string[] input)
        {
            Get = FindIndexes(input);
        }

        private List<Tuple<int, int, int, int>> FindIndexes(string[] input)
        {
            var indexList = new List<Tuple<int, int, int, int>>();

            for (int yIndex = 0; yIndex < input.Length; yIndex++)
            {
                for (int xIndex = 0; xIndex < input[yIndex].Length; xIndex++)
                {
                    if (!Char.IsDigit(input[yIndex][xIndex]))
                        continue;

                    var newTuple = GetTuple(input[yIndex], yIndex, ref xIndex);
                    indexList.Add(newTuple);
                }
            }

            return indexList;
        }

        private Tuple<int, int, int, int> GetTuple(string textLine, int yIndex, ref int xIndex)
        {
            var completeValue = "";

            for (; xIndex < textLine.Length; xIndex++)
            {
                if (!Char.IsDigit(textLine[xIndex]))
                    break;

                completeValue += textLine[xIndex];
            }

            var result = new Tuple<int, int, int, int>(
                int.Parse(completeValue),
                yIndex,
                xIndex - completeValue.Length,
                xIndex - 1);

            return result;
        }
    }
}

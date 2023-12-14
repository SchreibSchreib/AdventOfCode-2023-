using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14
{
    internal class StringArrayRotator
    {
        public string[] Get { get; }

        public StringArrayRotator(string[] inputArray)
        {
            Get = RotateArray(inputArray);
        }

        private string[] RotateArray(string[] inputArray)
        {
            string[] rotatedArray = new string[inputArray[0].Length];

            for (int indexOnLine = 0; indexOnLine < rotatedArray.Length; indexOnLine++)
            {
                StringBuilder convertInput = new StringBuilder();

                foreach (string line in inputArray)
                {
                    convertInput.Append(line[indexOnLine]);
                }

                rotatedArray[indexOnLine] = convertInput.ToString();
                rotatedArray[indexOnLine] = new string(rotatedArray[indexOnLine].Reverse().ToArray());
            }

            return rotatedArray;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    internal class InputDictionaryCreator
    {
        public Dictionary<int, int> Get { get; }

        public InputDictionaryCreator(string[] input)
        {
            Get = CreateDictionary(input);
        }

        private Dictionary<int, int> CreateDictionary(string[] input)
        {
            List<int> values = SplitInput(input[0]);
            List<int> keys = SplitInput(input[1]);

            return keys.Zip(values, (time, distance) => new { Time = time, Distance = distance })
            .ToDictionary(pair => pair.Time, pair => pair.Distance);
        }

        private List<int> SplitInput(string inputLine) => inputLine.Split(' ',StringSplitOptions.RemoveEmptyEntries)
            .Skip(1)
            .Select(int.Parse)
            .ToList();
    }
}

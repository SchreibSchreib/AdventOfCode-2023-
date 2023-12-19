using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day19
{
    internal class AcceptedParts
    {
        public List<Dictionary<string, int>> Get { get; }

        public AcceptedParts(string acceptedParts)
        {
            Get = GetPartsList(acceptedParts);
        }

        private List<Dictionary<string, int>> GetPartsList(string acceptedParts)
        {
            var splittedAcceptedParts = acceptedParts.Split("\n");
            var result = new List<Dictionary<string, int>>();

            foreach (var part in splittedAcceptedParts)
            {
                var splittedPart = part
                    .Replace("{","")
                    .Replace("}","")
                    .Replace("\r","")
                    .Split(",");

                var entriesForParts = new Dictionary<string, int>();

                foreach (var entry in  splittedPart)
                {
                    string letter = entry.Split("=")[0];
                    int number = int.Parse(entry.Split("=")[1]);

                    entriesForParts.Add(letter, number);
                }
                result.Add(entriesForParts);
            }
            return result;
        }

    }
}

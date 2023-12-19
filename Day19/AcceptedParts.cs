using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day19
{
    internal class AcceptedParts
    {
        public List<string[]> Get { get; }

        public AcceptedParts(string acceptedParts)
        {
            Get = GetPartsList(acceptedParts);
        }

        private List<string[]> GetPartsList(string acceptedParts)
        {
            var splittedAcceptedParts = acceptedParts.Split("\n");
            var result = new List<string[]>();

            foreach (var part in splittedAcceptedParts)
            {
                result.Add(part
                    .Replace("{", "")
                    .Replace("}", "")
                    .Replace("\r", "")
                    .Split(","));
            }
            return result;
        }

    }
}

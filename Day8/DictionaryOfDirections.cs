using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    internal class DictionaryOfDirections
    {
        public Dictionary<string, string> Get;

        public DictionaryOfDirections(string[] input)
        {
            Get = CreateDictionary(input);
        }

        private Dictionary<string, string> CreateDictionary(string[] input)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            foreach (string key in input)
            {
                if (key.Contains("="))
                {
                    result.Add(CropArrayToCleanStrings(key)[0], CropArrayToCleanStrings(key)[1]);
                }
            }
            return result;
        }

        private string[] CropArrayToCleanStrings(string line) => line.Replace(" ", "").Split('=');
    }
}

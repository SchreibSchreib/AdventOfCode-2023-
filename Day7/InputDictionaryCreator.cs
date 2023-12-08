using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{

    internal class InputDictionaryCreator
    {
        public Dictionary<string, int> Get { get; }

        public InputDictionaryCreator(string[] content) 
        {
            Get = LoadDictionary(content);
        }

        private Dictionary<string, int> LoadDictionary(string[] content)
        {
            Dictionary<string,int> handAndPointValue = new Dictionary<string, int>();

            foreach ( string contentLine in content )
            {
                string handCards = contentLine.Split(" ")[0];
                int points = int.Parse(contentLine.Split(" ")[1]);

                handAndPointValue.Add(handCards, points);
            }

            return handAndPointValue;
        }
    }
}

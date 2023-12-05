using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    internal class inputDictionary
    {
        public Dictionary<string, string[]> Get { get; }

        public inputDictionary(string[] content)
        {
            Get = new Dictionary<string, string[]>();
            TransformInputToDictionary(content);
        }

        private void TransformInputToDictionary(string[] input)
        {
            string? currentLoad = null;
            List<string> loadStrings = new List<string>();

            for (int index = 0; index < input.Length; index++)
            {
                if (!char.IsDigit(input[index][0]) && currentLoad == null)
                {
                    currentLoad = input[index];
                }
                else if (!char.IsDigit(input[index][0]) && currentLoad != null)
                {
                    Get.Add(currentLoad, loadStrings.ToArray());
                    loadStrings.Clear();
                    currentLoad = input[index];
                }
                else
                {
                    loadStrings.Add(input[index]);
                }
            }
            Get.Add(currentLoad, loadStrings.ToArray());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    internal class Content
    {
        private readonly string _filePath;

        public string[] Get { get; }

        public Content()
        {
            _filePath = GetCurrentPath();
            Get = LoadContent();
        }


        private string GetCurrentPath() => Path.Combine(
            Directory.GetCurrentDirectory(),
            "Input.txt");

        private string[] LoadContent()
        {
            List<string> content = new List<string>();

            using (StreamReader reader = new StreamReader(_filePath))
            {
                while (!reader.EndOfStream)
                {
                    content.Add(reader.ReadLine());
                }
                reader.Close();

                string[] inputArray = content.ToArray();
                inputArray = inputArray.Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();

                return inputArray;
            }
        }
    }
}

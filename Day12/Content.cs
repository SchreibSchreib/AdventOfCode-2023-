using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12
{
    internal class Content
    {
        private readonly string _filePath;

        public Dictionary<string,int[]> Get { get; }

        public Content()
        {
            _filePath = GetCurrentPath();
            Get = LoadContent();
        }


        private string GetCurrentPath() => Path.Combine(
            Directory.GetCurrentDirectory(),
            "Input.txt");

        private Dictionary<string, int[]> LoadContent()
        {
            Dictionary<string, int[]> content = new Dictionary<string, int[]>();

            using (StreamReader reader = new StreamReader(_filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string splittedInputText = line.Split(" ")[0];
                    int[] splittedInputNumbers = line.Split(" ")[1].Split(',').Select(int.Parse).ToArray();

                    content.Add(splittedInputText, splittedInputNumbers);
                }
                reader.Close();

                return content;
            }
        }
    }
}

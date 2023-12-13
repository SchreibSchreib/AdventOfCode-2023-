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

        public List<Tuple<string, int[]>> Get { get; }

        public Content()
        {
            _filePath = GetCurrentPath();
            Get = LoadContent();
        }


        private string GetCurrentPath() => Path.Combine(
            Directory.GetCurrentDirectory(),
            "Input.txt");

        private List<Tuple<string, int[]>> LoadContent()
        {
            List<Tuple<string, int[]>> content = new List<Tuple<string, int[]>>();

            using (StreamReader reader = new StreamReader(_filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string splittedInputText = line.Split(" ")[0];
                    int[] splittedInputNumbers = line.Split(" ")[1].Split(',').Select(int.Parse).ToArray();
                    Tuple<string,int[]> splittedInput = new Tuple<string,int[]>(splittedInputText, splittedInputNumbers);
                    content.Add(splittedInput);
                }
                reader.Close();

                return content;
            }
        }
    }
}

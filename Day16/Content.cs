using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16
{
    internal class Content
    {
        private readonly string _filePath;

        public char[,] Get { get; }

        public Content()
        {
            _filePath = GetCurrentPath();
            Get = LoadContent();
        }


        private string GetCurrentPath() => Path.Combine(
            Directory.GetCurrentDirectory(),
            "Input.txt");

        private char[,] LoadContent()
        {
            string[] fileContent = new string[0];

            using (StreamReader reader = new StreamReader(_filePath))
            {
                List<string> lines = new List<string>();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    lines.Add(line);
                }

                fileContent = lines.ToArray();
            }

            char[,] content = new char[fileContent.Length, fileContent[0].Length];

            for (int yIndex = 0; yIndex < fileContent.Length; yIndex++)
            {
                for (int xIndex = 0; xIndex < fileContent[yIndex].Length; xIndex++)
                {
                    content[yIndex,xIndex] = (char)fileContent[yIndex][xIndex];
                }
            }


            return content;
        }
    }
}

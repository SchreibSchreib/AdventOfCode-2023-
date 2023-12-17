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
                while (!reader.EndOfStream)
                {
                    string file = reader.ReadToEnd();

                    fileContent = file.Split("/n");
                }
                reader.Close();
            }

            char[,] content = new char[fileContent.Length, fileContent[0].Length];

            for (int yIndex = 0; yIndex < fileContent.Length; yIndex++)
            {
                for (int xIndex = 0; xIndex < fileContent[0].Length; xIndex++)
                {
                    content[yIndex,xIndex] = (char)fileContent[yIndex][xIndex];
                }
            }


            return content;
        }
    }
}

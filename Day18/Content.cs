using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day18
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
            string[] result = new string[0];

            using (StreamReader reader = new StreamReader(_filePath))
            {
                while (!reader.EndOfStream)
                {
                    string nextLine = reader.ReadLine();

                        result = nextLine.Split(",");
                }
                reader.Close();

                return result;
            }
        }
    }
}

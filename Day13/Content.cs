using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day13
{
    internal class Content
    {
        private readonly string _filePath;

        public List<string[]> Get { get; }

        public Content()
        {
            _filePath = GetCurrentPath();
            Get = LoadContent();
        }


        private string GetCurrentPath() => Path.Combine(
            Directory.GetCurrentDirectory(),
            "Input.txt");

        private List<string[]> LoadContent()
        {
            List<string> content = new List<string>();
            List<string[]> result = new List<string[]>();

            using (StreamReader reader = new StreamReader(_filePath))
            {
                while (!reader.EndOfStream)
                {
                    string nextLine = reader.ReadLine();
                    if (string.IsNullOrEmpty(nextLine))
                    {
                        string[] nextBlock = content.Select(x => x).ToArray();
                        result.Add(nextBlock);
                        content.Clear();
                        continue;
                    }
                    content.Add(nextLine);
                }
                string[] lastBlock = content.Select(x => x).ToArray();
                result.Add(lastBlock);
                reader.Close();

                return result;
            }
        }
    }
}

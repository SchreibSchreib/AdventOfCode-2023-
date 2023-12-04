using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    internal class Content
    {
        private readonly string _filePath;

        public List<string> Get { get; }

        public Content()
        {
            _filePath = GetCurrentPath();
            Get = LoadContent();
        }


        private string GetCurrentPath() => Path.Combine(
            Directory.GetCurrentDirectory(),
            "Input.txt");

        private List<string> LoadContent()
        {
            List<string> content = new List<string>();

            using (StreamReader reader = new StreamReader(_filePath))
            {
                while (!reader.EndOfStream)
                {
                    content.Add(reader.ReadLine());
                }
                reader.Close();

                return content;
            }
        }
    }
}

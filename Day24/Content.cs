using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day24
{
    internal class Content
    {
        private readonly string _filePath;

        public List<HailStone> Get { get; }

        public Content()
        {
            _filePath = GetCurrentPath();
            Get = LoadContent();
        }


        private string GetCurrentPath() => Path.Combine(
            Directory.GetCurrentDirectory(),
            "Input.txt");

        private List<HailStone> LoadContent()
        {
            List<HailStone> listOfAllStones = new List<HailStone>();

            using (StreamReader reader = new StreamReader(_filePath))
            {

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    listOfAllStones.Add(ConvertToStone(line));
                }
            }

            return listOfAllStones;
        }

        private HailStone ConvertToStone(string line)
        {
            var splitToStartAndMove = line.Split("@");
            var listStartPoints = GenerateListStartPoints(splitToStartAndMove);
            var listVelocity = GenerateVelocityList(splitToStartAndMove);

            return new HailStone(listStartPoints[0],
                listStartPoints[1],
                listStartPoints[2],
                listVelocity[0],
                listVelocity[1],
                listVelocity[2]);
        }

        private List<int> GenerateVelocityList(string[] splitToStartAndMove)
        {
            var velocityList = new List<int>();
            var velocityData = splitToStartAndMove[1].Split(",");

            foreach (var point in velocityData)
            {
                velocityList.Add(int.Parse(point));
            }

            return velocityList;
        }

        private List<long> GenerateListStartPoints(string[] splitToStartAndMove)
        {
            var startList = new List<long>();
            var startingPoints = splitToStartAndMove[0].Split(",");

            foreach (var point in startingPoints)
            {
                startList.Add(long.Parse(point));
            }

            return startList;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    internal class CubeCollection
    {
        private int _maxRed;
        private int _maxBlue;
        private int _maxGreen;
        private bool _shallAdd = true;
        private string _gameString;
        public int NumberOfPossibleGame { get; private set; }

        public CubeCollection(string gameString)
        {
            _maxRed = 12;
            _maxGreen = 13;
            _maxBlue = 14;
            _gameString = gameString;
            Evaluate();
        }

        private void Evaluate()
        {
            char[] game = _gameString.Split(':')[0]
                .Reverse()
                .TakeWhile(char.IsDigit)
                .Reverse().ToArray();
            int gameNumber = int.Parse(game);
            string[] allRounds = _gameString.Split(':')[1].Split(';');

            foreach (string round in allRounds) 
            {
                string[] partOfRound = round.Split(",");
                foreach (string part in partOfRound)
                {
                    string number = part.Split(' ')[1];
                    int numberOfCubes = int.Parse(number);
                    string color = part.Split(" ")[2];
                    if (IsMoreThanMax(numberOfCubes, color))
                    {
                        _shallAdd = false;
                    }
                }
            }
            if (_shallAdd)
            {
                NumberOfPossibleGame = gameNumber;
            }
        }

        private bool IsMoreThanMax(int currentNumber, string colorOfCube)
        {
            return currentNumber > GetMax(colorOfCube);
        }

        private int GetMax(string colorOfCube)
        {
            switch (colorOfCube)
            {
                case "red":
                    return _maxRed;
                case "green":
                    return _maxGreen;
                default:
                    return _maxBlue;

            }
        }
    }
}

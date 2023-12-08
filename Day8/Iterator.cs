using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    internal class Iterator
    {
        private string _start = "AAA";
        private string _goal = "ZZZ";
        private bool _goalFound = false;
        private string _leftOrRight;

        public int Iterations { get; }

        public Iterator(Dictionary<string, string> network, string leftOrRight)
        {
            _leftOrRight = leftOrRight;
            Iterations = GetIterations(network);
        }

        private int GetIterations(Dictionary<string, string> network) => NavigateThroughNetwork(network);

        private int NavigateThroughNetwork(Dictionary<string, string> network)
        {
            string netWorkPoint = _start;
            int numberOfIterations = 0;

            while (!_goalFound)
            {
                foreach (char navigation in _leftOrRight)
                {
                    numberOfIterations++;
                    ConsoleColor consoleColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{numberOfIterations} times navigated");
                    Console.ForegroundColor = consoleColor;
                    netWorkPoint = GetNewPoint(navigation, network, netWorkPoint); 
                    if (netWorkPoint == "ZZZ")
                    {
                        _goalFound = true;
                        break;
                    }
                }
            }
            return numberOfIterations;
        }

        private string GetNewPoint(char navigation, Dictionary<string, string> network, string currentLocation)
        {
            Console.WriteLine($"Going from: {currentLocation}");

            string cleanString = GetCleanString(network[currentLocation]);
            if (navigation == 'L')
            {
                Console.WriteLine($"Going to: {cleanString.Split(",")[0]}");
                return cleanString.Split(",")[0];
            }
            Console.WriteLine($"Going to: {cleanString.Split(",")[1]}");
            return cleanString.Split(",")[1];
        }

        private string GetCleanString(string cleanString) => cleanString.Replace("(", "").Replace(")", "");
    }
}

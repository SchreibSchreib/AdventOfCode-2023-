using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day22
{
    internal class Brick
    {
        public int[]? CoordinatesX { get; }
        public int[]? CoordinatesY { get; }
        public int[]? CoordinatesZ { get; }
        private string[] _brickSymbolForDirection;


        public Brick()
        {
            _brickSymbolForDirection = new string[] { ".", "." };
        }

        public Brick(string brickInformation)
        {
            _brickSymbolForDirection = new string[] { "X", "Y", "?" };
            CoordinatesX = GetCoordinates(GetStartCoordinate(brickInformation, 0), GetEndCoorinate(brickInformation, 0));
            CoordinatesY = GetCoordinates(GetStartCoordinate(brickInformation, 1), GetEndCoorinate(brickInformation, 1));
            CoordinatesZ = GetCoordinates(GetStartCoordinate(brickInformation, 2), GetEndCoorinate(brickInformation, 2));
        }

        private int GetStartCoordinate(string brickInformation, int indexNumber) => int.Parse
            (brickInformation.Split("~")[0].Split(",")[indexNumber]);

        private int GetEndCoorinate(string brickInformation, int indexNumber) => int.Parse
            (brickInformation.Split("~")[1].Split(",")[indexNumber]);

        private int[] GetCoordinates(int startPoint, int endPoint) => new int[] { startPoint, endPoint };
    }
}

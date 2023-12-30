using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day23.AbstractClasses
{
    abstract class FieldSign
    {
        public bool IsStepped { get; private set; } = false;
        public int[,] Coordinates { get; }
        public int StepsToWalkHere { get; private set; }

        public Dictionary<string, string>? PossibleDirections;

        public FieldSign(int yCoords, int xCoords)
        {
            PossibleDirections = GetDirections();
            Coordinates = new int[,]
                {
                    { yCoords, xCoords }
                };
        }

        public void SteppedOn(Person currentRoute)
        {
            IsStepped = true;
            StepsToWalkHere = currentRoute.CurrentWalkedSteps;
        }

        protected abstract Dictionary<string, string>? GetDirections();
    }
}

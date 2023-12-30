using Day23.AbstractClasses;
using Day23.Signs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day23
{
    internal class Person
    {
        public int[,] CurrentPosition { get; private set; }
        public int CurrentWalkedSteps { get; private set; }

        public bool ReachedEnd { get; private set; } = false;
        public bool CrossedBetterOrEqualWay { get; private set; } = false;

        public Person(int[,] positionOfPerson, int currentWalkedSteps)
        {
            CurrentPosition = positionOfPerson;
            CurrentWalkedSteps = currentWalkedSteps;
        }

        internal void Move(FieldSign nextField)
        {
            CurrentWalkedSteps++;

            if (nextField.StepsToWalkHere >= CurrentWalkedSteps && !nextField.IsStepped)
            {
                CrossedBetterOrEqualWay = true;
            }

            CurrentPosition = nextField.Coordinates;
        }

        public void HasReachedEnd() => ReachedEnd = true;
    }
}

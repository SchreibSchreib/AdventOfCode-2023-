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
        public int MaxSteps { get; private set; }
        public bool ReachedEnd { get; private set; } = false;
        public bool CrossedOtherWay { get; private set; } = false;

        public Person(int[,] positionOfPerson, int currentWalkedSteps)
        {
            CurrentPosition = positionOfPerson;
            CurrentWalkedSteps = currentWalkedSteps;
        }

        internal void Move(FieldSign nextField)
        {
            if (nextField.StepsToWalkHere >= CurrentWalkedSteps + 1 && nextField.IsStepped)
            {
                CrossedOtherWay = true;
                return;
            }

            if (nextField.StepsToWalkHere < CurrentWalkedSteps + 1 && nextField.IsStepped)
            {
                CrossedOtherWay = true;
                MaxSteps = CalculateMaxStepsUsingOtherRoute(nextField);
            }

            CurrentWalkedSteps++;
            nextField.CalculateSteps(this);
            nextField.SteppedOn(this);
            CurrentPosition = nextField.Coordinates;
        }

        private int CalculateMaxStepsUsingOtherRoute(FieldSign nextField)
        {
            return (CurrentWalkedSteps + 1 - nextField.StepsToWalkHere) + nextField.PersonWhoSteppedOnThisField.MaxSteps;
        }

        public void CalculateMaxSteps(int maxSteps) => MaxSteps = maxSteps;

        public void EndReached() => ReachedEnd = true;
    }
}

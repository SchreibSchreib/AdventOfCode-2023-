﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day23.AbstractClasses
{
    abstract class FieldSign
    {
        public Person? PersonWhoSteppedOnThisField { get; private set; }
        public bool IsStepped { get; private set; } = false;
        public int[,] Coordinates { get; }
        public int StepsToWalkHere { get; private set; }
        public string Symbol = "#";

        public int DirectionY { get; protected set; }
        public int DirectionX { get; protected set; }

        public FieldSign(int yCoords, int xCoords)
        {
            Coordinates = new int[,]
                {
                    { yCoords, xCoords }
                };
        }

        public void SteppedOn(Person currentRoute)
        {
            IsStepped = true;
            PersonWhoSteppedOnThisField = currentRoute;
        }
        public void CalculateSteps(Person currentRoute)
        {
            StepsToWalkHere = currentRoute.CurrentWalkedSteps + 1;
        }
    }
}

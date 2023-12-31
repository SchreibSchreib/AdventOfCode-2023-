using Day23.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day23.Signs
{
    internal class SlopeRight : FieldSign
    {
        public SlopeRight(int yCoords, int xCoords) : base(yCoords, xCoords)
        {
            DirectionY = 0;
            DirectionX = 1;
        }
    }
}

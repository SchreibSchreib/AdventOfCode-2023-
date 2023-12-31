using Day23.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day23.Signs
{
    internal class SlopeDown : FieldSign
    {
        public SlopeDown(int yCoords, int xCoords) : base(yCoords, xCoords)
        {
            DirectionY = -1;
            DirectionX = 0;
        }
    }
}

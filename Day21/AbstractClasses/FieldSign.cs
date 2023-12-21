using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16.AbstractClasses
{
    abstract class FieldSign
    {
        public bool IsBlocking { get; protected set; } = false;
        public int[,] Position;

        public FieldSign(int[,] positionOfSign)
        {
            Position = positionOfSign;
        }
    }
}

using Day16.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day21
{
    internal class NonBlockingField : FieldSign
    {
        public NonBlockingField(int[,] positionOfSign) : base(positionOfSign)
        {
        }
    }
}

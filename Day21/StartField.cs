using Day16.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day21
{
    internal class StartField : FieldSign
    {
        public StartField(int[,] positionOfSign) : base(positionOfSign)
        {
        }
    }
}

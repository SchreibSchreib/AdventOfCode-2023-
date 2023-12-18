using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16.AbstractClasses
{
    abstract class FieldSign
    {
        public bool IsPowered { get; private set; } = false;

        public Dictionary<string, string>? PossibleDirections;

        public FieldSign()
        {
            PossibleDirections = GetDirections();
        }

        public void PowerField()
        {
            IsPowered = true;
        }

        protected abstract Dictionary<string, string>? GetDirections();
    }
}

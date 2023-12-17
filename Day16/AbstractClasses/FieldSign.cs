using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16.AbstractClasses
{
    abstract class FieldSign
    {
        protected Dictionary<char, string>? _possibleDirections;
        public bool IsPowered { get; } = false;

        public FieldSign()
        {
            _possibleDirections = GetDirections();
        }

        protected abstract Dictionary<char, string>? GetDirections();
    }
}

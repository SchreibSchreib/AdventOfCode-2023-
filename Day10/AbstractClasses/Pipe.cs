using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day10.AbstractClasses
{
    internal abstract class Pipe
    {
        public Dictionary<string, char[]> PossibleMoves { get; }
        public bool WasVisited;
        public int[] NumberOnField { get; }

        public Pipe(int[] numberOnField)
        {
            PossibleMoves = GetPossibleMoves();
            NumberOnField = numberOnField;
        }

        private Dictionary<string, char[]> GetPossibleMoves()
        {
            Dictionary<string, char[]> directionToValidCounterParts = GetDirctionary();
            return directionToValidCounterParts;
        }

        protected char[] GetUp() => new char[] { '|', '7', 'F' };

        protected char[] GetDown() => new char[] { '|', 'L', 'J' };

        protected char[] GetRight() => new char[] { 'J', '7', '-' };

        protected char[] GetLeft() => new char[] { 'L', 'F', '-' };

        protected abstract Dictionary<string, char[]> GetDirctionary();
    }
}

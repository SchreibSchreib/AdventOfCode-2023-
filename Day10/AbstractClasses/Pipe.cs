using Day10.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day10.AbstractClasses
{
    internal abstract class Pipe : IMoveable
    {
        protected Dictionary<string, char[]> _possibleMoves;
        protected int _movesToReachField;

        public bool WasVisited;
        public int[] NumberOnField { get; }

        public Pipe(int[] numberOnField)
        {
            _possibleMoves = GetPossibleMoves();
            NumberOnField = numberOnField;
        }

        public Dictionary<string, char[]> GetPossibleMoves()
        {
            Dictionary<string, char[]> directionToValidCounterParts = GetDirctionary();
            return directionToValidCounterParts;
        }

        protected char[] GetUp() => new char[] { '|', '7', 'F' };

        protected char[] GetDown() => new char[] { '|', 'L', 'J' };

        protected char[] GetRight() => new char[] { 'J', '7', '-' };

        protected char[] GetLeft() => new char[] { 'L', 'F', '-' };

        protected abstract Dictionary<string, char[]> GetDirctionary();

        public int[] Move()
        {
            foreach (KeyValuePair<string, char[]> move in _possibleMoves)
            {
                if (move.Key == "up")
                {
                    return new int[] { NumberOnField[0] + 1, NumberOnField[1] };
                }
                if (move.Key == "right")
                {
                    return new int[] { NumberOnField[0], NumberOnField[1] + 1 };
                }
                if (move.Key == "down")
                {
                    return new int[] { NumberOnField[0] - 1, NumberOnField[1] };
                }
                if (move.Key == "left")
                {
                    return new int[] { NumberOnField[0], NumberOnField[1] - 1 };
                }
            }
            return NumberOnField;
        }
    }
}

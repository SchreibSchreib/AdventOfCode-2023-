using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10.Interfaces
{
    internal interface IMoveable
    {
        Dictionary<string, char[]> GetPossibleMoves();
        int[] Move();
    }
}

using Day23.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day23.Signs
{
    internal class WallTile : FieldSign
    {
        public WallTile(int yCoords, int xCoords) : base(yCoords, xCoords)
        {
        }

        protected override Dictionary<string, string> GetDirections()
        {
            return new Dictionary<string, string>
            {
                { ">", ">" },
                { "^", "^" },
                { "v", "v" },
                { "<", "<" }
            };
        }
    }
}

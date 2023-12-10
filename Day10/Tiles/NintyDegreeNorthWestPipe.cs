using Day10.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10.Tiles
{
    internal class NintyDegreeNorthWestPipe : Pipe
    {
        public NintyDegreeNorthWestPipe(int[] numberOnField) : base(numberOnField)
        {
        }

        protected override Dictionary<string, char[]> GetDirctionary()
        {
            return new Dictionary<string, char[]>
            {
                {
                    "up", GetUp()
                },
                {
                    "left", GetLeft()
                }
            };
        }
    }
}

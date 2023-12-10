using Day10.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10.Tiles
{
    internal class NintyDegreeSouthEastPipe : Pipe
    {
        public NintyDegreeSouthEastPipe(int[] numberOnField) : base(numberOnField)
        {
        }

        protected override Dictionary<string, char[]> GetDirctionary()
        {
            return new Dictionary<string, char[]>
            {
                {
                    "right", GetRight()
                },
                {
                    "down", GetDown()
                }
            };
        }
    }
}

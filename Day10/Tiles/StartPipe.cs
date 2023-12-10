using Day10.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10.Tiles
{
    internal class StartPipe : Pipe
    {
        private List<Pipe>? _gameField;

        public StartPipe(int[] numberOnField) : base(numberOnField)
        {
        }

        protected override Dictionary<string, char[]> GetDirctionary()
        {
            return ConvertPipe(NumberOnField);
        }

        private Dictionary<string, char[]> ConvertPipe(int[] numberOnField)
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

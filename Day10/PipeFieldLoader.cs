using Day10.AbstractClasses;
using Day10.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{

    internal class PipeFieldLoader
    {
        public List<Pipe> Get { get; }

        public PipeFieldLoader(string[] input)
        {
            Get = LoadField(input);
        }

        private List<Pipe> LoadField(string[] input)
        {
            List<Pipe> result = new List<Pipe>();

            for (int yIndex = 0; yIndex < input.Length; yIndex++)
            {
                for (int xIndex = 0; xIndex < input[yIndex].Length; xIndex++)
                {
                    int[] indexOnField = new int[] { yIndex, xIndex };
                    result.Add(GetTile(input[yIndex][xIndex], indexOnField));
                }
            }

            return result;
        }
        private Pipe GetTile(char v, int[] indexOnField)
        {
            switch(v)
            {
                case '|':
                    return new VerticalPipe(indexOnField);
                case '-':
                    return new HorizontalPipe(indexOnField);
                case 'L':
                    return new NintyDegreeNorthEastPipe(indexOnField);
                case 'J':
                    return new NintyDegreeNorthWestPipe(indexOnField);
                case '7':
                    return new NintyDegreeSouthWestPipe(indexOnField);
                case 'F':
                    return new NintyDegreeSouthEastPipe(indexOnField);
                case 'S':
                    return new StartPipe(indexOnField);
                default:
                    return new NoPipe(indexOnField);
            }
        }
    }
}

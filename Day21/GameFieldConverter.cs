using Day16.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day21
{

    internal class GameFieldConverter
    {
        public FieldSign[,] GetConverted { get; }

        public GameFieldConverter(char[,] gameFieldInChars)
        {
            GetConverted = ConvertToFieldSigns(gameFieldInChars);
        }

        private FieldSign[,] ConvertToFieldSigns(char[,] gameFieldInChars)
        {
            FieldSign[,] map = new FieldSign[gameFieldInChars.GetLength(0), gameFieldInChars.GetLength(1)];

            for (int yIndex = 0; yIndex < gameFieldInChars.GetLength(0); yIndex++)
            {
                for (int xIndex = 0; xIndex < gameFieldInChars.GetLength(1); xIndex++)
                {
                    if (gameFieldInChars[yIndex, xIndex] == 'S')
                    {
                        map[yIndex, xIndex] = new StartField(new int[,] { { yIndex, xIndex } });
                    }
                    else if (gameFieldInChars[yIndex, xIndex] != '#')
                    {
                        map[yIndex, xIndex] = new NonBlockingField(new int[,] { { yIndex, xIndex } });
                    }
                    else
                    {
                        map[yIndex, xIndex] = new BlockingField(new int[,] { { yIndex, xIndex } });
                    }
                }
            }

            return map;
        }
    }
}

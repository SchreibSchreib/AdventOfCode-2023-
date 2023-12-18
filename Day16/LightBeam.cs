using Day16.AbstractClasses;
using Day16.Signs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16
{
    internal class LightBeam
    {
        public int[] CurrentPosition { get; }
        public string Direction { get; set; } 
        public bool HittedWall = false;

        public LightBeam(int[] positionOfBeam, string direction)
        {
            CurrentPosition = positionOfBeam;
            Direction = direction;
        }

        internal void Move(FieldSign[,] gameField)
        {
            if (Direction == ">")
            {
                MoveRight(gameField);
                return;
            }
            if (Direction == "v")
            {
                MoveDown(gameField);
                return;
            }
            if (Direction == "<")
            {
                MoveLeft(gameField);
                return;
            }
            if (Direction == "^") 
            {
                MoveUp(gameField);
                return;
            }

        }

        private void MoveUp(FieldSign[,] gameField)
        {
            CurrentPosition[0] = CurrentPosition[0] - 1;
            Direction = GetNextDirection(gameField);
        }

        private void MoveLeft(FieldSign[,] gameField)
        {
            CurrentPosition[1] = CurrentPosition[1] - 1;
            Direction = GetNextDirection(gameField);
        }

        private void MoveDown(FieldSign[,] gameField)
        {
            CurrentPosition[0] = CurrentPosition[0] + 1;
            Direction = GetNextDirection(gameField);
        }

        private void MoveRight(FieldSign[,] gameField)
        {
            CurrentPosition[1] = CurrentPosition[1] + 1;
            Direction = GetNextDirection(gameField);
        }

        private string GetNextDirection(FieldSign[,] gameField)
        {
            try
            {
               gameField[CurrentPosition[0], CurrentPosition[1]].PowerField();
               return gameField[CurrentPosition[0], CurrentPosition[1]].PossibleDirections[Direction];
            }
            catch
            {
                HittedWall = true;
                return Direction;
            }
        }
    }
}

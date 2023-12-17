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
        public char Direction { get; } = '>'; 
        public bool HittedWall = false;

        public LightBeam(int[] positionOfBeam)
        {
            CurrentPosition = positionOfBeam;
        }

        internal void Move()
        {
            if (Direction == '>')
            {
                MoveRight();
                return;
            }
            if (Direction == 'v')
            {
                MoveDown();
                return;
            }
            if (Direction == '<')
            {
                MoveLeft();
                return;
            }
            if (Direction == '^') 
            {
                MoveUp();
                return;
            }

        }

        private void MoveUp()
        {
            CurrentPosition[0] = CurrentPosition[0] - 1;
        }

        private void MoveLeft()
        {
            CurrentPosition[1] = CurrentPosition[1] - 1;
        }

        private void MoveDown()
        {
            CurrentPosition[0] = CurrentPosition[0] + 1;
        }

        private void MoveRight()
        {
            CurrentPosition[1] = CurrentPosition[1] + 1;
        }
    }
}

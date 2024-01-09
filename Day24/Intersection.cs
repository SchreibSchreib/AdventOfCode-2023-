using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day24
{
    internal class Intersection
    {
        public decimal GetX { get; private set; }
        public decimal GetY { get; private set; }

        public Intersection(HailStone firstHailStone, HailStone secondHailstone)
        {
            GetIntersection2D(firstHailStone, secondHailstone);
        }

        private void GetIntersection2D(HailStone firstHailStone, HailStone secondHailStone)
        {
            decimal increaseFirstTrajectory = firstHailStone.Trajectory.Increase;
            decimal axisSectionFirstTrajectory = firstHailStone.Trajectory.AxisSection;
            decimal increaseSecondTrajectory = secondHailStone.Trajectory.Increase;
            decimal axisSectionSecondtTrajectory = secondHailStone.Trajectory.AxisSection;

            if (increaseFirstTrajectory != increaseSecondTrajectory)
            {
                GetX = (axisSectionSecondtTrajectory - axisSectionFirstTrajectory) / (increaseFirstTrajectory - increaseSecondTrajectory);
                GetY = firstHailStone.Trajectory.CalculateTrajectory(GetX);
            }
            else
            {
                GetX = 0;
                GetY = 0;
            }
        }
    }
}

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
        public bool CrossedInPast { get; }
        public bool IsInsideArea { get; }

        public Intersection(HailStone firstHailStone, HailStone secondHailStone)
        {
            GetIntersection2D(firstHailStone, secondHailStone);
            IsInsideArea = IsInsideOfArea();
            CrossedInPast = DidIntersectionHappenInPast(firstHailStone, secondHailStone);
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
                return;
            }
        }

        private bool DidIntersectionHappenInPast(HailStone firstHailStone, HailStone secondHailStone)
        {
            var directionXFirstStone = GetDircetion(firstHailStone);
            var directionXSecondStone = GetDircetion(secondHailStone);
            bool pastXFirst = false;
            bool pastYFirst = false;

            if (directionXFirstStone == "positive")
                pastXFirst = GetX < firstHailStone.StartPosition.Get2D[0];
            if (directionXFirstStone == "negative")
                pastXFirst = GetX > firstHailStone.StartPosition.Get2D[0];
            if (directionXSecondStone == "positive")
                pastYFirst = GetX < secondHailStone.StartPosition.Get2D[0];
            if (directionXSecondStone == "negative")
                pastYFirst = GetX > secondHailStone.StartPosition.Get2D[0];

            return pastXFirst || pastYFirst;
        }

        private string GetDircetion(HailStone currentStone)
        {
            if (currentStone.StartPosition.Get2D[0] > currentStone.PositionAfterTick.Get2D[0])
                return "negative";

            return "positive";
        }

        private bool IsInsideOfArea()
        {
            decimal x = GetX;
            decimal y = GetY;

            return (x >= 200000000000000 && x <= 400000000000000) && (y >= 200000000000000 && y <= 400000000000000);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day24
{
    internal class Intersection
    {
        public decimal[] Get { get; }

        public Intersection(HailStone firstHailStone, HailStone secondHailstone)
        {
            Get = GetIntersection2D(firstHailStone, secondHailstone);
        }

        private decimal GetIntersection2D(HailStone firstHailStone, HailStone secondHailstone)
        {
            Trajectory firstTrajectory = firstHailStone.Trajectory;
            Trajectory secondTrajectory = secondHailstone.Trajectory;
        }
    }
}

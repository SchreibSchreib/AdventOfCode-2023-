

namespace Day24
{
    public class HailStone
    {
        public Trajectory Trajectory { get; }
        public Position StartPosition { get; }
        public Position PositionAfterTick { get; }


        public HailStone(long startX, long startY, long startZ, int tickX, int tickY, int tickZ)
        {
            StartPosition = new Position(startX, startY, startZ);
            PositionAfterTick = new Position(startX + tickX, startY + tickY, startZ + tickZ);
            Trajectory = GetTrajectory();
        }

        private Trajectory GetTrajectory()
        {
            decimal increase = GetIncrease();
            decimal axisSection = GetAxisSection(increase);
            return new Trajectory(increase, axisSection);
        }

        private decimal GetAxisSection(decimal increase) => StartPosition.Get2D[1] - (increase * StartPosition.Get2D[0]);

        private decimal GetIncrease()
        {
            return (PositionAfterTick.Get2D[1] - StartPosition.Get2D[1]) / (PositionAfterTick.Get2D[0] - StartPosition.Get2D[0]);
        }
    }
}
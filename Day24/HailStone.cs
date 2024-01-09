

namespace Day24
{
    public class HailStone
    {
        public Trajectory Trajectory { get; }

        private Position _startPosition;
        private Position _positionAfterTick;


        public HailStone(long startX, long startY, long startZ, int tickX, int tickY, int tickZ)
        {
            _startPosition = new Position(startX, startY, startZ);
            _positionAfterTick = new Position(startX + tickX, startY + tickY, startZ + tickZ);
            Trajectory = GetTrajectory();
        }

        private Trajectory GetTrajectory()
        {
            decimal increase = GetIncrease();
            decimal axisSection = GetAxisSection(increase);
            return new Trajectory(increase, axisSection);
        }

        private decimal GetAxisSection(decimal increase) => _startPosition.Get2D[1] - (increase * _startPosition.Get2D[0]);

        private decimal GetIncrease()
        {
            return (_positionAfterTick.Get2D[1] - _startPosition.Get2D[1]) / (_positionAfterTick.Get2D[0] - _startPosition.Get2D[0]);
        }
    }
}
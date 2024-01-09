namespace Day24
{
    public class Trajectory
    {
        public Decimal Increase { get; }
        public Decimal AxisSection { get; }

        private readonly Func<decimal, decimal> _lineEquatation;

        public Trajectory(decimal increase, decimal axisSection)
        {
            Increase = increase;
            AxisSection = axisSection;
            _lineEquatation = x => Increase * x + AxisSection;
        }

        public decimal CalculateTrajectory(decimal y)
        {
            return _lineEquatation(y);
        }
    }
}
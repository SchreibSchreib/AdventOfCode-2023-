namespace Day24
{
    public class Trajectory
    {
        private readonly Func<decimal, decimal> _lineEquatation;

        public Trajectory(decimal increase, decimal axisSection)
        {
            _lineEquatation = x => increase * x + axisSection;
        }

        public decimal CalculateTrajectory(decimal x)
        {
            return _lineEquatation(x);
        }
    }
}
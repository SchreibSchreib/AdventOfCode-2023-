namespace Day24
{
    public class Position
    {
        public decimal[] Get2D { get; }
        public decimal[] Get3D { get; }

        public Position(long xCoords, long yCoords, long zCoords)
        {
            Get2D = Get2DPosition(xCoords, yCoords);
            Get3D = Get3DPosition(xCoords, yCoords, zCoords);
        }

        private decimal[] Get3DPosition(long xCoords, long yCoords, long zCoords) => new decimal[] { xCoords, yCoords, zCoords };

        private decimal[] Get2DPosition(long xCoords, long yCoords) => new decimal[] { xCoords, yCoords };
    }
}
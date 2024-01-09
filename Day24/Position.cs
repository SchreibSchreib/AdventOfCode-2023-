namespace Day24
{
    internal class Position
    {
        public long[] Get2D { get; }
        public long[] Get3D { get; }

        public Position(long xCoords, long yCoords, long zCoords)
        {
            Get2D = Get2DPosition(xCoords, yCoords);
            Get3D = Get3DPosition(xCoords, yCoords, zCoords);
        }

        private long[] Get3DPosition(long xCoords, long yCoords, long zCoords) => new long[] { xCoords, yCoords, zCoords };

        private long[] Get2DPosition(long xCoords, long yCoords) => new long[] { xCoords, yCoords };
    }
}
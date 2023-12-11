using System.Runtime.CompilerServices;

internal class CoordinateGenerator
{
    private string[] _input;

    public Dictionary<int, int[]> Get { get; }

    public CoordinateGenerator(string[] input)
    {
        _input = new GalaxyExpander(input).Get;
        Get = GetCoordinatesOfGalaxies();
    }

    private Dictionary<int, int[]> GetCoordinatesOfGalaxies()
    {
        Dictionary<int, int[]> result = new Dictionary<int, int[]>();
        int galaxiesFound = 1;

        for (int yIndex = 0; yIndex < _input.Length; yIndex++)
        {
            for (int xIndex = 0; xIndex < _input[yIndex].Length; xIndex++)
            {
                if (_input[yIndex][xIndex] == '#')
                {
                    result.Add(galaxiesFound++, new int[] { yIndex, xIndex });
                }
            }
        }
        return result;
    }
}
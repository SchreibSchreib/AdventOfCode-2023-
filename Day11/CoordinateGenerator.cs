using System.Runtime.CompilerServices;

internal class CoordinateGenerator
{
    private string[] _input;
    private GalaxyExpander _expander;

    public Dictionary<int, int[]> Get { get; }

    public CoordinateGenerator(string[] input)
    {
        _expander = new GalaxyExpander(input);
        _input = _expander.Get;
        Get = GetCoordinatesOfGalaxies();
    }

    //Part 1

    //private Dictionary<int, int[]> GetCoordinatesOfGalaxies()
    //{
    //    Dictionary<int, int[]> result = new Dictionary<int, int[]>();
    //    int galaxiesFound = 1;

    //    for (int yIndex = 0; yIndex < _input.Length; yIndex++)
    //    {
    //        for (int xIndex = 0; xIndex < _input[yIndex].Length; xIndex++)
    //        {
    //            if (_input[yIndex][xIndex] == '#')
    //            {
    //                result.Add(galaxiesFound++, new int[] { yIndex, xIndex });
    //            }
    //        }
    //    }
    //}

    //Part 2

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
                    int expandLineY = yIndex;
                    int expandLineX = xIndex;

                    foreach (int y in _expander.indexExpansionsY)
                    {
                        if (yIndex > y)
                        {
                            expandLineY += 999998;
                        }
                    }
                    foreach (int x in _expander.indexExpansionsX)
                    {
                        if (xIndex > x)
                        {
                            expandLineX += 999998;
                        }
                    }
                    result.Add(galaxiesFound++, new int[] { expandLineY, expandLineX });
                }
            }
        }
        return result;
    }
}
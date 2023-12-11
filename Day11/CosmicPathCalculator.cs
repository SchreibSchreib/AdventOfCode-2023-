internal class CosmicPathCalculator
{
    private Dictionary<int, int[]> _cosmicCoordinates;

    public long Result { get; }

    public CosmicPathCalculator(Dictionary<int, int[]> cosmicCoordinates)
    {
        _cosmicCoordinates = cosmicCoordinates;
        Result = Calculate();
    }

    private long Calculate()
    {
        List<int> singlePaths = GetNumberOfPaths();
        long result = 0;

        foreach (int path in singlePaths)
        {
            result += path;
        }
        return result;
    }

    private List<int> GetNumberOfPaths()
    {
        Dictionary<string, int> possibleRoutes = new Dictionary<string, int>();

        foreach (KeyValuePair<int, int[]> positionOfGalaxies in _cosmicCoordinates)
        {
            for (int coordinatesForGalaxy = 1; coordinatesForGalaxy <= _cosmicCoordinates.Count; coordinatesForGalaxy++)
            {
                if (positionOfGalaxies.Value != _cosmicCoordinates[coordinatesForGalaxy])
                {
                    string keyToAdd = (positionOfGalaxies.Key < _cosmicCoordinates.ElementAt(coordinatesForGalaxy - 1).Key) ?
                        $"{positionOfGalaxies.Key} {_cosmicCoordinates.ElementAt(coordinatesForGalaxy - 1).Key}" :
                        $"{_cosmicCoordinates.ElementAt(coordinatesForGalaxy - 1).Key} {positionOfGalaxies.Key}";

                    if (!possibleRoutes.ContainsKey(keyToAdd))
                    {
                        int numberOfSteps = CalculateSteps(positionOfGalaxies.Value, _cosmicCoordinates[coordinatesForGalaxy]);
                        possibleRoutes.Add(keyToAdd, numberOfSteps);
                    }
                }
            }
        }
        return GetAllSteps(possibleRoutes);
    }

    private List<int> GetAllSteps(Dictionary<string, int> possibleRoutes)
    {
        List<int> allSteps = new List<int>();

        foreach (KeyValuePair<string, int> allRoutes in possibleRoutes)
        {
            allSteps.Add(allRoutes.Value);
        }

        return allSteps;
    }

    private int CalculateSteps(int[] fromGalaxy, int[] toGalaxy)
    {
        int stepsY = (fromGalaxy[0] > toGalaxy[0]) ?
            fromGalaxy[0] - toGalaxy[0] :
            toGalaxy[0] - fromGalaxy[0];

        int stepsX = (fromGalaxy[1] > toGalaxy[1]) ?
            fromGalaxy[1] - toGalaxy[1] :
            toGalaxy[1] - fromGalaxy[1];

        return stepsY + stepsX;
    }
}
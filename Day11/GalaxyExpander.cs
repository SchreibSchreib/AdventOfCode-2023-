﻿internal class GalaxyExpander
{
    public string[] Get { get; }
    public List<int> indexExpansionsX { get; private set; } = new List<int>();
    public List<int> indexExpansionsY { get; private set; } = new List<int>();

    public GalaxyExpander(string[] input)
    {
        Get = ExpandGalaxy(input);
    }

    private string[] ExpandGalaxy(string[] input)
    {
        List<string> inputAsList = input.ToList();
        List<string> result = ExpandYCoordinates(inputAsList);
        result = ExpandXCoordinates(result);

        return result.ToArray();
    }

    private List<string> ExpandYCoordinates(List<string> inputAsList)
    {
        List<string> result = new List<string>();
        List<int> positionForExpansion = new List<int>();
        int insertionCount = 0;
        for (int yIndex = 0; yIndex < inputAsList.Count; yIndex++)
        {
            result.Add(inputAsList[yIndex]);
            if (!inputAsList[yIndex].Contains("#"))
            {
                indexExpansionsY.Add(yIndex + insertionCount++);
                result.Add(inputAsList[yIndex]);
            }
        }
        //List<string> result = new List<string>();
        //foreach (string inputLine in inputAsList)
        //{
        //    result.Add(inputLine);
        //    if (!inputLine.Contains("#"))
        //    {
        //        result.Add(inputLine);
        //    }
        //}
        return result;
    }

    private List<string> ExpandXCoordinates(List<string> inputAsList)
    {
        List<string> result = inputAsList;
        List<int> positionForExpansion = new List<int>();

        for (int xIndex = 0; xIndex < inputAsList[0].Length; xIndex++)
        {
            if (inputAsList[0][xIndex] == '.' && IsYWithoutGalaxy(inputAsList, xIndex))
            {
                positionForExpansion.Add(xIndex);
            }
        }

        int insertionCount = 0;

        foreach (int xIndex in positionForExpansion)
        {
            for (int yIndex = 0; yIndex < inputAsList.Count; yIndex++)
            {
                result[yIndex] = (result[yIndex].Insert(xIndex + insertionCount, "."));
            }
            indexExpansionsX.Add(xIndex + insertionCount++);
        }
        return result;
    }

    private bool IsYWithoutGalaxy(List<string> inputAsList, int xIndex)
    {
        foreach (string inputLine in inputAsList)
        {
            if (inputLine[xIndex] == '#')
            {
                return false;
            }
        }
        return true;
    }
}
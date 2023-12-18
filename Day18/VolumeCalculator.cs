using System.Text;

internal class VolumeCalculator
{
    public int Get { get; }

    private List<Tuple<string, int>> _directionAndRange;

    public VolumeCalculator(List<Tuple<string, int>> directionAndRange)
    {
        _directionAndRange = directionAndRange;
        Get = CalculateArea(_directionAndRange);
    }

    private int CalculateArea(List<Tuple<string, int>> directionAndRange)
    {
        List<int[]> cornerPoints = GetCornerPoints(directionAndRange);
        int result = ShoelaceAlgorithm(cornerPoints);
        result = AddPerimeterToHalfShoelaceResult(result, directionAndRange);
        return result;
    }

    private int AddPerimeterToHalfShoelaceResult(int result, List<Tuple<string, int>> directionAndRange)
    {
        directionAndRange = directionAndRange.OrderBy(x => x.Item1).ToList();
        int scope = GetPerimeter(directionAndRange) / 2;

        return result + scope;
    }

    private int GetPerimeter(List<Tuple<string, int>> directionAndRange)
    {
        int h = 0;
        int b = 0;

        foreach (Tuple<string, int> point in directionAndRange)
        {
            if (point.Item1 == "R") b += point.Item2;
            if (point.Item1 == "D") h += point.Item2;
        }

        return 2 * h + 2 * b;
    }

    private int ShoelaceAlgorithm(List<int[]> cornerPoints)
    {
        int area = 0;

        for (int indexList = 0; indexList < cornerPoints.Count - 1; indexList++)
        {
            area += cornerPoints[indexList][0] * cornerPoints[indexList + 1][1];
            area -= cornerPoints[indexList][1] * cornerPoints[indexList + 1][0];
        }

        area += cornerPoints.Last()[0] * cornerPoints.First()[1];
        area -= cornerPoints.Last()[1] * cornerPoints.First()[0];

        return Math.Abs(area) / 2 + 1;
    }

    private List<int[]> GetCornerPoints(List<Tuple<string, int>> directionAndRange)
    {
        List<int[]> shape = new List<int[]>();
        int x = 0;
        int y = 0;

        foreach (Tuple<string, int> pair in directionAndRange)
        {
            if (pair.Item1 == "U")
            {
                y -= pair.Item2;
                shape.Add(new int[] { y, x });
            }
            if (pair.Item1 == "D")
            {
                y += pair.Item2;
                shape.Add(new int[] { y, x });
            }
            if (pair.Item1 == "L")
            {
                x -= pair.Item2;
                shape.Add(new int[] { y, x });
            }
            if (pair.Item1 == "R")
            {
                x += pair.Item2;
                shape.Add(new int[] { y, x });
            }
        }

        return shape;
    }
}
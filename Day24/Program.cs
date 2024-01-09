using Day24;

var input = new Content().Get;

foreach (var hailStone in input)
{
    foreach(var hailStoneForMath in input)
    {
        if (hailStoneForMath ==  hailStone)
        continue;

        var testResult = new Intersection(hailStone, hailStoneForMath);
        Console.WriteLine($"X: {testResult.GetX} Y: {testResult.GetY}");
    }
}
Console.ReadLine();
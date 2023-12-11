using Day11;

string[] input = new Content().Get;

Dictionary<int,int[]> cosmicCoordinates = new CoordinateGenerator(input).Get;

long result = new CosmicPathCalculator(cosmicCoordinates).Result;

Console.ReadLine();
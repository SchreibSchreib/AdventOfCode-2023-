using Day14;

List<string[]> input = new Content().Get;

foreach (var item in input)
{
    int result = new RockCalculator(new StringArrayRotator(item).Get).Get;
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Result: {result}");
}

Console.ReadLine();
using Day5;

string[] input = new Content().Get;
Dictionary<string, string[]> loadStrings = new inputDictionary(new Content().Get).Get;

string seedNumbers = loadStrings["seeds: "][0];
string actualNumbers = seedNumbers;
loadStrings.Remove("seeds: ");

foreach (KeyValuePair<string, string[]> entry in loadStrings)
{
    Console.WriteLine($"Numbers found: {actualNumbers}");
    Converter convertNumbers = new Converter(actualNumbers, entry.Value);
    actualNumbers = convertNumbers.Get;
    Console.WriteLine($"Numbers converted to: {actualNumbers}");
    Console.WriteLine();
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"Smallest number: {actualNumbers.Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(x => long.Parse(x)).Min()}");


Console.ReadLine();

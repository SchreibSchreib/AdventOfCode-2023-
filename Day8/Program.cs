using Day8;

string[] input = new Content().Get;
string leftOrRight = input[0];
Dictionary<string, string> network = new DictionaryDirections(input).Get;

Iterator iterator = new Iterator(network, leftOrRight);

int result = iterator.Iterations;

Console.WriteLine();
Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"Total navigations: {result}");

Console.ReadLine();
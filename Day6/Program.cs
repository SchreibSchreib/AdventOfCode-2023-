using Day6;

string[] input = new Content().Get;
Dictionary<int, int> resultDictionary = new InputDictionaryCreator(input).Get;
List<int> possibleWins = new List<int>();

int result = new RaceCalculator(resultDictionary).Result;

Console.WriteLine(result);
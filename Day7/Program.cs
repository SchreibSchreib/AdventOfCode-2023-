using Day7;

Dictionary<string, int> handAndPointPair = new InputDictionaryCreator(new Content().Get).Get;
HandCardTypeEvaluator evaluateGame = new HandCardTypeEvaluator(handAndPointPair);

Dictionary<string, List<string>> typeOfHandsAndOccurences = evaluateGame.GetTypeOfHandsAndOccurences;

TypeStrengthEvaluator completeSortedHandWithMultiplicator = new TypeStrengthEvaluator(typeOfHandsAndOccurences);

int result = 0;

foreach (KeyValuePair<string, int> entry in completeSortedHandWithMultiplicator.GetHandCardsWithMultiplicator)
{
    result += handAndPointPair[entry.Key] * entry.Value;
    Console.WriteLine($"Evaluating result: {result}");
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine();
Console.WriteLine(result);

Console.ReadLine();
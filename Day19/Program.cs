using Day19;

var input = new Content().Get;

var allWorkflowsWithPredicates = new WorkflowDictionaryCreator(input[0]).WorkFlowToPredicates;
var RankingOfParts = new AcceptedParts(input[1]).Get;
string keyToFind = "in";
int result = 0;

foreach (var part in RankingOfParts)
{
    result += new PredicateEvaluator(keyToFind, part, allWorkflowsWithPredicates).Result;
    Console.WriteLine(result);
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine();
Console.WriteLine();
Console.WriteLine($"Total result: {result}");

Console.ReadLine();
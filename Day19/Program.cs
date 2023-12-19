using Day19;

var input = new Content().Get;

var test = new WorkflowDictionaryCreator(input[0]).WorkFlowToPredicates;
var RankingOfParts = new AcceptedParts(input[1]).Get;
string keyToFind = "in";

foreach (var part in RankingOfParts)
{
    
}

Console.WriteLine();
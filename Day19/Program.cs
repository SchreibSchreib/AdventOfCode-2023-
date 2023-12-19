using Day19;

var input = new Content().Get;

var test = new WorkflowDictionaryCreator(input[0]).WorkFlowToPredicates;
var tes2 = new AcceptedParts(input[1]).Get;

Console.WriteLine();
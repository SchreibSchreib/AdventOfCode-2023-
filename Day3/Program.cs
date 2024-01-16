using Day3;

var input = new Content();
var indicesOfSymbols = new NumberIndexer(input.Get);
var listOfAvailableNumbers = new BroadSearch(indicesOfSymbols);



Console.WriteLine();

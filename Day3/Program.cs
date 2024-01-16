using Day3;

var input = new Content();
var indicesOfSymbols = new NumberIndexer(input.Get);
var sumOfAvailableNumbers = new BroadSearch(input.Get, indicesOfSymbols).NumbersForSum;

var result = sumOfAvailableNumbers.Sum(x => x);

Console.WriteLine();

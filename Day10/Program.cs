using Day10;
using Day10.AbstractClasses;
using Day10.Tiles;

string[] input = new Content().Get;
List<Pipe> pipeField = new PipeFieldLoader(input).Get;

foreach (Pipe tile in pipeField)
{
    if (tile.GetType() == typeof(StartPipe))
    {
        int numberOfMoves = new SearchAlgorithm(tile, pipeField).GetMoves;
    }
}

Console.ReadLine();
using Day10;
using Day10.AbstractClasses;
using Day10.Tiles;

string[] input = new Content().Get;
List<Pipe> pipeField = new PipeFieldLoader(input).Get;
int movesA = 0;
int movesB = 0;

foreach (Pipe tile in pipeField)
{
    if (tile.GetType() == typeof(StartPipe))
    {
        movesA = new SearchAlgorithm(tile, pipeField).Way;
        movesB = new SearchAlgorithm(tile, pipeField).Way;
    }
}

Console.ReadLine();
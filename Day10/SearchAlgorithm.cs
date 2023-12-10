using Day10.AbstractClasses;
using Day10.Tiles;

internal class SearchAlgorithm
{
    private Pipe _startPipe;
    private Pipe _pipeRouteA;
    private Pipe _pipeRouteB;
    private List<Pipe> _pipeField;

    public int GetMoves { get; }

    public SearchAlgorithm(Pipe startPipe, List<Pipe> pipeField)
    {
        _startPipe = startPipe;
        _startPipe.WasVisited = true;
        _pipeRouteA = new StartPipe(startPipe.NumberOnField);
        _pipeRouteB = new StartPipe(startPipe.NumberOnField);
        _pipeField = pipeField;
        GetMoves = SearchEnd();
    }

    private int SearchEnd()
    {
        int moves = 0;
        List<Pipe> RouteA = GetReacheableNeighbours(_pipeRouteA);
        List<Pipe> RouteB = GetReacheableNeighbours(_pipeRouteB);

        while (!IsEndReached(RouteA))
        {
            moves++;
            RouteA = MakeMove(ref _pipeRouteA, RouteA);
            RouteB = MakeMove(ref _pipeRouteB, RouteB);
        }
        return moves;
    }

    private List<Pipe> MakeMove(ref Pipe pipeRoute, List<Pipe> neighbours)
    {
        foreach (Pipe pipe in neighbours)
        {
            if (pipe.WasVisited == true)
            {
                continue;
            }
            pipeRoute.WasVisited = true;
            pipeRoute = pipe;
            pipeRoute.WasVisited = true;
            break;
        }
        return GetReacheableNeighbours(pipeRoute);
    }

    private List<Pipe> GetReacheableNeighbours(Pipe pipe)
    {
        List<Pipe> neighbours = new List<Pipe>();

        foreach (KeyValuePair<string, char[]> test in pipe.PossibleMoves)
        {
            if (test.Key == "left")
            {
                int[] index = new int[] { pipe.NumberOnField[0], pipe.NumberOnField[1] - 1 };
                neighbours.Add(_pipeField.First(x => x.NumberOnField.SequenceEqual(index)));
            }
            if (test.Key == "up")
            {
                int[] index = new int[] { pipe.NumberOnField[0] - 1, pipe.NumberOnField[1] };
                neighbours.Add(_pipeField.First(x => x.NumberOnField.SequenceEqual(index)));
            }
            if (test.Key == "right")
            {
                int[] index = new int[] { pipe.NumberOnField[0], pipe.NumberOnField[1] + 1 };
                neighbours.Add(_pipeField.First(x => x.NumberOnField.SequenceEqual(index)));
            }
            if (test.Key == "down")
            {
                int[] index = new int[] { pipe.NumberOnField[0] + 1, pipe.NumberOnField[1] };
                neighbours.Add(_pipeField.First(x => x.NumberOnField.SequenceEqual(index)));
            }
        }
        return neighbours;
    }

    private bool IsEndReached(List<Pipe> neighbourPipes) => neighbourPipes.All(x => x.WasVisited == true);
}
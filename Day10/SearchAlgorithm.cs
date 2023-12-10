using Day10.AbstractClasses;

internal class SearchAlgorithm
{
    private Pipe _startPipe;
    private List<Pipe> _pipeField;

    public int Way { get; }

    public SearchAlgorithm(Pipe tileOnField, List<Pipe> pipeField)
    {
        _startPipe = tileOnField;
        _pipeField = pipeField;
        Way = SearchEnd();
    }

    private int SearchEnd()
    {
        int moves = 0;

        while (!IsEndReached())
        {
            moves++;
            foreach (Pipe pipe in _pipeField)
            {
                if (pipe.NumberOnField.SequenceEqual(_startPipe.Move()))
                {
                    _startPipe = pipe;
                    break;
                }
            }
        }
        return moves;
    }

    private bool IsEndReached() => _startPipe != _pipeField.Select(x => x.NumberOnField == x.Move());
}
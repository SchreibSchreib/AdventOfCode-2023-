using Day16.AbstractClasses;
using Day21;

internal class BroadSearch
{
    public List<FieldSign> UpdatedList { get; }

    private FieldSign[,] _gameField;
    private List<FieldSign> _fieldsToCheck;

    public BroadSearch(List<FieldSign> fieldsToCheck, FieldSign[,] gameField)
    {
        _fieldsToCheck = fieldsToCheck;
        _gameField = gameField;
        UpdatedList = GetUpdatedList(_fieldsToCheck);
    }

    private List<FieldSign> GetUpdatedList(List<FieldSign> fieldsToCheck)
    {
        var result = new List<FieldSign>();

        foreach (var field in fieldsToCheck)
        {
            var neighboursOfEntry = GetNeighbours(field);
            foreach (var entry in neighboursOfEntry)
            {
                if (!result.Any(item => ReferenceEquals(item, entry)))
                {
                    result.Add(entry);
                }
            }
        }

        return result;
    }

    private List<FieldSign> GetNeighbours(FieldSign field)
    {
        var result = new List<FieldSign>();
        int row = field.Position[0, 0];
        int col = field.Position[0, 1];

        if (row > 0)
        {
            if (_gameField[row - 1, col].GetType() != typeof(BlockingField))
            {
                result.Add(_gameField[row - 1, col]);
            }
        }
        if (row < _gameField.GetLength(0) - 1)
        {
            if (_gameField[row + 1, col].GetType() != typeof(BlockingField))
            {
                result.Add(_gameField[row + 1, col]);
            }
        }
        if (col > 0)
        {
            if (_gameField[row, col - 1].GetType() != typeof(BlockingField))
            {
                result.Add(_gameField[row, col - 1]);
            }
        }
        if (col < _gameField.GetLength(1) - 1)
        {
            if (_gameField[row, col + 1].GetType() != typeof(BlockingField))
            {
                result.Add(_gameField[row, col + 1]);
            }
        }

        return result;
    }
}
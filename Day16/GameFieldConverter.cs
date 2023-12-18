using Day16.AbstractClasses;
using Day16.Signs;

internal class GameFieldConverter
{
    public FieldSign[,] Get { get; }

    private char[,] _gameFieldChars;


    public GameFieldConverter(char[,] gameFieldChars)
    {
        _gameFieldChars = gameFieldChars;
        Get = ConvertField(gameFieldChars);
    }

    private FieldSign[,] ConvertField(char[,] gameFieldChars)
    {
        int rows = gameFieldChars.GetLength(0);
        int cols = gameFieldChars.GetLength(1);

        FieldSign[,] convertedField = new FieldSign[rows, cols];

        for (int rowIndex = 0; rowIndex < rows; rowIndex++)
        {
            for (int colIndex = 0; colIndex < cols; colIndex++)
            {
                char currentChar = gameFieldChars[rowIndex, colIndex];
                convertedField[rowIndex, colIndex] = ConvertCharToFieldSign(currentChar);
            }
        }
        return convertedField;
    }

    private FieldSign ConvertCharToFieldSign(char currentChar)
    {
        switch (currentChar)
        {
            case '\\':
                return new MirrorDownLeftOrUpRight();
            case '/':
                return new MirrorLeftUpOrDownRight();
            case '-':
                return new SplitterLeftRight();
            case '|':
                return new SplitterUpDown();
            default:
                return new EmptySpace();
        }
    }
}
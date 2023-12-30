using Day23.AbstractClasses;
using Day23.Signs;

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
                convertedField[rowIndex, colIndex] = ConvertCharToFieldSign(currentChar, rowIndex, colIndex);
            }
        }
        return convertedField;
    }

    private FieldSign ConvertCharToFieldSign(char currentChar, int row, int col)
    {
        switch (currentChar)
        {
            case '>':
                return new MirrorDownLeftOrUpRight(row,col);
            case 'v':
                return new MirrorLeftUpOrDownRight(row, col);
            case '^':
                return new SplitterLeftRight(row, col);
            case '<':
                return new SplitterUpDown(row, col);
            case '.':
                return new EmptySpace(row, col);
            default:
                return new WallTile(row, col);
        }
    }
}
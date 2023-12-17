using Day16.AbstractClasses;

internal class GameFieldConverter
{
    public FieldSign[,] Get { get; }

    private char[,] _gameFieldChars;


    public GameFieldConverter(char[,] gameFieldChars)
    {
        _gameFieldChars = gameFieldChars;
        Get = ConvertField(gameFieldChars);
    }

    private FieldSign[] ConvertField(char[,] gameFieldChars)
    {
        FieldSign[,] convertedField;
        for(int yIndex = )
    }
}
using Day23;
using Day23.AbstractClasses;
using Day23.Signs;

internal class RouteCalculator
{
    public int Get { get; }

    private List<Person> _routesList;
    private FieldSign[,] _gameField;


    public RouteCalculator(Person startPosition, FieldSign[,] gameField)
    {
        _routesList = new List<Person>
        {
            startPosition
        };
        _gameField = gameField;
        Get = EvaluateSteps(_routesList, _gameField);
    }

    private int EvaluateSteps(List<Person> possibleRoutesList, FieldSign[,] gameField)
    {
        for (int listNumber = 0; listNumber < possibleRoutesList.Count; listNumber++)
        {
            var possibleRoute = possibleRoutesList[listNumber];
            while (!possibleRoute.CrossedWorseWay)
            {
                FieldSign[] possibleMoves = GetNextFields(possibleRoute.CurrentPosition, gameField);

                if (possibleMoves.Length < 1)
                {
                    possibleRoute.CalculateMaxSteps(possibleRoute.CurrentWalkedSteps);
                    possibleRoute.EndReached();
                    break;
                }

                for (int possibleMove = 1; possibleMove != possibleMoves.Length; possibleMove++)
                {
                    AddRoute(possibleRoute);
                }

                possibleMoves[0].Symbol = "O";
                possibleRoute.Move(possibleMoves[0]);
            }
        }

        return possibleRoutesList.Max(x => x.CurrentWalkedSteps);
    }

    private FieldSign[] GetNextFields(int[,] currentPosition, FieldSign[,] gameField)
    {
        int y = currentPosition[0, 0];
        int x = currentPosition[0, 1];

        List<FieldSign> nextFields = new List<FieldSign>();

        if (x - 1 >= 0 && IsAccessible(y, x, gameField[y, x - 1]))
            nextFields.Add(gameField[y, x - 1]);

        if (x + 1 < gameField.GetLength(1) && IsAccessible(y, x, gameField[y, x + 1]))
            nextFields.Add(gameField[y, x + 1]);

        if (y - 1 >= 0 && IsAccessible(y, x, gameField[y - 1, x]))
            nextFields.Add(gameField[y - 1, x]);

        if (y + 1 < gameField.GetLength(0) && IsAccessible(y, x, gameField[y + 1, x]))
            nextFields.Add(gameField[y + 1, x]);

        return nextFields.ToArray();
    }

    private bool IsAccessible(int y, int x, FieldSign signToStepOn)
    {
        if (signToStepOn.GetType() == typeof(WallTile))
            return false;

        if (signToStepOn.IsStepped)
            return false;

        if (signToStepOn.GetType() == typeof(EmptySpace))
            return true;


        int yOfTile = signToStepOn.Coordinates[0, 0];
        int xOfTile = signToStepOn.Coordinates[0, 1];

        return yOfTile - signToStepOn.DirectionY != y || xOfTile + signToStepOn.DirectionX != x;
    }

    public void AddRoute(Person currentRoute)
    {
        _routesList.Add(new Person(currentRoute.CurrentPosition, currentRoute.CurrentWalkedSteps));
    }
}
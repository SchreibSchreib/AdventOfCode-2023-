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
            while (!possibleRoute.CrossedOtherWay)
            {
                FieldSign[] possibleMoves = GetNextFields(possibleRoute, gameField);

                if (possibleMoves.Length < 1)
                {
                    possibleRoute.CalculateMaxSteps(possibleRoute.CurrentWalkedSteps);
                    possibleRoute.EndReached();
                    break;
                }

                for (int possibleMove = 1; possibleMove != possibleMoves.Length; possibleMove++)
                {
                    FieldSign nextSign = possibleMoves[possibleMove];
                    AddRoute(nextSign, possibleRoute.CurrentWalkedSteps + 1);
                }

                possibleMoves[0].Symbol = "O";
                possibleRoute.Move(possibleMoves[0]);
            }
        }

        return possibleRoutesList.Max(x => x.CurrentWalkedSteps);
    }

    private FieldSign[] GetNextFields(Person currentPerson, FieldSign[,] gameField)
    {
        int y = currentPerson.CurrentPosition[0, 0];
        int x = currentPerson.CurrentPosition[0, 1];

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

        if (signToStepOn.IsStepped && !signToStepOn.PersonWhoSteppedOnThisField.ReachedEnd)
            return false;

        if (signToStepOn.GetType() == typeof(EmptySpace))
            return true;

        int yOfTile = signToStepOn.Coordinates[0, 0];
        int xOfTile = signToStepOn.Coordinates[0, 1];

        return yOfTile - signToStepOn.DirectionY != y || xOfTile + signToStepOn.DirectionX != x;
    }

    public void AddRoute(FieldSign nextRoute, int currentWalkedSteps)
    {
        Person copiedPerson = new Person(nextRoute.Coordinates, currentWalkedSteps);
        nextRoute.SteppedOn(copiedPerson);
        _routesList.Add(copiedPerson);
    }
}
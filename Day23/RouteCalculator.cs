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
        foreach (var possibleRoute in possibleRoutesList)
        {
            while (!possibleRoute.ReachedEnd || !possibleRoute.CrossedBetterOrEqualWay)
            {
                FieldSign[] possibleMoves = GetNextFields(possibleRoute.CurrentPosition, gameField);

                for (int possibleMove = 1; possibleMove != possibleMoves.Length; possibleMove++)
                {
                    AddRoute(possibleRoute);
                }

                possibleMoves[0].SteppedOn(possibleRoute);
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

        if (x - 1 >= 0 && gameField[y, x - 1].GetType() == typeof(EmptySpace) && !gameField[y, x - 1].IsStepped)
            nextFields.Add(gameField[y, x - 1]);

        if (x + 1 < gameField.GetLength(1) && gameField[y, x + 1].GetType() == typeof(EmptySpace) && !gameField[y, x + 1].IsStepped)
            nextFields.Add(gameField[y, x + 1]);

        if (y - 1 >= 0 && gameField[y - 1, x].GetType() == typeof(EmptySpace) && !gameField[y - 1, x].IsStepped)
            nextFields.Add(gameField[y - 1, x]);

        if (y + 1 < gameField.GetLength(0) && gameField[y + 1, x].GetType() == typeof(EmptySpace) && !gameField[y + 1, x].IsStepped)
            nextFields.Add(gameField[y + 1, x]);

        return nextFields.ToArray();
    }

    public void AddRoute(Person currentRoute)
    {
        _routesList.Insert(_routesList.Count - 1, new Person(currentRoute.CurrentPosition, currentRoute.CurrentWalkedSteps));
    }
}
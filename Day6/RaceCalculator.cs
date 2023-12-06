internal class RaceCalculator
{
    public int Result { get; }

    public RaceCalculator(Dictionary<int, int> raceData)
    {
        Result = Calculate(raceData);
    }

    private int Calculate(Dictionary<int, int> raceData) => IterateThroughGame(raceData);

    private int IterateThroughGame(Dictionary<int, int> raceData)
    {
        List<int> possibleWins = new List<int>();
        foreach (var distanceToTime in raceData)
        {
            int wonMatches = 0;
            for (int time = distanceToTime.Value; time > 0; time--)
            {
                int mmPerMilliSecond = distanceToTime.Value - time;
                int timeLeft = distanceToTime.Value - mmPerMilliSecond;
                int distanceReached = 0;

                for (int i = timeLeft; timeLeft > 0; timeLeft--)
                {
                    distanceReached += mmPerMilliSecond;
                }
                if (distanceReached > distanceToTime.Key)
                {
                    wonMatches++;
                }
            }
            possibleWins.Add(wonMatches);
        }
        return possibleWins.Aggregate((x, y) => x * y);
    }
}
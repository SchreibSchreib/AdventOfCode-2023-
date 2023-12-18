using Day16;
using Day16.AbstractClasses;

internal class BeamEvaluator
{
    public int Get { get; }

    private List<LightBeam> _beamsList;
    private FieldSign[,] _gameField;


    public BeamEvaluator(LightBeam initialBeam, FieldSign[,] gameField)
    {
        _beamsList = new List<LightBeam>
        {
            initialBeam
        };
        _gameField = gameField;
        Get = EvaluateBeams(_beamsList, _gameField);
    }

    private int EvaluateBeams(List<LightBeam> beamsList, FieldSign[,] gameField)
    {
        gameField[0, 0].PowerField();

        while (beamsList.Count != 0)
        {
            for (int indexOfBeam = 0; indexOfBeam < _beamsList.Count(); indexOfBeam++)
            {
                LightBeam currentCheckedBeam = _beamsList[indexOfBeam];

                if (!currentCheckedBeam.HittedWall)
                {
                    currentCheckedBeam.Move(gameField);

                    if (currentCheckedBeam.Direction.Length > 1)
                    {
                        string[] directions = currentCheckedBeam.Direction.Split(',');
                        currentCheckedBeam.Direction = directions[0];
                        AddBeam(currentCheckedBeam.CurrentPosition, directions[1]);
                    }
                }
                else
                {
                    SubtractBeam(currentCheckedBeam);
                }
            }
            Console.WriteLine(CountLoadedFields(gameField));
        }
        return CountLoadedFields(gameField);
    }

    private int CountLoadedFields(FieldSign[,] gameField)
    {
        int result = 0;

        foreach (FieldSign fieldSign in gameField)
        {
            if (fieldSign.IsPowered)
            {
                result++;
            }
        }

        return result;
    }

    private void SubtractBeam(LightBeam currentCheckedBeam)
    {
        _beamsList.RemoveAt(_beamsList.IndexOf(currentCheckedBeam));
    }

    public void AddBeam(int[] positionOfBeam, string direction)
    {
        _beamsList.Insert(_beamsList.Count - 1,new LightBeam(positionOfBeam.ToArray(), direction));
    }
}
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

    private int EvaluateBeams(List<LightBeam> beamsList, char[,] gameField)
    {
        gameField[0,0]
        foreach (LightBeam beam in beamsList)
        {

        }
    }

    public void AddBeam(int[] positionOfBeam)
    {
        _beamsList.Add(new LightBeam(positionOfBeam));
    }
}
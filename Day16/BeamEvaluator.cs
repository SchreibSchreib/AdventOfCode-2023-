using Day16;

internal class BeamEvaluator
{
    public List<LightBeam> _beamsList { private get; set; }

    public BeamEvaluator(LightBeam initialBeam)
    {
        _beamsList = new List<LightBeam>();
    }
}
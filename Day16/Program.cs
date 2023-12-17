using Day16;

char[,] gameField = new Content().Get;

int[,] startPosition = new int[,]
{
    { 0,0 }
};

LightBeam initialBeam = new LightBeam(startPosition);
List<LightBeam> beams = new List<LightBeam>();
beams.Add(initialBeam);

foreach (LightBeam beam in beams)
{
    beam.Move();
}


using Day16;
using Day16.AbstractClasses;

char[,] gameFieldChars = new Content().Get;

FieldSign[,] gameField = new GameFieldConverter(gameFieldChars).Get;

int[] startPosition = new int[]
{
    0,0
};

LightBeam initialBeam = new LightBeam(startPosition);

int result = new BeamEvaluator(initialBeam, gameField).Get;



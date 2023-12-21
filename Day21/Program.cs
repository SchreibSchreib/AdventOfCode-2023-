using Day16.AbstractClasses;
using Day21;

FieldSign[,] gameField = new GameFieldConverter(new Content().Get).GetConverted;


List<FieldSign> fieldsToCheck = gameField
    .Cast<FieldSign>()
    .Where(f => f is StartField)
    .ToList();
int stepsToMake = 64;
int steps = 0;

while (steps++ < stepsToMake)
{
    fieldsToCheck = new BroadSearch(fieldsToCheck, gameField).UpdatedList;
}

int result = fieldsToCheck.Count;


Console.WriteLine();
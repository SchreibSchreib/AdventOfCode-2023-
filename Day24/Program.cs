using Day24;

var input = new Content().Get;
int result = 0;

for (int startFrom = 0; startFrom < input.Count; startFrom++)
{
    for (int calculateWith = startFrom; calculateWith < input.Count; calculateWith++)
    {
        if (startFrom == calculateWith)
            continue;

        var intersection = new Intersection(input[startFrom], input[calculateWith]);

        if (!intersection.IsInsideArea || intersection.CrossedInPast)
            continue;

        result++;
    }
}



Console.ReadLine();
using Day15;

string[] input = new Content().Get;

int endResult = 0;
Dictionary<string, List<string>>
boxes =
new Dictionary
<string, List<string>>();

foreach (string line in input)
{
    string nameBox;
    string letters;
    if (line.Contains('='))
    {
        letters =
        line.Split("=")[0];
    }
    else
    {
        letters =
        line.Split("-")[0];
    }


    int result = 0;
    foreach (char ch in letters)
    {
        result +=
        Convert.ToInt32(ch);
        result *= 17;
        result %= 256;
    }
    nameBox = $"Box {result}";
    List<string> listLens =
    new List<string>();
    if (!boxes.ContainsKey(nameBox))
    {
        boxes.Add
        (
            nameBox,
            listLens
        );
    }
}

foreach (string line in input)
{
    string nameBox;
    string letters;
    if (line.Contains('='))
    {
        letters =
        line.Split("=")[0];
    }
    else
    {
        letters =
        line.Split("-")[0];
    }


    int result = 0;
    foreach (char ch in letters)
    {
        result +=
        Convert.ToInt32(ch);
        result *= 17;
        result %= 256;
    }
    nameBox = $"Box {result}";
    List<string> entries =
    boxes[nameBox];
    string searchterm =
    (line.Contains("=")) ?
    line.Split("=")[0] + '=' :
    line.Split("-")[0] + '=';
    if (line.Contains("="))
    {
        bool hasInserted = false;
        for (int indexEntry = 0;
        indexEntry < entries.Count();
        indexEntry++)
        {
            if (entries[indexEntry]
               .Contains(searchterm))
            {
                entries[indexEntry] =
                line;
                hasInserted = true;
                break;
            }
        }
        if (!hasInserted)
        {
            entries.Add(line);
        }
    }
    else
    {
        for (int indexEntry = 0;
        indexEntry < entries.Count();
        indexEntry++)
        {
            if (entries[indexEntry]
               .Contains(searchterm))
            {
                entries.RemoveAt(indexEntry);
                break;
            }
        }
    }
}

endResult = 0;
foreach (var kvp in boxes)
{
    int slotNumber = 1;
    int boxValue =
    int.Parse(kvp.Key
    .Split(" ")[1] + 1);
    foreach (string entry in kvp.Value)
    {
        int focalLength =
        int.Parse(entry.Split("=")[1]);

        endResult +=
        boxValue *
        slotNumber++ *
        focalLength;
    }
}
Console.WriteLine(endResult);
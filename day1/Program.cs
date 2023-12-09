using Day1;

Content line = new Content();
List<int> convertedValues = new List<int>();

foreach (string wordLine in line.Get)
{
    Converter convertLine = new Converter(wordLine);

    convertedValues.Add(int.Parse(convertLine.GetNumber));
}

int result = convertedValues.Sum(x => x);

Console.WriteLine(result);
Console.ReadLine();
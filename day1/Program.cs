using Day1;

Content line = new Content();
List<int> convertedValues = new List<int>();

foreach (string wordLine in line.Get)
{
    Converter convertLine = new Converter(
        wordLine.FirstOrDefault(char.IsDigit) - '0',
        wordLine.Reverse().FirstOrDefault(char.IsDigit) - '0');

    convertedValues.Add(convertLine.GetNumber);
}

int result = convertedValues.Sum(x => x);

Console.WriteLine(result);
Console.ReadLine();
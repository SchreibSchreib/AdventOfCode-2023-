using day1;

Content line = new Content();
List<int> list = new List<int>();
int sum = 0;
foreach (string wordLine in line.Get)
{
    Converter2 convertedString = new Converter2(wordLine);
    string numbers = $"{ convertedString.FirstNumber}{convertedString.LastNumber}";
    list.Add(int.Parse(numbers));
    Console.WriteLine(sum += int.Parse(numbers));
}

int result = list.Sum(x => x);

Console.WriteLine(result);
Console.ReadLine();
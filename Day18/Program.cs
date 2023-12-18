using Day18;

string[] input = new Content().Get;

List<Tuple<string, int>> directionToNumber = new List<Tuple<string, int>>();

foreach (string line in input)
{
    directionToNumber.Add(new Tuple<string, int>(line.Split(' ')[0], int.Parse(line.Split(' ')[1])));
}


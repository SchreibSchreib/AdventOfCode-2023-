using day2;
using Day2;

Content input = new Content();
List<int> wonGames = new List<int>();

foreach (string line in input.Get)
{
    CubeCollection newGame = new CubeCollection(line);
    wonGames.Add(newGame.NumberOfPossibleGame);
}

Console.WriteLine(wonGames.Sum(x => x));

Console.ReadLine();
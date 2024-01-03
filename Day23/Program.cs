using Day23;

var input = new GameFieldConverter(new Content().Get).Get;

int[,] test = new int[,]
{
    {0,1}
};

var testPerson = new Person(test, 0);
input[0, 1].SteppedOn(testPerson);

int result = new RouteCalculator(testPerson,input).Get;

for (int i = 0; i < input.GetLength(0); i++)
{
    Console.WriteLine();
    for (int j = 0; j < input.GetLength(1); j++)
    {
        Console.Write(input[i,j].Symbol);
    }
}

Console.ReadLine();
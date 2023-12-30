using Day23;

var input = new GameFieldConverter(new Content().Get).Get;

int[,] test = new int[,]
{
    {0,1}
};

var testPerson = new Person(test, 0);
input[0, 1].SteppedOn(testPerson);

int result = new RouteCalculator(testPerson,input).Get;
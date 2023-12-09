using Day9;

Content input = new Content();
int result = 0;

foreach (string line in input.Get)
{
    ArrayBuilder listOfNumbers = new ArrayBuilder(line);
    ExpressionExtrapolator extrapolate = new ExpressionExtrapolator(listOfNumbers.Get);
    result += extrapolate.Result;
}

Console.WriteLine(result);
Console.ReadLine();

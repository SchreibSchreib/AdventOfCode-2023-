using Day9;

Content input = new Content();
int result = 0;

foreach (string line in input.Get)
{
    ListBuilder listOfNumbers = new ListBuilder(line);
    ExpressionExtrapolator extrapolate = new ExpressionExtrapolator(listOfNumbers.Get);
    result += extrapolate.Result;
}

Console.WriteLine(result);
Console.ReadLine();

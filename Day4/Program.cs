using Day4;

Content input = new Content();
int pointsTotal = 0;

for (int indexInput = 0; indexInput < input.Get.Count; indexInput++)
{
    HandCards handCards = new HandCards(input.Get[indexInput].Split("|")[1]);
    WinningNumbers winningNumbers = new WinningNumbers(input.Get[indexInput].Split("|")[0]);
    int points = 0;

    foreach (int handcard in handCards.Get)
    {
        foreach (int winCard in winningNumbers.Get)
        {
            if (handcard == winCard && points == 0)
            {
                points = 1;
                Console.WriteLine("+1");
            }
            else if (handcard == winCard)
            {
                points *= 2;
                Console.WriteLine("*2");
            }
        }
    }
    pointsTotal += points;
}
Console.WriteLine(pointsTotal);

Console.ReadLine();

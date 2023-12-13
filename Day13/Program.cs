using Day13;

Content input = new Content();
int result = 0;

foreach (string[] block in input.Get)
{
    result += new MirrorCalculator(block).Result;
} 

Console.ReadLine();

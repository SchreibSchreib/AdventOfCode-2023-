using Day13;

Content inputBlock = new Content();
int result = 0;

foreach (string[] block in inputBlock.Get)
{
    result += new MirrorCalculator(block).Result;
} 

Console.ReadLine();

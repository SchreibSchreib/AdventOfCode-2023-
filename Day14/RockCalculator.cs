using System.Reflection.Metadata.Ecma335;

internal class RockCalculator
{
    private string[] _input;

    public int Get { get; }

    public RockCalculator(string[] input)
    {
        _input = input;
        Get = CalculateResult(_input);
    }

    private int CalculateResult(string[] input)
    {
        string[] rearrangedInput = Rearrange(input);
        int result = CalculatePoints(rearrangedInput);
        return result;
    }

    private int CalculatePoints(string[] rearrangedInput)
    {
        int result = 0;

        foreach (string line in rearrangedInput)
        {
            for (int indexChar = line.Length - 1; indexChar >= 0; indexChar--)
            {
                if (line[indexChar] == 'O')
                {
                    result += indexChar + 1;
                    Console.WriteLine($"Calculated Sum : {result}");
                }
            }
        }
        return result;
    }

    private string[] Rearrange(string[] input)
    {
        string[] result = new string[input.Length];

        for (int lineIndex = 0; lineIndex < result.Length; lineIndex++)
        {
            string currentLine = input[lineIndex].Replace("O.", ".O");

            for (int charIndex = 0; charIndex < input[lineIndex].Length; charIndex++)
            {
                if (currentLine.Contains("O."))
                {
                    currentLine = currentLine.Replace("O.", ".O");
                }
                else
                {
                    result[lineIndex] = currentLine;
                    break;
                }
            }
        }
        return result;
    }
}
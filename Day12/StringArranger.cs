using Day12;
using System.ComponentModel;
using System.Text;

internal class StringArranger
{
    private Content _input;

    public List<int> Count { get; }

    public StringArranger(Content input)
    {
        _input = input;
        Count = GetPossibleStrings(input);
    }

    private List<int> GetPossibleStrings(Content input)
    {
        List<int> result = new List<int>();

        foreach (Tuple<string, int[]> entry in input.Get)
        {
            result.Add(GetPossiblePermutations(entry));
        }

        return result;
    }

    private int GetPossiblePermutations(Tuple<string, int[]> entry)
    {
        string inputLine = entry.Item1;
        List<string> permutations = GeneratePermutations(inputLine);
        foreach (string line in  permutations)
        {
            Console.WriteLine(line);
        }
        int counter = 0;

        return counter;
    }

    private List<string> GeneratePermutations(string inputLine)
    {
        List<char> chars = new List<char>(inputLine.ToArray());
        List<string> allPermutations = Permutations(chars).Distinct().OrderBy(c => c).ToList();

        return allPermutations;
    }

    static IEnumerable<string>
    Permutations(List<char> chars)
    {
        if (chars.Count() == 0)
        {
            yield return "";
        }
        foreach (char ch in chars.ToList())
        {
            chars.Remove(ch);

            foreach (string line in Permutations(chars))
            {
                yield return ch + line;
            }
            chars.Add(ch);
        }
    }
}
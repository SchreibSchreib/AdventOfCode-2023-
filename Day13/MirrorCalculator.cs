using Day13;
using System.Collections;
using System.Collections.Generic;
using System.Text;

internal class MirrorCalculator
{
    private string[] _inputBlock;

    public int Result { get; }

    public MirrorCalculator(string[] inputBlock)
    {
        _inputBlock = inputBlock;
        Result = CalculateNumber();
    }

    private int CalculateNumber()
    {
        int result = (IsVertical(out int indexOfMirror))
            ? GetVerticalResult(indexOfMirror)
            : GetHorizontalResult();

        return result;
    }

    private bool IsVertical(out int indexOfMirror)
    {
        indexOfMirror = 0;
        int lineNumber = -1;
        Dictionary<int, List<int>> lineNumberToMirrorIndex = new Dictionary<int, List<int>>();
        foreach (string line in _inputBlock)
        {
            List<int> indexBeforeMirror = new List<int>();

            for (int indexLine = 0; indexLine < line.Length; indexLine++)
            {
                if (indexLine + 1 != line.Length)
                {
                    if (line[indexLine] == line[indexLine + 1])
                    {
                        indexBeforeMirror.Add(indexLine);
                    }
                }
            }
            lineNumberToMirrorIndex.Add(++lineNumber, indexBeforeMirror);
        }

        int[] commonElements = lineNumberToMirrorIndex.Values
            .SelectMany(x => x)
            .GroupBy(x => x)
            .Where(group => group.Count() == lineNumberToMirrorIndex.Count)
            .Select(group => group.Key)
            .ToArray();

        List<bool> allMirrors = new List<bool>();
        foreach (int indexToSplit in commonElements)
        {
            if (allMirrors.Count(x => x).Equals(_inputBlock.Length))
            {
                break;
            }
            allMirrors.Clear();
            bool isMirror = true;
            foreach (string line in _inputBlock)
            {
                int mirrorIndex = line.Length - 1 - indexToSplit;
                string firstPart = line.Remove(indexToSplit + 1);
                string secondPart = line.Substring(indexToSplit + 1);
                if (firstPart.Length < secondPart.Length)
                {
                    secondPart = secondPart.Remove(indexToSplit + 1);
                }
                if (firstPart.Length > secondPart.Length)
                {
                    firstPart = firstPart.Substring(firstPart.Length - secondPart.Length);
                }
                string mirroredFirstPart = new string(firstPart.Reverse().ToArray());

                if (secondPart != mirroredFirstPart)
                {
                    isMirror = false;
                    break;
                }
                indexOfMirror = indexToSplit;
                allMirrors.Add(isMirror);
            }
        }

        return allMirrors.Count(x => x).Equals(_inputBlock.Length);
    }

    private int GetVerticalResult(int indexOfMirror) => indexOfMirror + 1;

    private int GetHorizontalResult()
    {
        string[] turnedInputBlock = TurnInputBlock(_inputBlock);
        _inputBlock = turnedInputBlock;
        IsVertical(out int indexOfMirror);

        return (indexOfMirror + 1) * 100;
    }

    private string[] TurnInputBlock(string[] inputBlock)
    {

        string[] turnInputNinetyDegree = new string[inputBlock[0].Length];

        for (int indexOnLine = 0; indexOnLine < turnInputNinetyDegree.Length; indexOnLine++)
        {
            StringBuilder convertInput = new StringBuilder();

            foreach (string line in _inputBlock)
            {
                convertInput.Append(line[indexOnLine]);
            }

            turnInputNinetyDegree[indexOnLine] = convertInput.ToString();
        }

        return turnInputNinetyDegree;
    }
}
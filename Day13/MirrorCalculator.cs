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

    private int GetHorizontalResult() => FindMirrorLineIndex() * 100;

    private int FindMirrorLineIndex()
    {
        int columnAdded = 0;
        bool isTrueMirror = false;
        List<string> lines = new List<string>();

        foreach (string column in _inputBlock)
        {
            if (lines.Count - 1 < 0)
            {
                columnAdded++;
                lines.Add(column);
                continue;
            }
            if (lines.Count == _inputBlock.Length)
            {
                continue;
            }
            if (lines[lines.Count - 1] == column)
            {
                if (CheckMirror(lines.Count, _inputBlock))
                {
                    return columnAdded;
                }
            }
            columnAdded++;
            lines.Add(column);
        }
        return 0;
    }

    private bool CheckMirror(int count, string[] inputBlock)
    {
        List<string> lines = new List<string>();
        List<string> secondLines = new List<string>();
        List<string> mirroredLines = new List<string>();

        for (int indexList = 0; indexList < count; indexList++)
        {
            lines.Add(inputBlock[indexList]);
        }
        for (int indexList = count; indexList < count + indexList; indexList++)
        {
            if (indexList != inputBlock.Length)
            {
                secondLines.Add(inputBlock[indexList]);
            }
            else
            {
                break;
            }
        }
        foreach (string line in secondLines)
        {
            mirroredLines.Insert(0, line);
        }

        if (mirroredLines.Count < lines.Count) 
        {
            lines.RemoveRange(mirroredLines.Count - 1, lines.Count - mirroredLines.Count);
        }
        if (mirroredLines.Count > lines.Count)
        {
            mirroredLines.RemoveRange(lines.Count - 1, mirroredLines.Count - lines.Count);
        }

        return lines.SequenceEqual(secondLines);
    }
}
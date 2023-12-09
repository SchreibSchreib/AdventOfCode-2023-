namespace Day9
{
    internal class NumberAdder
    {
        public Dictionary<int, List<int>> Get { get; }

        public NumberAdder(Dictionary<int, List<int>> dictionaryAllLines)
        {
            Get = GetAddedNumberForFirstLine(dictionaryAllLines);
        }

        private Dictionary<int, List<int>> GetAddedNumberForFirstLine(Dictionary<int, List<int>> dictionaryAllLines)
        {
            dictionaryAllLines = AddNeededNumbers(dictionaryAllLines);
            return dictionaryAllLines;
        }

        private Dictionary<int, List<int>> AddNeededNumbers(Dictionary<int, List<int>> dictionaryAllLines)
        {
            for (int i = dictionaryAllLines.Count - 1; i >= 0; i--)
            {
                if (dictionaryAllLines[i].All(x => x == 0))
                {
                    dictionaryAllLines[i].Add(0);
                    continue;
                }
                dictionaryAllLines[i] = AddNewNumber(dictionaryAllLines[i], dictionaryAllLines[i + 1]);
            }
            return dictionaryAllLines;
        }

        private List<int> AddNewNumber(List<int> listToInsert, List<int> listForCalculation)
        {
            listToInsert.Add(listForCalculation.Last() + listToInsert.Last());
            return listToInsert;
        }
    }
}
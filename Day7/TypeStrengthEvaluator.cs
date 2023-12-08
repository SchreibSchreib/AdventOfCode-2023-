using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    internal class TypeStrengthEvaluator
    {
        public Dictionary<string, int> GetHandCardsWithMultiplicator { get; }

        public TypeStrengthEvaluator(Dictionary<string, List<string>> handTypesAndOccurences)
        {
            GetHandCardsWithMultiplicator = EvaluateCardsToMultiplicator(handTypesAndOccurences);
        }

        private Dictionary<string, int> EvaluateCardsToMultiplicator(Dictionary<string, List<string>> handTypesAndOccurences)
        {
            Dictionary<string, int> handCardsWithMultiplicator = new Dictionary<string, int>();
            int highestStrengthOfType = 0;

            foreach (KeyValuePair<string, List<string>> handCardsType in handTypesAndOccurences)
            {
                handCardsType.Value.Sort(ComparePokerHands);

                for (int i = 0; i < handCardsType.Value.Count; i++)
                {
                    int multiplicator = i + 1;

                    handCardsWithMultiplicator.Add(handCardsType.Value[i], multiplicator + highestStrengthOfType);
                    if (i == handCardsType.Value.Count - 1)
                    {
                        highestStrengthOfType += multiplicator;
                    }
                }
            }
            return handCardsWithMultiplicator;
        }
        private int ComparePokerHands(string hand1, string hand2)
        {
            string cardOrder = "23456789TJQKA";

            for (int i = 0; i < Math.Min(hand1.Length, hand2.Length); i++)
            {
                int index1 = cardOrder.IndexOf(hand1[i]);
                int index2 = cardOrder.IndexOf(hand2[i]);

                if (index1 < index2)
                    return -1;
                else if (index1 > index2)
                    return 1;
            }
            return hand1.Length.CompareTo(hand2.Length);
        }
    }
}

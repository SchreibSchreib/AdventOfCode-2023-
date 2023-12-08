using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    internal class HandCardTypeEvaluator
    {
        public Dictionary<string, List<string>> GetTypeOfHandsAndOccurences { get; }

        public HandCardTypeEvaluator(Dictionary<string, int> handAndPointPair)
        {
            GetTypeOfHandsAndOccurences = EvaluateHands(handAndPointPair);
        }

        private Dictionary<string, List<string>> EvaluateHands(Dictionary<string, int> handAndPointPair)
        {
            List<string> highCard = new List<string>();
            List<string> pair = new List<string>();
            List<string> twoPairs = new List<string>();
            List<string> threeOfAKind = new List<string>();
            List<string> fullHouse = new List<string>();
            List<string> fourOfAKind = new List<string>();
            List<string> fiveOfAKind = new List<string>();

            foreach (KeyValuePair<string, int> currentHandAndPoints in handAndPointPair)
            {
                HandType handType = GetHandType(currentHandAndPoints.Key);

                switch (handType)
                {
                    case HandType.HighCard:
                        highCard.Add(currentHandAndPoints.Key);
                        break;
                    case HandType.Pair:
                        pair.Add(currentHandAndPoints.Key);
                        break;
                    case HandType.TwoPairs:
                        twoPairs.Add(currentHandAndPoints.Key);
                        break;
                    case HandType.ThreeOfAKind:
                        threeOfAKind.Add(currentHandAndPoints.Key);
                        break;
                    case HandType.FourOfAKind:
                        fourOfAKind.Add(currentHandAndPoints.Key);
                        break;
                    case HandType.FullHouse:
                        fullHouse.Add(currentHandAndPoints.Key);
                        break;
                    case HandType.FiveOfAKind:
                        fiveOfAKind.Add(currentHandAndPoints.Key);
                        break;
                }
            }

            return new Dictionary<string, List<string>>
            {
                { "highCard", highCard },
                { "pair", pair },
                { "twoPairs", twoPairs },
                { "threeOfAKind", threeOfAKind },
                { "fullHouse", fullHouse },
                { "fourOfAKind", fourOfAKind },
                { "fiveOfAKind", fiveOfAKind }
            };
        }

        private HandType GetHandType(string hand)
        {
            var occurrences = hand.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());

            if (IsHighCard(occurrences.Count))
            {
                return HandType.HighCard;
            }
            else if (IsPair(occurrences.Count))
            {
                return HandType.Pair;
            }
            else if (IsTwoPairsOrThreeOfAKind(occurrences.Count))
            {
                foreach (var pair in occurrences)
                {
                    if (pair.Value == 2)
                    {
                        return HandType.TwoPairs;
                    }
                    else if (pair.Value == 3)
                    {
                        return HandType.ThreeOfAKind;
                    }
                    continue;
                }

            }
            else if (IsFullHouseOrFourOfAKind(occurrences.Count))
            {
                if (occurrences.Values.First() == 4 || occurrences.Values.First() == 1)
                {
                    return HandType.FourOfAKind;
                }
                return HandType.FullHouse;
            }

            return HandType.FiveOfAKind;
        }

        private enum HandType
        {
            HighCard,
            Pair,
            TwoPairs,
            ThreeOfAKind,
            FourOfAKind,
            FullHouse,
            FiveOfAKind
        }

        private bool IsHighCard(int handCardCount) => handCardCount == 5;

        private bool IsPair(int handCardCount) => handCardCount == 4;

        private bool IsTwoPairsOrThreeOfAKind(int handCardCount) => handCardCount == 3;

        private bool IsFullHouseOrFourOfAKind(int handCardCount) => handCardCount == 2;
    }
}

namespace AdventOfCode
{
    [Day(7, "Camel Cards")]
    internal class Day7
    {

        [Solution("A")]
        public static string SolutionA(string input)
        {
            return "" + input.Split(Environment.NewLine).Select(x => ReadLine(x)).Select(DefineHand).OrderBy(x => x.Item1).ThenBy(x => x.Item2).Select((x,i) => (x.Item3 * (i+1))).Sum();
        }

        [Solution("B")]
        public static string SolutionB(string input)
        {
            return "" + input.Split(Environment.NewLine).Select(x => ReadLine(x, true)).Select(DefineHand).OrderBy(x => x.Item1).ThenBy(x => x.Item2).Select((x, i) => (x.Item3 * (i + 1))).Sum();
        }

        private static (HandString, long) ReadLine(string line, bool isJokerVariant = false) => (new HandString() { Hand = line.Split(" ")[0], IsJoker = isJokerVariant }, long.Parse(line.Split(" ")[1]));

        private static (HandType, HandString, long) DefineHand((HandString, long) hand)
        {
            var handString = hand.Item1.Hand;
            var jokerCount = handString.Count(x => x == 'J');
            if(hand.Item1.IsJoker)
            {
                handString = handString.Replace("J", "");
            }
            var handValuesSorted = handString.ToCharArray().ToList();
            handValuesSorted.Sort();
            var handValuesCount = handValuesSorted.GroupBy(i => i);
            var valuesCountSorted = handValuesCount.Select(i => i.Count()).ToList();
            valuesCountSorted.Sort();
            var count = valuesCountSorted.Count;
            var top1Count = (count > 0 ? valuesCountSorted[count - 1] : 0) + (hand.Item1.IsJoker ? jokerCount : 0);
            var top2Count = count > 1 ? valuesCountSorted[count - 2] : 0;
            var top3Count = count > 2 ? valuesCountSorted[count - 3] : 0;
            var top4Count = count > 3 ? valuesCountSorted[count - 4] : 0;
            var top5Count = count > 4 ? valuesCountSorted[count - 5] : 0;

            switch ((top1Count, top2Count, top3Count, top4Count, top5Count))
            {
                case (5, 0, 0, 0, 0):
                    return (HandType.FiveOfAKind, hand.Item1, hand.Item2);
                case (4, 1, 0, 0, 0):
                    return (HandType.FourOfAKind, hand.Item1, hand.Item2);
                case (3, 2, 0, 0, 0):
                    return (HandType.FullHouse, hand.Item1, hand.Item2);
                case (3, 1, 1, 0, 0):
                    return (HandType.ThreeOfAKind, hand.Item1, hand.Item2);
                case (2, 2, 1, 0, 0):
                    return (HandType.TwoPair, hand.Item1, hand.Item2);
                case (2, 1, 1, 1, 0):
                    return (HandType.OnePair, hand.Item1, hand.Item2);
                case (1, 1, 1, 1, 1):
                    return (HandType.BitchAssHand, hand.Item1, hand.Item2);
            }
            return (HandType.BitchAssHand, hand.Item1, hand.Item2);
        }

        private static (HandType, HandString, long) PrintHand((HandType, HandString, long) hand)
        {
            Console.WriteLine($"{hand.Item1} {hand.Item2.Hand} {hand.Item3}");
            return hand;
        }

        private class HandString : IComparable<HandString>
        {
            public string Hand { get; set; }
            public bool IsJoker { get; set; }

            public int CompareTo(HandString other)
            {
                for(int i = 0; i < Hand.Length; i++)
                {
                    if (!IsJoker)
                    {
                        if (CharToValue[Hand[i]] > CharToValue[other.Hand[i]])
                        {
                            return 1;
                        }
                        else if (CharToValue[Hand[i]] < CharToValue[other.Hand[i]])
                        {
                            return -1;
                        }
                    }
                    else
                    {
                        if (CharToValueJokerVariant[Hand[i]] > CharToValueJokerVariant[other.Hand[i]])
                        {
                            return 1;
                        }
                        else if (CharToValueJokerVariant[Hand[i]] < CharToValueJokerVariant[other.Hand[i]])
                        {
                            return -1;
                        }
                    }
                }
                return 0;
            }

            private Dictionary<char, int> CharToValue = new Dictionary<char, int>()
            {
                { 'A', 14 }, { 'K', 13 }, { 'Q', 12 }, { 'J', 11 }, { 'T', 10 }, { '9', 9 }, { '8', 8 }, { '7', 7 }, { '6', 6 },{ '5', 5 },{ '4', 4 },{ '3', 3 },{ '2', 2 },
            };
            private Dictionary<char, int> CharToValueJokerVariant = new Dictionary<char, int>()
            {
                { 'A', 14 }, { 'K', 13 }, { 'Q', 12 }, { 'J', 1 }, { 'T', 10 }, { '9', 9 }, { '8', 8 }, { '7', 7 }, { '6', 6 },{ '5', 5 },{ '4', 4 },{ '3', 3 },{ '2', 2 },
            };
        }

        enum HandType : int { BitchAssHand, OnePair, TwoPair, ThreeOfAKind, FullHouse, FourOfAKind, FiveOfAKind}
    }
}

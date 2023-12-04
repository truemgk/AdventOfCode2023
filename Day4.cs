namespace AdventOfCode
{
    [Day(4, "Scratchcards")]
    public class Day4
    {
        [Solution("A")]
        public static string SolutionA(string input)
        {
            return "" + input.Split(Environment.NewLine).ToList().Select(ExtractCardData).Select(CalculateScore).Sum();
        }

        [Solution("B")]
        public static string SolutionB(string input)
        {
            var cards = input.Split(Environment.NewLine).ToList().Select(ExtractCardData).Select(c => (CalculateAmount(c), 1)).ToList();
            for (int i = 0; i < cards.Count; i++)
            {
                for(int j = i+1; j <= i + cards[i].Item1 && j < cards.Count; j++)
                {
                    cards[j] = (cards[j].Item1, cards[j].Item2 + cards[i].Item2);
                }
            }
            return "" + cards.Select(c => c.Item2).Sum();
        }

        private static (int, List<int>, List<int>) ExtractCardData(string line)
        {
            var cardNumber = int.Parse(HardTrim(line.Split(":")[0].Split(" ").Last()));
            var winningNumber = line.Split(":")[1].Split("|")[0].Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(int.Parse).ToList();
            var ourNumber = line.Split(":")[1].Split("|")[1].Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(int.Parse).ToList();
            return (cardNumber, winningNumber, ourNumber);
        }

        private static string HardTrim(string input) => input.Replace(" ", "");

        private static int CalculateAmount((int cardNumber, List<int> winningNumber, List<int> ourNumber) input) => input.winningNumber.Intersect(input.ourNumber).Count();

        private static int CalculateScore((int cardNumber, List<int> winningNumber, List<int> ourNumber) input)
        {
            var power = CalculateAmount(input);
            return power == 0? 0: (int)Math.Pow(2, power-1);
        }
    }
}

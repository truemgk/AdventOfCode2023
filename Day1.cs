using System.Text.RegularExpressions;

namespace AdventOfCode
{
    [Day(1, "Trebuchet")]
    internal class Day1
    {
        [Solution("A")]
        public static string SolutionA(string input)
        {
            Regex regex = new(@"[^0-9]");

            var lines = input.Split("\n");
            var total = 0;
            foreach (var line in lines)
            {
                var mline = regex.Replace(line, "");
                var dub = "" + mline.First() + mline.Last();
                var num = int.Parse(dub);
                total += num;
            }

            return "" + total;
        }

        [Solution("B")]
        public static string SolutionB(string input)
        {
            var lines = input.Split("\n");
            var total = 0;
            var regreplace = new Dictionary<Regex, string> { { new(@"one"), "one1one" }, { new(@"two"), "two2two" }, { new(@"three"), "three3three" }, { new(@"four"), "four4four" }, { new(@"five"), "five5five" }, { new(@"six"), "six6six" }, { new(@"seven"), "seven7seven" }, { new(@"eight"), "eight8eight" }, { new(@"nine"), "nine9nine" }, { new(@"[^1-9]"), ""} };

            foreach (var line in lines)
            {
                var mline = line;
                foreach (var item in regreplace)
                {
                    mline = item.Key.Replace(mline, item.Value);
                }
                var dub = "" + mline.First() + mline.Last();
                var num = int.Parse(dub);
                total += num;
            }

            return "" + total;
        }
    }
}

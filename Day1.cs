using System.Text.RegularExpressions;

namespace AdventOfCode
{
    [Day(1, "Trebuchet")]
    internal class Day1
    {
        [Solution("Regex - Part one")]
        public static string Regx(string input)
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

        [Solution("Trebuchet - Regex - now with words")]
        public static string SolutionPart2(string input)
        {
            var lines = input.Split("\n");
            var total = 0;
            Regex numbers = new(@"[^0-9]");
            Regex one = new(@"one");
            Regex two = new(@"two");
            Regex three = new(@"three");
            Regex four = new(@"four");
            Regex five = new(@"five");
            Regex six = new(@"six");
            Regex seven = new(@"seven");
            Regex eight = new(@"eight");
            Regex nine = new(@"nine");

            foreach (var line in lines)
            {
                var mline = one.Replace(line, "1");
                mline = two.Replace(mline, "2");
                mline = three.Replace(mline, "3");
                mline = four.Replace(mline, "4");
                mline = five.Replace(mline, "5");
                mline = six.Replace(mline, "6");
                mline = seven.Replace(mline, "7");
                mline = eight.Replace(mline, "8");
                mline = nine.Replace(mline, "9");
                mline = numbers.Replace(mline, "");

                var dub = "" + mline.First() + mline.Last();
                var num = int.Parse(dub);
                total += num;
            }

            return "" + total;
        }
    }
}

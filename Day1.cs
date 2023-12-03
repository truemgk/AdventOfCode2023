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
            Regex numbers = new(@"[^1-9]");
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
                var mline = one.Replace(line, "one1one");
                Console.WriteLine(mline);
                mline = two.Replace(mline, "two2two");
                Console.WriteLine(mline);

                mline = three.Replace(mline, "three3three");
                Console.WriteLine(mline);

                mline = four.Replace(mline, "four4four");
                Console.WriteLine(mline);

                mline = five.Replace(mline, "five5five");
                Console.WriteLine(mline);

                mline = six.Replace(mline, "six6six");
                Console.WriteLine(mline);

                mline = seven.Replace(mline, "seven7seven");
                Console.WriteLine(mline);

                mline = eight.Replace(mline, "eight8eight");
                Console.WriteLine(mline);

                mline = nine.Replace(mline, "nine9nine");
                Console.WriteLine(mline);

                mline = numbers.Replace(mline, "");
                Console.WriteLine(mline);


                var dub = "" + mline.First() + mline.Last();
                Console.WriteLine(dub);
                var num = int.Parse(dub);
                total += num;
            }

            return "" + total;
        }
    }
}

using System.Text.RegularExpressions;

namespace AdventOfCode
{
    [Day(3, "Gear Ratios")]
    internal class Day3
    {

        [Solution("Part one")]
        public static string PartOne(string input)
        {
            Regex numbers = new(@"[0-9]");
            var lines = input.Split("\n");
            var total = 0;
            var numberBuilder = "";
            bool isPartNumber = false;
            for(int y = 0; y < lines.Length; y++)
            {
                var line = lines[y];
                for(int x = 0; x < line.Length; x++)
                {
                    if (numbers.IsMatch(""+ line[x]))
                    {
                        numberBuilder += line[x];
                        //look around
                        var up = y > 0 ? lines[y - 1][x] : '.';
                        var down = y < lines.Length - 1 ? lines[y + 1][x] : '.';
                        var left = x > 0 ? lines[y][x - 1] : '.';
                        var right = x < line.Length - 1 ? lines[y][x + 1] : '.';
                        var upLeft = y > 0 && x > 0 ? lines[y - 1][x - 1] : '.';
                        var upRight = y > 0 && x < line.Length - 1 ? lines[y - 1][x + 1] : '.';
                        var downLeft = y < lines.Length - 1 && x > 0 ? lines[y + 1][x - 1] : '.';
                        var downRight = y < lines.Length - 1 && x < line.Length - 1 ? lines[y + 1][x + 1] : '.';

                        var idea = up + "" + down + "" + left + "" + right + "" + upLeft + "" + upRight + "" + downLeft + "" + downRight;

                        idea = numbers.Replace(idea, ".");
                        idea = idea.Replace(".", "");
                        //Console.WriteLine(idea + "   -   " + idea.Length + "  - -- --   " + numberBuilder);
                        if (idea.Length > 0)
                        {
                            isPartNumber = true;
                        }
                    }
                    else
                    {
                        if(isPartNumber)
                        {
                            total += int.Parse(numberBuilder);
                            Console.WriteLine("adding " + numberBuilder);
                            isPartNumber = false;
                        }
                        numberBuilder = "";
                    }
                }
            }
            return "" + total;
        }
    }
}

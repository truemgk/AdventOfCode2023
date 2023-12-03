namespace AdventOfCode
{
    [Day(2, "Cube Conundrum")]
    internal class Day2
    {
        [Solution("Part one")]
        public static string PartOne(string input)
        {
            // "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green"
            var lines = input.Split("\n");
            var total = 0;
            foreach (var line in lines)
            {
                var gameID = int.Parse(line.Split(":")[0].Replace("Game ", ""));

                var pulls = line.Split(":")[1].Split(";");
                foreach (var pull in pulls)
                {
                    var items = pull.Split(",");
                    foreach (var item in items)
                    {
                        var color = item.Trim().Split(" ")[1];
                        var count = int.Parse(item.Trim().Split(" ")[0]);
                        if (color == "red" && count > 12)
                        {
                            goto lineNotPossible;
                        }
                        if (color == "green" && count > 13)
                        {
                            goto lineNotPossible;
                        }
                        if (color == "blue" && count > 14)
                        {
                            goto lineNotPossible;
                        }
                    }
                }
                total+= gameID;
            lineNotPossible:
                continue;
            }
            return ""  + total;
        }

        [Solution("Part two")]
        public static string PartTwo(string input)
        {
            // "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green"
            var lines = input.Split("\n");
            var total = 0;
            foreach (var line in lines)
            {
                var pulls = line.Split(":")[1].Split(";");
                var maxRed = 0;
                var maxGreen = 0;
                var maxBlue = 0;
                foreach (var pull in pulls)
                {

                    var items = pull.Split(",");
                    foreach (var item in items)
                    {
                        var color = item.Trim().Split(" ")[1];
                        var count = int.Parse(item.Trim().Split(" ")[0]);
                        if (color == "red" && count > maxRed)
                        {
                            maxRed = count;
                        }
                        if (color == "green" && count > maxGreen)
                        {
                            maxGreen = count;

                        }
                        if (color == "blue" && count > maxBlue)
                        {
                            maxBlue = count;

                        }
                    }
                }
                total += maxRed * maxGreen * maxBlue;
            }
            return "" + total;
        }
    }
}

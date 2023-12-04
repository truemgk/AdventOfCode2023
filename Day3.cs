namespace AdventOfCode.inputs;

[Day(3, "Gear Ratio")]
public class Day3
{
    [Solution("A")]
    public static string SolutionA(string input)
    {
        List<Number> FilterNonParts(List<Number> numberMap, string input)
        {
            var returnValue = new List<Number>();
            var lines = input.Split(Environment.NewLine);
            foreach (var numberData in numberMap)
            {
                var x = numberData.X;
                var y = numberData.Y;
                var size = numberData.Size;
                var value = numberData.Value;

                var found = false;

                for (var cx = x - 1; cx <= x + size; cx++)
                {
                    for (var cy = y - 1; cy <= y + 1; cy++)
                    {
                        if (cy < 0 || cy >= lines.Length || cx < 0 || cx >= lines[cy].Length)
                        {
                            continue;
                        }

                        var character = lines[cy][cx];
                        if (character != '.' && !IsANumber(character))
                        {
                            found = true;
                            break;
                        }
                    }
                }

                if (found)
                {
                    returnValue.Add(new Number(x, y, size, value));
                }
            }

            return returnValue;
        }

        var numberMap = FindAllNumbers(input);
        var filtered = FilterNonParts(numberMap, input);

        var total = 0;
        foreach (var number in filtered)
        {
            total += number.Value;
        }

        return "" + total;
    }

    [Solution("B")]
    public static string SolutionB(string input)
    {
        List<Gear> GetAllGears(string input)
        {
            var lines = input.Split(Environment.NewLine);
            var returnValue = new List<Gear>();
            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    if (lines[y][x] == '*')
                    {
                        returnValue.Add(new Gear(x, y, 1, 0));
                    }
                }
            }
            return returnValue;
        }

        List<Gear> FindAllAdjacentNumbers(List<Gear> gears, List<Number> numbers)
        {
            var returnValue = new List<Gear>();
            foreach (var gear in gears)
            {
                var x = gear.X;
                var y = gear.Y;
                var value = 1;
                var count = 0;

                var found = false;

                foreach (var number in numbers)
                {
                    var nx = number.X;
                    var ny = number.Y;
                    var size = number.Size;
                    var nvalue = number.Value;

                    if (nx - 1<= x && x <= nx + size && ny - 1 <= y && y <= ny + 1)
                    {
                        value *= nvalue;
                        count += 1;
                    }
                }

                if (count == 2)
                {
                    returnValue.Add(new Gear(x, y, value, count));
                }
            }

            return returnValue;
        }


        var numberMap = FindAllNumbers(input);
        var gearMap = GetAllGears(input);
        var filtered = FindAllAdjacentNumbers(gearMap, numberMap);

        var total = 0;
        foreach (var gear in filtered)
        {
            total += gear.Value;
        }

        return "" + total;
    }

    static List<Number> FindAllNumbers(string input)
    {
        var returnValue = new List<Number>();
        var lines = input.Split(Environment.NewLine);
        var foundNumber = false;
        var fx = 0;
        var fy = 0;
        var fs = 0;
        var value = 0;
        for (int y = 0; y < lines.Length; y++)
        {
            for (int x = 0; x < lines[y].Length; x++)
            {
                if (foundNumber && IsANumber(lines[y][x]))
                {
                    fs += 1;
                    value = value * 10 + lines[y][x] - '0';
                }
                else if (IsANumber(lines[y][x]))
                {
                    fx = x;
                    fy = y;
                    fs = 1;
                    value = lines[y][x] - '0';
                    foundNumber = true;
                }
                else if (foundNumber)
                {
                    returnValue.Add(new Number(fx, fy, fs, value));
                    fx = 0;
                    fy = 0;
                    fs = 0;
                    value = 0;
                    foundNumber = false;
                }
            }
        }

        return returnValue;
    }

    static bool IsANumber(char test)
    {
        return test is >= '0' and <= '9';
    }

    record Number(int X, int Y, int Size, int Value);
    record Gear(int X, int Y, int Value, int Count);
}
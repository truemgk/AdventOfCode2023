namespace AdventOfCode
{
    [Day(5, "If You Give A Seed A Fertilizer")]
    internal class Day5
    {

        [Solution("A")]
        public static string SolutionA(string input)
        {
            var lowest = long.MaxValue;

            (List<long> seeds, List<List<RangeConversion>> ranges) = GetData(input);

            foreach (var seed in seeds)
            {
                var value = seed;
                foreach (var range in ranges)
                {
                    foreach (var conversion in range)
                    {
                        if (TryConvertRange(conversion, value, out var result))
                        {
                            value = result;
                            break;
                        }
                    }
                }

                if (value < lowest)
                {
                    lowest = value;
                }
            }

            return "" + lowest;
        }

        [Solution("B")]
        public static string SolutionB(string input)
        {
            var lowest = long.MaxValue;
            return "skipped";
            (List<long> seeds, List<List<RangeConversion>> ranges) = GetData(input);

            for(int i = 0; i < seeds.Count; i += 2)
            {
                for(long s = seeds[i]; s < seeds[i]+seeds[i+1]; s++)
                {
                    var value = s;
                    foreach (var range in ranges)
                    {
                        foreach (var conversion in range)
                        {
                            if (TryConvertRange(conversion, value, out var result))
                            {
                                value = result;
                                break;
                            }
                        }
                    }

                    if (value < lowest)
                    {
                        lowest = value;
                    }
                }
            }

            return "" + lowest;
        }

        public static (List<long> seeds, List<List<RangeConversion>> ranges) GetData(string input)
        {
            string[] lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            var seeds = new List<long>();
            var ranges = new List<List<RangeConversion>>();
            foreach (var line in lines)
            {
                if (line.Contains("seeds:"))
                {
                    seeds = line.Split(":")[1].Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(long.Parse).ToList();
                }
                else if (line.Contains("map:"))
                {
                    ranges.Add(new List<RangeConversion>());
                }
                else
                {
                    var values = line.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(long.Parse).ToList();
                    ranges.Last().Add(new RangeConversion(values[0], values[1], values[2]));
                }
            }

            return (seeds, ranges);
        }

        public static bool TryConvertRange(RangeConversion conversion, long value, out long result)
        {
            if(value >= conversion.start && value < conversion.start + conversion.length)
            {
                result = conversion.result + value - conversion.start;
                return true;
            }
            result = value;
            return false;
        }

        public record RangeConversion(long result, long start, long length);
    }
}

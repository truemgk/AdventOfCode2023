namespace AdventOfCode
{
    [Day(6, "Wait For It")]
    internal class Day6
    {
        [Solution("A")]
        public static string SolutionA(string input)
        {
            Dictionary<int, int> TimeDistance = new Dictionary<int, int>() { { 54, 446 }, { 81, 1292 }, { 70, 1035 }, { 88, 1007 }, };
            var total = 1;
            foreach (var item in TimeDistance)
            {
                var subtotal = 0;
                for(int i = 0; i < item.Key; i++)
                {
                    if(i * (item.Key - i) > item.Value)
                    {
                        subtotal++;
                    }
                    else if(subtotal > 0)
                    {
                        break;
                    }
                }
                if(subtotal > 0)
                {
                    total *= subtotal;
                }
            }
            return "" + total;
        }

        [Solution("B")]
        public static string SolutionB(string input)
        {
            Dictionary<long, long> TimeDistance = new Dictionary<long, long>() { { 54817088, 446129210351007 }, };
            var total = 1;
            foreach (var item in TimeDistance)
            {
                var subtotal = 0;
                for (long i = 0; i < item.Key; i++)
                {
                    if (i * (item.Key - i) > item.Value)
                    {
                        subtotal++;
                    }
                    else if (subtotal > 0)
                    {
                        break;
                    }
                }
                if (subtotal > 0)
                {
                    total *= subtotal;
                }
            }
            return "" + total;
        }
    }
}
